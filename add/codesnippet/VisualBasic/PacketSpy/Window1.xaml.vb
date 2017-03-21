
Imports System
Imports System.Windows
Imports System.Windows.Controls
Imports System.Windows.Data
Imports System.Windows.Documents
Imports System.Windows.Media
Imports System.Windows.Shapes
Imports System.Windows.Ink
Imports System.Windows.Input
Imports System.Threading
Imports System.Collections.ObjectModel
Imports System.Collections.Generic
Imports System.Reflection
Imports System.IO


'/ <summary>
'/ Interaction logic for Window1.xaml
'/ </summary>

Class Window1
    Inherits Window '
    'ToDo: Error processing original source shown below
    '
    '    public partial class Window1 : Window
    '------------^--- 'class', 'struct', 'interface' or 'delegate' expected
    '
    'ToDo: Error processing original source shown below
    '
    '    public partial class Window1 : Window
    '--------------------^--- Syntax error: ';' expected
    Private constrainingRect As Rect
    
    
    
    Public Sub New() 
        InitializeComponent()
        Me.WindowState = WindowState.Maximized
        inkCanvas1.EditingMode = InkCanvasEditingMode.Ink
        inkCanvas1.DefaultDrawingAttributes.IgnorePressure = False
        inkCanvas1.DefaultDrawingAttributes.Height = 5
        inkCanvas1.DefaultDrawingAttributes.Width = 5
        AddHandler inkCanvas1.StylusDown, AddressOf inkCanvas1_StylusDown
        AddHandler inkCanvas1.StylusMove, AddressOf inkCanvas1_StylusMove
        
        
        
        inkCanvas1.DefaultStylusPointDescription = New StylusPointDescription(New StylusPointPropertyInfo() {New StylusPointPropertyInfo(StylusPointProperties.X), New StylusPointPropertyInfo(StylusPointProperties.Y), New StylusPointPropertyInfo(StylusPointProperties.NormalPressure)})
        
        constrainingRect = New Rect(100, 100, 200, 200)
        
        AddHandler Me.KeyDown, AddressOf Window1_KeyDown
        
        'DrawRect();
        StylusPointConstructor()
        
        StylusPointCollectionSnippets()
        DescriptionSnippets()
        ClonePoints()
        StylusPropertySnippets()
    
    End Sub 'New
     
    'CompareDescriptions();
    'MessageBox.Show(StylusPoint.MinXYValue.ToString() & ", " +
    '    StylusPoint.MaxXYValue.ToString());
    
    Private Sub Window1_KeyDown(ByVal sender As Object, ByVal e As KeyEventArgs)
        If e.Key = Key.T Then
            GetTabletStylusPointProperties()
        End If

    End Sub 'Window1_KeyDown
    
    
    ' <Snippet21>
    Private Sub inkCanvas1_StylusMove(ByVal sender As Object, ByVal e As StylusEventArgs)
        Dim points As StylusPointCollection = e.GetStylusPoints(inkCanvas1)
        Dim description As StylusPointDescription = points.Description
        Dim normalPressureInfo As New StringWriter()

        If description.HasProperty(StylusPointProperties.NormalPressure) Then

            Dim propertyInfo As StylusPointPropertyInfo = _
                description.GetPropertyInfo(StylusPointProperties.NormalPressure)

            normalPressureInfo.WriteLine("  Guid = {0}", propertyInfo.Id.ToString())
            normalPressureInfo.Write("  Min = {0}", propertyInfo.Minimum.ToString())
            normalPressureInfo.Write("  Max = {0}", propertyInfo.Maximum.ToString())
            normalPressureInfo.Write("  Unit = {0}", propertyInfo.Unit.ToString())
            normalPressureInfo.WriteLine("  Res = {0}", propertyInfo.Resolution.ToString())
        End If

    End Sub 'inkCanvas1_StylusMove
    
    ' </Snippet21>

    '<Snippet13>
    Private Sub inkCanvas1_StylusDown(ByVal sender As Object, ByVal e As StylusDownEventArgs)
        Dim points As StylusPointCollection = e.GetStylusPoints(inkCanvas1)
        Dim firstPoint As Point = CType(points(0), Point)

        Dim circle As Ellipse = New Ellipse()
        circle.Width = 5
        circle.Height = 5
        circle.Fill = Brushes.Red
        InkCanvas.SetTop(circle, firstPoint.Y)
        InkCanvas.SetLeft(circle, firstPoint.X)
        inkCanvas1.Children.Add(circle)

    End Sub 'inkCanvas1_StylusDown    
    '</Snippet13>

    Sub ValidateMinMaxX(ByVal point As StylusPoint) 
        Dim x As Double = 1000
        
        '<Snippet14>
        If x < StylusPoint.MinXY Then
            x = StylusPoint.MinXY
        ElseIf x > StylusPoint.MaxXY Then
            x = StylusPoint.MaxXY
        End If
        
        point.X = x
        '</Snippet14>

    End Sub 'ValidateMinMaxX

    '<Snippet15>
    Private Sub inkCanvas1_StylusSystemGesture(ByVal sender As Object, ByVal e As StylusSystemGestureEventArgs)

        Me.Title = e.SystemGesture.ToString()

        Select Case e.SystemGesture
            Case SystemGesture.RightTap
                ' Do something.

            Case SystemGesture.Tap
                ' Do something else.
        End Select

    End Sub 'inkCanvas1_StylusSystemGesture
    
    '</Snippet15>

    Sub GetTabletStylusPointProperties()
        '<Snippet27>
        Dim currentTablet As TabletDevice = Tablet.CurrentTabletDevice

        Dim supportedProperties As ReadOnlyCollection(Of StylusPointProperty) _
                    = currentTablet.SupportedStylusPointProperties

        Dim properties As New StringWriter()

        For Each supportedProperty As StylusPointProperty In supportedProperties
            properties.WriteLine(supportedProperty.ToString())
        Next supportedProperty

        MessageBox.Show(properties.ToString())
        '</Snippet27>

    End Sub 'GetTabletStylusPointProperties

    
    ' To use Loaded event put Loaded="WindowLoaded" attribute in root element of .xaml file.
    ' private void WindowLoaded(object sender, EventArgs e) {}
    ' Sample event handler:  
    'private void SaveStrokes_Click(object sender, RoutedEventArgs e) 
    '{
    '}
    Private Sub DrawRect() 
        Dim myRectVisual As DrawingVisual
        
        myRectVisual = New DrawingVisual()
        Dim myDrawingContext As DrawingContext = myRectVisual.RenderOpen()
        
        Dim mySolidColorBrush As New SolidColorBrush()
        Dim myPen As New Pen(Brushes.Red, 1)
        
        myDrawingContext.DrawRectangle(Nothing, myPen, constrainingRect)
        
        ' Important: Close the DrawingContext.
        myDrawingContext.Close()
        
        'Dim collection As VisualCollection = VisualOperations.GetChildren(inkCanvas1)

        'collection.Add(myRectVisual)
    
    End Sub 'DrawRect
     
    
    Private Sub StylusMoveEventHandler(ByVal sender As Object, ByVal e As StylusEventArgs) 
        
        Dim points As StylusPointCollection = e.GetStylusPoints(inkCanvas1)
        WriteStylusPointValues(points)
        WriteDescriptionInfo(points)
    
    End Sub 'StylusMoveEventHandler
    
    
    Private Sub StylusEventHandler(ByVal sender As Object, ByVal e As StylusEventArgs) 
    
    End Sub 'StylusEventHandler
    
    
    
    Sub GetDescriptionFromStylusDevice() 
        '<Snippet26>
        Dim currentStylus As StylusDevice = Stylus.CurrentStylusDevice

        Dim description1 As New StylusPointDescription(New StylusPointPropertyInfo() _
            {New StylusPointPropertyInfo(StylusPointProperties.X), _
             New StylusPointPropertyInfo(StylusPointProperties.Y), _
             New StylusPointPropertyInfo(StylusPointProperties.NormalPressure), _
             New StylusPointPropertyInfo(StylusPointProperties.XTiltOrientation), _
             New StylusPointPropertyInfo(StylusPointProperties.YTiltOrientation), _
             New StylusPointPropertyInfo(StylusPointProperties.BarrelButton)})
        
        Dim description2 As StylusPointDescription = currentStylus.GetStylusPoints(inkCanvas1).Description
        
        Dim description3 As StylusPointDescription = _
                                StylusPointDescription.GetCommonDescription(description1, description2)
        
        Dim points As StylusPointCollection = currentStylus.GetStylusPoints(inkCanvas1, description3)
        '</Snippet26>
    End Sub 'GetDescriptionFromStylusDevice

    
    '<Snippet2>
    Private Sub WriteDescriptionInfo(ByVal points As StylusPointCollection) 

        Dim pointsDescription As StylusPointDescription = points.Description

        Dim properties As ReadOnlyCollection(Of StylusPointPropertyInfo) = _
            pointsDescription.GetStylusPointProperties()

        Dim descriptionStringWriter As New StringWriter
        descriptionStringWriter.Write("Property Count:{0}", pointsDescription.PropertyCount.ToString())
        
        Dim pointProperty As StylusPointPropertyInfo
        For Each pointProperty In properties

            ' GetStylusPointPropertyName is defined below and returns the
            ' name of the property.
            descriptionStringWriter.Write("name = {0}", GetStylusPointPropertyName(pointProperty).ToString())
            descriptionStringWriter.WriteLine("  Guid = {0}", pointProperty.Id.ToString())
            descriptionStringWriter.Write("  IsButton = {0}", pointProperty.IsButton.ToString())
            descriptionStringWriter.Write("  Min = {0}", pointProperty.Minimum.ToString())
            descriptionStringWriter.Write("  Max = {0}", pointProperty.Maximum.ToString())
            descriptionStringWriter.Write("  Unit = {0}", pointProperty.Unit.ToString())
            descriptionStringWriter.WriteLine("  Res {0}", pointProperty.Resolution.ToString())

        Next pointProperty

        descriptionOutput.Text = descriptionStringWriter.ToString()

    End Sub 'WriteDescriptionInfo
    
    '</Snippet2>
    '<Snippet3>
    Private Sub WriteStylusPointValues(ByVal points As StylusPointCollection) 
        Dim pointsDescription As StylusPointDescription = points.Description
        
        Dim properties As ReadOnlyCollection(Of StylusPointPropertyInfo) = _
                                pointsDescription.GetStylusPointProperties()
        
        ' Write the name and and value of each property in
        ' every stylus point.
        Dim packetWriter As New StringWriter()

        packetWriter.WriteLine("{0} stylus points", points.Count.ToString())

        For Each stylusPoint As StylusPoint In points

            packetWriter.WriteLine("Stylus Point info")
            packetWriter.WriteLine("X: {0}", stylusPoint.X.ToString())
            packetWriter.WriteLine("Y: {0}", stylusPoint.Y.ToString())
            packetWriter.WriteLine("Pressure: {0}", stylusPoint.PressureFactor.ToString())

            ' Get the property name and value for each StylusPoint.
            ' Note that this loop reports the X, Y, and pressure values differantly than 
            ' getting their values above.
            For i As Integer = 0 To pointsDescription.PropertyCount - 1

                Dim currentProperty As StylusPointProperty = properties(i)

                ' GetStylusPointPropertyName is defined below and returns the
                ' name of the property.
                packetWriter.Write("{0}: ", GetStylusPointPropertyName(currentProperty))
                packetWriter.WriteLine(stylusPoint.GetPropertyValue(currentProperty).ToString())
            Next i

            packetWriter.WriteLine()

        Next stylusPoint

        packetOutput.Text = packetWriter.ToString()

    End Sub 'WriteStylusPointValues
    
    '</Snippet3>
    '<Snippet4>
    ' Use reflection to get the name of currentProperty.
    Private Function GetStylusPointPropertyName(ByVal currentProperty As StylusPointProperty) As String 
        Dim guid As Guid = currentProperty.Id
        
        ' Iterate through the StylusPointProperties to find the StylusPointProperty
        ' that matches currentProperty, then return the name.
        Dim theFieldInfo As FieldInfo

        For Each theFieldInfo In GetType(StylusPointProperties).GetFields()

            Dim pointProperty As StylusPointProperty = _
                CType(theFieldInfo.GetValue(currentProperty), StylusPointProperty)

            If pointProperty.Id = guid Then
                Return theFieldInfo.Name
            End If

        Next theFieldInfo

        Return "Not found"
    
    End Function 'GetStylusPointPropertyName
    
    '</Snippet4>
    Sub StylusPointConstructor()

        '<snippet5>
        Dim newDescription As New StylusPointDescription( _
            New StylusPointPropertyInfo() {New StylusPointPropertyInfo(StylusPointProperties.X), _
                                           New StylusPointPropertyInfo(StylusPointProperties.Y), _
                                           New StylusPointPropertyInfo(StylusPointProperties.NormalPressure), _
                                           New StylusPointPropertyInfo(StylusPointProperties.XTiltOrientation), _
                                           New StylusPointPropertyInfo(StylusPointProperties.YTiltOrientation), _
                                           New StylusPointPropertyInfo(StylusPointProperties.BarrelButton)})

        Dim propertyValues As Integer() = {1800, 1000, 1}

        Dim newStylusPoint As New StylusPoint(100, 100, 0.5F, newDescription, propertyValues)
        '</snippet5>

        '<Snippet16>
        Dim XTiltPropertyInfo As New StylusPointPropertyInfo( _
                                StylusPointProperties.XTiltOrientation, 0, 3600, _
                                StylusPointPropertyUnit.Degrees, 10.0F)
        '</Snippet16>
        Dim point As New StylusPoint()

        '<Snippet11>
        If point.HasProperty(StylusPointProperties.PitchRotation) Then
            Dim pitchRotation As Integer = _
                    point.GetPropertyValue(StylusPointProperties.PitchRotation)
        End If
        '</Snippet11>

        '<Snippet12>
        If point.HasProperty(StylusPointProperties.PitchRotation) Then
            point.SetPropertyValue(StylusPointProperties.PitchRotation, 1000)
        End If
        '</Snippet12>
    End Sub 'StylusPointConstructor

    
    ' All equality tests pass
    Sub TestStylusPointsEquality() 

        '<Snippet6>
        Dim point1 As New StylusPoint()
        Dim point2 As New StylusPoint()
        
        point1.X = 150
        point1.Y = 400
        point1.PressureFactor = 0.45F
        
        point2.X = 150
        point2.Y = 400
        point2.PressureFactor = 0.45F
        '</Snippet6>

        '<Snippet7>
        If point2.Equals(point1) Then
            MessageBox.Show("The two StylusPoint objects are equal.")
        Else
            MessageBox.Show("The two StylusPoint objects are not equal.")
        End If
        '</Snippet7>

        '<Snippet8>
        If StylusPoint.Equals(point1, point2) Then
            MessageBox.Show("The two StylusPoint objects are equal.")
        Else
            MessageBox.Show("The two StylusPoint objects are not equal.")
        End If
        '</Snippet8>

        '<Snippet9>
        If point1 = point2 Then
            MessageBox.Show("The two StylusPoint objects are equal.")
        Else
            MessageBox.Show("The two StylusPoint objects are not equal.")
        End If
        '</Snippet9>

        '<Snippet10>
        If point1 <> point2 Then
            MessageBox.Show("The two StylusPoint objects are not equal.")
        Else
            MessageBox.Show("The two StylusPoint objects are equal.")
        End If
        '</Snippet10>
    End Sub 'TestStylusPointsEquality

    
    Sub StylusPointCollectionSnippets()
        'MessageBox.Show("hi");
        '<Snippet20>
        Dim points As New StylusPointCollection(New Point() _
                                {New Point(100, 100), _
                                 New Point(100, 200), _
                                 New Point(200, 250), _
                                 New Point(300, 300)})
        '</Snippet20>
        'points.RemoveAt(0);
        'points.RemoveAt(0);
        Dim point As New StylusPoint(400, 300)

    End Sub 'StylusPointCollectionSnippets
     'points.Insert(3, point);
    'points.Insert(2, point);
    
    
    Sub StylusPointCollectionConstructor() 
        '<Snippet28>
        Dim stylusPoint1 As New StylusPoint(100, 100, 0.5F)
        Dim stylusPoint2 As New StylusPoint(200, 200, 0.35F)
        
        Dim points As New StylusPointCollection(New StylusPoint() {stylusPoint1, stylusPoint2})
        '</Snippet28>    
    End Sub 'StylusPointCollectionConstructor
    

    
    Sub DescriptionSnippets() 
        '<Snippet17>
        Dim description1 As New StylusPointDescription( _
            New StylusPointPropertyInfo() {New StylusPointPropertyInfo(StylusPointProperties.X), _
                                           New StylusPointPropertyInfo(StylusPointProperties.Y), _
                                           New StylusPointPropertyInfo(StylusPointProperties.NormalPressure), _
                                           New StylusPointPropertyInfo(StylusPointProperties.XTiltOrientation), _
                                           New StylusPointPropertyInfo(StylusPointProperties.YTiltOrientation), _
                                           New StylusPointPropertyInfo(StylusPointProperties.BarrelButton)})

        ' Create a StylusPointCollection that uses description1 as its
        ' StylusPointDescription.
        Dim points As New StylusPointCollection(description1)
        
        Dim description2 As New StylusPointDescription( _
            New StylusPointPropertyInfo() {New StylusPointPropertyInfo(StylusPointProperties.X), _
                                           New StylusPointPropertyInfo(StylusPointProperties.Y), _
                                           New StylusPointPropertyInfo(StylusPointProperties.NormalPressure), _
                                           New StylusPointPropertyInfo(StylusPointProperties.ButtonPressure), _
                                           New StylusPointPropertyInfo(StylusPointProperties.BarrelButton)})
        
        ' Find the common StylusPointDescription between description1
        ' and description2.  Get a StylusPointCollection that uses the
        ' common StylusPointDescription.
        Dim common As StylusPointDescription = _
                StylusPointDescription.GetCommonDescription(description1, description2)
        
        Dim points2 As StylusPointCollection = points.Reformat(common)
        '</Snippet17>    
    End Sub 'DescriptionSnippets


    Sub ClonePoints() 
        '<Snippet18>
        Dim rawPoints() As Point = {New Point(100, 100), _
                                    New Point(100, 200), _
                                    New Point(200, 250), _
                                    New Point(300, 300)}
        
        Dim points1 As New StylusPointCollection(rawPoints)
        
        ' Create a copy of points1 and change the second StylusPoint.
        Dim points2 As StylusPointCollection = points1.Clone()
        points2(1) = New StylusPoint(200, 100)
        
        ' Create a stroke from each StylusPointCollection and add them to
        ' inkCanvas1. Note that changing a StylusPoint in point2 did not
        ' affect points1.
        Dim stroke1 As New Stroke(points1)
        inkCanvas1.Strokes.Add(stroke1)
        
        Dim stroke2 As New Stroke(points2)
        stroke2.DrawingAttributes.Color = Colors.Red
        inkCanvas1.Strokes.Add(stroke2)
        '</Snippet18>
    End Sub 'ClonePoints

    
    
    Sub CompareDescriptions() 
        '<Snippet22>
        Dim description1 As New StylusPointDescription( _
            New StylusPointPropertyInfo() {New StylusPointPropertyInfo(StylusPointProperties.X), _
                                           New StylusPointPropertyInfo(StylusPointProperties.Y), _
                                           New StylusPointPropertyInfo(StylusPointProperties.NormalPressure), _
                                           New StylusPointPropertyInfo(StylusPointProperties.XTiltOrientation), _
                                           New StylusPointPropertyInfo(StylusPointProperties.YTiltOrientation), _
                                           New StylusPointPropertyInfo(StylusPointProperties.BarrelButton)})
        
        Dim description2 As New StylusPointDescription( _
            New StylusPointPropertyInfo() {New StylusPointPropertyInfo(StylusPointProperties.X), _
                                           New StylusPointPropertyInfo(StylusPointProperties.Y), _
                                           New StylusPointPropertyInfo(StylusPointProperties.NormalPressure), _
                                           New StylusPointPropertyInfo(StylusPointProperties.BarrelButton)})
        '</Snippet22>

        '<Snippet23>
        If StylusPointDescription.AreCompatible(description1, description2) Then
            MessageBox.Show("The two descriptions are compatible.")
        Else
            MessageBox.Show("The two descriptions are not compatible.")
        End If
        '</Snippet23>

        '<Snippet24>
        If description2.IsSubsetOf(description1) Then
            MessageBox.Show("description2 is a subset of description1.")
        Else
            MessageBox.Show("description2 is not a subset of description1.")
        End If
        '</Snippet24>
    End Sub 'CompareDescriptions

    
    Private Sub points_Changed(ByVal sender As Object, ByVal e As EventArgs)
        MessageBox.Show("The SylusPointCollection changed")

    End Sub 'points_Changed
    
    ' The OnStylusDown method is to demonstrate how to create
    ' a StylusPointCollection to collect stylus points in a custom control.
    ' Nothing happens with stylusPoints, it's dead end code.
    '<Snippet19>
    Private stylusPoints As StylusPointCollection
    
    
    Protected Overrides Sub OnStylusDown(ByVal e As StylusDownEventArgs) 
        MyBase.OnStylusDown(e)
        
        Dim eventPoints As StylusPointCollection = e.GetStylusPoints(Me)
        
        ' Create a new StylusPointCollection using the StylusPointDescription
        ' from the stylus points in the StylusDownEventArgs.
        stylusPoints = New StylusPointCollection(eventPoints.Description, eventPoints.Count)
        stylusPoints.Add(eventPoints)
    
    End Sub 'OnStylusDown
    '</Snippet19>

    Sub StylusPropertySnippets()
        Dim newProperty As New StylusPointPropertyInfo(StylusPointProperties.TwistOrientation)

        '<Snippet25>
        Dim guid As New Guid("12345678-1234-1234-1234-123456789012")
        Dim newlyDefinedProperty As New StylusPointProperty(guid, False)
        '</Snippet25>
    End Sub 'StylusPropertySnippets

    
    Sub StylusPropertyInfoSnippets() 
    
    End Sub 'StylusPropertyInfoSnippets
End Class 