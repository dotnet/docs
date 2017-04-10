'  Copyright (c) Microsoft Corporation. All rights reserved.

imports System.Collections.Generic 
imports System.ServiceModel 
imports System.ServiceModel.Web 

<ServiceContract()> _
Public Interface ICustomerCollection
    <OperationContract()> _
<WebInvoke(Method:="POST", UriTemplate:="")> _
Function AddCustomer(ByVal customer As Customer) As Customer

    <OperationContract()> _
    <WebInvoke(Method:="DELETE", UriTemplate:="{id}")> _
    Sub DeleteCustomer(ByVal id As String)

    <OperationContract()> _
    <WebGet(UriTemplate:="{id}")> _
    Function GetCustomer(ByVal id As String) As Customer

    <OperationContract()> _
    <WebGet(UriTemplate:="")> _
    Function GetCustomers() As List(Of Customer)

    <OperationContract()> _
    <WebInvoke(Method:="PUT", UriTemplate:="{id}")> _
    Function UpdateCustomer(ByVal id As String, ByVal newCustomer As Customer) As Customer
End Interface


