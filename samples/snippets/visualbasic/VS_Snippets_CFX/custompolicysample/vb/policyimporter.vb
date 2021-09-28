Imports System.Collections.Generic
Imports System.ServiceModel
Imports System.ServiceModel.Channels
Imports System.ServiceModel.Configuration
Imports System.ServiceModel.Description
Imports System.Text
Imports System.Xml

Namespace Microsoft.WCF.Documentation
    Public Class CustomPolicyImporter
        Implements IPolicyImportExtension
        ' <snippet1>
#Region "IPolicyImporter Members"
        Public Const name1 As String = "acme"
        Public Const ns1 As String = "http://Microsoft/WCF/Documentation/CustomPolicyAssertions"

        '    
        '     * Importing policy assertions usually means modifying the bindingelement stack in some way
        '     * to support the policy assertion. The procedure is:
        '     * 1. Find the custom assertion to import.
        '     * 2. Insert a supporting custom bindingelement or modify the current binding element collection
        '     *     to support the assertion.
        '     * 3. Remove the assertion from the collection. Once the ImportPolicy method has returned, 
        '     *     any remaining assertions for the binding cause the binding to fail import and not be 
        '     *     constructed.
        '     
        Public Sub ImportPolicy(ByVal importer As MetadataImporter, ByVal context As PolicyConversionContext) Implements IPolicyImportExtension.ImportPolicy
            Console.WriteLine("The custom policy importer has been called.")
            '<snippet9>
            ' Locate the custom assertion and remove it.
            '<snippet8>
            Dim customAssertion As XmlElement = context.GetBindingAssertions().Remove(name1, ns1)
            '</snippet8>
            If customAssertion IsNot Nothing Then
                Console.WriteLine("Removed our custom assertion from the imported " & "assertions collection and inserting our custom binding element.")
                ' Here we would add the binding modification that implemented the policy.
                ' This sample does not do this.
                Console.ForegroundColor = ConsoleColor.Red
                Console.WriteLine(customAssertion.NamespaceURI & " : " & customAssertion.Name)
                Console.WriteLine(customAssertion.OuterXml)
                Console.ForegroundColor = ConsoleColor.Gray
            End If
            '</snippet9>
        End Sub
#End Region
        ' </snippet1>
    End Class
End Namespace
