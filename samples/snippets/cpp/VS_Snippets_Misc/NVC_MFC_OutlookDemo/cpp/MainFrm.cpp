// This is a part of the Microsoft Foundation Classes C++ library.
// Copyright (c) Microsoft Corporation.  All rights reserved.
//
// This source code is only intended as a supplement to the
// Microsoft Foundation Classes Reference and related
// electronic documentation provided with the library.
// See these sources for detailed information regarding the
// Microsoft Foundation Classes product.

#include "stdafx.h"
#include "OutlookDemo.h"
#include "WorkspaceObj.h"
#include "FolderListPopupWnd.h"
#include "PreviewPane.h"
#include "MailFrame.h"

#include "MainFrm.h"

#ifdef _DEBUG
#define new DEBUG_NEW
#undef THIS_FILE
static char THIS_FILE[] = __FILE__;
#endif

BOOL CMyOutlookBar::AllowShowOnPaneMenu() const
{
	return m_bMode2003 == ((CMainFrame*)GetParent())->IsOutlookBar2003();
}

/////////////////////////////////////////////////////////////////////////////
// CMainFrame

IMPLEMENT_DYNCREATE(CMainFrame, CFrameWnd)

const int  iMaxUserToolbars = 10;
const UINT uiFirstUserToolBarId = AFX_IDW_CONTROLBAR_FIRST + 40;
const UINT uiLastUserToolBarId = uiFirstUserToolBarId + iMaxUserToolbars - 1;

BEGIN_MESSAGE_MAP(CMainFrame, CFrameWnd)
	ON_WM_CREATE()
	ON_WM_ACTIVATE()
	ON_COMMAND(ID_OUTLOOK_ADD_PAGE, OnOutlookAddPage)
	ON_COMMAND(ID_OUTLOOK_ANIMATION, OnOutlookAnimation)
	ON_COMMAND(ID_OUTLOOK_DELETE_PAGE, OnOutlookDeletePage)
	ON_COMMAND(ID_OUTLOOK_RENAME_PAGE, OnOutlookRenamePage)
	ON_COMMAND(ID_OUTLOOK_SHOW_TEXT_LABELS, OnOutlookShowTextLabels)
	ON_UPDATE_COMMAND_UI(ID_OUTLOOK_RENAME_PAGE, OnUpdateOutlookRenamePage)
	ON_UPDATE_COMMAND_UI(ID_OUTLOOK_DELETE_PAGE, OnUpdateOutlookDeletePage)
	ON_UPDATE_COMMAND_UI(ID_OUTLOOK_ANIMATION, OnUpdateOutlookAnimation)
	ON_UPDATE_COMMAND_UI(ID_OUTLOOK_SHOW_TEXT_LABELS, OnUpdateOutlookShowTextLabels)
	ON_COMMAND(ID_RESET_PAGE, OnResetPage)
	ON_UPDATE_COMMAND_UI(ID_RESET_PAGE, OnUpdateResetPage)
	ON_WM_CLOSE()
	ON_UPDATE_COMMAND_UI(ID_OUTLOOK_ADD_PAGE, OnUpdateOutlookAddPage)
	ON_WM_SETTINGCHANGE()
	ON_WM_ENABLE()
	ON_COMMAND(ID_VIEW_CAPTIONBAR, OnViewCaptionbar)
	ON_UPDATE_COMMAND_UI(ID_VIEW_CAPTIONBAR, OnUpdateViewCaptionbar)
	ON_COMMAND(ID_VIEW_FOLDER_LIST, OnViewFolderList)
	ON_UPDATE_COMMAND_UI(ID_VIEW_FOLDER_LIST, OnUpdateViewFolderList)
	ON_COMMAND(ID_VIEW_OUTLOOKBAR, OnViewOutlookbar)
	ON_UPDATE_COMMAND_UI(ID_VIEW_OUTLOOKBAR, OnUpdateViewOutlookbar)
	ON_COMMAND(ID_VIEW_CUSTOMIZE, OnViewCustomize)
	ON_REGISTERED_MESSAGE(AFX_WM_RESETTOOLBAR, OnToolbarReset)
	ON_REGISTERED_MESSAGE(AFX_WM_TOOLBARMENU, OnToolbarContextMenu)
	ON_REGISTERED_MESSAGE(AFX_WM_CREATETOOLBAR, OnToolbarCreateNew)
	ON_COMMAND_RANGE(ID_VIEW_GOTO_HOME, ID_VIEW_GOTO_FAVORITES, OnViewWorkSpace)
	ON_COMMAND(ID_VIEW_MY_COMPUTER, OnViewMyComputer)
	ON_COMMAND(ID_SHOW_FOLDERS_POPUP, OnViewFoldersPopup)
	ON_UPDATE_COMMAND_UI(ID_INDICATOR_ANIMATION, OnUpdateIndicatorSendReceive)
END_MESSAGE_MAP()

static UINT indicators[] =
{
	ID_SEPARATOR, // status line indicator
	ID_INDICATOR_ANIMATION, // status icon
	ID_INDICATOR_CAPS,
	ID_INDICATOR_NUM,
	ID_INDICATOR_SCRL,
};

/////////////////////////////////////////////////////////////////////////////
// CMainFrame construction/destruction

CMainFrame::CMainFrame() : m_wndFolderList(m_lstWorkspaces, m_ImagesSmall)
{
	m_uiHilightedPage = (UINT)-1;
	m_pCurrWorkSpace = NULL;
	m_pCurrOutlookWnd = NULL;
	m_pCurrOutlookPage = NULL;

	CMFCVisualManager::SetDefaultManager(RUNTIME_CLASS(CMFCVisualManagerOffice2003));
	CMFCOutlookBarTabCtrl::EnableAnimation(TRUE);

	m_bOutlookBar2003 = FALSE;
}

CMainFrame::~CMainFrame()
{
	while (!m_lstWorkspaces.IsEmpty())
	{
		delete m_lstWorkspaces.RemoveHead();
	}
}

