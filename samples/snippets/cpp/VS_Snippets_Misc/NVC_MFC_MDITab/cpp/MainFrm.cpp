// MainFrm.cpp : implementation of the CMainFrame class
//

#include "stdafx.h"
#include "MFCRibbonApp.h"

#include "MainFrm.h"

#ifdef _DEBUG
#define new DEBUG_NEW
#endif

// CMainFrame

IMPLEMENT_DYNAMIC(CMainFrame, CMDIFrameWndEx)

BEGIN_MESSAGE_MAP(CMainFrame, CMDIFrameWndEx)
	ON_WM_CREATE()
	ON_COMMAND(ID_WINDOW_MANAGER, &CMainFrame::OnWindowManager)
	ON_COMMAND_RANGE(ID_VIEW_APPLOOK_WIN_2000, ID_VIEW_APPLOOK_OFF_2007_AQUA, OnApplicationLook)
	ON_UPDATE_COMMAND_UI_RANGE(ID_VIEW_APPLOOK_WIN_2000, ID_VIEW_APPLOOK_OFF_2007_AQUA, OnUpdateApplicationLook)
	ON_COMMAND( ID_SLIDER_CONTROL, OnSliding )
	ON_REGISTERED_MESSAGE( AFX_WM_ON_GET_TAB_TOOLTIP, OnTooltips )
	ON_WM_ACTIVATE()
END_MESSAGE_MAP()

// CMainFrame construction/destruction

CMainFrame::CMainFrame()
{
	// TODO: add member initialization code here
	theApp.m_nAppLook = theApp.GetInt(_T("ApplicationLook"), ID_VIEW_APPLOOK_OFF_2007_BLUE);
	m_ribbonSlider = new CMFCRibbonSlider(ID_SLIDER_CONTROL, 500 );
}

CMainFrame::~CMainFrame()
{
}

LRESULT CMainFrame::OnTooltips(WPARAM /*wp*/, LPARAM lp) 
{
	CMFCTabToolTipInfo* pInfo = (CMFCTabToolTipInfo*) lp;
	ASSERT (pInfo != NULL);
	ASSERT_VALID (pInfo->m_pTabWnd);

	if (!pInfo->m_pTabWnd->IsMDITab ())
	{
		return 0;
	}

	pInfo->m_strText.Format (_T("Tab #%d Custom Tooltip"), pInfo->m_nTabIndex + 1);
	return 0;
}

void CMainFrame::OnSliding( ) 
{
	CString cstr;

	if (GetAsyncKeyState (VK_LBUTTON) == 0)
	{
		cstr.Format( _T( "position %d" ), m_ribbonSlider -> GetPos() ),  
		AfxMessageBox( cstr );
	}
}

