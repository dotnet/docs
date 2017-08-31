using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
//<Snippet6>
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
//</Snippet6>
//<Snippet10>
using System.Runtime.Serialization.Formatters.Soap;
//</Snippet10>

namespace VbObjectPersistenceWalkthroughCS
{
    public partial class Form1 : Form
    {
        //<Snippet7>
        const string FileName = @"..\..\SavedLoan.bin";
        //</Snippet7>

        public Form1()
        {
            InitializeComponent();
        }

        //<Snippet8>
        private LoanClass.Loan TestLoan = new LoanClass.Loan(10000.0, 0.075, 36, "Neil Black");

        private void Form1_Load(object sender, EventArgs e)
        {
            if (File.Exists(FileName))
            {
                Stream TestFileStream = File.OpenRead(FileName);
                BinaryFormatter deserializer = new BinaryFormatter();
                TestLoan = (LoanClass.Loan)deserializer.Deserialize(TestFileStream);
                TestFileStream.Close();
            }

            TestLoan.PropertyChanged += this.CustomerPropertyChanged;

            textBox1.Text = TestLoan.LoanAmount.ToString();
            textBox2.Text = TestLoan.InterestRate.ToString();
            textBox3.Text = TestLoan.Term.ToString();
            textBox4.Text = TestLoan.Customer;
        }
        //</Snippet8>

        //<Snippet9>
        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            TestLoan.LoanAmount = Convert.ToDouble(textBox1.Text);
            TestLoan.InterestRate = Convert.ToDouble(textBox2.Text);
            TestLoan.Term = Convert.ToInt32(textBox3.Text);
            TestLoan.Customer = textBox4.Text;

            Stream TestFileStream = File.Create(FileName);
            BinaryFormatter serializer = new BinaryFormatter();
            serializer.Serialize(TestFileStream, TestLoan);
            TestFileStream.Close();
        }
        //</Snippet9>

        private void CustomerPropertyChanged(object sender, 
            System.ComponentModel.PropertyChangedEventArgs e)
        {
            MessageBox.Show(e.PropertyName + " has been changed.");
        }
    }

    public class Form2 : Form
    {
        private TextBox textBox1 = new TextBox();
        private TextBox textBox2 = new TextBox();
        private TextBox textBox3 = new TextBox();
        private TextBox textBox4 = new TextBox();


        //<Snippet2>
        private LoanClass.Loan TestLoan = new LoanClass.Loan(10000.0, 0.075, 36, "Neil Black");

        private void Form1_Load(object sender, EventArgs e)
        {
            textBox1.Text = TestLoan.LoanAmount.ToString();
            textBox2.Text = TestLoan.InterestRate.ToString();
            textBox3.Text = TestLoan.Term.ToString();
            textBox4.Text = TestLoan.Customer;
        }
        //</Snippet2>

        //<Snippet3>
        private void CustomerPropertyChanged(object sender, 
            System.ComponentModel.PropertyChangedEventArgs e)
        {
            MessageBox.Show(e.PropertyName + " has been changed.");
        }
        //</Snippet3>
    }


    public class Form3 : Form
    {
        const string FileName = @"..\..\SavedLoan.xml";

        private TextBox textBox1 = new TextBox();
        private TextBox textBox2 = new TextBox();
        private TextBox textBox3 = new TextBox();
        private TextBox textBox4 = new TextBox();

        private LoanClass.Loan TestLoan = new LoanClass.Loan(10000.0, 0.075, 36, "Neil Black");

        private void Form1_Load(object sender, EventArgs e)
        {
            if (File.Exists(FileName))
            {
                Stream TestFileStream = File.OpenRead(FileName);
                //<Snippet11>
                SoapFormatter deserializer = new SoapFormatter();
                //</Snippet11>
                TestLoan = ( LoanClass.Loan)deserializer.Deserialize(TestFileStream);
                TestFileStream.Close();
            }

            TestLoan.PropertyChanged += this.CustomerPropertyChanged;

            textBox1.Text = TestLoan.LoanAmount.ToString();
            textBox2.Text = TestLoan.InterestRate.ToString();
            textBox3.Text = TestLoan.Term.ToString();
            textBox4.Text = TestLoan.Customer;
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            TestLoan.LoanAmount = Convert.ToDouble(textBox1.Text);
            TestLoan.InterestRate = Convert.ToDouble(textBox2.Text);
            TestLoan.Term = Convert.ToInt32(textBox3.Text);
            TestLoan.Customer = textBox4.Text;

            Stream TestFileStream = File.Create(FileName);
            //<Snippet12>
            SoapFormatter serializer = new SoapFormatter();
            //</Snippet12>
            serializer.Serialize(TestFileStream, TestLoan);
            TestFileStream.Close();
        }

        private void CustomerPropertyChanged(object sender,
            System.ComponentModel.PropertyChangedEventArgs e)
        {
            MessageBox.Show(e.PropertyName + " has been changed.");
        }
    }
}
