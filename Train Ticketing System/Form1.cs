using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Train_Ticketing_System
{
    public partial class Form1 : Form
    {
        Double firstnum;
        Double secondnum;
        Double answer;
        String operation;

        //int operan;
        //bool operanselected = false;
        const double Lagos = 23.9;
        const double ELagos = 28.9;
        const double FSLagos = 38.99;

        const double Oxford = 67.23;
        const double EOxford = 72.23;
        const double FSOxford = 77.23;

        const double Preston = 78;
        const double EPreston = 83;
        const double FSPreston = 88;


        const double Brixton = 56;
        const double EBrixton = 61;
        const double FSBrixton = 66;

        const double Leeds = 76;
        const double ELeeds = 71;
        const double FSLeeds = 76;

        const double Kano = 76;
        const double EKano = 82;
        const double FSKano = 86;

        const double Tax = 19.75;
        Double Totalcost;
        String Class;


        public Form1()
        {
            InitializeComponent();
        }

        private void groupBox5_Enter(object sender, EventArgs e)
        {

        }

        private void tabPage1_Click(object sender, EventArgs e)
        {

        }

        private void BtnBackspace_Click(object sender, EventArgs e)
        {
            //if (TxtDisplay.Text.Length > 0)
            //    TxtDisplay.Text = TxtDisplay.Text.Remove(TxtDisplay.Text.Length - 1, 1);
            if (TxtDisplay.Text != "")
            {
                TxtDisplay.Text = TxtDisplay.Text.Remove(TxtDisplay.Text.Length - 1);

                if (TxtDisplay.Text == "")
                    TxtDisplay.Text = "0";

                else
                    TxtDisplay.Text += "";
            }
        }

        private void BtnC_Click(object sender, EventArgs e)
        {
            TxtDisplay.Text = "0";
            TxtResult.Text = "";
        }

        private void Button_Click(object sender, EventArgs e)
        {
            Button num = (Button)sender;
            if (TxtDisplay.Text == "0")
                TxtDisplay.Text = num.Text;
            else
                TxtDisplay.Text = (TxtDisplay.Text + num.Text);
        }

        private void Arithmetic_Fuction(object sender, EventArgs e)
        {
            Button ops = (Button)sender;

            firstnum = Double.Parse(TxtDisplay.Text);
            TxtDisplay.Text = "";
            operation = ops.Text;
            TxtResult.Text = System.Convert.ToString(firstnum) + " " + operation;
        }

        private void BtnEqual_Click(object sender, EventArgs e)
        {
            secondnum = Double.Parse(TxtDisplay.Text);
            TxtResult.Text = "";

            switch (operation)
            {
                case "+":
                    answer = (firstnum + secondnum);
                    TxtDisplay.Text = System.Convert.ToString(answer);
                    break;

                case "-":
                    answer = (firstnum - secondnum);
                    TxtDisplay.Text = System.Convert.ToString(answer);
                    break;

                case "/":
                    answer = (firstnum / secondnum);
                    TxtDisplay.Text = System.Convert.ToString(answer);
                    break;

                case "*":
                    answer = (firstnum * secondnum);
                    TxtDisplay.Text = System.Convert.ToString(answer);
                    break;
                default:
                    break;
            }
        }

        private void AlignLeftStripButton2_Click(object sender, EventArgs e)
        {
            RtbReciept.SelectionAlignment = HorizontalAlignment.Left;
        }

        private void AlignCenterStripButton4_Click(object sender, EventArgs e)
        {
            RtbReciept.SelectionAlignment = HorizontalAlignment.Center;
        }

        private void AlignRightStripButton4_Click(object sender, EventArgs e)
        {
            RtbReciept.SelectionAlignment = HorizontalAlignment.Right;
        }

        private void cutToolStripButton_Click(object sender, EventArgs e)
        {
            RtbReciept.Cut();
        }

        private void copyToolStripButton_Click(object sender, EventArgs e)
        {
            RtbReciept.Copy();
        }

        private void pasteToolStripButton_Click(object sender, EventArgs e)
        {
            RtbReciept.Paste();
        }

        private void RecycleBinStripButton1_Click(object sender, EventArgs e)
        {
            RtbReciept.Clear();
        }

        private void BtnGo_Click(object sender, EventArgs e)
        {
            webBrowser1.Visible = true;
            webBrowser1.Navigate(TxtURL.Text);
        }

        private void newToolStripButton_Click(object sender, EventArgs e)
        {
            RtbReciept.Clear();
        }

        private void openToolStripButton_Click(object sender, EventArgs e)
        {
            openFileDialog1.Filter = "Text Files (*.txt)|*.txt|All files (*.*)|*.*";

            if (openFileDialog1.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                RtbReciept.LoadFile(openFileDialog1.FileName, RichTextBoxStreamType.PlainText);
        }

        private void saveToolStripButton_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFile = new SaveFileDialog();

            saveFile.FileName = "Notepad Text";
            saveFile.Filter = "Text Files (*.txt)|*.txt|All files (*.*)|*.*";

        if (saveFile.ShowDialog() ==DialogResult.OK)
        {
            using (System.IO.StreamWriter SW = new System.IO.StreamWriter(saveFile.FileName))
                SW.WriteLine(RtbReciept.Text);
        }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //timer1.Start();
            //lblTime.Text = DateTime.Now.ToLongTimeString();
            //lblDate.Text = DateTime.Now.ToLongDateString();

            DateTime iDate = DateTime.Now;
            lblTime.Text = iDate.ToLongTimeString();
            lblDate.Text = DateTime.Now.Date.ToShortDateString();


            webBrowser1.Visible = false;
            RtbReciept.Visible = true;
            
            CmbDestination.Items.Add("Lagos");
            CmbDestination.Items.Add("Ibadan");
            CmbDestination.Items.Add("Ado-Ekiti");
            CmbDestination.Items.Add("Abuja");
            CmbDestination.Items.Add("Ondo");
            CmbDestination.Items.Add("Yobe");
            CmbDestination.Items.Add("Damaturu");
            CmbDestination.Items.Add("Sokoto");
            CmbDestination.Items.Add("Jos");
            CmbDestination.Items.Add("Oshogbo");
            CmbDestination.Items.Add("Akure");
            CmbDestination.Items.Add("Port Harcourt");
            CmbDestination.Items.Add("Katsina");
            CmbDestination.Items.Add("Owerri");
            CmbDestination.Items.Add("Umuahia");
            CmbDestination.Items.Add("Abakaliki");
            CmbDestination.Items.Add("Kano");


            BtnZero.Enabled = false;
            Btn1.Enabled = false;
            Btn2.Enabled = false;
            Btn3.Enabled = false;
            Btn4.Enabled = false;
            Btn5.Enabled = false;
            Btn6.Enabled = false;
            Btn7.Enabled = false;
            Btn8.Enabled = false;
            Btn9.Enabled = false;


            BtnAdd.Enabled = false;
            BtnSubtract.Enabled = false;
            BtnDivide.Enabled = false;
            BtnC.Enabled = false;
            BtnBackspace.Enabled = false;
            BtnMultiply.Enabled = false;
            BtnEqual.Enabled = false;
            BtnDot.Enabled = false;

            TxtResult.Enabled = false;
            TxtDisplay.Enabled = false;

        }

        private void printToolStripButton_Click(object sender, EventArgs e)
        {
            printPreviewDialog1.Document = printDocument1;
            printPreviewDialog1.ShowDialog();
        }

        private void lblTime_Click(object sender, EventArgs e)
        {
        //    timer1.Start();
        //    lblTime.Text = DateTime.Now.ToLongTimeString();
        //    lblDate.Text = DateTime.Now.ToLongDateString();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            //lblTime.Text = DateTime.Now.ToLongTimeString();
            //timer1.Start();

            DateTime iDate = DateTime.Now;
            lblTime.Text  = iDate.ToLongTimeString();
            
        }

        private void printDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            e.Graphics.DrawString(RtbReciept.Text,new Font("Arial",14,FontStyle.Regular ),Brushes.Black,120,120);

        }

        private void BoldtoolStripLabel1_Click(object sender, EventArgs e)
        {
            Font bFont =new Font (RtbReciept.Font,FontStyle.Bold);
            Font rFont =new Font (RtbReciept.Font,FontStyle.Regular);

            if (RtbReciept.SelectedText.Length ==0)

	        return;
        if (RtbReciept.SelectionFont.Bold)
	        {
	        RtbReciept.SelectionFont =rFont ;
	
	    }
	    else
	    {
        RtbReciept.SelectionFont = bFont;
       
            }
        }

        private void toolStripLabel2_Click(object sender, EventArgs e)
        {
            Font rFont =new Font (RtbReciept.Font,FontStyle.Italic );
            Font iFont =new Font (RtbReciept.Font,FontStyle.Regular);
            
            if (RtbReciept.SelectedText.Length ==0)

	    return;
            if (RtbReciept.SelectionFont.Italic)
	{
	      RtbReciept.SelectionFont =rFont;
	
	}
	        else
	{
	       RtbReciept.SelectionFont =iFont;
	  }
     }

        private void toolStripLabel3_Click(object sender, EventArgs e)
        {

            Font uFont = new Font(RtbReciept.Font, FontStyle.Underline);
            Font rFont = new Font(RtbReciept.Font, FontStyle.Regular);

            if (RtbReciept.SelectedText.Length == 0)

                return;
            if (RtbReciept.SelectionFont.Underline)
            {
                RtbReciept.SelectionFont = rFont;
            }
            else
            {
                RtbReciept.SelectionFont = uFont;
            }
        }

        private void BtnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void BtnReset_Click(object sender, EventArgs e)
        {
            foreach (Control controls in new Control[] { LblDisplayRoute,LblDisplayClass, LblDisplayRefNo, LblDisplayPrice, LblDisplayTo, LblDisplayFrom, LblDisplayChild, LblDisplayAdult, LblDisplayTicket, LblDisplayTotal, LblDisplayTax, LblDisplaySubTotal })
            {
                controls.Text = "";
            }
            foreach (Control controls1 in new Control[] { RtbReciept })
            {

                controls1.Text = "";
                }

            foreach (RadioButton control2 in new RadioButton[] { RbtnSingle, RbtnReturn, RbtnAdultYes, RbtnChildYes, RbtnStandard, RbtnEconomy, RbtnFirstClass, RbtnCalculator})
             {
       
                control2.Checked = false;;
                }
            foreach (ComboBox control3 in new ComboBox[] { CmbDestination })
	            control3.Text ="Select an option";

            BtnZero.Enabled = false;
            Btn1.Enabled = false;
            Btn2.Enabled = false;
            Btn3.Enabled = false;
            Btn4.Enabled = false;
            Btn5.Enabled = false;
            Btn6.Enabled = false;
            Btn7.Enabled = false;
            Btn8.Enabled = false;
            Btn9.Enabled = false;


            BtnAdd.Enabled = false;
            BtnSubtract.Enabled = false;
            BtnDivide.Enabled = false;
            BtnC.Enabled = false;
            BtnBackspace.Enabled = false;
            BtnMultiply.Enabled = false;
            BtnEqual.Enabled = false;
            BtnDot.Enabled = false;

            TxtResult.Enabled = false;
            TxtDisplay.Enabled = false;

        }

        private void BtnClear_Click(object sender, EventArgs e)
        {
            foreach (Control controls in new Control[] { LblDisplayRoute, LblDisplayRefNo, LblDisplayPrice, LblDisplayTo, LblDisplayFrom, LblDisplayChild, LblDisplayAdult, LblDisplayTicket, LblDisplayTotal, LblDisplayTax, LblDisplaySubTotal })
            {
                controls.Text = "";
            }
            foreach (Control controls1 in new Control[] { RtbReciept })
            {

                controls1.Text = "";
            }

            foreach (RadioButton control2 in new RadioButton[] { RbtnSingle, RbtnReturn, RbtnAdultYes, RbtnChildYes, RbtnStandard, RbtnEconomy, RbtnFirstClass, RbtnCalculator})
            {

                control2.Checked = false; ;
            }
            foreach (ComboBox control3 in new ComboBox[] { CmbDestination })
                control3.Text = "Select an option";

            BtnZero.Enabled = false;
            Btn1.Enabled = false;
            Btn2.Enabled = false;
            Btn3.Enabled = false;
            Btn4.Enabled = false;
            Btn5.Enabled = false;
            Btn6.Enabled = false;
            Btn7.Enabled = false;
            Btn8.Enabled = false;
            Btn9.Enabled = false;


            BtnAdd.Enabled = false;
            BtnSubtract.Enabled = false;
            BtnDivide.Enabled = false;
            BtnC.Enabled = false;
            BtnBackspace.Enabled = false;
            BtnMultiply.Enabled = false;
            BtnEqual.Enabled = false;
            BtnDot.Enabled = false;

            TxtResult.Enabled = false;
            TxtDisplay.Enabled = false;

        }

        private void BtnTotal_Click(object sender, EventArgs e)
        {
            
            if (RbtnStandard.Checked ==true)
            { LblDisplayClass.Text = RbtnStandard.Text; }

            if (RbtnEconomy.Checked == true)
            { LblDisplayClass.Text = RbtnEconomy.Text; }

            if (RbtnFirstClass.Checked == true)
            { LblDisplayClass.Text = RbtnFirstClass.Text; }

            if (RbtnSingle.Checked == true)
            { LblDisplayTicket.Text = RbtnSingle.Text; }

            if (RbtnReturn.Checked == true)
            { LblDisplayTicket.Text = RbtnReturn.Text; }

            if (RbtnAdultYes.Checked == true)
            { LblDisplayAdult.Text = RbtnAdultYes.Text; }

            if (RbtnChildYes.Checked == true)
            { LblDisplayChild.Text = RbtnChildYes.Text; }
            
            
            
            int Ref;
            Random rnd = new Random();
            Ref = rnd.Next(1000, 326650);
            LblDisplayRefNo.Text = Convert.ToString(Ref);


                LblDisplaySubTotal.Text = String.Format("{0:C2}", (Kano));
                Totalcost = (Kano * Tax) / 100;
                LblDisplayTax.Text = String.Format("{0:C2}", (Totalcost));
                LblDisplayTotal.Text = String.Format("{0:C2}", (Totalcost + Kano));
            
            
                LblDisplayPrice.Text = LblDisplayTotal.Text;
                LblDisplayFrom.Text = "Sokoto";
                LblDisplayTo.Text = (CmbDestination.Text);
                LblDisplayRoute.Text = "ANY";

                RtbReciept.AppendText("\t\t\t\t" + label8.Text + Environment.NewLine);

                RtbReciept.AppendText("==================================================" + Environment.NewLine);


                RtbReciept.AppendText("\n" + label15.Text + "\t\t" + label16.Text + "\t\t" + label17.Text + "\t\t\t" + label18.Text + Environment.NewLine);

                RtbReciept.AppendText("\n" + LblDisplayClass.Text + "\t" + LblDisplayTicket.Text + "\t\t" + LblDisplayAdult.Text + "\t\t\t" + LblDisplayChild.Text + "\t\t\t" + Environment.NewLine);


                RtbReciept.AppendText("==================================================" + Environment.NewLine);

                RtbReciept.AppendText("\t\t\t\t" + label24.Text + "\t\t\t" + LblDisplayFrom .Text + Environment.NewLine);

                RtbReciept.AppendText("\t\t\t\t" + label26.Text + "\t\t\t" + LblDisplayTo .Text + Environment.NewLine);

                RtbReciept.AppendText("\t\t\t\t" + label28.Text + "\t\t\t" + LblDisplayPrice .Text + Environment.NewLine);

                RtbReciept.AppendText("==================================================" + Environment.NewLine);

                RtbReciept.AppendText("\n" + label36.Text + "\t\t" + label35.Text + "\t\t\t" + label34.Text + "\t\t\t" + label33.Text + Environment.NewLine);

                RtbReciept.AppendText("\n" + LblDisplayRefNo.Text + "\t\t" + lblTime.Text + "\t\t" + lblDate.Text + "\t\t" + LblDisplayRoute.Text + Environment.NewLine);

                RtbReciept.AppendText("==================================================" + Environment.NewLine);
        }
        
        private void lblDate_Click(object sender, EventArgs e)
        {
            //timer1.Start();
            //lblDate.Text = DateTime.Now.ToLongDateString();
        }

        private void RbtnStandard_CheckedChanged(object sender, EventArgs e)
        {


        }

        private void RbtnEconomy_CheckedChanged(object sender, EventArgs e)
        {
    
        }

        private void RbtnFirstClass_CheckedChanged(object sender, EventArgs e)
        {
      
        }

        private void TxtURL_Click(object sender, EventArgs e)
        {

        }

        private void helpToolStripButton_Click(object sender, EventArgs e)
        {

        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            RtbReciept.Visible = true;
            webBrowser1.Visible = false;

            RtbReciept.AppendText("\t\t\t\t" + label8.Text + Environment.NewLine);

            RtbReciept.AppendText("==================================================" + Environment.NewLine);


            RtbReciept.AppendText("\n" + label15.Text + "\t\t" + label16.Text + "\t\t" + label17.Text + "\t\t\t" + label18.Text + Environment.NewLine);

            RtbReciept.AppendText("\n" + LblDisplayClass.Text + "\t" + LblDisplayTicket.Text + "\t\t" + LblDisplayAdult.Text + "\t\t\t" + LblDisplayChild.Text + "\t\t\t" + Environment.NewLine);


            RtbReciept.AppendText("==================================================" + Environment.NewLine);

            RtbReciept.AppendText("\t\t\t\t" + label24.Text + "\t\t\t" + LblDisplayFrom.Text + Environment.NewLine);

            RtbReciept.AppendText("\t\t\t\t" + label26.Text + "\t\t\t" + LblDisplayTo.Text + Environment.NewLine);

            RtbReciept.AppendText("\t\t\t\t" + label28.Text + "\t\t\t" + LblDisplayPrice.Text + Environment.NewLine);

            RtbReciept.AppendText("==================================================" + Environment.NewLine);

            RtbReciept.AppendText("\n" + label36.Text + "\t\t" + label35.Text + "\t\t\t" + label34.Text + "\t\t\t" + label33.Text + Environment.NewLine);

            RtbReciept.AppendText("\n" + LblDisplayRefNo.Text + "\t\t" + lblTime.Text + "\t\t" + lblDate.Text + "\t\t" + LblDisplayRoute.Text + Environment.NewLine);

            RtbReciept.AppendText("==================================================" + Environment.NewLine);
        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            webBrowser1.Visible = true ;
            RtbReciept.Visible = false ;
        }

        private void groupBox6_Enter(object sender, EventArgs e)
        {

        }

        private void RbtnCalculator_CheckedChanged(object sender, EventArgs e)
        {

            BtnZero.Enabled = true;
            Btn1.Enabled = true;
            Btn2.Enabled = true;
            Btn3.Enabled = true;
            Btn4.Enabled = true;
            Btn5.Enabled = true;
            Btn6.Enabled = true;
            Btn7.Enabled = true;
            Btn8.Enabled = true;
            Btn9.Enabled = true;


            BtnAdd.Enabled = true;
            BtnSubtract.Enabled = true;
            BtnDivide.Enabled = true;
            BtnC.Enabled = true;
            BtnBackspace.Enabled = true;
            BtnMultiply.Enabled = true;
            BtnEqual.Enabled = true;
            BtnDot.Enabled = true;

            TxtResult.Enabled = true;
            TxtDisplay.Enabled = true;

        }
      }
   }