int CMainFrame::OnCreate(LPCREATESTRUCT lpCreateStruct)
{
	if (CMDIFrameWndEx::OnCreate(lpCreateStruct) == -1)
		return -1;
	// set the visual manager and style based on persisted value
	OnApplicationLook(theApp.m_nAppLook);

	// <snippet1>
	CMDITabInfo mdiTabParams;
	mdiTabParams.m_style = CMFCTabCtrl::STYLE_3D_ONENOTE; 
	// set to FALSE to place close button at right of tab area
	mdiTabParams.m_bActiveTabCloseButton = FALSE;
	// set to TRUE to enable document icons on MDI taba
	mdiTabParams.m_bTabIcons = TRUE;    
	// set to FALSE to disable auto-coloring of MDI tabs
	mdiTabParams.m_bAutoColor = FALSE; 
	// set to TRUE to enable the document menu at the right edge of the tab area
	mdiTabParams.m_bDocumentMenu = TRUE; 
	//set to TRUE to enable the user to change the tabs positions by dragging the tabs
	mdiTabParams.m_bEnableTabSwap = TRUE;
	// set to TRUE to give each tab window has a flat frame
	mdiTabParams.m_bFlatFrame = TRUE;
	// set to TRUE to enable each tab window to display the Close button on the right edge of the tab. 
	mdiTabParams.m_bTabCloseButton = FALSE;
	// set to TRUE to enable the tabs to display tooltips.
	mdiTabParams.m_bTabCustomTooltips = TRUE;
	// Specifies that the tabs labels are located at the top of the page
	mdiTabParams.m_tabLocation = CMFCTabCtrl::LOCATION_TOP;
	EnableMDITabbedGroups(TRUE, mdiTabParams);
	// </snippet1>
     
	m_wndRibbonBar.Create(this,WS_CHILD|CBRS_TOP);
	InitializeRibbon();

	if (!m_wndStatusBar.Create(this))
	{
		TRACE0("Failed to create status bar\n");
		return -1;      // fail to create
	}

	CString strTitlePane1;
	CString strTitlePane2;
	strTitlePane1.LoadString(IDS_STATUS_PANE1);
	strTitlePane2.LoadString(IDS_STATUS_PANE2);

	CMFCRibbonStatusBarPane* rsbp = new CMFCRibbonStatusBarPane( ID_STATUSBAR_PANE1, strTitlePane1, TRUE );
	rsbp->SetTextAlign( TA_CENTER );
		
	m_wndStatusBar.AddElement(rsbp, strTitlePane1);
	m_wndStatusBar.AddExtendedElement(new CMFCRibbonStatusBarPane(ID_STATUSBAR_PANE2, strTitlePane2, TRUE), strTitlePane2);

	// enable Visual Studio 2005 style docking window behavior
	CDockingManager::SetDockingMode(DT_SMART);
	// enable Visual Studio 2005 style docking window auto-hide behavior
	EnableAutoHidePanes(CBRS_ALIGN_ANY);

	// Enable enhanced windows management dialog
	EnableWindowsDialog(ID_WINDOW_MANAGER, IDS_WINDOWS_MANAGER, TRUE);

	return 0;
}

BOOL CMainFrame::PreCreateWindow(CREATESTRUCT& cs)
{
	if( !CMDIFrameWndEx::PreCreateWindow(cs) )
		return FALSE;
	// TODO: Modify the Window class or styles here by modifying
	//  the CREATESTRUCT cs

	return TRUE;
}

