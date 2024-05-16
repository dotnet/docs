using System;
using System.Data;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using System.Drawing;
using System.Drawing.Imaging;
using System.Runtime.Versioning;

// API is only supported on Windows
[SupportedOSPlatform("windows")]
static class Program
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
    static void TestGetSqlBytes(int documentID, string filePath)
    {
        // Assumes GetConnectionString returns a valid connection string.
        using (SqlConnection connection =
                   new(GetConnectionString()))
        {
            SqlCommand command = connection.CreateCommand();
            SqlDataReader reader = default!;
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
                    new("@ProductPhotoID", SqlDbType.Int)
                    {
                        Value = documentID
                    };
                command.Parameters.Add(paramID);
                connection.Open();

                string photoName = default!;

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
                            using (Bitmap productImage = new(bytes.Stream))
                            {
                                var fileName = filePath + photoName;

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
                reader?.Dispose();
            }
        }
    }
    // </Snippet1>

    static string GetConnectionString() =>
        // To avoid storing the connectionection string in your code,
        // you can retrieve it from a configuration file, using the
        // System.Configuration.ConfigurationSettings.AppSettings property
        "Data Source=(local);Initial Catalog=AdventureWorks;" +
            "Integrated Security=SSPI";
}
