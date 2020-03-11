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
#include "explorer.h"
#include "FolderBar.h"

#ifdef _DEBUG
#define new DEBUG_NEW
#undef THIS_FILE
static char THIS_FILE[] = __FILE__;
#endif

const int idTree = 1;

/////////////////////////////////////////////////////////////////////////////
// CFolderBar

CFolderBar::CFolderBar()
{
//	m_nSize = 300;	// Initial width
}

CFolderBar::~CFolderBar()
{
}


BEGIN_MESSAGE_MAP(CFolderBar, CDockablePane)
	ON_WM_CREATE()
	ON_WM_SIZE()
	ON_WM_SETFOCUS()
	ON_WM_ERASEBKGND()
END_MESSAGE_MAP()


/////////////////////////////////////////////////////////////////////////////
// CFolderBar message handlers

int CFolderBar::OnCreate(LPCREATESTRUCT lpCreateStruct) 
{
	if (CDockablePane::OnCreate(lpCreateStruct) == -1)
		return -1;
	
	// <snippet5>
	// const int idTree = 1
	CRect rectDummy (0, 0, 0, 0);
	const DWORD dwViewStyle =	WS_CHILD | WS_VISIBLE | TVS_HASLINES | 
								TVS_LINESATROOT | TVS_HASBUTTONS;

	// The this pointer points to CFolderBar class which extends the CDockablePane class
	m_wndShellTree.Create (dwViewStyle, rectDummy, this, idTree);
	// </snippet5>
	return 0;
}

void CFolderBar::OnSize(UINT nType, int cx, int cy) 
{
	CDockablePane::OnSize(nType, cx, cy);
	
	m_wndShellTree.SetWindowPos (NULL, 0, 0,
		cx, cy,
		SWP_NOACTIVATE | SWP_NOZORDER);
}

void CFolderBar::OnSetFocus(CWnd* pOldWnd)
{
	CDockablePane::OnSetFocus(pOldWnd);
	m_wndShellTree.SetFocus ();
}

BOOL CFolderBar::OnEraseBkgnd(CDC* /*pDC*/) 
{
	return TRUE;
}
