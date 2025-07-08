Imports System.IO

Module Program

    '<TestCode>
    Sub Main(args As String())
        'Read the contents of data.txt, encrypt it, And write it to shifted.txt
        WriteShiftedFile()

        'Read the contents of shifted.txt, decrypt it, And write it to unshifted.txt
        ReadShiftedFile()

        'Check if the decrypted file Is valid
        Console.WriteLine(IIf(IsShiftedFileValid(),
                                "Decrypted file is valid",  ' True
                                "Decrypted file is invalid" ' False
                         ))
    End Sub
    '</TestCode>

    '<WriteShiftedFile>
    Sub WriteShiftedFile()

        'Create the base streams for the input and output files
        Using inputBaseStream As FileStream = File.OpenRead("data.txt")
            Using encryptStream As CipherStream = CipherStream.CreateForRead(inputBaseStream)
                Using outputBaseStream As FileStream = File.Open("shifted.txt", FileMode.Create, FileAccess.Write)


                    'Read byte from inputBaseStream through the encryptStream (normal bytes into shifted bytes)
                    Dim intValue As Integer = encryptStream.ReadByte()
                    While intValue <> -1

                        outputBaseStream.WriteByte(Convert.ToByte(intValue))

                        intValue = encryptStream.ReadByte()

                    End While

                End Using
            End Using
        End Using

        'Process is:
        '  (inputBaseStream -> encryptStream) -> outputBaseStream
    End Sub
    '</WriteShiftedFile>

    '<ReadShiftedFile>
    Sub ReadShiftedFile()

        'Create the base streams for the input and output files
        Using inputBaseStream As FileStream = File.OpenRead("shifted.txt")
            Using outputBaseStream As FileStream = File.Open("unshifted.txt", FileMode.Create, FileAccess.Write)
                Using unencryptStream As CipherStream = CipherStream.CreateForWrite(outputBaseStream)


                    'Read byte from inputBaseStream through the encryptStream (shifted bytes into normal bytes)
                    Dim intValue As Integer = inputBaseStream.ReadByte()
                    While intValue <> -1

                        unencryptStream.WriteByte(Convert.ToByte(intValue))

                        intValue = inputBaseStream.ReadByte()

                    End While

                End Using
            End Using
        End Using

    End Sub
    '</ReadShiftedFile>

    '<ValidateFile>
    Function IsShiftedFileValid() As Boolean

        'Read the shifted file
        Dim originalText As String = File.ReadAllText("data.txt")

        'Read the shifted file
        Dim shiftedText As String = File.ReadAllText("unshifted.txt")

        'Check if the decrypted file is valid
        Return shiftedText = originalText

    End Function
    '</ValidateFile>

End Module
