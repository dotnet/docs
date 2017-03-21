            String[] dirNames = isoFile.GetDirectoryNames("*");
            String[] fileNames = isoFile.GetFileNames("Archive\\*");

            // Delete all the files currently in the Archive directory.

            if (fileNames.Length > 0)
            {
                for (int i = 0; i < fileNames.Length; ++i)
                {
                    // Delete the files.
                    isoFile.DeleteFile("Archive\\" + fileNames[i]);
                }
                // Confirm that no files remain.
                fileNames = isoFile.GetFileNames("Archive\\*");
            }


            if (dirNames.Length > 0)
            {
                for (int i = 0; i < dirNames.Length; ++i)
                {
                    // Delete the Archive directory.
                }
            }
            dirNames = isoFile.GetDirectoryNames("*");
            isoFile.Remove();
        }
        catch (Exception e)
        {
            Console.WriteLine(e.ToString());
        }