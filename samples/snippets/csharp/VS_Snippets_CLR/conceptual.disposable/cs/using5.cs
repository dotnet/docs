// <Snippet6>
using System;
using System.Globalization;
using System.IO;
using System.Threading.Tasks;

class Example
{
    static async Task Main()
    {
        StreamReader streamReader = null;
        try
        {
            streamReader = new StreamReader("file1.txt");
            var contents = await streamReader.ReadToEndAsync();
            var info = new StringInfo(contents);
            Console.WriteLine($"The file has {info.LengthInTextElements} text elements.");
        }
        catch (FileNotFoundException)
        {
            Console.WriteLine("The file cannot be found.");
        }
        catch (IOException)
        {
            Console.WriteLine("An I/O error has occurred.");
        }
        catch (OutOfMemoryException)
        {
            Console.WriteLine("There is insufficient memory to read the file.");
        }
        finally
        {
            streamReader?.Dispose();
        }
    }
}
// </Snippet6>
