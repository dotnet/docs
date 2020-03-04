Imports System.Collections.Generic
Imports System.Reflection
                                                               
' A custom attribute to allow multiple authors per method.
<AttributeUsage(AttributeTargets.Method)> _
Public Class AuthorsAttribute : Inherits Attribute 
   Protected _authors As List(Of String)

	Public Sub New(paramarray names As String()) 
      _authors = New List(Of string)(names)
	End Sub

   Public ReadOnly Property Authors As List(Of String) 
	   Get 
         Return _authors
      End Get   
   End Property

	' Determine if the object is a match to this one.
	Public Overrides Function Match(obj As Object) As Boolean 
      ' Return false if obj is null or not an AuthorsAttribute.
      Dim authors2 As AuthorsAttribute = DirectCast(obj, AuthorsAttribute)
      If authors2 Is Nothing Then Return False
      
		' Return true if obj and this instance are the same object reference.
      If Object.ReferenceEquals(Me, authors2) Then Return True

      ' Return false if obj and this instance have different numbers of authors
      If _authors.Count <> authors2._authors.Count Then Return False
         
      Dim matches As Boolean = False
      For Each author in _authors 
         For ctr As Integer = 0 To authors2._authors.Count - 1
            If author = authors2._authors(ctr) Then
               matches = True
               Exit For
            End If
            If ctr = authors2._authors.Count Then matches = False
         Next
      Next
      Return matches
   End Function

   Public Overrides Function ToString() As String
      Dim retval As String = ""
      For ctr As Integer = 0 To _authors.Count -1
         retval += $"{_authors(ctr)}{If(ctr < _authors.Count - 1, ", ", String.Empty)}"
      Next
      If retval.Trim().Length = 0 Then Return "<unknown>"

      Return retval
   End Function
End Class

' Add some authors to methods of a class.
Public Class TestClass 
	<Authors("Leo Tolstoy", "John Milton")>
	Public sub Method1()
	End sub

	<Authors("Anonymous")>
	Public Sub Method2()
	End Sub

	<Authors("Leo Tolstoy", "John Milton", "Nathaniel Hawthorne")>
	Public Sub Method3()
	End Sub

	<Authors("John Milton", "Leo Tolstoy")>
	Public Sub Method4()
	End Sub
End Class

Public Module Example 
	Public Sub Main() 
		' Get the type for TestClass to access its metadata.
		Dim clsType As Type = GetType(TestClass)

		' Iterate through each method of the class.
      Dim authors As AuthorsAttribute = Nothing
		For Each method In clsType.GetMethods() 
			' Check each method for the Authors attribute.
			Dim authAttr As AuthorsAttribute = DirectCast(Attribute.GetCustomAttribute(method, 
				                         GetType(AuthorsAttribute)), AuthorsAttribute)
			If authAttr IsNot Nothing Then 
            ' Display the authors.
				Console.WriteLine($"{clsType.Name}.{method.Name} was authored by {authAttr}.")

            ' Select Method1's authors as the basis for comparison.
            If method.Name = "Method1" Then
				   authors = authAttr
               Console.WriteLine()
               Continue For
            End If
         
   			' Compare first authors with the authors of this method.
            If authors.Match(authAttr) Then
					Console.WriteLine("TestClass.Method1 was also authored by the same team.")
            End If

            ' Perform an equality comparison of the two attributes.
            Console.WriteLine($"{authors} {If(authors.Equals(authAttr), "=", "<>")} {authAttr}")
            Console.WriteLine()
			End If
      Next
   End Sub
End Module
' The example displays the following output:
//       TestClass.Method1 was authored by Leo Tolstoy, John Milton.
//       
//       TestClass.Method2 was authored by Anonymous.
//       Leo Tolstoy, John Milton <> Anonymous
//       
//       TestClass.Method3 was authored by Leo Tolstoy, John Milton, Nathaniel Hawthorne.
//       Leo Tolstoy, John Milton <> Leo Tolstoy, John Milton, Nathaniel Hawthorne
//       
//       TestClass.Method4 was authored by John Milton, Leo Tolstoy.
//       TestClass.Method1 was also authored by the same team.
//       Leo Tolstoy, John Milton <> John Milton, Leo Tolstoy

