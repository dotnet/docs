   String^ filePath = "C:\\MyDir\\MySubDir\\myfile.ext";
   String^ directoryName;
   int i = 0;

   while (filePath != nullptr)
   {
       directoryName = Path::GetDirectoryName(filePath);
       Console::WriteLine("GetDirectoryName('{0}') returns '{1}'",
           filePath, directoryName);
       filePath = directoryName;
       if (i == 1)
       {
           filePath = directoryName + "\\";  // this will preserve the previous path
       }
       i++;
   }
   /*
   This code produces the following output:

   GetDirectoryName('C:\MyDir\MySubDir\myfile.ext') returns 'C:\MyDir\MySubDir'
   GetDirectoryName('C:\MyDir\MySubDir') returns 'C:\MyDir'
   GetDirectoryName('C:\MyDir\') returns 'C:\MyDir'
   GetDirectoryName('C:\MyDir') returns 'C:\'
   GetDirectoryName('C:\') returns ''
   */