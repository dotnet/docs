' Visual Basic .NET Document
Option Strict On

' <Snippet1>
Imports System.Collections
Imports System.Globalization
Imports System.Reflection

Public Class Example : Implements IComparer
   Public Shared Sub Main()
      Dim nfi1 As NumberFormatInfo = NumberFormatInfo.CurrentInfo
      Dim nfi2 As NumberFormatInfo = CultureInfo.CurrentCulture.NumberFormat
      Console.WriteLine("Objects equal: {0}", nfi1.Equals(nfi2))
      Console.WriteLine("Equal references: {0}", Object.ReferenceEquals(nfi1, nfi2))
      Console.WriteLine()
      
      Dim props() As PropertyInfo = nfi1.GetType().GetProperties(BindingFlags.Instance Or BindingFlags.Public)
      Array.Sort(props, New Example)
      Console.WriteLine("Properties of NumberFormat.CurrentInfo object:")
      For Each prop In props
         If prop.PropertyType.IsArray Then
            Dim arr As Array = CType(prop.GetValue(nfi1), Array)
            Console.Write(String.Format("   {0}: ", prop.Name) + "{ ")
            Dim ctr As Integer = 0
            For Each item In arr
               Console.Write("{0}{1}", item, If(ctr = arr.Length - 1, " }", ", "))
               ctr += 1
            Next
            Console.WriteLine()
         Else
            Console.WriteLine("   {0}: {1}", prop.Name, prop.GetValue(nfi1))
        End If   
      Next      
   End Sub
   
   Private Function Compare(x As Object, y As Object) As Integer _
      Implements IComparer.Compare
      
      If x Is Nothing And y Is Nothing Then Return 0
      Dim px As PropertyInfo = TryCast(x, PropertyInfo)
      If px Is Nothing Then Return -1
      
      Dim py As PropertyInfo = TryCast(y, PropertyInfo)
      If py Is Nothing Then Return 1
      
      Return String.Compare(px.Name, py.Name)
   End Function
End Class
' The example displays the following output:
'       Objects equal: True
'       Equal references: True
'       
'       Properties of NumberFormat.CurrentInfo object:
'          CurrencyDecimalDigits: 2
'          CurrencyDecimalSeparator: .
'          CurrencyGroupSeparator: ,
'          CurrencyGroupSizes: { 3 }
'          CurrencyNegativePattern: 0
'          CurrencyPositivePattern: 0
'          CurrencySymbol: $
'          DigitSubstitution: None
'          IsReadOnly: True
'          NaNSymbol: NaN
'          NativeDigits: { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9 }
'          NegativeInfinitySymbol: -Infinity
'          NegativeSign: -
'          NumberDecimalDigits: 2
'          NumberDecimalSeparator: .
'          NumberGroupSeparator: ,
'          NumberGroupSizes: { 3 }
'          NumberNegativePattern: 1
'          PercentDecimalDigits: 2
'          PercentDecimalSeparator: .
'          PercentGroupSeparator: ,
'          PercentGroupSizes: { 3 }
'          PercentNegativePattern: 0
'          PercentPositivePattern: 0
'          PercentSymbol: %
'          PerMilleSymbol: %
'          PositiveInfinitySymbol: Infinity
'          PositiveSign: +
' </Snippet1>
