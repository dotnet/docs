' Visual Basic .NET Document
Option Strict On

' <Snippet11>
Imports System.Text
' </Snippet11>

<Assembly: CLSCompliant(True)>
Module Example
   Public Sub Main()
      InstantiateStringBuilder()
      InstantiateWithCapacity()
      Appending()
      AppendingFormat()
      Inserting()
      Removing()
      Replacing()
   End Sub
   
   Private Sub InstantiateStringBuilder()
      ' <Snippet1>
      Dim MyStringBuilder As New StringBuilder("Hello World!")
      ' </Snippet1>
   End Sub
   
   Private Sub InstantiateWithCapacity()
      ' <Snippet2>
      Dim MyStringBuilder As New StringBuilder("Hello World!", 25) 
      ' </Snippet2>
      ' <Snippet3>
      MyStringBuilder.Capacity = 25
      ' </Snippet3>
   End Sub
   
   Private Sub Appending()
      ' <Snippet4>
      Dim MyStringBuilder As New StringBuilder("Hello World!")
      MyStringBuilder.Append(" What a beautiful day.")
      Console.WriteLine(MyStringBuilder)
      ' The example displays the following output:
      '       Hello World! What a beautiful day.
      ' </Snippet4>
   End Sub

   Private Sub AppendingFormat()
      ' <Snippet5>
      Dim MyInt As Integer = 25
      Dim MyStringBuilder As New StringBuilder("Your total is ")
      MyStringBuilder.AppendFormat("{0:C} ", MyInt)
      Console.WriteLine(MyStringBuilder)
      ' The example displays the following output:
      '     Your total is $25.00  
      ' </Snippet5>
   End Sub

   Private Sub Inserting()
      ' <Snippet6>
      Dim MyStringBuilder As New StringBuilder("Hello World!")
      MyStringBuilder.Insert(6, "Beautiful ")
      Console.WriteLine(MyStringBuilder)
      ' The example displays the following output:
      '      Hello Beautiful World!
      ' </Snippet6>
   End Sub

   Private Sub Removing()
      ' <Snippet7>
      Dim MyStringBuilder As New StringBuilder("Hello World!")
      MyStringBuilder.Remove(5, 7)
      Console.WriteLine(MyStringBuilder)
      ' The example displays the following output:
      '       Hello
      ' </Snippet7>
   End Sub
   
   Private Sub Replacing()
      ' <Snippet8>
      Dim MyStringBuilder As New StringBuilder("Hello World!")
      MyStringBuilder.Replace("!"c, "?"c)
      Console.WriteLine(MyStringBuilder)
      ' The example displays the following output:
      '       Hello World?
      ' </Snippet8>
   End Sub
End Module

