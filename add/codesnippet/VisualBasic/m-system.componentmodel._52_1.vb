 Private Sub ContainsAttributes()
     ' Creates a new collection and assigns it the attributes for button1.
     Dim myCollection As AttributeCollection
     myCollection = TypeDescriptor.GetAttributes(button1)
       
     ' Checks to see whether the attributes in myCollection are the attributes for textBox1.
     Dim myAttrArray(100) As Attribute
     TypeDescriptor.GetAttributes(textBox1).CopyTo(myAttrArray, 0)
     If myCollection.Contains(myAttrArray) Then
         textBox1.Text = "Both the button and text box have the same attributes."
     Else
         textBox1.Text = "The button and the text box do not have the same attributes."
     End If
 End Sub