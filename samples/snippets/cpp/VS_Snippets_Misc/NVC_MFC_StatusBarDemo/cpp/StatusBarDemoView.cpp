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
#include "StatusBarDemo.h"

#include "StatusBarDemoDoc.h"
#include "StatusBarDemoView.h"

#ifdef _DEBUG
#define new DEBUG_NEW
#undef THIS_FILE
static char THIS_FILE[] = __FILE__;
#endif

#define ID_PROGRESS_TIMER	1
#define PROGRESS_MAX		50

/////////////////////////////////////////////////////////////////////////////
// CStatusBarDemoView

IMPLEMENT_DYNCREATE(CStatusBarDemoView, CFormView)

BEGIN_MESSAGE_MAP(CStatusBarDemoView, CFormView)
	ON_BN_CLICKED(IDC_START_PROGRESS, OnStartProgress)
	ON_BN_CLICKED(IDC_START_ANIMATION, OnStartAnimation)
	ON_BN_CLICKED(IDC_ICON1, OnIcon)
	ON_BN_CLICKED(IDC_ICON2, OnIcon)
	ON_BN_CLICKED(IDC_BACK_COLOR, OnBackColor)
	ON_BN_CLICKED(IDC_TEXT_COLOR, OnTextColor)
	ON_WM_TIMER()
	ON_WM_CONTEXTMENU()
	// Standard printing commands
	ON_COMMAND(ID_FILE_PRINT, CFormView::OnFilePrint)
	ON_COMMAND(ID_FILE_PRINT_DIRECT, CFormView::OnFilePrint)
	ON_COMMAND(ID_FILE_PRINT_PREVIEW, OnFilePrintPreview)
	ON_COMMAND(ID_INDICATOR_LABEL, OnIndicatorLabel)
END_MESSAGE_MAP()

/////////////////////////////////////////////////////////////////////////////
// CStatusBarDemoView construction/destruction

CStatusBarDemoView::CStatusBarDemoView()
	: CFormView(CStatusBarDemoView::IDD)
{
	m_nIcon = 0;

	m_nProgressCurr = 0;
	m_bInProgress = FALSE;
	m_bInAnimation = FALSE;
}

CStatusBarDemoView::~CStatusBarDemoView()
{
}

void CStatusBarDemoView::DoDataExchange(CDataExchange* pDX)
{
	CFormView::DoDataExchange(pDX);
	DDX_Control(pDX, IDC_TEXT_COLOR, m_wndTextColor);
	DDX_Control(pDX, IDC_BACK_COLOR, m_wndBackColor);
	DDX_Control(pDX, IDC_START_ANIMATION, m_wndStartAnimation);
	DDX_Control(pDX, IDC_START_PROGRESS, m_wndStartProgress);
	DDX_Radio(pDX, IDC_ICON1, m_nIcon);
}

BOOL CStatusBarDemoView::PreCreateWindow(CREATESTRUCT& cs)
{
	// TODO: Modify the Window class or styles here by modifying
	//  the CREATESTRUCT cs

	return CFormView::PreCreateWindow(cs);
}

void CStatusBarDemoView::OnInitialUpdate()
{
	// There is only one view ever, so it only needs to do the initial
	// update once--otherwise the application is  resized needlessly.
	static BOOL bUpdatedOnce = FALSE;
	if (bUpdatedOnce)
		return;
	bUpdatedOnce = TRUE;

	CFormView::OnInitialUpdate();

	// <snippet11>
	m_wndTextColor.EnableAutomaticButton (_T("Default"), afxGlobalData.clrBtnText);
	m_wndTextColor.EnableOtherButton (_T("Other..."));
	m_wndTextColor.SetColor ((COLORREF)-1);
	m_wndTextColor.SetColorName((COLORREF)-1, "Default Color");
	m_wndTextColor.SetColumnsNumber(3);
	// </snippet11>

	m_wndBackColor.EnableAutomaticButton (_T("Default"), afxGlobalData.clrBtnFace);
	m_wndBackColor.EnableOtherButton (_T("Other..."));
	m_wndBackColor.SetColor ((COLORREF)-1);

	if (m_imlStatusAnimation.GetSafeHandle () == NULL)
	{
		m_imlStatusAnimation.Create (IDB_ANIMATION, 16, 0, RGB (255, 0, 255));
	}

	if (m_bmpIcon1.GetSafeHandle () == NULL)
	{
		m_bmpIcon1.LoadBitmap (IDB_ICON1);
	}

	if (m_bmpIcon2.GetSafeHandle () == NULL)
	{
		m_bmpIcon2.LoadBitmap (IDB_ICON2);
	}

	// <Snippet1>
	// in StatusBarDemoView.cpp
	GetStatusBar ().SetPaneIcon (nStatusIcon, m_bmpIcon1);
	GetStatusBar ().SetTipText (nStatusIcon, _T("This is a tooltip"));
    // </Snippet1>
}

