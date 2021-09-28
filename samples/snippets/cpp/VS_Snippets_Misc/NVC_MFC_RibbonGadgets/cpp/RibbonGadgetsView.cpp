#include "stdafx.h"
#include "RibbonGadgets.h"

#include "RibbonGadgetsDoc.h"
#include "RibbonGadgetsView.h"

#ifdef _DEBUG
#define new DEBUG_NEW
#undef THIS_FILE
static char THIS_FILE[] = __FILE__;
#endif

static const CString strInfo = 
	_T("This sample illustrates how to create the various Ribbon elements.\r\n")
	_T("\"Source Code\" window contains source code for the current ribbon category (tab).\r\n")
	_T("Please select a specific tab on the bottom to see the panel source code.\r\n")
	_T("You may copy this code into the clipboard, print it or save it in an external file.");

/////////////////////////////////////////////////////////////////////////////
// CRibbonGadgetsView

IMPLEMENT_DYNCREATE(CRibbonGadgetsView, CView)

BEGIN_MESSAGE_MAP(CRibbonGadgetsView, CView)
	ON_WM_DESTROY()
	ON_WM_CREATE()
	ON_WM_CONTEXTMENU()
	// Standard printing commands
	ON_COMMAND(ID_FILE_PRINT, CView::OnFilePrint)
	ON_COMMAND(ID_FILE_PRINT_DIRECT, CView::OnFilePrint)
	ON_COMMAND(ID_FILE_PRINT_PREVIEW, OnFilePrintPreview)
END_MESSAGE_MAP()

/////////////////////////////////////////////////////////////////////////////
// CRibbonGadgetsView construction/destruction

CRibbonGadgetsView::CRibbonGadgetsView()
{
	
}

CRibbonGadgetsView::~CRibbonGadgetsView()
{
}

BOOL CRibbonGadgetsView::PreCreateWindow(CREATESTRUCT& cs)
{
	// TODO: Modify the Window class or styles here by modifying
	//  the CREATESTRUCT cs

	return CView::PreCreateWindow(cs);
}

/////////////////////////////////////////////////////////////////////////////
// CRibbonGadgetsView printing

void CRibbonGadgetsView::OnFilePrintPreview() 
{
	AFXPrintPreview (this);
}

BOOL CRibbonGadgetsView::OnPreparePrinting(CPrintInfo* pInfo)
{
	// default preparation
	return DoPreparePrinting(pInfo);
}


void CRibbonGadgetsView::OnDestroy()
{
   CView::OnDestroy();
}


/////////////////////////////////////////////////////////////////////////////
// CRibbonGadgetsView diagnostics

#ifdef _DEBUG
void CRibbonGadgetsView::AssertValid() const
{
	CView::AssertValid();
}

void CRibbonGadgetsView::Dump(CDumpContext& dc) const
{
	CView::Dump(dc);
}

CRibbonGadgetsDoc* CRibbonGadgetsView::GetDocument() // non-debug version is inline
{
	ASSERT(m_pDocument->IsKindOf(RUNTIME_CLASS(CRibbonGadgetsDoc)));
	return (CRibbonGadgetsDoc*)m_pDocument;
}
#endif //_DEBUG

/////////////////////////////////////////////////////////////////////////////
// CRibbonGadgetsView message handlers

int CRibbonGadgetsView::OnCreate(LPCREATESTRUCT lpCreateStruct) 
{
	if (CView::OnCreate(lpCreateStruct) == -1)
		return -1;
	
	return 0;
}

HMENU CRibbonGadgetsView::GetContextMenu(WORD, LPOLEOBJECT, CHARRANGE* )
{
	return NULL;
}

void CRibbonGadgetsView::OnContextMenu(CWnd* /*pWnd*/, CPoint point) 
{
	theApp.ShowPopupMenu (IDR_EDIT_MENU, point, this);	
}

void CRibbonGadgetsView::OnDraw(CDC* pDC) 
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
