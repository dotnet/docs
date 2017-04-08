' Visual Basic .NET Document
Option Strict On

' <Snippet1>
Imports System.Reflection

Public Class Planet
   Private planetName As String
   Private distanceFromEarth As Double
   
   Public Sub New(name As String, distance As Double)
      planetName = name
      distanceFromEarth = distance
   End Sub 

   Public ReadOnly Property Name As String
      Get
         Return planetName
      End Get
   End Property
   
   Public Property Distance As Double
      Get
         Return distanceFromEarth
      End Get
      Set
         distanceFromEarth = value
      End Set
   End Property
End Class

Module Example
   Public Sub Main()
      Dim jupiter As New Planet("Jupiter", 3.65e08);
      GetPropertyValues(jupiter)
   End Sub
   
   Private Sub GetPropertyValues(obj As Object)
      Dim t As Type = obj.GetType()
      Console.WriteLine("Type is: {0}", t.Name)
      Dim props() As PropertyInfo = t.GetProperties()
      Console.WriteLine("Properties (N = {0}):", 
                        props.Length)
      For Each prop In props
         If prop.GetIndexParameters().Length = 0 Then
            Console.WriteLine("   {0} ({1}): {2}", prop.Name,
                              prop.PropertyType.Name,
                              prop.GetValue(obj))
         Else
            Console.WriteLine("   {0} ({1}): <Indexed>", prop.Name,
                              prop.PropertyType.Name)
         End If                  
      Next                         
   End Sub
End Module
' The example displays the following output:
'       Type is: Planet
'       Properties (N = 2):
'          Name (String): Jupiter
'          Distance (Double): 365000000
' </Snippet1>

