#include "stdafx.h"
#include "OutlookMultiViews.h"

#include "MainFrm.h"

#include "View1.h"
#include "View2.h"
#include "View3.h"

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
	ON_COMMAND(ID_VIEW_OUTLOOKBAR, OnViewOutlookBar)
	ON_UPDATE_COMMAND_UI(ID_VIEW_OUTLOOKBAR, OnUpdateViewOutlookBar)
	ON_COMMAND_RANGE(ID_SHORTCUT_1, ID_SHORTCUT_4, OnOutlookBarShortcut)
	ON_UPDATE_COMMAND_UI_RANGE(ID_SHORTCUT_1, ID_SHORTCUT_4, OnUpdateOutlookBarShortcut)
	ON_COMMAND(ID_VIEW_CAPTIONBAR, OnViewCaptionBar)
	ON_UPDATE_COMMAND_UI(ID_VIEW_CAPTIONBAR, OnUpdateViewCaptionBar)
	ON_COMMAND_RANGE(ID_VIEW_APPLOOK_2000, ID_VIEW_APPLOOK_2007_4, OnAppLook)
	ON_UPDATE_COMMAND_UI_RANGE(ID_VIEW_APPLOOK_2000, ID_VIEW_APPLOOK_2007_4, OnUpdateAppLook)
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
	m_nAppLook = theApp.GetInt (_T("ApplicationLook"), ID_VIEW_APPLOOK_2003);

	// TODO: add member initialization code here
	
}

CMainFrame::~CMainFrame()
{
}

