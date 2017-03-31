#include "stdafx.h"
#include "OutlookMultiViews.h"
#include "View2.h"

#ifdef _DEBUG
#define new DEBUG_NEW
#undef THIS_FILE
static char THIS_FILE[] = __FILE__;
#endif

static const CString strInfo = 
	_T("This sample illustrates how to switch between multiple views on a single document in a SDI application\r\n\r\nView 3");

/////////////////////////////////////////////////////////////////////////////
// CView2

IMPLEMENT_DYNCREATE(CView2, CView)

CView2::CView2()
{
}

CView2::~CView2()
{
}


BEGIN_MESSAGE_MAP(CView2, CView)
	ON_WM_CONTEXTMENU()
	// Standard printing commands
	ON_COMMAND(ID_FILE_PRINT, CView::OnFilePrint)
	ON_COMMAND(ID_FILE_PRINT_DIRECT, CView::OnFilePrint)
	ON_COMMAND(ID_FILE_PRINT_PREVIEW, OnFilePrintPreview)
END_MESSAGE_MAP()

/////////////////////////////////////////////////////////////////////////////
// CView2 drawing

void CView2::OnDraw(CDC* pDC)
{
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

	dm.FillGradient2 (rectFrame, RGB (196, 245, 184), RGB (119, 231, 91), 35);

	pDC->Draw3dRect (rectFrame, RGB (39, 126, 17), RGB (39, 126, 17));

	pDC->SetBkMode (TRANSPARENT);
	pDC->SetTextColor (0);
	pDC->DrawText (strInfo, rectText, DT_WORDBREAK);
	pDC->SelectObject (pFontOld);
}

/////////////////////////////////////////////////////////////////////////////
// CView2 diagnostics

#ifdef _DEBUG
void CView2::AssertValid() const
{
	CView::AssertValid();
}

void CView2::Dump(CDumpContext& dc) const
{
	CView::Dump(dc);
}
#endif //_DEBUG

/////////////////////////////////////////////////////////////////////////////
// CView2 message handlers

void CView2::OnFilePrintPreview() 
{
	AFXPrintPreview (this);
}

BOOL CView2::OnPreparePrinting(CPrintInfo* pInfo)
{
	// default preparation
	return DoPreparePrinting(pInfo);
}

void CView2::OnBeginPrinting(CDC* /*pDC*/, CPrintInfo* /*pInfo*/)
{
	// TODO: add extra initialization before printing
}

void CView2::OnEndPrinting(CDC* /*pDC*/, CPrintInfo* /*pInfo*/)
{
	// TODO: add cleanup after printing
}

void CView2::OnContextMenu(CWnd*, CPoint point)
{
	theApp.ShowPopupMenu (IDR_CONTEXT_MENU, point, this);
}

