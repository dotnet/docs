Namespace CustomCodeAttributes
    '<snippet4>
    <AttributeUsage(AttributeTargets.All)>
    Public Class DeveloperAttribute
        Inherits Attribute
        ' Private fields.
        Private myname As String
        Private mylevel As String
        Private myreviewed As Boolean

        ' This constructor defines two required parameters: name and level.

        Public Sub New(name As String, level As String)
            Me.myname = name
            Me.mylevel = level
            Me.myreviewed = False
        End Sub

        ' Define Name property.
        ' This is a read-only attribute.

        Public Overridable ReadOnly Property Name() As String
            Get
                Return myname
            End Get
        End Property

        ' Define Level property.
        ' This is a read-only attribute.

        Public Overridable ReadOnly Property Level() As String
            Get
                Return mylevel
            End Get
        End Property

        ' Define Reviewed property.
        ' This is a read/write attribute.

        Public Overridable Property Reviewed() As Boolean
            Get
                Return myreviewed
            End Get
            Set
                myreviewed = value
            End Set
        End Property
    End Class
    '</snippet4>
End Namespace

Namespace CustomCodeAttributes_Examples1
    '<snippet5>
    <AttributeUsage(AttributeTargets.All, Inherited:=False, AllowMultiple:=True)>
    Public Class SomeClass
        Inherits Attribute
        '...
    End Class
    '</snippet5>

    '<snippet6>
    <AttributeUsage(AttributeTargets.Class Or AttributeTargets.Method)>
    Public Class SomeOtherClass
        Inherits Attribute
        '...
    End Class
    '</snippet6>

    '<snippet7>
    ' This defaults to Inherited = true.
    Public Class MyAttribute
        Inherits Attribute
        '...
    End Class

    <AttributeUsage(AttributeTargets.Method, Inherited:=False)>
    Public Class YourAttribute
        Inherits Attribute
        '...
    End Class
    '</snippet7>

    '<snippet9>
    Public Class MeClass
        <MyAttribute>
        <YourAttribute>
        Public Overridable Sub MyMethod()
            '...
        End Sub
    End Class
    '</snippet9>

    '<snippet10>
    Public Class YourClass
        Inherits MeClass
        ' MyMethod will have MyAttribute but not YourAttribute.
        Public Overrides Sub MyMethod()
            '...
        End Sub

    End Class
    '</snippet10>
End Namespace

Namespace CustomCodeAttributes_Examples2
    '<snippet11>
    ' This defaults to AllowMultiple = false.
    Public Class MyAttribute
        Inherits Attribute
    End Class

    <AttributeUsage(AttributeTargets.Method, AllowMultiple:=true)>
    Public Class YourAttribute
        Inherits Attribute
    End Class
    '</snippet11>

    ' #if'd out since MyClass will intentionally not compile
#If False
    '<snippet12>
    <Developer("Joan Smith", "1")>

    -or-

    <Developer("Joan Smith", "1", Reviewed := true)>
    '</snippet12>

    '<snippet13>
    Public Class MyClass
        ' This produces an error.
        ' Duplicates are not allowed.
        <MyAttribute>
        <MyAttribute>
        Public Sub MyMethod()
            '...
        End Sub

        ' This is valid.
        <YourAttribute>
        <YourAttribute>
        Public Sub YourMethod()
            '...
        End Sub
    End Class
    '</snippet13>
#End If
End Namespace

Namespace CustomCodeAttributes_Examples3
    '<snippet14>
    <AttributeUsage(AttributeTargets.Method)>
    Public Class MyAttribute
        Inherits Attribute
        ' . . .
    End Class
    '</snippet14>
End Namespace

Namespace CustomCodeAttributes_Examples4
    Public Class MyAttribute
        Inherits Attribute

        Private myvalue As Boolean
        Private myoptional As String

        '<snippet15>
        Public Sub New(myvalue As Boolean)
            Me.myvalue = myvalue
        End Sub
        '</snippet15>

        '<snippet16>
        Public Property MyProperty As Boolean
            Get
                Return Me.myvalue
            End Get
            Set
                Me.myvalue = Value
            End Set
        End Property
        '</snippet16>

        Public Property OptionalParameter As String
            Get
                Return Me.myoptional
            End Get
            Set
                Me.myoptional = Value
            End Set
        End Property
    End Class

    '<snippet17>
    ' One required (positional) and one optional (named) parameter are applied.
    <MyAttribute(false, OptionalParameter:="optional data")>
    Public Class SomeClass
        '...
    End Class

    ' One required (positional) parameter is applied.
    <MyAttribute(false)>
    Public Class SomeOtherClass
        '...
    End Class
    '</snippet17>
End Namespace

