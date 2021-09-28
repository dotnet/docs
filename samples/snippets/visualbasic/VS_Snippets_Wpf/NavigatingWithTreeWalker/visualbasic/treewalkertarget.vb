'************************************************************************************************\
'*
'* File: NavigateWithTreeWalker.vb
'*
'* Description:  
'*   The NavigateWithTreeWalker sample consists of a windows form with a tabcontrol with 
'*   three tabs. Each tabitem container has three controls on it. 
'*   Clicking the Start menu item initializes an instance of the myAutomationClass
'* 
'* 
'*
'* Copyright (C) 2005 by Microsoft Corporation.  All rights reserved.
'*
'\************************************************************************************************
Imports System.ComponentModel
Imports System.Text

Namespace TreeWalkerTarget
	Partial Public Class myTestForm
		Inherits Form
		Public Sub New()
			InitializeComponent()
		End Sub
	End Class
End Namespace