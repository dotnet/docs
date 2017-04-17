' <snippet210>
' <snippet220>
Imports System
Imports System.Collections
Imports System.ComponentModel
Imports System.ComponentModel.Design
Imports System.Drawing
Imports System.Windows.Forms
Imports System.Windows.Forms.Design
' </snippet220>

' <snippet240>
<Designer(GetType(MarqueeControlLibrary.Design.MarqueeControlRootDesigner), _
 GetType(IRootDesigner))> _
Public Class MarqueeControl
    Inherits UserControl
    ' </snippet240>

    ' Required designer variable.
    Private components As System.ComponentModel.Container = Nothing

    ' <snippet250>
    Public Sub New()
        ' This call is required by the Windows.Forms Form Designer.
        InitializeComponent()

        ' Minimize flickering during animation by enabling 
        ' double buffering.
        SetStyle(ControlStyles.OptimizedDoubleBuffer, True)
    End Sub
    ' </snippet250>

    ' <summary> 
    ' Clean up any resources being used.
    ' </summary>
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        If disposing Then
            If (components IsNot Nothing) Then
                components.Dispose()
            End If
        End If
        MyBase.Dispose(disposing)
    End Sub


    ' <snippet260>
    Public Sub Start()
        ' The MarqueeControl may contain any number of 
        ' controls that implement IMarqueeWidget, so 
        ' find each IMarqueeWidget child and call its
        ' StartMarquee method.
        Dim cntrl As Control
        For Each cntrl In Me.Controls
            If TypeOf cntrl Is IMarqueeWidget Then
                Dim widget As IMarqueeWidget = CType(cntrl, IMarqueeWidget)

                widget.StartMarquee()
            End If
        Next cntrl
    End Sub


    Public Sub [Stop]()
        ' The MarqueeControl may contain any number of 
        ' controls that implement IMarqueeWidget, so find
        ' each IMarqueeWidget child and call its StopMarquee
        ' method.
        Dim cntrl As Control
        For Each cntrl In Me.Controls
            If TypeOf cntrl Is IMarqueeWidget Then
                Dim widget As IMarqueeWidget = CType(cntrl, IMarqueeWidget)

                widget.StopMarquee()
            End If
        Next cntrl
    End Sub
    ' </snippet260>

    ' <snippet270>
    Protected Overrides Sub OnLayout(ByVal levent As LayoutEventArgs)
        MyBase.OnLayout(levent)

        ' Repaint all IMarqueeWidget children if the layout 
        ' has changed.
        Dim cntrl As Control
        For Each cntrl In Me.Controls
            If TypeOf cntrl Is IMarqueeWidget Then
                Dim widget As IMarqueeWidget = CType(cntrl, IMarqueeWidget)

                cntrl.PerformLayout()
            End If
        Next cntrl
    End Sub
    ' </snippet270>

#Region "Component Designer generated code"

    ' <summary> 
    ' Required method for Designer support - do not modify 
    ' the contents of this method with the code editor.
    ' </summary>
    Private Sub InitializeComponent()
    End Sub

#End Region

End Class
' </snippet210>