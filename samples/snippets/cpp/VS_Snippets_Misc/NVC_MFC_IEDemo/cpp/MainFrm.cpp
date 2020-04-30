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
#include "LinkButton.h"

#ifdef _DEBUG
#define new DEBUG_NEW
#undef THIS_FILE
static char THIS_FILE[] = __FILE__;
#endif

/////////////////////////////////////////////////////////////////////////////
// CMainFrame

IMPLEMENT_DYNCREATE(CMainFrame, CFrameWnd)

BEGIN_MESSAGE_MAP(CMainFrame, CFrameWnd)
	//{{AFX_MSG_MAP(CMainFrame)
	ON_WM_CREATE()
	ON_COMMAND(ID_LINK_1, OnLink1)
	ON_COMMAND(ID_VIEW_ADDRESS_BAR, OnViewAddressBar)
	ON_UPDATE_COMMAND_UI(ID_VIEW_ADDRESS_BAR, OnUpdateViewAddressBar)
	ON_COMMAND(ID_VIEW_LINKS_BAR, OnViewLinksBar)
	ON_UPDATE_COMMAND_UI(ID_VIEW_LINKS_BAR, OnUpdateViewLinksBar)
	ON_COMMAND(ID_VIEW_TEXTLABELS, OnViewTextlabels)
	ON_UPDATE_COMMAND_UI(ID_VIEW_TEXTLABELS, OnUpdateViewTextlabels)
	ON_COMMAND(ID_VIEW_EXPLORERBAR, OnViewExplorerbar)
	ON_UPDATE_COMMAND_UI(ID_VIEW_EXPLORERBAR, OnUpdateViewExplorerbar)
	//}}AFX_MSG_MAP
	ON_COMMAND(ID_VIEW_CUSTOMIZE, OnViewCustomize)
	ON_REGISTERED_MESSAGE(AFX_WM_RESETTOOLBAR, OnToolbarReset)
	ON_REGISTERED_MESSAGE(AFX_WM_TOOLBARMENU, OnToolbarContextMenu)
	ON_REGISTERED_MESSAGE(AFX_WM_CUSTOMIZEHELP, OnHelpCustomizeToolbars)
	ON_CBN_SELENDOK(AFX_IDW_TOOLBAR + 1,OnNewAddress)
	ON_COMMAND_RANGE(FIRST_FAVORITE_COMMAND, LAST_FAVORITE_COMMAND, OnFavorite)
	ON_COMMAND_RANGE(FIRST_HISTORY_COMMAND, FIRST_HISTORY_COMMAND + HISTORY_LEN - 1, OnHistory)
	ON_COMMAND(IDOK, OnNewAddressEnter)
	ON_COMMAND(ID_LINK_MSDN, OnLinkMSDN)
	ON_COMMAND(ID_LINK_MICROSOFT, OnLinkMicrosoft)
	ON_COMMAND(ID_LINK_VISUALCPP, OnLinkVisualCPP)
END_MESSAGE_MAP()

static UINT indicators[] =
{
	ID_INDICATOR_ICON,		// status icon
	ID_SEPARATOR,           // status line indicator
	ID_INDICATOR_PROGRESS,	// progress bar
	ID_INDICATOR_CAPS,
	ID_INDICATOR_NUM,
	ID_INDICATOR_SCRL,
};

const int nStatusIcon = 0;
const int nStatusInfo = 1;
const int nStatusProgress = 2;

/////////////////////////////////////////////////////////////////////////////
// CMainFrame construction/destruction

CMainFrame::CMainFrame()
{
	m_bMainToolbarMenu = FALSE;
}

CMainFrame::~CMainFrame()
{
}

