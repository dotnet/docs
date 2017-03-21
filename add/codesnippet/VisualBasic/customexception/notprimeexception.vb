' <Snippet1>
Imports System.Runtime.Serialization

<Serializable()> _
Public Class NotPrimeException : Inherits Exception
   Private notAPrime As Integer

   Protected Sub New()
      MyBase.New()
   End Sub

   Public Sub New(value As Integer)
      MyBase.New(String.Format("{0} is not a prime number.", value))
      notAPrime = value
   End Sub

   Public Sub New(value As Integer, message As String)
      MyBase.New(message)
      notAPrime = value
   End Sub

   Public Sub New(value As Integer, message As String, innerException As Exception)
      MyBase.New(message, innerException)
      notAPrime = value
   End Sub

   Protected Sub New(info As SerializationInfo,
                     context As StreamingContext)
      MyBase.New(info, context)
   End Sub

   Public ReadOnly Property NonPrime As Integer
      Get
         Return notAPrime
      End Get
   End Property
End Class
' </Snippet1>
