// This is a part of the Microsoft Foundation Classes C++ library.
// Copyright (c) Microsoft Corporation.  All rights reserved.
//
// This source code is only intended as a supplement to the
// Microsoft Foundation Classes Reference and related
// electronic documentation provided with the library.
// See these sources for detailed information regarding the
// Microsoft Foundation Classes product.

#include "stdafx.h"
#include "DrawClient.h"

#include "mainfrm.h"
#include "drawdoc.h"
#include "drawvw.h"

#include "RibbonListButton.h"

#ifdef _DEBUG
#undef THIS_FILE
static char BASED_CODE THIS_FILE[] = __FILE__;
#endif

static int g_nSelectedObjectGroupIndex = 0;
static int g_nMaxLineWeight = 20;

static const CMainFrame::XStyle c_Styles[] =
{
	{RGB( 64,  64,  64), RGB(  0,   0,   0)},
	{RGB( 85, 140, 205), RGB( 61,  97, 140)},
	{RGB(207,  86,  82), RGB(143,  61,  59)},
	{RGB(168, 203,  96), RGB(116, 141,  66)},
	{RGB(145, 113, 184), RGB( 97,  77, 121)},
	{RGB( 77, 179, 206), RGB( 56, 129, 149)},
	{RGB(249, 151,  70), RGB(212, 107,  22)},
	{RGB(  0,   0,   0), (COLORREF)-1},
	{RGB( 78, 128, 188), (COLORREF)-1},
	{RGB(191,  79,  76), (COLORREF)-1},
	{RGB(154, 186,  88), (COLORREF)-1},
	{RGB(127,  99, 161), (COLORREF)-1},
	{RGB( 74, 171, 197), (COLORREF)-1},
	{RGB(246, 149,  69), (COLORREF)-1},
	{(COLORREF)-1, RGB(  0,   0,   0)},
	{(COLORREF)-1, RGB( 78, 128, 188)},
	{(COLORREF)-1, RGB(191,  79,  76)},
	{(COLORREF)-1, RGB(154, 186,  88)},
	{(COLORREF)-1, RGB(127,  99, 161)},
	{(COLORREF)-1, RGB( 74, 171, 197)},
	{(COLORREF)-1, RGB(246, 149,  69)},
};

/////////////////////////////////////////////////////////////////////////////
// CMainFrame

IMPLEMENT_DYNAMIC(CMainFrame, CMDIFrameWndEx)

BEGIN_MESSAGE_MAP(CMainFrame, CMDIFrameWndEx)
	//{{AFX_MSG_MAP(CMainFrame)
	ON_WM_CREATE()
	ON_COMMAND_RANGE(ID_VIEW_APPLOOK_2007, ID_VIEW_APPLOOK_2007_3, OnAppLook)
	ON_UPDATE_COMMAND_UI_RANGE(ID_VIEW_APPLOOK_2007, ID_VIEW_APPLOOK_2007_3, OnUpdateAppLook)
	ON_COMMAND(ID_WINDOW_MANAGER, OnWindowManager)
	ON_COMMAND(ID_MDI_MOVE_TO_NEXT_GROUP, OnMdiMoveToNextGroup)
	ON_COMMAND(ID_MDI_MOVE_TO_PREV_GROUP, OnMdiMoveToPrevGroup)
	ON_COMMAND(ID_MDI_NEW_HORZ_TAB_GROUP, OnMdiNewHorzTabGroup)
	ON_COMMAND(ID_MDI_NEW_VERT_GROUP, OnMdiNewVertGroup)
	ON_COMMAND(ID_MDI_CANCEL, OnMdiCancel)
	ON_REGISTERED_MESSAGE(AFX_WM_ON_RIBBON_CUSTOMIZE, OnRibbonCustomize)
	ON_REGISTERED_MESSAGE(AFX_WM_ON_HIGHLIGHT_RIBBON_LIST_ITEM, OnHighlightRibbonListItem)
	ON_COMMAND(ID_WINDOWS_MENU,OnDummy)
	ON_COMMAND(ID_TOOLS_OPTIONS, OnToolsOptions)
	ON_WM_SYSCOLORCHANGE()
	//}}AFX_MSG_MAP
END_MESSAGE_MAP()

/////////////////////////////////////////////////////////////////////////////
// CMainFrame construction/destruction

CMainFrame::CMainFrame()
{
	m_nAppLook = theApp.GetInt(_T("ApplicationLook"), ID_VIEW_APPLOOK_2007);
}

CMainFrame::~CMainFrame()
{
}

