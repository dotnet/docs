Dim MyType() As String
 Dim Indx As Integer
 
 MyType = Request.AcceptTypes
 For Indx = 0 To MyType.GetUpperBound(0)
    Response.Write("Accept Type " & Cstr(Indx) & ": " & Cstr(MyType(Indx)) & "<br>")
 Next Indx
   