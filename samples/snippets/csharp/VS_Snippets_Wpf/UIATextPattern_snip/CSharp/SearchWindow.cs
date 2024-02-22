/*****************************************************************************************
 * File: FindText.cs
 *
 * Description:
 *    This sample opens a 'canned' text file (Text.txt) in Notepad and shows how to use
 *    UI Automation to find/select text and track text selection changes in the Notepad instance.
 *
 *    Text.txt should be automatically copied to the same folder as the executable when
 *    you build the sample. You may have to manually copy this file if you receive an error
 *    stating the file cannot be found.
 *
 * Programming Elements:
 *    This sample demonstrates the following UI Automation programming elements from...
 *
 *       System.Windows.Automation Namespace:
 *         Automation Class
 *           AddAutomationEventHandler
 *           AddAutomationPropertyChangedEventHandler
 *         WindowPattern Class
 *           WindowClosedEvent field
 *         AutomationPattern Class
 *         AutomationEventHandler Delegate
 *         AutomationElement Class
 *           RootElement property
 *           GetCurrentPropertyValue method
 *           BoundingRectangleProperty field
 *           GetCurrentPattern method
 *           FromHandle method
 *           ControlTypeProperty field
 *           FindFirst method
 *           SetFocus method
 *         TreeScope Enumeration
 *           Element member
 *           Descendants member
 *         ControlType Class
 *           Document field
 *         TextPattern Class
 *           Pattern field
 *           TextSelectionChangedEvent field
 *           SupportsTextSelection property
 *           DocumentRange property
 *         ValuePattern Class
 *           Pattern field
 *           ValueProperty field
 *         AutomationPropertyChangedEventHandler Delegate
 *
 *       System.Windows.Automation.Searcher Namespace:
 *         PropertyCondition Class
 *
 *       System.Windows.Automation.Text Namespace:
 *         TextPatternRange Class
 *           FindText method
 *           Select method
 *         TextPatternRangeEndpoint Enumeration
 *
 *
 * This file is part of the Microsoft .NET Framework SDK Code Samples.
 *
 * Copyright (C) Microsoft Corporation.  All rights reserved.
 *
 * This source code is intended only as a supplement to Microsoft
 * Development Tools and/or on-line documentation.  See these other
 * materials for detailed information regarding Microsoft code samples.
 *
 * THIS CODE AND INFORMATION ARE PROVIDED AS IS WITHOUT WARRANTY OF ANY
 * KIND, EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE
 * IMPLIED WARRANTIES OF MERCHANTABILITY AND/OR FITNESS FOR A
 * PARTICULAR PURPOSE.
 *
 ******************************************************************************************/

using System;
using System.Windows;
using System.Windows.Documents;
using System.Windows.Automation;
using System.Windows.Controls;
using System.Diagnostics;
using System.ComponentModel;
using System.IO;
using System.Windows.Automation.Text;
using System.Threading;
using System.Windows.Threading;

namespace SDKSample
{
    public class SearchWindow
    {
        private Window _window;
        private DockPanel _dp;
        private AutomationElement _root;
        private Button _btnApp;
        private TextBlock _txtAppResult;
        private TextBox _tbSearch;
        private Button _btnSearch;
        private CheckBox _cbSearch;
        private TextBlock _txtSearchResult;
        private TextBlock _txtHighlighted;
        private TextBlock _txtHighlightResult;
        private TextPattern targetTextPattern;
        private TextPatternRange documentTextRange;
        private TextPatternRange searchTextRange;
        private Boolean _bBOD;
        private Boolean _bBackward;
        private String _sApplication = "WordPad.exe";

        // Constructor
        public SearchWindow()
        {
            try
            {
                // Specs for Window
                double wHeight = 400;
                double wWidth = 400;

                // Specs for TextBox
                int tbMaxlines = 1;
                int tbMaxlength = 25;

                // Specs for Buttons
                double dWidth = 100;

                // Instantiate your window and set location and size
                _window = new Window();
                _window.Height = wHeight;
                _window.Width = wWidth;
                _window.Left = SystemParameters.WorkArea.Location.X;
                _window.Top = SystemParameters.WorkArea.Location.Y;
                _window.Title = "Find Text";
                _window.WindowStyle = WindowStyle.ToolWindow;

                _btnApp = new Button();
                _btnApp.Width = dWidth;
                _btnApp.Content = "Start " + _sApplication;
                _btnApp.Click += new RoutedEventHandler(btnApp_Click);
                _btnApp.IsEnabled = true;

                _txtAppResult = new TextBlock();
                _txtAppResult.Text = "";
                _txtAppResult.HorizontalAlignment = HorizontalAlignment.Center;
                _txtAppResult.Margin = new Thickness(0, 10, 0, 20);

                StackPanel sp = new StackPanel();
                sp.Orientation = Orientation.Horizontal;
                sp.HorizontalAlignment = HorizontalAlignment.Center;

                TextBlock txt1 = new TextBlock();
                txt1.Text = "Search for: ";
                txt1.VerticalAlignment = VerticalAlignment.Center;

                _tbSearch = new TextBox();
                _tbSearch.MaxLines = tbMaxlines;
                _tbSearch.MaxLength = tbMaxlength;
                _tbSearch.TextChanged += new TextChangedEventHandler(tbSearch_TextChanged);
                _tbSearch.IsEnabled = false;
                _tbSearch.Margin = new Thickness(10, 0, 10, 0);

                _btnSearch = new Button();
                _btnSearch.Width = dWidth;
                _btnSearch.Content = "Highlight";
                _btnSearch.Click += new RoutedEventHandler(btnSearch_Click);
                _btnSearch.IsEnabled = false;

                _cbSearch = new CheckBox();
                _cbSearch.VerticalAlignment = VerticalAlignment.Center;
                _cbSearch.Checked += new RoutedEventHandler(cbSearch_IsCheckedChanged);
                _cbSearch.Unchecked += new RoutedEventHandler(cbSearch_IsCheckedChanged);
                _cbSearch.IsEnabled = false;
                _cbSearch.Margin = new Thickness(10, 0, 0, 0);

                TextBlock txt2 = new TextBlock();
                txt2.Text = "Reverse";
                txt2.VerticalAlignment = VerticalAlignment.Center;

                sp.Children.Add(txt1);
                sp.Children.Add(_tbSearch);
                sp.Children.Add(_btnSearch);
                sp.Children.Add(_cbSearch);
                sp.Children.Add(txt2);

                _txtSearchResult = new TextBlock();
                _txtSearchResult.Text = "";
                _txtSearchResult.HorizontalAlignment = HorizontalAlignment.Center;
                _txtSearchResult.Margin = new Thickness(0, 10, 0, 20);

                _txtHighlighted = new TextBlock();
                _txtHighlighted.Text = "Currently highlighted:";

                _txtHighlightResult = new TextBlock();
                _txtHighlightResult.Text = "";
                _txtHighlightResult.HorizontalAlignment = HorizontalAlignment.Left;
                _txtHighlightResult.Margin = new Thickness(0, 10, 0, 20);

                // Create a dockpanel to hold output
                _dp = new DockPanel();
                _dp.LastChildFill = false;
                DockPanel.SetDock(_btnApp, Dock.Top);
                _dp.Children.Add(_btnApp);
                DockPanel.SetDock(_txtAppResult, Dock.Top);
                _dp.Children.Add(_txtAppResult);
                DockPanel.SetDock(sp, Dock.Top);
                _dp.Children.Add(sp);
                DockPanel.SetDock(_txtSearchResult, Dock.Top);
                _dp.Children.Add(_txtSearchResult);
                DockPanel.SetDock(_txtHighlighted, Dock.Top);
                _dp.Children.Add(_txtHighlighted);
                DockPanel.SetDock(_txtHighlightResult, Dock.Top);
                _dp.Children.Add(_txtHighlightResult);
                _window.Content = _dp;
                _window.Show();
            }
            catch (Exception e)
            {
                Output(e.ToString());
            }
        }

        void cbSearch_IsCheckedChanged(object sender, RoutedEventArgs e)
        {
            _bBackward = (bool)_cbSearch.IsChecked;

            // Reset the document range
            // <Snippet1050>
            documentTextRange = targetTextPattern.DocumentRange;
            // </Snippet1050>

            // Re-enable search button if necessary (ie, EOD reached)
            _btnSearch.IsEnabled = true;
        }

        void btnSearch_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                // Check if search text entered
                if (_tbSearch.Text.Trim() == "")
                {
                    _txtSearchResult.Text = "No search criteria.";
                    return;
                }
                // Check if the TextPattern supports text selection
                if (targetTextPattern.SupportedTextSelection == SupportedTextSelection.None)
                {
                    _txtSearchResult.Text = "Unable to select text.";
                    return;
                }

                // Move the TextPatternRange endpoints for 'Highlight Next' functionality
                TextPatternRange[] tprSelection = targetTextPattern.GetSelection();

                if (tprSelection[0] != null)
                {
                    if (_bBackward) documentTextRange.MoveEndpointByRange(TextPatternRangeEndpoint.End, tprSelection[0], TextPatternRangeEndpoint.Start);
                    else documentTextRange.MoveEndpointByRange(TextPatternRangeEndpoint.Start, tprSelection[0], TextPatternRangeEndpoint.End);
                    _btnSearch.Content = "Highlight next";
                }

                // Find the text specified in the Search textbox
                // backward = false -- search from the start of the document range
                // ignoreCase = false -- search is case sensitive
                searchTextRange = documentTextRange.FindText(_tbSearch.Text, _bBackward, false);

                if (searchTextRange == null)
                {
                    if (!_bBOD)
                    {
                        _txtSearchResult.Text = "End of document reached.";
                        _btnSearch.IsEnabled = false;
                    }
                    else
                    {
                        _txtSearchResult.Text = "Text not found.";
                    }
                    return;
                }

                searchTextRange.Select();

                // No longer at the beginning of the TextPatternRange
                _bBOD = false;

