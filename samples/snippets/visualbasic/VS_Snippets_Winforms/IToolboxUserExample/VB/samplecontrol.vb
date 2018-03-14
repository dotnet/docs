'<Snippet1>
Imports System
Imports System.Collections
Imports System.ComponentModel
Imports System.ComponentModel.Design
Imports System.Diagnostics
Imports System.Drawing
Imports System.Drawing.Design
Imports System.Windows.Forms
Imports System.Windows.Forms.Design

' This example contains an IRootDesigner that implements the IToolboxUser interface.
' This example demonstrates how to enable the GetToolSupported method of an IToolboxUser
' designer in order to disable specific toolbox items, and how to respond to the 
' invocation of a ToolboxItem in the ToolPicked method of an IToolboxUser implementation.
' This example component class demonstrates the associated IRootDesigner which 
' implements the IToolboxUser interface. When designer view is invoked, Visual 
' Studio .NET attempts to display a design mode view for the class at the top 
' of a code file. This can sometimes fail when the class is one of multiple types 
' in a code file, and has a DesignerAttribute associating it with an IRootDesigner. 
' Placing a derived class at the top of the code file solves this problem. A 
' derived class is not typically needed for this reason, except that placing the 
' RootDesignedComponent class in another file is not a simple solution for a code 
' example that is packaged in one segment of code.

Public Class RootViewSampleComponent
    Inherits RootDesignedComponent
End Class

' The following attribute associates the SampleRootDesigner with this example component.
<DesignerAttribute(GetType(SampleRootDesigner), GetType(IRootDesigner))> _
Public Class RootDesignedComponent
    Inherits System.Windows.Forms.Control
End Class

' This example IRootDesigner implements the IToolboxUser interface and provides a 
' Windows Forms view technology view for its associated component using an internal 
' Control type.     
' The following ToolboxItemFilterAttribute enables the GetToolSupported method of this
' IToolboxUser designer to be queried to check for whether to enable or disable all 
' ToolboxItems which create any components whose type name begins with "System.Windows.Forms".
<ToolboxItemFilterAttribute("System.Windows.Forms", ToolboxItemFilterType.Custom)> _
<System.Security.Permissions.PermissionSetAttribute(System.Security.Permissions.SecurityAction.Demand, Name:="FullTrust")> _
Public Class SampleRootDesigner
    Inherits ParentControlDesigner
    Implements IRootDesigner, IToolboxUser

    ' Member field of custom type RootDesignerView, a control that is shown in the 
    ' design mode document window. This member is cached to reduce processing needed 
    ' to recreate the view control on each call to GetView().
    Private m_view As RootDesignerView

    ' This string array contains type names of components that should not be added to 
    ' the component managed by this designer from the Toolbox.  Any ToolboxItems whose 
    ' type name matches a type name in this array will be marked disabled according to  
    ' the signal returned by the IToolboxUser.GetToolSupported method of this designer.
    Private blockedTypeNames As String() = {"System.Windows.Forms.ListBox", "System.Windows.Forms.GroupBox"}

    ' IRootDesigner.SupportedTechnologies is a required override for an IRootDesigner.
    ' This designer provides a display using the Windows Forms view technology.
    ReadOnly Property SupportedTechnologies() As ViewTechnology() Implements IRootDesigner.SupportedTechnologies
        Get
            Return New ViewTechnology() {ViewTechnology.Default}
        End Get
    End Property

    ' This method returns an object that provides the view for this root designer. 
    Function GetView(ByVal technology As ViewTechnology) As Object Implements IRootDesigner.GetView
        ' If the design environment requests a view technology other than Windows 
        ' Forms, this method throws an Argument Exception.
        If technology <> ViewTechnology.Default Then
            Throw New ArgumentException("An unsupported view technology was requested", "Unsupported view technology.")
        End If

        ' Creates the view object if it has not yet been initialized.
        If m_view Is Nothing Then
            m_view = New RootDesignerView(Me)
        End If
        Return m_view
    End Function

    '<Snippet2>
    ' This method can signal whether to enable or disable the specified
    ' ToolboxItem when the component associated with this designer is selected.
    Function GetToolSupported(ByVal tool As ToolboxItem) As Boolean Implements IToolboxUser.GetToolSupported
        ' Search the blocked type names array for the type name of the tool
        ' for which support for is being tested. Return false to indicate the
        ' tool should be disabled when the associated component is selected.
        Dim i As Integer
        For i = 0 To blockedTypeNames.Length - 1
            If tool.TypeName = blockedTypeNames(i) Then
                Return False
            End If
        Next i ' Return true to indicate support for the tool, if the type name of the
        ' tool is not located in the blockedTypeNames string array.
        Return True
    End Function
    '</Snippet2>

    '<Snippet3>
    ' This method can perform behavior when the specified tool has been invoked.
    ' Invocation of a ToolboxItem typically creates a component or components, 
    ' and adds any created components to the associated component.
    Sub ToolPicked(ByVal tool As ToolboxItem) Implements IToolboxUser.ToolPicked
    End Sub
    '</Snippet3>

    ' This control provides a Windows Forms view technology view object that 
    ' provides a display for the SampleRootDesigner.
    <DesignerAttribute(GetType(ParentControlDesigner), GetType(IDesigner))> _
    Friend Class RootDesignerView
        Inherits Control
        ' This field stores a reference to a designer.
        Private m_designer As IDesigner

        Public Sub New(ByVal designer As IDesigner)
            ' Performs basic control initialization.
            m_designer = designer
            BackColor = Color.Blue
            Font = New Font(Font.FontFamily.Name, 24.0F)
        End Sub

        ' This method is called to draw the view for the SampleRootDesigner.
        Protected Overrides Sub OnPaint(ByVal pe As PaintEventArgs)
            MyBase.OnPaint(pe)
            ' Draws the name of the component in large letters.
            pe.Graphics.DrawString(m_designer.Component.Site.Name, Font, Brushes.Yellow, New RectangleF(ClientRectangle.X, ClientRectangle.Y, ClientRectangle.Width, ClientRectangle.Height))
        End Sub
    End Class
End Class
'</Snippet1>