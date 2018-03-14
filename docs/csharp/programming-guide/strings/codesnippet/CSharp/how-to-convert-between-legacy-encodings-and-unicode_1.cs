    class ANSIToUnicode
    {
        static void Main()
        {
            // Create a file that contains the Greek work ψυχή (psyche) when interpreted by using 
            // code page 737 ((DOS) Greek). You can also create the file by using Character Map 
            // to paste the characters into Microsoft Word and then "Save As" by using the DOS
            // (Greek) encoding. (Word will actually create a six-byte file by appending "\r\n" at the end.)
            System.IO.File.WriteAllBytes(@"greek.txt", new byte[] { 0xAF, 0xAC, 0xAE, 0x9E });

            // Specify the code page to correctly interpret byte values
            Encoding encoding = Encoding.GetEncoding(737); //(DOS) Greek code page
            byte[] codePageValues = System.IO.File.ReadAllBytes(@"greek.txt");

            // Same content is now encoded as UTF-16
            string unicodeValues = encoding.GetString(codePageValues);

            // Show that the text content is still intact in Unicode string
            // (Add a reference to System.Windows.Forms.dll)
            System.Windows.Forms.MessageBox.Show(unicodeValues);

            // Same content "ψυχή" is stored as UTF-8
            System.IO.File.WriteAllText(@"greek_unicode.txt", unicodeValues);

            // Conversion is complete. Show the bytes to prove the conversion. 
            Console.WriteLine("8-bit encoding byte values:");
            foreach(byte b in codePageValues)
                Console.Write("{0:X}-", b);

            Console.WriteLine();
            Console.WriteLine("Unicode values:");
            string unicodeString = System.IO.File.ReadAllText("greek_unicode.txt");
            System.Globalization.TextElementEnumerator enumerator = 
                System.Globalization.StringInfo.GetTextElementEnumerator(unicodeString);
            while(enumerator.MoveNext())
            {                
               string s = enumerator.GetTextElement();
               int i = Char.ConvertToUtf32(s, 0);                
               Console.Write("{0:X}-", i);          
            }                
            Console.WriteLine();
            
            // Keep the console window open in debug mode.
            Console.Write("Press any key to exit.");
            Console.ReadKey();
        }
        /*
         * Output:
            8-bit encoding byte values:
            AF-AC-AE-9E
            Unicode values:
            3C8-3C5-3C7-3B7
        */
    }