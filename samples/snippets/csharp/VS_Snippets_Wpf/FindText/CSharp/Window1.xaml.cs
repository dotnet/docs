/*****************************************************************************************
 * File: Window1.xaml.cs
 *
 * Description: 
 *    This sample opens a 'canned' text file (Text.txt) in Notepad and shows how to use 
 *    UI Automation to find/select text and track text selection changes in the Notepad instance.
 * 
 *    Text.txt should be automatically copied to the same folder as the executable when 
 *    you build the sample. You may have to manually copy this file if you receive an error 
 *    stating the file cannot be found.
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
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.Windows.Forms;
using System.IO;
using System.Windows.Markup;

namespace SDKSample
{

    public partial class Window1 : Window
    {

        public Window1()
        {
            InitializeComponent();
        }

        void LoadFile(Object sender, RoutedEventArgs args)
        {
            FlowDocument content = null;

            OpenFileDialog openFile = new OpenFileDialog();
            openFile.Filter = "FlowDocument Files (*.xaml)|*.xaml|All Files (*.*)|*.*";
            openFile.InitialDirectory = "Content";

            if (openFile.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                FileStream xamlFile = openFile.OpenFile() as FileStream;
                if (xamlFile == null) return;
                else
                {
                    try
                    {
                        content = XamlReader.Load(xamlFile) as FlowDocument;
                        if (content == null)
                            throw (new XamlParseException("The specified file could not be loaded as a FlowDocument."));
                    }
                    catch (XamlParseException e)
                    {
                        String error = "There was a problem parsing the specified file:\n\n";
                        error += openFile.FileName;
                        error += "\n\nException details:\n\n";
                        error += e.Message;
                        System.Windows.MessageBox.Show(error);
                        return;
                    }
                    catch (Exception e)
                    {
                        String error = "There was a problem loading the specified file:\n\n";
                        error += openFile.FileName;
                        error += "\n\nException details:\n\n";
                        error += e.Message;
                        System.Windows.MessageBox.Show(error);
                        return;
                    }

                    // At this point, there is a non-null FlowDocument loaded into content.  
                    FlowDocRdr.Document = content;
                }
            }
        }

        void SaveFile(Object sender, RoutedEventArgs args)
        {
            SaveFileDialog saveFile = new SaveFileDialog();
            FileStream xamlFile = null;
            saveFile.Filter = "FlowDocument Files (*.xaml)|*.xaml|All Files (*.*)|*.*";
            if (saveFile.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                try
                {
                    xamlFile = saveFile.OpenFile() as FileStream;
                }
                catch (Exception e)
                {
                    String error = "There was a opening the file:\n\n";
                    error += saveFile.FileName;
                    error += "\n\nException details:\n\n";
                    error += e.Message;
                    System.Windows.MessageBox.Show(error);
                    return;
                }
                if (xamlFile == null) return;
                else
                {
                    XamlWriter.Save(FlowDocRdr.Document, xamlFile);
                    xamlFile.Close();
                }
            }
        }

        void Clear(Object sender, RoutedEventArgs args) { FlowDocRdr.Document = null; }
        void Exit(Object sender, RoutedEventArgs args) { this.Close(); }
    }
}