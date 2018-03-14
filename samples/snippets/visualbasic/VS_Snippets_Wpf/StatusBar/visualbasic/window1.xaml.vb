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

Namespace StatusBarSimple
	''' <summary>
	''' Interaction logic for Window1.xaml
	''' </summary>

	Partial Public Class Window1
		Inherits Window

		'<SnippetMakeProgressBar>
		Private Sub MakeProgressBar(ByVal sender As Object, ByVal e As RoutedEventArgs)
			sbar.Items.Clear()
			Dim txtb As New TextBlock()
			txtb.Text = "Progress of download."
			sbar.Items.Add(txtb)
			Dim progressbar As New ProgressBar()
			progressbar.Width = 100
			progressbar.Height = 20
			Dim duration As New Duration(TimeSpan.FromSeconds(5))
			Dim doubleanimation As New DoubleAnimation(100.0, duration)
			progressbar.BeginAnimation(ProgressBar.ValueProperty, doubleanimation)
			Dim ttprogbar As New ToolTip()
			ttprogbar.Content = "Shows the progress of a download."
			progressbar.ToolTip = (ttprogbar)
			sbar.Items.Add(progressbar)
		End Sub
		'</SnippetMakeProgressBar>

		Private Sub MakeTextBlock(ByVal sender As Object, ByVal e As RoutedEventArgs)
			sbar.Items.Clear()
			Dim txtb As New TextBlock()
			txtb.Text = "Code compiled successfully."
			sbar.Items.Add(txtb)
			Dim rect As New Rectangle()
			rect.Height = 20
			rect.Width = 1
			rect.Fill = Brushes.LightGray
			sbar.Items.Add(rect)
		End Sub

		Private Sub MakeImage(ByVal sender As Object, ByVal e As RoutedEventArgs)
			sbar.Items.Clear()
			Dim dpanel As New DockPanel()
			Dim txtb As New TextBlock()
			txtb.Text = "Printing  "
			dpanel.Children.Add(txtb)
			Dim printImage As New Image()
			printImage.Width = 16
			printImage.Height = 16
			Dim bi As New BitmapImage()
			bi.BeginInit()
			bi.UriSource = New Uri("pack://application:,,,/images/print.bmp")
			bi.EndInit()
			printImage.Source = bi
			dpanel.Children.Add(printImage)
			Dim txtb2 As New TextBlock()
			txtb2.Text = "  5pgs"
			dpanel.Children.Add(txtb2)
			Dim sbi As New StatusBarItem()
			sbi.Content = dpanel
			sbi.HorizontalAlignment = HorizontalAlignment.Right
			Dim ttp As New ToolTip()
			ttp.Content = "Sent to printer."
			sbi.ToolTip = (ttp)
			sbar.Items.Add(sbi)
		End Sub

		Private Sub MakeHelp(ByVal sender As Object, ByVal e As RoutedEventArgs)
			sbar.Items.Clear()
			Dim helpImage As New Image()
			helpImage.Width = 16
			helpImage.Height = 16
			Dim bi As New BitmapImage()
			bi.BeginInit()
			bi.UriSource = New Uri("pack://application:,,,/images/help.bmp")
			bi.EndInit()
			helpImage.Source = bi
			Dim ttp As New ToolTip()
			ttp.Content = "HELP"
			helpImage.ToolTip = (ttp)
			sbar.Items.Add(helpImage)
		End Sub

		Private Sub MakeGroup(ByVal sender As Object, ByVal e As RoutedEventArgs)
			sbar.Items.Clear()
			'<SnippetItemsWithSeparator>
			Dim helpImage As New Image()
			helpImage.Width = 16
			helpImage.Height = 16
			Dim bi As New BitmapImage()
			bi.BeginInit()
			bi.UriSource = New Uri("pack://application:,,,/images/help.bmp")
			bi.EndInit()
			helpImage.Source = bi
			Dim ttp As New ToolTip()
			ttp.Content = "HELP"
			helpImage.ToolTip = (ttp)
			sbar.Items.Add(helpImage)

			Dim sp As New Separator()
			sp.Style = CType(FindResource("StatusBarSeparatorStyle"), Style)
			sbar.Items.Add(sp)

			Dim printImage As New Image()
			printImage.Width = 16
			printImage.Height = 16
			Dim bi_print As New BitmapImage()
			bi_print.BeginInit()
			bi_print.UriSource = New Uri("pack://application:,,,/images/print.bmp")
			bi_print.EndInit()
			printImage.Source = bi_print
			Dim ttp_print As New ToolTip()
			ttp.Content = "Sent to printer."
			printImage.ToolTip = (ttp_print)
			sbar.Items.Add(printImage)
			'</SnippetItemsWithSeparator>

		End Sub
	End Class
End Namespace