//
// ipframe.cpp : implementation of the CInPlaceFrame class
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
#include "formatba.h"
#include "ruler.h"
#include "ipframe.h"
#include "wordpdoc.h"
#include "wordpvw.h"

#ifdef _DEBUG
#undef THIS_FILE
static char BASED_CODE THIS_FILE[] = __FILE__;
#endif

const UINT uiMenuBarId			= AFX_IDW_CONTROLBAR_FIRST + 20;

/////////////////////////////////////////////////////////////////////////////
// CInPlaceFrame

IMPLEMENT_DYNCREATE(CInPlaceFrame, COleIPFrameWndEx)

BEGIN_MESSAGE_MAP(CInPlaceFrame, COleIPFrameWndEx)
	//{{AFX_MSG_MAP(CInPlaceFrame)
	ON_WM_CREATE()
	ON_WM_DESTROY()
	ON_COMMAND(ID_HELP, OnHelpFinder)
	ON_COMMAND(ID_PEN_TOGGLE, OnPenToggle)
	ON_COMMAND(ID_HELP_INDEX, OnHelpFinder)
	//}}AFX_MSG_MAP
	ON_UPDATE_COMMAND_UI(ID_VIEW_TOOLBAR, OnUpdateControlBarMenu)
	ON_COMMAND_EX(ID_VIEW_TOOLBAR, OnBarCheck)
	ON_UPDATE_COMMAND_UI(ID_VIEW_FORMATBAR, OnUpdateControlBarMenu)
	ON_COMMAND_EX(ID_VIEW_FORMATBAR, OnBarCheck)
	ON_UPDATE_COMMAND_UI(ID_VIEW_RULER, OnUpdateControlBarMenu)
	ON_COMMAND_EX(ID_VIEW_RULER, OnBarCheck)
	ON_MESSAGE(WM_SIZECHILD, OnResizeChild)
	ON_MESSAGE(WPM_BARSTATE, OnBarState)
	ON_COMMAND(ID_DEFAULT_HELP, OnHelpFinder)
END_MESSAGE_MAP()

/////////////////////////////////////////////////////////////////////////////
// arrays of IDs used to initialize control bars

static UINT BASED_CODE toolButtons[] =
{
	// same order as in the bitmap 'itoolbar.bmp'
	ID_EDIT_CUT,
	ID_EDIT_COPY,
	ID_EDIT_PASTE,

		ID_SEPARATOR,
	ID_PEN_TOGGLE,
	ID_PEN_PERIOD,
	ID_PEN_SPACE,
	ID_PEN_BACKSPACE,
	ID_PEN_NEWLINE,
	ID_PEN_LENS
};

#define NUM_PEN_ITEMS 7
#define NUM_PEN_TOGGLE 5

static UINT BASED_CODE format[] =
{
	// same order as in the bitmap 'format.bmp'
	IDC_FONTNAME,
		ID_SEPARATOR,
	IDC_FONTSIZE,
		ID_SEPARATOR,
	ID_CHAR_BOLD,
	ID_CHAR_ITALIC,
	ID_CHAR_UNDERLINE,
	ID_CHAR_COLOR,
		ID_SEPARATOR,
	ID_PARA_LEFT,
	ID_PARA_CENTER,
	ID_PARA_RIGHT,
		ID_SEPARATOR,
	ID_INSERT_BULLET,
};

/////////////////////////////////////////////////////////////////////////////
// CInPlaceFrame construction/destruction

CInPlaceFrame::CInPlaceFrame() : m_wndRulerBar(FALSE)
{
}

int CInPlaceFrame::OnCreate(LPCREATESTRUCT lpCreateStruct)
{
	if (COleIPFrameWndEx::OnCreate(lpCreateStruct) == -1)
		return -1;

	// CResizeBar implements in-place resizing.
	if (!m_wndResizeBar.Create(this))
	{
		TRACE0("Failed to create resize bar\n");
		return -1;      // fail to create
	}

	if (!CreateRulerBar(this))
		return FALSE;

	// By default, it is a good idea to register a drop-target that does
	//  nothing with your frame window.  This prevents drops from
	//  "falling through" to a container that supports drag-drop.
	m_dropTarget.Register(this);

	return 0;
}

// OnCreateControlBars is called by the framework to create control bars on the
//  container application's windows.  pWndFrame is the top level frame window of
//  the container and is always non-NULL.  pWndDoc is the doc level frame window
//  and will be NULL when the container is an SDI application.  A server
//  application can place MFC control bars on either window.
BOOL CInPlaceFrame::OnCreateControlBars(CFrameWnd* pWndFrame, CFrameWnd* /*pWndDoc*/)
{
	if (!CreateMenuBar())
		return -1;

	if (!CreateToolBar(pWndFrame))
		return FALSE;

	if (!CreateFormatBar(pWndFrame))
		return FALSE;

	// set owner to this window, so messages are delivered to correct app
	m_wndToolBar.EnableDocking(CBRS_ALIGN_ANY);
	m_wndFormatBar.EnableDocking(CBRS_ALIGN_TOP|CBRS_ALIGN_BOTTOM);

	COleCntrFrameWndEx* pFrame = DYNAMIC_DOWNCAST (COleCntrFrameWndEx, m_pMainFrame);
	if (pFrame == NULL) 
	{
		return FALSE;
	}

	ASSERT_VALID (pFrame);

	pFrame->EnableDocking(CBRS_ALIGN_ANY);
	pFrame->DockPane(&m_wndToolBar);
	pFrame->DockPane(&m_wndFormatBar);

	m_wndToolBar.SetOwner(this);
	m_wndFormatBar.SetOwner(this);
	m_wndRulerBar.SetOwner(this);
	OnBarState(1, RD_EMBEDDED); //load bar state
	return TRUE;
}

