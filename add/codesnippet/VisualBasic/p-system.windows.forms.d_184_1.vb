    Private Sub PrintReadOnlyValues()
        Dim tableStyle As DataGridTableStyle
        For Each tableStyle In  dataGrid1.TableStyles
            Console.WriteLine(tableStyle.ReadOnly)
        Next tableStyle
    End Sub 'PrintReadOnlyValues