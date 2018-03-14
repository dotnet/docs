#include "stdafx.h"
#include "OutlookMultiViews.h"

#include "OutlookMultiViewsDoc.h"
#include "OutlookMultiViewsView.h"

#ifdef _DEBUG
#define new DEBUG_NEW
#undef THIS_FILE
static char THIS_FILE[] = __FILE__;
#endif

static const CString strInfo = 
	_T("This sample illustrates how to switch between multiple views on a single document in a SDI application\r\n\r\nView 1");

/////////////////////////////////////////////////////////////////////////////
// COutlookMultiViewsView

IMPLEMENT_DYNCREATE(COutlookMultiViewsView, CView)

BEGIN_MESSAGE_MAP(COutlookMultiViewsView, CView)
	ON_WM_CONTEXTMENU()
	// Standard printing commands
	ON_COMMAND(ID_FILE_PRINT, CView::OnFilePrint)
	ON_COMMAND(ID_FILE_PRINT_DIRECT, CView::OnFilePrint)
	ON_COMMAND(ID_FILE_PRINT_PREVIEW, OnFilePrintPreview)
END_MESSAGE_MAP()

/////////////////////////////////////////////////////////////////////////////
// COutlookMultiViewsView construction/destruction

COutlookMultiViewsView::COutlookMultiViewsView()
{
	// TODO: add construction code here

}

COutlookMultiViewsView::~COutlookMultiViewsView()
{
}

BOOL COutlookMultiViewsView::PreCreateWindow(CREATESTRUCT& cs)
{
	// TODO: Modify the Window class or styles here by modifying
	//  the CREATESTRUCT cs

	return CView::PreCreateWindow(cs);
}

/////////////////////////////////////////////////////////////////////////////
// COutlookMultiViewsView drawing

void COutlookMultiViewsView::OnDraw(CDC* pDC)
{
//	COutlookMultiViewsDoc* pDoc = GetDocument();
//	ASSERT_VALID(pDoc);

	const int iOffset = 20;

	CFont* pFontOld = (CFont*) pDC->SelectStockObject (DEFAULT_GUI_FONT);
	ASSERT (pFontOld != NULL);

	CRect rectClient;
	GetClientRect (&rectClient);

	CRect rectText = rectClient;
	rectText.DeflateRect (iOffset, iOffset);
	pDC->DrawText (strInfo, rectText, DT_CALCRECT | DT_WORDBREAK);

	rectText.OffsetRect (	(rectClient.Width () - rectText.Width () - 2 * iOffset) / 2,
							(rectClient.Height () - rectText.Height () - 2 * iOffset) / 2);

	CRect rectFrame = rectText;
	rectFrame.InflateRect (iOffset, iOffset);

	CDrawingManager dm (*pDC);

	dm.FillGradient2 (rectFrame, RGB (246, 241, 178), RGB (234, 223, 67), 35);

	pDC->Draw3dRect (rectFrame, RGB (168, 158, 18), RGB (168, 158, 18));

	pDC->SetBkMode (TRANSPARENT);
	pDC->SetTextColor (0);
	pDC->DrawText (strInfo, rectText, DT_WORDBREAK);
	pDC->SelectObject (pFontOld);
}

/////////////////////////////////////////////////////////////////////////////
// COutlookMultiViewsView printing

void COutlookMultiViewsView::OnFilePrintPreview() 
{
	AFXPrintPreview (this);
}

BOOL COutlookMultiViewsView::OnPreparePrinting(CPrintInfo* pInfo)
{
	// default preparation
	return DoPreparePrinting(pInfo);
}

void COutlookMultiViewsView::OnBeginPrinting(CDC* /*pDC*/, CPrintInfo* /*pInfo*/)
{
	// TODO: add extra initialization before printing
}

void COutlookMultiViewsView::OnEndPrinting(CDC* /*pDC*/, CPrintInfo* /*pInfo*/)
{
	// TODO: add cleanup after printing
}

/////////////////////////////////////////////////////////////////////////////
// COutlookMultiViewsView diagnostics

#ifdef _DEBUG
void COutlookMultiViewsView::AssertValid() const
{
	CView::AssertValid();
}

void COutlookMultiViewsView::Dump(CDumpContext& dc) const
{
	CView::Dump(dc);
}

COutlookMultiViewsDoc* COutlookMultiViewsView::GetDocument() // non-debug version is inline
{
	ASSERT(m_pDocument->IsKindOf(RUNTIME_CLASS(COutlookMultiViewsDoc)));
	return (COutlookMultiViewsDoc*)m_pDocument;
}
#endif //_DEBUG

/////////////////////////////////////////////////////////////////////////////
// COutlookMultiViewsView message handlers

void COutlookMultiViewsView::OnContextMenu(CWnd*, CPoint point)
{
	theApp.ShowPopupMenu (IDR_CONTEXT_MENU, point, this);
}