/////////////////////////////////////////////////////////////////////////////
// CStatusBarDemoView printing

void CStatusBarDemoView::OnFilePrintPreview() 
{
	AFXPrintPreview (this);
}

BOOL CStatusBarDemoView::OnPreparePrinting(CPrintInfo* pInfo)
{
	// default preparation
	return DoPreparePrinting(pInfo);
}

void CStatusBarDemoView::OnBeginPrinting(CDC* /*pDC*/, CPrintInfo* /*pInfo*/)
{
	// TODO: add extra initialization before printing
}

void CStatusBarDemoView::OnEndPrinting(CDC* /*pDC*/, CPrintInfo* /*pInfo*/)
{
	// TODO: add cleanup after printing
}

void CStatusBarDemoView::OnPrint(CDC* /*pDC*/, CPrintInfo* /*pInfo*/)
{
	// TODO: add customized printing code here
}

/////////////////////////////////////////////////////////////////////////////
// CStatusBarDemoView diagnostics

#ifdef _DEBUG
void CStatusBarDemoView::AssertValid() const
{
	CFormView::AssertValid();
}

void CStatusBarDemoView::Dump(CDumpContext& dc) const
{
	CFormView::Dump(dc);
}

CStatusBarDemoDoc* CStatusBarDemoView::GetDocument() // non-debug version is inline
{
	ASSERT(m_pDocument->IsKindOf(RUNTIME_CLASS(CStatusBarDemoDoc)));
	return (CStatusBarDemoDoc*)m_pDocument;
}
#endif //_DEBUG

/////////////////////////////////////////////////////////////////////////////
// CStatusBarDemoView message handlers

void CStatusBarDemoView::OnContextMenu(CWnd*, CPoint point)
{
	theApp.ShowPopupMenu (IDR_CONTEXT_MENU, point, this);
}

void CStatusBarDemoView::OnStartProgress() 
{
	if (m_bInProgress)
	{
		KillTimer (ID_PROGRESS_TIMER);
		m_wndStartProgress.SetWindowText (_T("Start Progress"));
		GetStatusBar ().EnablePaneProgressBar (nStatusProgress, -1);

		m_bInProgress = FALSE;

		return;
	}

	// <Snippet2>
	GetStatusBar ().EnablePaneProgressBar (nStatusProgress, PROGRESS_MAX);
	// </Snippet2>

	m_nProgressCurr = 0;
	m_bInProgress = TRUE;

	SetTimer (ID_PROGRESS_TIMER, 200, NULL);
	m_wndStartProgress.SetWindowText (_T("Stop Progress"));
}

void CStatusBarDemoView::OnStartAnimation() 
{
	if (m_bInAnimation)
	{
		m_wndStartAnimation.SetWindowText (_T("Start Animation"));
		// <Snippet3>
		GetStatusBar ().SetPaneAnimation (nStatusAnimation, NULL);
		// </Snippet3>
		m_bInAnimation = FALSE;
		return;
	}

	// <Snippet4>
	GetStatusBar ().SetPaneAnimation (nStatusAnimation, m_imlStatusAnimation);
	GetStatusBar ().SetPaneText (nStatusAnimation, _T(""));
	GetStatusBar ().SetPaneWidth (nStatusAnimation, 16);
    // </Snippet4>

	m_wndStartAnimation.SetWindowText (_T("Stop Animation"));
	m_bInAnimation = TRUE;
}

void CStatusBarDemoView::OnIcon() 
{
	UpdateData ();
	GetStatusBar ().SetPaneIcon (nStatusIcon, m_nIcon == 0 ? m_bmpIcon1 : m_bmpIcon2);
}

void CStatusBarDemoView::OnBackColor() 
{
	GetStatusBar ().SetPaneBackgroundColor (nStatusLabel, m_wndBackColor.GetColor ());
}

void CStatusBarDemoView::OnTextColor() 
{
	GetStatusBar ().SetPaneTextColor (nStatusLabel, m_wndTextColor.GetColor ());
}

void CStatusBarDemoView::OnIndicatorLabel()
{
	MessageBox (_T("Status bar pane double-click..."));
}

void CStatusBarDemoView::OnTimer(UINT_PTR nIDEvent) 
{
	if (nIDEvent == ID_PROGRESS_TIMER)
	{
		m_nProgressCurr += 5;

		if (m_nProgressCurr > PROGRESS_MAX)
		{
			m_nProgressCurr = 0;
		}

		// <Snippet5>
		GetStatusBar ().SetPaneProgress (nStatusProgress, m_nProgressCurr);
		// </Snippet5>
	}
	
	CFormView::OnTimer(nIDEvent);
}