int CMainFrame::OnCreate(LPCREATESTRUCT lpCreateStruct)
{
	if (CMDIFrameWndEx::OnCreate(lpCreateStruct) == -1)
		return -1;

	OnAppLook(m_nAppLook);

	if (!CreateRibbonBar())
	{
		TRACE0("Failed to create ribbon bar\n");
		return -1;      // fail to create
	}

	if (!CreateStatusBar())
	{
		TRACE0("Failed to create status bar\n");
		return -1;      // fail to create
	}

	// Enable windows manager:
	EnableWindowsDialog(ID_WINDOW_MANAGER, _T("&Windows..."), TRUE);

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
// CMainFrame message handlers and overrides

void CMainFrame::OnAppLook(UINT id)
{
	CDockingManager::SetDockingMode(DT_SMART);

	m_nAppLook = id;

	CTabbedPane::m_StyleTabWnd = CMFCTabCtrl::STYLE_3D;

	switch (m_nAppLook)
	{
	case ID_VIEW_APPLOOK_2007:
	case ID_VIEW_APPLOOK_2007_1:
	case ID_VIEW_APPLOOK_2007_2:
	case ID_VIEW_APPLOOK_2007_3:
		// enable Office 2007 look:
		switch (m_nAppLook)
		{
		case ID_VIEW_APPLOOK_2007:
			CMFCVisualManagerOffice2007::SetStyle(CMFCVisualManagerOffice2007::Office2007_LunaBlue);
			break;

		case ID_VIEW_APPLOOK_2007_1:
			CMFCVisualManagerOffice2007::SetStyle(CMFCVisualManagerOffice2007::Office2007_ObsidianBlack);
			break;

		case ID_VIEW_APPLOOK_2007_2:
			CMFCVisualManagerOffice2007::SetStyle(CMFCVisualManagerOffice2007::Office2007_Silver);
			break;

		case ID_VIEW_APPLOOK_2007_3:
			CMFCVisualManagerOffice2007::SetStyle(CMFCVisualManagerOffice2007::Office2007_Aqua);
			break;
		}

		CMFCVisualManager::SetDefaultManager(RUNTIME_CLASS(CMFCVisualManagerOffice2007));

		CDockingManager::SetDockingMode(DT_SMART);
		break;
	}

	CMDITabInfo mdiTabParams;

	mdiTabParams.m_style = CMFCTabCtrl::STYLE_3D_VS2005;
	mdiTabParams.m_bAutoColor = TRUE;
	mdiTabParams.m_bDocumentMenu = TRUE;
	mdiTabParams.m_bActiveTabCloseButton = TRUE;

	EnableMDITabbedGroups(TRUE, mdiTabParams);

	CDockingManager* pDockManager = GetDockingManager();
	if (pDockManager != NULL)
	{
		ASSERT_VALID(pDockManager);
		pDockManager->AdjustPaneFrames();
	}

	CTabbedPane::ResetTabs();

	RecalcLayout();
	RedrawWindow(NULL, NULL, RDW_ALLCHILDREN | RDW_INVALIDATE | RDW_UPDATENOW | RDW_ERASE);

	theApp.WriteInt(_T("ApplicationLook"), m_nAppLook);
}

void CMainFrame::OnUpdateAppLook(CCmdUI* pCmdUI)
{
	pCmdUI->SetRadio(m_nAppLook == pCmdUI->m_nID);
}

void CMainFrame::OnWindowManager()
{
	ShowWindowsDialog();
}

LRESULT CMainFrame::OnRibbonCustomize(WPARAM /*wp*/, LPARAM /*lp*/)
{
	ShowOptions(0);
	return 1;
}

void CMainFrame::OnToolsOptions()
{
	ShowOptions(0);
}

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

	CMFCPopupMenu* pPopupMenu = new CMFCPopupMenu;
	pPopupMenu->SetAutoDestroy(FALSE);
	pPopupMenu->Create(this, point.x, point.y, pPopup->GetSafeHmenu());

	return TRUE;
}

void CMainFrame::OnMdiMoveToNextGroup()
{
	MDITabMoveToNextGroup();
}

void CMainFrame::OnMdiMoveToPrevGroup()
{
	MDITabMoveToNextGroup(FALSE);
}

void CMainFrame::OnMdiNewHorzTabGroup()
{
	MDITabNewGroup(FALSE);
}

void CMainFrame::OnMdiNewVertGroup()
{
	MDITabNewGroup();
}

void CMainFrame::OnMdiCancel()
{
	// TODO: Add your command handler code here

}
BOOL CMainFrame::OnShowPopupMenu(CMFCPopupMenu* pMenuPopup)
{
	BOOL bRes = CMDIFrameWndEx::OnShowPopupMenu(pMenuPopup);

	if (pMenuPopup != NULL && !pMenuPopup->IsCustomizePane())
	{
		AdjustObjectSubmenu(pMenuPopup);
	}

	return bRes;
}

/////////////////////////////////////////////////////////////////////////////
// CMainFrame helpers
BOOL CMainFrame::CreateRibbonBar()
{
	if (!m_wndRibbonBar.Create(this))
	{
		return FALSE;
	}

	// Load panel images:
	m_PanelImages.SetImageSize(CSize(16, 16));
	m_PanelImages.Load(IDB_RIBBON_ICONS);

	// Init main button:
	InitMainButton();

	InitHomeCategory();
	InitViewCategory();
	InitTabButtons();

	AddContextTab_Format();

	// Init QAT state
	// Add quick access toolbar commands:
	CMFCRibbonQuickAccessToolBarDefaultState qatState;

	qatState.AddCommand(ID_FILE_NEW, FALSE);
	qatState.AddCommand(ID_FILE_OPEN, FALSE);
	qatState.AddCommand(ID_FILE_SAVE);
	qatState.AddCommand(ID_FILE_PRINT_DIRECT);
	qatState.AddCommand(ID_FILE_PRINT_PREVIEW, FALSE);
	qatState.AddCommand(ID_EDIT_UNDO);

	// Set the state
	m_wndRibbonBar.SetQuickAccessDefaultState(qatState);

	return TRUE;
}

BOOL CMainFrame::CreateStatusBar()
{
	if (!m_wndStatusBar.Create(this))
	{
		return FALSE;
	}

	m_wndStatusBar.AddElement(new CMFCRibbonStatusBarPane(ID_STATUSBAR_PANE_OBJECTCOUNT, _T("Object Count: None"), TRUE), _T("Object Count: None"));

	m_wndStatusBar.AddElement(new CMFCRibbonStatusBarPane(ID_STATUSBAR_PANE_SELECTEDOBJECTCOUNT, _T("Selected Count: None"), TRUE), _T("Selected Count: None"));

	{
		// <Snippet2>
		CMFCRibbonButtonsGroup* pSBGroup = new CMFCRibbonButtonsGroup;

		CMFCToolBarImages images;
		images.SetImageSize(CSize(14, 14));
	
		CMFCToolBarImages hotimages;
		hotimages.SetImageSize(CSize(14, 14));
	
		if (images.Load(IDB_STATUSBAR_1) && hotimages.Load(IDB_STATUSBAR_2))
		{
			pSBGroup->SetImages(&images, &hotimages, NULL);
		}

		pSBGroup->AddButton(new CMFCRibbonButton(ID_FILE_PRINT_PREVIEW, _T(""), 0));
		pSBGroup->AddButton(new CMFCRibbonButton(ID_FILE_SUMMARYINFO, _T(""), 1));
		
		// CMFCRibbonStatusBar m_wndStatusBar
		m_wndStatusBar.AddExtendedElement(pSBGroup, _T("View Shortcuts"));
		// </Snippet2>
	}

	{
		CMFCRibbonButtonsGroup* pSBGroup = new CMFCRibbonButtonsGroup;

		CMFCToolBarImages images;
		images.SetImageSize(CSize(14, 14));
		if (images.Load(IDB_STATUSBAR_2))
		{
			pSBGroup->SetImages(&images, NULL, NULL);
		}

		pSBGroup->AddButton(new CMFCRibbonButton(ID_VIEW_GRID, _T(""), 0));
		pSBGroup->AddButton(new CMFCRibbonButton(ID_VIEW_SHOWOBJECTS, _T(""), 1));

		m_wndStatusBar.AddExtendedElement(pSBGroup, _T("View Shortcuts"));
	}

	return TRUE;
}

