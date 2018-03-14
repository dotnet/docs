' File name: CustomElement.cs
' Allowed snippet tags range: [31 - 50].

'<Snippet31>
Imports System
Imports System.Configuration
Imports System.Collections

Public Class UrlConfigElement
    Inherits ConfigurationElement

    '<Snippet32>
    ' Constructor allowing name, url, and port to be specified.
    Public Sub New(ByVal newName As String, _
        ByVal newUrl As String, _
        ByVal newPort As Integer)

        Name = newName
        Url = newUrl
        Port = newPort

    End Sub 'New

    '</Snippet32>
    ' Default constructor, will use default values as defined
    Public Sub New()

    End Sub 'New


    ' Constructor allowing name to be specified, will take the
    ' default values for url and port.
    Public Sub New(ByVal elementName As String)
        Name = elementName

    End Sub 'New


    <ConfigurationProperty("name", _
        DefaultValue:="Microsoft", _
        IsRequired:=True, _
        IsKey:=True)> _
        Public Property Name() As String

        Get
            Return CStr(Me("name"))
        End Get
        Set(ByVal value As String)
            Me("name") = value
        End Set
    End Property


    <ConfigurationProperty("url", _
        DefaultValue:="http://www.microsoft.com", _
        IsRequired:=True), _
        RegexStringValidator("\w+:\/\/[\w.]+\S*")> _
        Public Property Url() As String

        Get
            Return CStr(Me("url"))
        End Get
        Set(ByVal value As String)
            Me("url") = value
        End Set
    End Property


    <ConfigurationProperty("port", _
        DefaultValue:=0, _
        IsRequired:=False), _
        IntegerValidator(MinValue:=0, _
        MaxValue:=8080, ExcludeRange:=False)> _
        Public Property Port() As Integer

        Get
            Return Fix(Me("port"))
        End Get
        Set(ByVal value As Integer)
            Me("port") = value
        End Set
    End Property


    ' <Snippet33>
    Protected Overrides Sub DeserializeElement(ByVal reader _
        As System.Xml.XmlReader, _
        ByVal serializeCollectionKey As Boolean)

        MyBase.DeserializeElement(reader, _
            serializeCollectionKey)
        ' Enter your custom processing code here.
    End Sub 'DeserializeElement
    '</Snippet33>

    ' <Snippet34>
    Protected Overrides Function SerializeElement(ByVal writer _
        As System.Xml.XmlWriter, _
        ByVal serializeCollectionKey As Boolean) As Boolean

        Dim ret As Boolean = _
            MyBase.SerializeElement(writer, serializeCollectionKey)
        ' Enter your custom processing code here.
        Return ret
    End Function 'SerializeElement
    ' </Snippet34>

    ' <Snippet35>
    Protected Overrides Function IsModified() As Boolean
        Dim ret As Boolean = MyBase.IsModified()
        ' Enter your custom processing code here.
        Return ret

    End Function 'IsModified
End Class 'UrlConfigElement 
'</Snippet35>

'</Snippet31>