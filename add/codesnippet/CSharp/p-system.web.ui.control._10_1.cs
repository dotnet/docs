   // An HttpException occurs if the server control does not,;
   // have permissions to read the resulting mapped file. 
        output.Write("The Actual Path of the virtual directory : "+
        MapPathSecure(TemplateSourceDirectory)+"<br>");

       // Get all the files from the absolute path of 'MyControl';
       // using TemplateSourceDirectory which gives the virtual Directory.
           string [] myFiles=
           Directory.GetFiles(MapPathSecure(TemplateSourceDirectory));
           output.Write("The files in this Directory are <br>");

            // List all the files.
            for (int i=0;i<myFiles.Length;i++)
               output.Write(myFiles[i]+"<br>");