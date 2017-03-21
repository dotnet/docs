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
 *           Edit field
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
using System.Threading;
using System.IO;

namespace SDKSample
{
    public class FindText: Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
			// Initialize the sample
            new SearchWindow();
        }

        // Window shut down event handler
        protected override void  OnExit(ExitEventArgs e)
        {
            base.OnExit(e);
        }

        // Launch the sample application.
        internal sealed class TestMain
        {
            [STAThread()]
            static void Main()
            {
                // Create an instance of the sample class and call its Run() method to start it.
                FindText app = new FindText();
                app.Run();
            }
        }
    }
}