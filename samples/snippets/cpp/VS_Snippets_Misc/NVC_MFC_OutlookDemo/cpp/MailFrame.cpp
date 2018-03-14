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
#include "MailFrame.h"

#ifdef _DEBUG
#define new DEBUG_NEW
#undef THIS_FILE
static char THIS_FILE[] = __FILE__;
#endif

static UINT indicators[] =
{
	ID_SEPARATOR,           // status line indicator
	ID_INDICATOR_CAPS,
	ID_INDICATOR_NUM,
	ID_INDICATOR_SCRL,
};

/////////////////////////////////////////////////////////////////////////////
// CMailFrame

CObList CMailFrame::m_lstMailFrames;

IMPLEMENT_DYNCREATE(CMailFrame, CFrameWndEx)

CMailFrame::CMailFrame()
{
	m_wndMenuBar.m_bClearHashOnClose = TRUE;
}

CMailFrame::~CMailFrame()
{
}

BEGIN_MESSAGE_MAP(CMailFrame, CFrameWndEx)
	ON_WM_CREATE()
	ON_WM_ACTIVATE()
	ON_COMMAND(ID_VIEW_CUSTOMIZE, OnViewCustomize)
	ON_WM_CLOSE()
	ON_COMMAND(ID_MAIL_CLOSE, OnMailClose)
	ON_WM_ENABLE()
	ON_REGISTERED_MESSAGE(AFX_WM_RESETTOOLBAR, OnToolbarReset)
END_MESSAGE_MAP()

/////////////////////////////////////////////////////////////////////////////
// CMailFrame message handlers

int CMailFrame::OnCreate(LPCREATESTRUCT lpCreateStruct)
{
	m_lstMailFrames.AddTail(this);

	m_pMainWnd = theApp.m_pMainWnd;

	if (CFrameWndEx::OnCreate(lpCreateStruct) == -1)
		return -1;

	BOOL bIsLook2003 = CMFCVisualManager::GetInstance()->IsKindOf(RUNTIME_CLASS(CMFCVisualManagerOffice2003));

	CWindowDC dc(NULL);
	int nBitsPerPixel = dc.GetDeviceCaps(BITSPIXEL);

	BOOL bHiColorToolbarIcons = bIsLook2003 && nBitsPerPixel > 16;

	// Create menu bar:
	if (!m_wndMenuBar.Create(this, AFX_DEFAULT_TOOLBAR_STYLE, ID_MAIL_MENU))
	{
		TRACE0("Failed to create menubar\n");
		return -1;      // fail to create
	}

	m_wndMenuBar.SetPaneStyle(m_wndMenuBar.GetPaneStyle() | CBRS_SIZE_DYNAMIC);

	// Create main toolbar:
	if (!m_wndToolBar.Create(this, WS_CHILD | WS_VISIBLE | CBRS_TOP
		| CBRS_GRIPPER | CBRS_TOOLTIPS | CBRS_FLYBY | CBRS_SIZE_DYNAMIC, ID_VIEW_MAIL_TOOLBAR) || !m_wndToolBar.LoadToolBar(IDR_MAILFRAME, 0, 0, FALSE, 0, 0, bHiColorToolbarIcons ? IDB_MAIL_HC : 0))
	{
		TRACE0("Failed to create toolbar\n");
		return -1;      // fail to create
	}

	BOOL bValidString;
	CString strMainToolbarTitle;
	bValidString = strMainToolbarTitle.LoadString(IDS_MAIN_TOOLBAR);
	m_wndToolBar.SetWindowText(strMainToolbarTitle);

	// Create status bar:
	if (!m_wndStatusBar.Create(this) || !m_wndStatusBar.SetIndicators(indicators, sizeof(indicators)/sizeof(UINT)))
	{
		TRACE0("Failed to create status bar\n");
		return -1;      // fail to create
	}

	m_wndMenuBar.EnableDocking(CBRS_ALIGN_ANY);
	m_wndToolBar.EnableDocking(CBRS_ALIGN_ANY);

	EnableDocking(CBRS_ALIGN_ANY);

	DockPane(&m_wndMenuBar);
	DockPane(&m_wndToolBar);

	// Create mail bar:
	if (!m_wndMailBar.Create(_T(""), this, FALSE, MAKEINTRESOURCE(IDD_MAILBAR), WS_VISIBLE | WS_CHILD | CBRS_TOP, ID_MAIL_BAR, AFX_CBRS_REGULAR_TABS, 0))
	{
		TRACE0("Failed to create mail bar\n");
		return -1;      // fail to create
	}

	DockPane(&m_wndMailBar);

	CRect rect;
	m_wndMailBar.GetWindowRect(rect);
	m_wndMailBar.SetMinSize(rect.Size());

	// Enable customization button fore all toolbars:
	m_wndToolBar.EnableCustomizeButton(TRUE, ID_VIEW_CUSTOMIZE, IDS_CUSTOMIZE);

	// Enable conttol bar context menu(list of bars + customize command):
	EnablePaneMenu( TRUE, ID_VIEW_CUSTOMIZE, _T("Customize..."), ID_VIEW_TOOLBARS);
	return 0;
}