int CMainFrame::OnCreate(LPCREATESTRUCT lpCreateStruct)
{
	CWindowDC dc(NULL);
	const BOOL bIsHiColor = dc.GetDeviceCaps(BITSPIXEL) > 16;

	if (CFrameWnd::OnCreate(lpCreateStruct) == -1)
		return -1;

	// Load toolbar user images:
	if (m_UserImages.Load(_T(".\\Userimages.bmp")))
	{
		CMFCToolBar::SetUserImages(&m_UserImages);
	}

	CMFCToolBar::EnableQuickCustomization();
	CMFCToolBarComboBoxButton::SetFlatMode();
	CMFCToolBar::AddToolBarForImageCollection(IDR_MENU_IMAGES);

	// Define basic commands. These commands will appear in
	// the menu by default:
	SetBasicCommands();

	// Create menu bar:
	if (!m_wndMenuBar.Create(this))
	{
		TRACE0("Failed to create menubar\n");
		return -1;      // fail to create
	}

	m_wndMenuBar.SetPaneStyle(m_wndMenuBar.GetPaneStyle() | CBRS_SIZE_DYNAMIC);

	// Create main toolbar:
	if (!m_wndToolBar.CreateEx(this, TBSTYLE_FLAT, WS_CHILD | WS_VISIBLE | CBRS_TOP | CBRS_GRIPPER | CBRS_TOOLTIPS | CBRS_FLYBY | CBRS_SIZE_DYNAMIC) ||
		!m_wndToolBar.LoadToolBar(IDR_MAINFRAME))
	{
		TRACE0("Failed to create toolbar\n");
		return -1;      // fail to create
	}

	BOOL bValidString;
	CString strMainToolbarTitle;
	bValidString = strMainToolbarTitle.LoadString(IDS_MAIN_TOOLBAR);
	m_wndToolBar.SetWindowText(strMainToolbarTitle);

	// Create advanced toolbar:
	if (!m_wndToolBarAdvanced.Create(this, WS_CHILD | WS_VISIBLE | CBRS_TOP | CBRS_GRIPPER | CBRS_TOOLTIPS | CBRS_FLYBY | CBRS_SIZE_DYNAMIC, ID_VIEW_ADVANCED_TOOLBAR) ||
		!m_wndToolBarAdvanced.LoadToolBar(IDR_ADVANCED))
	{
		TRACE0("Failed to create advanced toolbar\n");
		return -1;      // fail to create
	}

	CString strAdvToolbarTitle;
	bValidString = strAdvToolbarTitle.LoadString(IDS_ADV_TOOLBAR);
	m_wndToolBarAdvanced.SetWindowText(strAdvToolbarTitle);

	// Create Web toolbar:
	if (!m_wndToolBarWeb.Create(this, WS_CHILD | WS_VISIBLE | CBRS_TOP | CBRS_GRIPPER | CBRS_TOOLTIPS | CBRS_FLYBY | CBRS_SIZE_DYNAMIC, ID_VIEW_WEB_TOOLBAR) ||
		!m_wndToolBarWeb.LoadToolBar(IDR_WEB))
	{
		TRACE0("Failed to create web toolbar\n");
		return -1;      // fail to create
	}

	CString strWebToolbarTitle;
	bValidString = strWebToolbarTitle.LoadString(IDS_WEB_TOOLBAR);
	m_wndToolBarWeb.SetWindowText(strWebToolbarTitle);

	// Create status bar:
	if (!m_wndStatusBar.Create(this) || !m_wndStatusBar.SetIndicators(indicators, sizeof(indicators)/sizeof(UINT)))
	{
		TRACE0("Failed to create status bar\n");
		return -1;      // fail to create
	}

	CBitmap bmpAni;
	if (bmpAni.LoadBitmap(bIsHiColor ? IDB_ANIMATION_HC : IDB_ANIMATION))
	{
		m_imlStatusAnimation.Create(16, 16,
			(bIsHiColor ? ILC_COLOR8 : ILC_COLOR4) | ILC_MASK, 10, 0);
		m_imlStatusAnimation.Add(&bmpAni, RGB(255, 0, 255));
		m_wndStatusBar.SetPaneAnimation(1, m_imlStatusAnimation);
		m_wndStatusBar.SetPaneStyle(1, SBPS_NOBORDERS);
	}

	m_wndMenuBar.EnableDocking(CBRS_ALIGN_ANY);
	m_wndToolBar.EnableDocking(CBRS_ALIGN_ANY);
	m_wndToolBarAdvanced.EnableDocking(CBRS_ALIGN_ANY);
	m_wndToolBarWeb.EnableDocking(CBRS_ALIGN_ANY);

	// Outlook bar will be created at left, so temporary disable docking
	// at the left side:
	EnableDocking(CBRS_ALIGN_TOP | CBRS_ALIGN_BOTTOM | CBRS_ALIGN_RIGHT);

	m_wndBarOutlook2003.SetMode2003();

	// Create and setup "Outlook" shortcuts bar:
	if (!CreateOutlookBar( m_wndBarOutlook, ID_VIEW_OUTLOOKBAR, m_wndOutlookPane1, m_wndOutlookPane2, m_wndTree, m_wndCalendar, 100) ||
		!CreateOutlookBar(m_wndBarOutlook2003, ID_VIEW_OUTLOOKBAR2003, m_wndOutlookPane12003, m_wndOutlookPane22003, m_wndTree2003, m_wndCalendar2003, 200))
	{
		TRACE0("Failed to create outlook bar\n");
		return -1;      // fail to create
	}

	m_wndBarOutlook2003.SetButtonsFont(&afxGlobalData.fontBold);
	m_wndBarOutlook2003.ShowWindow(SW_HIDE);

	CImageList images;
	CBitmap bmp;
	if (!bmp.LoadBitmap(bIsHiColor ? IDB_OUTLOOK_SMALL_HC : IDB_OUTLOOK_SMALL))
	{
		return FALSE;
	}

	BITMAP bm;
	bmp.GetBitmap(&bm);

	UINT nFlags = ILC_MASK;

	if (bIsHiColor)
	{
		nFlags |= ILC_COLOR24;
	}
	else
	{
		nFlags |= ILC_COLOR;
	}

	m_ImagesSmall.Create(16, bm.bmHeight, nFlags, 0, 0);
	m_ImagesSmall.Add(&bmp, RGB(255, 0, 255));

	// Create a caption bar:
	if (!CreateCaptionBar())
	{
		TRACE0("Failed to create caption bar\n");
		return -1;      // fail to create
	}
	// Create folders list:
	if (!m_wndFolderList.Create(_T("Folder List"),this, CRect(0, 0, 200, 200), TRUE, ID_VIEW_FOLDER_LIST,
		WS_CHILD | WS_VISIBLE | CBRS_LEFT | CBRS_HIDE_INPLACE | WS_CAPTION, AFX_CBRS_OUTLOOK_TABS, AFX_CBRS_CLOSE | AFX_CBRS_RESIZE))
	{
		TRACE0("Failed to create folder list\n");
		return -1;      // fail to create
	}

	m_wndFolderList.EnableDocking(CBRS_ALIGN_LEFT);
	DockPane(&m_wndFolderList);

	// Outlook bar is created and docking on the left side
	// should be allowed.
	EnableDocking(CBRS_ALIGN_LEFT);
	EnableAutoHidePanes(CBRS_ALIGN_RIGHT);

	DockPane(&m_wndMenuBar);
	DockPane(&m_wndToolBar);
	DockPane(&m_wndToolBarAdvanced);
	DockPaneLeftOf(&m_wndToolBarWeb, &m_wndToolBarAdvanced);

	// Allow user-defined toolbars operations:
	InitUserToolbars(NULL, uiFirstUserToolBarId, uiLastUserToolBarId);

	// Enable customization button fore all toolbars:
	m_wndToolBar.EnableCustomizeButton(TRUE, ID_VIEW_CUSTOMIZE, IDS_CUSTOMIZE);
	m_wndToolBarAdvanced.EnableCustomizeButton(TRUE, ID_VIEW_CUSTOMIZE, IDS_CUSTOMIZE);
	m_wndToolBarWeb.EnableCustomizeButton(TRUE, ID_VIEW_CUSTOMIZE, IDS_CUSTOMIZE);

	SetWorkSpace((CWorkspaceObj*) m_lstWorkspaces.GetHead());

	// Enable conttol bar context menu(list of bars + customize command):
	EnablePaneMenu( TRUE, ID_VIEW_CUSTOMIZE, _T("Customize..."), ID_VIEW_TOOLBARS,
		FALSE /* all control bars on the context menu */, TRUE /* toolbars only on the "View" menu*/);
	return 0;
}

