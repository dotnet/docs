Imports System.Windows.Controls.Primitives
Imports System.Windows.Markup
Imports System.IO
Imports System.Windows
Imports System.Windows.Media
Imports System.Windows.Shapes

Namespace SDKSamples
    Friend Class InitializeElements
        Inherits Application
        '<SnippetMain>
        <STAThread>
        Shared Sub Main(ByVal args() As String)
            Dim e As UIElement
            Dim _file As String = Directory.GetCurrentDirectory() & "\starting.xaml"
            Using stream As Stream = File.Open(_file, FileMode.Open)
                ' loading files from current directory, project settings take care of copying the file
                Dim pc As New ParserContext()
                pc.BaseUri = New Uri(_file, UriKind.Absolute)
                e = CType(XamlReader.Load(stream, pc), UIElement)
            End Using

            Dim paperSize As New Size(8.5 * 96, 11 * 96)
            e.Measure(paperSize)
            e.Arrange(New Rect(paperSize))
            e.UpdateLayout()

            '            
            '             *   Render effect at normal dpi, indicator is the original RED rectangle
            '             
            Dim image1 As RenderTargetBitmap = Rasterize(e, paperSize.Width, paperSize.Height, 96, 96)
            Save(image1, "render1.png")

            Dim b As New Button()
            b.BeginInit()
            b.Background = Brushes.Blue
            b.Height = 200
            b.Width = b.Height
            b.EndInit()
            b.Measure(paperSize)
            b.Arrange(New Rect(paperSize))
            b.UpdateLayout()

            ' now render the altered version, with the element built up and initialized

            Dim image2 As RenderTargetBitmap = Rasterize(b, paperSize.Width, paperSize.Height, 96, 96)
            Save(image2, "render2.png")
        End Sub
        '</SnippetMain>

        Private Shared Function Rasterize(ByVal visual As Visual, ByVal width As Double, ByVal height As Double, ByVal dpiX As Double, ByVal dpiY As Double) As RenderTargetBitmap
            Dim pixelWidth As Integer = CInt(Fix(width * dpiX / 96))
            Dim pixelHeight As Integer = CInt(Fix(height * dpiY / 96))

            Dim bi As New RenderTargetBitmap(pixelWidth, pixelHeight, dpiX, dpiY, PixelFormats.Pbgra32)


            Dim rect As New Rectangle()
            rect.Width = width
            rect.Height = height
            rect.Fill = Brushes.White
            rect.Measure(New Size(width, height))
            rect.Arrange(New Rect(0, 0, width, height))
            bi.Render(rect)
            bi.Render(visual)

            Return bi
        End Function

        Private Shared Sub Save(ByVal id As BitmapSource, ByVal filename As String)
            Dim encoder As BitmapEncoder = New PngBitmapEncoder()

            encoder.Frames.Add(BitmapFrame.Create(id))

            Dim imageStreamDest As Stream = New System.IO.FileStream(filename, FileMode.Create, FileAccess.ReadWrite, FileShare.None)

            encoder.Save(imageStreamDest)

            imageStreamDest.Close()

            Console.WriteLine("Saved {0}", filename)
        End Sub
    End Class
End Namespace


