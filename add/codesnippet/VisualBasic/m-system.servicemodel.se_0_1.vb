' Apply the ServiceKnownTypeAttribute to the 
' interface specifying the type to include. Apply the attribute
' more than once, if needed.
<ServiceKnownType(GetType(Widget)), ServiceKnownType(GetType(Machine)), _
 ServiceContract()>  _
Public Interface ICalculator2
    ' Any object type can be inserted into a Hashtable. The 
    ' ServiceKnownTypeAttribute allows you to include those types
    ' with the client code.
    <OperationContract()>  _
    Function GetItems() As Hashtable 
End Interface 