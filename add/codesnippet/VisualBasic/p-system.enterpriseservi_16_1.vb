    Protected Overrides Sub Activate() 
        MessageBox.Show(String.Format("Now entering..." + vbLf + "Application: {0}" + vbLf + "Instance: {1}" + vbLf + "Context: {2}" + vbLf, ContextUtil.ApplicationId.ToString(), ContextUtil.ApplicationInstanceId.ToString(), ContextUtil.ContextId.ToString()))
    
    End Sub 'Activate