/*****************************************************************************************
 * File: FindText.cs
 *
 * Description: 
 *    This sample demonstrates the UI Automation TextPattern and TextPatternRange classes.
 * 
 *    The sample consists of a Windows Presentation Foundation (WPF) client and the choice 
 *    of a WPF FlowDocumentReader target or a Win32 WordPad target. The client uses the 
 *    TextPattern control pattern and the TextPatternRange class to interact with the text 
 *    controls in either target.  
 * 
 *    The functionality demonstrated by the sample includes the ability to search for and 
 *    select text, expand a selection to a specific TextUnit, navigate by TextUnit, access 
 *    embedded objects within a selection, and access the enclosing element of a selection.
 * 
 *    Note: Three WPF documents, a RichText document, and a plain text document are provided 
 *          in the Content folder of the TextProvider project.
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
        /// <summary>
        /// Handles our application startup.
        /// </summary>
        /// <param name="e">Event arguments.</param>
        protected override void OnStartup(StartupEventArgs e)
        {
			// Initialize the sample
            new SearchWindow();
        }

        /// <summary>
        /// Handles our application shutdown.
        /// </summary>
        /// <param name="e">Event arguments.</param>
        // Window shut down event handler
        protected override void  OnExit(ExitEventArgs e)
        {
            base.OnExit(e);
        }

        /// <summary>
        /// The main entry point for the application.
        /// </summary>
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