//
// mainfrm.cpp : implementation of the CMainFrame class
//
// This is a part of the Microsoft Foundation Classes C++ library.
// Copyright (C) 1992-1998 Microsoft Corporation
// All rights reserved.
//
// This source code is only intended as a supplement to the
// Microsoft Foundation Classes Reference and related
// electronic documentation provided with the library.
// See these sources for detailed information regarding the
// Microsoft Foundation Classes product.

#include "stdafx.h"

#include "wordpad.h"
#include "mainfrm.h"
#include "wordpdoc.h"
#include "wordpvw.h"
#include "strings.h"

#ifdef _DEBUG
#undef THIS_FILE
static char BASED_CODE THIS_FILE[] = __FILE__;
#endif

const int  iMaxUserToolbars		= 10;

const UINT uiFirstUserToolBarId	= AFX_IDW_CONTROLBAR_FIRST + 40;
const UINT uiLastUserToolBarId	= uiFirstUserToolBarId + iMaxUserToolbars - 1;

/////////////////////////////////////////////////////////////////////////////
// CMainFrame

IMPLEMENT_DYNCREATE(CMainFrame, CFrameWndEx)

BEGIN_MESSAGE_MAP(CMainFrame, CFrameWndEx)
	//{{AFX_MSG_MAP(CMainFrame)
	ON_WM_CREATE()
	ON_WM_SYSCOLORCHANGE()
	ON_WM_SIZE()
	ON_WM_MOVE()
	ON_COMMAND(ID_HELP, OnHelpFinder)
	ON_WM_DROPFILES()
	ON_WM_FONTCHANGE()
	ON_WM_QUERYNEWPALETTE()
	ON_WM_PALETTECHANGED()
	ON_WM_DEVMODECHANGE()
	ON_COMMAND(ID_VIEW_CUSTOMIZE, OnViewCustomize)
	ON_COMMAND(ID_HELP_INDEX, OnHelpFinder)
	ON_COMMAND(ID_VIEW_FULL_SCREEN, OnViewFullScreen)
	//}}AFX_MSG_MAP
	// Global help commands
	ON_COMMAND(ID_CONTEXT_HELP, CFrameWndEx::OnContextHelp)
	ON_COMMAND(ID_DEFAULT_HELP, OnHelpFinder)
	ON_MESSAGE(WPM_BARSTATE, OnBarState)
	ON_REGISTERED_MESSAGE(CWordPadApp::m_nOpenMsg, OnOpenMsg)
	ON_REGISTERED_MESSAGE(AFX_WM_CUSTOMIZEHELP, OnHelpCustomizeToolbars)
	ON_REGISTERED_MESSAGE(AFX_WM_CUSTOMIZETOOLBAR, OnStartCustomize)
	ON_REGISTERED_MESSAGE(AFX_WM_CREATETOOLBAR, OnToolbarCreateNew)
	ON_REGISTERED_MESSAGE(AFX_WM_GETDOCUMENTCOLORS, OnGetDocumentColors)
	ON_COMMAND(ID_DUMMY, OnDummy)
	ON_COMMAND(ID_HELP_FIND, OnAskQuestion)
END_MESSAGE_MAP()

static UINT BASED_CODE indicators[] =
{
	ID_SEPARATOR,           // status line indicator
	ID_INDICATOR_CAPS,
	ID_INDICATOR_NUM,
};

/////////////////////////////////////////////////////////////////////////////
// CMainFrame construction/destruction

CMainFrame::CMainFrame()
{
	m_hIconDoc = theApp.LoadIcon(IDI_ICON_DOC);
	m_hIconText = theApp.LoadIcon(IDI_ICON_TEXT);
	m_hIconWrite = theApp.LoadIcon(IDI_ICON_WRITE);
}

CMainFrame::~CMainFrame()
{
}

