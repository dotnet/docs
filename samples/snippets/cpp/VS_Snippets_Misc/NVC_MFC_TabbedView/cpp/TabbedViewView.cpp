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

#include "TabbedViewDoc.h"
#include "TabbedViewView.h"

#include "View1.h"
#include "View2.h"
#include "View3.h"
#include "View4.h"

#ifdef _DEBUG
#define new DEBUG_NEW
#undef THIS_FILE
static char THIS_FILE[] = __FILE__;
#endif

/////////////////////////////////////////////////////////////////////////////
// CTabbedViewView

IMPLEMENT_DYNCREATE(CTabbedViewView, CTabView)

BEGIN_MESSAGE_MAP(CTabbedViewView, CTabView)
	ON_WM_CREATE()
	ON_WM_ERASEBKGND()
	ON_WM_CONTEXTMENU()
	// Standard printing commands
	ON_COMMAND(ID_FILE_PRINT, CTabView::OnFilePrint)
	ON_COMMAND(ID_FILE_PRINT_DIRECT, CTabView::OnFilePrint)
	ON_COMMAND(ID_FILE_PRINT_PREVIEW, OnFilePrintPreview)
END_MESSAGE_MAP()

/////////////////////////////////////////////////////////////////////////////
// CTabbedViewView construction/destruction

CTabbedViewView::CTabbedViewView()
{
}

CTabbedViewView::~CTabbedViewView()
{
}

BOOL CTabbedViewView::PreCreateWindow(CREATESTRUCT& cs)
{
	// TODO: Modify the Window class or styles here by modifying
	//  the CREATESTRUCT cs

	return CTabView::PreCreateWindow(cs);
}

/////////////////////////////////////////////////////////////////////////////
// CTabbedViewView drawing

void CTabbedViewView::OnDraw(CDC* /*pDC*/)
{
//	CTabbedViewDoc* pDoc = GetDocument();
//	ASSERT_VALID(pDoc);
	// TODO: add draw code for native data here
}

/////////////////////////////////////////////////////////////////////////////
// CTabbedViewView printing

void CTabbedViewView::OnFilePrintPreview() 
{
	AFXPrintPreview (this);
}

BOOL CTabbedViewView::OnPreparePrinting(CPrintInfo* pInfo)
{
	// default preparation
	return DoPreparePrinting(pInfo);
}

void CTabbedViewView::OnBeginPrinting(CDC* /*pDC*/, CPrintInfo* /*pInfo*/)
{
	// TODO: add extra initialization before printing
}

void CTabbedViewView::OnEndPrinting(CDC* /*pDC*/, CPrintInfo* /*pInfo*/)
{
	// TODO: add cleanup after printing
}

/////////////////////////////////////////////////////////////////////////////
// CTabbedViewView diagnostics

#ifdef _DEBUG
void CTabbedViewView::AssertValid() const
{
	CTabView::AssertValid();
}

void CTabbedViewView::Dump(CDumpContext& dc) const
{
	CTabView::Dump(dc);
}

CTabbedViewDoc* CTabbedViewView::GetDocument() // non-debug version is inline
{
	ASSERT(m_pDocument->IsKindOf(RUNTIME_CLASS(CTabbedViewDoc)));
	return (CTabbedViewDoc*)m_pDocument;
}
#endif //_DEBUG

/////////////////////////////////////////////////////////////////////////////
// CTabbedViewView message handlers

void CTabbedViewView::OnContextMenu(CWnd*, CPoint point)
{
	theApp.ShowPopupMenu (IDR_CONTEXT_MENU, point, this);
}

int CTabbedViewView::OnCreate(LPCREATESTRUCT lpCreateStruct) 
{
	if (CTabView::OnCreate(lpCreateStruct) == -1)
		return -1;
	
	AddView (RUNTIME_CLASS (CView1), _T("Simple"), 100);
	AddView (RUNTIME_CLASS (CView2), _T("List"), 101);
	AddView (RUNTIME_CLASS (CView3), _T("Form"), 102);
	AddView (RUNTIME_CLASS (CView4), _T("ScrollView"), 102);

	return 0;
}

BOOL CTabbedViewView::OnEraseBkgnd(CDC* /*pDC*/) 
{
	return TRUE;
}
