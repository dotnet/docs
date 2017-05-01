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
#include "IEDemo.h"

#include "IEDemoDoc.h"
#include "IEDemoView.h"

#include "MainFrm.h"

#ifdef _DEBUG
#define new DEBUG_NEW
#undef THIS_FILE
static char THIS_FILE[] = __FILE__;
#endif

/////////////////////////////////////////////////////////////////////////////
// CIEDemoView

IMPLEMENT_DYNCREATE(CIEDemoView, CHtmlView)

BEGIN_MESSAGE_MAP(CIEDemoView, CHtmlView)
	//{{AFX_MSG_MAP(CIEDemoView)
	ON_COMMAND(ID_GO_BACK, OnGoBack)
	ON_COMMAND(ID_GO_FORWARD, OnGoForward)
	ON_COMMAND(ID_GO_SEARCH_THE_WEB, OnGoSearchTheWeb)
	ON_COMMAND(ID_GO_START_PAGE, OnGoStartPage)
	ON_COMMAND(ID_VIEW_STOP, OnViewStop)
	ON_COMMAND(ID_VIEW_REFRESH, OnViewRefresh)
	ON_COMMAND(ID_VIEW_FONTS_LARGEST, OnViewFontsLargest)
	ON_COMMAND(ID_VIEW_FONTS_LARGE, OnViewFontsLarge)
	ON_COMMAND(ID_VIEW_FONTS_MEDIUM, OnViewFontsMedium)
	ON_COMMAND(ID_VIEW_FONTS_SMALL, OnViewFontsSmall)
	ON_COMMAND(ID_VIEW_FONTS_SMALLEST, OnViewFontsSmallest)
	ON_COMMAND(ID_FILE_OPEN, OnFileOpen)
	ON_UPDATE_COMMAND_UI(ID_GO_FORWARD, OnUpdateGoForward)
	ON_UPDATE_COMMAND_UI(ID_GO_BACK, OnUpdateGoBack)
	ON_WM_DESTROY()
	//}}AFX_MSG_MAP
	// Standard printing commands
	ON_COMMAND(ID_FILE_PRINT, CHtmlView::OnFilePrint)
	ON_COMMAND(ID_FILE_PRINT_DIRECT, CHtmlView::OnFilePrint)
	ON_COMMAND(ID_FILE_PRINT_PREVIEW, CHtmlView::OnFilePrintPreview)
END_MESSAGE_MAP()

/////////////////////////////////////////////////////////////////////////////
// CIEDemoView construction/destruction

CIEDemoView::CIEDemoView()
{
	// TODO: add construction code here

}

CIEDemoView::~CIEDemoView()
{
}

BOOL CIEDemoView::PreCreateWindow(CREATESTRUCT& cs)
{
	// TODO: Modify the Window class or styles here by modifying
	//  the CREATESTRUCT cs

	return CHtmlView::PreCreateWindow(cs);
}

/////////////////////////////////////////////////////////////////////////////
// CIEDemoView drawing

void CIEDemoView::OnDraw(CDC* /*pDC*/)
{
//	CIEDemoDoc* pDoc = GetDocument();
//	ASSERT_VALID(pDoc);
	// TODO: add draw code for native data here
}

/////////////////////////////////////////////////////////////////////////////
// CIEDemoView printing

BOOL CIEDemoView::OnPreparePrinting(CPrintInfo* pInfo)
{
	// default preparation
	return DoPreparePrinting(pInfo);
}

void CIEDemoView::OnBeginPrinting(CDC* /*pDC*/, CPrintInfo* /*pInfo*/)
{
	// TODO: add extra initialization before printing
}

void CIEDemoView::OnEndPrinting(CDC* /*pDC*/, CPrintInfo* /*pInfo*/)
{
	// TODO: add cleanup after printing
}

/////////////////////////////////////////////////////////////////////////////
// CIEDemoView diagnostics

#ifdef _DEBUG
void CIEDemoView::AssertValid() const
{
	CHtmlView::AssertValid();
}

void CIEDemoView::Dump(CDumpContext& dc) const
{
	CHtmlView::Dump(dc);
}

CIEDemoDoc* CIEDemoView::GetDocument() // non-debug version is inline
{
	ASSERT(m_pDocument->IsKindOf(RUNTIME_CLASS(CIEDemoDoc)));
	return (CIEDemoDoc*)m_pDocument;
}
#endif //_DEBUG

/////////////////////////////////////////////////////////////////////////////
// CIEDemoView message handlers
// these are all simple one-liners to do simple controlling of the browser
void CIEDemoView::OnGoBack()
{
	CIEDemoDoc* pDoc = GetDocument();
	ASSERT_VALID(pDoc);

	CHistoryObj* pHistoryObj = pDoc->GoBack ();
	if (pHistoryObj != NULL)
	{
		Navigate2 (pHistoryObj->GetURL (), 0, NULL);
	}
}

