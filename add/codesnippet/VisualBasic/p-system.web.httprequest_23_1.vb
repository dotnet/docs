Dim loop1 As Integer
Dim arr1() As String
Dim coll As NameValueCollection
 
' Load Form variables into NameValueCollection variable.
coll=Request.Form

' Get names of all forms into a string array.
arr1 = coll.AllKeys
For loop1 = 0 To arr1.GetUpperBound(0)
   Response.Write("Form: " & arr1(loop1) & "<br>")
Next loop1
   