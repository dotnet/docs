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
#include "FindComboBox.h"
#include "OptionsDlg.h"
#include "MainFrm.h"

#include "ChildFrm.h"
#include "UndoBar.h"

#ifdef _DEBUG
#define new DEBUG_NEW
#undef THIS_FILE
static char THIS_FILE[] = __FILE__;
#endif

/////////////////////////////////////////////////////////////////////////////
// CMainFrame

IMPLEMENT_DYNAMIC(CMainFrame, CMDIFrameWndEx)

const int  iMaxUserToolbars = 10;
const UINT uiFirstUserToolBarId = AFX_IDW_CONTROLBAR_FIRST + 40;
const UINT uiLastUserToolBarId = uiFirstUserToolBarId + iMaxUserToolbars - 1;

BEGIN_MESSAGE_MAP(CMainFrame, CMDIFrameWndEx)
	ON_WM_CREATE()
	ON_COMMAND(ID_WINDOW_MANAGER, OnWindowManager)
	ON_COMMAND(ID_HELP_KEYBOARDMAP, OnHelpKeyboardmap)
	ON_COMMAND(ID_FILE_NEW_PROJECT, OnFileNewProject)
	ON_COMMAND(ID_FILE_NEW_BLANK_SOLUTION, OnFileNewBlankSolution)
	ON_COMMAND(ID_FILE_OPEN_SOLUTION, OnFileOpenSolution)
	ON_COMMAND(ID_FILE_CLOSE_SOLUTION, OnFileCloseSolution)
	ON_COMMAND(ID_FILE_SAVE_ALL, OnFileSaveAll)
	ON_COMMAND(ID_VIEW_REFRESH, OnViewRefresh)
	ON_COMMAND(ID_TOOLS_CONNECT_TO_DATABASE, OnToolsConnectToDatabase)
	ON_COMMAND(ID_TOOLS_DEBUG_PROCESSES, OnToolsDebugProcesses)
	ON_COMMAND(ID_VIEW_FULLSCREEN, OnViewFullScreen)
	ON_COMMAND(ID_TOOLS_OPTIONS, OnToolsOptions)
	ON_COMMAND(ID_HELP_WEB, OnHelpWeb)
	ON_COMMAND(ID_MDI_MOVE_TO_NEXT_GROUP, OnMdiMoveToNextGroup)
	ON_COMMAND(ID_MDI_MOVE_TO_PREV_GROUP, OnMdiMoveToPrevGroup)
	ON_COMMAND(ID_MDI_NEW_HORZ_TAB_GROUP, OnMdiNewHorzTabGroup)
	ON_COMMAND(ID_MDI_NEW_VERT_GROUP, OnMdiNewVertGroup)
	ON_COMMAND(ID_MDI_CANCEL, OnMdiCancel)
	ON_WM_CLOSE()
	ON_COMMAND(ID_VIEW_CLASS, OnViewClass)
	ON_UPDATE_COMMAND_UI(ID_VIEW_CLASS, OnUpdateViewClass)
	ON_COMMAND(ID_VIEW_FILE, OnViewFile)
	ON_UPDATE_COMMAND_UI(ID_VIEW_FILE, OnUpdateViewFile)
	ON_COMMAND(ID_VIEW_RESOURCE, OnViewResource)
	ON_UPDATE_COMMAND_UI(ID_VIEW_RESOURCE, OnUpdateViewResource)
	ON_COMMAND(ID_VIEW_PROPERTIES, OnViewProperties)
	ON_UPDATE_COMMAND_UI(ID_VIEW_PROPERTIES, OnUpdateViewProperties)
	ON_COMMAND(ID_VIEW_OUTPUT, OnViewOutput)
	ON_UPDATE_COMMAND_UI(ID_VIEW_OUTPUT, OnUpdateViewOutput)
	ON_COMMAND(ID_VIEW_WATCH, OnViewWatch)
	ON_UPDATE_COMMAND_UI(ID_VIEW_WATCH, OnUpdateViewWatch)
	ON_COMMAND(ID_VIEW_DYNAMICHELP, OnViewDynamichelp)
	ON_UPDATE_COMMAND_UI(ID_VIEW_DYNAMICHELP, OnUpdateViewDynamichelp)
	ON_COMMAND(ID_MDI_TABBED_DOCUMENT, OnMdiTabbedDocument)
	ON_UPDATE_COMMAND_UI(ID_MDI_TABBED_DOCUMENT, OnUpdateMdiTabbedDocument)
	ON_COMMAND(ID_VIEW_CUSTOMIZE, OnViewCustomize)
	ON_REGISTERED_MESSAGE(AFX_WM_RESETTOOLBAR, OnToolbarReset)
	ON_REGISTERED_MESSAGE(AFX_WM_ON_GET_TAB_TOOLTIP, OnGetTabToolTip)
	ON_REGISTERED_MESSAGE(AFX_WM_CUSTOMIZEHELP, OnHelpCustomizeToolbars)
	ON_REGISTERED_MESSAGE(AFX_WM_CREATETOOLBAR, OnToolbarCreateNew)
	ON_WM_SYSCOLORCHANGE()
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

// <snippet13>
CMainFrame::CMainFrame()
{
	CMFCPopupMenu::SetForceShadow(TRUE);

	m_bCanConvertControlBarToMDIChild = TRUE;
}
// </snippet13>

