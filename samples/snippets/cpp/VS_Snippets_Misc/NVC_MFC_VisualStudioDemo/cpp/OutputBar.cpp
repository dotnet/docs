// This is a part of the Microsoft Foundation Classes C++ library.
// Copyright (c) Microsoft Corporation.  All rights reserved.
//
// This source code is only intended as a supplement to the
// Microsoft Foundation Classes Reference and related
// electronic documentation provided with the library.
// See these sources for detailed information regarding the
// Microsoft Foundation Classes product.

#include "stdafx.h"
#include "VisualStudioDemo.h"
#include "MainFrm.h"
#include "OutputBar.h"

#ifdef _DEBUG
#define new DEBUG_NEW
#undef THIS_FILE
static char THIS_FILE[] = __FILE__;
#endif

/////////////////////////////////////////////////////////////////////////////
// COutputBar

COutputBar::COutputBar()
{
}

COutputBar::~COutputBar()
{
}

BEGIN_MESSAGE_MAP(COutputBar, CDockablePane)
	ON_WM_CREATE()
	ON_WM_SIZE()
END_MESSAGE_MAP()

/////////////////////////////////////////////////////////////////////////////
// COutputBar message handlers

int COutputBar::OnCreate(LPCREATESTRUCT lpCreateStruct)
{
	if (CDockablePane::OnCreate(lpCreateStruct) == -1)
		return -1;

	m_Font.CreateStockObject(DEFAULT_GUI_FONT);

	CRect rectClient(0, 0, lpCreateStruct->cx, lpCreateStruct->cy);

	// Create tabs window:
	if (!m_wndTabs.Create(CMFCTabCtrl::STYLE_FLAT_SHARED_HORZ_SCROLL, rectClient, this, 101))
	{
		TRACE0("Failed to create output tab window\n");
		return -1;      // fail to create
	}

	// Create output panes:
	const DWORD dwStyle = LBS_NOINTEGRALHEIGHT | WS_CHILD | WS_CLIPSIBLINGS | WS_VISIBLE | WS_HSCROLL | WS_VSCROLL;

	m_wndOutputBuild.Create(dwStyle, rectClient, &m_wndTabs, 1);
	m_wndOutputBuild.SetFont(&m_Font);
	m_wndOutputBuild.SetOwner(this);

	m_wndOutputDebug.Create(dwStyle, rectClient, &m_wndTabs, 2);
	m_wndOutputDebug.SetFont(&m_Font);
	m_wndOutputDebug.SetOwner(this);

	m_wndOutputFind1.Create(dwStyle, rectClient, &m_wndTabs, 3);
	m_wndOutputFind1.SetFont(&m_Font);
	m_wndOutputFind1.SetOwner(this);

	m_wndOutputFind2.Create(dwStyle, rectClient, &m_wndTabs, 4);
	m_wndOutputFind2.SetFont(&m_Font);
	m_wndOutputFind2.SetOwner(this);

	m_wndOutputSQL.Create(dwStyle, rectClient, &m_wndTabs, 5);
	m_wndOutputSQL.SetFont(&m_Font);
	m_wndOutputSQL.SetOwner(this);

	// Fill view context(dummy code, don't seek here something magic :-)):
	FillBuildWindow();
	FillDebugWindow();

	// Attach views to tab:
	m_wndTabs.AddTab(&m_wndOutputBuild, _T("Build"), (UINT)-1);
	m_wndTabs.AddTab(&m_wndOutputDebug, _T("Debug"), (UINT)-1);
	m_wndTabs.AddTab(&m_wndOutputFind1, _T("Find in Files 1"), (UINT)-1);
	m_wndTabs.AddTab(&m_wndOutputFind2, _T("Find in Files 2"), (UINT)-1);
	m_wndTabs.AddTab(&m_wndOutputSQL, _T("SQL Debugging"), (UINT)-1);

	return 0;
}

void COutputBar::OnSize(UINT nType, int cx, int cy)
{
	CDockablePane::OnSize(nType, cx, cy);

	CRect rc;
	GetClientRect(rc);

	m_wndTabs.SetWindowPos(NULL, rc.left, rc.top, rc.Width(), rc.Height(), SWP_NOACTIVATE | SWP_NOZORDER | SWP_NOREDRAW);

	AdjusrHorzScroll(m_wndOutputBuild);
	AdjusrHorzScroll(m_wndOutputDebug);
	AdjusrHorzScroll(m_wndOutputFind1);
	AdjusrHorzScroll(m_wndOutputFind2);
	AdjusrHorzScroll(m_wndOutputSQL);
}

void COutputBar::AdjusrHorzScroll(CListBox& wndListBox)
{
	CClientDC dc(this);
	CFont* pOldFont = dc.SelectObject(&m_Font);

	int cxExtentMax = 0;

	for (int i = 0; i < wndListBox.GetCount(); i ++)
	{
		CString strItem;
		wndListBox.GetText(i, strItem);

		cxExtentMax = max(cxExtentMax, dc.GetTextExtent(strItem).cx);
	}

	wndListBox.SetHorizontalExtent(cxExtentMax);
	dc.SelectObject(pOldFont);
}

void COutputBar::FillBuildWindow()
{
	m_wndOutputBuild.AddString(_T("--------------------Configuration: Hello - Win32 Debug--------------------"));
	m_wndOutputBuild.AddString(_T("Compiling..."));
	m_wndOutputBuild.AddString(_T("Hello.cpp..."));
	m_wndOutputBuild.AddString(_T("Linking..."));
	m_wndOutputBuild.AddString(_T(""));
	m_wndOutputBuild.AddString(_T("Hello.exe - 0 error(s), 0 warning(s)"));

}

