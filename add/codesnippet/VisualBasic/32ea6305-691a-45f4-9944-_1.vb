                Dim itemsList As ArrayList = CType(dictionary("List"), ArrayList)
                Dim i As Integer
                For i = 0 To itemsList.Count - 1
                    list.Add(serializer.ConvertToType(Of ListItem)(itemsList(i)))
                Next i