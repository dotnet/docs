' Visual Basic .NET Document
Option Strict On

' <Snippet11>
Imports System.Collections.Generic
Imports System.Threading

Public Class Continent
   Public Property Name As String
   Public Property Population As Integer
   Public Property Area As Decimal  
End Class

Module Example
   Dim continents As New List(Of Continent)
   Dim msg As String 
      
   Public Sub Main()
      Dim names() As String = { "Africa", "Antarctica", "Asia", 
                                     "Australia", "Europe", "North America",
                                     "South America" }
      ' Populate the list.
      For Each name In names
         Dim th As New Thread(AddressOf PopulateContinents)
         th.Start(name)
      Next              
      Console.WriteLine(msg)
      Console.WriteLine()

      ' Display the list.
      For ctr As Integer = 0 To names.Length - 1
         Dim continent = continents(ctr)
         Console.WriteLine("{0}: Area: {1}, Population {2}", 
                           continent.Name, continent.Population,
                           continent.Area)
      Next
   End Sub
   
   Private Sub PopulateContinents(obj As Object)
      Dim name As String = obj.ToString()
      msg += String.Format("Adding '{0}' to the list.{1}", name, vbCrLf)
      Dim continent As New Continent()
      continent.Name = name
      ' Sleep to simulate retrieving remaining data.
      Thread.Sleep(50)
      continents.Add(continent)
   End Sub
End Module
' The example displays output like the following:
'    Adding 'Africa' to the list.
'    Adding 'Antarctica' to the list.
'    Adding 'Asia' to the list.
'    Adding 'Australia' to the list.
'    Adding 'Europe' to the list.
'    Adding 'North America' to the list.
'    Adding 'South America' to the list.
'    
'    
'    
'    Unhandled Exception: System.ArgumentOutOfRangeException: Index was out of range. Must be non-negative and less than the size of the collection.
'    Parameter name: index
'       at System.ThrowHelper.ThrowArgumentOutOfRangeException(ExceptionArgument argument, ExceptionResource resource)
'       at Example.Main()
' </Snippet11>

