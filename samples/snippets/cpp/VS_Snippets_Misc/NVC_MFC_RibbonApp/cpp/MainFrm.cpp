// MainFrm.cpp : implementation of the CMainFrame class
//

#include "stdafx.h"
#include "MFCRibbonApp.h"

#include "MainFrm.h"

#include <afxautohidedocksite.h>
#include <afxbasepane.h>
#include <afxcolorpropertysheet.h>

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

static UINT indicators[] =
{
	//ID_INDICATOR_ICON,		// status icon
	ID_SEPARATOR,           // status line indicator
	//ID_INDICATOR_PROGRESS,	// progress bar
	//ID_INDICATOR_LABEL,		// text label
	//ID_INDICATOR_ANIMATION,	// animation pane
	ID_INDICATOR_CAPS,
	ID_INDICATOR_NUM,
	ID_INDICATOR_SCRL, 
};


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
	
	// <Snippet1>
	// CMFCRibbonBar m_wndRibbonBar
	m_wndRibbonBar.Create(this,WS_CHILD|CBRS_TOP);
	// </Snippet1>
	InitializeRibbon();

	if (!m_wndStatusBar.Create(this))
	{
		TRACE0("Failed to create status bar\n");
		return -1;      // fail to create
	}

	// <Snippet2>
	// <Snippet14>
	CString strTitlePane1;
	CString strTitlePane2;
	strTitlePane1.LoadString(IDS_STATUS_PANE1);
	strTitlePane2.LoadString(IDS_STATUS_PANE2);

	CMFCRibbonStatusBarPane* rsbp = new CMFCRibbonStatusBarPane( ID_STATUSBAR_PANE1, strTitlePane1, TRUE );
	// </Snippet14>
	rsbp->SetTextAlign( TA_CENTER );
	rsbp->SetAlmostLargeText( _T( "Status bar" ) );
	CBitmap bitmap;
	bitmap.LoadBitmapW( IDB_FILESMALL );
	rsbp->SetAnimationList( (HBITMAP)bitmap );
	rsbp->StartAnimation();
	// </Snippet2>

	// <Snippet15>
	// CMFCRibbonStatusBar  m_wndStatusBar
	m_wndStatusBar.AddElement(rsbp, strTitlePane1);
	m_wndStatusBar.AddExtendedElement(new CMFCRibbonStatusBarPane(ID_STATUSBAR_PANE2, strTitlePane2, TRUE), 
		strTitlePane2);
	// </Snippet15>
    

	// <Snippet16>
	m_wndStatusBar.AddSeparator();
	m_wndStatusBar.SetInformation(NULL);
	// </Snippet16>

	// enable Visual Studio 2005 style docking window behavior
	CDockingManager::SetDockingMode(DT_SMART);
	// enable Visual Studio 2005 style docking window auto-hide behavior
	EnableAutoHidePanes(CBRS_ALIGN_ANY);

	// Enable enhanced windows management dialog
	EnableWindowsDialog(ID_WINDOW_MANAGER, IDS_WINDOWS_MANAGER, TRUE);

	// <Snippet18>
	// CMFCRibbonBar m_wndRibbonBar
	// this points to CMainFrame
	CMFCRibbonCustomizeDialog* cDialog = new CMFCRibbonCustomizeDialog(this, &m_wndRibbonBar);
	// </Snippet18>

	cDialog->DoModal();

	// snippet 19 is not part of the original sample and is placed here to show how to 
	// use CMemDC. Exclude these lines if you want to run the sample.

	// <snippet20>
	// this points to CMainFrame
	// CDC* pDCPaint;
	// pDCPaint = NULL;
	// CMemDC memDC(*pDCPaint, this);
	// CDC* pDC = &memDC.GetDC();

	// set the text color and the background mode
	// pDC->SetTextColor(afxGlobalData.clrBtnText);
	// pDC->SetBkMode(TRANSPARENT);
	//</Snippet20>

	// Do drawing here:
	// pDC->Some Draw Operations
	// at this point the contents of CMemDC are copied to the screen DC.

	// <snippet23>
    CMFCPropertyGridToolTipCtrl* pToolTipCtrl = new CMFCPropertyGridToolTipCtrl();
	CRect crect(1,1,50,50);
	pToolTipCtrl->Track( crect, _T("this is a tool tip control"));
    // </snippet23>

	// <snippet24>
	CMFCHeaderCtrl* headerCtrl = new CMFCHeaderCtrl();
	headerCtrl->EnableMultipleSort();
	// </snippet24>

	// <snippet25>
	CMFCSpinButtonCtrl* pWndSpin = new CMFCSpinButtonCtrl;
	CRect rectSpin(1,1,10,10);
	CMFCPropertyGridCtrl* pWndList = new CMFCPropertyGridCtrl();
	if (!pWndSpin->Create(WS_CHILD | WS_VISIBLE | UDS_ARROWKEYS | UDS_SETBUDDYINT | UDS_NOTHOUSANDS, rectSpin, pWndList, AFX_PROPLIST_ID_INPLACE))
	{
		return 0;
	}
    // </snippet25>

	// <snippet26>
	CMFCAutoHideBar* pParentBar = new CMFCAutoHideBar();
	CDockingPanesRow* pParentRow = pParentBar->GetDockSiteRow();
	// </snippet26>
                
	// <snippet29>
	CAutoHideDockSite* pParentDockBar = DYNAMIC_DOWNCAST(CAutoHideDockSite, pParentBar->GetParentDockSite());
    pParentDockBar->SetOffsetLeft(10);
	pParentDockBar->SetOffsetRight(10);
	// </snippet29>

	// <snippet27>
	AFX_DOCKSITE_INFO info;
	CDockSite* pDockBar = (CDockSite*) info.pDockBarRTC->CreateObject();
	// </snippet27>

	// <snippet28>
	CMFCTasksPane* tPane = new CMFCTasksPane();
    tPane->EnableGroupCollapse(true);
	tPane->EnableHistoryMenuButtons(true);
	tPane->EnableScrollButtons(true);
	tPane->EnableWrapLabels(true);
    tPane->SetCaption(_T("Task Pane"));
	tPane->SetGroupTextColor(0,RGB(0,0,128));
	tPane->SetHorzMargin(15);
	tPane->SetVertMargin(15);
	tPane->Update();
	// </snippet28>

    // <snippet30>
	CString strKey;
	ACCEL accel;
	accel.fVirt = FVIRTKEY | FCONTROL;
	accel.key = VK_DOWN;

	CMFCAcceleratorKey helper(&accel);
	helper.Format(strKey);
	// </snippet30>

	// <snippet31>
	CMFCAcceleratorKeyAssignCtrl* accelCtrl = new CMFCAcceleratorKeyAssignCtrl();
	accelCtrl->ResetKey();
	// </snippet31>

    // <snippet32>
	CMFCAutoHideButton* autoHideButton = new CMFCAutoHideButton();
	CDockablePane cPane;
	// CMFCAutoHideBar* pParentBar
	if ( !autoHideButton->Create(pParentBar, &cPane, CBRS_ALIGN_LEFT) )
	{
		return 0;
	}
	autoHideButton->ShowAttachedWindow(true);
	autoHideButton->ShowButton(true);
    // </snippet32>
	
	// <snippet33>
	CSettingsStoreSP regSP;
	CSettingsStore& reg = regSP.Create(FALSE, TRUE);
	// </snippet33>

	// <snippet34>
	COLORREF color;
	CArray<COLORREF, COLORREF> colors;
	CString strAutoColorText;
	CString strOtherText;
	CString strDocColorsText;
	CList<COLORREF,COLORREF> lstDocColors;
	COLORREF colorAutomatic;
	int nColumns;
	CMFCColorButton colorButton;
	CMFCColorPopupMenu* pPopup = new CMFCColorPopupMenu(&colorButton, colors, color, strAutoColorText, strOtherText, strDocColorsText, lstDocColors, nColumns, colorAutomatic);
	// </snippet34>

	// <snippet35>
    CMFCCustomColorsPropertyPage* colourSheet = new CMFCCustomColorsPropertyPage();
	colourSheet->Setup(0,0,255);
	// </snippet35>

	// <snippet36>
	CFrameWnd* pTopFrame = AFXGetParentFrame(this);
	if (pTopFrame == NULL)
	{
		return FALSE;
	}

	CMFCDropDownFrame* pDropFrame = DYNAMIC_DOWNCAST(CMFCDropDownFrame, pTopFrame);
	pDropFrame->SetAutoDestroy(true);
	// </snippet36>

	// <snippet37>
	COLORREF mcolor(RGB(0,255,0));
	//CBitmap bitmap;
	CMFCImageEditorDialog* dialog = new CMFCImageEditorDialog(&bitmap);
	CMFCImagePaintArea* wndLargeDrawArea = new CMFCImagePaintArea(dialog);
	wndLargeDrawArea->SetColor(mcolor);
	wndLargeDrawArea->SetMode(CMFCImagePaintArea::IMAGE_EDIT_MODE_PEN);
	wndLargeDrawArea->SetBitmap(&bitmap);
	// </snippet37>

	// <snippet39>
	HWND hWndTab = NULL;
	CBasePane* basePane = new CBasePane();
	CMFCBaseTabCtrl* pTabParent = basePane->GetParentTabWnd(hWndTab);
	CMFCTabDropTarget* dropTarget = new CMFCTabDropTarget();
	dropTarget->Register(pTabParent);
	// </snippet39>

	// <snippet40>
	CMFCToolBarEditBoxButton* boxButton = new CMFCToolBarEditBoxButton();
	boxButton->CanBeStretched();
	boxButton->HaveHotBorder();
	boxButton->SetContents(_T("edit box button"));
	boxButton->SetFlatMode(true);
	boxButton->SetStyle(TBBS_PRESSED);
	// </snippet40>

	// <snippet43>
	CMFCCaptionButton* captionButton = new CMFCCaptionButton(AFX_HTCLOSE);
	captionButton->SetMiniFrameButton(true);
	// </snippet43>

	// <snippet44>
	// The this pointer points to a CMainFrame class which extends the CMDIFrameWndEx class.
	CMFCColorPropertySheet* pPropertySheet = new CMFCColorPropertySheet(_T("color property sheet"), this);
	// </snippet44>

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

	// Load panel images:
	m_PanelImages.SetImageSize(CSize(16, 16));
	m_PanelImages.Load(IDB_BUTTONS);

	// <Snippet3>
	// Init main button:
	// CMFCRibbonApplicationButton m_MainButton
	m_MainButton.SetImage(IDB_MAIN);
	m_MainButton.SetText(_T("\nf"));
	m_MainButton.SetToolTipText(strTemp);

	// CMFCRibbonBar m_wndRibbonBar
	m_wndRibbonBar.SetApplicationButton(&m_MainButton, CSize (45, 45));
	// </Snippet3>

	
	m_wndRibbonBar.EnableToolTips( true, true );
	m_wndRibbonBar.EnablePrintPreview( true );
	CMFCRibbonCategory* rc = m_wndRibbonBar.AddPrintPreviewCategory();
	m_wndRibbonBar.EnableKeyTips( true );
	
    
	// <Snippet4>
	// m_wndRibbonBar is declared as a protected member variable 
	// CMFCRibbonBar m_wndRibbonBar.
	// strTemp is a CString variable.
	strTemp.LoadString(IDS_RIBBON_FILE);
	CMFCRibbonMainPanel* pMainPanel = m_wndRibbonBar.AddMainCategory(strTemp, 
		IDB_FILESMALL, IDB_FILELARGE);
	// </Snippet4>

	CString cstr;
	CMFCRibbonUndoButton* undoButton = new CMFCRibbonUndoButton(ID_EDIT_UNDO, 
		_T("Undo button"), 0, 0);
   
	for (int i = 0; i < 20; i++)
	{
		CString str;
		str.Format(_T("Action %d"), i + 1);
		undoButton->AddUndoAction(str);
	}
    pMainPanel->Add(undoButton); 

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

    // <snippet19>
	// CMFCRibbonMainPanel* pMainPanel
	pMainPanel->Add(new CMFCRibbonSeparator(TRUE));
    // </snippet19>

	strTemp.LoadString(IDS_RIBBON_CLOSE);
	pMainPanel->Add(new CMFCRibbonButton(ID_FILE_CLOSE, strTemp, 9, 9));

	strTemp.LoadString(IDS_RIBBON_RECENT_DOCS);
	pMainPanel->AddRecentFilesList(strTemp);

	strTemp.LoadString(IDS_RIBBON_EXIT);
	pMainPanel->AddToBottom(new CMFCRibbonMainPanelButton(ID_APP_EXIT, strTemp, 15));

	// Add "Home" category with "Clipboard" panel

	// <Snippet5> 
	// Add "Home" category.
	// CMFCRibbonBar m_wndRibbonBar
	strTemp.LoadString(IDS_RIBBON_HOME);
	CMFCRibbonCategory* pCategoryHome = m_wndRibbonBar.AddCategory(strTemp, 
		IDB_WRITESMALL, IDB_WRITELARGE);
	// </Snippet5>
	
	m_wndRibbonBar.ToggleMimimizeState();	
	
	// Create "Clipboard" panel
	strTemp.LoadString(IDS_RIBBON_CLIPBOARD);
	CMFCRibbonPanel* pPanelClipboard = pCategoryHome->AddPanel(strTemp, m_PanelImages.ExtractIcon(27));
    
	// Create a paste button and add it to the "Clipboard" panel
	strTemp.LoadString(IDS_RIBBON_PASTE);
	CMFCRibbonButton* pBtnPaste = new CMFCRibbonButton(ID_EDIT_PASTE, strTemp, 0, 0);
	pPanelClipboard->Add(pBtnPaste);
	
	// <Snippet6>
	strTemp.LoadString(IDS_RIBBON_CUT);
	CMFCRibbonButton* butn = new CMFCRibbonButton(ID_EDIT_CUT, strTemp, 1);
	butn ->SetKeys(_T("k"));
	// </Snippet6>
	pPanelClipboard->Add(butn);
	
	strTemp.LoadString(IDS_RIBBON_COPY);
	pPanelClipboard->Add(new CMFCRibbonButton(ID_EDIT_COPY, strTemp, 2));
	strTemp.LoadString(IDS_RIBBON_SELECTALL);
	pPanelClipboard->Add(new CMFCRibbonButton(ID_EDIT_SELECT_ALL, strTemp, -1));

	// Create and add a "View" panel:
	strTemp.LoadString(IDS_RIBBON_VIEW);
	CMFCRibbonPanel* pPanelView = pCategoryHome->AddPanel(strTemp, m_PanelImages.ExtractIcon (7));

	// <snippet17>
	strTemp.LoadString(IDS_RIBBON_STATUSBAR);
	CMFCRibbonButton* pBtnStatusBar = new CMFCRibbonCheckBox(ID_VIEW_STATUS_BAR, strTemp);
	// </snippet17>
	pPanelView->Add(pBtnStatusBar);
    

	// Create and add a "Windows" panel:
	strTemp.LoadString(IDS_RIBBON_WINDOW);
	CMFCRibbonPanel* pPanelWindow = pCategoryHome->AddPanel(strTemp, m_PanelImages.ExtractIcon (7));

	strTemp.LoadString(IDS_RIBBON_WINDOWS);

	CMFCRibbonButton* pBtnWindows = new CMFCRibbonButton(ID_WINDOW_MANAGER, strTemp, -1, 1);
	pBtnWindows->SetMenu(IDR_WINDOWS_MENU, TRUE);
	pPanelWindow->Add(pBtnWindows);

	// <Snippet7>
	strTemp.LoadString(IDS_RIBBON_STYLE);
    // The first parameter is the command ID of the button.
	// The third parameter is a zero-based index of the button's small image in the 
	// image list of the parent category.
	// The fourth parameter is a zero-based index of the button's large image in the 
	// image list of the parent category.
	CMFCRibbonButton* pVisualStyleButton = new CMFCRibbonButton(1, strTemp, -1, -1);
	
	pVisualStyleButton->SetMenu(IDR_THEME_MENU, TRUE, TRUE);

	strTemp.LoadString(IDS_RIBBON_STYLE_TIP);
	pVisualStyleButton->SetToolTipText(strTemp);
	strTemp.LoadString(IDS_RIBBON_STYLE_DESC);
	pVisualStyleButton->SetDescription(strTemp);
	pVisualStyleButton->RemoveSubItem(0);
	pVisualStyleButton->SetRightAlignMenu(TRUE);
	// </Snippet7>

	m_wndRibbonBar.AddToTabs(pVisualStyleButton);
	m_wndRibbonBar.SetQuickAccessToolbarOnTop( false );

    m_wndRibbonBar.RecalcLayout ();
	CFrameWnd* pParentFrame = this->GetParentFrame();
	
    if (pParentFrame->GetSafeHwnd () != NULL)
	{
		pParentFrame->RecalcLayout ();
        pParentFrame->RedrawWindow (NULL, NULL, RDW_FRAME | RDW_INVALIDATE | RDW_UPDATENOW | RDW_ALLCHILDREN);
    }

	// <Snippet8>
	// Add quick access commands to the toolbar
	CList<UINT, UINT> lstQATCmds;

	lstQATCmds.AddTail(ID_FILE_NEW);
	lstQATCmds.AddTail(ID_FILE_OPEN);
	lstQATCmds.AddTail(ID_FILE_SAVE);
	lstQATCmds.AddTail(ID_FILE_PRINT_DIRECT);

	// CMFCRibbonBar m_wndRibbonBar
	m_wndRibbonBar.SetQuickAccessCommands(lstQATCmds);
    // </Snippet8>

	// <Snippet9>
	// <snippet21>
	CMFCRibbonQuickAccessToolBarDefaultState* qaToolBarState = 
		new CMFCRibbonQuickAccessToolBarDefaultState();
	qaToolBarState->AddCommand(ID_FILE_NEW, true);
	qaToolBarState->AddCommand(ID_FILE_OPEN, true);
	// </snippet21>
	// CMFCRibbonBar m_wndRibbonBar
	m_wndRibbonBar.SetQuickAccessDefaultState(*qaToolBarState);
    // </Snippet9>

	m_wndRibbonBar.AddToTabs(new CMFCRibbonButton(ID_APP_ABOUT, _T("\na"), m_PanelImages.ExtractIcon (0)));

	strTemp.LoadString(IDS_RIBBON_CUSTOM);
	CMFCRibbonCategory* pCategoryCustom	= m_wndRibbonBar.AddCategory(strTemp, IDB_FILESMALL, IDB_FILELARGE);

	// <Snippet10>
	// Create "Favorites" panel:
	strTemp.LoadString(IDS_RIBBON_FAVORITES);
	// CMFCRibbonCategory* pCategoryCustom
	CMFCRibbonPanel* pPanelFavorites = pCategoryCustom->AddPanel(strTemp, 
		m_PanelImages.ExtractIcon(15));
    // </Snippet10>

  	// Create "Quick Print" button:
	strTemp.LoadString(IDS_RIBBON_PRINT_QUICK);
	CMFCRibbonButton* pBtnFavPrintQuick = new CMFCRibbonButton(ID_FILE_PRINT_DIRECT, strTemp, 7);

	// Create "Print" button with "Quick Print" as subitem:
	strTemp.LoadString(IDS_RIBBON_PRINT);
	CMFCRibbonButton* pBtnFavPrint = new CMFCRibbonButton(ID_FILE_PRINT, strTemp, 6);
	pBtnFavPrint->AddSubItem(pBtnFavPrintQuick);

	// Add "Print" button to "Favorites" panel:
	pPanelFavorites->Add(pBtnFavPrint);

	// <Snippet11>
	// Create a simple combo box with two entries:
	// The first parameter is the id of the combo box.
	// The third parameter is the width of the combo box in pixels.
	// The fourth parameter is the display label of the combo box.
	// The fifth parameter is the index of the small image of the combo box.
	CMFCRibbonComboBox *pComboSimple = new CMFCRibbonComboBox(-1, FALSE, -1, 0, -1);

	// Add two items to the combo box and select the first item in the list:
	pComboSimple->AddItem(_T("Hi!"));
	pComboSimple->AddItem(_T("Hello!"));
	pComboSimple->SelectItem(0);

	// Add combo button to "Favorites" panel:
	// CMFCRibbonPanel* pPanelFavorites
	pPanelFavorites->Add(pComboSimple);
	// </Snippet11>

	// <Snippet12>
	// Create a ribbon slider.
	CMFCRibbonSlider* ribbonSlider = new CMFCRibbonSlider();
	// Set the various properties of the slider.
	ribbonSlider->SetZoomButtons(true);
	ribbonSlider->SetPos(50, TRUE);
	ribbonSlider->SetRange(0, 100);
	// Add the ribbon slider to the Favorites panel.
	// CMFCRibbonPanel* pPanelFavorites
	pPanelFavorites->Add(ribbonSlider);
	// </Snippet12>	

	// <Snippet13>
	CArray<int,int> arCollapseOrder;
	arCollapseOrder.Add(0);
	arCollapseOrder.Add(1);
	arCollapseOrder.Add(2);
	// CMFCRibbonCategory* pCategoryHome
	pCategoryHome->SetCollapseOrder(arCollapseOrder);
	// </Snippet13>

	pCategoryHome->SetKeys(_T("O"));

	pCategoryHome->SetTabColor(AFX_CategoryColor_Red);

	// <snippet22>
	// Create "Customize" page
	// CMFCRibbonBar m_wndRibbonBar
	CMFCRibbonCustomizePropertyPage pageCustomize(&m_wndRibbonBar);

	// Create a list of popular items:
	CList<UINT, UINT> lstPopular;
	lstPopular.AddTail(ID_FILE_NEW);
	lstPopular.AddTail(ID_FILE_OPEN);
	
	// add a custom category
	pageCustomize.AddCustomCategory(_T("Popular Commands"), lstPopular);
	// </snippet22>

	// <snippet38>
	// CMFCRibbonComboBox *pComboSimple
	CMFCDropDownListBox* listBox = new CMFCDropDownListBox(pComboSimple);
	listBox->AddString(_T("this is a drop down list box"));
	listBox->SetCurSel(0);
	listBox->SetMaxHeight(100);
	listBox->SetMinWidth(10);
	// </snippet38>

	// <snippet41>
	// <snippet42>
	CMFCToolTipInfo* params = new CMFCToolTipInfo();
	
	params->m_bBoldLabel = FALSE;
	params->m_bDrawDescription = FALSE;
	params->m_bDrawIcon = FALSE;
	params->m_bRoundedCorners = TRUE;
	params->m_bDrawSeparator = FALSE;
	params->m_clrFill = RGB (255, 255, 255);
	params->m_clrFillGradient = RGB (228, 228, 240);
	params->m_clrText = RGB (61, 83, 80);
	params->m_clrBorder = RGB (144, 149, 168);
	// </snippet42>

	CMFCToolTipCtrl* tipCtrl = new CMFCToolTipCtrl(params);
	tipCtrl->SetDescription(_T("tool tip control"));
	tipCtrl->SetFixedWidth(100,150);
	// </snippet41>
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
