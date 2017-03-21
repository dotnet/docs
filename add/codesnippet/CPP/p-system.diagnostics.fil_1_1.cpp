private:
    void GetSpecialBuild()
    {
        // Get the file version for the notepad.
        FileVersionInfo^ myFileVersionInfo =
            FileVersionInfo::GetVersionInfo( Environment::SystemDirectory + "\\Notepad.exe" );

        // Print the special build information.
        textBox1->Text = String::Concat( "Special build information: ", myFileVersionInfo->SpecialBuild );
    }