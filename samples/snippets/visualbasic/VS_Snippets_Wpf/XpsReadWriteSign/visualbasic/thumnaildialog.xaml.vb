Imports System
Imports System.Windows
Imports System.Windows.Controls
Imports System.Windows.Data
Imports System.Windows.Documents
Imports System.Windows.Media
Imports System.Windows.Media.Imaging
Imports System.Windows.Shapes
Imports System.Windows.Xps.Packaging
Imports System.IO
Imports System.IO.Packaging


Namespace SDKSample
	''' <summary>
	''' Interaction logic for ThumnailDialog.xaml
	''' </summary>

	Partial Public Class ThumnailDialog
		Inherits Window

		Public Sub New(ByVal xpsDocument As XpsDocument)
			InitializeComponent()
			_xpsDocument = xpsDocument
			If xpsDocument.Thumbnail IsNot Nothing Then
				thumbnailDisplay.Fill = New ImageBrush(BitmapFrame.Create(xpsDocument.Thumbnail.GetStream()))
				addThumbnailButton.IsEnabled = False
			End If
		End Sub

		Private Sub AddThumbnail(ByVal sender As Object, ByVal e As RoutedEventArgs)
			Dim docSeq As FixedDocumentSequence = _xpsDocument.GetFixedDocumentSequence()
			Dim paginator As DocumentPaginator = docSeq.DocumentPaginator
			Dim page As DocumentPage = paginator.GetPage(0)
			' Create a rendertarget for the glyphs element. Round up width and height
            Dim rt As New RenderTargetBitmap(CInt(page.Size.Width), CInt(page.Size.Height), 96, 96, PixelFormats.Default)


			Dim fixedPage As FixedPage = CType(page.Visual, FixedPage)
			fixedPage.Measure(New Size(page.Size.Width, page.Size.Height))
			fixedPage.Arrange(New Rect(New Size(page.Size.Width, page.Size.Height)))
			rt.Render(fixedPage)
			Dim jpegEncoder As New JpegBitmapEncoder()
			jpegEncoder.Frames.Add(BitmapFrame.Create(CType(rt, BitmapSource)))
			Dim stream As Stream = New MemoryStream()
			jpegEncoder.Save(stream)
			Dim thumbnail As XpsThumbnail = _xpsDocument.AddThumbnail(XpsImageType.JpegImageType)
			Dim dstStream As Stream = thumbnail.GetStream()
            Dim thumbnailData(CInt(stream.Length) - 1) As Byte
			' let's read the whole block into our buffer 
			Dim totalBytesRead As Integer = 0
            Dim requestedCount As Integer = CInt(stream.Length)
			stream.Position = 0
			Do While totalBytesRead < requestedCount
				Dim bytesRead As Integer = stream.Read(thumbnailData, totalBytesRead, requestedCount - totalBytesRead)
				If bytesRead = 0 Then
					Exit Do
				End If
				totalBytesRead += bytesRead
			Loop
            dstStream.Write(thumbnailData, 0, CInt(stream.Length))
			dstStream.Close()
			thumbnail.Commit()
			_xpsDocument.Close()
			stream.Position = 0
			Dim imageBrush As New ImageBrush(BitmapFrame.Create(stream))
			imageBrush.Stretch = Stretch.Uniform
			thumbnailDisplay.Fill = imageBrush

			' Once a thumbnail is set disable the "Add Thumbnail" button.
			addThumbnailButton.IsEnabled = False
		End Sub
		Private _xpsDocument As XpsDocument

	End Class
End Namespace