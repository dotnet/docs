' *****************************************************************************************
' * File: SearchWindow.cs
' *
' * Description: 
' *    This sample shows how User Interface (UI) Automation clients
' *    can use UI Automation to do the following:
' *        1. Find an AutomationElement
' *        2. Get Supported Control Patterns
' *        3. Register for an Event
' *        4. Get Property Values
' *
' *****************************************************************************************
' *****************************************************************************************
' * File: FindText.cs
' *
' * Description: 
' *    This sample opens a 'canned' text file (Text.txt) in Notepad and shows how to use 
' *    UI Automation to find/select text and track text selection changes in the Notepad instance.
' * 
' *    Text.txt should be automatically copied to the same folder as the executable when 
' *    you build the sample. You may have to manually copy this file if you receive an error 
' *    stating the file cannot be found.
' *
' * Programming Elements:
' *    This sample demonstrates the following UI Automation programming elements from...
' * 
' *       System.Windows.Automation Namespace:
' *         Automation Class
' *           AddAutomationEventHandler
' *           AddAutomationPropertyChangedEventHandler
' *         WindowPattern Class
' *           WindowClosedEvent field
' *         AutomationPattern Class 
' *         AutomationEventHandler Delegate
' *         AutomationElement Class
' *           RootElement property
' *           GetCurrentPropertyValue method
' *           BoundingRectangleProperty field
' *           GetCurrentPattern method
' *           FromHandle method
' *           ControlTypeProperty field
' *           FindFirst method
' *           SetFocus method
' *         TreeScope Enumeration
' *           Element member
' *           Descendants member
' *         ControlType Class
' *           Document field
' *         TextPattern Class
' *           Pattern field
' *           TextSelectionChangedEvent field
' *           SupportsTextSelection property
' *           DocumentRange property
' *         ValuePattern Class
' *           Pattern field
' *           ValueProperty field
' *         AutomationPropertyChangedEventHandler Delegate
' * 
' *       System.Windows.Automation.Searcher Namespace:
' *         PropertyCondition Class
' * 
' *       System.Windows.Automation.Text Namespace:
' *         TextPatternRange Class
' *           FindText method
' *           Select method
' *         TextPatternRangeEndpoint Enumeration
' *         
' *
' *  This file is part of the Microsoft .NET Framework SDK Code Samples.
' * 
' *  Copyright (C) Microsoft Corporation.  All rights reserved.
' * 
' *  This source code is intended only as a supplement to Microsoft
' *  Development Tools and/or on-line documentation.  See these other
' *  materials for detailed information regarding Microsoft code samples.
' *
' *  THIS CODE AND INFORMATION ARE PROVIDED AS IS WITHOUT WARRANTY OF ANY
' *  KIND, EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE
' *  IMPLIED WARRANTIES OF MERCHANTABILITY AND/OR FITNESS FOR A
' *  PARTICULAR PURPOSE.
' *
' ******************************************************************************************

Imports System
Imports System.Windows
Imports System.Windows.Documents
Imports System.Windows.Automation
Imports System.Windows.Controls
Imports System.Diagnostics
Imports System.ComponentModel
Imports System.Threading
Imports System.IO
Imports System.Windows.Automation.Text
Imports System.Windows.Threading