void CMainFrame::InitMainButton()
{
	// <snippet5>
	m_MainButton.SetImage(IDB_RIBBON_MAIN);
	m_MainButton.SetToolTipText(_T("File"));
	// Set the short cut keyboard text.
	m_MainButton.SetText(_T("f"));
	// </snippet5>

	m_wndRibbonBar.SetApplicationButton(&m_MainButton, CSize(45, 45));

	CMFCRibbonMainPanel* pMainPanel = m_wndRibbonBar.AddMainCategory(_T("File"), IDB_RIBBON_FILESMALL, IDB_RIBBON_FILELARGE);
	pMainPanel->Add(new CMFCRibbonButton(ID_FILE_NEW, _T("&New"), 0, 0));
	pMainPanel->Add(new CMFCRibbonButton(ID_FILE_OPEN, _T("&Open..."), 1, 1));

	pMainPanel->Add(new CMFCRibbonButton(ID_FILE_SAVE, _T("&Save"), 2, 2));
	pMainPanel->Add(new CMFCRibbonButton(ID_FILE_SAVE_AS, _T("Save &As..."), 3, 3));

	CMFCRibbonButton* pBtnPrint = new CMFCRibbonButton(ID_FILE_PRINT, _T("&Print"), 4, 4);

	pBtnPrint->AddSubItem(new CMFCRibbonLabel(_T("Preview and print the document")));
	pBtnPrint->AddSubItem(new CMFCRibbonButton(ID_FILE_PRINT_DIRECT, _T("&Quick Print"), 7, 7, TRUE));
	pBtnPrint->AddSubItem(new CMFCRibbonButton(ID_FILE_PRINT_PREVIEW, _T("Print Pre&view"), 6, 6, TRUE));

	pBtnPrint->SetKeys(_T("p"), _T("w"));
	pMainPanel->Add(pBtnPrint);

	pMainPanel->AddSeparator();
	pMainPanel->Add(new CMFCRibbonButton(ID_FILE_SEND_MAIL, _T("Sen&d..."), 8, 8));
	pMainPanel->Add(new CMFCRibbonButton(ID_FILE_SUMMARYINFO, _T("Summary &Info..."), 9, 9));

	pMainPanel->AddSeparator();
	pMainPanel->Add(new CMFCRibbonButton(ID_FILE_CLOSE, _T("&Close"), 5, 5));

	pMainPanel->AddRecentFilesList(_T("Recent Documents"));
	pMainPanel->AddToBottom(new CMFCRibbonMainPanelButton(ID_TOOLS_OPTIONS, _T("Opt&ions"), 10));
	pMainPanel->AddToBottom(new CMFCRibbonMainPanelButton(ID_APP_EXIT, _T("E&xit"), 11));
}

void CMainFrame::InitHomeCategory()
{
	CreateDocumentColors();

	CMFCRibbonCategory* pCategory = m_wndRibbonBar.AddCategory(_T("&Home"), IDB_RIBBON_HOMESMALL, IDB_RIBBON_HOMELARGE);

	// Create "Clipboard" panel:
	CMFCRibbonPanel* pPanelClipboard = pCategory->AddPanel(_T("Clipboard\nzc"), m_PanelImages.ExtractIcon(0));

	CMFCRibbonButton* pBtnPaste = new CMFCRibbonButton(ID_EDIT_PASTE, _T("Paste\nv"), 0, 0);
	pPanelClipboard->Add(pBtnPaste);

	pPanelClipboard->Add(new CMFCRibbonButton(ID_EDIT_CUT, _T("Cut\nx"), 1));
	pPanelClipboard->Add(new CMFCRibbonButton(ID_EDIT_COPY, _T("Copy\nc"), 2));
	pPanelClipboard->Add(new CMFCRibbonButton(ID_EDIT_CLEAR, _T("Delete\nt"), 3));

	// Create "Operations" panel
	CMFCRibbonPanel* pPanelOperations = pCategory->AddPanel(_T("Operations\nzo"), m_PanelImages.ExtractIcon(1));

	// <Snippet3>
	// Create the "Paper Color" button
	CMFCRibbonColorButton* pBtnPaperColor = new CMFCRibbonColorButton(ID_VIEW_PAPERCOLOR, _T("Paper Color\ng"), TRUE, 13, 1);
	pBtnPaperColor->SetAlwaysLargeImage();
	pBtnPaperColor->EnableAutomaticButton(_T("&Automatic"), RGB(255, 255, 255));
	pBtnPaperColor->EnableOtherButton(_T("&More Colors..."), _T("More Colors"));
	pBtnPaperColor->SetColumns(10);
	pBtnPaperColor->SetColorBoxSize(CSize(17, 17));
	// CList<COLORREF,COLORREF> m_lstMainColors
	pBtnPaperColor->AddColorsGroup(_T("Theme Colors"), m_lstMainColors, TRUE);
	// CList<COLORREF,COLORREF> m_lstAdditionalColors
	pBtnPaperColor->AddColorsGroup(_T(""), m_lstAdditionalColors, FALSE);
	// CList<COLORREF,COLORREF> m_lstStandardColors
	pBtnPaperColor->AddColorsGroup(_T("Standard Colors"), m_lstStandardColors, TRUE);
	CList<COLORREF,COLORREF> lstColors;
	lstColors.AddTail(RGB(255,0,0));
	lstColors.AddTail(RGB(0,255,0));
	lstColors.AddTail(RGB(0,0,255));
	pBtnPaperColor->SetDocumentColors( _T("Document Colors"), lstColors );
    // </Snippet3>

	pPanelOperations->Add(pBtnPaperColor);

	pPanelOperations->Add(new CMFCRibbonButton(ID_EDIT_SELECT_ALL, _T("Select All\na"), 4));
	pPanelOperations->Add(new CMFCRibbonButton(ID_OLE_INSERT_NEW, _T("New Object...\no"), 5));
	pPanelOperations->Add(new CMFCRibbonButton(ID_OLE_EDIT_LINKS, _T("Links...\ni"), 6));

	// Create "Draw" panel
	CMFCRibbonPanel* pPanelDraw = pCategory->AddPanel(_T("Draw\nzd"), m_PanelImages.ExtractIcon(2));

	pPanelDraw->Add(new CMFCRibbonButton(ID_DRAW_SELECT, _T("Select\ns"), 7));
	pPanelDraw->Add(new CMFCRibbonButton(ID_DRAW_LINE, _T("Line\nl"), 8));
	pPanelDraw->Add(new CMFCRibbonButton(ID_DRAW_RECT, _T("Rectangle\nr"), 9));
	pPanelDraw->Add(new CMFCRibbonButton(ID_DRAW_ROUNDRECT, _T("Round Rectangle\nn"), 10));
	pPanelDraw->Add(new CMFCRibbonButton(ID_DRAW_ELLIPSE, _T("Ellipse\ne"), 11));
	pPanelDraw->Add(new CMFCRibbonButton(ID_DRAW_POLYGON, _T("Polygon\ny"), 12));

	// Create "Arrange" panel
	CMFCRibbonPanel* pPanelArrange = pCategory->AddPanel(_T("Arrange\nzj"), m_PanelImages.ExtractIcon(3));

	pPanelArrange->Add(new CMFCRibbonButton(ID_OBJECT_MOVETOFRONT, _T("Move to Front\nmf"), 15, 3));
	pPanelArrange->Add(new CMFCRibbonButton(ID_OBJECT_MOVEFORWARD, _T("Move Forward\nmw"), 17, 5));
	pPanelArrange->Add(new CMFCRibbonButton(ID_OBJECT_MOVEBACK, _T("Move Backward\nmd"), 18, 6));
	pPanelArrange->Add(new CMFCRibbonButton(ID_OBJECT_MOVETOBACK, _T("Move to Back\nmb"), 16, 4));

	// Add not-in-ribbon commands
	CMFCRibbonButton* pUndo = new CMFCRibbonButton(ID_EDIT_UNDO, _T("Undo"), 20);
	pCategory->AddHidden(pUndo);
}

