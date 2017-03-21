    ' The ReplaceFlowDirectionMapping method replaces the
    ' default mapping for the FlowDirection property.
    Private Sub ReplaceFlowDirectionMapping()

        wfHost.PropertyMap.Remove("FlowDirection")

        wfHost.PropertyMap.Add( _
            "FlowDirection", _
            New PropertyTranslator(AddressOf OnFlowDirectionChange))
    End Sub


    ' The OnFlowDirectionChange method translates a 
    ' Windows Presentation Foundation FlowDirection value 
    ' to a Windows Forms RightToLeft value and assigns
    ' the result to the hosted control's RightToLeft property.
    Private Sub OnFlowDirectionChange( _
    ByVal h As Object, _
    ByVal propertyName As String, _
    ByVal value As Object)

        Dim host As WindowsFormsHost = h

        Dim fd As System.Windows.FlowDirection = _
            CType(value, System.Windows.FlowDirection)

        Dim cb As System.Windows.Forms.CheckBox = host.Child

        cb.RightToLeft = IIf(fd = System.Windows.FlowDirection.RightToLeft, _
            RightToLeft.Yes, _
            RightToLeft.No)

    End Sub


    ' The cb_CheckedChanged method handles the hosted control's
    ' CheckedChanged event. If the Checked property is true,
    ' the flow direction is set to RightToLeft, otherwise it is
    ' set to LeftToRight.
    Private Sub cb_CheckedChanged( _
    ByVal sender As Object, _
    ByVal e As EventArgs)

        Dim cb As System.Windows.Forms.CheckBox = sender

        wfHost.FlowDirection = IIf(cb.CheckState = CheckState.Checked, _
        System.Windows.FlowDirection.RightToLeft, _
        System.Windows.FlowDirection.LeftToRight)

    End Sub