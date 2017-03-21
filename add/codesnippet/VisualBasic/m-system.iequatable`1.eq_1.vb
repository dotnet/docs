Imports System.Collections.Generic
Imports System.Text.RegularExpressions

Public Class Person : Implements IEquatable(Of Person)
   Private uniqueSsn As String
   Private lName As String
   
   Public Sub New(lastName As String, ssn As String)
      If Regex.IsMatch(ssn, "\d{9}") Then
         uniqueSsn = String.Format("{0}-(1}-{2}", ssn.Substring(0, 3), _
                                                  ssn.Substring(3, 2), _
                                                  ssn.Substring(5, 4))
      ElseIf Regex.IsMatch(ssn, "\d{3}-\d{2}-\d{4}") Then
         uniqueSsn = ssn
      Else 
         Throw New FormatException("The social security number has an invalid format.")
      End If
      Me.uniqueSsn = ssn
      Me.LastName = lastName
   End Sub
   
   Public ReadOnly Property SSN As String
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