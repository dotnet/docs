    ' Define a custom parameter attribute that takes a single message argument.
    <AttributeUsage(AttributeTargets.Parameter)>  _
    Public Class ArgumentUsageAttribute
        Inherits Attribute
           
        ' This is the attribute constructor.
        Public Sub New(UsageMsg As String)
            Me.usageMsg = UsageMsg
        End Sub ' New

        ' usageMsg is storage for the attribute message.
        Protected usageMsg As String
           
        ' This is the Message property for the attribute.
        Public Property Message() As String
            Get
                Return usageMsg
            End Get
            Set
                usageMsg = value
            End Set
        End Property
    End Class ' ArgumentUsageAttribute 