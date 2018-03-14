// This is a part of the Microsoft Foundation Classes C++ library.
// Copyright (c) Microsoft Corporation.  All rights reserved.
//
// This source code is only intended as a supplement to the
// Microsoft Foundation Classes Reference and related
// electronic documentation provided with the library.
// See these sources for detailed information regarding the
// Microsoft Foundation Classes product.

#include "stdafx.h"
#include "OutlookDemo.h"
#include "FolderListBar.h"
#include "WorkspaceObj.h"
#include "MainFrm.h"

#ifdef _DEBUG
#define new DEBUG_NEW
#undef THIS_FILE
static char THIS_FILE[] = __FILE__;
#endif

const int idTree = 5;

/////////////////////////////////////////////////////////////////////////////
// CFolderListBar

CFolderListBar::CFolderListBar(const CObList& lstWorkspaces, CImageList& images) : m_wndFolders(lstWorkspaces, images)
{
	// m_nSize = 200; // Initial width
	m_bNotifyFrame = TRUE;
}

CFolderListBar::~CFolderListBar()
{
}

BEGIN_MESSAGE_MAP(CFolderListBar, CDockablePane)
	ON_WM_CREATE()
	ON_WM_SIZE()
	ON_NOTIFY(TVN_SELCHANGED, idTree, OnSelectTree)
END_MESSAGE_MAP()

/////////////////////////////////////////////////////////////////////////////
// CFolderListBar message handlers

int CFolderListBar::OnCreate(LPCREATESTRUCT lpCreateStruct)
{
	if (CDockablePane::OnCreate(lpCreateStruct) == -1)
		return -1;

	CRect rectDummy(0, 0, 0, 0);
	m_wndFolders.Create(0, rectDummy, this, idTree);

	return 0;
}

void CFolderListBar::OnSize(UINT nType, int cx, int cy)
{
	CDockablePane::OnSize(nType, cx, cy);
	if (CanAdjustLayout())
	{
		m_wndFolders.SetWindowPos(NULL, 0, 0, cx , cy , SWP_NOACTIVATE | SWP_NOZORDER);
	}
}

void CFolderListBar::OnEraseWorkArea(CDC* pDC, CRect rectWorkArea)
{
	ASSERT_VALID(pDC);
	pDC->FillSolidRect(rectWorkArea, GetSysColor(COLOR_WINDOW));
}

void CFolderListBar::OnSelectTree(NMHDR* /*pNMHDR*/, LRESULT* pResult)
{
	HTREEITEM hTreeItem = m_wndFolders.GetSelectedItem();
	if (hTreeItem != NULL)
	{
		CWorkspaceObj* pWS = (CWorkspaceObj*) m_wndFolders.GetItemData(hTreeItem);
		ASSERT_VALID(pWS);

		CMainFrame* pMainFrame = DYNAMIC_DOWNCAST(CMainFrame, GetParentFrame());
		if (pMainFrame != NULL && m_bNotifyFrame)
		{
			pMainFrame->SetWorkSpace(pWS);
		}
	}

	*pResult = 0;
}

BOOL CFolderListBar::SelectWorkspace(CWorkspaceObj* pWS)
{
	ASSERT_VALID(pWS);

	m_bNotifyFrame = FALSE;
	m_wndFolders.SelectWorkspace(pWS);
	m_bNotifyFrame = TRUE;

	return TRUE;
}

