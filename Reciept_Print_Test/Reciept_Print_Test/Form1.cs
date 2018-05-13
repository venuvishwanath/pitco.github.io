using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing.Printing;
using Microsoft.VisualBasic;

namespace Reciept_Print_Test
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            txtName.Focus();
            label1.Font = new Font("Arial", 16);
            DateTime datetime = DateTime.Now;
            time_lbl.Text = datetime.ToString();
        }
        

        private void btnAddItem_Click_1(object sender, EventArgs e)
        {
            listBox1.Items.Add(txtName.Text.PadRight(30)); // + txtPrice.Text);
            txtName.Text = "";
            txtName.Focus();
           //txtPrice.Text = "";
        }
        //private void btnAddItem_Click_1(object sender, EventArgs e)
        //{
        //    listBox1.Items.Add(txtName.Text.PadRight(30) + txtPrice.Text);
        //    txtName.Text = "";
        //    txtPrice.Text = "";
        //}
        private void btnRemoveItem_Click(object sender, EventArgs e)
        {
            try
            {
                listBox1.Items.RemoveAt(listBox1.SelectedIndex);
                txtName.Focus();
            }
            catch (Exception)
            {

                return;
            }
        }

        private void btnPrintReciept_Click_1(object sender, EventArgs e)
        {
            PrintDialog printDialog = new PrintDialog();

            PrintDocument printDocument = new PrintDocument();

            printDialog.Document = printDocument; //add the document to the dialog box...        

            printDocument.PrintPage += new System.Drawing.Printing.PrintPageEventHandler(CreateReceipt); //add an event handler that will do the printing

            //on a till you will not want to ask the user where to print but this is fine for the test envoironment.

            DialogResult result = printDialog.ShowDialog();

            if (result == DialogResult.OK)
            {
                printDocument.Print();

            }
        }

        public void CreateReceipt(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {

            
            float cash = 10;
            float change = 0.00f;

            //this prints the reciept

            Graphics graphic = e.Graphics;

            Font font = new Font("Courier New", 14); //must use a mono spaced font as the spaces need to line up

            float fontHeight = font.GetHeight();

            int startX = 10;
            int startY = 10;
            int offset = 40;

            graphic.DrawString("COMMUNICATIONS CENTRAL STORES", new Font("Courier New", 20), new SolidBrush(Color.Black), startX, startY);
            offset = offset + (int)fontHeight + 5;
            graphic.DrawString("Date :" + time_lbl.Text, new Font("Courier New", 10), new SolidBrush(Color.Black), startX + offset, startY+40 );
            string top = "Manpack Serial Number".PadLeft(20);// +"Price";
            graphic.DrawString(top, font, new SolidBrush(Color.Black), startX, startY + offset);
            offset = offset + (int)fontHeight; //make the spacing consistent
            graphic.DrawString("================================", font, new SolidBrush(Color.Black), startX, startY + offset);
            offset = offset + (int)fontHeight + 5; //make the spacing consistent

            string totalprice = listBox1.Items.Count.ToString();

            foreach (string item in listBox1.Items)
            {
                //create the string to print on the reciept
                string productDescription = item;
                //string productTotal = item.Substring(item.Length - 6, 6);
                //float productPrice = float.Parse(item.Substring(item.Length - 5, 5));

              //  MessageBox.Show(item.Substring(item.Length - 5, 5) );//+ "PROD TOTAL: " + productTotal);


                //totalprice += productPrice;

                if (productDescription.Contains("  -"))
                {
                    string productLine = productDescription.Substring(0, 24);

                    graphic.DrawString(productLine, new Font("Courier New", 14, FontStyle.Italic), new SolidBrush(Color.Red), startX, startY + offset);

                    offset = offset + (int)fontHeight + 5; //make the spacing consistent
                }
                else
                {
                    string productLine = productDescription;

                    graphic.DrawString(productLine, font, new SolidBrush(Color.Black), startX, startY + offset);

                    offset = offset + (int)fontHeight + 5; //make the spacing consistent
                }

            }

           
            //when we have drawn all of the items add the total

            offset = offset + 20; //make some room so that the total stands out.

            graphic.DrawString("-------------------------------", font, new SolidBrush(Color.Black), startX, startY + offset);
            offset = offset + (int)fontHeight + 5; //make the spacing consistent

            graphic.DrawString("Total Number of Items   =".PadRight(30) + String.Format("{0:c}", totalprice), new Font("Courier New", 14, FontStyle.Bold), new SolidBrush(Color.Black), startX, startY + offset);

            offset = offset + 30; //make some room so that the total stands out.
            //graphic.DrawString("CASH ".PadRight(30) + String.Format("{0:c}", cash), font, new SolidBrush(Color.Black), startX, startY + offset);
            //offset = offset + 15;
            //graphic.DrawString("CHANGE ".PadRight(30) + String.Format("{0:c}", change), font, new SolidBrush(Color.Black), startX, startY + offset);
            //offset = offset + 30; //make some room so that the total stands out.
            graphic.DrawString("     Thank-you ", font, new SolidBrush(Color.Black), startX, startY + offset);
            offset = offset + 15;
           

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

      
        

       

       

        
    }
}