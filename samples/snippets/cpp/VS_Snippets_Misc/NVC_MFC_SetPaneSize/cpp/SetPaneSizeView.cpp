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
#include "SetPaneSize.h"

#include "SetPaneSizeDoc.h"
#include "SetPaneSizeView.h"
#include "MainFrm.h"

#ifdef _DEBUG
#define new DEBUG_NEW
#undef THIS_FILE
static char THIS_FILE[] = __FILE__;
#endif

/////////////////////////////////////////////////////////////////////////////
// CSetPaneSizeView

IMPLEMENT_DYNCREATE(CSetPaneSizeView, CFormView)

BEGIN_MESSAGE_MAP(CSetPaneSizeView, CFormView)
	ON_BN_CLICKED(IDC_BUTTON_SET_DLGBAR_SIZE, OnButtonSetDlgBarSize)
	ON_BN_CLICKED(IDC_BUTTON_SET_CONTAINER_SIZE, OnButtonSetContainerSize)
	ON_BN_CLICKED(IDC_BTN_SET_HEIGHT_IN_PIXELS, OnBtnSetHeightInPixels)
	ON_BN_CLICKED(IDC_BTN_SET_WIDTH_IN_PIXELS, OnBtnSetWidthInPixels)
	ON_WM_CONTEXTMENU()
	// Standard printing commands
	ON_COMMAND(ID_FILE_PRINT, CFormView::OnFilePrint)
	ON_COMMAND(ID_FILE_PRINT_DIRECT, CFormView::OnFilePrint)
	ON_COMMAND(ID_FILE_PRINT_PREVIEW, OnFilePrintPreview)
END_MESSAGE_MAP()

/////////////////////////////////////////////////////////////////////////////
// CSetPaneSizeView construction/destruction

CSetPaneSizeView::CSetPaneSizeView()
	: CFormView(CSetPaneSizeView::IDD)
{
	m_nSizePercent = 50;
	m_nContainerSize = 100;
	m_nHeightInPixels = 100;
	m_nWidthInPixels = 100;
}

CSetPaneSizeView::~CSetPaneSizeView()
{
}

void CSetPaneSizeView::DoDataExchange(CDataExchange* pDX)
{
	CFormView::DoDataExchange(pDX);
	DDX_Text(pDX, IDC_EDIT_SIZE, m_nSizePercent);
	DDV_MinMaxUInt(pDX, m_nSizePercent, 1, 99);
	DDX_Text(pDX, IDC_EDIT_WIDTH, m_nContainerSize);
	DDV_MinMaxUInt(pDX, m_nContainerSize, 1, 2056);
	DDX_Text(pDX, IDC_EDIT_HEIGHT_IN_PIXELS, m_nHeightInPixels);
	DDV_MinMaxUInt(pDX, m_nHeightInPixels, 1, 2056);
	DDX_Text(pDX, IDC_EDIT_WIDTH_IN_PIXELS, m_nWidthInPixels);
	DDV_MinMaxUInt(pDX, m_nWidthInPixels, 1, 2056);
}

BOOL CSetPaneSizeView::PreCreateWindow(CREATESTRUCT& cs)
{
	// TODO: Modify the Window class or styles here by modifying
	//  the CREATESTRUCT cs

	return CFormView::PreCreateWindow(cs);
}

void CSetPaneSizeView::OnInitialUpdate()
{
	// There is only one view ever, so it only needs to do the initial
	// update once--otherwise the application is  resized needlessly.
	static BOOL bUpdatedOnce = FALSE;
	if (bUpdatedOnce)
		return;
	bUpdatedOnce = TRUE;

	CFormView::OnInitialUpdate();
	GetParentFrame()->RecalcLayout();
	ResizeParentToFit();

}

/////////////////////////////////////////////////////////////////////////////
// CSetPaneSizeView printing

void CSetPaneSizeView::OnFilePrintPreview() 
{
	AFXPrintPreview (this);
}

BOOL CSetPaneSizeView::OnPreparePrinting(CPrintInfo* pInfo)
{
	// default preparation
	return DoPreparePrinting(pInfo);
}

void CSetPaneSizeView::OnBeginPrinting(CDC* /*pDC*/, CPrintInfo* /*pInfo*/)
{
	// TODO: add extra initialization before printing
}

void CSetPaneSizeView::OnEndPrinting(CDC* /*pDC*/, CPrintInfo* /*pInfo*/)
{
	// TODO: add cleanup after printing
}

void CSetPaneSizeView::OnPrint(CDC* /*pDC*/, CPrintInfo* /*pInfo*/)
{
	// TODO: add customized printing code here
}

/////////////////////////////////////////////////////////////////////////////
// CSetPaneSizeView diagnostics

#ifdef _DEBUG
void CSetPaneSizeView::AssertValid() const
{
	CFormView::AssertValid();
}

void CSetPaneSizeView::Dump(CDumpContext& dc) const
{
	CFormView::Dump(dc);
}

CSetPaneSizeDoc* CSetPaneSizeView::GetDocument() // non-debug version is inline
{
	ASSERT(m_pDocument->IsKindOf(RUNTIME_CLASS(CSetPaneSizeDoc)));
	return (CSetPaneSizeDoc*)m_pDocument;
}
#endif //_DEBUG

/////////////////////////////////////////////////////////////////////////////
// CSetPaneSizeView message handlers

void CSetPaneSizeView::OnContextMenu(CWnd*, CPoint point)
{
	theApp.ShowPopupMenu (IDR_CONTEXT_MENU, point, this);
}

void CSetPaneSizeView::OnButtonSetDlgBarSize() 
{
	UpdateData ();
	CMainFrame* pMainFrame = DYNAMIC_DOWNCAST (CMainFrame, GetTopLevelFrame());
	if (pMainFrame != NULL)
	{
		pMainFrame->SetDlgBarSizeInContainer (m_nSizePercent);
	}
}

void CSetPaneSizeView::OnButtonSetContainerSize() 
{
	UpdateData ();	
	CMainFrame* pMainFrame = DYNAMIC_DOWNCAST (CMainFrame, GetTopLevelFrame());
	if (pMainFrame != NULL)
	{
		pMainFrame->SetContainerSize (m_nContainerSize);
	}
}

void CSetPaneSizeView::OnBtnSetHeightInPixels() 
{
	UpdateData ();	
	CMainFrame* pMainFrame = DYNAMIC_DOWNCAST (CMainFrame, GetTopLevelFrame());
	if (pMainFrame != NULL)
	{
		pMainFrame->SetDlgBarHeightInPixels (m_nHeightInPixels);
	}
}

void CSetPaneSizeView::OnBtnSetWidthInPixels() 
{
	UpdateData ();	
	CMainFrame* pMainFrame = DYNAMIC_DOWNCAST (CMainFrame, GetTopLevelFrame());
	if (pMainFrame != NULL)
	{
		pMainFrame->SetDlgBarWidthInPixels (m_nWidthInPixels);
	}
}
