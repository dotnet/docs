#include "stdafx.h"
#include "RibbonGadgets.h"

#include "MainFrm.h"

#ifdef _DEBUG
#define new DEBUG_NEW
#undef THIS_FILE
static char THIS_FILE[] = __FILE__;
#endif

const int IdShowProgress1Timer  = 1;
const int IdShowProgress2Timer  = 2;

/////////////////////////////////////////////////////////////////////////////
// CMainFrame

IMPLEMENT_DYNCREATE(CMainFrame, CFrameWndEx)


BEGIN_MESSAGE_MAP(CMainFrame, CFrameWndEx)
	ON_WM_CREATE()
	ON_COMMAND(ID_RIBBON_BTN_7, OnRibbonBtn7)
	ON_UPDATE_COMMAND_UI(ID_RIBBON_BTN_7, OnUpdateRibbonBtn7)
	ON_COMMAND(ID_RIBBON_BTN_8, OnRibbonBtn8)
	ON_UPDATE_COMMAND_UI(ID_RIBBON_BTN_8, OnUpdateRibbonBtn8)
	ON_COMMAND(ID_RIBBON_BTN_9, OnRibbonBtn9)
	ON_UPDATE_COMMAND_UI(ID_RIBBON_BTN_9, OnUpdateRibbonBtn9)
	ON_COMMAND(ID_RIBBON_OBTN_2, OnRibbonObtn2)
	ON_COMMAND(ID_RIBBON_OBTN_3, OnRibbonObtn3)
	ON_COMMAND(ID_RIBBON_OBTN_4, OnRibbonObtn4)
	ON_COMMAND(ID_RIBBON_OBTN_8, OnRibbonObtn8)
	ON_UPDATE_COMMAND_UI(ID_RIBBON_OBTN_8, OnUpdateRibbonObtn8)
	ON_COMMAND(ID_RIBBON_OBTN_10, OnRibbonObtn10)
	ON_UPDATE_COMMAND_UI(ID_RIBBON_OBTN_10, OnUpdateRibbonObtn10)
	ON_WM_TIMER()
	ON_COMMAND_RANGE(ID_VIEW_APPLOOK_2007, ID_VIEW_APPLOOK_2007_3, OnAppLook)
	ON_UPDATE_COMMAND_UI_RANGE(ID_VIEW_APPLOOK_2007, ID_VIEW_APPLOOK_2007_3, OnUpdateAppLook)
	ON_REGISTERED_MESSAGE(AFX_WM_ON_RIBBON_CUSTOMIZE, OnRibbonCustomize)
	ON_REGISTERED_MESSAGE(AFX_WM_ON_CHANGE_RIBBON_CATEGORY, OnChangeRibbonCategory)
	ON_COMMAND(ID_TOOLS_OPTIONS, OnToolsOptions)
	ON_COMMAND_RANGE(ID_RIBBON_A, ID_RIBBON_Z, OnDummy)
	ON_COMMAND(ID_FILE_PRINT, OnFilePrint)
	ON_COMMAND(ID_FILE_PRINT_DIRECT, OnFilePrint)
	ON_COMMAND(ID_FILE_PRINT_PREVIEW, OnFilePrintPreview)
	ON_UPDATE_COMMAND_UI(ID_FILE_PRINT_PREVIEW, OnUpdateFilePrintPreview)
	ON_WM_SYSCOLORCHANGE()
END_MESSAGE_MAP()

/////////////////////////////////////////////////////////////////////////////
// CMainFrame construction/destruction

CMainFrame::CMainFrame()
	: m_bCheckBox1 (TRUE)
	, m_bCheckBox2 (FALSE)
	, m_bCheckBox3 (FALSE)
	, m_nProgressValue1 (-1)
	, m_nProgressValue2 (-1)
{
	m_nAppLook = theApp.GetInt (_T("ApplicationLook"), ID_VIEW_APPLOOK_2007);
}