CMainFrame::~CMainFrame()
{
}

int CMainFrame::OnCreate(LPCREATESTRUCT lpCreateStruct)
{
	if (CMDIFrameWndEx::OnCreate(lpCreateStruct) == -1)
		return -1;

	CMFCVisualManager::SetDefaultManager(RUNTIME_CLASS(CMFCVisualManagerVS2005));

	CMFCToolBarComboBoxButton::SetFlatMode();

	// Load toolbar user images:
	if (m_UserImages.Load(_T("UserImages.bmp")))
	{
		CMFCToolBar::SetUserImages(&m_UserImages);
	}

	CMFCToolBar::EnableQuickCustomization();

	// Create menu bar:
	if (!m_wndMenuBar.Create(this))
	{
		TRACE0("Failed to create menubar\n");
		return -1;      // fail to create
	}

	m_wndMenuBar.SetPaneStyle(m_wndMenuBar.GetPaneStyle() | CBRS_SIZE_DYNAMIC | CBRS_TOOLTIPS | CBRS_FLYBY);

	// Menu will not take the focus on activation:
	CMFCPopupMenu::SetForceMenuFocus(FALSE);

	// <snippet30>
	// Create Resource toolbar:
	// The this pointer points to CMainFrame class which extends the CMDIFrameWndEx class
	if (!m_wndToolbarResource.Create(this, WS_CHILD|CBRS_TOP|CBRS_TOOLTIPS|CBRS_FLYBY|CBRS_HIDE_INPLACE|CBRS_SIZE_DYNAMIC| CBRS_GRIPPER | CBRS_BORDER_3D, IDR_TOOLBAR_RESOURCE) || !m_wndToolbarResource.LoadToolBar(IDR_TOOLBAR_RESOURCE))
	{
		TRACE0("Failed to create build toolbar\n");
		return FALSE;      // fail to create
	}
	// </snippet30>

	// Create main toolbar:
	if (!m_wndToolBar.CreateEx(this, TBSTYLE_FLAT, WS_CHILD | WS_VISIBLE | CBRS_TOP | CBRS_GRIPPER | CBRS_TOOLTIPS | CBRS_FLYBY | CBRS_SIZE_DYNAMIC) || !m_wndToolBar.LoadToolBar(IDR_MAINFRAME))
	{
		TRACE0("Failed to create toolbar\n");
		return -1;      // fail to create
	}

	CString strMainToolbarTitle;
	strMainToolbarTitle.LoadString(IDS_MAIN_TOOLBAR);
	m_wndToolBar.SetWindowText(strMainToolbarTitle);

	// Create Build toolbar:
	if (!m_wndToolbarBuild.Create(this, WS_CHILD|WS_VISIBLE|CBRS_TOP|CBRS_TOOLTIPS|CBRS_FLYBY|CBRS_HIDE_INPLACE|CBRS_SIZE_DYNAMIC| CBRS_GRIPPER | CBRS_BORDER_3D, ID_VIEW_BUILD_TOOLBAR) || !m_wndToolbarBuild.LoadToolBar(IDR_BUILD))
	{
		TRACE0("Failed to create build toolbar\n");
		return FALSE;      // fail to create
	}

	CString strBuildToolbarTitle;
	strBuildToolbarTitle.LoadString(IDS_BUILD_TOOLBAR);
	m_wndToolbarBuild.SetWindowText(strBuildToolbarTitle);

	// Create Edit toolbar:
	if (!m_wndToolbarEdit.Create(this, WS_CHILD|WS_VISIBLE|CBRS_TOP|CBRS_TOOLTIPS|CBRS_FLYBY|CBRS_HIDE_INPLACE|CBRS_SIZE_DYNAMIC| CBRS_GRIPPER | CBRS_BORDER_3D, ID_VIEW_EDIT_TOOLBAR) || !m_wndToolbarEdit.LoadToolBar(IDR_EDIT))
	{
		TRACE0("Failed to create edit toolbar\n");
		return FALSE;      // fail to create
	}

	CString strEditToolbarTitle;
	strEditToolbarTitle.LoadString(IDS_EDIT_TOOLBAR);
	m_wndToolbarEdit.SetWindowText(strEditToolbarTitle);

	// Load menu items images(not placed on the standard toolbars):
	CMFCToolBar::AddToolBarForImageCollection(IDR_MENU_IMAGES);

	// Create status bar:
	if (!m_wndStatusBar.Create(this) || !m_wndStatusBar.SetIndicators(indicators, sizeof(indicators)/sizeof(UINT)))
	{
		TRACE0("Failed to create status bar\n");
		return -1;      // fail to create
	}

	m_wndStatusBar.SetPaneStyle(0, SBPS_STRETCH);

	// Create docking control windows:
	if (!CreateDockingBars())
	{
		return -1;
	}

	m_wndToolBar.EnableCustomizeButton(TRUE, ID_VIEW_CUSTOMIZE, _T("Customize..."));
	m_wndToolbarBuild.EnableCustomizeButton(TRUE, ID_VIEW_CUSTOMIZE, _T("Customize..."));
	m_wndToolbarEdit.EnableCustomizeButton(TRUE, ID_VIEW_CUSTOMIZE, _T("Customize..."));

	m_wndMenuBar.EnableDocking(CBRS_ALIGN_ANY);
	m_wndToolBar.EnableDocking(CBRS_ALIGN_ANY);
	m_wndToolbarBuild.EnableDocking(CBRS_ALIGN_ANY);
	m_wndToolbarEdit.EnableDocking(CBRS_ALIGN_ANY);
	m_wndToolbarResource.EnableDocking(CBRS_ALIGN_ANY);
	m_wndClassView.EnableDocking(CBRS_ALIGN_ANY);
	m_wndResourceView.EnableDocking(CBRS_ALIGN_ANY);
	m_wndFileView.EnableDocking(CBRS_ALIGN_ANY);
	m_wndOutputView.EnableDocking(CBRS_ALIGN_ANY);
	m_wndDynamicHelpView.EnableDocking(CBRS_ALIGN_ANY);
	m_wndPropertiesBar.EnableDocking(CBRS_ALIGN_ANY);

	m_wndWatchBar.EnableDocking(CBRS_ALIGN_ANY);

	// <snippet7>
	EnableDocking(CBRS_ALIGN_ANY);
	// </snippet7>

	// <snippet6>
	EnableAutoHidePanes(CBRS_ALIGN_ANY);
	// </snippet6>

	// <snippet4>
	DockPane(&m_wndMenuBar);
	DockPane(&m_wndToolBar);
	DockPane(&m_wndPropertiesBar);

	// <snippet5>
	DockPane(&m_wndToolbarBuild);
	// </snippet4>
	DockPaneLeftOf(&m_wndToolbarEdit, &m_wndToolbarBuild);
	// </snippet5>

	DockPane(&m_wndClassView);

	CDockablePane* pTabbedBar = NULL;
	m_wndResourceView.AttachToTabWnd(&m_wndClassView, DM_SHOW, TRUE, &pTabbedBar);
	m_wndFileView.AttachToTabWnd(pTabbedBar, DM_SHOW, TRUE, &pTabbedBar);

	DockPane(&m_wndOutputView);

	m_wndDynamicHelpView.DockToWindow(&m_wndPropertiesBar, CBRS_ALIGN_BOTTOM);
	m_wndWatchBar.DockToWindow(&m_wndOutputView, CBRS_ALIGN_LEFT);

	CRect rectMainToolBar;
	m_wndToolBar.GetWindowRect(&rectMainToolBar);

	// Allow user-defined toolbars operations:
	InitUserToolbars(NULL, uiFirstUserToolBarId, uiLastUserToolBarId);

	// <snippet10>
	// Enable windows manager:
	EnableWindowsDialog(ID_WINDOW_MANAGER, _T("Windows..."), TRUE);
	// </snippet10>

	// <snippet9>
	// Enable pane context menu(list of bars + customize command):
	EnablePaneMenu( TRUE, ID_VIEW_CUSTOMIZE, _T("Customize..."), ID_VIEW_TOOLBARS, FALSE, TRUE);
	// </snippet9>

	EnableFullScreenMode(ID_VIEW_FULLSCREEN);
	return 0;
}

