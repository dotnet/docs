' <snippet12>
Imports System.Collections.Generic
Imports System.ServiceModel
Imports System.ServiceModel.Channels
Imports System.ServiceModel.Description
Imports System.Text
Imports System.Xml
Imports System.ServiceModel.Configuration

Namespace Microsoft.WCF.Documentation
    ' <snippet13>
    Public Class ExporterBindingElement
        Inherits BindingElement
        Implements IPolicyExportExtension

        Public Const name1 As String = "acme"
        Public Const ns1 As String = "http://Microsoft/WCF/Documentation/CustomPolicyAssertions"

        Private Shared doc As New XmlDocument()
        Private roadrunnerSpeed As String

        Public Sub New()
            Console.WriteLine("Exporter created.")
        End Sub
        '<snippet14>
#Region "IPolicyExporter Members"
        Public Sub ExportPolicy(ByVal exporter As MetadataExporter, ByVal policyContext As PolicyConversionContext) Implements IPolicyExportExtension.ExportPolicy
            If exporter Is Nothing Then
                Throw New NullReferenceException("The MetadataExporter object passed to the ExporterBindingElement is null.")
            End If
            If policyContext Is Nothing Then
                Throw New NullReferenceException("The PolicyConversionContext object passed to the ExporterBindingElement is null.")
            End If

            Dim elem As XmlElement = doc.CreateElement(name1, ns1)
            elem.InnerText = "My custom text."
            Dim att As XmlAttribute = doc.CreateAttribute("MyCustomAttribute", ns1)
            att.Value = "ExampleValue"
            elem.Attributes.Append(att)
            Dim subElement As XmlElement = doc.CreateElement("MyCustomSubElement", ns1)
            subElement.InnerText = "Custom Subelement Text."
            elem.AppendChild(subElement)
            policyContext.GetBindingAssertions().Add(elem)
            Console.WriteLine("The custom policy exporter was called.")
        End Sub
#End Region
        '</snippet14>

        Public Overrides Function Clone() As BindingElement
            ' Note: All custom binding elements must return a deep clone 
            ' to enable the run time to support multiple bindings using the 
            ' same custom binding.
            Return Me
        End Function

        ' Call the inner property.
        Public Overloads Overrides Function GetProperty(Of T As Class)(ByVal context As BindingContext) As T
            Return context.GetInnerProperty(Of T)()

        End Function
    End Class
    ' </snippet13>
    ' <snippet15>
    Public Class ExporterBindingElementConfigurationSection
        Inherits BindingElementExtensionElement
        Public Sub New()
            Console.WriteLine("Exporter configuration section created.")
        End Sub

        Public Overrides ReadOnly Property BindingElementType() As Type
            Get
                Return GetType(ExporterBindingElement)
            End Get
        End Property

        Protected Overrides Function CreateBindingElement() As BindingElement
            Return New ExporterBindingElement()
        End Function
    End Class
    ' </snippet15>
End Namespace
' </snippet12>
