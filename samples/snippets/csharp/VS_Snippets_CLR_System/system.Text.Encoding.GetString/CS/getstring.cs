using System;
using System.IO;

namespace ConsoleApplication1 {
  class MyBinaryFile {
    string m_author = null;
    static void Main(string[] args) {
      MyBinaryFile bf1 = new MyBinaryFile();
      bf1.Author = "Marin Millar";
      bf1.Save("a.dat");

      MyBinaryFile bf2 = new MyBinaryFile();
      bf2.Load("a.dat");
      Console.WriteLine(bf2.Author);


      bf2.PrintEncodingInfo(System.Text.Encoding.Default);
    }
    public MyBinaryFile() {
    }
    public string Author {
      set {
        m_author = value;
      }
      get {
        return m_author;
      }
    }
    public void Save(string filename) {
      FileStream fs = File.Open(filename, FileMode.Create);
      WriteAuthor(fs, m_author);
      fs.Flush();
      fs.Close();
    }
    private void WriteAuthor(Stream binary_file, string author) {
      System.Text.Encoding encoding = System.Text.Encoding.UTF8;
      // Get buffer size required for conversion
      int buffersize = encoding.GetByteCount(author);
      if (buffersize < 30) {
        buffersize = 30;
      }
      // Write string into binary file with UTF8 encoding
      byte[] buffer = new byte[buffersize];
      encoding.GetBytes(author, 0, author.Length, buffer, 0);
      binary_file.Write(buffer, 0, 30);
    }
    public void Load(string filename) {
      FileStream fs = File.OpenRead(filename);
      m_author = ReadAuthor(fs);
      fs.Close();
    }
    // <Snippet1>
    private string ReadAuthor(Stream binary_file) {
      System.Text.Encoding encoding = System.Text.Encoding.UTF8;
      // Read string from binary file with UTF8 encoding
      byte[] buffer = new byte[30];
      binary_file.Read(buffer, 0, 30);
      return encoding.GetString(buffer);
    }
/* This code produces the following output.

Marin Millar                  
BodyName:        iso-8859-1
HeaderName:      Windows-1252
WebName:         Windows-1252
CodePage:        1252
EncodingName:    Western European (Windows)
WindowsCodePage: 1252
MailNewsDisplay: True
MailNewsSave:    True
BrowserDisplay:  True
BrowserSave:     True
*/
    // </Snippet1>
    private void PrintEncodingInfo(System.Text.Encoding encoding) {
      // Print information of encoding
      Console.WriteLine("BodyName:        " + encoding.BodyName);
      Console.WriteLine("HeaderName:      " + encoding.HeaderName);
      Console.WriteLine("WebName:         " + encoding.WebName);
      Console.WriteLine("CodePage:        " + encoding.CodePage);
      Console.WriteLine("EncodingName:    " + encoding.EncodingName);
      Console.WriteLine("WindowsCodePage: " + encoding.WindowsCodePage);
      Console.WriteLine("MailNewsDisplay: " + encoding.IsMailNewsDisplay);
      Console.WriteLine("MailNewsSave:    " + encoding.IsMailNewsSave);
      Console.WriteLine("BrowserDisplay:  " + encoding.IsBrowserDisplay);
      Console.WriteLine("BrowserSave:     " + encoding.IsBrowserSave);
    }
  }
}