BOOL CMainFrame::PreCreateWindow(CREATESTRUCT& cs)
{
	if ( !CFrameWnd::PreCreateWindow(cs) )
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
	// Create a customize toolbars dialog:
	CMFCToolBarsCustomizeDialog* pDlgCust = new CMFCToolBarsCustomizeDialog(this, TRUE /* Automatic menus scaning */);

	pDlgCust->EnableUserDefinedToolbars();
	pDlgCust->Create();
}

LRESULT CMainFrame::OnToolbarContextMenu(WPARAM wp,LPARAM lp)
{
	CPoint point(AFX_GET_X_LPARAM(lp), AFX_GET_Y_LPARAM(lp));

	m_pCurrOutlookPage = DYNAMIC_DOWNCAST( CMFCOutlookBarPane, CWnd::FromHandlePermanent((HWND) wp));

	if (m_pCurrOutlookPage == NULL)
	{
		m_uiHilightedPage = (UINT)-1;
		return 1l; // Default menu
	}

	CMenu menu;
	VERIFY(menu.LoadMenu(m_bOutlookBar2003 ? IDR_POPUP_OLBAR2003 : IDR_POPUP_OLBAR));

	CMenu* pPopup = menu.GetSubMenu(0);
	ASSERT(pPopup != NULL);

	if (pPopup)
	{
		SetupToolbarMenu(*pPopup, ID_VIEW_USER_TOOLBAR1, ID_VIEW_USER_TOOLBAR10);

		CMFCPopupMenu* pPopupMenu = new CMFCPopupMenu;
		pPopupMenu->Create(this, point.x, point.y, pPopup->Detach());
	}

	m_uiHilightedPage = FindFocusedOutlookWnd(&m_pCurrOutlookWnd);
	return 0;
}

LRESULT CMainFrame::OnToolbarReset(WPARAM wp,LPARAM)
{
	UINT uiToolBarId = (UINT) wp;
	if (uiToolBarId == IDR_MAINFRAME)
	{
		// Replace new button by the menu
		CMenu menu;
		VERIFY(menu.LoadMenu(IDR_MAINFRAME));

		CMenu* pMenuFile = menu.GetSubMenu(0);
		VERIFY(pMenuFile != NULL);

		if (pMenuFile)
		{
			CMenu* pMenuNew = pMenuFile->GetSubMenu(0);
			VERIFY(pMenuNew != NULL);

			if (pMenuNew)
			{
				UINT uiNewCmdID = (m_pCurrWorkSpace == NULL) ? ID_NEW_MAIL : m_pCurrWorkSpace->m_uiDefaultNewAction;
				CMFCToolBarMenuButton btnNew(uiNewCmdID, pMenuNew->GetSafeHmenu(), GetCmdMgr()->GetCmdImage(uiNewCmdID));
				m_wndToolBar.ReplaceButton(ID_FILE_NEW, btnNew);
				m_wndToolBar.SetToolBarBtnText(m_wndToolBar.CommandToIndex(uiNewCmdID), _T("&New"));
			}
		}

		// Send/Receive appear with the text label:
		m_wndToolBar.SetToolBarBtnText(m_wndToolBar.CommandToIndex(ID_SEND_RECEIVE));

		// Replace Find Contact by combo:
		m_wndToolBar.ReplaceButton(ID_FIND_CONTACT, CMFCToolBarComboBoxButton(ID_FIND_CONTACT, GetCmdMgr()->GetCmdImage(ID_FIND_CONTACT), CBS_DROPDOWN));
	}
	else if (uiToolBarId == IDR_WEB)
	{
		CMenu menu;
		VERIFY(menu.LoadMenu(IDR_DUMMY));
		CMenu* pSubMenu = menu.GetSubMenu(0);

		CMFCToolBarMenuButton btnBack(ID_WEB_BACK, pSubMenu->GetSafeHmenu(), GetCmdMgr()->GetCmdImage(ID_WEB_BACK));
		m_wndToolBarWeb.ReplaceButton(ID_WEB_BACK, btnBack);

		m_wndToolBarWeb.ReplaceButton(ID_WEB_ADDRESS, CMFCToolBarComboBoxButton(ID_WEB_ADDRESS, GetCmdMgr()->GetCmdImage(ID_WEB_ADDRESS), CBS_DROPDOWN));
	}
	else if (uiToolBarId == IDR_ADVANCED)
	{
		CMenu menu;
		VERIFY(menu.LoadMenu(IDR_DUMMY));
		CMenu* pSubMenu = menu.GetSubMenu(0);

		CMFCToolBarMenuButton btnBack(ID_VIEW_BACK, pSubMenu->GetSafeHmenu(), GetCmdMgr()->GetCmdImage(ID_VIEW_BACK));
		m_wndToolBarAdvanced.ReplaceButton(ID_VIEW_BACK, btnBack);
	}

	return 0;
}

