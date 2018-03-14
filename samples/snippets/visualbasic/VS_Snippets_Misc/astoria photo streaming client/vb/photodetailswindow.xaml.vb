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
Imports System.Windows.Shapes

Imports PhotoStreamingClient.PhotoData
Imports System.Data.Services.Client
Imports System.IO

''' <summary>
''' Interaction logic for PhotoDetailsWindow.xaml
''' </summary>
Partial Public Class PhotoDetailsWindow
    Inherits Window

    Dim photoEntity As PhotoInfo
    Dim context As DataServiceContext
    Dim imageStream As FileStream
    Dim cachedMergeOption As MergeOption

    Public Sub New(ByVal photo As PhotoInfo, ByVal context As DataServiceContext)
        InitializeComponent()

        Me.photoEntity = photo
        Me.context = context
    End Sub

    Private Sub Window_Loaded(ByVal sender As Object, ByVal e As RoutedEventArgs)
        ' Display the OpenImage dialog if we are adding a new photo.
        If photoEntity.PhotoId = 0 Then
            If Not SelectPhotoToSend() Then
                ' Close the add photo window if a photo cannot be selected.
                Me.Close()
            End If
        End If

        ' Set the binding source of the root WPF object to the new entity.
        LayoutRoot.DataContext = photoEntity
    End Sub
    Private Sub setPhoto_Click(ByVal sender As Object, ByVal e As RoutedEventArgs)
        ' Select a photo from the local computer.
        SelectPhotoToSend()
    End Sub
    Private Function SelectPhotoToSend() As Boolean
        ' Create a dialog to select the image file to stream to the data service.
        Dim openImage = New Microsoft.Win32.OpenFileDialog()
        openImage.FileName = "image"
        openImage.DefaultExt = ".*"
        openImage.Filter = "Images File|*.jpg*.png*.gif*.bmp"
        openImage.Title = "Select the image file to upload..."
        openImage.Multiselect = False
        openImage.CheckFileExists = True

        ' Reset the image stream.
        imageStream = Nothing

        Try
            If openImage.ShowDialog(Me) = True Then
                If photoEntity.PhotoId = 0 Then
                    ' Set the image name from the selected file.
                    photoEntity.FileName = openImage.SafeFileName

                    photoEntity.DateAdded = DateTime.Today

                    ' Set the content type and the file name for the slug header.
                    photoEntity.ContentType = _
                        GetContentTypeFromFileName(photoEntity.FileName)
                End If

                photoEntity.DateModified = DateTime.Today

                ' Use a FileStream to open the existing image file.
                imageStream = New FileStream(openImage.FileName, FileMode.Open)

                photoEntity.FileSize = CType(imageStream.Length, Integer)

                ' Create a new image Imports the memory stream.
                Dim imageFromStream = New BitmapImage()
                imageFromStream.BeginInit()
                imageFromStream.StreamSource = imageStream
                imageFromStream.CacheOption = BitmapCacheOption.OnLoad
                imageFromStream.EndInit()

                ' Set the height and width of the image.
                photoEntity.Dimensions.Height = CType(imageFromStream.PixelHeight, Nullable(Of Short))
                photoEntity.Dimensions.Width = CType(imageFromStream.PixelWidth, Nullable(Of Short))

                ' Reset to the beginning of the stream before we pass it to the service.
                imageStream.Position = 0

                '<snippetSetSaveStream>
                ' Set the file stream as the source of binary stream 
                ' to send to the data service. The Slug header is the file name and
                ' the content type is determined from the file extension. 
                ' A value of 'true' means that the stream is closed by the client when 
                ' the upload is complete.
                context.SetSaveStream(photoEntity, imageStream, True, _
                    photoEntity.ContentType, photoEntity.FileName)
                '</snippetSetSaveStream>

                Return True
            Else
                MessageBox.Show("The selected file could not be opened.")
                Return False
            End If
        Catch ex As IOException
            MessageBox.Show( _
                String.Format("The selected image file could not be opened. {0}", _
                ex.Message), "Operation Failed")

            Return False
        End Try
    End Function
    Private Sub savePhotoDetails_Click(ByVal sender As Object, ByVal ByVale As RoutedEventArgs)
        Dim entity As EntityDescriptor = Nothing
        Try
            If photoEntity.FileName = String.Empty OrElse _
                photoEntity.FileName = Nothing Then
                MessageBox.Show("You must first select an image file to upload.")
                Return
            End If

            ' Send the update (POST or MERGE) request to the data service and
            ' capture the added or updated entity in the response.
            Dim response As ChangeOperationResponse = _
                CType(context.SaveChanges().FirstOrDefault(), ChangeOperationResponse)

            ' When we issue a POST request, the photo ID and edit-media link are not updated 
            ' on the client (a bug), so we need to get the server values.
            If photoEntity.PhotoId = 0 Then
                If Not response Is Nothing Then
                    entity = CType(response.Descriptor, EntityDescriptor)
                End If

                ' Verify that the entity was created correctly.
                If Not entity Is Nothing AndAlso Not entity.EditLink Is Nothing Then
                    ' Cache the current merge option (we reset to the cached 
                    ' value in the finally block).
                    cachedMergeOption = context.MergeOption

                    ' Set the merge option so that server changes win.
                    context.MergeOption = MergeOption.OverwriteChanges

                    ' Get the updated entity from the service.
                    ' Note: we need Count() just to execute the query.
                    context.Execute(Of PhotoInfo)(entity.EditLink).Count()
                End If
            End If

            Me.DialogResult = True
            Me.Close()
        Catch ex As DataServiceRequestException
            ' Get the change operation result.
            Dim response As ChangeOperationResponse = _
                CType(ex.Response.FirstOrDefault(), ChangeOperationResponse)

            Dim errorMessage = String.Empty

            ' Check for a resource not found error.
            If Not response Is Nothing AndAlso response.StatusCode = 404 Then
                ' Tell the user to refresh the photos from the data service.
                errorMessage = "The selected image may have been removed from the data service.\n" _
                & "Click the Refresh Photos button to refresh photos from the service."
            Else
                ' Just provide the general error message.
                errorMessage = String.Format("The photo data could not be updated or saved. {0}", _
                    ex.Message)
            End If

            ' Show the messsage box.
            MessageBox.Show(errorMessage, "Operation Failed")

            ' Return false since we could not add or update the photo.
            Me.DialogResult = False
            Return
        Finally
            ' Reset to the cached merge option.
            context.MergeOption = cachedMergeOption
        End Try
    End Sub
    Private Shared Function GetContentTypeFromFileName(ByVal fileName As String) As String
        ' Get the file extension from the FileName property.
        Dim splitFileName As String() = fileName.Split(New Char() {"."})

        ' Return the Content-Type value based on the file extension.
        Select Case splitFileName(splitFileName.Length - 1)

            Case "jpeg"
                Return "image/jpeg"
            Case "jpg"
                Return "image/jpeg"
            Case "gif"
                Return "image/gif"
            Case "png"
                Return "image/png"
            Case "tiff"
                Return "image/tiff"
            Case "bmp"
                Return "image/bmp"
            Case Else
                Return "application/octet-stream"
        End Select
    End Function
    Private Sub cancelDetails_Click(ByVal sender As Object, ByVal e As RoutedEventArgs)
        If MessageBox.Show("If you cancel without saving you will lose any changes.", "Close this dialog?", _
             MessageBoxButton.OKCancel) = MessageBoxResult.OK Then
            Me.DialogResult = False
            Me.Close()
        End If
    End Sub
End Class