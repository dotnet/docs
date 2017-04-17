'<Snippet1>
Imports System
Imports System.Web.DynamicData
Imports System.ComponentModel.DataAnnotations


<MetadataType(GetType(CustomerMetaData))> _
Partial Public Class Customer

    
End Class

Public Class CustomerMetaData
    
    '<Snippet3>
    ' Allow up to 40 uppercase and lowercase 
    ' characters. Use custom error.
    <RegularExpression("^[a-zA-Z''-'\s]{1,40}$", _
                       ErrorMessage:="Characters are not allowed.")> _
    Public FirstName As Object
    '</Snippet3>

    '<Snippet2>
    ' Allow up to 40 uppercase and lowercase 
    ' characters. Use standard error.
    <RegularExpression("^[a-zA-Z''-'\s]{1,40}$")> _
    Public LastName As Object
    '</Snippet2>
End Class

'</Snippet1>

