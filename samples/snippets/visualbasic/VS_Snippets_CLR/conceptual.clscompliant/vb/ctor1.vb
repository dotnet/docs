' Visual Basic .NET Document
Option Strict On

' <Snippet11>
<Assembly: CLSCompliant(True)> 

Public Class Person
   Private fName, lName, _id As String
   
   Public Sub New(firstName As String, lastName As String, id As String)
      If String.IsNullOrEmpty(firstName + lastName) Then
         Throw New ArgumentNullException("Either a first name or a last name must be provided.")    
      End If
      
      fName = firstName
      lName = lastName
      _id = id
   End Sub
   
   Public ReadOnly Property FirstName As String
      Get
         Return fName
      End Get
   End Property

   Public ReadOnly Property LastName As String
      Get
         Return lName
      End Get
   End Property
   
   Public ReadOnly Property Id As String
      Get
         Return _id
      End Get
   End Property

   Public Overrides Function ToString() As String
      Return String.Format("{0}{1}{2}", fName, 
                           If(String.IsNullOrEmpty(fName), "", " "),
                           lName)
   End Function
End Class

Public Class Doctor : Inherits Person
   Public Sub New(firstName As String, lastName As String, id As String)
   End Sub

   Public Overrides Function ToString() As String
      Return "Dr. " + MyBase.ToString()
   End Function
End Class
' Attempting to compile the example displays output like the following:
'    Ctor1.vb(46) : error BC30148: First statement of this 'Sub New' must be a call 
'    to 'MyBase.New' or 'MyClass.New' because base class 'Person' of 'Doctor' does 
'    not have an accessible 'Sub New' that can be called with no arguments.
'    
'       Public Sub New()
'                  ~~~
' </Snippet11>

Module Example
   Public Sub Main()

   End Sub
End Module