BOOL CInPlaceFrame::CreateMenuBar()
{
	//----------------------------------------------
	// Create menu bar (replaces the standard menu):
	//----------------------------------------------
	if (!m_wndMenuBar.Create (this, WS_CHILD | WS_VISIBLE | CBRS_TOP, uiMenuBarId))
	{
		TRACE0("Failed to create menubar\n");
		return FALSE;
	}

	m_wndMenuBar.SetPaneStyle(m_wndMenuBar.GetPaneStyle() |
		CBRS_TOOLTIPS | CBRS_FLYBY | CBRS_SIZE_DYNAMIC | CBRS_GRIPPER | CBRS_BORDER_3D);

	CString str;
	str.LoadString(IDS_TITLE_MENUBAR);
	m_wndMenuBar.SetWindowText(str);
	return TRUE;
}

BOOL CInPlaceFrame::CreateToolBar(CWnd* pWndFrame)
{
	// Create toolbar on client's frame window
	ASSERT(m_wndToolBar.m_hWnd == NULL);
	int nPen = GetSystemMetrics(SM_PENWINDOWS) ? NUM_PEN_TOGGLE :
		NUM_PEN_ITEMS;

	if (!m_wndToolBar.Create(pWndFrame, WS_CHILD|WS_VISIBLE|CBRS_TOP|
			CBRS_TOOLTIPS|CBRS_FLYBY|CBRS_SIZE_DYNAMIC | CBRS_GRIPPER | CBRS_BORDER_3D)||
		!m_wndToolBar.LoadBitmap(IDR_SRVR_INPLACE) ||
		!m_wndToolBar.SetButtons(toolButtons,
			sizeof(toolButtons)/sizeof(UINT) - nPen))
	{
		TRACE0("Failed to create toolbar\n");
		return FALSE;      // fail to create
	}

	CString str;
	str.LoadString(IDS_TITLE_TOOLBAR);
	m_wndToolBar.SetWindowText(str);
	return TRUE;
}

BOOL CInPlaceFrame::CreateFormatBar(CWnd* pWndFrame)
{
	ASSERT(m_wndFormatBar.m_hWnd == NULL);
	m_wndFormatBar.m_hWndOwner = m_hWnd;
	
	if (!m_wndFormatBar.Create(pWndFrame, WS_CHILD|WS_VISIBLE|CBRS_TOP|
		CBRS_TOOLTIPS|CBRS_FLYBY|CBRS_HIDE_INPLACE|CBRS_SIZE_DYNAMIC | CBRS_GRIPPER | CBRS_BORDER_3D, 
		ID_VIEW_FORMATBAR) ||
		!m_wndFormatBar.LoadBitmap(IDB_FORMATBAR) ||
		!m_wndFormatBar.SetButtons(format,
			sizeof(format)/sizeof(UINT)))
	{
		TRACE0("Failed to create FormatBar\n");
		return FALSE;      // fail to create
	}

	CString str;
	str.LoadString(IDS_TITLE_FORMATBAR);
	m_wndFormatBar.SetWindowText(str);
	return TRUE;
}

BOOL CInPlaceFrame::CreateRulerBar(CWnd* pWndFrame)
{
	if (!m_wndRulerBar.Create(pWndFrame,
		WS_CHILD|WS_VISIBLE|CBRS_ALIGN_TOP|CBRS_HIDE_INPLACE, ID_VIEW_RULER))
	{
		TRACE0("Failed to create ruler\n");
		return FALSE;      // fail to create
	}
	return TRUE;
}

/////////////////////////////////////////////////////////////////////////////
// CInPlaceFrame Operations

/////////////////////////////////////////////////////////////////////////////
// CInPlaceFrame diagnostics

#ifdef _DEBUG
void CInPlaceFrame::AssertValid() const
{
	COleIPFrameWndEx::AssertValid();
}

void CInPlaceFrame::Dump(CDumpContext& dc) const
{
	COleIPFrameWndEx::Dump(dc);
}
#endif //_DEBUG

/////////////////////////////////////////////////////////////////////////////
// CInPlaceFrame commands
// <snippet1>
void CInPlaceFrame::OnDestroy()
{
	m_wndToolBar.DestroyWindow();
	m_wndFormatBar.DestroyWindow();
	COleIPFrameWndEx::OnDestroy();
}