                // Scroll the selection into view, aligning with top of viewport
                searchTextRange.ScrollIntoView(true);
                _txtSearchResult.Text = "Text found.";
            }
            catch (Exception error)
            {
                Output(error.ToString());
            }
        }

        // Reset all controls if user changes search text
        void tbSearch_TextChanged(object sender, TextChangedEventArgs e)
        {
            _btnSearch.IsEnabled = true;
            documentTextRange = targetTextPattern.DocumentRange;
        }

        // Start the text application that we are going to use for the TextPattern sample
        private void btnApp_Click(object sender, RoutedEventArgs e)
        {
            // Start notepad.exe and use it as our root element.
            // For performance reasons, it's not a good idea to start searching for UI from
            // The root unless the UI you are looking for is very near the root.
            string _sFile = System.Windows.Forms.Application.StartupPath + "\\" + "Text.txt";
            _root = StartApp(_sApplication, _sFile);
            if (_root == null)
            {
                _btnApp.IsEnabled = false;
                return;
            }
            FindEdit(_root, _sApplication, _sFile);
        }

        // Initialize our TextPattern and event handlers
        private void FindEdit(AutomationElement target, string app, string file)
        {
            try
            {
                // <Snippet1037>
                // Specify the control type we're looking for, in this case 'Document'
                PropertyCondition cond = new PropertyCondition(AutomationElement.ControlTypeProperty, ControlType.Document);

                // target --> The root AutomationElement.
                AutomationElement textProvider = target.FindFirst(TreeScope.Descendants, cond);

                targetTextPattern = textProvider.GetCurrentPattern(TextPattern.Pattern) as TextPattern;

                if (targetTextPattern == null)
                {
                    Console.WriteLine("Root element does not contain a descendant that supports TextPattern.");
                    return;
                }
                // </Snippet1037>

                _txtAppResult.Text = app + " started and identified in the UI Automation tree.";

                _btnSearch.IsEnabled = true;
                _tbSearch.IsEnabled = true;
                _btnApp.IsEnabled = false;
                _cbSearch.IsEnabled = true;

                // Initialize the document range for the text of the document
                documentTextRange = targetTextPattern.DocumentRange;

                // Beginning of document range
                _bBOD = true;
                // Search starts at end of doc and goes backward
                _bBackward = false;

                // <Snippet1052>
                AutomationEventHandler ehTextChanged = new AutomationEventHandler(onTextChange);
                Automation.AddAutomationEventHandler(TextPattern.TextChangedEvent, textProvider, TreeScope.Element, ehTextChanged);
                // </Snippet1052>
                // <Snippet1042>
                AutomationEventHandler ehTextSelection = new AutomationEventHandler(onTextSelectionChange);
                Automation.AddAutomationEventHandler(TextPattern.TextSelectionChangedEvent, textProvider, TreeScope.Element, ehTextSelection);
                // </Snippet1042>

                AutomationEventHandler ehClose = new AutomationEventHandler(onNotepadClose);
                Automation.AddAutomationEventHandler(WindowPattern.WindowClosedEvent, target, TreeScope.Element, ehClose);
            }
            catch (Win32Exception e)
            {
                Output(e.ToString());
                Output(app + " not found.");
            }
            catch (Exception e)
            {
                Output(e.ToString());
            }
        }

        // Start the application this sample uses for the TextPattern
        private AutomationElement StartApp(string app, string args)
        {
            try
            {
                if (File.Exists(args))
                {
                    // Start application.
                    Process p = Process.Start(app, args);

                    // Give application a second to startup.
                    Thread.Sleep(1000);

                    // Return the AutomationElement that represents the target main window.
                    return (AutomationElement.FromHandle(p.MainWindowHandle));
                }
                else
                {
                    throw new FileNotFoundException(args + " not found.");
                }
            }
            catch (Exception e)
            {
                Output(e.ToString());
                return (null);
            }
        }

        // Handle the TextChange event
        private void onTextChange(object sender, AutomationEventArgs e)
        {
            documentTextRange = targetTextPattern.DocumentRange;
        }

        // Handle the TextSelectChange event on the WCP thread
        private void onTextSelectionChange(object sender, AutomationEventArgs e)
        {
            _window.Dispatcher.BeginInvoke(DispatcherPriority.Background, new DispatcherOperationCallback(ChangeSelection),null);
        }

       // The delegate for the onTextSelectionChange event
        private object ChangeSelection(object arg)
        {
            TextPatternRange[] currentSelection = targetTextPattern.GetSelection();
            string selectionText = currentSelection[0].GetText(-1);
            _txtHighlighted.Text = "Currently highlighted: (" + selectionText.Length.ToString() + " chars)\n";

            Object oAttribute = currentSelection[0].GetAttributeValue(TextPattern.FontNameAttribute);
            if (oAttribute == TextPattern.MixedAttributeValue)
            {
                // Fontface: Mixed
            }
            else
            {
                // Fontface: _oAttribute.ToString();
            }

            _txtHighlightResult.Text = selectionText;
            selectionText = currentSelection[0].GetText(-1);

            return (null);
        }

        // Handle the WindowClose event for the our instance of notepad on the WCP thread
        private void onNotepadClose(object sender, AutomationEventArgs e)
        {
            _window.Dispatcher.BeginInvoke(
                    DispatcherPriority.Background, new DispatcherOperationCallback(CloseApp),null);
        }

        // The delegate for the notepad close event
        private object CloseApp(object arg)
        {
            _window.Close();
            return (null);
        }

        public void Output(string s)
        {
            //TextBlock _textElement = new TextBlock();
            //_textElement.Text = s;
            //DockPanel.SetDock(_textElement, Dock.Top);
            //dp.Children.Add(_textElement);
            //Console.WriteLine(s);
            MessageBox.Show(s);
        }

        // <Snippet1000>
        private void GetAnimationStyleAttribute()
        {
            // Start application.
            Process p = Process.Start("Notepad.exe","text.txt");

            // target --> The root AutomationElement.
            AutomationElement target = AutomationElement.FromHandle(p.MainWindowHandle);

            // Specify the control type we're looking for, in this case 'Document'
            PropertyCondition cond = new PropertyCondition(AutomationElement.ControlTypeProperty, ControlType.Document);

            AutomationElement textProvider = target.FindFirst(TreeScope.Descendants, cond);

            TextPattern textpatternPattern = textProvider.GetCurrentPattern(TextPattern.Pattern) as TextPattern;

            if (textpatternPattern == null)
            {
                Console.WriteLine("Root element does not contain a descendant that supports TextPattern.");
                return;
            }

            Object oAttribute = textpatternPattern.DocumentRange.GetAttributeValue(TextPattern.AnimationStyleAttribute);
            if (oAttribute == TextPattern.MixedAttributeValue)
            {
                Console.WriteLine("Mixed animation styles.");
            }
            else
            {
                Console.WriteLine(oAttribute.ToString());
            }
        }
        // </Snippet1000>
        // <Snippet1001>
        private void GetBackgroundColorAttribute()
        {
            // Start application.
            Process p = Process.Start("Notepad.exe", "text.txt");

            // target --> The root AutomationElement.
            AutomationElement target = AutomationElement.FromHandle(p.MainWindowHandle);

            // Specify the control type we're looking for, in this case 'Document'
            PropertyCondition cond = new PropertyCondition(AutomationElement.ControlTypeProperty, ControlType.Document);

            AutomationElement textProvider = target.FindFirst(TreeScope.Descendants, cond);

            TextPattern textpatternPattern = textProvider.GetCurrentPattern(TextPattern.Pattern) as TextPattern;

            if (textpatternPattern == null)
            {
                Console.WriteLine("Root element does not contain a descendant that supports TextPattern.");
                return;
            }

            Object oAttribute = textpatternPattern.DocumentRange.GetAttributeValue(TextPattern.BackgroundColorAttribute);
            if (oAttribute == TextPattern.MixedAttributeValue)
            {
                Console.WriteLine("Mixed background colors.");
            }
            else
            {
                Console.WriteLine(oAttribute.ToString());
            }
        }
        // </Snippet1001>

            // <Snippet1002>
        private void GetBulletStyleAttribute()
        {
            // Start application.
            Process p = Process.Start("Notepad.exe", "text.txt");

            // target --> The root AutomationElement.
            AutomationElement target = AutomationElement.FromHandle(p.MainWindowHandle);

            // Specify the control type we're looking for, in this case 'Document'
            PropertyCondition cond = new PropertyCondition(AutomationElement.ControlTypeProperty, ControlType.Document);

            AutomationElement textProvider = target.FindFirst(TreeScope.Descendants, cond);

            TextPattern textpatternPattern = textProvider.GetCurrentPattern(TextPattern.Pattern) as TextPattern;

            if (textpatternPattern == null)
            {
                Console.WriteLine("Root element does not contain a descendant that supports TextPattern.");
                return;
            }

            Object oAttribute = textpatternPattern.DocumentRange.GetAttributeValue(TextPattern.BulletStyleAttribute);
            if (oAttribute == TextPattern.MixedAttributeValue)
            {
                Console.WriteLine("Mixed bullet styles.");
            }
            else
            {
                Console.WriteLine(oAttribute.ToString());
            }
        }
            // </Snippet1002>

            // <Snippet1003>
        private void GetCapStyleAttribute()
        {
            // Start application.
            Process p = Process.Start("Notepad.exe", "text.txt");

            // target --> The root AutomationElement.
            AutomationElement target = AutomationElement.FromHandle(p.MainWindowHandle);

            // Specify the control type we're looking for, in this case 'Document'
            PropertyCondition cond = new PropertyCondition(AutomationElement.ControlTypeProperty, ControlType.Document);

            AutomationElement textProvider = target.FindFirst(TreeScope.Descendants, cond);

            TextPattern textpatternPattern = textProvider.GetCurrentPattern(TextPattern.Pattern) as TextPattern;

            if (textpatternPattern == null)
            {
                Console.WriteLine("Root element does not contain a descendant that supports TextPattern.");
                return;
            }

            Object oAttribute = textpatternPattern.DocumentRange.GetAttributeValue(TextPattern.CapStyleAttribute);
            if (oAttribute == TextPattern.MixedAttributeValue)
            {
                Console.WriteLine("Mixed cap styles.");
            }
            else
            {
                Console.WriteLine(oAttribute.ToString());
            }
        }
            // </Snippet1003>
        //    // <Snippet1004>
        //private void GetCompositionStateAttribute()
        //{
        //    // Start application.
        //    Process p = Process.Start("Notepad.exe", "text.txt");

        //    // target --> The root AutomationElement.
        //    AutomationElement target = AutomationElement.FromHandle(p.MainWindowHandle);

        //    // Specify the control type we're looking for, in this case 'Document'
        //    PropertyCondition cond = new PropertyCondition(AutomationElement.ControlTypeProperty, ControlType.Document);

        //    AutomationElement textProvider = target.FindFirst(TreeScope.Descendants, cond);

        //    TextPattern textpatternPattern = textProvider.GetCurrentPattern(TextPattern.Pattern) as TextPattern;

        //    if (textpatternPattern == null)
        //    {
        //        Console.WriteLine("Root element does not contain a descendant that supports TextPattern.");
        //        return;
        //    }

        //    Object oAttribute = textpatternPattern.DocumentRange.GetAttributeValue(TextPattern.CompositionStateAttribute);
        //    if (oAttribute == TextPattern.MixedAttributeValue)
        //    {
        //        Console.WriteLine("Mixed composition states.");
        //    }
        //    else
        //    {
        //        Console.WriteLine(oAttribute.ToString());
        //    }
        //}
        //    // </Snippet1004>
            // <Snippet1005>
        private void GetCultureAttribute()
        {
            // Start application.
            Process p = Process.Start("Notepad.exe", "text.txt");

            // target --> The root AutomationElement.
            AutomationElement target = AutomationElement.FromHandle(p.MainWindowHandle);

            // Specify the control type we're looking for, in this case 'Document'
            PropertyCondition cond = new PropertyCondition(AutomationElement.ControlTypeProperty, ControlType.Document);

            AutomationElement textProvider = target.FindFirst(TreeScope.Descendants, cond);

            TextPattern textpatternPattern = textProvider.GetCurrentPattern(TextPattern.Pattern) as TextPattern;

            if (textpatternPattern == null)
            {
                Console.WriteLine("Root element does not contain a descendant that supports TextPattern.");
                return;
            }

            Object oAttribute = textpatternPattern.DocumentRange.GetAttributeValue(TextPattern.CultureAttribute);
            if (oAttribute == TextPattern.MixedAttributeValue)
            {
                Console.WriteLine("Mixed culture info.");
            }
            else
            {
                Console.WriteLine(oAttribute.ToString());
            }
        }
            // </Snippet1005>
        // <SnippetStartTarget>
        /// -------------------------------------------------------------------
        /// <summary>
        /// Starts the target application and returns the AutomationElement
        /// obtained from the targets window handle.
        /// </summary>
        /// <param name="exe">
        /// The target application.
        /// </param>
        /// <param name="filename">
        /// The text file to be opened in the target application
        /// </param>
        /// <returns>
        /// An AutomationElement representing the target application.
        /// </returns>
        /// -------------------------------------------------------------------
        private AutomationElement StartTarget(string exe, string filename)
        {
            // Start text editor and load with a text file.
            Process p = Process.Start(exe, filename);

            // targetApp --> the root AutomationElement.
            AutomationElement targetApp =
                AutomationElement.FromHandle(p.MainWindowHandle);

            return targetApp;
        }
        // </SnippetStartTarget>

        // <SnippetGetTextElement>
        /// -------------------------------------------------------------------
        /// <summary>
        /// Obtain the text control of interest from the target application.
        /// </summary>
        /// <param name="targetApp">
        /// The target application.
        /// </param>
        /// <returns>
        /// An AutomationElement that represents a text provider..
        /// </returns>
        /// -------------------------------------------------------------------
        private AutomationElement GetTextElement(AutomationElement targetApp)
        {
            // The control type we're looking for; in this case 'Document'
            PropertyCondition cond1 =
                new PropertyCondition(
                AutomationElement.ControlTypeProperty,
                ControlType.Document);

            // The control pattern of interest; in this case 'TextPattern'.
            PropertyCondition cond2 =
                new PropertyCondition(
                AutomationElement.IsTextPatternAvailableProperty,
                true);

            AndCondition textCondition = new AndCondition(cond1, cond2);

            AutomationElement targetTextElement =
                targetApp.FindFirst(TreeScope.Descendants, textCondition);

            // If targetText is null then a suitable text control was not found.
            return targetTextElement;
        }
        // </SnippetGetTextElement>

        // <SnippetFontName>
        /// -------------------------------------------------------------------
        /// <summary>
        /// Outputs the FontNameAttribute value for a range of text.
        /// </summary>
        /// <param name="targetTextElement">
        /// The AutomationElement that represents a text control.
        /// </param>
        /// -------------------------------------------------------------------
        private void GetFontNameAttribute(AutomationElement targetTextElement)
        {
            TextPattern textPattern =
                targetTextElement.GetCurrentPattern(TextPattern.Pattern) as TextPattern;

            if (textPattern == null)
            {
                // Target control doesn't support TextPattern.
                return;
            }

            // If the target control doesn't support selection then return.
            // Otherwise, get the text attribute for the selected text.
            // If there are currently no selections then the text attribute
            // will be obtained from the insertion point.
            TextPatternRange[] textRanges;
            if (textPattern.SupportedTextSelection == SupportedTextSelection.None)
            {
                return;
            }
            else
            {
                textRanges = textPattern.GetSelection();
            }

            foreach (TextPatternRange textRange in textRanges)
            {
                Object textAttribute =
                    textRange.GetAttributeValue(
                    TextPattern.FontNameAttribute);

                if (textAttribute == TextPattern.MixedAttributeValue)
                {
                    // Returns MixedAttributeValue if the value of the
                    // specified attribute varies over the text range.
                    Console.WriteLine("Mixed fonts.");
                }
                else if (textAttribute == AutomationElement.NotSupported)
                {
                    // Returns NotSupported if the specified attribute is
                    // not supported by the provider or the control.
                    Console.WriteLine(
                        "FontNameAttribute not supported by provider.");
                }
                else
                {
                    Console.WriteLine(textAttribute.ToString());
                }
            }
        }
        // </SnippetFontName>

            // <Snippet1007>
        private void GetFontSizeAttribute()
        {
            // Start application.
            Process p = Process.Start("Notepad.exe", "text.txt");

            // target --> The root AutomationElement.
            AutomationElement target = AutomationElement.FromHandle(p.MainWindowHandle);

            // Specify the control type we're looking for, in this case 'Document'
            PropertyCondition cond = new PropertyCondition(AutomationElement.ControlTypeProperty, ControlType.Document);

            AutomationElement textProvider = target.FindFirst(TreeScope.Descendants, cond);

            TextPattern textpatternPattern = textProvider.GetCurrentPattern(TextPattern.Pattern) as TextPattern;

            if (textpatternPattern == null)
            {
                Console.WriteLine("Root element does not contain a descendant that supports TextPattern.");
                return;
            }

            Object oAttribute = textpatternPattern.DocumentRange.GetAttributeValue(TextPattern.FontSizeAttribute);
            if (oAttribute == TextPattern.MixedAttributeValue)
            {
                Console.WriteLine("Mixed font sizes.");
            }
            else
            {
                Console.WriteLine(oAttribute.ToString());
            }
        }
            // </Snippet1007>
            // <Snippet1008>
        private void GetFontWeightAttribute()
        {
            // Start application.
            Process p = Process.Start("Notepad.exe", "text.txt");

            // target --> The root AutomationElement.
            AutomationElement target = AutomationElement.FromHandle(p.MainWindowHandle);

            // Specify the control type we're looking for, in this case 'Document'
            PropertyCondition cond = new PropertyCondition(AutomationElement.ControlTypeProperty, ControlType.Document);

            AutomationElement textProvider = target.FindFirst(TreeScope.Descendants, cond);

            TextPattern textpatternPattern = textProvider.GetCurrentPattern(TextPattern.Pattern) as TextPattern;

            if (textpatternPattern == null)
            {
                Console.WriteLine("Root element does not contain a descendant that supports TextPattern.");
                return;
            }

            Object oAttribute = textpatternPattern.DocumentRange.GetAttributeValue(TextPattern.FontWeightAttribute);
            if (oAttribute == TextPattern.MixedAttributeValue)
            {
                Console.WriteLine("Mixed font weights.");
            }
            else
            {
                Console.WriteLine(oAttribute.ToString());
            }
        }
            // </Snippet1008>
            // <Snippet1009>
        private void GetForegroundColorAttribute()
        {
            // Start application.
            Process p = Process.Start("Notepad.exe", "text.txt");

            // target --> The root AutomationElement.
            AutomationElement target = AutomationElement.FromHandle(p.MainWindowHandle);

            // Specify the control type we're looking for, in this case 'Document'
            PropertyCondition cond = new PropertyCondition(AutomationElement.ControlTypeProperty, ControlType.Document);

            AutomationElement textProvider = target.FindFirst(TreeScope.Descendants, cond);

            TextPattern textpatternPattern = textProvider.GetCurrentPattern(TextPattern.Pattern) as TextPattern;

            if (textpatternPattern == null)
            {
                Console.WriteLine("Root element does not contain a descendant that supports TextPattern.");
                return;
            }

            Object oAttribute = textpatternPattern.DocumentRange.GetAttributeValue(TextPattern.ForegroundColorAttribute);
            if (oAttribute == TextPattern.MixedAttributeValue)
            {
                Console.WriteLine("Mixed foreground colors.");
            }
            else
            {
                Console.WriteLine(oAttribute.ToString());
            }
        }
            // </Snippet1009>
        //    // <Snippet1010>
        //private void GetHeadingLevelAttribute()
        //{
        //    // Start application.
        //    Process p = Process.Start("Notepad.exe", "text.txt");

        //    // target --> The root AutomationElement.
        //    AutomationElement target = AutomationElement.FromHandle(p.MainWindowHandle);

        //    // Specify the control type we're looking for, in this case 'Document'
        //    PropertyCondition cond = new PropertyCondition(AutomationElement.ControlTypeProperty, ControlType.Document);

        //    AutomationElement textProvider = target.FindFirst(TreeScope.Descendants, cond);

        //    TextPattern textpatternPattern = textProvider.GetCurrentPattern(TextPattern.Pattern) as TextPattern;

        //    if (textpatternPattern == null)
        //    {
        //        Console.WriteLine("Root element does not contain a descendant that supports TextPattern.");
        //        return;
        //    }

        //    Object oAttribute = textpatternPattern.DocumentRange.GetAttributeValue(TextPattern.HeadingLevelAttribute);
        //    if (oAttribute == TextPattern.MixedAttributeValue)
        //    {
        //        Console.WriteLine("Mixed heading levels.");
        //    }
        //    else
        //    {
        //        Console.WriteLine(oAttribute.ToString());
        //    }
        //}
        //    // </Snippet1010>
            // <Snippet1011>
        private void GetHorizontalTextAlignmentAttribute()
        {
            // Start application.
            Process p = Process.Start("Notepad.exe", "text.txt");

            // target --> The root AutomationElement.
            AutomationElement target = AutomationElement.FromHandle(p.MainWindowHandle);

            // Specify the control type we're looking for, in this case 'Document'
            PropertyCondition cond = new PropertyCondition(AutomationElement.ControlTypeProperty, ControlType.Document);

            AutomationElement textProvider = target.FindFirst(TreeScope.Descendants, cond);

            TextPattern textpatternPattern = textProvider.GetCurrentPattern(TextPattern.Pattern) as TextPattern;

            if (textpatternPattern == null)
            {
                Console.WriteLine("Root element does not contain a descendant that supports TextPattern.");
                return;
            }

            Object oAttribute = textpatternPattern.DocumentRange.GetAttributeValue(TextPattern.HorizontalTextAlignmentAttribute);
            if (oAttribute == TextPattern.MixedAttributeValue)
            {
                Console.WriteLine("Mixed horizontal alignments.");
            }
            else
            {
                Console.WriteLine(oAttribute.ToString());
            }
        }
            // </Snippet1011>
            // <Snippet1012>
        private void GetIndentationFirstLineAttribute()
        {
            // Start application.
            Process p = Process.Start("Notepad.exe", "text.txt");

            // target --> The root AutomationElement.
            AutomationElement target = AutomationElement.FromHandle(p.MainWindowHandle);

            // Specify the control type we're looking for, in this case 'Document'
            PropertyCondition cond = new PropertyCondition(AutomationElement.ControlTypeProperty, ControlType.Document);

            AutomationElement textProvider = target.FindFirst(TreeScope.Descendants, cond);

            TextPattern textpatternPattern = textProvider.GetCurrentPattern(TextPattern.Pattern) as TextPattern;

            if (textpatternPattern == null)
            {
                Console.WriteLine("Root element does not contain a descendant that supports TextPattern.");
                return;
            }

            Object oAttribute = textpatternPattern.DocumentRange.GetAttributeValue(TextPattern.IndentationFirstLineAttribute);
            if (oAttribute == TextPattern.MixedAttributeValue)
            {
                Console.WriteLine("Mixed first line indents.");
            }
            else
            {
                Console.WriteLine(oAttribute.ToString());
            }
        }
            // </Snippet1012>
            // <Snippet1013>
        private void GetIndentationLeadingAttribute()
        {
            // Start application.
            Process p = Process.Start("Notepad.exe", "text.txt");

            // target --> The root AutomationElement.
            AutomationElement target = AutomationElement.FromHandle(p.MainWindowHandle);

            // Specify the control type we're looking for, in this case 'Document'
            PropertyCondition cond = new PropertyCondition(AutomationElement.ControlTypeProperty, ControlType.Document);

            AutomationElement textProvider = target.FindFirst(TreeScope.Descendants, cond);

            TextPattern textpatternPattern = textProvider.GetCurrentPattern(TextPattern.Pattern) as TextPattern;

            if (textpatternPattern == null)
            {
                Console.WriteLine("Root element does not contain a descendant that supports TextPattern.");
                return;
            }

            Object oAttribute = textpatternPattern.DocumentRange.GetAttributeValue(TextPattern.IndentationLeadingAttribute);
            if (oAttribute == TextPattern.MixedAttributeValue)
            {
                Console.WriteLine("Mixed leading indentation.");
            }
            else
            {
                Console.WriteLine(oAttribute.ToString());
            }
        }
            // </Snippet1013>
            // <Snippet1014>
        private void GetIndentationTrailingAttribute()
        {
            // Start application.
            Process p = Process.Start("Notepad.exe", "text.txt");

            // target --> The root AutomationElement.
            AutomationElement target = AutomationElement.FromHandle(p.MainWindowHandle);

            // Specify the control type we're looking for, in this case 'Document'
            PropertyCondition cond = new PropertyCondition(AutomationElement.ControlTypeProperty, ControlType.Document);

            AutomationElement textProvider = target.FindFirst(TreeScope.Descendants, cond);

            TextPattern textpatternPattern = textProvider.GetCurrentPattern(TextPattern.Pattern) as TextPattern;

            if (textpatternPattern == null)
            {
                Console.WriteLine("Root element does not contain a descendant that supports TextPattern.");
                return;
            }

            Object oAttribute = textpatternPattern.DocumentRange.GetAttributeValue(TextPattern.IndentationTrailingAttribute);
            if (oAttribute == TextPattern.MixedAttributeValue)
            {
                Console.WriteLine("Mixed trailing indentation.");
            }
            else
            {
                Console.WriteLine(oAttribute.ToString());
            }
        }
            // </Snippet1014>
            // <Snippet1015>
        private void GetIsHiddenAttribute()
        {
            // Start application.
            Process p = Process.Start("Notepad.exe", "text.txt");

            // target --> The root AutomationElement.
            AutomationElement target = AutomationElement.FromHandle(p.MainWindowHandle);

            // Specify the control type we're looking for, in this case 'Document'
            PropertyCondition cond = new PropertyCondition(AutomationElement.ControlTypeProperty, ControlType.Document);

            AutomationElement textProvider = target.FindFirst(TreeScope.Descendants, cond);

            TextPattern textpatternPattern = textProvider.GetCurrentPattern(TextPattern.Pattern) as TextPattern;

            if (textpatternPattern == null)
            {
                Console.WriteLine("Root element does not contain a descendant that supports TextPattern.");
                return;
            }

            Object oAttribute = textpatternPattern.DocumentRange.GetAttributeValue(TextPattern.IsHiddenAttribute);
            if (oAttribute == TextPattern.MixedAttributeValue)
            {
                Console.WriteLine("Mixture of hidden and visible.");
            }
            else
            {
                Console.WriteLine(oAttribute.ToString());
            }
        }
            // </Snippet1015>
            // <Snippet1016>
        private void GetIsItalicAttribute()
        {
            // Start application.
            Process p = Process.Start("Notepad.exe", "text.txt");

            // target --> The root AutomationElement.
            AutomationElement target = AutomationElement.FromHandle(p.MainWindowHandle);

            // Specify the control type we're looking for, in this case 'Document'
            PropertyCondition cond = new PropertyCondition(AutomationElement.ControlTypeProperty, ControlType.Document);

            AutomationElement textProvider = target.FindFirst(TreeScope.Descendants, cond);

            TextPattern textpatternPattern = textProvider.GetCurrentPattern(TextPattern.Pattern) as TextPattern;

            if (textpatternPattern == null)
            {
                Console.WriteLine("Root element does not contain a descendant that supports TextPattern.");
                return;
            }

            Object oAttribute = textpatternPattern.DocumentRange.GetAttributeValue(TextPattern.IsItalicAttribute);
            if (oAttribute == TextPattern.MixedAttributeValue)
            {
                Console.WriteLine("Mixture of italic and non-italic.");
            }
            else
            {
                Console.WriteLine(oAttribute.ToString());
            }
        }
            // </Snippet1016>
        //    // <Snippet1017>
        //private void GetIsMarkedAutocorrectedAttribute()
        //{
        //    // Start application.
        //    Process p = Process.Start("Notepad.exe", "text.txt");

        //    // target --> The root AutomationElement.
        //    AutomationElement target = AutomationElement.FromHandle(p.MainWindowHandle);

        //    // Specify the control type we're looking for, in this case 'Document'
        //    PropertyCondition cond = new PropertyCondition(AutomationElement.ControlTypeProperty, ControlType.Document);

        //    AutomationElement textProvider = target.FindFirst(TreeScope.Descendants, cond);

        //    TextPattern textpatternPattern = textProvider.GetCurrentPattern(TextPattern.Pattern) as TextPattern;

        //    if (textpatternPattern == null)
        //    {
        //        Console.WriteLine("Root element does not contain a descendant that supports TextPattern.");
        //        return;
        //    }

        //    Object oAttribute = textpatternPattern.DocumentRange.GetAttributeValue(TextPattern.IsMarkedAutocorrectedAttribute);
        //    if (oAttribute == TextPattern.MixedAttributeValue)
        //    {
        //        Console.WriteLine("Mixture of autocorrected and non-autocorrected.");
        //    }
        //    else
        //    {
        //        Console.WriteLine(oAttribute.ToString());
        //    }
        //}
        //    // </Snippet1017>
        //    // <Snippet1018>
        //private void GetIsMarkedGrammaticallyWrongAttribute()
        //{
        //    // Start application.
        //    Process p = Process.Start("Notepad.exe", "text.txt");

        //    // target --> The root AutomationElement.
        //    AutomationElement target = AutomationElement.FromHandle(p.MainWindowHandle);

        //    // Specify the control type we're looking for, in this case 'Document'
        //    PropertyCondition cond = new PropertyCondition(AutomationElement.ControlTypeProperty, ControlType.Document);

        //    AutomationElement textProvider = target.FindFirst(TreeScope.Descendants, cond);

        //    TextPattern textpatternPattern = textProvider.GetCurrentPattern(TextPattern.Pattern) as TextPattern;

        //    if (textpatternPattern == null)
        //    {
        //        Console.WriteLine("Root element does not contain a descendant that supports TextPattern.");
        //        return;
        //    }

        //    Object oAttribute = textpatternPattern.DocumentRange.GetAttributeValue(TextPattern.IsMarkedGrammaticallyWrongAttribute);
        //    if (oAttribute == TextPattern.MixedAttributeValue)
        //    {
        //        Console.WriteLine("Mixture of grammatically marked and non-marked.");
        //    }
        //    else
        //    {
        //        Console.WriteLine(oAttribute.ToString());
        //    }
        //}
        //    // </Snippet1018>
        //    // <Snippet1019>
        //private void GetIsMarkedMisspelledAttribute()
        //{
        //    // Start application.
        //    Process p = Process.Start("Notepad.exe", "text.txt");

        //    // target --> The root AutomationElement.
        //    AutomationElement target = AutomationElement.FromHandle(p.MainWindowHandle);

        //    // Specify the control type we're looking for, in this case 'Document'
        //    PropertyCondition cond = new PropertyCondition(AutomationElement.ControlTypeProperty, ControlType.Document);

        //    AutomationElement textProvider = target.FindFirst(TreeScope.Descendants, cond);

        //    TextPattern textpatternPattern = textProvider.GetCurrentPattern(TextPattern.Pattern) as TextPattern;

        //    if (textpatternPattern == null)
        //    {
        //        Console.WriteLine("Root element does not contain a descendant that supports TextPattern.");
        //        return;
        //    }

        //    Object oAttribute = textpatternPattern.DocumentRange.GetAttributeValue(TextPattern.IsMarkedMisspelledAttribute);
        //    if (oAttribute == TextPattern.MixedAttributeValue)
        //    {
        //        Console.WriteLine("Mixture of misspellings marked and non-marked.");
        //    }
        //    else
        //    {
        //        Console.WriteLine(oAttribute.ToString());
        //    }
        //}
        //    // </Snippet1019>
        //    // <Snippet1020>
        //private void GetIsMarkedSmartTagAttribute()
        //{
        //    // Start application.
        //    Process p = Process.Start("Notepad.exe", "text.txt");

        //    // target --> The root AutomationElement.
        //    AutomationElement target = AutomationElement.FromHandle(p.MainWindowHandle);

        //    // Specify the control type we're looking for, in this case 'Document'
        //    PropertyCondition cond = new PropertyCondition(AutomationElement.ControlTypeProperty, ControlType.Document);

        //    AutomationElement textProvider = target.FindFirst(TreeScope.Descendants, cond);

        //    TextPattern textpatternPattern = textProvider.GetCurrentPattern(TextPattern.Pattern) as TextPattern;

        //    if (textpatternPattern == null)
        //    {
        //        Console.WriteLine("Root element does not contain a descendant that supports TextPattern.");
        //        return;
        //    }

        //    Object oAttribute = textpatternPattern.DocumentRange.GetAttributeValue(TextPattern.IsMarkedSmartTagAttribute);
        //    if (oAttribute == TextPattern.MixedAttributeValue)
        //    {
        //        Console.WriteLine("Mixture of designer action marked and non-marked.");
        //    }
        //    else
        //    {
        //        Console.WriteLine(oAttribute.ToString());
        //    }
        //}
        //    // </Snippet1020>
        //    // <Snippet1021>
        //private void GetIsPortraitAttribute()
        //{
        //    // Start application.
        //    Process p = Process.Start("Notepad.exe", "text.txt");

        //    // target --> The root AutomationElement.
        //    AutomationElement target = AutomationElement.FromHandle(p.MainWindowHandle);

        //    // Specify the control type we're looking for, in this case 'Document'
        //    PropertyCondition cond = new PropertyCondition(AutomationElement.ControlTypeProperty, ControlType.Document);

        //    AutomationElement textProvider = target.FindFirst(TreeScope.Descendants, cond);

        //    TextPattern textpatternPattern = textProvider.GetCurrentPattern(TextPattern.Pattern) as TextPattern;

        //    if (textpatternPattern == null)
        //    {
        //        Console.WriteLine("Root element does not contain a descendant that supports TextPattern.");
        //        return;
        //    }

        //    Object oAttribute = textpatternPattern.DocumentRange.GetAttributeValue(TextPattern.IsPortraitAttribute);
        //    if (oAttribute == TextPattern.MixedAttributeValue)
        //    {
        //        Console.WriteLine("Mixture of portrait and non-portrait pages.");
        //    }
        //    else
        //    {
        //        Console.WriteLine(oAttribute.ToString());
        //    }
        //}
        //    // </Snippet1021>
            // <Snippet1022>
        private void GetIsReadOnlyAttribute()
        {
            // Start application.
            Process p = Process.Start("Notepad.exe", "text.txt");

            // target --> The root AutomationElement.
            AutomationElement target = AutomationElement.FromHandle(p.MainWindowHandle);

            // Specify the control type we're looking for, in this case 'Document'
            PropertyCondition cond = new PropertyCondition(AutomationElement.ControlTypeProperty, ControlType.Document);

            AutomationElement textProvider = target.FindFirst(TreeScope.Descendants, cond);

            TextPattern textpatternPattern = textProvider.GetCurrentPattern(TextPattern.Pattern) as TextPattern;

            if (textpatternPattern == null)
            {
                Console.WriteLine("Root element does not contain a descendant that supports TextPattern.");
                return;
            }

            Object oAttribute = textpatternPattern.DocumentRange.GetAttributeValue(TextPattern.IsReadOnlyAttribute);
            if (oAttribute == TextPattern.MixedAttributeValue)
            {
                Console.WriteLine("Mixture of readonly and non-readonly.");
            }
            else
            {
                Console.WriteLine(oAttribute.ToString());
            }
        }
            // </Snippet1022>
            // <Snippet1023>
        private void GetIsSubscriptAttribute()
        {
            // Start application.
            Process p = Process.Start("Notepad.exe", "text.txt");

            // target --> The root AutomationElement.
            AutomationElement target = AutomationElement.FromHandle(p.MainWindowHandle);

            // Specify the control type we're looking for, in this case 'Document'
            PropertyCondition cond = new PropertyCondition(AutomationElement.ControlTypeProperty, ControlType.Document);

            AutomationElement textProvider = target.FindFirst(TreeScope.Descendants, cond);

            TextPattern textpatternPattern = textProvider.GetCurrentPattern(TextPattern.Pattern) as TextPattern;

            if (textpatternPattern == null)
            {
                Console.WriteLine("Root element does not contain a descendant that supports TextPattern.");
                return;
            }

            Object oAttribute = textpatternPattern.DocumentRange.GetAttributeValue(TextPattern.IsSubscriptAttribute);
            if (oAttribute == TextPattern.MixedAttributeValue)
            {
                Console.WriteLine("Mixture of subscript and non-subscript.");
            }
            else
            {
                Console.WriteLine(oAttribute.ToString());
            }
        }
            // </Snippet1023>
            // <Snippet1024>
        private void GetIsSuperscriptAttribute()
        {
            // Start application.
            Process p = Process.Start("Notepad.exe", "text.txt");

            // target --> The root AutomationElement.
            AutomationElement target = AutomationElement.FromHandle(p.MainWindowHandle);

            // Specify the control type we're looking for, in this case 'Document'
            PropertyCondition cond = new PropertyCondition(AutomationElement.ControlTypeProperty, ControlType.Document);

            AutomationElement textProvider = target.FindFirst(TreeScope.Descendants, cond);

            TextPattern textpatternPattern = textProvider.GetCurrentPattern(TextPattern.Pattern) as TextPattern;

            if (textpatternPattern == null)
            {
                Console.WriteLine("Root element does not contain a descendant that supports TextPattern.");
                return;
            }

            Object oAttribute = textpatternPattern.DocumentRange.GetAttributeValue(TextPattern.IsSuperscriptAttribute);
            if (oAttribute == TextPattern.MixedAttributeValue)
            {
                Console.WriteLine("Mixture of superscript and non-superscript.");
            }
            else
            {
                Console.WriteLine(oAttribute.ToString());
            }
        }
            // </Snippet1024>
            // <Snippet1025>
        private void GetMarginBottomAttribute()
        {
            // Start application.
            Process p = Process.Start("Notepad.exe", "text.txt");

            // target --> The root AutomationElement.
            AutomationElement target = AutomationElement.FromHandle(p.MainWindowHandle);

            // Specify the control type we're looking for, in this case 'Document'
            PropertyCondition cond = new PropertyCondition(AutomationElement.ControlTypeProperty, ControlType.Document);

            AutomationElement textProvider = target.FindFirst(TreeScope.Descendants, cond);

            TextPattern textpatternPattern = textProvider.GetCurrentPattern(TextPattern.Pattern) as TextPattern;

            if (textpatternPattern == null)
            {
                Console.WriteLine("Root element does not contain a descendant that supports TextPattern.");
                return;
            }

            Object oAttribute = textpatternPattern.DocumentRange.GetAttributeValue(TextPattern.MarginBottomAttribute);
            if (oAttribute == TextPattern.MixedAttributeValue)
            {
                Console.WriteLine("Mixed bottom margins.");
            }
            else
            {
                Console.WriteLine(oAttribute.ToString());
            }
        }
            // </Snippet1025>
            // <Snippet1026>
        private void GetMarginLeadingAttribute()
        {
            // Start application.
            Process p = Process.Start("Notepad.exe", "text.txt");

            // target --> The root AutomationElement.
            AutomationElement target = AutomationElement.FromHandle(p.MainWindowHandle);

            // Specify the control type we're looking for, in this case 'Document'
            PropertyCondition cond = new PropertyCondition(AutomationElement.ControlTypeProperty, ControlType.Document);

            AutomationElement textProvider = target.FindFirst(TreeScope.Descendants, cond);

            TextPattern textpatternPattern = textProvider.GetCurrentPattern(TextPattern.Pattern) as TextPattern;

            if (textpatternPattern == null)
            {
                Console.WriteLine("Root element does not contain a descendant that supports TextPattern.");
                return;
            }

            Object oAttribute = textpatternPattern.DocumentRange.GetAttributeValue(TextPattern.MarginLeadingAttribute);
            if (oAttribute == TextPattern.MixedAttributeValue)
            {
                Console.WriteLine("Mixed leading margins.");
            }
            else
            {
                Console.WriteLine(oAttribute.ToString());
            }
        }
            // </Snippet1026>
            // <Snippet1027>
        private void GetMarginTopAttribute()
        {
            // Start application.
            Process p = Process.Start("Notepad.exe", "text.txt");

            // target --> The root AutomationElement.
            AutomationElement target = AutomationElement.FromHandle(p.MainWindowHandle);

            // Specify the control type we're looking for, in this case 'Document'
            PropertyCondition cond = new PropertyCondition(AutomationElement.ControlTypeProperty, ControlType.Document);

            AutomationElement textProvider = target.FindFirst(TreeScope.Descendants, cond);

            TextPattern textpatternPattern = textProvider.GetCurrentPattern(TextPattern.Pattern) as TextPattern;

            if (textpatternPattern == null)
            {
                Console.WriteLine("Root element does not contain a descendant that supports TextPattern.");
                return;
            }

            Object oAttribute = textpatternPattern.DocumentRange.GetAttributeValue(TextPattern.MarginTopAttribute);
            if (oAttribute == TextPattern.MixedAttributeValue)
            {
                Console.WriteLine("Mixed top margins.");
            }
            else
            {
                Console.WriteLine(oAttribute.ToString());
            }
        }
            // </Snippet1027>
            // <Snippet1028>
        private void GetMarginTrailingAttribute()
        {
            // Start application.
            Process p = Process.Start("Notepad.exe", "text.txt");

            // target --> The root AutomationElement.
            AutomationElement target = AutomationElement.FromHandle(p.MainWindowHandle);

            // Specify the control type we're looking for, in this case 'Document'
            PropertyCondition cond = new PropertyCondition(AutomationElement.ControlTypeProperty, ControlType.Document);

            AutomationElement textProvider = target.FindFirst(TreeScope.Descendants, cond);

            TextPattern textpatternPattern = textProvider.GetCurrentPattern(TextPattern.Pattern) as TextPattern;

            if (textpatternPattern == null)
            {
                Console.WriteLine("Root element does not contain a descendant that supports TextPattern.");
                return;
            }

            Object oAttribute = textpatternPattern.DocumentRange.GetAttributeValue(TextPattern.MarginTrailingAttribute);
            if (oAttribute == TextPattern.MixedAttributeValue)
            {
                Console.WriteLine("Mixed trailing margins.");
            }
            else
            {
                Console.WriteLine(oAttribute.ToString());
            }
        }
            // </Snippet1028>
        //    // <Snippet1030>
        //private void GetOrderedListStringAttribute()
        //{
        //    // Start application.
        //    Process p = Process.Start("Notepad.exe", "text.txt");

        //    // target --> The root AutomationElement.
        //    AutomationElement target = AutomationElement.FromHandle(p.MainWindowHandle);

        //    // Specify the control type we're looking for, in this case 'Document'
        //    PropertyCondition cond = new PropertyCondition(AutomationElement.ControlTypeProperty, ControlType.Document);

        //    AutomationElement textProvider = target.FindFirst(TreeScope.Descendants, cond);

        //    TextPattern textpatternPattern = textProvider.GetCurrentPattern(TextPattern.Pattern) as TextPattern;

        //    if (textpatternPattern == null)
        //    {
        //        Console.WriteLine("Root element does not contain a descendant that supports TextPattern.");
        //        return;
        //    }

        //    Object oAttribute = textpatternPattern.DocumentRange.GetAttributeValue(TextPattern.OrderedListStringAttribute);
        //    if (oAttribute == TextPattern.MixedAttributeValue)
        //    {
        //        Console.WriteLine("Mixed ordered list strings.");
        //    }
        //    else
        //    {
        //        Console.WriteLine(oAttribute.ToString());
        //    }
        //}
        //    // </Snippet1030>
            // <Snippet1031>
        private void GetOutlineStylesAttribute()
        {
            // Start application.
            Process p = Process.Start("Notepad.exe", "text.txt");

            // target --> The root AutomationElement.
            AutomationElement target = AutomationElement.FromHandle(p.MainWindowHandle);

            // Specify the control type we're looking for, in this case 'Document'
            PropertyCondition cond = new PropertyCondition(AutomationElement.ControlTypeProperty, ControlType.Document);

            AutomationElement textProvider = target.FindFirst(TreeScope.Descendants, cond);

            TextPattern textpatternPattern = textProvider.GetCurrentPattern(TextPattern.Pattern) as TextPattern;

            if (textpatternPattern == null)
            {
                Console.WriteLine("Root element does not contain a descendant that supports TextPattern.");
                return;
            }

            Object oAttribute = textpatternPattern.DocumentRange.GetAttributeValue(TextPattern.OutlineStylesAttribute);
            if (oAttribute == TextPattern.MixedAttributeValue)
            {
                Console.WriteLine("Mixed outline styles.");
            }
            else
            {
                Console.WriteLine(oAttribute.ToString());
            }
        }
            // </Snippet1031>
            // <Snippet1032>
        private void GetOverlineColorAttribute()
        {
            // Start application.
            Process p = Process.Start("Notepad.exe", "text.txt");

            // target --> The root AutomationElement.
            AutomationElement target = AutomationElement.FromHandle(p.MainWindowHandle);

            // Specify the control type we're looking for, in this case 'Document'
            PropertyCondition cond = new PropertyCondition(AutomationElement.ControlTypeProperty, ControlType.Document);

            AutomationElement textProvider = target.FindFirst(TreeScope.Descendants, cond);

            TextPattern textpatternPattern = textProvider.GetCurrentPattern(TextPattern.Pattern) as TextPattern;

            if (textpatternPattern == null)
            {
                Console.WriteLine("Root element does not contain a descendant that supports TextPattern.");
                return;
            }

            Object oAttribute = textpatternPattern.DocumentRange.GetAttributeValue(TextPattern.OverlineColorAttribute);
            if (oAttribute == TextPattern.MixedAttributeValue)
            {
                Console.WriteLine("Mixed overline color.");
            }
            else
            {
                Console.WriteLine(oAttribute.ToString());
            }
        }
            // </Snippet1032>
            // <Snippet1033>
        private void GetOverlineStyleAttribute()
        {
            // Start application.
            Process p = Process.Start("Notepad.exe", "text.txt");

            // target --> The root AutomationElement.
            AutomationElement target = AutomationElement.FromHandle(p.MainWindowHandle);

            // Specify the control type we're looking for, in this case 'Document'
            PropertyCondition cond = new PropertyCondition(AutomationElement.ControlTypeProperty, ControlType.Document);

            AutomationElement textProvider = target.FindFirst(TreeScope.Descendants, cond);

            TextPattern textpatternPattern = textProvider.GetCurrentPattern(TextPattern.Pattern) as TextPattern;

            if (textpatternPattern == null)
            {
                Console.WriteLine("Root element does not contain a descendant that supports TextPattern.");
                return;
            }

            Object oAttribute = textpatternPattern.DocumentRange.GetAttributeValue(TextPattern.OverlineStyleAttribute);
            if (oAttribute == TextPattern.MixedAttributeValue)
            {
                Console.WriteLine("Mixed overline style.");
            }
            else
            {
                Console.WriteLine(oAttribute.ToString());
            }
        }
            // </Snippet1033>
        //    // <Snippet1034>
        //private void GetPageHeightAttribute()
        //{
        //    // Start application.
        //    Process p = Process.Start("Notepad.exe", "text.txt");

        //    // target --> The root AutomationElement.
        //    AutomationElement target = AutomationElement.FromHandle(p.MainWindowHandle);

        //    // Specify the control type we're looking for, in this case 'Document'
        //    PropertyCondition cond = new PropertyCondition(AutomationElement.ControlTypeProperty, ControlType.Document);

        //    AutomationElement textProvider = target.FindFirst(TreeScope.Descendants, cond);

        //    TextPattern textpatternPattern = textProvider.GetCurrentPattern(TextPattern.Pattern) as TextPattern;

        //    if (textpatternPattern == null)
        //    {
        //        Console.WriteLine("Root element does not contain a descendant that supports TextPattern.");
        //        return;
        //    }

        //    Object oAttribute = textpatternPattern.DocumentRange.GetAttributeValue(TextPattern.PageHeightAttribute);
        //    if (oAttribute == TextPattern.MixedAttributeValue)
        //    {
        //        Console.WriteLine("Mixed page heights.");
        //    }
        //    else
        //    {
        //        Console.WriteLine(oAttribute.ToString());
        //    }
        //}
        //    // </Snippet1034>
        //    // <Snippet1035>
        //private void GetPageNumberAttribute()
        //{
        //    // Start application.
        //    Process p = Process.Start("Notepad.exe", "text.txt");

        //    // target --> The root AutomationElement.
        //    AutomationElement target = AutomationElement.FromHandle(p.MainWindowHandle);

        //    // Specify the control type we're looking for, in this case 'Document'
        //    PropertyCondition cond = new PropertyCondition(AutomationElement.ControlTypeProperty, ControlType.Document);

        //    AutomationElement textProvider = target.FindFirst(TreeScope.Descendants, cond);

        //    TextPattern textpatternPattern = textProvider.GetCurrentPattern(TextPattern.Pattern) as TextPattern;

        //    if (textpatternPattern == null)
        //    {
        //        Console.WriteLine("Root element does not contain a descendant that supports TextPattern.");
        //        return;
        //    }

        //    Object oAttribute = textpatternPattern.DocumentRange.GetAttributeValue(TextPattern.PageNumberAttribute);
        //    if (oAttribute == TextPattern.MixedAttributeValue)
        //    {
        //        Console.WriteLine("Mixed page numbers.");
        //    }
        //    else
        //    {
        //        Console.WriteLine(oAttribute.ToString());
        //    }
        //}
        //    // </Snippet1035>
        //    // <Snippet1036>
        //private void GetPageWidthAttribute()
        //{
        //    // Start application.
        //    Process p = Process.Start("Notepad.exe", "text.txt");

        //    // target --> The root AutomationElement.
        //    AutomationElement target = AutomationElement.FromHandle(p.MainWindowHandle);

        //    // Specify the control type we're looking for, in this case 'Document'
        //    PropertyCondition cond = new PropertyCondition(AutomationElement.ControlTypeProperty, ControlType.Document);

        //    AutomationElement textProvider = target.FindFirst(TreeScope.Descendants, cond);

        //    TextPattern textpatternPattern = textProvider.GetCurrentPattern(TextPattern.Pattern) as TextPattern;

        //    if (textpatternPattern == null)
        //    {
        //        Console.WriteLine("Root element does not contain a descendant that supports TextPattern.");
        //        return;
        //    }

        //    Object oAttribute = textpatternPattern.DocumentRange.GetAttributeValue(TextPattern.PageWidthAttribute);
        //    if (oAttribute == TextPattern.MixedAttributeValue)
        //    {
        //        Console.WriteLine("Mixed page widths.");
        //    }
        //    else
        //    {
        //        Console.WriteLine(oAttribute.ToString());
        //    }
        //}
        //    // </Snippet1036>
            // <Snippet1038>
        private void GetStrikethroughColorAttribute()
        {
            // Start application.
            Process p = Process.Start("Notepad.exe", "text.txt");

            // target --> The root AutomationElement.
            AutomationElement target = AutomationElement.FromHandle(p.MainWindowHandle);

            // Specify the control type we're looking for, in this case 'Document'
            PropertyCondition cond = new PropertyCondition(AutomationElement.ControlTypeProperty, ControlType.Document);

            AutomationElement textProvider = target.FindFirst(TreeScope.Descendants, cond);

            TextPattern textpatternPattern = textProvider.GetCurrentPattern(TextPattern.Pattern) as TextPattern;

            if (textpatternPattern == null)
            {
                Console.WriteLine("Root element does not contain a descendant that supports TextPattern.");
                return;
            }

            Object oAttribute = textpatternPattern.DocumentRange.GetAttributeValue(TextPattern.StrikethroughColorAttribute);
            if (oAttribute == TextPattern.MixedAttributeValue)
            {
                Console.WriteLine("Mixed strikethrough colors.");
            }
            else
            {
                Console.WriteLine(oAttribute.ToString());
            }
        }
            // </Snippet1038>
            // <Snippet1039>
        private void GetStrikethroughStyleAttribute()
        {
            // Start application.
            Process p = Process.Start("Notepad.exe", "text.txt");

            // target --> The root AutomationElement.
            AutomationElement target = AutomationElement.FromHandle(p.MainWindowHandle);

            // Specify the control type we're looking for, in this case 'Document'
            PropertyCondition cond = new PropertyCondition(AutomationElement.ControlTypeProperty, ControlType.Document);

            AutomationElement textProvider = target.FindFirst(TreeScope.Descendants, cond);

            TextPattern textpatternPattern = textProvider.GetCurrentPattern(TextPattern.Pattern) as TextPattern;

            if (textpatternPattern == null)
            {
                Console.WriteLine("Root element does not contain a descendant that supports TextPattern.");
                return;
            }

            Object oAttribute = textpatternPattern.DocumentRange.GetAttributeValue(TextPattern.StrikethroughStyleAttribute);
            if (oAttribute == TextPattern.MixedAttributeValue)
            {
                Console.WriteLine("Mixed strikethrough styles.");
            }
            else
            {
                Console.WriteLine(oAttribute.ToString());
            }
        }
            // </Snippet1039>
            // <Snippet1040>
        private void GetTabsAttribute()
        {
            // Start application.
            Process p = Process.Start("Notepad.exe", "text.txt");

            // target --> The root AutomationElement.
            AutomationElement target = AutomationElement.FromHandle(p.MainWindowHandle);

            // Specify the control type we're looking for, in this case 'Document'
            PropertyCondition cond = new PropertyCondition(AutomationElement.ControlTypeProperty, ControlType.Document);

            AutomationElement textProvider = target.FindFirst(TreeScope.Descendants, cond);

            TextPattern textpatternPattern = textProvider.GetCurrentPattern(TextPattern.Pattern) as TextPattern;

            if (textpatternPattern == null)
            {
                Console.WriteLine("Root element does not contain a descendant that supports TextPattern.");
                return;
            }

            Object oAttribute = textpatternPattern.DocumentRange.GetAttributeValue(TextPattern.TabsAttribute);
            if (oAttribute == TextPattern.MixedAttributeValue)
            {
                Console.WriteLine("Mixed tabs.");
            }
            else
            {
                Console.WriteLine(oAttribute.ToString());
            }
        }
            // </Snippet1040>
            // <Snippet1041>
        private void GetTextFlowDirectionsAttribute()
        {
            // Start application.
            Process p = Process.Start("Notepad.exe", "text.txt");

            // target --> The root AutomationElement.
            AutomationElement target = AutomationElement.FromHandle(p.MainWindowHandle);

            // Specify the control type we're looking for, in this case 'Document'
            PropertyCondition cond = new PropertyCondition(AutomationElement.ControlTypeProperty, ControlType.Document);

            AutomationElement textProvider = target.FindFirst(TreeScope.Descendants, cond);

            TextPattern textpatternPattern = textProvider.GetCurrentPattern(TextPattern.Pattern) as TextPattern;

            if (textpatternPattern == null)
            {
                Console.WriteLine("Root element does not contain a descendant that supports TextPattern.");
                return;
            }

            Object oAttribute = textpatternPattern.DocumentRange.GetAttributeValue(TextPattern.TextFlowDirectionsAttribute);
            if (oAttribute == TextPattern.MixedAttributeValue)
            {
                Console.WriteLine("Mixed text flow directions.");
            }
            else
            {
                Console.WriteLine(oAttribute.ToString());
            }
        }
            // </Snippet1041>
            // <Snippet1043>
        private void GetUnderlineColorAttribute()
        {
            // Start application.
            Process p = Process.Start("Notepad.exe", "text.txt");

            // target --> The root AutomationElement.
            AutomationElement target = AutomationElement.FromHandle(p.MainWindowHandle);

            // Specify the control type we're looking for, in this case 'Document'
            PropertyCondition cond = new PropertyCondition(AutomationElement.ControlTypeProperty, ControlType.Document);

            AutomationElement textProvider = target.FindFirst(TreeScope.Descendants, cond);

            TextPattern textpatternPattern = textProvider.GetCurrentPattern(TextPattern.Pattern) as TextPattern;

            if (textpatternPattern == null)
            {
                Console.WriteLine("Root element does not contain a descendant that supports TextPattern.");
                return;
            }

            Object oAttribute = textpatternPattern.DocumentRange.GetAttributeValue(TextPattern.UnderlineColorAttribute);
            if (oAttribute == TextPattern.MixedAttributeValue)
            {
                Console.WriteLine("Mixed underline colors.");
            }
            else
            {
                Console.WriteLine(oAttribute.ToString());
            }
        }
            // </Snippet1043>
            // <Snippet1044>
        private void GetUnderlineStyleAttribute()
        {
            // Start application.
            Process p = Process.Start("Notepad.exe", "text.txt");

            // target --> The root AutomationElement.
            AutomationElement target = AutomationElement.FromHandle(p.MainWindowHandle);

            // Specify the control type we're looking for, in this case 'Document'
            PropertyCondition cond = new PropertyCondition(AutomationElement.ControlTypeProperty, ControlType.Document);

            AutomationElement textProvider = target.FindFirst(TreeScope.Descendants, cond);

            TextPattern textpatternPattern = textProvider.GetCurrentPattern(TextPattern.Pattern) as TextPattern;

            if (textpatternPattern == null)
            {
                Console.WriteLine("Root element does not contain a descendant that supports TextPattern.");
                return;
            }

            Object oAttribute = textpatternPattern.DocumentRange.GetAttributeValue(TextPattern.UnderlineStyleAttribute);
            if (oAttribute == TextPattern.MixedAttributeValue)
            {
                Console.WriteLine("Mixed underline styles.");
            }
            else
            {
                Console.WriteLine(oAttribute.ToString());
            }
        }
            // </Snippet1044>
        //    // <Snippet1045>
        //private void GetVerticalTextAlignmentAttribute()
        //{
        //    // Start application.
        //    Process p = Process.Start("Notepad.exe", "text.txt");

        //    // target --> The root AutomationElement.
        //    AutomationElement target = AutomationElement.FromHandle(p.MainWindowHandle);

        //    // Specify the control type we're looking for, in this case 'Document'
        //    PropertyCondition cond = new PropertyCondition(AutomationElement.ControlTypeProperty, ControlType.Document);

        //    AutomationElement textProvider = target.FindFirst(TreeScope.Descendants, cond);

        //    TextPattern textpatternPattern = textProvider.GetCurrentPattern(TextPattern.Pattern) as TextPattern;

        //    if (textpatternPattern == null)
        //    {
        //        Console.WriteLine("Root element does not contain a descendant that supports TextPattern.");
        //        return;
        //    }

        //    Object oAttribute = textpatternPattern.DocumentRange.GetAttributeValue(TextPattern.VerticalTextAlignmentAttribute);
        //    if (oAttribute == TextPattern.MixedAttributeValue)
        //    {
        //        Console.WriteLine("Mixed vertical text alignments.");
        //    }
        //    else
        //    {
        //        Console.WriteLine(oAttribute.ToString());
        //    }
        //}
        //    // </Snippet1045>
            // <Snippet1049>
        private TextPatternRange GetRangeFromPoint()
        {
            return targetTextPattern.RangeFromPoint(
                _root.Current.BoundingRectangle.TopLeft);
        }
            // </Snippet1049>
        //    // <Snippet1051>
        //private void GetSupportsTextSelection()
        //{
        //    TextPattern textpatternPattern;
        //    Process p = Process.Start("Notepad.exe");
        //    AutomationElement target = AutomationElement.FromHandle(p.MainWindowHandle);
        //    PropertyCondition cond = new PropertyCondition(AutomationElement.ControlTypeProperty, ControlType.Document);

        //    AutomationElement textProvider = target.FindFirst(TreeScope.Descendants, cond);

        //    textpatternPattern = textProvider.GetCurrentPattern(TextPattern.Pattern) as TextPattern;

        //    Boolean bSupportsTextSelection = textpatternPattern.SupportsTextSelection;
        //}
        //    // </Snippet1051>

        // <Snippet1046>
        private TextPatternRange CurrentSelection(AutomationElement target)
        {
            // Specify the control type we're looking for, in this case 'Document'
            PropertyCondition cond = new PropertyCondition(AutomationElement.ControlTypeProperty, ControlType.Document);

            // target --> The root AutomationElement.
            AutomationElement textProvider = target.FindFirst(TreeScope.Descendants, cond);

            TextPattern textpatternPattern = textProvider.GetCurrentPattern(TextPattern.Pattern) as TextPattern;

            if (textpatternPattern == null)
            {
                Console.WriteLine("Root element does not contain a descendant that supports TextPattern.");
                return null;
            }
            TextPatternRange[] currentSelection = textpatternPattern.GetSelection();
            return currentSelection[0];
        }
        // </Snippet1046>
        // <SnippetVisibleRanges>
        private TextPatternRange[] CurrentVisibleRanges(AutomationElement target)
        {
            // Specify the control type we're looking for, in this case 'Document'
            PropertyCondition cond = new PropertyCondition(AutomationElement.ControlTypeProperty, ControlType.Document);

            // target --> The root AutomationElement.
            AutomationElement textProvider = target.FindFirst(TreeScope.Descendants, cond);

            TextPattern textpatternPattern = textProvider.GetCurrentPattern(TextPattern.Pattern) as TextPattern;

            if (textpatternPattern == null)
            {
                Console.WriteLine("Root element does not contain a descendant that supports TextPattern.");
                return null;
            }
            return textpatternPattern.GetVisibleRanges();
        }
        // </SnippetVisibleRanges>
        // <Snippet1060>
        private TextPatternRange CloneSelection(AutomationElement target)
        {
            // Specify the control type we're looking for, in this case 'Document'
            PropertyCondition cond = new PropertyCondition(AutomationElement.ControlTypeProperty, ControlType.Document);

            // target --> The root AutomationElement.
            AutomationElement textProvider = target.FindFirst(TreeScope.Descendants, cond);

            TextPattern textpatternPattern = textProvider.GetCurrentPattern(TextPattern.Pattern) as TextPattern;

            if (textpatternPattern == null)
            {
                Console.WriteLine("Root element does not contain a descendant that supports TextPattern.");
                return null;
            }
            TextPatternRange[] currentSelection = textpatternPattern.GetSelection();
            return currentSelection[0].Clone();
        }
        // </Snippet1060>
        // <Snippet1061>
        private Boolean CompareRanges(AutomationElement target)
        {
            // Specify the control type we're looking for, in this case 'Document'
            PropertyCondition cond = new PropertyCondition(AutomationElement.ControlTypeProperty, ControlType.Document);

            // target --> The root AutomationElement.
            AutomationElement textProvider = target.FindFirst(TreeScope.Descendants, cond);

            TextPattern textpatternPattern = textProvider.GetCurrentPattern(TextPattern.Pattern) as TextPattern;

            if (textpatternPattern == null)
            {
                Console.WriteLine("Root element does not contain a descendant that supports TextPattern.");
                return false;
            }
            TextPatternRange[] currentSelection = textpatternPattern.GetSelection();
            TextPatternRange[] currentVisibleRanges = textpatternPattern.GetVisibleRanges();
            return currentSelection[0].Compare(currentVisibleRanges[0]);
        }
        // </Snippet1061>
        // <Snippet1062>
        private Int32 CompareRangeEndpoints(AutomationElement target)
        {
            // Specify the control type we're looking for, in this case 'Document'
            PropertyCondition cond = new PropertyCondition(AutomationElement.ControlTypeProperty, ControlType.Document);

            // target --> The root AutomationElement.
            AutomationElement textProvider = target.FindFirst(TreeScope.Descendants, cond);

            TextPattern textpatternPattern = textProvider.GetCurrentPattern(TextPattern.Pattern) as TextPattern;

            if (textpatternPattern == null)
            {
                Console.WriteLine("Root element does not contain a descendant that supports TextPattern.");
                return 0;
            }
            TextPatternRange[] currentSelections = textpatternPattern.GetSelection();
            TextPatternRange[] currentVisibleRanges = textpatternPattern.GetVisibleRanges();
            return currentSelections[0].CompareEndpoints(
                TextPatternRangeEndpoint.Start,
                currentVisibleRanges[0],
                TextPatternRangeEndpoint.Start);
        }
        // </Snippet1062>
        // <Snippet1063>
         private void ExpandSelection(AutomationElement target)
        {
            // Specify the control type we're looking for, in this case 'Document'
            PropertyCondition cond = new PropertyCondition(AutomationElement.ControlTypeProperty, ControlType.Document);

            // target --> The root AutomationElement.
            AutomationElement textProvider = target.FindFirst(TreeScope.Descendants, cond);

            TextPattern textpatternPattern = textProvider.GetCurrentPattern(TextPattern.Pattern) as TextPattern;

            if (textpatternPattern == null)
            {
                Console.WriteLine("Root element does not contain a descendant that supports TextPattern.");
                return;
            }
            TextPatternRange[] currentSelection = textpatternPattern.GetSelection();
            // Expand selection to include entire document
            currentSelection[0].ExpandToEnclosingUnit(TextUnit.Document);
        }
        // </Snippet1063>
        // <Snippet1064>
         private TextPatternRange RangeFromAttribute(AutomationElement target)
        {
            // Specify the control type we're looking for, in this case 'Document'
            PropertyCondition cond = new PropertyCondition(AutomationElement.ControlTypeProperty, ControlType.Document);

            // target --> The root AutomationElement.
            AutomationElement textProvider = target.FindFirst(TreeScope.Descendants, cond);

            TextPattern textpatternPattern = textProvider.GetCurrentPattern(TextPattern.Pattern) as TextPattern;

            if (textpatternPattern == null)
            {
                Console.WriteLine("Root element does not contain a descendant that supports TextPattern.");
                return null;
            }
            TextPatternRange[] currentSelection = textpatternPattern.GetSelection();
            // Find 'italic' range
            return currentSelection[0].FindAttribute(TextPattern.IsItalicAttribute, true, false);
        }
        // </Snippet1064>
        // <Snippet1065>
         private TextPatternRange TextFromSelection(AutomationElement target)
        {
            // Specify the control type we're looking for, in this case 'Document'
            PropertyCondition cond = new PropertyCondition(AutomationElement.ControlTypeProperty, ControlType.Document);

            // target --> The root AutomationElement.
            AutomationElement textProvider = target.FindFirst(TreeScope.Descendants, cond);

            TextPattern textpatternPattern = textProvider.GetCurrentPattern(TextPattern.Pattern) as TextPattern;

            if (textpatternPattern == null)
            {
                Console.WriteLine("Root element does not contain a descendant that supports TextPattern.");
                return null;
            }
            TextPatternRange[] tprSelection = textpatternPattern.GetSelection();
            // Find 'text' in selection range
            return tprSelection[0].FindText("text", false, true);
        }
        // </Snippet1065>
        // <Snippet1066>
         private Object AttributeValueFromSelection(AutomationElement target)
        {
            // Specify the control type we're looking for, in this case 'Document'
            PropertyCondition cond = new PropertyCondition(AutomationElement.ControlTypeProperty, ControlType.Document);

            // target --> The root AutomationElement.
            AutomationElement textProvider = target.FindFirst(TreeScope.Descendants, cond);

            TextPattern textpatternPattern = textProvider.GetCurrentPattern(TextPattern.Pattern) as TextPattern;

            if (textpatternPattern == null)
            {
                Console.WriteLine("Root element does not contain a descendant that supports TextPattern.");
                return null;
            }
            TextPatternRange[] currentSelection = textpatternPattern.GetSelection();
            // Is 'italic'?
            return currentSelection[0].GetAttributeValue(TextPattern.IsItalicAttribute);
        }
        // </Snippet1066>
        // <Snippet1067>
         private Rect[] BoundingRectanglesFromSelection(AutomationElement target)
        {
            // Specify the control type we're looking for, in this case 'Document'
            PropertyCondition cond = new PropertyCondition(AutomationElement.ControlTypeProperty, ControlType.Document);

            // target --> The root AutomationElement.
            AutomationElement textProvider = target.FindFirst(TreeScope.Descendants, cond);

            TextPattern textpatternPattern = textProvider.GetCurrentPattern(TextPattern.Pattern) as TextPattern;

            if (textpatternPattern == null)
            {
                Console.WriteLine("Root element does not contain a descendant that supports TextPattern.");
                return null;
            }
            TextPatternRange[] currentSelection = textpatternPattern.GetSelection();

            return currentSelection[0].GetBoundingRectangles();
        }
        // </Snippet1067>
        // <SnippetGetEmbeddedObjects>
        /// -------------------------------------------------------------------
        /// <summary>
        /// Retrieves the embedded children of a document control.
        /// </summary>
        /// <param name="targetTextElement">
        /// The AutomationElement that represents a text control.
        /// </param>
        /// -------------------------------------------------------------------
        private void GetEmbeddedObjects(AutomationElement targetTextElement)
        {
            TextPattern textPattern =
                targetTextElement.GetCurrentPattern(TextPattern.Pattern)
                as TextPattern;

            if (textPattern == null)
            {
                // Target control doesn't support TextPattern.
                return;
            }

            // Obtain a text range spanning the entire document.
            TextPatternRange textRange = textPattern.DocumentRange;

            // Retrieve the embedded objects within the range.
            AutomationElement[] embeddedObjects = textRange.GetChildren();

            foreach (AutomationElement embeddedObject in embeddedObjects)
            {
                Console.WriteLine(embeddedObject.Current.Name);
            }
        }
        // </SnippetGetEmbeddedObjects>
        // <SnippetGetRangeFromChild>
        /// -------------------------------------------------------------------
        /// <summary>
        /// Obtains a text range spanning an embedded child
        /// of a document control and displays the content of the range.
        /// </summary>
        /// <param name="targetTextElement">
        /// The AutomationElement that represents a text control.
        /// </param>
        /// -------------------------------------------------------------------
        private void GetRangeFromChild(AutomationElement targetTextElement)
        {
            TextPattern textPattern =
                targetTextElement.GetCurrentPattern(TextPattern.Pattern)
                as TextPattern;

            if (textPattern == null)
            {
                // Target control doesn't support TextPattern.
                return;
            }

            // Obtain a text range spanning the entire document.
            TextPatternRange textRange = textPattern.DocumentRange;

            // Retrieve the embedded objects within the range.
            AutomationElement[] embeddedObjects = textRange.GetChildren();

            // Retrieve and display text value of embedded object.
            foreach (AutomationElement embeddedObject in embeddedObjects)
            {
                if ((bool)embeddedObject.GetCurrentPropertyValue(
                    AutomationElement.IsTextPatternAvailableProperty))
                {
                   // For full functionality a secondary TextPattern should
                   // be obtained from the embedded object.
                   // embeddedObject must be a child of the text provider.
                    TextPatternRange embeddedObjectRange =
                        textPattern.RangeFromChild(embeddedObject);
                    // GetText(-1) retrieves all text in the range.
                    // Typically a more limited amount of text would be
                    // retrieved for performance and security reasons.
                    Console.WriteLine(embeddedObjectRange.GetText(-1));
                }
            }
        }
        // </SnippetGetRangeFromChild>
        // <Snippet1069>
         private AutomationElement EnclosingElementFromSelection(AutomationElement target)
        {
            // Specify the control type we're looking for, in this case 'Document'
            PropertyCondition cond = new PropertyCondition(AutomationElement.ControlTypeProperty, ControlType.Document);

            // target --> The root AutomationElement.
            AutomationElement textProvider = target.FindFirst(TreeScope.Descendants, cond);

            TextPattern textpatternPattern = textProvider.GetCurrentPattern(TextPattern.Pattern) as TextPattern;

            if (textpatternPattern == null)
            {
                Console.WriteLine("Root element does not contain a descendant that supports TextPattern.");
                return null;
            }
            TextPatternRange[] currentSelection = textpatternPattern.GetSelection();

            return currentSelection[0].GetEnclosingElement();
        }
        // </Snippet1069>
        // <Snippet1070>
         private String TextFromSelection(AutomationElement target, Int32 length)
        {
            // Specify the control type we're looking for, in this case 'Document'
            PropertyCondition cond = new PropertyCondition(AutomationElement.ControlTypeProperty, ControlType.Document);

            // target --> The root AutomationElement.
            AutomationElement textProvider = target.FindFirst(TreeScope.Descendants, cond);

            TextPattern textpatternPattern = textProvider.GetCurrentPattern(TextPattern.Pattern) as TextPattern;

            if (textpatternPattern == null)
            {
                Console.WriteLine("Root element does not contain a descendant that supports TextPattern.");
                return null;
            }
            TextPatternRange[] currentSelection = textpatternPattern.GetSelection();

            // GetText(-1) retrieves all characters but can be inefficient
            return currentSelection[0].GetText(length);
        }
        // </Snippet1070>
        // <SnippetMoveSelection>
        /// -------------------------------------------------------------------
        /// <summary>
        /// Moves a text range a specified number of text units. The text range
        /// is the current selection.
        /// </summary>
        /// <param name="targetTextElement">
        /// The AutomationElement that represents a text control.
        /// </param>
        /// <param name="textUnit">
        /// The text unit value.
        /// </param>
        /// <param name="units">
        /// The number of text units to move.
        /// </param>
        /// <param name="direction">
        /// Direction to move the text range. Valid values are -1, 0, 1.
        /// </param>
        /// <returns>
        /// The number of text units actually moved. This can be less than the
        /// number requested if either of the new text range endpoints is
        /// greater than or less than the DocumentRange endpoints.
        /// </returns>
        /// <remarks>
        /// Moving the text range does not modify the text source in any way.
        /// Only the text range starting and ending endpoints are modified.
        /// </remarks>
        /// -------------------------------------------------------------------
        private Int32 MoveSelection(
            AutomationElement targetTextElement,
            TextUnit textUnit,
            int units,
            int direction)
        {
            TextPattern textPattern =
                targetTextElement.GetCurrentPattern(TextPattern.Pattern)
                as TextPattern;

            if (textPattern == null)
            {
                // Target control doesn't support TextPattern.
                return -1;
            }

            TextPatternRange[] currentSelection = textPattern.GetSelection();

            if (currentSelection.Length > 1)
            {
                // For this example, we cannot move more than one text range.
                return -1;
            }

            return currentSelection[0].Move(textUnit, Math.Sign(direction) * units);
        }
        // </SnippetMoveSelection>
        // <Snippet1072>
         private void MoveEndpointByRangeFromSelection(AutomationElement target)
        {
            // Specify the control type we're looking for, in this case 'Document'
            PropertyCondition cond = new PropertyCondition(AutomationElement.ControlTypeProperty, ControlType.Document);

            // target --> The root AutomationElement.
            AutomationElement textProvider = target.FindFirst(TreeScope.Descendants, cond);

            TextPattern textpatternPattern = textProvider.GetCurrentPattern(TextPattern.Pattern) as TextPattern;

            if (textpatternPattern == null)
            {
                Console.WriteLine("Root element does not contain a descendant that supports TextPattern.");
                return;
            }
            TextPatternRange[] currentSelection = textpatternPattern.GetSelection();
            TextPatternRange[] currentVisibleRanges = textpatternPattern.GetVisibleRanges();

            currentSelection[0].MoveEndpointByRange(
                TextPatternRangeEndpoint.Start,
                currentVisibleRanges[0],
                TextPatternRangeEndpoint.Start);
        }
        // </Snippet1072>
        // <Snippet1073>
        private Int32 MoveEndpointByRangeFromSelection(AutomationElement target, Int32 units)
        {
            // Specify the control type we're looking for, in this case 'Document'
            PropertyCondition cond = new PropertyCondition(AutomationElement.ControlTypeProperty, ControlType.Document);

            // target --> The root AutomationElement.
            AutomationElement textProvider = target.FindFirst(TreeScope.Descendants, cond);

            TextPattern textpatternPattern = textProvider.GetCurrentPattern(TextPattern.Pattern) as TextPattern;

            if (textpatternPattern == null)
            {
                Console.WriteLine("Root element does not contain a descendant that supports TextPattern.");
                return 0;
            }
            TextPatternRange[] currentSelection = textpatternPattern.GetSelection();

            return currentSelection[0].MoveEndpointByUnit(
                TextPatternRangeEndpoint.Start, TextUnit.Paragraph, units);
        }
        // </Snippet1073>
        // <Snippet1074>
        private void ScrollToSelection(AutomationElement target)
        {
            // Specify the control type we're looking for, in this case 'Document'
            PropertyCondition cond = new PropertyCondition(AutomationElement.ControlTypeProperty, ControlType.Document);

            // target --> The root AutomationElement.
            AutomationElement textProvider = target.FindFirst(TreeScope.Descendants, cond);

            TextPattern textpatternPattern = textProvider.GetCurrentPattern(TextPattern.Pattern) as TextPattern;

            if (textpatternPattern == null)
            {
                Console.WriteLine("Root element does not contain a descendant that supports TextPattern.");
                return;
            }
            TextPatternRange[] currentSelection = textpatternPattern.GetSelection();

            currentSelection[0].ScrollIntoView(true);
        }
        // </Snippet1074>
        // <Snippet1075>
        private void SetSelection(AutomationElement target, String s, Boolean backward, Boolean ignorecase)
        {
            // Specify the control type we're looking for, in this case 'Document'
            PropertyCondition cond = new PropertyCondition(AutomationElement.ControlTypeProperty, ControlType.Document);

            // target --> The root AutomationElement.
            AutomationElement textProvider = target.FindFirst(TreeScope.Descendants, cond);

            TextPattern textpatternPattern = textProvider.GetCurrentPattern(TextPattern.Pattern) as TextPattern;

            if (textpatternPattern == null)
            {
                Console.WriteLine("Root element does not contain a descendant that supports TextPattern.");
                return;
            }
            TextPatternRange[] currentSelection = textpatternPattern.GetSelection();

            TextPatternRange tprText = currentSelection[0].FindText(s, backward, ignorecase);
            tprText.Select();
        }
        // </Snippet1075>
        // <Snippet1076>
        private TextPattern TextPatternFromSelection(AutomationElement target)
        {
            // Specify the control type we're looking for, in this case 'Document'
            PropertyCondition cond = new PropertyCondition(AutomationElement.ControlTypeProperty, ControlType.Document);

            // target --> The root AutomationElement.
            AutomationElement textProvider = target.FindFirst(TreeScope.Descendants, cond);

            TextPattern textpatternPattern = textProvider.GetCurrentPattern(TextPattern.Pattern) as TextPattern;

            if (textpatternPattern == null)
            {
                Console.WriteLine("Root element does not contain a descendant that supports TextPattern.");
                return null;
            }

            TextPatternRange[] currentSelection = textpatternPattern.GetSelection();

            return currentSelection[0].TextPattern;
        }
        // </Snippet1076>
    }
}
