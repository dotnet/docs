' File name: CustomSection.cs
' Allowed snippet tags range: [71 - 90].

'<Snippet71>
Imports System
Imports System.Configuration
Imports System.Collections

' Define a custom section containing an individual
' element and a collection of elements.
Public Class UrlsSection
    Inherits ConfigurationSection

    ' <Snippet72>    
    <ConfigurationProperty("name", _
        DefaultValue:="MyFavorites", _
        IsRequired:=True, _
        IsKey:=False), _
        StringValidator( _
        InvalidCharacters:=" ~!@#$%^&*()[]{}/;'""|\", _
        MinLength:=1, MaxLength:=60)> _
        Public Property Name() As String

        Get
            Return CStr(Me("name"))
        End Get
        Set(ByVal value As String)
            Me("name") = value
        End Set
    End Property
    ' </Snippet72>
    
    ' Declare an element (not in a collection) of the type
    ' UrlConfigElement. In the configuration
    ' file it corresponds to <simple .... />.
    <ConfigurationProperty("simple")> _
        Public ReadOnly Property Simple() _
        As UrlConfigElement

        Get
            Dim url As UrlConfigElement = _
                CType(Me("simple"),  _
                UrlConfigElement)
            Return url
        End Get
    End Property
    
    ' Declare a collection element represented 
    ' in the configuration file by the sub-section
    ' <urls> <add .../> </urls> 
    ' Note: the "IsDefaultCollection = false" 
    ' instructs the .NET Framework to build a nested 
    ' section like <urls> ...</urls>.
    <ConfigurationProperty("urls", _
        IsDefaultCollection:=False)> _
        Public ReadOnly Property Urls() _
        As UrlsCollection

        Get
            Dim urlsCollection _
                As UrlsCollection = _
                CType(Me("urls"), UrlsCollection)
            Return urlsCollection
        End Get
    End Property

    '<Snippet73>
    Protected Overrides Sub DeserializeSection( _
        ByVal reader As System.Xml.XmlReader)

        MyBase.DeserializeSection(reader)
        ' Enter your custom processing code here.
    End Sub 'DeserializeSection
    '</Snippet73>

    '<Snippet74>
    Protected Overrides Function SerializeSection( _
        ByVal parentElement As ConfigurationElement, _
        ByVal name As String, _
        ByVal saveMode As ConfigurationSaveMode) As String

        Dim s As String = _
            MyBase.SerializeSection(parentElement, _
            name, saveMode)
        ' Enter your custom processing code here.
        Return s
    End Function 'SerializeSection
    '</Snippet74>
End Class 'UrlsSection 
'</Snippet71>