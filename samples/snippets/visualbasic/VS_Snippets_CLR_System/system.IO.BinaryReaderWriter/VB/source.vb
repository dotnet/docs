' <Snippet1>
Imports System.IO

Module Module1
    Const fileName As String = "AppSettings.dat"

    Sub Main()
        WriteDefaultValues()
        DisplayValues()
    End Sub

    Sub WriteDefaultValues()
        Using writer As BinaryWriter = New BinaryWriter(File.Open(fileName, FileMode.Create))
            writer.Write(1.25F)
            writer.Write("c:\Temp")
            writer.Write(10)
            writer.Write(True)
        End Using
    End Sub

    Sub DisplayValues()
        Dim aspectRatio As Single
        Dim tempDirectory As String
        Dim autoSaveTime As Integer
        Dim showStatusBar As Boolean

        If (File.Exists(fileName)) Then

            Using reader As BinaryReader = New BinaryReader(File.Open(fileName, FileMode.Open))
                aspectRatio = reader.ReadSingle()
                tempDirectory = reader.ReadString()
                autoSaveTime = reader.ReadInt32()
                showStatusBar = reader.ReadBoolean()
            End Using

            Console.WriteLine("Aspect ratio set to: " & aspectRatio)
            Console.WriteLine("Temp directory is: " & tempDirectory)
            Console.WriteLine("Auto save time set to: " & autoSaveTime)
            Console.WriteLine("Show status bar: " & showStatusBar)
        End If
    End Sub

End Module
' </Snippet1>