void CMainFrame::InitializeRibbon()
{
	CString strTemp;
	strTemp.LoadString(IDS_RIBBON_FILE);

	// Load panel images:
	m_PanelImages.SetImageSize(CSize(16, 16));
	m_PanelImages.Load(IDB_BUTTONS);

	// Init main button:
	m_MainButton.SetImage(IDB_MAIN);
	m_MainButton.SetText(_T("\nf"));
	m_MainButton.SetToolTipText(strTemp);

	m_wndRibbonBar.SetApplicationButton(&m_MainButton, CSize (45, 45));

	m_wndRibbonBar.EnableToolTips( true, false );

	CMFCRibbonMainPanel* pMainPanel = m_wndRibbonBar.AddMainCategory(strTemp, IDB_FILESMALL, IDB_FILELARGE);

	strTemp.LoadString(IDS_RIBBON_NEW);
	pMainPanel->Add(new CMFCRibbonButton(ID_FILE_NEW, strTemp, 0, 0));
	strTemp.LoadString(IDS_RIBBON_OPEN);
	pMainPanel->Add(new CMFCRibbonButton(ID_FILE_OPEN, strTemp, 1, 1));
	strTemp.LoadString(IDS_RIBBON_SAVE);
	pMainPanel->Add(new CMFCRibbonButton(ID_FILE_SAVE, strTemp, 2, 2));
	strTemp.LoadString(IDS_RIBBON_SAVEAS);
	pMainPanel->Add(new CMFCRibbonButton(ID_FILE_SAVE_AS, strTemp, 3, 3));

	strTemp.LoadString(IDS_RIBBON_PRINT);
	CMFCRibbonButton* pBtnPrint = new CMFCRibbonButton(ID_FILE_PRINT, strTemp, 6, 6);
	pBtnPrint->SetKeys(_T("p"), _T("w"));
	strTemp.LoadString(IDS_RIBBON_PRINT_LABEL);
	pBtnPrint->AddSubItem(new CMFCRibbonLabel(strTemp));
	strTemp.LoadString(IDS_RIBBON_PRINT_QUICK);
	pBtnPrint->AddSubItem(new CMFCRibbonButton(ID_FILE_PRINT_DIRECT, strTemp, 7, 7, TRUE));
	strTemp.LoadString(IDS_RIBBON_PRINT_PREVIEW);
	pBtnPrint->AddSubItem(new CMFCRibbonButton(ID_FILE_PRINT_PREVIEW, strTemp, 8, 8, TRUE));
	strTemp.LoadString(IDS_RIBBON_PRINT_SETUP);
	pBtnPrint->AddSubItem(new CMFCRibbonButton(ID_FILE_PRINT_SETUP, strTemp, 11, 11, TRUE));
	pMainPanel->Add(pBtnPrint);
	pMainPanel->Add(new CMFCRibbonSeparator(TRUE));

	strTemp.LoadString(IDS_RIBBON_CLOSE);
	pMainPanel->Add(new CMFCRibbonButton(ID_FILE_CLOSE, strTemp, 9, 9));

	strTemp.LoadString(IDS_RIBBON_RECENT_DOCS);
	pMainPanel->AddRecentFilesList(strTemp);

	strTemp.LoadString(IDS_RIBBON_EXIT);
	pMainPanel->AddToBottom(new CMFCRibbonMainPanelButton(ID_APP_EXIT, strTemp, 15));

	// Add "Home" category with "Clipboard" panel:
	strTemp.LoadString(IDS_RIBBON_HOME);
	CMFCRibbonCategory* pCategoryHome = m_wndRibbonBar.AddCategory(strTemp, IDB_WRITESMALL, IDB_WRITELARGE);

	 

	CMFCRibbonCategory* activeCategory = m_wndRibbonBar.GetActiveCategory();
	//MessageBox( activeCategory ->GetName() );
	
	m_wndRibbonBar.AddContextCategory( _T( "HI" ), _T( "there" ), IDS_RIBBON_HOME, AFX_CategoryColor_Red, IDB_WRITESMALL, IDB_WRITELARGE );

	CString cstr;
	cstr.Format( _T( "category count %d" ), m_wndRibbonBar.GetCategoryCount() ); 
	//MessageBox( cstr );
		
	
	if ( m_wndRibbonBar.GetContextName( IDS_RIBBON_HOME, cstr ) )
	{
		//MessageBox( cstr );
	}
	

	CMFCRibbonCategory* mainCategory = m_wndRibbonBar.GetMainCategory();

	//MessageBox( mainCategory ->GetName() );

	// Create "Clipboard" panel:
	strTemp.LoadString(IDS_RIBBON_CLIPBOARD);
	CMFCRibbonPanel* pPanelClipboard = pCategoryHome->AddPanel(strTemp, m_PanelImages.ExtractIcon(27));

	strTemp.LoadString(IDS_RIBBON_PASTE);
	CMFCRibbonButton* pBtnPaste = new CMFCRibbonButton(ID_EDIT_PASTE, strTemp, 0, 0);
	pPanelClipboard->Add(pBtnPaste);

	strTemp.LoadString(IDS_RIBBON_CUT);
	pPanelClipboard->Add(new CMFCRibbonButton(ID_EDIT_CUT, strTemp, 1));
	strTemp.LoadString(IDS_RIBBON_COPY);
	pPanelClipboard->Add(new CMFCRibbonButton(ID_EDIT_COPY, strTemp, 2));
	strTemp.LoadString(IDS_RIBBON_SELECTALL);
	pPanelClipboard->Add(new CMFCRibbonButton(ID_EDIT_SELECT_ALL, strTemp, -1));

	// Create and add a "View" panel:
	strTemp.LoadString(IDS_RIBBON_VIEW);
	CMFCRibbonPanel* pPanelView = pCategoryHome->AddPanel(strTemp, m_PanelImages.ExtractIcon (7));

	strTemp.LoadString(IDS_RIBBON_STATUSBAR);
	CMFCRibbonButton* pBtnStatusBar = new CMFCRibbonCheckBox(ID_VIEW_STATUS_BAR, strTemp);
	pPanelView->Add(pBtnStatusBar);

	// Create and add a "Windows" panel:
	strTemp.LoadString(IDS_RIBBON_WINDOW);
	CMFCRibbonPanel* pPanelWindow = pCategoryHome->AddPanel(strTemp, m_PanelImages.ExtractIcon (7));

	strTemp.LoadString(IDS_RIBBON_WINDOWS);

	//MessageBox( strTemp );
	strTemp = "Sam";
	CMFCRibbonButton* pBtnWindows = new CMFCRibbonButton(ID_WINDOW_MANAGER, strTemp, -1, 1);
	pBtnWindows->SetMenu(IDR_WINDOWS_MENU, TRUE);
	pPanelWindow->Add(pBtnWindows);

	// Add elements to the right side of tabs:
	strTemp.LoadString(IDS_RIBBON_STYLE);
	CMFCRibbonButton* pVisualStyleButton = new CMFCRibbonButton(1, strTemp, -1, -1);

	pVisualStyleButton->SetMenu(IDR_THEME_MENU, TRUE /* No default command */, TRUE /* Right align */);

	CString strp;

	strp.Format( _T( "%d" ), pVisualStyleButton ->GetQuickAccessToolBarID() );

	//MessageBox( strp );

	strTemp.LoadString(IDS_RIBBON_STYLE_TIP);
	pVisualStyleButton->SetToolTipText(strTemp);
	strTemp.LoadString(IDS_RIBBON_STYLE_DESC);
	pVisualStyleButton->SetDescription(strTemp);
	m_wndRibbonBar.AddToTabs(pVisualStyleButton);

	pVisualStyleButton -> SetDefaultCommand( TRUE );
	pVisualStyleButton ->RemoveSubItem( 0 );
	pVisualStyleButton ->SetRightAlignMenu( TRUE );

	MessageBox( pVisualStyleButton ->GetText() );
   
	// Add quick access toolbar commands:
	CList<UINT, UINT> lstQATCmds;

	lstQATCmds.AddTail(ID_FILE_NEW);
	lstQATCmds.AddTail(ID_FILE_OPEN);
	lstQATCmds.AddTail(ID_FILE_SAVE);
	lstQATCmds.AddTail(ID_FILE_PRINT_DIRECT);

	m_wndRibbonBar.SetQuickAccessCommands(lstQATCmds);
	m_wndRibbonBar.AddToTabs(new CMFCRibbonButton(ID_APP_ABOUT, _T("\na"), m_PanelImages.ExtractIcon (0)));

	strTemp.LoadString(IDS_RIBBON_CUSTOM);
	CMFCRibbonCategory* pCategoryCustom	= m_wndRibbonBar.AddCategory(strTemp, IDB_FILESMALL, IDB_FILELARGE);

	// Create "Favorites" panel:
	strTemp.LoadString(IDS_RIBBON_FAVORITES);
	CMFCRibbonPanel* pPanelFavorites = pCategoryCustom->AddPanel(strTemp, m_PanelImages.ExtractIcon(15));

	// Create "Quick Print" button:
	strTemp.LoadString(IDS_RIBBON_PRINT_QUICK);
	CMFCRibbonButton* pBtnFavPrintQuick = new CMFCRibbonButton(ID_FILE_PRINT_DIRECT, strTemp, 7);

	// Create "Print" button with "Quick Print" as subitem:
	strTemp.LoadString(IDS_RIBBON_PRINT);
	CMFCRibbonButton* pBtnFavPrint = new CMFCRibbonButton(ID_FILE_PRINT, strTemp, 6);
	pBtnFavPrint->AddSubItem(pBtnFavPrintQuick);

	// Add "Print" button to "Favorites" panel:
	pPanelFavorites->Add(pBtnFavPrint);

	// Create a simple combo box with two entries:
	CMFCRibbonComboBox *pComboSimple = new CMFCRibbonComboBox(-1, FALSE, -1, 0, -1);

	// Add two items to the combo box and select the first item in the list:
	pComboSimple->AddItem(_T("Hi!"));
	pComboSimple->AddItem(_T("Hello!"));
	pComboSimple->SelectItem(0);

	// Add combo button to "Favorites" panel:
	pPanelFavorites->Add(pComboSimple);

	//CMFCRibbonSlider* ribbonSlider = new CMFCRibbonSlider();
	m_ribbonSlider->SetZoomButtons( true );
	pPanelFavorites->Add( m_ribbonSlider );
	pCategoryHome ->AddHidden( m_ribbonSlider );
	/*
	int pageSize = ribbonSlider -> GetPageSize();
	CString cstr;
	cstr.Format( _T( "page size = %d" ), pageSize );
	MessageBox( cstr, _T( "hello" ), 0 );
	*/
}

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


