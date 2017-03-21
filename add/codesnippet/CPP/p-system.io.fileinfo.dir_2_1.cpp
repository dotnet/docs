   String^ fileName = "C:\\TMP\\log.txt";
   FileInfo^ fileInfo = gcnew FileInfo( fileName );
   if (  !fileInfo->Exists )
   {
      return;
   }

   Console::WriteLine( " {0} has a directoryName of {1}",
      fileName, fileInfo->DirectoryName );