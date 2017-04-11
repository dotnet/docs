using System;
using System.Reflection;

public class Page
{ }

public class MainPage
{
   static MainPage()
   {
      outputBlock = new TextBlock();
      outputBlock.Text = "";
   }

   internal static TextBlock outputBlock;
}

internal class TextBlock
{
   private String s;
   
   public String Text 
   {
      get { return s; }
      set { s = value; }
   }
}

// <Snippet6>
namespace LibraryApplications
{
   public sealed class Example
   {
      public void Execute()
      {
         TextBlock outputBlock = MainPage.outputBlock;
         Type t = typeof(Book);
         Object obj = Activator.CreateInstance(t, new Object[] { "A Tale of 2 Cities", "Charles Dickens", "" });
         outputBlock.Text += "\n\n\n";
         foreach (var p in t.GetRuntimeProperties())
         {
            outputBlock.Text += String.Format("{0}: {1}\n", p.Name, p.GetValue(obj));
         }
      }
   }

   public class Book
   {
      private string bookTitle = "";
      private string bookAuthor = "";
      private string bookISBN = "";

      public Book(string title, string author, string isbn)
      {
         bookTitle = title;
         bookAuthor = author;
         bookISBN = isbn;
      }

      public string Title
      {
         get { return bookTitle; }
         set { bookTitle = value; }
      }

      public string Author
      {
         get { return bookAuthor; }
         set { bookTitle = value; }
      }

      public string ISBN
      {
         get { return bookISBN; }
      }

      public override string ToString()
      {
         return String.Format("{0}, {1}", Author, Title);
      }
   }
}

public class TextUtilities
{
   public static string ConvertNumberToWord(int value)
   {
      switch (value)
      {
         case 1:
            return "One";
         case 2:
            return "Two";
         case 3:
            return "Three";
         case 4:
            return "Four";
         case 5:
            return "Five";
         case 6:
            return "Six";
         case 7:
            return "Seven";
         case 8:
            return "Eight";
         case 9:
            return "Nine";
         default:
            return value.ToString();
      }
   }
}
// </Snippet6>