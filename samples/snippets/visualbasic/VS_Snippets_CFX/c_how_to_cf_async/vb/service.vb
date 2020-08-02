'  Copyright (c) Microsoft Corporation.  All Rights Reserved.

Imports System.Globalization
Imports System.IO
Imports System.ServiceModel
Imports System.Text
Imports System.Threading

Namespace Microsoft.ServiceModel.Samples
    ' Define a service contract.
    '<snippet4>
    <ServiceContract(Namespace:="http://Microsoft.ServiceModel.Samples")> _
    Public Interface ICalculator
        <OperationContract> _
        Function Add(ByVal n1 As Double, ByVal n2 As Double) As Double

        <OperationContract> _
        Function Subtract(ByVal n1 As Double, ByVal n2 As Double) As Double

        'Multiply involves some file I/O so we'll make it Async.
        <OperationContract(AsyncPattern:=True)> _
        Function BeginMultiply(ByVal n1 As Double, ByVal n2 As Double, ByVal callback As AsyncCallback, ByVal state As Object) As IAsyncResult
        Function EndMultiply(ByVal ar As IAsyncResult) As Double

        'Divide involves some file I/O so we'll make it Async.
        <OperationContract(AsyncPattern:=True)> _
        Function BeginDivide(ByVal n1 As Double, ByVal n2 As Double, ByVal callback As AsyncCallback, ByVal state As Object) As IAsyncResult
        Function EndDivide(ByVal ar As IAsyncResult) As Double
    End Interface
    '</snippet4>

End Namespace
