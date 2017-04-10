// This MFC Samples source code demonstrates using MFC Microsoft Office Fluent User Interface 
// (the "Fluent UI") and is provided only as referential material to supplement the 
// Microsoft Foundation Classes Reference and related electronic documentation 
// included with the MFC C++ library software.  
// License terms to copy, use or distribute the Fluent UI are available separately.  
// To learn more about our Fluent UI licensing program, please visit 
// http://msdn.microsoft.com/officeui.
//
// Copyright (C) Microsoft Corporation
// All rights reserved.

#include "stdafx.h"
#include "MSOffice2007Demo.h"
#include "OptionsPage.h"
#include "ResourcePage.h"
#include "MainFrm.h"
#include "keys.h"
#include "RibbonTableButton.h"

#ifdef _DEBUG
#define new DEBUG_NEW
#undef THIS_FILE
static char THIS_FILE[] = __FILE__;
#endif

#pragma warning(disable:4100)

const int IdStartProgressTimer = 1;
const int IdShowProgressTimer = 2;

const DWORD idTabDeveloper = 101;

/////////////////////////////////////////////////////////////////////////////
// CMainFrame

IMPLEMENT_DYNCREATE(CMainFrame, CFrameWndEx)

BEGIN_MESSAGE_MAP(CMainFrame, CFrameWndEx)
	//{{AFX_MSG_MAP(CMainFrame)
	ON_WM_CREATE()
	ON_WM_GETMINMAXINFO()
	ON_WM_PAINT()
	ON_WM_ERASEBKGND()
	ON_WM_SIZING()
	ON_WM_SIZE()
	ON_WM_TIMER()
	ON_COMMAND(ID_WRITE_CLIPBOARD, OnWriteClipboard)
	ON_UPDATE_COMMAND_UI(ID_WRITE_CLIPBOARD, OnUpdateWriteClipboard)
	ON_COMMAND(ID_VIEW_RTL, OnViewRtl)
	ON_UPDATE_COMMAND_UI(ID_VIEW_RTL, OnUpdateViewRtl)
	ON_COMMAND(ID_STATUSBAR_ZOOM_SLIDER, OnZoomSlider)
	ON_COMMAND(ID_STATUSBAR_ZOOM, OnZoom)
	ON_COMMAND_RANGE(ID_VIEW_APPLOOK_2003, ID_VIEW_APPLOOK_2007_4, OnAppLook)
	ON_UPDATE_COMMAND_UI_RANGE(ID_VIEW_APPLOOK_2003, ID_VIEW_APPLOOK_2007_4, OnUpdateAppLook)
	ON_COMMAND(ID_STATUSBAR_REFRESH, OnRefresh)
	ON_UPDATE_COMMAND_UI(ID_STATUSBAR_REFRESH, OnUpdateRefresh)
	ON_COMMAND(ID_STATUSBAR_SPELL, OnSpell)
	ON_COMMAND(ID_TOOLS_OPTIONS, OnToolsOptions)
	ON_REGISTERED_MESSAGE(AFX_WM_ON_RIBBON_CUSTOMIZE, OnRibbonCustomize)
	ON_COMMAND(ID_STATUSBAR_LINK, OnLink)
	ON_REGISTERED_MESSAGE(AFX_WM_ON_HIGHLIGHT_RIBBON_LIST_ITEM, OnHighlightRibbonListItem)
	ON_COMMAND(ID_VIEW_MESSAGEBAR, OnViewMessageBar)
	ON_UPDATE_COMMAND_UI(ID_VIEW_MESSAGEBAR, OnUpdateViewMessageBar)
	ON_REGISTERED_MESSAGE(AFX_WM_ON_BEFORE_SHOW_RIBBON_ITEM_MENU, OnShowRibbonItemMenu)
	ON_COMMAND_RANGE(ID_PAGELAYOUT_EFFECTS_ACADEMIC, ID_PAGELAYOUT_THEMES_MORETHEMES, OnDummy)
	ON_COMMAND(ID_FILE_PRINT, OnFilePrint)
	ON_COMMAND(ID_FILE_PRINT_DIRECT, OnFilePrint)
	ON_COMMAND(ID_FILE_PRINT_PREVIEW, OnFilePrintPreview)
	ON_UPDATE_COMMAND_UI(ID_FILE_PRINT_PREVIEW, OnUpdateFilePrintPreview)
	//}}AFX_MSG_MAP
END_MESSAGE_MAP()

/////////////////////////////////////////////////////////////////////////////
// CMainFrame construction/destruction

CMainFrame::CMainFrame()
{
	m_rectFill.SetRectEmpty();
	m_rectSizing.SetRectEmpty();

	m_nProgressValue = -1;
	m_bInfiniteProgressMode = TRUE;

	CreateDocumentColors();
	CreateStyleList();
	CreateThemeList();
	CreateFontsList();

	CMFCPopupMenu::SetAnimationType(CMFCPopupMenu::SYSTEM_DEFAULT_ANIMATION);
}

CMainFrame::~CMainFrame()
{
	for (POSITION pos = m_TooltipImages.GetStartPosition(); pos != NULL;)
	{
		CMFCToolBarImages* pBmp = NULL;
		UINT uiID;

		m_TooltipImages.GetNextAssoc(pos, uiID, pBmp);
		delete pBmp;
	}
}

int CMainFrame::OnCreate(LPCREATESTRUCT lpCreateStruct)
{
	if (CFrameWndEx::OnCreate(lpCreateStruct) == -1)
		return -1;

	// Load background patterns:
	m_Pat[0].Create(CMFCControlRendererInfo(IDB_VIEWPAT_1, RGB(255, 0, 255), CRect(0, 0, 8, 8), CRect(0, 0, 0, 0)));
	m_Pat[1].Create(CMFCControlRendererInfo(IDB_VIEWPAT_2, RGB(255, 255, 255), CRect(0, 0, 499, 157), CRect(0, 0, 0, 0), CRect(480, 0, 0, 0), CRect(480, 0, 499, 157)));
	m_Pat[2].Create(CMFCControlRendererInfo(IDB_VIEWPAT_3, RGB(255, 255, 255), CRect(0, 0, 499, 157), CRect(0, 0, 0, 0), CRect(480, 0, 0, 0), CRect(480, 0, 499, 157)));
	m_Pat[3].Create(CMFCControlRendererInfo(IDB_VIEWPAT_4, RGB(255, 255, 255), CRect(0, 0, 499, 157), CRect(0, 0, 0, 0), CRect(480, 0, 0, 0), CRect(480, 0, 499, 157)));

	if (!CreateRibbonBar())
	{
		TRACE0("Failed to create ribbon bar\n");
		return -1;      // fail to create
	};

	if (!CreateStatusBar())
	{
		TRACE0("Failed to create status bar\n");
		return -1;      // fail to create
	}

	if (!CreateMessageBar())
	{
		TRACE0("Failed to create message bar\n");
	}

	// Create task pane:
	CRect rectDummy(0, 0, 200, 400);

	if (!m_wndTaskPane.Create(_T("Clipboard"), this, rectDummy, TRUE, ID_VIEW_TASK_PANE, WS_CHILD | WS_CLIPSIBLINGS | WS_CLIPCHILDREN | CBRS_LEFT | AFX_CBRS_CLOSE | AFX_CBRS_FLOAT))
	{
		TRACE0("Failed to create task pane\n");
		return -1;
	}

	m_wndTaskPane.EnableDocking(CBRS_ALIGN_RIGHT | CBRS_ALIGN_LEFT);
	DockPane(&m_wndTaskPane);

	EnableDocking(CBRS_ALIGN_ANY);

	OnChangeLayout();

	// Show progress bar after the short delay:
	SetTimer(IdStartProgressTimer, 500, NULL);

	// Start animation:
	CMFCRibbonStatusBarPane* pPane = DYNAMIC_DOWNCAST(CMFCRibbonStatusBarPane, m_wndStatusBar.FindElement(ID_STATUSBAR_SPELL));

	if (pPane != NULL)
	{
		pPane->StartAnimation(500 /* Frame delay*/, 5000 /* Duration */);
	}

	return 0;
}

void CMainFrame::SetKeys()
{
	m_MainButton.SetKeys(_T("f"));

	for (int i = 0; keys [i].uiCmd != 0; i++)
	{
		CString str = keys [i].lpszKey;

		int nAmpIndex = str.Find(_T('&'));

		if (nAmpIndex >= 0)
		{
			CString str1 = str.Left(nAmpIndex);
			CString str2 = str.Mid(nAmpIndex + 1);

			m_wndRibbonBar.SetElementKeys(keys [i].uiCmd, str1, str2);
		}
		else
		{
			m_wndRibbonBar.SetElementKeys(keys [i].uiCmd, str);
		}
	}
}

