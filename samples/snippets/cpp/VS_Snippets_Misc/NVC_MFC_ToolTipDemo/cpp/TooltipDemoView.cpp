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
#include "TooltipDemo.h"

#include "TooltipDemoDoc.h"
#include "TooltipDemoView.h"

#include "MyToolTipCtrl.h"

#ifdef _DEBUG
#define new DEBUG_NEW
#undef THIS_FILE
static char THIS_FILE[] = __FILE__;
#endif

/////////////////////////////////////////////////////////////////////////////
// CTooltipDemoView

IMPLEMENT_DYNCREATE(CTooltipDemoView, CFormView)

BEGIN_MESSAGE_MAP(CTooltipDemoView, CFormView)
	ON_BN_CLICKED(IDC_BOLD_LABEL, OnApplyParams)
	ON_BN_CLICKED(IDC_CUSTOM_COLORS, OnApplyParams)
	ON_BN_CLICKED(IDC_DRAW_DESCR, OnApplyParams)
	ON_BN_CLICKED(IDC_DRAW_ICON, OnApplyParams)
	ON_BN_CLICKED(IDC_ROUNDED_CORNERS, OnApplyParams)
	ON_BN_CLICKED(IDC_TT_TYPE, OnApplyParams)
	ON_BN_CLICKED(IDC_TT_TYPE2, OnApplyParams)
	ON_BN_CLICKED(IDC_TT_TYPE3, OnApplyParams)
	ON_BN_CLICKED(IDC_DRAW_SEPARATOR, OnApplyParams)
	ON_BN_CLICKED(IDC_SHOW_TOOLTIPS_IN_MENU, OnApplyParams)
	ON_BN_CLICKED(IDC_TT_TYPE4, OnApplyParams)
	ON_BN_CLICKED(IDC_TT_TYPE5, OnApplyParams)
	ON_WM_CONTEXTMENU()
	// Standard printing commands
	ON_COMMAND(ID_FILE_PRINT, CFormView::OnFilePrint)
	ON_COMMAND(ID_FILE_PRINT_DIRECT, CFormView::OnFilePrint)
	ON_COMMAND(ID_FILE_PRINT_PREVIEW, OnFilePrintPreview)
END_MESSAGE_MAP()

/////////////////////////////////////////////////////////////////////////////
// CTooltipDemoView construction/destruction

CTooltipDemoView::CTooltipDemoView()
	: CFormView(CTooltipDemoView::IDD)
{
	m_nTTType = 0;
	m_bBoldLabel = FALSE;
	m_bCustomColors = FALSE;
	m_bDrawDescription = FALSE;
	m_bDrawIcon = FALSE;
	m_bRoundedCorners = FALSE;
	m_bDrawSeparator = FALSE;
	m_bTTInPopupMenus = FALSE;

	m_nTTType = theApp.GetInt (_T("TTType"), 0);
	m_bBoldLabel = theApp.GetInt (_T("BoldLabel"), TRUE);
	m_bCustomColors = theApp.GetInt (_T("CustomColors"), TRUE);
	m_bDrawDescription = theApp.GetInt (_T("DrawDescription"), TRUE);
	m_bDrawIcon = theApp.GetInt (_T("DrawIcon"), TRUE);
	m_bRoundedCorners = theApp.GetInt (_T("RoundedCorners"), TRUE);
	m_bDrawSeparator = theApp.GetInt (_T("DrawSeparator"), TRUE);
	m_bTTInPopupMenus = theApp.GetInt (_T("TTInPopupMenus"), TRUE);
}

CTooltipDemoView::~CTooltipDemoView()
{
}

void CTooltipDemoView::DoDataExchange(CDataExchange* pDX)
{
	CFormView::DoDataExchange(pDX);
	DDX_Radio(pDX, IDC_TT_TYPE, m_nTTType);
	DDX_Check(pDX, IDC_BOLD_LABEL, m_bBoldLabel);
	DDX_Check(pDX, IDC_CUSTOM_COLORS, m_bCustomColors);
	DDX_Check(pDX, IDC_DRAW_DESCR, m_bDrawDescription);
	DDX_Check(pDX, IDC_DRAW_ICON, m_bDrawIcon);
	DDX_Check(pDX, IDC_ROUNDED_CORNERS, m_bRoundedCorners);
	DDX_Check(pDX, IDC_DRAW_SEPARATOR, m_bDrawSeparator);
	DDX_Check(pDX, IDC_SHOW_TOOLTIPS_IN_MENU, m_bTTInPopupMenus);
}

BOOL CTooltipDemoView::PreCreateWindow(CREATESTRUCT& cs)
{
	// TODO: Modify the Window class or styles here by modifying
	//  the CREATESTRUCT cs

	return CFormView::PreCreateWindow(cs);
}

BOOL IsBalloonTooltipAvailable ()
{
	// <snippet1>
	CSettingsStore reg (FALSE, TRUE);
	DWORD dwEnableBalloonTips = 1;

	if (reg.Open (_T("Software\\Microsoft\\Windows\\CurrentVersion\\Explorer\\Advanced")) &&
		reg.Read (_T("EnableBalloonTips"), dwEnableBalloonTips))
	{
		return dwEnableBalloonTips == 1;
	}
	// </snippet1>

	return TRUE;
}

void CTooltipDemoView::OnInitialUpdate()
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

	// Check for balloon tooltips:
	if (!IsBalloonTooltipAvailable ())
	{
		if (m_nTTType == 1)
		{
			m_nTTType = 0;
			UpdateData (FALSE);
		}

		GetDlgItem (IDC_TT_TYPE4)->EnableWindow (FALSE);
	}
	else
	{
		GetDlgItem (IDC_NO_BALLOON)->ShowWindow (SW_HIDE);
	}

	OnApplyParams ();
}