void CMainFrame::InitViewCategory()
{
	CMFCRibbonCategory* pCategory = m_wndRibbonBar.AddCategory(_T("&View"), IDB_RIBBON_VIEWSMALL, IDB_RIBBON_VIEWLARGE);

	// Create "Show/Hide" panel:
	CMFCRibbonPanel* pPanelShow = pCategory->AddPanel(_T("Show/Hide\nzs"), m_PanelImages.ExtractIcon(4));

	pPanelShow->Add(new CMFCRibbonCheckBox(ID_VIEW_GRID, _T("Grid Lines\ng")));
	pPanelShow->Add(new CMFCRibbonCheckBox(ID_VIEW_SHOWOBJECTS, _T("Show Objects\ns")));

	// Create "Window" panel:
	CMFCRibbonPanel* pPanelWindow = pCategory->AddPanel(_T("Window\nzw"), m_PanelImages.ExtractIcon(5));

	pPanelWindow->Add(new CMFCRibbonButton(ID_WINDOW_NEW, _T("New Window\nn"), 0, 0));

	CMFCRibbonButton* pBtnWindows = new CMFCRibbonButton(ID_WINDOWS_MENU, _T("Switch Windows\ns"), 1, 1);
	pBtnWindows->SetMenu(IDR_WINDOWS_MENU, TRUE);
	pBtnWindows->SetDefaultCommand(FALSE);
	pPanelWindow->Add(pBtnWindows);
}

void CMainFrame::InitTabButtons()
{
	// Add "Style" button to the right of tabs:
	CMFCRibbonButton* pStyleButton = new CMFCRibbonButton((UINT) -1, _T("Style\ns"));
	pStyleButton->SetMenu(IDR_THEME_MENU, TRUE /* Right align */);

	m_wndRibbonBar.AddToTabs(pStyleButton);

	// Add "About" button to the right of tabs:
	m_wndRibbonBar.AddToTabs(new CMFCRibbonButton(ID_APP_ABOUT, _T("\na"), m_PanelImages.ExtractIcon(6)));

}

