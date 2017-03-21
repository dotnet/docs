' Define a service contract and apply the ServiceKnownTypeAttribute
' to specify types to include when generating client code. 
' The types must have the DataContractAttribute and DataMemberAttribute
' applied to be serialized and deserialized. The attribute specifies the 
' name of a method (GetKnownTypes) in a class (Helper) defined below.
<ServiceKnownType("GetKnownTypes", GetType(Helper)), ServiceContract()>  _
Public Interface ICalculator
    ' Any object type can be inserted into a Hashtable. The 
    ' ServiceKnownTypeAttribute allows you to include those types
    ' with the client code.
    <OperationContract()>  _
    Function GetItems() As Hashtable 
End Interface 

' This class has the method named GetKnownTypes that returns a generic IEnumerable.
Friend Class Helper
    Public Shared  Function GetKnownTypes(provider As ICustomAttributeProvider) _
     As IEnumerable(of Type) 
        Dim knownTypes As List(Of Type) = New List(Of Type)
        ' Add any types to include here.
        knownTypes.Add(GetType(Widget))
        knownTypes.Add(GetType(Machine))
        Return knownTypes
    End Function 
End Class 

<DataContract()>  _
Public Class Widget
    <DataMember()>  _
    Public Id As String
    <DataMember()>  _
    Public Catalog As String
End Class 

<DataContract()>  _
Public Class Machine
    Inherits Widget
    <DataMember()>  _
    Public Maker As String
End Class 
