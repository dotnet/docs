﻿Imports System.Text
Imports System.Windows
Imports System.Windows.Controls
Imports System.Windows.Documents
Imports System.Windows.Navigation

Namespace SDKSample
	Partial Public Class PropertiesOvw
		Inherits StackPanel
	  Private Sub NavTo1(ByVal sender As Object, ByVal args As RoutedEventArgs)
		Dim currentApp As Application = Application.Current
		Dim nw As NavigationWindow = TryCast(currentApp.Windows(0), NavigationWindow)
		nw.Source = New Uri("page1.xaml", UriKind.RelativeOrAbsolute)
	  End Sub
	  Private Sub NavTo2(ByVal sender As Object, ByVal args As RoutedEventArgs)
		Dim currentApp As Application = Application.Current
		Dim nw As NavigationWindow = TryCast(currentApp.Windows(0), NavigationWindow)
		nw.Source = New Uri("page2.xaml",UriKind.RelativeOrAbsolute)
	  End Sub
	  Private Sub NavTo3(ByVal sender As Object, ByVal args As RoutedEventArgs)
		Dim currentApp As Application = Application.Current
		Dim nw As NavigationWindow = TryCast(currentApp.Windows(0), NavigationWindow)
		nw.Source = New Uri("page3.xaml", UriKind.RelativeOrAbsolute)
	  End Sub
	  Private Sub NavTo4(ByVal sender As Object, ByVal args As RoutedEventArgs)
		Dim currentApp As Application = Application.Current
		Dim nw As NavigationWindow = TryCast(currentApp.Windows(0), NavigationWindow)
		nw.Source = New Uri("page4.xaml", UriKind.RelativeOrAbsolute)
	  End Sub
	  Private Sub NavTo5(ByVal sender As Object, ByVal args As RoutedEventArgs)
		Dim currentApp As Application = Application.Current
		Dim nw As NavigationWindow = TryCast(currentApp.Windows(0), NavigationWindow)
		nw.Source = New Uri("page5.xaml", UriKind.RelativeOrAbsolute)
	  End Sub
	End Class
End Namespace