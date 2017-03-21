Public Sub New()
   ' Create a 'MyCheckBox' control and 
   ' display an image on it. 
   Dim myCheckBox As New MyCustomControls.MyCheckBox()
   myCheckBox.Location = New Point(5, 5)
   myCheckBox.Image = Image.FromFile( _
     Application.CommonAppDataPath + "\Preview.jpg")

   ' Set the AccessibleName property
   ' since there is no Text displayed. 
   myCheckBox.AccessibleName = "Preview"

   ' Set the AccessibleDescription text.
   myCheckBox.AccessibleDescription = _
     "A toggle button used to show the document preview."
   Me.Controls.Add(myCheckBox)
End Sub