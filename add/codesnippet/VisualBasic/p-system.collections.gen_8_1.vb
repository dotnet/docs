		' Get the default comparer that 
		' sorts first by the height.
		Dim defComp As Comparer(Of Box) = Comparer(Of Box).Default

		' Calling Boxes.Sort() with no parameter
		' is the same as calling Boxs.Sort(defComp)
		' because they are both using the default comparer.
		Boxes.Sort()

		For Each bx As Box In Boxes
            Console.WriteLine("{0}" & vbTab & "{1}" & vbTab & "{2}", _
                              bx.Height.ToString(), _
                              bx.Length.ToString(), _
                              bx.Width.ToString())
		Next bx