/////////////////////////////////////////////////////////////////////////////
// CMainFrame diagnostics

#ifdef _DEBUG
void CMainFrame::AssertValid() const
{
	CMDIFrameWndEx::AssertValid();
}

void CMainFrame::Dump(CDumpContext& dc) const
{
	CMDIFrameWndEx::Dump(dc);
}

#endif //_DEBUG

/////////////////////////////////////////////////////////////////////////////
// CMainFrame message handlers

void CMainFrame::OnViewCustomize()
{
	// Create a customize toolbars dialog:
	CMFCToolBarsCustomizeDialog* pDlgCust = new CMFCToolBarsCustomizeDialog(this, TRUE /* Automatic menus scaning */, AFX_CUSTOMIZE_MENU_SHADOWS | AFX_CUSTOMIZE_TEXT_LABELS | AFX_CUSTOMIZE_MENU_ANIMATIONS);

	pDlgCust->EnableUserDefinedToolbars();

	// Setup combboxes:
	pDlgCust->ReplaceButton(ID_EDIT_FIND, CFindComboButton());

	CMFCToolBarComboBoxButton comboButtonConfig(ID_DUMMY_SELECT_ACTIVE_CONFIGURATION, GetCmdMgr()->GetCmdImage(ID_DUMMY_SELECT_ACTIVE_CONFIGURATION, FALSE), CBS_DROPDOWNLIST);
	comboButtonConfig.AddItem(_T("Win32 Debug"));
	comboButtonConfig.AddItem(_T("Win32 Release"));
	comboButtonConfig.SelectItem(0);

	// <snippet34>
	// CMFCToolBarsCustomizeDialog* pDlgCust
	// CMFCToolBarComboBoxButton comboButtonConfig
	pDlgCust->ReplaceButton(ID_DUMMY_SELECT_ACTIVE_CONFIGURATION, comboButtonConfig);
	// </snippet34>

	// <snippet31>
	// Add dropdown resources button
	// CMFCToolBarsCustomizeDialog* pDlgCust
	// CMFCDropDownToolBar m_wndToolbarResource
	pDlgCust->AddButton(_T("Build"), CMFCDropDownToolbarButton(_T("Add Resource"), &m_wndToolbarResource));
	// </snippet31>

	// Setup undo/redo buttons:
	pDlgCust->ReplaceButton(ID_EDIT_UNDO, CUndoButton(ID_EDIT_UNDO, _T("&Undo")));
	pDlgCust->ReplaceButton(ID_EDIT_REDO, CUndoButton(ID_EDIT_REDO, _T("&Redo")));

	pDlgCust->Create();
}

