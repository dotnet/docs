using System;
using System.Data.SqlClient;
using System.Data;
using System.Data.SqlTypes;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;

class Program
{
    static void Main()
    {
        // Supply any valid DocumentID value and file path.
        // The value 3 is supplied for DocumentID, and a literal
        // string for the file path where the image will be saved. 1, 60
        TestGetSqlBytes(7, @"c:\temp\");
        Console.ReadLine();
    }
    // <Snippet1>
    static private void TestGetSqlBytes(int documentID, string filePath)
    {
        // Assumes GetConnectionString returns a valid connection string.
        using (SqlConnection connection =
                   new SqlConnection(GetConnectionString()))
        {
            SqlCommand command = connection.CreateCommand();
            SqlDataReader reader = null;
            try
            {
                // Setup the command
                command.CommandText =
                    "SELECT LargePhotoFileName, LargePhoto "
                    + "FROM Production.ProductPhoto "
                    + "WHERE ProductPhotoID=@ProductPhotoID";
                command.CommandType = CommandType.Text;

                // Declare the parameter
                SqlParameter paramID =
                    new SqlParameter("@ProductPhotoID", SqlDbType.Int);
                paramID.Value = documentID;
                command.Parameters.Add(paramID);
                connection.Open();

                string photoName = null;

                reader = command.ExecuteReader(CommandBehavior.CloseConnection);

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        // Get the name of the file.
                        photoName = reader.GetString(0);

                        // Ensure that the column isn't null
                        if (reader.IsDBNull(1))
                        {
                            Console.WriteLine("{0} is unavailable.", photoName);
                        }
                        else
                        {
                            SqlBytes bytes = reader.GetSqlBytes(1);
                            using (Bitmap productImage = new Bitmap(bytes.Stream))
                            {
                                String fileName = filePath + photoName;

                                // Save in gif format.
                                productImage.Save(fileName, ImageFormat.Gif);
                                Console.WriteLine("Successfully created {0}.", fileName);
                            }
                        }
                    }
                }
                else
                {
                    Console.WriteLine("No records returned.");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                if (reader != null)
                    reader.Dispose();
            }
        }
    }
    // </Snippet1>

    static private string GetConnectionString()
    {
        // To avoid storing the connectionection string in your code,
        // you can retrieve it from a configuration file, using the
        // System.Configuration.ConfigurationSettings.AppSettings property
        return "Data Source=(local);Initial Catalog=AdventureWorks;" +
            "Integrated Security=SSPI";
    }
}