LRESULT CMailFrame::OnToolbarReset(WPARAM wp,LPARAM)
{
	UINT uiToolBarId = (UINT) wp;
	if (uiToolBarId == IDR_MAILFRAME)
	{
		m_wndToolBar.SetToolBarBtnText(m_wndToolBar.CommandToIndex(ID_MAIL_SEND));
		m_wndToolBar.SetToolBarBtnText(m_wndToolBar.CommandToIndex(ID_MAIL_OPTIONS));
	}

	return 0;
}

void CMailFrame::OnActivate(UINT nState, CWnd* pWndOther, BOOL bMinimized)
{
	CFrameWndEx::OnActivate(nState, pWndOther, bMinimized);

	if (nState != WA_INACTIVE)
	{
		theApp.SetActiveFrame(COutlookDemoApp::MailFrame);
		theApp.m_pMainWnd = this;
	}
}

void CMailFrame::OnViewCustomize()
{
	// Create a customize toolbars dialog:
	CMFCToolBarsCustomizeDialog* pDlgCust = new CMFCToolBarsCustomizeDialog(this, TRUE /* Automatic menus scaning */);
	pDlgCust->Create();
}

void CMailFrame::OnClose()
{
	theApp.m_pMainWnd = m_pMainWnd;

	POSITION pos = m_lstMailFrames.Find(this);
	if (pos != NULL)
	{
		m_lstMailFrames.RemoveAt(pos);
	}

	CFrameWndEx::OnClose();
}

BOOL CMailFrame::LoadFrame(UINT nIDResource, DWORD dwDefaultStyle, CWnd* pParentWnd, CCreateContext* pContext)
{
	BOOL bRes = CFrameWndEx::LoadFrame(nIDResource, dwDefaultStyle, pParentWnd, pContext);
	if (bRes)
	{
		InitialUpdateFrame(pContext->m_pCurrentDoc, TRUE);
	}

	theApp.SetActiveFrame(COutlookDemoApp::MailFrame);
	return bRes;
}

void CMailFrame::OnMailClose()
{
	SendMessage(WM_CLOSE);
}

void CMailFrame::OnChangeLook()
{
	BOOL bIsLook2003 = CMFCVisualManager::GetInstance()->IsKindOf(RUNTIME_CLASS(CMFCVisualManagerOffice2003));

	CWindowDC dc(NULL);
	int nBitsPerPixel = dc.GetDeviceCaps(BITSPIXEL);

	BOOL bIsHiColor = bIsLook2003 && nBitsPerPixel > 16;

	for (POSITION pos = m_lstMailFrames.GetHeadPosition(); pos != NULL;)
	{
		CMailFrame* pFrame = (CMailFrame*) m_lstMailFrames.GetNext(pos);
		ASSERT_VALID(pFrame);

		pFrame->m_wndToolBar.LoadBitmap(bIsHiColor ? IDB_MAIL_HC : IDR_MAILFRAME);
		pFrame->RedrawWindow(NULL, NULL, RDW_ALLCHILDREN | RDW_INVALIDATE | RDW_UPDATENOW | RDW_ERASE);
	}
}

void CMailFrame::OnEnable( BOOL bEnable )
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


