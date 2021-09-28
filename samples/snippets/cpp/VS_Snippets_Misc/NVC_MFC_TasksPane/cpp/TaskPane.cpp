// This is a part of the Microsoft Foundation Classes C++ library.
// Copyright (C) Microsoft Corporation
// All rights reserved.
//
// This source code is only intended as a supplement to the
// Microsoft Foundation Classes Reference and related
// electronic documentation provided with the library.
// See these sources for detailed information regarding the
// Microsoft Foundation Classes product.

#include "stdafx.h"
#include "TasksPane.h"
#include "TaskPane.h"

#ifdef _DEBUG
#define new DEBUG_NEW
#undef THIS_FILE
static char THIS_FILE[] = __FILE__;
#endif

/////////////////////////////////////////////////////////////////////////////
// CTaskPane

BEGIN_MESSAGE_MAP(CTaskPane, CMFCTasksPane)
	ON_WM_CREATE()
END_MESSAGE_MAP()

/////////////////////////////////////////////////////////////////////////////
// CTaskPane construction/destruction

CTaskPane::CTaskPane()
{
	m_nDocumentsGroup = -1;

	m_nUserColorGroup = -1;
	m_nUserColorTask = -1;
	// TODO: add one-time construction code here

}

CTaskPane::~CTaskPane()
{
}

/////////////////////////////////////////////////////////////////////////////
// CTaskPane message handlers

int CTaskPane::OnCreate(LPCREATESTRUCT lpCreateStruct) 
{
	if (CMFCTasksPane::OnCreate(lpCreateStruct) == -1)
		return -1;
	
	SetCaption (_T("Tasks Pane"));
	SetIconsList (IDB_TASKS, 16);

	EnableNavigationToolbar (TRUE);

	EnableWrapLabels (TRUE);
	EnableOffsetCustomControls (FALSE);

	m_nDocumentsGroup = AddGroup (_T("Open a document"), FALSE, TRUE);

	// Add MRU list:
	AddMRUFilesList (m_nDocumentsGroup);
	AddTask (m_nDocumentsGroup, _T("More Documents..."), 0, ID_FILE_OPEN);

	int nPage1Gr2 = AddGroup (_T("Custom group"));
	m_nUserColorGroup = nPage1Gr2;

	AddTask (nPage1Gr2, _T("Task 1"), 1, ID_TASK1);
	m_nUserColorTask = AddTask (nPage1Gr2, _T("Task 2"), 2, ID_TASK2);
	AddTask (nPage1Gr2, _T("Task 3"), 3, ID_TASK3);
	AddSeparator (nPage1Gr2);
	AddTask (nPage1Gr2, _T("Task 4"), 4, ID_TASK4);
	AddTask (nPage1Gr2, _T("Task 5"), 5, ID_TASK5);
	AddTask (nPage1Gr2, _T("Long task's name to see words wrap feature"), 6, ID_TASK6);

	int nPage1Gr3 = AddGroup (_T("Details"), TRUE);
	AddLabel (nPage1Gr3, _T("The Label contains text, which can be displayed in several lines. \n\nText can include line breaking characters \'\\n\' and &underline markers \'&&\'"));

	// Add second page:
	int nPage2 = AddPage (_T("Custom page"));

	int nPage2Gr1 = AddGroup (nPage2, _T("Tree Control"));

	if (!CreateTreeControl())
	{
		TRACE0("Failed to create the custom window\n");
		return -1;      // fail to create
	}

	const int nControlHeight = 65;

	AddWindow (nPage2Gr1, m_wndTree.GetSafeHwnd (), nControlHeight);
	AddTask (nPage2Gr1, _T("My favorites..."), 9, ID_TASK9);

	int nPage2Gr2 = AddGroup (nPage2, _T("Edit Control"));

	if (!CreateEditControl())
	{
		TRACE0("Failed to create the custom window\n");
		return -1;      // fail to create
	}

	AddWindow (nPage2Gr2, m_wndEdit.GetSafeHwnd (), nControlHeight);

	// Create tasks pane windows.
	// TODO: create your own tasks panes here:

	return 0;
}

void CTaskPane::UpdateMRUFilesList ()
{
	AddMRUFilesList (m_nDocumentsGroup);
	RedrawWindow ();
}

void CTaskPane::UpdateToolbar ()
{
	m_wndToolBar.RedrawWindow ();
}

BOOL CTaskPane::CreateTreeControl()
{
	CRect rectDummy (0, 0, 0, 0);
	const DWORD dwTreeStyle =	WS_CHILD | WS_VISIBLE | TVS_HASLINES | 
								TVS_LINESATROOT | TVS_HASBUTTONS;

	if(!m_wndTree.Create (dwTreeStyle, rectDummy, this, (UINT)-1))
	{
		TRACE0("Failed to create the custom window\n");
		return FALSE;
	}

	m_wndTree.ModifyStyleEx (0, WS_EX_CLIENTEDGE);

	HTREEITEM hRoot = m_wndTree.InsertItem (_T("Folders"));

	m_wndTree.InsertItem (_T("Folder 1"), hRoot);
	m_wndTree.InsertItem (_T("Folder 2"), hRoot);
	m_wndTree.InsertItem (_T("Folder 3"), hRoot);
	m_wndTree.InsertItem (_T("Folder 4"), hRoot);

	m_wndTree.Expand (hRoot, TVE_EXPAND);

	m_wndTree.RedrawWindow ();
	return TRUE;
}

BOOL CTaskPane::CreateEditControl()
{
	CRect rectDummy (0, 0, 0, 0);
	DWORD dwEditStyle = WS_CHILD | WS_VISIBLE |
		ES_AUTOHSCROLL | ES_AUTOVSCROLL | ES_MULTILINE;

	m_Font.CreateStockObject (DEFAULT_GUI_FONT);

	if (!m_wndEdit.Create (dwEditStyle, rectDummy, this, (UINT)-1))
	{
		TRACE0("Failed to create the edit window\n");
		return FALSE;
	}

	m_wndEdit.ModifyStyleEx (0, WS_EX_CLIENTEDGE);

	m_wndEdit.SetFont (&m_Font);
	m_wndEdit.SetWindowText(
		_T("This is the standard multiline Edit Box.\r\nHere you can type your text."));

	return TRUE;
}

