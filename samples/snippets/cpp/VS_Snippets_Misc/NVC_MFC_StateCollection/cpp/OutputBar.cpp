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
#include "StateCollection.h"
#include "OutputBar.h"

#ifdef _DEBUG
#define new DEBUG_NEW
#undef THIS_FILE
static char THIS_FILE[] = __FILE__;
#endif

/////////////////////////////////////////////////////////////////////////////
// COutputBar

BEGIN_MESSAGE_MAP(COutputBar, CDockablePane)
	ON_WM_CREATE()
	ON_WM_SIZE()
END_MESSAGE_MAP()

/////////////////////////////////////////////////////////////////////////////
// COutputBar construction/destruction

COutputBar::COutputBar()
{
	// TODO: add one-time construction code here

}

COutputBar::~COutputBar()
{
}

/////////////////////////////////////////////////////////////////////////////
// COutputBar message handlers

int COutputBar::OnCreate(LPCREATESTRUCT lpCreateStruct) 
{
	if (CDockablePane::OnCreate(lpCreateStruct) == -1)
		return -1;
	
	CRect rectDummy;
	rectDummy.SetRectEmpty ();

	// <snippet2>
	// Create tabs window:
	// CRect rectDummy
	// this is a pointer to a parent window
	// fourth parameter is the id of the tab control
	if (!m_wndTabs.Create (CMFCTabCtrl::STYLE_FLAT, rectDummy, this, 1))
	{
		TRACE0("Failed to create output tab window\n");
		return -1;      // fail to create
	}
	// </snippet2>

	// Create tree windows.
	// TODO: create your own tab windows here:
	const DWORD dwViewStyle =	
		LBS_NOINTEGRALHEIGHT | WS_CHILD | WS_VISIBLE | WS_HSCROLL | WS_VSCROLL;
	
	if (!m_wndList1.Create (dwViewStyle, rectDummy, &m_wndTabs, 2) ||
		!m_wndList2.Create (dwViewStyle, rectDummy, &m_wndTabs, 3) ||
		!m_wndList3.Create (dwViewStyle, rectDummy, &m_wndTabs, 4))
	{
		TRACE0("Failed to create output view\n");
		return -1;      // fail to create
	}

	// <snippet3>
	// Attach list windows to tab:
	// CListCtrl m_wndList1
	// CListCtrl m_wndList2
	// CListCtrl m_wndList3
	m_wndTabs.AddTab (&m_wndList1, _T("Output 1"), (UINT)-1);
	m_wndTabs.AddTab (&m_wndList2, _T("Output 2"), (UINT)-1);
	m_wndTabs.AddTab (&m_wndList3, _T("Output 3"), (UINT)-1);

	m_wndTabs.EnableActiveTabCloseButton();
	m_wndTabs.EnableInPlaceEdit(true);
	m_wndTabs.EnableTabDocumentsMenu();
	m_wndTabs.SetActiveTab(1);
	m_wndTabs.SetDrawFrame();
	m_wndTabs.SetFlatFrame();
	// </snippet3>


	return 0;
}

void COutputBar::OnSize(UINT nType, int cx, int cy) 
{
	CDockablePane::OnSize(nType, cx, cy);

	// Tab control should cover a whole client area:
	m_wndTabs.SetWindowPos (NULL, -1, -1, cx, cy,
		SWP_NOMOVE | SWP_NOACTIVATE | SWP_NOZORDER);
}

