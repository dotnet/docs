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
#include "MDITabsDemo.h"

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

IMPLEMENT_DYNAMIC(CMainFrame, CMDIFrameWnd)


BEGIN_MESSAGE_MAP(CMainFrame, CMDIFrameWnd)
	ON_WM_CREATE()
	ON_COMMAND(ID_VIEW_THEME_TOOLBAR, OnViewThemeToolbar)
	ON_UPDATE_COMMAND_UI(ID_VIEW_THEME_TOOLBAR, OnUpdateViewThemeToolbar)
	ON_COMMAND(ID_MDI_TABBED, OnMdiTabbed)
	ON_UPDATE_COMMAND_UI(ID_MDI_TABBED, OnUpdateMdiTabbed)
	ON_COMMAND(ID_WINDOW_MANAGER, OnWindowManager)
	ON_COMMAND(ID_VIEW_CUSTOMIZE, OnViewCustomize)
	ON_REGISTERED_MESSAGE(AFX_WM_RESETTOOLBAR, OnToolbarReset)
	ON_REGISTERED_MESSAGE(AFX_WM_TOOLBARMENU, OnToolbarContextMenu)
	ON_COMMAND(ID_VIEW_WORKSPACE, OnViewWorkspace)
	ON_UPDATE_COMMAND_UI(ID_VIEW_WORKSPACE, OnUpdateViewWorkspace)
	ON_COMMAND_RANGE(ID_VIEW_APPLOOK_2000, ID_VIEW_APPLOOK_2007_4, OnAppLook)
	ON_UPDATE_COMMAND_UI_RANGE(ID_VIEW_APPLOOK_2000, ID_VIEW_APPLOOK_2007_4, OnUpdateAppLook)
	ON_REGISTERED_MESSAGE(AFX_WM_ON_GET_TAB_TOOLTIP, OnGetTabToolTip)
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
}

CMainFrame::~CMainFrame()
{
}

int CMainFrame::OnCreate(LPCREATESTRUCT lpCreateStruct)
{
	if (CMDIFrameWnd::OnCreate(lpCreateStruct) == -1)
		return -1;

	OnAppLook (m_nAppLook);

	CMFCToolBar::EnableQuickCustomization ();

	UpdateMDITabs (FALSE);

	if (!m_wndMenuBar.Create (this))
	{
		TRACE0("Failed to create menubar\n");
		return -1;      // fail to create
	}

	m_wndMenuBar.SetPaneStyle(m_wndMenuBar.GetPaneStyle() | CBRS_SIZE_DYNAMIC);

	// Prevent the menu bar from taking the focus on activation
	CMFCPopupMenu::SetForceMenuFocus(FALSE);

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

	CImageList imagesWorkspace;
	imagesWorkspace.Create (IDB_WORKSPACE, 16, 0, RGB (255, 0, 255));

	if (!m_wndWorkSpace.Create (_T("MDI Tabs Options"), this, CRect (0, 0, 300, 300),
		TRUE, ID_VIEW_WORKSPACE,
		WS_CHILD | WS_VISIBLE | WS_CLIPSIBLINGS | WS_CLIPCHILDREN | CBRS_LEFT | CBRS_FLOAT_MULTI))
	{
		TRACE0("Failed to create Workspace bar\n");
		return FALSE;      // fail to create
	}

	m_wndWorkSpace.SetIcon (imagesWorkspace.ExtractIcon (0), FALSE);

	m_wndToolBar.SetWindowText (_T("Standard"));
	m_wndToolBarTheme.SetWindowText (_T("Visual Style"));

	// TODO: Delete these three lines if you don't want the toolbar to
	//  be dockable
	m_wndMenuBar.EnableDocking(CBRS_ALIGN_ANY);
	m_wndToolBar.EnableDocking(CBRS_ALIGN_ANY);
	m_wndToolBarTheme.EnableDocking(CBRS_ALIGN_ANY);

	m_wndWorkSpace.EnableDocking(CBRS_ALIGN_ANY);
	EnableDocking(CBRS_ALIGN_ANY);
	EnableAutoHidePanes(CBRS_ALIGN_ANY);
	DockPane(&m_wndMenuBar);
	DockPane(&m_wndToolBar);
	DockPane(&m_wndToolBarTheme);
	DockPane (&m_wndWorkSpace);

	m_wndToolBar.EnableCustomizeButton (TRUE, ID_VIEW_CUSTOMIZE, _T("Customize..."));
	m_wndToolBarTheme.EnableCustomizeButton (TRUE, -1, _T(""));

	// Enable windows manager:
	EnableWindowsDialog (ID_WINDOW_MANAGER, IDS_WINDOWS_MANAGER, TRUE);
	return 0;
}

