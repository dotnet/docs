<%@ Page Language="VB" AutoEventWireup="True" Debug="true"%>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<script runat="server">

  Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs)

    '<Snippet1>
    '<Snippet2>
    ' Create an empty ParserErrorCollection.
    Dim collection As New ParserErrorCollection()
    '</Snippet2>

    '<Snippet3>
    ' Add a ParserError to the collection.
    collection.Add(New ParserError("ErrorName", "Path", 1))
    '</Snippet3>

    '<Snippet4>
    ' Add an array of ParserError objects to the collection.
    Dim errors As ParserError() = _
        {New ParserError("Error 2", "Path", 1), _
        New ParserError("Error 3", "Path", 1)}
    collection.AddRange(errors)

    ' Ads a collection of ParserError objects to the collection.
    Dim errorsCollection As New ParserErrorCollection()
    errorsCollection.Add(New ParserError("Error", "Path", 1))
    errorsCollection.Add(New ParserError("Error", "Path", 1))
    collection.AddRange(errorsCollection)
    '</Snippet4>

    '<Snippet5>
    ' Test for the presence of a ParserError in the 
    ' collection, and retrieve its index if it is found.
    Dim testError As New ParserError("Error", "Path", 1)
    Dim itemIndex As Integer = -1
    If collection.Contains(testError) Then
      itemIndex = collection.IndexOf(testError)
    End If
    '</Snippet5>

    '<Snippet6>
    ' Copy the contents of the collection to a
    ' compatible array, starting at index 0 of the
    ' destination array. 
    Dim errorsToSort(5) As ParserError
    collection.CopyTo(errorsToSort, 0)
    '</Snippet6>

    '<Snippet7>
    ' Retrieve the count of the items in the collection.
    Dim collectionCount As Integer = collection.Count
    '</Snippet7>

    '<Snippet8>
    ' Insert a ParserError at index 0 of the collection.
    Dim [error] As New ParserError("Error", "Path", 1)
    collection.Insert(0, [error])

    ' Remove the specified ParserError from the collection.
    collection.Remove([error])
    '</Snippet8>

    '<Snippet10>
    ' Remove the ParserError at index 0.
    collection.RemoveAt(0)
    '</Snippet10>
    '</Snippet1>
    
  End Sub
  
</script>

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>ParserErrorCollection Example</title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
    </div>
    </form>
</body>
</html>
