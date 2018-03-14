Imports System
Imports System.Windows
Imports System.Windows.Controls
Imports System.Windows.Controls.Primitives
Imports System.Windows.Data
Imports System.Windows.Documents
Imports System.Windows.Media
Imports System.Windows.Media.Animation
Imports System.Windows.Media.Imaging
Imports System.Windows.Shapes



Namespace ProgBar
	''' <summary>
	''' Interaction logic for Window1.xaml
	''' </summary>

	Partial Public Class Window1
		Inherits Window

		Private Sub MakeOne(ByVal sender As Object, ByVal e As RoutedEventArgs)
		   sbar.Items.Clear()
		   Dim lbl As New Label()
		   lbl.Background = New LinearGradientBrush(Colors.LightBlue, Colors.SlateBlue, 90)
		   lbl.Content = "ProgressBar with one iteration."
		   sbar.Items.Add(lbl)
		   '<Snippet1>
		   Dim progbar As New ProgressBar()
		   progbar.IsIndeterminate = False
		   progbar.Orientation = Orientation.Horizontal
		   progbar.Width = 150
		   progbar.Height = 15
		   Dim duration As New Duration(TimeSpan.FromSeconds(10))
		   Dim doubleanimation As New DoubleAnimation(100.0, duration)
		   progbar.BeginAnimation(ProgressBar.ValueProperty, doubleanimation)
		   '</Snippet1>
		   sbar.Items.Add(progbar)
		End Sub

		 Private Sub MakeThree(ByVal sender As Object, ByVal e As RoutedEventArgs)
		   sbar.Items.Clear()
		   Dim lbl As New Label()
		   lbl.Background = New LinearGradientBrush(Colors.Pink, Colors.Red, 90)
		   lbl.Content = "ProgressBar with three iterations."
		   sbar.Items.Add(lbl)
		   Dim progbar As New ProgressBar()
		   progbar.Background = Brushes.Gray
		   progbar.Foreground = Brushes.Red
		   progbar.Width = 150
		   progbar.Height = 15
		   Dim duration As New Duration(TimeSpan.FromMilliseconds(2000))
		   Dim doubleanimation As New DoubleAnimation(100.0, duration)
		   doubleanimation.RepeatBehavior = New RepeatBehavior(3)
		   progbar.BeginAnimation(ProgressBar.ValueProperty, doubleanimation)
		   sbar.Items.Add(progbar)
		 End Sub

		Private Sub MakeFive(ByVal sender As Object, ByVal e As RoutedEventArgs)
			sbar.Items.Clear()
			Dim txtb As New TextBlock()
			txtb.Text = "ProgressBar with five iterations."
			sbar.Items.Add(txtb)
			Dim image As New Image()
			Dim bi As New BitmapImage()
			bi.BeginInit()
			bi.UriSource = New Uri("pack://application:,,,/data/sunset.png")
			bi.EndInit()
			image.Source = bi
			Dim imagebrush As New ImageBrush(bi)

			Dim progbar As New ProgressBar()
			progbar.Background = imagebrush
			progbar.Width = 150
			progbar.Height = 15
			Dim duration As New Duration(TimeSpan.FromMilliseconds(2000))
			Dim doubleanimation As New DoubleAnimation(100.0, duration)
			doubleanimation.RepeatBehavior = New RepeatBehavior(5)
			progbar.BeginAnimation(ProgressBar.ValueProperty, doubleanimation)
			sbar.Items.Add(progbar)
		End Sub

		 Private Sub MakeForever(ByVal sender As Object, ByVal e As RoutedEventArgs)
		   sbar.Items.Clear()
		   Dim lbl As New Label()
		   lbl.Background = New LinearGradientBrush(Colors.LightBlue, Colors.SlateBlue, 90)
		   lbl.Content = "ProgressBar with infinite iterations."
		   sbar.Items.Add(lbl)
		   Dim progbar As New ProgressBar()
		   progbar.Width = 150
		   progbar.Height = 15
		   Dim duration As New Duration(TimeSpan.FromSeconds(1))
		   Dim doubleanimation As New DoubleAnimation(100.0, duration)
		   doubleanimation.RepeatBehavior = RepeatBehavior.Forever
		   progbar.BeginAnimation(ProgressBar.ValueProperty, doubleanimation)
		   sbar.Items.Add(progbar)

		 End Sub

		 Private Sub MakeIndeterminate(ByVal sender As Object, ByVal e As RoutedEventArgs)
			 sbar.Items.Clear()
			 Dim lbl As New Label()
			 lbl.Background = New LinearGradientBrush(Colors.Pink, Colors.Red, 90)
			 lbl.Content = "Indeterminate ProgressBar."
			 sbar.Items.Add(lbl)
			 '<Snippet3>
			 Dim progbar As New ProgressBar()
			 progbar.Background = Brushes.Gray
			 progbar.Foreground = Brushes.Red
			 progbar.Width = 150
			 progbar.Height = 15
			 progbar.IsIndeterminate = True
			 '</Snippet3>
			 sbar.Items.Add(progbar)
		 End Sub

	End Class
End Namespace