int CMainFrame::OnCreate(LPCREATESTRUCT lpCreateStruct)
{
	if (CFrameWnd::OnCreate(lpCreateStruct) == -1)
		return -1;

	CMFCToolBar::EnableQuickCustomization ();
	CMFCVisualManager::SetDefaultManager (RUNTIME_CLASS (CMFCVisualManagerWindows));

	((CMFCVisualManagerWindows*)CMFCVisualManager::GetInstance ())->SetOfficeStyleMenus ();

	//---------------------------------
	// Set toolbar and menu image size:
	//---------------------------------
	CMFCToolBar::SetSizes (CSize (36, 30), CSize (23, 23));
	CMFCToolBar::SetMenuSizes (CSize (22, 22), CSize (16, 16));

	//--------------------
	// Create the menubar:
	//--------------------
	// <snippet2>
	// The this pointer points to CMainFrame class which extends the CFrameWnd class.
	if (!m_wndMenuBar.CreateEx (this, TBSTYLE_TRANSPARENT))
	{
		TRACE0("Failed to create menubar\n");
		return -1;      // fail to create
	}
	// </snippet2>

	// <snippet3>
	m_wndMenuBar.SetPaneStyle(m_wndMenuBar.GetPaneStyle() | CBRS_SIZE_DYNAMIC);
	m_wndMenuBar.EnableCustomizeButton (TRUE, -1, _T(""));
	// first parameter is the command ID for the button of the Help combo box
	// third parameter is the width of the button for the combo box in pixels.
	m_wndMenuBar.EnableHelpCombobox(1,_T("enter text here"),30);
	m_wndMenuBar.EnableMenuShadows();
	m_wndMenuBar.SetMaximizeMode(true);
	// </snippet3>

	//------------------------------------
	// Remove menubar gripper and borders:
	//------------------------------------
	m_wndMenuBar.SetPaneStyle (m_wndMenuBar.GetPaneStyle() &
		~(CBRS_GRIPPER | CBRS_BORDER_TOP | CBRS_BORDER_BOTTOM | CBRS_BORDER_LEFT | CBRS_BORDER_RIGHT));

	// Detect color depth. 256 color toolbars can be used in the
	// high or true color modes only (bits per pixel is > 8):
	CClientDC dc (this);
	m_bIsHighColor = dc.GetDeviceCaps (BITSPIXEL) > 16;

	UINT uiToolbarHotID = m_bIsHighColor ? IDB_HOTTOOLBAR : 0;
	UINT uiToolbarColdID = m_bIsHighColor ? IDB_COLDTOOLBAR : 0;
	UINT uiMenuID = m_bIsHighColor ? IDB_MENU_IMAGES : IDB_MENU_IMAGES_16;

	// <snippet7>
	// The this pointer points to CMainFrame class which extends the CFrameWnd class.
	if (!m_wndToolBar.CreateEx (this, TBSTYLE_TRANSPARENT) ||
		!m_wndToolBar.LoadToolBar (IDR_MAINFRAME, uiToolbarColdID, uiMenuID, 
			FALSE /* Not locked */, 0, 0, uiToolbarHotID))
	{
		TRACE0("Failed to create toolbar\n");
		return -1;      // fail to create
	}
	// </snippet7>

	// <snippet8>
	m_wndToolBar.SetWindowText (_T("Standard"));
	m_wndToolBar.SetBorders ();

	//------------------------------------
	// Remove toolbar gripper and borders:
	//------------------------------------
	m_wndToolBar.SetPaneStyle (m_wndToolBar.GetPaneStyle() &
		~(CBRS_GRIPPER | CBRS_BORDER_TOP | CBRS_BORDER_BOTTOM | CBRS_BORDER_LEFT | CBRS_BORDER_RIGHT));

	m_wndToolBar.EnableCustomizeButton (TRUE, ID_VIEW_CUSTOMIZE, _T("Customize..."));
	// </snippet8>

	BOOL bValidString;

	//----------------------------------------
	// Create a combo box for the address bar:
	//----------------------------------------
	CString strAddressLabel;
	bValidString = strAddressLabel.LoadString(IDS_ADDRESS);

	if (!m_wndAddress.Create (CBS_DROPDOWN | WS_CHILD, CRect(0, 0, 200, 120), this, AFX_IDW_TOOLBAR + 1))
	{
		TRACE0("Failed to create combobox\n");
		return -1;      // fail to create
	}

	//------------------
	// Create links bar:
	//------------------
	CString strLinksLabel;
	bValidString = strLinksLabel.LoadString (IDS_LINKS);

	if (!m_wndLinksBar.CreateEx (this, TBSTYLE_TRANSPARENT,
		AFX_DEFAULT_TOOLBAR_STYLE, CRect(0, 0, 0, 0), AFX_IDW_TOOLBAR + 3))
	{
		TRACE0("Failed to create links bar\n");
	}

	m_wndLinksBar.EnableCustomizeButton (TRUE, -1, _T(""));

	m_wndLinksBar.SetWindowText (strLinksLabel);
	m_wndLinksBar.SetPaneStyle (m_wndLinksBar.GetPaneStyle() &
		~(CBRS_GRIPPER | CBRS_BORDER_TOP | CBRS_BORDER_BOTTOM | CBRS_BORDER_LEFT | CBRS_BORDER_RIGHT));

	//--------------
	// Create rebar:
	//--------------
	if (!m_wndReBar.Create(this) ||
		!m_wndReBar.AddBar(&m_wndMenuBar) ||
		!m_wndReBar.AddBar(&m_wndToolBar, NULL, NULL,
				RBBS_GRIPPERALWAYS | RBBS_FIXEDBMP | RBBS_BREAK) ||
		!m_wndReBar.AddBar(&m_wndAddress, strAddressLabel, NULL,
				RBBS_GRIPPERALWAYS | RBBS_FIXEDBMP | RBBS_BREAK) ||
		!m_wndReBar.AddBar(&m_wndLinksBar, strLinksLabel, NULL,
				RBBS_GRIPPERALWAYS | RBBS_FIXEDBMP | RBBS_BREAK))
	{
		TRACE0("Failed to create rebar\n");
		return -1;      // fail to create
	}

	m_wndMenuBar.AdjustLayout ();
	m_wndToolBar.AdjustLayout ();
	m_wndLinksBar.AdjustLayout ();

	//--------------------------------------------------------------
	// Set up min/max sizes and ideal sizes for pieces of the rebar:
	//--------------------------------------------------------------
	REBARBANDINFO rbbi;

	// <snippet9>
	CRect rectToolBar;
	m_wndToolBar.GetItemRect(0, &rectToolBar);
	// </snippet9>

	rbbi.cbSize = sizeof(rbbi);
	rbbi.fMask = RBBIM_CHILDSIZE | RBBIM_IDEALSIZE | RBBIM_SIZE;
	rbbi.cxMinChild = rectToolBar.Width();
	rbbi.cyMinChild = rectToolBar.Height();
	rbbi.cx = rbbi.cxIdeal = rectToolBar.Width() * m_wndToolBar.GetCount ();
	m_wndReBar.GetReBarCtrl().SetBandInfo (1, &rbbi);
	rbbi.cxMinChild = 0;

	CRect rectAddress;
	m_wndAddress.GetEditCtrl()->GetWindowRect(&rectAddress);

	rbbi.fMask = RBBIM_CHILDSIZE | RBBIM_IDEALSIZE;
	rbbi.cyMinChild = rectAddress.Height() + 10;
	rbbi.cxIdeal = 200;
	m_wndReBar.GetReBarCtrl().SetBandInfo (3, &rbbi);

	EnableDocking(CBRS_ALIGN_ANY);
	m_wndReBar.EnableDocking (CBRS_TOP);
	DockPane (&m_wndReBar);

	//-------------------
	// Create status bar:
	//-------------------
	if (!m_wndStatusBar.Create(this) ||
		!m_wndStatusBar.SetIndicators(indicators,
		  sizeof(indicators)/sizeof(UINT)))
	{
		TRACE0("Failed to create status bar\n");
		return -1;      // fail to create
	}

	//------------------------------
	// First pane - image/animation:
	//------------------------------
	m_wndStatusBar.SetPaneStyle (nStatusIcon, SBPS_NOBORDERS);

	m_bmpStatus.LoadBitmap (IDB_STATUS_READY);
	m_imlStatusAnimation.Create (IDB_STATUS_ANIMATION, 11, 0, RGB (255, 0, 255));

	m_wndStatusBar.SetPaneIcon (nStatusIcon, m_bmpStatus);
	m_wndStatusBar.SetPaneText (nStatusIcon, NULL);
	m_wndStatusBar.SetPaneWidth (nStatusIcon, 0);

	m_wndStatusBar.SetPaneStyle (nStatusInfo, SBPS_STRETCH | SBPS_NOBORDERS);
	m_wndStatusBar.SetPaneWidth (nStatusProgress, 80);

	CString strMainToolbarTitle;
	bValidString = strMainToolbarTitle.LoadString (IDS_MAIN_TOOLBAR);
	m_wndToolBar.SetWindowText (strMainToolbarTitle);
	m_wndMenuBar.SetPaneStyle(m_wndMenuBar.GetPaneStyle() |
		CBRS_TOOLTIPS | CBRS_FLYBY);
	m_wndToolBar.SetPaneStyle(m_wndToolBar.GetPaneStyle() |
		CBRS_TOOLTIPS | CBRS_FLYBY);
	m_wndLinksBar.SetPaneStyle(m_wndLinksBar.GetPaneStyle() |
		CBRS_TOOLTIPS | CBRS_FLYBY);

	//-----------------------
	// Set up Favorites menu:
	//-----------------------
	VERIFY (theApp.m_Favorites.CreateMenu (m_menuFavotites));

	//---------------------
	// Create explorer bar:
	//---------------------
	if (!m_wndExplorerBar.Create (_T("Favorites"),this, CRect (0, 0, 200, 200),
		TRUE,
		ID_VIEW_EXPLORERBAR,
		WS_CHILD | WS_VISIBLE | CBRS_LEFT | CBRS_HIDE_INPLACE | WS_CAPTION,
		AFX_CBRS_OUTLOOK_TABS,
		AFX_CBRS_CLOSE | AFX_CBRS_RESIZE))
	{
		TRACE0("Failed to create explorerbar\n");
		return FALSE;		// fail to create
	}

	m_wndExplorerBar.EnableDocking (CBRS_ALIGN_LEFT | CBRS_ALIGN_RIGHT);
	DockPane(&m_wndExplorerBar);

	//------------------------------------------------------
	// Add additional images to the global image collection:
	//------------------------------------------------------
	CMFCToolBar::AddToolBarForImageCollection (
		IDR_TOOLBAR_IMAGE_COLLECTION,					// Toolbar (need for map "Command - Image")
		m_bIsHighColor ? IDB_IMAGE_COLLECTION : 0,		// "Hot" images
		m_bIsHighColor ? IDB_IMAGE_COLLECTION : 0,		// "Cold" images
		m_bIsHighColor ? IDB_IMAGE_COLLECTION_SMALL : 0);	// Menu images
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
		TRUE /* Automatic menus scaning */,
		AFX_CUSTOMIZE_TEXT_LABELS | AFX_CUSTOMIZE_NOTOOLS | AFX_CUSTOMIZE_NO_LARGE_ICONS);

	CMenu menuFavorites;
	menuFavorites.LoadMenu (IDR_FAVORITES_POPUP);

	BOOL bValidString;
	CString strFavorites;
	bValidString = strFavorites.LoadString (IDS_FAVORITES);

	// CMFCToolBarsCustomizeDialog* pDlgCust
	// <snippet4>
	pDlgCust->ReplaceButton (ID_FAVORITS_DUMMY,
		CMFCToolBarMenuButton ((UINT)-1, menuFavorites, -1, strFavorites));
	pDlgCust->EnableUserDefinedToolbars();
	pDlgCust->Create ();
	// </snippet4>
}

