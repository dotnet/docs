private:
    void GetFileName()
    {
        // Get the file version for the notepad.
        FileVersionInfo^ myFileVersionInfo =
            FileVersionInfo::GetVersionInfo( Environment::SystemDirectory + "\\Notepad.exe" );

        // Print the file name.
        textBox1->Text = String::Concat( "File name: ", myFileVersionInfo->FileName );
    }