void CMainFrame::CreateDocumentColors ()
{
	typedef struct 
	{
		COLORREF	color;
		TCHAR*		szName;
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

	m_lstMainColors.RemoveAll ();
	nNumColours = sizeof (colorsMain) / sizeof (ColorTableEntry);

	for (i = 0; i < nNumColours; i++)
	{
		m_lstMainColors.AddTail (colorsMain [i].color);
		CMFCRibbonColorButton::SetColorName (colorsMain [i].color, colorsMain [i].szName);
	};

	m_lstAdditionalColors.RemoveAll ();
	nNumColours = sizeof (colorsAdditional) / sizeof (ColorTableEntry);

	for (i = 0; i < nNumColours; i++)
	{
		m_lstAdditionalColors.AddTail (colorsAdditional [i].color);
		CMFCRibbonColorButton::SetColorName (colorsAdditional [i].color, colorsAdditional [i].szName);
	};

	m_lstStandardColors.RemoveAll ();
	nNumColours = sizeof (colorsStandard) / sizeof (ColorTableEntry);

	for (i = 0; i < nNumColours; i++)
	{
		m_lstStandardColors.AddTail (colorsStandard [i].color);
		CMFCRibbonColorButton::SetColorName (colorsStandard [i].color, colorsStandard [i].szName);
	};
}

CMainFrame::~CMainFrame()
{
}

int CMainFrame::OnCreate(LPCREATESTRUCT lpCreateStruct)
{
	if (CFrameWndEx::OnCreate(lpCreateStruct) == -1)
		return -1;

	OnAppLook (m_nAppLook);

	if (!CreateRibbonBar ())
	{
		TRACE0("Failed to create ribbon bar\n");
		return -1;      // fail to create
	}

	if (!m_wndStatusBar.Create(this))
	{
		TRACE0("Failed to create status bar\n");
		return -1;      // fail to create
	}

	m_wndStatusBar.AddElement (new CMFCRibbonStatusBarPane (ID_STATUSBAR_PANE1, _T("Pane 1"), TRUE), _T("Pane 1"));
	m_wndStatusBar.AddExtendedElement (new CMFCRibbonStatusBarPane (ID_STATUSBAR_PANE2, _T("Pane 2"), TRUE), _T("Pane 2"));

	if (!m_wndOutput.Create (_T("Source Code"), this, CRect (0, 0, 150, 150),
		TRUE /* Has gripper */, ID_VIEW_OUTPUT,
		WS_CHILD | WS_VISIBLE | CBRS_BOTTOM | CBRS_FLOAT_MULTI,
		AFX_CBRS_REGULAR_TABS, AFX_CBRS_RESIZE | AFX_CBRS_AUTOHIDE))
	{
		TRACE0("Failed to create output bar\n");
		return -1;      // fail to create
	}

	EnableDocking(CBRS_ALIGN_ANY);
	EnableAutoHidePanes(CBRS_ALIGN_ANY);
	DockPane(&m_wndOutput);

	OnChangeRibbonCategory (0, 0);
	return 0;
}

BOOL CMainFrame::PreCreateWindow(CREATESTRUCT& cs)
{
	if( !CFrameWndEx::PreCreateWindow(cs) )
		return FALSE;

	cs.style &= ~FWS_ADDTOTITLE;

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
	CDockingManager::SetDockingMode (DT_SMART);

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
			CMFCVisualManagerOffice2007::SetStyle (CMFCVisualManagerOffice2007::Office2007_LunaBlue);
			break;

		case ID_VIEW_APPLOOK_2007_1:
			CMFCVisualManagerOffice2007::SetStyle (CMFCVisualManagerOffice2007::Office2007_ObsidianBlack);
			break;

		case ID_VIEW_APPLOOK_2007_2:
			CMFCVisualManagerOffice2007::SetStyle (CMFCVisualManagerOffice2007::Office2007_Silver);
			break;

		case ID_VIEW_APPLOOK_2007_3:
			CMFCVisualManagerOffice2007::SetStyle (CMFCVisualManagerOffice2007::Office2007_Aqua);
			break;
		}

		CMFCVisualManager::SetDefaultManager (RUNTIME_CLASS (CMFCVisualManagerOffice2007));
		CDockingManager::SetDockingMode (DT_SMART);
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

	CTabbedPane::ResetTabs ();

	RecalcLayout ();
	RedrawWindow (NULL, NULL, RDW_ALLCHILDREN | RDW_INVALIDATE | RDW_UPDATENOW | RDW_ERASE);

	theApp.WriteInt (_T("ApplicationLook"), m_nAppLook);
}

void CMainFrame::OnUpdateAppLook(CCmdUI* pCmdUI)
{
	pCmdUI->SetRadio (m_nAppLook == pCmdUI->m_nID);
}

BOOL CMainFrame::CreateRibbonBar ()
{
	if (!m_wndRibbonBar.Create(this))
	{
		return FALSE;
	}

	// Load panel images:
	m_PanelImages.SetImageSize (CSize (16, 16));
	m_PanelImages.Load (IDB_RIBBON_ICONS);

	// Add main panel:
	Add_MainPanel ();

	Add_Category1 ();
	Add_Category2 ();
	Add_Category3 ();
	Add_Category4 ();
	Add_Category5 ();
	Add_Category6 ();

	// Add quick access toolbar commands:
	Add_QAT ();

	// Add "Style" button to the right of tabs:
	CMFCRibbonButton* pStyleButton = new CMFCRibbonButton ((UINT)-1, _T("Style\ns"), -1, -1);
	pStyleButton->SetMenu (IDR_THEME_MENU, TRUE /* Right align */);
	m_wndRibbonBar.AddToTabs (pStyleButton);

	// Add "About" button to the right of tabs:
	m_wndRibbonBar.AddToTabs (new CMFCRibbonButton (ID_APP_ABOUT, _T("About\na"), m_PanelImages.ExtractIcon (0)));

	return TRUE;
}

void CMainFrame::Add_MainPanel ()
{
	m_MainButton.SetImage (IDB_RIBBON_MAIN);
	m_MainButton.SetToolTipText (_T("File"));
	m_MainButton.SetText (_T("\nf"));

	m_wndRibbonBar.SetApplicationButton (&m_MainButton, CSize (45, 45));

	CMFCRibbonMainPanel* pMainPanel = m_wndRibbonBar.AddMainCategory (_T("File"), IDB_RIBBON_FILE_SMALL, IDB_RIBBON_FILE_LARGE);

	pMainPanel->Add (new CMFCRibbonButton (ID_FILE_NEW, _T("&New"), 0, 0));
	pMainPanel->Add (new CMFCRibbonButton (ID_FILE_OPEN, _T("&Open..."), 1, 1));

	pMainPanel->Add (new CMFCRibbonButton (ID_FILE_SAVE, _T("&Save"), 2, 2));

	pMainPanel->Add (new CMFCRibbonButton (ID_FILE_SAVE_AS, _T("Save &As..."), 3, 3));

	CMFCRibbonButton* pBtnPrint = new CMFCRibbonButton (ID_FILE_PRINT, _T("&Print"), 4, 4);

	pBtnPrint->AddSubItem (new CMFCRibbonLabel (_T("Preview and print the document")));
	pBtnPrint->AddSubItem (new CMFCRibbonButton (ID_FILE_PRINT, _T("&Print"), 4, 4, TRUE));
	pBtnPrint->AddSubItem (new CMFCRibbonButton (ID_FILE_PRINT_DIRECT, _T("&Quick Print"), 6, 6, TRUE));
	pBtnPrint->AddSubItem (new CMFCRibbonButton (ID_FILE_PRINT_PREVIEW, _T("Print Pre&view"), 7, 7, TRUE));

	pBtnPrint->SetKeys (_T("p"), _T("w"));

	pMainPanel->Add (pBtnPrint);

	pMainPanel->AddRecentFilesList (_T("Recent Documents"));

	pMainPanel->AddToBottom (new CMFCRibbonMainPanelButton (ID_TOOLS_OPTIONS, _T("Opt&ions"), 8));
	pMainPanel->AddToBottom (new CMFCRibbonMainPanelButton (ID_APP_EXIT, _T("E&xit"), 9));
}

