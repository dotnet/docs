' <Snippet1>
Public Module Example
   Public Sub Main()
      ' Create a string array with 3 elements having the same value.
      Dim strings() As String = { "the", "quick", "brown", "fox",
                                  "jumps", "over", "the", "lazy",
                                  "dog", "in", "the", "barn" }

      ' Display the values of the array.
      Console.WriteLine("The array contains the following values:")
      For i As Integer = strings.GetLowerBound(0) To strings.GetUpperBound(0)
         Console.WriteLine("   [{0,2}]: {1}", i, strings(i))
      Next

      ' Search for the first occurrence of the duplicated value.
      Dim searchString As String = "the"
      Dim index As Integer = Array.IndexOf(strings, searchString)
      Console.WriteLine("The first occurrence of ""{0}"" is at index {1}.",
                        searchString, index)
        
      ' Search for the first occurrence of the duplicated value in the last section of the array.
      index = Array.IndexOf(strings, searchString, 4)
      Console.WriteLine("The first occurrence of ""{0}"" between index 4 and the end is at index {1}.",
                        searchString, index)
        
      ' Search for the first occurrence of the duplicated value in a section of the array.
       Dim position As Integer = index + 1
       index = Array.IndexOf(strings, searchString, position, strings.GetUpperBound(0) - position + 1)
       Console.WriteLine("The first occurrence of ""{0}"" between index {1} and index {2} is at index {3}.",
                         searchString, position, strings.GetUpperBound(0), index)
    End Sub
End Module
' The example displays the following output:
'    The array contains the following values:
'       [ 0]: the
'       [ 1]: quick
'       [ 2]: brown
'       [ 3]: fox
'       [ 4]: jumps
'       [ 5]: over
'       [ 6]: the
'       [ 7]: lazy
'       [ 8]: dog
'       [ 9]: in
'       [10]: the
'       [11]: barn
'    The first occurrence of "the" is at index 0.
'    The first occurrence of "the" between index 4 and the end is at index 6.
'    The first occurrence of "the" between index 7 and index 11 is at index 10.
' </Snippet1>
