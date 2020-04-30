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
#include "TabbedView.h"
#include "View2.h"

#ifdef _DEBUG
#define new DEBUG_NEW
#undef THIS_FILE
static char THIS_FILE[] = __FILE__;
#endif

/////////////////////////////////////////////////////////////////////////////
// CView2

IMPLEMENT_DYNCREATE(CView2, CListView)

CView2::CView2()
{
}

CView2::~CView2()
{
}


BEGIN_MESSAGE_MAP(CView2, CListView)
	ON_WM_CONTEXTMENU()
	ON_WM_WINDOWPOSCHANGING()
	ON_WM_KEYDOWN()
END_MESSAGE_MAP()

/////////////////////////////////////////////////////////////////////////////
// CView2 drawing

void CView2::OnDraw(CDC* /*pDC*/)
{
}

/////////////////////////////////////////////////////////////////////////////
// CView2 diagnostics

#ifdef _DEBUG
void CView2::AssertValid() const
{
	CListView::AssertValid();
}

void CView2::Dump(CDumpContext& dc) const
{
	CListView::Dump(dc);
}
#endif //_DEBUG

/////////////////////////////////////////////////////////////////////////////
// CView2 message handlers

BOOL CView2::PreCreateWindow(CREATESTRUCT& cs) 
{
	cs.style |= LVS_REPORT;
	return CListView::PreCreateWindow(cs);
}

void CView2::OnInitialUpdate() 
{
	CListView::OnInitialUpdate();

	CListCtrl& wndList = GetListCtrl ();

	wndList.SetExtendedStyle (LVS_EX_FULLROWSELECT | LVS_EX_GRIDLINES);

	const int nColumns = 15;
	int iColumn = 0;

	// Insert columns:
	for (iColumn = 0; iColumn < nColumns; iColumn++)
	{
		CString strColumn;
		strColumn.Format (_T("Column %d"), iColumn + 1);

		wndList.InsertColumn (iColumn, strColumn, LVCFMT_LEFT, 70);
	}

	// Insert items:
	for (int i = 0; i < 100; i++)
	{
		const CString strItemFmt = _T("Item (%d, %d)");
		
		CString strItem;
		strItem.Format (strItemFmt, 1, i + 1);

		int iItem = wndList.InsertItem (i, strItem, 0);

		for (iColumn = 1; iColumn < nColumns; iColumn++)
		{
			strItem.Format (strItemFmt, iColumn + 1, i + 1);
			wndList.SetItemText (iItem, iColumn, strItem);
		}
	}
}

void CView2::OnContextMenu(CWnd* /*pWnd*/, CPoint point) 
{
	theApp.ShowPopupMenu (IDR_CONTEXT_MENU, point, this);
}

void CView2::OnWindowPosChanging(WINDOWPOS FAR* lpwndpos) 
{
	CListView::OnWindowPosChanging(lpwndpos);
	
	// Hide horizontal scrollbar:
	ShowScrollBar (SB_HORZ, FALSE);
	ModifyStyle (WS_HSCROLL, 0, SWP_DRAWFRAME);
}

void CView2::OnKeyDown(UINT nChar, UINT nRepCnt, UINT nFlags) 
{
	CListView::OnKeyDown(nChar, nRepCnt, nFlags);

	if (nChar == VK_LEFT || nChar == VK_RIGHT)
	{
		// Assume scroll left or right. Synchronize scorll bars:
		CMFCTabCtrl* pTabWnd = DYNAMIC_DOWNCAST (CMFCTabCtrl, GetParent ());
		ASSERT_VALID (pTabWnd);

		pTabWnd->SynchronizeScrollBar ();
	}
}