void CMainFrame::Add_QAT ()
{
	CMFCRibbonQuickAccessToolBarDefaultState qatState;
	qatState.AddCommand (ID_FILE_NEW);
	qatState.AddCommand (ID_FILE_OPEN, FALSE);
	qatState.AddCommand (ID_FILE_SAVE, FALSE);
	qatState.AddCommand (ID_FILE_SAVE_AS);
	qatState.AddCommand (ID_FILE_PRINT_DIRECT);
	qatState.AddCommand (ID_FILE_PRINT_PREVIEW, FALSE);
	m_wndRibbonBar.SetQuickAccessDefaultState (qatState);
}

void CMainFrame::Add_Category1()
{
	CMFCRibbonCategory* pCategory = m_wndRibbonBar.AddCategory(_T("&Buttons"), IDB_RIBBON_CATEGORY1_SMALL, IDB_RIBBON_CATEGORY1_LARGE);

	CMFCRibbonPanel* pPanel1 = pCategory->AddPanel(_T("Large Buttons"));

	CMFCRibbonButton* pBtn1 = new CMFCRibbonButton(ID_RIBBON_BTN_1, _T("Button"), 0, 0);
	pBtn1->SetAlwaysLargeImage();
	pPanel1->Add(pBtn1);

	CMFCRibbonButton* pBtn2 = new CMFCRibbonButton(ID_RIBBON_BTN_2, _T("Menu Button"), 1, 1);
	pBtn2->SetMenu(IDR_RIBBON_MENU_1);
	pBtn2->SetAlwaysLargeImage();
	pPanel1->Add(pBtn2);

	CMFCRibbonButton* pBtn3 = new CMFCRibbonButton(ID_RIBBON_BTN_3, _T("Split Button"), 2, 2);
	pBtn3->SetMenu(IDR_RIBBON_MENU_1, TRUE);
	pBtn3->SetAlwaysLargeImage();
	pBtn3->RemoveSubItem(0);
	pBtn3->AddSubItem(new CMFCRibbonButton(ID_RIBBON_MBTN_1, _T("Item 1"), 2), 0);
	pPanel1->Add(pBtn3);

	CMFCRibbonPanel* pPanel2 = pCategory->AddPanel(_T("Small"));

	CMFCRibbonButton* pBtn4 = new CMFCRibbonButton(ID_RIBBON_BTN_4, _T("Button"), 3);
	pPanel2->Add(pBtn4);

	CMFCRibbonButton* pBtn5 = new CMFCRibbonButton(ID_RIBBON_BTN_5, _T("Menu Button"), 4);
	pBtn5->SetMenu(IDR_RIBBON_MENU_1);
	pPanel2->Add(pBtn5);

	CMFCRibbonButton* pBtn6 = new CMFCRibbonButton(ID_RIBBON_BTN_6, _T("Split Button"), 5);
	pBtn6->SetMenu(IDR_RIBBON_MENU_1, TRUE);
	pBtn6->SetAlwaysLargeImage();
	pBtn6->RemoveSubItem(1);
	pBtn6->AddSubItem(new CMFCRibbonButton(ID_RIBBON_MBTN_2, _T("Item 2"), 5), 1);
	pPanel2->Add(pBtn6);

	CMFCRibbonPanel* pPanel3 = pCategory->AddPanel(_T("Check Boxes"));

	pPanel3->Add(new CMFCRibbonCheckBox(ID_RIBBON_BTN_7, _T("Check Box 1")));
	pPanel3->Add(new CMFCRibbonCheckBox(ID_RIBBON_BTN_8, _T("Check Box 2")));
	pPanel3->Add(new CMFCRibbonCheckBox(ID_RIBBON_BTN_9, _T("Check Box 3")));

	pPanel1->SetData(ID_RIBBON_SOURCE_CODE_1_1);
	pPanel2->SetData(ID_RIBBON_SOURCE_CODE_1_2);
	pPanel3->SetData(ID_RIBBON_SOURCE_CODE_1_3);
}

void CMainFrame::Add_Category2()
{
	CMFCRibbonCategory* pCategory = m_wndRibbonBar.AddCategory(_T("&Palette Buttons"), IDB_RIBBON_CATEGORY2_SMALL, IDB_RIBBON_CATEGORY2_LARGE);

	CMFCRibbonPanel* pPanel1 = pCategory->AddPanel(_T("Standard"));

	pPanel1->Add(new CMFCRibbonGallery(ID_RIBBON_PBTN_1, _T("Embedded"), 0, 0, IDB_RIBBON_PALETTE_1, 64));

	CMFCRibbonGallery* pBtn2 = new CMFCRibbonGallery(ID_RIBBON_PBTN_2, _T("Button"), 1, 1, IDB_RIBBON_PALETTE_1, 64);
	pBtn2->SetButtonMode();
	pBtn2->SetAlwaysLargeImage();
	pPanel1->Add(pBtn2);

	CMFCRibbonPanel* pPanel2 = pCategory->AddPanel(_T("Extended"));

	CMFCRibbonGallery* pBtn3 = new CMFCRibbonGallery(ID_RIBBON_PBTN_3, _T("Resize Vertical"), 2, 2, IDB_RIBBON_PALETTE_1, 64);
	pBtn3->SetButtonMode();
	pBtn3->SetIconsInRow(2);
	pBtn3->EnableMenuResize(TRUE, TRUE);
	pPanel2->Add(pBtn3);

	CMFCRibbonGallery* pBtn4 = new CMFCRibbonGallery(ID_RIBBON_PBTN_4, _T("Resize Both"), 3, 3, IDB_RIBBON_PALETTE_1, 64);
	pBtn4->SetButtonMode();
	pBtn4->SetIconsInRow(4);
	pBtn4->EnableMenuResize(TRUE);
	pPanel2->Add(pBtn4);

	CMFCRibbonGallery* pBtn5 = new CMFCRibbonGallery(ID_RIBBON_PBTN_5, _T("Groups && Subitems"), 4, 4);
	pBtn5->AddGroup(_T("Group 1"), IDB_RIBBON_PALETTE_1, 64);
	pBtn5->AddGroup(_T("Group 2"), IDB_RIBBON_PALETTE_2, 64);
	pBtn5->SetButtonMode();
	pBtn5->SetIconsInRow(4);
	pBtn5->EnableMenuResize(TRUE);
	pBtn5->AddSubItem(new CMFCRibbonButton(ID_RIBBON_MENU_ITEM_1, _T("Item 1")));
	pBtn5->AddSubItem(new CMFCRibbonButton(ID_RIBBON_MENU_ITEM_2, _T("Item 2")));
	pBtn5->AddSubItem(new CMFCRibbonButton(ID_RIBBON_MENU_ITEM_3, _T("Item 3")));
	pPanel2->Add(pBtn5);

	pPanel1->SetData(ID_RIBBON_SOURCE_CODE_2_1);
	pPanel2->SetData(ID_RIBBON_SOURCE_CODE_2_2);
}

