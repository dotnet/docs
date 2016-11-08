// Use NotePad to save the following RTF code to a text file in the same folder as  
// your .exe file for this project. Name the file test.rtf. 
/*
{\rtf1\ansi\ansicpg1252\deff0\deflang1033{\fonttbl{\f0\fswiss\fcharset0 Arial;}
{\f1\fnil\fprq1\fcharset0 Courier New;}{\f2\fswiss\fprq2\fcharset0 Arial;}}
{\colortbl ;\red0\green128\blue0;\red0\green0\blue0;}
{\*\generator Msftedit 5.41.21.2508;}
\viewkind4\uc1\pard\f0\fs20 The \i Greek \i0 word for "psyche" is spelled \cf1\f1\u968?\u965?\u967?\u942?\cf2\f2 . The Greek letters are encoded in Unicode.\par
These characters are from the extended \b ASCII \b0 character set (Windows code page 1252):  \'e2\'e4\u1233?\'e5\cf0\par }
*/
class ConvertFromRTF
{
    static void Main()
    {
        // If your RTF file isn't in the same folder as the .exe file for the project, 
        // specify the path to the file in the following assignment statement. 
        string path = @"test.rtf";

        //Create the RichTextBox. (Requires a reference to System.Windows.Forms.)
        System.Windows.Forms.RichTextBox rtBox = new System.Windows.Forms.RichTextBox();

        // Get the contents of the RTF file. When the contents of the file are  
        // stored in the string (rtfText), the contents are encoded as UTF-16. 
        string rtfText = System.IO.File.ReadAllText(path);

        // Display the RTF text. This should look like the contents of your file.
        System.Windows.Forms.MessageBox.Show(rtfText);

        // Use the RichTextBox to convert the RTF code to plain text.
        rtBox.Rtf = rtfText;
        string plainText = rtBox.Text;

        // Display the plain text in a MessageBox because the console can't  
        // display the Greek letters. You should see the following result: 
        //   The Greek word for "psyche" is spelled ψυχή. The Greek letters are
        //   encoded in Unicode.
        //   These characters are from the extended ASCII character set (Windows
        //   code page 1252): âäӑå
        System.Windows.Forms.MessageBox.Show(plainText);

        // Output the plain text to a file, encoded as UTF-8. 
        System.IO.File.WriteAllText(@"output.txt", plainText);
    }
}