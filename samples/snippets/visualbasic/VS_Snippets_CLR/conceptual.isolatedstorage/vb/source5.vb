'<snippet5>
Imports System.IO
Imports System.IO.IsolatedStorage

Module Module1

    Sub Main()
        Dim isoStore As IsolatedStorageFile = IsolatedStorageFile.GetStore(IsolatedStorageScope.User Or IsolatedStorageScope.Assembly, Nothing, Nothing)

        If (isoStore.FileExists("TestStore.txt")) Then
            Console.WriteLine("The file already exists!")
            Using isoStream As IsolatedStorageFileStream = New IsolatedStorageFileStream("TestStore.txt", FileMode.Open, isoStore)
                Using reader As StreamReader = New StreamReader(isoStream)
                    Console.WriteLine("Reading contents:")
                    Console.WriteLine(reader.ReadToEnd())
                End Using
            End Using
        Else
            Using isoStream As IsolatedStorageFileStream = New IsolatedStorageFileStream("TestStore.txt", FileMode.CreateNew, isoStore)
                Using writer As StreamWriter = New StreamWriter(isoStream)
                    writer.WriteLine("Hello Isolated Storage")
                    Console.WriteLine("You have written to the file.")
                End Using
            End Using
        End If 
    End Sub

End Module
'</snippet5>