BOOL CMainFrame::PreCreateWindow(CREATESTRUCT& cs)
{
	WNDCLASS wndcls;

	BOOL bRes = CFrameWndEx::PreCreateWindow(cs);
	HINSTANCE hInst = AfxGetInstanceHandle();

	// see if the class already exists
	if (!::GetClassInfo(hInst, szWordPadClass, &wndcls))
	{
		// get default stuff
		::GetClassInfo(hInst, cs.lpszClass, &wndcls);
		wndcls.style &= ~(CS_HREDRAW|CS_VREDRAW);
		// register a new class
		wndcls.lpszClassName = szWordPadClass;
		wndcls.hIcon = ::LoadIcon(hInst, MAKEINTRESOURCE(IDR_MAINFRAME));
		ASSERT(wndcls.hIcon != NULL);
		if (!AfxRegisterClass(&wndcls))
			AfxThrowResourceException();
	}
	cs.lpszClass = szWordPadClass;
	CRect rect = theApp.m_rectInitialFrame;
	if (rect.Width() > 0 && rect.Height() > 0)
	{
		// make sure window will be visible
		CDisplayIC dc;
		CRect rectDisplay(0, 0, dc.GetDeviceCaps(HORZRES),
			dc.GetDeviceCaps(VERTRES));
		if (rectDisplay.PtInRect(rect.TopLeft()) &&
			rectDisplay.PtInRect(rect.BottomRight()))
		{
			cs.x = rect.left;
			cs.y = rect.top;
			cs.cx = rect.Width();
			cs.cy = rect.Height();
		}
	}
	return bRes;
}

int CMainFrame::OnCreate(LPCREATESTRUCT lpCreateStruct)
{
	CMFCVisualManager::SetDefaultManager (RUNTIME_CLASS (CMFCVisualManagerOfficeXP));
	CMFCToolBarComboBoxButton::SetFlatMode ();
	CMFCToolBarComboBoxButton::SetCenterVert ();

	CMFCFontComboBox::m_bDrawUsingFont = TRUE;

	if (CFrameWndEx::OnCreate(lpCreateStruct) == -1)
		return -1;

	if (!CreateMenuBar())
		return -1;

	if (!CreateToolBar())
		return -1;

	if (!CreateFormatBar())
		return -1;

	if (!CreateStatusBar())
		return -1;

	EnableDocking(CBRS_ALIGN_ANY);

	if (!CreateTaskPane())
		return -1;

	if (!CreateRulerBar())
		return -1;

	CMFCToolBar::AddToolBarForImageCollection (IDR_TOOLBAR_IMAGES);
	CMFCToolBar::AddToolBarForImageCollection (IDR_BORDER_TYPE);
	
	CMFCToolBar::EnableQuickCustomization ();

	m_wndToolBar.EnableDocking(CBRS_ALIGN_ANY);
	m_wndMenuBar.EnableDocking(CBRS_ALIGN_ANY);
	m_wndFormatBar.EnableDocking(CBRS_ALIGN_ANY);
	m_wndTaskPane.EnableDocking(CBRS_ALIGN_RIGHT | CBRS_ALIGN_LEFT);

	DockPane(&m_wndMenuBar);
	DockPane(&m_wndToolBar);
	DockPane(&m_wndFormatBar);
	DockPane(&m_wndTaskPane);

	CWnd* pView = GetDlgItem(AFX_IDW_PANE_FIRST);
	if (pView != NULL)
	{
		pView->SetWindowPos(&wndBottom, 0, 0, 0, 0,
			SWP_NOSIZE|SWP_NOMOVE|SWP_NOACTIVATE);
	}

	//----------------------------------------
	// Allow user-defined toolbars operations:
	//----------------------------------------
	InitUserToolbars (NULL,
					uiFirstUserToolBarId,
					uiLastUserToolBarId);

	//--------------------
	// Set basic commands:
	//--------------------
	CList<UINT, UINT>	lstBasicCommands;
	lstBasicCommands.AddTail (ID_FILE_NEW);
	lstBasicCommands.AddTail (ID_FILE_OPEN);
	lstBasicCommands.AddTail (ID_FILE_SAVE);
	lstBasicCommands.AddTail (ID_FILE_PRINT);
	lstBasicCommands.AddTail (ID_APP_EXIT);
	lstBasicCommands.AddTail (ID_EDIT_UNDO);
	lstBasicCommands.AddTail (ID_EDIT_CUT);
	lstBasicCommands.AddTail (ID_EDIT_COPY);
	lstBasicCommands.AddTail (ID_EDIT_PASTE);
	lstBasicCommands.AddTail (ID_EDIT_SELECT_ALL);
	lstBasicCommands.AddTail (ID_EDIT_FIND);
	lstBasicCommands.AddTail (ID_EDIT_REPEAT);
	lstBasicCommands.AddTail (ID_EDIT_REPLACE);
	lstBasicCommands.AddTail (ID_OLE_EDIT_PROPERTIES);
	lstBasicCommands.AddTail (ID_VIEW_OPTIONS);
	lstBasicCommands.AddTail (ID_VIEW_CUSTOMIZE);
	lstBasicCommands.AddTail (ID_VIEW_APP_LOOK);
	lstBasicCommands.AddTail (ID_VIEW_FULL_SCREEN);
	lstBasicCommands.AddTail (ID_OLE_INSERT_NEW);
	lstBasicCommands.AddTail (ID_FORMAT_FONT);
	lstBasicCommands.AddTail (ID_INSERT_BULLET);
	lstBasicCommands.AddTail (ID_CHAR_COLOR);
	lstBasicCommands.AddTail (ID_HELP_INDEX);
	lstBasicCommands.AddTail (ID_APP_ABOUT);
	lstBasicCommands.AddTail (ID_PARA_LEFT);
	lstBasicCommands.AddTail (ID_VIEW_TOOLBARS);

	CMFCToolBar::SetBasicCommands (lstBasicCommands);

	//--------------------------------------------------------------------
	// Enable conttol bar context menu (list of bars + customize command):
	//--------------------------------------------------------------------
	EnablePaneMenu (	TRUE, ID_VIEW_CUSTOMIZE, 
							_T("Customize..."), ID_VIEW_TOOLBARS,
							FALSE, TRUE);

	EnableFullScreenMode (ID_VIEW_FULL_SCREEN);
	EnableFullScreenMainMenu (FALSE);

	return 0;
}

