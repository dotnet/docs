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
        
        ' Create a shared property group manager.
        Dim groupManager As New SharedPropertyGroupManager()

        ' Create a shared property group.
        Dim group As SharedPropertyGroup = groupManager.CreatePropertyGroup("Receipts", lockMode, releaseMode, groupExists)
        ' Create a shared property.
        Dim ReceiptNumber As SharedProperty
        ReceiptNumber = group.CreateProperty("ReceiptNumber", propertyExists)

        ' Retrieve the value from shared property, and increment the shared 
        ' property value.
        nextReceiptNumber = Fix(ReceiptNumber.Value)
        ReceiptNumber.Value = nextReceiptNumber + 1

        ' Return nextReceiptNumber
        Return nextReceiptNumber
    
    End Function 'GetNextReceiptNumber

End Class 'ReceiptNumberGeneratorClass