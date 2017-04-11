<%@ page language="VB" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN"
    "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<script runat="server">
  ' <Snippet1>
  Class Sample
    Inherits Control
    
    Dim currentIndex As Integer
    
        Protected Overrides Sub OnInit(ByVal e As EventArgs)
            Page.RegisterRequiresControlState(Me)
            currentIndex = 0
            MyBase.OnInit(e)
        End Sub
    
        Protected Overrides Function SaveControlState() As Object
            If currentIndex <> 0 Then
                Return CType(currentIndex, Object)
            Else
                Return Nothing
            End If
        End Function
    
        Protected Overrides Sub LoadControlState(ByVal state As Object)
            If (state <> Nothing) Then
                currentIndex = CType(state, Integer)
            End If
        End Sub
    
  End Class
  ' </Snippet1>
</script>

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Untitled Page</title>
</head>
<body>
    <form id="form1" runat="server">
      <p>The page worked.</p>
    </form>
</body>
</html>
