 ' The specified IDesigner implements IUIService.
 Function GetFont(designer As IDesigner) As Font
     Dim hostfont As Font
        
     ' Gets the dialog box font from the host environment.
     hostfont = CType(CType(designer, IUIService).Styles("DialogFont"), Font)
        
     Return hostfont
 End Function
