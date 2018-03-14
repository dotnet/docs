Imports System
Imports System.Windows
Imports System.Windows.Controls
Imports System.Windows.Data
Imports System.Windows.Documents
Imports System.Windows.Input
Imports System.Windows.Media
Imports System.Windows.Shapes
Imports System.Collections


' Interaction logic for Window1.xaml
Partial Public Class Window1
    Inherits Window
    Public Sub New()
        InitializeComponent()

        textbox0.Text = ""

        ' Set event handler for stylus down event in button
        ' <Snippet18>
        AddHandler button1.StylusDown, AddressOf button1_StylusDown
        ' </Snippet18>

        AddHandler button1.StylusUp, AddressOf button1_StylusUp

        AddHandler button1.MouseLeftButtonDown, AddressOf button1_MouseLeftButtonDown
        AddHandler button1.MouseLeftButtonUp, AddressOf button1_MouseLeftButtonUp
    End Sub
    Private Sub button1_StylusDown(ByVal sender As Object, ByVal e As StylusDownEventArgs)
        ' Notify base class of event
        MyBase.OnStylusDown(e)

        ' Barf out a message that the stylus is down
        textbox0.Text = "Stylus Down"
    End Sub
    Private Sub button1_StylusUp(ByVal sender As Object, ByVal e As StylusEventArgs)
        MyBase.OnStylusUp(e)

        textbox0.Text = ""
    End Sub
    Private Sub button1_MouseLeftButtonDown(ByVal sender As Object, ByVal e As MouseButtonEventArgs)
        MyBase.OnMouseLeftButtonDown(e)

        textbox0.Text = "Mouse Left Button Down"
    End Sub
    Private Sub button1_MouseLeftButtonUp(ByVal sender As Object, ByVal e As MouseButtonEventArgs)
        MyBase.OnMouseLeftButtonUp(e)

        textbox0.Text = ""
    End Sub
    ' When user clicks button,
    ' barf out capabilities into panel

    Private Sub Button1Click(ByVal sender As Object, ByVal e As RoutedEventArgs) ' Handles button1.Click
        ' Clear the textbox if they clicked once before
        textbox1.Clear()

        ' <Snippet1>
        ' Get the current stylus device
        Dim myStylusDevice As StylusDevice = Stylus.CurrentStylusDevice
        ' </Snippet1>

        ' Check whether we got the current stylus
        If IsNothing(myStylusDevice) Then
            textbox1.AppendText("No current stylus device" + vbCrLf)

            ' Try to get it through the default tablet
            Dim defaultTabletDevice As TabletDevice = Tablet.TabletDevices(0)

            ' Quit if we did not get the default tablet
            If IsNothing(defaultTabletDevice) Then
                textbox1.AppendText("No default tablet device. Goodbye!" + vbCrLf)
                Return
            End If

            ' Now try to get the default stylus device through the default tablet device
            Dim myStylusDeviceCollection As StylusDeviceCollection = defaultTabletDevice.StylusDevices

            Dim numStylusDevices As Integer = myStylusDeviceCollection.Count

            ' If none returned, we are toast, so quit
            If numStylusDevices < 1 Then
                textbox1.AppendText("No stylus devices attached." + vbCrLf)
                Return
            Else
                ' We have at least one stylus device, so just grab the first one
                textbox1.AppendText("Got " + numStylusDevices.ToString() + " stylus device through default tablet" + vbCrLf)

                myStylusDevice = myStylusDeviceCollection(0)
            End If

            ' See what properties the default stylus device has

            ' <Snippet2>
            Dim myPresentationSource As PresentationSource = myStylusDevice.ActiveSource

            If IsNothing(myPresentationSource) Then
                textbox1.AppendText("ActiveSource : null" + vbCrLf)
            Else
                textbox1.AppendText("ActiveSource :" + myPresentationSource.ToString() + vbCrLf)
            End If
            ' </Snippet2>

            ' <Snippet15>
            Dim myTabletDevice As TabletDevice = myStylusDevice.TabletDevice
            ' </Snippet15>

            ' <Snippet3>
            ' Bind stylus to tablet's input element
            myStylusDevice.Capture(myStylusDevice.Target)
            ' </Snippet3>

            ' <Snippet4>
            ' See to what Captured property is set
            ' First see if it's null
            If IsNothing(myStylusDevice.Captured) Then
                textbox1.AppendText("Captured: null" + vbCrLf)
            Else
                ' Otherwise display the underlying type
                textbox1.AppendText("Captured (type): " + TypeName(myStylusDevice.Captured) + vbCrLf)
            End If
            ' </Snippet4>

            ' <Snippet5>
            ' Bind stylus to tablet's input element
            ' through entire subtree
            myStylusDevice.Capture(myStylusDevice.Target, CaptureMode.SubTree)
            ' </Snippet5>

            ' <Snippet6>
            ' See to what DirectlyOver property is set
            ' First see if it's null
            If IsNothing(myStylusDevice.DirectlyOver) Then
                textbox1.AppendText("DirectlyOver: null" + vbCrLf)
            Else
                ' Otherwise display the underlying type
                textbox1.AppendText("DirectlyOver (type): " + TypeName(myStylusDevice.DirectlyOver) + vbCrLf)
            End If
            ' </Snippet6>

            ' <Snippet7>
            Dim myStylusPoints As StylusPointCollection = _
                myStylusDevice.GetStylusPoints(myStylusDevice.Target)
            textbox1.AppendText("Got " + myStylusPoints.Count.ToString() + " packets" + vbCrLf)
            ' </Snippet7>

            ' <Snippet8>
            Dim myPoint As Point = myStylusDevice.GetPosition(myStylusDevice.Target)
            textbox1.AppendText("The relative position is: (" + myPoint.X.ToString() + "," + myPoint.Y.ToString() + ")" + vbCrLf)
            ' </Snippet8>

            ' <Snippet9>
            textbox1.AppendText("Id: " + myStylusDevice.Id.ToString() + vbCrLf)
            ' </Snippet9>

            ' <Snippet11>
            textbox1.AppendText("InRange: " + myStylusDevice.InRange.ToString() + vbCrLf)
            ' </Snippet11>

            ' <Snippet13>
            textbox1.AppendText("Name: " + myStylusDevice.Name + vbCrLf)
            ' </Snippet13>

            ' <Snippet14>
            Dim myStylusButtonCollection As StylusButtonCollection = myStylusDevice.StylusButtons

            If IsNothing(myStylusButtonCollection) Then
                textbox1.AppendText("StylusButtons: null" + vbCrLf)
            Else
                textbox1.AppendText("# of StylusButtons == " + myStylusButtonCollection.Count.ToString() + vbCrLf)
            End If
            ' </Snippet14>

            ' Snippet 15 (TabletDevice property) is between snippet 2 and snippet 3

            ' <Snippet16>
            ' See to what Target property is set
            ' First see if it's null
            If IsNothing(myStylusDevice.Target) Then
                textbox1.AppendText("Target: null" + vbCrLf)
            Else
                ' Otherwise display the underlying type
                textbox1.AppendText("Target (type): " + TypeName(myStylusDevice.Target) + vbCrLf)
            End If
            ' </Snippet16>

            ' <Snippet17>
            textbox1.AppendText(vbCrLf + "StylusDevice: " + myStylusDevice.ToString() + vbCrLf)
            ' </Snippet17>

            ' StylusButton members

            ' Dummy array to hold result of CopyTo method
            Dim myStylusButtonArray(100) As StylusButton

            Dim index As Integer = 0

            ' <Snippet19>
            myStylusButtonCollection.CopyTo(myStylusButtonArray, index)
            ' </Snippet19>

            ' <Snippet20>
            ' Get the names of the buttons
            Dim i As Integer

            While i < myStylusButtonCollection.Count
                textbox1.AppendText("Button[" + i.ToString() + "]: " + myStylusButtonCollection(i).Name)

                i = i + 1
            End While
            ' </Snippet20>

            ' <Snippet21>
            ' Ensure collection access is synchronized
            'If Not myStylusButtonCollection.IsSynchronized Then
            '    SyncLock (myStylusButtonCollection.SyncRoot)
            '        ' work with collection
            '    End SyncLock
            'End If
            ' </Snippet21>

            ' <Snippet22>
            ' Get the names of all of the of StylusButton objects
            ' and store them in an ArrayList
            Dim myStylusButtonNamesArrayList As ArrayList = New ArrayList()

            Dim sb As StylusButton

            For Each sb In myStylusButtonCollection
                myStylusButtonNamesArrayList.Add(sb.Name)
            Next
            ' </Snippet22>

            ' <Snippet23>
            ' Get the first StylusButton, if it exists
            If myStylusButtonCollection.Count > 0 Then
                Dim mySB As StylusButton = myStylusButtonCollection(0)
            End If
            ' </Snippet23>

            Dim myStylusButton As StylusButton = myStylusButtonCollection(0)

            ' <Snippet25>
            ' Get the name of the StylusButton
            textbox1.AppendText("StylusButton.Name: " + myStylusButton.Name + vbCrLf)
            ' </Snippet25>

            ' <Snippet26>
            ' Get the state of the StylusButton
            Select Case myStylusButton.StylusButtonState
                Case StylusButtonState.Down
                    textbox1.AppendText("StylusButton.State: Down" + vbCrLf)
                Case Else ' StylusButtonState.Up
                    textbox1.AppendText("StylusButton.State: Up" + vbCrLf)
            End Select
            ' </Snippet26>

            ' <Snippet27>
            ' Get the name of the StylusDevice to which the StylusButton is attached
            textbox1.AppendText("StylusButton.StylusDevice: " + myStylusButton.StylusDevice.Name + vbCrLf)
            ' </Snippet27>

            ' <Snippet28>
            ' Get string representation of the StylusButton
            textbox1.AppendText(vbCrLf + myStylusButton.ToString() + vbCrLf)
            ' </Snippet28>
        End If
    End Sub

    ' This isn't hooked up to anything.
    ' <Snippet24>
    Private Sub OnStylusButtonDown(ByVal sender As Object, ByVal e As StylusButtonEventArgs)

        Dim myStylusButton As StylusButton = e.StylusButton
        If myStylusButton.Guid = StylusPointProperties.BarrelButton.Id Then
            ' the barrel button on the stylus has been pressed
        End If
    End Sub
    ' </Snippet24>

    ' This isn't hooked up to anything.
    ' <Snippet10>
    Private Sub OnMouseMove(ByVal sender As Object, _
                            ByVal e As MouseEventArgs)

        Dim myStylusDevice As StylusDevice
        myStylusDevice = e.StylusDevice
        If Not IsNothing(myStylusDevice) Then
            If myStylusDevice.InAir = True Then
                textbox1.Text = "stylus moves in air"
            Else
                textbox1.Text = "stylus moves with pen down"
            End If
        End If
    End Sub
    ' </Snippet10>

    ' This isn't hooked up to anything.
    ' <Snippet12>
    Private Sub OnStylusMove(ByVal sender As Object, _
                             ByVal e As StylusEventArgs)

        Dim myStylusDevice As StylusDevice
        myStylusDevice = e.StylusDevice
        If myStylusDevice.Inverted = True Then
            textbox1.Text = "stylus moves with eraser down"
        Else
            textbox1.Text = "stylus moves with pen down"
        End If
    End Sub
    ' </Snippet12>

End Class
