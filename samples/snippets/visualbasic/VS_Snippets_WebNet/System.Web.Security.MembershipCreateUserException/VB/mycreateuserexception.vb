'<Snippet5>
Imports System.Web.Security
Imports System.Runtime.Serialization

Public NotInheritable Class MyCreateUserException
  Inherits MembershipCreateUserException

  Public Sub New (info As SerializationInfo, context As StreamingContext)
    MyBase.New(info, context)
  End Sub
End Class
'</Snippet5>


