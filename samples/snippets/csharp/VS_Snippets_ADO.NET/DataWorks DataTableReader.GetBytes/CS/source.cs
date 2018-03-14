// <Snippet1>
using System;
using System.Data.SqlClient;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;

class Class1
{
    [STAThread]
    static void Main(string[] args)
    {
        TestGetBytes();
    }

    static private void TestGetBytes()
    {
        // Set up the data adapter, using information from 
        // the AdventureWorks sample database.
        SqlDataAdapter photoAdapter = SetupDataAdapter( 
            "SELECT ThumbnailPhotoFileName, ThumbNailPhoto " +
            "FROM Production.ProductPhoto");
        // Fill the DataTable.
        DataTable photoDataTable = new DataTable();
        photoAdapter.Fill(photoDataTable);
         
        using (DataTableReader reader = new DataTableReader(photoDataTable))
        {
            while (reader.Read())
            {
                String productName = null;
                try
                {
                    // Get the name of the file.
                    productName = reader.GetString(0);
                    // Get the length of the field. Pass null
                    // in the buffer parameter to retrieve the length
                    // of the data field. Ensure that the field isn't
                    // null before continuing.
                    if (reader.IsDBNull(1))
                    {
                        Console.WriteLine(productName + " is unavailable.");
                    }
                    else
                    {
                        long len = reader.GetBytes(1, 0, null, 0, 0);
                        // Create a buffer to hold the bytes, and then
                        // read the bytes from the DataTableReader.
                        Byte[] buffer = new Byte[len];
                        reader.GetBytes(1, 0, buffer, 0, (int)len);
                        // Create a new Bitmap object, passing the array 
                        // of bytes to the constructor of a MemoryStream.
                        using (Bitmap productImage = new 
                                   Bitmap(new MemoryStream(buffer)))
                        {
                            String fileName = "C:\\" + productName;
                            // Save in gif format.
                            productImage.Save(fileName, ImageFormat.Gif);
                            Console.WriteLine("Successfully created " + fileName);
                        }
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(productName + ": " + ex.Message);
                }
            }
        }
        Console.WriteLine("Press Enter to finish.");
        Console.ReadLine();
    }

    static private SqlDataAdapter SetupDataAdapter(String sqlString)
    {
        // Assuming all the default settings, create a SqlDataAdapter
        // working with the AdventureWorks sample database that's 
        // available with SQL Server.
        String connectionString = 
            "Data Source=(local);Initial Catalog=AdventureWorks;" +
            "Integrated Security=true";
        return new SqlDataAdapter(sqlString, connectionString);
    }
}

// </Snippet1>