void CMainFrame::Add_Category3()
{
	CreateDocumentColors();

	CMFCRibbonCategory* pCategory = m_wndRibbonBar.AddCategory(_T("&Color Buttons"), IDB_RIBBON_CATEGORY3_SMALL, IDB_RIBBON_CATEGORY3_LARGE);

	CMFCRibbonPanel* pPanel1 = pCategory->AddPanel(_T("Large"));

	CMFCRibbonColorButton* pBtn1 = new CMFCRibbonColorButton(ID_RIBBON_CBTN_1, _T("Simple"), TRUE, 0, 0);
	pBtn1->SetAlwaysLargeImage();
	pBtn1->SetDefaultCommand(FALSE);
	pPanel1->Add(pBtn1);

	CMFCRibbonColorButton* pBtn2 = new CMFCRibbonColorButton(ID_RIBBON_CBTN_2, _T("Simple with Options"), TRUE, 1, 1);
	pBtn2->SetAlwaysLargeImage();
	pBtn2->SetDefaultCommand(FALSE);
	pBtn2->EnableAutomaticButton(_T("&Automatic"), RGB(0, 0, 0));
	pBtn2->EnableOtherButton(_T("&More Colors..."), _T("More Colors"));
	pPanel1->Add(pBtn2);

	CMFCRibbonColorButton* pBtn3 = new CMFCRibbonColorButton(ID_RIBBON_CBTN_3, _T("Custom"), TRUE, 2, 2);
	pBtn3->SetAlwaysLargeImage();
	pBtn3->SetDefaultCommand(FALSE);
	pBtn3->EnableAutomaticButton(_T("&Automatic"), RGB(0, 0, 0));
	pBtn3->EnableOtherButton(_T("&More Colors..."), _T("More Colors"));
	pBtn3->SetColumns(10);
	pBtn3->SetColorBoxSize(CSize(17, 17));
	pBtn3->AddColorsGroup(_T("Theme Colors"), m_lstMainColors);
	pBtn3->AddColorsGroup(_T(""), m_lstAdditionalColors, TRUE);
	pBtn3->AddColorsGroup(_T("Standard Colors"), m_lstStandardColors);
	pPanel1->Add(pBtn3);

	CMFCRibbonPanel* pPanel2 = pCategory->AddPanel(_T("Small"));

	CMFCRibbonColorButton* pBtn4 = new CMFCRibbonColorButton(ID_RIBBON_CBTN_4, _T("Simple"), TRUE, 3, -1);
	pBtn4->SetDefaultCommand(FALSE);
	pPanel2->Add(pBtn4);

	CMFCRibbonColorButton* pBtn5 = new CMFCRibbonColorButton(ID_RIBBON_CBTN_5, _T("Simple with Options"), TRUE, 4, -1);
	pBtn5->SetDefaultCommand(FALSE);
	pBtn5->EnableAutomaticButton(_T("&Automatic"), RGB(0, 0, 0));
	pBtn5->EnableOtherButton(_T("&More Colors..."), _T("More Colors"));
	pPanel2->Add(pBtn5);

	CMFCRibbonColorButton* pBtn6 = new CMFCRibbonColorButton(ID_RIBBON_CBTN_6, _T("Custom"), TRUE, 5, -1);
	pBtn6->SetDefaultCommand(FALSE);
	pBtn6->EnableAutomaticButton(_T("&Automatic"), RGB(0, 0, 0));
	pBtn6->EnableOtherButton(_T("&More Colors..."), _T("More Colors"));
	pBtn6->SetColumns(10);
	pBtn6->SetColorBoxSize(CSize(17, 17));
	pBtn6->AddColorsGroup(_T("Theme Colors"), m_lstMainColors);
	pBtn6->AddColorsGroup(_T(""), m_lstAdditionalColors, TRUE);
	pBtn6->AddColorsGroup(_T("Standard Colors"), m_lstStandardColors);
	pPanel2->Add(pBtn6);

	CMFCRibbonPanel* pPanel3 = pCategory->AddPanel(_T("Small with Indicator"));

	CMFCRibbonColorButton* pBtn7 = new CMFCRibbonColorButton(ID_RIBBON_CBTN_7, _T("Simple"), 6);
	pBtn7->SetColor(RGB(255, 0, 0));
	pPanel3->Add(pBtn7);

	CMFCRibbonColorButton* pBtn8 = new CMFCRibbonColorButton(ID_RIBBON_CBTN_8, _T("Simple with Options"), 7);
	pBtn8->SetColor(RGB(0, 0, 255));
	pBtn8->EnableAutomaticButton(_T("&Automatic"), RGB(0, 0, 0));
	pBtn8->EnableOtherButton(_T("&More Colors..."), _T("More Colors"));
	pPanel3->Add(pBtn8);

	CMFCRibbonColorButton* pBtn9 = new CMFCRibbonColorButton(ID_RIBBON_CBTN_9, _T("Custom"), 8);
	pBtn9->EnableAutomaticButton(_T("&Automatic"), RGB(0, 0, 0));
	pBtn9->EnableOtherButton(_T("&More Colors..."), _T("More Colors"));
	pBtn9->SetColumns(10);
	pBtn9->SetColorBoxSize(CSize(17, 17));
	pBtn9->AddColorsGroup(_T("Theme Colors"), m_lstMainColors);
	pBtn9->AddColorsGroup(_T(""), m_lstAdditionalColors, TRUE);
	pBtn9->AddColorsGroup(_T("Standard Colors"), m_lstStandardColors);
	pPanel3->Add(pBtn9);

	CMFCRibbonPanel* pPanel4 = pCategory->AddPanel(_T("Embedded"));

	CMFCRibbonColorButton* pBtn10 = new CMFCRibbonColorButton(ID_RIBBON_CBTN_10, _T("Embedded"), TRUE, 1, 1);
	pBtn10->EnableOtherButton(_T("&More Colors..."), _T("More Shading Colors"));
	pBtn10->SetColor(RGB(240, 240, 240));
	pBtn10->SetColumns(10);
	pBtn10->AddColorsGroup(_T("Theme Colors"), m_lstMainColors);
	pBtn10->AddColorsGroup(_T(""), m_lstAdditionalColors, TRUE);
	pBtn10->AddColorsGroup(_T("Standard Colors"), m_lstStandardColors);
	pBtn10->SetColorBoxSize(CSize(17, 17));
	pBtn10->SetButtonMode(FALSE);
	pBtn10->EnableAutomaticButton(_T("&No Color"), (COLORREF)-1, TRUE, NULL, FALSE /* Bottom */);
	pPanel4->Add(pBtn10);

	pPanel1->SetData(ID_RIBBON_SOURCE_CODE_3_1);
	pPanel2->SetData(ID_RIBBON_SOURCE_CODE_3_2);
	pPanel3->SetData(ID_RIBBON_SOURCE_CODE_3_3);
	pPanel4->SetData(ID_RIBBON_SOURCE_CODE_3_4);
}

