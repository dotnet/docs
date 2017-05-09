Imports System
Imports System.Collections.Generic
Imports System.Linq
Imports System.Text
Imports System.IO
Imports System.Data.Services
Imports System.Data.Services.Providers
Imports System.Data.Objects
Imports System.Web.Hosting
Imports System.Drawing

Class PhotoServiceStreamProvider
    Implements IDataServiceStreamProvider, IDisposable

    Private imageFilePath As String
    Private cachedEntity As PhotoInfo
    Private context As PhotoDataContainer
    Private Const thumbnailContentType As String = "image/jpeg"

    Private tempFile As String

    Public Sub New(ByVal context As PhotoDataContainer)
        Me.context = context

        ' Get the physical path to the app_data directory used to store the image files.
        imageFilePath = HostingEnvironment.MapPath("~/App_Data/")

        ' Create a temp file to store the new images during POST operations.
        tempFile = Path.GetTempFileName()
    End Sub

#Region "IDataServiceStreamProvider Members"
    Public Sub DeleteStream(ByVal entity As Object, ByVal operationContext As DataServiceOperationContext) _
        Implements IDataServiceStreamProvider.DeleteStream
        Dim image As PhotoInfo = CType(entity, PhotoInfo)
        If image Is Nothing Then
            Throw New DataServiceException(500, "Internal Server Error.")
        End If

        Try

            ' Delete the requested file by Imports the key value.
            File.Delete(imageFilePath & "image" & image.PhotoId.ToString())
        Catch ex As IOException
            Throw New DataServiceException("The image could not be found.", ex)
        End Try
    End Sub
    Public Function GetReadStream(ByVal entity As Object, ByVal etag As String, _
                                  ByVal checkETagForEquality As Nullable(Of Boolean), _
                                  ByVal operationContext As DataServiceOperationContext) As Stream _
        Implements IDataServiceStreamProvider.GetReadStream

        If Not checkETagForEquality Is Nothing Then

            ' This stream provider implementation does not support 
            ' ETag headers for media resources. This means that we do not track 
            ' concurrency for a media resource and last-in wins on updates.
            Throw New DataServiceException(400,
                "Me sample service does not support the ETag header for a media resource.")
        End If

        Dim image As PhotoInfo = CType(entity, PhotoInfo)

        If image Is Nothing Then
            Throw New DataServiceException(500, "Internal Server Error.")
        End If

        ' Build the full path to the stored image file, which includes the entity key.
        Dim fullImageFilePath As String = imageFilePath & "image" & image.PhotoId

        If Not File.Exists(fullImageFilePath) Then
            Throw New DataServiceException(500, "The image could not be found.")
        End If
        ' Return a stream that contains the requested file.
        Return New FileStream(fullImageFilePath, FileMode.Open)
    End Function
    Public Function GetReadStreamUri(ByVal entity As Object, ByVal operationContext As DataServiceOperationContext) As Uri _
        Implements IDataServiceStreamProvider.GetReadStreamUri
        ' Allow the runtime set the URI of the Media Resource.
        Return Nothing
    End Function
    Public Function GetStreamContentType(ByVal entity As Object, ByVal operationContext As DataServiceOperationContext) As String _
        Implements IDataServiceStreamProvider.GetStreamContentType
        ' Get the PhotoInfo entity instance.
        Dim image As PhotoInfo = CType(entity, PhotoInfo)
        If image Is Nothing Then
            Throw New DataServiceException(500, "Internal Server Error.")
        End If
        Return image.ContentType
    End Function
    Public Function GetStreamETag(ByVal entity As Object, ByVal operationContext As DataServiceOperationContext) As String _
        Implements IDataServiceStreamProvider.GetStreamETag
        ' Me sample provider does not support the eTag header with media resources.
        ' Me means that we do not track concurrency for a media resource 
        ' and last-in wins on updates.
        Return Nothing
    End Function
    Public Function GetWriteStream(ByVal entity As Object, ByVal etag As String, _
        ByVal checkETagForEquality As Nullable(Of Boolean), ByVal operationContext As DataServiceOperationContext) As Stream _
        Implements IDataServiceStreamProvider.GetWriteStream
        If Not checkETagForEquality Is Nothing Then
            ' Me stream provider implementation does not support ETags associated with BLOBs.
            ' Me means that we do not track concurrency for a media resource 
            ' and last-in wins on updates.
            Throw New DataServiceException(400, _
                "Me demo does not support ETags associated with BLOBs")
        End If

        Dim image As PhotoInfo = CType(entity, PhotoInfo)

        If image Is Nothing Then
            Throw New DataServiceException(500, "Internal Server Error: " _
                                           & "the Media Link Entry could not be determined.")
        End If

        ' Handle the POST request.
        If operationContext.RequestMethod = "POST" Then
            ' Set the file name from the Slug header if we don't have a 
            ' Slug header, just set a temporary name which is overwritten 
            ' by the subsequent MERGE request from the client. 
            image.FileName = If(Nothing, "newFile", operationContext.RequestHeaders("Slug"))

            ' Set the required DateTime values.
            image.DateModified = DateTime.Today
            image.DateAdded = DateTime.Today

            ' Set the content type, which cannot be null.
            image.ContentType = operationContext.RequestHeaders("Content-Type")

            ' Cache the current entity to enable us to both create a key based storage file name 
            ' and to maintain transactional integrity in the disposer we do Me only for a POST request.
            cachedEntity = image

            Return New FileStream(tempFile, FileMode.Open)
            ' Handle the PUT request
        Else
            ' Return a stream to write to an existing file.
            Return New FileStream(imageFilePath & "image" & image.PhotoId.ToString(), _
            FileMode.Open, FileAccess.Write)
        End If
    End Function
    Public Function ResolveType(ByVal entitySetName As String, ByVal operationContext As DataServiceOperationContext) As String _
        Implements IDataServiceStreamProvider.ResolveType
        ' We should only be handling PhotoInfo types.
        If entitySetName = "PhotoInfo" Then
            Return "PhotoService.PhotoInfo"
        Else
            ' This will raise an DataServiceException.
            Return Nothing
        End If
    End Function
    Public ReadOnly Property StreamBufferSize As Integer _
        Implements IDataServiceStreamProvider.StreamBufferSize
        ' Use a buffer size of 64K bytes.
        Get
            Return 64000
        End Get
    End Property
