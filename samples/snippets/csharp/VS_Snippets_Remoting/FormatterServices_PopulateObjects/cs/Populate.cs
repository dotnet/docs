//<snippet1>
using System;
using System.Collections;
using System.Runtime.Serialization;
using System.IO;
using System.Reflection;
using System.Security.Permissions;

[assembly: SecurityPermission(SecurityAction.RequestMinimum)]
namespace Examples
{
    // The SerializableAttribute specifies that instances of the class 
    // can be serialized by the BinaryFormatter or SoapFormatter.
    [Serializable]
    class Book
    {
        public string Title;
        public string Author;

        // Constructor for setting new values.
        public Book(string newTitle, string newAuthor)
        {
            Title = newTitle;
            Author = newAuthor;
        }
    }

    [SecurityPermission(SecurityAction.Demand)]
    public sealed class Test
    {
        public static void Main()
        {
            try
            {
                Run();
            }
            catch (System.Exception exc)
            {
                Console.WriteLine("{0}: {1}", exc.Message, exc.StackTrace);
            }
            finally
            {
                Console.WriteLine("Press <Enter> to exit....");
                Console.ReadLine();
            }
        }

        
        static void Run()
        {
            // Create an instance of a Book class 
            // with a title and author.
            Book Book1 = new Book("Book Title 1",
                "Masato Kawai");

            // Store data about the serializable members in a 
            // MemberInfo array. The MemberInfo type holds 
            // only type data, not instance data.
            MemberInfo[] members =
               FormatterServices.GetSerializableMembers
               (typeof(Book));

            // Copy the data from the first book into an 
            // array of objects.
            object[] data =
                FormatterServices.GetObjectData(Book1, members);

            // Create an uninitialized instance of the Book class.
            Book Book1Copy =
                (Book)FormatterServices.GetSafeUninitializedObject
                (typeof(Book));

            // Call the PopuluateObjectMembers to copy the
            // data into the new Book instance.
            FormatterServices.PopulateObjectMembers
                (Book1Copy, members, data);

            // Print the data from the copy.
            Console.WriteLine("Title: {0}", Book1Copy.Title);
            Console.WriteLine("Author: {0}", Book1Copy.Author);
        }
        // A private constructor is good practice on
        // a class containing only static methods.
        private Test() { }
    }
}
//</snippet1>