void CMainFrame::Add_Category4()
{
	CMFCRibbonCategory* pCategory = m_wndRibbonBar.AddCategory(_T("&Groups"), IDB_RIBBON_CATEGORY4_SMALL, 0);

	CMFCRibbonPanel* pPanel1 = pCategory->AddPanel(_T("From Toolbar"));

	pPanel1->AddToolBar(IDR_TOOLBAR);

	CMFCRibbonPanel* pPanel2 = pCategory->AddPanel(_T("Manual"));

	CMFCRibbonButtonsGroup* pButtonsGroup1 = new CMFCRibbonButtonsGroup;

	pButtonsGroup1->AddButton(new CMFCRibbonButton(ID_RIBBON_GBTN_1, _T(""), 0));
	pButtonsGroup1->AddButton(new CMFCRibbonButton(ID_RIBBON_GBTN_2, _T(""), 1));

	CMFCRibbonEdit* pEdit = new CMFCRibbonEdit(ID_RIBBON_GBTN_3, 65);
	pEdit->SetEditText(_T("Edit"));
	pButtonsGroup1->AddButton(pEdit);

	pButtonsGroup1->AddButton(new CMFCRibbonButton(ID_RIBBON_GBTN_4, _T(""), 2));
	pButtonsGroup1->AddButton(new CMFCRibbonButton(ID_RIBBON_GBTN_5, _T(""), 3));

	pPanel2->Add(pButtonsGroup1);

	CMFCRibbonButtonsGroup* pButtonsGroup2 = new CMFCRibbonButtonsGroup;
	pButtonsGroup2->AddButton(new CMFCRibbonButton(ID_RIBBON_GBTN_6, _T(""), 4));
	pButtonsGroup2->AddButton(new CMFCRibbonButton(ID_RIBBON_GBTN_7, _T(""), 5));
	pButtonsGroup2->AddButton(new CMFCRibbonButton(ID_RIBBON_GBTN_8, _T(""), 6));
	pButtonsGroup2->AddButton(new CMFCRibbonButton(ID_RIBBON_GBTN_9, _T(""), 7));
	
	pPanel2->Add(pButtonsGroup2);

	CMFCRibbonButtonsGroup* pButtonsGroup3 = new CMFCRibbonButtonsGroup;

	CMFCRibbonButton* pBtn10 = new CMFCRibbonButton(ID_RIBBON_GBTN_10, _T(""), 8);
	pBtn10->SetMenu(IDR_RIBBON_MENU_1);
	pButtonsGroup3->AddButton(pBtn10);

	CMFCRibbonButton* pBtn11 = new CMFCRibbonButton(ID_RIBBON_GBTN_11, _T(""), 9);
	pBtn11->SetMenu(IDR_RIBBON_MENU_1, TRUE);
	pButtonsGroup3->AddButton(pBtn11);

	pPanel2->Add(pButtonsGroup3);

	pPanel1->SetData(ID_RIBBON_SOURCE_CODE_4_1);
	pPanel2->SetData(ID_RIBBON_SOURCE_CODE_4_2);
}

