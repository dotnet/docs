Partial Public Class Window1


    Public Sub New()
        InitializeComponent()

        Snippet1()
        InitializeDatePicker()
    End Sub

    Private Sub Snippet1()
        '<Snippet1> 
        Dim datePickerFor2009 As New DatePicker()
        datePickerFor2009.SelectedDate = New DateTime(2009, 3, 23)
        datePickerFor2009.DisplayDateStart = New DateTime(2009, 1, 1)
        datePickerFor2009.DisplayDateEnd = New DateTime(2009, 12, 31)
        datePickerFor2009.SelectedDateFormat = DatePickerFormat.[Long]
        datePickerFor2009.FirstDayOfWeek = DayOfWeek.Monday

        ' root is a Panel that is defined elsewhere. 
        root.Children.Add(datePickerFor2009)
        '</Snippet1> 

    End Sub

    Private Sub InitializeDatePicker()

        '<Snippet2> 
        Dim datePickerWithBlackoutDates As New DatePicker()

        datePickerWithBlackoutDates.DisplayDateStart = New DateTime(2009, 8, 1)
        datePickerWithBlackoutDates.DisplayDateEnd = New DateTime(2009, 8, 31)
        datePickerWithBlackoutDates.SelectedDate = New DateTime(2009, 8, 10)

        datePickerWithBlackoutDates.BlackoutDates.Add( _
            New CalendarDateRange(New DateTime(2009, 8, 1), New DateTime(2009, 8, 2)))

        datePickerWithBlackoutDates.BlackoutDates.Add( _
            New CalendarDateRange(New DateTime(2009, 8, 8), New DateTime(2009, 8, 9)))

        datePickerWithBlackoutDates.BlackoutDates.Add( _
            New CalendarDateRange(New DateTime(2009, 8, 15), New DateTime(2009, 8, 16)))

        datePickerWithBlackoutDates.BlackoutDates.Add( _
            New CalendarDateRange(New DateTime(2009, 8, 22), New DateTime(2009, 8, 23)))

        datePickerWithBlackoutDates.BlackoutDates.Add( _
            New CalendarDateRange(New DateTime(2009, 8, 29), New DateTime(2009, 8, 30)))

        AddHandler datePickerWithBlackoutDates.DateValidationError, _
            AddressOf DatePicker_DateValidationError

        ' root is a Panel that is defined elsewhere. 
        root.Children.Add(datePickerWithBlackoutDates)
        '</Snippet2> 
    End Sub

    '<Snippet3> 
    ' If the text is a valid date, but a part of the 
    ' BlackoutDates collection, show a message. 
    ' If the text is not a valid date, thow an exception. 
    Private Sub DatePicker_DateValidationError(ByVal sender As Object, _
                                               ByVal e As DatePickerDateValidationErrorEventArgs)

        Dim newDate As DateTime
        Dim datePickerObj As DatePicker = TryCast(sender, DatePicker)

        If DateTime.TryParse(e.Text, newDate) Then
            If datePickerObj.BlackoutDates.Contains(newDate) Then
                MessageBox.Show([String].Format("The date, {0}, cannot be selected.", e.Text))
            End If
        Else
            e.ThrowException = True
        End If
    End Sub
    '</Snippet3> 

    '<Snippet8>
    Private Sub DatePicker_CalendarOpened(
                 ByVal sender As System.Object,
                 ByVal e As System.Windows.RoutedEventArgs)
        textBlock1.Text = "Select a date from the calendar"
    End Sub

    Private Sub DatePicker_CalendarClosed(
                 ByVal sender As System.Object,
                 ByVal e As System.Windows.RoutedEventArgs)
        textBlock1.Text = "Enter a date or click the calendar"
    End Sub
    '</Snippet8>

End Class
