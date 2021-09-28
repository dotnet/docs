Option Explicit On
Option Strict On

Imports NorthwindStreamingClient.Northwind
Imports System.Data.Services.Client
Imports System.IO

Class CustomerPhotoWindow
    Private context As NorthwindEntities
    Private trackedEmployees As DataServiceCollection(Of Employees)
    Private currentEmployee As Employees

    ' Ideally, the service URI should be stored in the settings file.
    Private svcUri As Uri = _
        New Uri("http://" + Environment.MachineName + _
            "/NorthwindStreaming/NorthwindStreaming.svc")
    Public Sub New()
        InitializeComponent()
    End Sub

    Private Sub Window_Loaded(ByVal sender As Object, ByVal e As RoutedEventArgs)
        ' Instantiate the data service context.
        context = New NorthwindEntities(svcUri)

        Try
            ' Create a new collection for binding based on the LINQ query.
            trackedEmployees = New DataServiceCollection(Of Employees)(context.Employees)

            ' Load all pages of the response at once.
            While trackedEmployees.Continuation IsNot Nothing
                trackedEmployees.Load( _
                    context.Execute(Of Employees)(trackedEmployees.Continuation.NextLinkUri))
            End While


            ' Bind the root StackPanel element to the collection;
            ' related object binding paths are defined in the XAML.
            LayoutRoot.DataContext = trackedEmployees

            If trackedEmployees.Count = 0 Then
                MessageBox.Show("Data could not be returned from the data service.")
            End If

            ' Select the first employee in the collection.
            employeesComboBox.SelectedIndex = 0

        Catch ex As DataServiceQueryException
            MessageBox.Show(ex.Message)
        Catch ex As InvalidOperationException
            MessageBox.Show(ex.Message)
        End Try
    End Sub
    Private Sub employeesComboBox_SelectionChanged(ByVal sender As Object, ByVal e As SelectionChangedEventArgs)
        ' Get the currently selected employee.
        currentEmployee = _
            CType(Me.employeesComboBox.SelectedItem, Employees)

        Try
            '<snippetGetReadStreamClient>
            ' Get the read stream for the Media Resource of the currently selected 
            ' entity (Media Link Entry).
            Using response As DataServiceStreamResponse = _
                    context.GetReadStream(currentEmployee, "image/bmp")

                ' Use the returned binary stream to create a bitmap image that is 
                ' the source of the image control.
                employeeImage.Source = CreateBitmapFromStream(response.Stream)
            End Using
            '</snippetGetReadStreamClient>

            '<snippetGetReadStreamClientUri>
            ' Get the read stream URI for the Media Resource of the currently selected 
            ' entity (Media Link Entry), and use it to create a bitmap image that is 
            ' the source of the image control.
            employeeImage.Source = New BitmapImage(context.GetReadStreamUri(currentEmployee))
            '</snippetGetReadStreamClientUri>
        Catch ex As DataServiceRequestException
            MessageBox.Show(ex.InnerException.Message)
        End Try
    End Sub

    Private Sub setImage_Click(ByVal sender As Object, ByVal e As RoutedEventArgs)

        ' Create a dialog to select the bitmap to stream to the data service.
        Dim openImage As Microsoft.Win32.OpenFileDialog = New Microsoft.Win32.OpenFileDialog()
        With openImage
            .FileName = "image"
            .DefaultExt = ".bmp"
            .Filter = "Bitmap images (.bmp)|*.bmp"
            .Title = "Select the image file to upload..."
        End With

        Try
            If openImage.ShowDialog(Me) = True Then
                '<snippetSetSaveStreamClient>
                ' Use the FileStream to open an existing image file.
                Dim imageStream As FileStream = _
                    New FileStream(openImage.FileName, FileMode.Open)

                ' Set the file stream as the source of binary stream 
                ' to send to the data service. Allow the context to 
                ' close the filestream.
                context.SetSaveStream(currentEmployee, _
                    imageStream, True, "image/bmp", _
                    String.Empty)

                ' Upload the binary stream to the data service.
                context.SaveChanges()
                '</snippetSetSaveStreamClient>

                imageStream = _
                    New FileStream(openImage.FileName, FileMode.Open)

                employeeImage.Source = CreateBitmapFromStream(imageStream)
            End If
        Catch ex As DataServiceRequestException
            For Each response As OperationResponse In ex.Response
                If response.StatusCode = 400 Then
                    MessageBox.Show( _
                    "The file was too large to be accepted by the service.")
                Else
                    MessageBox.Show(ex.Message)
                End If
            Next
        End Try
    End Sub
    Private Function CreateBitmapFromStream(ByVal stream As Stream) As BitmapImage
        Try
            ' Create a new bitmap image using the memory stream.
            Dim imageFromStream As BitmapImage = New BitmapImage()
            With imageFromStream
                .BeginInit()
                .StreamSource = stream
                .CacheOption = BitmapCacheOption.OnLoad
                .EndInit()
            End With

            ' Return the bitmap.
            Return imageFromStream
        Catch
            MessageBox.Show("The file cannot be read; " _
            + "make sure that it is a valid .bmp file.")
            Return Nothing
        End Try
    End Function
    Private Sub closeWindow_Click(ByVal sender As Object, ByVal e As RoutedEventArgs)
        Close()
    End Sub
End Class
