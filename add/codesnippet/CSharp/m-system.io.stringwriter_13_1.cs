            convertedCharacter = Convert.ToChar(intCharacter);
            if(convertedCharacter == '.')
            {
                strWriter.Write(".\n\n");

                // Bypass the spaces between sentences.
                strReader.Read();
                strReader.Read();
            }