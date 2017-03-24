        Using MyReader As New FileIO.TextFieldParser("..\..\testfile.txt")
            MyReader.TextFieldType = FileIO.FieldType.FixedWidth
            MyReader.FieldWidths = stdFormat