void CMainFrame::AddWorkSpace(const CString& strName, const int iIconIndex, const UINT uiCmd, CMFCOutlookBarPane& pane, const UINT uiNewCmdID, CImageList& images)
{
	pane.AddButton(images.ExtractIcon(iIconIndex), strName, uiCmd);

	BOOL bIsAlreadyExist = FALSE;
	for (POSITION pos = m_lstWorkspaces.GetHeadPosition(); pos != NULL;)
	{
		CWorkspaceObj* pWS = (CWorkspaceObj*) m_lstWorkspaces.GetNext(pos);
		ASSERT_VALID(pWS);

		if (pWS->m_uiCmd == uiCmd)
		{
			bIsAlreadyExist = TRUE;
			break;
		}
	}

	if (!bIsAlreadyExist)
	{
		m_lstWorkspaces.AddTail(new CWorkspaceObj(strName, uiCmd, iIconIndex, uiNewCmdID));
	}
}

BOOL CMainFrame::CreateOutlookBar(CMFCOutlookBar& bar, UINT uiID, CMFCOutlookBarPane& pane1, CMFCOutlookBarPane& pane2, CShellTreeCtrl& tree, CCalendarBar& calendar, int nInitialWidth)
{
	CWindowDC dc(NULL);
	const BOOL bIsHiColor = dc.GetDeviceCaps(BITSPIXEL) > 16;

	if (!bar.Create(_T("Shortcuts"), this, CRect(0, 0, nInitialWidth, 32000), uiID, WS_CHILD | WS_VISIBLE | CBRS_LEFT))
	{
		return FALSE; // fail to create
	}

	// <snippet1>
	// CMFCOutlookBar& bar
	CMFCOutlookBarTabCtrl* pOutlookBar = (CMFCOutlookBarTabCtrl*)bar.GetUnderlyingWindow();
	// </snippet1>

	if (pOutlookBar == NULL)
	{
		ASSERT(FALSE);
		return FALSE;
	}

	// <snippet2>
	pOutlookBar->EnableInPlaceEdit(TRUE);
	pOutlookBar->EnableAnimation();
	pOutlookBar->EnableScrollButtons();
	pOutlookBar->SetBorderSize(10);
	pOutlookBar->SetPageButtonTextAlign(TA_LEFT);
	// </snippet2>
	static UINT uiPageID = 1;

	DWORD dwPaneStyle = AFX_DEFAULT_TOOLBAR_STYLE | CBRS_FLOAT_MULTI;

	// can float, can autohide, can resize, CAN NOT CLOSE
	DWORD dwStyle = AFX_CBRS_FLOAT | AFX_CBRS_AUTOHIDE | AFX_CBRS_RESIZE;

	pane1.Create(&bar, dwPaneStyle, uiPageID++, dwStyle);
	pane1.SetOwner(this);
	pane1.EnableTextLabels();
	pane1.EnableDocking(CBRS_ALIGN_ANY);

	pane2.Create(&bar, dwPaneStyle, uiPageID++, dwStyle);
	pane2.SetOwner(this);
	pane2.EnableTextLabels();
	pane2.EnableDocking(CBRS_ALIGN_ANY);

	CImageList images;
	CBitmap bmp;
	if (!bmp.LoadBitmap(bIsHiColor ? IDB_OUTLOOK_LARGE_HC : IDB_OUTLOOK_LARGE))
	{
		return FALSE;
	}

	BITMAP bm;
	bmp.GetBitmap(&bm);

	UINT nFlags = ILC_MASK;

	if (bIsHiColor)
	{
		nFlags |= ILC_COLOR24;
	}
	else
	{
		nFlags |= ILC_COLOR;
	}

	images.Create(32, bm.bmHeight, nFlags, 0, 0);
	images.Add(&bmp, RGB(255, 0, 255));

	AddWorkSpace(_T("Home"), 0, ID_VIEW_GOTO_HOME, pane1, ID_NEW_MAIL, images);
	AddWorkSpace(_T("Calendar"), 1, ID_VIEW_GOTO_CALENDAR, pane1, ID_NEW_APPOINTMENT, images);
	AddWorkSpace(_T("Drafts"), 2, ID_VIEW_GOTO_DRAFTS, pane1, ID_NEW_MAIL, images);
	AddWorkSpace(_T("Inbox"), 3, ID_VIEW_GOTO_INBOX, pane1, ID_NEW_MAIL, images);
	AddWorkSpace(_T("Journal"), 4, ID_VIEW_GOTO_JOURNAL, pane1, ID_NEW_JOURNAL_ENTRY, images);
	AddWorkSpace(_T("Notes"), 5, ID_VIEW_GOTO_NOTES, pane1, ID_NEW_NOTE, images);
	AddWorkSpace(_T("Outbox"), 6, ID_VIEW_GOTO_OUTBOX, pane1, ID_NEW_MAIL, images);
	AddWorkSpace(_T("Sent Items"), 7, ID_VIEW_GOTO_SENTITEMS, pane1, ID_NEW_MAIL, images);
	AddWorkSpace(_T("Tasks"), 8, ID_VIEW_GOTO_TASKS, pane1, ID_NEW_TASK, images);

	// <snippet3>
	// CMFCOutlookBarTabCtrl* pOutlookBar
	// DWORD dwStyle = AFX_CBRS_FLOAT | AFX_CBRS_AUTOHIDE | AFX_CBRS_RESIZE
	// CMFCOutlookBarPane pane1
	// The third parameter is the image index.
	pOutlookBar->AddControl(&pane1, _T("General"), 0, TRUE, dwStyle);
	// </snippet3>
	pane1.EnableDocking(CBRS_ALIGN_ANY);
	pane1.SetDefaultState();

	AddWorkSpace(_T("My Computer"), 9, ID_VIEW_MY_COMPUTER, pane2, ID_NEW_SHORTCUT, images);
	AddWorkSpace(_T("Personal"), 10, ID_VIEW_GOTO_PERSONAL, pane2, ID_NEW_SHORTCUT, images);
	AddWorkSpace(_T("Favorites"), 10, ID_VIEW_GOTO_FAVORITES, pane2, ID_NEW_SHORTCUT, images);

	pOutlookBar->AddControl(&pane2, _T("Other Shortcuts"), 1, TRUE, dwStyle);
	pane2.EnableDocking(CBRS_ALIGN_ANY);
	pane2.SetDefaultState();

	CRect rectDummy(0, 0, 0, 0);
	const DWORD dwTreeStyle = WS_CHILD | WS_VISIBLE | TVS_HASLINES | TVS_LINESATROOT | TVS_HASBUTTONS;

	int nShift = (uiID == ID_VIEW_OUTLOOKBAR) ? 0 : 2; // we are going to create the same controls for two Outlook bars (regular and 2003), so we need this to prevent controls with the same ID

	tree.Create(dwTreeStyle, rectDummy, &bar, 1200 + nShift);
	pOutlookBar->AddControl(&tree, _T("Folders"), 2, TRUE, dwStyle);

	calendar.Create(rectDummy, &bar, 1201 + nShift);
	pOutlookBar->AddControl(&calendar, _T("Calendar"), 3, TRUE, dwStyle);

	bar.SetPaneStyle(bar.GetPaneStyle() | CBRS_TOOLTIPS | CBRS_FLYBY | CBRS_SIZE_DYNAMIC);
	bar.FillDefaultTabsOrderArray();

	BOOL bAnimation = theApp.GetInt(_T("OutlookAnimation"), TRUE);
	CMFCOutlookBarTabCtrl::EnableAnimation(bAnimation);

	return TRUE;
}

