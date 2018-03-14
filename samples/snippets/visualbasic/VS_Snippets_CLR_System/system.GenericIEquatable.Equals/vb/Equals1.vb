' Visual Basic .NET Document
Option Strict On

' <Snippet1>
Imports System.Collections.Generic
Imports System.Text.RegularExpressions

Public Class Person : Implements IEquatable(Of Person)
   Private uniqueSsn As String
   Private lName As String
   
   Public Sub New(lastName As String, ssn As String)
      Me.SSN = ssn
      Me.LastName = lastName
   End Sub
   
   Public Property SSN As String
      Set
         If Regex.IsMatch(value, "\d{9}") Then
            uniqueSsn = String.Format("{0}-(1}-{2}", value.Substring(0, 3), _
                                                     value.Substring(3, 2), _
                                                     value.Substring(5, 4))
         ElseIf Regex.IsMatch(value, "\d{3}-\d{2}-\d{4}") Then
            uniqueSsn = value
         Else 
            Throw New FormatException("The social security number has an invalid format.")
         End If
      End Set
      Get
         Return Me.uniqueSsn
      End Get      
   End Property
   
   Public Property LastName As String
      Get
         Return Me.lName
      End Get
      Set
         If String.IsNullOrEmpty(value) Then
            Throw New ArgumentException("The last name cannot be null or empty.")
         Else
            lname = value
         End If   
      End Set
   End Property
   
   Public Overloads Function Equals(other As Person) As Boolean _
                   Implements IEquatable(Of Person).Equals
      If other Is Nothing Then Return False
      
      If Me.uniqueSsn = other.uniqueSsn Then
         Return True
      Else
         Return False
      End If
   End Function

   Public Overrides Function Equals(obj As Object) As Boolean
      If obj Is Nothing Then Return False
      
      Dim personObj As Person = TryCast(obj, Person)
      If personObj Is Nothing Then
         Return False
      Else   
         Return Equals(personObj)   
      End If
   End Function   
   
   Public Overrides Function GetHashCode() As Integer
      Return Me.SSN.GetHashCode()
   End Function
   
   Public Shared Operator = (person1 As Person, person2 As Person) As Boolean
      If person1 Is Nothing OrElse person2 Is Nothing Then
         Return Object.Equals(person1, person2)
      End If
         
      Return person1.Equals(person2)
   End Operator
   
   Public Shared Operator <> (person1 As Person, person2 As Person) As Boolean
      If person1 Is Nothing OrElse person2 Is Nothing Then
         Return Not Object.Equals(person1, person2) 
      End If
      
      Return Not person1.Equals(person2)
   End Operator
End Class
' </Snippet1>

' <Snippet2>
Module TestIEquatable
   Public Sub Main()
      ' Create a Person object for each job applicant.
      Dim applicant1 As New Person("Jones", "099-29-4999")
      Dim applicant2 As New Person("Jones", "199-29-3999")
      Dim applicant3 As New Person("Jones", "299-49-6999")

      ' Add applicants to a List object.
      Dim applicants As New List(Of Person)
      applicants.Add(applicant1)
      applicants.Add(applicant2)
      applicants.Add(applicant3)
      
      ' Create a Person object for the final candidate.
      Dim candidate As New Person("Jones", "199-29-3999")
      
      If applicants.Contains(candidate) Then
         Console.WriteLine("Found {0} (SSN {1}).", _
                            candidate.LastName, candidate.SSN)
      Else
         Console.WriteLine("Applicant {0} not found.", candidate.SSN)
      End If         

      ' Call the shared inherited Equals(Object, Object) method.
      ' It will in turn call the IEquatable(Of T).Equals implementation.
      Console.WriteLine("{0}({1}) already on file: {2}.", _ 
                        applicant2.LastName, _
                        applicant2.SSN, _
                        Person.Equals(applicant2, candidate)) 
   End Sub
End Module
' The example displays the following output:
'       Found Jones (SSN 199-29-3999).
'       Jones(199-29-3999) already on file: True.
' </Snippet2>
