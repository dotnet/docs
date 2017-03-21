private:
    void GetFileDescription()
    {
        // Get the file version for the notepad.
        FileVersionInfo^ myFileVersionInfo =
        FileVersionInfo::GetVersionInfo( Environment::SystemDirectory + "\\Notepad.exe" );

        // Print the file description.
        textBox1->Text = String::Concat( "File description: ", myFileVersionInfo->FileDescription );
    }