' The following code example creates a case-sensitive hashtable and a case-insensitive hashtable
' and demonstrates the difference in their behavior, even if both contain the same elements.

' <Snippet1>
Imports System
Imports System.Collections
Imports System.Globalization

Public Class SamplesHashtable

   Public Shared Sub Main()

      ' Create a Hashtable using the default hash code provider and the default comparer.
      Dim myHT1 As New Hashtable()
      myHT1.Add("FIRST", "Hello")
      myHT1.Add("SECOND", "World")
      myHT1.Add("THIRD", "!")

      ' Create a Hashtable using a case-insensitive code provider and a case-insensitive comparer,
      ' based on the culture of the current thread.
      Dim myHT2 As New Hashtable(New CaseInsensitiveHashCodeProvider(), New CaseInsensitiveComparer())
      myHT2.Add("FIRST", "Hello")
      myHT2.Add("SECOND", "World")
      myHT2.Add("THIRD", "!")

      ' Create a Hashtable using a case-insensitive code provider and a case-insensitive comparer,
      ' based on the InvariantCulture.
      Dim myHT3 As New Hashtable(CaseInsensitiveHashCodeProvider.DefaultInvariant, CaseInsensitiveComparer.DefaultInvariant)
      myHT3.Add("FIRST", "Hello")
      myHT3.Add("SECOND", "World")
      myHT3.Add("THIRD", "!")

      ' Create a Hashtable using a case-insensitive code provider and a case-insensitive comparer,
      ' based on the Turkish culture (tr-TR), where "I" is not the uppercase version of "i".
      Dim myCul As New CultureInfo("tr-TR")
      Dim myHT4 As New Hashtable(New CaseInsensitiveHashCodeProvider(myCul), New CaseInsensitiveComparer(myCul))
      myHT4.Add("FIRST", "Hello")
      myHT4.Add("SECOND", "World")
      myHT4.Add("THIRD", "!")

      ' Search for a key in each hashtable.
      Console.WriteLine("first is in myHT1: {0}", myHT1.ContainsKey("first"))
      Console.WriteLine("first is in myHT2: {0}", myHT2.ContainsKey("first"))
      Console.WriteLine("first is in myHT3: {0}", myHT3.ContainsKey("first"))
      Console.WriteLine("first is in myHT4: {0}", myHT4.ContainsKey("first"))

   End Sub 'Main 

End Class 'SamplesHashtable


'This code produces the following output.  Results vary depending on the system's culture settings.
'
'first is in myHT1: False
'first is in myHT2: True
'first is in myHT3: True
'first is in myHT4: False

' </Snippet1>
