        using System;
        using System.IO;

        public class ExceptionExample
        {
            static void Main()
            {
                try
                {
                    using(var sw = new StreamWriter(@"C:\test\test.txt"))
                    {
                    sw.WriteLine("Hello");
                    }   
                }
                // Put the more specific exceptions first.
                catch (DirectoryNotFoundException ex)
                {
                    System.Console.WriteLine(ex.ToString());  
                }
                catch (FileNotFoundException ex)
                {
                    System.Console.WriteLine(ex.ToString());  
                }
                // Put the least specific exception last.
                catch (IOException ex)
                {
                    System.Console.WriteLine(ex.ToString());  
                }

                Console.WriteLine("Done"); 
            }
        }