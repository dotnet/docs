 Public Overridable Function LoadPostData(postDataKey As String, _
    postCollection As NameValueCollection) As Boolean
        
     Dim presentValue As String = Text
     Dim postedValue As String = postCollection(postDataKey)
        
     If (presentValue Is Nothing) OrElse (Not presentValue.Equals(postedValue)) Then 
         Text = postedValue
         Return True
     End If
     Return False
 End Function