LRESULT CMainFrame::OnToolbarContextMenu(WPARAM wp,LPARAM lp)
{
	CMFCToolBar* pToolBar = DYNAMIC_DOWNCAST (CMFCToolBar, 
											CWnd::FromHandlePermanent ((HWND) wp));
	m_bMainToolbarMenu = (
		pToolBar != NULL && pToolBar->GetDlgCtrlID () == AFX_IDW_TOOLBAR);

	CPoint point (AFX_GET_X_LPARAM(lp), AFX_GET_Y_LPARAM(lp));

	CMenu menu;
	VERIFY(menu.LoadMenu (IDR_POPUP_TOOLBAR));

	CMenu* pPopup = menu.GetSubMenu(0);
	ASSERT(pPopup != NULL);

	if (pPopup)
	{
		CMFCPopupMenu* pPopupMenu = new CMFCPopupMenu;
		if (pPopupMenu)
		{
			pPopupMenu->Create (this, point.x, point.y, pPopup->Detach ());
		}
	}

	return 0;
}

afx_msg LRESULT CMainFrame::OnToolbarReset(WPARAM wp, LPARAM)
{
	UINT uiToolBarId = (UINT) wp;
	if (uiToolBarId == IDR_MAINFRAME)
	{
		CString str;

		// Replace "Back" and "Forward" buttons by the menu buttons
		// with the history lists:

		CMenu menuHistory;
		menuHistory.LoadMenu (IDR_HISTORY_POPUP);

		BOOL bValidString;
		bValidString = str.LoadString (IDS_BACK);

		// <snippet10>
		// CMenu menuHistory
		// CString str
		m_wndToolBar.ReplaceButton (ID_GO_BACK, 
			CMFCToolBarMenuButton (ID_GO_BACK, menuHistory, 
						GetCmdMgr ()->GetCmdImage (ID_GO_BACK), str));
		// </snippet10>

		bValidString = str.LoadString (IDS_FORWARD);
		m_wndToolBar.ReplaceButton (ID_GO_FORWARD,
			CMFCToolBarMenuButton (ID_GO_FORWARD, menuHistory, 
						GetCmdMgr ()->GetCmdImage (ID_GO_FORWARD), str));

		// Setup "Favorites" menu button:
		CMenu menuFavorites;
		menuFavorites.LoadMenu (IDR_FAVORITES_POPUP);

		bValidString = str.LoadString (IDS_FAVORITES);
		m_wndToolBar.ReplaceButton (ID_FAVORITS_DUMMY,
			CMFCToolBarMenuButton ((UINT)-1, menuFavorites, 
						GetCmdMgr ()->GetCmdImage (ID_FAVORITS_DUMMY), str));

		// Setup "Fonts" menu button:
		CMenu menuFonts;
		menuFonts.LoadMenu (IDR_FONT_POPUP);

		bValidString = str.LoadString(IDS_FONT);
		m_wndToolBar.ReplaceButton (ID_FONT_DROPDOWN,
			CMFCToolBarMenuButton ((UINT)-1, *menuFonts.GetSubMenu (0), 
						GetCmdMgr ()->GetCmdImage (ID_FONT_DROPDOWN), str));
		// Some buttons will appear with text by default:

		m_wndToolBar.SetToolBarBtnText (m_wndToolBar.CommandToIndex (ID_GO_BACK));
		m_wndToolBar.SetToolBarBtnText (m_wndToolBar.CommandToIndex (ID_GO_SEARCH_THE_WEB));
	}

	return 0;
}