void COutputBar::FillDebugWindow()
{
	m_wndOutputDebug.AddString(_T("Loaded 'C:\\WINNT\\System32\\ntdll.dll', no matching symbolic information found."));
	m_wndOutputDebug.AddString(_T("Loaded 'C:\\WINNT\\System32\\winmm.dll', no matching symbolic information found."));
	m_wndOutputDebug.AddString(_T("Loaded 'C:\\WINNT\\System32\\USER32.DLL', no matching symbolic information found."));
	m_wndOutputDebug.AddString(_T("Loaded 'C:\\WINNT\\System32\\KERNEL32.DLL', no matching symbolic information found."));
	m_wndOutputDebug.AddString(_T("Loaded 'C:\\WINNT\\System32\\GDI32.DLL', no matching symbolic information found."));
	m_wndOutputDebug.AddString(_T("Loaded 'C:\\WINNT\\System32\\ADVAPI32.DLL', no matching symbolic information found."));
	m_wndOutputDebug.AddString(_T("Loaded 'C:\\WINNT\\System32\\RPCRT4.DLL', no matching symbolic information found."));
	m_wndOutputDebug.AddString(_T("Loaded symbols for 'C:\\WINNT\\System32\\MFC42D.DLL'"));
	m_wndOutputDebug.AddString(_T("Loaded symbols for 'C:\\WINNT\\System32\\MSVCRTD.DLL'"));
	m_wndOutputDebug.AddString(_T("Loaded symbols for 'C:\\WINNT\\System32\\MFCO42D.DLL'"));
	m_wndOutputDebug.AddString(_T("Loaded 'C:\\WINNT\\System32\\MMDRV.DLL', no matching symbolic information found."));
	m_wndOutputDebug.AddString(_T("Loaded 'C:\\WINNT\\System32\\sndblst.dll', no matching symbolic information found."));
	m_wndOutputDebug.AddString(_T("Loaded 'C:\\WINNT\\System32\\COMCTL32.DLL', no matching symbolic information found."));
	m_wndOutputDebug.AddString(_T("CONTROLBAR.DLL Initializing!"));
	m_wndOutputDebug.AddString(_T("Loaded 'C:\\WINNT\\System32\\OLE32.DLL', no matching symbolic information found."));
	m_wndOutputDebug.AddString(_T("The thread 0x142 has exited with code 0(0x0)."));
	m_wndOutputDebug.AddString(_T("CONTROLBAR.DLL Terminating!"));
	m_wndOutputDebug.AddString(_T("The thread 0x15C has exited with code 0(0x0)."));
	m_wndOutputDebug.AddString(_T("The program 'Hello.exe' has exited with code 0(0x0)."));
}
/////////////////////////////////////////////////////////////////////////////
// COutputList1

COutputList1::COutputList1()
{
}

COutputList1::~COutputList1()
{
}

BEGIN_MESSAGE_MAP(COutputList1, CListBox)
	ON_WM_WINDOWPOSCHANGING()
	ON_WM_CONTEXTMENU()
	ON_COMMAND(ID_EDIT_COPY, OnEditCopy)
	ON_COMMAND(ID_EDIT_CLEAR, OnEditClear)
	ON_COMMAND(ID_OUTPUT_GOTO_ERROR, OnOutputGotoError)
	ON_COMMAND(ID_VIEW_OUTPUT, OnViewOutput)
END_MESSAGE_MAP()

/////////////////////////////////////////////////////////////////////////////
// COutputList1 message handlers

void COutputList1::OnWindowPosChanging(WINDOWPOS FAR* lpwndpos)
{
	CListBox::OnWindowPosChanging(lpwndpos);

	// Hide horizontal scrollbar:
	ShowScrollBar(SB_HORZ, FALSE);
	ModifyStyle(WS_HSCROLL, 0, SWP_DRAWFRAME);
}

void COutputList1::OnContextMenu(CWnd* /*pWnd*/, CPoint point)
{
	CMenu menu;
	menu.LoadMenu(IDR_POPUP_OUTPUT);

	CMenu* pSumMenu = menu.GetSubMenu(0);

	if (AfxGetMainWnd()->IsKindOf(RUNTIME_CLASS(CMDIFrameWndEx)))
	{
		CMFCPopupMenu* pPopupMenu = new CMFCPopupMenu;

		if (!pPopupMenu->Create(this, point.x, point.y, (HMENU)pSumMenu->m_hMenu, FALSE, TRUE))
			return;

		((CMDIFrameWndEx*)AfxGetMainWnd())->OnShowPopupMenu(pPopupMenu);
		UpdateDialogControls(this, FALSE);
	}
}

void COutputList1::OnEditCopy()
{
	MessageBox(_T("Copy output"));
}

void COutputList1::OnEditClear()
{
	MessageBox(_T("Clear output"));
}

void COutputList1::OnOutputGotoError()
{
	// TODO: Add your command handler code here
}

// <snippet16>
void COutputList1::OnViewOutput()
{
	CBasePane* pParentBar = DYNAMIC_DOWNCAST(CBasePane, GetOwner());
	CFrameWndEx* pMainFrame = DYNAMIC_DOWNCAST(CFrameWndEx, GetTopLevelFrame());

	if (pMainFrame != NULL && pParentBar != NULL)
	{
		pMainFrame->SetFocus();
		pMainFrame->ShowPane(pParentBar, FALSE, FALSE, FALSE);
	}
}
// </snippet16>
