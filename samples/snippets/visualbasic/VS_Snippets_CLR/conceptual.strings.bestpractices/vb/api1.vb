' Visual Basic .NET Document
Option Strict On

Module modMain
   Public Sub Main()
      Dim file1 As New FileName("autoexec.bat", Nothing)
      Dim file2 As New FileName("AutoExec.BAT", Nothing)
      Console.WriteLine(file1.CompareTo(file2))
   End Sub
End Module

'<Snippet6>
Public Class FileName : Implements IComparable
   Dim fname As String
   Dim comparer As StringComparer 
   
   Public Sub New(name As String, comparer As StringComparer)
      If String.IsNullOrEmpty(name) Then
         Throw New ArgumentNullException("name")
      End If

      Me.fname = name
      
      If comparer IsNot Nothing Then
         Me.comparer = comparer
      Else
         Me.comparer = StringComparer.OrdinalIgnoreCase
      End If      
   End Sub

   Public ReadOnly Property Name As String
      Get
         Return fname
      End Get   
   End Property
   
   Public Function CompareTo(obj As Object) As Integer _
          Implements IComparable.CompareTo
      If obj Is Nothing Then Return 1

      If Not TypeOf obj Is FileName Then
         obj = obj.ToString()
      Else
         obj = CType(obj, FileName).Name
      End If         
      Return comparer.Compare(Me.fname, obj)
   End Function
End Class
' </Snippet6>