#End Region

   
#Region "IDisposable Members"

    Public Sub Dispose() Implements IDisposable.Dispose
        ' If we have a cached entity, it must be a POST request.
        If Not cachedEntity Is Nothing Then
            Dim newImageFileName As String = imageFilePath & "image" & cachedEntity.PhotoId.ToString()
            Dim newImageThumbnailName As String = _
            imageFilePath & "image" & cachedEntity.PhotoId.ToString() & "_thumb"

            ' Get the new entity from the Entity Framework object state manager.
            Dim entry As ObjectStateEntry = Me.context.ObjectStateManager.GetObjectStateEntry(cachedEntity)

            If entry.State = System.Data.EntityState.Unchanged Then
                ' Since the entity was created successfully, move the temp file into the 
                ' storage directory and rename the file based on the new entity key.
                File.Move(tempFile, newImageFileName)

                ' Delete the temp file.
                File.Delete(tempFile)

                ' Create a bitmap for the new image.
                Dim newImage As Bitmap = New Bitmap(newImageFileName)

                ' Generate the 100px thumbnail of the image.
                Dim thumbnail As Image = newImage.GetThumbnailImage(100, 100, Nothing, IntPtr.Zero)

                ' Save the thumbnail.
                thumbnail.Save(newImageThumbnailName)
            Else
                ' A problem must have occurred when saving the entity to the database, 
                ' so we should delete the entity and temp file.
                context.DeleteObject(cachedEntity)
                File.Delete(tempFile)
                Throw New DataServiceException("An error occurred. The photo could not be saved.")
            End If
        End If
    End Sub
#End Region
End Class
