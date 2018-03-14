Imports System
Imports System.Collections.Generic
Imports System.Text
Imports System.ServiceModel
Imports System.ServiceModel.Web

Module Program

    '<Snippet0>
    <ServiceContract()> _
    Public Interface ICalculator
        <OperationContract()> _
        <WebGet()> _
        Function Add(ByVal x As Long, ByVal y As Long) As Long

        '<Snippet4>
        <OperationContract()> _
        <WebGet(UriTemplate:="Sub?x={x}&y={y}")> _
        Function Subtract(ByVal x As Long, ByVal y As Long) As Long
        '</Snippet4>

        '<Snippet1>
        <OperationContract()> _
        <WebGet(UriTemplate:="Mult?x={x}&y={y}", BodyStyle:=WebMessageBodyStyle.Bare)> _
        Function Multiply(ByVal x As Long, ByVal y As Long) As Long
        '</Snippet1>

        '<Snippet2>
        <OperationContract()> _
        <WebGet(UriTemplate:="Div?x={x}&y={y}", RequestFormat:=WebMessageFormat.Xml)> _
        Function Divide(ByVal x As Long, ByVal y As Long) As Long
        '</Snippet2>

        '<Snippet3>
        <OperationContract()> _
        <WebGet(ResponseFormat:=WebMessageFormat.Json)> _
        Function Modulo(ByVal x As Long, ByVal y As Long) As Long
        '</Snippet3>
    End Interface
        '</Snippet0>

        '<Snippet5>
    <ServiceContract()> _
    Public Interface ICalculator2
        <OperationContract()> _
        <WebInvoke()> _
        Function Add(ByVal x As Long, ByVal y As Long) As Long

        '<Snippet9>
        <OperationContract()> _
        <WebInvoke(UriTemplate:="Sub?x={x}&y={y}")> _
        Function Subtract(ByVal x As Long, ByVal y As Long) As Long
        '</Snippet9>

        '<Snippet6>
        <OperationContract()> _
        <WebInvoke(UriTemplate:="Mult?x={x}&y={y}", BodyStyle:=WebMessageBodyStyle.Bare)> _
        Function Multiply(ByVal x As Long, ByVal y As Long) As Long
        '</Snippet6>

        '<Snippet8>
        <OperationContract()> _
        <WebInvoke(UriTemplate:="Div?x={x}&y={y}", BodyStyle:=WebMessageBodyStyle.Bare, RequestFormat:=WebMessageFormat.Xml, ResponseFormat:=WebMessageFormat.Xml)> _
        Function Divide(ByVal x As Long, ByVal y As Long) As Long
        '</Snippet8>

        '<Snippet7>
        <OperationContract()> _
       <WebInvoke(Method:="POST", UriTemplate:="Mod?x={x}&y={y}")> _
       Function Modulo(ByVal x As Long, ByVal y As Long) As Long
        '</Snippet7>
    End Interface
        '</Snippet5>

    Sub Main()

    End Sub

End Module
