   Function GetFirstCharacter(s As String) As Char
      If String.IsNullOrEmpty(s) Then 
         Return ChrW(0)
      Else   
         Return s(0)
      End If   
   End Function