void CInPlaceFrame::RepositionFrame(LPCRECT lpPosRect, LPCRECT lpClipRect)
{
	CRect rectNew = lpPosRect;
	rectNew.left -= HORZ_TEXTOFFSET;
	rectNew.top -= VERT_TEXTOFFSET;
	m_wndResizeBar.BringWindowToTop();
	COleIPFrameWndEx::RepositionFrame(&rectNew, lpClipRect);
	CWnd* pWnd = GetActiveView();
	if (pWnd != NULL)
		pWnd->BringWindowToTop();
	m_wndRulerBar.BringWindowToTop();
}

void CInPlaceFrame::RecalcLayout(BOOL bNotify)
{
	if (m_wndResizeBar.m_hWnd != NULL)
		m_wndResizeBar.BringWindowToTop();
	COleIPFrameWndEx::RecalcLayout(bNotify);
	CWnd* pWnd = GetActiveView();
	if (pWnd != NULL)
		pWnd->BringWindowToTop();
	if (m_wndRulerBar.m_hWnd != NULL)
		m_wndRulerBar.BringWindowToTop();

	// at least 12 pt region plus ruler if it exists
	CDisplayIC dc;
	CSize size;
	size.cy = MulDiv(12, dc.GetDeviceCaps(LOGPIXELSY), 72)+1;
	size.cx = dc.GetDeviceCaps(LOGPIXELSX)/4; // 1/4"
	size.cx += HORZ_TEXTOFFSET; //adjust for offset
	size.cy += VERT_TEXTOFFSET;
	if (m_wndRulerBar.m_hWnd != NULL && m_wndRulerBar.IsVisible())
	{
		CRect rect;
		m_wndRulerBar.GetWindowRect(&rect);
		size.cy += rect.Height();
	}
	m_wndResizeBar.SetMinSize(size);
}

void CInPlaceFrame::CalcWindowRect(LPRECT lpClientRect, UINT nAdjustType)
{
	COleIPFrameWndEx::CalcWindowRect(lpClientRect, nAdjustType);
}
// </snippet1>
LRESULT CInPlaceFrame::OnResizeChild(WPARAM /*wParam*/, LPARAM lParam)
{
	// notify the container that the rectangle has changed!
	CWordPadDoc* pDoc = (CWordPadDoc*)GetActiveDocument();
	if (pDoc == NULL)
		return 0;

	ASSERT(pDoc->IsKindOf(RUNTIME_CLASS(CWordPadDoc)));

	// get new rect and parent
	CRect rectNew;
	rectNew.CopyRect((LPCRECT)lParam);
	CWnd* pParentWnd = GetParent();
	ASSERT_VALID(pParentWnd);

	// convert rectNew relative to pParentWnd
	ClientToScreen(&rectNew);
	pParentWnd->ScreenToClient(&rectNew);

	if (m_wndRulerBar.GetStyle()&WS_VISIBLE)
	{
		CRect rect;
		m_wndRulerBar.GetWindowRect(&rect);
		rectNew.top += rect.Height();
	}
	rectNew.left += HORZ_TEXTOFFSET;
	rectNew.top += VERT_TEXTOFFSET;

	// adjust the new rectangle for the current control bars
	CWnd* pLeftOver = GetDlgItem(AFX_IDW_PANE_FIRST);
	ASSERT(pLeftOver != NULL);
	CRect rectCur = m_rectPos;
	pLeftOver->CalcWindowRect(&rectCur, CWnd::adjustOutside);
	rectNew.left += m_rectPos.left - rectCur.left;
	rectNew.top += m_rectPos.top - rectCur.top;
	rectNew.right -= rectCur.right - m_rectPos.right;
	rectNew.bottom -= rectCur.bottom - m_rectPos.bottom;
	OnRequestPositionChange(rectNew);

	return 0;
}

LRESULT CInPlaceFrame::OnBarState(WPARAM wParam, LPARAM lParam)
{
	if (lParam == -1)
		return 0L;
	if (wParam == 0)
	{
		GetDockState(theApp.GetDockState(RD_EMBEDDED));
		ASSERT(m_pMainFrame != NULL);
		m_pMainFrame->GetDockState(theApp.GetDockState(RD_EMBEDDED, FALSE));
	}
	else
	{
		SetDockState(theApp.GetDockState(RD_EMBEDDED));
		m_pMainFrame->SetDockState(theApp.GetDockState(RD_EMBEDDED, FALSE));
	}
	return 0L;
}

void CInPlaceFrame::OnHelpFinder()
{
	theApp.WinHelp(0, HELP_FINDER);
}

void CInPlaceFrame::OnPenToggle()
{
	static int nPen = 0;
	m_wndToolBar.SetButtons(toolButtons, sizeof(toolButtons)/sizeof(UINT) - nPen);
	nPen = (nPen == 0) ? NUM_PEN_TOGGLE : 0;
	m_wndToolBar.Invalidate();
	m_wndToolBar.GetParentFrame()->RecalcLayout();
}
