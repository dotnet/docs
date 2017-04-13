'<Snippet1>
Module Example
    Public Sub Main()
        ' Define an array of byte values. 
        Dim bytes() As Byte = { 0, 1, 2, 4, 8, 16, 32, 64, 128, 255 }

        Console.WriteLine("{0,5}{1,16}{2,10}\n", "index", "array element", "bool" )
        ' Convert each array element to a Boolean value.
        For index As Integer = 0 To bytes.Length - 1
           Console.WriteLine("{0,5}{1,16:X2}{2,10}", index, bytes(index), 
                             BitConverter.ToBoolean(bytes, index))
        Next                     
    End Sub 
End Module
' The example displays the following output:
'     index   array element      bool
'     
'         0              00     False
'         1              01      True
'         2              02      True
'         3              04      True
'         4              08      True
'         5              10      True
'         6              20      True
'         7              40      True
'         8              80      True
'         9              FF      True
'</Snippet1>