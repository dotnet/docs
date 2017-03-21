        Dim p As Integer = 0
        Console.WriteLine(ControlChars.Lf & "Current evidence = ")
        If myEvidence Is Nothing Then
            Return 0
        End If
        Dim list As IEnumerator = myEvidence.GetEnumerator()
        Dim obj As Object
        While list.MoveNext()
            Console.WriteLine(list.Current.ToString())
            p = p + 1
        End While