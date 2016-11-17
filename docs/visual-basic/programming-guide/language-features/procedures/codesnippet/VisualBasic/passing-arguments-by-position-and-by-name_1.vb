  Sub studentInfo(ByVal name As String, 
         Optional ByVal age As Short = 0, 
         Optional ByVal birth As Date = #1/1/2000#)

    Debug.WriteLine("Name = " & name & 
                  "; age = " & CStr(age) & 
                  "; birth date = " & CStr(birth))
  End Sub