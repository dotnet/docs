        Using FileReader As New Microsoft.VisualBasic.FileIO.
            TextFieldParser("C:\logs\test.log")

            FileReader.SetDelimiters(vbTab)
        End Using