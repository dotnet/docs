private:
    void GetTrademarks()
    {
        // Get the file version for the notepad.
        FileVersionInfo^ myFileVersionInfo =
            FileVersionInfo::GetVersionInfo( Environment::SystemDirectory + "\\Notepad.exe" );

        // Print the trademarks.
        textBox1->Text = String::Concat( "Trademarks: ", myFileVersionInfo->LegalTrademarks );
    }