// CMainFrame message handlers

void CMainFrame::OnWindowManager()
{
	ShowWindowsDialog();
}

void CMainFrame::OnApplicationLook(UINT id)
{
	CWaitCursor wait;

	theApp.m_nAppLook = id;

	switch (theApp.m_nAppLook)
	{
	case ID_VIEW_APPLOOK_WIN_2000:
		CMFCVisualManager::SetDefaultManager(RUNTIME_CLASS(CMFCVisualManager));
		break;

	case ID_VIEW_APPLOOK_OFF_XP:
		CMFCVisualManager::SetDefaultManager(RUNTIME_CLASS(CMFCVisualManagerOfficeXP));
		break;

	case ID_VIEW_APPLOOK_WIN_XP:
		CMFCVisualManagerWindows::m_b3DTabsXPTheme = TRUE;
		CMFCVisualManager::SetDefaultManager(RUNTIME_CLASS(CMFCVisualManagerWindows));
		break;

	case ID_VIEW_APPLOOK_OFF_2003:
		CMFCVisualManager::SetDefaultManager(RUNTIME_CLASS(CMFCVisualManagerOffice2003));
		CDockingManager::SetDockingMode(DT_SMART);
		break;

	case ID_VIEW_APPLOOK_VS_2005:
		CMFCVisualManager::SetDefaultManager(RUNTIME_CLASS(CMFCVisualManagerVS2005));
		CDockingManager::SetDockingMode(DT_SMART);
		break;

	default:
		switch (theApp.m_nAppLook)
		{
		case ID_VIEW_APPLOOK_OFF_2007_BLUE:
			CMFCVisualManagerOffice2007::SetStyle(CMFCVisualManagerOffice2007::Office2007_LunaBlue);
			break;

		case ID_VIEW_APPLOOK_OFF_2007_BLACK:
			CMFCVisualManagerOffice2007::SetStyle(CMFCVisualManagerOffice2007::Office2007_ObsidianBlack);
			break;

		case ID_VIEW_APPLOOK_OFF_2007_SILVER:
			CMFCVisualManagerOffice2007::SetStyle(CMFCVisualManagerOffice2007::Office2007_Silver);
			break;

		case ID_VIEW_APPLOOK_OFF_2007_AQUA:
			CMFCVisualManagerOffice2007::SetStyle(CMFCVisualManagerOffice2007::Office2007_Aqua);
			break;
		}

		CMFCVisualManager::SetDefaultManager(RUNTIME_CLASS(CMFCVisualManagerOffice2007));
		CDockingManager::SetDockingMode(DT_SMART);
	}

	RedrawWindow(NULL, NULL, RDW_ALLCHILDREN | RDW_INVALIDATE | RDW_UPDATENOW | RDW_FRAME | RDW_ERASE);

	theApp.WriteInt(_T("ApplicationLook"), theApp.m_nAppLook);
}

void CMainFrame::OnUpdateApplicationLook(CCmdUI* pCmdUI)
{
	pCmdUI->SetRadio(theApp.m_nAppLook == pCmdUI->m_nID);
}

void CMainFrame::OnActivate(UINT nState, CWnd* pWndOther, BOOL bMinimized)
{
	CMDIFrameWndEx::OnActivate(nState, pWndOther, bMinimized);

	// TODO: Add your message handler code here
}