BOOL CMainFrame::PreCreateWindow(CREATESTRUCT& cs)
{
	if ( !CFrameWndEx::PreCreateWindow(cs) )
		return FALSE;

	cs.style |= WS_CLIPCHILDREN;
	return TRUE;
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

void CMainFrame::OnAppLook(UINT id)
{
	CWaitCursor wait;

	theApp.m_nAppLook = id;

	switch (theApp.m_nAppLook)
	{
	case ID_VIEW_APPLOOK_2003:
		CMFCVisualManager::SetDefaultManager(RUNTIME_CLASS(CMFCVisualManagerOffice2003));
		break;

	default:
		switch (theApp.m_nAppLook)
		{
		case ID_VIEW_APPLOOK_2007_1:
			CMFCVisualManagerOffice2007::SetStyle(CMFCVisualManagerOffice2007::Office2007_LunaBlue);
			break;

		case ID_VIEW_APPLOOK_2007_2:
			CMFCVisualManagerOffice2007::SetStyle(CMFCVisualManagerOffice2007::Office2007_ObsidianBlack);
			break;

		case ID_VIEW_APPLOOK_2007_3:
			CMFCVisualManagerOffice2007::SetStyle(CMFCVisualManagerOffice2007::Office2007_Aqua);
			break;

		case ID_VIEW_APPLOOK_2007_4:
			CMFCVisualManagerOffice2007::SetStyle(CMFCVisualManagerOffice2007::Office2007_Silver);
			break;
		}
		CMFCVisualManager::SetDefaultManager(RUNTIME_CLASS(CMFCVisualManagerOffice2007));
	}

	if (m_MemBitmap.GetSafeHandle() != NULL)
	{
		m_MemBitmap.DeleteObject();
	}

	RedrawWindow(NULL, NULL, RDW_ALLCHILDREN | RDW_INVALIDATE | RDW_UPDATENOW | RDW_FRAME | RDW_ERASE);

	theApp.WriteInt(_T("ApplicationLook"), theApp.m_nAppLook);
}

void CMainFrame::OnUpdateAppLook(CCmdUI* pCmdUI)
{
	pCmdUI->SetRadio(theApp.m_nAppLook == pCmdUI->m_nID);
}

BOOL CMainFrame::CreateRibbonBar()
{
	if (!m_wndRibbonBar.Create(this))
	{
		return -1;      // fail to create
	}

	// Load panel images:
	m_PanelImages.SetImageSize(CSize(16, 16));
	if (!m_PanelImages.Load(IDB_BUTTONS))
	{
		TRACE0("Failed to load panel images\n");
		return -1;
	}

	// Add main button:
	AddMainCategory();

	// Add tabs:
	AddTab_Home();
	AddTab_Insert();
	AddTab_PageLayout();
	AddTab_References();
	AddTab_Mailings();
	AddTab_Review();
	AddTab_View();

	if (theApp.m_bShowDevTab)
	{
		AddTab_Developer();
	}

	// Add context tabs:
	AddContextTab_Picture();
	AddContextTab_Chart();
	AddContextTab_Table();

	// Add quick access toolbar commands:
	CMFCRibbonQuickAccessToolBarDefaultState qatState;

	qatState.AddCommand(ID_FILE_NEW, FALSE);
	qatState.AddCommand(ID_FILE_OPEN, FALSE);
	qatState.AddCommand(ID_FILE_SAVE);
	qatState.AddCommand(ID_FILE_SEND_EMAIL, FALSE);
	qatState.AddCommand(ID_FILE_PRINT_DIRECT);
	qatState.AddCommand(ID_FILE_PRINT_PREVIEW, FALSE);
	qatState.AddCommand(ID_EDIT_UNDO);
	qatState.AddCommand(ID_TABLE_DRAWTABLE, FALSE);

	m_wndRibbonBar.SetQuickAccessDefaultState(qatState);

	// Add elements to the right side of tabs:
	CMFCRibbonButton* pVisualStyleButton = new CMFCRibbonButton(ID_SET_STYLE, _T("Style"), -1, -1);

	pVisualStyleButton->SetMenu(IDR_THEME_MENU, FALSE /* No default command */, TRUE /* Right align */);

	pVisualStyleButton->SetToolTipText(_T("Modify Visual Style"));
	pVisualStyleButton->SetDescription(_T("Choose one of the following looks:\r\nMS Office 2003 or MS Office 2007"));
	m_wndRibbonBar.AddToTabs(pVisualStyleButton);

	m_wndRibbonBar.AddToTabs(new CMFCRibbonButton(ID_APP_ABOUT, _T(""), m_PanelImages.ExtractIcon(0)));

	m_wndRibbonBar.EnableToolTips(theApp.m_bShowToolTips, theApp.m_bShowToolTipDescr);
	m_wndRibbonBar.EnableKeyTips(theApp.m_bShowKeyTips);

	SetKeys();

	return TRUE;
}

void CMainFrame::AddMainCategory()
{
	m_MainButton.SetImage(IDB_MAIN);
	m_MainButton.SetToolTipText(_T("Main Button"));
	m_MainButton.SetDescription(_T("Click here to see everything you can do with your document, including saving, printing or sharing it with others"));
	m_MainButton.SetID(ID_MAIN_BUTTON);

	m_wndRibbonBar.SetApplicationButton(&m_MainButton, CSize(45, 45));

	CMFCRibbonMainPanel* pMainPanel = m_wndRibbonBar.AddMainCategory(_T("Main Menu"), IDB_FILESMALL, IDB_FILELARGE);

	pMainPanel->Add(new CMFCRibbonButton(ID_FILE_NEW, _T("&New"), 0, 0));
	pMainPanel->Add(new CMFCRibbonButton(ID_FILE_OPEN, _T("&Open"), 1, 1));

	pMainPanel->Add(new CMFCRibbonButton(ID_FILE_SAVE, _T("&Save"), 2, 2));

	CMFCRibbonButton* pBtnSaveAs = new CMFCRibbonButton(ID_FILE_SAVE_AS, _T("Save &As"), 3, 3);
	pBtnSaveAs->AddSubItem(new CMFCRibbonLabel(_T("Save a copy of the document")));
	pBtnSaveAs->AddSubItem(new CMFCRibbonButton(ID_FILE_SAVE_AS_DOCUMENT, _T("&Word Document"), 9, 9, TRUE));
	pBtnSaveAs->AddSubItem(new CMFCRibbonButton(ID_FILE_SAVE_AS_TEMPLATE, _T("Word &Template"), 10, 10, TRUE));
	pBtnSaveAs->AddSubItem(new CMFCRibbonButton(ID_FILE_SAVE_AS_DOCUMENT_OLD, _T("Word &97-2003 Document"), 11, 11, TRUE));
	pBtnSaveAs->AddSubItem(new CMFCRibbonButton(ID_FILE_SAVE_AS_ADDINS, _T("&Find add-ins for other file formats"), 12, 12, TRUE));
	pBtnSaveAs->AddSubItem(new CMFCRibbonButton(ID_FILE_SAVE_AS_OTHER, _T("&Other Formats"), 3, 3, TRUE));
	pMainPanel->Add(pBtnSaveAs);

	pMainPanel->Add(new CMFCRibbonSeparator(TRUE));

	CMFCRibbonButton* pBtnPrint = new CMFCRibbonButton(ID_FILE_PRINT, _T("&Print"), 4, 4);
	pBtnPrint->AddSubItem(new CMFCRibbonLabel(_T("Preview and print the document")));
	pBtnPrint->AddSubItem(new CMFCRibbonButton(ID_FILE_PRINT, _T("&Print"), 4, 4, TRUE));
	pBtnPrint->AddSubItem(new CMFCRibbonButton(ID_FILE_PRINT_DIRECT, _T("&Quick Print"), 13, 13, TRUE));
	pBtnPrint->AddSubItem(new CMFCRibbonButton(ID_FILE_PRINT_PREVIEW, _T("Print Pre&view"), 14, 14, TRUE));
	pMainPanel->Add(pBtnPrint);

	CMFCRibbonButton* pBtnPrepare = new CMFCRibbonButton(ID_FILE_PREPARE, _T("Pr&epare"), 5, 5);
	pBtnPrepare->AddSubItem(new CMFCRibbonLabel(_T("Prepare the document for distribution")));
	pBtnPrepare->AddSubItem(new CMFCRibbonButton(ID_FILE_PREPARE_PROPERTIES, _T("&Properties"), 15, 15, TRUE));
	pBtnPrepare->AddSubItem(new CMFCRibbonButton(ID_FILE_PREPARE_INSPECT, _T("&Inspect Document"), 16, 16, TRUE));
	pBtnPrepare->AddSubItem(new CMFCRibbonButton(ID_FILE_PREPARE_ENCRYPT, _T("&Encrypt Document"), 17, 17, TRUE));
	pBtnPrepare->AddSubItem(new CMFCRibbonButton(ID_FILE_PREPARE_ADD_SIGNATURE, _T("Add a Digital &Signature"), 18, 18, TRUE));
	pBtnPrepare->AddSubItem(new CMFCRibbonButton(ID_FILE_PREPARE_MARK_AS_FINAL, _T("Mark as &Final"), 19, 19, TRUE));
	pBtnPrepare->SetDefaultCommand(FALSE);
	pMainPanel->Add(pBtnPrepare);

	CMFCRibbonButton* pBtnSend = new CMFCRibbonButton(ID_FILE_SEND, _T("Sen&d"), 6, 6);
	pBtnSend->AddSubItem(new CMFCRibbonLabel(_T("Send a copy of the document to other people")));
	pBtnSend->AddSubItem(new CMFCRibbonButton(ID_FILE_SEND_EMAIL, _T("&E-mail"), 21, 21, TRUE));
	pBtnSend->AddSubItem(new CMFCRibbonButton(ID_FILE_SEND_FAX, _T("Internet Fa&x"), 22, 22, TRUE));
	pBtnSend->SetDefaultCommand(FALSE);
	pMainPanel->Add(pBtnSend);

	CMFCRibbonButton* pBtnPublish = new CMFCRibbonButton(ID_FILE_PUBLISH, _T("P&ublish"), 7, 7);
	pBtnPublish->AddSubItem(new CMFCRibbonLabel(_T("Distribute the document to other people")));
	pBtnPublish->AddSubItem(new CMFCRibbonButton(ID_FILE_PUBLISH_BLOG, _T("&Blog"), 23, 23, TRUE));
	pBtnPublish->AddSubItem(new CMFCRibbonButton(ID_FILE_PUBLISH_DOCMANAGE_SERVER, _T("&Document Management Server"), 24, 24, TRUE));
	pBtnPublish->AddSubItem(new CMFCRibbonButton(ID_FILE_PUBLISH_CREATE_DOCWORKSPACE, _T("&Create Document Workspace"), 25, 25, TRUE));
	pBtnPublish->SetDefaultCommand(FALSE);
	pMainPanel->Add(pBtnPublish);

	pMainPanel->AddRecentFilesList(_T("Recent Documents"));

	pMainPanel->AddToBottom(new CMFCRibbonMainPanelButton(ID_TOOLS_OPTIONS, _T("Opt&ions"), 26));
	pMainPanel->AddToBottom(new CMFCRibbonMainPanelButton(ID_APP_EXIT, _T("E&xit"), 27));
}

void CMainFrame::AddTab_Home()
{
	// Create a new category(tab):
	CMFCRibbonCategory* pCategory = m_wndRibbonBar.AddCategory(_T("Home\nh"), IDB_WRITE, IDB_WRITELARGE);

	// Create "Clipboard" panel:
	// <snippet10>
	// CMFCRibbonCategory* pCategory
	// CMFCToolBarImages m_PanelImages
	CMFCRibbonPanel* pPanelClipboard = pCategory->AddPanel(_T("Clipboard"), m_PanelImages.ExtractIcon(1));
	pPanelClipboard->SetKeys(_T("zc"));
	pPanelClipboard->SetCenterColumnVert();
	pPanelClipboard->SetJustifyColumns();
	// </snippet10>

	CMFCRibbonButton* pBtnPaste = new CMFCRibbonButton(ID_EDIT_PASTE, _T("Paste"), 0, 0);
	pBtnPaste->SetMenu(IDR_WRITE_PASTE_MENU, TRUE);
	pPanelClipboard->Add(pBtnPaste);

	pPanelClipboard->Add(new CMFCRibbonButton(ID_EDIT_CUT, _T("Cut"), 1));
	pPanelClipboard->Add(new CMFCRibbonButton(ID_EDIT_COPY, _T("Copy"), 2));
	pPanelClipboard->Add(new CMFCRibbonButton(ID_EDIT_COPYFORMAT, _T("Format Painter"), 3));



	// Create "Font" panel:
	CMFCRibbonPanel* pPanelFont = pCategory->AddPanel(_T("Font"), m_PanelImages.ExtractIcon(2));
	pPanelFont->SetKeys(_T("zf"));

	// Create a new group with 2 elements: font name and font size:
	CMFCRibbonButtonsGroup* pFontGroup = new CMFCRibbonButtonsGroup;

	CMFCRibbonFontComboBox::m_bDrawUsingFont = TRUE;

	CMFCRibbonFontComboBox* pFontCombo = new CMFCRibbonFontComboBox(ID_FONT_FONT);
	pFontCombo->SetWidth(55, TRUE); // Width in "floaty" mode
	pFontCombo->SelectItem(10);
	pFontGroup->AddButton(pFontCombo);

	CMFCRibbonComboBox* pFontSizeCombo = new CMFCRibbonComboBox(ID_FONT_FONTSIZE, TRUE, 39);
	pFontSizeCombo->AddItem(_T("8"));
	pFontSizeCombo->AddItem(_T("9"));
	pFontSizeCombo->AddItem(_T("10"));
	pFontSizeCombo->AddItem(_T("11"));
	pFontSizeCombo->AddItem(_T("12"));
	pFontSizeCombo->AddItem(_T("14"));
	pFontSizeCombo->AddItem(_T("16"));
	pFontSizeCombo->AddItem(_T("18"));
	pFontSizeCombo->AddItem(_T("20"));
	pFontSizeCombo->AddItem(_T("22"));
	pFontSizeCombo->AddItem(_T("24"));
	pFontSizeCombo->AddItem(_T("26"));
	pFontSizeCombo->AddItem(_T("28"));
	pFontSizeCombo->AddItem(_T("36"));
	pFontSizeCombo->AddItem(_T("48"));
	pFontSizeCombo->AddItem(_T("72"));
	pFontSizeCombo->SetWidth(20, TRUE); // Width in "floaty" mode
	pFontSizeCombo->SelectItem(3);
	pFontGroup->AddButton(pFontSizeCombo);

	pPanelFont->Add(pFontGroup);

	// Add toolbar(all toolbar buttons will be automatically
	// converted to ribbon elements:
	pPanelFont->AddToolBar(IDR_FONT);

	// Add menu to ID_FONT_UNDERLINE element:
	pPanelFont->SetElementMenu(ID_FONT_UNDERLINE, IDR_DUMMY_MENU, TRUE);

	// Add menu to ID_FONT_CHANGECASE element:
	pPanelFont->SetElementMenu(ID_FONT_CHANGECASE, IDR_WRITE_FONTCASE_MENU);

	// Replace ID_FONT_COLOR and ID_FONT_TEXTHIGHLIGHT elements
	// by color pickers:
	CMFCRibbonColorButton* pFontColorBtn = new CMFCRibbonColorButton();
	pFontColorBtn->EnableAutomaticButton(_T("&Automatic"), RGB(0, 0, 0));
	pFontColorBtn->EnableOtherButton(_T("&More Colors..."), _T("More Colors"));
	pFontColorBtn->SetColumns(10);
	pFontColorBtn->SetColor(RGB(255, 0, 0));
	pFontColorBtn->SetColorBoxSize(CSize(17, 17));

	pFontColorBtn->AddColorsGroup(_T("Theme Colors"), m_lstMainColors);
	pFontColorBtn->AddColorsGroup(_T(""), m_lstAdditionalColors, TRUE /* Contiguous Columns*/);
	pFontColorBtn->AddColorsGroup(_T("Standard Colors"), m_lstStandardColors);

	pPanelFont->ReplaceByID(ID_FONT_COLOR, pFontColorBtn);

	CMFCRibbonColorButton* pFontColorHighlightBtn = new CMFCRibbonColorButton();
	pFontColorHighlightBtn->SetColor(RGB(255, 255, 255));
	pFontColorHighlightBtn->EnableAutomaticButton(_T("&No Color"), RGB(240, 240, 240), TRUE, NULL, FALSE /* Bottom */, TRUE /* Draw border */);

	pPanelFont->ReplaceByID(ID_FONT_TEXTHIGHLIGHT, pFontColorHighlightBtn);

	pFontColorHighlightBtn->SetColorBoxSize(CSize(26, 26));
	pFontColorHighlightBtn->AddSubItem(new CMFCRibbonButton(ID_STOP_HIGHLIGHTING, _T("&Stop Highlighting")));

	// Create "Paragraph" panel:
	CMFCRibbonPanel* pPanelParagraph = pCategory->AddPanel(_T("Paragraph"), m_PanelImages.ExtractIcon(3));
	pPanelParagraph->SetKeys(_T("zp"));

	pPanelParagraph->AddToolBar(IDR_PARAGRAPH);

	// Attach palette to "Bullets" button:
	CMFCRibbonGallery* pPaletteBullet = new CMFCRibbonGallery(ID_PARA_BULLETS, _T(""), -1, -1);

	pPanelParagraph->ReplaceByID(ID_PARA_BULLETS, pPaletteBullet);
	InitBulletPalette(pPaletteBullet);
	pPaletteBullet->EnableMenuResize();

	// Attach palette to "Numbering" button:
	CMFCRibbonGallery* pPaletteNum = new CMFCRibbonGallery(ID_PARA_NUMBERING, _T(""), -1, -1);

	pPanelParagraph->ReplaceByID(ID_PARA_NUMBERING, pPaletteNum);
	InitNumberingPalette(pPaletteNum);
	pPaletteNum->EnableMenuResize();

	// Attach palette to "Multilevel" button:
	CMFCRibbonGallery* pPaletteMulti = new CMFCRibbonGallery(ID_PARA_MULTILEVEL, _T(""), -1, -1);

	pPanelParagraph->ReplaceByID(ID_PARA_MULTILEVEL, pPaletteMulti);
	InitMultilevelPalette(pPaletteMulti);
	pPaletteMulti->EnableMenuResize();
	pPaletteMulti->SetDefaultCommand(FALSE);

	pPanelParagraph->SetElementMenu(ID_PARA_LINESPACING, IDR_PARA_LINESPACING_MENU);

	CMFCRibbonColorButton* pParaColorBtn = new CMFCRibbonColorButton();
	pParaColorBtn->EnableOtherButton(_T("&More Colors..."), _T("More Shading Colors"));
	pParaColorBtn->SetColor(RGB(255, 255, 255));

	pParaColorBtn->SetColumns(10);
	pParaColorBtn->AddColorsGroup(_T("Theme Colors"), m_lstMainColors);
	pParaColorBtn->AddColorsGroup(_T(""), m_lstAdditionalColors, TRUE /* Contiguous Columns*/);
	pParaColorBtn->AddColorsGroup(_T("Standard Colors"), m_lstStandardColors);
	pParaColorBtn->SetColorBoxSize(CSize(17, 17));
	pParaColorBtn->EnableAutomaticButton(_T("&No Color"), RGB(240, 240, 240), TRUE, NULL, FALSE /* Bottom */, TRUE);

	pPanelParagraph->ReplaceByID(ID_PARA_SHADING, pParaColorBtn);

	// Add menu to ID_PARA_BORDER element:
	pPanelParagraph->SetElementMenu(ID_PARA_BORDER, IDR_WRITE_BORDERS_MENU, TRUE);

	// Create "Styles" panel:
	CMFCRibbonPanel* pPanelStyle = pCategory->AddPanel(_T("Styles"), m_PanelImages.ExtractIcon(4));
	pPanelStyle->SetKeys(_T("zs"));

	CMFCRibbonGallery* pStyleBtn = new CMFCRibbonGallery(ID_WRITE_QUICKSTYLES, _T("Quick Styles"), 9, 1, IDB_STYLES, 64);
	pStyleBtn->AddSubItem(new CMFCRibbonButton(ID_WRITE_SAVESTYLE, _T("Save Selection as a New &Quick Style..."), -1, -1));
	pStyleBtn->AddSubItem(new CMFCRibbonButton(ID_WRITE_CLEARFORMATTING, _T("&Clear Formatting"), 8, -1));
	pStyleBtn->AddSubItem(new CMFCRibbonButton(ID_WRITE_APPLYSTYLES, _T("&Apply Styles"), 9, -1));
	for (int i = 0; i < m_arStyles.GetSize(); i++)
	{
		pStyleBtn->SetItemToolTip(i, m_arStyles [i]);
	}

	pStyleBtn->EnableMenuResize();
	pPanelStyle->Add(pStyleBtn);

	CMFCRibbonButton* pStyleChangeBtn = new CMFCRibbonButton(ID_WRITE_CHANGESTYLES, _T("Change Styles"), 9, 2);

	CRibbonListButton* pStyleSetPalette = new CRibbonListButton(ID_STYLECHANGE_STYLESET, _T("St&yle Set"), 32, -1);
	pStyleSetPalette->AddGroup(_T(""), 0, 0, m_arStyleSets);
	pStyleSetPalette->AddSubItem(new CMFCRibbonButton(0, _T("&Reset to Quick Styles from Template")));
	pStyleSetPalette->EnableMenuResize(TRUE, TRUE); // Vertical only
	pStyleSetPalette->EnableMenuSideBar();

	pStyleChangeBtn->AddSubItem(pStyleSetPalette);

	CRibbonListButton* pColorsPalette = new CRibbonListButton(ID_STYLECHANGE_COLORS, _T("&Colors"), 33, -1);
	pColorsPalette->AddGroup(_T("Built-In"), IDB_THEME_COLORS, 103, m_arColorThemes);
	pColorsPalette->AddSubItem(new CMFCRibbonButton(ID_PAGELAYOUT_COLORS_CREATENEWTHEMECOLORS, _T("&Create New Theme Colors...")));
	pColorsPalette->EnableMenuResize(TRUE, TRUE); // Vertical only

	pStyleChangeBtn->AddSubItem(pColorsPalette);

	CRibbonListFontButton* pFontsPalette = new CRibbonListFontButton(ID_STYLECHANGE_FONTS, _T("&Fonts"), 34, -1);
	pFontsPalette->AddGroup(_T("Built-In"), IDB_THEME_FONTS, 43, m_arFonts);
	pFontsPalette->AddSubItem(new CMFCRibbonButton(ID_PAGELAYOUT_FONTS_CREATENEWTHEMEFONTS, _T("&Create New Theme Fonts...")));
	pFontsPalette->EnableMenuResize(TRUE, TRUE); // Vertical only

	pStyleChangeBtn->AddSubItem(pFontsPalette);

	pStyleChangeBtn->SetAlwaysLargeImage();
	pStyleChangeBtn->SetDefaultCommand(FALSE);

	pPanelStyle->Add(pStyleChangeBtn);

	// Create "Editing" panel:
	CMFCRibbonPanel* pPanelEdit = pCategory->AddPanel(_T("Editing"), m_PanelImages.ExtractIcon(5));
	pPanelEdit->SetKeys(_T("zn"));

	CMFCRibbonButton* pFindBtn = new CMFCRibbonButton(ID_EDIT_FIND, _T("Find"), 4);
	pFindBtn->SetMenu(IDR_WRITE_FIND_MENU);
	pFindBtn->SetDefaultCommand(ID_EDIT_FIND);
	pPanelEdit->Add(pFindBtn);

	pPanelEdit->Add(new CMFCRibbonButton(ID_EDIT_REPLACE, _T("Replace"), 5));

	CMFCRibbonButton* pFindSelectBtn = new CMFCRibbonButton(ID_WRITE_SELECT, _T("Select"), 7);
	pFindSelectBtn->SetMenu(IDR_WRITE_SELECT_MENU);
	pPanelEdit->Add(pFindSelectBtn);

	// Add some hidden elements:
	pCategory->AddHidden(new CMFCRibbonUndoButton(ID_EDIT_UNDO, _T("Undo"), 10));

	pCategory->AddHidden(new CMFCRibbonUndoButton(ID_EDIT_FIND, _T("Find"), 4));
	pCategory->AddHidden(new CMFCRibbonUndoButton(ID_EDIT_GOTO, _T("Go To"), 6));

	pCategory->AddHidden(new CMFCRibbonButton(ID_EDIT_PASTE_SPECIAL, _T("Paste Special"), 11));
	pCategory->AddHidden(new CMFCRibbonButton(ID_EDIT_PASTE_HYPERLINK, _T("Paste as Hyperlink"), 12));

	pCategory->AddHidden(new CMFCRibbonButton(ID_PARA_CHANGE_LIST_LEVEL, _T("Change List Level"), 13));

	pCategory->AddHidden(new CMFCRibbonButton(ID_PARA_LINESPACINGBEFORE, _T("Add Space Before Paragraph"), 14));
	pCategory->AddHidden(new CMFCRibbonButton(ID_PARA_LINESPACINGAFTER, _T("Remove Space After Paragraph"), 15));

	pCategory->AddHidden(new CMFCRibbonButton(ID_BORDERS_BOTTOMBORDER, _T("&Bottom Border"), 16));
	pCategory->AddHidden(new CMFCRibbonButton(ID_BORDERS_TOPBORDER, _T("To&p Border"), 17));
	pCategory->AddHidden(new CMFCRibbonButton(ID_BORDERS_LEFTBORDER, _T("&Left Border"), 18));
	pCategory->AddHidden(new CMFCRibbonButton(ID_BORDERS_RIGHTBORDER, _T("&Right Border"), 19));
	pCategory->AddHidden(new CMFCRibbonButton(ID_BORDERS_NOBORDER, _T("&No Border"), 20));
	pCategory->AddHidden(new CMFCRibbonButton(ID_BORDERS_ALLBORDERS, _T("&All Borders"), 21));
	pCategory->AddHidden(new CMFCRibbonButton(ID_BORDERS_OUTSIDEBORDERS, _T("Out&side Borders"), 22));
	pCategory->AddHidden(new CMFCRibbonButton(ID_BORDERS_INSIDEBORDERS, _T("&Inside Borders"), 23));
	pCategory->AddHidden(new CMFCRibbonButton(ID_BORDERS_INSIDEHORIZONTALBORDER, _T("Inside &Horizontal Border"), 24));
	pCategory->AddHidden(new CMFCRibbonButton(ID_BORDERS_INSIDEVERTICALBORDER, _T("Inside &Vertical Border"), 25));
	pCategory->AddHidden(new CMFCRibbonButton(ID_BORDERS_DIAGONALDOWNBORDER, _T("Diagonal Do&wn Border"), 26));
	pCategory->AddHidden(new CMFCRibbonButton(ID_BORDERS_DIAGONALUPBORDER, _T("Diagonal &Up Border"), 27));
	pCategory->AddHidden(new CMFCRibbonButton(ID_BORDERS_HORIZONTALLINE, _T("Hori&zontal Line"), 28));
	pCategory->AddHidden(new CMFCRibbonButton(ID_TABLE_DRAWTABLE, _T("&Draw Table"), 29));
	pCategory->AddHidden(new CMFCRibbonButton(ID_BORDERS_VIEWGRIDLINES, _T("View &Gridlines"), 30));
	pCategory->AddHidden(new CMFCRibbonButton(ID_BORDERS_BORDERSANDSHADING, _T("B&orders and Shading..."), 31));

	pCategory->AddHidden(new CMFCRibbonButton(ID_EDIT_SELECT_ALL, _T("Select All"), 35));
	pCategory->AddHidden(new CMFCRibbonButton(ID_EDIT_SELECTOBJECTS, _T("Select Objects"), 7));

	// Pane collapsing fine tuning:
	CArray<int, int> arCollapseOrder;

	arCollapseOrder.Add(pCategory->GetPanelIndex(pPanelStyle));
	arCollapseOrder.Add(pCategory->GetPanelIndex(pPanelClipboard));
	arCollapseOrder.Add(pCategory->GetPanelIndex(pPanelStyle));
	arCollapseOrder.Add(pCategory->GetPanelIndex(pPanelStyle));
	arCollapseOrder.Add(pCategory->GetPanelIndex(pPanelEdit));
	arCollapseOrder.Add(pCategory->GetPanelIndex(pPanelParagraph));
	arCollapseOrder.Add(pCategory->GetPanelIndex(pPanelFont));
	arCollapseOrder.Add(pCategory->GetPanelIndex(pPanelStyle));
	arCollapseOrder.Add(pCategory->GetPanelIndex(pPanelStyle));
	arCollapseOrder.Add(pCategory->GetPanelIndex(pPanelParagraph));
	arCollapseOrder.Add(pCategory->GetPanelIndex(pPanelFont));

	pCategory->SetCollapseOrder(arCollapseOrder);
}

void CMainFrame::AddTab_Insert()
{
	CMFCRibbonCategory* pCategory = m_wndRibbonBar.AddCategory(_T("Insert\nn"), IDB_INSERT, IDB_INSERTLARGE);

	CMFCRibbonPanel* pPanelPages = pCategory->AddPanel(_T("Pages"), m_PanelImages.ExtractIcon(6));

	pPanelPages->SetKeys(_T("zp"));

	CMFCRibbonButton* pInsertCoverPageBtn = new CMFCRibbonButton(ID_INSERT_COVERPAGE, _T("Cover Page"), 0, 0);
	pInsertCoverPageBtn->SetMenu(IDR_INSERT_COVERPAGE_MENU);
	pPanelPages->Add(pInsertCoverPageBtn);

	pPanelPages->Add(new CMFCRibbonButton(ID_INSERT_BLACKPAGE, _T("Blank Page"), 1, 1));
	pPanelPages->Add(new CMFCRibbonButton(ID_INSERT_PAGEBREAK, _T("Page Break"), 2, 2));

	CMFCRibbonPanel* pPanelInsertTable = pCategory->AddPanel(_T("Tables"), m_PanelImages.ExtractIcon(7));
	pPanelInsertTable->SetKeys(_T("zt"));

	CRibbonTableButton* pTableMenuBtn = new CRibbonTableButton(ID_INSERT_TABLE, _T("Table"), 3, 3);
	pTableMenuBtn->SetMenu(IDR_INSERT_TABLE_MENU);
	pTableMenuBtn->SetPaletteID(ID_FROM_PALETTE_TABLE);
	pTableMenuBtn->SetButtonMode();
	pPanelInsertTable->Add(pTableMenuBtn);

	CMFCRibbonPanel* pPanelIllustrations = pCategory->AddPanel(_T("Illustrations"), m_PanelImages.ExtractIcon(8));
	pPanelIllustrations->SetKeys(_T("zi"));

	CMFCRibbonButton* pInsertPictureBtn = new CMFCRibbonButton(ID_INSERT_PICTURE, _T("Picture"), 4, 4);
	pPanelIllustrations->Add(pInsertPictureBtn);
	pPanelIllustrations->Add(new CMFCRibbonButton(ID_INSERT_CLIPART, _T("Clip Art"), 5, 5));

	CMFCRibbonGallery* pInsertShapesBtn = new CMFCRibbonGallery(ID_INSERT_SHAPES, _T("Shapes"), 6, 6);
	pInsertShapesBtn->SetButtonMode();
	pInsertShapesBtn->SetIconsInRow(12);

	pInsertShapesBtn->AddGroup(_T("Recently Used Shapes"), IDB_SHAPE1, 20);
	pInsertShapesBtn->AddGroup(_T("Lines"), IDB_SHAPE2, 20);
	pInsertShapesBtn->AddGroup(_T("Basic Shapes"), IDB_SHAPE3, 20);
	pInsertShapesBtn->AddGroup(_T("Block Arrows"), IDB_SHAPE4, 20);
	pInsertShapesBtn->AddGroup(_T("Flowchart"), IDB_SHAPE5, 20);
	pInsertShapesBtn->AddGroup(_T("Callouts"), IDB_SHAPE6, 20);
	pInsertShapesBtn->AddGroup(_T("Stars and Banners"), IDB_SHAPE7, 20);

	pInsertShapesBtn->AddSubItem(new CMFCRibbonButton(ID_INSERT_SHAPESNEW, _T("&New Drawing Canvas"), 29, -1));

	pPanelIllustrations->Add(pInsertShapesBtn);
	pPanelIllustrations->Add(new CMFCRibbonButton(ID_INSERT_SMARTART, _T("SmartArt"), 7, 7));
	pPanelIllustrations->Add(new CMFCRibbonButton(ID_INSERT_CHART, _T("Chart"), 8, 8));

	CMFCRibbonPanel* pPanelLinks = pCategory->AddPanel(_T("Links"), m_PanelImages.ExtractIcon(9));
	pPanelLinks->SetKeys(_T("zl"));

	pPanelLinks->Add(new CMFCRibbonButton(ID_INSERT_HYPERLINK, _T("Hyperlink"), 9, 9));
	pPanelLinks->Add(new CMFCRibbonButton(ID_INSERT_BOOKMARK, _T("Bookmark"), 10, 10));
	pPanelLinks->Add(new CMFCRibbonButton(ID_INSERT_REFERENCE, _T("Cross-reference"), 11, 11));

	CMFCRibbonPanel* pPanelHeaderFooter = pCategory->AddPanel(_T("Header & Footer"), m_PanelImages.ExtractIcon(10));
	pPanelHeaderFooter->SetKeys(_T("zh"));

	CMFCRibbonButton* pInsertHeaderBtn = new CMFCRibbonButton(ID_INSERT_HEADER, _T("Header"), 12, 12);
	pInsertHeaderBtn->SetMenu(IDR_INSERT_HEADER_MENU);
	pPanelHeaderFooter->Add(pInsertHeaderBtn);

	CMFCRibbonButton* pInsertFooterBtn = new CMFCRibbonButton(ID_INSERT_FOOTER, _T("Footer"), 13, 13);
	pInsertFooterBtn->SetMenu(IDR_INSERT_FOOTER_MENU);
	pPanelHeaderFooter->Add(pInsertFooterBtn);

	CMFCRibbonButton* pInsertPageNumbersBtn = new CMFCRibbonButton(ID_INSERT_PAGENUMBER, _T("Page Number"), 14, 14);
	pInsertPageNumbersBtn->SetMenu(IDR_INSERT_PAGENUMBERS_MENU);
	pPanelHeaderFooter->Add(pInsertPageNumbersBtn);

	CMFCRibbonPanel* pPanelText = pCategory->AddPanel(_T("Text"), m_PanelImages.ExtractIcon(11));
	pPanelText->SetKeys(_T("zt"));

	CMFCRibbonButton* pTextBoxBtn = new CMFCRibbonButton(ID_INSERT_TEXTBOX, _T("Text Box"), 15, 15);
	pTextBoxBtn->SetMenu(IDR_INSERT_TEXTBOX_MENU);
	pPanelText->Add(pTextBoxBtn);

	pPanelText->Add(new CMFCRibbonButton(ID_INSERT_QUICKPARTS, _T("Quick Parts"), 16, 16));
	pPanelText->Add(new CMFCRibbonButton(ID_INSERT_WORDART, _T("WordArt"), 17, 17));
	pPanelText->Add(new CMFCRibbonButton(ID_INSERT_DROPCAP, _T("Drop Cap"), 18, 18));
	pPanelText->Add(new CMFCRibbonButton(ID_INSERT_SIGNATURELINE, _T("Signature Line"), 19));
	pPanelText->Add(new CMFCRibbonButton(ID_INSERT_DATETIME, _T("Date && Time"), 20));
	pPanelText->Add(new CMFCRibbonButton(ID_INSERT_OBJECT, _T("Object"), 21));

	pPanelText->SetElementMenu(ID_INSERT_QUICKPARTS, IDR_DUMMY_MENU);
	pPanelText->SetElementMenu(ID_INSERT_WORDART, IDR_DUMMY_MENU);
	pPanelText->SetElementMenu(ID_INSERT_DROPCAP, IDR_DUMMY_MENU);
	pPanelText->SetElementMenu(ID_INSERT_SIGNATURELINE, IDR_DUMMY_MENU, TRUE);
	pPanelText->SetElementMenu(ID_INSERT_OBJECT, IDR_DUMMY_MENU, TRUE);

	CMFCRibbonPanel* pPanelSymbols = pCategory->AddPanel(_T("Symbols"), m_PanelImages.ExtractIcon(12));
	pPanelSymbols->SetKeys(_T("zs"));

	pPanelSymbols->Add(new CMFCRibbonButton(ID_INSERT_EQUATION, _T("Equation"), 22, 19));
	pPanelSymbols->Add(new CMFCRibbonButton(ID_INSERT_SYMBOL, _T("Symbol"), 23, 20));

	// pPanelSymbols->SetElementMenu(ID_INSERT_EQUATION, IDR_DUMMY_MENU, TRUE);
	pPanelSymbols->SetElementMenu(ID_INSERT_SYMBOL, IDR_DUMMY_MENU);

	pCategory->AddHidden(new CMFCRibbonButton(ID_INSERT_REMOVECURRENTCOVERPAGE, _T("Remove Current Cover Page"), 24));
	pCategory->AddHidden(new CMFCRibbonButton(ID_INSERT_SAVETOCOVERPAGEGALLERY, _T("Save Selection to Cover Page Gallery"), 25));

	pCategory->AddHidden(new CMFCRibbonButton(ID_TABLE_TABLE, _T("Insert Table"), 3));
	pCategory->AddHidden(new CMFCRibbonButton(ID_TABLE_DRAWTABLE, _T("Draw Table"), 26));
	pCategory->AddHidden(new CMFCRibbonButton(ID_TABLE_CONVERTTOTABLE, _T("Convert to Table"), 27));
	pCategory->AddHidden(new CMFCRibbonButton(ID_TABLE_EXCELSPREADSHEET, _T("Excel Spreadsheet"), 28));
	pCategory->AddHidden(new CMFCRibbonButton(ID_TABLE_QUICKTABLES, _T("Quick Tables"), 3));

	pCategory->AddHidden(new CMFCRibbonButton(ID_INSERT_EDITHEADER, _T("Edit Header"), 12));
	pCategory->AddHidden(new CMFCRibbonButton(ID_INSERT_REMOVEHEADER, _T("Remove Header"), 30));
	pCategory->AddHidden(new CMFCRibbonButton(ID_INSERT_SAVESELECTIONTOHEADERGALLERY, _T("Save Selection to Header Gallery"), 31));

	pCategory->AddHidden(new CMFCRibbonButton(ID_INSERT_EDITFOOTER, _T("Edit Footer"), 13));
	pCategory->AddHidden(new CMFCRibbonButton(ID_INSERT_REMOVEFOOTER, _T("Remove Footer"), 32));
	pCategory->AddHidden(new CMFCRibbonButton(ID_INSERT_SAVESELECTIONTOFOOTERGALLERY, _T("Save Selection to Footer Gallery"), 33));

	pCategory->AddHidden(new CMFCRibbonButton(ID_INSERT_TOPOFPAGE, _T("Top of Page"), 34));
	pCategory->AddHidden(new CMFCRibbonButton(ID_INSERT_BOTTOMOFPAGE, _T("Bottom of Page"), 35));
	pCategory->AddHidden(new CMFCRibbonButton(ID_INSERT_PAGEMARGINS, _T("Page Margins"), 36));
	pCategory->AddHidden(new CMFCRibbonButton(ID_INSERT_CURRENTPOSITION, _T("Current Position"), 14));
	pCategory->AddHidden(new CMFCRibbonButton(ID_INSERT_FORMATPAGENUMBERS, _T("Format Page Numbers"), 37));
	pCategory->AddHidden(new CMFCRibbonButton(ID_INSERT_REMOVEPAGENUMBERS, _T("Remove Page Numbers"), 38));

	pCategory->AddHidden(new CMFCRibbonButton(ID_INSERT_DRAWTEXTBOX, _T("Draw Text Box"), 15));
	pCategory->AddHidden(new CMFCRibbonButton(ID_INSERT_SAVESELECTIONTOTEXTBOXGALLERY, _T("Save Selection to Text Box Gallery"), 39));

	// Pane collapsing fine tuning:
	CArray<int, int> arCollapseOrder;

	arCollapseOrder.Add(pCategory->GetPanelIndex(pPanelLinks));
	arCollapseOrder.Add(pCategory->GetPanelIndex(pPanelSymbols));
	arCollapseOrder.Add(pCategory->GetPanelIndex(pPanelPages));
	arCollapseOrder.Add(pCategory->GetPanelIndex(pPanelText));
	arCollapseOrder.Add(pCategory->GetPanelIndex(pPanelHeaderFooter));
	arCollapseOrder.Add(pCategory->GetPanelIndex(pPanelIllustrations));
	arCollapseOrder.Add(pCategory->GetPanelIndex(pPanelText));
	arCollapseOrder.Add(pCategory->GetPanelIndex(pPanelLinks));
	arCollapseOrder.Add(pCategory->GetPanelIndex(pPanelPages));
	arCollapseOrder.Add(pCategory->GetPanelIndex(pPanelSymbols));
	arCollapseOrder.Add(pCategory->GetPanelIndex(pPanelIllustrations));
	arCollapseOrder.Add(pCategory->GetPanelIndex(pPanelText)); // Setting -1 to the next index
	arCollapseOrder.Add(-1); // means force panel collapse
	arCollapseOrder.Add(pCategory->GetPanelIndex(pPanelHeaderFooter));
	arCollapseOrder.Add(pCategory->GetPanelIndex(pPanelIllustrations));

	pCategory->SetCollapseOrder(arCollapseOrder);
}

void CMainFrame::AddTab_PageLayout()
{
	CMFCRibbonCategory* pCategory = m_wndRibbonBar.AddCategory(_T("Page Layout\np"), IDB_PAGELAYOUT, IDB_PAGELAYOUTLARGE);

	CMFCRibbonPanel* pPanelThemes = pCategory->AddPanel(_T("Themes\nzt"), m_PanelImages.ExtractIcon(13));

	CRibbonListButton* pListBtn = new CRibbonListButton(ID_PAGELAYOUT_THEMES, _T("Themes\nth"), 23, 0, FALSE);
	pListBtn->AddGroup(_T("Built-In"), IDB_THEME_THEMES, 64, m_arThemes);
	pListBtn->AddSubItem(new CMFCRibbonButton(ID_PAGELAYOUT_THEMES_RESETFROMTEMPLATE, _T("&Reset to Theme from Template")));
	pListBtn->AddSubItem(new CMFCRibbonButton(ID_PAGELAYOUT_THEMES_MORETHEMES, _T("More Themes on Microsoft &Office Online...")));
	pListBtn->AddSubItem(new CMFCRibbonButton(ID_PAGELAYOUT_THEMES_BROWSEFORTHEMES, _T("&Browse for Themes..."), 24));
	pListBtn->AddSubItem(new CMFCRibbonButton(ID_PAGELAYOUT_THEMES_SAVECURRENTTHEME, _T("&Save Current Theme..."), 25));
	pListBtn->SetIconsInRow(4);
	pListBtn->EnableMenuResize();
	pPanelThemes->Add(pListBtn);

	pListBtn = new CRibbonListButton(ID_PAGELAYOUT_COLORS, _T("Colors\ntc"), 0, -1);
	pListBtn->AddGroup(_T("Built-In"), IDB_THEME_COLORS, 103, m_arColorThemes);
	pListBtn->AddSubItem(new CMFCRibbonButton(ID_PAGELAYOUT_COLORS_CREATENEWTHEMECOLORS, _T("&Create New Theme Colors...")));
	pListBtn->EnableMenuResize(TRUE, TRUE); // Vertical only
	pPanelThemes->Add(pListBtn);

	CRibbonListFontButton* pFontsBtn = new CRibbonListFontButton(ID_PAGELAYOUT_FONTS, _T("Fonts\ntf"), 1, -1);
	pFontsBtn->AddGroup(_T("Built-In"), IDB_THEME_FONTS, 43, m_arFonts);
	pFontsBtn->AddSubItem(new CMFCRibbonButton(ID_PAGELAYOUT_FONTS_CREATENEWTHEMEFONTS, _T("&Create New Theme Fonts...")));
	pFontsBtn->EnableMenuResize(TRUE, TRUE); // Vertical only
	pPanelThemes->Add(pFontsBtn);

	pListBtn = new CRibbonListButton(ID_PAGELAYOUT_EFFECTS, _T("Effects\nte"), 2, -1, FALSE);
	pListBtn->AddGroup(_T("Built-In"), IDB_THEME_EFFECTS, 64, m_arThemes);
	pListBtn->SetIconsInRow(4);
	pListBtn->EnableMenuResize();
	pPanelThemes->Add(pListBtn);

	CMFCRibbonPanel* pPanelPageSetup = pCategory->AddPanel(_T("Page Setup\nzs"), m_PanelImages.ExtractIcon(14));

	CMFCRibbonButton* pBtn = new CMFCRibbonButton(ID_PAGELAYOUT_MARGINS, _T("Margins\nm"), 3, 1);
	pBtn->SetMenu(IDR_PAGELAYOUT_MARGINS);
	pPanelPageSetup->Add(pBtn);

	pBtn = new CMFCRibbonButton(ID_PAGELAYOUT_ORIENTATION, _T("Orientation\no"), 4, 2);
	pBtn->SetMenu(IDR_PAGELAYOUT_ORIENTATION);
	pPanelPageSetup->Add(pBtn);

	pPanelPageSetup->Add(new CMFCRibbonButton(ID_PAGELAYOUT_PAGESETUP_SIZE, _T("Size\nsz"), 5, 3));
	pPanelPageSetup->SetElementMenu(ID_PAGELAYOUT_PAGESETUP_SIZE, IDR_DUMMY_MENU);

	pBtn = new CMFCRibbonButton(ID_PAGELAYOUT_COLUMNS, _T("Columns\nj"), 6, 4);
	pBtn->SetMenu(IDR_PAGELAYOUT_COLUMNS);
	pPanelPageSetup->Add(pBtn);

	pPanelPageSetup->Add(new CMFCRibbonButton(ID_PAGELAYOUT_PAGESETUP_BREAKS, _T("Breaks\nb"), 7, -1));
	pPanelPageSetup->Add(new CMFCRibbonButton(ID_PAGELAYOUT_PAGESETUP_LINENUMBERS, _T("Line Numbers\nln"), 8, -1));
	pPanelPageSetup->Add(new CMFCRibbonButton(ID_PAGELAYOUT_PAGESETUP_HYPHENATION, _T("Hyphenation\nh"), 9, -1));

	pPanelPageSetup->SetElementMenu(ID_PAGELAYOUT_PAGESETUP_BREAKS, IDR_DUMMY_MENU);
	pPanelPageSetup->SetElementMenu(ID_PAGELAYOUT_PAGESETUP_LINENUMBERS, IDR_DUMMY_MENU);
	pPanelPageSetup->SetElementMenu(ID_PAGELAYOUT_PAGESETUP_HYPHENATION, IDR_DUMMY_MENU);

	CMFCRibbonPanel* pPanelPageBackground = pCategory->AddPanel(_T("Page Background\nzb"), m_PanelImages.ExtractIcon(15));

	pPanelPageBackground->Add(new CMFCRibbonButton(ID_PAGELAYOUT_PAGEBACKGROUND_WATERMARK, _T("Watermark\npw"), 10, 5));

	CMFCRibbonColorButton* pPageBackBtn = new CMFCRibbonColorButton(ID_PAGELAYOUT_PAGEBACKGROUND_PAGECOLOR, _T("Page Color\npc"), TRUE, 11, 6);

	pPageBackBtn->EnableOtherButton(_T("&More Colors..."), _T("More Shading Colors"));
	pPageBackBtn->SetColor(RGB(240, 240, 240));
	pPageBackBtn->SetDefaultCommand(FALSE);
	pPageBackBtn->SetColumns(10);
	pPageBackBtn->AddColorsGroup(_T("Theme Colors"), m_lstMainColors);
	pPageBackBtn->AddColorsGroup(_T(""), m_lstAdditionalColors, TRUE /* Contiguous Columns*/);
	pPageBackBtn->AddColorsGroup(_T("Standard Colors"), m_lstStandardColors);
	pPageBackBtn->SetColorBoxSize(CSize(17, 17));
	pPageBackBtn->EnableAutomaticButton(_T("&No Color"), RGB(255, 255, 255), TRUE, NULL, FALSE /* Bottom */);

	pPanelPageBackground->Add(pPageBackBtn);

	pPanelPageBackground->Add(new CMFCRibbonButton(ID_PAGELAYOUT_PAGEBACKGROUND_PAGEBORDERS, _T("Page Borders\npb"), 12, 7));
	pPanelPageBackground->SetElementMenu(ID_PAGELAYOUT_PAGEBACKGROUND_WATERMARK, IDR_DUMMY_MENU);

	CMFCRibbonPanel* pPanelParagraph = pCategory->AddPanel(_T("Paragraph\nzg"), m_PanelImages.ExtractIcon(16));

	pPanelParagraph->Add(new CMFCRibbonLabel(_T("Indent")));

	// <snippet7>
	CMFCRibbonEdit* pEditIndentLeft = new CMFCRibbonEdit(ID_PAGELAYOUT_INDENT_LEFT, 72, _T("Left:\nil"), 13);
	// specify the min and max value of the spin button control
	pEditIndentLeft->EnableSpinButtons(0, 1000);
	// set the text of the edit control
	pEditIndentLeft->SetEditText(_T("0"));
	// </snippet7>
	pPanelParagraph->Add(pEditIndentLeft);

	CMFCRibbonEdit* pEditIndentRight = new CMFCRibbonEdit(ID_PAGELAYOUT_INDENT_RIGHT, 72, _T("Right:\nir"), 14);
	pEditIndentRight->EnableSpinButtons(0, 1000);
	pEditIndentRight->SetEditText(_T("0"));
	pPanelParagraph->Add(pEditIndentRight);

	pPanelParagraph->AddSeparator();

	pPanelParagraph->Add(new CMFCRibbonLabel(_T("Spacing")));

	CMFCRibbonEdit* pEditSpaceBefore = new CMFCRibbonEdit(ID_PAGELAYOUT_SPACE_BEFORE, 72, _T("Before:\nsb"), 15);
	pEditSpaceBefore->EnableSpinButtons(0, 100);
	pEditSpaceBefore->SetEditText(_T("0"));
	pPanelParagraph->Add(pEditSpaceBefore);

	CMFCRibbonEdit* pEditSpaceAfter = new CMFCRibbonEdit(ID_PAGELAYOUT_SPACE_AFTER, 72, _T("After:\nsa"), 16);
	pEditSpaceAfter->EnableSpinButtons(0, 100);
	pEditSpaceAfter->SetEditText(_T("0"));
	pPanelParagraph->Add(pEditSpaceAfter);

	pPanelParagraph->SetJustifyColumns();

	CMFCRibbonPanel* pPanelArrange = AddPanelArrange(pCategory, 17, 17, 8);

	pCategory->AddHidden(new CMFCRibbonButton(ID_PAGELAYOUT_COLUMNS_MORECOLUMNS, _T("More Columns"), 6));

	pCategory->AddHidden(new CMFCRibbonButton(ID_PAGELAYOUT_BRINGFORWARD, _T("Bring Forward"), 26));
	pCategory->AddHidden(new CMFCRibbonButton(ID_PAGELAYOUT_BRINGINFRONTOFTEXT, _T("Bring in Front of Text"), 27));
	pCategory->AddHidden(new CMFCRibbonButton(ID_PAGELAYOUT_SENDBACKWARD, _T("Send Backward"), 28));
	pCategory->AddHidden(new CMFCRibbonButton(ID_PAGELAYOUT_SENDBEHINDTEXT, _T("Send Behind Text"), 29));

	pCategory->AddHidden(new CMFCRibbonButton(ID_PAGELAYOUT_TEXTWRAPPING_INLINEWITHTEXT, _T("In Line With Text"), 30));
	pCategory->AddHidden(new CMFCRibbonButton(ID_PAGELAYOUT_TEXTWRAPPING_SQUARE, _T("Square"), 31));
	pCategory->AddHidden(new CMFCRibbonButton(ID_PAGELAYOUT_TEXTWRAPPING_TIGHT, _T("Tight"), 32));
	pCategory->AddHidden(new CMFCRibbonButton(ID_PAGELAYOUT_TEXTWRAPPING_BEHINDTEXT, _T("Behind Text"), 33));
	pCategory->AddHidden(new CMFCRibbonButton(ID_PAGELAYOUT_TEXTWRAPPING_INFRONTOFTEXT, _T("In Front of Text"), 34));
	pCategory->AddHidden(new CMFCRibbonButton(ID_PAGELAYOUT_TEXTWRAPPING_TOPANDBOTTOM, _T("Top and Bottom"), 35));
	pCategory->AddHidden(new CMFCRibbonButton(ID_PAGELAYOUT_TEXTWRAPPING_THROUGH, _T("Through"), 36));
	pCategory->AddHidden(new CMFCRibbonButton(ID_PAGELAYOUT_TEXTWRAPPING_EDITWRAPPOINTS, _T("Edit Wrap Points"), 37));
	pCategory->AddHidden(new CMFCRibbonButton(ID_PAGELAYOUT_MORELAYOUTOPTIONS, _T("More Layout Options"), 38));

	// Pane collapsing fine tuning:
	CArray<int, int> arCollapseOrder;

	arCollapseOrder.Add(pCategory->GetPanelIndex(pPanelArrange));
	arCollapseOrder.Add(pCategory->GetPanelIndex(pPanelThemes));
	arCollapseOrder.Add(pCategory->GetPanelIndex(pPanelPageBackground));
	arCollapseOrder.Add(pCategory->GetPanelIndex(pPanelPageSetup));
	arCollapseOrder.Add(pCategory->GetPanelIndex(pPanelParagraph));
	arCollapseOrder.Add(pCategory->GetPanelIndex(pPanelArrange));
	arCollapseOrder.Add(pCategory->GetPanelIndex(pPanelPageSetup));
	arCollapseOrder.Add(pCategory->GetPanelIndex(pPanelArrange)); // Setting -1 to the next index
	arCollapseOrder.Add(-1); // means force panel collapse
	arCollapseOrder.Add(pCategory->GetPanelIndex(pPanelParagraph));
	arCollapseOrder.Add(pCategory->GetPanelIndex(pPanelThemes));
	arCollapseOrder.Add(pCategory->GetPanelIndex(pPanelPageBackground));
	arCollapseOrder.Add(pCategory->GetPanelIndex(pPanelPageSetup));
	arCollapseOrder.Add(-1);

	pCategory->SetCollapseOrder(arCollapseOrder);
}

void CMainFrame::AddTab_References()
{
	CMFCRibbonCategory* pCategory = m_wndRibbonBar.AddCategory(_T("References\ns"), IDB_REFERENCES, IDB_REFERENCESLARGE);

	CMFCRibbonPanel* pPanelRef_TC = pCategory->AddPanel(_T("Table of Contents\nzc"), m_PanelImages.ExtractIcon(18));

	CMFCRibbonButton* pBtn = new CMFCRibbonButton(ID_TABLE_OF_CONTENTS, _T("Table of Contents\nt"), 12, 0);
	pBtn->SetMenu(IDR_DUMMY_MENU);
	pPanelRef_TC->Add(pBtn);

	pBtn = new CMFCRibbonButton(ID_REFERENCES_ADDTEXT, _T("Add Text\na"), 0, -1);
	pBtn->SetMenu(IDR_REFERENCES_ADDTEXT);
	pPanelRef_TC->Add(pBtn);

	pPanelRef_TC->Add(new CMFCRibbonButton(ID_REFERENCES_TC_UPDATETABLE, _T("Update Table\nu"), 1, -1));

	CMFCRibbonPanel* pPanelRef_Footnotes = pCategory->AddPanel(_T("Footnotes\nzf"), m_PanelImages.ExtractIcon(19));

	pPanelRef_Footnotes->Add(new CMFCRibbonButton(ID_REFERENCES_FOOTNOTES_INSERTFOOTNOTE, _T("Insert Footnote\nf"), 13, 1));
	pPanelRef_Footnotes->Add(new CMFCRibbonButton(ID_REFERENCES_FOOTNOTES_INSERTENDNOTE, _T("Insert Endnote\ne"), 2, -1));

	pBtn = new CMFCRibbonButton(ID_REFERENCES_FOOTNOTE_NEXT, _T("Next Footnote\no"), 3, -1);
	pBtn->SetMenu(IDR_REFERENCES_NEXTFOOTNOTE, TRUE);
	pPanelRef_Footnotes->Add(pBtn);

	pPanelRef_Footnotes->Add(new CMFCRibbonButton(ID_REFERENCES_FOOTNOTES_SHOWNOTES, _T("Show Notes\nh"), 4, -1));

	CMFCRibbonPanel* pPanelRef_CB = pCategory->AddPanel(_T("Citations & Bibliography\nzb"), m_PanelImages.ExtractIcon(20));

	pBtn = new CMFCRibbonButton(ID_INSERT_CITATION, _T("Insert Citation\nc"), 14, 2);
	pBtn->SetMenu(IDR_REFERENCES_INSERTCITATION);
	pPanelRef_CB->Add(pBtn);

	pPanelRef_CB->Add(new CMFCRibbonButton(ID_REFERENCES_CB_MANAGESOURCES, _T("Manage Sources\nm"), 5, -1));

	// Add "Style" combo:
	CMFCRibbonComboBox* pStyleCombo = new CMFCRibbonComboBox(ID_REFERENCES_STYLE, TRUE, 45, _T("Style: \nl"), 6);

	pStyleCombo->AddItem(_T("APA"));
	pStyleCombo->AddItem(_T("Style 1"));
	pStyleCombo->AddItem(_T("Style 2"));
	pStyleCombo->AddItem(_T("Style 3"));
	pStyleCombo->AddItem(_T("Style 4"));
	pStyleCombo->SelectItem(0);
	pStyleCombo->EnableDropDownListResize(FALSE);

	pPanelRef_CB->Add(pStyleCombo);

	pPanelRef_CB->Add(new CMFCRibbonButton(ID_REFERENCES_CB_INSERTBIBLIOGRAPHY, _T("Bibliography\nb"), 7, -1));
	pPanelRef_CB->SetElementMenu(ID_REFERENCES_CB_INSERTBIBLIOGRAPHY, IDR_DUMMY_MENU);

	CMFCRibbonPanel* pPanelRef_Captions = pCategory->AddPanel(_T("Captions\nzp"), m_PanelImages.ExtractIcon(21));

	pPanelRef_Captions->Add(new CMFCRibbonButton(ID_REFERENCES_CAPTIONS_INSERTCAPTION, _T("Insert Caption\np"), 15, 3));
	pPanelRef_Captions->Add(new CMFCRibbonButton(ID_REFERENCES_CAPTIONS_INSERTTOF, _T("Insert Table of Figures\ng"), 8, -1));
	pPanelRef_Captions->Add(new CMFCRibbonButton(ID_REFERENCES_CAPTIONS_UPDATETABLE, _T("Update Table\nv"), 1, -1));
	pPanelRef_Captions->Add(new CMFCRibbonButton(ID_REFERENCES_CAPTIONS_CROSSREFERENCE, _T("Cross-reference\nrf"), 9, -1));

	CMFCRibbonPanel* pPanelRef_Index = pCategory->AddPanel(_T("Index\nzi"), m_PanelImages.ExtractIcon(22));

	pPanelRef_Index->Add(new CMFCRibbonButton(ID_REFERENCES_INDEX_MARKENTRY, _T("Mark Entry\nn"), 16, 4));
	pPanelRef_Index->Add(new CMFCRibbonButton(ID_REFERENCES_INDEX_INSERTINDEX, _T("Insert Index\nx"), 10, -1));
	pPanelRef_Index->Add(new CMFCRibbonButton(ID_REFERENCES_INDEX_UPDATEINDEX, _T("Update Index\nd"), 1, -1));

	CMFCRibbonPanel* pPanelRef_TA = pCategory->AddPanel(_T("Table of Authorities\nza"), m_PanelImages.ExtractIcon(23));

	pPanelRef_TA->Add(new CMFCRibbonButton(ID_REFERENCES_TA_MARKCITATION, _T("Mark Citation\ni"), 17, 5));
	pPanelRef_TA->Add(new CMFCRibbonButton(ID_REFERENCES_TA_INSERTTOA, _T("Insert Table of Authorities\nrt"), 11, -1));
	pPanelRef_TA->Add(new CMFCRibbonButton(ID_REFERENCES_TA_UPDATETABLE, _T("Update Table\nru"), 1, -1));
}

void CMainFrame::AddTab_Mailings()
{
	CMFCRibbonCategory* pCategory = m_wndRibbonBar.AddCategory(_T("Mailings\nm"), IDB_MAILINGS, IDB_MAILINGSLARGE);

	CMFCRibbonPanel* pPanelCreate = pCategory->AddPanel(_T("Create\nzc"), m_PanelImages.ExtractIcon(24));

	pPanelCreate->Add(new CMFCRibbonButton(ID_MAILINGS_CREATE, _T("Envelopes\ne"), 0, 0));
	pPanelCreate->Add(new CMFCRibbonButton(ID_MAILINGS_CREATELABELS, _T("Labels\nl"), 1, 1));

	CMFCRibbonPanel* pPanelStartMerge = pCategory->AddPanel(_T("Start Mail Merge\nzs"), m_PanelImages.ExtractIcon(25));

	CMFCRibbonButton* pMailMergeMenuBtn = new CMFCRibbonButton(ID_MAILINGS_STARTMAILMERGE, _T("Start Mail Merge\ns"), 2, 2);
	pMailMergeMenuBtn->SetMenu(IDR_MAIL_MERGE_MENU);
	pPanelStartMerge->Add(pMailMergeMenuBtn);

	CMFCRibbonButton* pSelectRecipientMenuBtn = new CMFCRibbonButton(ID_MAILINGS_SELECTRECIPIENTS, _T("Select Recipients\nr"), 3, 3);
	pSelectRecipientMenuBtn->SetMenu(IDR_MAIL_RECIPIENTS_MENU);
	pPanelStartMerge->Add(pSelectRecipientMenuBtn);

	pPanelStartMerge->Add(new CMFCRibbonButton(ID_MAILINGS_EDITRECIPIENTLIST, _T("Edit Recipient List\nd"), 4, 4));

	CMFCRibbonPanel* pPanelWriteFields = pCategory->AddPanel(_T("Write & Insert Fields\nzw"), m_PanelImages.ExtractIcon(26));

	pPanelWriteFields->Add(new CMFCRibbonButton(ID_MAILINGS_HIGHLIGHT, _T("Highlight Merge Fields\nh"), 5, 5));
	pPanelWriteFields->Add(new CMFCRibbonButton(ID_MAILINGS_ADDRESSBLOCK, _T("Address Block\na"), 6, 6));
	pPanelWriteFields->Add(new CMFCRibbonButton(ID_MAILINGS_GREATINGLINE, _T("Greating Line\ng"), 7, 7));
	pPanelWriteFields->Add(new CMFCRibbonButton(ID_MAILINGS_INSERTMERGEDFIELD, _T("Insert Merge Field\ni"), 8, 8));
	pPanelWriteFields->Add(new CMFCRibbonButton(ID_MAILINGS_RULES, _T("Rules\nu"), 9));
	pPanelWriteFields->Add(new CMFCRibbonButton(ID_MAILINGS_MATCHFIELDS, _T("Match Fields\nt"), 10));
	pPanelWriteFields->Add(new CMFCRibbonButton(ID_MAILINGS_UPDATELABELS, _T("Update Labels\nb"), 11));

	pPanelWriteFields->SetElementMenu(ID_MAILINGS_INSERTMERGEDFIELD, IDR_DUMMY_MENU, TRUE);

	CMFCRibbonPanel* pPanelReview = pCategory->AddPanel(_T("Preview Results\nzp"), m_PanelImages.ExtractIcon(27));

	pPanelReview->Add(new CMFCRibbonButton(ID_MAILINGS_VIEWMERGEDDATA, _T("Preview Results\np"), 12, 9));
	pPanelReview->AddSeparator();

	CMFCRibbonButtonsGroup* pButtonsListRecords = new CMFCRibbonButtonsGroup;

	pButtonsListRecords->AddButton(new CMFCRibbonButton(ID_MAILINGS_FIRSTRECORD, _T("\nq"), 16));
	pButtonsListRecords->AddButton(new CMFCRibbonButton(ID_MAILINGS_PREVIOUSRECORD, _T("\nm"), 17));

	CMFCRibbonEdit* pEdit = new CMFCRibbonEdit(ID_MAILINGS_GOTORECORD, 40);
	pEdit->SetKeys(_T("w"));
	pButtonsListRecords->AddButton(pEdit);

	pButtonsListRecords->AddButton(new CMFCRibbonButton(ID_MAILINGS_NEXTRECORD, _T("\nx"), 18));
	pButtonsListRecords->AddButton(new CMFCRibbonButton(ID_MAILINGS_LASTRECORD, _T("\nv"), 19));

	pPanelReview->Add(pButtonsListRecords);

	pPanelReview->Add(new CMFCRibbonButton(ID_MAILINGS_FINDRECIPIENT, _T("Find Recipient\nj"), 13));
	pPanelReview->Add(new CMFCRibbonButton(ID_MAILINGS_AUTOCHECHERRORS, _T("Auto Check for Errors\nk"), 14));

	CMFCRibbonPanel* pPanelFinish = pCategory->AddPanel(_T("Finish\nzf"), m_PanelImages.ExtractIcon(28));
	pPanelFinish->Add(new CMFCRibbonButton(ID_MAILINGS_FINISH, _T("Finish && Merge\nf"), 15, 10));

	pCategory->AddHidden(new CMFCRibbonButton(ID_MAILINGS_TYPENEWLIST, _T("Type New List..."), 27));
	pCategory->AddHidden(new CMFCRibbonButton(ID_MAILINGS_USEEXISTINGLIST, _T("Use Existing List..."), 28));
	pCategory->AddHidden(new CMFCRibbonButton(ID_MAILINGS_SELECTFROMCONTACTS, _T("Select from Contacts..."), 29));

	pCategory->AddHidden(new CMFCRibbonButton(ID_MAILINGS_LETTERS, _T("Letters"), 20));
	pCategory->AddHidden(new CMFCRibbonButton(ID_MAILINGS_EMAILMESSAGES, _T("E-mail Messages"), 21));
	pCategory->AddHidden(new CMFCRibbonButton(ID_MAILINGS_ENVELOPES, _T("Envelops..."), 22));
	pCategory->AddHidden(new CMFCRibbonButton(ID_MAILINGS_LABELS, _T("Labels..."), 23));
	pCategory->AddHidden(new CMFCRibbonButton(ID_MAILINGS_DIRECTORY, _T("Directory"), 24));
	pCategory->AddHidden(new CMFCRibbonButton(ID_MAILINGS_NORMALDOCUMENT, _T("Normal Document"), 25));
	pCategory->AddHidden(new CMFCRibbonButton(ID_MAILINGS_STEPBYSTEPMAILMERGEWIZARD, _T("Step by Step Mail Merge Wizard..."), 26));
}

void CMainFrame::AddTab_Review()
{
	CMFCRibbonCategory* pCategory = m_wndRibbonBar.AddCategory(_T("Review\nr"), IDB_REVIEW, IDB_REVIEWLARGE);

	CMFCRibbonPanel* pPanelProofing = pCategory->AddPanel(_T("Proofing\np"), m_PanelImages.ExtractIcon(29));

	pPanelProofing->Add(new CMFCRibbonButton(ID_REVIEW_PROOFING_SPELLINGGRAMMAR, _T("Spelling && Grammar\ns"), 0, 0));
	pPanelProofing->Add(new CMFCRibbonButton(ID_REVIEW_PROOFING_RESEARCH, _T("Research\nr"), 1, 1));
	pPanelProofing->Add(new CMFCRibbonButton(ID_REVIEW_PROOFING_THESAURUS, _T("Thesaurus\ne"), 2, 2));
	pPanelProofing->Add(new CMFCRibbonButton(ID_REVIEW_PROOFING_TRANSLATE, _T("Translate\nl"), 3, 3));
	pPanelProofing->Add(new CMFCRibbonButton(ID_REVIEW_PROOFING_TRANSLATIONSCREENTIP, _T("Translation ScreenTip\npt"), 4, -1));
	pPanelProofing->Add(new CMFCRibbonButton(ID_REVIEW_PROOFING_SETLANGUAGE, _T("Set Language\nu"), 5, -1));
	pPanelProofing->Add(new CMFCRibbonButton(ID_REVIEW_PROOFING_WORDCOUNT, _T("Word Count\nw"), 6, -1));

	pPanelProofing->SetElementMenu(ID_REVIEW_PROOFING_TRANSLATIONSCREENTIP, IDR_DUMMY_MENU);

	CMFCRibbonPanel* pPanelComments = pCategory->AddPanel(_T("Comments\nc"), m_PanelImages.ExtractIcon(30));

	pPanelComments->Add(new CMFCRibbonButton(ID_REVIEW_COMMENTS_NEWCOMMENT, _T("New Comment\nc"), 7, 4));

	CMFCRibbonButton* pDeleteBtn = new CMFCRibbonButton(ID_REVIEW_COMMENTS_DELETE, _T("Delete\nd"), 8, 5);
	pDeleteBtn->SetMenu(IDR_REVIEW_COMMENTS_DELETE, TRUE);
	pPanelComments->Add(pDeleteBtn);

	pPanelComments->Add(new CMFCRibbonButton(ID_REVIEW_COMMENTS_PREVIOUS, _T("Previous\nv"), 9, 6));
	pPanelComments->Add(new CMFCRibbonButton(ID_REVIEW_COMMENTS_NEXT, _T("Next\nn"), 10, 7));

	CMFCRibbonPanel* pPanelTracking = pCategory->AddPanel(_T("Tracking\nt"), m_PanelImages.ExtractIcon(31));

	CMFCRibbonButton* pTCButton = new CMFCRibbonButton(ID_REVIEW_TRACKING_TRACKCHANGES, _T("Track Changes\ng"), 11, 8);
	pTCButton->SetMenu(IDR_REVIEW_TRACKING_TRACKCHANGES, TRUE);
	pTCButton->SetAlwaysLargeImage();
	pPanelTracking->Add(pTCButton);

	CMFCRibbonButton* pBalloonsBtn = new CMFCRibbonButton(ID_REVIEW_TRACKING_BALLOONS, _T("Balloons\ntb"), 12, 9);
	pBalloonsBtn->SetMenu(IDR_REVIEW_TRACKING_BALLOONS);
	pBalloonsBtn->SetAlwaysLargeImage();
	pPanelTracking->Add(pBalloonsBtn);

	CMFCRibbonComboBox* pDisplayCombo = new CMFCRibbonComboBox(ID_REVIEW_TRACKING_DISPLAYFORREVIEW, FALSE, 149, NULL, 13);
	pDisplayCombo->EnableDropDownListResize(FALSE);
	pDisplayCombo->AddItem(_T("Final Showing Markup"));
	pDisplayCombo->AddItem(_T("Final"));
	pDisplayCombo->AddItem(_T("Original Showing Markup"));
	pDisplayCombo->AddItem(_T("Original"));
	pDisplayCombo->SelectItem(0);
	pDisplayCombo->SetKeys(_T("td"));
	pPanelTracking->Add(pDisplayCombo);

	CMFCRibbonButton* pShowBtn = new CMFCRibbonButton(ID_REVIEW_TRACKING_SHOW_MARKUP, _T("Show Markup\ntm"), 14, -1);
	pShowBtn->SetMenu(IDR_REVIEW_TRACKING_SHOW);
	pPanelTracking->Add(pShowBtn);

	CMFCRibbonButton* pPaneBtn = new CMFCRibbonButton(ID_REVIEW_TRACKING_REVIEWINGPANE, _T("Reviewing Pane\ntp"), 15, -1);
	pPaneBtn->SetMenu(IDR_REVIEW_TRACKING_REVIEWINGPANE, TRUE);
	pPanelTracking->Add(pPaneBtn);

	CMFCRibbonPanel* pPanelChanges = pCategory->AddPanel(_T("Changes\nh"), m_PanelImages.ExtractIcon(32));

	pPanelChanges->SetCenterColumnVert();

	CMFCRibbonButton* pAcceptBtn = new CMFCRibbonButton(ID_REVIEW_CHANGES_ACCEPT, _T("Accept\na"), 16, 10);
	pAcceptBtn->SetMenu(IDR_REVIEW_CHANGES_ACCEPT, TRUE);
	pPanelChanges->Add(pAcceptBtn);

	CMFCRibbonButton* pRejectBtn = new CMFCRibbonButton(ID_REVIEW_CHANGES_REJECT, _T("Reject\nj"), 17, 11);
	pRejectBtn->SetMenu(IDR_REVIEW_CHANGES_REJECT, TRUE);
	pPanelChanges->Add(pRejectBtn);

	pPanelChanges->Add(new CMFCRibbonButton(ID_REVIEW_CHANGES_PREVIOUS, _T("Previous\nf"), 18, -1));
	pPanelChanges->Add(new CMFCRibbonButton(ID_REVIEW_CHANGES_NEXT, _T("Next\nh"), 19, -1));

	CMFCRibbonPanel* pPanelCompare = pCategory->AddPanel(_T("Compare\nm"), m_PanelImages.ExtractIcon(33));

	CMFCRibbonButton* pCompareBtn = new CMFCRibbonButton(ID_REVIEW_COMPARE_COMPARE, _T("Compare\nm"), 20, 12);
	pCompareBtn->SetMenu(IDR_REVIEW_COMPARE_COMPARE_COMPARE);
	pPanelCompare->Add(pCompareBtn);

	CMFCRibbonButton* pShowSrcBtn = new CMFCRibbonButton(ID_REVIEW_COMPARE_SHOWSOURCE, _T("Show Source Documents\no"), 21, 13);
	pShowSrcBtn->SetMenu(IDR_REVIEW_COMPARE_SHOWSOURCE);
	pPanelCompare->Add(pShowSrcBtn);

	CMFCRibbonPanel* pPanelProtect = pCategory->AddPanel(_T("Protect\nr"), m_PanelImages.ExtractIcon(34));

	pPanelProtect->Add(new CMFCRibbonButton(ID_REVIEW_PROTECT, _T("Protect Document\npr"), 22, 14));

	pCategory->AddHidden(new CMFCRibbonButton(ID_REVIEW_TRACKING_REVIEWINGPANE_VERTICAL, _T("Reviewing Pane Vertical\nrv"), 15));
	pCategory->AddHidden(new CMFCRibbonButton(ID_REVIEW_TRACKING_REVIEWINGPANE_HORIZONTAL, _T("Reviewing Pane Horizontal\nrh"), 23));
	pCategory->AddHidden(new CMFCRibbonButton(ID_REVIEW_CHANGES_ACCEPT_CHANGE, _T("Accept Change\nac"), 16));
	pCategory->AddHidden(new CMFCRibbonButton(ID_REVIEW_CHANGES_REJECT_CHANGE, _T("Reject Change\nrc"), 17));

	pCategory->AddHidden(new CMFCRibbonButton(ID_REVIEW_COMPARE_COMPARE_COMPARE, _T("Compare\ncp"), 24));
	pCategory->AddHidden(new CMFCRibbonButton(ID_REVIEW_COMPARE_COMPARE_COMBINE, _T("Combine\ncb"), 25));
}

void CMainFrame::AddTab_View()
{
	CMFCRibbonCategory* pCategory = m_wndRibbonBar.AddCategory(_T("View\nw"), IDB_VIEW, IDB_VIEWLARGE);

	CMFCRibbonPanel* pPanelDocViews = pCategory->AddPanel(_T("Document Views\nzv"), m_PanelImages.ExtractIcon(35));

	pPanelDocViews->Add(new CMFCRibbonButton(ID_VIEW_PRINTLAYOUT, _T("Print Layout\np"), 7, 0));
	pPanelDocViews->Add(new CMFCRibbonButton(ID_VIEW_FULLSCREEN, _T("Full Screen Reading\nf"), 4, 1));
	pPanelDocViews->Add(new CMFCRibbonButton(ID_VIEW_WEBLAYOUT, _T("Web Layout\nl"), 12, 2));
	pPanelDocViews->Add(new CMFCRibbonButton(ID_VIEW_OUTLINE, _T("Outline\nu"), 6, 3));
	pPanelDocViews->Add(new CMFCRibbonButton(ID_VIEW_DRAFT, _T("Draft\ne"), 3, 4));

	CMFCRibbonPanel* pPanelShowHide = pCategory->AddPanel(_T("Show/Hide\nzs"), m_PanelImages.ExtractIcon(36));

	pPanelShowHide->Add(new CMFCRibbonCheckBox(ID_VIEW_RULER, _T("Ruler\nr")));
	pPanelShowHide->Add(new CMFCRibbonCheckBox(ID_VIEW_GRIDLINES, _T("Gridlines\ng")));
	pPanelShowHide->Add(new CMFCRibbonCheckBox(ID_VIEW_MESSAGEBAR, _T("Message Bar\nd")));
	pPanelShowHide->Add(new CMFCRibbonCheckBox(ID_VIEW_DOCUMENTMAP, _T("Document Map\nvm")));
	pPanelShowHide->Add(new CMFCRibbonCheckBox(ID_VIEW_TRUMBNAILS, _T("Thumbnails\nh")));

	CMFCRibbonPanel* pPanelZoom = pCategory->AddPanel(_T("Zoom\nzz"), m_PanelImages.ExtractIcon(37));

	pPanelZoom->Add(new CMFCRibbonButton(ID_VIEW_ZOOM, _T("Zoom\nq"), 13, 5));
	pPanelZoom->Add(new CMFCRibbonButton(ID_VIEW_ZOOM_100, _T("100%\nj"), 2, 10));
	pPanelZoom->Add(new CMFCRibbonButton(ID_VIEW_ZOOM_ONE_PAGE, _T("One Page\n1"), 14));
	pPanelZoom->Add(new CMFCRibbonButton(ID_VIEW_ZOOM_TWO_PAGES, _T("Two Pages\n2"), 15));
	pPanelZoom->Add(new CMFCRibbonButton(ID_VIEW_ZOOM_PAGE_WIDTH, _T("Page Width\ni"), 16));

	CMFCRibbonPanel* pPanelWindow = pCategory->AddPanel(_T("Window\nzw"), m_PanelImages.ExtractIcon(38));

	pPanelWindow->Add(new CMFCRibbonButton(ID_VIEW_NEWWINDOW, _T("New Window\nn"), 5, 6));
	pPanelWindow->Add(new CMFCRibbonButton(ID_VIEW_ARRANGEALL, _T("Arrange All\na"), 0, 7));
	pPanelWindow->Add(new CMFCRibbonButton(ID_VIEW_SPLIT, _T("Split\ns"), 9, 8));
	pPanelWindow->AddSeparator();
	pPanelWindow->Add(new CMFCRibbonButton(ID_VIEW_COMPARE, _T("View Side by Side\nb"), 11));
	pPanelWindow->Add(new CMFCRibbonButton(ID_VIEW_SYNCSCROLLING, _T("Synchronous Scrolling\nvs"), 10));
	pPanelWindow->Add(new CMFCRibbonButton(ID_VIEW_RESETWINDOW, _T("Reset Window Position\nt"), 8));
	pPanelWindow->AddSeparator();

	CMFCRibbonButton* pWindowsBtn = new CMFCRibbonButton(ID_VIEW_SWITCHWINDOW, _T("Switch Windows\nw"), 1, 9);
	pWindowsBtn->SetAlwaysLargeImage();
	pWindowsBtn->SetMenu(IDR_DUMMY_MENU);
	pPanelWindow->Add(pWindowsBtn);

	CMFCRibbonPanel* pPanelMacros = pCategory->AddPanel(_T("Macros\nzm"), m_PanelImages.ExtractIcon(39));
	pPanelMacros->Add(new CMFCRibbonButton(ID_VIEW_MACROS, _T("Macros\nm"), -1, 11));

	// Pane collapsing fine tuning:
	CArray<int, int> arCollapseOrder;

	arCollapseOrder.Add(pCategory->GetPanelIndex(pPanelWindow));
	arCollapseOrder.Add(pCategory->GetPanelIndex(pPanelDocViews));
	arCollapseOrder.Add(pCategory->GetPanelIndex(pPanelWindow));
	arCollapseOrder.Add(pCategory->GetPanelIndex(pPanelZoom));
	arCollapseOrder.Add(pCategory->GetPanelIndex(pPanelShowHide));
	arCollapseOrder.Add(pCategory->GetPanelIndex(pPanelZoom));
	arCollapseOrder.Add(pCategory->GetPanelIndex(pPanelWindow));
	arCollapseOrder.Add(-1); // Force PanelWindow collapse
	arCollapseOrder.Add(pCategory->GetPanelIndex(pPanelDocViews));
	arCollapseOrder.Add(-1); // Force PanelDocViews collapse

	pCategory->SetCollapseOrder(arCollapseOrder);
}

void CMainFrame::AddTab_Developer()
{
	CMFCRibbonCategory* pCategory = m_wndRibbonBar.AddCategory(_T("Developer\nl"), 0, 0);

	pCategory->SetData(idTabDeveloper);
}

void CMainFrame::OnGetMinMaxInfo(MINMAXINFO FAR* lpMMI)
{
	CFrameWndEx::OnGetMinMaxInfo(lpMMI);

	ASSERT(lpMMI != NULL);

	lpMMI->ptMinTrackSize.y = GetSystemMetrics(SM_CXFIXEDFRAME) * 3 + GetSystemMetrics(SM_CYCAPTION);

	lpMMI->ptMinTrackSize.x = GetSystemMetrics(SM_CYCAPTION) * 2 + GetSystemMetrics(SM_CXFIXEDFRAME) * 2 + GetSystemMetrics(SM_CXSIZE) * 3;
}

CMFCToolBarImages* CMainFrame::GetTooltipImage(UINT uiID)
{
	if (!theApp.m_bShowToolTipDescr)
	{
		return NULL;
	}

	UINT uiResID = 0;

	switch (uiID)
	{
	case ID_MAIN_BUTTON:
		uiResID = IDB_TOOLTIP_MAIN;
		break;

	case ID_WRITE_CLIPBOARD:
		uiResID = IDB_TOOLTIP_CLIPBOARD;
		break;

	case ID_WRITE_FONT:
		uiResID = IDB_TOOLTIP_FONTDLG;
		break;

	case ID_WRITE_PARAGRAPH:
		uiResID = IDB_TOOLTIP_PARAGRAPH;
		break;
	}

	if (uiResID == 0)
	{
		return NULL;
	}

	CMFCToolBarImages* pBmp = NULL;

	if (!m_TooltipImages.Lookup(uiID, pBmp))
	{
		pBmp = new CMFCToolBarImages;
		pBmp->Load(uiResID);
		pBmp->SetSingleImage();

		m_TooltipImages.SetAt(uiID, pBmp);
	}

	return pBmp;
}

void CMainFrame::AdjustClientArea()
{
	if (m_pPrintPreviewFrame != NULL)
	{
		CFrameWndEx::AdjustClientArea();
		return;
	}

	CWnd* pChildWnd = GetDlgItem(AFX_IDW_PANE_FIRST);
	if (pChildWnd != NULL)
	{
		CRect rectClientAreaBounds = m_dockManager.GetClientAreaBounds();

		rectClientAreaBounds.left += m_rectBorder.left;
		rectClientAreaBounds.top  += m_rectBorder.top;
		rectClientAreaBounds.right -= m_rectBorder.right;
		rectClientAreaBounds.bottom -= m_rectBorder.bottom;

		if (rectClientAreaBounds.Width() > 100 && rectClientAreaBounds.Height() > 100)
		{
			m_rectFill = rectClientAreaBounds;
			rectClientAreaBounds.DeflateRect(40, 20, 40, 20);
		}
		else
		{
			m_rectFill.SetRectEmpty();
		}

		pChildWnd->CalcWindowRect(rectClientAreaBounds);

		if (!pChildWnd->IsKindOf(RUNTIME_CLASS(CSplitterWnd)))
		{
			pChildWnd->ModifyStyle(0, WS_CLIPCHILDREN | WS_CLIPSIBLINGS);

			if (!m_rectFill.IsRectEmpty())
			{
				pChildWnd->ModifyStyleEx(WS_EX_CLIENTEDGE, 0);
				pChildWnd->ModifyStyle(0, WS_BORDER);
			}
		}
		else
		{
			pChildWnd->ModifyStyle(0, WS_CLIPSIBLINGS);
		}

		pChildWnd->SetWindowPos(&wndBottom, rectClientAreaBounds.left, rectClientAreaBounds.top, rectClientAreaBounds.Width(), rectClientAreaBounds.Height(), SWP_NOACTIVATE);
	}

	if (!m_rectFill.IsRectEmpty())
	{
		RedrawWindow(m_rectFill);
	}
}

void CMainFrame::OnPaint()
{
	if (m_rectFill.IsRectEmpty())
	{
		Default();
		return;
	}

	CPaintDC dc(this); // device context for painting

	CRect rectChild;
	rectChild.SetRectEmpty();

	CWnd* pChildWnd = GetDlgItem(AFX_IDW_PANE_FIRST);
	if (pChildWnd != NULL)
	{
		pChildWnd->GetWindowRect(rectChild);
		ScreenToClient(rectChild);
	}

	CRect rectScreen;

	MONITORINFO mi;
	mi.cbSize = sizeof(MONITORINFO);
	if (GetMonitorInfo(MonitorFromPoint(CPoint(0, 0), MONITOR_DEFAULTTONEAREST), &mi))
	{
		rectScreen = mi.rcWork;
	}
	else
	{
		::SystemParametersInfo(SPI_GETWORKAREA, 0, &rectScreen, 0);
	}

	if (m_MemBitmap.GetSafeHandle() != NULL)
	{
		BITMAP bmp;
		m_MemBitmap.GetBitmap(&bmp);

		if (bmp.bmWidth != rectScreen.Width() || bmp.bmHeight != rectScreen.Height())
		{
			m_MemBitmap.DeleteObject();
		}
	}

	if (m_MemBitmap.GetSafeHandle() == NULL)
	{
		CDC dcMem;
		dcMem.CreateCompatibleDC(&dc);

		m_MemBitmap.CreateCompatibleBitmap(&dc, rectScreen.Width(), rectScreen.Height());

		CBitmap* pBmpOld = dcMem.SelectObject(&m_MemBitmap);

		CDrawingManager dm(dcMem);

		rectScreen.OffsetRect(-rectScreen.TopLeft());

		switch (theApp.m_nAppLook)
		{
		case ID_VIEW_APPLOOK_2003:
			::FillRect(dcMem.GetSafeHdc(), rectScreen, ::GetSysColorBrush(COLOR_APPWORKSPACE));
			break;

		case ID_VIEW_APPLOOK_2007_3:
			// <snippet12>
			// CRect rectScreen
			// CDrawingManager dm
			dm.FillGradient(rectScreen, RGB(114, 125, 152), RGB(178, 185, 202), TRUE);
			// </snippet12>
			
			break;

		default:
			{
				const BOOL bLuna     = theApp.m_nAppLook == ID_VIEW_APPLOOK_2007_1;
				const BOOL bObsidian = theApp.m_nAppLook == ID_VIEW_APPLOOK_2007_2;

				CMFCControlRenderer& pat = bLuna ? m_Pat[1] : bObsidian ? m_Pat[2] : m_Pat[3];

				COLORREF clrF = bLuna ? RGB(136, 170, 214) : bObsidian ? RGB( 71,  71,  71) : RGB(164, 170, 186);
				COLORREF clrM = bLuna ? RGB( 86, 125, 176) : bObsidian ? RGB( 56,  56,  56) : RGB(156, 160, 167);
				COLORREF clrL = bLuna ? RGB(101, 145, 205) : bObsidian ? RGB( 11,  11,  11) : RGB(204, 207, 216);

				const CSize szPat = pat.GetParams().m_rectImage.Size();

				CRect rectPat = rectScreen;

				rectPat.bottom = rectPat.top + szPat.cy;

				CRect rectGradient = rectScreen;
				rectGradient.top += szPat.cy;

				if (rectGradient.Height() < 50 ||
					(rectGradient.Height() - 120) < 50)
				{
					rectGradient.bottom = rectGradient.top + 50;
				}
				else
				{
					rectGradient.bottom -= 120;
				}

				dm.FillGradient(rectGradient, clrM, clrF, TRUE);

				if (rectGradient.bottom < rectScreen.bottom)
				{
					rectGradient.top    = rectGradient.bottom;
					rectGradient.bottom = rectScreen.bottom;

					dm.FillGradient(rectGradient, clrL, clrM, TRUE);
				}

				pat.Draw(&dcMem, rectPat, 0);
			}
		}

		dcMem.SelectObject(pBmpOld);
	}

	CRect rectFill = m_rectFill;

	if (!m_rectSizing.IsRectEmpty())
	{
		dc.FillRect(m_rectSizing, &afxGlobalData.brBarFace);
		rectFill.right += m_rectSizing.Width();
	}

	dc.DrawState(rectFill.TopLeft(), rectFill.Size(), &m_MemBitmap, DSS_NORMAL);
}

BOOL CMainFrame::OnEraseBkgnd(CDC* pDC)
{
	return TRUE;
}

void CMainFrame::OnSizing(UINT fwSide, LPRECT pRect)
{
	CRect rectOld;
	GetWindowRect(rectOld);

	CRect rectNew = pRect;

	if (rectNew.right > rectOld.right)
	{
		m_rectSizing = rectNew;
		m_rectSizing.left = rectOld.right;

		ScreenToClient(m_rectSizing);
	}
	else
	{
		m_rectSizing.SetRectEmpty();
	}

	CFrameWndEx::OnSizing(fwSide, pRect);
}

void CMainFrame::OnSize(UINT nType, int cx, int cy)
{
	CFrameWndEx::OnSize(nType, cx, cy);

	if (nType == SIZE_MAXIMIZED || nType == SIZE_RESTORED)
	{
		RedrawWindow(NULL, NULL, RDW_FRAME | RDW_INVALIDATE | RDW_UPDATENOW);
	}
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
		{	RGB (255, 255, 255),	_T("White, Background 1")	},
		{	RGB (0, 0, 0),			_T("Black, Text 1")			},
		{	RGB (238, 236, 225),	_T("Tan, Background 2")		},
		{	RGB (31, 73, 125),		_T("Dark Blue, Text 2")		},
		{	RGB (79, 129, 189),		_T("Blue, Accent 1")		},
		{	RGB (192, 80, 77),		_T("Red, Accent 2")			},
		{	RGB (155, 187, 89),		_T("Olive Green, Accent 3")	},
		{	RGB (128, 100, 162),	_T("Purple, Accent 4")		},
		{	RGB (75, 172, 198),		_T("Aqua, Accent 5")		},
		{	RGB (245, 150, 70),		_T("Orange, Accent 6")		}
	};

	static ColorTableEntry colorsAdditional [] = 
	{
		{	RGB (242, 242, 242),	_T("White, Background 1, Darker 5%")	},
		{	RGB (127, 127, 127),	_T("Black, Text 1, Lighter 50%")		},
		{	RGB (214, 212, 202),	_T("Tan, Background 2, Darker 10%")		},
		{	RGB (210, 218, 229),	_T("Dark Blue, Text 2, Lighter 80%")	},
		{	RGB (217, 228, 240),	_T("Blue, Accent 1, Lighter 80%")		},
		{	RGB (244, 219, 218),	_T("Red, Accent 2, Lighter 80%")		},
		{	RGB (234, 241, 221),	_T("Olive Green, Accent 3, Lighter 80%")},
		{	RGB (229, 223, 235),	_T("Purple, Accent 4, Lighter 80%")		},
		{	RGB (216, 237, 242),	_T("Aqua, Accent 5, Lighter 80%")		},
		{	RGB (255, 234, 218),	_T("Orange, Accent 6, Lighter 80%")		},

		{	RGB (215, 215, 215),	_T("White, Background 1, Darker 15%")	},
		{	RGB (89, 89, 89),		_T("Black, Text 1, Lighter 35%")		},
		{	RGB (177, 176, 167),	_T("Tan, Background 2, Darker 25%")		},
		{	RGB (161, 180, 201),	_T("Dark Blue, Text 2, Lighter 60%")	},
		{	RGB (179, 202, 226),	_T("Blue, Accent 1, Lighter 60%")		},
		{	RGB (233, 184, 182),	_T("Red, Accent 2, Lighter 60%")		},
		{	RGB (213, 226, 188),	_T("Olive Green, Accent 3, Lighter 60%")},
		{	RGB (203, 191, 215),	_T("Purple, Accent 4, Lighter 60%")		},
		{	RGB (176, 220, 231),	_T("Aqua, Accent 5, Lighter 60%")		},
		{	RGB (255, 212, 181),	_T("Orange, Accent 6, Lighter 60%")		},

		{	RGB (190, 190, 190),	_T("White, Background 1, Darker 25%")	},
		{	RGB (65, 65, 65),		_T("Black, Text 1, Lighter 25%")		},
		{	RGB (118, 117, 112),	_T("Tan, Background 2, Darker 35%")		},
		{	RGB (115, 143, 175),	_T("Dark Blue, Text 2, Lighter 40%")	},
		{	RGB (143, 177, 213),	_T("Blue, Accent 1, Lighter 40%")		},
		{	RGB (222, 149, 147),	_T("Red, Accent 2, Lighter 40%")		},
		{	RGB (192, 213, 155),	_T("Olive Green, Accent 3, Lighter 40%")},
		{	RGB (177, 160, 197),	_T("Purple, Accent 4, Lighter 40%")		},
		{	RGB (137, 203, 218),	_T("Aqua, Accent 5, Lighter 40%")		},
		{	RGB (255, 191, 145),	_T("Orange, Accent 6, Lighter 40%")		},

		{	RGB (163, 163, 163),	_T("White, Background 1, Darker 35%")	},
		{	RGB (42, 42, 42),		_T("Black, Text 1, Lighter 15%")		},
		{	RGB (61, 61, 59),		_T("Tan, Background 2, Darker 50%")		},
		{	RGB (20, 57, 92),		_T("Dark Blue, Text 2, Darker 25%")		},
		{	RGB (54, 96, 139),		_T("Blue, Accent 1, Darker 25%")		},
		{	RGB (149, 63, 60),		_T("Red, Accent 2, Darker 25%")			},
		{	RGB (114, 139, 71),		_T("Olive Green, Accent 3, Darker 25%")	},
		{	RGB (97, 76, 119),		_T("Purple, Accent 4, Darker 25%")		},
		{	RGB (41, 128, 146),		_T("Aqua, Accent 5, Darker 25%")		},
		{	RGB (190, 112, 59),		_T("Orange, Accent 6, Darker 25%")		},

		{	RGB (126, 126, 126),	_T("White, Background 1, Darker 50%")	},
		{	RGB (20, 20, 20),		_T("Black, Text 1, Lighter 5%")			},
		{	RGB (29, 29, 28),		_T("Tan, Background 2, Darker 90%")		},
		{	RGB (17, 40, 64),		_T("Dark Blue, Text 2, Darker 50%")		},
		{	RGB (38, 66, 94),		_T("Blue, Accent 1, Darker 50%")		},
		{	RGB (100, 44, 43),		_T("Red, Accent 2, Darker 50%")			},
		{	RGB (77, 93, 49),		_T("Olive Green, Accent 3, Darker 50%")	},
		{	RGB (67, 53, 81),		_T("Purple, Accent 4, Darker 50%")		},
		{	RGB (31, 86, 99),		_T("Aqua, Accent 5, Darker 50%")		},
		{	RGB (126, 77, 42),		_T("Orange, Accent 6, Darker 50%")		},
	};

	static ColorTableEntry colorsStandard [] = 
	{
		{	RGB (200, 15, 18),		_T("Dark Red")		},
		{	RGB (255, 20, 24),		_T("Red")			},
		{	RGB (255, 191, 40),		_T("Orange")		},
		{	RGB (255, 255, 49),		_T("Yellow")		},
		{	RGB (138, 207, 87),		_T("Light Green")	},
		{	RGB (0, 175, 84),		_T("Green")			},
		{	RGB (0, 174, 238),		_T("Light Blue")	},
		{	RGB (0, 111, 189),		_T("Blue")			},
		{	RGB (0, 36, 95),		_T("Black")			},
		{	RGB (114, 50, 157),		_T("Purple")		},
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

void CMainFrame::CreateStyleList()
{
	m_arStyles.RemoveAll();
	m_arStyleSets.RemoveAll();

	m_arStyles.Add( _T("� Normal"));
	m_arStyles.Add( _T("� No Spacing"));
	m_arStyles.Add( _T("Heading 1"));
	m_arStyles.Add( _T("Heading 2"));
	m_arStyles.Add( _T("Heading 3"));
	m_arStyles.Add( _T("Title"));
	m_arStyles.Add( _T("Subtitle"));
	m_arStyles.Add( _T("Subtle Emphasis"));
	m_arStyles.Add( _T("Emphasis"));
	m_arStyles.Add( _T("Intense Emphasis"));
	m_arStyles.Add( _T("Strong"));
	m_arStyles.Add( _T("Quote"));
	m_arStyles.Add( _T("Intense Quote"));
	m_arStyles.Add( _T("Subtle Reference"));
	m_arStyles.Add( _T("Intense Reference"));
	m_arStyles.Add( _T("Book Title"));
	m_arStyles.Add( _T("� List Paragraph"));
	m_arStyles.Add( _T("� Caption"));

	m_arStyleSets.Add(_T("Default(Black and White)"));
	m_arStyleSets.Add(_T("Elegant"));
	m_arStyleSets.Add(_T("Fancy"));
	m_arStyleSets.Add(_T("Formal"));
	m_arStyleSets.Add(_T("Manuscript"));
	m_arStyleSets.Add(_T("Modern"));
	m_arStyleSets.Add(_T("Simple"));
	m_arStyleSets.Add(_T("Traditional"));
};

void CMainFrame::CreateThemeList()
{
	m_arThemes.RemoveAll();
	m_arColorThemes.RemoveAll();

	m_arThemes.Add(_T("Office"));
	m_arThemes.Add(_T("Apex"));
	m_arThemes.Add(_T("Aspect"));
	m_arThemes.Add(_T("Civic"));
	m_arThemes.Add(_T("Concource"));
	m_arThemes.Add(_T("Equite"));
	m_arThemes.Add(_T("Flow"));
	m_arThemes.Add(_T("Foundry"));
	m_arThemes.Add(_T("Median"));
	m_arThemes.Add(_T("Metro"));
	m_arThemes.Add(_T("Module"));
	m_arThemes.Add(_T("Opulent"));
	m_arThemes.Add(_T("Oriel"));
	m_arThemes.Add(_T("Origin"));
	m_arThemes.Add(_T("Paper"));
	m_arThemes.Add(_T("Solstice"));
	m_arThemes.Add(_T("Technic"));
	m_arThemes.Add(_T("Trek"));
	m_arThemes.Add(_T("Urban"));
	m_arThemes.Add(_T("Verve"));

	m_arColorThemes.Copy(m_arThemes);
	m_arColorThemes.InsertAt(1, _T("Grayscale"));
}

void CMainFrame::CreateFontsList()
{
	m_arFonts.RemoveAll();

	{
		CRibbonListFontButton::XItem item;

		item.m_Caption = _T("Office Classic");
		_tcscpy_s(item.m_Font[0].lfFaceName, _countof(item.m_Font[0].lfFaceName), _T("Arial"));
		_tcscpy_s(item.m_Font[1].lfFaceName, _countof(item.m_Font[1].lfFaceName), _T("Times New Roman"));

		m_arFonts.Add(item);
	}

	{
		CRibbonListFontButton::XItem item;

		item.m_Caption = _T("Office Classic 2");
		_tcscpy_s(item.m_Font[0].lfFaceName, _countof(item.m_Font[0].lfFaceName), _T("Arial"));
		_tcscpy_s(item.m_Font[1].lfFaceName, _countof(item.m_Font[1].lfFaceName), _T("Arial"));

		m_arFonts.Add(item);
	}

	{
		CRibbonListFontButton::XItem item;

		item.m_Caption = _T("Aspect");
		_tcscpy_s(item.m_Font[0].lfFaceName, _countof(item.m_Font[0].lfFaceName), _T("Verdana"));
		_tcscpy_s(item.m_Font[1].lfFaceName, _countof(item.m_Font[1].lfFaceName), _T("Verdana"));

		m_arFonts.Add(item);
	}
}

void CMainFrame::ActivateRibbonContextCategory(UINT uiCategoryID)
{
	if (m_wndRibbonBar.GetHideFlags() == 0)
	{
		m_wndRibbonBar.ActivateContextCategory(uiCategoryID);
	}
}

void CMainFrame::SetRibbonContextCategory(UINT uiCategoryID)
{
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

CMFCRibbonPanel* CMainFrame::AddPanelArrange(CMFCRibbonCategory* pCategory, UINT imageP, UINT imageS, UINT imageL)
{
	ASSERT_VALID(pCategory);

	CMFCRibbonPanel* pPanelPL_Arrange = pCategory->AddPanel(_T("Arrange\nza"), m_PanelImages.ExtractIcon(imageP));

	CMFCRibbonGallery* pPositionBtn = new CMFCRibbonGallery(ID_PAGELAYOUT_ARRANGE_POSITION, _T("Position\npo"), -1, imageL);
	InitPositionPalette(pPositionBtn);
	pPositionBtn->EnableMenuResize();
	pPositionBtn->SetButtonMode();
	pPanelPL_Arrange->Add(pPositionBtn);

	CMFCRibbonButton* pBtn = new CMFCRibbonButton(ID_PAGELAYOUT_BRINGTOFRONT, _T("Bring to Front\naf"), imageS, imageL > 0 ? imageL + 1 : -1);
	pBtn->SetMenu(IDR_PAGELAYOUT_BRINGTOFRONT, TRUE);
	pPanelPL_Arrange->Add(pBtn);

	pBtn = new CMFCRibbonButton(ID_PAGELAYOUT_SENDTOBACK, _T("Send to Back\nab"), imageS + 2, imageL > 0 ? imageL + 2 : -1);
	pBtn->SetMenu(IDR_PAGELAYOUT_SENDTOBACK, TRUE);
	pPanelPL_Arrange->Add(pBtn);

	pBtn = new CMFCRibbonButton(ID_PAGELAYOUT_TEXTWRAPPING, _T("Text Wrapping\ntw"), imageS + 4, imageL > 0 ? imageL + 3 : -1);
	pBtn->SetMenu(IDR_PAGELAYOUT_TEXTWRAPPING, FALSE);
	pPanelPL_Arrange->Add(pBtn);

	pPanelPL_Arrange->Add(new CMFCRibbonButton(ID_PAGELAYOUT_ARRANGE_ALIGN, _T("Align\naa"), imageS + 1, imageL > 0 ? imageL + 4 : -1));
	pPanelPL_Arrange->Add(new CMFCRibbonButton(ID_PAGELAYOUT_ARRANGE_GROUP, _T("Group\nag"), imageS + 3, imageL > 0 ? imageL + 5 : -1));
	pPanelPL_Arrange->Add(new CMFCRibbonButton(ID_PAGELAYOUT_ARRANGE_ROTATE, _T("Rotate\nay"), imageS + 5, imageL > 0 ? imageL + 6 : -1));

	return pPanelPL_Arrange;
}

void CMainFrame::AddContextTab_Picture()
{
	CMFCRibbonCategory* pCategory = m_wndRibbonBar.AddContextCategory(_T("Format"), _T("Picture tools"), IDB_PICTURE, AFX_CategoryColor_Red, IDB_PICTURE_FORMAT, IDB_PICTURE_FORMATLARGE);

	pCategory->SetKeys(_T("jp"));

	CMFCRibbonPanel* pPanelTools = pCategory->AddPanel(_T("Picture Tools"), m_PanelImages.ExtractIcon(20));

	pPanelTools->Add(new CMFCRibbonButton(ID_PICTURE_FORMAT_TOOLS_BRIGHTNESS, _T("Brightness\nb"), 0, -1));
	pPanelTools->Add(new CMFCRibbonButton(ID_PICTURE_FORMAT_TOOLS_CONTRAST, _T("Contrast\nn"), 1, -1));
	pPanelTools->Add(new CMFCRibbonButton(ID_PICTURE_FORMAT_TOOLS_RECOLOR, _T("Recolor\ne"), 2, -1));
	pPanelTools->Add(new CMFCRibbonButton(ID_PICTURE_FORMAT_TOOLS_COMPRESS, _T("Compress Pictures\nm"), 3, -1));
	pPanelTools->Add(new CMFCRibbonButton(ID_PICTURE_FORMAT_TOOLS_CHANGE, _T("Change Picture\ng"), 4, -1));
	pPanelTools->Add(new CMFCRibbonButton(ID_PICTURE_FORMAT_TOOLS_RESET, _T("Reset Picture\no"), 5, -1));

	AddPanelArrange(pCategory, 19, 6, 0);
}

void CMainFrame::AddContextTab_Chart()
{
	CMFCRibbonCategory* pCategory = m_wndRibbonBar.AddContextCategory(_T("Design"), _T("Chart tools"), IDB_CHART, AFX_CategoryColor_Green, IDB_CHART_DESIGN, IDB_CHART_DESIGNLARGE);
	pCategory->SetKeys(_T("jc"));

	CMFCRibbonPanel* pPanelDesign_Type = pCategory->AddPanel(_T("Type"), m_PanelImages.ExtractIcon(20));

	pPanelDesign_Type->Add(new CMFCRibbonButton(ID_CHART_DESIGN_TYPE_CHANGE, _T("Change Chart Type\nc"), -1, 0));
	pPanelDesign_Type->Add(new CMFCRibbonButton(ID_CHART_DESIGN_TYPE_SAVETEMPLATE, _T("Save Template\nt"), -1, 1));

	CMFCRibbonPanel* pPanelDesign_Data = pCategory->AddPanel(_T("Data"), m_PanelImages.ExtractIcon(20));

	pPanelDesign_Data->Add(new CMFCRibbonButton(ID_CHART_DESIGN_DATA_SWITCH, _T("Switch Row/Column\nw"), -1, 2));
	pPanelDesign_Data->Add(new CMFCRibbonButton(ID_CHART_DESIGN_DATA_EDIT, _T("Edit Data Source\ne"), -1, 3));
	pPanelDesign_Data->Add(new CMFCRibbonButton(ID_CHART_DESIGN_DATA_SHOW, _T("Show Data\nd"), -1, 4));

	CMFCRibbonCategory* pCategory2 = m_wndRibbonBar.AddContextCategory(_T("Layout"), _T("Chart tools"), IDB_CHART, AFX_CategoryColor_Green, IDB_CHART_LAYOUT, IDB_CHART_LAYOUTLARGE);
	pCategory2->SetKeys(_T("ja"));

	CMFCRibbonPanel* pPanelLayout_Shapes = pCategory2->AddPanel(_T("Shapes"), m_PanelImages.ExtractIcon(20));

	pPanelLayout_Shapes->Add(new CMFCRibbonButton(ID_CHART_LAYOUT_SHAPES_PICTURE, _T("Picture\np"), 0, 0));
	pPanelLayout_Shapes->Add(new CMFCRibbonButton(ID_CHART_LAYOUT_SHAPES_SHAPES, _T("Shapes\nsh"), 1, 1));
	pPanelLayout_Shapes->Add(new CMFCRibbonButton(ID_CHART_LAYOUT_SHAPES_TEXTBOX, _T("Draw Text Box\nx"), 2, 2));

	CMFCRibbonPanel* pPanelLayout_Labels = pCategory2->AddPanel(_T("Labels"), m_PanelImages.ExtractIcon(20));

	pPanelLayout_Labels->Add(new CMFCRibbonButton(ID_CHART_LAYOUT_LABELS_TITLE, _T("Chart Title\nt"), -1, 3));
	pPanelLayout_Labels->Add(new CMFCRibbonButton(ID_CHART_LAYOUT_LABELS_AXIS, _T("Axis Titles\ni"), -1, 4));
	pPanelLayout_Labels->Add(new CMFCRibbonButton(ID_CHART_LAYOUT_LABELS_LEGEND, _T("Legend\nl"), 3, 5));
	pPanelLayout_Labels->Add(new CMFCRibbonButton(ID_CHART_LAYOUT_LABELS_DATALABELS, _T("Data Labels\nb"), 4, 6));
	pPanelLayout_Labels->Add(new CMFCRibbonButton(ID_CHART_LAYOUT_LABELS_DATATABLE, _T("Data Table\nd"), 5, 7));

	CMFCRibbonPanel* pPanelLayout_Axes = pCategory2->AddPanel(_T("Axes"), m_PanelImages.ExtractIcon(20));

	pPanelLayout_Axes->Add(new CMFCRibbonButton(ID_CHART_LAYOUT_AXES_AXES, _T("Axes\na"), -1, 8));
	pPanelLayout_Axes->Add(new CMFCRibbonButton(ID_CHART_LAYOUT_AXES_GRIDLINES, _T("Gridlines\ng"), -1, 9));

	CMFCRibbonCategory* pCategory3 = m_wndRibbonBar.AddContextCategory(_T("Format"), _T("Chart tools"), IDB_CHART, AFX_CategoryColor_Green, IDB_CHART_FORMAT, IDB_CHART_FORMATLARGE);
	pCategory3->SetKeys(_T("jo"));

	CMFCRibbonPanel* pPanelFormat_Sel = pCategory3->AddPanel(_T("Current Selection"), m_PanelImages.ExtractIcon(20));

	pPanelFormat_Sel->Add(new CMFCRibbonButton(ID_CHART_FORMAT_CURSEL_FORMAT, _T("Format Selection\nm"), 0, -1));
	pPanelFormat_Sel->Add(new CMFCRibbonButton(ID_CHART_FORMAT_CURSEL_RESET, _T("Reset to Match Style\nv"), 1, -1));

	CMFCRibbonPanel* pPanelFormat_Shape = pCategory3->AddPanel(_T("Shape Styles"), m_PanelImages.ExtractIcon(20));

	pPanelFormat_Shape->Add(new CMFCRibbonButton(ID_CHART_FORMAT_SHAPES_FILL, _T("Shape Fill\nsf"), 2, -1));
	pPanelFormat_Shape->Add(new CMFCRibbonButton(ID_CHART_FORMAT_SHAPES_OUTLINE, _T("Shape Outline\nso"), 3, -1));
	pPanelFormat_Shape->Add(new CMFCRibbonButton(ID_CHART_FORMAT_SHAPES_EFFECTS, _T("Shape Effects\nse"), 4, -1));

	AddPanelArrange(pCategory3, 19, 5, 0);
}

void CMainFrame::AddContextTab_Table()
{
	CMFCRibbonCategory* pCategory = m_wndRibbonBar.AddContextCategory(_T("Design"), _T("Table tools"), IDB_TABLE, AFX_CategoryColor_Yellow, IDB_INSERT, IDB_INSERTLARGE);
	pCategory->SetKeys(_T("jt"));

	CMFCRibbonPanel* pPanelTableStyleOptions = pCategory->AddPanel(_T("Table Style Options"), m_PanelImages.ExtractIcon(20));
	pPanelTableStyleOptions->Add(new CMFCRibbonCheckBox(ID_TABLE_HEADERROW, _T("Header Row\nhr")));
	pPanelTableStyleOptions->Add(new CMFCRibbonCheckBox(ID_TABLE_TOTALROW, _T("Total Row\ntr")));
	pPanelTableStyleOptions->Add(new CMFCRibbonCheckBox(ID_TABLE_BANDEDROWS, _T("Banded Rows\nbr")));
	pPanelTableStyleOptions->Add(new CMFCRibbonCheckBox(ID_TABLE_FIRSTCOLUMN, _T("First Column\nfc")));
	pPanelTableStyleOptions->Add(new CMFCRibbonCheckBox(ID_TABLE_LASTCOLUMN, _T("Last Column\nlc")));
	pPanelTableStyleOptions->Add(new CMFCRibbonCheckBox(ID_TABLE_BANDEDCOLUMNS, _T("Banded Columns\nbc")));

	pCategory->AddPanel(_T("Table Styles"), m_PanelImages.ExtractIcon(20));
	pCategory->AddPanel(_T("Draw Borders"), m_PanelImages.ExtractIcon(20));

	CMFCRibbonCategory* pCategory2 = m_wndRibbonBar.AddContextCategory(_T("Layout"), _T("Table tools"), IDB_TABLE, AFX_CategoryColor_Yellow, IDB_INSERT, IDB_INSERTLARGE);
	pCategory2->SetKeys(_T("jl"));

	pCategory2->AddPanel(_T("Table"), m_PanelImages.ExtractIcon(20));
	pCategory2->AddPanel(_T("Rows & Columns"), m_PanelImages.ExtractIcon(20));
	pCategory2->AddPanel(_T("Merge"), m_PanelImages.ExtractIcon(20));
	pCategory2->AddPanel(_T("Cell Size"), m_PanelImages.ExtractIcon(20));
	pCategory2->AddPanel(_T("Alignment"), m_PanelImages.ExtractIcon(20));
	pCategory2->AddPanel(_T("Data"), m_PanelImages.ExtractIcon(20));
}

BOOL CMainFrame::CreateStatusBar()
{
	if (!m_wndStatusBar.Create(this))
	{
		TRACE0("Failed to create status bar\n");
		return FALSE;
	}

	m_wndStatusBar.AddElement(new CMFCRibbonLinkCtrl(ID_STATUSBAR_LINK, _T("www.microsoft.com"), _T("http://www.microsoft.com")), _T("Link to website"));

	m_wndStatusBar.AddSeparator();

	m_wndStatusBar.AddElement(new CMFCRibbonStatusBarPane(ID_STATUSBAR_PAGE, _T("Page 1")), _T("Formatted Page Number"));

	m_wndStatusBar.AddElement(new CMFCRibbonStatusBarPane(ID_STATUSBAR_LINE, _T("Line 1")), _T("Line Number"));

	m_wndStatusBar.AddSeparator();

	HICON hIconSpell = (HICON) ::LoadImage(AfxGetResourceHandle(), MAKEINTRESOURCE(IDI_SPELL), IMAGE_ICON, ::GetSystemMetrics(SM_CXSMICON), ::GetSystemMetrics(SM_CYSMICON), LR_SHARED);

	m_wndStatusBar.AddElement(new CMFCRibbonStatusBarPane(ID_STATUSBAR_SPELL, _T(""), (UINT) IDB_SPELL, 16, RGB(192, 192, 192), hIconSpell), _T("Spelling and Grammar Check"));

	m_wndStatusBar.AddSeparator();

	HICON hIconRefresh = (HICON) ::LoadImage(AfxGetResourceHandle(), MAKEINTRESOURCE(IDI_REFRESH), IMAGE_ICON, ::GetSystemMetrics(SM_CXSMICON), ::GetSystemMetrics(SM_CYSMICON), LR_SHARED);

	m_wndStatusBar.AddElement(new CMFCRibbonStatusBarPane(ID_STATUSBAR_REFRESH, _T("Refresh"), FALSE, hIconRefresh), _T("Refresh"));

	CMFCRibbonButtonsGroup* pSBGroup = new CMFCRibbonButtonsGroup;

	CMFCToolBarImages images1;
	images1.SetImageSize(CSize(14, 14));
	images1.Load(IDB_LAYOUT);

	pSBGroup->SetImages(&images1, NULL, NULL);
	pSBGroup->SetID(ID_GROUP_SHORTCUTS);

	pSBGroup->AddButton(new CMFCRibbonButton(ID_STATUSBAR_PRINTLAYOUT, _T(""), 0));
	pSBGroup->AddButton(new CMFCRibbonButton(ID_STATUSBAR_FULL_SCREEN_READING, _T(""), 1));
	pSBGroup->AddButton(new CMFCRibbonButton(ID_STATUSBAR_WEBLAYOUT, _T(""), 2));
	pSBGroup->AddButton(new CMFCRibbonButton(ID_STATUSBAR_MASTER_DOCUMENT_TOOLS, _T(""), 3));
	pSBGroup->AddButton(new CMFCRibbonButton(ID_STATUSBAR_DRAFT, _T(""), 4));

	m_wndStatusBar.AddExtendedElement(pSBGroup, _T("View Shortcuts"));

	m_wndStatusBar.AddExtendedElement(new CMFCRibbonStatusBarPane(ID_STATUSBAR_ZOOM, _T("100%"), FALSE, NULL, _T("1000%")), _T("Zoom"));

	CMFCRibbonSlider* pSlider = new CMFCRibbonSlider(ID_STATUSBAR_ZOOM_SLIDER);
	pSlider->SetZoomButtons();
	pSlider->SetRange(0, 200);
	pSlider->SetPos(100);

	m_wndStatusBar.AddExtendedElement(pSlider, _T("Zoom Slider"));

	return TRUE;
}

// <Snippet2>
BOOL CMainFrame::CreateMessageBar()
{
	// The this pointer points to a CMainFrame class which extends the CFrameWndEx class.
	if (!m_wndMessageBar.Create(WS_CHILD | WS_VISIBLE | WS_CLIPSIBLINGS, this, ID_VIEW_MESSAGEBAR, -1, TRUE))
	{
		TRACE0("Failed to create caption bar\n");
		return FALSE;
	}

	m_wndMessageBar.SetFlatBorder( FALSE );
	m_wndMessageBar.SetMargin(10);
	m_wndMessageBar.SetButton(_T("Options..."), ID_TOOLS_OPTIONS, CMFCCaptionBar::ALIGN_LEFT, FALSE);
	m_wndMessageBar.SetButtonToolTip(_T("Click here to see more options"));

	m_wndMessageBar.SetText(_T("Welcome to the MFC MSOffice2007 demonstration!"), CMFCCaptionBar::ALIGN_LEFT);

	m_wndMessageBar.SetBitmap(IDB_INFO, RGB(255, 255, 255), FALSE, CMFCCaptionBar::ALIGN_LEFT);
	m_wndMessageBar.SetImageToolTip(_T("Important"), _T("Please take a look at MSOffice2007Demo source code to learn how to create advanced user interface in minutes."));

	return TRUE;
}
// </Snippet2>

void CMainFrame::OnTimer(UINT_PTR nIDEvent)
{
	if (nIDEvent == IdStartProgressTimer)
	{
		ShowProgress();
		KillTimer(IdStartProgressTimer);
	}

	if (nIDEvent == IdShowProgressTimer)
	{
		m_nProgressValue++;

		if (m_nProgressValue > 100)
		{
			ShowProgress(FALSE);
		}
		else
		{
			CMFCRibbonProgressBar* pProgress = DYNAMIC_DOWNCAST(CMFCRibbonProgressBar, m_wndStatusBar.FindElement(ID_STATUSBAR_PROGRESS));
			ASSERT_VALID(pProgress);

			pProgress->SetPos(m_nProgressValue, TRUE);
		}
	}
}

void CMainFrame::ShowProgress(BOOL bShow)
{
	if (bShow)
	{
		int cxFree = m_wndStatusBar.GetSpace();
		if (cxFree < 20)
		{
			// Not enough space for progress bar
			return;
		}

		int cxProgress = min(cxFree, 150);

		// <snippet11>
		// int cxProgress
		// BOOL m_bInfiniteProgressMode
		CMFCRibbonProgressBar* pProgressBar = new CMFCRibbonProgressBar(ID_STATUSBAR_PROGRESS, cxProgress);

		pProgressBar->SetInfiniteMode(m_bInfiniteProgressMode);
		pProgressBar->SetRange(0,200);
		pProgressBar->SetPos(200,true);
		// </snippet11>

		m_wndStatusBar.AddDynamicElement(pProgressBar);

		m_nProgressValue = 0;

		SetTimer(IdShowProgressTimer, 10, NULL);
	}
	else
	{
		KillTimer(IdShowProgressTimer);
		m_wndStatusBar.RemoveElement(ID_STATUSBAR_PROGRESS);
		m_nProgressValue = -1;
	}

	m_wndStatusBar.RecalcLayout();
	m_wndStatusBar.RedrawWindow();

	CMFCPopupMenu::UpdateAllShadows();
}

void CMainFrame::OnZoomSlider()
{
	CMFCRibbonSlider* pSlider = DYNAMIC_DOWNCAST(CMFCRibbonSlider, m_wndStatusBar.FindElement(ID_STATUSBAR_ZOOM_SLIDER));
	ASSERT_VALID(pSlider);

	int nPos = pSlider->GetPos();

	CMFCRibbonStatusBarPane* pZoom = DYNAMIC_DOWNCAST(CMFCRibbonStatusBarPane, m_wndStatusBar.FindElement(ID_STATUSBAR_ZOOM));
	ASSERT_VALID(pZoom);

	CString strZoom;
	strZoom.Format(_T("%d%%"), nPos);

	pZoom->SetText(strZoom);
	pZoom->Redraw();
}

void CMainFrame::OnZoom()
{
	MessageBox(_T("Zoom dialog box..."));
}

void CMainFrame::OnRefresh()
{
	m_bInfiniteProgressMode = FALSE;
	ShowProgress();
}

void CMainFrame::OnUpdateRefresh(CCmdUI* pCmdUI)
{
	pCmdUI->Enable(m_nProgressValue < 0);
}

void CMainFrame::OnSpell()
{
	CMFCRibbonStatusBarPane* pPane = DYNAMIC_DOWNCAST(CMFCRibbonStatusBarPane, m_wndStatusBar.FindElement(ID_STATUSBAR_SPELL));

	if (pPane == NULL)
	{
		return;
	}

	if (pPane->IsAnimation())
	{
		pPane->StopAnimation();
	}
	else
	{
		pPane->StartAnimation( 500 /* 1/2 sec, Frame delay */, 10000 /* 10 sec, animation duration */);
	}
}

BOOL CMainFrame::OnShowPopupMenu(CMFCPopupMenu* pMenuPopup)
{
	CFrameWndEx::OnShowPopupMenu(pMenuPopup);

	if (pMenuPopup == NULL)
	{
		return TRUE;
	}

	CMFCPopupMenuBar* pMenuBar = pMenuPopup->GetMenuBar();
	ASSERT_VALID(pMenuBar);

	int nBulletIndex = pMenuBar->CommandToIndex(ID_PARA_BULLETS);

	if (nBulletIndex >= 0)
	{
		CMFCToolBarButton* pExButton = pMenuBar->GetButton(nBulletIndex);
		ASSERT_VALID(pExButton);

		// <snippet8>
		// CMFCToolBarButton pExButton
		CMFCRibbonGalleryMenuButton paletteBullet(pExButton->m_nID, pExButton->GetImage(), pExButton->m_strText);
		// </snippet8>

		InitBulletPalette(&paletteBullet.GetPalette());

		pMenuBar->ReplaceButton(ID_PARA_BULLETS, paletteBullet);
	}

	int nNumIndex = pMenuBar->CommandToIndex(ID_PARA_NUMBERING);

	if (nNumIndex >= 0)
	{
		CMFCToolBarButton* pExButton = pMenuBar->GetButton(nNumIndex);
		ASSERT_VALID(pExButton);

		CMFCRibbonGalleryMenuButton paletteNum(pExButton->m_nID, pExButton->GetImage(), pExButton->m_strText);

		InitNumberingPalette(&paletteNum.GetPalette());

		pMenuBar->ReplaceButton(ID_PARA_NUMBERING, paletteNum);
	}

	return TRUE;
}

void CMainFrame::InitBulletPalette(CMFCRibbonGallery* pPalette)
{
	ASSERT_VALID(pPalette);

	pPalette->SetPaletteID(ID_FROM_PALETTE_BULLET);

	pPalette->AddGroup(_T("Bullets"), IDB_BULLETS, 40);

	pPalette->AddSubItem(new CMFCRibbonButton(ID_PARA_CHANGE_LIST_LEVEL, _T("&Change List Level")));

	pPalette->AddSubItem(new CMFCRibbonButton(ID_PARA_DEFINENEWBULLET, _T("&Define New Bullet...")));

	pPalette->SetIconsInRow(6);
}

void CMainFrame::InitNumberingPalette(CMFCRibbonGallery* pPalette)
{
	ASSERT_VALID(pPalette);

	pPalette->SetPaletteID(ID_FROM_PALETTE_NUMBER);

	pPalette->AddGroup(_T("Numbering Library"), IDB_NUM, 76);

	pPalette->AddSubItem(new CMFCRibbonButton(ID_PARA_CHANGE_LIST_LEVEL, _T("&Change List Level")));

	pPalette->AddSubItem(new CMFCRibbonButton(ID_PARA_DEFINENEWNUMBERFORMAT, _T("&Define New Number Format...")));

	pPalette->SetIconsInRow(3);
}

void CMainFrame::InitMultilevelPalette(CMFCRibbonGallery* pPalette)
{
	ASSERT_VALID(pPalette);

	pPalette->SetPaletteID(ID_FROM_PALETTE_MULTILEVEL);

	pPalette->AddGroup(_T("List Library"), IDB_MULTI, 76);

	pPalette->AddSubItem(new CMFCRibbonButton(ID_PARA_CHANGE_LIST_LEVEL, _T("&Change List Level")));

	pPalette->AddSubItem(new CMFCRibbonButton(ID_PARA_DEFINENEWMULTILEVELLIST, _T("&Define New Multilevel List")));

	pPalette->AddSubItem(new CMFCRibbonButton(ID_PARA_DEFINENEWLISTSTYLE, _T("Define New List &Style...")));

	pPalette->SetIconsInRow(3);
}

void CMainFrame::InitPositionPalette(CMFCRibbonGallery* pPalette)
{
	ASSERT_VALID(pPalette);

	pPalette->SetPaletteID(ID_FROM_PALETTE_POSITION);

	pPalette->AddGroup(_T("In Line with"), IDB_POSITION_1, 37);
	pPalette->AddGroup(_T("With Text Wrapping"), IDB_POSITION_2, 37);

	pPalette->AddSubItem(new CMFCRibbonButton(ID_PAGELAYOUT_MORELAYOUTOPTIONS, _T("&More &Layout Options")));

	pPalette->SetIconsInRow(3);
}

void CMainFrame::OnToolsOptions()
{
	ShowOptions(0);
}

LRESULT CMainFrame::OnRibbonCustomize(WPARAM wp, LPARAM lp)
{
	ShowOptions(1);
	return 1;
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
	lstPopular.AddTail(ID_FILE_SEND_EMAIL);

	lstPopular.AddTail(ID_EDIT_UNDO);

	lstPopular.AddTail(ID_PAGELAYOUT_PAGEBACKGROUND_PAGEBORDERS);
	lstPopular.AddTail(ID_PAGELAYOUT_PAGESETUP_BREAKS);

	lstPopular.AddTail(ID_TABLE_DRAWTABLE);
	lstPopular.AddTail(ID_INSERT_HYPERLINK);
	lstPopular.AddTail(ID_INSERT_PICTURE);

	pageCustomize.AddCustomCategory(_T("Popular Commands"), lstPopular);

	// Add hidden commands:
	CList<UINT,UINT> lstHidden;
	m_wndRibbonBar.GetItemIDsList(lstHidden, TRUE);

	pageCustomize.AddCustomCategory(_T("Commands not in the Ribbon"), lstHidden);

	// Add all commands:
	CList<UINT,UINT> lstAll;
	m_wndRibbonBar.GetItemIDsList(lstAll);

	pageCustomize.AddCustomCategory(_T("All Commands"), lstAll);

	// Create "Options" and "Resources" pages:
	CDemoOptionsPage pageOptions;
	CResourcePage pageRes;

	// Create property sheet:
	CDemoOptionsPropSheet propSheet(this, nPage);
	propSheet.EnablePageHeader(max(60, afxGlobalData.GetTextHeight() * 3));

	propSheet.m_psh.dwFlags |= PSH_NOAPPLYNOW;

	propSheet.SetLook(CMFCPropertySheet::PropSheetLook_List, 124);

	propSheet.AddPage(&pageOptions);
	propSheet.AddPage(&pageCustomize);
	propSheet.AddPage(&pageRes);

	if (propSheet.DoModal() != IDOK)
	{
		return;
	}

	// Show ot hide "Developer" tab:
	int nTabDevIndex = m_wndRibbonBar.FindCategoryIndexByData(idTabDeveloper);

	if (theApp.m_bShowDevTab)
	{
		if (nTabDevIndex < 0)
		{
			AddTab_Developer();
		}
	}
	else
	{
		if (nTabDevIndex >= 0)
		{
			m_wndRibbonBar.RemoveCategory(nTabDevIndex );
		}
	}

	// Change application theme and tooltips:
	OnAppLook(theApp.m_nAppLook);

	m_wndRibbonBar.EnableToolTips(theApp.m_bShowToolTips, theApp.m_bShowToolTipDescr);
	m_wndRibbonBar.EnableKeyTips(theApp.m_bShowKeyTips);
}

void CMainFrame::OnWriteClipboard()
{
	m_wndTaskPane.ShowPane(!m_wndTaskPane.IsVisible(), FALSE, TRUE);
}

void CMainFrame::OnUpdateWriteClipboard(CCmdUI* pCmdUI)
{
	pCmdUI->Enable(m_pPrintPreviewFrame == NULL);
}

void CMainFrame::OnViewRtl()
{
	theApp.m_bIsRTL = !theApp.m_bIsRTL;
	OnChangeLayout();
}

void CMainFrame::OnUpdateViewRtl(CCmdUI* pCmdUI)
{
	pCmdUI->SetCheck(theApp.m_bIsRTL);
}

void CMainFrame::OnChangeLayout(CWnd* pWnd/* = NULL*/, BOOL bNoLoopOverPopup/* = FALSE*/)
{
	BOOL bTopLevel = FALSE;

	if (pWnd == NULL)
	{
		pWnd = this;
		bTopLevel = TRUE;
	}

	if (pWnd->IsKindOf(RUNTIME_CLASS(CRichEditView)) || pWnd->IsKindOf(RUNTIME_CLASS(CRichEditCtrl)))
	{
		return;
	}

	if (theApp.m_bIsRTL)
	{
		pWnd->ModifyStyleEx(0, WS_EX_LAYOUTRTL);
	}
	else
	{
		pWnd->ModifyStyleEx(WS_EX_LAYOUTRTL, 0);
	}

	CWnd* pWndChild = pWnd->GetWindow(GW_CHILD);
	while (pWndChild != NULL)
	{
		OnChangeLayout(pWndChild, TRUE);
		pWndChild = pWndChild->GetNextWindow();
	}

	if (!bNoLoopOverPopup)
	{
		CWnd* pWndPopup = pWnd->GetWindow(GW_HWNDFIRST);
		while (pWndPopup != NULL)
		{
			if (pWndPopup->IsKindOf(RUNTIME_CLASS(CPaneFrameWnd)))
			{
				OnChangeLayout(pWndPopup, TRUE);
				pWndPopup->RedrawWindow(NULL, NULL, RDW_ALLCHILDREN | RDW_INVALIDATE | RDW_UPDATENOW | RDW_ERASE);
			}
			pWndPopup = pWndPopup->GetNextWindow();
		}
	}

	if (bTopLevel)
	{
		CMFCToolBarImages::EnableRTL(theApp.m_bIsRTL);

		CMFCToolBar::GetImages()->Mirror();
		CMenuImages::CleanUp();

		OnAppLook(theApp.m_nAppLook);
	}
}

void CMainFrame::OnLink()
{
	CMFCRibbonLinkCtrl* pLink = (CMFCRibbonLinkCtrl*) m_wndStatusBar.FindByID(ID_STATUSBAR_LINK);

	if (pLink != NULL)
	{
		pLink->OpenLink();
	}
}

LRESULT CMainFrame::OnHighlightRibbonListItem(WPARAM wp, LPARAM lp)
{
	int nIndex = (int) wp;

	CMFCRibbonBaseElement* pElem = (CMFCRibbonBaseElement*) lp;
	ASSERT_VALID(pElem);

	UINT uiCommand = pElem->GetID();

	if (nIndex < 0)
	{
		m_wndStatusBar.SetInformation(NULL);
		return 0;
	}

	CString strInfo;

	switch (uiCommand)
	{
	case ID_WRITE_QUICKSTYLES:
		strInfo.Format(_T("Modify document style. Index: %d"), nIndex);
		break;

	case ID_FONT_FONT:
		{
			CMFCRibbonFontComboBox* pFontCombo = (CMFCRibbonFontComboBox*) pElem;
			strInfo.Format(_T("Changing selection font: %s"), pFontCombo->GetItem(nIndex));
		}
		break;

	case ID_FONT_COLOR:
		{
			CMFCRibbonColorButton* pColorButton = (CMFCRibbonColorButton*) pElem;
			COLORREF color = pColorButton->GetHighlightedColor();

			strInfo.Format(_T("Changing selection color: %02X,%02X,%02X"), GetRValue(color), GetGValue(color), GetBValue(color));
		}
		break;

	case ID_INSERT_TABLE:
		{
			strInfo.Format(_T("Insert Table: %d x %d"), CRibbonTableButton::GetColumns(), CRibbonTableButton::GetRows());
		}
		break;

	case ID_PAGELAYOUT_THEMES:
		{
			strInfo.Format(_T("Changing theme: %d"), nIndex);
		}
		break;

	default:
		return 0;
	}

	m_wndStatusBar.SetInformation(strInfo);
	return 0;
}

void CMainFrame::OnViewMessageBar()
{
	ShowPane(&m_wndMessageBar, !(m_wndMessageBar.IsVisible()), FALSE, TRUE);
	RecalcLayout();
}

void CMainFrame::OnUpdateViewMessageBar(CCmdUI* pCmdUI)
{
	pCmdUI->SetCheck(m_wndMessageBar.IsVisible());
}

LRESULT CMainFrame::OnShowRibbonItemMenu(WPARAM /*wp*/, LPARAM lp)
{
	CMFCRibbonBaseElement* pElem = (CMFCRibbonBaseElement*) lp;
	ASSERT_VALID(pElem);

	switch (pElem->GetID())
	{
	case ID_EDIT_UNDO:
		// Fill Undo items list:
		{
			CMFCRibbonUndoButton* pUndo = DYNAMIC_DOWNCAST(CMFCRibbonUndoButton, pElem);
			ASSERT_VALID(pUndo);

			pUndo->CleanUpUndoList();

			pUndo->AddUndoAction(_T("Undo Item 1"));
			pUndo->AddUndoAction(_T("Undo Item 2"));
			pUndo->AddUndoAction(_T("Undo Item 3"));
			pUndo->AddUndoAction(_T("Undo Item 4"));
			pUndo->AddUndoAction(_T("Undo Item 5"));
		}
		break;

	case ID_PARA_BULLETS:
		// Rebuild "Recently used bullets" group:
		{
			CMFCRibbonGallery* pPaletteButton = DYNAMIC_DOWNCAST(CMFCRibbonGallery, pElem);
			ASSERT_VALID(pPaletteButton);

			pPaletteButton->Clear();

			// Load all bullets:
			CMFCToolBarImages imagesAll;
			imagesAll.SetImageSize(CSize(40, 40));
			imagesAll.Load(IDB_BULLETS);

			// Create "Recently used bullets" group:
			CMFCToolBarImages imagesRU;
			imagesRU.SetImageSize(imagesAll.GetImageSize());

			imagesRU.AddIcon(imagesAll.ExtractIcon(1));
			imagesRU.AddIcon(imagesAll.ExtractIcon(7));

			pPaletteButton->AddGroup(_T("Recently Used Bullets"), imagesRU);

			// Add all bullets group:
			pPaletteButton->AddGroup(_T("Bullets"), imagesAll);
		}
		break;

	case ID_FONT_COLOR:
	case ID_PARA_SHADING:
		// Set document text colors:
		{
			CMFCRibbonColorButton* pColorBtn = DYNAMIC_DOWNCAST(CMFCRibbonColorButton, pElem);
			ASSERT_VALID(pColorBtn);

			CList<COLORREF,COLORREF> lstColors;

			lstColors.AddTail(RGB(108, 154, 233));
			lstColors.AddTail(RGB(18, 159, 126));
			lstColors.AddTail(RGB(223, 149, 1));
			lstColors.AddTail(RGB(192, 255, 0));

			pColorBtn->SetDocumentColors(_T("Recent Colors"), lstColors);
		}
		break;
	}

	return 0;
}

void CMainFrame::OnDummy(UINT id)
{
}

void CMainFrame::OnFilePrint()
{
	if (IsPrintPreview())
	{
		PostMessage(WM_COMMAND, AFX_ID_PREVIEW_PRINT);
	}
}

void CMainFrame::OnFilePrintPreview()
{
	if (IsPrintPreview())
	{
		PostMessage(WM_COMMAND, AFX_ID_PREVIEW_CLOSE);      // Force Print Preview Close
	}
}

void CMainFrame::OnUpdateFilePrintPreview(CCmdUI* pCmdUI)
{
	pCmdUI->SetCheck(IsPrintPreview());
}