BOOL CMainFrame::CreateMenuBar()
{
	//----------------------------------------------
	// Create menu bar (replaces the standard menu):
	//----------------------------------------------
	if (!m_wndMenuBar.Create (this/*, WS_CHILD | WS_VISIBLE | CBRS_TOP, uiMenuBarId*/))
	{
		TRACE0("Failed to create menubar\n");
		return FALSE;
	}

	m_wndMenuBar.SetPaneStyle(m_wndMenuBar.GetPaneStyle() |
		CBRS_TOOLTIPS | CBRS_FLYBY | CBRS_SIZE_DYNAMIC | CBRS_GRIPPER | CBRS_BORDER_3D);

	m_wndMenuBar.EnableHelpCombobox (ID_HELP_FIND, _T("Type a question for help"));

	CString str;
	str.LoadString(IDS_TITLE_MENUBAR);
	m_wndMenuBar.SetWindowText(str);
	return TRUE;
}

BOOL CMainFrame::CreateToolBar()
{
	if (!m_wndToolBar.Create(this,
		WS_CHILD|WS_VISIBLE|CBRS_TOP|CBRS_TOOLTIPS|CBRS_FLYBY|CBRS_SIZE_DYNAMIC |
			CBRS_GRIPPER | CBRS_BORDER_3D)||
			!m_wndToolBar.LoadToolBar (IDR_MAINFRAME))
	{
		TRACE0("Failed to create toolbar\n");
		return FALSE;      // fail to create
	}

	CString str;
	str.LoadString(IDS_TITLE_TOOLBAR);
	m_wndToolBar.SetWindowText(str);

	m_wndToolBar.EnableCustomizeButton (TRUE, ID_VIEW_CUSTOMIZE, _T("Customize..."));
	return TRUE;
}

