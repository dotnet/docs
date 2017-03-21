        Using MyReader As New Microsoft.VisualBasic.FileIO.
            TextFieldParser("C:\logs\test.log")

            MyReader.SetFieldWidths(5, 10, -1)
        End Using