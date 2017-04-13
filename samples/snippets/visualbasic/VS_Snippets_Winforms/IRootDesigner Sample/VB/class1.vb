'<Snippet1>
Imports System
Imports System.Collections
Imports System.ComponentModel
Imports System.ComponentModel.Design
Imports System.Diagnostics
Imports System.Drawing
Imports System.Windows.Forms
Imports System.Windows.Forms.Design

Namespace SampleRootDesigner

    ' This sample demonstrates how to provide the root designer view, or
    ' design mode background view, by overriding IRootDesigner.GetView().

    ' This sample component inherits from RootDesignedComponent which 
    ' uses the SampleRootDesigner.
    Public Class RootViewSampleComponent
        Inherits RootDesignedComponent

        Public Sub New()
        End Sub

    End Class

    ' The following attribute associates the SampleRootDesigner designer 
    ' with the SampleComponent component.
    <Designer(GetType(SampleRootDesigner), GetType(IRootDesigner))> _
    Public Class RootDesignedComponent
        Inherits Component

        Public Sub New()
        End Sub 

    End Class 

    Public Class SampleRootDesigner
        Inherits ComponentDesigner
        Implements IRootDesigner

        ' Member field of custom type RootDesignerView, a control that 
        ' will be shown in the Forms designer view. This member is 
        ' cached to reduce processing needed to recreate the 
        ' view control on each call to GetView().
        Private m_view As RootDesignerView

        ' This method returns an instance of the view for this root
        ' designer. The "view" is the user interface that is presented
        ' in a document window for the user to manipulate. 
        Function GetView(ByVal technology As ViewTechnology) As Object Implements IRootDesigner.GetView
            If Not technology = ViewTechnology.Default Then
                Throw New ArgumentException("Not a supported view technology", "technology")
            End If
            If m_view Is Nothing Then
                ' Some type of displayable Form or control is required for a root designer that overrides 
                ' GetView(). In this example, a Control of type RootDesignerView is used.
                ' Any class that inherits from Control will work. 
                m_view = New RootDesignerView(Me)
            End If
            Return m_view
        End Function 

        ' IRootDesigner.SupportedTechnologies is a required override for an 
        ' IRootDesigner. Default is the view technology used by this designer.
        ReadOnly Property SupportedTechnologies() As ViewTechnology() Implements IRootDesigner.SupportedTechnologies
            Get
                Return New ViewTechnology() {ViewTechnology.Default}
            End Get
        End Property

        ' RootDesignerView is a simple control that will be displayed 
        ' in the designer window.
        Private Class RootDesignerView
            Inherits Control
            Private m_designer As SampleRootDesigner

            Public Sub New(ByVal designer As SampleRootDesigner)
                m_designer = designer
                BackColor = Color.Blue
                Font = New Font(Font.FontFamily.Name, 24.0F)
            End Sub 

            Protected Overrides Sub OnPaint(ByVal pe As PaintEventArgs)
                MyBase.OnPaint(pe)
                ' Draws the name of the component in large letters.
                Dim rf As New RectangleF(ClientRectangle.X, ClientRectangle.Y, ClientRectangle.Width, ClientRectangle.Height)
                pe.Graphics.DrawString(m_designer.Component.Site.Name, Font, Brushes.Yellow, rf)
            End Sub 

        End Class
    End Class

End Namespace 
'</Snippet1>