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

#include "MainFrm.h"

#ifdef _DEBUG
#define new DEBUG_NEW
#undef THIS_FILE
static char THIS_FILE[] = __FILE__;
#endif

class CToolbarLabel : public CMFCToolBarButton  
{
	DECLARE_SERIAL(CToolbarLabel)

public:
	CToolbarLabel (UINT nID = 0, LPCTSTR lpszText = NULL);

	virtual void OnDraw (CDC* pDC, const CRect& rect, CMFCToolBarImages* pImages, 
						 BOOL bHorz = TRUE, BOOL bCustomizeMode = FALSE,						
						 BOOL bHighlight = FALSE,						
						 BOOL bDrawBorder = TRUE, 
						 BOOL bGrayDisabledButtons = TRUE);
};

IMPLEMENT_SERIAL(CToolbarLabel, CMFCToolBarButton, 1)

//////////////////////////////////////////////////////////////////////
// Construction/Destruction
//////////////////////////////////////////////////////////////////////

CToolbarLabel::CToolbarLabel (UINT nID, LPCTSTR lpszText)
{
	if (lpszText != NULL)	
	{		
		m_strText = lpszText;	
	}	

	m_bText = TRUE;
	m_nID = nID;
	m_iImage = -1;
}

void CToolbarLabel::OnDraw (CDC* pDC, const CRect& rect, CMFCToolBarImages* pImages, 
							  BOOL bHorz, BOOL /*bCustomizeMode*/, BOOL /*bHighlight*/, 
							  BOOL /*bDrawBorder*/,	BOOL /*bGrayDisabledButtons*/)
{
	UINT nStyle = m_nStyle;	
	m_nStyle &= ~TBBS_DISABLED;

	CMFCToolBarButton::OnDraw (pDC, rect, pImages, bHorz, FALSE,
								FALSE, FALSE, FALSE);

	m_nStyle = nStyle;
}

/////////////////////////////////////////////////////////////////////////////
// CMainFrame

IMPLEMENT_DYNCREATE(CMainFrame, CFrameWnd)


BEGIN_MESSAGE_MAP(CMainFrame, CFrameWnd)
	ON_COMMAND(ID_VIEW_THEME_TOOLBAR, OnViewThemeToolbar)
	ON_UPDATE_COMMAND_UI(ID_VIEW_THEME_TOOLBAR, OnUpdateViewThemeToolbar)
	ON_WM_CREATE()
	ON_COMMAND(ID_VIEW_CUSTOMIZE, OnViewCustomize)
	ON_REGISTERED_MESSAGE(AFX_WM_RESETTOOLBAR, OnToolbarReset)
	ON_REGISTERED_MESSAGE(AFX_WM_TOOLBARMENU, OnToolbarContextMenu)
	ON_COMMAND_RANGE(ID_VIEW_APPLOOK_2000, ID_VIEW_APPLOOK_2007_4, OnAppLook)
	ON_UPDATE_COMMAND_UI_RANGE(ID_VIEW_APPLOOK_2000, ID_VIEW_APPLOOK_2007_4, OnUpdateAppLook)
END_MESSAGE_MAP()

static UINT indicators[] =
{
	ID_SEPARATOR,           // status line indicator
	ID_INDICATOR_CAPS,
	ID_INDICATOR_NUM,
	ID_INDICATOR_SCRL,
};

/////////////////////////////////////////////////////////////////////////////
// CMainFrame construction/destruction

CMainFrame::CMainFrame()
{
	m_nAppLook = theApp.GetInt (_T("ApplicationLook"), ID_VIEW_APPLOOK_2003);

	// TODO: add member initialization code here
	
}

CMainFrame::~CMainFrame()
{
}

