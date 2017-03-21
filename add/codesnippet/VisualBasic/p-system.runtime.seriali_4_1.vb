<DataContract()>  _
Public Class Employee
    ' The CLR default for as string is a null value.
    ' This will be written as <employeeName xsi:nil="true" />
    <DataMember()>  _
    Public employeeName As String = Nothing
    
    ' This will be written as <employeeID>0</employeeID>
    <DataMember()>  _
    Public employeeID As Integer = 0
    
    ' The next two will not be written because the EmitDefaultValue = false.
    <DataMember(EmitDefaultValue := False)> Public position As String = Nothing
    <DataMember(EmitDefaultValue := False)> Public salary As Integer = 0

    ' This will be written as <targetSalary>555</targetSalary> because 
    ' the 555 does not match the .NET default of 0.
    <DataMember(EmitDefaultValue := False)> Public targetSalary As Integer = 555
End Class 