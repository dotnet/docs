private:
    void GetProductMajorPart()
    {
        // Get the file version for the notepad.
        FileVersionInfo^ myFileVersionInfo =
            FileVersionInfo::GetVersionInfo( Environment::SystemDirectory + "\\Notepad.exe" );

        // Print the product major part number.
        textBox1->Text = String::Concat( "Product major part number: ", myFileVersionInfo->ProductMajorPart );
    }