void CMainFrame::AddContextTab_Format()
{
	CMFCRibbonCategory* pCategory = m_wndRibbonBar.AddContextCategory(_T("Format"), _T("Drawing tools"), ID_FORMAT_CONTEXT_TAB, AFX_CategoryColor_Orange, IDB_RIBBON_FORMATSMALL, IDB_RIBBON_FORMATLARGE);
	pCategory->SetKeys(_T("jd"));

	// Create "Styles" panel
	CMFCRibbonPanel* pPanelStyles = pCategory->AddPanel(_T("Styles\nzs"), m_PanelImages.ExtractIcon(8));

	// <snippet6>
	CMFCRibbonGallery* pBtnStyles = new CMFCRibbonGallery(ID_OBJECT_STYLES, _T("Styles\nk"), 0, 0, IDB_STYLES, 40);
	pBtnStyles->SetIconsInRow(7);
	pBtnStyles->EnableMenuResize(TRUE, TRUE);
	pBtnStyles->EnableMenuSideBar();
	pBtnStyles->SetButtonMode(false);
	pBtnStyles->RedrawIcons();
	// </snippet6>

	pPanelStyles->Add(pBtnStyles);

	CMFCRibbonColorButton* pBtnFillColor = new CMFCRibbonColorButton(ID_OBJECT_FILLCOLOR, _T("Fill Color\nsf"), FALSE, 1, -1);
	pBtnFillColor->SetDefaultCommand(FALSE);
	pBtnFillColor->EnableAutomaticButton(_T("&Automatic"), RGB(128, 128, 128));
	pBtnFillColor->EnableOtherButton(_T("&More Fill Colors..."), _T("More Fill Colors"));
	pBtnFillColor->SetColumns(10);
	pBtnFillColor->SetColorBoxSize(CSize(17, 17));
	pBtnFillColor->AddColorsGroup(_T("Theme Colors"), m_lstMainColors);
	pBtnFillColor->AddColorsGroup(_T(""), m_lstAdditionalColors, TRUE);
	pBtnFillColor->AddColorsGroup(_T("Standard Colors"), m_lstStandardColors);
	pBtnFillColor->AddSubItem(new CMFCRibbonButton(ID_OBJECT_NOFILL, _T("&No Fill\nn"), 2));
	pBtnFillColor->SetColor((COLORREF)-1);
	pPanelStyles->Add(pBtnFillColor);

	CMFCRibbonColorButton* pBtnLineColor = new CMFCRibbonColorButton(ID_OBJECT_LINECOLOR, _T("Line Color\nso"), FALSE, 3, -1);
	pBtnLineColor->SetDefaultCommand(FALSE);
	pBtnLineColor->EnableAutomaticButton(_T("&Automatic"), RGB(0, 0, 0));
	pBtnLineColor->EnableOtherButton(_T("&More Line Colors..."), _T("More Line Colors"));
	pBtnLineColor->SetColumns(10);
	pBtnLineColor->SetColorBoxSize(CSize(17, 17));
	pBtnLineColor->AddColorsGroup(_T("Theme Colors"), m_lstMainColors);
	pBtnLineColor->AddColorsGroup(_T(""), m_lstAdditionalColors, TRUE);
	pBtnLineColor->AddColorsGroup(_T("Standard Colors"), m_lstStandardColors);
	pBtnLineColor->AddSubItem(new CMFCRibbonButton(ID_OBJECT_NOLINE, _T("&No Line\nn"), 2));
	pBtnLineColor->SetColor((COLORREF)-1);
	pPanelStyles->Add(pBtnLineColor);

	CStringArray sa;
	sa.Add(_T("1 pt"));
	sa.Add(_T("2 pt"));
	sa.Add(_T("3 pt"));
	sa.Add(_T("4 pt"));
	sa.Add(_T("5 pt"));
	sa.Add(_T("6 pt"));
	sa.Add(_T("7 pt"));
	CRibbonListButton* pBtnLineWeight = new CRibbonListButton(ID_OBJECT_LINEWEIGHT, _T("Line Weight\nsw"), 4, -1, IDB_LINEWEIGHT, 96, sa);
	pBtnLineWeight->AddSubItem(new CMFCRibbonButton(ID_OBJECT_LINEWEIGHT_MORE, _T("More &Lines..."), 5, -1));
	pBtnLineWeight->EnableMenuResize(TRUE, TRUE); // Vertical only
	pPanelStyles->Add(pBtnLineWeight);

	// Create "Arrange" panel
	CMFCRibbonPanel* pPanelArrange = pCategory->AddPanel(_T("Arrange\nzj"), m_PanelImages.ExtractIcon(3));

	pPanelArrange->Add(new CMFCRibbonButton(ID_OBJECT_MOVETOFRONT, _T("Move to Front\nmf"), 7, 1));
	pPanelArrange->Add(new CMFCRibbonButton(ID_OBJECT_MOVEFORWARD, _T("Move Forward\nmw"), 9, 3));
	pPanelArrange->Add(new CMFCRibbonButton(ID_OBJECT_MOVEBACK, _T("Move Backward\nmd"), 10, 4));
	pPanelArrange->Add(new CMFCRibbonButton(ID_OBJECT_MOVETOBACK, _T("Move to Back\nmb"), 8, 2));
}

void CMainFrame::AdjustObjectSubmenu(CMFCPopupMenu* pMenuPopup)
{
	ASSERT(pMenuPopup != NULL);

	if (pMenuPopup->GetParentPopupMenu() != NULL)
	{
		return;
	}

	// <snippet7>
	// CMFCPopupMenu* pMenuPopup
	CMFCPopupMenuBar* pMenuBar = pMenuPopup->GetMenuBar();
	// </snippet7>
	ASSERT(pMenuBar != NULL);

	// <snippet10>
	// CMFCPopupMenuBar* pMenuBar
	CMFCCustomizeMenuButton* pBtn = (CMFCCustomizeMenuButton*)pMenuBar->GetButton(0);
	pBtn->EnableCustomization(true);
	pBtn->SetSeparator();
	// </snippet10>


	int iIndex = pMenuBar->CommandToIndex(ID_OLE_VERB_FIRST);
	if (iIndex < 0)
	{
		return;
	}

	CFrameWnd* pFrame = GetActiveFrame();

	if (pFrame == NULL)
	{
		return;
	}

	CDrawDoc* pDoc = (CDrawDoc*)pFrame->GetActiveDocument();
	ASSERT_VALID(pDoc);

	// check for single selection
	COleClientItem* pItem = pDoc->GetPrimarySelectedItem(pFrame->GetActiveView());
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

	HMENU hMenu = pMenuBar->ExportToMenu();
	ASSERT(hMenu != NULL);

	// update the menu
	AfxOleSetEditMenu(pItem, CMenu::FromHandle(hMenu), iIndex, ID_OLE_VERB_FIRST, ID_OLE_VERB_LAST, nConvertID);

	pMenuBar->ImportFromMenu(hMenu);
	::DestroyMenu(hMenu);
}

