Dim Loop1 As Integer
Dim StateVars(Application.Count) As String
 
For Loop1 = 0 To Application.Count -1
   StateVars(Loop1) = Application.GetKey(Loop1)
Next Loop1