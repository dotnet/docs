 '<snippet1>
Imports System
Imports System.Collections
Imports System.ComponentModel
Imports System.ComponentModel.Design
Imports System.Drawing
Imports System.Data
Imports System.Windows.Forms
Imports System.Windows.Forms.Design


' This control demonstrates retrieving the standard 
' designer option service values in design mode.

Public Class DesignerOptionServiceControl
   Inherits System.Windows.Forms.UserControl
   Private designerOptionSvc As DesignerOptionService
   
   
   Public Sub New()
      Me.BackColor = Color.Beige
      Me.Size = New Size(404, 135)
    End Sub
   
   
   Public Overrides Property Site() As System.ComponentModel.ISite
      Get
         Return MyBase.Site
      End Get
      Set
         MyBase.Site = value
         
         ' If siting component, attempt to obtain an DesignerOptionService.
         If (MyBase.Site IsNot Nothing) Then
            designerOptionSvc = CType(Me.GetService(GetType(DesignerOptionService)), DesignerOptionService)
         End If
      End Set
   End Property
    
   ' Displays control information and current DesignerOptionService 
   ' values, if available.
   Protected Overrides Sub OnPaint(e As System.Windows.Forms.PaintEventArgs)
        e.Graphics.DrawString("DesignerOptionServiceControl", _
        New Font("Arial", 9), _
        New SolidBrush(Color.Blue), 4, 4)
      
      If Me.DesignMode Then
            e.Graphics.DrawString("Currently in design mode", _
            New Font("Arial", 8), _
            New SolidBrush(Color.Black), 4, 18)
      Else
            e.Graphics.DrawString("Not in design mode. Cannot access DesignerOptionService.", _
            New Font("Arial", 8), _
            New SolidBrush(Color.Red), 4, 18)
      End If
      
      If (MyBase.Site IsNot Nothing) AndAlso (designerOptionSvc IsNot Nothing) Then
            e.Graphics.DrawString("DesignerOptionService provides access to the table of option values listed when", _
            New Font("Arial", 8), _
            New SolidBrush(Color.Black), 4, 38)

            e.Graphics.DrawString("the Windows Forms Designer\General tab of the Tools\Options menu is selected.", _
            New Font("Arial", 8), _
            New SolidBrush(Color.Black), 4, 50)

            e.Graphics.DrawString("Table of standard value names and current values", _
            New Font("Arial", 8), _
            New SolidBrush(Color.Red), 4, 76)

            ' Displays a table of the standard value names and current values.
            Dim ypos As Integer = 90

            ' <snippet2>
            ' <snippet3>
            ' Obtains and shows the size of the standard design-mode grid square.
            Dim pd As PropertyDescriptor
            pd = designerOptionSvc.Options.Properties("GridSize")

            e.Graphics.DrawString("GridSize", _
            New Font("Arial", 8), _
            New SolidBrush(Color.Black), 4, ypos)

            e.Graphics.DrawString(pd.GetValue(Nothing).ToString(), _
            New Font("Arial", 8), _
            New SolidBrush(Color.Black), 200, ypos)

            ypos += 12
            ' </snippet2>

            ' Uncomment the following code to demonstrate that this
            ' alternate syntax works the same as the previous syntax.
            'pd = designerOptionSvc.Options["WindowsFormsDesigner"].Properties["GridSize"];
            'e.Graphics.DrawString("GridSize",
            '    new Font("Arial", 8),
            '    new SolidBrush(Color.Black), 4, ypos);
            'e.Graphics.DrawString(pd.GetValue(null).ToString(),
            '    new Font("Arial", 8),
            '    new SolidBrush(Color.Black), 200, ypos);
            'ypos += 12;
            'pd = designerOptionSvc.Options["WindowsFormsDesigner"]["General"].Properties["GridSize"];
            'e.Graphics.DrawString("GridSize",
            '    new Font("Arial", 8),
            '    new SolidBrush(Color.Black), 4, ypos);
            'e.Graphics.DrawString(pd.GetValue(null).ToString(),
            '    new Font("Arial", 8),
            '    new SolidBrush(Color.Black), 200, ypos);
            'ypos += 12;
            ' </snippet3>

            ' Obtains and shows whether the design mode surface grid is enabled.
            pd = designerOptionSvc.Options.Properties("ShowGrid")

            e.Graphics.DrawString("ShowGrid", _
            New Font("Arial", 8), _
            New SolidBrush(Color.Black), 4, ypos)

            e.Graphics.DrawString(pd.GetValue(Nothing).ToString(), _
            New Font("Arial", 8), _
            New SolidBrush(Color.Black), 200, ypos)

            ypos += 12

            ' Obtains and shows whether components should be aligned with the surface grid.
            pd = designerOptionSvc.Options.Properties("SnapToGrid")

            e.Graphics.DrawString("SnapToGrid", _
            New Font("Arial", 8), _
            New SolidBrush(Color.Black), 4, ypos)

            e.Graphics.DrawString(pd.GetValue(Nothing).ToString(), _
            New Font("Arial", 8), _
            New SolidBrush(Color.Black), 200, ypos)

            ypos += 12

            ' Obtains and shows which layout mode is selected.
            pd = designerOptionSvc.Options.Properties("LayoutMode")

            e.Graphics.DrawString("LayoutMode", _
            New Font("Arial", 8), _
            New SolidBrush(Color.Black), 4, ypos)

            e.Graphics.DrawString(pd.GetValue(Nothing).ToString(), _
            New Font("Arial", 8), _
            New SolidBrush(Color.Black), 200, ypos)

            ypos += 12

            ' Obtains and shows whether the Toolbox is automatoically
            ' populated with custom controls and components.
            pd = designerOptionSvc.Options.Properties("AutoToolboxPopulate")

            e.Graphics.DrawString("AutoToolboxPopulate", _
            New Font("Arial", 8), _
            New SolidBrush(Color.Black), 4, ypos)

            e.Graphics.DrawString(pd.GetValue(Nothing).ToString(), _
            New Font("Arial", 8), _
            New SolidBrush(Color.Black), 200, ypos)

            ypos += 12

            ' Obtains and shows whether the component cache is used.
            pd = designerOptionSvc.Options.Properties("UseOptimizedCodeGeneration")

            e.Graphics.DrawString("Optimized Code Generation", _
            New Font("Arial", 8), _
            New SolidBrush(Color.Black), 4, ypos)

            e.Graphics.DrawString(pd.GetValue(Nothing).ToString(), _
            New Font("Arial", 8), _
            New SolidBrush(Color.Black), 200, ypos)

            ypos += 12

            ' Obtains and shows whether smart tags are automatically opened.
            pd = designerOptionSvc.Options.Properties("ObjectBoundSmartTagAutoShow")

            e.Graphics.DrawString("Automatically Open Smart Tags", _
            New Font("Arial", 8), _
            New SolidBrush(Color.Black), 4, ypos)

            e.Graphics.DrawString(pd.GetValue(Nothing).ToString(), _
            New Font("Arial", 8), _
            New SolidBrush(Color.Black), 200, ypos)
      End If
    End Sub
End Class
'</snippet1>