int CMainFrame::OnCreate(LPCREATESTRUCT lpCreateStruct)
{
	if (CFrameWnd::OnCreate(lpCreateStruct) == -1)
		return -1;

	OnAppLook (m_nAppLook);

	CMFCToolBar::EnableQuickCustomization ();

	// TODO: Define your own basic commands. Be sure, that each pulldown 
	// menu have at least one basic command.

	CList<UINT, UINT>	lstBasicCommands;

	lstBasicCommands.AddTail (ID_VIEW_TOOLBARS);
	lstBasicCommands.AddTail (ID_FILE_NEW);
	lstBasicCommands.AddTail (ID_FILE_OPEN);
	lstBasicCommands.AddTail (ID_FILE_SAVE);
	lstBasicCommands.AddTail (ID_FILE_PRINT);
	lstBasicCommands.AddTail (ID_APP_EXIT);
	lstBasicCommands.AddTail (ID_EDIT_CUT);
	lstBasicCommands.AddTail (ID_EDIT_PASTE);
	lstBasicCommands.AddTail (ID_EDIT_UNDO);
	lstBasicCommands.AddTail (ID_APP_ABOUT);
	lstBasicCommands.AddTail (ID_VIEW_TOOLBAR);
	lstBasicCommands.AddTail (ID_VIEW_CUSTOMIZE);
	lstBasicCommands.AddTail (ID_VIEW_APPLOOK_2000);
	lstBasicCommands.AddTail (ID_VIEW_APPLOOK_XP);
	lstBasicCommands.AddTail (ID_VIEW_APPLOOK_2003);
	lstBasicCommands.AddTail (ID_VIEW_APPLOOK_VS2005);
	lstBasicCommands.AddTail (ID_VIEW_APPLOOK_WIN_XP);
	lstBasicCommands.AddTail (ID_VIEW_APPLOOK_2007_1);
	lstBasicCommands.AddTail (ID_VIEW_APPLOOK_2007_2);
	lstBasicCommands.AddTail (ID_VIEW_APPLOOK_2007_3);
	lstBasicCommands.AddTail (ID_VIEW_APPLOOK_2007_4);

	CMFCToolBar::SetBasicCommands (lstBasicCommands);

	if (!m_wndMenuBar.Create (this))
	{
		TRACE0("Failed to create menubar\n");
		return -1;      // fail to create
	}

	m_wndMenuBar.SetPaneStyle(m_wndMenuBar.GetPaneStyle() | CBRS_SIZE_DYNAMIC);

	// Detect color depth. 256 color toolbars can be used in the
	// high or true color modes only (bits per pixel is > 8):
	CClientDC dc (this);
	BOOL bIsHighColor = dc.GetDeviceCaps (BITSPIXEL) > 8;

	UINT uiToolbarHotID = bIsHighColor ? IDB_TOOLBAR256 : 0;

	if (!m_wndToolBar.CreateEx(this, TBSTYLE_FLAT, WS_CHILD | WS_VISIBLE | CBRS_TOP
		| CBRS_GRIPPER | CBRS_TOOLTIPS | CBRS_FLYBY | CBRS_SIZE_DYNAMIC) ||
		!m_wndToolBar.LoadToolBar(IDR_MAINFRAME, 0, 0, FALSE, 0, 0, uiToolbarHotID))
	{
		TRACE0("Failed to create toolbar\n");
		return -1;      // fail to create
	}
	if (!m_wndStatusBar.Create(this) ||
		!m_wndStatusBar.SetIndicators(indicators,
		  sizeof(indicators)/sizeof(UINT)))
	{
		TRACE0("Failed to create status bar\n");
		return -1;      // fail to create
	}

	m_wndToolBar.SetWindowText (_T("Standard"));
	// TODO: Delete these three lines if you don't want the toolbar to
	//  be dockable
	m_wndMenuBar.EnableDocking(CBRS_ALIGN_ANY);
	m_wndToolBar.EnableDocking(CBRS_ALIGN_ANY);

	//------------------------------------------------------------------
	// Outlook bar will be created at left, so temporary disable docking
	// at the left side:
	//------------------------------------------------------------------
	EnableDocking (CBRS_ALIGN_TOP | CBRS_ALIGN_BOTTOM | CBRS_ALIGN_RIGHT);

	if (!CreateShortcutsBar ())
	{
		TRACE0("Failed to create shortcuts bar\n");
		return -1;      // fail to create
	}

	//----------------------------------------------------
	// Outlook bar is created and docking on the left side
	// should be allowed.
	//----------------------------------------------------
	EnableDocking (CBRS_ALIGN_LEFT);

	if (!m_wndCaptionBar.Create (WS_CHILD | WS_VISIBLE | WS_CLIPSIBLINGS, this,
		ID_VIEW_CAPTIONBAR, -1))
	{
		TRACE0("Failed to create caption bar\n");
		return -1;      // fail to create
	}

	m_wndCaptionBar.SetFlatBorder ();
	m_wndCaptionBar.SetText (_T("View 1"));
	m_bmpCaption.LoadBitmap (IDB_CAPTION);
	m_wndCaptionBar.SetBitmap (m_bmpCaption, RGB (255, 0, 255));

	DockPane(&m_wndMenuBar);
	DockPane(&m_wndToolBar);

	m_wndToolBar.EnableCustomizeButton (TRUE, ID_VIEW_CUSTOMIZE, _T("Customize..."));

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

afx_msg LRESULT CMainFrame::OnToolbarReset(WPARAM /*wp*/,LPARAM)
{
	// TODO: reset toolbar with id = (UINT) wp to its initial state:
	//
	// UINT uiToolBarId = (UINT) wp;
	// if (uiToolBarId == IDR_MAINFRAME)
	// {
	//		do something with m_wndToolBar
	// }

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
			// Don't show toolbars list in the customization mode!
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

void CMainFrame::OnViewOutlookBar() 
{
	ShowPane (&m_wndShortcutsBar,
					!(m_wndShortcutsBar.IsVisible ()),
					FALSE, TRUE);
	RecalcLayout ();
}

void CMainFrame::OnUpdateViewOutlookBar(CCmdUI* pCmdUI) 
{
	pCmdUI->SetCheck (m_wndShortcutsBar.IsVisible ());
}

void CMainFrame::OnOutlookBarShortcut(UINT id)
{
	const int nIndex = id - ID_SHORTCUT_1;

	ASSERT( nIndex >=0 && nIndex < NUMVIEWS );
	if ( nIndex < 0 || nIndex >= NUMVIEWS )
		return;

	if (!m_pViews)
		return;

	CView* pNewView = m_pViews[nIndex];
	if (!pNewView)
		return;

	CView* pActiveView =GetActiveView();

	if ( !pActiveView )    // No currently active view
		return;

	if ( pNewView == pActiveView )    // Already there
		return;

	m_nCurView = nIndex;    // Store the new current view's index

	// exchange view window ID's so RecalcLayout() works
	UINT temp = ::GetWindowLong(pActiveView->m_hWnd, GWL_ID);
	::SetWindowLong(pActiveView->m_hWnd, GWL_ID,
		::GetWindowLong(pNewView->m_hWnd, GWL_ID));
	::SetWindowLong(pNewView->m_hWnd, GWL_ID, temp);

	// Display and update the new current view - hide the old one    
	pActiveView->ShowWindow(SW_HIDE);
	pNewView->ShowWindow(SW_SHOW);
	SetActiveView(pNewView);
	RecalcLayout();
	pNewView->Invalidate();

	CString strCaption;
	strCaption.Format (_T("View %d"), nIndex + 1);

	m_wndCaptionBar.SetText (strCaption);
	m_wndCaptionBar.RedrawWindow ();
}

void CMainFrame::OnUpdateOutlookBarShortcut(CCmdUI* pCmdUI)
{
	pCmdUI->SetCheck (pCmdUI->m_nID == ID_SHORTCUT_1 + m_nCurView);
}

void CMainFrame::OnViewCaptionBar() 
{
	ShowPane (&m_wndCaptionBar,
					!(m_wndCaptionBar.IsVisible ()),
					FALSE, TRUE);
	RecalcLayout ();
}

void CMainFrame::OnUpdateViewCaptionBar(CCmdUI* pCmdUI) 
{
	pCmdUI->SetCheck (m_wndCaptionBar.IsVisible ());
}

BOOL CMainFrame::CreateShortcutsBar ()
{
	CMFCOutlookBarTabCtrl::EnableAnimation ();

	const int nInitialWidth = 150;
	const CString strCaption = _T("Shortcuts");

	// <snippet2>
	// int nInitialWidth
	// CString strCaption
	if (!m_wndShortcutsBar.Create (strCaption, this, 
		CRect (0, 0, nInitialWidth, nInitialWidth), 
		ID_VIEW_OUTLOOKBAR, WS_CHILD | WS_VISIBLE | CBRS_LEFT))
	{
		TRACE0("Failed to create outlook bar\n");
		return FALSE;      // fail to create
	}
	// </snippet2>

	CMFCOutlookBarTabCtrl* pShortcutsBarContainer = DYNAMIC_DOWNCAST (CMFCOutlookBarTabCtrl, m_wndShortcutsBar.GetUnderlyingWindow ());
	if (pShortcutsBarContainer == NULL)
	{
		TRACE0("Cannot get outlook bar container\n");
		return FALSE;
	}

	// <snippet4>
	CImageList images;
	images.Create (IDB_SHORTCUTS, 32, 0, RGB (255, 0, 255));

	// Create first page:
	m_wndShortcutsPane1.Create (&m_wndShortcutsBar, AFX_DEFAULT_TOOLBAR_STYLE, ID_SHORTCUTS_PANE_1);
	// The this pointer points to a CMainFrame class which extends the CFrameWnd class
	m_wndShortcutsPane1.SetOwner (this);
	m_wndShortcutsPane1.EnableTextLabels ();
	m_wndShortcutsPane1.EnableDocking (CBRS_ALIGN_ANY);
	m_wndShortcutsPane1.EnablePageScrollMode();
	m_wndShortcutsPane1.SetBackColor(RGB(0,255,0));
	
	m_wndShortcutsPane1.AddButton (images.ExtractIcon (0), _T("View 1"), ID_SHORTCUT_1);
	m_wndShortcutsPane1.AddButton (images.ExtractIcon (1), _T("View 2"), ID_SHORTCUT_2);
	m_wndShortcutsPane1.AddButton (images.ExtractIcon (2), _T("View 3"), ID_SHORTCUT_3);
	m_wndShortcutsPane1.AddButton (images.ExtractIcon (3), _T("View 4"), ID_SHORTCUT_4);
	// </snippet4>

	pShortcutsBarContainer->AddTab (&m_wndShortcutsPane1, _T("Views"), (UINT)-1, FALSE);

	return TRUE;
}

void CMainFrame::OnAppLook(UINT id)
{
	CDockingManager::SetDockingMode (DT_SMART);

	m_nAppLook = id;

	switch (m_nAppLook)
	{
	case ID_VIEW_APPLOOK_2000:
		// enable Office 2000 look:
		CMFCVisualManager::SetDefaultManager (RUNTIME_CLASS (CMFCVisualManager));
		break;

	case ID_VIEW_APPLOOK_XP:
		// enable Office XP look:
		CMFCVisualManager::SetDefaultManager (RUNTIME_CLASS (CMFCVisualManagerOfficeXP));
		break;

	case ID_VIEW_APPLOOK_WIN_XP:
		// enable Windows XP look (in other OS Office XP look will be used):
		CMFCVisualManagerWindows::m_b3DTabsXPTheme = TRUE;
		CMFCVisualManager::SetDefaultManager (RUNTIME_CLASS (CMFCVisualManagerWindows));
		break;

	case ID_VIEW_APPLOOK_2003:
		// enable Office 2003 look:
		CMFCVisualManager::SetDefaultManager (RUNTIME_CLASS (CMFCVisualManagerOffice2003));
		CDockingManager::SetDockingMode (DT_SMART);
		break;

	case ID_VIEW_APPLOOK_VS2005:
		// enable VS.NET 2005 look:
		CMFCVisualManager::SetDefaultManager (RUNTIME_CLASS (CMFCVisualManagerVS2005));
		CMFCVisualManager::GetInstance ();
		CDockingManager::SetDockingMode (DT_SMART);
		break;

	case ID_VIEW_APPLOOK_2007_1:
		// enable Office 2007 look:
		CMFCVisualManagerOffice2007::SetStyle (CMFCVisualManagerOffice2007::Office2007_LunaBlue);
		CMFCVisualManager::SetDefaultManager (RUNTIME_CLASS (CMFCVisualManagerOffice2007));
		CDockingManager::SetDockingMode (DT_SMART);
		break;

	case ID_VIEW_APPLOOK_2007_2:
		// enable Office 2007 look:
		CMFCVisualManagerOffice2007::SetStyle (CMFCVisualManagerOffice2007::Office2007_ObsidianBlack);
		CMFCVisualManager::SetDefaultManager (RUNTIME_CLASS (CMFCVisualManagerOffice2007));
		CDockingManager::SetDockingMode (DT_SMART);
		break;

	case ID_VIEW_APPLOOK_2007_3:
		// enable Office 2007 look:
		CMFCVisualManagerOffice2007::SetStyle (CMFCVisualManagerOffice2007::Office2007_Aqua);
		CMFCVisualManager::SetDefaultManager (RUNTIME_CLASS (CMFCVisualManagerOffice2007));
		CDockingManager::SetDockingMode (DT_SMART);
		break;

	case ID_VIEW_APPLOOK_2007_4:
		// enable Office 2007 look:
		CMFCVisualManagerOffice2007::SetStyle (CMFCVisualManagerOffice2007::Office2007_Silver);
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

	RecalcLayout ();
	RedrawWindow (NULL, NULL, RDW_ALLCHILDREN | RDW_INVALIDATE | RDW_UPDATENOW | RDW_ERASE);

	theApp.WriteInt (_T("ApplicationLook"), m_nAppLook);
}

void CMainFrame::OnUpdateAppLook(CCmdUI* pCmdUI)
{
	pCmdUI->SetRadio (m_nAppLook == pCmdUI->m_nID);
}


void CMainFrame::InitViews ()
{
    m_nCurView = 0;        // Save index of the currently active view class
    CView* pActiveView = GetActiveView();

    m_pViews[0] = pActiveView;
    m_pViews[1] = (CView*) new CView1;
    m_pViews[2] = (CView*) new CView2;
    m_pViews[3] = (CView*) new CView3;
    
    CDocument* pCurrentDoc = GetActiveDocument();
    
    // Initialize a CCreateContext to point to the active document.
    // With this context, the new view is added to the document
    // when the view is created in CView::OnCreate().
    CCreateContext newContext;
    newContext.m_pNewViewClass = NULL;
    newContext.m_pNewDocTemplate = NULL;
    newContext.m_pLastView = NULL;
    newContext.m_pCurrentFrame = NULL;
    newContext.m_pCurrentDoc = pCurrentDoc;
    
    CRect rect(0, 0, 0, 0); // gets resized later
    
	for (int nView = 1; nView < NUMVIEWS; nView++)
    {
        // Create the new view. In this example, the view persists for
        // the life of the application. The application automatically
        // deletes the view when the application is closed.
        m_pViews[nView]->Create(NULL, NULL,
				(AFX_WS_DEFAULT_VIEW & ~WS_VISIBLE),
			// views are created with the style of AFX_WS_DEFAULT_VIEW
			// In MFC 4.0, this is (WS_BORDER | WS_VISIBLE | WS_CHILD)
		                rect, this,
				AFX_IDW_PANE_FIRST + nView, &newContext);

		// When a document template creates a view, the WM_INITIALUPDATE
		// message is sent automatically. However, this code must
		// explicitly send the message, as follows.
		m_pViews [nView]->OnInitialUpdate();
    }
}


