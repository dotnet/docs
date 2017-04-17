' <snippet1>
Imports System
Imports System.Collections
Imports System.Text
Imports System.Configuration
Imports System.Xml

Namespace Samples.AspNet

    Public Class PageAppearanceSection
        Inherits ConfigurationSection

        ' Create a "remoteOnly" attribute.
        <ConfigurationProperty("remoteOnly", DefaultValue:="false", IsRequired:=False)> _
        Public Property RemoteOnly() As Boolean
            Get
                Return CType(Me("remoteOnly"), Boolean)
            End Get
            Set(ByVal value As Boolean)
                Me("remoteOnly") = value
            End Set
        End Property

        ' Create a "font" element.
        <ConfigurationProperty("font")> _
        Public Property Font() As FontElement
            Get
                Return CType(Me("font"), FontElement)
            End Get
            Set(ByVal value As FontElement)
                Me("font") = value
            End Set
        End Property

        ' Create a "color element."
        <ConfigurationProperty("color")> _
        Public Property Color() As ColorElement
            Get
                Return CType(Me("color"), ColorElement)
            End Get
            Set(ByVal value As ColorElement)
                Me("color") = value
            End Set
        End Property
    End Class

    ' Define the "font" element
    ' with "name" and "size" attributes.
    Public Class FontElement
        Inherits ConfigurationElement

        <ConfigurationProperty("name", DefaultValue:="Arial", IsRequired:=True), _
         StringValidator(InvalidCharacters:="~!@#$%^&*()[]{}/;'\""|\\", MinLength:=1, MaxLength:=60)> _
        Public Property Name() As String
            Get
                Return CType(Me("name"), String)
            End Get
            Set(ByVal value As String)
                Me("name") = value
            End Set
        End Property

        <ConfigurationProperty("size", DefaultValue:="12", IsRequired:=False), _
         IntegerValidator(ExcludeRange:=False, MaxValue:=24, MinValue:=6)> _
        Public Property Size() As Integer
            Get
                Return CType(Me("size"), Integer)
            End Get
            Set(ByVal value As Integer)
                Me("size") = value
            End Set
        End Property
    End Class

    ' Define the "color" element 
    ' with "background" and "foreground" attributes.
    Public Class ColorElement
        Inherits ConfigurationElement

        <ConfigurationProperty("background", DefaultValue:="FFFFFF", IsRequired:=True), _
         StringValidator(InvalidCharacters:="~!@#$%^&*()[]{}/;'\""|\\GHIJKLMNOPQRSTUVWXYZ", MinLength:=6, MaxLength:=6)> _
        Public Property Background() As String
            Get
                Return CType(Me("background"), String)
            End Get
            Set(ByVal value As String)
                Me("background") = value
            End Set
        End Property

        <ConfigurationProperty("foreground", DefaultValue:="000000", IsRequired:=True), _
         StringValidator(InvalidCharacters:="~!@#$%^&*()[]{}/;'\""|\\GHIJKLMNOPQRSTUVWXYZ", MinLength:=6, MaxLength:=6)> _
        Public Property Foreground() As String
            Get
                Return CType(Me("foreground"), String)
            End Get
            Set(ByVal value As String)
                Me("foreground") = value
            End Set
        End Property
    End Class
End Namespace
' </snippet1>
