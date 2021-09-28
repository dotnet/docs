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
#include "TabControl.h"

#include "TabControlDoc.h"
#include "TabControlView.h"

#ifdef _DEBUG
#define new DEBUG_NEW
#undef THIS_FILE
static char THIS_FILE[] = __FILE__;
#endif

/////////////////////////////////////////////////////////////////////////////
// CTabControlView

IMPLEMENT_DYNCREATE(CTabControlView, CFormView)

BEGIN_MESSAGE_MAP(CTabControlView, CFormView)
	ON_CBN_SELCHANGE(IDC_TAB_STYLE, OnSelchangeTabStyle)
	ON_BN_CLICKED(IDC_LOCATION, OnLocation)
	ON_BN_CLICKED(IDC_COLOR, OnColor)
	ON_BN_CLICKED(IDC_TAB_ICONS, OnTabIcons)
	ON_BN_CLICKED(IDC_LOCATION2, OnLocation)
	ON_BN_CLICKED(IDC_COLOR1, OnColor)
	ON_BN_CLICKED(IDC_COLOR2, OnColor)
	ON_BN_CLICKED(IDC_TAB_SWAP, OnTabSwap)
	ON_WM_CONTEXTMENU()
	// Standard printing commands
	ON_COMMAND(ID_FILE_PRINT, CFormView::OnFilePrint)
	ON_COMMAND(ID_FILE_PRINT_DIRECT, CFormView::OnFilePrint)
	ON_COMMAND(ID_FILE_PRINT_PREVIEW, OnFilePrintPreview)
	// Tab control notifications
	ON_REGISTERED_MESSAGE(AFX_WM_ON_MOVE_TAB, OnMoveTab)
	ON_REGISTERED_MESSAGE(AFX_WM_CHANGE_ACTIVE_TAB, OnChangeActiveTab)
	ON_REGISTERED_MESSAGE(AFX_WM_CHANGING_ACTIVE_TAB, OnChangingActiveTab)
END_MESSAGE_MAP()

/////////////////////////////////////////////////////////////////////////////
// CTabControlView construction/destruction

CTabControlView::CTabControlView()
	: CFormView(CTabControlView::IDD)
{
	m_nTabStyle = 0;
	m_nTabLocation = 0;
	m_nColor = 0;
	m_bTabIcons = TRUE;
	m_bTabsSwap = TRUE;
}

CTabControlView::~CTabControlView()
{
}

void CTabControlView::DoDataExchange(CDataExchange* pDX)
{
	CFormView::DoDataExchange(pDX);
	DDX_Control(pDX, IDC_TAB_ICONS, m_wndTabIcons);
	DDX_Control(pDX, IDC_NOTIFICATIONS, m_wndNotifications);
	DDX_Control(pDX, IDC_TAB, m_wndTabLoc);
	DDX_CBIndex(pDX, IDC_TAB_STYLE, m_nTabStyle);
	DDX_Radio(pDX, IDC_LOCATION, m_nTabLocation);
	DDX_Radio(pDX, IDC_COLOR, m_nColor);
	DDX_Check(pDX, IDC_TAB_ICONS, m_bTabIcons);
	DDX_Check(pDX, IDC_TAB_SWAP, m_bTabsSwap);
}

BOOL CTabControlView::PreCreateWindow(CREATESTRUCT& cs)
{
	// TODO: Modify the Window class or styles here by modifying
	//  the CREATESTRUCT cs

	return CFormView::PreCreateWindow(cs);
}

