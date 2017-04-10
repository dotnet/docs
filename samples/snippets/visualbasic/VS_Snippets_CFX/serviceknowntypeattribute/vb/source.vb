 '  Copyright (c) Microsoft Corporation.  All Rights Reserved.
'<snippet0>
Imports System
Imports System.Collections
Imports System.ServiceModel
Imports System.Runtime.Serialization
Imports System.Collections.Generic
Imports System.Reflection
Imports System.Security.Permissions
<assembly: SecurityPermission(SecurityAction.RequestMinimum, Execution := True)>

'</snippet0>

'<snippet1>
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

'</snippet1>

'<snippet2>
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
'</snippet2>

Public Class CalculatorService
    Implements ICalculator
    
    Public Function GetItems() As Hashtable Implements ICalculator.GetItems
        Dim myHashtable As New Hashtable()
        
        Dim widget1 As New Widget()
        widget1.Catalog = "My First Widget"
        widget1.Id = "W-00001"
        
        Dim machine1 As New Machine()
        machine1.Catalog = "My Machine"
        machine1.Id = "M-00001"
        machine1.Maker = "Contoso.com"
        
        myHashtable.Add("Key1", widget1)
        myHashtable.Add("Key2", machine1)
        Return myHashtable
    
    End Function 
End Class 

Public Class Test
   Shared Sub Main()
   End Sub
End Class