Namespace SDKSample

    Public Class SearchWindow
        Private _window As Window
        Private _dp As DockPanel
        Private _root As AutomationElement
        Private _btnApp As Button
        Private _txtAppResult As TextBlock
        Private _tbSearch As TextBox
        Private _btnSearch As Button
        Private _cbSearch As CheckBox
        Private _txtSearchResult As TextBlock
        Private _txtHighlighted As TextBlock
        Private _txtHighlightResult As TextBlock
        Private targetTextPattern As TextPattern
        Private _tprDoc As TextPatternRange
        Private _tprSearch As TextPatternRange
        Private _bBOD As Boolean
        Private _bBackward As Boolean
        Private _sApplication As String = "WordPad.exe"

        Public Event BtnAppClick(ByVal Status As String)

        ' Constructor
        Public Sub SearchWindow()
            ' Specs for Window
            Dim wHeight As Double = 400
            Dim wWidth As Double = 400

            ' Specs for TextBox
            Dim tbMaxlines As Integer = 1
            Dim tbMaxlength As Integer = 25

            ' Specs for Buttons
            Dim bWidth As Double = 100

            ' Instantiate our window and set location and size
            _window = New Window()
            _window.Height = wHeight
            _window.Width = wWidth
            _window.Left = SystemParameters.WorkArea.Left
            _window.Top = SystemParameters.WorkArea.Top
            _window.Title = "Find Text"
            _window.WindowStyle = WindowStyle.ToolWindow

            _btnApp = New Button()
            _btnApp.Width = bWidth
            _btnApp.Content = "Start " + _sApplication
            _btnApp.IsEnabled = True
            AddHandler _btnApp.Click, AddressOf btnApp_Click

            _txtAppResult = New TextBlock()
            _txtAppResult.Text = ""
            _txtAppResult.HorizontalAlignment = HorizontalAlignment.Center
            _txtAppResult.Margin = New Thickness(0, 10, 0, 20)

            Dim sp As StackPanel = New StackPanel()
            sp.Orientation = Orientation.Horizontal
            sp.HorizontalAlignment = HorizontalAlignment.Center

            Dim txt1 As TextBlock = New TextBlock()
            txt1.Text = "Search for: "
            txt1.VerticalAlignment = VerticalAlignment.Center

            _tbSearch = New TextBox()
            _tbSearch.MaxLines = tbMaxlines
            _tbSearch.MaxLength = tbMaxlength
            _tbSearch.IsEnabled = False
            _tbSearch.Margin = New Thickness(10, 0, 10, 0)
            AddHandler _tbSearch.TextChanged, AddressOf tbSearch_TextChanged

            _btnSearch = New Button()
            _btnSearch.Width = bWidth
            _btnSearch.Content = "Search"
            _btnSearch.IsEnabled = False
            AddHandler _btnSearch.Click, AddressOf btnSearch_Click

            _cbSearch = New CheckBox()
            _cbSearch.VerticalAlignment = VerticalAlignment.Center
            _cbSearch.IsEnabled = False
            _cbSearch.Margin = New Thickness(10, 0, 0, 0)

            'cbSearch.IsCheckedChanged += new RoutedPropertyChangedEventHandler<bool?>(cbSearch_IsCheckedChanged);
            AddHandler _cbSearch.Unchecked, AddressOf cbSearch_IsCheckedChanged
            AddHandler _cbSearch.Checked, AddressOf cbSearch_IsCheckedChanged


            Dim txt2 As TextBlock = New TextBlock()
            txt2.Text = "Reverse"
            txt2.VerticalAlignment = VerticalAlignment.Center

            sp.Children.Add(txt1)
            sp.Children.Add(_tbSearch)
            sp.Children.Add(_btnSearch)
            sp.Children.Add(_cbSearch)
            sp.Children.Add(txt2)

            _txtSearchResult = New TextBlock()
            _txtSearchResult.Text = ""
            _txtSearchResult.HorizontalAlignment = HorizontalAlignment.Center
            _txtSearchResult.Margin = New Thickness(0, 10, 0, 20)

            _txtHighlighted = New TextBlock()
            _txtHighlighted.Text = "Currently highlighted:"

            _txtHighlightResult = New TextBlock()
            _txtHighlightResult.Text = ""
            _txtHighlightResult.HorizontalAlignment = HorizontalAlignment.Left
            _txtHighlightResult.Margin = New Thickness(0, 10, 0, 20)

            ' Create a DockPanel to hold output
            _dp = New DockPanel()
            _dp.Width = wWidth
            _dp.Height = wHeight
            _dp.LastChildFill = False
            DockPanel.SetDock(_btnApp, Dock.Top)
            _dp.Children.Add(_btnApp)
            DockPanel.SetDock(_txtAppResult, Dock.Top)
            _dp.Children.Add(_txtAppResult)
            DockPanel.SetDock(sp, Dock.Top)
            _dp.Children.Add(sp)
            DockPanel.SetDock(_txtSearchResult, Dock.Top)
            _dp.Children.Add(_txtSearchResult)
            DockPanel.SetDock(_txtHighlighted, Dock.Top)
            _dp.Children.Add(_txtHighlighted)
            DockPanel.SetDock(_txtHighlightResult, Dock.Top)
            _dp.Children.Add(_txtHighlightResult)
            _window.Content = _dp
            _window.Show()
        End Sub

        Private Sub cbSearch_IsCheckedChanged(ByVal sender As Object, ByVal e As RoutedEventArgs)
            _bBackward = _cbSearch.IsChecked
            ' Reset the document range
            ' <Snippet2050>
            _tprDoc = targetTextPattern.DocumentRange
            ' </Snippet2050>
            ' Re-enable search button if necessary (eod reached)
            _btnSearch.IsEnabled = True
        End Sub


        ' Reset all controls if user changes search text
        Private Sub tbSearch_TextChanged(ByVal sender As Object, ByVal e As TextChangedEventArgs)
            _btnSearch.IsEnabled = True
            _tprDoc = targetTextPattern.DocumentRange
        End Sub

        ' Start the text application that you are going to use for the TextPattern sample
        Private Sub btnApp_Click(ByVal sender As Object, ByVal e As RoutedEventArgs)
            ' Start notepad.exe and use it as your root element.  
            ' For performance reasons, it's not a good idea to start searching for UI from
            ' the root unless the UI you are looking for is very near the root.
            Dim sFile As String = System.Windows.Forms.Application.StartupPath + "\\" + "Text.txt"
            _root = StartApp(_sApplication, sFile)
            If (_root Is Nothing) Then
                _btnApp.IsEnabled = False
                Return
            End If
            FindEdit(_root, _sApplication, sFile)
        End Sub

        Private Function StartApp(ByVal app As String, ByVal args As String) As AutomationElement
            Try
                If (File.Exists(args)) Then
                    ' Start application.
                    Dim p As Process = Process.Start(app, args)

                    ' Give application a second to start up.
                    Thread.Sleep(1000)

                    ' Return the AutomationElement
                    Return (AutomationElement.FromHandle(p.MainWindowHandle))
                Else
                    Throw New FileNotFoundException(args + " not found.")
                End If
            Catch [error] As Exception
                Output([error].ToString())
                Return Nothing
            End Try
        End Function

        ' Initialize our TextPattern and event handlers
        Private Sub FindEdit(ByVal target As AutomationElement, ByVal app As String, ByVal file As String)
            Try
                ' <Snippet2037>
                ' Specify the control type we're looking for, in this case 'Document'
                Dim cond As PropertyCondition = New PropertyCondition(AutomationElement.ControlTypeProperty, ControlType.Document)

                ' target --> The root AutomationElement.
                Dim textProvider As AutomationElement = target.FindFirst(TreeScope.Descendants, cond)

                Dim o As Object = textProvider.GetCurrentPattern(TextPattern.Pattern)
                targetTextPattern = CType(o, TextPattern)

                If (targetTextPattern Is Nothing) Then
                    Console.WriteLine("Root element does not contain a descendant that supports TextPattern.")
                    Return
                End If
                ' </Snippet2037>

                _txtAppResult.Text = app + " started and identified in the UI Automation tree."

                _btnSearch.IsEnabled = True
                _tbSearch.IsEnabled = True
                _btnApp.IsEnabled = False
                _cbSearch.IsEnabled = True

                ' Initialize the document range for the text of the document
                _tprDoc = targetTextPattern.DocumentRange

                ' Beginning of document range
                _bBOD = True
                ' Search starts at end of doc and goes backward
                _bBackward = False

                ' <Snippet2052>
                Dim ehTextChanged As AutomationEventHandler = New AutomationEventHandler(AddressOf onTextChange)
                System.Windows.Automation.Automation.AddAutomationEventHandler(TextPattern.TextChangedEvent, textProvider, TreeScope.Element, ehTextChanged)
                ' </Snippet2052>
                ' <Snippet2042>
                Dim ehTextSelection As AutomationEventHandler = New AutomationEventHandler(AddressOf onTextSelectionChange)
                System.Windows.Automation.Automation.AddAutomationEventHandler(TextPattern.TextSelectionChangedEvent, textProvider, TreeScope.Element, ehTextSelection)
                ' </Snippet2042>

                Dim ehClose As AutomationEventHandler = New AutomationEventHandler(AddressOf onNotepadClose)
                System.Windows.Automation.Automation.AddAutomationEventHandler(WindowPattern.WindowClosedEvent, target, TreeScope.Element, ehClose)

            Catch [error] As Win32Exception
                Output([error].ToString())
                Output(app + " not found.")
            Catch [error] As Exception
                Output([error].ToString())
            End Try
        End Sub

        ' Handle the ValueChange event
        Private Sub onTextChange(ByVal sender As Object, ByVal e As AutomationEventArgs)
            _tprDoc = targetTextPattern.DocumentRange
        End Sub

        ' Handle the TextSelectChange event on the WCP thread
        Private Sub onTextSelectionChange(ByVal sender As Object, ByVal e As AutomationEventArgs)
            _window.Dispatcher.BeginInvoke(DispatcherPriority.Background, New DispatcherOperationCallback(AddressOf ChangeSelection), Nothing)
        End Sub

        ' The delegate for the onTextSelectionChange event
        Private Function ChangeSelection(ByVal arg As Object) As Object
            Dim currentSelection As TextPatternRange() = targetTextPattern.GetSelection()
            Dim selectedText As String = currentSelection(0).GetText(-1)
            Dim oAttribute As Object = currentSelection(0).GetAttributeValue(TextPattern.FontNameAttribute)
            If (oAttribute Is TextPattern.MixedAttributeValue) Then
                ' Fontface: Mixed
            Else
                ' Fontface: _oAttribute.ToString()
            End If
            _txtHighlightResult.Text = selectedText
            selectedText = currentSelection(0).GetText(-1)
            Return (Nothing)
        End Function

        ' Handle the WindowClose event for the instance of Notepad on the WCP thread
        Private Sub onNotepadClose(ByVal sender As Object, ByVal e As AutomationEventArgs)
            _window.Dispatcher.BeginInvoke(DispatcherPriority.Background, New DispatcherOperationCallback(AddressOf CloseApp), Nothing)
        End Sub

        ' The delegate for the Notepad close event
        Private Function CloseApp(ByVal arg As Object) As Object
            _window.Close()
            Return (Nothing)
        End Function

        ' Find the text specified in the text box
        Private Sub btnSearch_Click(ByVal sender As Object, ByVal e As RoutedEventArgs)
            Try
                ' Check if search text entered
                If (_tbSearch.Text.Trim() = "") Then
                    _txtSearchResult.Text = "No search criteria."
                    Return
                End If

                ' Check if the TextPattern supports text selection
                If (targetTextPattern.SupportedTextSelection = SupportedTextSelection.None) Then
                    _txtSearchResult.Text = "Unable to select text."
                End If

                ' Move the TextPatternRange endpoints for 'Highlight Next' functionality
                Dim currentSelection As TextPatternRange() = targetTextPattern.GetSelection()

                If Not currentSelection Is Nothing Then
                    If (_bBackward) Then
                        _tprDoc.MoveEndpointByRange(TextPatternRangeEndpoint.End, CurrentSelection(0), TextPatternRangeEndpoint.Start)
                    Else
                        _tprDoc.MoveEndpointByRange(TextPatternRangeEndpoint.Start, CurrentSelection(0), TextPatternRangeEndpoint.End)
                    End If
                    _btnSearch.Content = "Highlight next"
                End If

                ' Find the text specified in the Search textbox
                ' backward = false -- search from the start of the document range
                ' ignoreCase = false -- search is case sensitive
                _tprSearch = _tprDoc.FindText(_tbSearch.Text, _bBackward, False)

                If (_tprSearch Is Nothing) Then
                    If Not _bBOD Then
                        _txtSearchResult.Text = "End of document reached."
                        _btnSearch.IsEnabled = False
                    Else
                        _txtSearchResult.Text = "Text not found."
                    End If
                    Return
                End If

                'root.SetFocus()
                _tprSearch.Select()

                ' No longer at the beginning of the TextPatternRange
                _bBOD = False

                ' Scroll the selection into view, aligning with top of viewport
                _tprSearch.ScrollIntoView(True)

                _txtSearchResult.Text = "Text found."



            Catch [error] As Exception
                Output([error].ToString())
            End Try

        End Sub

        Private Sub Output(ByVal s As String)
            MessageBox.Show(s)
        End Sub


        ' <Snippet2000>
        Private Sub GetAnimationStyleAttribute()
            ' Start application.
            Dim p As Process = Process.Start("Notepad.exe", "text.txt")

            ' target --> The root AutomationElement.
            Dim target As AutomationElement = AutomationElement.FromHandle(p.MainWindowHandle)

            ' Specify the control type we're looking for, in this case 'Document'
            Dim cond As PropertyCondition = New PropertyCondition(AutomationElement.ControlTypeProperty, ControlType.Document)

            Dim textProvider As AutomationElement = target.FindFirst(TreeScope.Descendants, cond)

            Dim textpatternPattern As TextPattern = CType(textProvider.GetCurrentPattern(TextPattern.Pattern), TextPattern)

            If (textpatternPattern Is Nothing) Then
                Console.WriteLine("Root element does not contain a descendant that supports TextPattern.")
                Return
            End If

            Dim oAttribute As Object = textpatternPattern.DocumentRange.GetAttributeValue(TextPattern.AnimationStyleAttribute)
            If (oAttribute = TextPattern.MixedAttributeValue) Then
                Console.WriteLine("Mixed animation styles.")
            Else
                Console.WriteLine(oAttribute.ToString())
            End If
        End Sub
        ' </Snippet2000>
        ' <Snippet2001>
        Private Sub GetBackgroundColorAttribute()
            ' Start application.
            Dim p As Process = Process.Start("Notepad.exe", "text.txt")

            ' target --> The root AutomationElement.
            Dim target As AutomationElement = AutomationElement.FromHandle(p.MainWindowHandle)

            ' Specify the control type we're looking for, in this case 'Document'
            Dim cond As PropertyCondition = New PropertyCondition(AutomationElement.ControlTypeProperty, ControlType.Document)

            Dim textProvider As AutomationElement = target.FindFirst(TreeScope.Descendants, cond)

            Dim textpatternPattern As TextPattern = CType(textProvider.GetCurrentPattern(TextPattern.Pattern), TextPattern)

            If (textpatternPattern Is Nothing) Then
                Console.WriteLine("Root element does not contain a descendant that supports TextPattern.")
                Return
            End If

            Dim oAttribute As Object = textpatternPattern.DocumentRange.GetAttributeValue(TextPattern.BackgroundColorAttribute)
            If (oAttribute = TextPattern.MixedAttributeValue) Then
                Console.WriteLine("Mixed background colors.")
            Else
                Console.WriteLine(oAttribute.ToString())
            End If
        End Sub
        ' </Snippet2001>
        ' <Snippet2002>
        Private Sub GetBulletStyleAttribute()
            ' Start application.
            Dim p As Process = Process.Start("Notepad.exe", "text.txt")

            ' target --> The root AutomationElement.
            Dim target As AutomationElement = AutomationElement.FromHandle(p.MainWindowHandle)

            ' Specify the control type we're looking for, in this case 'Document'
            Dim cond As PropertyCondition = New PropertyCondition(AutomationElement.ControlTypeProperty, ControlType.Document)

            Dim textProvider As AutomationElement = target.FindFirst(TreeScope.Descendants, cond)

            Dim textpatternPattern As TextPattern = CType(textProvider.GetCurrentPattern(TextPattern.Pattern), TextPattern)

            If (textpatternPattern Is Nothing) Then
                Console.WriteLine("Root element does not contain a descendant that supports TextPattern.")
                Return
            End If

            Dim oAttribute As Object = textpatternPattern.DocumentRange.GetAttributeValue(TextPattern.BulletStyleAttribute)
            If (oAttribute = TextPattern.MixedAttributeValue) Then
                Console.WriteLine("Mixed bullet styles.")
            Else
                Console.WriteLine(oAttribute.ToString())
            End If
        End Sub
        ' </Snippet2002>
        ' <Snippet2003>
        Private Sub GetCapStyleAttribute()
            ' Start application.
            Dim p As Process = Process.Start("Notepad.exe", "text.txt")

            ' target --> The root AutomationElement.
            Dim target As AutomationElement = AutomationElement.FromHandle(p.MainWindowHandle)

            ' Specify the control type we're looking for, in this case 'Document'
            Dim cond As PropertyCondition = New PropertyCondition(AutomationElement.ControlTypeProperty, ControlType.Document)

            Dim textProvider As AutomationElement = target.FindFirst(TreeScope.Descendants, cond)

            Dim textpatternPattern As TextPattern = CType(textProvider.GetCurrentPattern(TextPattern.Pattern), TextPattern)

            If (textpatternPattern Is Nothing) Then
                Console.WriteLine("Root element does not contain a descendant that supports TextPattern.")
                Return
            End If

            Dim oAttribute As Object = textpatternPattern.DocumentRange.GetAttributeValue(TextPattern.CapStyleAttribute)
            If (oAttribute = TextPattern.MixedAttributeValue) Then
                Console.WriteLine("Mixed cap styles.")
            Else
                Console.WriteLine(oAttribute.ToString())
            End If
        End Sub
        ' </Snippet2003>
        '' <Snippet2004>
        'Private Sub GetCompositionStateAttribute()
        '    ' Start application.
        '    Dim p As Process = Process.Start("Notepad.exe", "text.txt")

        '    ' target --> The root AutomationElement.
        '    Dim target As AutomationElement = AutomationElement.FromHandle(p.MainWindowHandle)

        '    ' Specify the control type we're looking for, in this case 'Document'
        '    Dim cond As PropertyCondition = New PropertyCondition(AutomationElement.ControlTypeProperty, ControlType.Document)

        '    Dim textProvider As AutomationElement = target.FindFirst(TreeScope.Descendants, cond)

        '    Dim textpatternPattern As TextPattern = CType(textProvider.GetCurrentPattern(TextPattern.Pattern), TextPattern)

        '    If (textpatternPattern Is Nothing) Then
        '        Console.WriteLine("Root element does not contain a descendant that supports TextPattern.")
        '        Return
        '    End If

        '    Dim oAttribute As Object = textpatternPattern.DocumentRange.GetAttributeValue(TextPattern.CompositionStateAttribute)
        '    If (oAttribute = TextPattern.MixedAttributeValue) Then
        '        Console.WriteLine("Mixed composition state.")
        '    Else
        '        Console.WriteLine(oAttribute.ToString())
        '    End If
        'End Sub
        '' </Snippet2004>
        ' <Snippet2005>
        Private Sub GetCultureAttribute()
            ' Start application.
            Dim p As Process = Process.Start("Notepad.exe", "text.txt")

            ' target --> The root AutomationElement.
            Dim target As AutomationElement = AutomationElement.FromHandle(p.MainWindowHandle)

            ' Specify the control type we're looking for, in this case 'Document'
            Dim cond As PropertyCondition = New PropertyCondition(AutomationElement.ControlTypeProperty, ControlType.Document)

            Dim textProvider As AutomationElement = target.FindFirst(TreeScope.Descendants, cond)

            Dim textpatternPattern As TextPattern = CType(textProvider.GetCurrentPattern(TextPattern.Pattern), TextPattern)

            If (textpatternPattern Is Nothing) Then
                Console.WriteLine("Root element does not contain a descendant that supports TextPattern.")
                Return
            End If

            Dim oAttribute As Object = textpatternPattern.DocumentRange.GetAttributeValue(TextPattern.CultureAttribute)
            If (oAttribute = TextPattern.MixedAttributeValue) Then
                Console.WriteLine("Mixed culture info.")
            Else
                Console.WriteLine(oAttribute.ToString())
            End If
        End Sub
        ' </Snippet2005>
        ' <SnippetStartTarget>
        ''' -------------------------------------------------------------------
        ''' <summary>
        ''' Starts the target application and returns the AutomationElement 
        ''' obtained from the targets window handle.
        ''' </summary>
        ''' <param name="exe">
        ''' The target application.
        ''' </param>
        ''' <param name="filename">
        ''' The text file to be opened in the target application
        ''' </param>
        ''' <returns>
        ''' An AutomationElement representing the target application.
        ''' </returns>
        ''' -------------------------------------------------------------------
        Private Function StartTarget( _
        ByVal exe As String, ByVal filename As String) As AutomationElement
            ' Start text editor and load with a text file.
            Dim p As Process = Process.Start(exe, filename)

            ' targetApp --> the root AutomationElement.
            Dim targetApp As AutomationElement
            targetApp = AutomationElement.FromHandle(p.MainWindowHandle)

            Return targetApp
        End Function
        ' </SnippetStartTarget>

        ' <SnippetGetTextElement>
        ''' -------------------------------------------------------------------
        ''' <summary>
        ''' Obtain the text control of interest from the target application.
        ''' </summary>
        ''' <param name="targetApp">
        ''' The target application.
        ''' </param>
        ''' <returns>
        ''' An AutomationElement. representing a text control.
        ''' </returns>
        ''' -------------------------------------------------------------------
        Private Function GetTextElement(ByVal targetApp As AutomationElement) As AutomationElement
            ' The control type we're looking for; in this case 'Document'
            Dim cond1 As PropertyCondition = _
                New PropertyCondition( _
                AutomationElement.ControlTypeProperty, _
                ControlType.Document)

            ' The control pattern of interest; in this case 'TextPattern'.
            Dim cond2 As PropertyCondition = _
                New PropertyCondition( _
                AutomationElement.IsTextPatternAvailableProperty, _
                True)

            Dim textCondition As AndCondition = New AndCondition(cond1, cond2)

            Dim targetTextElement As AutomationElement = _
                targetApp.FindFirst(TreeScope.Descendants, textCondition)

            ' If targetText is null then a suitable text control was not found.
            Return targetTextElement
        End Function
        ' </SnippetGetTextElement>

        ' <SnippetFontName>
        ''' -------------------------------------------------------------------
        ''' <summary>
        ''' Outputs the FontNameAttribute value for a range of text.
        ''' </summary>
        ''' <param name="targetTextElement">
        ''' The AutomationElement. that represents the text provider.
        ''' </param>
        ''' -------------------------------------------------------------------
        Private Sub GetFontNameAttribute( _
        ByVal targetTextElement As AutomationElement)
            Dim targetTextPattern As TextPattern = _
                DirectCast(targetTextElement.GetCurrentPattern( _
                TextPattern.Pattern), TextPattern)

            If (targetTextPattern Is Nothing) Then
                ' Target control doesn't support TextPattern.
                Return
            End If

            ' If the target control doesn't support selection then return.
            ' Otherwise, get the text attribute for the selected text.
            ' If there are currently no selections then the text attribute 
            ' will be obtained from the insertion point.
            Dim textRanges() As TextPatternRange
            If (targetTextPattern.SupportedTextSelection = SupportedTextSelection.None) Then
                Return
            Else
                textRanges = targetTextPattern.GetSelection()
            End If

            Dim textRange As TextPatternRange
            For Each textRange In textRanges
                Dim textAttribute As Object = _
                    textRange.GetAttributeValue( _
                    TextPattern.FontNameAttribute)

                If (textAttribute = TextPattern.MixedAttributeValue) Then
                    ' Returns MixedAttributeValue if the value of the 
                    ' specified attribute varies over the text range. 
                    Console.WriteLine("Mixed fonts.")
                ElseIf (textAttribute = AutomationElement.NotSupported) Then
                    ' Returns NotSupported if the specified attribute is 
                    ' not supported by the provider or the control. 
                    Console.WriteLine( _
                    "FontNameAttribute not supported by provider.")
                Else
                    Console.WriteLine(textAttribute.ToString())
                End If
            Next
        End Sub
        ' </SnippetFontName>


        ' <Snippet2007>
        Private Sub GetFontSizeAttribute()
            ' Start application.
            Dim p As Process = Process.Start("Notepad.exe", "text.txt")

            ' target --> The root AutomationElement.
            Dim target As AutomationElement = AutomationElement.FromHandle(p.MainWindowHandle)

            ' Specify the control type we're looking for, in this case 'Document'
            Dim cond As PropertyCondition = New PropertyCondition(AutomationElement.ControlTypeProperty, ControlType.Document)

            Dim textProvider As AutomationElement = target.FindFirst(TreeScope.Descendants, cond)

            Dim textpatternPattern As TextPattern = CType(textProvider.GetCurrentPattern(TextPattern.Pattern), TextPattern)

            If (textpatternPattern Is Nothing) Then
                Console.WriteLine("Root element does not contain a descendant that supports TextPattern.")
                Return
            End If

            Dim oAttribute As Object = textpatternPattern.DocumentRange.GetAttributeValue(TextPattern.FontSizeAttribute)
            If (oAttribute = TextPattern.MixedAttributeValue) Then
                Console.WriteLine("Mixed font sizes.")
            Else
                Console.WriteLine(oAttribute.ToString())
            End If
        End Sub
        ' </Snippet2007>
        ' <Snippet2008>
        Private Sub GetFontWeightAttribute()
            ' Start application.
            Dim p As Process = Process.Start("Notepad.exe", "text.txt")

            ' target --> The root AutomationElement.
            Dim target As AutomationElement = AutomationElement.FromHandle(p.MainWindowHandle)

            ' Specify the control type we're looking for, in this case 'Document'
            Dim cond As PropertyCondition = New PropertyCondition(AutomationElement.ControlTypeProperty, ControlType.Document)

            Dim textProvider As AutomationElement = target.FindFirst(TreeScope.Descendants, cond)

            Dim textpatternPattern As TextPattern = CType(textProvider.GetCurrentPattern(TextPattern.Pattern), TextPattern)

            If (textpatternPattern Is Nothing) Then
                Console.WriteLine("Root element does not contain a descendant that supports TextPattern.")
                Return
            End If

            Dim oAttribute As Object = textpatternPattern.DocumentRange.GetAttributeValue(TextPattern.FontWeightAttribute)
            If (oAttribute = TextPattern.MixedAttributeValue) Then
                Console.WriteLine("Mixed font weights.")
            Else
                Console.WriteLine(oAttribute.ToString())
            End If
        End Sub
        ' </Snippet2008>
        ' <Snippet2009>
        Private Sub GetForegroundColorAttribute()
            ' Start application.
            Dim p As Process = Process.Start("Notepad.exe", "text.txt")

            ' target --> The root AutomationElement.
            Dim target As AutomationElement = AutomationElement.FromHandle(p.MainWindowHandle)

            ' Specify the control type we're looking for, in this case 'Document'
            Dim cond As PropertyCondition = New PropertyCondition(AutomationElement.ControlTypeProperty, ControlType.Document)

            Dim textProvider As AutomationElement = target.FindFirst(TreeScope.Descendants, cond)

            Dim textpatternPattern As TextPattern = CType(textProvider.GetCurrentPattern(TextPattern.Pattern), TextPattern)

            If (textpatternPattern Is Nothing) Then
                Console.WriteLine("Root element does not contain a descendant that supports TextPattern.")
                Return
            End If

            Dim oAttribute As Object = textpatternPattern.DocumentRange.GetAttributeValue(TextPattern.ForegroundColorAttribute)
            If (oAttribute = TextPattern.MixedAttributeValue) Then
                Console.WriteLine("Mixed foreground colors.")
            Else
                Console.WriteLine(oAttribute.ToString())
            End If
        End Sub
        ' </Snippet2009>
        '' <Snippet2010>
        'Private Sub GetHeadingLevelAttribute()
        '    ' Start application.
        '    Dim p As Process = Process.Start("Notepad.exe", "text.txt")

        '    ' target --> The root AutomationElement.
        '    Dim target As AutomationElement = AutomationElement.FromHandle(p.MainWindowHandle)

        '    ' Specify the control type we're looking for, in this case 'Document'
        '    Dim cond As PropertyCondition = New PropertyCondition(AutomationElement.ControlTypeProperty, ControlType.Document)

        '    Dim textProvider As AutomationElement = target.FindFirst(TreeScope.Descendants, cond)

        '    Dim textpatternPattern As TextPattern = CType(textProvider.GetCurrentPattern(TextPattern.Pattern), TextPattern)

        '    If (textpatternPattern Is Nothing) Then
        '        Console.WriteLine("Root element does not contain a descendant that supports TextPattern.")
        '        Return
        '    End If

        '    Dim oAttribute As Object = textpatternPattern.DocumentRange.GetAttributeValue(TextPattern.HeadingLevelAttribute)
        '    If (oAttribute = TextPattern.MixedAttributeValue) Then
        '        Console.WriteLine("Mixed heading levels.")
        '    Else
        '        Console.WriteLine(oAttribute.ToString())
        '    End If
        'End Sub
        '' </Snippet2010>
        ' <Snippet2011>
        Private Sub GetHorizontalTextAlignmentAttribute()
            ' Start application.
            Dim p As Process = Process.Start("Notepad.exe", "text.txt")

            ' target --> The root AutomationElement.
            Dim target As AutomationElement = AutomationElement.FromHandle(p.MainWindowHandle)

            ' Specify the control type we're looking for, in this case 'Document'
            Dim cond As PropertyCondition = New PropertyCondition(AutomationElement.ControlTypeProperty, ControlType.Document)

            Dim textProvider As AutomationElement = target.FindFirst(TreeScope.Descendants, cond)

            Dim textpatternPattern As TextPattern = CType(textProvider.GetCurrentPattern(TextPattern.Pattern), TextPattern)

            If (textpatternPattern Is Nothing) Then
                Console.WriteLine("Root element does not contain a descendant that supports TextPattern.")
                Return
            End If

            Dim oAttribute As Object = textpatternPattern.DocumentRange.GetAttributeValue(TextPattern.HorizontalTextAlignmentAttribute)
            If (oAttribute = TextPattern.MixedAttributeValue) Then
                Console.WriteLine("Mixed horizontal alignments.")
            Else
                Console.WriteLine(oAttribute.ToString())
            End If
        End Sub
        ' </Snippet2011>
        ' <Snippet2012>
        Private Sub GetIndentationFirstLineAttribute()
            ' Start application.
            Dim p As Process = Process.Start("Notepad.exe", "text.txt")

            ' target --> The root AutomationElement.
            Dim target As AutomationElement = AutomationElement.FromHandle(p.MainWindowHandle)

            ' Specify the control type we're looking for, in this case 'Document'
            Dim cond As PropertyCondition = New PropertyCondition(AutomationElement.ControlTypeProperty, ControlType.Document)

            Dim textProvider As AutomationElement = target.FindFirst(TreeScope.Descendants, cond)

            Dim textpatternPattern As TextPattern = CType(textProvider.GetCurrentPattern(TextPattern.Pattern), TextPattern)

            If (textpatternPattern Is Nothing) Then
                Console.WriteLine("Root element does not contain a descendant that supports TextPattern.")
                Return
            End If

            Dim oAttribute As Object = textpatternPattern.DocumentRange.GetAttributeValue(TextPattern.IndentationFirstLineAttribute)
            If (oAttribute = TextPattern.MixedAttributeValue) Then
                Console.WriteLine("Mixed first line indentations.")
            Else
                Console.WriteLine(oAttribute.ToString())
            End If
        End Sub
        ' </Snippet2012>
        ' <Snippet2013>
        Private Sub GetIndentationLeadingAttribute()
            ' Start application.
            Dim p As Process = Process.Start("Notepad.exe", "text.txt")

            ' target --> The root AutomationElement.
            Dim target As AutomationElement = AutomationElement.FromHandle(p.MainWindowHandle)

            ' Specify the control type we're looking for, in this case 'Document'
            Dim cond As PropertyCondition = New PropertyCondition(AutomationElement.ControlTypeProperty, ControlType.Document)

            Dim textProvider As AutomationElement = target.FindFirst(TreeScope.Descendants, cond)

            Dim textpatternPattern As TextPattern = CType(textProvider.GetCurrentPattern(TextPattern.Pattern), TextPattern)

            If (textpatternPattern Is Nothing) Then
                Console.WriteLine("Root element does not contain a descendant that supports TextPattern.")
                Return
            End If

            Dim oAttribute As Object = textpatternPattern.DocumentRange.GetAttributeValue(TextPattern.IndentationLeadingAttribute)
            If (oAttribute = TextPattern.MixedAttributeValue) Then
                Console.WriteLine("Mixed leading indentations.")
            Else
                Console.WriteLine(oAttribute.ToString())
            End If
        End Sub
        ' </Snippet2013>
        ' <Snippet2014>
        Private Sub GetIndentationTrailingAttribute()
            ' Start application.
            Dim p As Process = Process.Start("Notepad.exe", "text.txt")

            ' target --> The root AutomationElement.
            Dim target As AutomationElement = AutomationElement.FromHandle(p.MainWindowHandle)

            ' Specify the control type we're looking for, in this case 'Document'
            Dim cond As PropertyCondition = New PropertyCondition(AutomationElement.ControlTypeProperty, ControlType.Document)

            Dim textProvider As AutomationElement = target.FindFirst(TreeScope.Descendants, cond)

            Dim textpatternPattern As TextPattern = CType(textProvider.GetCurrentPattern(TextPattern.Pattern), TextPattern)

            If (textpatternPattern Is Nothing) Then
                Console.WriteLine("Root element does not contain a descendant that supports TextPattern.")
                Return
            End If

            Dim oAttribute As Object = textpatternPattern.DocumentRange.GetAttributeValue(TextPattern.IndentationTrailingAttribute)
            If (oAttribute = TextPattern.MixedAttributeValue) Then
                Console.WriteLine("Mixed trailing indentations.")
            Else
                Console.WriteLine(oAttribute.ToString())
            End If
        End Sub
        ' </Snippet2014>
        ' <Snippet2015>
        Private Sub GetIsHiddenAttribute()
            ' Start application.
            Dim p As Process = Process.Start("Notepad.exe", "text.txt")

            ' target --> The root AutomationElement.
            Dim target As AutomationElement = AutomationElement.FromHandle(p.MainWindowHandle)

            ' Specify the control type we're looking for, in this case 'Document'
            Dim cond As PropertyCondition = New PropertyCondition(AutomationElement.ControlTypeProperty, ControlType.Document)

            Dim textProvider As AutomationElement = target.FindFirst(TreeScope.Descendants, cond)

            Dim textpatternPattern As TextPattern = CType(textProvider.GetCurrentPattern(TextPattern.Pattern), TextPattern)

            If (textpatternPattern Is Nothing) Then
                Console.WriteLine("Root element does not contain a descendant that supports TextPattern.")
                Return
            End If

            Dim oAttribute As Object = textpatternPattern.DocumentRange.GetAttributeValue(TextPattern.IsHiddenAttribute)
            If (oAttribute = TextPattern.MixedAttributeValue) Then
                Console.WriteLine("Mixture of hidden and visible.")
            Else
                Console.WriteLine(oAttribute.ToString())
            End If
        End Sub
        ' </Snippet2015>
        ' <Snippet2016>
        Private Sub GetIsItalicAttribute()
            ' Start application.
            Dim p As Process = Process.Start("Notepad.exe", "text.txt")

            ' target --> The root AutomationElement.
            Dim target As AutomationElement = AutomationElement.FromHandle(p.MainWindowHandle)

            ' Specify the control type we're looking for, in this case 'Document'
            Dim cond As PropertyCondition = New PropertyCondition(AutomationElement.ControlTypeProperty, ControlType.Document)

            Dim textProvider As AutomationElement = target.FindFirst(TreeScope.Descendants, cond)

            Dim textpatternPattern As TextPattern = CType(textProvider.GetCurrentPattern(TextPattern.Pattern), TextPattern)

            If (textpatternPattern Is Nothing) Then
                Console.WriteLine("Root element does not contain a descendant that supports TextPattern.")
                Return
            End If

            Dim oAttribute As Object = textpatternPattern.DocumentRange.GetAttributeValue(TextPattern.IsItalicAttribute)
            If (oAttribute = TextPattern.MixedAttributeValue) Then
                Console.WriteLine("Mixture of italic and non-italic.")
            Else
                Console.WriteLine(oAttribute.ToString())
            End If
        End Sub
        ' </Snippet2016>
        '' <Snippet2017>
        'Private Sub GetIsMarkedAutocorrectedAttribute()
        '    ' Start application.
        '    Dim p As Process = Process.Start("Notepad.exe", "text.txt")

        '    ' target --> The root AutomationElement.
        '    Dim target As AutomationElement = AutomationElement.FromHandle(p.MainWindowHandle)

        '    ' Specify the control type we're looking for, in this case 'Document'
        '    Dim cond As PropertyCondition = New PropertyCondition(AutomationElement.ControlTypeProperty, ControlType.Document)

        '    Dim textProvider As AutomationElement = target.FindFirst(TreeScope.Descendants, cond)

        '    Dim textpatternPattern As TextPattern = CType(textProvider.GetCurrentPattern(TextPattern.Pattern), TextPattern)

        '    If (textpatternPattern Is Nothing) Then
        '        Console.WriteLine("Root element does not contain a descendant that supports TextPattern.")
        '        Return
        '    End If

        '    Dim oAttribute As Object = textpatternPattern.DocumentRange.GetAttributeValue(TextPattern.IsMarkedAutocorrectedAttribute)
        '    If (oAttribute = TextPattern.MixedAttributeValue) Then
        '        Console.WriteLine("Mixture of autocorrected and non-autocorrected.")
        '    Else
        '        Console.WriteLine(oAttribute.ToString())
        '    End If
        'End Sub
        '' </Snippet2017>
        '' <Snippet2018>
        'Private Sub GetIsMarkedGrammaticallyWrongAttribute()
        '    ' Start application.
        '    Dim p As Process = Process.Start("Notepad.exe", "text.txt")

        '    ' target --> The root AutomationElement.
        '    Dim target As AutomationElement = AutomationElement.FromHandle(p.MainWindowHandle)

        '    ' Specify the control type we're looking for, in this case 'Document'
        '    Dim cond As PropertyCondition = New PropertyCondition(AutomationElement.ControlTypeProperty, ControlType.Document)

        '    Dim textProvider As AutomationElement = target.FindFirst(TreeScope.Descendants, cond)

        '    Dim textpatternPattern As TextPattern = CType(textProvider.GetCurrentPattern(TextPattern.Pattern), TextPattern)

        '    If (textpatternPattern Is Nothing) Then
        '        Console.WriteLine("Root element does not contain a descendant that supports TextPattern.")
        '        Return
        '    End If

        '    Dim oAttribute As Object = textpatternPattern.DocumentRange.GetAttributeValue(TextPattern.IsMarkedGrammaticallyWrongAttribute)
        '    If (oAttribute = TextPattern.MixedAttributeValue) Then
        '        Console.WriteLine("Mixture of grammatically marked and non-marked.")
        '    Else
        '        Console.WriteLine(oAttribute.ToString())
        '    End If
        'End Sub
        '' </Snippet2018>
        '' <Snippet2019>
        'Private Sub GetIsMarkedMisspelledAttribute()
        '    ' Start application.
        '    Dim p As Process = Process.Start("Notepad.exe", "text.txt")

        '    ' target --> The root AutomationElement.
        '    Dim target As AutomationElement = AutomationElement.FromHandle(p.MainWindowHandle)

        '    ' Specify the control type we're looking for, in this case 'Document'
        '    Dim cond As PropertyCondition = New PropertyCondition(AutomationElement.ControlTypeProperty, ControlType.Document)

        '    Dim textProvider As AutomationElement = target.FindFirst(TreeScope.Descendants, cond)

        '    Dim textpatternPattern As TextPattern = CType(textProvider.GetCurrentPattern(TextPattern.Pattern), TextPattern)

        '    If (textpatternPattern Is Nothing) Then
        '        Console.WriteLine("Root element does not contain a descendant that supports TextPattern.")
        '        Return
        '    End If

        '    Dim oAttribute As Object = textpatternPattern.DocumentRange.GetAttributeValue(TextPattern.IsMarkedMisspelledAttribute)
        '    If (oAttribute = TextPattern.MixedAttributeValue) Then
        '        Console.WriteLine("Mixture of misspellings marked and non-marked.")
        '    Else
        '        Console.WriteLine(oAttribute.ToString())
        '    End If
        'End Sub
        '' </Snippet2019>
        '' <Snippet2020>
        'Private Sub GetIsMarkedSmartTagAttribute()
        '    ' Start application.
        '    Dim p As Process = Process.Start("Notepad.exe", "text.txt")

        '    ' target --> The root AutomationElement.
        '    Dim target As AutomationElement = AutomationElement.FromHandle(p.MainWindowHandle)

        '    ' Specify the control type we're looking for, in this case 'Document'
        '    Dim cond As PropertyCondition = New PropertyCondition(AutomationElement.ControlTypeProperty, ControlType.Document)

        '    Dim textProvider As AutomationElement = target.FindFirst(TreeScope.Descendants, cond)

        '    Dim textpatternPattern As TextPattern = CType(textProvider.GetCurrentPattern(TextPattern.Pattern), TextPattern)

        '    If (textpatternPattern Is Nothing) Then
        '        Console.WriteLine("Root element does not contain a descendant that supports TextPattern.")
        '        Return
        '    End If

        '    Dim oAttribute As Object = textpatternPattern.DocumentRange.GetAttributeValue(TextPattern.IsMarkedSmartTagAttribute)
        '    If (oAttribute = TextPattern.MixedAttributeValue) Then
        '        Console.WriteLine("Mixture of smart tag marked and non-marked.")
        '    Else
        '        Console.WriteLine(oAttribute.ToString())
        '    End If
        'End Sub
        '' </Snippet2020>
        '' <Snippet2021>
        'Private Sub GetIsPortraitAttribute()
        '    ' Start application.
        '    Dim p As Process = Process.Start("Notepad.exe", "text.txt")

        '    ' target --> The root AutomationElement.
        '    Dim target As AutomationElement = AutomationElement.FromHandle(p.MainWindowHandle)

        '    ' Specify the control type we're looking for, in this case 'Document'
        '    Dim cond As PropertyCondition = New PropertyCondition(AutomationElement.ControlTypeProperty, ControlType.Document)

        '    Dim textProvider As AutomationElement = target.FindFirst(TreeScope.Descendants, cond)

        '    Dim textpatternPattern As TextPattern = CType(textProvider.GetCurrentPattern(TextPattern.Pattern), TextPattern)

        '    If (textpatternPattern Is Nothing) Then
        '        Console.WriteLine("Root element does not contain a descendant that supports TextPattern.")
        '        Return
        '    End If

        '    Dim oAttribute As Object = textpatternPattern.DocumentRange.GetAttributeValue(TextPattern.IsPortraitAttribute)
        '    If (oAttribute = TextPattern.MixedAttributeValue) Then
        '        Console.WriteLine("Mixture of portrait and non-portrait pages.")
        '    Else
        '        Console.WriteLine(oAttribute.ToString())
        '    End If
        'End Sub
        '' </Snippet2021>
        ' <Snippet2022>
        Private Sub GetIsReadOnlyAttribute()
            ' Start application.
            Dim p As Process = Process.Start("Notepad.exe", "text.txt")

            ' target --> The root AutomationElement.
            Dim target As AutomationElement = AutomationElement.FromHandle(p.MainWindowHandle)

            ' Specify the control type we're looking for, in this case 'Document'
            Dim cond As PropertyCondition = New PropertyCondition(AutomationElement.ControlTypeProperty, ControlType.Document)

            Dim textProvider As AutomationElement = target.FindFirst(TreeScope.Descendants, cond)

            Dim textpatternPattern As TextPattern = CType(textProvider.GetCurrentPattern(TextPattern.Pattern), TextPattern)

            If (textpatternPattern Is Nothing) Then
                Console.WriteLine("Root element does not contain a descendant that supports TextPattern.")
                Return
            End If

            Dim oAttribute As Object = textpatternPattern.DocumentRange.GetAttributeValue(TextPattern.IsReadOnlyAttribute)
            If (oAttribute = TextPattern.MixedAttributeValue) Then
                Console.WriteLine("Mixture of readonly and non-readonly.")
            Else
                Console.WriteLine(oAttribute.ToString())
            End If
        End Sub
        ' </Snippet2022>
        ' <Snippet2023>
        Private Sub GetIsSubscriptAttribute()
            ' Start application.
            Dim p As Process = Process.Start("Notepad.exe", "text.txt")

            ' target --> The root AutomationElement.
            Dim target As AutomationElement = AutomationElement.FromHandle(p.MainWindowHandle)

            ' Specify the control type we're looking for, in this case 'Document'
            Dim cond As PropertyCondition = New PropertyCondition(AutomationElement.ControlTypeProperty, ControlType.Document)

            Dim textProvider As AutomationElement = target.FindFirst(TreeScope.Descendants, cond)

            Dim textpatternPattern As TextPattern = CType(textProvider.GetCurrentPattern(TextPattern.Pattern), TextPattern)

            If (textpatternPattern Is Nothing) Then
                Console.WriteLine("Root element does not contain a descendant that supports TextPattern.")
                Return
            End If

            Dim oAttribute As Object = textpatternPattern.DocumentRange.GetAttributeValue(TextPattern.IsSubscriptAttribute)
            If (oAttribute = TextPattern.MixedAttributeValue) Then
                Console.WriteLine("Mixture of subscript and non-subscript.")
            Else
                Console.WriteLine(oAttribute.ToString())
            End If
        End Sub
        ' </Snippet2023>
        ' <Snippet2024>
        Private Sub GetIsSuperscriptAttribute()
            ' Start application.
            Dim p As Process = Process.Start("Notepad.exe", "text.txt")

            ' target --> The root AutomationElement.
            Dim target As AutomationElement = AutomationElement.FromHandle(p.MainWindowHandle)

            ' Specify the control type we're looking for, in this case 'Document'
            Dim cond As PropertyCondition = New PropertyCondition(AutomationElement.ControlTypeProperty, ControlType.Document)

            Dim textProvider As AutomationElement = target.FindFirst(TreeScope.Descendants, cond)

            Dim textpatternPattern As TextPattern = CType(textProvider.GetCurrentPattern(TextPattern.Pattern), TextPattern)

            If (textpatternPattern Is Nothing) Then
                Console.WriteLine("Root element does not contain a descendant that supports TextPattern.")
                Return
            End If

            Dim oAttribute As Object = textpatternPattern.DocumentRange.GetAttributeValue(TextPattern.IsSuperscriptAttribute)
            If (oAttribute = TextPattern.MixedAttributeValue) Then
                Console.WriteLine("Mixture of superscript and non-superscript.")
            Else
                Console.WriteLine(oAttribute.ToString())
            End If
        End Sub
        ' </Snippet2024>
        ' <Snippet2025>
        Private Sub GetMarginBottomAttribute()
            ' Start application.
            Dim p As Process = Process.Start("Notepad.exe", "text.txt")

            ' target --> The root AutomationElement.
            Dim target As AutomationElement = AutomationElement.FromHandle(p.MainWindowHandle)

            ' Specify the control type we're looking for, in this case 'Document'
            Dim cond As PropertyCondition = New PropertyCondition(AutomationElement.ControlTypeProperty, ControlType.Document)

            Dim textProvider As AutomationElement = target.FindFirst(TreeScope.Descendants, cond)

            Dim textpatternPattern As TextPattern = CType(textProvider.GetCurrentPattern(TextPattern.Pattern), TextPattern)

            If (textpatternPattern Is Nothing) Then
                Console.WriteLine("Root element does not contain a descendant that supports TextPattern.")
                Return
            End If

            Dim oAttribute As Object = textpatternPattern.DocumentRange.GetAttributeValue(TextPattern.MarginBottomAttribute)
            If (oAttribute = TextPattern.MixedAttributeValue) Then
                Console.WriteLine("Mixed bottom margins.")
            Else
                Console.WriteLine(oAttribute.ToString())
            End If
        End Sub
        ' </Snippet2025>
        ' <Snippet2026>
        Private Sub GetMarginLeadingAttribute()
            ' Start application.
            Dim p As Process = Process.Start("Notepad.exe", "text.txt")

            ' target --> The root AutomationElement.
            Dim target As AutomationElement = AutomationElement.FromHandle(p.MainWindowHandle)

            ' Specify the control type we're looking for, in this case 'Document'
            Dim cond As PropertyCondition = New PropertyCondition(AutomationElement.ControlTypeProperty, ControlType.Document)

            Dim textProvider As AutomationElement = target.FindFirst(TreeScope.Descendants, cond)

            Dim textpatternPattern As TextPattern = CType(textProvider.GetCurrentPattern(TextPattern.Pattern), TextPattern)

            If (textpatternPattern Is Nothing) Then
                Console.WriteLine("Root element does not contain a descendant that supports TextPattern.")
                Return
            End If

            Dim oAttribute As Object = textpatternPattern.DocumentRange.GetAttributeValue(TextPattern.MarginLeadingAttribute)
            If (oAttribute = TextPattern.MixedAttributeValue) Then
                Console.WriteLine("Mixed leading margins.")
            Else
                Console.WriteLine(oAttribute.ToString())
            End If
        End Sub
        ' </Snippet2026>
        ' <Snippet2027>
        Private Sub GetMarginTopAttribute()
            ' Start application.
            Dim p As Process = Process.Start("Notepad.exe", "text.txt")

            ' target --> The root AutomationElement.
            Dim target As AutomationElement = AutomationElement.FromHandle(p.MainWindowHandle)

            ' Specify the control type we're looking for, in this case 'Document'
            Dim cond As PropertyCondition = New PropertyCondition(AutomationElement.ControlTypeProperty, ControlType.Document)

            Dim textProvider As AutomationElement = target.FindFirst(TreeScope.Descendants, cond)

            Dim textpatternPattern As TextPattern = CType(textProvider.GetCurrentPattern(TextPattern.Pattern), TextPattern)

            If (textpatternPattern Is Nothing) Then
                Console.WriteLine("Root element does not contain a descendant that supports TextPattern.")
                Return
            End If

            Dim oAttribute As Object = textpatternPattern.DocumentRange.GetAttributeValue(TextPattern.MarginTopAttribute)
            If (oAttribute = TextPattern.MixedAttributeValue) Then
                Console.WriteLine("Mixed top margins.")
            Else
                Console.WriteLine(oAttribute.ToString())
            End If
        End Sub
        ' </Snippet2027>
        ' <Snippet2028>
        Private Sub GetMarginTrailingAttribute()
            ' Start application.
            Dim p As Process = Process.Start("Notepad.exe", "text.txt")

            ' target --> The root AutomationElement.
            Dim target As AutomationElement = AutomationElement.FromHandle(p.MainWindowHandle)

            ' Specify the control type we're looking for, in this case 'Document'
            Dim cond As PropertyCondition = New PropertyCondition(AutomationElement.ControlTypeProperty, ControlType.Document)

            Dim textProvider As AutomationElement = target.FindFirst(TreeScope.Descendants, cond)

            Dim textpatternPattern As TextPattern = CType(textProvider.GetCurrentPattern(TextPattern.Pattern), TextPattern)

            If (textpatternPattern Is Nothing) Then
                Console.WriteLine("Root element does not contain a descendant that supports TextPattern.")
                Return
            End If

            Dim oAttribute As Object = textpatternPattern.DocumentRange.GetAttributeValue(TextPattern.MarginTrailingAttribute)
            If (oAttribute = TextPattern.MixedAttributeValue) Then
                Console.WriteLine("Mixed trailing margins.")
            Else
                Console.WriteLine(oAttribute.ToString())
            End If
        End Sub
        ' </Snippet2028>
        '' <Snippet2030>
        'Private Sub GetOrderedListStringAttribute()
        '    ' Start application.
        '    Dim p As Process = Process.Start("Notepad.exe", "text.txt")

        '    ' target --> The root AutomationElement.
        '    Dim target As AutomationElement = AutomationElement.FromHandle(p.MainWindowHandle)

        '    ' Specify the control type we're looking for, in this case 'Document'
        '    Dim cond As PropertyCondition = New PropertyCondition(AutomationElement.ControlTypeProperty, ControlType.Document)

        '    Dim textProvider As AutomationElement = target.FindFirst(TreeScope.Descendants, cond)

        '    Dim textpatternPattern As TextPattern = CType(textProvider.GetCurrentPattern(TextPattern.Pattern), TextPattern)

        '    If (textpatternPattern Is Nothing) Then
        '        Console.WriteLine("Root element does not contain a descendant that supports TextPattern.")
        '        Return
        '    End If

        '    Dim oAttribute As Object = textpatternPattern.DocumentRange.GetAttributeValue(TextPattern.OrderedListStringAttribute)
        '    If (oAttribute = TextPattern.MixedAttributeValue) Then
        '        Console.WriteLine("Mixed ordered list strings.")
        '    Else
        '        Console.WriteLine(oAttribute.ToString())
        '    End If
        'End Sub
        '' </Snippet2030>
        ' <Snippet2031>
        Private Sub GetOutlineStylesAttribute()
            ' Start application.
            Dim p As Process = Process.Start("Notepad.exe", "text.txt")

            ' target --> The root AutomationElement.
            Dim target As AutomationElement = AutomationElement.FromHandle(p.MainWindowHandle)

            ' Specify the control type we're looking for, in this case 'Document'
            Dim cond As PropertyCondition = New PropertyCondition(AutomationElement.ControlTypeProperty, ControlType.Document)

            Dim textProvider As AutomationElement = target.FindFirst(TreeScope.Descendants, cond)

            Dim textpatternPattern As TextPattern = CType(textProvider.GetCurrentPattern(TextPattern.Pattern), TextPattern)

            If (textpatternPattern Is Nothing) Then
                Console.WriteLine("Root element does not contain a descendant that supports TextPattern.")
                Return
            End If

            Dim oAttribute As Object = textpatternPattern.DocumentRange.GetAttributeValue(TextPattern.OutlineStylesAttribute)
            If (oAttribute = TextPattern.MixedAttributeValue) Then
                Console.WriteLine("Mixed outline styles.")
            Else
                Console.WriteLine(oAttribute.ToString())
            End If
        End Sub
        ' </Snippet2031>
        ' <Snippet2032>
        Private Sub GetOverlineColorAttribute()
            ' Start application.
            Dim p As Process = Process.Start("Notepad.exe", "text.txt")

            ' target --> The root AutomationElement.
            Dim target As AutomationElement = AutomationElement.FromHandle(p.MainWindowHandle)

            ' Specify the control type we're looking for, in this case 'Document'
            Dim cond As PropertyCondition = New PropertyCondition(AutomationElement.ControlTypeProperty, ControlType.Document)

            Dim textProvider As AutomationElement = target.FindFirst(TreeScope.Descendants, cond)

            Dim textpatternPattern As TextPattern = CType(textProvider.GetCurrentPattern(TextPattern.Pattern), TextPattern)

            If (textpatternPattern Is Nothing) Then
                Console.WriteLine("Root element does not contain a descendant that supports TextPattern.")
                Return
            End If

            Dim oAttribute As Object = textpatternPattern.DocumentRange.GetAttributeValue(TextPattern.OverlineColorAttribute)
            If (oAttribute = TextPattern.MixedAttributeValue) Then
                Console.WriteLine("Mixed overline colors.")
            Else
                Console.WriteLine(oAttribute.ToString())
            End If
        End Sub
        ' </Snippet2032>
        ' <Snippet2033>
        Private Sub GetOverlineStyleAttribute()
            ' Start application.
            Dim p As Process = Process.Start("Notepad.exe", "text.txt")

            ' target --> The root AutomationElement.
            Dim target As AutomationElement = AutomationElement.FromHandle(p.MainWindowHandle)

            ' Specify the control type we're looking for, in this case 'Document'
            Dim cond As PropertyCondition = New PropertyCondition(AutomationElement.ControlTypeProperty, ControlType.Document)

            Dim textProvider As AutomationElement = target.FindFirst(TreeScope.Descendants, cond)

            Dim textpatternPattern As TextPattern = CType(textProvider.GetCurrentPattern(TextPattern.Pattern), TextPattern)

            If (textpatternPattern Is Nothing) Then
                Console.WriteLine("Root element does not contain a descendant that supports TextPattern.")
                Return
            End If

            Dim oAttribute As Object = textpatternPattern.DocumentRange.GetAttributeValue(TextPattern.OverlineStyleAttribute)
            If (oAttribute = TextPattern.MixedAttributeValue) Then
                Console.WriteLine("Mixed overline styles.")
            Else
                Console.WriteLine(oAttribute.ToString())
            End If
        End Sub
        ' </Snippet2033>
        '' <Snippet2034>
        'Private Sub GetPageHeightAttribute()
        '    ' Start application.
        '    Dim p As Process = Process.Start("Notepad.exe", "text.txt")

        '    ' target --> The root AutomationElement.
        '    Dim target As AutomationElement = AutomationElement.FromHandle(p.MainWindowHandle)

        '    ' Specify the control type we're looking for, in this case 'Document'
        '    Dim cond As PropertyCondition = New PropertyCondition(AutomationElement.ControlTypeProperty, ControlType.Document)

        '    Dim textProvider As AutomationElement = target.FindFirst(TreeScope.Descendants, cond)

        '    Dim textpatternPattern As TextPattern = CType(textProvider.GetCurrentPattern(TextPattern.Pattern), TextPattern)

        '    If (textpatternPattern Is Nothing) Then
        '        Console.WriteLine("Root element does not contain a descendant that supports TextPattern.")
        '        Return
        '    End If

        '    Dim oAttribute As Object = textpatternPattern.DocumentRange.GetAttributeValue(TextPattern.PageHeightAttribute)
        '    If (oAttribute = TextPattern.MixedAttributeValue) Then
        '        Console.WriteLine("Mixed page heights.")
        '    Else
        '        Console.WriteLine(oAttribute.ToString())
        '    End If
        'End Sub
        '' </Snippet2034>
        '' <Snippet2035>
        'Private Sub GetPageNumberAttribute()
        '    ' Start application.
        '    Dim p As Process = Process.Start("Notepad.exe", "text.txt")

        '    ' target --> The root AutomationElement.
        '    Dim target As AutomationElement = AutomationElement.FromHandle(p.MainWindowHandle)

        '    ' Specify the control type we're looking for, in this case 'Document'
        '    Dim cond As PropertyCondition = New PropertyCondition(AutomationElement.ControlTypeProperty, ControlType.Document)

        '    Dim textProvider As AutomationElement = target.FindFirst(TreeScope.Descendants, cond)

        '    Dim textpatternPattern As TextPattern = CType(textProvider.GetCurrentPattern(TextPattern.Pattern), TextPattern)

        '    If (textpatternPattern Is Nothing) Then
        '        Console.WriteLine("Root element does not contain a descendant that supports TextPattern.")
        '        Return
        '    End If

        '    Dim oAttribute As Object = textpatternPattern.DocumentRange.GetAttributeValue(TextPattern.PageNumberAttribute)
        '    If (oAttribute = TextPattern.MixedAttributeValue) Then
        '        Console.WriteLine("Mixed page numbers.")
        '    Else
        '        Console.WriteLine(oAttribute.ToString())
        '    End If
        'End Sub
        '' </Snippet2035>
        '' <Snippet2036>
        'Private Sub GetPageWidthAttribute()
        '    ' Start application.
        '    Dim p As Process = Process.Start("Notepad.exe", "text.txt")

        '    ' target --> The root AutomationElement.
        '    Dim target As AutomationElement = AutomationElement.FromHandle(p.MainWindowHandle)

        '    ' Specify the control type we're looking for, in this case 'Document'
        '    Dim cond As PropertyCondition = New PropertyCondition(AutomationElement.ControlTypeProperty, ControlType.Document)

        '    Dim textProvider As AutomationElement = target.FindFirst(TreeScope.Descendants, cond)

        '    Dim textpatternPattern As TextPattern = CType(textProvider.GetCurrentPattern(TextPattern.Pattern), TextPattern)

        '    If (textpatternPattern Is Nothing) Then
        '        Console.WriteLine("Root element does not contain a descendant that supports TextPattern.")
        '        Return
        '    End If

        '    Dim oAttribute As Object = textpatternPattern.DocumentRange.GetAttributeValue(TextPattern.PageWidthAttribute)
        '    If (oAttribute = TextPattern.MixedAttributeValue) Then
        '        Console.WriteLine("Mixed page widths.")
        '    Else
        '        Console.WriteLine(oAttribute.ToString())
        '    End If
        'End Sub
        '' </Snippet2036>
        ' <Snippet2038>
        Private Sub GetStrikethroughColorAttribute()
            ' Start application.
            Dim p As Process = Process.Start("Notepad.exe", "text.txt")

            ' target --> The root AutomationElement.
            Dim target As AutomationElement = AutomationElement.FromHandle(p.MainWindowHandle)

            ' Specify the control type we're looking for, in this case 'Document'
            Dim cond As PropertyCondition = New PropertyCondition(AutomationElement.ControlTypeProperty, ControlType.Document)

            Dim textProvider As AutomationElement = target.FindFirst(TreeScope.Descendants, cond)

            Dim textpatternPattern As TextPattern = CType(textProvider.GetCurrentPattern(TextPattern.Pattern), TextPattern)

            If (textpatternPattern Is Nothing) Then
                Console.WriteLine("Root element does not contain a descendant that supports TextPattern.")
                Return
            End If

            Dim oAttribute As Object = textpatternPattern.DocumentRange.GetAttributeValue(TextPattern.StrikethroughColorAttribute)
            If (oAttribute = TextPattern.MixedAttributeValue) Then
                Console.WriteLine("Mixed strikethrough colors.")
            Else
                Console.WriteLine(oAttribute.ToString())
            End If
        End Sub
        ' </Snippet2038>
        ' <Snippet2039>
        Private Sub GetStrikethroughStyleAttribute()
            ' Start application.
            Dim p As Process = Process.Start("Notepad.exe", "text.txt")

            ' target --> The root AutomationElement.
            Dim target As AutomationElement = AutomationElement.FromHandle(p.MainWindowHandle)

            ' Specify the control type we're looking for, in this case 'Document'
            Dim cond As PropertyCondition = New PropertyCondition(AutomationElement.ControlTypeProperty, ControlType.Document)

            Dim textProvider As AutomationElement = target.FindFirst(TreeScope.Descendants, cond)

            Dim textpatternPattern As TextPattern = CType(textProvider.GetCurrentPattern(TextPattern.Pattern), TextPattern)

            If (textpatternPattern Is Nothing) Then
                Console.WriteLine("Root element does not contain a descendant that supports TextPattern.")
                Return
            End If

            Dim oAttribute As Object = textpatternPattern.DocumentRange.GetAttributeValue(TextPattern.StrikethroughStyleAttribute)
            If (oAttribute = TextPattern.MixedAttributeValue) Then
                Console.WriteLine("Mixed strikethrough styles.")
            Else
                Console.WriteLine(oAttribute.ToString())
            End If
        End Sub
        ' </Snippet2039>
        ' <Snippet2040>
        Private Sub GetTabsAttribute()
            ' Start application.
            Dim p As Process = Process.Start("Notepad.exe", "text.txt")

            ' target --> The root AutomationElement.
            Dim target As AutomationElement = AutomationElement.FromHandle(p.MainWindowHandle)

            ' Specify the control type we're looking for, in this case 'Document'
            Dim cond As PropertyCondition = New PropertyCondition(AutomationElement.ControlTypeProperty, ControlType.Document)

            Dim textProvider As AutomationElement = target.FindFirst(TreeScope.Descendants, cond)

            Dim textpatternPattern As TextPattern = CType(textProvider.GetCurrentPattern(TextPattern.Pattern), TextPattern)

            If (textpatternPattern Is Nothing) Then
                Console.WriteLine("Root element does not contain a descendant that supports TextPattern.")
                Return
            End If

            Dim oAttribute As Object = textpatternPattern.DocumentRange.GetAttributeValue(TextPattern.TabsAttribute)
            If (oAttribute = TextPattern.MixedAttributeValue) Then
                Console.WriteLine("Mixed tabs.")
            Else
                Console.WriteLine(oAttribute.ToString())
            End If
        End Sub
        ' </Snippet2040>
        ' <Snippet2041>
        Private Sub GetTextFlowDirectionsAttribute()
            ' Start application.
            Dim p As Process = Process.Start("Notepad.exe", "text.txt")

            ' target --> The root AutomationElement.
            Dim target As AutomationElement = AutomationElement.FromHandle(p.MainWindowHandle)

            ' Specify the control type we're looking for, in this case 'Document'
            Dim cond As PropertyCondition = New PropertyCondition(AutomationElement.ControlTypeProperty, ControlType.Document)

            Dim textProvider As AutomationElement = target.FindFirst(TreeScope.Descendants, cond)

            Dim textpatternPattern As TextPattern = CType(textProvider.GetCurrentPattern(TextPattern.Pattern), TextPattern)

            If (textpatternPattern Is Nothing) Then
                Console.WriteLine("Root element does not contain a descendant that supports TextPattern.")
                Return
            End If

            Dim oAttribute As Object = textpatternPattern.DocumentRange.GetAttributeValue(TextPattern.TextFlowDirectionsAttribute)
            If (oAttribute = TextPattern.MixedAttributeValue) Then
                Console.WriteLine("Mixed text flow directions.")
            Else
                Console.WriteLine(oAttribute.ToString())
            End If
        End Sub
        ' </Snippet2041>
        ' <Snippet2043>
        Private Sub GetUnderlineColorAttribute()
            ' Start application.
            Dim p As Process = Process.Start("Notepad.exe", "text.txt")

            ' target --> The root AutomationElement.
            Dim target As AutomationElement = AutomationElement.FromHandle(p.MainWindowHandle)

            ' Specify the control type we're looking for, in this case 'Document'
            Dim cond As PropertyCondition = New PropertyCondition(AutomationElement.ControlTypeProperty, ControlType.Document)

            Dim textProvider As AutomationElement = target.FindFirst(TreeScope.Descendants, cond)

            Dim textpatternPattern As TextPattern = CType(textProvider.GetCurrentPattern(TextPattern.Pattern), TextPattern)

            If (textpatternPattern Is Nothing) Then
                Console.WriteLine("Root element does not contain a descendant that supports TextPattern.")
                Return
            End If

            Dim oAttribute As Object = textpatternPattern.DocumentRange.GetAttributeValue(TextPattern.UnderlineColorAttribute)
            If (oAttribute = TextPattern.MixedAttributeValue) Then
                Console.WriteLine("Mixed underline colors.")
            Else
                Console.WriteLine(oAttribute.ToString())
            End If
        End Sub
        ' </Snippet2043>
        ' <Snippet2044>
        Private Sub GetUnderlineStyleAttribute()
            ' Start application.
            Dim p As Process = Process.Start("Notepad.exe", "text.txt")

            ' target --> The root AutomationElement.
            Dim target As AutomationElement = AutomationElement.FromHandle(p.MainWindowHandle)

            ' Specify the control type we're looking for, in this case 'Document'
            Dim cond As PropertyCondition = New PropertyCondition(AutomationElement.ControlTypeProperty, ControlType.Document)

            Dim textProvider As AutomationElement = target.FindFirst(TreeScope.Descendants, cond)

            Dim textpatternPattern As TextPattern = CType(textProvider.GetCurrentPattern(TextPattern.Pattern), TextPattern)

            If (textpatternPattern Is Nothing) Then
                Console.WriteLine("Root element does not contain a descendant that supports TextPattern.")
                Return
            End If

            Dim oAttribute As Object = textpatternPattern.DocumentRange.GetAttributeValue(TextPattern.UnderlineStyleAttribute)
            If (oAttribute = TextPattern.MixedAttributeValue) Then
                Console.WriteLine("Mixed underline styles.")
            Else
                Console.WriteLine(oAttribute.ToString())
            End If
        End Sub
        ' </Snippet2044>
        '' <Snippet2045>
        'Private Sub GetVerticalTextAlignmentAttribute()
        '    ' Start application.
        '    Dim p As Process = Process.Start("Notepad.exe", "text.txt")

        '    ' target --> The root AutomationElement.
        '    Dim target As AutomationElement = AutomationElement.FromHandle(p.MainWindowHandle)

        '    ' Specify the control type we're looking for, in this case 'Document'
        '    Dim cond As PropertyCondition = New PropertyCondition(AutomationElement.ControlTypeProperty, ControlType.Document)

        '    Dim textProvider As AutomationElement = target.FindFirst(TreeScope.Descendants, cond)

        '    Dim textpatternPattern As TextPattern = CType(textProvider.GetCurrentPattern(TextPattern.Pattern), TextPattern)

        '    If (textpatternPattern Is Nothing) Then
        '        Console.WriteLine("Root element does not contain a descendant that supports TextPattern.")
        '        Return
        '    End If

        '    Dim oAttribute As Object = textpatternPattern.DocumentRange.GetAttributeValue(TextPattern.VerticalTextAlignmentAttribute)
        '    If (oAttribute = TextPattern.MixedAttributeValue) Then
        '        Console.WriteLine("Mixed vertical text alignments.")
        '    Else
        '        Console.WriteLine(oAttribute.ToString())
        '    End If
        'End Sub
        '' </Snippet2045>


        ' <Snippet1049>
        Private Function GetRangeFromPoint() As TextPatternRange
            Return targetTextPattern.RangeFromPoint( _
            _root.Current.BoundingRectangle.TopLeft)
        End Function
        ' </Snippet1049>
        '' <Snippet2051>
        'Private Sub GetSupportsTextSelection()
        '    Dim textpatternPattern As TextPattern
        '    Dim p As Process = Process.Start("Notepad.exe")
        '    Dim target As AutomationElement = AutomationElement.FromHandle(p.MainWindowHandle)
        '    Dim cond As PropertyCondition = New PropertyCondition(AutomationElement.ControlTypeProperty, ControlType.Document)

        '    Dim textProvider As AutomationElement = target.FindFirst(TreeScope.Descendants, cond)

        '    textpatternPattern = CType(textProvider.GetCurrentPattern(TextPattern.Pattern), TextPattern)

        '    Dim bSupportsTextSelection As Boolean = textpatternPattern.SupportsTextSelection
        'End Sub
        '' </Snippet2051>

        ' <Snippet2046>
        Private Function CurrentSelection(ByVal target As AutomationElement) As TextPatternRange
            ' Specify the control type we're looking for, in this case 'Document'
            Dim cond As PropertyCondition = New PropertyCondition(AutomationElement.ControlTypeProperty, ControlType.Document)

            ' target --> The root AutomationElement.
            Dim textProvider As AutomationElement = target.FindFirst(TreeScope.Descendants, cond)

            Dim textpatternPattern As TextPattern = CType(textProvider.GetCurrentPattern(TextPattern.Pattern), TextPattern)

            If (textpatternPattern Is Nothing) Then
                Console.WriteLine("Root element does not contain a descendant that supports TextPattern.")
                Return Nothing
            End If
            Dim currentTextSelection As TextPatternRange() = textpatternPattern.GetSelection()
            Return currentTextSelection(0)
        End Function
        ' </Snippet2046>

        ' <SnippetVisibleRanges>
        Private Function CurrentVisibleRanges(ByVal target As AutomationElement) As TextPatternRange()
            ' Specify the control type we're looking for, in this case 'Document'
            Dim cond As PropertyCondition = New PropertyCondition(AutomationElement.ControlTypeProperty, ControlType.Document)

            ' target --> The root AutomationElement.
            Dim textProvider As AutomationElement = target.FindFirst(TreeScope.Descendants, cond)

            Dim textpatternPattern As TextPattern = CType(textProvider.GetCurrentPattern(TextPattern.Pattern), TextPattern)

            If (textpatternPattern Is Nothing) Then
                Console.WriteLine("Root element does not contain a descendant that supports TextPattern.")
                Return Nothing
            End If

            Return textpatternPattern.GetVisibleRanges()
        End Function
        ' </SnippetVisibleRanges>

        ' <Snippet2060>
        Private Function CloneSelection(ByVal target As AutomationElement) As TextPatternRange
            ' Specify the control type we're looking for, in this case 'Document'
            Dim cond As PropertyCondition = New PropertyCondition(AutomationElement.ControlTypeProperty, ControlType.Document)

            ' target --> The root AutomationElement.
            Dim textProvider As AutomationElement = target.FindFirst(TreeScope.Descendants, cond)

            Dim textpatternPattern As TextPattern = CType(textProvider.GetCurrentPattern(TextPattern.Pattern), TextPattern)

            If (textpatternPattern Is Nothing) Then
                Console.WriteLine("Root element does not contain a descendant that supports TextPattern.")
                Return Nothing
            End If
            Dim currentSelection As TextPatternRange() = textpatternPattern.GetSelection()
            Return currentSelection.Clone(0)
        End Function
        ' </Snippet2060>
        ' <Snippet2061>
        Private Function CompareRanges(ByVal target As AutomationElement) As Boolean
            ' Specify the control type we're looking for, in this case 'Document'
            Dim cond As PropertyCondition = New PropertyCondition(AutomationElement.ControlTypeProperty, ControlType.Document)

            ' target --> The root AutomationElement.
            Dim textProvider As AutomationElement = target.FindFirst(TreeScope.Descendants, cond)

            Dim textpatternPattern As TextPattern = CType(textProvider.GetCurrentPattern(TextPattern.Pattern), TextPattern)

            If (textpatternPattern Is Nothing) Then
                Console.WriteLine("Root element does not contain a descendant that supports TextPattern.")
                Return Nothing
            End If
            Dim currentSelection As TextPatternRange() = textpatternPattern.GetSelection()
            Dim currentVisibleRange As TextPatternRange() = textpatternPattern.GetVisibleRanges()
            Return currentSelection(0).Compare(currentVisibleRange(0))
        End Function
        ' </Snippet2061>
        ' <Snippet2062>
        Private Function CompareRangeEndpoints(ByVal target As AutomationElement) As Integer
            ' Specify the control type we're looking for, in this case 'Document'
            Dim cond As PropertyCondition = New PropertyCondition(AutomationElement.ControlTypeProperty, ControlType.Document)

            ' target --> The root AutomationElement.
            Dim textProvider As AutomationElement = target.FindFirst(TreeScope.Descendants, cond)

            Dim textpatternPattern As TextPattern = CType(textProvider.GetCurrentPattern(TextPattern.Pattern), TextPattern)

            If (textpatternPattern Is Nothing) Then
                Console.WriteLine("Root element does not contain a descendant that supports TextPattern.")
                Return Nothing
            End If
            Dim currentSelection As TextPatternRange() = textpatternPattern.GetSelection()
            Dim currentVisibleRanges As TextPatternRange() = textpatternPattern.GetVisibleRanges()
            Return currentSelection(0).CompareEndpoints(TextPatternRangeEndpoint.Start, _
                                                 currentVisibleRanges(0), _
                                                 TextPatternRangeEndpoint.Start)
        End Function
        ' </Snippet2062>
        ' <Snippet2063>
        Private Sub ExpandSelection(ByVal target As AutomationElement)
            ' Specify the control type we're looking for, in this case 'Document'
            Dim cond As PropertyCondition = New PropertyCondition(AutomationElement.ControlTypeProperty, ControlType.Document)

            ' target --> The root AutomationElement.
            Dim textProvider As AutomationElement = target.FindFirst(TreeScope.Descendants, cond)

            Dim textpatternPattern As TextPattern = CType(textProvider.GetCurrentPattern(TextPattern.Pattern), TextPattern)

            If (textpatternPattern Is Nothing) Then
                Console.WriteLine("Root element does not contain a descendant that supports TextPattern.")
                Return
            End If
            Dim currentSelection As TextPatternRange() = textpatternPattern.GetSelection()
            currentSelection(0).ExpandToEnclosingUnit(TextUnit.Document)
        End Sub
        ' </Snippet2063>
        ' <Snippet2064>
        Private Function RangeFromAttribute(ByVal target As AutomationElement) As TextPatternRange
            ' Specify the control type we're looking for, in this case 'Document'
            Dim cond As PropertyCondition = New PropertyCondition(AutomationElement.ControlTypeProperty, ControlType.Document)

            ' target --> The root AutomationElement.
            Dim textProvider As AutomationElement = target.FindFirst(TreeScope.Descendants, cond)

            Dim textpatternPattern As TextPattern = CType(textProvider.GetCurrentPattern(TextPattern.Pattern), TextPattern)

            If (textpatternPattern Is Nothing) Then
                Console.WriteLine("Root element does not contain a descendant that supports TextPattern.")
                Return Nothing
            End If
            Dim currentSelection As TextPatternRange() = textpatternPattern.GetSelection()
            Return currentSelection(0).FindAttribute(TextPattern.IsItalicAttribute, True, False)
        End Function
        ' </Snippet2064>
        ' <Snippet2065>
        Private Function TextFromSelection(ByVal target As AutomationElement) As TextPatternRange
            ' Specify the control type we're looking for, in this case 'Document'
            Dim cond As PropertyCondition = New PropertyCondition(AutomationElement.ControlTypeProperty, ControlType.Document)

            ' target --> The root AutomationElement.
            Dim textProvider As AutomationElement = target.FindFirst(TreeScope.Descendants, cond)

            Dim textpatternPattern As TextPattern = CType(textProvider.GetCurrentPattern(TextPattern.Pattern), TextPattern)

            If (textpatternPattern Is Nothing) Then
                Console.WriteLine("Root element does not contain a descendant that supports TextPattern.")
                Return Nothing
            End If
            Dim currentSelection As TextPatternRange() = textpatternPattern.GetSelection()
            ' Find 'text' in selection range
            Return currentSelection(0).FindText("text", False, True)
        End Function
        ' </Snippet2065>
        ' <Snippet2066>
        Private Function AttributeValueFromSelection(ByVal target As AutomationElement) As Object
            ' Specify the control type we're looking for, in this case 'Document'
            Dim cond As PropertyCondition = New PropertyCondition(AutomationElement.ControlTypeProperty, ControlType.Document)

            ' target --> The root AutomationElement.
            Dim textProvider As AutomationElement = target.FindFirst(TreeScope.Descendants, cond)

            Dim textpatternPattern As TextPattern = CType(textProvider.GetCurrentPattern(TextPattern.Pattern), TextPattern)

            If (textpatternPattern Is Nothing) Then
                Console.WriteLine("Root element does not contain a descendant that supports TextPattern.")
                Return Nothing
            End If
            Dim currentSelection As TextPatternRange() = textpatternPattern.GetSelection()
            ' Is 'italic'?
            Return currentSelection(0).GetAttributeValue(TextPattern.IsItalicAttribute)
        End Function
        ' </Snippet2066>
        ' <Snippet2067>
        Private Function BoundingRectanglesFromSelection(ByVal target As AutomationElement) As Rect()
            ' Specify the control type we're looking for, in this case 'Document'
            Dim cond As PropertyCondition = New PropertyCondition(AutomationElement.ControlTypeProperty, ControlType.Document)

            ' target --> The root AutomationElement.
            Dim textProvider As AutomationElement = target.FindFirst(TreeScope.Descendants, cond)

            Dim textpatternPattern As TextPattern = CType(textProvider.GetCurrentPattern(TextPattern.Pattern), TextPattern)

            If (textpatternPattern Is Nothing) Then
                Console.WriteLine("Root element does not contain a descendant that supports TextPattern.")
                Return Nothing
            End If
            Dim currentSelection As TextPatternRange() = textpatternPattern.GetSelection()
            Return currentSelection(0).GetBoundingRectangles()
        End Function
        ' </Snippet2067>
        ' <SnippetGetEmbeddedObjects>
        ''' -------------------------------------------------------------------
        ''' <summary>
        ''' Retrieves the embedded children of a document control.
        ''' </summary>
        ''' <param name="targetTextElement">
        ''' The AutomationElement. representing a text control.
        ''' </param>
        ''' -------------------------------------------------------------------
        Private Sub GetEmbeddedObjects( _
        ByVal targetTextElement As AutomationElement)
            Dim textPattern As TextPattern = _
            DirectCast(targetTextElement.GetCurrentPattern(textPattern.Pattern), TextPattern)

            If (textPattern Is Nothing) Then
                ' Target control doesn't support TextPattern.
                Return
            End If

            ' Obtain a text range spanning the entire document.
            Dim textRange As TextPatternRange = textPattern.DocumentRange

            ' Retrieve the embedded objects within the range.
            Dim embeddedObjects() As AutomationElement = textRange.GetChildren()

            Dim embeddedObject As AutomationElement
            For Each embeddedObject In embeddedObjects
                Console.WriteLine(embeddedObject.Current.Name)
            Next
        End Sub
        ' </SnippetGetEmbeddedObjects>

        ' <SnippetGetRangeFromChild>
        ''' -------------------------------------------------------------------
        ''' <summary>
        ''' Obtains a text range spanning an embedded child 
        ''' of a document control and displays the content of the range.
        ''' </summary>
        ''' <param name="targetTextElement">
        ''' The AutomationElement. representing a text control.
        ''' </param>
        ''' -------------------------------------------------------------------
        Private Sub GetRangeFromChild( _
        ByVal targetTextElement As AutomationElement)
            Dim textPattern As TextPattern = _
            DirectCast( _
            targetTextElement.GetCurrentPattern(textPattern.Pattern), _
            TextPattern)

            If (textPattern Is Nothing) Then
                ' Target control doesn't support TextPattern.
                Return
            End If

            ' Obtain a text range spanning the entire document.
            Dim textRange As TextPatternRange = textPattern.DocumentRange

            ' Retrieve the embedded objects within the range.
            Dim embeddedObjects() As AutomationElement = textRange.GetChildren()

            Dim embeddedObject As AutomationElement
            For Each embeddedObject In embeddedObjects
                If (embeddedObject.GetCurrentPropertyValue( _
                    AutomationElement.IsTextPatternAvailableProperty) = True) Then
                    ' For full functionality a secondary TextPattern should
                    ' be obtained from the embedded object.
                    ' embeddedObject must be a child of the text provider.
                    Dim embeddedObjectRange As TextPatternRange = _
                    textPattern.RangeFromChild(embeddedObject)
                    ' GetText(-1) retrieves all text in the range.
                    ' Typically a more limited amount of text would be 
                    ' retrieved for performance and security reasons.
                    Console.WriteLine(embeddedObjectRange.GetText(-1))
                End If
            Next
        End Sub
        ' </SnippetGetRangeFromChild>

        ' <Snippet2069>
        Private Function EnclosingElementFromSelection(ByVal target As AutomationElement) As AutomationElement
            ' Specify the control type we're looking for, in this case 'Document'
            Dim cond As PropertyCondition = New PropertyCondition(AutomationElement.ControlTypeProperty, ControlType.Document)

            ' target --> The root AutomationElement.
            Dim textProvider As AutomationElement = target.FindFirst(TreeScope.Descendants, cond)

            Dim textpatternPattern As TextPattern = CType(textProvider.GetCurrentPattern(TextPattern.Pattern), TextPattern)

            If (textpatternPattern Is Nothing) Then
                Console.WriteLine("Root element does not contain a descendant that supports TextPattern.")
                Return Nothing
            End If
            Dim currentSelection As TextPatternRange() = textpatternPattern.GetSelection()
            Return currentSelection(0).GetEnclosingElement()
        End Function
        ' </Snippet2069>
        ' <Snippet2070>
        Private Function TextFromSelection(ByVal target As AutomationElement, ByVal length As Int32) As String
            ' Specify the control type we're looking for, in this case 'Document'
            Dim cond As PropertyCondition = New PropertyCondition(AutomationElement.ControlTypeProperty, ControlType.Document)

            ' target --> The root AutomationElement.
            Dim textProvider As AutomationElement = target.FindFirst(TreeScope.Descendants, cond)

            Dim textpatternPattern As TextPattern = CType(textProvider.GetCurrentPattern(TextPattern.Pattern), TextPattern)

            If (textpatternPattern Is Nothing) Then
                Console.WriteLine("Root element does not contain a descendant that supports TextPattern.")
                Return Nothing
            End If
            Dim currentSelection As TextPatternRange() = textpatternPattern.GetSelection()
            ' GetText(-1) retrieves all characters but can be inefficient
            Return currentSelection(0).GetText(length)
        End Function
        ' </Snippet2070>
        ' <SnippetMoveSelection>
        ''' -------------------------------------------------------------------
        ''' <summary>
        ''' Moves a text range a specified number of text units.
        ''' </summary>
        ''' <param name="targetTextElement">
        ''' The AutomationElement that represents a text control.
        ''' </param>
        ''' <param name="textUnit">
        ''' The text unit value.
        ''' </param>
        ''' <param name="units">
        ''' The number of text units to move.
        ''' </param>
        ''' <param name="direction">
        ''' Direction to move the text range. Valid values are -1, 0, 1.
        ''' </param>
        ''' <returns>
        ''' The number of text units actually moved. This can be less than the 
        ''' number requested if either of the new text range endpoints is 
        ''' greater than or less than the DocumentRange endpoints. 
        ''' </returns>
        ''' <remarks>
        ''' Moving the text range does not modify the text source in any way. 
        ''' Only the text range starting and ending endpoints are modified.
        ''' </remarks>
        ''' -------------------------------------------------------------------
        Private Function MoveSelection( _
            ByVal targetTextElement As AutomationElement, _
            ByVal textUnit As TextUnit, _
            ByVal units As Integer, _
            ByVal direction As Integer) As Integer

            Dim textPattern As TextPattern = _
            DirectCast( _
            targetTextElement.GetCurrentPattern(textPattern.Pattern), _
            TextPattern)

            If (textPattern Is Nothing) Then
                ' Target control doesn't support TextPattern.
                Return -1
            End If

            Dim currentSelection As TextPatternRange() = _
            textPattern.GetSelection()

            If (currentSelection.Length > 1) Then
                ' For this example, we cannot move more than one text range.
                Return -1
            End If

            Return currentSelection(0).Move(textUnit, Math.Sign(direction) * units)
        End Function
        ' </SnippetMoveSelection>

        ' <Snippet2072>
        Private Sub MoveEndpointByRangeFromSelection(ByVal target As AutomationElement)
            ' Specify the control type we're looking for, in this case 'Document'
            Dim cond As PropertyCondition = New PropertyCondition(AutomationElement.ControlTypeProperty, ControlType.Document)

            ' target --> The root AutomationElement.
            Dim textProvider As AutomationElement = target.FindFirst(TreeScope.Descendants, cond)

            Dim textpatternPattern As TextPattern = CType(textProvider.GetCurrentPattern(TextPattern.Pattern), TextPattern)

            If (textpatternPattern Is Nothing) Then
                Console.WriteLine("Root element does not contain a descendant that supports TextPattern.")
                Return
            End If
            Dim currentSelection As TextPatternRange() = textpatternPattern.GetSelection()
            Dim currentVisibleRanges As TextPatternRange() = textpatternPattern.GetVisibleRanges()
            currentSelection(0).MoveEndpointByRange(TextPatternRangeEndpoint.Start, _
                                             currentVisibleRanges(0), _
                                             TextPatternRangeEndpoint.Start)
        End Sub
        ' </Snippet2072>
        ' <Snippet2073>
        Private Function MoveEndpointByRangeFromSelection(ByVal target As AutomationElement, ByVal units As Int32) As Int32
            ' Specify the control type we're looking for, in this case 'Document'
            Dim cond As PropertyCondition = New PropertyCondition(AutomationElement.ControlTypeProperty, ControlType.Document)

            ' target --> The root AutomationElement.
            Dim textProvider As AutomationElement = target.FindFirst(TreeScope.Descendants, cond)

            Dim textpatternPattern As TextPattern = CType(textProvider.GetCurrentPattern(TextPattern.Pattern), TextPattern)

            If (textpatternPattern Is Nothing) Then
                Console.WriteLine("Root element does not contain a descendant that supports TextPattern.")
                Return Nothing
            End If
            Dim currentSelection As TextPatternRange() = textpatternPattern.GetSelection()
            ' GetText(-1) retrieves all characters but can be inefficient
            Return currentSelection(0).MoveEndpointByUnit(TextPatternRangeEndpoint.Start, TextUnit.Paragraph, units)
        End Function
        ' </Snippet2073>
        ' <Snippet2074>
        Private Sub ScrollToSelection(ByVal target As AutomationElement)
            ' Specify the control type we're looking for, in this case 'Document'
            Dim cond As PropertyCondition = New PropertyCondition(AutomationElement.ControlTypeProperty, ControlType.Document)

            ' target --> The root AutomationElement.
            Dim textProvider As AutomationElement = target.FindFirst(TreeScope.Descendants, cond)

            Dim textpatternPattern As TextPattern = CType(textProvider.GetCurrentPattern(TextPattern.Pattern), TextPattern)

            If (textpatternPattern Is Nothing) Then
                Console.WriteLine("Root element does not contain a descendant that supports TextPattern.")
                Return
            End If
            Dim currentSelection As TextPatternRange() = textpatternPattern.GetSelection()
            currentSelection(0).ScrollIntoView(True)
        End Sub
        ' </Snippet2074>
        ' <Snippet2075>
        Private Sub SetSelection(ByVal target As AutomationElement, ByVal s As String, ByVal backward As Boolean, ByVal ignorecase As Boolean)
            ' Specify the control type we're looking for, in this case 'Document'
            Dim cond As PropertyCondition = New PropertyCondition(AutomationElement.ControlTypeProperty, ControlType.Document)

            ' target --> The root AutomationElement.
            Dim textProvider As AutomationElement = target.FindFirst(TreeScope.Descendants, cond)

            Dim textpatternPattern As TextPattern = CType(textProvider.GetCurrentPattern(TextPattern.Pattern), TextPattern)

            If (textpatternPattern Is Nothing) Then
                Console.WriteLine("Root element does not contain a descendant that supports TextPattern.")
                Return
            End If
            Dim currentSelection As TextPatternRange() = textpatternPattern.GetSelection()
            Dim selectedText As TextPatternRange = currentSelection(0).FindText(s, backward, ignorecase)
            selectedText.Select()
        End Sub
        ' </Snippet2075>
        ' <Snippet2076>
        Private Function TextPatternFromSelection(ByVal target As AutomationElement) As TextPattern
            ' Specify the control type we're looking for, in this case 'Document'
            Dim cond As PropertyCondition = New PropertyCondition(AutomationElement.ControlTypeProperty, ControlType.Document)

            ' target --> The root AutomationElement.
            Dim textProvider As AutomationElement = target.FindFirst(TreeScope.Descendants, cond)

            Dim textpatternPattern As TextPattern = CType(textProvider.GetCurrentPattern(TextPattern.Pattern), TextPattern)

            If (textpatternPattern Is Nothing) Then
                Console.WriteLine("Root element does not contain a descendant that supports TextPattern.")
                Return Nothing
            End If
            Dim currentSelection As TextPatternRange() = textpatternPattern.GetSelection()
            Return currentSelection(0).TextPattern
        End Function
        ' </Snippet2076>

    End Class

End Namespace

