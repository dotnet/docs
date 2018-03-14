// <Snippet1>
using System;
using System.Data;
using System.IO;

class Class1
{
    static void Main()
    {
        DataTable table = new DataTable();
        table.Columns.Add("FileName", typeof(string));
        table.Columns.Add("Data", typeof(char[]));
        table.Rows.Add(new object[] { "File1.txt", "0123456789ABCDEF".ToCharArray() });
        table.Rows.Add(new object[] { "File2.txt", "0123456789ABCDEF".ToCharArray() });

        DataTableReader reader = new DataTableReader(table);
        TestGetChars(reader, 7);
    }

    private static void TestGetChars(DataTableReader reader, int bufferSize)
    {
        // The filename is in column 0, and the contents are in column 1.
        const int FILENAME_COLUMN = 0;
        const int DATA_COLUMN = 1;

        char[] buffer;
        long offset;
        int charsRead = 0;
        string fileName;
        int currentBufferSize = 0;

        while (reader.Read())
        {
            // Reinitialize the buffer size and the buffer itself.
            currentBufferSize = bufferSize;
            buffer = new char[bufferSize];
            // For each row, write the data to the specified file.
            // First, verify that the FileName column isn't null.
            if (!reader.IsDBNull(FILENAME_COLUMN))
            {
                // Get the file name, and create a file with 
                // the supplied name.
                fileName = reader.GetString(FILENAME_COLUMN);
                // Start at the beginning.
                offset = 0;

                using (StreamWriter outputStream =
                           new StreamWriter(fileName, false))
                {
                    try
                    {
                        // Loop through all the characters in the input field,
                        // incrementing the offset for the next time. If this
                        // pass through the loop reads characters, write them to 
                        // the output stream.
                        do
                        {
                            charsRead = (int)reader.GetChars(DATA_COLUMN, offset,
                                buffer, 0, bufferSize);
                            if (charsRead > 0)
                            {
                                outputStream.Write(buffer, 0, charsRead);
                                offset += charsRead;
                            }
                        } while (charsRead > 0);
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(fileName + ": " + ex.Message);
                    }
                }
            }
        }
        Console.WriteLine("Press Enter key to finish.");
        Console.ReadLine();
    }
}
// </Snippet1>