BOOL CMainFrame::CreateFormatBar()
{
	if (!m_wndFormatBar.Create(this,
		WS_CHILD|WS_VISIBLE|CBRS_TOP|CBRS_TOOLTIPS|CBRS_FLYBY|CBRS_HIDE_INPLACE|CBRS_SIZE_DYNAMIC|
		CBRS_GRIPPER | CBRS_BORDER_3D,
		ID_VIEW_FORMATBAR) ||
		!m_wndFormatBar.LoadToolBar (IDR_FORMATBAR))
	{
		TRACE0("Failed to create FormatBar\n");
		return FALSE;      // fail to create
	}

	CString str;
	str.LoadString(IDS_TITLE_FORMATBAR);
	m_wndFormatBar.SetWindowText(str);

	m_wndFormatBar.EnableCustomizeButton (TRUE, ID_VIEW_CUSTOMIZE, _T("Customize..."));
	return TRUE;
}

BOOL CMainFrame::CreateTaskPane ()
{
	CRect rectDummy(0, 0, 200, 400);
	if (!m_wndTaskPane.Create(_T("Tasks Pane"), this, rectDummy, TRUE, ID_VIEW_TASK_PANE,
		WS_CHILD | WS_VISIBLE | WS_CLIPSIBLINGS | WS_CLIPCHILDREN | CBRS_RIGHT | AFX_CBRS_CLOSE | AFX_CBRS_FLOAT))
	{
		TRACE0("Failed to create task pane\n");
		return FALSE;      // fail to create
	}

	m_wndTaskPane.EnableDocking (CBRS_ALIGN_RIGHT | CBRS_ALIGN_LEFT);
	DockPane(&m_wndTaskPane);

	return TRUE;
}

BOOL CMainFrame::CreateRulerBar()
{
	if (!m_wndRulerBar.Create(this,
		WS_CHILD|WS_VISIBLE|CBRS_TOP|CBRS_HIDE_INPLACE, ID_VIEW_RULER))
	{
		TRACE0("Failed to create ruler\n");
		return FALSE;      // fail to create
	}
	return TRUE;
}

BOOL CMainFrame::CreateStatusBar()
{
	if (!m_wndStatusBar.Create(this) ||
		!m_wndStatusBar.SetIndicators(indicators,
		  sizeof(indicators)/sizeof(UINT)))
	{
		TRACE0("Failed to create status bar\n");
		return FALSE;      // fail to create
	}
	return TRUE;
}

/////////////////////////////////////////////////////////////////////////////
// CMainFrame Operations

HICON CMainFrame::GetIcon(int nDocType)
{
	switch (nDocType)
	{
		case RD_WINWORD6:
		case RD_WORDPAD:
		case RD_EMBEDDED:
		case RD_RICHTEXT:
			return m_hIconDoc;
		case RD_TEXT:
		case RD_OEMTEXT:
			return m_hIconText;
		case RD_WRITE:
			return m_hIconWrite;
	}
	return m_hIconDoc;
}

/////////////////////////////////////////////////////////////////////////////
// CMainFrame diagnostics

#ifdef _DEBUG
void CMainFrame::AssertValid() const
{
	CFrameWndEx::AssertValid();
}

void CMainFrame::Dump(CDumpContext& dc) const
{
	CFrameWndEx::Dump(dc);
}

#endif //_DEBUG

/////////////////////////////////////////////////////////////////////////////
// CMainFrame message handlers

void CMainFrame::OnFontChange()
{
	m_wndFormatBar.SendMessage(CWordPadApp::m_nPrinterChangedMsg);
}

void CMainFrame::OnDevModeChange(LPTSTR lpDeviceName)
{
	theApp.NotifyPrinterChanged();
	CFrameWndEx::OnDevModeChange(lpDeviceName); //sends message to descendants
}

void CMainFrame::OnSysColorChange()
{
	CFrameWndEx::OnSysColorChange();
	OnChangeLook ();
}

void CMainFrame::ActivateFrame(int nCmdShow)
{
	CFrameWndEx::ActivateFrame(nCmdShow);
	// make sure and display the toolbar, ruler, etc while loading a document.
	OnIdleUpdateCmdUI(0, 0);
	UpdateWindow();
}

