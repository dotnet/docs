    private:
        void GetImageEncodersExample(PaintEventArgs^ e)
        {
            // Get an array of available codecs.
            array<ImageCodecInfo^>^ codecInfo;
            codecInfo = ImageCodecInfo::GetImageEncoders();
            int numCodecs = codecInfo->GetLength(0);

            //numCodecs = 1;

            // Set up display variables.
            Color^ foreColor = Color::Black;
            Drawing::Font^ font = gcnew Drawing::Font("Arial", 8);

            // Check to determine whether any codecs were found.
            if (numCodecs > 0)
            {
                // Set up an array to hold codec information. There are 9
                // information elements plus 1 space for each codec, so 10
                // times the number of codecs found is allocated.
                array<String^>^ codecInfoStrings = 
                    gcnew array<String^>(numCodecs * 10);

                // Write all the codec information to the array.
                for (int i = 0; i < numCodecs; i++)
                {
                    codecInfoStrings[i * 10] = "Codec Name = " +
                        codecInfo[i]->CodecName;
                    codecInfoStrings[(i * 10) + 1] = "Class ID = " +
                        codecInfo[i]->Clsid.ToString();
                    codecInfoStrings[(i * 10) + 2] = "DLL Name = " +
                        codecInfo[i]->DllName;
                    codecInfoStrings[(i * 10) + 3] = "Filename Ext. = " +
                        codecInfo[i]->FilenameExtension;
                    codecInfoStrings[(i * 10) + 4] = "Flags = " +
                        codecInfo[i]->Flags.ToString();
                    codecInfoStrings[(i * 10) + 5] = "Format Descrip. = " +
                        codecInfo[i]->FormatDescription;
                    codecInfoStrings[(i * 10) + 6] = "Format ID = " +
                        codecInfo[i]->FormatID.ToString();
                    codecInfoStrings[(i * 10) + 7] = "MimeType = " +
                        codecInfo[i]->MimeType;
                    codecInfoStrings[(i * 10) + 8] = "Version = " +
                        codecInfo[i]->Version.ToString();
                    codecInfoStrings[(i * 10) + 9] = " ";
                }
                int numCodecInfo = codecInfoStrings->GetLength(0);

                // Render all of the information to the screen.
                int j = 20;
                for (int i = 0; i < numCodecInfo; i++)
                {
                    e->Graphics->DrawString(codecInfoStrings[i],
                        font, gcnew SolidBrush(*foreColor), 20, (float)j);
                    j += 12;
                }
            }
            else
                e->Graphics->DrawString("No Codecs Found",
                    font, gcnew SolidBrush(*foreColor), 20, 20);
        }