int CMainFrame::OnCreate(LPCREATESTRUCT lpCreateStruct)
{
	if (CFrameWnd::OnCreate(lpCreateStruct) == -1)
		return -1;

	OnAppLook (m_nAppLook);

	CMFCToolBar::EnableQuickCustomization ();


	// TODO: Define your own basic commands. Be sure, that each pulldown 
	// menu have at least one basic command.

	CList<UINT, UINT>	lstBasicCommands;

	lstBasicCommands.AddTail (ID_VIEW_TOOLBARS);
	lstBasicCommands.AddTail (ID_FILE_NEW);
	lstBasicCommands.AddTail (ID_FILE_OPEN);
	lstBasicCommands.AddTail (ID_FILE_SAVE);
	lstBasicCommands.AddTail (ID_FILE_PRINT);
	lstBasicCommands.AddTail (ID_APP_EXIT);
	lstBasicCommands.AddTail (ID_EDIT_CUT);
	lstBasicCommands.AddTail (ID_EDIT_PASTE);
	lstBasicCommands.AddTail (ID_EDIT_UNDO);
	lstBasicCommands.AddTail (ID_APP_ABOUT);
	lstBasicCommands.AddTail (ID_VIEW_TOOLBAR);
	lstBasicCommands.AddTail (ID_VIEW_CUSTOMIZE);
	lstBasicCommands.AddTail (ID_VIEW_APPLOOK_2000);
	lstBasicCommands.AddTail (ID_VIEW_APPLOOK_XP);
	lstBasicCommands.AddTail (ID_VIEW_APPLOOK_2003);
	lstBasicCommands.AddTail (ID_VIEW_APPLOOK_VS2005);
	lstBasicCommands.AddTail (ID_VIEW_APPLOOK_WIN_XP);
	lstBasicCommands.AddTail (ID_VIEW_APPLOOK_2007_1);
	lstBasicCommands.AddTail (ID_VIEW_APPLOOK_2007_2);
	lstBasicCommands.AddTail (ID_VIEW_APPLOOK_2007_3);
	lstBasicCommands.AddTail (ID_VIEW_APPLOOK_2007_4);

	CMFCToolBar::SetBasicCommands (lstBasicCommands);

	if (!m_wndMenuBar.Create (this))
	{
		TRACE0("Failed to create menubar\n");
		return -1;      // fail to create
	}

	m_wndMenuBar.SetPaneStyle(m_wndMenuBar.GetPaneStyle() | CBRS_SIZE_DYNAMIC);

	// Detect color depth. 256 color toolbars can be used in the
	// high or true color modes only (bits per pixel is > 8):
	CClientDC dc (this);
	BOOL bIsHighColor = dc.GetDeviceCaps (BITSPIXEL) > 8;

	UINT uiToolbarHotID = bIsHighColor ? IDB_TOOLBAR256 : 0;

	if (!m_wndToolBar.CreateEx(this, TBSTYLE_FLAT, WS_CHILD | WS_VISIBLE | CBRS_TOP
		| CBRS_GRIPPER | CBRS_TOOLTIPS | CBRS_FLYBY | CBRS_SIZE_DYNAMIC) ||
		!m_wndToolBar.LoadToolBar(IDR_MAINFRAME, 0, 0, FALSE, 0, 0, uiToolbarHotID))
	{
		TRACE0("Failed to create toolbar\n");
		return -1;      // fail to create
	}

	if (!m_wndToolBarTheme.Create(this, WS_CHILD | WS_VISIBLE | CBRS_TOP
		| CBRS_GRIPPER | CBRS_TOOLTIPS | CBRS_FLYBY | CBRS_SIZE_DYNAMIC, ID_VIEW_THEME_TOOLBAR) ||
		!m_wndToolBarTheme.LoadToolBar (IDR_THEME, 0, 0, TRUE /* Locked */))
	{
		TRACE0("Failed to create toolbar\n");
		return -1;      // fail to create
	}

	if (!m_wndStatusBar.Create(this) ||
		!m_wndStatusBar.SetIndicators(indicators,
		  sizeof(indicators)/sizeof(UINT)))
	{
		TRACE0("Failed to create status bar\n");
		return -1;      // fail to create
	}

	m_wndToolBar.SetWindowText (_T("Standard"));
	m_wndToolBarTheme.SetWindowText (_T("Visual Style"));

	// TODO: Delete these three lines if you don't want the toolbar to
	//  be dockable
	m_wndMenuBar.EnableDocking(CBRS_ALIGN_ANY);
	m_wndToolBar.EnableDocking(CBRS_ALIGN_ANY);
	m_wndToolBarTheme.EnableDocking(CBRS_ALIGN_ANY);

	EnableDocking(CBRS_ALIGN_ANY);
	DockPane(&m_wndMenuBar);
	DockPane(&m_wndToolBar);
	DockPane(&m_wndToolBarTheme);

	m_wndToolBar.EnableCustomizeButton (TRUE, ID_VIEW_CUSTOMIZE, _T("Customize..."));
	m_wndToolBarTheme.EnableCustomizeButton (TRUE, -1, _T(""), FALSE);

	return 0;
}

BOOL CMainFrame::PreCreateWindow(CREATESTRUCT& cs)
{
	if( !CFrameWnd::PreCreateWindow(cs) )
		return FALSE;
	// TODO: Modify the Window class or styles here by modifying
	//  the CREATESTRUCT cs

	return TRUE;
}

/////////////////////////////////////////////////////////////////////////////
// CMainFrame diagnostics

#ifdef _DEBUG
void CMainFrame::AssertValid() const
{
	CFrameWnd::AssertValid();
}

void CMainFrame::Dump(CDumpContext& dc) const
{
	CFrameWnd::Dump(dc);
}

#endif //_DEBUG

