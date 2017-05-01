using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace cs_walk4
{
    public partial class Form1 : Form
    {
        // <Snippet1>
        Northwnd db = new Northwnd(@"c:\linqtest7\northwnd.mdf");
        // </Snippet1>

        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // <Snippet2>
            // Declare a variable to hold the contents of
            // textBox1 as an argument for the stored
            // procedure.
            string param = textBox1.Text;

            // Declare a variable to hold the results
            // returned by the stored procedure.
            var custquery = db.CustOrdersDetail(Convert.ToInt32(param));

            // Execute the stored procedure and display the results.
            string msg = "";
            foreach (CustOrdersDetailResult custOrdersDetail in custquery)
            {
                msg = msg + custOrdersDetail.ProductName + "\n";
            }
            if (msg == "")
                msg = "No results.";
            MessageBox.Show(msg);

            // Clear the variables before continuing.
            param = "";
            textBox1.Text = "";
            // </Snippet2>

        }

        private void button2_Click(object sender, EventArgs e)
        {
            // <Snippet3>
            // Comments in the code for button2 are the same
            // as for button1.
            string param = textBox2.Text;

            var custquery = db.CustOrderHist(param);

            string msg = "";
            foreach (CustOrderHistResult custOrdHist in custquery)
            {
                msg = msg + custOrdHist.ProductName + "\n";
            }
            MessageBox.Show(msg);

            param = "";
            textBox2.Text = "";
            // </Snippet3>
        }
    }
}