void CMainFrame::ShowOptions(int nPage)
{
	// Create "Customize" page:
	CMFCRibbonCustomizePropertyPage pageCustomize(&m_wndRibbonBar);

	// Add "popular" items:
	CList<UINT, UINT> lstPopular;

	lstPopular.AddTail(ID_FILE_NEW);
	lstPopular.AddTail(ID_FILE_OPEN);
	lstPopular.AddTail(ID_FILE_SAVE);
	lstPopular.AddTail(ID_FILE_PRINT_PREVIEW);
	lstPopular.AddTail(ID_FILE_PRINT_DIRECT);
	lstPopular.AddTail(ID_EDIT_UNDO);

	pageCustomize.AddCustomCategory(_T("Popular Commands"), lstPopular);

	// Add hidden commands:
	CList<UINT,UINT> lstHidden;
	m_wndRibbonBar.GetItemIDsList(lstHidden, TRUE);

	pageCustomize.AddCustomCategory(_T("Commands not in the Ribbon"), lstHidden);

	// Add all commands:
	CList<UINT,UINT> lstAll;
	m_wndRibbonBar.GetItemIDsList(lstAll);

	pageCustomize.AddCustomCategory(_T("All Commands"), lstAll);

	// Create property sheet:
	CMFCPropertySheet propSheet(_T("Options"), this, nPage);
	propSheet.m_psh.dwFlags |= PSH_NOAPPLYNOW;

	propSheet.SetLook(CMFCPropertySheet::PropSheetLook_List, 124 /* List width */);

	propSheet.AddPage(&pageCustomize);

	if (propSheet.DoModal() != IDOK)
	{
		return;
	}
}

void CMainFrame::UpdateUI(CDrawView* pCurrView)
{
	// Update Status Bar
	CDrawDoc* pCurrDoc = pCurrView->GetDocument();
	UpdateStatusBarCountPane(ID_STATUSBAR_PANE_OBJECTCOUNT, _T("Object Count"), (int) pCurrDoc->GetObjects()->GetCount());
	UpdateStatusBarCountPane(ID_STATUSBAR_PANE_SELECTEDOBJECTCOUNT, _T("Selected Count"), (int) pCurrView->m_selection.GetCount());

	m_wndStatusBar.Invalidate();
	m_wndStatusBar.UpdateWindow();
}

void CMainFrame::UpdateContextTab(CDrawView* pCurrView)
{
	bool bEnable = pCurrView->m_selection.GetCount() > 0;

	SetRibbonContextCategory(bEnable ? ID_FORMAT_CONTEXT_TAB : 0);

	if (bEnable)
	{
		UpdateContextTabFromObject(pCurrView->m_selection);
	}
}

void CMainFrame::UpdateStatusBarCountPane(int nID, CString strText, int nCount)
{
	// <snippet8>
	// CMFCRibbonStatusBar m_wndStatusBar
	CMFCRibbonBaseElement* pPane = m_wndStatusBar.FindByID(nID);
	// </snippet8>

	if (pPane != NULL)
	{
		if (nCount == 0)
		{
			strText += _T(": None");
		}
		else
		{
			CString strFormatted;
			strFormatted.Format(_T(": %d"), nCount);

			strText += strFormatted;
		}

		// <snippet9>
		pPane->SetDescription(_T("a pane"));
		// CString strText
		pPane->SetText(strText);
		pPane->SetKeys(_T("p"));
		pPane->SetToolTipText(_T("this is a pane"));
		// </snippet9>
	}

}

void CMainFrame::UpdateContextTabFromObject(CDrawObjList& list)
{
	int count = (int) list.GetCount();
	if (count == 0)
	{
		return;
	}

	COLORREF clrFill = (COLORREF)-1;
	COLORREF clrLine = (COLORREF)-1;
	int nLineWeight  = -1;
	if (count == 1)
	{
		CDrawObj* pObj = list.GetHead();
		if (pObj->CanChangeFillColor() && pObj->IsEnableFill())
		{
			clrFill = pObj->GetFillColor();
		}
		if (pObj->CanChangeLineColor() && pObj->IsEnableLine())
		{
			clrLine = pObj->GetLineColor();
		}
		if (pObj->CanChangeLineWeight() && pObj->IsEnableLine())
		{
			nLineWeight = pObj->GetLineWeight() - 1;
		}
	}

	{
		CArray<CMFCRibbonBaseElement*, CMFCRibbonBaseElement*> arButtons;
		m_wndRibbonBar.GetElementsByID(ID_OBJECT_FILLCOLOR, arButtons);

		if (arButtons.GetSize() > 0)
		{
			for (int i = 0; i < arButtons.GetSize(); i++)
			{
				CMFCRibbonColorButton* pButton = DYNAMIC_DOWNCAST
					(CMFCRibbonColorButton, arButtons[i]
				);
				pButton->SetColor(clrFill);
			}
		}
	}

	{
		CArray<CMFCRibbonBaseElement*, CMFCRibbonBaseElement*> arButtons;
		m_wndRibbonBar.GetElementsByID(ID_OBJECT_LINECOLOR, arButtons);

		if (arButtons.GetSize() > 0)
		{
			for (int i = 0; i < arButtons.GetSize(); i++)
			{
				CMFCRibbonColorButton* pButton = DYNAMIC_DOWNCAST
					(CMFCRibbonColorButton, arButtons[i]
				);
				pButton->SetColor(clrLine);
			}
		}
	}

	{
		CArray<CMFCRibbonBaseElement*, CMFCRibbonBaseElement*> arButtons;
		m_wndRibbonBar.GetElementsByID(ID_OBJECT_LINEWEIGHT, arButtons);

		if (arButtons.GetSize() > 0)
		{
			for (int i = 0; i < arButtons.GetSize(); i++)
			{
				CRibbonListButton* pButton = DYNAMIC_DOWNCAST
					(CRibbonListButton, arButtons[i]
				);
				pButton->SelectItem(nLineWeight);
			}
		}
	}

	m_wndRibbonBar.RedrawWindow();
}

