//
// TaskPane.cpp : implementation file
//

#include "stdafx.h"
#include "wordpad.h"
#include "TaskPane.h"

#ifdef _DEBUG
#define new DEBUG_NEW
#undef THIS_FILE
static char THIS_FILE[] = __FILE__;
#endif

/////////////////////////////////////////////////////////////////////////////
// CTaskPane

CTaskPane::CTaskPane()
{
	m_nDocumentsGroup = -1;
}

CTaskPane::~CTaskPane()
{
}


BEGIN_MESSAGE_MAP(CTaskPane, CMFCTasksPane)
	//{{AFX_MSG_MAP(CTaskPane)
	ON_WM_CREATE()
	//}}AFX_MSG_MAP
END_MESSAGE_MAP()


/////////////////////////////////////////////////////////////////////////////
// CTaskPane message handlers

int CTaskPane::OnCreate(LPCREATESTRUCT lpCreateStruct) 
{
	if (CMFCTasksPane::OnCreate(lpCreateStruct) == -1)
		return -1;
	
	SetIconsList (IDB_TASKS, 16);
	
	SetCaption (_T("Tasks Pane"));
	SetPageCaption (0, _T("New document"));

	m_nDocumentsGroup = AddGroup (_T("Open a document"), FALSE, TRUE);

	// Add MRU list
	AddMRUFilesList (m_nDocumentsGroup);
	AddTask (m_nDocumentsGroup, _T("More Documents..."), 0, ID_FILE_OPEN);

	int nPage1Gr2 = AddGroup (_T("New"));

	AddTask (nPage1Gr2, _T("Blank Document"), 1, ID_FILE_NEW);

	AddTask (nPage1Gr2, _T("Blank Web Page"), 2, ID_DUMMY);
	AddSeparator (nPage1Gr2);
	AddTask (nPage1Gr2, _T("Blank E-mail message"), 3, ID_DUMMY);

	int nPage1Gr3 = AddGroup (_T("New from existing document"));

	AddTask (nPage1Gr3, _T("Choose document..."), 4, ID_DUMMY);

	int nPage1Gr4 = AddGroup (_T("New from template"));

	AddTask (nPage1Gr4, _T("General Templates..."), 5, ID_DUMMY);
	AddTask (nPage1Gr4, _T("Templates on my Web Sites..."), 6, ID_DUMMY);
	AddTask (nPage1Gr4, _T("Templates on Microsoft.com..."), 7, ID_DUMMY);

	int nPage1Gr5 = AddGroup (_T(""), TRUE /* Group at bottom */);

	AddTask (nPage1Gr5, _T("Add Network Place..."), 8, ID_DUMMY);
	AddTask (nPage1Gr5, _T("Help..."), 9, ID_DUMMY);
	AddLabel (nPage1Gr5, _T("Label"));

	//--------
	// Page 2:
	//--------
	int nPage2 = AddPage (_T("Basic Search"));

	int nPage2Gr1 = AddGroup (nPage2, _T("Search for:"));

	AddTask (nPage2Gr1, _T("Search Tips..."), 9, ID_DUMMY);

	int nPage2Gr3 = AddGroup (nPage2, _T("See also:"));

	AddTask (nPage2Gr3, _T("Advanced Search"), 9, ID_DUMMY);
	AddTask (nPage2Gr3, _T("Find in this document..."), 9, ID_DUMMY);

	//--------
	// Page 3:
	//--------
	int nPage3 = AddPage (_T("Custom page"));

	int nPage3Gr1 = AddGroup (nPage3, _T("Folders"));

	if (!CreateTreeWindow())
	{
		TRACE0("Failed to create the custom window\n");
		return -1;      // fail to create
	}

	AddWindow (nPage3Gr1, m_wndTree.GetSafeHwnd (), 65);
	AddTask (nPage3Gr1, _T("My favorites..."), 0, ID_DUMMY);

	int nPage3Gr2 = AddGroup (nPage3, _T("Enter your text"));

	CRect rectDummy;
	rectDummy.SetRectEmpty ();
	DWORD dwEditStyle = WS_CHILD | WS_VISIBLE | WS_BORDER | 
		ES_AUTOHSCROLL | ES_AUTOVSCROLL | ES_MULTILINE | ES_WANTRETURN;
	m_Font.CreateStockObject (DEFAULT_GUI_FONT);
	if (!m_wndEdit.Create (dwEditStyle, rectDummy, this, (UINT)-1))
	{
		TRACE0("Failed to create the edit window\n");
		return -1;      // fail to create
	}
	m_wndEdit.SetFont (&m_Font);
	m_wndEdit.SetWindowText(
		_T("This is the standard multiline Edit Box.\r\nHere you can type your text."));
	
	AddWindow (nPage3Gr2, m_wndEdit.GetSafeHwnd (), 65);
	return 0;
}

void CTaskPane::UpdateMRUFilesList ()
{
	AddMRUFilesList (m_nDocumentsGroup);
	RedrawWindow ();
}

BOOL CTaskPane::CreateTreeWindow()
{
	CRect rectDummy (0, 0, 0, 0);
	const DWORD dwTreeStyle =	WS_CHILD | WS_VISIBLE | TVS_HASLINES | 
								TVS_LINESATROOT | TVS_HASBUTTONS;

	if(!m_wndTree.Create (dwTreeStyle, rectDummy, this, (UINT)-1))
	{
		TRACE0("Failed to create the custom window\n");
		return FALSE;      // fail to create
	}

	TCHAR szWinDir [MAX_PATH + 1];
	GetWindowsDirectory (szWinDir, MAX_PATH);

	SHFILEINFO sfi;
	HIMAGELIST himSystem = (HIMAGELIST)SHGetFileInfo (szWinDir,
                                       0,
                                       &sfi, 
                                       sizeof(SHFILEINFO), 
                                       SHGFI_SYSICONINDEX | SHGFI_SMALLICON);
	int iIndex = sfi.iIcon;

	m_wndTree.SetImageList (CImageList::FromHandle (himSystem), TVSIL_NORMAL);

	HTREEITEM hRoot = m_wndTree.InsertItem (_T("Folders"), iIndex, iIndex);
	m_wndTree.InsertItem (_T("Folder 1"), iIndex, iIndex, hRoot);
	m_wndTree.InsertItem (_T("Folder 2"), iIndex, iIndex, hRoot);
	m_wndTree.InsertItem (_T("Folder 3"), iIndex, iIndex, hRoot);
	m_wndTree.InsertItem (_T("Folder 4"), iIndex, iIndex, hRoot);
	m_wndTree.Expand (hRoot, TVE_EXPAND);

	m_wndTree.RedrawWindow ();

	return TRUE;
}

void CTaskPane::UpdateIcons ()
{
	SetIconsList (theApp.m_bHiColorIcons ? IDB_TASKS_HC : IDB_TASKS, 16);
}