LRESULT CMainFrame::OnToolbarReset(WPARAM wp,LPARAM)
{
	UINT uiToolBarId = (UINT) wp;

	switch (uiToolBarId)
	{
	case IDR_MAINFRAME:
		{
			ASSERT(m_wndToolbarResource.GetSafeHwnd() != NULL);

			// Replace dropdown resources button:
			m_wndToolBar.ReplaceButton(ID_DUMMY_INSERT_RESOURCE, CMFCDropDownToolbarButton(_T("Add Resource"), &m_wndToolbarResource));

			// Replace "Find..." button by combobox:
			m_wndToolBar.ReplaceButton(ID_EDIT_FIND, CFindComboButton());

			// Replace "Undo" button by menubutton:
			m_wndToolBar.ReplaceButton(ID_EDIT_UNDO, CUndoButton(ID_EDIT_UNDO, _T("&Undo")));
			m_wndToolBar.ReplaceButton(ID_EDIT_REDO, CUndoButton(ID_EDIT_REDO, _T("&Redo")));
		}
		break;

	case IDR_BUILD:
		{
			// Replace "Confoguration..." button by combobox:
			CMFCToolBarComboBoxButton comboButton(ID_DUMMY_SELECT_ACTIVE_CONFIGURATION, GetCmdMgr()->GetCmdImage(ID_DUMMY_SELECT_ACTIVE_CONFIGURATION, FALSE), CBS_DROPDOWNLIST);
			comboButton.AddItem(_T("Win32 Debug"));
			comboButton.AddItem(_T("Win32 Release"));
			comboButton.SelectItem(0);

			m_wndToolbarBuild.ReplaceButton(ID_DUMMY_SELECT_ACTIVE_CONFIGURATION, comboButton);
		}
		break;
	}

	return 0;
}

LRESULT CMainFrame::OnHelpCustomizeToolbars(WPARAM /*wp*/, LPARAM /*lp*/)
{
	// int iPageNum = (int) wp;

	// CMFCToolBarsCustomizeDialog* pDlg = (CMFCToolBarsCustomizeDialog*) lp;
	// ASSERT_VALID(pDlg);

	// TODO: show help about page number iPageNum

	return 0;
}

// <snippet14>
BOOL CMainFrame::OnShowMDITabContextMenu(CPoint point, DWORD dwAllowedItems, BOOL bDrop)
{
	CMenu menu;
	VERIFY(menu.LoadMenu(bDrop ? IDR_POPUP_DROP_MDITABS : IDR_POPUP_MDITABS));

	CMenu* pPopup = menu.GetSubMenu(0);
	ASSERT(pPopup != NULL);

	if ((dwAllowedItems & AFX_MDI_CREATE_HORZ_GROUP) == 0)
	{
		pPopup->DeleteMenu(ID_MDI_NEW_HORZ_TAB_GROUP, MF_BYCOMMAND);
	}

	if ((dwAllowedItems & AFX_MDI_CREATE_VERT_GROUP) == 0)
	{
		pPopup->DeleteMenu(ID_MDI_NEW_VERT_GROUP, MF_BYCOMMAND);
	}

	if ((dwAllowedItems & AFX_MDI_CAN_MOVE_NEXT) == 0)
	{
		pPopup->DeleteMenu(ID_MDI_MOVE_TO_NEXT_GROUP, MF_BYCOMMAND);
	}

	if ((dwAllowedItems & AFX_MDI_CAN_MOVE_PREV) == 0)
	{
		pPopup->DeleteMenu(ID_MDI_MOVE_TO_PREV_GROUP, MF_BYCOMMAND);
	}

	if ((dwAllowedItems & AFX_MDI_CAN_BE_DOCKED) == 0)
	{
		pPopup->DeleteMenu(ID_MDI_TABBED_DOCUMENT, MF_BYCOMMAND);
	}

	CMFCPopupMenu* pPopupMenu = new CMFCPopupMenu;
	pPopupMenu->SetAutoDestroy(FALSE);
	pPopupMenu->Create(this, point.x, point.y, pPopup->GetSafeHmenu());

	return TRUE;
}
// </snippet14>

// <snippet18>
void CMainFrame::OnWindowManager()
{
	ShowWindowsDialog();
}
// </snippet18>

