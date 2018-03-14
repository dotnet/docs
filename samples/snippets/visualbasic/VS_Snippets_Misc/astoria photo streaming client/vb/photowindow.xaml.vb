'*********************************************************
'
'    Copyright (c) Microsoft. All rights reserved.
'    This code is licensed under the Microsoft Public License.
'    THIS CODE IS PROVIDED *AS IS* WITHOUT WARRANTY OF
'    ANY KIND, EITHER EXPRESS OR IMPLIED, INCLUDING ANY
'    IMPLIED WARRANTIES OF FITNESS FOR A PARTICULAR
'    PURPOSE, MERCHANTABILITY, OR NON-INFRINGEMENT.
'
'*********************************************************
Imports System
Imports System.Collections.Generic
Imports System.Linq
Imports System.Text
Imports System.Windows
Imports System.Windows.Controls
Imports System.Windows.Data
Imports System.Windows.Documents
Imports System.Windows.Input
Imports System.Windows.Media
Imports System.Windows.Media.Imaging
Imports System.Windows.Navigation
Imports System.Windows.Shapes

Imports PhotoStreamingClient.PhotoData
Imports System.Data.Services.Client
Imports System.IO
Imports System.Xml.Linq

''' <summary>
''' Interaction logic for PhotoWindow.xaml
''' </summary>
Partial Public Class PhotoWindow
    Inherits Window

    Dim context As PhotoDataContainer
    Dim trackedPhotos As DataServiceCollection(Of PhotoInfo)
    Dim currentPhoto As PhotoInfo

    ' Get the service URI from the settings file.
    Dim svcUri As Uri = _
        New Uri(My.Settings.svcUri)
    Public Sub New()
        InitializeComponent()
    End Sub
    Private Sub Window_Loaded(ByVal sender As Object, ByVal a As RoutedEventArgs)
        ' Instantiate the data service context.
        context = New PhotoDataContainer(svcUri)

        ' Call the method to get photos from the data service.
        GetPhotosFromService(MergeOption.AppendOnly)
    End Sub
    Private Sub GetPhotosFromService(ByVal mergeOption As MergeOption)
        ' Set the merge option.
        context.MergeOption = mergeOption

        Try
            ' Define a query that returns a feed with all PhotoInfo objects.
            Dim query = context.PhotoInfo

            ' Create a new collection for binding based on the executed query.
            trackedPhotos = New DataServiceCollection(Of PhotoInfo)(query)

            ' Load all pages of the response into the binding collection.
            While Not trackedPhotos.Continuation Is Nothing
                trackedPhotos.Load( _
                    context.Execute(Of PhotoInfo)(trackedPhotos.Continuation.NextLinkUri))
            End While

            ' Bind the root StackPanel element to the collection
            ' related object binding paths are defined in the XAML.
            LayoutRoot.DataContext = trackedPhotos

            If trackedPhotos.Count = 0 Then
                MessageBox.Show("Data could not be returned from the data service.")
            End If

            ' Select the first photo in the collection.
            photoComboBox.SelectedIndex = 0

            ' Enable the buttons.
            photoDetails.IsEnabled = True
            addPhoto.IsEnabled = True
            deletePhoto.IsEnabled = True
        Catch ex As DataServiceQueryException
            Dim errorMessage = String.Empty

            ' Get the response from the request.
            Dim response As QueryOperationResponse = ex.Response

            ' If we have a 404, the URI may be incorrect.
            If response.StatusCode = 404 Then
                errorMessage = String.Format("Make sure that the service URI '{0}' is correct.", _
                    svcUri.ToString())
            Else
                ' Get the error message from the response.
                errorMessage = response.Error.Message
            End If

            ' Display the message.
            MessageBox.Show(errorMessage,
                String.Format("Error Status Code: {0}", response.StatusCode))
        Catch ex As InvalidOperationException
            MessageBox.Show(ex.Message)
        Finally
            ' Reset the merge option to the default.
            context.MergeOption = mergeOption.AppendOnly
        End Try
    End Sub
    Private Sub photoComboBox_SelectionChanged(ByVal sender As Object, ByVal e As SelectionChangedEventArgs)
        getCurrentPhoto()
    End Sub
    Private Sub getCurrentPhoto()
        ' Get the currently selected photo.
        currentPhoto = CType(Me.photoComboBox.SelectedItem, PhotoInfo)

        ' Get the image for the selected PhotoData not an added one.
        If Not currentPhoto Is Nothing AndAlso currentPhoto.PhotoId <> 0 Then
            Try
                '<snippetGetReadStreamUri>
                ' Use the ReadStreamUri of the Media Resource for selected PhotoInfo object
                ' as the URI source of a new bitmap image.
                photoImage.Source = New BitmapImage(context.GetReadStreamUri(currentPhoto))
                '</snippetGetReadStreamUri>
            Catch ex As DataServiceClientException
                Dim err = XElement.Parse(ex.Message)

                ' Display the error messages.
                MessageBox.Show(err.Value,
                        String.Format("Error Status Code: {0}", ex.StatusCode))
            End Try
        End If
    End Sub
    Private Sub addPhoto_Click(ByVal sender As Object, ByVal e As RoutedEventArgs)
        ' Create a new PhotoInfo object.
        Dim newPhotoEntity As New PhotoInfo

        ' Ceate an new PhotoDetailsWindow instance with the current 
        ' context and the new photo entity.
        Dim addPhotoWindow As PhotoDetailsWindow = _
            New PhotoDetailsWindow(newPhotoEntity, context)

        addPhotoWindow.Title = "Select a new photo to upload..."

        ' We need to have the new entity tracked to be able to 
        ' call DataServiceContext.SetSaveStream.
        trackedPhotos.Add(newPhotoEntity)

        ' If we successfully created the new image, then display it.
        If addPhotoWindow.ShowDialog() = True Then
            ' Set the index to the new photo.
            photoComboBox.SelectedItem = newPhotoEntity
        Else
            ' Remove the new entity since the add operation failed.
            trackedPhotos.Remove(newPhotoEntity)
        End If
    End Sub
    Private Sub photoDetails_Click(ByVal sender As Object, ByVal e As RoutedEventArgs)
        ' Get the selected photo.
        currentPhoto = CType(photoComboBox.SelectedItem, PhotoInfo)

        ' Create an instance of the photo details window.
        Dim PhotoDetailsWindow As PhotoDetailsWindow = _
            New PhotoDetailsWindow(currentPhoto, context)

        PhotoDetailsWindow.Title = _
            String.Format("Details {0}:", currentPhoto.FileName)

        ' Display the dialog.
        If PhotoDetailsWindow.ShowDialog() = True Then
            ' Request the image file again in case it was changed.
            ' We might have also used a client-side copy of the image to avoid
            ' this GET request to the data service.
            getCurrentPhoto()
        End If
    End Sub
    Private Sub deletePhoto_Click(ByVal sender As Object, ByVal e As RoutedEventArgs)
        Try
            ' Get the currently selected photo.
            Dim currentPhoto As PhotoInfo = CType(photoComboBox.SelectedItem, PhotoInfo)

            If MessageBox.Show("Are you sure you want to delete this photo from the service?", _
                "Delete Photo", MessageBoxButton.OKCancel) = MessageBoxResult.OK Then

                Dim currentIndex = photoComboBox.SelectedIndex

                ' Delete the currently selected photo entity from the binding collection.
                trackedPhotos.Remove(currentPhoto)

                ' Send the DELETE request to the data service.
                context.SaveChanges()

                ' Move the index to the previous photo.
                IIf(currentIndex = 0, photoComboBox.SelectedIndex = 0, photoComboBox.SelectedIndex = currentIndex - 1)
            End If
        Catch ex As DataServiceRequestException
            ' The delete failed we should ask the user to refresh images from the data service.
            If MessageBox.Show("The image may have already been deleted.\n" & _
                "Refresh images from the data service?", "Error on Delete", _
                MessageBoxButton.YesNo) = MessageBoxResult.Yes Then

                ' Refresh images from the data service Imports overwrite changes.
                GetPhotosFromService(MergeOption.OverwriteChanges)
            Else
                ' Warn the user about possible other errors.
                MessageBox.Show("If other errors occur, click Refresh Photos.")
            End If
        End Try
    End Sub
    Private Sub refreshPhotosButton_Click(ByVal sender As Object, ByVal e As RoutedEventArgs)
        ' Refresh the list of photos from the data service.
        GetPhotosFromService(MergeOption.OverwriteChanges)
    End Sub
    Private Sub closeWindow_Click(ByVal sender As Object, ByVal e As RoutedEventArgs)
        Close()
    End Sub
End Class