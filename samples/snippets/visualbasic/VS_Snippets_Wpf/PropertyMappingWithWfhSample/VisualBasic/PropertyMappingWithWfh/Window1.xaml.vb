' <Snippet10>
Imports System
Imports System.Windows
Imports System.Windows.Controls
Imports System.Windows.Data
Imports System.Windows.Documents
Imports System.Windows.Media
Imports System.Windows.Media.Imaging
Imports System.Windows.Shapes

' <Snippet20>
Imports System.Drawing
Imports System.Drawing.Drawing2D
Imports System.Windows.Forms
Imports System.Windows.Forms.Integration
' </Snippet20>

' <summary>
' Interaction logic for Window1.xaml
' </summary>
Class Window1
    Inherits Window
 
    Public Sub New() 
        InitializeComponent()
    
    End Sub
    
    
    ' <Snippet11>
    ' The WindowLoaded method handles the Loaded event.
    ' It enables Windows Forms visual styles, creates 
    ' a Windows Forms checkbox control, and assigns the
    ' control as the child of the WindowsFormsHost element. 
    ' This method also modifies property mappings on the 
    ' WindowsFormsHost element.
    Private Sub WindowLoaded( _
    ByVal sender As Object, _
    ByVal e As RoutedEventArgs)

        System.Windows.Forms.Application.EnableVisualStyles()

        ' Create a Windows Forms checkbox control and assign 
        ' it as the WindowsFormsHost element's child.
        Dim cb As New System.Windows.Forms.CheckBox()
        cb.Text = "Windows Forms checkbox"
        cb.Dock = DockStyle.Fill
        cb.TextAlign = ContentAlignment.MiddleCenter
        AddHandler cb.CheckedChanged, AddressOf cb_CheckedChanged
        wfHost.Child = cb

        ' Replace the default mapping for the FlowDirection property.
        Me.ReplaceFlowDirectionMapping()

        ' Remove the mapping for the Cursor property.
        Me.RemoveCursorMapping()

        ' Add the mapping for the Clip property.
        Me.AddClipMapping()

        ' Add another mapping for the Background property.
        Me.ExtendBackgroundMapping()

        ' Cause the OnFlowDirectionChange delegate to be called.
        wfHost.FlowDirection = System.Windows.FlowDirection.LeftToRight

        ' Cause the OnClipChange delegate to be called.
        wfHost.Clip = New RectangleGeometry()

        ' Cause the OnBackgroundChange delegate to be called.
        wfHost.Background = New ImageBrush()

    End Sub
    ' </Snippet11>

    ' <Snippet12>
    ' The ReplaceFlowDirectionMapping method replaces the
    ' default mapping for the FlowDirection property.
    Private Sub ReplaceFlowDirectionMapping()

        wfHost.PropertyMap.Remove("FlowDirection")

        wfHost.PropertyMap.Add( _
            "FlowDirection", _
            New PropertyTranslator(AddressOf OnFlowDirectionChange))
    End Sub


    ' The OnFlowDirectionChange method translates a 
    ' Windows Presentation Foundation FlowDirection value 
    ' to a Windows Forms RightToLeft value and assigns
    ' the result to the hosted control's RightToLeft property.
    Private Sub OnFlowDirectionChange( _
    ByVal h As Object, _
    ByVal propertyName As String, _
    ByVal value As Object)

        Dim host As WindowsFormsHost = h

        Dim fd As System.Windows.FlowDirection = _
            CType(value, System.Windows.FlowDirection)

        Dim cb As System.Windows.Forms.CheckBox = host.Child

        cb.RightToLeft = IIf(fd = System.Windows.FlowDirection.RightToLeft, _
            RightToLeft.Yes, _
            RightToLeft.No)

    End Sub


    ' The cb_CheckedChanged method handles the hosted control's
    ' CheckedChanged event. If the Checked property is true,
    ' the flow direction is set to RightToLeft, otherwise it is
    ' set to LeftToRight.
    Private Sub cb_CheckedChanged( _
    ByVal sender As Object, _
    ByVal e As EventArgs)

        Dim cb As System.Windows.Forms.CheckBox = sender

        wfHost.FlowDirection = IIf(cb.CheckState = CheckState.Checked, _
        System.Windows.FlowDirection.RightToLeft, _
        System.Windows.FlowDirection.LeftToRight)

    End Sub
    ' </Snippet12>

    ' <Snippet13>
    ' The RemoveCursorMapping method deletes the default
    ' mapping for the Cursor property.
    Private Sub RemoveCursorMapping()
        wfHost.PropertyMap.Remove("Cursor")
    End Sub
    ' </Snippet13>

    ' <Snippet14>
    ' The AddClipMapping method adds a custom mapping 
    ' for the Clip property.
    Private Sub AddClipMapping()

        wfHost.PropertyMap.Add( _
            "Clip", _
            New PropertyTranslator(AddressOf OnClipChange))

    End Sub
    
    ' The OnClipChange method assigns an elliptical clipping 
    ' region to the hosted control's Region property.
    Private Sub OnClipChange( _
    ByVal h As Object, _
    ByVal propertyName As String, _
    ByVal value As Object)

        Dim host As WindowsFormsHost = h

        Dim cb As System.Windows.Forms.CheckBox = host.Child

        If cb IsNot Nothing Then
            cb.Region = Me.CreateClipRegion()
        End If

    End Sub
    
    ' The Window1_SizeChanged method handles the window's 
    ' SizeChanged event. It calls the OnClipChange method explicitly 
    ' to assign a new clipping region to the hosted control.
    Private Sub Window1_SizeChanged( _
    ByVal sender As Object, _
    ByVal e As SizeChangedEventArgs)

        Me.OnClipChange(wfHost, "Clip", Nothing)

    End Sub
    
    ' The CreateClipRegion method creates a Region from an
    ' elliptical GraphicsPath.
    Private Function CreateClipRegion() As [Region] 
        Dim path As New GraphicsPath()
        
        path.StartFigure()
        
        path.AddEllipse(New System.Drawing.Rectangle( _
            0, _
            0, _
            wfHost.ActualWidth, _
            wfHost.ActualHeight))
        
        path.CloseFigure()
        
        Return New [Region](path)
    
    End Function
    ' </Snippet14>

    ' <Snippet15>
    ' The ExtendBackgroundMapping method adds a property
    ' translator if a mapping already exists.
    Private Sub ExtendBackgroundMapping() 
        If wfHost.PropertyMap("Background") IsNot Nothing Then

            wfHost.PropertyMap("Background") = PropertyTranslator.Combine( _
            wfHost.PropertyMap("Background"), _
            PropertyTranslator.CreateDelegate( _
                GetType(PropertyTranslator), _
                Me, _
                "OnBackgroundChange"))
        End If
    
    End Sub
    
    
    ' The OnBackgroundChange method assigns a specific image 
    ' to the hosted control's BackgroundImage property.
    Private Sub OnBackgroundChange(ByVal h As Object, ByVal propertyName As String, ByVal value As Object) 
        Dim host As WindowsFormsHost = h 
        Dim cb As System.Windows.Forms.CheckBox = host.Child 
        Dim b As ImageBrush = value 
        
        If Not (b Is Nothing) Then
            cb.BackgroundImage = New System.Drawing.Bitmap("C:\WINDOWS\Santa Fe Stucco.bmp")
        End If
    
    End Sub
    ' </Snippet15>
End Class

' </Snippet10>