BOOL CMainFrame::LoadFrame(UINT nIDResource, DWORD dwDefaultStyle, CWnd* pParentWnd, CCreateContext* pContext)
{
	if (!CMDIFrameWndEx::LoadFrame(nIDResource, dwDefaultStyle, pParentWnd, pContext))
	{
		return FALSE;
	}

	// Add some tools for example....
	// <snippet38>
	CUserToolsManager* pUserToolsManager = theApp.GetUserToolsManager();
	if (pUserToolsManager != NULL && pUserToolsManager->GetUserTools().IsEmpty())
	{
		// <snippet35>
		// CUserToolsManager* pUserToolsManager
		CUserTool* pTool1 = pUserToolsManager->CreateNewTool();
		pTool1->m_strLabel = _T("&Notepad");
		pTool1->SetCommand(_T("notepad.exe"));
		// </snippet35>

		CUserTool* pTool2 = pUserToolsManager->CreateNewTool();
		pTool2->m_strLabel = _T("Paint &Brush");
		pTool2->SetCommand(_T("mspaint.exe"));

		CUserTool* pTool3 = pUserToolsManager->CreateNewTool();
		pTool3->m_strLabel = _T("&Windows Explorer");
		pTool3->SetCommand(_T("explorer.exe"));

		CUserTool* pTool4 = pUserToolsManager->CreateNewTool();
		pTool4->m_strLabel = _T("Microsoft On-&Line");
		pTool4->SetCommand(_T("http://www.microsoft.com"));
	}
	// </snippet38>

	CMDITabInfo mdiTabParams;
	mdiTabParams.m_bTabCustomTooltips = TRUE;

	EnableMDITabbedGroups(TRUE, mdiTabParams);

	// Enable customization button fore all user toolbars:
	for (int i = 0; i < iMaxUserToolbars; i ++)
	{
		CMFCToolBar* pUserToolbar = GetUserToolBarByIndex(i);
		if (pUserToolbar != NULL)
		{
			pUserToolbar->EnableCustomizeButton(TRUE, ID_VIEW_CUSTOMIZE, _T("Customize..."));
		}
	}

	return TRUE;
}

BOOL CMainFrame::OnCommand(WPARAM wParam, LPARAM lParam)
{
	// If control located on toolbar has focus, we should
	// redirect clipboard commands to this control:
	if (CFindComboButton::HasFocus() && HIWORD(wParam) == 1) // Command from accelerator
	{
		UINT uiCmd = LOWORD(wParam);
		switch (uiCmd)
		{
		case ID_EDIT_PASTE:
			::SendMessage(::GetFocus(), WM_PASTE, 0, 0);
			return TRUE;

		case ID_EDIT_COPY:
			::SendMessage(::GetFocus(), WM_COPY, 0, 0);
			return TRUE;

		case ID_EDIT_CUT:
			::SendMessage(::GetFocus(), WM_CUT, 0, 0);
			return TRUE;
		}
	}

	return CMDIFrameWndEx::OnCommand(wParam, lParam);
}

void CMainFrame::OnHelpKeyboardmap()
{
	// <snippet21>
	// this points to a CMainFrame class which extends the 
	// CMDIFrameWndEx class
	CMFCKeyMapDialog dlg(this, TRUE /* Enable Print */);
	// </snippet21>
	dlg.DoModal();
}

LRESULT CMainFrame::OnToolbarCreateNew(WPARAM wp,LPARAM lp)
{
	LRESULT lres = CMDIFrameWndEx::OnToolbarCreateNew(wp,lp);
	if (lres == 0)
	{
		return 0;
	}

	CMFCToolBar* pUserToolbar = (CMFCToolBar*) lres;
	ASSERT_VALID(pUserToolbar);

	pUserToolbar->EnableCustomizeButton(TRUE, ID_VIEW_CUSTOMIZE, _T("Customize..."));
	return lres;
}

BOOL CMainFrame::CreateDockingBars()
{
	// Crate class view:
	if (!m_wndClassView.Create(_T("Class View"), this, CRect(0, 0, 200, 200), TRUE, ID_VIEW_CLASS, WS_CHILD | WS_VISIBLE | WS_CLIPSIBLINGS | WS_CLIPCHILDREN | CBRS_LEFT | CBRS_FLOAT_MULTI))
	{
		TRACE0("Failed to create Class View bar\n");
		return FALSE;      // fail to create
	}

	// Create resource view:
	if (!m_wndResourceView.Create(_T("Resource View"), this, CRect(0, 0, 200, 200), TRUE, ID_VIEW_RESOURCE, WS_CHILD | WS_VISIBLE | WS_CLIPSIBLINGS | WS_CLIPCHILDREN | CBRS_LEFT | CBRS_FLOAT_MULTI))
	{
		TRACE0("Failed to create Resource View bar\n");
		return FALSE;      // fail to create
	}

	// Create file view:
	if (!m_wndFileView.Create(_T("Solution Explorer"), this, CRect(0, 0, 200, 200), TRUE, ID_VIEW_FILE, WS_CHILD | WS_VISIBLE | WS_CLIPSIBLINGS | WS_CLIPCHILDREN | CBRS_LEFT| CBRS_FLOAT_MULTI))
	{
		TRACE0("Failed to create Solution Explorer bar\n");
		return FALSE;      // fail to create
	}

	//////////////////////////////////New Output////////////////////////////////////////
	if (!m_wndOutputView.Create(_T("Output"), this, CRect(0, 0, 100, 100), TRUE, ID_VIEW_OUTPUT, WS_CHILD | WS_VISIBLE | WS_CLIPSIBLINGS | WS_CLIPCHILDREN | CBRS_BOTTOM | CBRS_FLOAT_MULTI))
	{
		TRACE0("Failed to create output bar\n");
		return FALSE;      // fail to create
	}

	if (!m_wndDynamicHelpView.Create(_T("Dynamic Help"), this, CRect(0, 0, 200, 200), TRUE, ID_VIEW_DYNAMICHELP, WS_CHILD | WS_VISIBLE | CBRS_RIGHT | CBRS_FLOAT_MULTI))
	{
		TRACE0("Failed to create Dynamic Help Bar\n");
		return FALSE; // fail to create
	}

	// Create watch bar:
	if (!m_wndWatchBar.Create(_T("Watch"), this, CRect(0, 0, 100, 100), TRUE, ID_VIEW_WATCH, WS_CHILD | WS_VISIBLE | WS_CLIPSIBLINGS | WS_CLIPCHILDREN | CBRS_BOTTOM | CBRS_FLOAT_MULTI))
	{
		TRACE0("Failed to create watch bar\n");
		return FALSE;      // fail to create
	}

	if (!m_wndPropertiesBar.Create(_T("Properties"), this, CRect(0, 0, 200, 200), TRUE, ID_VIEW_PROPERTIES, WS_CHILD | WS_VISIBLE | WS_CLIPSIBLINGS | WS_CLIPCHILDREN | CBRS_RIGHT | CBRS_FLOAT_MULTI))
	{
		TRACE0("Failed to create Properties Bar\n");
		return FALSE; // fail to create
	}

	SetDockingBarsIcons(FALSE);

	return TRUE;
}

