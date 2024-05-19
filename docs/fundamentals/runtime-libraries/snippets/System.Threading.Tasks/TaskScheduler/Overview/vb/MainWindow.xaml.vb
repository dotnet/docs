Option Infer On

' <Snippet01>

Partial Public Class MainWindow : Inherits Window
    Dim fileCount As Integer
    Dim colCount As Integer
    Dim rowCount As Integer
    Dim tilePixelHeight As Integer
    Dim tilePixelWidth As Integer
    Dim largeImagePixelHeight As Integer
    Dim largeImagePixelWidth As Integer
    Dim largeImageStride As Integer
    Dim format As PixelFormat
    Dim palette As BitmapPalette = Nothing

    Public Sub New()
        InitializeComponent()

        ' For this example, values are hard-coded to a mosaic of 8x8 tiles.
        ' Each tile Is 50 pixels high and 66 pixels wide and 32 bits per pixel.
        colCount = 12
        rowCount = 8
        tilePixelHeight = 50
        tilePixelWidth = 66
        largeImagePixelHeight = tilePixelHeight * rowCount
        largeImagePixelWidth = tilePixelWidth * colCount
        largeImageStride = largeImagePixelWidth * (32 / 8)
        Me.Width = largeImagePixelWidth + 40
        image.Width = largeImagePixelWidth
        image.Height = largeImagePixelHeight
    End Sub

    Private Sub button_Click(sender As Object, e As RoutedEventArgs) _
        Handles button.Click

        ' For best results use 1024 x 768 jpg files at 32bpp.
        Dim files() As String = System.IO.Directory.GetFiles("C:\Users\Public\Pictures\Sample Pictures\", "*.jpg")

        fileCount = files.Length
        Dim images(fileCount - 1) As Task(Of Byte())
        For i As Integer = 0 To fileCount - 1
            Dim x As Integer = i
            images(x) = Task.Factory.StartNew(Function() LoadImage(files(x)))
        Next

        ' When they have all been loaded, tile them into a single byte array.
        'var tiledImage = Task.Factory.ContinueWhenAll(
        '        images, (i) >= TileImages(i));

        '        Dim tiledImage As Task(Of Byte()) = Task.Factory.ContinueWhenAll(images, Function(i As Task(Of Byte())) TileImages(i))
        Dim tiledImage = Task.Factory.ContinueWhenAll(images, Function(i As Task(Of Byte())()) TileImages(i))
        ' We are currently on the UI thread. Save the sync context and pass it to
        ' the next task so that it can access the UI control "image1".
        Dim UISyncContext = TaskScheduler.FromCurrentSynchronizationContext()

        ' On the UI thread, put the bytes into a bitmap and
        ' display it in the Image control.
        Dim t3 = tiledImage.ContinueWith(Sub(antecedent)
                                             ' Get System DPI.
                                             Dim m As Matrix = PresentationSource.FromVisual(Application.Current.MainWindow).CompositionTarget.TransformToDevice
                                             Dim dpiX As Double = m.M11
                                             Dim dpiY As Double = m.M22

                                             ' Use the default palette in creating the bitmap.
                                             Dim bms As BitmapSource = BitmapSource.Create(largeImagePixelWidth,
                                                                                           largeImagePixelHeight,
                                             dpiX,
                                             dpiY,
                                             format,
                                             palette,
                                             antecedent.Result,
                                             largeImageStride)
                                             image.Source = bms
                                         End Sub, UISyncContext)
    End Sub

    Public Function LoadImage(filename As String) As Byte()
        ' Use the WPF BitmapImage class to load and 
        ' resize the bitmap. NOTE: Only 32bpp formats are supported correctly.
        ' Support for additional color formats Is left as an exercise
        ' for the reader. For more information, see documentation for ColorConvertedBitmap.
        Dim bitmapImage As New BitmapImage()
        bitmapImage.BeginInit()
        bitmapImage.UriSource = New Uri(filename)
        bitmapImage.DecodePixelHeight = tilePixelHeight
        bitmapImage.DecodePixelWidth = tilePixelWidth
        bitmapImage.EndInit()

        format = bitmapImage.Format
        Dim size As Integer = CInt(bitmapImage.Height * bitmapImage.Width)
        Dim stride As Integer = CInt(bitmapImage.Width * 4)
        Dim dest(stride * tilePixelHeight - 1) As Byte

        bitmapImage.CopyPixels(dest, stride, 0)

        Return dest
    End Function

    Function Stride(pixelWidth As Integer, bitsPerPixel As Integer) As Integer
        Return (((pixelWidth * bitsPerPixel + 31) / 32) * 4)
    End Function

    ' Map the individual image tiles to the large image
    ' in parallel. Any kind of raw image manipulation can be
    ' done here because we are Not attempting to access any 
    ' WPF controls from multiple threads.
    Function TileImages(sourceImages As Task(Of Byte())()) As Byte()
        Dim largeImage(largeImagePixelHeight * largeImageStride - 1) As Byte
        Dim tileImageStride As Integer = tilePixelWidth * 4 ' hard coded To 32bpp

        Dim rand As New Random()
        Parallel.For(0, rowCount * colCount, Sub(i)
                                                 ' Pick one of the images at random for this tile.
                                                 Dim cur As Integer = rand.Next(0, sourceImages.Length)
                                                 Dim pixels() As Byte = sourceImages(cur).Result

                                                 ' Get the starting index for this tile.
                                                 Dim row As Integer = i \ colCount
                                                 Dim col As Integer = i Mod colCount
                                                 Dim idx As Integer = ((row * (largeImageStride * tilePixelHeight)) + (col * tileImageStride))

                                                 ' Write the pixels for the current tile. The pixels are Not contiguous
                                                 ' in the array, therefore we have to advance the index by the image stride
                                                 ' (minus the stride of the tile) for each scanline of the tile.
                                                 Dim tileImageIndex As Integer = 0
                                                 For j As Integer = 0 To tilePixelHeight - 1
                                                     ' Write the next scanline for this tile.
                                                     For k As Integer = 0 To tileImageStride - 1
                                                         largeImage(idx) = pixels(tileImageIndex)
                                                         idx += 1
                                                         tileImageIndex += 1
                                                     Next
                                                     ' Advance to the beginning of the next scanline.
                                                     idx += largeImageStride - tileImageStride
                                                 Next
                                             End Sub)
        Return largeImage
    End Function
End Class
' </Snippet01>