void CMainFrame::OnSize(UINT nType, int cx, int cy)
{
	CFrameWndEx::OnSize(nType, cx, cy);
	theApp.m_bMaximized = (nType == SIZE_MAXIMIZED);
	if (nType == SIZE_RESTORED)
		GetWindowRect(theApp.m_rectInitialFrame);
}

LRESULT CMainFrame::OnBarState(WPARAM wParam, LPARAM lParam)
{
	if (lParam == -1)
		return 0L;
	ASSERT(lParam != RD_EMBEDDED);
	if (wParam != 0)
	{
		if (IsTextType((int) lParam))
		{
			// in text mode hide the ruler and format bar so that it is the default
			// <snippet2>
			// This CMainFrame class extends the CFrameWndEx class.
			// GetPane is a method in the CFrameWndEx class which 
			// Returns a pointer to the pane that has the specified ID.
			CBasePane* pBar = GetPane(ID_VIEW_FORMATBAR);
			if (pBar != NULL)
			{
				// Set the docking mode, the pane alignment, and the pane style.
				pBar->SetDockingMode(DT_STANDARD);
				pBar->SetPaneAlignment(CBRS_ALIGN_LEFT);
				pBar->SetPaneStyle(pBar->GetCurrentAlignment() | CBRS_TOOLTIPS);
				pBar->ShowPane(TRUE, FALSE, FALSE);
			}
			// </snippet2>

			pBar = GetPane(ID_VIEW_RULER);
			if (pBar != NULL)
			{
				pBar->ShowPane(FALSE, FALSE, FALSE);
			}
		}
		HICON hIcon = GetIcon((int)lParam);
		SendMessage(WM_SETICON, TRUE, (LPARAM)hIcon);

	}
	return 0L;
}

void CMainFrame::OnMove(int x, int y)
{
	CFrameWndEx::OnMove(x, y);
	WINDOWPLACEMENT wp;
	wp.length = sizeof(wp);
	GetWindowPlacement(&wp);
	theApp.m_rectInitialFrame = wp.rcNormalPosition;
	CView* pView = GetActiveView();
	if (pView != NULL)
		pView->SendMessage(WM_MOVE);
}

LRESULT CMainFrame::OnOpenMsg(WPARAM, LPARAM lParam)
{
	TCHAR szAtomName[256];
	szAtomName[0] = NULL;
	GlobalGetAtomName((ATOM)lParam, szAtomName, 256);
	CWordPadDoc* pDoc = (CWordPadDoc*)GetActiveDocument();
	if (szAtomName[0] != NULL && pDoc != NULL)
	{
		if (lstrcmpi(szAtomName, pDoc->GetPathName()) == 0)
			return TRUE;
	}
	return FALSE;
}

void CMainFrame::OnHelpFinder()
{
	theApp.WinHelp(0, HELP_FINDER);
}

void CMainFrame::OnDropFiles(HDROP hDropInfo)
{
	TCHAR szFileName[_MAX_PATH];
	::DragQueryFile(hDropInfo, 0, szFileName, _MAX_PATH);
	::DragFinish(hDropInfo);
	theApp.OpenDocumentFile(szFileName);
}

BOOL CMainFrame::OnQueryNewPalette()
{
	CView* pView = GetActiveView();
	if (pView != NULL)
		return (BOOL) pView->SendMessage(WM_QUERYNEWPALETTE);
	return FALSE;
}

void CMainFrame::OnPaletteChanged(CWnd* pFocusWnd)
{
	CView* pView = GetActiveView();
	if (pView != NULL)
		pView->SendMessage(WM_PALETTECHANGED, (WPARAM)pFocusWnd->GetSafeHwnd());
}