BOOL CMainFrame::CreateCaptionBar()
{
	if (!m_wndCaption.Create(WS_CHILD | WS_VISIBLE | WS_CLIPSIBLINGS, this, ID_VIEW_CAPTIONBAR, -1))
	{
		TRACE0("Failed to create caption bar\n");
		return FALSE;
	}

	m_wndCaption.SetFlatBorder();
	m_wndCaption.SetFont(&afxGlobalData.fontBold);

	return TRUE;
}

void CMainFrame::OnViewWorkSpace(UINT id)
{
	for (POSITION pos = m_lstWorkspaces.GetHeadPosition(); pos != NULL;)
	{
		CWorkspaceObj* pWS = (CWorkspaceObj*) m_lstWorkspaces.GetNext(pos);
		ASSERT_VALID(pWS);

		if (pWS->m_uiCmd == id)
		{
			SetWorkSpace(pWS);
		}
	}
}

void CMainFrame::OnViewMyComputer()
{
	OnViewWorkSpace(ID_VIEW_MY_COMPUTER);
}

void CMainFrame::SetWorkSpace(CWorkspaceObj* pWorkSpace)
{
	ASSERT_VALID(pWorkSpace);

	m_pCurrWorkSpace = pWorkSpace;

	m_wndCaption.SetIcon(m_ImagesSmall.ExtractIcon(m_pCurrWorkSpace->m_iIconIndex));
	m_wndCaption.SetButton(m_pCurrWorkSpace->m_strName, ID_SHOW_FOLDERS_POPUP);

	m_wndCaption.Invalidate();
	m_wndCaption.UpdateWindow();

	m_wndFolderList.SelectWorkspace(pWorkSpace);

}

void CMainFrame::OnViewFoldersPopup()
{
	// First, calculate popup window rectangle.
	// Top left corner need to be under the caption's button:
	CRect rectButton = m_wndCaption.GetButtonRect();
	m_wndCaption.ClientToScreen(&rectButton);

	// Width will be same as folder bar's width:
	CRect rectFolderBar;
	m_wndFolderList.GetWindowRect(&rectFolderBar);

	// Bottom will be near the main frame bottom:
	CRect rectStatusBar;
	m_wndStatusBar.GetWindowRect(rectStatusBar);

	CRect rectPopup(rectButton.left, rectButton.bottom, rectButton.left + rectFolderBar.Width(), rectStatusBar.bottom - 1);

	CFolderListPopupWnd* pFoldersPopup = new CFolderListPopupWnd(m_lstWorkspaces, m_ImagesSmall, m_pCurrWorkSpace);
	pFoldersPopup->Create(rectPopup);

	m_wndCaption.SetButtonPressed();
}

void CMainFrame::OnCloseFoldersPopup(BOOL bKeep)
{
	if (bKeep)
	{
		m_wndCaption.EnableButton(FALSE);
		ShowPane(&m_wndFolderList, TRUE, FALSE, TRUE);
	}

	m_wndCaption.SetButtonPressed(FALSE);
}

