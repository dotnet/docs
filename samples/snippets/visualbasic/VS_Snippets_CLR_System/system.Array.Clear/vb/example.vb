' <Snippet1>
Module Example
    Sub Main()
        Console.WriteLine(vbLf & "One dimension (Rank=1):")
        Dim numbers1() As Integer = {1, 2, 3, 4, 5, 6, 7, 8, 9}

        For i As Integer = 0 To 8
            Console.Write("{0} ", numbers1(i))
        Next 
        Console.WriteLine()

        Console.WriteLine(vbLf & "Array.Clear(numbers1, 2, 5)")
        Array.Clear(numbers1, 2, 5)

        For i As Integer = 0 To 8
            Console.Write("{0} ", numbers1(i))
        Next 
        Console.WriteLine()


        Console.WriteLine(vbLf & "Two dimensions (Rank=2):")
        Dim numbers2(,) As Integer = {{ 1, 2, 3 }, { 4, 5, 6 }, { 7, 8, 9 }}

        For i As Integer = 0 To 2
            For j As Integer = 0 To 2
                Console.Write("{0} ", numbers2(i, j))
            Next 
            Console.WriteLine()
        Next 

        Console.WriteLine(vbLf & "Array.Clear(numbers2, 2, 5)")
        Array.Clear(numbers2, 2, 5)

        For i As Integer = 0 To 2
            For j As Integer = 0 To 2
                Console.Write("{0} ", numbers2(i, j))
            Next 
            Console.WriteLine()
        Next 


        Console.WriteLine(vbLf & "Three dimensions (Rank=3):")
        Dim numbers3(,,) As Integer = {{{ 1, 2 }, { 3, 4 }}, _
                                       {{ 5, 6 }, { 7, 8 }}, _
                                       {{ 9, 10 }, { 11, 12 }}}

        For i As Integer = 0 To 1
            For j As Integer = 0 To 1
                For k As Integer = 0 To 1
                    Console.Write("{0} ", numbers3(i, j, k))
                Next 
                Console.WriteLine()
            Next 
            Console.WriteLine()
        Next 
        Console.WriteLine()
        
        Console.WriteLine("Array.Clear(numbers3, 2, 5)")
        Array.Clear(numbers3, 2, 5)

        For i As Integer = 0 To 1
            For j As Integer = 0 To 1
                For k As Integer = 0 To 1
                    Console.Write("{0} ", numbers3(i, j, k))
                Next 
                Console.WriteLine()
            Next 
            Console.WriteLine()
        Next 
    End Sub
End Module
' The example displays the following output:
'       One dimension (Rank=1):
'       1 2 3 4 5 6 7 8 9
'       
'       Array.Clear(numbers1, 2, 5)
'       1 2 0 0 0 0 0 8 9
'       
'       Two dimensions (Rank=2):
'       1 2 3
'       4 5 6
'       7 8 9
'       
'       Array.Clear(numbers2, 2, 5)
'       1 2 0
'       0 0 0
'       0 8 9
'       
'       Three dimensions (Rank=3):
'       1 2
'       3 4
'
'       5 6
'       7 8
'       
'       Array.Clear(numbers3, 2, 5)
'       1 2
'       0 0
'       
'       0 0
'       0 8
' </Snippet1>