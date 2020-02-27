<!-- <snippet1> -->
<%@ Page Language="VB" %>

<html>
 <Script runat=server>
' <snippet2>
    Shared itemRemoved As boolean = false
    Shared reason As CacheItemRemovedReason
    Dim onRemove As CacheItemRemovedCallback

    Public Sub RemovedCallback(k As String, v As Object, r As CacheItemRemovedReason)
      itemRemoved = true
      reason = r
    End Sub
' </snippet2>

' <snippet3>
    Public Sub AddItemToCache(sender As Object, e As EventArgs)
        itemRemoved = false

        onRemove = New CacheItemRemovedCallback(AddressOf Me.RemovedCallback)

        If (IsNothing(Cache("Key1"))) Then
          Cache.Add("Key1", "Value 1", Nothing, DateTime.Now.AddSeconds(60), Cache.NoSlidingExpiration, CacheItemPriority.High, onRemove)
        End If
    End Sub
' </snippet3>

' <snippet4>
    Public Sub RemoveItemFromCache(sender As Object, e As EventArgs)
        If (Not IsNothing(Cache("Key1"))) Then
          Cache.Remove("Key1")
        End If
    End Sub
' </snippet4>
 </Script>

 <body>
  <Form runat="server">
    <input type=submit OnServerClick="AddItemToCache" value="Add Item To Cache" runat="server"/>
    <input type=submit OnServerClick="RemoveItemFromCache" value="Remove Item From Cache" runat="server"/>
  </Form>
<%
If (itemRemoved) Then
    Response.Write("RemovedCallback event raised.")
    Response.Write("<BR>")
    Response.Write("Reason: <B>" + reason.ToString() + "</B>")
Else
' <snippet5>
    Response.Write("Value of cache key: <B>" + Server.HtmlEncode(CType(Cache("Key1"),String)) + "</B>")
' </snippet5>
End If
%>
 </body>
</html>
<!-- </snippet1> -->