void CMainFrame::Add_Category5()
{
	int i = 0;
	
	CMFCRibbonCategory* pCategory = m_wndRibbonBar.AddCategory(_T("&Edit and Combo"), IDB_RIBBON_CATEGORY5_SMALL, 0);

	CMFCRibbonPanel* pPanel1 = pCategory->AddPanel(_T("Standard"));

	CMFCRibbonEdit* pBtn1 = new CMFCRibbonEdit(ID_RIBBON_EBTN_1, 90);
	pBtn1->SetEditText(_T("Edit"));
	pPanel1->Add(pBtn1);

	CMFCRibbonEdit* pBtn2 = new CMFCRibbonEdit(ID_RIBBON_EBTN_2, 90);
	pBtn2->EnableSpinButtons(0, 99);
	pBtn2->SetEditText(_T("0"));
	pPanel1->Add(pBtn2);

	CMFCRibbonComboBox* pBtn3 = new CMFCRibbonComboBox(ID_RIBBON_EBTN_3, TRUE, 74);
	pBtn3->AddItem(_T("Combo Box"));
	for (i = 0; i < 20; i++)
	{
		CString str;
		str.Format(_T("Item %d"), i + 1);
		pBtn3->AddItem(str);
	}
	pBtn3->SelectItem(0);
	pPanel1->Add(pBtn3);

	CMFCRibbonPanel* pPanel2 = pCategory->AddPanel(_T("With Icons and Labels"));

	CMFCRibbonEdit* pBtn4 = new CMFCRibbonEdit(ID_RIBBON_EBTN_4, 90, _T("Label:"), 0);
	pBtn4->SetEditText(_T("Edit"));
	pPanel2->Add(pBtn4);

	CMFCRibbonEdit* pBtn5 = new CMFCRibbonEdit(ID_RIBBON_EBTN_5, 90, _T("Label:"), 1);
	pBtn5->EnableSpinButtons(0, 99);
	pBtn5->SetEditText(_T("0"));
	pPanel2->Add(pBtn5);

	CMFCRibbonComboBox* pBtn6 = new CMFCRibbonComboBox(ID_RIBBON_EBTN_6, TRUE, 74, _T("Label:"), 2);
	pBtn6->AddItem(_T("Combo Box"));
	for (i = 0; i < 20; i++)
	{
		CString str;
		str.Format(_T("Item %d"), i + 1);
		pBtn6->AddItem(str);
	}
	pBtn6->SelectItem(0);
	pPanel2->Add(pBtn6);

	CMFCRibbonPanel* pPanel3 = pCategory->AddPanel(_T("Font"));

	CMFCRibbonFontComboBox::m_bDrawUsingFont = TRUE;
	CMFCRibbonFontComboBox* pBtn7 = new CMFCRibbonFontComboBox(ID_RIBBON_EBTN_7);
	pBtn7->SelectItem(_T("Arial"));
	pPanel3->Add(pBtn7);

	pPanel1->SetData(ID_RIBBON_SOURCE_CODE_5_1);
	pPanel2->SetData(ID_RIBBON_SOURCE_CODE_5_2);
	pPanel3->SetData(ID_RIBBON_SOURCE_CODE_5_3);
}

void CMainFrame::Add_Category6()
{
	CMFCRibbonCategory* pCategory = m_wndRibbonBar.AddCategory(_T("&Other"), IDB_RIBBON_CATEGORY6_SMALL, IDB_RIBBON_CATEGORY6_LARGE);

	CMFCRibbonPanel* pPanel1 = pCategory->AddPanel(_T("Undo"));

	// <snippet2>
	// The third parameter is the zero-based index in the image list of the parent 
	// object for the button's small image.
	// The fourth parameter is the zero-based index in the image list of the parent object 
	// for the of button's large image.
	CMFCRibbonUndoButton* pBtn1 = new CMFCRibbonUndoButton(ID_RIBBON_OBTN_1, _T("Undo"), 0, 0);
	for (int i = 0; i < 20; i++)
	{
		CString str;
		str.Format(_T("Action %d"), i + 1);
		pBtn1->AddUndoAction(str);
	}
	// </snippet2>
	pPanel1->Add(pBtn1);

	CMFCRibbonPanel* pPanel2 = pCategory->AddPanel(_T("Label"));

	pPanel2->Add(new CMFCRibbonLabel(_T("Label 1")));
	pPanel2->Add(new CMFCRibbonLabel(_T("Label 2")));
	pPanel2->Add(new CMFCRibbonLabel(_T("Label 3")));

	pPanel2->Add(new CMFCRibbonSeparator());

	pPanel2->Add(new CMFCRibbonLabel(_T("This is a multi-line label"), TRUE));

	CMFCRibbonPanel* pPanel3 = pCategory->AddPanel(_T("Hyperlink"));

	// <snippet1>
	// CMFCRibbonPanel* pPanel3
	pPanel3->Add(new CMFCRibbonLinkCtrl(ID_RIBBON_OBTN_2, _T("Send email"), _T("mailto:info@microsoft.com")));
	// </snippet1>
	pPanel3->Add(new CMFCRibbonLinkCtrl(ID_RIBBON_OBTN_3, _T("Visit site"), _T("http://www.microsoft.com")));
	pPanel3->Add(new CMFCRibbonLinkCtrl(ID_RIBBON_OBTN_4, _T("Launch Notepad"), _T("notepad")));

	CMFCRibbonPanel* pPanel4 = pCategory->AddPanel(_T("Sliders"));
	pPanel4->SetCenterColumnVert();

	pPanel4->Add(new CMFCRibbonLabel(_T("Simple Slider:")));
	pPanel4->Add(new CMFCRibbonSlider(ID_RIBBON_OBTN_5, 70 /* Slider width */));

	pPanel4->Add(new CMFCRibbonSeparator());

	pPanel4->Add(new CMFCRibbonLabel(_T("Slider with Buttons:")));
	CMFCRibbonSlider* pBtn6 = new CMFCRibbonSlider(ID_RIBBON_OBTN_6, 70 /* Slider width */);
	pBtn6->SetZoomButtons();
	pBtn6->SetRange(0, 100);
	pBtn6->SetPos(50);
	pPanel4->Add(pBtn6);

	CMFCRibbonPanel* pPanel5 = pCategory->AddPanel(_T("Progress Bars"));
	pPanel5->SetCenterColumnVert();

	pPanel5->Add(new CMFCRibbonLabel(_T("Simple Progress:")));
	pPanel5->Add(new CMFCRibbonProgressBar(ID_RIBBON_OBTN_7, 100 /* Bar width */));
	pPanel5->Add(new CMFCRibbonButton(ID_RIBBON_OBTN_8, _T("Show Progress 1")));

	pPanel5->Add(new CMFCRibbonSeparator());

	pPanel5->Add(new CMFCRibbonLabel(_T("Infinite Progress:")));
	CMFCRibbonProgressBar* pBtn9 = new CMFCRibbonProgressBar(ID_RIBBON_OBTN_9, 100 /* Bar width */);
	pBtn9->SetInfiniteMode();
	pPanel5->Add(pBtn9);

	pPanel5->Add(new CMFCRibbonButton(ID_RIBBON_OBTN_10, _T("Show Progress 2")));

	pPanel1->SetData(ID_RIBBON_SOURCE_CODE_6_1);
	pPanel2->SetData(ID_RIBBON_SOURCE_CODE_6_2);
	pPanel3->SetData(ID_RIBBON_SOURCE_CODE_6_3);
	pPanel4->SetData(ID_RIBBON_SOURCE_CODE_6_4);
	pPanel5->SetData(ID_RIBBON_SOURCE_CODE_6_5);
}

