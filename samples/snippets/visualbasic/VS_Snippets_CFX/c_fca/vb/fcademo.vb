
Imports System
Imports System.ServiceModel


<ServiceContractAttribute()>  _
Public Interface FCADemonstration
    ' <snippet1>
  <OperationContractAttribute(), FaultContractAttribute(GetType(Integer))> _
    Function Divide(ByVal arg1 As Integer, ByVal arg2 As Integer) As Integer
End Interface 'FCADemonstration
' </snippet1>


Public Class FCADemoService
    Implements FCADemonstration
    
    Public Function Divide(ByVal arg1 As Integer, ByVal arg2 As Integer) As Integer _
        Implements FCADemonstration.Divide
        If arg1 <= arg2 Then
            '<snippet2>
      Throw New FaultException(Of Integer)(4)
            ' </snippet2>
        End If
        Return 0

    End Function 'Divide
End Class 'FCADemoService