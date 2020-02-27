<%@ Page Language="C#"%>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<script runat="server">

  public void Page_Load()
  {
    //<Snippet1>
    //<Snippet2>
    // Create an empty ParserErrorCollection.
    ParserErrorCollection collection = new ParserErrorCollection();
    //</Snippet2>

    //<Snippet3>
    // Add a ParserError to the collection.
    collection.Add(new ParserError("ErrorName", "Path", 1));
    //</Snippet3>

    //<Snippet4>
    // Add an array of ParserError objects to the collection.
    ParserError[] errors = 
        { new ParserError("Error 2", "Path", 1), 
        new ParserError("Error 3", "Path", 1) };
    collection.AddRange(errors);

    // Add a collection of ParserError objects to the collection.
    ParserErrorCollection errorsCollection = new ParserErrorCollection();
    errorsCollection.Add(new ParserError("Error", "Path", 1));
    errorsCollection.Add(new ParserError("Error", "Path", 1));
    collection.AddRange(errorsCollection);
    //</Snippet4>

    //<Snippet5>
    // Test for the presence of a ParserError in the 
    // collection, and retrieve its index if it is found.
    ParserError testError = new ParserError("Error", "Path", 1);
    int itemIndex = -1;
    if (collection.Contains(testError))
      itemIndex = collection.IndexOf(testError);
    //</Snippet5>

    //<Snippet6>
    // Copy the contents of the collection to a
    // compatible array, starting at index 0 of the
    // destination array. 
    ParserError[] errorsToSort = new ParserError[5];
    collection.CopyTo(errorsToSort, 0);
    //</Snippet6>

    //<Snippet7>
    // Retrieve the count of the items in the collection.
    int collectionCount = collection.Count;
    //</Snippet7>

    //<Snippet8>
    // Insert a ParserError at index 0 of the collection.
    ParserError error = new ParserError("Error", "Path", 1);
    collection.Insert(0, error);

    // Remove the specified ParserError from the collection.
    collection.Remove(error);
    //</Snippet8>

    //<Snippet10>
    // Remove the ParserError at index 0.
    collection.RemoveAt(0);
    //</Snippet10>
    //</Snippet1>
  }
  
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