void CMainFrame::SetDockingBarsIcons(BOOL bHiColorIcons)
{
	HICON hClassViewIcon = (HICON) ::LoadImage(::AfxGetResourceHandle(), MAKEINTRESOURCE(bHiColorIcons ? IDI_CLASS_VIEW_HC : IDI_CLASS_VIEW), IMAGE_ICON, ::GetSystemMetrics(SM_CXSMICON), ::GetSystemMetrics(SM_CYSMICON), 0);
	m_wndClassView.SetIcon(hClassViewIcon, FALSE);

	HICON hResViewIcon = (HICON) ::LoadImage(::AfxGetResourceHandle(), MAKEINTRESOURCE(bHiColorIcons ? IDI_RES_VIEW_HC : IDI_RES_VIEW), IMAGE_ICON, ::GetSystemMetrics(SM_CXSMICON), ::GetSystemMetrics(SM_CYSMICON), 0);
	m_wndResourceView.SetIcon(hResViewIcon, FALSE);

	HICON hFileViewIcon = (HICON) ::LoadImage(::AfxGetResourceHandle(), MAKEINTRESOURCE(bHiColorIcons ? IDI_FILE_VIEW_HC : IDI_FILE_VIEW), IMAGE_ICON, ::GetSystemMetrics(SM_CXSMICON), ::GetSystemMetrics(SM_CYSMICON), 0);
	m_wndFileView.SetIcon(hFileViewIcon, FALSE);

	HICON hOutputBarIcon = (HICON) ::LoadImage(::AfxGetResourceHandle(), MAKEINTRESOURCE(bHiColorIcons ? IDI_OUTPUT_BAR_HC : IDI_OUTPUT_BAR), IMAGE_ICON, ::GetSystemMetrics(SM_CXSMICON), ::GetSystemMetrics(SM_CYSMICON), 0);
	m_wndOutputView.SetIcon(hOutputBarIcon, FALSE);

	HICON hDynamicHelpIcon = (HICON) ::LoadImage(::AfxGetResourceHandle(), MAKEINTRESOURCE(bHiColorIcons ? IDI_DYNAMICHELP_VIEW_HC : IDI_DYNAMICHELP_VIEW), IMAGE_ICON, ::GetSystemMetrics(SM_CXSMICON), ::GetSystemMetrics(SM_CYSMICON), 0);
	m_wndDynamicHelpView.SetIcon(hDynamicHelpIcon, FALSE);

	HICON hWatchBarIcon = (HICON) ::LoadImage(::AfxGetResourceHandle(), MAKEINTRESOURCE(bHiColorIcons ? IDI_WATCH_BAR_HC : IDI_WATCH_BAR), IMAGE_ICON, ::GetSystemMetrics(SM_CXSMICON), ::GetSystemMetrics(SM_CYSMICON), 0);
	m_wndWatchBar.SetIcon(hWatchBarIcon, FALSE);

	HICON hPropertiesBarIcon = (HICON) ::LoadImage(::AfxGetResourceHandle(), MAKEINTRESOURCE(bHiColorIcons ? IDI_PROP_BAR_HC : IDI_PROPERTIES_BAR), IMAGE_ICON, ::GetSystemMetrics(SM_CXSMICON), ::GetSystemMetrics(SM_CYSMICON), 0);
	m_wndPropertiesBar.SetIcon(hPropertiesBarIcon, FALSE);

	UpdateMDITabbedBarsIcons();
}

void CMainFrame::OnFileNewProject()
{
	// TODO: Add your command handler code here
}

void CMainFrame::OnFileNewBlankSolution()
{
	// TODO: Add your command handler code here
}

void CMainFrame::OnFileOpenSolution()
{
	// TODO: Add your command handler code here
}

void CMainFrame::OnFileCloseSolution()
{
	// TODO: Add your command handler code here
}

void CMainFrame::OnFileSaveAll()
{
	// TODO: Add your command handler code here
}

void CMainFrame::OnViewRefresh()
{
	// TODO: Add your command handler code here
}

void CMainFrame::OnToolsConnectToDatabase()
{
	// TODO: Add your command handler code here
}

void CMainFrame::OnToolsDebugProcesses()
{
	// TODO: Add your command handler code here
}