/////////////////////////////////////////////////////////////////////////////
// CMainFrame message handlers


void CMainFrame::OnViewCustomize()
{
	//------------------------------------
	// Create a customize toolbars dialog:
	//------------------------------------
	CMFCToolBarsCustomizeDialog* pDlgCust = new CMFCToolBarsCustomizeDialog (this,
		TRUE /* Automatic menus scaning */
		);

	pDlgCust->Create ();
}

LRESULT CMainFrame::OnToolbarContextMenu(WPARAM,LPARAM lp)
{
	CPoint point (AFX_GET_X_LPARAM(lp), AFX_GET_Y_LPARAM(lp));

	CMenu menu;
	VERIFY(menu.LoadMenu (IDR_POPUP_TOOLBAR));

	CMenu* pPopup = menu.GetSubMenu(0);
	ASSERT(pPopup != NULL);

	if (pPopup)
	{
		CMFCPopupMenu* pPopupMenu = new CMFCPopupMenu;
		pPopupMenu->Create (this, point.x, point.y, pPopup->Detach ());
	}

	return 0;
}

afx_msg LRESULT CMainFrame::OnToolbarReset(WPARAM wp,LPARAM)
{
	UINT uiToolBarId = (UINT) wp;
	
	if (uiToolBarId == IDR_THEME)
	{
		CMenu menu2007;
		menu2007.LoadMenu (IDR_POPUP_STYLE_20007);

		UINT uiCmd2007 = ID_VIEW_APPLOOK_2007_1;

		if (m_nAppLook >= ID_VIEW_APPLOOK_2007_1 && 
			m_nAppLook <= ID_VIEW_APPLOOK_2007_4)
		{
			uiCmd2007 = m_nAppLook;
		}

		CMFCToolBarMenuButton menuButton (uiCmd2007, menu2007.Detach (), -1);

		for (UINT uiCmd = ID_VIEW_APPLOOK_2007_1; uiCmd <= ID_VIEW_APPLOOK_2007_4; uiCmd++)
		{
			if (m_wndToolBarTheme.ReplaceButton (ID_VIEW_APPLOOK_2007_1, menuButton) > 0)
			{
				break;
			}
		}

		for (int i = 0; i < m_wndToolBarTheme.GetCount (); i++)
		{
			m_wndToolBarTheme.SetToolBarBtnText (i, NULL, TRUE, FALSE);
		}

		m_wndToolBarTheme.ReplaceButton (ID_LABEL, 
			CToolbarLabel (ID_LABEL, _T("Visual style: ")));
	}

	return 0;
}

BOOL CMainFrame::OnShowPopupMenu (CMFCPopupMenu* pMenuPopup)
{
	//---------------------------------------------------------
	// Replace ID_VIEW_TOOLBARS menu item to the toolbars list:
	//---------------------------------------------------------
	CFrameWnd::OnShowPopupMenu (pMenuPopup);

	if (pMenuPopup != NULL &&
		pMenuPopup->GetMenuBar ()->CommandToIndex (ID_VIEW_TOOLBARS) >= 0)
	{
		if (CMFCToolBar::IsCustomizeMode ())
		{
			//----------------------------------------------------
			// Don't show toolbars list in the customization mode!
			//----------------------------------------------------
			return FALSE;
		}

		pMenuPopup->RemoveAllItems ();

		CMenu menu;
		VERIFY(menu.LoadMenu (IDR_POPUP_TOOLBAR));

		CMenu* pPopup = menu.GetSubMenu(0);
		ASSERT(pPopup != NULL);

		if (pPopup)
		{
			pMenuPopup->GetMenuBar ()->ImportFromMenu (*pPopup, TRUE);
		}
	}

	return TRUE;
}