LRESULT CMainFrame::OnHelpCustomizeToolbars(WPARAM /*wp*/, LPARAM /*lp*/)
{
// int iPageNum = (int) wp;

//	CToolbarCustomize* pDlg = (CToolbarCustomize*) lp;
//	ASSERT_VALID (pDlg);

	// TODO: show help about page number iPageNum

	return 0;
}

BOOL CMainFrame::OnShowPopupMenu (CMFCPopupMenu* pMenuPopup)
{
    CFrameWnd::OnShowPopupMenu (pMenuPopup);

	if (pMenuPopup == NULL)
	{
        return TRUE;
    }

	CMFCPopupMenuBar* pMenuBar = pMenuPopup->GetMenuBar ();
	ASSERT_VALID (pMenuBar);

	for (int i = 0; i < pMenuBar->GetCount (); i ++)
	{
		CMFCToolBarButton* pButton = pMenuBar->GetButton (i);
		ASSERT_VALID (pButton);

		if (pButton->m_nID == ID_FAVORITS_DUMMY)
		{
			if (CMFCToolBar::IsCustomizeMode ())
			{
				return FALSE;
			}

			pMenuBar->ImportFromMenu (m_menuFavotites);
			pMenuPopup->SetMaxWidth (300);

			return TRUE;
		}
	}

	CMFCToolBarMenuButton* pParentButton = pMenuPopup->GetParentButton ();
	if (pParentButton == NULL)
	{
		return TRUE;
	}

	switch (pParentButton->m_nID)
	{
	case ID_GO_BACK:
	case ID_GO_FORWARD:
		{
			if (CMFCToolBar::IsCustomizeMode ())
			{
				return FALSE;
			}

			CIEDemoView* pView = ((CIEDemoView*)GetActiveView());
			ASSERT_VALID (pView);

			CIEDemoDoc* pDoc = pView->GetDocument();
			ASSERT_VALID(pDoc);

			_T_HistotyList lst;

			if (pParentButton->m_nID == ID_GO_BACK)
			{
				pDoc->GetBackList (lst);
			}
			else
			{
				pDoc->GetFrwdList (lst);
			}
			
			if (!lst.IsEmpty ())
			{
				pMenuPopup->RemoveAllItems ();

				for (POSITION pos = lst.GetHeadPosition (); pos != NULL;)
				{
					CHistoryObj* pObj = lst.GetNext (pos);
					ASSERT (pObj != NULL);

					if (pObj)
					{
						pMenuPopup->InsertItem (CMFCToolBarMenuButton (pObj->GetCommand (), NULL, -1, pObj->GetTitle ()));
					}
				}
			}
		}
	}

	return TRUE;
}