void CMainFrame::OnViewFullScreen()
{
	ShowFullScreen();
}

CMFCToolBarComboBoxButton* CMainFrame::GetFindCombo()
{
	CMFCToolBarComboBoxButton* pFindCombo = NULL;

	CObList listButtons;
	if (CMFCToolBar::GetCommandButtons(ID_EDIT_FIND_COMBO, listButtons) > 0)
	{
		for (POSITION posCombo = listButtons.GetHeadPosition();
			pFindCombo == NULL && posCombo != NULL;)
		{
			// <snippet36>
			// CObList listButtons
			// POSITION posCombo
			CMFCToolBarComboBoxButton* pCombo = DYNAMIC_DOWNCAST(CMFCToolBarComboBoxButton, listButtons.GetNext(posCombo));
			// </snippet36>

			if (pCombo != NULL && pCombo->GetEditCtrl()->GetSafeHwnd() == ::GetFocus())
			{
				pFindCombo = pCombo;

				// <snippet37>
				pCombo->EnableWindow(true);
				pCombo->SetCenterVert();
				pCombo->SetDropDownHeight(25);
				pCombo->SetFlatMode();
				pCombo->SetText(_T("this is a combo box"));
				// </snippet37>
			}
		}
	}

	return pFindCombo;
}

void CMainFrame::OnToolsOptions()
{
	COptionsDlg dlgOptions(_T("Options"), this);
	dlgOptions.DoModal();
}

void CMainFrame::OnChangeLook(BOOL bOneNoteTabs, BOOL bMDITabColors, BOOL bIsVSDotNetLook, BOOL bDockTabColors, BOOL bMDITabsVS2005Look, BOOL bActiveTabCloseButton)
{
	// <snippet8>
	CMDITabInfo mdiTabParams;
	mdiTabParams.m_bTabCustomTooltips = TRUE;

	if (bMDITabsVS2005Look)
	{
		mdiTabParams.m_style = CMFCTabCtrl::STYLE_3D_VS2005;
		mdiTabParams.m_bDocumentMenu = TRUE;
	}
	else if (bOneNoteTabs)
	{
		mdiTabParams.m_style = CMFCTabCtrl::STYLE_3D_ONENOTE;
		mdiTabParams.m_bAutoColor = bMDITabColors;
	}

	if (bActiveTabCloseButton)
	{
		mdiTabParams.m_bTabCloseButton = FALSE;
		mdiTabParams.m_bActiveTabCloseButton = TRUE;
	}

	EnableMDITabbedGroups(TRUE, mdiTabParams);
	// </snippet8>

	m_wndPropertiesBar.SetVSDotNetLook(bIsVSDotNetLook);

	m_wndPropertiesBar.OnChangeVisualStyle();
	m_wndDynamicHelpView.OnChangeVisualStyle();
	m_wndClassView.OnChangeVisualStyle();
	m_wndFileView.OnChangeVisualStyle();
	m_wndResourceView.OnChangeVisualStyle();

	CTabbedPane::EnableTabAutoColor(bDockTabColors);

	// Reload toolbar images:
	CMFCToolBar::ResetAllImages();

	m_wndToolBar.LoadBitmap(theApp.m_bHiColorIcons ? IDB_TOOLBAR24 : IDR_MAINFRAME);
	m_wndToolbarBuild.LoadBitmap(theApp.m_bHiColorIcons ? IDB_BUILD24 : IDR_BUILD);
	m_wndToolbarEdit.LoadBitmap(theApp.m_bHiColorIcons ? IDB_EDIT24 : IDR_EDIT);

	CMFCToolBar::AddToolBarForImageCollection(IDR_MENU_IMAGES, theApp.m_bHiColorIcons ? IDB_MENUIMAGES24 : 0);
	SetDockingBarsIcons(theApp.m_bHiColorIcons);

	// <snippet24>
	CDockingManager* pDockManager = GetDockingManager();
	ASSERT_VALID(pDockManager);
	pDockManager->AdjustPaneFrames();
	pDockManager->EnableDockSiteMenu();
	pDockManager->SetDockingMode(DT_STANDARD);
    // </snippet24>

	RecalcLayout();
	RedrawWindow(NULL, NULL, RDW_ALLCHILDREN | RDW_INVALIDATE | RDW_UPDATENOW | RDW_ERASE);
}

void CMainFrame::OnHelpWeb()
{
	::ShellExecute(NULL, NULL, _T("http://www.microsoft.com"), NULL, NULL, NULL);
}

BOOL CMainFrame::PreCreateWindow(CREATESTRUCT& cs)
{
	return CMDIFrameWndEx::PreCreateWindow(cs);
}

BOOL CMainFrame::DestroyWindow()
{
	return CMDIFrameWndEx::DestroyWindow();
}

void CMainFrame::OnMdiMoveToNextGroup()
{
	MDITabMoveToNextGroup();
}

void CMainFrame::OnMdiMoveToPrevGroup()
{
	MDITabMoveToNextGroup(FALSE);
}

// <snippet12>
void CMainFrame::OnMdiNewHorzTabGroup()
{
	MDITabNewGroup(FALSE);
}
// </snippet12>

void CMainFrame::OnMdiNewVertGroup()
{
	MDITabNewGroup();
}

void CMainFrame::OnMdiCancel()
{
	// TODO: Add your command handler code here
}

