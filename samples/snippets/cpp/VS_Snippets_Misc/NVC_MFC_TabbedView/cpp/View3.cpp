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
#include "View3.h"

#ifdef _DEBUG
#define new DEBUG_NEW
#undef THIS_FILE
static char THIS_FILE[] = __FILE__;
#endif

/////////////////////////////////////////////////////////////////////////////
// CView3

IMPLEMENT_DYNCREATE(CView3, CFormView)

CView3::CView3()
	: CFormView(CView3::IDD)
{
}

CView3::~CView3()
{
}

void CView3::DoDataExchange(CDataExchange* pDX)
{
	CFormView::DoDataExchange(pDX);
}


BEGIN_MESSAGE_MAP(CView3, CFormView)
	ON_WM_CONTEXTMENU()
	ON_WM_WINDOWPOSCHANGING()
	ON_WM_ERASEBKGND()
END_MESSAGE_MAP()

/////////////////////////////////////////////////////////////////////////////
// CView3 diagnostics

#ifdef _DEBUG
void CView3::AssertValid() const
{
	CFormView::AssertValid();
}

void CView3::Dump(CDumpContext& dc) const
{
	CFormView::Dump(dc);
}
#endif //_DEBUG

/////////////////////////////////////////////////////////////////////////////
// CView3 message handlers

void CView3::OnContextMenu(CWnd* /*pWnd*/, CPoint point) 
{
	theApp.ShowPopupMenu (IDR_CONTEXT_MENU, point, this);
}

void CView3::OnWindowPosChanging(WINDOWPOS FAR* lpwndpos) 
{
	CFormView::OnWindowPosChanging(lpwndpos);
	
	// Hide horizontal scrollbar:
	ShowScrollBar (SB_HORZ, FALSE);
	ModifyStyle (WS_HSCROLL, 0, SWP_DRAWFRAME);
}


BOOL CView3::OnEraseBkgnd(CDC* /*pDC*/) 
{
	return TRUE;
}

void CView3::OnDraw(CDC* pDC) 
{
	CRect rectClient;
	GetClientRect (rectClient);
	
	pDC->FillSolidRect (rectClient, ::GetSysColor (COLOR_3DFACE));
}
