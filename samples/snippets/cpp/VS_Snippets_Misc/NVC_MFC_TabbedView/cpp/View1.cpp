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
#include "View1.h"

#ifdef _DEBUG
#define new DEBUG_NEW
#undef THIS_FILE
static char THIS_FILE[] = __FILE__;
#endif

static const CString strInfo = 
	_T("This sample illustrates usage of CTabbedView class. To create a tabbed view, you need to:\r\n\r\n")
	_T("* Derive your view class from CTabbedView\r\n")
	_T("* Add OnCreate handler\r\n")
	_T("* Call AddView for each view\r\n\r\n")
	_T("Please note that you cannot add an existing view to the tabbed view, the framework creates all tabbed views.");

/////////////////////////////////////////////////////////////////////////////
// CView1

IMPLEMENT_DYNCREATE(CView1, CScrollView)

CView1::CView1()
{
}

CView1::~CView1()
{
}


BEGIN_MESSAGE_MAP(CView1, CScrollView)
	ON_WM_WINDOWPOSCHANGING()
	ON_WM_HSCROLL()
	ON_WM_ERASEBKGND()
END_MESSAGE_MAP()

/////////////////////////////////////////////////////////////////////////////
// CView1 drawing

void CView1::OnDraw(CDC* pDC)
{
	const int iOffset = 20;

	CFont* pFontOld = (CFont*) pDC->SelectStockObject (DEFAULT_GUI_FONT);
	ASSERT (pFontOld != NULL);

	CRect rectClient;
	GetClientRect (&rectClient);

	CRect rectFill = rectClient;
	pDC->DPtoLP (&rectFill);

	pDC->FillSolidRect (rectFill, ::GetSysColor (COLOR_WINDOW));

	CRect rectText = rectClient;
	rectText.DeflateRect (iOffset, iOffset);
	pDC->DrawText (strInfo, rectText, DT_CALCRECT | DT_WORDBREAK);

	rectText.OffsetRect (	(rectClient.Width () - rectText.Width () - 2 * iOffset) / 2,
							(rectClient.Height () - rectText.Height () - 2 * iOffset) / 2);

	CRect rectFrame = rectText;
	rectFrame.InflateRect (iOffset, iOffset);

	pDC->FillSolidRect (rectFrame, ::GetSysColor (COLOR_INFOBK));
	
	rectFrame.DeflateRect (1, 1);
	pDC->Draw3dRect (rectFrame, ::GetSysColor (COLOR_3DSHADOW), 
					::GetSysColor (COLOR_3DLIGHT));

	rectFrame.DeflateRect (2, 2);
	pDC->Draw3dRect (rectFrame, ::GetSysColor (COLOR_3DSHADOW), 
					::GetSysColor (COLOR_3DLIGHT));

	pDC->SetTextColor (::GetSysColor (COLOR_INFOTEXT));
	pDC->SetBkMode (TRANSPARENT);

	pDC->DrawText (strInfo, rectText, DT_WORDBREAK);

	pDC->SelectObject (pFontOld);
}

/////////////////////////////////////////////////////////////////////////////
// CView1 diagnostics

#ifdef _DEBUG
void CView1::AssertValid() const
{
	CScrollView::AssertValid();
}

void CView1::Dump(CDumpContext& dc) const
{
	CScrollView::Dump(dc);
}
#endif //_DEBUG

/////////////////////////////////////////////////////////////////////////////
// CView1 message handlers

void CView1::OnInitialUpdate() 
{
	CScrollView::OnInitialUpdate();
	
	SetScrollSizes (MM_TEXT, CSize (1000, 1000));

	CMFCTabCtrl* pTabWnd = DYNAMIC_DOWNCAST (CMFCTabCtrl, GetParent ());
	ASSERT_VALID (pTabWnd);

	pTabWnd->SynchronizeScrollBar ();
}

void CView1::OnWindowPosChanging(WINDOWPOS FAR* lpwndpos) 
{
	CScrollView::OnWindowPosChanging(lpwndpos);
	
	// Hide horizontal scrollbar:
	ShowScrollBar (SB_HORZ, FALSE);
	ModifyStyle (WS_HSCROLL, 0, SWP_DRAWFRAME);
}

void CView1::OnHScroll(UINT nSBCode, UINT nPos, CScrollBar* /*pScrollBar*/) 
{
	CMFCTabCtrl* pTabWnd = DYNAMIC_DOWNCAST (CMFCTabCtrl, GetParent ());
	ASSERT_VALID (pTabWnd);

	CScrollView::OnHScroll(nSBCode, nPos, pTabWnd->GetScrollBar ());
}

CScrollBar* CView1::GetScrollBarCtrl(int nBar) const
{
	if (nBar == SB_HORZ)
	{
		CMFCTabCtrl* pTabWnd = DYNAMIC_DOWNCAST (CMFCTabCtrl, GetParent ());
		ASSERT_VALID (pTabWnd);

		return pTabWnd->GetScrollBar ();
	}
	
	return CScrollView::GetScrollBarCtrl(nBar);
}

BOOL CView1::OnEraseBkgnd(CDC* /*pDC*/) 
{
	return TRUE;
}