void CMainFrame::CreateDocumentColors()
{
	typedef struct
	{
		COLORREF color;
		TCHAR* szName;
	}
	ColorTableEntry;

	int i = 0;
	int nNumColours = 0;

	static ColorTableEntry colorsMain [] =
	{
		{ RGB(255, 255, 255), _T("White, Background 1") },
		{ RGB(0, 0, 0), _T("Black, Text 1") },
		{ RGB(238, 236, 225), _T("Tan, Background 2") },
		{ RGB(31, 73, 125), _T("Dark Blue, Text 2") },
		{ RGB(79, 129, 189), _T("Blue, Accent 1") },
		{ RGB(192, 80, 77), _T("Red, Accent 2") },
		{ RGB(155, 187, 89), _T("Olive Green, Accent 3") },
		{ RGB(128, 100, 162), _T("Purple, Accent 4") },
		{ RGB(75, 172, 198), _T("Aqua, Accent 5") },
		{ RGB(245, 150, 70), _T("Orange, Accent 6") }
	};

	static ColorTableEntry colorsAdditional [] =
	{
		{ RGB(242, 242, 242), _T("White, Background 1, Darker 5%") },
		{ RGB(127, 127, 127), _T("Black, Text 1, Lighter 50%") },
		{ RGB(214, 212, 202), _T("Tan, Background 2, Darker 10%") },
		{ RGB(210, 218, 229), _T("Dark Blue, Text 2, Lighter 80%") },
		{ RGB(217, 228, 240), _T("Blue, Accent 1, Lighter 80%") },
		{ RGB(244, 219, 218), _T("Red, Accent 2, Lighter 80%") },
		{ RGB(234, 241, 221), _T("Olive Green, Accent 3, Lighter 80%")},
		{ RGB(229, 223, 235), _T("Purple, Accent 4, Lighter 80%") },
		{ RGB(216, 237, 242), _T("Aqua, Accent 5, Lighter 80%") },
		{ RGB(255, 234, 218), _T("Orange, Accent 6, Lighter 80%") },
		{ RGB(215, 215, 215), _T("White, Background 1, Darker 15%") },
		{ RGB(89, 89, 89), _T("Black, Text 1, Lighter 35%") },
		{ RGB(177, 176, 167), _T("Tan, Background 2, Darker 25%") },
		{ RGB(161, 180, 201), _T("Dark Blue, Text 2, Lighter 60%") },
		{ RGB(179, 202, 226), _T("Blue, Accent 1, Lighter 60%") },
		{ RGB(233, 184, 182), _T("Red, Accent 2, Lighter 60%") },
		{ RGB(213, 226, 188), _T("Olive Green, Accent 3, Lighter 60%")},
		{ RGB(203, 191, 215), _T("Purple, Accent 4, Lighter 60%") },
		{ RGB(176, 220, 231), _T("Aqua, Accent 5, Lighter 60%") },
		{ RGB(255, 212, 181), _T("Orange, Accent 6, Lighter 60%") },
		{ RGB(190, 190, 190), _T("White, Background 1, Darker 25%") },
		{ RGB(65, 65, 65), _T("Black, Text 1, Lighter 25%") },
		{ RGB(118, 117, 112), _T("Tan, Background 2, Darker 35%") },
		{ RGB(115, 143, 175), _T("Dark Blue, Text 2, Lighter 40%") },
		{ RGB(143, 177, 213), _T("Blue, Accent 1, Lighter 40%") },
		{ RGB(222, 149, 147), _T("Red, Accent 2, Lighter 40%") },
		{ RGB(192, 213, 155), _T("Olive Green, Accent 3, Lighter 40%")},
		{ RGB(177, 160, 197), _T("Purple, Accent 4, Lighter 40%") },
		{ RGB(137, 203, 218), _T("Aqua, Accent 5, Lighter 40%") },
		{ RGB(255, 191, 145), _T("Orange, Accent 6, Lighter 40%") },
		{ RGB(163, 163, 163), _T("White, Background 1, Darker 35%") },
		{ RGB(42, 42, 42), _T("Black, Text 1, Lighter 15%") },
		{ RGB(61, 61, 59), _T("Tan, Background 2, Darker 50%") },
		{ RGB(20, 57, 92), _T("Dark Blue, Text 2, Darker 25%") },
		{ RGB(54, 96, 139), _T("Blue, Accent 1, Darker 25%") },
		{ RGB(149, 63, 60), _T("Red, Accent 2, Darker 25%") },
		{ RGB(114, 139, 71), _T("Olive Green, Accent 3, Darker 25%") },
		{ RGB(97, 76, 119), _T("Purple, Accent 4, Darker 25%") },
		{ RGB(41, 128, 146), _T("Aqua, Accent 5, Darker 25%") },
		{ RGB(190, 112, 59), _T("Orange, Accent 6, Darker 25%") },
		{ RGB(126, 126, 126), _T("White, Background 1, Darker 50%") },
		{ RGB(20, 20, 20), _T("Black, Text 1, Lighter 5%") },
		{ RGB(29, 29, 28), _T("Tan, Background 2, Darker 90%") },
		{ RGB(17, 40, 64), _T("Dark Blue, Text 2, Darker 50%") },
		{ RGB(38, 66, 94), _T("Blue, Accent 1, Darker 50%") },
		{ RGB(100, 44, 43), _T("Red, Accent 2, Darker 50%") },
		{ RGB(77, 93, 49), _T("Olive Green, Accent 3, Darker 50%") },
		{ RGB(67, 53, 81), _T("Purple, Accent 4, Darker 50%") },
		{ RGB(31, 86, 99), _T("Aqua, Accent 5, Darker 50%") },
		{ RGB(126, 77, 42), _T("Orange, Accent 6, Darker 50%") },
	};

	static ColorTableEntry colorsStandard [] =
	{
		{ RGB(200, 15, 18), _T("Dark Red") },
		{ RGB(255, 20, 24), _T("Red") },
		{ RGB(255, 191, 40), _T("Orange") },
		{ RGB(255, 255, 49), _T("Yellow") },
		{ RGB(138, 207, 87), _T("Light Green") },
		{ RGB(0, 175, 84), _T("Green") },
		{ RGB(0, 174, 238), _T("Light Blue") },
		{ RGB(0, 111, 189), _T("Blue") },
		{ RGB(0, 36, 95), _T("Black") },
		{ RGB(114, 50, 157), _T("Purple") },
	};

	m_lstMainColors.RemoveAll();
	nNumColours = sizeof(colorsMain) / sizeof(ColorTableEntry);

	for (i = 0; i < nNumColours; i++)
	{
		m_lstMainColors.AddTail(colorsMain [i].color);
		CMFCRibbonColorButton::SetColorName(colorsMain [i].color, colorsMain [i].szName);
	};

	m_lstAdditionalColors.RemoveAll();
	nNumColours = sizeof(colorsAdditional) / sizeof(ColorTableEntry);

	for (i = 0; i < nNumColours; i++)
	{
		m_lstAdditionalColors.AddTail(colorsAdditional [i].color);
		CMFCRibbonColorButton::SetColorName(colorsAdditional [i].color, colorsAdditional [i].szName);
	};

	m_lstStandardColors.RemoveAll();
	nNumColours = sizeof(colorsStandard) / sizeof(ColorTableEntry);

	for (i = 0; i < nNumColours; i++)
	{
		m_lstStandardColors.AddTail(colorsStandard [i].color);
		CMFCRibbonColorButton::SetColorName(colorsStandard [i].color, colorsStandard [i].szName);
	};
}

