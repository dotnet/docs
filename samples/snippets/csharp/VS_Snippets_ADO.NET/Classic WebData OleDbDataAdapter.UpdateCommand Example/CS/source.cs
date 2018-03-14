    using System;
    using System.Data;
    using System.Data.OleDb;

    namespace OleDbDataAdapterUpdateCommandCS
              {
    class Program
    {
        static void Main()
        {
            OleDbConnection connection = new OleDbConnection("Provider=sqloledb;Data Source=(local);Initial Catalog=Northwind;"
                + "Integrated Security=SSPI");
            OleDbDataAdapter da = CreateCustomerAdapter(connection);
            Console.WriteLine(da.ToString());
            connection.Dispose();
            Console.ReadLine();
        }


        //<Snippet1>
        private static OleDbDataAdapter CreateCustomerAdapter(
            OleDbConnection connection)
        {
            OleDbDataAdapter dataAdapter = new OleDbDataAdapter();
            OleDbCommand command;
            OleDbParameter parameter;

            // Create the SelectCommand.
            command = new OleDbCommand("SELECT * FROM dbo.Customers " +
                "WHERE Country = ? AND City = ?", connection);

            command.Parameters.Add("Country", OleDbType.VarChar, 15);
            command.Parameters.Add("City", OleDbType.VarChar, 15);

            dataAdapter.SelectCommand = command;

            // Create the UpdateCommand.
            command = new OleDbCommand(
                "UPDATE dbo.Customers SET CustomerID = ?, CompanyName = ? " +
                "WHERE CustomerID = ?", connection);

            command.Parameters.Add(
                "CustomerID", OleDbType.Char, 5, "CustomerID");
            command.Parameters.Add(
                "CompanyName", OleDbType.VarChar, 40, "CompanyName");

            parameter = command.Parameters.Add(
                "oldCustomerID", OleDbType.Char, 5, "CustomerID");
            parameter.SourceVersion = DataRowVersion.Original;

            dataAdapter.UpdateCommand = command;

            return dataAdapter;
        }
        //</Snippet1>

    }
}




