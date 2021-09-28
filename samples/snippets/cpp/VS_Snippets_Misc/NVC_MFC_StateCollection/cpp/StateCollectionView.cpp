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
#include "StateCollection.h"

#include "StateCollectionDoc.h"
#include "StateCollectionView.h"

#ifdef _DEBUG
#define new DEBUG_NEW
#undef THIS_FILE
static char THIS_FILE[] = __FILE__;
#endif

static const CString strInfo = 
	_T("This sample illustrates how to save/load the current configuration on the fly.\r\n")
	_T("You can configure two 'environments' - Regular and Debug.\r\n")
	_T("Just customize the toolbar/menu/docking bars and select 'Project|Save Debug' or 'Project|Save Regular'.\r\n")
	_T("When you want to switch between configurations select 'Project|Load Debug' or 'Project|Load Regular'.\r\n")
	_T("When the application is starting up, it loads the default configuration.\r\n\r\n")
	_T("You can combine this code with the 'StateToFile' example for greater flexibility.\r\n")
	_T("In this way you can export/import the desired configurations/profiles on the fly.\r\n")
	_T("Note the use of CWinAppEx::LoadState/SaveState.");

/////////////////////////////////////////////////////////////////////////////
// CStateCollectionView

IMPLEMENT_DYNCREATE(CStateCollectionView, CView)

BEGIN_MESSAGE_MAP(CStateCollectionView, CView)
	ON_WM_LBUTTONDBLCLK()
	ON_WM_CONTEXTMENU()
	// Standard printing commands
	ON_COMMAND(ID_FILE_PRINT, CView::OnFilePrint)
	ON_COMMAND(ID_FILE_PRINT_DIRECT, CView::OnFilePrint)
	ON_COMMAND(ID_FILE_PRINT_PREVIEW, OnFilePrintPreview)
END_MESSAGE_MAP()

/////////////////////////////////////////////////////////////////////////////
// CStateCollectionView construction/destruction

CStateCollectionView::CStateCollectionView()
{
	// TODO: add construction code here

}

CStateCollectionView::~CStateCollectionView()
{
}

BOOL CStateCollectionView::PreCreateWindow(CREATESTRUCT& cs)
{
	// TODO: Modify the Window class or styles here by modifying
	//  the CREATESTRUCT cs

	return CView::PreCreateWindow(cs);
}

/////////////////////////////////////////////////////////////////////////////
// CStateCollectionView drawing

void CStateCollectionView::OnDraw(CDC* pDC)
{
//	CStateCollectionDoc* pDoc = GetDocument();
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
// CStateCollectionView printing

void CStateCollectionView::OnFilePrintPreview() 
{
	AFXPrintPreview (this);
}

BOOL CStateCollectionView::OnPreparePrinting(CPrintInfo* pInfo)
{
	// default preparation
	return DoPreparePrinting(pInfo);
}

void CStateCollectionView::OnBeginPrinting(CDC* /*pDC*/, CPrintInfo* /*pInfo*/)
{
	// TODO: add extra initialization before printing
}

void CStateCollectionView::OnEndPrinting(CDC* /*pDC*/, CPrintInfo* /*pInfo*/)
{
	// TODO: add cleanup after printing
}

/////////////////////////////////////////////////////////////////////////////
// CStateCollectionView diagnostics

#ifdef _DEBUG
void CStateCollectionView::AssertValid() const
{
	CView::AssertValid();
}

void CStateCollectionView::Dump(CDumpContext& dc) const
{
	CView::Dump(dc);
}

CStateCollectionDoc* CStateCollectionView::GetDocument() // non-debug version is inline
{
	ASSERT(m_pDocument->IsKindOf(RUNTIME_CLASS(CStateCollectionDoc)));
	return (CStateCollectionDoc*)m_pDocument;
}
#endif //_DEBUG

/////////////////////////////////////////////////////////////////////////////
// CStateCollectionView message handlers

void CStateCollectionView::OnLButtonDblClk(UINT /*nFlags*/, CPoint /*point*/) 
{
	theApp.OnViewDoubleClick (this, IDR_MAINFRAME);
}

void CStateCollectionView::OnContextMenu(CWnd*, CPoint point)
{
	theApp.ShowPopupMenu (IDR_CONTEXT_MENU, point, this);
}
