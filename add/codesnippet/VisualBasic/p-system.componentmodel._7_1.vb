	Private Sub PrintIndexItem
		' Creates a new collection and assigns it the attributes for button1.
		Dim attributes As AttributeCollection
		attributes = TypeDescriptor.GetAttributes(button1)

		' Prints the second attribute's name.
		textBox1.Text = attributes(1).ToString
	End Sub