void CMainFrame::RecalcLayout(BOOL bNotify)
{
	CFrameWnd::RecalcLayout(bNotify);

	if (m_wndFolderList.GetSafeHwnd() != NULL)
	{
		m_wndCaption.EnableButton(!(m_wndFolderList.GetStyle() & WS_VISIBLE));
	}
}

void CMainFrame::AdjustDockingLayout(HDWP hdwp)
{
	CFrameWnd::AdjustDockingLayout(hdwp);
	if (m_wndFolderList.GetSafeHwnd() != NULL)
	{
		m_wndCaption.EnableButton(!(m_wndFolderList.GetStyle() & WS_VISIBLE));
	}
}

BOOL CMainFrame::OnCreateClient(LPCREATESTRUCT /*lpcs*/, CCreateContext* pContext)
{
	CRect rectClient;
	GetClientRect(rectClient);

	m_wndSplitter.CreateStatic(this, 2, 1);
	m_wndSplitter.CreateView(0, 0, pContext->m_pNewViewClass, CSize(0, rectClient.Height() / 2), pContext);
	m_wndSplitter.CreateView(1, 0, RUNTIME_CLASS(CPreviewPane), CSize(0, rectClient.Height() / 2), pContext);

	return TRUE;
}

void CMainFrame::SetBasicCommands()
{
	CList<UINT, UINT> lstBasicCommands;

	lstBasicCommands.AddTail(ID_VIEW_TOOLBARS);
	lstBasicCommands.AddTail(ID_FILE_NEW);
	lstBasicCommands.AddTail(ID_FILE_OPEN);
	lstBasicCommands.AddTail(ID_FILE_SAVE);
	lstBasicCommands.AddTail(ID_FILE_PRINT);
	lstBasicCommands.AddTail(ID_APP_EXIT);
	lstBasicCommands.AddTail(ID_EDIT_CUT);
	lstBasicCommands.AddTail(ID_EDIT_PASTE);
	lstBasicCommands.AddTail(ID_EDIT_UNDO);
	lstBasicCommands.AddTail(ID_APP_ABOUT);
	lstBasicCommands.AddTail(ID_VIEW_TOOLBAR);
	lstBasicCommands.AddTail(ID_VIEW_CUSTOMIZE);
	lstBasicCommands.AddTail(ID_VIEW_APP_LOOK);
	lstBasicCommands.AddTail(ID_NEW_MAIL);
	lstBasicCommands.AddTail(ID_NEW_FAX);
	lstBasicCommands.AddTail(ID_NEW_POST_FOLDER);
	lstBasicCommands.AddTail(ID_NEW_APPOINTMENT);
	lstBasicCommands.AddTail(ID_NEW_MEETING);
	lstBasicCommands.AddTail(ID_NEW_CONTRACT);
	lstBasicCommands.AddTail(ID_NEW_DISTRIBUTION_LIST);
	lstBasicCommands.AddTail(ID_NEW_TASK);
	lstBasicCommands.AddTail(ID_NEW_NOTE);
	lstBasicCommands.AddTail(ID_DUMMY);
	lstBasicCommands.AddTail(ID_VIEW_FOLDER_LIST);
	lstBasicCommands.AddTail(ID_MAIL_SEND);
	lstBasicCommands.AddTail(ID_MAIL_SAVE);
	lstBasicCommands.AddTail(ID_FILE_SAVE_AS);
	lstBasicCommands.AddTail(ID_MAIL_SAVE_ATTACHMENTS);
	lstBasicCommands.AddTail(ID_MAIL_SAVE_STATIONERY);
	lstBasicCommands.AddTail(ID_MAIL_DELETE);
	lstBasicCommands.AddTail(ID_MAIL_MOVE_TO_FOLDER);
	lstBasicCommands.AddTail(ID_FILE_PRINT_PREVIEW);
	lstBasicCommands.AddTail(ID_FILE_CLOSE);
	lstBasicCommands.AddTail(ID_MAIL_ATTACHMENT);
	lstBasicCommands.AddTail(ID_MAIL_ITEM);
	lstBasicCommands.AddTail(ID_MAIL_SIGNATURE);
	lstBasicCommands.AddTail(ID_MAIL_SPELL);
	lstBasicCommands.AddTail(ID_MAIL_CLOSE);
	lstBasicCommands.AddTail(ID_ADDRESS_BOOK);
	lstBasicCommands.AddTail(ID_VIEW_GOTO_HOME);
	lstBasicCommands.AddTail(ID_VIEW_GOTO_CALENDAR);
	lstBasicCommands.AddTail(ID_VIEW_GOTO_TASKS);
	lstBasicCommands.AddTail(ID_VIEW_GOTO_FAVORITES);

	CMFCToolBar::SetBasicCommands(lstBasicCommands);
}

void CMainFrame::OnActivate(UINT nState, CWnd* pWndOther, BOOL bMinimized)
{
	CFrameWnd::OnActivate(nState, pWndOther, bMinimized);

	if (nState != WA_INACTIVE)
	{
		theApp.SetActiveFrame(COutlookDemoApp::MainFrame);
		theApp.m_pMainWnd = this;
	}
}

BOOL CMainFrame::LoadFrame(UINT nIDResource, DWORD dwDefaultStyle, CWnd* pParentWnd, CCreateContext* pContext)
{
	if (!CFrameWnd::LoadFrame(nIDResource, dwDefaultStyle, pParentWnd, pContext))
	{
		return FALSE;
	}

	// Enable customization button fore all user toolbars:
	for (int i = 0; i < uiLastUserToolBarId - uiFirstUserToolBarId + 1; i++)
	{
		CMFCToolBar* pUserToolbar = GetUserToolBarByIndex(i);
		if (pUserToolbar != NULL)
		{
			pUserToolbar->EnableCustomizeButton(TRUE, ID_VIEW_CUSTOMIZE, IDS_CUSTOMIZE);
		}
	}

	return TRUE;
}

