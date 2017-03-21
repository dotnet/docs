            try
            {
                // Assign the selected file's path to 
                // the SoundPlayer object.  
                player.SoundLocation = filepathTextbox.Text;

                // Load the .wav file.
                player.Load();
            }
            catch (Exception ex)
            {
                ReportStatus(ex.Message);
            }