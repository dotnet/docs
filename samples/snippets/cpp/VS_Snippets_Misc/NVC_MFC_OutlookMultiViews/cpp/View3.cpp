#include "stdafx.h"
#include "OutlookMultiViews.h"
#include "View3.h"

#ifdef _DEBUG
#define new DEBUG_NEW
#undef THIS_FILE
static char THIS_FILE[] = __FILE__;
#endif

static const CString strInfo = 
	_T("This sample illustrates how to switch between multiple views on a single document in a SDI application\r\n\r\nView 4");

/////////////////////////////////////////////////////////////////////////////
// CView3

IMPLEMENT_DYNCREATE(CView3, CView)

CView3::CView3()
{
}

CView3::~CView3()
{
}


BEGIN_MESSAGE_MAP(CView3, CView)
	ON_WM_CONTEXTMENU()
	// Standard printing commands
	ON_COMMAND(ID_FILE_PRINT, CView::OnFilePrint)
	ON_COMMAND(ID_FILE_PRINT_DIRECT, CView::OnFilePrint)
	ON_COMMAND(ID_FILE_PRINT_PREVIEW, OnFilePrintPreview)
END_MESSAGE_MAP()

/////////////////////////////////////////////////////////////////////////////
// CView3 drawing

void CView3::OnDraw(CDC* pDC)
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

	dm.FillGradient2 (rectFrame, RGB (219, 227, 251), RGB (167, 186, 247), 35);

	pDC->Draw3dRect (rectFrame, RGB (94, 128, 240), RGB (94, 128, 240));

	pDC->SetBkMode (TRANSPARENT);
	pDC->SetTextColor (0);
	pDC->DrawText (strInfo, rectText, DT_WORDBREAK);
	pDC->SelectObject (pFontOld);
}

/////////////////////////////////////////////////////////////////////////////
// CView3 diagnostics

#ifdef _DEBUG
void CView3::AssertValid() const
{
	CView::AssertValid();
}

void CView3::Dump(CDumpContext& dc) const
{
	CView::Dump(dc);
}
#endif //_DEBUG

/////////////////////////////////////////////////////////////////////////////
// CView3 message handlers

void CView3::OnFilePrintPreview() 
{
	AFXPrintPreview (this);
}

BOOL CView3::OnPreparePrinting(CPrintInfo* pInfo)
{
	// default preparation
	return DoPreparePrinting(pInfo);
}

void CView3::OnBeginPrinting(CDC* /*pDC*/, CPrintInfo* /*pInfo*/)
{
	// TODO: add extra initialization before printing
}

void CView3::OnEndPrinting(CDC* /*pDC*/, CPrintInfo* /*pInfo*/)
{
	// TODO: add cleanup after printing
}

void CView3::OnContextMenu(CWnd*, CPoint point)
{
	theApp.ShowPopupMenu (IDR_CONTEXT_MENU, point, this);
}