BOOL CMainFrame::OnDrawMenuImage (CDC* pDC,
								const CMFCToolBarMenuButton* pMenuButton,
								const CRect& rectImage)
{
	if (theApp.m_Favorites.GetSysImages () == NULL)
	{
		return FALSE;
	}

	ASSERT_VALID (pDC);
	ASSERT_VALID (pMenuButton);

	int iIcon = -1;

	if (pMenuButton->m_nID >= FIRST_FAVORITE_COMMAND &&
		pMenuButton->m_nID <= LAST_FAVORITE_COMMAND)
	{
		iIcon = theApp.m_Favorites.GetIDIcon (pMenuButton->m_nID);
	}
	else if (IsFavoritesMenu (pMenuButton))	// Maybe, favorits folder?
	{
		iIcon = theApp.m_Favorites.GetFolderIcon ();
	}

	if (iIcon == -1)
	{
		return FALSE;	// Don't draw it!
	}

	::ImageList_Draw (theApp.m_Favorites.GetSysImages (), iIcon, 
		pDC->GetSafeHdc (), 
		rectImage.left + (rectImage.Width () - theApp.m_Favorites.GetSysImageSize ().cx) / 2, 
		rectImage.top + (rectImage.Height () - theApp.m_Favorites.GetSysImageSize ().cy) / 2, ILD_TRANSPARENT);

	return TRUE;
}

