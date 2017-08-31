using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace CS
{
    public partial class Form2 : Form
    {
        //---------------------------------------------------------------------
        private void TestTyped()
        {
            //<Snippet4>
            this.customersTableAdapter.Fill(this.northwindDataSet.Customers);
            //</Snippet4>


            //<Snippet5>
            customersTableAdapter.FillByCity(northwindDataSet.Customers, "Seattle");
            customersTableAdapter.FillByCityAndState(northwindDataSet.Customers, "Seattle", "WA");
            //</Snippet5>
        }


        //---------------------------------------------------------------------
        private void TestUnTyped()
        {
            System.Data.SqlClient.SqlDataAdapter sqlDataAdapter1 = new System.Data.SqlClient.SqlDataAdapter();
            System.Data.DataSet dataset1 = new System.Data.DataSet();
            dataset1.Tables.Add(new System.Data.DataTable("Customers"));

            //<Snippet6>
            sqlDataAdapter1.Fill(dataset1.Tables["Customers"]);
            //</Snippet6>
        }


        //-------------------------------------------------------------------------
        private void Parameters()
        {
            System.Data.OleDb.OleDbCommand oleDbCommand1 = new System.Data.OleDb.OleDbCommand();
            System.Data.OleDb.OleDbConnection oleDbConnection1 = new System.Data.OleDb.OleDbConnection();

            //<Snippet16>
            oleDbCommand1.CommandText = "UpdateAuthor";
            oleDbCommand1.CommandType = System.Data.CommandType.StoredProcedure;

            oleDbCommand1.Parameters["au_id"].Value = "172-32-1176";
            oleDbCommand1.Parameters["au_lname"].Value = "White";
            oleDbCommand1.Parameters["au_fname"].Value = "Johnson";

            oleDbConnection1.Open();
            oleDbCommand1.ExecuteNonQuery();
            oleDbConnection1.Close();
            //</Snippet16>


            //<Snippet17>
            int returnValue;

            oleDbCommand1.CommandText = "CountAuthors";
            oleDbCommand1.CommandType = CommandType.StoredProcedure;

            oleDbConnection1.Open();
            oleDbCommand1.ExecuteNonQuery();
            oleDbConnection1.Close();

            returnValue = (int)(oleDbCommand1.Parameters["retvalue"].Value);
            MessageBox.Show("Return Value = " + returnValue.ToString());
            //</Snippet17>
        }


        //---------------------------------------------------------------------
        private void TestTableAdapter1()
        {
            //<Snippet7>
            NorthwindDataSetTableAdapters.CustomersTableAdapter tableAdapter = 
                new NorthwindDataSetTableAdapters.CustomersTableAdapter();

            tableAdapter.FillByCity(northwindDataSet.Customers, "Seattle");
            //</Snippet7>


            //<Snippet8>
            SqlConnection sqlConnection1 = new SqlConnection("Your Connection String");
            SqlCommand cmd = new SqlCommand();
            SqlDataReader reader;

            cmd.CommandText = "SELECT * FROM Customers";
            cmd.CommandType = CommandType.Text;
            cmd.Connection = sqlConnection1;

            sqlConnection1.Open();

            reader = cmd.ExecuteReader();
            // Data is accessible through the DataReader object here.

            sqlConnection1.Close();
            //</Snippet8>
        }


        //---------------------------------------------------------------------
        private void TestTableAdapter1C()
        {
            //<Snippet13>
            SqlConnection sqlConnection1 = new SqlConnection("Your Connection String");
            SqlCommand cmd = new SqlCommand();
            SqlDataReader reader;

            cmd.CommandText = "StoredProcedureName";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Connection = sqlConnection1;

            sqlConnection1.Open();

            reader = cmd.ExecuteReader();
            // Data is accessible through the DataReader object here.

            sqlConnection1.Close();
            //</Snippet13>
        }


        //---------------------------------------------------------------------
        private void TestTableAdapter2()
        {
            //<Snippet9>
            NorthwindDataSetTableAdapters.CustomersTableAdapter tableAdapter = 
                new NorthwindDataSetTableAdapters.CustomersTableAdapter();

            int returnValue = (int)tableAdapter.GetCustomerCount();
            //</Snippet9>
        }


        //---------------------------------------------------------------------
        private void TestTableAdapter2B()
        {
            //<Snippet10>
            SqlConnection sqlConnection1 = new SqlConnection("Your Connection String");
            SqlCommand cmd = new SqlCommand();
            Object returnValue;
            
            cmd.CommandText = "SELECT COUNT(*) FROM Customers";
            cmd.CommandType = CommandType.Text;
            cmd.Connection = sqlConnection1;

            sqlConnection1.Open();

            returnValue = cmd.ExecuteScalar();

            sqlConnection1.Close();
            //</Snippet10>
        }


        //---------------------------------------------------------------------
        private void TestTableAdapter2C()
        {
            //<Snippet14>
            SqlConnection sqlConnection1 = new SqlConnection("Your Connection String");
            SqlCommand cmd = new SqlCommand();
            Object returnValue;
            
            cmd.CommandText = "StoredProcedureName";
            cmd.CommandType = CommandType. StoredProcedure;
            cmd.Connection = sqlConnection1;

            sqlConnection1.Open();

            returnValue = cmd.ExecuteScalar();

            sqlConnection1.Close();
            //</Snippet14>
        }


        //---------------------------------------------------------------------
        private void TestTableAdapter3()
        {
            //<Snippet11>
            NorthwindDataSetTableAdapters.CustomersTableAdapter tableAdapter = 
                new NorthwindDataSetTableAdapters.CustomersTableAdapter();

            int rowsAffected = tableAdapter.UpdateContactTitle("Sales Manager", "ALFKI");
            //</Snippet11>
        }


        //---------------------------------------------------------------------
        private void TestTableAdapter3B()
        {
            //<Snippet12>
            SqlConnection sqlConnection1 = new SqlConnection("Your Connection String");
            SqlCommand cmd = new SqlCommand();
            Int32 rowsAffected;
            
            cmd.CommandText = "UPDATE Customers SET ContactTitle = 'Sales Manager' WHERE CustomerID = 'ALFKI'";
            cmd.CommandType = CommandType.Text;
            cmd.Connection = sqlConnection1;

            sqlConnection1.Open();

            rowsAffected = cmd.ExecuteNonQuery();

            sqlConnection1.Close();
            //</Snippet12>
        }


        //---------------------------------------------------------------------
        private void TestTableAdapter3C()
        {
            //<Snippet15>
            SqlConnection sqlConnection1 = new SqlConnection("Your Connection String");
            SqlCommand cmd = new SqlCommand();
            Int32 rowsAffected;
            
            cmd.CommandText = "StoredProcedureName";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Connection = sqlConnection1;

            sqlConnection1.Open();

            rowsAffected = cmd.ExecuteNonQuery();

            sqlConnection1.Close();
            //</Snippet15>
        }


        //---------------------------------------------------------------------
        private void customersBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            this.Validate();
            this.customersBindingSource.EndEdit();
            this.customersTableAdapter.Update(this.northwindDataSet.Customers);
        }


        //---------------------------------------------------------------------
        public Form2()
        {
            InitializeComponent();
        }
    }
}