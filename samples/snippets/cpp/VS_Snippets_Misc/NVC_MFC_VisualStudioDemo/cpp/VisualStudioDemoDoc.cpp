// This is a part of the Microsoft Foundation Classes C++ library.
// Copyright (c) Microsoft Corporation.  All rights reserved.
//
// This source code is only intended as a supplement to the
// Microsoft Foundation Classes Reference and related
// electronic documentation provided with the library.
// See these sources for detailed information regarding the
// Microsoft Foundation Classes product.

#include "stdafx.h"
#include "VisualStudioDemo.h"

#include "VisualStudioDemoDoc.h"

#ifdef _DEBUG
#define new DEBUG_NEW
#endif

// CVisualStudioDemoDoc

IMPLEMENT_DYNCREATE(CVisualStudioDemoDoc, CDocument)

BEGIN_MESSAGE_MAP(CVisualStudioDemoDoc, CDocument)
	//{{AFX_MSG_MAP(CVisualStudioDemoDoc)
	ON_COMMAND(ID_DUMMY_SELECT_ACTIVE_CONFIGURATION, OnDummySelectActiveConfiguration)
	ON_COMMAND(ID_DUMMY_BUILD, &CVisualStudioDemoDoc::OnDummyBuild)
	ON_COMMAND(ID_DUMMY_COMPILE, &CVisualStudioDemoDoc::OnDummyCompile)
	ON_COMMAND(ID_DUMMY_EXECUTE, &CVisualStudioDemoDoc::OnDummyExecute)
	ON_COMMAND(ID_DUMMY_GO, &CVisualStudioDemoDoc::OnDummyGo)
	ON_COMMAND(ID_DUMMY_REBUILD_ALL, &CVisualStudioDemoDoc::OnDummyRebuildAll)
	ON_COMMAND(ID_DUMMY_REMOVE_ALL_BREAKPOINTS, &CVisualStudioDemoDoc::OnDummyRemoveAllBreakpoints)
	ON_COMMAND(ID_DUMMY_CLEAN, &CVisualStudioDemoDoc::OnDummyClean)
	ON_COMMAND(ID_NEW_DIALOG, OnNewDialog)
	ON_COMMAND(ID_NEW_ACCELERATOR, OnNewAccelerator)
	ON_COMMAND(ID_NEW_BITMAP, OnNewBitmap)
	ON_COMMAND(ID_NEW_CURSOR, OnNewCursor)
	ON_COMMAND(ID_NEW_ICON, OnNewIcon)
	ON_COMMAND(ID_NEW_MENU, OnNewMenu)
	ON_COMMAND(ID_NEW_STRING_TABLE, OnNewStringTable)
	ON_COMMAND(ID_NEW_TOOLBAR, OnNewToolbar)
	ON_COMMAND(ID_NEW_VERSION, OnNewVersion)
	ON_CBN_SELENDOK(ID_DUMMY_SELECT_ACTIVE_CONFIGURATION, OnDummySelectActiveConfiguration)
	//}}AFX_MSG_MAP
END_MESSAGE_MAP()

// CVisualStudioDemoDoc construction/destruction

CVisualStudioDemoDoc::CVisualStudioDemoDoc()
{
	// TODO: add one-time construction code here
}

CVisualStudioDemoDoc::~CVisualStudioDemoDoc()
{
}

BOOL CVisualStudioDemoDoc::OnNewDocument()
{
	if (!CDocument::OnNewDocument())
		return FALSE;

	// TODO: add reinitialization code here
	//(SDI documents will reuse this document)
	return TRUE;
}

void CVisualStudioDemoDoc::OnDummySelectActiveConfiguration()
{
	CMFCToolBarComboBoxButton* pSrcCombo = NULL;

	CObList listButtons;
	if (CMFCToolBar::GetCommandButtons(ID_DUMMY_SELECT_ACTIVE_CONFIGURATION, listButtons) > 0)
	{
		for (POSITION posCombo = listButtons.GetHeadPosition();
			pSrcCombo == NULL && posCombo != NULL;)
		{
			CMFCToolBarComboBoxButton* pCombo = DYNAMIC_DOWNCAST(CMFCToolBarComboBoxButton, listButtons.GetNext(posCombo));

			if (pCombo != NULL && CMFCToolBar::IsLastCommandFromButton(pCombo))
			{
				pSrcCombo = pCombo;
			}
		}
	}

	if (pSrcCombo != NULL)
	{
		ASSERT_VALID(pSrcCombo);

		LPCTSTR lpszSelItem = pSrcCombo->GetItem();
		CString strSelItem = (lpszSelItem == NULL) ? _T("") : lpszSelItem;

		AfxMessageBox(strSelItem);
	}
	else
	{
		AfxMessageBox(_T("Show \"Set Active Configuration\" dialog...."));
	}
}

// CVisualStudioDemoDoc serialization

void CVisualStudioDemoDoc::Serialize(CArchive& ar)
{
	// CEditView contains an edit control which handles all serialization
	reinterpret_cast<CEditView*>(m_viewList.GetHead())->SerializeRaw(ar);
}

// CVisualStudioDemoDoc diagnostics

#ifdef _DEBUG
void CVisualStudioDemoDoc::AssertValid() const
{
	CDocument::AssertValid();
}

void CVisualStudioDemoDoc::Dump(CDumpContext& dc) const
{
	CDocument::Dump(dc);
}
#endif //_DEBUG

// CVisualStudioDemoDoc commands

void CVisualStudioDemoDoc::OnDummyBuild()
{
	// TODO: Add your command handler code here
}

void CVisualStudioDemoDoc::OnDummyCompile()
{
	// TODO: Add your command handler code here
}

void CVisualStudioDemoDoc::OnDummyExecute()
{
	// TODO: Add your command handler code here
}

void CVisualStudioDemoDoc::OnDummyGo()
{
	// TODO: Add your command handler code here
}

void CVisualStudioDemoDoc::OnDummyRebuildAll()
{
	// TODO: Add your command handler code here
}

void CVisualStudioDemoDoc::OnDummyRemoveAllBreakpoints()
{
	// TODO: Add your command handler code here
}

void CVisualStudioDemoDoc::OnDummyClean()
{
	// TODO: Add your command handler code here
}
void CVisualStudioDemoDoc::OnNewDialog()
{
	AfxMessageBox(_T("New Dialog"));
}

void CVisualStudioDemoDoc::OnNewAccelerator()
{
	AfxMessageBox(_T("New Accelerator"));
}

void CVisualStudioDemoDoc::OnNewBitmap()
{
	AfxMessageBox(_T("New Bitmap"));
}

void CVisualStudioDemoDoc::OnNewCursor()
{
	AfxMessageBox(_T("New Cursor"));
}

void CVisualStudioDemoDoc::OnNewIcon()
{
	AfxMessageBox(_T("New Icon"));
}

void CVisualStudioDemoDoc::OnNewMenu()
{
	AfxMessageBox(_T("New Menu"));
}

void CVisualStudioDemoDoc::OnNewStringTable()
{
	AfxMessageBox(_T("New StringTable"));
}

void CVisualStudioDemoDoc::OnNewToolbar()
{
	AfxMessageBox(_T("New Toolbar"));
}

void CVisualStudioDemoDoc::OnNewVersion()
{
	AfxMessageBox(_T("New Version"));
}

