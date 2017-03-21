        ' Override the BeginRender method to write a
        ' message and call the WriteBreak method
        ' before a control is rendered.
        Overrides Public Sub BeginRender()
           Me.Write("A control is about to render.")
           Me.WriteBreak()
        End Sub
        
        ' Override the EndRender method to
        ' write a string immediately after 
        ' a control has rendered. 
        Overrides Public Sub EndRender()
           Me.Write("A control just rendered.")
        End Sub  