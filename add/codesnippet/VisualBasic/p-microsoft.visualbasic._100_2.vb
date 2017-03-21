        Using FileReader As New Microsoft.VisualBasic.FileIO.
            TextFieldParser("C:\ParserText.txt")

            FileReader.TextFieldType = 
                Microsoft.VisualBasic.FileIO.FieldType.FixedWidth
            FileReader.FieldWidths = New Integer() {5, 10, 11, -1}
        End Using