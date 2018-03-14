'<Snippet1>
Imports System
Imports System.Configuration
Imports System.Web
Imports System.Web.Configuration
Imports System.Web.Security
Imports System.Reflection


Namespace Samples.AspNet



    ' Define a custom configuration.

    Public Class CustomConfiguration




        Public Sub New()

        End Sub 'New
       

        ' Define a custom section.

        Public Class CustomSection
            Inherits ConfigurationSection

            Private Const configString As String = "aString"

            Private Const configInteger As String = "anInteger"

            Private Const configTimeout As String = "aTimeout"



            <ConfigurationProperty(CustomSection.configString, DefaultValue:="default")> _
            Public Property aString() As String



                Get
                    Return CStr(Me(CustomSection.configString))
                End Get
                Set(ByVal value As String)
                    Me(CustomSection.configString) = value
                End Set
            End Property




            <ConfigurationProperty(CustomSection.configInteger, DefaultValue:=1)> _
            Public Property anInteger() As Integer



                Get
                    Return Fix(Me(CustomSection.configInteger))
                End Get
                Set(ByVal value As Integer)
                    Me(CustomSection.configInteger) = value
                End Set
            End Property




            <ConfigurationProperty(CustomSection.configTimeout)> _
            Public Property aTimeout() As TimeSpan


                Get
                    Return CType(Me(CustomSection.configTimeout), TimeSpan)
                End Get
                Set(ByVal value As TimeSpan)
                    Me(CustomSection.configTimeout) = value
                End Set
            End Property
        End Class 'CustomSection



        ' Create a custom section and save it in the
        ' application configuration file.
        Public Sub CreateCustomSection()

            Dim config As Configuration = WebConfigurationManager.OpenWebConfiguration("/ConfigSite")

            Dim section As CustomSection = config.Sections("CustomSection")
            
            If section Is Nothing Then

                ' Create section and add it to the configuration.
                section = New CustomSection()
                config.Sections.Add("CustomSection", section)
            End If

            ' Assign configuration settings.
            section.aTimeout = TimeSpan.FromSeconds(DateTime.Now.Second)

            section.anInteger = 1500

            section.aString = "Hello World"


            ' Save the changes.
            config.Save()

        End Sub 'CreateCustomSection


        ' Get the custom section stored in 
        ' the configuration file.
        Public Function GetCustomSection() As String


            Dim config As Configuration = WebConfigurationManager.OpenWebConfiguration("/ConfigSite")


            Dim section As CustomSection = config.Sections("CustomSection")
        
            Dim currentSection As String = String.Empty

            If Not (section Is Nothing) Then
                currentSection = HttpContext.Current.Server.HtmlEncode(section.SectionInformation.GetRawXml())

            Else
                currentSection = "CustomSection does not exist"
            End If
            Return currentSection

        End Function 'GetCustomSection
    End Class 'CustomConfiguration

End Namespace
'</Snippet1>