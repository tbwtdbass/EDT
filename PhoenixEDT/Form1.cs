using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PhoenixEDT
{
    public partial class Form1 : Form
    {
        List<String> EziDebitCustomerList = new List<string>();
        

        public Form1()
        {
            //EziDebit test env requires TLS 1.2
            System.Net.ServicePointManager.SecurityProtocol = System.Net.SecurityProtocolType.Tls12;
            InitializeComponent();
        }

        private void GetPaymentsBtn_Click(object sender, EventArgs e)
        {
            DateTime startTime = DateTime.Now;
            DateTime endTime;

            this.responseText.Text = "Querying service with..." + Environment.NewLine;

            PhoenixEDT.Ezidebit35nonpci.NonPCIServiceClient KFC = new Ezidebit35nonpci.NonPCIServiceClient();
            PhoenixEDT.Ezidebit35nonpci.EziResponseOfArrayOfPaymentTHgMB7oL CustomerPayments = new Ezidebit35nonpci.EziResponseOfArrayOfPaymentTHgMB7oL();

            if (radioButton1.Checked || radioButton2.Checked)
            {
                KFC.Open();


                if (radioButton1.Checked)
                {
                    this.responseText.Text = this.responseText.Text + Environment.NewLine + "GetPayments("+digitalKey.Text+", ALL, ALL, ALL, ,"+ dateFrom.Text+","+ dateTo.Text+", PAYMENT,"+ EziDebitSingleID.Text+", )" + Environment.NewLine;
                    CustomerPayments = KFC.GetPayments(digitalKey.Text, "ALL", "ALL", "ALL", "", dateFrom.Text, dateTo.Text, "PAYMENT", EziDebitSingleID.Text, "");
                }
                    
                if (radioButton2.Checked)
                {
                    this.responseText.Text = this.responseText.Text + Environment.NewLine + "GetPayments(" + digitalKey.Text + ", ALL, ALL, ALL, ," + dateFrom.Text + "," + dateTo.Text + ", SETTLEMENT," + EziDebitSingleID.Text + ", )" + Environment.NewLine;
                    CustomerPayments = KFC.GetPayments(digitalKey.Text, "ALL", "ALL", "ALL", "", dateFrom.Text, dateTo.Text, "SETTLEMENT", EziDebitSingleID.Text, "");
                }
                endTime = DateTime.Now;

                this.responseText.Text = this.responseText.Text + Environment.NewLine + "Time taken to retrieve payments was: " + (endTime - startTime).TotalMinutes.ToString() + " minutes. " + Environment.NewLine + Environment.NewLine;


                if (CustomerPayments.ErrorMessage == null && !serviceTimer.Checked)
                {
                      for (int i = 0; i < CustomerPayments.Data.Length; i++)
                    {
                        this.responseText.Text = this.responseText.Text + "Payment " + (i + 1).ToString() + Environment.NewLine +
                            "BankFailedReason = " + CustomerPayments.Data[i].BankFailedReason + " | BankReceiptID = " + CustomerPayments.Data[i].BankReceiptID
                            + " | BankReturnCode = " + CustomerPayments.Data[i].BankReturnCode + " | CustomerName = " + CustomerPayments.Data[i].CustomerName + " | DebitDate = "
                            + CustomerPayments.Data[i].DebitDate.ToString() + " | EziDebitCustomerID = " + CustomerPayments.Data[i].EzidebitCustomerID + " | InvoiceID = "
                            + CustomerPayments.Data[i].InvoiceID + " PaymentAmount = " + CustomerPayments.Data[i].PaymentAmount.ToString() + " | PaymentID = " + CustomerPayments.Data[i].PaymentID
                            + " | PaymentMethod = " + CustomerPayments.Data[i].PaymentMethod + " | PaymentReference = " + CustomerPayments.Data[i].PaymentReference + " | PaymentSource = " + CustomerPayments.Data[i].PaymentSource
                            + " | PaymentStatus = " + CustomerPayments.Data[i].PaymentStatus + " | ScheduledAmount = " + CustomerPayments.Data[i].ScheduledAmount.ToString() + " | SettlementDate = " + CustomerPayments.Data[i].SettlementDate.ToString()
                            + " | TransactionFeeClient = " + CustomerPayments.Data[i].TransactionFeeClient.ToString() + " | TransactionFeeCustomer = " + CustomerPayments.Data[i].TransactionFeeCustomer.ToString()
                            + " | TransactionTime = " + CustomerPayments.Data[i].TransactionTime.ToString() + " | YourGeneralReference = " + CustomerPayments.Data[i].YourGeneralReference + " | YourSystemReference = " + CustomerPayments.Data[i].YourSystemReference
                            + Environment.NewLine;
                    }
                }
                else this.responseText.Text = this.responseText.Text + Environment.NewLine+ "No payments for this ID, error received is:" + Environment.NewLine + Environment.NewLine + CustomerPayments.ErrorMessage;

                KFC.Close();
            }
            else this.responseText.Text = "Select PAYMENT or SETTLEMENT and try again..";

        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton1.Checked) radioButton2.Checked= false;
           
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton2.Checked) radioButton1.Checked= false;
            
        }

        private async void GetCustomerListBtn_Click(object sender, EventArgs e)
        {
            EziDebitCustomerList.Clear();
            progressBar1.Value = 0;
            GetCustomerListBtn.Enabled = false;

            this.responseText2.Text = "Customer list:" + Environment.NewLine + Environment.NewLine;
            PhoenixEDT.Ezidebit35nonpci.NonPCIServiceClient KFC = new Ezidebit35nonpci.NonPCIServiceClient();

            KFC.Open();
            
            PhoenixEDT.Ezidebit35nonpci.CustomerDetails CustomerDetailPage = new Ezidebit35nonpci.CustomerDetails();

            PhoenixEDT.Ezidebit35nonpci.EziResponseOfArrayOfCustomerTHgMB7oL CustomerDetailPageAwait = new Ezidebit35nonpci.EziResponseOfArrayOfCustomerTHgMB7oL();

            int i = Convert.ToInt32(textBox2.Text);

            if (!checkBox1.Checked)
                progressBar1.Maximum = i;
            else progressBar1.Maximum = 1;

            progressBar1.Step = 1;

            if(i>0 && i<101) 
            {
                if (!checkBox1.Checked)
                {
                    for (int j = 1; j <= i; j++) //get our pages
                    {

                        CustomerDetailPageAwait = await KFC.GetCustomerListAsync(digitalKey.Text, "", "", CustomerStatus.Text, "EzidebitCustomerID", "ASC", j);
                        if (CustomerDetailPageAwait.ErrorMessage == null)
                        {
                            //this.responseText.Text = this.responseText.Text + Environment.NewLine + "Page " + j.ToString() + " Count = " + CustomerDetailPageAwait.Data.Length.ToString() + Environment.NewLine; debug
                            for (int k = 0; k < CustomerDetailPageAwait.Data.Length; k++)
                            {
                                EziDebitCustomerList.Add(CustomerDetailPageAwait.Data[k].EzidebitCustomerID);
                                //this.responseText.Text = this.responseText.Text + Environment.NewLine + CustomerDetailPageAwait.Data[k].EzidebitCustomerID; for debug
                            }

                        }
                        progressBar1.PerformStep();
                    }
                }
                else
                {
                    CustomerDetailPageAwait = await KFC.GetCustomerListAsync(digitalKey.Text, "", "", CustomerStatus.Text, "EzidebitCustomerID", "ASC", i);
                    if (CustomerDetailPageAwait.ErrorMessage == null)
                    {
                        //this.responseText.Text = this.responseText.Text + Environment.NewLine + "Page " + j.ToString() + " Count = " + CustomerDetailPageAwait.Data.Length.ToString() + Environment.NewLine; debug
                        for (int k = 0; k < CustomerDetailPageAwait.Data.Length; k++)
                        {
                            EziDebitCustomerList.Add(CustomerDetailPageAwait.Data[k].EzidebitCustomerID);
                            //this.responseText.Text = this.responseText.Text + Environment.NewLine + CustomerDetailPageAwait.Data[k].EzidebitCustomerID; for debug
                        }

                    }
                    progressBar1.PerformStep();
                } 

                this.responseText2.Text = this.responseText2.Text + "There are " + EziDebitCustomerList.Count.ToString()+ " ID's" + Environment.NewLine + Environment.NewLine;
                foreach (string CID in EziDebitCustomerList)
                {
                    this.responseText2.Text = this.responseText2.Text + CID + Environment.NewLine;
                }
                
            }

            button1.Enabled = true;
            GetCustomerListBtn.Enabled = true;
            KFC.Close();
        }

        private async void button1_Click(object sender, EventArgs e)
        {
            DateTime startTime = DateTime.Now;
            DateTime endTime;

            int paymentsCount = 0;

            button1.Enabled = false;
            GetCustomerListBtn.Enabled = false;
            GetPaymentsBtn.Enabled = false;

            progressBar2.Value = 0;

            this.responseText.Text = "Getting Payments..." + Environment.NewLine;

            PhoenixEDT.Ezidebit35nonpci.NonPCIServiceClient KFC = new Ezidebit35nonpci.NonPCIServiceClient();
            PhoenixEDT.Ezidebit35nonpci.EziResponseOfArrayOfPaymentTHgMB7oL CustomerPayments = new Ezidebit35nonpci.EziResponseOfArrayOfPaymentTHgMB7oL();

            List<PhoenixEDT.Ezidebit35nonpci.EziResponseOfArrayOfPaymentTHgMB7oL> CustomerPaymentsList = new List<PhoenixEDT.Ezidebit35nonpci.EziResponseOfArrayOfPaymentTHgMB7oL>();
            
            progressBar2.Maximum = EziDebitCustomerList.Count;
            progressBar2.Step = 1;

            if (radioButton1.Checked || radioButton2.Checked)
            {
                KFC.Open();

                

                for (int j = 0; j < EziDebitCustomerList.Count; j++)
                {
                    if (radioButton1.Checked)
                    {
                        //this.responseText.Text = this.responseText.Text + Environment.NewLine + "GetPayments(" + digitalKey.Text + ", ALL, ALL, ALL, ," + dateFrom.Text + "," + dateTo.Text + ", PAYMENT," + EziDebitSingleID.Text + ", )" + Environment.NewLine;
                        //CustomerPayments = KFC.GetPayments(digitalKey.Text, "ALL", "ALL", "ALL", "", dateFrom.Text, dateTo.Text, "PAYMENT", EziDebitSingleID.Text, "");
                        CustomerPayments = await KFC.GetPaymentsAsync(digitalKey.Text, "ALL", "ALL", "ALL", "", dateFrom.Text, dateTo.Text, "PAYMENT", EziDebitCustomerList[j], "");
                    }

                    if (radioButton2.Checked)
                    {
                        //this.responseText.Text = this.responseText.Text + Environment.NewLine + "GetPayments(" + digitalKey.Text + ", ALL, ALL, ALL, ," + dateFrom.Text + "," + dateTo.Text + ", SETTLEMENT," + EziDebitSingleID.Text + ", )" + Environment.NewLine;
                        CustomerPayments = await KFC.GetPaymentsAsync(digitalKey.Text, "ALL", "ALL", "ALL", "", dateFrom.Text, dateTo.Text, "SETTLEMENT", EziDebitCustomerList[j], "");
                    }

                    if (CustomerPayments.ErrorMessage == null)
                    {
                        CustomerPaymentsList.Add(CustomerPayments);
                        paymentsCount = paymentsCount + CustomerPayments.Data.Length;
                    }
                    else
                        this.responseText.Text = this.responseText.Text + Environment.NewLine + "No payments for this ID ("+ EziDebitCustomerList[j]+"), error received is:" + Environment.NewLine + Environment.NewLine + CustomerPayments.ErrorMessage;
                    /* debug
                    if (CustomerPayments.ErrorMessage == null)
                    {
                        this.responseText.Text = this.responseText.Text + Environment.NewLine;
                        for (int i = 0; i < CustomerPayments.Data.Length; i++)
                        {
                            this.responseText.Text = this.responseText.Text + "Payment " + (i + 1).ToString() + Environment.NewLine +
                                "BankFailedReason = " + CustomerPayments.Data[i].BankFailedReason + " | BankReceiptID = " + CustomerPayments.Data[i].BankReceiptID
                                + " | BankReturnCode = " + CustomerPayments.Data[i].BankReturnCode + " | CustomerName = " + CustomerPayments.Data[i].CustomerName + " | DebitDate = "
                                + CustomerPayments.Data[i].DebitDate.ToString() + " | EziDebitCustomerID = " + CustomerPayments.Data[i].EzidebitCustomerID + " | InvoiceID = "
                                + CustomerPayments.Data[i].InvoiceID + " PaymentAmount = " + CustomerPayments.Data[i].PaymentAmount.ToString() + " | PaymentID = " + CustomerPayments.Data[i].PaymentID
                                + " | PaymentMethod = " + CustomerPayments.Data[i].PaymentMethod + " | PaymentReference = " + CustomerPayments.Data[i].PaymentReference + " | PaymentSource = " + CustomerPayments.Data[i].PaymentSource
                                + " | PaymentStatus = " + CustomerPayments.Data[i].PaymentStatus + " | ScheduledAmount = " + CustomerPayments.Data[i].ScheduledAmount.ToString() + " | SettlementDate = " + CustomerPayments.Data[i].SettlementDate.ToString()
                                + " | TransactionFeeClient = " + CustomerPayments.Data[i].TransactionFeeClient.ToString() + " | TransactionFeeCustomer = " + CustomerPayments.Data[i].TransactionFeeCustomer.ToString()
                                + " | TransactionTime = " + CustomerPayments.Data[i].TransactionTime.ToString() + " | YourGeneralReference = " + CustomerPayments.Data[0].YourGeneralReference + " | YourSystemReference = " + CustomerPayments.Data[i].YourSystemReference
                                + Environment.NewLine;
                        }
                    }
                    else this.responseText.Text = this.responseText.Text + Environment.NewLine + "No payments for this ID, error received is:" + Environment.NewLine + Environment.NewLine + CustomerPayments.ErrorMessage;
                    */
                    progressBar2.PerformStep();
                    paymentCountLabel.Text = "Payment Count: " + paymentsCount.ToString();
                }
                endTime = DateTime.Now;

                this.responseText.Text = this.responseText.Text + "Time taken to retrieve payments was: " + (endTime - startTime).TotalMinutes.ToString() + " minutes. " + Environment.NewLine+Environment.NewLine;

                KFC.Close();
                if (!serviceTimer.Checked)
                {
                    for (int a = 0; a < CustomerPaymentsList.Count; a++)
                    {
                        this.responseText.Text = this.responseText.Text + Environment.NewLine;

                        for (int i = 0; i < CustomerPaymentsList[a].Data.Length; i++)
                        {
                            this.responseText.Text = this.responseText.Text + "Payment " + (i + 1).ToString() + Environment.NewLine +
                                "BankFailedReason = " + CustomerPaymentsList[a].Data[i].BankFailedReason + " | BankReceiptID = " + CustomerPaymentsList[a].Data[i].BankReceiptID
                                + " | BankReturnCode = " + CustomerPaymentsList[a].Data[i].BankReturnCode + " | CustomerName = " + CustomerPaymentsList[a].Data[i].CustomerName + " | DebitDate = "
                                + CustomerPaymentsList[a].Data[i].DebitDate.ToString() + " | EziDebitCustomerID = " + CustomerPaymentsList[a].Data[i].EzidebitCustomerID + " | InvoiceID = "
                                + CustomerPaymentsList[a].Data[i].InvoiceID + " PaymentAmount = " + CustomerPaymentsList[a].Data[i].PaymentAmount.ToString() + " | PaymentID = " + CustomerPaymentsList[a].Data[i].PaymentID
                                + " | PaymentMethod = " + CustomerPaymentsList[a].Data[i].PaymentMethod + " | PaymentReference = " + CustomerPaymentsList[a].Data[i].PaymentReference + " | PaymentSource = " + CustomerPaymentsList[a].Data[i].PaymentSource
                                + " | PaymentStatus = " + CustomerPaymentsList[a].Data[i].PaymentStatus + " | ScheduledAmount = " + CustomerPaymentsList[a].Data[i].ScheduledAmount.ToString() + " | SettlementDate = " + CustomerPaymentsList[a].Data[i].SettlementDate.ToString()
                                + " | TransactionFeeClient = " + CustomerPaymentsList[a].Data[i].TransactionFeeClient.ToString() + " | TransactionFeeCustomer = " + CustomerPaymentsList[a].Data[i].TransactionFeeCustomer.ToString()
                                + " | TransactionTime = " + CustomerPaymentsList[a].Data[i].TransactionTime.ToString() + " | YourGeneralReference = " + CustomerPaymentsList[a].Data[i].YourGeneralReference + " | YourSystemReference = " + CustomerPaymentsList[a].Data[i].YourSystemReference
                                + Environment.NewLine;
                        }
                    }
                }
            }
            else this.responseText.Text = "Select PAYMENT or SETTLEMENT and try again..";

            button1.Enabled = true;
            GetCustomerListBtn.Enabled = true;
            GetPaymentsBtn.Enabled = true;
        }
    }
    
}
