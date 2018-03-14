 ' <snippet10>
Imports System
Imports System.Windows
Imports System.Windows.Media
Imports System.Windows.Controls
Imports System.Windows.Navigation
Imports MyControls
Imports System.Windows.Forms.Integration


Class MainWindow
    Inherits Window

    ' <snippet11>
    Private app As Application
    Private myWindow As Window
    Private initFontWeight As FontWeight
    Private initFontSize As [Double]
    Private initFontStyle As FontStyle
    Private initBackBrush As SolidColorBrush
    Private initForeBrush As SolidColorBrush
    Private initFontFamily As FontFamily
    Private UIIsReady As Boolean = False


    Private Sub Init(ByVal sender As Object, ByVal e As RoutedEventArgs)
        app = System.Windows.Application.Current
        myWindow = CType(app.MainWindow, Window)
        myWindow.SizeToContent = SizeToContent.WidthAndHeight
        wfh.TabIndex = 10
        initFontSize = wfh.FontSize
        initFontWeight = wfh.FontWeight
        initFontFamily = wfh.FontFamily
        initFontStyle = wfh.FontStyle
        initBackBrush = CType(wfh.Background, SolidColorBrush)
        initForeBrush = CType(wfh.Foreground, SolidColorBrush)

        Dim mc As MyControl1 = wfh.Child

        AddHandler mc.OnButtonClick, AddressOf Pane1_OnButtonClick
        UIIsReady = True

    End Sub
    ' </snippet11>

    ' <snippet13>
    Private Sub BackColorChanged(ByVal sender As Object, ByVal e As RoutedEventArgs)

        If sender.Equals(rdbtnBackGreen) Then
            wfh.Background = New SolidColorBrush(Colors.LightGreen)
        ElseIf sender.Equals(rdbtnBackSalmon) Then
            wfh.Background = New SolidColorBrush(Colors.LightSalmon)
        ElseIf UIIsReady = True Then
            wfh.Background = initBackBrush
        End If

    End Sub

    Private Sub ForeColorChanged(ByVal sender As Object, ByVal e As RoutedEventArgs)
        If sender.Equals(rdbtnForeRed) Then
            wfh.Foreground = New SolidColorBrush(Colors.Red)
        ElseIf sender.Equals(rdbtnForeYellow) Then
            wfh.Foreground = New SolidColorBrush(Colors.Yellow)
        ElseIf UIIsReady = True Then
            wfh.Foreground = initForeBrush
        End If

    End Sub

    Private Sub FontChanged(ByVal sender As Object, ByVal e As RoutedEventArgs)
        If sender.Equals(rdbtnTimes) Then
            wfh.FontFamily = New FontFamily("Times New Roman")
        ElseIf sender.Equals(rdbtnWingdings) Then
            wfh.FontFamily = New FontFamily("Wingdings")
        ElseIf UIIsReady = True Then
            wfh.FontFamily = initFontFamily
        End If

    End Sub

    Private Sub FontSizeChanged(ByVal sender As Object, ByVal e As RoutedEventArgs)
        If sender.Equals(rdbtnTen) Then
            wfh.FontSize = 10
        ElseIf sender.Equals(rdbtnTwelve) Then
            wfh.FontSize = 12
        ElseIf UIIsReady = True Then
            wfh.FontSize = initFontSize
        End If

    End Sub

    Private Sub StyleChanged(ByVal sender As Object, ByVal e As RoutedEventArgs)
        If sender.Equals(rdbtnItalic) Then
            wfh.FontStyle = FontStyles.Italic
        ElseIf UIIsReady = True Then
            wfh.FontStyle = initFontStyle
        End If

    End Sub

    Private Sub WeightChanged(ByVal sender As Object, ByVal e As RoutedEventArgs)
        If sender.Equals(rdbtnBold) Then
            wfh.FontWeight = FontWeights.Bold
        ElseIf UIIsReady = True Then
            wfh.FontWeight = initFontWeight
        End If

    End Sub
    ' </snippet13>

    ' <snippet12>
    'Handle button clicks on the Windows Form control
    Private Sub Pane1_OnButtonClick(ByVal sender As Object, ByVal args As MyControlEventArgs)
        txtName.Inlines.Clear()
        txtAddress.Inlines.Clear()
        txtCity.Inlines.Clear()
        txtState.Inlines.Clear()
        txtZip.Inlines.Clear()

        If args.IsOK Then
            txtName.Inlines.Add(" " + args.MyName)
            txtAddress.Inlines.Add(" " + args.MyStreetAddress)
            txtCity.Inlines.Add(" " + args.MyCity)
            txtState.Inlines.Add(" " + args.MyState)
            txtZip.Inlines.Add(" " + args.MyZip)
        End If

    End Sub
    ' </snippet12>
End Class
' </snippet10>