/////////////////////////////////////////////////////////////////////////////
// CTooltipDemoView printing

void CTooltipDemoView::OnFilePrintPreview() 
{
	AFXPrintPreview (this);
}

BOOL CTooltipDemoView::OnPreparePrinting(CPrintInfo* pInfo)
{
	// default preparation
	return DoPreparePrinting(pInfo);
}

void CTooltipDemoView::OnBeginPrinting(CDC* /*pDC*/, CPrintInfo* /*pInfo*/)
{
	// TODO: add extra initialization before printing
}

void CTooltipDemoView::OnEndPrinting(CDC* /*pDC*/, CPrintInfo* /*pInfo*/)
{
	// TODO: add cleanup after printing
}

void CTooltipDemoView::OnPrint(CDC* /*pDC*/, CPrintInfo* /*pInfo*/)
{
	// TODO: add customized printing code here
}

/////////////////////////////////////////////////////////////////////////////
// CTooltipDemoView diagnostics

#ifdef _DEBUG
void CTooltipDemoView::AssertValid() const
{
	CFormView::AssertValid();
}

void CTooltipDemoView::Dump(CDumpContext& dc) const
{
	CFormView::Dump(dc);
}

CTooltipDemoDoc* CTooltipDemoView::GetDocument() // non-debug version is inline
{
	ASSERT(m_pDocument->IsKindOf(RUNTIME_CLASS(CTooltipDemoDoc)));
	return (CTooltipDemoDoc*)m_pDocument;
}
#endif //_DEBUG

/////////////////////////////////////////////////////////////////////////////
// CTooltipDemoView message handlers

void CTooltipDemoView::OnContextMenu(CWnd*, CPoint point)
{
	theApp.ShowPopupMenu (IDR_CONTEXT_MENU, point, this);
}

void CTooltipDemoView::OnApplyParams() 
{
	UpdateData ();
	
	EnableControls ();

	afxGlobalData.m_nMaxToolTipWidth = 200;

	theApp.WriteInt (_T("TTType"), m_nTTType);
	theApp.WriteInt (_T("BoldLabel"), m_bBoldLabel);
	theApp.WriteInt (_T("CustomColors"), m_bCustomColors);
	theApp.WriteInt (_T("DrawDescription"), m_bDrawDescription);
	theApp.WriteInt (_T("DrawIcon"), m_bDrawIcon);
	theApp.WriteInt (_T("RoundedCorners"), m_bRoundedCorners);
	theApp.WriteInt (_T("DrawSeparator"), m_bDrawSeparator);
	theApp.WriteInt (_T("TTInPopupMenus"), m_bTTInPopupMenus);

	theApp.m_bTTInPopupMenus = m_bTTInPopupMenus;

	if (m_nTTType == 0)	// Standard tooltip
	{
		theApp.GetTooltipManager ()->SetTooltipParams (
			AFX_TOOLTIP_TYPE_ALL,
			NULL,
			NULL);
		return;
	}

	if (m_nTTType == 1)	// Balloon tooltip
	{
		CMFCToolTipInfo paramsBalloon;
		paramsBalloon.m_bBalloonTooltip = TRUE;

		theApp.GetTooltipManager ()->SetTooltipParams (
			AFX_TOOLTIP_TYPE_ALL,
			RUNTIME_CLASS (CMFCToolTipCtrl),
			&paramsBalloon);
		return;
	}

	if (m_nTTType == 3)	// Visual Manager-based tooltip
	{
		CMFCToolTipInfo params;
		params.m_bVislManagerTheme = TRUE;

		theApp.GetTooltipManager ()->SetTooltipParams (
			AFX_TOOLTIP_TYPE_ALL,
			RUNTIME_CLASS (CMFCToolTipCtrl),
			&params);
		return;
	}

	if (m_nTTType == 4)	// Custom tooltip
	{
		theApp.GetTooltipManager ()->SetTooltipParams (
			AFX_TOOLTIP_TYPE_ALL,
			RUNTIME_CLASS (CMyToolTipCtrl));
		return;
	}

	// Custom tooltip with parameters:
	CMFCToolTipInfo params;

	params.m_bBoldLabel = m_bBoldLabel;
	params.m_bDrawDescription = m_bDrawDescription;
	params.m_bDrawIcon = m_bDrawIcon;
	params.m_bRoundedCorners = m_bRoundedCorners;
	params.m_bDrawSeparator = m_bDrawSeparator;

	if (m_bCustomColors)
	{
		params.m_clrFill = RGB (255, 255, 255);
		params.m_clrFillGradient = RGB (228, 228, 240);
		params.m_clrText = RGB (61, 83, 80);
		params.m_clrBorder = RGB (144, 149, 168);
	}

	theApp.GetTooltipManager ()->SetTooltipParams (
		AFX_TOOLTIP_TYPE_ALL,
		RUNTIME_CLASS (CMFCToolTipCtrl),
		&params);
}

void CTooltipDemoView::EnableControls ()
{
	BOOL bEnableParams = m_nTTType == 2;

	GetDlgItem (IDC_DRAW_ICON)->EnableWindow (bEnableParams);
	GetDlgItem (IDC_DRAW_DESCR)->EnableWindow (bEnableParams);
	GetDlgItem (IDC_ROUNDED_CORNERS)->EnableWindow (bEnableParams);
	GetDlgItem (IDC_BOLD_LABEL)->EnableWindow (bEnableParams && m_bDrawDescription);
	GetDlgItem (IDC_CUSTOM_COLORS)->EnableWindow (bEnableParams);
	GetDlgItem (IDC_DRAW_SEPARATOR)->EnableWindow (bEnableParams && m_bDrawDescription);
}
