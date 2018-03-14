'************************************************************************************************
' *
' * File: Program.vb
' *
' * Description: Entry point for an application that supports UIAutomation in a custom control.
' * 
' * See ProviderForm.vb for a full description of this sample.
' * 
' * 
' *  This file is part of the Microsoft Windows SDK Code Samples.
' * 
' *  Copyright (C) Microsoft Corporation.  All rights reserved.
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
' ************************************************************************************************


Imports System
Imports System.Collections.Generic
Imports System.Windows.Forms

Namespace CustomControls
	Friend NotInheritable Class Program
		''' <summary>
		''' The main entry point for the application.
		''' </summary>
		Private Sub New()
		End Sub
		<STAThread>
		Shared Sub Main()
			Application.EnableVisualStyles()
			Application.Run(New SampleApplicationForm())
		End Sub
	End Class
End Namespace