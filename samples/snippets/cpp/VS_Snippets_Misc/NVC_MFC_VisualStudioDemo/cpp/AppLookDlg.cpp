// This is a part of the Microsoft Foundation Classes C++ library.
// Copyright (c) Microsoft Corporation.  All rights reserved.
//
// This source code is only intended as a supplement to the
// Microsoft Foundation Classes Reference and related
// electronic documentation provided with the library.
// See these sources for detailed information regarding the
// Microsoft Foundation Classes product.

#include "stdafx.h"
#include "VisualStudioDemo.h"
#include "AppLookDlg.h"
#include "MainFrm.h"

#ifdef _DEBUG
#define new DEBUG_NEW
#undef THIS_FILE
static char THIS_FILE[] = __FILE__;
#endif

/////////////////////////////////////////////////////////////////////////////
// CAppLookDlg dialog

CAppLookDlg::CAppLookDlg(BOOL bStartup, CWnd* pParent /*=NULL*/) :
	CDialog(CAppLookDlg::IDD, pParent), m_bStartup(bStartup)
{
	m_bShowAtStartup = FALSE;
	m_bOneNoteTabs = TRUE;
	m_bDockTabColors = FALSE;
	m_bRoundedTabs = FALSE;
	m_bCustomTooltips = TRUE;
	m_nAppLook = 3;
	m_nStyle = 0;
	m_bActiveTabCloseButton = FALSE;

	m_nAppLook = theApp.GetInt(_T("AppLook"), 3);
	m_nStyle = theApp.GetInt(_T("AppStyle"), 0);;
	m_bShowAtStartup = theApp.GetInt(_T("ShowAppLookAtStartup"), TRUE);
	m_bOneNoteTabs = theApp.GetInt(_T("OneNoteTabs"), TRUE);
	m_bDockTabColors = theApp.GetInt(_T("DockTabColors"), FALSE);
	m_bRoundedTabs = theApp.GetInt(_T("RoundedTabs"), FALSE);
	m_bCustomTooltips = theApp.GetInt(_T("CustomTooltips"), TRUE);
	m_bActiveTabCloseButton = theApp.GetInt(_T("ActiveTabCloseButton"), FALSE);
}

void CAppLookDlg::DoDataExchange(CDataExchange* pDX)
{
	CDialog::DoDataExchange(pDX);
	DDX_Control(pDX, IDC_STYLE, m_wndStyle);
	DDX_Control(pDX, IDC_ROUNDED_TABS, m_wndRoundedTabs);
	DDX_Control(pDX, IDC_DOCK_TAB_COLORS, m_wndDockTabColors);
	DDX_Control(pDX, IDC_ONENOTE_TABS, m_wndOneNoteTabs);
	DDX_Control(pDX, IDOK, m_wndOK);
	DDX_Control(pDX, IDCANCEL, m_wndCancel);
	DDX_Check(pDX, IDC_SHOW_AT_STARTUP, m_bShowAtStartup);
	DDX_Check(pDX, IDC_ONENOTE_TABS, m_bOneNoteTabs);
	DDX_Check(pDX, IDC_DOCK_TAB_COLORS, m_bDockTabColors);
	DDX_Check(pDX, IDC_ROUNDED_TABS, m_bRoundedTabs);
	DDX_Check(pDX, IDC_CUSTOM_TOOLTIPS, m_bCustomTooltips);
	DDX_CBIndex(pDX, IDC_APP_LOOK, m_nAppLook);
	DDX_CBIndex(pDX, IDC_STYLE, m_nStyle);
	DDX_Check(pDX, IDC_ACTIVETAB_CLOSE_BUTTON, m_bActiveTabCloseButton);
}

BEGIN_MESSAGE_MAP(CAppLookDlg, CDialog)
	ON_BN_CLICKED(IDC_APPLY, OnApply)
	ON_CBN_SELENDOK(IDC_APP_LOOK, OnAppLook)
END_MESSAGE_MAP()

/////////////////////////////////////////////////////////////////////////////
// CAppLookDlg message handlers

BOOL CAppLookDlg::OnInitDialog()
{
	CDialog::OnInitDialog();
	UpdateData(FALSE);
	OnAppLook();

	if (m_bStartup)
	{
		SetLook();

		if (!m_bShowAtStartup)
		{
			EndDialog(IDCANCEL);
			return TRUE;
		}

		CRect rectBtn;

		// Hide "Cancel" button:
		m_wndCancel.GetWindowRect(rectBtn);
		ScreenToClient(rectBtn);

		m_wndOK.MoveWindow(rectBtn);

		m_wndCancel.EnableWindow(FALSE);
		m_wndCancel.ShowWindow(SW_HIDE);
	}

	return TRUE;  // return TRUE unless you set the focus to a control
}

void CAppLookDlg::OnOK()
{
	SetLook();
	CDialog::OnOK();
}

