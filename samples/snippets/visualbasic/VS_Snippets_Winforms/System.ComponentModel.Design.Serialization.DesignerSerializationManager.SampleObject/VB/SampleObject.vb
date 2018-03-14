 ' <snippet10>
Imports System
Imports System.Text

' <snippet11>
Public Class SampleObject
   Private stringValue As String = Nothing
   Private intValue As Integer = Integer.MinValue
   Private childValue As SampleObject = Nothing
   
   
   Public Property StringProperty() As String
      Get
         Return Me.stringValue
      End Get 
      Set
         Me.stringValue = value
      End Set
   End Property 
   
   Public Property IntProperty() As Integer
      Get
         Return Me.intValue
      End Get 
      Set
         Me.intValue = value
      End Set
   End Property 
   
   Public Property Child() As SampleObject
      Get
         Return Me.childValue
      End Get 
      Set
         Me.childValue = value
      End Set
   End Property
End Class 
' </snippet11>

' <snippet12>
Class Program
   
   Public Overloads Shared Sub Main()
      Main(System.Environment.GetCommandLineArgs())
   End Sub
   
   ' <snippet13>
   Overloads Shared Sub Main(args() As String)
      ' <snippet14>
      Dim root As New SampleObject()
      
      Dim currentObject As SampleObject = root
      
      Dim i As Integer
      For i = 0 To 9
         Dim o As New SampleObject()
         
         currentObject.Child = o
         
         currentObject = o
      Next i
      ' </snippet14>
   End Sub 
   ' </snippet13>   
End Class
' </snippet12>
' </snippet10>