void CMainFrame::OnViewCustomize() 
{
	CWordPadView* pView = DYNAMIC_DOWNCAST (CWordPadView, GetActiveView());
	if (pView != NULL && pView->GetInPlaceActiveItem () != NULL)
	{
		return;
	}

	//------------------------------------
	// Create a customize toolbars dialog:
	//------------------------------------
	// <snippet11>
	CMFCToolBarsCustomizeDialog* pDlgCust = new CMFCToolBarsCustomizeDialog (this,
		TRUE /* Automatic menus scaning */,
		AFX_CUSTOMIZE_MENU_SHADOWS | AFX_CUSTOMIZE_TEXT_LABELS | 
		AFX_CUSTOMIZE_MENU_ANIMATIONS);

	pDlgCust->AddToolBar (_T("Format"), IDR_FORMATBAR);
	// </snippet11>

	CMFCToolBarFontComboBox* pFontButton = m_wndFormatBar.CreateFontComboButton ();
	pDlgCust->ReplaceButton (IDC_FONTNAME, *pFontButton);
	delete pFontButton;

	CMFCToolBarFontSizeComboBox comboButtonFontSize (IDC_FONTSIZE, 
		GetCmdMgr ()->GetCmdImage (IDC_FONTSIZE, FALSE),
		WS_TABSTOP|WS_VISIBLE|WS_TABSTOP|WS_VSCROLL|CBS_DROPDOWN,
		10*m_wndFormatBar.m_szBaseUnits.cx + 10);
	pDlgCust->ReplaceButton (IDC_FONTSIZE, comboButtonFontSize);

	CMFCColorMenuButton* pColorButton = m_wndFormatBar.CreateColorButton ();
	pDlgCust->ReplaceButton (ID_CHAR_COLOR, *pColorButton);
	delete pColorButton;

	CMFCToolBarMenuButton* pBorderTypeButton = m_wndFormatBar.CreateBorderTypeButton ();
	pDlgCust->ReplaceButton (ID_BORDER_1, *pBorderTypeButton);
	delete pBorderTypeButton;

	pDlgCust->EnableUserDefinedToolbars ();
	pDlgCust->Create ();
}

// <snippet4>
BOOL CMainFrame::OnShowPopupMenu (CMFCPopupMenu* pMenuPopup)
{
	BOOL bRes = CFrameWndEx::OnShowPopupMenu (pMenuPopup);

	if (pMenuPopup != NULL && !pMenuPopup->IsCustomizePane())
	{
		AdjustObjectSubmenu (pMenuPopup);
		AdjustColorsMenu (pMenuPopup, ID_CHAR_COLOR);
	}

	return bRes;
}
// </snippet4>

void CMainFrame::AdjustObjectSubmenu (CMFCPopupMenu* pMenuPopup)
{
	ASSERT (pMenuPopup != NULL);

	if (pMenuPopup->GetParentPopupMenu () != NULL)
	{
		return;
	}

	CMFCPopupMenuBar* pMenuBar = pMenuPopup->GetMenuBar ();
	ASSERT (pMenuBar != NULL);

	int iIndex = pMenuBar->CommandToIndex (ID_OLE_VERB_POPUP);
	if (iIndex < 0)
	{
		return;
	}

	CWordPadDoc* pDoc = (CWordPadDoc*)GetActiveDocument();
	ASSERT_VALID (pDoc);

	// check for single selection
	COleClientItem* pItem = pDoc->GetPrimarySelectedItem(GetActiveView());
	if (pItem == NULL || pItem->GetType() == OT_STATIC)
	{
		// no selection, or is 'static' item
		return;
	}

	// only include Convert... if there is a handler for ID_OLE_EDIT_CONVERT
	UINT nConvertID = ID_OLE_EDIT_CONVERT;
	AFX_CMDHANDLERINFO info;
	if (!pDoc->OnCmdMsg(ID_OLE_EDIT_CONVERT, CN_COMMAND, NULL, &info))
		nConvertID = 0;

	HMENU hMenu = pMenuBar->ExportToMenu ();
	ASSERT(hMenu != NULL);

	// update the menu
	AfxOleSetEditMenu(pItem,
		CMenu::FromHandle (hMenu), iIndex,
		ID_OLE_VERB_FIRST, ID_OLE_VERB_LAST, nConvertID);

	pMenuBar->ImportFromMenu (hMenu);
	::DestroyMenu (hMenu);
}

