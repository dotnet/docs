Imports System
Imports System.Workflow.Activities
Imports System.ServiceModel

Namespace WorkflowServiceAttributesSnippets
	Friend Class snippets
		Private Sub Container0()
			'WorkflowServiceAttributes.WorkflowServiceAttributes
			'<snippet0>
			Dim attributes As New WorkflowServiceAttributes()
			'</snippet0>
		End Sub
		Private Sub Container1()
			'WorkflowServiceAttributes.AddressFilterMode
			'<snippet1>
			Dim attributes As New WorkflowServiceAttributes()
			attributes.AddressFilterMode = AddressFilterMode.Exact
			'</snippet1>
		End Sub
		Private Sub Container2()
			'WorkflowServiceAttributes.ConfigurationName
			'<snippet2>
			Dim attributes As New WorkflowServiceAttributes()
			attributes.ConfigurationName = "CalculatorService"
			'</snippet2>
		End Sub
		Private Sub Container3()
			'WorkflowServiceAttributes.IgnoreExtensionDataObject
		'<snippet3>
			Dim attributes As New WorkflowServiceAttributes()
            attributes.IgnoreExtensionDataObject = True
			'</snippet3>
		End Sub
		Private Sub Container4()
			'WorkflowServiceAttributes.IncludeExceptionDetailInFaults
			'<snippet4>
			Dim attributes As New WorkflowServiceAttributes()
			attributes.IncludeExceptionDetailInFaults = True
			'</snippet4>
		End Sub
		Private Sub Container5()
			'WorkflowServiceAttributes.MaxItemsInObjectGraph
			'<snippet5>
			Dim attributes As New WorkflowServiceAttributes()
			attributes.MaxItemsInObjectGraph = 10
			'</snippet5>
		End Sub
		Private Sub Container6()
			'WorkflowServiceAttributes.Name
			'<snippet6>
			Dim attributes As New WorkflowServiceAttributes()
			attributes.Name = "CalculatorService"
			'</snippet6>
		End Sub
		Private Sub Container7()
			'WorkflowServiceAttributes.Namespace
			'<snippet7>
			Dim attributes As New WorkflowServiceAttributes()
			attributes.Namespace = "Microsoft.Samples.WorkflowServices.SampleCode"
			'</snippet7>
		End Sub
		Private Sub Container8()
			'WorkflowServiceAttributes.UseSynchronizationContext
			'<snippet8>
			Dim attributes As New WorkflowServiceAttributes()
			attributes.UseSynchronizationContext = False
			'</snippet8>
		End Sub
		Private Sub Container9()
			'WorkflowServiceAttributes.ValidateMustUnderstand
			'<snippet9>
			Dim attributes As New WorkflowServiceAttributes()
			attributes.ValidateMustUnderstand = False
			'</snippet9>
		End Sub

	End Class
End Namespace
