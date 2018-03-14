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
#include "Explorer.h"

#include "MainFrm.h"
#include "ExplorerDoc.h"
#include "ExplorerView.h"

#ifdef _DEBUG
#define new DEBUG_NEW
#undef THIS_FILE
static char THIS_FILE[] = __FILE__;
#endif

/////////////////////////////////////////////////////////////////////////////
// CMainFrame

IMPLEMENT_DYNCREATE(CMainFrame, CFrameWnd)


BEGIN_MESSAGE_MAP(CMainFrame, CFrameWnd)
	ON_WM_CREATE()
	ON_COMMAND(ID_VIEW_CUSTOMIZE, OnViewCustomize)
	ON_REGISTERED_MESSAGE(AFX_WM_RESETTOOLBAR, OnToolbarReset)
	ON_REGISTERED_MESSAGE(AFX_WM_TOOLBARMENU, OnToolbarContextMenu)
	ON_COMMAND(ID_VIEW_FOLDERS, OnViewFolders)
	ON_UPDATE_COMMAND_UI(ID_VIEW_FOLDERS, OnUpdateViewFolders)
	ON_CBN_SELENDOK(AFX_IDW_TOOLBAR + 1, OnNewAddress)
	ON_COMMAND(IDOK, OnNewAddressEnter)
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
	// TODO: add member initialization code here
	
}

CMainFrame::~CMainFrame()
{
}