void CMainFrame::AdjustColorsMenu (CMFCPopupMenu* pMenuPopup, UINT uiID)
{
	CMFCPopupMenuBar* pMenuBar = pMenuPopup->GetMenuBar ();
	ASSERT (pMenuBar != NULL);

	int iIndex = pMenuBar->CommandToIndex (uiID);
	if (iIndex < 0)
	{
		return;
	}

	if (DYNAMIC_DOWNCAST (CMFCColorMenuButton, pMenuBar->GetButton (iIndex)) != NULL)
	{
		return;
	}

	CMFCColorMenuButton* pColorButton = m_wndFormatBar.CreateColorButton ();
	pMenuBar->ReplaceButton (ID_CHAR_COLOR, *pColorButton, TRUE);
	delete pColorButton;
}
//**********************************************************************************
LRESULT CMainFrame::OnHelpCustomizeToolbars(WPARAM wp, LPARAM /*lp*/)
{
	int iPageNum = (int) wp;

	// Test!
	CString str;
	str.Format (_T("Help about page number %d"), iPageNum);

	MessageBox (str);

	return 0;
}
//***************************************************************************************
LRESULT CMainFrame::OnStartCustomize(WPARAM, LPARAM)
{
	CWordPadView* pView = DYNAMIC_DOWNCAST (CWordPadView, GetActiveView());
	if (pView == NULL)
	{
		return 0;
	}

	pView->GetRichEditCtrl().SetSel (-1, 0);
	return 0;
}
//***************************************************************************************
LRESULT CMainFrame::OnToolbarCreateNew(WPARAM wp,LPARAM lp)
{
	LRESULT lres = CFrameWndEx::OnToolbarCreateNew (wp,lp);
	if (lres == 0)
	{
		return 0;
	}

	CMFCToolBar* pUserToolbar = (CMFCToolBar*) lres;
	ASSERT_VALID (pUserToolbar);

	pUserToolbar->EnableCustomizeButton (TRUE, ID_VIEW_CUSTOMIZE, _T("Customize..."));
	pUserToolbar->AdjustLayout ();
	return lres;
}
//*******************************************************************************
BOOL CMainFrame::OnCommand(WPARAM wParam, LPARAM lParam) 
{
	//----------------------------------------------------
	// If Font/Size combobox has focus, we should redirect 
	// clipboard commands to its editbox:
	//----------------------------------------------------
	if (HIWORD (wParam) == 1)	// Command from accelerator
	{
		if (CMFCToolBarComboBoxButton::GetByCmd (IDC_FONTNAME, TRUE) != NULL ||
			CMFCToolBarComboBoxButton::GetByCmd (IDC_FONTSIZE, TRUE) != NULL)
		{
			// Either font combox or size combo are focused
			UINT uiCmd = LOWORD (wParam);
			switch (uiCmd)
			{
			case ID_EDIT_PASTE:
				::SendMessage (::GetFocus (), WM_PASTE, 0, 0);
				return TRUE;

			case ID_EDIT_COPY:
				::SendMessage (::GetFocus (), WM_COPY, 0, 0);
				return TRUE;

			case ID_EDIT_CUT:
				::SendMessage (::GetFocus (), WM_CUT, 0, 0);
				return TRUE;
			}
		}
	}

	return CFrameWndEx::OnCommand(wParam, lParam);
}
//*************************************************************************************
LRESULT CMainFrame::OnGetDocumentColors(WPARAM, LPARAM lp)
{
	CList<COLORREF,COLORREF>* pLstDocColors =
		(CList<COLORREF,COLORREF>*) lp;
	ASSERT_VALID (pLstDocColors);

	CWordPadView* pView = DYNAMIC_DOWNCAST (CWordPadView, GetActiveView());
	if (pView != NULL)
	{
		pView->GetDocumentColors (*pLstDocColors);
	}

	return 0;
}
//*************************************************************************************
BOOL CMainFrame::OnTearOffMenu (CMFCPopupMenu* /*pMenuPopup*/, CPane* pBar)
{
	CMFCColorBar* pColorBar = DYNAMIC_DOWNCAST (CMFCColorBar, pBar);
	if (pColorBar != NULL)
	{
		CWordPadView* pView = DYNAMIC_DOWNCAST (CWordPadView, GetActiveView());
		if (pView != NULL)
		{
			CList<COLORREF,COLORREF> lstDocColors;
			pView->GetDocumentColors (lstDocColors);

			pColorBar->SetDocumentColors (_T("Document's Colors"), lstDocColors);
		}
	}

	return TRUE;
}
//**************************************************************************************
BOOL CMainFrame::LoadFrame(UINT nIDResource, DWORD dwDefaultStyle, CWnd* pParentWnd, CCreateContext* pContext) 
{
	if (!CFrameWndEx::LoadFrame(nIDResource, dwDefaultStyle, pParentWnd, pContext))
	{
		return FALSE;
	}

	//----------------------------------------------------
	// Enable customization button fore all user toolbars:
	//----------------------------------------------------
	for (int i = 0; i < iMaxUserToolbars; i ++)
	{
		CMFCToolBar* pUserToolbar = GetUserToolBarByIndex (i);
		if (pUserToolbar != NULL)
		{
			pUserToolbar->EnableCustomizeButton (TRUE, ID_VIEW_CUSTOMIZE, _T("Customize..."));
		}
	}

	return TRUE;
}

