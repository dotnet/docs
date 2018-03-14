using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace IsDBNull_To_NA_CS
{
   static class Program
   {
      /// <summary>
      /// The main entry point for the application.
      /// </summary>
      [STAThread]
      static void Main()
      {
         Application.EnableVisualStyles();
         Application.SetCompatibleTextRenderingDefault(false);
         Application.Run(new Form1());
      }
   }
   
   public partial class Form1 : Form
   {
      private string connectionString = @"Data Source=RONPET59\SQLEXPRESS;Initial Catalog=SurveyDB;Integrated Security=True";

      public Form1()
      {
         InitializeComponent();
      }

      private bool CompareForMissing(object value)
      {
         // <Snippet1>
         return DBNull.Value.Equals(value);
         // </Snippet1> 
      }

      // <Snippet2>
      private void Form1_Load(object sender, EventArgs e)
      {
         // Define ADO.NET objects.
         SqlConnection conn = new SqlConnection(connectionString);
         SqlCommand cmd = new SqlCommand();
         SqlDataReader dr;

         // Open connection, and retrieve dataset.
         conn.Open();

         // Define Command object.
         cmd.CommandText = "Select * From Responses";
         cmd.CommandType = CommandType.Text;
         cmd.Connection = conn;

         // Retrieve data reader.
         dr = cmd.ExecuteReader();

         int fieldCount = dr.FieldCount;
         object[] fieldValues = new object[fieldCount];
         string[] headers = new string[fieldCount];
          
         // Get names of fields.
         for (int ctr = 0; ctr < fieldCount; ctr++)
            headers[ctr] = dr.GetName(ctr);

         // Set up data grid.
         this.grid.ColumnCount = fieldCount;

         this.grid.ColumnHeadersDefaultCellStyle.BackColor = Color.Navy;
         this.grid.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
         this.grid.ColumnHeadersDefaultCellStyle.Font = new Font(this.grid.Font, FontStyle.Bold);

         this.grid.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.DisplayedCellsExceptHeaders;
         this.grid.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.Single;
         this.grid.CellBorderStyle = DataGridViewCellBorderStyle.Single;
         this.grid.GridColor = Color.Black;
         this.grid.RowHeadersVisible = true;

         for (int columnNumber = 0; columnNumber < headers.Length;  columnNumber++)
            this.grid.Columns[columnNumber].Name = headers[columnNumber];

         // Get data, replace missing values with "NA", and display it.
         while (dr.Read())
         {
            dr.GetValues(fieldValues);

            for (int fieldCounter = 0; fieldCounter < fieldCount; fieldCounter++)
            {
               if (Convert.IsDBNull(fieldValues[fieldCounter]))
                  fieldValues[fieldCounter] = "NA";
            }
            grid.Rows.Add(fieldValues);
         }
         dr.Close();
      }
      // </Snippet2>      
   }
}