BOOL CMainFrame::IsFavoritesMenu (const CMFCToolBarMenuButton* pMenuButton)
{
	if (pMenuButton == NULL || pMenuButton->m_nID != (UINT) -1)
	{
		return FALSE;
	}

	ASSERT_VALID (pMenuButton);
	const CObList& lstCommands = pMenuButton->GetCommands ();
	
	for (POSITION pos = lstCommands.GetHeadPosition (); pos != NULL;)
	{
		CMFCToolBarButton* pCmd = (CMFCToolBarButton*) lstCommands.GetNext (pos);
		ASSERT_VALID (pCmd);

		if ((pCmd->m_nID >= FIRST_FAVORITE_COMMAND &&
			pCmd->m_nID <= LAST_FAVORITE_COMMAND) ||
			IsFavoritesMenu (DYNAMIC_DOWNCAST (CMFCToolBarMenuButton, pCmd)))
		{
			return TRUE;
		}
	}

	return FALSE;
}

void CMainFrame::OnFavorite(UINT nID)
{
	SetFocus ();
	((CIEDemoView*)GetActiveView())->Navigate2(theApp.m_Favorites.GetURLofID (nID), 0, NULL);
}

void CMainFrame::OnHistory(UINT nID)
{
	CIEDemoView* pView = ((CIEDemoView*)GetActiveView());
	ASSERT_VALID (pView);

	CIEDemoDoc* pDoc = pView->GetDocument();
	ASSERT_VALID(pDoc);

	CHistoryObj* pObj = pDoc->Go (nID);
	ASSERT (pObj != NULL);

	if (pObj)
	{
		pView->Navigate2 (pObj->GetURL (), 0, NULL);
	}
}

