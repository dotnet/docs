' <Snippet1>
Public Module Example    
    Public Sub Main()
        ' Create a one-dimensional integer array.
        Dim integers() As Integer = { 2, 4, 6, 8, 10, 12, 14, 16, 18, 20 }
        ' Get the upper and lower bound of the array.
        Dim upper As Integer = integers.GetUpperBound(0)
        Dim lower As Integer = integers.GetLowerBound(0)
        Console.WriteLine("Elements from index {0} to {1}:", lower, upper)
        ' Iterate the array.
        For ctr As Integer = lower To upper
           Console.Write("{0}{1}{2}", If(ctr = lower, "   ", ""), 
                                     integers(ctr), 
                                     If(ctr < upper, ", ", vbCrLf))
        Next
        Console.WriteLine()
        
        ' Create a two-dimensional integer array.
        Dim integers2d(,) As Integer = {{2, 4}, {3, 9}, {4, 16}, {5, 25}, 
                                       {6, 36}, {7, 49}, {8, 64}, {9, 81} } 
        ' Get the number of dimensions.                               
        Dim rank As Integer = integers2d.Rank  
        Console.WriteLine("Number of dimensions: {0}", rank)      
        For ctr As Integer = 0 To integers2d.Rank - 1
           Console.WriteLine("   Dimension {0}: from {1} to {2}",
                             ctr, integers2d.GetLowerBound(ctr),
                             integers2d.GetUpperBound(ctr))
        Next
        ' Iterate the 2-dimensional array and display its values.
        Console.WriteLine("   Values of array elements:")
        For outer = integers2d.GetLowerBound(0) To integers2d.GetUpperBound(0)
           For inner = integers2d.GetLowerBound(1) To integers2d.GetUpperBound(1)
              Console.WriteLine("      {3}{0}, {1}{4} = {2}", outer, inner,
                                integers2d.GetValue(outer, inner), "{", "}")
           Next
        Next
    End Sub
End Module
' The example displays the following output.
'       Elements from index 0 to 9:
'          2, 4, 6, 8, 10, 12, 14, 16, 18, 20
'       
'       Number of dimensions: 2
'          Dimension 0: from 0 to 7
'          Dimension 1: from 0 to 1
'          Values of array elements:
'             {0, 0} = 2
'             {0, 1} = 4
'             {1, 0} = 3
'             {1, 1} = 9
'             {2, 0} = 4
'             {2, 1} = 16
'             {3, 0} = 5
'             {3, 1} = 25
'             {4, 0} = 6
'             {4, 1} = 36
'             {5, 0} = 7
'             {5, 1} = 49
'             {6, 0} = 8
'             {6, 1} = 64
'             {7, 0} = 9
'             {7, 1} = 81
' </Snippet1>
' Original: 97 lines.