Imports System
Imports System.Drawing
Imports System.ComponentModel.Design
Imports System.Windows.Forms
Imports System.Windows.Forms.Design

Public Class Form1
    Inherits Form
    
' <Snippet1>
 ' The specified IDesigner implements IUIService.
 Function GetFont(designer As IDesigner) As Font
     Dim hostfont As Font
        
     ' Gets the dialog box font from the host environment.
     hostfont = CType(CType(designer, IUIService).Styles("DialogFont"), Font)
        
     Return hostfont
 End Function

' </Snippet1>
End Class