void CMainFrame::SetAddress(LPCTSTR lpszUrl)
{
	// This is called when the browser has completely loaded the new location,
	// so make sure the text in the address bar is up to date and stop the
	// animation.
	m_wndAddress.SetWindowText(lpszUrl);
	m_wndStatusBar.SetPaneIcon (nStatusIcon, m_bmpStatus);
}

void CMainFrame::StartAnimation()
{
	// Start the animation.  This is called when the browser begins to
	// navigate to a new location
	m_wndStatusBar.SetPaneAnimation (nStatusIcon, m_imlStatusAnimation);
}

void CMainFrame::OnNewAddress()
{
	// gets called when an item in the Address combo box is selected
	// just navigate to the newly selected location.
	CString str;

	m_wndAddress.GetLBText(m_wndAddress.GetCurSel(), str);
	((CIEDemoView*)GetActiveView())->Navigate2(str, 0, NULL);
}

void CMainFrame::OnNewAddressEnter()
{
	// gets called when an item is entered manually into the edit box portion
	// of the Address combo box.
	// navigate to the newly selected location and also add this address to the
	// list of addresses in the combo box.
	CString str;

	m_wndAddress.GetEditCtrl()->GetWindowText(str);
	((CIEDemoView*)GetActiveView())->Navigate2(str, 0, NULL);

	COMBOBOXEXITEM item;

	item.mask = CBEIF_TEXT;
	item.iItem = -1;
	item.pszText = (LPTSTR)(LPCTSTR)str;
	m_wndAddress.InsertItem(&item);
}

void CMainFrame::OnLink1() 
{
	// TODO: Add your command handler code here
	
}

void CMainFrame::OnViewAddressBar() 
{
	m_wndReBar.GetReBarCtrl().ShowBand (3, !m_wndAddress.IsWindowVisible ());
}

void CMainFrame::OnUpdateViewAddressBar(CCmdUI* pCmdUI) 
{
	pCmdUI->SetCheck (m_wndAddress.IsWindowVisible ());
}

void CMainFrame::OnViewLinksBar() 
{
	ShowPane (&m_wndLinksBar, (m_wndLinksBar.GetStyle () & WS_VISIBLE) == 0, FALSE, TRUE);
}

