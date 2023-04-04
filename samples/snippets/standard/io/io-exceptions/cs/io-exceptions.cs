using System;
using System.IO;
using System.Text;

class Program
{
    static void Main()
    {
	    var sw = OpenStream(@".\textfile.txt");
        if (sw is null)
            return;
        sw.WriteLine("This is the first line.");
        sw.WriteLine("This is the second line.");
        sw.Close();
    }

   static StreamWriter OpenStream(string path)
   {
        if (path is null) {
            Console.WriteLine("You did not supply a file path.");
            return null;
        }

        try {
            var fs = new FileStream(path, FileMode.CreateNew);
            return new StreamWriter(fs);
        }
        catch (FileNotFoundException) {
            Console.WriteLine("The file or directory cannot be found.");
        }
        catch (DirectoryNotFoundException) {
            Console.WriteLine("The file or directory cannot be found.");
        }
        catch (DriveNotFoundException) {
            Console.WriteLine("The drive specified in 'path' is invalid.");
        }
        catch (PathTooLongException) {
            Console.WriteLine("'path' exceeds the maximum supported path length.");
        }
        catch (UnauthorizedAccessException) {
            Console.WriteLine("You do not have permission to create this file.");
        }
        catch (IOException e) when ((e.HResult & 0x0000FFFF) == 32 ) {
            Console.WriteLine("There is a sharing violation.");
        }
        catch (IOException e) when ((e.HResult & 0x0000FFFF) == 80) {
            Console.WriteLine("The file already exists.");
        }
        catch (IOException e) {
            Console.WriteLine($"An exception occurred:\nError code: " +
                              $"{e.HResult & 0x0000FFFF}\nMessage: {e.Message}");
        }
        return null;
    }
}
