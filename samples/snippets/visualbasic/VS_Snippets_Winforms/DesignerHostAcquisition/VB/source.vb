'<Snippet2>
Imports System
Imports System.ComponentModel
Imports System.ComponentModel.Design
Imports System.Windows.Forms

Namespace DesignerHostTest
   ' Note: Don't forget to include a reference to the System.Design assembly
   Public Class DesignerHostDesigner
      Inherits ComponentDesigner
      
      Public Sub New()
      End Sub 'New      
      
        Public Overrides Sub DoDefaultAction()
            '<Snippet1>
            ' Requests an IDesignerHost service from the design time environment using Component.Site.GetService()
            Dim host As IDesignerHost = CType(Me.Component.Site.GetService(GetType(IDesignerHost)), IDesignerHost)
            '</Snippet1>
        End Sub 'DoDefaultAction
    End Class 'DesignerHostDesigner
End Namespace 'RDTest
'</Snippet2>