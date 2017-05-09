' <snippet10>
Imports System
Imports System.ComponentModel
Imports System.ComponentModel.Design
Imports System.Drawing
Imports System.Drawing.Drawing2D
Imports System.Drawing.Design
Imports System.Windows.Forms
Imports System.Diagnostics

Namespace Microsoft.Samples.WinForms.VB.FlashTrackBar 

   Public Class FlashTrackBarDarkenByEditor 
        Inherits FlashTrackBarValueEditor 
   
       Overrides Protected Sub SetEditorProps(editingInstance As FlashTrackBar, editor As FlashTrackBar) 
           MyBase.SetEditorProps(editingInstance, editor)
           editor.Min = 0
           editor.Max = System.Byte.MaxValue
       End Sub
   
   End Class
   
End Namespace
' </snippet10>