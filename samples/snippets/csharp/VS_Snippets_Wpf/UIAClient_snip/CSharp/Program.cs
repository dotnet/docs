/*************************************************************************************************
 *
 * File: Program.cs
 *
 * Description:
 *
 * This is the entry point for a sample application that demonstrates interaction between UI Automation
 * and a custom control in a host application.
 *
 * See ProviderForm.cs in the ElementProvider project for a full description of this sample.
 *
 *
 *  This file is part of the Microsoft WinfFX SDK Code Samples.
 *
 *  Copyright (C) Microsoft Corporation.  All rights reserved.
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
 *************************************************************************************************/
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace CustomElementClient
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.Run(new Form1());
        }
    }
}