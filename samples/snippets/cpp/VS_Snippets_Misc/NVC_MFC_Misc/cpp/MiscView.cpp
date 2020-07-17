
// MiscView.cpp : implementation of the CMiscView class
//

#include "stdafx.h"
#include "Misc.h"

#include "MiscDoc.h"
#include "MiscView.h"

#ifdef _DEBUG
#define new DEBUG_NEW
#endif


// CMiscView

IMPLEMENT_DYNCREATE(CMiscView, CView)

BEGIN_MESSAGE_MAP(CMiscView, CView)
	// Standard printing commands
	ON_COMMAND(ID_FILE_PRINT, &CView::OnFilePrint)
	ON_COMMAND(ID_FILE_PRINT_DIRECT, &CView::OnFilePrint)
	ON_COMMAND(ID_FILE_PRINT_PREVIEW, &CMiscView::OnFilePrintPreview)
END_MESSAGE_MAP()

// CMiscView construction/destruction

CMiscView::CMiscView()
{
	// TODO: add construction code here

}

CMiscView::~CMiscView()
{
}

BOOL CMiscView::PreCreateWindow(CREATESTRUCT& cs)
{
	// TODO: Modify the Window class or styles here by modifying
	//  the CREATESTRUCT cs

	return CView::PreCreateWindow(cs);
}

// CMiscView drawing

void CMiscView::OnDraw(CDC* /*pDC*/)
{
	CMiscDoc* pDoc = GetDocument();
	ASSERT_VALID(pDoc);
	if (!pDoc)
		return;

	// TODO: add draw code for native data here
}


// CMiscView printing


void CMiscView::OnFilePrintPreview()
{
	AFXPrintPreview(this);
}

BOOL CMiscView::OnPreparePrinting(CPrintInfo* pInfo)
{
	// default preparation
	return DoPreparePrinting(pInfo);
}

void CMiscView::OnBeginPrinting(CDC* /*pDC*/, CPrintInfo* /*pInfo*/)
{
	// TODO: add extra initialization before printing
}

void CMiscView::OnEndPrinting(CDC* /*pDC*/, CPrintInfo* /*pInfo*/)
{
	// TODO: add cleanup after printing
}

void CMiscView::OnRButtonUp(UINT nFlags, CPoint point)
{
	ClientToScreen(&point);
	OnContextMenu(this, point);
}

void CMiscView::OnContextMenu(CWnd* pWnd, CPoint point)
{
	theApp.GetContextMenuManager()->ShowPopupMenu(IDR_POPUP_EDIT, point.x, point.y, this, TRUE);
}


// CMiscView diagnostics

#ifdef _DEBUG
void CMiscView::AssertValid() const
{
	CView::AssertValid();
}

void CMiscView::Dump(CDumpContext& dc) const
{
	CView::Dump(dc);
}

CMiscDoc* CMiscView::GetDocument() const // non-debug version is inline
{
	ASSERT(m_pDocument->IsKindOf(RUNTIME_CLASS(CMiscDoc)));
	return (CMiscDoc*)m_pDocument;
}
#endif //_DEBUG


// CMiscView message handlers
