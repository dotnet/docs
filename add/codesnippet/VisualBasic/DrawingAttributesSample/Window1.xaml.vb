
Imports System
Imports System.IO
Imports System.Windows
Imports System.Windows.Controls
Imports System.Windows.Data
Imports System.Windows.Documents
Imports System.Windows.Media
Imports System.Windows.Shapes
Imports System.Windows.Ink

'/ <summary>
'/ Interaction logic for Window1.xaml
'/ </summary>

Partial Public Class Window1
    Inherits Window

    '<Snippet3>
    Private WithEvents inkCanvas1 As New InkCanvas()
    Private inkDA As DrawingAttributes
    Private highlighterDA As DrawingAttributes
    Private useHighlighter As Boolean = False

    ' Add an InkCanvas to the window, and allow the user to 
    ' switch between using a green pen and a purple highlighter 
    ' on the InkCanvas.
    Private Sub WindowLoaded(ByVal sender As Object, ByVal e As RoutedEventArgs)

        inkCanvas1.Background = Brushes.DarkSlateBlue
        inkCanvas1.DefaultDrawingAttributes.Color = Colors.SpringGreen

        ' Add the InkCanvas to the DockPanel, named root.
        root.Children.Add(inkCanvas1)

        ' Set up the DrawingAttributes for the pen.
        inkDA = New DrawingAttributes()
        With inkDA
            .Color = Colors.SpringGreen
            .Height = 5
            .Width = 5
            .FitToCurve = True
        End With

        ' Set up the DrawingAttributes for the highlighter.
        highlighterDA = New DrawingAttributes()
        With highlighterDA
            .Color = Colors.Orchid
            .IsHighlighter = True
            .IgnorePressure = True
            .StylusTip = StylusTip.Rectangle
            .Height = 30
            .Width = 10
        End With

        inkCanvas1.DefaultDrawingAttributes = inkDA

    End Sub 'WindowLoaded


    ' Create a button called switchHighlighter and use 
    ' SwitchHighlighter_Click to handle the Click event.  
    ' The useHighlighter variable is a boolean that indicates
    ' whether the InkCanvas renders ink as a highlighter.

    '<Snippet2>
    ' Switch between using the 'pen' DrawingAttributes and the 
    ' 'highlighter' DrawingAttributes when the user clicks on .
    Private Sub SwitchHighlighter_Click(ByVal sender As [Object], ByVal e As RoutedEventArgs)

        useHighlighter = Not useHighlighter

        If useHighlighter Then
            switchHighlighter.Content = "Use Pen"
            inkCanvas1.DefaultDrawingAttributes = highlighterDA
        Else

            switchHighlighter.Content = "Use Highlighter"
            inkCanvas1.DefaultDrawingAttributes = inkDA
        End If

    End Sub 'SwitchHighlighter_Click
    '</Snippet2>

    '</Snippet3>

    '<Snippet6>
    Private Sub inkDA_AttributeChanged(ByVal sender As Object, _
                                      ByVal e As PropertyDataChangedEventArgs)

        If (e.PropertyGuid = DrawingAttributeIds.Color) Then
            Me.Title = "The pen color is: " + e.NewValue.ToString()
        End If

    End Sub
    '</Snippet6>

    Private Sub InitializeAllProperties()
        '<Snippet1>
        ' Set up the DrawingAttributes for the pen.
        inkDA = New Ink.DrawingAttributes()
        With inkDA
            .Color = Colors.SpringGreen
            .Height = 5
            .Width = 5
            .FitToCurve = True
            .StylusTipTransform = New Matrix(1, 0, 0, 1, 20, 0)
        End With

        ' Set up the DrawingAttributes for the highlighter.
        highlighterDA = New Ink.DrawingAttributes()
        With highlighterDA
            .Color = Colors.Orchid
            .IsHighlighter = True
            .IgnorePressure = True
            .StylusTip = StylusTip.Rectangle
            .Height = 30
            .Width = 10
        End With

        inkCanvas1.DefaultDrawingAttributes = inkDA
        ' </Snippet1>
    End Sub

    Public Sub New()
        InitializeComponent()
        'AddHandler inkCanvas1.StrokeCollected, AddressOf inkCanvas1_StrokeCollected
        AddHandler inkCanvas1.Strokes.StrokesChanged, AddressOf Strokes_StrokesChanged
        AddHandler inkCanvas1.StrokeErasing, AddressOf inkCanvas1_StrokeErasing
        AddHandler inkCanvas1.DefaultDrawingAttributesReplaced, AddressOf inkCanvas1_DefaultDrawingAttributesReplaced
        ' TODO: Remove from when the PropertyData is fixed.
        'AddHandler inkDA.AttributeChanged, AddressOf inkDA_AttributeChanged

        'Uncomment the following line to assign custom properties.
        'AssignDrawingAttributesInstrument()

    End Sub 'New

    '<Snippet17>
    Private Sub inkCanvas1_DefaultDrawingAttributesReplaced(ByVal sender As Object, _
                                ByVal e As DrawingAttributesReplacedEventArgs)

        If (e.NewDrawingAttributes.IsHighlighter) Then

            Me.Title = "Now using a highlighter."

        Else

            Me.Title = "Now using a pen."

        End If

    End Sub
    '</Snippet17>

    '<Snippet16>
    Private Sub inkCanvas1_StrokeErasing(ByVal sender As Object, _
                                 ByVal e As InkCanvasStrokeErasingEventArgs)

        If (e.Stroke.DrawingAttributes.IsHighlighter) Then
            e.Cancel = True

        End If
    End Sub
    '</Snippet16>

    '<Snippet4>
    Dim currentTimeGuid As Guid = New Guid("12345678-1234-1234-1234-123456789012")

    Private Sub Strokes_StrokesChanged(ByVal sender As Object, _
                ByVal args As StrokeCollectionChangedEventArgs)

        Dim s As Stroke

        For Each s In args.Added
            s.AddPropertyData(currentTimeGuid, DateTime.Now)
        Next

    End Sub
    '</Snippet4>

    Private Sub inkCanvas1_StrokeCollected(ByVal sender As Object, ByVal e As InkCanvasStrokeCollectedEventArgs)

    End Sub 'inkCanvas1_StrokeCollected

    Private Sub SaveStrokes_Click(ByVal sender As [Object], ByVal e As RoutedEventArgs)

        'Dim isf As [Byte]() = inkCanvas1.Strokes.Save(PersistenceFormat.InkSerializedFormat, CompressionMode.Maximum)

        'Dim fs As New FileStream("strokes.isf", FileMode.Create)
        'fs.Write(isf, 0, isf.Length)
        'fs.Close()

    End Sub 'SaveStrokes_Click

    Private Sub LoadStrokes_Click(ByVal sender As [Object], ByVal e As RoutedEventArgs)

        'If Not File.Exists("strokes.isf") Then
        '    MessageBox.Show("""strokes.isf"" does not exist." + _
        '        " Save the StrokeCollection before loading it.")
        '    Return
        'End If

        'Dim buffer(9999) As [Byte]
        'Dim fs As New FileStream("strokes.isf", FileMode.Open, _
        '    FileAccess.Read)
        'fs.Read(buffer, 0, buffer.Length)
        'fs.Close()

        'Dim strokes As New StrokeCollection(buffer)
        'inkCanvas1.Strokes = strokes

    End Sub 'LoadStrokes_Click 
    'ChangeAuthorsInk(aGuid, anAuthor, Colors.Red);

    '<Snippet5>
    Private purposeGuid As New Guid("12345678-9012-3456-7890-123456789012")
    Private penValue As String = "pen"
    Private highlighterValue As String = "highlighter"

    ' Add a property to each DrawingAttributes object to 
    ' specify its use.
    Private Sub AssignDrawingAttributesInstrument()

        inkDA.AddPropertyData(purposeGuid, penValue)
        highlighterDA.AddPropertyData(purposeGuid, highlighterValue)

    End Sub 'AssignDrawingAttributesInstrument

    ' Change the color of the ink that on the InkCanvas that used the pen.
    Private Sub ChangeColors_Click(ByVal sender As [Object], _
            ByVal e As RoutedEventArgs)

        Dim s As Stroke

        For Each s In inkCanvas1.Strokes
            If s.DrawingAttributes.ContainsPropertyData(purposeGuid) Then

                Dim data As Object = s.DrawingAttributes.GetPropertyData(purposeGuid)

                If TypeOf data Is String AndAlso CStr(data) = penValue Then
                    s.DrawingAttributes.Color = Colors.Black
                End If

            End If
        Next s

    End Sub 'ChangeColors_Click

    '</Snippet5>

    Private Sub ChangePenColors_Click(ByVal sender As [Object], _
                    ByVal e As RoutedEventArgs)

        If inkCanvas1.DefaultDrawingAttributes.Color = Colors.Black Then
            inkDA.Color = Colors.AntiqueWhite
        Else
            inkDA.Color = Colors.Black
        End If

    End Sub

    Private Sub ClearStrokes_Click(ByVal sender As [Object], ByVal e As RoutedEventArgs)
        inkCanvas1.Strokes.Clear()
        GetPropertyIds()

    End Sub 'ClearStrokes_Click

    Sub GetPropertyIds()

        '<Snippet7>
        Dim propertyIds() As Guid
        propertyIds = inkDA.GetPropertyDataIds()
        '</Snippet7>
    End Sub

    '<Snippet8>
    Sub CopyAttributes(ByVal someStroke As Stroke)
        Dim attributes As New DrawingAttributes()
        attributes.Color = Colors.Red
        someStroke.DrawingAttributes = attributes.Clone()
    End Sub
    '</Snippet8>

    '<Snippet9>
    Private customProperty As New Guid("12345678-9012-3456-7890-123456789012")

    Sub RemovePropertyDataId(ByVal attributes As Ink.DrawingAttributes)

        If attributes.ContainsPropertyData(customProperty) Then
            attributes.RemovePropertyData(customProperty)
        End If

    End Sub
    '</Snippet9>

    Private Sub AttributesEqual()

        '<Snippet10>
        Dim attributes1 As New DrawingAttributes()
        attributes1.Color = Colors.Blue
        attributes1.StylusTip = StylusTip.Rectangle
        attributes1.Height = 5
        attributes1.Width = 5

        Dim attributes2 As New DrawingAttributes()
        attributes2.Color = Colors.Blue
        attributes2.StylusTip = StylusTip.Rectangle
        attributes2.Height = 5
        attributes2.Width = 5
        '</Snippet10>

        '<Snippet11>
        If attributes1 = attributes2 Then
            MessageBox.Show("The DrawingAttributes are equal")
        Else
            MessageBox.Show("The DrawingAttributes are not equal")
        End If
        '</Snippet11>

        '<Snippet12>
        If attributes1.Equals(attributes2) Then
            MessageBox.Show("The DrawingAttributes are equal")
        Else
            MessageBox.Show("The DrawingAttributes are not equal")
        End If
        '</Snippet12>

        '<Snippet13>
        If attributes1 <> attributes2 Then
            MessageBox.Show("The DrawingAttributes are not equal")
        Else
            MessageBox.Show("The DrawingAttributes are equal")
        End If
        '</Snippet13>
    End Sub

    Private Sub ValidateHeightAndWidth()
        Dim DAHeight As Double = 100
        Dim DAWidth As Double = 100

        '<Snippet14>
        If DAHeight < DrawingAttributes.MinHeight Then

            DAHeight = DrawingAttributes.MinHeight

        ElseIf DAHeight > DrawingAttributes.MaxHeight Then

            DAHeight = DrawingAttributes.MaxHeight

        End If

        inkCanvas1.DefaultDrawingAttributes.Height = DAHeight
        '</Snippet14>

        '<Snippet15>
        If DAWidth < DrawingAttributes.MinWidth Then

            DAWidth = DrawingAttributes.MinWidth

        ElseIf DAWidth > DrawingAttributes.MaxWidth Then

            DAWidth = DrawingAttributes.MaxWidth

        End If

        inkCanvas1.DefaultDrawingAttributes.Width = DAWidth
        '</Snippet15>
    End Sub


End Class 'Window1  