void CMainFrame::OnUpdateViewLinksBar(CCmdUI* pCmdUI) 
{
	pCmdUI->SetCheck (m_wndLinksBar.IsWindowVisible ());
}

BOOL CMainFrame::OnMenuButtonToolHitTest (CMFCToolBarButton* pButton, TOOLINFO* pTI)
{
	ASSERT_VALID (pButton);
	
	if (pButton->m_nID < FIRST_FAVORITE_COMMAND ||
		pButton->m_nID > LAST_FAVORITE_COMMAND)
	{
		return FALSE;
	}

	ASSERT (pTI != NULL);

	if (pTI)
	{
		CString strText = theApp.m_Favorites.GetURLofID (pButton->m_nID);
		pTI->lpszText = (LPTSTR) ::calloc ((strText.GetLength () + 1), sizeof (TCHAR));
		if (pTI->lpszText)
		{
			lstrcpy (pTI->lpszText, strText);
		}
	}

	return TRUE;
}
//***************************************************************************************
void CMainFrame::OnViewTextlabels() 
{
	m_wndToolBar.EnableTextLabels (!m_wndToolBar.AreTextLabels ());
}
//***************************************************************************************
void CMainFrame::OnUpdateViewTextlabels(CCmdUI* pCmdUI) 
{
	pCmdUI->SetCheck (m_bMainToolbarMenu && m_wndToolBar.AreTextLabels ());
	pCmdUI->Enable (m_bMainToolbarMenu);
}
//***************************************************************************************
BOOL CMainFrame::GetToolbarButtonToolTipText (CMFCToolBarButton* pButton, CString& strTTText)
{
	CLinkButton* pLinkBtn = NULL;

	ASSERT_VALID (pButton);

	if (pButton->m_nID == ID_LINK_1 &&
		(pLinkBtn = DYNAMIC_DOWNCAST (CLinkButton, pButton)) != NULL)
	{
		strTTText = pLinkBtn->GetURL ();
		return TRUE;
	}

	return FALSE;	// Default tooltip text
}
//********************************************************************************************
BOOL CMainFrame::LoadFrame(UINT nIDResource, DWORD dwDefaultStyle, CWnd* pParentWnd, CCreateContext* pContext) 
{
	if (!CFrameWnd::LoadFrame(nIDResource, dwDefaultStyle, pParentWnd, pContext))
	{
		return FALSE;
	}

	return TRUE;
}
//********************************************************************************************
void CMainFrame::OnViewExplorerbar() 
{
	ShowPane (&m_wndExplorerBar, (m_wndExplorerBar.GetStyle () & WS_VISIBLE) == 0, FALSE, TRUE);
}
//********************************************************************************************
void CMainFrame::OnUpdateViewExplorerbar(CCmdUI* pCmdUI) 
{
	pCmdUI->SetCheck (m_wndExplorerBar.IsWindowVisible ());
}
//********************************************************************************************
void CMainFrame::SetProgress (long nCurr, long nTotal)
{
	m_wndStatusBar.EnablePaneProgressBar (nStatusProgress, nTotal);

	if (nTotal >= 0)
	{
		m_wndStatusBar.SetPaneProgress (nStatusProgress, min (nTotal, max (0, nCurr)));
	}
	else
	{
		m_wndStatusBar.RedrawWindow ();
	}
}
//********************************************************************************************
void CMainFrame::OnLinkMSDN()
{
	((CIEDemoView*)GetActiveView())->Navigate2 (_T("http://www.msdn.com"), 0, NULL);
}
//********************************************************************************************
void CMainFrame::OnLinkMicrosoft()
{
	((CIEDemoView*)GetActiveView())->Navigate2 (_T("http://www.microsoft.com"), 0, NULL);
}
//********************************************************************************************
void CMainFrame::OnLinkVisualCPP()
{
	((CIEDemoView*)GetActiveView())->Navigate2 (_T("http://msdn2.microsoft.com/visualc/"), 0, NULL);
}