void CTabControlView::OnInitialUpdate()
{
	// There is only one view ever, so it only needs to do the initial
	// update once--otherwise the application is  resized needlessly.
	static BOOL bUpdatedOnce = FALSE;
	if (bUpdatedOnce)
		return;
	bUpdatedOnce = TRUE;

	CFormView::OnInitialUpdate();
	GetParentFrame()->RecalcLayout();

	if (m_wndTab.GetSafeHwnd () != NULL)
	{
		return;
	}

	CRect rectTab;

	m_wndTabLoc.GetWindowRect (&rectTab);
	ScreenToClient (&rectTab);

	m_wndTab.Create (CMFCTabCtrl::STYLE_3D, rectTab, this, 1,
		CMFCTabCtrl::LOCATION_TOP);

	m_wndTab.SetImageList (IDB_ICONS, 16, RGB (255, 0, 255));
	
	m_wnd1.Create (WS_CHILD | WS_VISIBLE, CRect (0, 0, 0, 0), &m_wndTab, 1);
	m_wnd1.SetFont (&afxGlobalData.fontRegular);
	m_wnd1.SetWindowText (_T("Edit 1"));

	m_wnd2.Create (WS_CHILD | WS_VISIBLE, CRect (0, 0, 0, 0), &m_wndTab, 2);
	m_wnd2.SetFont (&afxGlobalData.fontRegular);
	m_wnd2.SetWindowText (_T("Edit 2"));

	m_wnd3.Create (WS_CHILD | WS_VISIBLE, CRect (0, 0, 0, 0), &m_wndTab, 3);
	m_wnd3.SetFont (&afxGlobalData.fontRegular);
	m_wnd3.SetWindowText (_T("Edit 3"));

	m_wnd4.Create (WS_CHILD | WS_VISIBLE, CRect (0, 0, 0, 0), &m_wndTab, 4);
	m_wnd4.SetFont (&afxGlobalData.fontRegular);
	m_wnd4.SetWindowText (_T("Edit 4"));

	m_wndTab.AddTab (&m_wnd1, _T("One"), 0, FALSE);
	m_wndTab.AddTab (&m_wnd2, _T("Two"), 1, FALSE);
	m_wndTab.AddTab (&m_wnd3, _T("Three"), 2, FALSE);
	m_wndTab.AddTab (&m_wnd4, _T("Four"), 3, FALSE);

	m_nTabStyle = theApp.GetInt (_T("TabStyle"), 0);
	m_nTabLocation = theApp.GetInt (_T("TabLocation"), 0);
	m_nColor = theApp.GetInt (_T("TabColor"), 0);
	m_bTabIcons = theApp.GetInt (_T("TabIcons"), TRUE);
	m_bTabsSwap = theApp.GetInt (_T("TabsSwap"), TRUE);

	UpdateData (FALSE);

	OnSelchangeTabStyle();
	OnLocation();
	OnColor();
	OnTabIcons ();
	OnTabSwap ();
}

/////////////////////////////////////////////////////////////////////////////
// CTabControlView printing

void CTabControlView::OnFilePrintPreview() 
{
	AFXPrintPreview (this);
}

BOOL CTabControlView::OnPreparePrinting(CPrintInfo* pInfo)
{
	// default preparation
	return DoPreparePrinting(pInfo);
}

void CTabControlView::OnBeginPrinting(CDC* /*pDC*/, CPrintInfo* /*pInfo*/)
{
	// TODO: add extra initialization before printing
}

void CTabControlView::OnEndPrinting(CDC* /*pDC*/, CPrintInfo* /*pInfo*/)
{
	// TODO: add cleanup after printing
}

void CTabControlView::OnPrint(CDC* /*pDC*/, CPrintInfo* /*pInfo*/)
{
	// TODO: add customized printing code here
}

/////////////////////////////////////////////////////////////////////////////
// CTabControlView diagnostics

#ifdef _DEBUG
void CTabControlView::AssertValid() const
{
	CFormView::AssertValid();
}

void CTabControlView::Dump(CDumpContext& dc) const
{
	CFormView::Dump(dc);
}

CTabControlDoc* CTabControlView::GetDocument() // non-debug version is inline
{
	ASSERT(m_pDocument->IsKindOf(RUNTIME_CLASS(CTabControlDoc)));
	return (CTabControlDoc*)m_pDocument;
}
#endif //_DEBUG

/////////////////////////////////////////////////////////////////////////////
// CTabControlView message handlers

void CTabControlView::OnContextMenu(CWnd*, CPoint point)
{
	theApp.ShowPopupMenu (IDR_CONTEXT_MENU, point, this);
}

