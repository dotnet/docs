 '****************************************************************************************
' * File: Window1.xaml.cs
' *
' * Description: 
' *    This sample opens a 'canned' text file (Text.txt) in Notepad and shows how to use 
' *    UI Automation to find/select text and track text selection changes in the Notepad instance.
' * 
' *    Text.txt should be automatically copied to the same folder as the executable when 
' *    you build the sample. You may have to manually copy this file if you receive an error 
' *    stating the file cannot be found.
' *         
' *
' * This file is part of the Microsoft .NET Framework SDK Code Samples.
' * 
' * Copyright (C) Microsoft Corporation.  All rights reserved.
' * 
' * This source code is intended only as a supplement to Microsoft
' * Development Tools and/or on-line documentation.  See these other
' * materials for detailed information regarding Microsoft code samples.
' *
' * THIS CODE AND INFORMATION ARE PROVIDED AS IS WITHOUT WARRANTY OF ANY
' * KIND, EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE
' * IMPLIED WARRANTIES OF MERCHANTABILITY AND/OR FITNESS FOR A
' * PARTICULAR PURPOSE.
' *
' *****************************************************************************************

Imports System
Imports System.Windows
Imports System.Windows.Controls
Imports System.Windows.Data
Imports System.Windows.Documents
Imports System.Windows.Media
Imports System.Windows.Media.Imaging
Imports System.Windows.Shapes
Imports System.Windows.Forms
Imports System.IO
Imports System.Windows.Markup


Namespace SDKSample

    Partial Class Window1
        Inherits Window

        Public Sub New()
            InitializeComponent()

        End Sub 'New


        Private Sub LoadFile(ByVal sender As [Object], ByVal args As RoutedEventArgs)
            Dim content As FlowDocument = Nothing

            Dim openFile As New OpenFileDialog()
            openFile.Filter = "FlowDocument Files (*.xaml)|*.xaml|All Files (*.*)|*.*"
            openFile.InitialDirectory = "Content"

            If openFile.ShowDialog() = System.Windows.Forms.DialogResult.OK Then
                Dim xamlFile As FileStream = DirectCast(openFile.OpenFile(), FileStream)
                If xamlFile Is Nothing Then
                    Return
                Else
                    Try
                        content = DirectCast(XamlReader.Load(xamlFile), FlowDocument)
                        If content Is Nothing Then
                            Throw New XamlParseException("The specified file could not be loaded as a FlowDocument.")
                        End If
                    Catch e As XamlParseException
                        Dim [error] As String = "There was a problem parsing the specified file:" + vbLf + vbLf
                        [error] += openFile.FileName
                        [error] += vbLf + vbLf + "Exception details:" + vbLf + vbLf
                        [error] += e.Message
                        System.Windows.MessageBox.Show([error])
                        Return
                    Catch e As Exception
                        Dim [error] As String = "There was a problem loading the specified file:" + vbLf + vbLf
                        [error] += openFile.FileName
                        [error] += vbLf + vbLf + "Exception details:" + vbLf + vbLf
                        [error] += e.Message
                        System.Windows.MessageBox.Show([error])
                        Return
                    End Try

                    ' At this point, there is a non-null FlowDocument loaded into content.  
                    FlowDocRdr.Document = content
                End If
            End If

        End Sub 'LoadFile


        Private Sub SaveFile(ByVal sender As [Object], ByVal args As RoutedEventArgs)
            Dim saveFile As New SaveFileDialog()
            Dim xamlFile As FileStream = Nothing
            saveFile.Filter = "FlowDocument Files (*.xaml)|*.xaml|All Files (*.*)|*.*"
            If saveFile.ShowDialog() = System.Windows.Forms.DialogResult.OK Then
                Try
                    xamlFile = DirectCast(saveFile.OpenFile(), FileStream)
                Catch e As Exception
                    Dim [error] As String = "There was a opening the file:" + vbLf + vbLf
                    [error] += saveFile.FileName
                    [error] += vbLf + vbLf + "Exception details:" + vbLf + vbLf
                    [error] += e.Message
                    System.Windows.MessageBox.Show([error])
                    Return
                End Try
                If xamlFile Is Nothing Then
                    Return
                Else
                    XamlWriter.Save(FlowDocRdr.Document, xamlFile)
                    xamlFile.Close()
                End If
            End If

        End Sub 'SaveFile


        Private Sub Clear(ByVal sender As [Object], ByVal args As RoutedEventArgs)
            FlowDocRdr.Document = Nothing

        End Sub 'Clear

        Private Sub [Exit](ByVal sender As [Object], ByVal args As RoutedEventArgs)
            Me.Close()

        End Sub 'Exit
    End Class 'Window1 '
End Namespace