BOOL CMainFrame::PreCreateWindow(CREATESTRUCT& cs)
{
	if( !CMDIFrameWnd::PreCreateWindow(cs) )
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
	CMDIFrameWnd::AssertValid();
}

void CMainFrame::Dump(CDumpContext& dc) const
{
	CMDIFrameWnd::Dump(dc);
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
	CMDIFrameWnd::OnShowPopupMenu (pMenuPopup);

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

void CMainFrame::OnViewWorkspace() 
{
	ShowPane (&m_wndWorkSpace,
					!(m_wndWorkSpace.IsVisible ()),
					FALSE, TRUE);
	RecalcLayout ();
}

void CMainFrame::OnUpdateViewWorkspace(CCmdUI* pCmdUI) 
{
	pCmdUI->SetCheck (m_wndWorkSpace.IsVisible ());
}

void CMainFrame::OnWindowManager() 
{
	ShowWindowsDialog ();
}

void CMainFrame::OnAppLook(UINT id)
{
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
		CMFCVisualManager::SetDefaultManager (RUNTIME_CLASS (CMFCVisualManagerWindows));
		CMFCVisualManagerWindows::m_b3DTabsXPTheme = TRUE;
		break;

	case ID_VIEW_APPLOOK_2003:
		// enable Office 2003 look:
		CMFCVisualManager::SetDefaultManager (RUNTIME_CLASS (CMFCVisualManagerOffice2003));
		break;

	case ID_VIEW_APPLOOK_VS2005:
		// enable VS 2005 look:
		CMFCVisualManager::SetDefaultManager (RUNTIME_CLASS (CMFCVisualManagerVS2005));
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
		CMFCVisualManagerOffice2007::SetStyle (CMFCVisualManagerOffice2007::Office2007_Silver);
		CMFCVisualManager::SetDefaultManager (RUNTIME_CLASS (CMFCVisualManagerOffice2007));
		CDockingManager::SetDockingMode (DT_SMART);
		SetupOffice2007Button ();
		break;

	case ID_VIEW_APPLOOK_2007_4:
		// enable Office 2007 look:
		CMFCVisualManagerOffice2007::SetStyle (CMFCVisualManagerOffice2007::Office2007_Aqua);
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

	CDockingManager::SetDockingMode (DT_SMART);

	if (!IsMDITabbedGroup())
	{
		HWND hwndT = ::GetWindow(m_hWndMDIClient, GW_CHILD);
		while (hwndT != NULL)
		{
			CMDIChildWndEx* pFrame = DYNAMIC_DOWNCAST(CMDIChildWndEx, CWnd::FromHandle(hwndT));
			if (pFrame != NULL)
			{
				ASSERT_VALID(pFrame);
				if (!pFrame->IsZoomed() && !pFrame->IsIconic())
				{
					CRect rectFrame;
					// Force a resize to happen on all the "restored" MDI child windows
					pFrame->GetWindowRect(rectFrame);
					pFrame->SetWindowPos(NULL, -1, -1, rectFrame.Width() + 1, rectFrame.Height(), SWP_NOACTIVATE | SWP_NOZORDER | SWP_NOMOVE);
					pFrame->SetWindowPos(NULL, -1, -1, rectFrame.Width(), rectFrame.Height(), SWP_NOACTIVATE | SWP_NOZORDER | SWP_NOMOVE);
				}
			}
			hwndT = ::GetWindow(hwndT, GW_HWNDNEXT);
		}
	}

	RecalcLayout ();
	RedrawWindow (NULL, NULL, RDW_ALLCHILDREN | RDW_INVALIDATE | RDW_UPDATENOW | RDW_ERASE);

	theApp.WriteInt (_T("ApplicationLook"), m_nAppLook);
}

void CMainFrame::OnUpdateAppLook(CCmdUI* pCmdUI)
{
	pCmdUI->SetRadio (m_nAppLook == pCmdUI->m_nID);
}

// <snippet3>
void CMainFrame::UpdateMDITabs (BOOL bResetMDIChild)
{
	CMDITabInfo params;
	HWND hwndActive = NULL;

	switch (theApp.m_Options.m_nMDITabsType)
	{
	case CMDITabOptions::None:
		{
			BOOL bCascadeMDIChild = FALSE;

			if (IsMDITabbedGroup ())
			{
				EnableMDITabbedGroups (FALSE, params);
				bCascadeMDIChild = TRUE;
			}
			else if (AreMDITabs ())
			{
				EnableMDITabs (FALSE);
				bCascadeMDIChild = TRUE;
			}

			if (bCascadeMDIChild)
			{
				//<snippet4>
				// CMDIClientAreaWnd m_wndClientArea
				hwndActive = (HWND) m_wndClientArea.SendMessage (WM_MDIGETACTIVE);
				m_wndClientArea.PostMessage (WM_MDICASCADE);
				m_wndClientArea.UpdateTabs( false );
				m_wndClientArea.SetActiveTab(hwndActive);
				//</snippet4>
				::BringWindowToTop (hwndActive);
			}
		}
		break;

	case CMDITabOptions::MDITabsStandard:
		hwndActive = (HWND) m_wndClientArea.SendMessage (WM_MDIGETACTIVE);
		m_wndClientArea.PostMessage (WM_MDIMAXIMIZE, LPARAM(hwndActive), 0L);
		::BringWindowToTop (hwndActive);

		EnableMDITabs (TRUE,theApp.m_Options.m_bMDITabsIcons, theApp.m_Options.m_bTabsOnTop ? CMFCTabCtrl::LOCATION_TOP : CMFCTabCtrl::LOCATION_BOTTOM, theApp.m_Options.m_nTabsStyle);

		GetMDITabs().EnableAutoColor (theApp.m_Options.m_bTabsAutoColor);
		GetMDITabs().EnableTabDocumentsMenu (theApp.m_Options.m_bMDITabsDocMenu);
		GetMDITabs().EnableTabSwap (theApp.m_Options.m_bDragMDITabs);
		GetMDITabs().SetTabBorderSize (theApp.m_Options.m_nMDITabsBorderSize);
		GetMDITabs().SetFlatFrame (theApp.m_Options.m_bFlatFrame);
		GetMDITabs().EnableCustomToolTips (theApp.m_Options.m_bCustomTooltips);
		GetMDITabs().EnableCustomToolTips (theApp.m_Options.m_bCustomTooltips);
		GetMDITabs().EnableActiveTabCloseButton (theApp.m_Options.m_bActiveTabCloseButton);
		break;
// </snippet3>

    // <snippet1>
	case CMDITabOptions::MDITabbedGroups:
		hwndActive = (HWND) m_wndClientArea.SendMessage (WM_MDIGETACTIVE);
		m_wndClientArea.PostMessage (WM_MDIMAXIMIZE, LPARAM(hwndActive), 0L);
		::BringWindowToTop (hwndActive);

		params.m_tabLocation = theApp.m_Options.m_bTabsOnTop ? CMFCTabCtrl::LOCATION_TOP : CMFCTabCtrl::LOCATION_BOTTOM;
		params.m_style = theApp.m_Options.m_nTabsStyle;
		params.m_bTabCloseButton = !theApp.m_Options.m_bActiveTabCloseButton;
		params.m_bActiveTabCloseButton = theApp.m_Options.m_bActiveTabCloseButton;
		params.m_bAutoColor = theApp.m_Options.m_bTabsAutoColor;
		params.m_bDocumentMenu = theApp.m_Options.m_bMDITabsDocMenu;
		params.m_bEnableTabSwap = theApp.m_Options.m_bDragMDITabs;
		params.m_nTabBorderSize = theApp.m_Options.m_nMDITabsBorderSize;
		params.m_bTabIcons = theApp.m_Options.m_bMDITabsIcons;
		params.m_bFlatFrame = theApp.m_Options.m_bFlatFrame;
		params.m_bTabCustomTooltips = theApp.m_Options.m_bCustomTooltips;

		EnableMDITabbedGroups (TRUE, params);
		break;
		// </snippet1>
	}

	// Some "Windows..." commands are non-relevant when all MDI child windows are always maximized:
	CList<UINT, UINT> lstCommands;

	if (theApp.m_Options.IsMDITabsDisabled())
	{
		lstCommands.AddTail (ID_WINDOW_CASCADE);
		lstCommands.AddTail (ID_WINDOW_TILE_HORZ);
		lstCommands.AddTail (ID_WINDOW_ARRANGE);
	}

	CMFCToolBar::SetNonPermittedCommands (lstCommands);

	if (bResetMDIChild)
	{
		// Adjust MDI child windows:
		BOOL bMaximize = !theApp.m_Options.IsMDITabsDisabled();

		HWND hwndT = ::GetWindow(m_hWndMDIClient, GW_CHILD);
		while (hwndT != NULL)
		{
			CMDIChildWndEx* pFrame = DYNAMIC_DOWNCAST(CMDIChildWndEx, CWnd::FromHandle(hwndT));
			if (pFrame != NULL)
			{
				ASSERT_VALID (pFrame);
				if (bMaximize)
				{
					pFrame->ModifyStyle(WS_SYSMENU, 0);
				}
				else
				{
					pFrame->ModifyStyle(0, WS_SYSMENU);
					pFrame->ShowWindow(SW_RESTORE);

					// Force a resize to happen on all the "restored" MDI child windows
					CRect rectFrame;
					pFrame->GetWindowRect(rectFrame);
					pFrame->SetWindowPos(NULL, -1, -1, rectFrame.Width() + 1, rectFrame.Height(), SWP_NOACTIVATE | SWP_NOZORDER | SWP_NOMOVE);
					pFrame->SetWindowPos(NULL, -1, -1, rectFrame.Width(), rectFrame.Height(), SWP_NOACTIVATE | SWP_NOZORDER | SWP_NOMOVE);
				}
			}

			hwndT = ::GetWindow(hwndT, GW_HWNDNEXT);
		}
		if (bMaximize)
		{
			m_wndMenuBar.SetMaximizeMode (FALSE);
		}
	}

	if (m_wndWorkSpace.IsAutoHideMode ())
	{
		m_wndWorkSpace.BringWindowToTop ();

		// <snippet5>
		// CWorkspaceBar m_wndWorkSpace
		CPaneDivider* pSlider = m_wndWorkSpace.GetDefaultPaneDivider ();
		// </snippet5>

		if (pSlider != NULL)
		{
			pSlider->BringWindowToTop ();
		}
	}

	CMDIFrameWndEx::m_bDisableSetRedraw = theApp.m_Options.m_bDisableMDIChildRedraw;

	RecalcLayout ();
	RedrawWindow (NULL, NULL, RDW_ALLCHILDREN | RDW_INVALIDATE | RDW_UPDATENOW | RDW_ERASE);
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

CMDIChildWndEx* CMainFrame::CreateDocumentWindow (LPCTSTR lpcszDocName)
{
	if (lpcszDocName != NULL && lpcszDocName [0] != '\0')
	{
		CDocument* pDoc = AfxGetApp()->OpenDocumentFile (lpcszDocName);

		if (pDoc != NULL)
		{
			POSITION pos = pDoc->GetFirstViewPosition();

			if (pos != NULL)
			{
				CView* pView = pDoc->GetNextView (pos);
				return DYNAMIC_DOWNCAST (CMDIChildWndEx, pView->GetParent ());
			}   
		}
	}
	return NULL;
}

BOOL CMainFrame::OnShowMDITabContextMenu (CPoint point, DWORD dwAllowedItems, BOOL bDrop)
{
	if (bDrop || !theApp.m_Options.m_bMDITabsContextMenu)
	{
		return FALSE;
	}

	CMenu menu;
	VERIFY(menu.LoadMenu (IDR_POPUP_MDITABS));

	CMenu* pPopup = menu.GetSubMenu(0);
	ASSERT(pPopup != NULL);

	if (pPopup)
	{
		if ((dwAllowedItems & AFX_MDI_CAN_BE_DOCKED) == 0)
		{
			pPopup->DeleteMenu (ID_MDI_TABBED, MF_BYCOMMAND);
		}

		CMFCPopupMenu* pPopupMenu = new CMFCPopupMenu;
		if (pPopupMenu)
		{
			pPopupMenu->SetAutoDestroy (FALSE);
			pPopupMenu->Create (this, point.x, point.y, pPopup->GetSafeHmenu ());
		}
	}

	return TRUE;
}

// <snippet2>
LRESULT CMainFrame::OnGetTabToolTip(WPARAM /*wp*/, LPARAM lp)
{
	CMFCTabToolTipInfo* pInfo = (CMFCTabToolTipInfo*) lp;
	ASSERT (pInfo != NULL);

	if (pInfo)
	{
		ASSERT_VALID (pInfo->m_pTabWnd);
		if (!pInfo->m_pTabWnd->IsMDITab ())
		{
			return 0;
		}
		pInfo->m_strText.Format (_T("Tab #%d Custom Tooltip"), pInfo->m_nTabIndex + 1);
	}

	return 0;
}
// </snippet2>

void CMainFrame::SetupOffice2007Button ()
{
	CMFCToolBarButton* pOffice2007 = NULL;
	int nIndex = -1;
	
	for (UINT uiCmd = ID_VIEW_APPLOOK_2007_1; uiCmd <= ID_VIEW_APPLOOK_2007_4; uiCmd++)
	{
		nIndex = m_wndToolBarTheme.CommandToIndex (uiCmd);

		CMFCToolBarButton* pButton = m_wndToolBarTheme.GetButton (nIndex);
		if (pButton != NULL)
		{
			pOffice2007 = pButton;
			break;
		}
	}

	if (pOffice2007 == NULL)
	{
		return;
	}

	ASSERT_VALID (pOffice2007);

	pOffice2007->m_nID = m_nAppLook;
	m_wndToolBarTheme.SetToolBarBtnText (nIndex, NULL, TRUE, FALSE);
	m_wndToolBarTheme.AdjustSizeImmediate ();
}

void CMainFrame::OnMdiTabbed() 
{
	CMDIChildWndEx* pMDIChild = DYNAMIC_DOWNCAST(CMDIChildWndEx, MDIGetActive ());
	if (pMDIChild == NULL)
	{
		ASSERT (FALSE);
		return;
	}

	TabbedDocumentToControlBar (pMDIChild);
}

void CMainFrame::OnUpdateMdiTabbed(CCmdUI* pCmdUI) 
{
	pCmdUI->SetCheck ();
}
