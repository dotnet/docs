Dim loop1 As Integer
 Dim MyFileColl As HttpFileCollection = Request.Files
 
 For loop1 = 0 To MyFileColl.Count - 1
    If MyFileColl.GetKey(loop1) = "CustInfo" Then
       '...
    End If
 Next loop1
    