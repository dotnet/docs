        private void GetImageEncodersExample(PaintEventArgs e)
        {
                     
            // Get an array of available codecs.
            ImageCodecInfo[] myCodecs;
            myCodecs = ImageCodecInfo.GetImageEncoders();
            int numCodecs = myCodecs.GetLength(0);
                     
            //numCodecs = 1;
                     
            // Set up display variables.
            Color foreColor = Color.Black;
            Font font = new Font("Arial", 8);
            int i = 0;
                     
            // Check to determine whether any codecs were found.
            if(numCodecs > 0)
            {
                     
                // Set up an array to hold codec information. There are 9
                     
                // information elements plus 1 space for each codec, so 10 times
                     
                // the number of codecs found is allocated.
                string[] myCodecInfo = new string[numCodecs*10];
                     
                // Write all the codec information to the array.
                for(i=0;i<numCodecs;i++)
                {
                    myCodecInfo[i*10] = "Codec Name = " + myCodecs[i].CodecName;
                    myCodecInfo[(i*10)+1] = "Class ID = " +
                        myCodecs[i].Clsid.ToString();
                    myCodecInfo[(i*10)+2] = "DLL Name = " + myCodecs[i].DllName;
                    myCodecInfo[(i*10)+3] = "Filename Ext. = " +
                        myCodecs[i].FilenameExtension;
                    myCodecInfo[(i*10)+4] = "Flags = " +
                        myCodecs[i].Flags.ToString();
                    myCodecInfo[(i*10)+5] = "Format Descrip. = " +
                        myCodecs[i].FormatDescription;
                    myCodecInfo[(i*10)+6] = "Format ID = " +
                        myCodecs[i].FormatID.ToString();
                    myCodecInfo[(i*10)+7] = "MimeType = " + myCodecs[i].MimeType;
                    myCodecInfo[(i*10)+8] = "Version = " +
                        myCodecs[i].Version.ToString();
                    myCodecInfo[(i*10)+9] = " ";
                }
                int numMyCodecInfo = myCodecInfo.GetLength(0);
                     
                // Render all of the information to the screen.
                int j=20;
                for(i=0;i<numMyCodecInfo;i++)
                {
                    e.Graphics.DrawString(myCodecInfo[i],
                        font,
                        new SolidBrush(foreColor),
                        20,
                        j);
                    j+=12;
                }
            }
            else
                e.Graphics.DrawString("No Codecs Found",
                    font,
                    new SolidBrush(foreColor),
                    20,
                    20);
        }