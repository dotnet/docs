'<snippet1>
' This example demonstrates the generic and non-generic versions of the 
' CompareTo method for several base types.
' The non-generic version takes a parameter of type Object, while the generic
' version takes a type-specific parameter, such as Boolean, Int32, or Double.

Imports System

Class Sample
   Public Shared Sub Main()
      Dim nl As String = Environment.NewLine
      Dim msg As String = _
          "{0}The following is the result of using the generic and non-generic{0}" & _
          "versions of the CompareTo method for several base types:{0}"
      
      Dim now As DateTime = DateTime.Now
      ' Time span = 11 days, 22 hours, 33 minutes, 44 seconds
      Dim tsX As New TimeSpan(11, 22, 33, 44)
      ' Version = 1.2.333.4
      Dim versX As New Version("1.2.333.4")
      ' Guid = CA761232-ED42-11CE-BACD-00AA0057B223
      Dim guidX As New Guid("{CA761232-ED42-11CE-BACD-00AA0057B223}")
      
      Dim a1 As [Boolean] = True,    a2 As [Boolean] = True
      Dim b1 As [Byte] = 1,          b2 As [Byte] = 1
      Dim c1 As Int16 = -2,          c2 As Int16 = 2
      Dim d1 As Int32 = 3,           d2 As Int32 = 3
      Dim e1 As Int64 = 4,           e2 As Int64 = -4
      Dim f1 As [Decimal] = -5.5D,   f2 As [Decimal] = 5.5D
      Dim g1 As [Single] = 6.6F,     g2 As [Single] = 6.6F
      Dim h1 As [Double] = 7.7,      h2 As [Double] = -7.7
      Dim i1 As [Char] = "A"c,       i2 As [Char] = "A"c
      Dim j1 As String = "abc",      j2 As String = "abc"
      Dim k1 As DateTime = now,      k2 As DateTime = now
      Dim l1 As TimeSpan = tsX,      l2 As TimeSpan = tsX
      Dim m1 As Version = versX,     m2 As New Version("2.0")
      Dim n1 As Guid = guidX,        n2 As Guid = guidX
      
      ' The following types are not CLS-compliant.
      ' SByte, UInt16, UInt32, UInt64

      Console.WriteLine(msg, nl)
      Try
         ' The second and third Show method call parameters are automatically boxed because
         ' the second and third Show method declaration arguments expect type Object.

         Show("Boolean:  ", a1, a2, a1.CompareTo(a2), a1.CompareTo(CObj(a2)))
         Show("Byte:     ", b1, b2, b1.CompareTo(b2), b1.CompareTo(CObj(b2)))
         Show("Int16:    ", c1, c2, c1.CompareTo(c2), c1.CompareTo(CObj(c2)))
         Show("Int32:    ", d1, d2, d1.CompareTo(d2), d1.CompareTo(CObj(d2)))
         Show("Int64:    ", e1, e2, e1.CompareTo(e2), e1.CompareTo(CObj(e2)))
         Show("Decimal:  ", f1, f2, f1.CompareTo(f2), f1.CompareTo(CObj(f2)))
         Show("Single:   ", g1, g2, g1.CompareTo(g2), g1.CompareTo(CObj(g2)))
         Show("Double:   ", h1, h2, h1.CompareTo(h2), h1.CompareTo(CObj(h2)))
         Show("Char:     ", i1, i2, i1.CompareTo(i2), i1.CompareTo(CObj(i2)))
         Show("String:   ", j1, j2, j1.CompareTo(j2), j1.CompareTo(CObj(j2)))
         Show("DateTime: ", k1, k2, k1.CompareTo(k2), k1.CompareTo(CObj(k2)))
         Show("TimeSpan: ", l1, l2, l1.CompareTo(l2), l1.CompareTo(CObj(l2)))
         Show("Version:  ", m1, m2, m1.CompareTo(m2), m1.CompareTo(CObj(m2)))
         Show("Guid:     ", n1, n2, n1.CompareTo(n2), n1.CompareTo(CObj(n2)))
         '
         Console.WriteLine("{0}The following types are not CLS-compliant:", nl)
         Console.WriteLine("SByte, UInt16, UInt32, UInt64")

      Catch e As Exception
         Console.WriteLine(e)
      End Try
   End Sub 'Main
   
   Public Shared Sub Show(caption As String, var1 As [Object], var2 As [Object], _
                          resultGeneric As Integer, resultNonGeneric As Integer)
      Dim relation As String
      
      Console.Write(caption)
      If resultGeneric = resultNonGeneric Then
         If resultGeneric < 0 Then
            relation = "less than"
         ElseIf resultGeneric > 0 Then
            relation = "greater than"
         Else
            relation = "equal to"
         End If
         Console.WriteLine("{0} is {1} {2}", var1, relation, var2)
      
      ' The following condition will never occur because the generic and non-generic
      ' CompareTo methods are equivalent.

      Else
         Console.WriteLine("Generic CompareTo = {0}; non-generic CompareTo = {1}", _
                            resultGeneric, resultNonGeneric)
      End If
   End Sub 'Show
End Class 'Sample
'
'This example produces the following results:
'
'The following is the result of using the generic and non-generic versions of the
'CompareTo method for several base types:
'
'Boolean:  True is equal to True
'Byte:     1 is equal to 1
'Int16:    -2 is less than 2
'Int32:    3 is equal to 3
'Int64:    4 is greater than -4
'Decimal:  -5.5 is less than 5.5
'Single:   6.6 is equal to 6.6
'Double:   7.7 is greater than -7.7
'Char:     A is equal to A
'String:   abc is equal to abc
'DateTime: 12/1/2003 5:37:46 PM is equal to 12/1/2003 5:37:46 PM
'TimeSpan: 11.22:33:44 is equal to 11.22:33:44
'Version:  1.2.333.4 is less than 2.0
'Guid:     ca761232-ed42-11ce-bacd-00aa0057b223 is equal to ca761232-ed42-11ce-bacd-00
'aa0057b223
'
'The following types are not CLS-compliant:
'SByte, UInt16, UInt32, UInt64
'
'</snippet1>