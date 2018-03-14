' <Snippet1>
Imports System.Reflection
Imports System.Collections.Generic

' A custom attribute to allow two authors per method.
<AttributeUsage(AttributeTargets.Method)> _
Public Class AuthorsAttribute : Inherits Attribute
   Protected _authorName1 As String
   Protected _authorName2 As String

   Public Sub New(name1 As String, name2 As String)
      _authorName1 = name1
      _authorName2 = name2
   End Sub

   Public Property AuthorName1() As String
      Get
          Return _authorName1
      End Get
      Set
          _authorName1 = AuthorName1
      End Set
   End Property

   Public Property AuthorName2() As String
      Get
          Return _authorName2
      End Get
      Set
          _authorName2 = AuthorName2
      End Set
   End Property

   Public Overrides Function Equals(obj As Object) As Boolean
      Dim auth As AuthorsAttribute = TryCast(obj, AuthorsAttribute)
      If auth Is Nothing Then Return False
      
      If (_authorName1 = auth._authorName1 And _authorName2 = auth._authorName2) Or
         (_authorName1 = auth._authorName2 And _authorName2 = auth._authorName1)
         Return True
      Else
         Return False
      End If 
   End Function

   ' Use the hash code of the string objects and Xor them together.
   Public Overrides Function GetHashCode() As Integer
      Return _authorName1.GetHashCode() Xor _authorName2.GetHashCode()
   End Function
End Class

' Provide the author names for each method of the class.
Public Class TestClass
   <Authors("Immanuel Kant", "Lao Tzu")> _
   Public Sub Method1()
   End Sub

   <Authors("Jean-Paul Sartre", "Friedrich Nietzsche")> _
   Public Sub Method2()
   End Sub

   <Authors("Immanuel Kant", "Lao Tzu")> _
   Public Sub Method3()
   End Sub

   <Authors("Jean-Paul Sartre", "Friedrich Nietzsche")> _
   Public Sub Method4()
   End Sub

   <Authors("Immanuel Kant", "Friedrich Nietzsche")> _
   Public Sub Method5()
   End Sub
End Class

Public Module Example
    Sub Main()
        ' Get the TestClass type to access its metadata.
        Dim clsType As Type = GetType(TestClass)
        
        ' Store author information in a list of tuples.
        Dim authorsInfo As New List(Of Tuple(Of String, AuthorsAttribute)) 
        ' Iterate through all the methods of the class.
        For Each method In clsType.GetMethods()
            ' Get the authors attribute information 
            Dim authAttr As AuthorsAttribute = CType(Attribute.GetCustomAttribute(method, GetType(AuthorsAttribute)),
                                                     AuthorsAttribute)
            If authAttr IsNot Nothing Then
                ' Add the information to the author list.
                authorsInfo.Add(Tuple.Create(clsType.Name + "." + method.Name,
                                             authAttr))
            End If
        Next

        ' Iterate through the list.
        Dim listed(authorsInfo.Count - 1) As Boolean 
        Console.WriteLine("Method authors:")
        Console.WriteLine()
        For ctr As Integer = 0 To authorsInfo.Count - 1
           Dim authorInfo = authorsInfo(ctr)
           If Not listed(ctr)
              Console.WriteLine("{0} and {1}", authorInfo.Item2.AuthorName1,
                                               authorInfo.Item2.AuthorName2)
              listed(ctr) = True
              Console.WriteLine("   {0}", authorInfo.Item1)
              For ctr2 As Integer = ctr + 1 To authorsInfo.Count - 1
                 If Not listed(ctr2) 
                    If authorInfo.Item2.Equals(authorsInfo(ctr2).Item2) Then
                       Console.WriteLine("   {0}", authorsInfo(ctr2).Item1)
                       listed(ctr2) = true  
                    End if
                 End If 
              Next  
           End If   
        Next
    End Sub
End Module
' The example displays the following output:
'       Method Authors:
'
'       Immanuel Kant and Lao Tzu
'          TestClass.Method1
'          TestClass.Method3
'       Jean-Paul Sartre and Friedrich Nietzsche
'          TestClass.Method2
'          TestClass.Method4
'       Immanuel Kant and Friedrich Nietzsche
'          TestClass.Method5
' </Snippet1>
