Imports System.Windows.Shapes
Imports System
Imports System.Windows
Imports System.Windows.Controls
Imports System.Windows.Controls.Primitives
Imports System.Windows.Documents
Imports System.Windows.Navigation
Imports System.Windows.Media.Imaging
Imports System.Windows.Media
Imports System.Windows.Data
Imports System.Collections.ObjectModel
Imports System.Collections.Generic


Namespace SDKSample

    '@ <summary>
    '@ Interaction logic for Window1_xaml.xaml
    '@ </summary>
    Partial Class Window1

        Private Sub WindowLoaded(ByVal Sender As Object, ByVal e As RoutedEventArgs)
            'Create Bullet Panel and add to aStackPanel4You
            '<Snippet1>
            Dim myBulletDecorator = New BulletDecorator()
            Dim myImage = New Image()
            Dim myBitmapImage = New BitmapImage()
            myBitmapImage.BeginInit()
            myBitmapImage.UriSource = _
               New Uri("pack://application:,,/images/apple.jpg")
            myBitmapImage.EndInit()
            myImage.Source = myBitmapImage
            myImage.Width = 10
            myBulletDecorator.Bullet = myImage
            myBulletDecorator.Margin = New Thickness(0, 10, 0, 0)
            myBulletDecorator.VerticalAlignment = VerticalAlignment.Center
            myBulletDecorator.Background = Brushes.Yellow
            Dim myTextBlock = New TextBlock()
            myTextBlock.Text = "This BulletDecorator created by using code"
            myTextBlock.TextWrapping = TextWrapping.Wrap
            myTextBlock.HorizontalAlignment = HorizontalAlignment.Left
            myTextBlock.Width = 100
            myTextBlock.Foreground = Brushes.Purple
            myBulletDecorator.Child = myTextBlock
            '</Snippet1>
            aStackPanel4You.Children.Add(myBulletDecorator)

        End Sub
        Private Sub ChangeFontSize(ByVal Sender As Object, _
                                   ByVal e As RoutedEventArgs)

            If (FontSize12.IsChecked) Then
                FontSizeExample.FontSize = 12
                FontSizeExample.Text = "FontSize 12"
            ElseIf (FontSize24.IsChecked) Then
                FontSizeExample.FontSize = 24
                FontSizeExample.Text = "FontSize 24"
            ElseIf (FontSize48.IsChecked) Then
                FontSizeExample.FontSize = 48
                FontSizeExample.Text = "FontSize 48"
            End If
        End Sub
    End Class

End Namespace
