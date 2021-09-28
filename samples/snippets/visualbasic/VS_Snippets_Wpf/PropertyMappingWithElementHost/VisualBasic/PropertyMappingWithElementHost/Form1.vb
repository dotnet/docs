' <snippet1>
Imports System.Drawing
Imports System.Windows.Forms

' <snippet10>
Imports System.Windows
Imports System.Windows.Media
Imports System.Windows.Media.Imaging
Imports System.Windows.Forms.Integration
' </snippet10>

Class Form1
    Inherits Form

    ' <snippet16>
    Private elemHost As ElementHost = Nothing
    ' </snippet16>

    Public Sub New()
        InitializeComponent()

    End Sub


    ' <snippet11>
    Private Sub Form1_Load( _
    ByVal sender As Object, _
    ByVal e As EventArgs) Handles MyBase.Load

        ' Create the ElementHost control.
        elemHost = New ElementHost()
        elemHost.Dock = DockStyle.Fill
        Me.Controls.Add(elemHost)

        ' Create a Windows Presentation Foundation Button element 
        ' and assign it as the ElementHost control's child. 
        Dim wpfButton As New System.Windows.Controls.Button()
        wpfButton.Content = "Windows Presentation Foundation Button"
        elemHost.Child = wpfButton

        ' Map the Margin property.
        Me.AddMarginMapping()

        ' Remove the mapping for the Cursor property.
        Me.RemoveCursorMapping()

        ' Add a mapping for the Region property.
        Me.AddRegionMapping()

        ' Add another mapping for the BackColor property.
        Me.ExtendBackColorMapping()

        ' Cause the OnMarginChange delegate to be called.
        elemHost.Margin = New Padding(23, 23, 23, 23)

        ' Cause the OnRegionChange delegate to be called.
        elemHost.Region = New [Region]()

        ' Cause the OnBackColorChange delegate to be called.
        elemHost.BackColor = System.Drawing.Color.AliceBlue

    End Sub
    ' </snippet11>

    ' <snippet12>
    ' The AddMarginMapping method adds a new property mapping
    ' for the Margin property.
    Private Sub AddMarginMapping()

        elemHost.PropertyMap.Add( _
            "Margin", _
            New PropertyTranslator(AddressOf OnMarginChange))

    End Sub


    ' The OnMarginChange method implements the mapping 
    ' from the Windows Forms Margin property to the
    ' Windows Presentation Foundation Margin property.
    '
    ' The provided Padding value is used to construct 
    ' a Thickness value for the hosted element's Margin
    ' property.
    Private Sub OnMarginChange( _
    ByVal h As Object, _
    ByVal propertyName As String, _
    ByVal value As Object)

        Dim host As ElementHost = h
        Dim p As Padding = CType(value, Padding)
        Dim wpfButton As System.Windows.Controls.Button = host.Child


        Dim t As New Thickness(p.Left, p.Top, p.Right, p.Bottom)

        wpfButton.Margin = t

    End Sub
    ' </snippet12>

    ' <snippet13>
    ' The RemoveCursorMapping method deletes the default
    ' mapping for the Cursor property.
    Private Sub RemoveCursorMapping()
        elemHost.PropertyMap.Remove("Cursor")
    End Sub
    ' </snippet13>

    ' <snippet14>
    ' The AddRegionMapping method assigns a custom 
    ' mapping for the Region property.
    Private Sub AddRegionMapping()

        elemHost.PropertyMap.Add( _
            "Region", _
            New PropertyTranslator(AddressOf OnRegionChange))

    End Sub


    ' The OnRegionChange method assigns an EllipseGeometry to
    ' the hosted element's Clip property.
    Private Sub OnRegionChange( _
    ByVal h As Object, _
    ByVal propertyName As String, _
    ByVal value As Object)

        Dim host As ElementHost = h

        Dim wpfButton As System.Windows.Controls.Button = host.Child

        wpfButton.Clip = New EllipseGeometry(New Rect( _
            0, _
            0, _
            wpfButton.ActualWidth, _
            wpfButton.ActualHeight))

    End Sub


    ' The Form1_Resize method handles the form's Resize event.
    ' It calls the OnRegionChange method explicitly to 
    ' assign a new clipping geometry to the hosted element.
    Private Sub Form1_Resize( _
    ByVal sender As Object, _
    ByVal e As EventArgs) Handles MyBase.Resize

        If elemHost IsNot Nothing Then
            Me.OnRegionChange(elemHost, "Region", Nothing)
        End If

    End Sub
    ' </snippet14>

    ' <snippet15>
    ' The ExtendBackColorMapping method adds a property
    ' translator if a mapping already exists.
    Private Sub ExtendBackColorMapping()

        If elemHost.PropertyMap("BackColor") IsNot Nothing Then

            elemHost.PropertyMap("BackColor") = PropertyTranslator.Combine( _
                elemHost.PropertyMap("BackColor"), _
                PropertyTranslator.CreateDelegate( _
                GetType(PropertyTranslator), _
                Me, _
                "OnBackColorChange"))
        End If

    End Sub


    ' The OnBackColorChange method assigns a specific image 
    ' to the hosted element's Background property.
    Private Sub OnBackColorChange( _
    ByVal h As Object, _
    ByVal propertyName As String, _
    ByVal value As Object)

        Dim host As ElementHost = h
        Dim wpfButton As System.Windows.Controls.Button = host.Child
        Dim b As New ImageBrush(New BitmapImage( _
            New Uri("file:///C:\WINDOWS\Santa Fe Stucco.bmp")))
        wpfButton.Background = b

    End Sub
    ' </snippet15>

End Class
' </snippet1>
