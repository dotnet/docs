private:
    void GetOriginalName()
    {
        // Get the file version for the notepad.
        FileVersionInfo^ myFileVersionInfo =
            FileVersionInfo::GetVersionInfo( Environment::SystemDirectory + "\\Notepad.exe" );

        // Print the original file name.
        textBox1->Text = String::Concat( "Original file name: ", myFileVersionInfo->OriginalFilename );
    }