void CAppLookDlg::SetLook()
{
	CWaitCursor wait;

	UpdateData();

	CMainFrame* pMainFrame = DYNAMIC_DOWNCAST(CMainFrame, AfxGetMainWnd());
	if (pMainFrame != NULL)
	{
		pMainFrame->LockWindowUpdate();
	}

	CTabbedPane::m_StyleTabWnd = CMFCTabCtrl::STYLE_3D;

	switch (m_nAppLook)
	{
	case 0:
		CMFCVisualManager::SetDefaultManager(RUNTIME_CLASS(CMFCVisualManager));
		break;

	case 1:
		CMFCVisualManager::SetDefaultManager(RUNTIME_CLASS(CMFCVisualManagerOfficeXP));
		break;

	case 2:
		CMFCVisualManager::SetDefaultManager(RUNTIME_CLASS(CMFCVisualManagerOffice2003));
		break;

	case 3:
		CMFCVisualManager::SetDefaultManager(RUNTIME_CLASS(CMFCVisualManagerVS2005));

		if (m_bRoundedTabs)
		{
			CTabbedPane::m_StyleTabWnd = CMFCTabCtrl::STYLE_3D_ROUNDED;
		}

		CMFCVisualManagerVS2005::m_bRoundedAutohideButtons = m_bRoundedTabs;
		break;

	case 4:
		CMFCVisualManager::SetDefaultManager(RUNTIME_CLASS(CMFCVisualManagerWindows));
		CMFCVisualManagerWindows::m_b3DTabsXPTheme = TRUE;
		break;

	case 5:
		switch (m_nStyle)
		{
		case 0:
			CMFCVisualManagerOffice2007::SetStyle(CMFCVisualManagerOffice2007::Office2007_LunaBlue);
			break;

		case 1:
			CMFCVisualManagerOffice2007::SetStyle(CMFCVisualManagerOffice2007::Office2007_ObsidianBlack);
			break;

		case 2:
			CMFCVisualManagerOffice2007::SetStyle(CMFCVisualManagerOffice2007::Office2007_Aqua);
			break;

		case 3:
			CMFCVisualManagerOffice2007::SetStyle(CMFCVisualManagerOffice2007::Office2007_Silver);
			break;
		}

		CMFCVisualManager::SetDefaultManager(RUNTIME_CLASS(CMFCVisualManagerOffice2007));
		break;
	}

	theApp.WriteInt(_T("AppLook"), m_nAppLook);
	theApp.WriteInt(_T("ShowAppLookAtStartup"), m_bShowAtStartup);
	theApp.WriteInt(_T("OneNoteTabs"), m_bOneNoteTabs);
	theApp.WriteInt(_T("DockTabColors"), m_bDockTabColors);
	theApp.WriteInt(_T("RoundedTabs"), m_bRoundedTabs);
	theApp.WriteInt(_T("CustomTooltips"), m_bCustomTooltips);
	theApp.WriteInt(_T("AppStyle"), m_nStyle);
	theApp.WriteInt(_T("ActiveTabCloseButton"), m_bActiveTabCloseButton);

	switch (m_nAppLook)
	{
	case 2: // Office 2003
	case 3: // VS.NET 2005
	case 4: // Windows XP
	case 5: // Office 2007
		{
			CWindowDC dc(NULL);
			theApp.m_bHiColorIcons = dc.GetDeviceCaps(BITSPIXEL) >= 16;

			CDockingManager::SetDockingMode(DT_SMART);
		}
		break;

	default:
		theApp.m_bHiColorIcons = FALSE;
	}

	CTabbedPane::ResetTabs();

	if (m_bCustomTooltips)
	{
		CMFCToolTipInfo params;
		params.m_bVislManagerTheme = TRUE;

		theApp.GetTooltipManager()->SetTooltipParams(AFX_TOOLTIP_TYPE_ALL, RUNTIME_CLASS(CMFCToolTipCtrl), &params);
	}
	else
	{
		theApp.GetTooltipManager()->SetTooltipParams(AFX_TOOLTIP_TYPE_ALL, NULL, NULL);
	}

	if (pMainFrame != NULL)
	{
		pMainFrame->OnChangeLook(m_bOneNoteTabs/* OneNote tabs */, m_bOneNoteTabs /* MDI tab colors*/, m_nAppLook != 0 /* VS.NET look */, m_bDockTabColors /* Dock tab colors*/, m_nAppLook == 3 /* VS.NET 2005 MDI tabs */, m_bActiveTabCloseButton);

		pMainFrame->UnlockWindowUpdate();
		pMainFrame->RedrawWindow();
	}
}

void CAppLookDlg::OnApply()
{
	SetLook();

	if (!m_bStartup)
	{
		m_wndCancel.SetWindowText(_T("Close"));
	}
}

void CAppLookDlg::OnAppLook()
{
	UpdateData();

	m_wndRoundedTabs.EnableWindow(m_nAppLook == 3);
	m_wndStyle.EnableWindow(m_nAppLook == 5);
}


