// This MFC Samples source code demonstrates using MFC Microsoft Office Fluent User Interface 
// (the "Fluent UI") and is provided only as referential material to supplement the 
// Microsoft Foundation Classes Reference and related electronic documentation 
// included with the MFC C++ library software.  
// License terms to copy, use or distribute the Fluent UI are available separately.  
// To learn more about our Fluent UI licensing program, please visit 
// http://msdn.microsoft.com/officeui.
//
// Copyright (C) Microsoft Corporation
// All rights reserved.

#include "stdafx.h"
#include "MSOffice2007Demo.h"
#include "TaskPane.h"

#ifdef _DEBUG
#define new DEBUG_NEW
#undef THIS_FILE
static char THIS_FILE[] = __FILE__;
#endif

/////////////////////////////////////////////////////////////////////////////
// CTaskPane

BEGIN_MESSAGE_MAP(CTaskPane, CMFCTasksPane)
	//{{AFX_MSG_MAP(CTaskPane)
	ON_WM_CREATE()
	//}}AFX_MSG_MAP
END_MESSAGE_MAP()

/////////////////////////////////////////////////////////////////////////////
// CTaskPane construction/destruction

CTaskPane::CTaskPane()
{
}

CTaskPane::~CTaskPane()
{
}

/////////////////////////////////////////////////////////////////////////////
// CTaskPane message handlers

int CTaskPane::OnCreate(LPCREATESTRUCT lpCreateStruct)
{
	SetWindowText(_T("Clipboard"));

	if (CMFCTasksPane::OnCreate(lpCreateStruct) == -1)
		return -1;

	// Create tasks pane windows.
	// TODO: create your own tasks panes here:

	return 0;
}

