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
#include "ToolbarDateTimePicker.h"

#include "MainFrm.h"

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
	ON_COMMAND(ID_DATE, OnDate)
	ON_COMMAND(ID_TIME, OnTime)
	//}}AFX_MSG_MAP
	ON_COMMAND(ID_VIEW_CUSTOMIZE, OnViewCustomize)
	ON_REGISTERED_MESSAGE(AFX_WM_RESETTOOLBAR, OnToolbarReset)
	ON_REGISTERED_MESSAGE(AFX_WM_TOOLBARMENU, OnToolbarContextMenu)
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
	// TODO: add member initialization code here
	
}

CMainFrame::~CMainFrame()
{
}

int CMainFrame::OnCreate(LPCREATESTRUCT lpCreateStruct)
{
	if (CFrameWnd::OnCreate(lpCreateStruct) == -1)
		return -1;

	// enable Office XP look:
	CMFCVisualManager::SetDefaultManager (RUNTIME_CLASS (CMFCVisualManagerOffice2003));

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
	lstBasicCommands.AddTail (ID_DATE);
	lstBasicCommands.AddTail (ID_TIME);

	CMFCToolBar::SetBasicCommands (lstBasicCommands);

	if (!m_wndMenuBar.Create (this))
	{
		TRACE0("Failed to create menubar\n");
		return -1;      // fail to create
	}

	m_wndMenuBar.SetPaneStyle(m_wndMenuBar.GetPaneStyle() | CBRS_SIZE_DYNAMIC);

	if (!m_wndToolBar.CreateEx(this, TBSTYLE_FLAT, WS_CHILD | WS_VISIBLE | CBRS_TOP
		| CBRS_GRIPPER | CBRS_TOOLTIPS | CBRS_FLYBY | CBRS_SIZE_DYNAMIC) ||
		!m_wndToolBar.LoadToolBar(IDR_MAINFRAME))
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

	BOOL bValidString;
	CString strMainToolbarTitle;
	bValidString = strMainToolbarTitle.LoadString (IDS_MAIN_TOOLBAR);
	m_wndToolBar.SetWindowText (strMainToolbarTitle);
	// TODO: Delete these three lines if you don't want the toolbar to
	//  be dockable
	m_wndMenuBar.EnableDocking(CBRS_ALIGN_ANY);
	m_wndToolBar.EnableDocking(CBRS_ALIGN_ANY);
	EnableDocking(CBRS_ALIGN_ANY);
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

	//----Example----//
	// <snippet1>
	CMFCToolBarDateTimeCtrl dateButton (ID_DATE,
		GetCmdMgr ()->GetCmdImage (ID_DATE, FALSE));
	// </snippet1>

	pDlgCust->ReplaceButton (ID_DATE, dateButton);

	CMFCToolBarDateTimeCtrl timeButton (ID_TIME,
		GetCmdMgr ()->GetCmdImage (ID_TIME, FALSE),
		DTS_TIMEFORMAT | DTS_UPDOWN);
	pDlgCust->ReplaceButton (ID_TIME, timeButton);

	//----Example----//

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

LRESULT CMainFrame::OnToolbarReset(WPARAM wp,LPARAM)
{
	//----Example----//

	UINT uiToolBarId = (UINT) wp;

	switch (uiToolBarId)
	{
	case IDR_MAINFRAME:
		{
			CMFCToolBarDateTimeCtrl dateButton (ID_DATE,
				GetCmdMgr ()->GetCmdImage (ID_DATE, FALSE));
			m_wndToolBar.ReplaceButton (ID_DATE, dateButton);

			CMFCToolBarDateTimeCtrl timeButton (ID_TIME,
				GetCmdMgr ()->GetCmdImage (ID_TIME, FALSE),
				DTS_TIMEFORMAT | DTS_UPDOWN);
			m_wndToolBar.ReplaceButton (ID_TIME, timeButton);
		}
		break;
	}

	//----Example----//

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

void CMainFrame::OnDate() 
{
	MessageBox (_T("Change date..."));
}

void CMainFrame::OnTime() 
{
	MessageBox (_T("Change time...."));
}