COLORREF CMainFrame::GetColorFromColorButton(int nButtonID)
{
	CArray<CMFCRibbonBaseElement*, CMFCRibbonBaseElement*> arButtons;

	m_wndRibbonBar.GetElementsByID(nButtonID, arButtons);

	if (arButtons.GetSize() == 0)
	{
		return(COLORREF) -1;
	}

	CMFCRibbonColorButton* pColorButton = (CMFCRibbonColorButton*)arButtons.GetAt(0);

	COLORREF clr = pColorButton->GetColor();
	if (clr == (COLORREF)-1)
	{
		clr = pColorButton->GetAutomaticColor();
	}

	return clr;
}

int CMainFrame::GetWeightFromLineWeight(int nButtonID)
{
	CArray<CMFCRibbonBaseElement*, CMFCRibbonBaseElement*> arButtons;

	m_wndRibbonBar.GetElementsByID(nButtonID, arButtons);

	if (arButtons.GetSize() == 0)
	{
		return -1;
	}

	int weight = -1;
	CMFCRibbonGallery* pBtn = DYNAMIC_DOWNCAST(CMFCRibbonGallery, arButtons.GetAt(0));
	if (pBtn != NULL && pBtn->GetSelectedItem() != -1)
	{
		weight = pBtn->GetSelectedItem() + 1;
	}

	return weight;
}

BOOL CMainFrame::GetStyleFromStyles(XStyle& style)
{
	CArray<CMFCRibbonBaseElement*, CMFCRibbonBaseElement*> arButtons;

	m_wndRibbonBar.GetElementsByID(ID_OBJECT_STYLES, arButtons);

	if (arButtons.GetSize() == 0)
	{
		return FALSE;
	}

	BOOL bRes = FALSE;

	CMFCRibbonGallery* pBtn = DYNAMIC_DOWNCAST(CMFCRibbonGallery, arButtons.GetAt(0));
	if (pBtn != NULL && pBtn->GetSelectedItem() != -1)
	{
		style = c_Styles[pBtn->GetSelectedItem()];
		bRes = TRUE;
	}

	return bRes;
}

void CMainFrame::OnDummy()
{
}

LRESULT CMainFrame::OnHighlightRibbonListItem(WPARAM wp, LPARAM lp)
{
	int nIndex = (int) wp;

	CMFCRibbonBaseElement* pElem = (CMFCRibbonBaseElement*) lp;
	ASSERT_VALID(pElem);

	const UINT uiCommand = pElem->GetID();

	CFrameWnd* pFrame = GetActiveFrame();
	if (pFrame == NULL)
	{
		return 0;
	}

	CDrawDoc* pDoc = (CDrawDoc*)pFrame->GetActiveDocument();
	if (pDoc == NULL)
	{
		return 0;
	}

	ASSERT_VALID(pDoc);

	CDrawView* pView = DYNAMIC_DOWNCAST(CDrawView, pFrame->GetActiveView());
	if (pView == NULL)
	{
		return 0;
	}

	if (uiCommand != ID_VIEW_PAPERCOLOR)
	{
		if (nIndex != -1)
		{
			pView->StorePreviewState();
		}
		else
		{
			pView->RestorePreviewState();
		}
	}

	switch (uiCommand)
	{
	case ID_VIEW_PAPERCOLOR:
	case ID_OBJECT_FILLCOLOR:
	case ID_OBJECT_LINECOLOR:
		{
			COLORREF color = ((CMFCRibbonColorButton*) pElem)->GetHighlightedColor();

			if (uiCommand == ID_VIEW_PAPERCOLOR)
			{
				pDoc->SetPreviewColor(color);
			}
			else if (nIndex != -1)
			{
				if (uiCommand == ID_OBJECT_FILLCOLOR)
				{
					pView->PreviewFillColor(color);
				}
				else
				{
					pView->PreviewLineColor(color);
				}
			}

			CMFCPopupMenu::UpdateAllShadows();
		}
		break;

	case ID_OBJECT_LINEWEIGHT:
		if (nIndex != -1)
		{
			pView->PreviewLineWeight(nIndex + 1);
			CMFCPopupMenu::UpdateAllShadows();
		}
		break;

	case ID_OBJECT_STYLES:
		if (nIndex != -1)
		{
			pView->PreviewStyle(c_Styles[nIndex].clrFill, c_Styles[nIndex].clrLine);
			CMFCPopupMenu::UpdateAllShadows();
		}
		break;
	}

	return 0;
}

void CMainFrame::SetRibbonContextCategory(UINT uiCategoryID)
{
	if (uiCategoryID != 0)
	{
		CMFCRibbonCategory* pActivaTab = m_wndRibbonBar.GetActiveCategory();
		if (pActivaTab != NULL && pActivaTab->GetContextID() == uiCategoryID)
		{
			return;
		}
	}

	BOOL bRecalc = m_wndRibbonBar.HideAllContextCategories();

	if (uiCategoryID != 0)
	{
		m_wndRibbonBar.ShowContextCategories(uiCategoryID);
		bRecalc = TRUE;
	}

	if (bRecalc)
	{
		m_wndRibbonBar.RecalcLayout();
		m_wndRibbonBar.RedrawWindow();

		SendMessage(WM_NCPAINT, 0, 0);
	}
}

void CMainFrame::ActivateRibbonContextCategory(UINT uiCategoryID)
{
	if (m_wndRibbonBar.GetHideFlags() == 0)
	{
		m_wndRibbonBar.ActivateContextCategory(uiCategoryID);
	}
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