LRESULT CMainFrame::OnRibbonCustomize (WPARAM /*wp*/, LPARAM /*lp*/)
{
	ShowOptions (0);
	return 1;
}

void CMainFrame::OnToolsOptions()
{
	ShowOptions (0);
}

void CMainFrame::ShowOptions (int nPage)
{
	// Create "Customize" page:
	CMFCRibbonCustomizePropertyPage pageCustomize (&m_wndRibbonBar);

	// Add "popular" items:
	CList<UINT, UINT> lstPopular;

	lstPopular.AddTail (ID_FILE_NEW);
	lstPopular.AddTail (ID_FILE_OPEN);
	lstPopular.AddTail (ID_FILE_SAVE);
	lstPopular.AddTail (ID_FILE_PRINT_PREVIEW);
	lstPopular.AddTail (ID_FILE_PRINT_DIRECT);
	lstPopular.AddTail (ID_EDIT_UNDO);

	pageCustomize.AddCustomCategory (_T("Popular Commands"), lstPopular);

	// Add hidden commands:
	CList<UINT,UINT> lstHidden;
	m_wndRibbonBar.GetItemIDsList (lstHidden, TRUE);

	pageCustomize.AddCustomCategory (_T("Commands not in the Ribbon"), lstHidden);

	// Add all commands:
	CList<UINT,UINT> lstAll;
	m_wndRibbonBar.GetItemIDsList (lstAll);

	pageCustomize.AddCustomCategory (_T("All Commands"), lstAll);

	// Create property sheet:
	CMFCPropertySheet propSheet (_T("Options"), this, nPage);
	propSheet.m_psh.dwFlags |= PSH_NOAPPLYNOW;

	propSheet.SetLook (CMFCPropertySheet::PropSheetLook_List, 124 /* List width */);

	propSheet.AddPage (&pageCustomize);

	// TODO: add your option pages here:
	// COptionsPage1 pageOptions1;
	// propSheet.AddPage (&pageOptions1);
	//
	// COptionsPage1 pageOptions2;
	// propSheet.AddPage (&pageOptions2);

	if (propSheet.DoModal() != IDOK)
	{
		return;
	}
}

void CMainFrame::OnDummy(UINT /*id*/)
{
}

void CMainFrame::OnRibbonBtn7() 
{
	m_bCheckBox1 = !m_bCheckBox1;
}

void CMainFrame::OnUpdateRibbonBtn7(CCmdUI* pCmdUI) 
{
	pCmdUI->SetCheck (m_bCheckBox1);	
}

void CMainFrame::OnRibbonBtn8() 
{
	m_bCheckBox2 = !m_bCheckBox2;
}

void CMainFrame::OnUpdateRibbonBtn8(CCmdUI* pCmdUI) 
{
	pCmdUI->SetCheck (m_bCheckBox2);
}

void CMainFrame::OnRibbonBtn9() 
{
	m_bCheckBox3 = !m_bCheckBox3;	
}

void CMainFrame::OnUpdateRibbonBtn9(CCmdUI* pCmdUI) 
{
	pCmdUI->SetCheck (m_bCheckBox3);
}

void CMainFrame::OnLink (UINT nID)
{
	CArray<CMFCRibbonBaseElement*, CMFCRibbonBaseElement*> ar;
	m_wndRibbonBar.GetElementsByID (nID, ar);

	if (ar.GetSize () >= 1)
	{
		CMFCRibbonLinkCtrl* pLink = DYNAMIC_DOWNCAST (CMFCRibbonLinkCtrl, ar[0]);
		if (pLink != NULL)
		{
			if (!pLink->OpenLink ())
			{
				AfxMessageBox (_T("Link clicked."));
			}
		}
	}
}

int CMainFrame::GetSliderPos (UINT nID)
{
	CArray<CMFCRibbonBaseElement*, CMFCRibbonBaseElement*> ar;
	CArray<CMFCRibbonBaseElement*, CMFCRibbonBaseElement*> ar2;
	m_wndRibbonBar.GetElementsByID (ID_RIBBON_OBTN_5, ar);
	m_wndRibbonBar.GetElementsByID (ID_RIBBON_OBTN_6, ar2);

	ar.Append (ar2);

	int nPos1 = -1;
	int nPos2 = -1;

	for (int k = 0; k < 2; k++)
	{
		for (int i = 0; i < ar.GetSize (); i++)
		{
			CMFCRibbonSlider* pSlider = DYNAMIC_DOWNCAST (CMFCRibbonSlider, ar[i]);
			if (pSlider != NULL)
			{
				if (k == 0)
				{
					if (pSlider->GetID () != nID)
					{
						nPos2 = pSlider->GetPos ();
						nPos1 = nPos2;
						break;
					}
				}
				else
				{
					if (pSlider->GetID () == nID)
					{
						if (pSlider->GetPos () != nPos2)
						{
							nPos1 = pSlider->GetPos ();
						}
					}
				}
			}
		}
	}

	return nPos1;
}

