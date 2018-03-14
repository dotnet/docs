 ' <snippet0>
Imports System
Imports System.EnterpriseServices
Imports System.Reflection

<Assembly: ApplicationName("ReceiptNumberGenerator")> 
<Assembly: ApplicationActivation(ActivationOption.Library)> 
 

Public Class ReceiptNumberGeneratorClass
    
    ' Generates a new receipt number based on the receipt number
    ' stored by the Shared Property Manager (SPM)
    Public Function GetNextReceiptNumber() As Integer 
        Dim groupExists, propertyExists As Boolean
        Dim nextReceiptNumber As Integer = 0
        Dim lockMode As PropertyLockMode = PropertyLockMode.SetGet
        Dim releaseMode As PropertyReleaseMode = PropertyReleaseMode.Standard
        
        ' <snippet1>
        ' Create a shared property group manager.
        Dim groupManager As New SharedPropertyGroupManager()
        ' </snippet1>

        ' <snippet21>
        ' <snippet2>
        ' Create a shared property group.
        Dim group As SharedPropertyGroup = groupManager.CreatePropertyGroup("Receipts", lockMode, releaseMode, groupExists)
        ' </snippet2>
        ' Create a shared property.
        Dim ReceiptNumber As SharedProperty
        ReceiptNumber = group.CreateProperty("ReceiptNumber", propertyExists)
        ' </snippet21>

        ' <snippet3>
        ' Retrieve the value from shared property, and increment the shared 
        ' property value.
        nextReceiptNumber = Fix(ReceiptNumber.Value)
        ReceiptNumber.Value = nextReceiptNumber + 1
        ' </snippet3>

        ' Return nextReceiptNumber
        Return nextReceiptNumber
    
    End Function 'GetNextReceiptNumber

End Class 'ReceiptNumberGeneratorClass
' </snippet0>

'added to make it compile
Public Class Test

    Public Shared Sub Main()

    End Sub 'Main
End Class 'Test

