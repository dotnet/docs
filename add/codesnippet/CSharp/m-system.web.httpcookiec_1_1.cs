// Create the one-dimensional target array.
 // Dimension it large enough to hold the cookies collection.
 Array MyArray = Array.CreateInstance( typeof(String), Request.Cookies.Count );
 
 // Copy the entire collection to the array.
 Request.Cookies.CopyTo( MyArray, 0 );
    