LRESULT CMainFrame::OnToolbarCreateNew(WPARAM wp,LPARAM lp)
{
	LRESULT lres = CFrameWndEx::OnToolbarCreateNew(wp,lp);
	if (lres == 0)
	{
		return 0;
	}

	CMFCToolBar* pUserToolbar = (CMFCToolBar*) lres;
	ASSERT_VALID(pUserToolbar);

	pUserToolbar->EnableCustomizeButton(TRUE, ID_VIEW_CUSTOMIZE, _T("Customize..."));
	pUserToolbar->AdjustLayout();
	return lres;
}

void CMainFrame::OnOutlookAddPage()
{
	CMFCOutlookBarTabCtrl* pOutlookBar = (CMFCOutlookBarTabCtrl*)m_wndBarOutlook.GetUnderlyingWindow();
	if (pOutlookBar == NULL)
	{
		return;
	}

	CMFCOutlookBarPane* pPane = m_wndBarOutlook.CreateCustomPage(_T("New Page"), TRUE, CBRS_ALIGN_ANY);

	if (pPane != NULL)
	{
		OnOutlookRenamePage();
	}
}

void CMainFrame::OnUpdateOutlookAddPage(CCmdUI* pCmdUI)
{
	pCmdUI->Enable(!m_bOutlookBar2003);
}

void CMainFrame::OnOutlookAnimation()
{
	CMFCOutlookBarTabCtrl::EnableAnimation(!CMFCOutlookBarTabCtrl::IsAnimation());
}

void CMainFrame::OnResetPage()
{
	if (m_pCurrOutlookPage == NULL)
	{
		ASSERT(FALSE);
		return;
	}

	ASSERT_VALID(m_pCurrOutlookPage);

	if (AfxMessageBox(IDP_REST_OUTLOOK_PAGE, MB_YESNO) == IDYES)
	{
		m_pCurrOutlookPage->RestoreOriginalstate();
	}
}

void CMainFrame::OnUpdateResetPage(CCmdUI* pCmdUI)
{
	pCmdUI->Enable(!m_bOutlookBar2003 && m_pCurrOutlookPage != NULL && m_pCurrOutlookPage->CanBeRestored());
}

void CMainFrame::OnOutlookDeletePage()
{
	if (m_pCurrOutlookWnd == NULL)
	{
		return;
	}

	UINT uiPage = m_pCurrOutlookWnd->GetActiveTab();

	CString strPageName = _T("");
	m_pCurrOutlookWnd->GetTabLabel(uiPage,strPageName);

	CString strMessage;
	strMessage.Format(_T("Remove page '%s'?"), strPageName);

	if (AfxMessageBox(strMessage, MB_YESNO) == IDYES)
	{
		m_wndBarOutlook.RemoveCustomPage(uiPage, m_pCurrOutlookWnd);
	}
}

void CMainFrame::OnOutlookRenamePage()
{
	if (m_pCurrOutlookWnd != NULL)
	{
		if (!m_pCurrOutlookWnd->IsInPlaceEdit())
		{
			m_pCurrOutlookWnd->EnableInPlaceEdit(TRUE);
		}
		m_pCurrOutlookWnd->StartRenameTab(m_pCurrOutlookWnd->GetActiveTab());
	}
}

void CMainFrame::OnOutlookShowTextLabels()
{
	m_wndOutlookPane1.EnableTextLabels(!m_wndOutlookPane1.AreTextLabels());
	m_wndOutlookPane12003.EnableTextLabels(!m_wndOutlookPane12003.AreTextLabels());
}

void CMainFrame::OnUpdateOutlookRenamePage(CCmdUI* pCmdUI)
{
	BOOL bEnable = (m_pCurrOutlookWnd != NULL) && ((UINT)m_uiHilightedPage != -1);
	pCmdUI->Enable(bEnable);
}

void CMainFrame::OnUpdateOutlookDeletePage(CCmdUI* pCmdUI)
{
	pCmdUI->Enable(!m_bOutlookBar2003 && m_uiHilightedPage != (UINT)-1);
}

void CMainFrame::OnUpdateOutlookAnimation(CCmdUI* pCmdUI)
{
	pCmdUI->SetCheck(CMFCOutlookBarTabCtrl::IsAnimation());
}

void CMainFrame::OnUpdateOutlookShowTextLabels(CCmdUI* pCmdUI)
{
	pCmdUI->SetCheck(m_wndOutlookPane1.AreTextLabels());
}

int CMainFrame::FindFocusedOutlookWnd(CMFCOutlookBarTabCtrl** ppOutlookWnd)
{
	ASSERT(ppOutlookWnd != NULL);

	if (!ppOutlookWnd)
	{
		return -1;
	}

	*ppOutlookWnd = NULL;
	// find the outlook from the current point
	CPoint pt;
	GetCursorPos(&pt);

	CWnd* pWndPoint = m_dockManager.PaneFromPoint(pt, 0);
	*ppOutlookWnd = FindOutlookParent(pWndPoint);

	CMFCOutlookBar& bar = m_bOutlookBar2003 ? m_wndBarOutlook2003 : m_wndBarOutlook;

	// find focused outlook
	if (*ppOutlookWnd != NULL)
	{
		CWnd* pWnd = GetFocus();

		if (pWnd == &bar)
		{
			*ppOutlookWnd = (CMFCOutlookBarTabCtrl*) bar.GetUnderlyingWindow();
		}
		else if (pWnd->IsKindOf(RUNTIME_CLASS(CMFCOutlookBar)))
		{
			*ppOutlookWnd = (CMFCOutlookBarTabCtrl*)((CMFCOutlookBar*)pWnd)->GetUnderlyingWindow();
		}
		else
		{
			CWnd* pParent = pWnd->GetParent();
			while (pParent != NULL)
			{
				if (pParent->IsKindOf(RUNTIME_CLASS(CMFCOutlookBar)))
				{
					*ppOutlookWnd = (CMFCOutlookBarTabCtrl*)((CMFCOutlookBar*)pParent)->GetUnderlyingWindow();
					break;
				}
				pParent = pParent->GetParent();
			}
		}
	}

	if (*ppOutlookWnd != NULL)
	{
		return(*ppOutlookWnd)->GetActiveTab();
	}

	return -1;
}