int CMainFrame::OnCreate(LPCREATESTRUCT lpCreateStruct)
{
	if (CFrameWnd::OnCreate(lpCreateStruct) == -1)
		return -1;

	// enable Windows XP look:
	CMFCVisualManager::SetDefaultManager (RUNTIME_CLASS (CMFCVisualManagerWindows));

	CMFCToolBar::EnableQuickCustomization ();

	//---------------------------------
	// Set toolbar and menu image size:
	//---------------------------------
	CMFCToolBar::SetSizes (CSize (28, 28), CSize (22, 22));
	CMFCToolBar::SetMenuSizes (CSize (22, 22), CSize (16, 16));

	// TODO: Define your own basic commands. Be sure, that each pulldown 
	// menu have at least one basic command.

	CList<UINT, UINT>	lstBasicCommands;

	lstBasicCommands.AddTail (ID_VIEW_TOOLBARS);
	lstBasicCommands.AddTail (ID_APP_EXIT);
	lstBasicCommands.AddTail (ID_APP_ABOUT);
	lstBasicCommands.AddTail (ID_VIEW_TOOLBAR);
	lstBasicCommands.AddTail (ID_VIEW_CUSTOMIZE);
	lstBasicCommands.AddTail (ID_COMMAND_HISTORY);
	lstBasicCommands.AddTail (ID_VIEW_LARGEICON);
	lstBasicCommands.AddTail (ID_VIEW_SMALLICON);
	lstBasicCommands.AddTail (ID_VIEW_LIST);
	lstBasicCommands.AddTail (ID_VIEW_DETAILS);
	lstBasicCommands.AddTail (ID_EDIT_CUT);
	lstBasicCommands.AddTail (ID_EDIT_COPY);
	lstBasicCommands.AddTail (ID_EDIT_PASTE);

	CMFCToolBar::SetBasicCommands (lstBasicCommands);

	if (!m_wndMenuBar.Create (this))
	{
		TRACE0("Failed to create menubar\n");
		return -1;      // fail to create
	}

	m_wndMenuBar.SetPaneStyle(m_wndMenuBar.GetPaneStyle() | CBRS_SIZE_DYNAMIC);

	// Remove menubar gripper and borders:
	m_wndMenuBar.SetPaneStyle (m_wndMenuBar.GetPaneStyle() &
		~(CBRS_GRIPPER | CBRS_BORDER_TOP | CBRS_BORDER_BOTTOM | CBRS_BORDER_LEFT | CBRS_BORDER_RIGHT));

	// Detect color depth. 256 color toolbars can be used in the
	// high or true color modes only (bits per pixel is > 8):
	CClientDC dc (this);
	BOOL bIsHighColor = dc.GetDeviceCaps (BITSPIXEL) > 8;

	UINT uiToolbarHotID = bIsHighColor ? IDB_TOOLBAR256 : 0;
	UINT uiToolbarColdID = bIsHighColor ? IDB_TOOLBARCOLD256 : 0;
	UINT uiMenuID = bIsHighColor ? IDB_MENU256 : IDB_MENU16;

	if (!m_wndToolBar.CreateEx(this) ||
		!m_wndToolBar.LoadToolBar(IDR_MAINFRAME, uiToolbarColdID, uiMenuID, FALSE, 0, 0, uiToolbarHotID))
	{
		TRACE0("Failed to create toolbar\n");
		return -1;      // fail to create
	}

	// Remove toolbar gripper and borders:
	m_wndToolBar.SetPaneStyle (m_wndToolBar.GetPaneStyle() &
		~(CBRS_GRIPPER | CBRS_BORDER_TOP | CBRS_BORDER_BOTTOM | CBRS_BORDER_LEFT | CBRS_BORDER_RIGHT));

	//----------------------------------------
	// Create a combo box for the address bar:
	//----------------------------------------
	if (!m_wndAddress.Create (CBS_DROPDOWN | WS_CHILD, CRect(0, 0, 200, 120), this, AFX_IDW_TOOLBAR + 1))
	{
		TRACE0("Failed to create combobox\n");
		return -1;      // fail to create
	}

	// Each rebar pane will ocupy its own row:
	DWORD dwStyle = RBBS_GRIPPERALWAYS | RBBS_FIXEDBMP | RBBS_BREAK;

	if (!m_wndReBar.Create(this) ||
		!m_wndReBar.AddBar (&m_wndMenuBar) ||
		!m_wndReBar.AddBar (&m_wndToolBar, NULL, NULL, dwStyle) ||
		!m_wndReBar.AddBar(&m_wndAddress, _T("Address"), NULL, dwStyle))
	{
		TRACE0("Failed to create rebar\n");
		return -1;      // fail to create
	}

	m_wndMenuBar.AdjustLayout ();
	m_wndToolBar.AdjustLayout ();

	// TODO: Remove this if you don't want chevrons:
	m_wndMenuBar.EnableCustomizeButton (TRUE, -1, _T(""));
	m_wndToolBar.EnableCustomizeButton (TRUE, -1, _T(""));

	if (!m_wndStatusBar.Create(this) ||
		!m_wndStatusBar.SetIndicators(indicators,
		  sizeof(indicators)/sizeof(UINT)))
	{
		TRACE0("Failed to create status bar\n");
		return -1;      // fail to create
	}

	if (!m_wndFoldersBar.Create (_T("Folders"), 
		this, CRect (0, 0, 200, 200), TRUE, ID_VIEW_FOLDERS, 
		WS_CHILD | WS_VISIBLE | CBRS_LEFT | CBRS_HIDE_INPLACE | WS_CAPTION))
	{
		TRACE0("Failed to create folders bar\n");
		return -1;      // fail to create
	}

	EnableDocking (CBRS_ALIGN_ANY);

	m_wndReBar.EnableDocking (CBRS_TOP);
	DockPane (&m_wndReBar);

	m_wndFoldersBar.EnableDocking (CBRS_LEFT | CBRS_RIGHT);
	DockPane (&m_wndFoldersBar);

	BOOL bValidString;
	CString strMainToolbarTitle;
	bValidString = strMainToolbarTitle.LoadString (IDS_MAIN_TOOLBAR);
	m_wndToolBar.SetWindowText (strMainToolbarTitle);

	// TODO: Remove this if you don't want tool tips
	m_wndMenuBar.SetPaneStyle(m_wndMenuBar.GetPaneStyle() |
		CBRS_TOOLTIPS | CBRS_FLYBY);
	m_wndToolBar.SetPaneStyle(m_wndToolBar.GetPaneStyle() |
		CBRS_TOOLTIPS | CBRS_FLYBY);

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

afx_msg LRESULT CMainFrame::OnToolbarReset(WPARAM wp, LPARAM)
{
	UINT uiToolBarId = (UINT) wp;
	if (uiToolBarId != IDR_MAINFRAME)
	{
		return 0;
	}

	// Replace "Back" and "Forward" buttons by the menu buttons
	// with the history lists:

	CMenu menuHistory;
	menuHistory.LoadMenu (IDR_HISTORY_POPUP);

	// <snippet7>
	// CMenu menuHistory
	CMFCToolBarMenuButton btnBack (ID_GO_BACK, menuHistory, 
					GetCmdMgr ()->GetCmdImage (ID_GO_BACK), _T("Back"));
	// </snippet7>

	btnBack.m_bText = TRUE;
	m_wndToolBar.ReplaceButton (ID_GO_BACK, btnBack);

	m_wndToolBar.ReplaceButton (ID_GO_FORWARD,
		CMFCToolBarMenuButton (ID_GO_FORWARD, menuHistory, 
					GetCmdMgr ()->GetCmdImage (ID_GO_FORWARD), _T("Forward")));

	// "Folders" button has a text label:
	m_wndToolBar.SetToolBarBtnText (m_wndToolBar.CommandToIndex (ID_VIEW_FOLDERS),
		_T("Folders"));

	// Replace "Views" button by the menu button:
	CMenu menuViews;
	menuViews.LoadMenu (IDR_VIEWS_POPUP);

	m_wndToolBar.ReplaceButton (ID_VIEW_VIEWS,
		CMFCToolBarMenuButton ((UINT)-1, menuViews, 
					GetCmdMgr ()->GetCmdImage (ID_VIEW_VIEWS), _T("Views")));

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
			// Don't show toolbars list in the cuztomization mode!
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

void CMainFrame::OnViewFolders() 
{
	ShowPane (&m_wndFoldersBar,
					!(m_wndFoldersBar.GetStyle () & WS_VISIBLE),
					FALSE,TRUE);
	RecalcLayout ();
}

void CMainFrame::OnUpdateViewFolders(CCmdUI* pCmdUI) 
{
	pCmdUI->SetCheck (m_wndFoldersBar.GetStyle () & WS_VISIBLE);
}

CMFCShellTreeCtrl& CMainFrame::GetFolders ()
{
	return m_wndFoldersBar.m_wndShellTree;
}

void CMainFrame::SetCurrFolder (LPCTSTR lpszPath)
{
	ASSERT (lpszPath != NULL);
	m_wndAddress.GetEditCtrl()->SetWindowText (lpszPath);
}

void CMainFrame::OnNewAddress()
{
	// gets called when an item in the Address combo box is selected
	// just navigate to the newly selected location.
	CString str;

	m_wndAddress.GetLBText(m_wndAddress.GetCurSel(), str);
	((CExplorerView*)GetActiveView())->m_wndList.DisplayFolder (str);
}

void CMainFrame::OnNewAddressEnter()
{
	CString str;

	m_wndAddress.GetEditCtrl()->GetWindowText(str);
	((CExplorerView*)GetActiveView())->m_wndList.DisplayFolder (str);

	COMBOBOXEXITEM item;

	item.mask = CBEIF_TEXT;
	item.iItem = -1;
	item.pszText = (LPTSTR)(LPCTSTR)str;
	m_wndAddress.InsertItem(&item);
}

