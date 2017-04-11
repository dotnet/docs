Imports System
Imports System.Collections
Imports System.Windows
Imports System.Windows.Controls
Imports System.Windows.Data
Imports System.Windows.Documents
Imports System.Windows.Input
Imports System.Windows.Media
Imports System.Windows.Shapes


' Interaction logic for Window1.xaml
Partial Public Class Window1
    Inherits Window

    Public Sub New()
        InitializeComponent()


        ' Handle StylusButtonDown event
        AddHandler Me.StylusButtonDown, AddressOf Window1_StylusButtonDown
    End Sub
    Private Sub Window1_StylusButtonDown(ByVal sender As Object, ByVal e As StylusButtonEventArgs)
        ' <Snippet27>
        ' Get tablet device that generated event
        'Dim myTabletDevice As TabletDevice = e.TabletDevice
        ' </Snippet27>
    End Sub

    ' Sample event handlers:
    'Private Sub OnLoaded(ByVal sender As Object, ByVal e As RoutedEventArgs) Handles Me.Loaded

    'End Sub

    ' Event handler for a Button with a Name of Button1
    Private Sub Button1Click(ByVal sender As Object, ByVal e As RoutedEventArgs) Handles button1.Click
        ' Clear the textbox if they clicked once before
        textbox1.Clear()

        ' Find out if we have more than one tablet device
        Dim count As Integer = Tablet.TabletDevices.Count

        If count = 1 Then
            textbox1.AppendText("There is one tablet device" & vbCrLf)
        Else
            textbox1.AppendText("There are " & count.ToString() & " tablet devices" & vbCrLf)
        End If

        ' <Snippet7>
        ' Get the current tablet device, if it exists
        Dim myCurrentTabletDevice As TabletDevice = Tablet.CurrentTabletDevice
        ' </Snippet7>

        If IsNothing(myCurrentTabletDevice) Then
            textbox1.AppendText("INFO: Got the current tablet device" & vbCrLf)
        Else
            textbox1.AppendText("INFO: Cannot get the current tablet device" & vbCrLf)
        End If

        ' <Snippet15>
        '  Get the TabletDevice objects
        Dim myTabletDeviceCollection As TabletDeviceCollection = Tablet.TabletDevices

        ' <Snippet24>
        ' Display the types of TabletDevices
        Dim td As TabletDevice

        For Each td In myTabletDeviceCollection
            Console.WriteLine(td.Name)
        Next
        ' </Snippet24>
        ' </Snippet15>

        ' Store them in an array of strings
        ' <Snippet16>
        '  Get the number of tablet devices
        Dim numTabletDevices As Integer = myTabletDeviceCollection.Count
        ' </Snippet16>

        ' <Snippet19>
        Dim myTabletDeviceNamesArray(numTabletDevices) As String

        Dim i As Integer = 0

        While i < numTabletDevices
            myTabletDeviceNamesArray(i) = myTabletDeviceCollection(i).Name

            i = i & 1
        End While
        ' </Snippet19>

        Dim gotCurrentTabletDevice As Boolean = False

        ' Barf out list of tablet device names
        i = 0

        While i < numTabletDevices
            Dim theTD As TabletDevice = myTabletDeviceCollection(i)

            textbox1.AppendText("TabletDevice(" & i.ToString() & ").Name == " & theTD.Name)

            ' Is this one the current TabletDevice?
            If theTD Is myCurrentTabletDevice Then
                textbox1.AppendText(" (current tablet device)" & vbCrLf & vbCrLf)

                gotCurrentTabletDevice = True
            Else
                textbox1.AppendText(vbCrLf & vbCrLf)
            End If

            i = i & 1
        End While

        If Not gotCurrentTabletDevice Then
            textbox1.AppendText("No match for current tablet device" & vbCrLf & vbCrLf)
        End If

        ' <Snippet17>
        '  Is the collection thread safe?
        If Not myTabletDeviceCollection.IsSynchronized Then
            ' If not, use SyncRoot to lock access
            SyncLock myTabletDeviceCollection.SyncRoot
                ' work with collection
            End SyncLock
        End If
        ' </Snippet17>

        Dim myTabletDeviceArray(100) As TabletDevice
        Dim index As Integer = 0

        ' <Snippet18>
        ' Copy the collection to array of tablet devices starting at position index
        myTabletDeviceCollection.CopyTo(myTabletDeviceArray, index)
        ' </Snippet18>

        ' <Snippet3>
        ' Get the first tablet device
        Dim myTabletDevice As TabletDevice = Tablet.TabletDevices(0)
        ' </Snippet3>

        ' If tablet device exists, display its capabilities
        If Not IsNothing(myTabletDevice) Then
            textbox1.AppendText("TABLET" & vbCrLf)
            textbox1.AppendText("Properties" & vbCrLf & vbCrLf)

            ' Display the tablet device properties

            ' <Snippet4>
            Dim myPresentationSource As PresentationSource = myTabletDevice.ActiveSource

            If Not IsNothing(myPresentationSource) Then
                textbox1.AppendText("ActiveSource.RootVisual: " & myPresentationSource.RootVisual.ToString() & vbCrLf)
            Else
                textbox1.AppendText("ActiveSource: null" & vbCrLf)
            End If
            ' </Snippet4>

            ' <Snippet5>
            Dim myDispatcher As System.Windows.Threading.Dispatcher = myTabletDevice.Dispatcher

            If Not IsNothing(myDispatcher) Then
                textbox1.AppendText("Dispatcher: " & myDispatcher.ToString() & vbCrLf)
            Else
                textbox1.AppendText("Dispatcher: null" & vbCrLf)
            End If
            ' </Snippet5>

            ' <Snippet8>
            textbox1.AppendText("Id: " & myTabletDevice.Id.ToString() & vbCrLf)
            ' </Snippet8>

            ' <Snippet9>
            textbox1.AppendText("Name: " & myTabletDevice.Name & vbCrLf)
            ' </Snippet9>

            ' <Snippet10>
            textbox1.AppendText("ProductId: " & myTabletDevice.ProductId & vbCrLf)
            ' </Snippet10>

            Dim myStylusDeviceCollection As StylusDeviceCollection = myTabletDevice.StylusDevices

            ' <Snippet20>
            ' Get the number of stylus devices
            Dim numStylusDevices As Integer = myStylusDeviceCollection.Count
            ' </Snippet20>

            ' <Snippet21>
            Dim myStylusDeviceNamesArray(numStylusDevices) As String

            Dim j As Integer = 0

            While j < numStylusDevices
                myStylusDeviceNamesArray(j) = myStylusDeviceCollection(j).Name

                j = j & 1
            End While
            ' </Snippet21>

            ' <Snippet22>
            ' Is the collection thread safe?
            'If Not myStylusDeviceCollection.IsSynchronized Then
            '    SyncLock (myStylusDeviceCollection.SyncRoot)
            '        ' work with collection
            '    End SyncLock
            'End If
            ' </Snippet22>

            Dim myStylusDeviceArray(100) As StylusDevice
            index = 0

            ' <Snippet23>
            ' Copy the collection to array of stylus devices starting at position index
            myStylusDeviceCollection.CopyTo(myStylusDeviceArray, index)
            ' </Snippet23>

            Dim k As Integer = 0

            While k < myStylusDeviceCollection.Count
                textbox1.AppendText("StylusDevice[" & k.ToString() & "] name: " & myStylusDeviceCollection(k).Name & vbCrLf)

                k = k & 1
            End While

            ' <Snippet12>
            'Dim myStylusPacketDescription As StylusPacketDescription = myTabletDevice.StylusPacketDescription
            '' </Snippet12>

            'If Not IsNothing(myStylusPacketDescription) Then
            '    textbox1.AppendText("StylusPacketDescription" & vbCrLf)
            '    textbox1.AppendText("    Number of buttons: " & myStylusPacketDescription.ButtonCount.ToString() & vbCrLf)

            '    ' Buttons
            '    Dim l As Integer = 0

            '    While l < myTabletDevice.StylusPacketDescription.ButtonCount
            '        textbox1.AppendText("        Button[" & l.ToString() & "] GUID: " & myStylusPacketDescription.GetButton(l).ToString() & vbCrLf)

            '        l = l & 1
            '    End While

            '    textbox1.AppendText("    Packet size: " & myStylusPacketDescription.PacketSize.ToString() & vbCrLf)
            '    textbox1.AppendText("    Number of values: " & myStylusPacketDescription.ValueCount.ToString() & vbCrLf)

            '    ' Stylus metrics
            '    Dim myStylusPacketValueMetrics() As StylusPacketValueMetric = myStylusPacketDescription.GetValueMetrics()

            '    ' If metrics exist, display them
            '    If Not IsNothing(myStylusPacketValueMetrics) Then
            '        Dim m As Integer = 0

            '        While m < myStylusPacketValueMetrics.Length
            '            textbox1.AppendText("    Metric[" & m.ToString() & "]" & vbCrLf)
            '            textbox1.AppendText("        Name:       " & GetPacketValueName(myStylusPacketValueMetrics(m).Guid) & vbCrLf)
            '            textbox1.AppendText("        Guid:       " & myStylusPacketValueMetrics(m).Guid.ToString() & vbCrLf)
            '            textbox1.AppendText("        Min:        " & myStylusPacketValueMetrics(m).Minimum.ToString() & vbCrLf)
            '            textbox1.AppendText("        Max:        " & myStylusPacketValueMetrics(m).Maximum.ToString() & vbCrLf)
            '            textbox1.AppendText("        Unit:       " & myStylusPacketValueMetrics(m).Unit.ToString() & vbCrLf)
            '            textbox1.AppendText("        Resolution: " & myStylusPacketValueMetrics(m).Resolution.ToString() & vbCrLf)
            '            textbox1.AppendText(vbCrLf)

            '            m = m & 1
            '        End While
            '    End If
            'Else
            '    textbox1.AppendText("StylusPacketDescription: null" & vbCrLf)
            'End If

            ' <Snippet13>
            If IsNothing(myTabletDevice.Target) Then
                textbox1.AppendText("Target: null" & vbCrLf)
            Else
                textbox1.AppendText("Target: " & TypeName(myTabletDevice.Target) & vbCrLf)
            End If
            ' </Snippet13>

            ' <Snippet2>
            ' Get the type of tablet device
            Dim myTabletDeviceType As TabletDeviceType = myTabletDevice.Type

            ' Display the type of tablet device
            textbox1.AppendText("Type: ")

            Select Case myTabletDeviceType
                Case TabletDeviceType.Stylus
                    textbox1.AppendText("Stylus" & vbCrLf)
                Case Else ' TabletDeviceType.Touch
                    textbox1.AppendText("Touch pad" & vbCrLf)
            End Select
            ' </Snippet2>

            ' Show output from TabletDevice.ToString()
            ' <Snippet14>
            textbox1.AppendText("vbCrLf & Tablet Device:" & myTabletDevice.ToString() & vbCrLf)
            ' </Snippet14>

            textbox1.AppendText(vbCrLf)

            ' <Snippet1>
            ' Get the capabilities of the current tablet device
            Dim myHWCaps As TabletHardwareCapabilities = myTabletDevice.TabletHardwareCapabilities
            ' </Snippet1>

            ' <Snippet26>
            If ((Tablet.CurrentTabletDevice.TabletHardwareCapabilities And _
                 TabletHardwareCapabilities.SupportsPressure) = _
                 TabletHardwareCapabilities.SupportsPressure) Then

                textbox1.AppendText("The tablet can detect the pressure of the teblet pen.")
            End If
            ' </Snippet26>

            '    textbox1.AppendText(vbCrLf)

            '    ' Get the current stylus, if it exists:
            '    Dim myStylusDevice As StylusDevice = myTabletDevice.StylusDevices(0)

            '    ' If stylus exists, print its properties
            '    If Not IsNothing(myStylusDevice) Then
            '        textbox1.AppendText("STYLUS" & vbCrLf)

            '        textbox1.AppendText("ActiveSource: " & GetStringOrNull(myStylusDevice.ActiveSource) & vbCrLf)
            '        textbox1.AppendText("Captured: " & GetStringOrNull(myStylusDevice.Captured) & vbCrLf)
            '        textbox1.AppendText("DirectlyOver: " & GetStringOrNull(myStylusDevice.DirectlyOver) & vbCrLf)
            '        textbox1.AppendText("Dispatcher: " & GetStringOrNull(myStylusDevice.Dispatcher) & vbCrLf)
            '        textbox1.AppendText("ID: " & GetStringOrNull(myStylusDevice.Id) & vbCrLf)
            '        textbox1.AppendText("InAir: " & GetStringOrNull(myStylusDevice.InAir) & vbCrLf)
            '        textbox1.AppendText("InRange: " & GetStringOrNull(myStylusDevice.InRange) & vbCrLf)
            '        textbox1.AppendText("Inverted: " & GetStringOrNull(myStylusDevice.Inverted) & vbCrLf)
            '        textbox1.AppendText("Name: " & GetStringOrNull(myStylusDevice.Name) & vbCrLf)
            '        textbox1.AppendText("PacketCount: " & GetStringOrNull(myStylusDevice.GetPackets(myTabletDevice.Target).PacketCount) & vbCrLf)
            '        textbox1.AppendText("Tablet Device: " & GetStringOrNull(myStylusDevice.TabletDevice.Name) & vbCrLf)
            '        textbox1.AppendText("Tablet Position: " & GetStringOrNull(myStylusDevice.GetPosition(myTabletDevice.Target)) & vbCrLf)
            '        ' textbox1.AppendText("Target: " & GetStringOrNull(myStylusDevice.Target) & vbCrLf)
            '    End If
        End If
    End Sub

    Sub Snippet(ByVal myTabletDevice As TabletDevice)
        ' <Snippet11>
        ' Get the StylusDevice objects.
        Dim myStylusDeviceCollection As StylusDeviceCollection = myTabletDevice.StylusDevices

        ' Get the names of all of the of StylusDevice objects.
        Dim myStylusDeviceNames() As String = New String(myStylusDeviceCollection.Count) {}


        For i As Integer = 0 To myStylusDeviceCollection.Count - 1
            myStylusDeviceNames(i) = myStylusDeviceCollection(i).Name
        Next
        ' </Snippet11>


    End Sub

    ' Retrieve the names of the tablet devices
    Private Function GetTabletNames() As String()
        ' <Snippet6>
        Dim numberOfNames As Integer = Tablet.TabletDevices.Count
        ' </Snippet6>

        Dim s(numberOfNames) As String

        If Not numberOfNames = 0 Then
            Dim i As Integer

            While i < numberOfNames
                s(i) = Tablet.TabletDevices(i).Name
            End While
        End If

        Return s
    End Function

    Private Function GetStringOrNull(ByVal o As Object) As String
        If IsNothing(o) Then
            Return "null"
        Else
            Return o.ToString()
        End If
    End Function

    Private Function GetPacketValueName(ByVal guid As Guid) As String
        'If guid = StylusPacketValue.X Then
        '    Return "X"
        'End If

        'If guid = StylusPacketValue.Y Then
        '    Return "Y"
        'End If

        'If guid = StylusPacketValue.Z Then
        '    Return "Z"
        'End If

        'If guid = StylusPacketValue.AltitudeOrientation Then
        '    Return "AltitudeOrientation"
        'End If

        'If guid = StylusPacketValue.AzimuthOrientation Then
        '    Return "AzimuthOrientation"
        'End If

        'If guid = StylusPacketValue.BarrelButton Then
        '    Return "BarrelButton"
        'End If

        'If guid = StylusPacketValue.ButtonPressure Then
        '    Return "ButtonPressure"
        'End If

        'If guid = StylusPacketValue.NormalPressure Then
        '    Return "NormalPressure"
        'End If

        'If guid = StylusPacketValue.PacketStatus Then
        '    Return "PacketStatus"
        'End If

        'If guid = StylusPacketValue.PitchRotation Then
        '    Return "PitchRotation"
        'End If

        'If guid = StylusPacketValue.RollRotation Then
        '    Return "RollRotation"
        'End If

        'If guid = StylusPacketValue.SecondaryTipButton Then
        '    Return "SecondaryTipButton"
        'End If

        'If guid = StylusPacketValue.SerialNumber Then
        '    Return "SerialNumber"
        'End If

        'If guid = StylusPacketValue.TangentPressure Then
        '    Return "TangentPressure"
        'End If

        'If guid = StylusPacketValue.TimerTick Then
        '    Return "TimerTick"
        'End If

        'If guid = StylusPacketValue.TipButton Then
        '    Return "TipButton"
        'End If

        'If guid = StylusPacketValue.TwistOrientation Then
        '    Return "TwistOrientation"
        'End If

        'If guid = StylusPacketValue.XTiltOrientation Then
        '    Return "XTiltOrientation"
        'End If

        'If guid = StylusPacketValue.YawRotation Then
        '    Return "YawRotation"
        'End If

        'If guid = StylusPacketValue.YTiltOrientation Then
        '    Return "YTiltOrientation"
        'End If

        Return ""
    End Function




End Class