void CMainFrame::OnChangeLook ()
{
	BOOL bIsLook2003 = CMFCVisualManager::GetInstance ()->IsKindOf (
		RUNTIME_CLASS (CMFCVisualManagerOffice2003));

	m_wndRulerBar.CreateGDIObjects ();
	m_wndRulerBar.RedrawWindow ();

	CWindowDC dc (NULL);
	int nBitsPerPixel = dc.GetDeviceCaps (BITSPIXEL);

	m_wndTaskPane.UpdateIcons ();
	m_wndTaskPane.EnableNavigationToolbar (bIsLook2003,
		theApp.m_bHiColorIcons && nBitsPerPixel > 16 ? IDB_TASKSPANE_TOOLBAR : 0, CSize (16, 16));
	m_wndTaskPane.RecalcLayout (FALSE);

	//-----------------------
	// Reload toolbar images:
	//-----------------------
	CMFCToolBar::ResetAllImages ();

	m_wndToolBar.LoadBitmap (
		theApp.m_bHiColorIcons && nBitsPerPixel > 16 ? IDB_MAINFRAME_HC : IDR_MAINFRAME);

	m_wndFormatBar.LoadBitmap (IDR_FORMATBAR);

	CMFCToolBar::AddToolBarForImageCollection (IDR_TOOLBAR_IMAGES, 
		theApp.m_bHiColorIcons && nBitsPerPixel > 16 ? IDR_TOOLBAR_IMAGES_HC : 0);

	CMFCToolBar::AddToolBarForImageCollection (IDR_BORDER_TYPE, IDR_BORDER_TYPE);

	RecalcLayout ();
	RedrawWindow (NULL, NULL, RDW_ALLCHILDREN | RDW_INVALIDATE | RDW_UPDATENOW | RDW_ERASE);
}

void CMainFrame::OnDummy()
{
	AfxMessageBox (ID_DUMMY);
}

void CMainFrame::OnViewFullScreen() 
{
	ShowFullScreen ();
}

void CMainFrame::OnAskQuestion()
{
	CMFCToolBarComboBoxButton* pHelpCombo = m_wndMenuBar.GetHelpCombobox ();
	if (pHelpCombo == NULL)
	{
		return;
	}

	CString strQuestion = pHelpCombo->GetText ();
	strQuestion.TrimLeft ();
	strQuestion.TrimRight ();

	if (strQuestion.IsEmpty ())
	{
		return;
	}

	pHelpCombo->AddItem (strQuestion);

	CString str;
	str.Format (_T("The question is: %s"), strQuestion);

	MessageBox (str);

	SetFocus ();
}
