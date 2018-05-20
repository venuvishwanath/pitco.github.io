using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace finalReport
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        public void Form1_Load(object sender, EventArgs e)
        {
            this.BackColor = Color.FromArgb(175,238,238);
            //create table with three columns

            DataTable t = new DataTable();
            
            t.Columns.Add("S.NO", typeof(Int16));
            t.Columns.Add("SET NO", typeof(string));
            t.Columns.Add("Rx SENSITIVITY", typeof(string));
            t.Columns.Add("Tx OUTPUT", typeof(string));
            t.Columns.Add("MODULATION", typeof(string));
            t.Columns.Add("REMARKS", typeof(string));

           

            //bind table to datagridview
            dataGridView1.DataSource = t;



            //DataSet dsReport = new dsCDCatalog();
            //// create temp dataset to read xml information 
            //DataSet dsTempReport = new DataSet();
            
                

                

            
              
            
        }

        //public DataSet CustomMethod()
        //{
        //    //Define a dataset

        //    DataSet ds = new DataSet();

        //    //Define a datatable

        //    DataTable dt = new DataTable();
        //    dt.Columns.Add("S.NO", typeof(Int16));
        //    dt.Columns.Add("SET NO", typeof(string));
        //    dt.Columns.Add("Rx SENSITIVITY", typeof(string));
        //    dt.Columns.Add("Tx OUTPUT", typeof(string));
        //    dt.Columns.Add("MODULATION", typeof(string));
        //    dt.Columns.Add("REMARKS", typeof(string));
        //   // dt.Columns.Add("equipment_name", typeof(string));
        //    //dt.Columns.Add("district_name", typeof(string));

        //    //Write DataGridView data to the datatable
        //    foreach (DataGridViewRow dgv in dataGridView1.Rows)
        //    {
        //        dt.Rows.Add(dgv.Cells[0].Value, dgv.Cells[1].Value, dgv.Cells[2].Value, dgv.Cells[3].Value, dgv.Cells[4].Value, dgv.Cells[5].Value);
        //    }

        //   // dt.Rows.Add(textBox1.Text,comboBox1.SelectedItem);
        //    //Add datatable to the dataset and convert to an XML format file

        //    ds.Tables.Add(dt);
        //    ds.WriteXmlSchema("data.xml");

        //    return ds;
        //}

        public void button1_Click(object sender, EventArgs e)
        {


            //Define a dataset

            DataSet ds = new DataSet();

            //Define a datatable

            DataTable dt = new DataTable();
            dt.Columns.Add("S.NO", typeof(Int16));
            dt.Columns.Add("SET NO", typeof(string));
            dt.Columns.Add("Rx SENSITIVITY", typeof(string));
            dt.Columns.Add("Tx OUTPUT", typeof(string));
            dt.Columns.Add("MODULATION", typeof(string));
            dt.Columns.Add("REMARKS", typeof(string));
            dt.Columns.Add("ID");

            //Write DataGridView data to the datatable
            foreach (DataGridViewRow dgv in dataGridView1.Rows)
            {
                dt.Rows.Add(dgv.Cells[0].Value, dgv.Cells[1].Value, dgv.Cells[2].Value,dgv.Cells[3].Value,dgv.Cells[4].Value,dgv.Cells[5].Value);
            }


            //Add datatable to the dataset and convert to an XML format file

            ds.Tables.Add(dt);
           




            //creating second table

            DataTable dt2 = new DataTable();
            dt2.Columns.Add("model");
            dt2.Columns.Add("district");
            dt2.Columns.Add("ID");
            dt2.Rows.Add(textBox1.Text);
            dt2.Rows.Add(comboBox1.SelectedText);

            ds.Tables.Add(dt2);
            ds.WriteXmlSchema("data.xml");
            

            //transefer data to crystalreportviewer
            
            
            CrystalReport1 cr = new CrystalReport1();
            cr.SetDataSource(ds.Tables[0]);
            crystalReportViewer1.ReportSource = cr;
            

            //Form2 f2 = new Form2();
            //f2.ShowDialog();
            
        }
    }
}
