' Implement the IExtensibleDataObject interface 
' to store the extra data for future versions.
<DataContract(Name := "Person", [Namespace] := "http://www.cohowinery.com/employees")>  _
Class Person
    Implements IExtensibleDataObject
    ' To implement the IExtensibleDataObject interface,
    ' you must implement the ExtensionData property. The property
    ' holds data from future versions of the class for backward
    ' compatibility.
    Private extensionDataObject_value As ExtensionDataObject
    
    Public Property ExtensionData() As ExtensionDataObject _
       Implements IExtensibleDataObject.ExtensionData
        Get
            Return extensionDataObject_value
        End Get
        Set
            extensionDataObject_value = value
        End Set
    End Property
    <DataMember()>  _
    Public Name As String
End Class 

' The second version of the class adds a new field. The field's 
' data is stored in the ExtensionDataObject field of
' the first version (Person). You must also set the Name property 
' of the DataContractAttribute to match the first version. 
' If necessary, also set the Namespace property so that the 
' name of the contracts is the same.

<DataContract(Name := "Person", [Namespace] := "http://www.cohowinery.com/employees")>  _
Class PersonVersion2
    Implements IExtensibleDataObject

    ' Best practice: add an Order number to new members.
    <DataMember(Order:=2)>  _
    Public ID As Integer
    
    <DataMember()>  _
    Public Name As String
    
    Private extensionDataObject_value As ExtensionDataObject
    
    Public Property ExtensionData() As ExtensionDataObject _
       Implements IExtensibleDataObject.ExtensionData
        Get
            Return extensionDataObject_value
        End Get
        Set
            extensionDataObject_value = value
        End Set
    End Property
End Class 