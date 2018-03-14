' Visual Basic .NET Document
Option Strict On

' <Snippet18>
Public Class Dog
   Private dogBreed As String
   Private dogName As String
   
   Public Sub New(name As String, breed As String)
      Me.dogName = name
      Me.dogBreed = breed
   End Sub
   
   Public ReadOnly Property Breed As String
      Get
         Return Me.dogBreed
      End Get
   End Property
   
   Public ReadOnly Property Name As String
      Get
         Return Me.dogName
      End Get
   End Property
   
   Public Overrides Function ToString() As String
      Return Me.dogName
   End Function
End Class
   
Module Example
   Public Sub Main()
      Dim dog1 As New Dog("Yiska", "Alaskan Malamute")
      Dim sb As New System.Text.StringBuilder()     
      sb.Append(dog1).Append(", Breed: ").Append(dog1.Breed)  
      Console.WriteLine(sb)
   End Sub
End Module
' The example displays the following output:
'       Yiska, Breed: Alaskan Malamute
' </Snippet18>
