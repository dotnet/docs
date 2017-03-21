        // From textReaderText, create a continuous paragraph 
        // with two spaces between each sentence.
        string aLine, aParagraph = null;
        StringReader strReader = new StringReader(textReaderText);
        while(true)
        {
            aLine = strReader.ReadLine();
            if(aLine != null)
            {
                aParagraph = aParagraph + aLine + " ";
            }
            else
            {
                aParagraph = aParagraph + "\n";
                break;
            }
        }
        Console.WriteLine("Modified text:\n\n{0}", aParagraph);