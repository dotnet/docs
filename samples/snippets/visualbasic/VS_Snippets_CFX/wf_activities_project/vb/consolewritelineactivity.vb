'<snippet2>
<ActivityValidator(GetType(ConsoleWriteLineActivityValidator))> _
Public Class ConsoleWriteLineActivity
    Inherits System.Workflow.ComponentModel.Activity

    Public Shared MsgProperty As DependencyProperty = DependencyProperty.Register("Msg", GetType(String), GetType(ConsoleWriteLineActivity))

    <Browsable(True)> _
    <DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)> _
    Public Property Msg() As String
        Get
            Return (CType((MyBase.GetValue(ConsoleWriteLineActivity.MsgProperty)), String))
        End Get
        Set(ByVal Value As String)
            MyBase.SetValue(ConsoleWriteLineActivity.MsgProperty, Value)
        End Set
    End Property

    Protected Overrides Function Execute(ByVal executionContext As System.Workflow.ComponentModel.ActivityExecutionContext) As System.Workflow.ComponentModel.ActivityExecutionStatus
        Console.WriteLine(Msg)
        Return ActivityExecutionStatus.Closed
    End Function

End Class
'</snippet2>

'<snippet1>
Class ConsoleWriteLineActivityValidator
    Inherits ActivityValidator

    '<snippet3>
    Public Overrides Function Validate( _
        ByVal manager As System.Workflow.ComponentModel.Compiler.ValidationManager, _
        ByVal obj As Object) As System.Workflow.ComponentModel.Compiler.ValidationErrorCollection

        'Invoke the base class method implementation to
        'perform default validation.
        Dim errors As ValidationErrorCollection = MyBase.Validate(manager, obj)

        'Make sure there is an activity instance.
        Dim crw As ConsoleWriteLineActivity = CType(obj, ConsoleWriteLineActivity)
        If crw Is Nothing Then
            Throw New InvalidOperationException()
        End If

        'If the activity has no parent then this validation
        'is occurring during the compilation of the activity
        'and not during the hosting or creation of an
        'activity instance.
        If crw.Parent Is Nothing Then
            'Can skip the rest of the validation because
            'it deals with the hosting and the creation
            'of the activity.
            Return errors
        End If

        'Msg is required. Add a validation error if there is no
        'Msg specified or Msg is not bound to another property.
        If String.IsNullOrEmpty(crw.Msg) And _
            crw.GetBinding(ConsoleWriteLineActivity.MsgProperty) Is Nothing Then

            '<snippet4>
            errors.Add(New ValidationError("Msg is required", 100, False, "Msg"))
            '</snippet4>

        End If

        Return errors
    End Function
    '</snippet3>
End Class
'</snippet1>