void CMainFrame::SetSliderPos (int nPos, UINT nID)
{
	CArray<CMFCRibbonBaseElement*, CMFCRibbonBaseElement*> ar;
	m_wndRibbonBar.GetElementsByID (nID, ar);

	for (int i = 0; i < ar.GetSize (); i++)
	{
		CMFCRibbonSlider* pSlider = DYNAMIC_DOWNCAST (CMFCRibbonSlider, ar[i]);
		if (pSlider != NULL)
		{
			if (pSlider->GetPos () != nPos)
			{
				pSlider->SetPos (nPos);
			}
		}
	}
}

void CMainFrame::SetProgressPos (int nPos, UINT nID)
{
	CArray<CMFCRibbonBaseElement*, CMFCRibbonBaseElement*> ar;
	m_wndRibbonBar.GetElementsByID (nID, ar);

	for (int i = 0; i < ar.GetSize (); i++)
	{
		CMFCRibbonProgressBar* pProgress = DYNAMIC_DOWNCAST (CMFCRibbonProgressBar, ar[i]);
		if (pProgress != NULL)
		{
			if (pProgress->GetPos () != nPos)
			{
				pProgress->SetPos (nPos);
			}
		}
	}
}

void CMainFrame::OnRibbonObtn2() 
{
	OnLink (ID_RIBBON_OBTN_2);
}

void CMainFrame::OnRibbonObtn3() 
{
	OnLink (ID_RIBBON_OBTN_3);	
}

void CMainFrame::OnRibbonObtn4() 
{
	OnLink (ID_RIBBON_OBTN_4);
}

void CMainFrame::OnRibbonObtn8() 
{
	m_nProgressValue1 = 0;
	SetTimer (IdShowProgress1Timer, 10, NULL);
}

void CMainFrame::OnUpdateRibbonObtn8(CCmdUI* pCmdUI) 
{
	pCmdUI->Enable (m_nProgressValue1 == -1);
}

void CMainFrame::OnRibbonObtn10() 
{
	m_nProgressValue2 = 0;
	SetTimer (IdShowProgress2Timer, 10, NULL);
}

void CMainFrame::OnUpdateRibbonObtn10(CCmdUI* pCmdUI) 
{
	pCmdUI->Enable (m_nProgressValue2 == -1);
}

void CMainFrame::OnTimer(UINT_PTR nIDEvent) 
{
	if (nIDEvent == IdShowProgress1Timer)
	{
		m_nProgressValue1++;

		if (m_nProgressValue1 > 100)
		{
			m_nProgressValue1 = -1;
			KillTimer (nIDEvent);
			SetProgressPos (0, ID_RIBBON_OBTN_7);
		}
		else
		{
			SetProgressPos (m_nProgressValue1, ID_RIBBON_OBTN_7);
		}
		
		CMFCPopupMenu::UpdateAllShadows ();
	}
	else if (nIDEvent == IdShowProgress2Timer)
	{
		m_nProgressValue2++;

		if (m_nProgressValue2 > 100)
		{
			m_nProgressValue2 = -1;
			KillTimer (nIDEvent);
			SetProgressPos (0, ID_RIBBON_OBTN_9);
		}
		else
		{
			SetProgressPos (m_nProgressValue2, ID_RIBBON_OBTN_9);
		}

		CMFCPopupMenu::UpdateAllShadows ();
	}
}

LRESULT CMainFrame::OnChangeRibbonCategory(WPARAM,LPARAM)
{
	if (!m_wndOutput.IsAutoHideMode ())
	{
		m_wndOutput.SetRedraw (FALSE);
	}

	m_wndOutput.ClearTabs ();

	CMFCRibbonCategory* pCategory = m_wndRibbonBar.GetActiveCategory ();
	if (pCategory != NULL)
	{
		ASSERT_VALID (pCategory);

		for (int i = 0; i < pCategory->GetPanelCount (); i++)
		{
			CMFCRibbonPanel* pPanel = pCategory->GetPanel (i);
			ASSERT_VALID (pPanel);

			m_wndOutput.AddTab (pPanel->GetName (), (UINT)pPanel->GetData ());
		}
	}

	if (!m_wndOutput.IsAutoHideMode ())
	{
		m_wndOutput.SetRedraw ();
		m_wndOutput.RedrawWindow (NULL, NULL, RDW_INVALIDATE | RDW_UPDATENOW | RDW_ALLCHILDREN);
	}

	return 0;
}

void CMainFrame::OnFilePrint ()
{
	if (IsPrintPreview ())
	{
		PostMessage (WM_COMMAND, AFX_ID_PREVIEW_PRINT);
	}
}

void CMainFrame::OnFilePrintPreview()
{
	if (IsPrintPreview ())
	{
		PostMessage (WM_COMMAND, AFX_ID_PREVIEW_CLOSE);      // Force Print Preview Close
	}
}

void CMainFrame::OnUpdateFilePrintPreview(CCmdUI* pCmdUI) 
{
	pCmdUI->SetCheck (IsPrintPreview ());
}

void CMainFrame::OnSysColorChange() 
{
	BOOL bWasWindowRgn = m_Impl.HasRegion ();

	CFrameWndEx::OnSysColorChange();

	m_Impl.OnChangeVisualManager ();

	if (bWasWindowRgn && ! m_Impl.HasRegion ())
	{
		SetWindowRgn (NULL, TRUE);
	}
}
