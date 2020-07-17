// MFCRibbonAppView.cpp : implementation of the CMFCRibbonAppView class
//

#include "stdafx.h"
#include "MFCRibbonApp.h"

#include "MFCRibbonAppDoc.h"
#include "MFCRibbonAppView.h"

#ifdef _DEBUG
#define new DEBUG_NEW
#endif


// CMFCRibbonAppView

IMPLEMENT_DYNCREATE(CMFCRibbonAppView, CView)

BEGIN_MESSAGE_MAP(CMFCRibbonAppView, CView)
END_MESSAGE_MAP()

// CMFCRibbonAppView construction/destruction

CMFCRibbonAppView::CMFCRibbonAppView()
{
	// TODO: add construction code here

}

CMFCRibbonAppView::~CMFCRibbonAppView()
{
}

BOOL CMFCRibbonAppView::PreCreateWindow(CREATESTRUCT& cs)
{
	// TODO: Modify the Window class or styles here by modifying
	//  the CREATESTRUCT cs

	return CView::PreCreateWindow(cs);
}

// CMFCRibbonAppView drawing

void CMFCRibbonAppView::OnDraw(CDC* /*pDC*/)
{
	CMFCRibbonAppDoc* pDoc = GetDocument();
	ASSERT_VALID(pDoc);
	if (!pDoc)
		return;

	// TODO: add draw code for native data here
}

void CMFCRibbonAppView::OnRButtonUp(UINT nFlags, CPoint point)
{
	ClientToScreen(&point);
	OnContextMenu(this, point);
}

void CMFCRibbonAppView::OnContextMenu(CWnd* pWnd, CPoint point)
{
	theApp.GetContextMenuManager()->ShowPopupMenu(IDR_POPUP_EDIT, point.x, point.y, this, TRUE);
}


// CMFCRibbonAppView diagnostics

#ifdef _DEBUG
void CMFCRibbonAppView::AssertValid() const
{
	CView::AssertValid();
}

void CMFCRibbonAppView::Dump(CDumpContext& dc) const
{
	CView::Dump(dc);
}

CMFCRibbonAppDoc* CMFCRibbonAppView::GetDocument() const // non-debug version is inline
{
	ASSERT(m_pDocument->IsKindOf(RUNTIME_CLASS(CMFCRibbonAppDoc)));
	return (CMFCRibbonAppDoc*)m_pDocument;
}
#endif //_DEBUG


// CMFCRibbonAppView message handlers
