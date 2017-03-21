private:
    void GetFileBuildPart()
    {
        // Get the file version for the notepad.
        FileVersionInfo^ myFileVersionInfo =
            FileVersionInfo::GetVersionInfo(Environment::SystemDirectory + "\\Notepad.exe");

        // Print the file build number.
        textBox1->Text = String::Format( "File build number: {0}", myFileVersionInfo->FileBuildPart );
    }