
		' This explicit interface implementation
		' compares first by the length.
		' Returns -1 because the length of BoxA
		' is less than the length of BoxB.
		Dim LengthFirst As New BoxLengthFirst()

		Dim bc As Comparer(Of Box) = CType(LengthFirst, Comparer(Of Box))

		Dim BoxA As New Box(2, 6, 8)
		Dim BoxB As New Box(10, 12, 14)
		Dim x As Integer = LengthFirst.Compare(BoxA, BoxB)
		Console.WriteLine()
		Console.WriteLine(x.ToString())