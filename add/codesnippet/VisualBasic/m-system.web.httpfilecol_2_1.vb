' Create the one-dimensional target array.
 ' Dimension it large enough to hold the files collection.
 Dim MyArray As Array = Array.CreateInstance(GetType(String), Request.Files.Count)
 
 ' Copy the entire collection to the array.
 Request.Files.CopyTo(MyArray, 0)
    