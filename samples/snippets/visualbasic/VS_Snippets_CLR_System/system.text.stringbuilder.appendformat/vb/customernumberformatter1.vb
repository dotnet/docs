' Visual Basic .NET Document
Option Strict On

' <Snippet1>
Imports System.Text

Public Class Customer
   Private custName As String
   Private custNumber As Integer
   
   Public Sub New(name As String, number As Integer)
      custName = name
      custNumber = number
   End Sub
   
   Public ReadOnly Property Name As String
      Get
         Return Me.custName
      End Get
   End Property
   
   Public ReadOnly Property CustomerNumber As Integer
      Get
         Return Me.custNumber
      End Get
   End Property
End Class

Public Class CustomerNumberFormatter 
   Implements IFormatProvider, ICustomFormatter
   
   Public Function GetFormat(formatType As Type) As Object _
                   Implements IFormatProvider.GetFormat
      If formatType Is GetType(ICustomFormatter) Then
         Return Me
      End If
      Return Nothing
   End Function
   
   Public Function Format(fmt As String, arg As Object, provider As IFormatProvider) As String _
                   Implements ICustomFormatter.Format
      If typeof arg Is Int32 Then
         Dim custNumber As String = CInt(arg).ToString("D10")
         Return custNumber.Substring(0, 4) + "-" + custNumber.SubString(4, 3) + _
                "-" + custNumber.Substring(7, 3)
      Else
         Return Nothing
      End If
   End Function                   
End Class

Module Example
   Public Sub Main()
      Dim customer As New Customer("A Plus Software", 903654)
      Dim sb As New StringBuilder()
      sb.AppendFormat(New CustomerNumberFormatter, "{0}: {1}", _
                      customer.CustomerNumber, customer.Name)
      Console.WriteLine(sb.ToString())
   End Sub
End Module
' The example displays the following output:
'      0000-903-654: A Plus Software
' </Snippet1>