void CMainFrame::OnAppLook(UINT id)
{
	CDockingManager::SetDockingMode (DT_SMART);

	m_nAppLook = id;

	switch (m_nAppLook)
	{
	case ID_VIEW_APPLOOK_2000:
		// enable Office 2000 look:
		CMFCVisualManager::SetDefaultManager (RUNTIME_CLASS (CMFCVisualManager));
		break;

	case ID_VIEW_APPLOOK_XP:
		// enable Office XP look:
		CMFCVisualManager::SetDefaultManager (RUNTIME_CLASS (CMFCVisualManagerOfficeXP));
		break;

	case ID_VIEW_APPLOOK_WIN_XP:
		// enable Windows XP look (in other OS Office XP look will be used):
		CMFCVisualManagerWindows::m_b3DTabsXPTheme = TRUE;
		CMFCVisualManager::SetDefaultManager (RUNTIME_CLASS (CMFCVisualManagerWindows));
		break;

	case ID_VIEW_APPLOOK_2003:
		// enable Office 2003 look:
		CMFCVisualManager::SetDefaultManager (RUNTIME_CLASS (CMFCVisualManagerOffice2003));
		CDockingManager::SetDockingMode (DT_SMART);
		break;

	case ID_VIEW_APPLOOK_VS2005:
		// enable VS.NET 2005 look:
		CMFCVisualManager::SetDefaultManager (RUNTIME_CLASS (CMFCVisualManagerVS2005));
		CMFCVisualManager::GetInstance ();
		CDockingManager::SetDockingMode (DT_SMART);
		break;

	case ID_VIEW_APPLOOK_2007_1:
		// enable Office 2007 look:
		CMFCVisualManagerOffice2007::SetStyle (CMFCVisualManagerOffice2007::Office2007_LunaBlue);
		CMFCVisualManager::SetDefaultManager (RUNTIME_CLASS (CMFCVisualManagerOffice2007));
		CDockingManager::SetDockingMode (DT_SMART);
		SetupOffice2007Button ();
		break;

	case ID_VIEW_APPLOOK_2007_2:
		// enable Office 2007 look:
		CMFCVisualManagerOffice2007::SetStyle (CMFCVisualManagerOffice2007::Office2007_ObsidianBlack);
		CMFCVisualManager::SetDefaultManager (RUNTIME_CLASS (CMFCVisualManagerOffice2007));
		CDockingManager::SetDockingMode (DT_SMART);
		SetupOffice2007Button ();
		break;

	case ID_VIEW_APPLOOK_2007_3:
		// enable Office 2007 look:
		CMFCVisualManagerOffice2007::SetStyle (CMFCVisualManagerOffice2007::Office2007_Aqua);
		CMFCVisualManager::SetDefaultManager (RUNTIME_CLASS (CMFCVisualManagerOffice2007));
		CDockingManager::SetDockingMode (DT_SMART);
		SetupOffice2007Button ();
		break;

	case ID_VIEW_APPLOOK_2007_4:
		// enable Office 2007 look:
		CMFCVisualManagerOffice2007::SetStyle (CMFCVisualManagerOffice2007::Office2007_Silver);
		CMFCVisualManager::SetDefaultManager (RUNTIME_CLASS (CMFCVisualManagerOffice2007));
		CDockingManager::SetDockingMode (DT_SMART);
		SetupOffice2007Button ();
		break;

	default:
		ASSERT (FALSE);
	}

	CDockingManager* pDockManager = GetDockingManager ();
	if (pDockManager != NULL)
	{
		ASSERT_VALID (pDockManager);
		pDockManager->AdjustPaneFrames ();
	}

	RecalcLayout ();
	RedrawWindow (NULL, NULL, RDW_ALLCHILDREN | RDW_INVALIDATE | RDW_UPDATENOW | RDW_ERASE);

	theApp.WriteInt (_T("ApplicationLook"), m_nAppLook);
}

void CMainFrame::OnUpdateAppLook(CCmdUI* pCmdUI)
{
	pCmdUI->SetRadio (m_nAppLook == pCmdUI->m_nID);
}

void CMainFrame::OnViewThemeToolbar() 
{
	ShowPane (&m_wndToolBarTheme,
					!(m_wndToolBarTheme.IsVisible ()),
					FALSE, TRUE);
	RecalcLayout ();
}

void CMainFrame::OnUpdateViewThemeToolbar(CCmdUI* pCmdUI) 
{
	pCmdUI->SetCheck (m_wndToolBarTheme.IsVisible ());
}

void CMainFrame::SetupOffice2007Button ()
{
	// <snippet1>
	CMFCToolBarButton* pOffice2007 = NULL;
	int nIndex = -1;
	
	for (UINT uiCmd = ID_VIEW_APPLOOK_2007_1; uiCmd <= ID_VIEW_APPLOOK_2007_4; uiCmd++)
	{
		// CMFCToolBar	m_wndToolBarTheme
		nIndex = m_wndToolBarTheme.CommandToIndex (uiCmd);

		CMFCToolBarButton* pButton = m_wndToolBarTheme.GetButton (nIndex);
	
		if (pButton != NULL)
		{
			pOffice2007 = pButton;
			break;
		}
	}
	// </snippet1>

	if (pOffice2007 == NULL)
	{
		return;
	}

	ASSERT_VALID (pOffice2007);

	pOffice2007->m_nID = m_nAppLook;
	m_wndToolBarTheme.SetToolBarBtnText (nIndex, NULL, TRUE, FALSE);
	m_wndToolBarTheme.AdjustSizeImmediate ();

	// <snippet2>
	pOffice2007->EnableWindow();
	pOffice2007->SetImage(1);
	pOffice2007->SetRect( CRect(1,1,1,1));
	pOffice2007->SetVisible();
	pOffice2007->Show(true);
	// </snippet2>
}
