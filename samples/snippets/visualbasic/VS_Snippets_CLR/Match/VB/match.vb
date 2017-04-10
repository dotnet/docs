' <Snippet1>
Imports System.Reflection

' A custom attribute to allow 2 authors per method.
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
         _authorName1 = value
      End Set
   End Property
   
   Public Property AuthorName2() As String
      Get
         Return _authorName2
      End Get
      Set
         _authorName2 = value
      End Set
   End Property
   
   Public Overrides Function Equals(obj As Object) As Boolean
      Dim auth As AuthorsAttribute = TryCast(obj, AuthorsAttribute)
      If auth Is Nothing Then Return False

      Return (_authorName1 = obj.AuthorName1 And 
              _authorName2 = obj.AuthorName2) Or
              (_authorName1 = obj.AuthorName2 And
              _authorName2 = obj.AuthorName1)
   End Function
   
   ' Use the hash code of the string objects and xor them together.
   Public Overrides Function GetHashCode() As Integer
      Return _authorName1.GetHashCode() XOr _authorName2.GetHashCode()
   End Function
   
   ' Determine if the object is a match to this one.
   Public Overrides Function Match(ByVal obj As Object) As Boolean
      ' Obviously a match.
      If obj Is Me Then
         Return True
      End If
   
      ' Obviously we're not nothing, so no.
      If obj Is Nothing Then
         Return False
      End If
   
      Dim authObj As AuthorsAttribute = TryCast(obj, AuthorsAttribute)
      If authObj IsNot Nothing Then
         ' Check for identical order.
         If _authorName1 = authObj._authorName1 And
            _authorName2 = authObj._authorName2 Then
            Return True
         ' Check for reversed order.
         Else If _authorName1 = authObj._authorName2 And
            _authorName2 = authObj._authorName1 Then
            Return True
         Else
            Return False
         End If
      Else
         Return False
      End If
   End Function
End Class

' Add some authors to methods of a class.
Public Class TestClass1
   <Authors("William Shakespeare", "Herman Melville")> _
   Public Sub Method1()
   End Sub

   <Authors("Leo Tolstoy", "John Milton")> _
   Public Sub Method2()
   End Sub
End Class

' Add authors to a second class's methods.
Public Class TestClass2
   <Authors("William Shakespeare", "Herman Melville")> _
   Public Sub Method1()
   End Sub

   <Authors("Leo Tolstoy", "John Milton")> _
   Public Sub Method2()
   End Sub

   <Authors("Francis Bacon", "Miguel Cervantes")> _
   Public Sub Method3()
   End Sub
   
   <Authors("John Milton", "Leo Tolstoy")> _
   Public Sub Method4()
   End Sub
End Class

Public Module Example
   Sub Main()
      ' Get the Type object for both classes.
      Dim clsType1 As Type = GetType(TestClass1)
      Dim clsType2 As Type = GetType(TestClass2)

      ' Iterate through each method of the first class.
      For Each method In clsType1.GetMethods()
         ' Check each method for the Authors attribute.
         Dim attr1 As AuthorsAttribute = CType(Attribute.GetCustomAttribute(method, 
                                  GetType(AuthorsAttribute)), AuthorsAttribute)
         If attr1 IsNot Nothing Then
            Dim authAttr1 As AuthorsAttribute = 
                             CType(attr1, AuthorsAttribute)
            ' Display the authors.
            Console.WriteLine("{0}.{1} was authored by {2} and {3}.", 
                              clsType1.Name, method.Name, authAttr1.AuthorName1, 
                              authAttr1.AuthorName2)
            ' Iterate through each method of the second class.
            For Each method2 In clsType2.GetMethods()
               ' Check each method for the Authors attribute.
               Dim attr2 As AuthorsAttribute = CType(Attribute.GetCustomAttribute( 
                                        method2, GetType(AuthorsAttribute)), 
                                        AuthorsAttribute)
               If attr2 IsNot Nothing Then
                  Dim authAttr2 As AuthorsAttribute = _
                                CType(attr2, AuthorsAttribute)
                  ' Compare with the authors in the first class.
                  If authAttr2.Match(authAttr1) = True Then
                     Console.WriteLine("{0}.{1} was also authored by the same team.", 
                                       clsType2.Name, method2.Name)
                  End If
               End If
            Next
            Console.WriteLine()
         End If
      Next
   End Sub
End Module
' The example displays the following output:
'    TestClass1.Method1 was authored by William Shakespeare and Herman Melville.
'    TestClass2.Method1 was also authored by the same team.
'    
'    TestClass1.Method2 was authored by Leo Tolstoy and John Milton.
'    TestClass2.Method2 was also authored by the same team.
'    TestClass2.Method4 was also authored by the same team.
' </Snippet1>
