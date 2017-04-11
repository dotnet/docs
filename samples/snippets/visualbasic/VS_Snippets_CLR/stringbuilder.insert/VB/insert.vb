' This example demonstrates StringBuilder.Insert()
'<snippet1>
Imports System
Imports System.Text

Class Sample
   '                                 index: 012345
   Private Shared initialValue As String = "--[]--"
   Private Shared sb As StringBuilder
   
   Public Shared Sub Main()
      Dim xyz As String = "xyz"
      Dim abc As Char() =  {"a"c, "b"c, "c"c}
      Dim star As Char = "*"c
      Dim obj As [Object] = 0
      
      Dim xBool As Boolean = True
      Dim xByte As Byte = 1
      Dim xInt16 As Short = 2
      Dim xInt32 As Integer = 3
      Dim xInt64 As Long = 4
      Dim xDecimal As [Decimal] = 5
      Dim xSingle As Single = 6.6F
      Dim xDouble As Double = 7.7
      
      ' The following types are not CLS-compliant.
      ' Dim xUInt16 As System.UInt16 = 8 
      ' Dim xUInt32 As System.UInt32 = 9
      ' Dim xUInt64 As System.UInt64 = 10 
      ' Dim xSByte As System.SByte = - 11
      '
      Console.WriteLine("StringBuilder.Insert method")
      sb = New StringBuilder(initialValue)
      
      sb.Insert(3, xyz, 2)
      Show(1, sb)
      
      sb.Insert(3, xyz)
      Show(2, sb)
      
      sb.Insert(3, star)
      Show(3, sb)
      
      sb.Insert(3, abc)
      Show(4, sb)
      
      sb.Insert(3, abc, 1, 2)
      Show(5, sb)
      
      sb.Insert(3, xBool)     ' True
      Show(6, sb)
      
      sb.Insert(3, obj)       ' 0
      Show(7, sb)
      
      sb.Insert(3, xByte)     ' 1
      Show(8, sb)
      
      sb.Insert(3, xInt16)    ' 2
      Show(9, sb)
      
      sb.Insert(3, xInt32)    ' 3
      Show(10, sb)
      
      sb.Insert(3, xInt64)    ' 4
      Show(11, sb)
      
      sb.Insert(3, xDecimal)  ' 5
      Show(12, sb)
      
      sb.Insert(3, xSingle)   ' 6.6
      Show(13, sb)
      
      sb.Insert(3, xDouble)   ' 7.7
      Show(14, sb)
      
      ' The following Insert methods are not CLS-compliant.
      ' sb.Insert(3, xUInt16) ' 8
      ' sb.Insert(3, xUInt32) ' 9
      ' sb.Insert(3, xUInt64) ' 10
      ' sb.Insert(3, xSByte)  ' -11

   End Sub 'Main
   
   Public Shared Sub Show(overloadNumber As Integer, sbs As StringBuilder)
      Console.WriteLine("{0,2:G} = {1}", overloadNumber, sbs.ToString())
      sb = New StringBuilder(initialValue)
   End Sub 'Show
End Class 'Sample
'
'This example produces the following results:
'
'StringBuilder.Insert method
' 1 = --[xyzxyz]--
' 2 = --[xyz]--
' 3 = --[*]--
' 4 = --[abc]--
' 5 = --[bc]--
' 6 = --[True]--
' 7 = --[0]--
' 8 = --[1]--
' 9 = --[2]--
'10 = --[3]--
'11 = --[4]--
'12 = --[5]--
'13 = --[6.6]--
'14 = --[7.7]--
'
'</snippet1>