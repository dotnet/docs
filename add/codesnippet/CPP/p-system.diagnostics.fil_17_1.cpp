private:
    void GetProductName()
    {
        // Get the file version for the notepad.
        FileVersionInfo^ myFileVersionInfo =
            FileVersionInfo::GetVersionInfo( Environment::SystemDirectory + "\\Notepad.exe" );

        // Print the product name.
        textBox1->Text = String::Concat( "Product name: ", myFileVersionInfo->ProductName );
    }