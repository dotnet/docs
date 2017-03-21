'
' The source code should be saved in a file named Friend1.vb. It 
' can be compiled at the command line as follows:
'
'    vbc Friend1.vb /r:Assembly1.dll /keyfile:<snkfilename> 
'
' The public key of the Friend1 assembly should correspond to the public key
' specified in the class constructor of the InternalsVisibleTo attribute in the
' Assembly1 assembly.
'
Module Example
   Public Sub Main()
      Dim dir As String = "C:\Program Files"
      dir = FileUtilities.AppendDirectorySeparator(dir)
      Console.WriteLine(dir)
   End Sub
End Module
' The example displays the following output:
'       C:\Program Files\