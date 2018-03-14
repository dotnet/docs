' The following code example creates hash tables using different Hashtable
' constructors and demonstrates the differences in the behavior of the hash
' tables, even if each one contains the same elements.

' <Snippet1>
Imports System
Imports System.Collections
Imports System.Globalization

Public Class myCultureComparer
    Implements IEqualityComparer

    Dim myComparer As CaseInsensitiveComparer

    Public Sub New()
        myComparer = CaseInsensitiveComparer.DefaultInvariant
    End Sub

    Public Sub New(ByVal myCulture As CultureInfo)
        myComparer = New CaseInsensitiveComparer(myCulture)
    End Sub

    Public Function Equals1(ByVal x As Object, ByVal y As Object) _
        As Boolean Implements IEqualityComparer.Equals

        If (myComparer.Compare(x, y) = 0) Then
            Return True
        Else
            Return False
        End If
    End Function

    Public Function GetHashCode1(ByVal obj As Object) _
        As Integer Implements IEqualityComparer.GetHashCode
        Return obj.ToString().ToLower().GetHashCode()
    End Function
End Class

Public Class SamplesHashtable   

   Public Shared Sub Main()

      ' Create a hash table using the default comparer.
      Dim myHT1 As New Hashtable(3)
      myHT1.Add("FIRST", "Hello")
      myHT1.Add("SECOND", "World")
      myHT1.Add("THIRD", "!")

      ' Create a hash table using the specified IEqualityComparer that uses
      ' the CaseInsensitiveComparer.DefaultInvariant to determine equality.
      Dim myHT2 As New Hashtable(3, New myCultureComparer())
      myHT2.Add("FIRST", "Hello")
      myHT2.Add("SECOND", "World")
      myHT2.Add("THIRD", "!")

      ' Create a hash table using an IEqualityComparer that is based on
      ' the Turkish culture (tr-TR) where "I" is not the uppercase
      ' version of "i".
      Dim myCul As New CultureInfo("tr-TR")
      Dim myHT3 As New Hashtable(3, New myCultureComparer(myCul))
      myHT3.Add("FIRST", "Hello")
      myHT3.Add("SECOND", "World")
      myHT3.Add("THIRD", "!")

      ' Search for a key in each hash table.
      Console.WriteLine("first is in myHT1: {0}", myHT1.ContainsKey("first"))
      Console.WriteLine("first is in myHT2: {0}", myHT2.ContainsKey("first"))
      Console.WriteLine("first is in myHT3: {0}", myHT3.ContainsKey("first"))

   End Sub 'Main 

End Class 'SamplesHashtable


'This code produces the following output.
'Results vary depending on the system's culture settings.
'
'first is in myHT1: False
'first is in myHT2: True
'first is in myHT3: False

' </Snippet1>
