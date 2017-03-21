        Console.WriteLine(ControlChars.Lf & "Copy the evidence to an array using CopyTo, then display the array.")
        Dim evidenceArray(myEvidence.Count - 1) As Object
        myEvidence.CopyTo(evidenceArray, 0)
        Dim obj As Object
        For Each obj In evidenceArray
            Console.WriteLine(obj.ToString())
        Next obj