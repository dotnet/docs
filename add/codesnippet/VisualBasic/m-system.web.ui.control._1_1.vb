            ' An HttpException occurs if the server control does not,;
            ' have permissions to read the resulting mapped file.
            output.Write("The Actual Path of the virtual directory : " & _
                        MapPathSecure(TemplateSourceDirectory) & "<br>")

            ' Get all the files from the absolute path of 'MyControl';
            ' using TemplateSourceDirectory which gives the virtual Directory.
            Dim myFiles As String() = Directory.GetFiles(MapPathSecure(TemplateSourceDirectory))
            output.Write("The files in this Directory are <br>")

            ' List all the files.
            Dim i As Integer
            For i = 0 To myFiles.Length - 1
               output.Write(myFiles(i) & "<br>")
            Next i