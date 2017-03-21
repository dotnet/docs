private:
    void GetProductVersion()
    {
        // Get the file version for the notepad.
        FileVersionInfo^ myFileVersionInfo =
            FileVersionInfo::GetVersionInfo( Environment::SystemDirectory + "\\Notepad.exe" );

        // Print the product version number.
        textBox1->Text = String::Concat( "Product version number: ", myFileVersionInfo->ProductVersion );
    }