void CTabControlView::OnSelchangeTabStyle() 
{
	UpdateData ();

	CMFCTabCtrl::Style style;
	int nTab = 0;

	m_wndTabIcons.EnableWindow ();

	for (nTab = 0; nTab < m_wndTab.GetTabsNum (); nTab++)
	{
		m_wndTab.SetTabIcon (nTab, m_bTabIcons ? nTab : (UINT)-1);
	}

	switch (m_nTabStyle)
	{
	case 1:
		style = CMFCTabCtrl::STYLE_FLAT;
		m_wndTabIcons.EnableWindow (FALSE);

		for (nTab = 0; nTab < m_wndTab.GetTabsNum (); nTab++)
		{
			m_wndTab.SetTabIcon (nTab, (UINT)-1);
		}

		break;

	case 2:
		style = CMFCTabCtrl::STYLE_3D_ONENOTE;
		break;

	case 3:
		style = CMFCTabCtrl::STYLE_3D_VS2005;
		break;

	case 4:
		style = CMFCTabCtrl::STYLE_3D_ROUNDED;
		break;
	default:
		style = CMFCTabCtrl::STYLE_3D;
	}

	m_wndTab.ModifyTabStyle (style);
	m_wndTab.RecalcLayout ();
	m_wndTab.RedrawWindow ();

	theApp.WriteInt (_T("TabStyle"), m_nTabStyle);
}

void CTabControlView::OnLocation() 
{
	UpdateData ();

	CMFCTabCtrl::Location location;

	switch (m_nTabLocation)
	{
	case 1:
		location = CMFCTabCtrl::LOCATION_BOTTOM;
		break;

	default:
		location = CMFCTabCtrl::LOCATION_TOP;
	}

	m_wndTab.SetLocation (location);
	m_wndTab.RecalcLayout ();
	m_wndTab.RedrawWindow ();

	theApp.WriteInt (_T("TabLocation"), m_nTabLocation);
}

void CTabControlView::OnColor() 
{
	UpdateData ();
	
	CArray<COLORREF, COLORREF> arColors;

	switch (m_nColor)
	{
	case 0:
		m_wndTab.EnableAutoColor (FALSE);
		break;

	case 1:
		m_wndTab.EnableAutoColor (TRUE);
		break;

	case 2:
		arColors.Add (RGB (121, 210, 231));
		arColors.Add (RGB (190, 218, 153));
		arColors.Add (RGB (255, 170, 100));

		m_wndTab.EnableAutoColor (TRUE);
	}

	m_wndTab.SetAutoColors (arColors);

	theApp.WriteInt (_T("TabColor"), m_nColor);
}

void CTabControlView::OnTabIcons() 
{
	UpdateData ();

	for (int nTab = 0; nTab < m_wndTab.GetTabsNum (); nTab++)
	{
		m_wndTab.SetTabIcon (nTab, m_bTabIcons ? nTab : (UINT)-1);
	}

	m_wndTab.RecalcLayout ();
	m_wndTab.RedrawWindow ();

	theApp.WriteInt (_T("TabIcons"), m_bTabIcons);
}

void CTabControlView::AddNotification (LPCTSTR lpszText)
{
	if (m_wndNotifications.GetCount () > 100)
	{
		m_wndNotifications.DeleteString (0);
	}

	int nIndex = m_wndNotifications.AddString (lpszText);
	m_wndNotifications.SetCurSel (nIndex);
}

LRESULT CTabControlView::OnMoveTab(WPARAM wp, LPARAM lp)
{
	CString str;
	str.Format (_T("AFX_WM_ON_MOVE_TAB: %d %d"), (int) wp, (int) lp);

	AddNotification (str);
	return 0;
}

LRESULT CTabControlView::OnChangeActiveTab(WPARAM wp, LPARAM /*lp*/)
{
	CString str;
	str.Format (_T("AFX_WM_CHANGE_ACTIVE_TAB: %d"), (int) wp);

	AddNotification (str);
	return 0;
}

LRESULT CTabControlView::OnChangingActiveTab(WPARAM wp, LPARAM /*lp*/)
{
	CString str;
	str.Format (_T("AFX_WM_CHANGING_ACTIVE_TAB: %d"), (int) wp);

	AddNotification (str);
	return 0;
}

void CTabControlView::OnTabSwap() 
{
	UpdateData ();

	m_wndTab.EnableTabSwap (m_bTabsSwap);
	theApp.WriteInt (_T("TabsSwap"), m_bTabsSwap);
}