// <snippet20>
CMDIChildWndEx* CMainFrame::CreateDocumentWindow(LPCTSTR lpcszDocName, CObject* /*pObj*/)
{
	if (lpcszDocName != NULL && lpcszDocName [0] != '\0')
	{
		CDocument* pDoc = NULL;
		if (g_strStartViewName.Compare(lpcszDocName) == 0)
		{
			pDoc = theApp.m_pStartDocTemplate->OpenDocumentFile(NULL);
		}
		else
		{
			pDoc = AfxGetApp()->OpenDocumentFile(lpcszDocName);
		}

		if (pDoc != NULL)
		{
			POSITION pos = pDoc->GetFirstViewPosition();

			if (pos != NULL)
			{
				CView* pView = pDoc->GetNextView(pos);
				return DYNAMIC_DOWNCAST(CMDIChildWndEx, pView->GetParent());
			}
		}

	}

	return NULL;
}
// </snippet20>

// <snippet15>
void CMainFrame::OnClose()
{
	SaveMDIState(theApp.GetRegSectionPath());
	CMDIFrameWndEx::OnClose();
}
// </snippet15>

LRESULT CMainFrame::OnGetTabToolTip(WPARAM /*wp*/, LPARAM lp)
{
	CMFCTabToolTipInfo* pInfo = (CMFCTabToolTipInfo*) lp;
	ASSERT(pInfo != NULL);
	ASSERT_VALID(pInfo->m_pTabWnd);

	if (!pInfo->m_pTabWnd->IsMDITab())
	{
		return 0;
	}

	CFrameWnd* pFrame = DYNAMIC_DOWNCAST(CFrameWnd, pInfo->m_pTabWnd->GetTabWnd(pInfo->m_nTabIndex));
	if (pFrame == NULL)
	{
		return 0;
	}

	CDocument* pDoc = pFrame->GetActiveDocument();
	if (pDoc == NULL)
	{
		return 0;
	}

	pInfo->m_strText = pDoc->GetPathName();
	return 0;
}

void CMainFrame::OnViewClass()
{
	m_wndClassView.ShowPane(!m_wndClassView.IsVisible(), FALSE, TRUE);
}

void CMainFrame::OnUpdateViewClass(CCmdUI* pCmdUI)
{
	pCmdUI->SetCheck(m_wndClassView.IsVisible());
}

void CMainFrame::OnViewFile()
{
	m_wndFileView.ShowPane(!m_wndFileView.IsVisible(), FALSE, TRUE);
}

void CMainFrame::OnUpdateViewFile(CCmdUI* pCmdUI)
{
	pCmdUI->SetCheck(m_wndFileView.IsVisible());
}

void CMainFrame::OnViewResource()
{
	m_wndResourceView.ShowPane(!m_wndResourceView.IsVisible(), FALSE, TRUE);
}

void CMainFrame::OnUpdateViewResource(CCmdUI* pCmdUI)
{
	pCmdUI->SetCheck(m_wndResourceView.IsVisible());
}

void CMainFrame::OnViewProperties()
{
	m_wndPropertiesBar.ShowPane(!m_wndPropertiesBar.IsVisible(), FALSE, TRUE);
}

void CMainFrame::OnUpdateViewProperties(CCmdUI* pCmdUI)
{
	pCmdUI->SetCheck(m_wndPropertiesBar.IsVisible());
}

void CMainFrame::OnViewOutput()
{
	m_wndOutputView.ShowPane(!m_wndOutputView.IsVisible(), FALSE, TRUE);
}

void CMainFrame::OnUpdateViewOutput(CCmdUI* pCmdUI)
{
	pCmdUI->SetCheck(m_wndOutputView.IsVisible());
}

void CMainFrame::OnViewWatch()
{
	m_wndWatchBar.ShowPane(!m_wndWatchBar.IsVisible(), FALSE, TRUE);
}

void CMainFrame::OnUpdateViewWatch(CCmdUI* pCmdUI)
{
	pCmdUI->SetCheck(m_wndWatchBar.IsVisible());
}

void CMainFrame::OnViewDynamichelp()
{
	m_wndDynamicHelpView.ShowPane(!m_wndDynamicHelpView.IsVisible(), FALSE, TRUE);
}

void CMainFrame::OnUpdateViewDynamichelp(CCmdUI* pCmdUI)
{
	pCmdUI->SetCheck(m_wndDynamicHelpView.IsVisible());
}

// <snippet19>
void CMainFrame::OnMdiTabbedDocument()
{
	CMDIChildWndEx* pMDIChild = DYNAMIC_DOWNCAST(CMDIChildWndEx, MDIGetActive());
	if (pMDIChild == NULL)
	{
		ASSERT(FALSE);
		return;
	}

	TabbedDocumentToControlBar(pMDIChild);
}
// </snippet19>

void CMainFrame::OnUpdateMdiTabbedDocument(CCmdUI* pCmdUI)
{
	pCmdUI->SetCheck();
}

void CMainFrame::OnSysColorChange() 
{
	BOOL bWasWindowRgn = m_Impl.HasRegion ();

	CMDIFrameWndEx::OnSysColorChange();

	m_Impl.OnChangeVisualManager ();

	if (bWasWindowRgn && ! m_Impl.HasRegion ())
	{
		SetWindowRgn (NULL, TRUE);
	}
}