void CIEDemoView::OnGoForward()
{
//	GoForward();
	CIEDemoDoc* pDoc = GetDocument();
	ASSERT_VALID(pDoc);

	CHistoryObj* pHistoryObj = pDoc->GoForward ();
	if (pHistoryObj != NULL)
	{
		Navigate2 (pHistoryObj->GetURL (), 0, NULL);
	}
}

void CIEDemoView::OnGoSearchTheWeb()
{
	GoSearch();
}

void CIEDemoView::OnGoStartPage()
{
	GoHome();
}

void CIEDemoView::OnViewStop()
{
	Stop();
}

void CIEDemoView::OnViewRefresh()
{
	Refresh();
}

// these functions control the font size.  There is no explicit command in the
// CHtmlView class to do this, but we can do it by using the ExecWB() function.
void CIEDemoView::OnViewFontsLargest()
{
	COleVariant vaZoomFactor(4l);

	ExecWB(OLECMDID_ZOOM, OLECMDEXECOPT_DONTPROMPTUSER,
		   &vaZoomFactor, NULL);
}

void CIEDemoView::OnViewFontsLarge()
{
	COleVariant vaZoomFactor(3l);

	ExecWB(OLECMDID_ZOOM, OLECMDEXECOPT_DONTPROMPTUSER,
		   &vaZoomFactor, NULL);
}

void CIEDemoView::OnViewFontsMedium()
{
	COleVariant vaZoomFactor(2l);

	ExecWB(OLECMDID_ZOOM, OLECMDEXECOPT_DONTPROMPTUSER,
		   &vaZoomFactor, NULL);
}

void CIEDemoView::OnViewFontsSmall()
{
	COleVariant vaZoomFactor(1l);

	ExecWB(OLECMDID_ZOOM, OLECMDEXECOPT_DONTPROMPTUSER,
		   &vaZoomFactor, NULL);
}

void CIEDemoView::OnViewFontsSmallest()
{
	COleVariant vaZoomFactor(0l);

	ExecWB(OLECMDID_ZOOM, OLECMDEXECOPT_DONTPROMPTUSER,
		   &vaZoomFactor, NULL);
}

// This demonstrates how we can use the Navigate2() function to load local files
// including local HTML pages, GIFs, AIFF files, etc.
void CIEDemoView::OnFileOpen()
{
	BOOL bValidString;
	CString str;
	bValidString = str.LoadString(IDS_FILETYPES);

	CFileDialog fileDlg(TRUE, NULL, NULL, OFN_HIDEREADONLY, str);

	if(fileDlg.DoModal() == IDOK)
		Navigate2(fileDlg.GetPathName(), 0, NULL);
}

void CIEDemoView::OnUpdateGoForward(CCmdUI* pCmdUI) 
{
	CIEDemoDoc* pDoc = GetDocument();
	ASSERT_VALID(pDoc);

	pCmdUI->Enable (pDoc->IsFrwdAvailable ());
}

void CIEDemoView::OnUpdateGoBack(CCmdUI* pCmdUI) 
{
	CIEDemoDoc* pDoc = GetDocument();
	ASSERT_VALID(pDoc);

	pCmdUI->Enable (pDoc->IsBackAvailable ());
}

void CIEDemoView::OnDocumentComplete(LPCTSTR lpszURL) 
{
	// make sure the main frame has the new URL.  This call also stops the animation
	((CMainFrame*)GetParentFrame())->SetAddress(lpszURL);

	CIEDemoDoc* pDoc = GetDocument();
	ASSERT_VALID(pDoc);

	pDoc->AddURLToHistory (GetLocationName (), lpszURL);
	((CMainFrame*)GetParentFrame())->SetProgress (0, -1);
	
	CHtmlView::OnDocumentComplete(lpszURL);
}

void CIEDemoView::OnTitleChange(LPCTSTR lpszText) 
{
	// this will change the main frame's title bar
	if (m_pDocument != NULL)
		m_pDocument->SetTitle(lpszText);
}

void CIEDemoView::OnBeforeNavigate2(LPCTSTR /*lpszURL*/, DWORD /*nFlags*/, LPCTSTR /*lpszTargetFrameName*/, CByteArray& /*baPostedData*/, LPCTSTR /*lpszHeaders*/, BOOL* /*pbCancel*/) 
{
	// start the animation so that is plays while the new page is being loaded
	((CMainFrame*)GetParentFrame())->StartAnimation();
}

void CIEDemoView::OnInitialUpdate() 
{
	GoHome();
}

void CIEDemoView::OnProgressChange(long nProgress, long nProgressMax) 
{
	((CMainFrame*)GetParentFrame())->SetProgress(nProgress, nProgressMax);
	
	CHtmlView::OnProgressChange(nProgress, nProgressMax);
}

void CIEDemoView::OnDestroy() 
{
	CHtmlView::OnDestroy();
	CView::OnDestroy();		// Fixes CHtmlView bug
}