CMFCOutlookBarTabCtrl* CMainFrame::FindOutlookParent(CWnd* pWnd)
{
	if (pWnd == NULL)
	{
		return NULL;
	}

	if (pWnd->IsKindOf(RUNTIME_CLASS(CMFCOutlookBar)))
	{
		return(CMFCOutlookBarTabCtrl*)((CMFCOutlookBar*)pWnd)->GetUnderlyingWindow();
	}

	CWnd* pParent = pWnd->GetParent();
	while (pParent != NULL)
	{
		if (pParent->IsKindOf(RUNTIME_CLASS(CMFCOutlookBar)))
		{
			return(CMFCOutlookBarTabCtrl*)((CMFCOutlookBar*)pParent)->GetUnderlyingWindow();

		}
		pParent = pParent->GetParent();
	}
	return NULL;
}

void CMainFrame::OnClose()
{
	theApp.WriteInt(_T("OutlookAnimation"), CMFCOutlookBarTabCtrl::IsAnimation());
	CFrameWnd::OnClose();
}

void CMainFrame::OnUpdateIndicatorSendReceive(CCmdUI* pCmdUI)
{
	pCmdUI->Enable();
}

void CMainFrame::OnChangeLook(BOOL bOutlookBar2003)
{
	BOOL bIsLook2003 = CMFCVisualManager::GetInstance()->IsKindOf(RUNTIME_CLASS(CMFCVisualManagerOffice2003));

	CMFCOutlookBar& bar = m_bOutlookBar2003 ? m_wndBarOutlook2003 : m_wndBarOutlook;

	m_bOutlookBar2003 = bOutlookBar2003;

	if ((bar.GetStyle() & WS_VISIBLE) != 0)
	{
		if (m_bOutlookBar2003)
		{
			ShowPane(&m_wndBarOutlook2003, TRUE, FALSE, TRUE);
			ShowPane(&m_wndBarOutlook, FALSE, FALSE, TRUE);
		}
		else
		{
			ShowPane(&m_wndBarOutlook, TRUE, FALSE, TRUE);
			ShowPane(&m_wndBarOutlook2003, FALSE, FALSE, TRUE);
		}
	}

	// Reload toolbar images:
	CWindowDC dc(NULL);
	int nBitsPerPixel = dc.GetDeviceCaps(BITSPIXEL);

	BOOL bIsHiColor = bIsLook2003 && nBitsPerPixel > 16;

	CMFCToolBar::ResetAllImages();

	CMFCToolBar::AddToolBarForImageCollection(IDR_MENU_IMAGES, bIsHiColor ? IDB_MENU_IMAGE_HC : 0);

	m_wndToolBar.LoadBitmap(bIsHiColor ? IDB_TOOLBAR_HC : IDR_MAINFRAME);
	m_wndToolBarAdvanced.LoadBitmap(bIsHiColor ? IDB_ADVANCED_HC : IDR_ADVANCED);
	m_wndToolBarWeb.LoadBitmap(bIsHiColor ? IDB_WEB_HC : IDR_WEB);

	CMFCOutlookBarTabCtrl* pOutlookBar = (CMFCOutlookBarTabCtrl*)m_wndBarOutlook2003.GetUnderlyingWindow();

	if (pOutlookBar != NULL)
	{
		pOutlookBar->SetImageList(bIsHiColor ? IDB_PAGES_HC : IDB_PAGES, 24);
		pOutlookBar->SetToolbarImageList(bIsHiColor ? IDB_PAGES_SMALL_HC : IDB_PAGES_SMALL, 16);

		m_wndBarOutlook2003.RecalcLayout();
	}

	RedrawWindow(NULL, NULL, RDW_ALLCHILDREN | RDW_INVALIDATE | RDW_UPDATENOW | RDW_ERASE);

	CMailFrame::OnChangeLook();
}

void CMainFrame::OnSettingChange(UINT uFlags, LPCTSTR lpszSection)
{
	m_wndCaption.SetFont(NULL);

	CFrameWnd::OnSettingChange(uFlags, lpszSection);

	m_wndCaption.SetFont(&afxGlobalData.fontBold);
}

void CMainFrame::OnEnable( BOOL bEnable )
{
	CWnd* pWnd = GetNextWindow();
	while (pWnd != NULL)
	{
		if (pWnd->IsKindOf(RUNTIME_CLASS(CFrameWndEx)))
		{
			pWnd->EnableWindow(bEnable);
		}
		pWnd = pWnd->GetNextWindow();
	}
}

void CMainFrame::OnViewCaptionbar()
{
	ShowPane(&m_wndCaption, !(m_wndCaption.GetStyle() & WS_VISIBLE), FALSE, TRUE);
}

void CMainFrame::OnUpdateViewCaptionbar(CCmdUI* pCmdUI)
{
	pCmdUI->SetCheck(m_wndCaption.GetStyle() & WS_VISIBLE);
}

void CMainFrame::OnViewFolderList()
{
	ShowPane(&m_wndFolderList, !(m_wndFolderList.GetStyle() & WS_VISIBLE), FALSE, TRUE);
	RecalcLayout();
}

void CMainFrame::OnUpdateViewFolderList(CCmdUI* pCmdUI)
{
	pCmdUI->SetCheck(m_wndFolderList.GetStyle() & WS_VISIBLE);
}

void CMainFrame::OnViewOutlookbar()
{
	CMFCOutlookBar& bar = m_bOutlookBar2003 ? m_wndBarOutlook2003 : m_wndBarOutlook;

	ShowPane(&bar, !(bar.GetStyle() & WS_VISIBLE), FALSE, TRUE);
}

void CMainFrame::OnUpdateViewOutlookbar(CCmdUI* pCmdUI)
{
	CMFCOutlookBar& bar = m_bOutlookBar2003 ? m_wndBarOutlook2003 : m_wndBarOutlook;
	pCmdUI->SetCheck(bar.GetStyle() & WS_VISIBLE);
}
