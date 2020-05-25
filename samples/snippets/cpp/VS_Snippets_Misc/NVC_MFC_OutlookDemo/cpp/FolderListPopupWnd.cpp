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
#include "FolderListPopupWnd.h"
#include "MainFrm.h"

#ifdef _DEBUG
#define new DEBUG_NEW
#undef THIS_FILE
static char THIS_FILE[] = __FILE__;
#endif

const UINT idFoldersTree = 1;
const UINT idPinBtn = 2;
const int nHorzMargin = 2;

/////////////////////////////////////////////////////////////////////////////
// CFolderListPopupWnd

CString CFolderListPopupWnd::m_strClassName;

CFolderListPopupWnd::CFolderListPopupWnd(const CObList& lstWorkspaces, CImageList& images, CWorkspaceObj* pSelWorkSpace) : m_wndFolders(lstWorkspaces, images), m_pSelWorkSpace(pSelWorkSpace), m_bNotify(FALSE)
{
}

CFolderListPopupWnd::~CFolderListPopupWnd()
{
}

BEGIN_MESSAGE_MAP(CFolderListPopupWnd, CWnd)
	ON_WM_SIZE()
	ON_WM_PAINT()
	ON_WM_ERASEBKGND()
	ON_WM_CREATE()
	ON_WM_CANCELMODE()
	ON_WM_NCDESTROY()
	ON_WM_ACTIVATE()
	ON_WM_ACTIVATEAPP()
	ON_NOTIFY(TVN_SELCHANGED, idFoldersTree, OnSelectTree)
	ON_COMMAND(idPinBtn, OnKeepVisible)
END_MESSAGE_MAP()

/////////////////////////////////////////////////////////////////////////////
// CFolderListPopupWnd message handlers

BOOL CFolderListPopupWnd::Create(const RECT& rect)
{
	if (m_strClassName.IsEmpty())
	{
		m_strClassName = ::AfxRegisterWndClass(CS_SAVEBITS, ::LoadCursor(NULL, IDC_ARROW),
			(HBRUSH)(COLOR_BTNFACE + 1), NULL);
	}

	return CWnd::CreateEx(WS_EX_TOPMOST | WS_EX_DLGMODALFRAME, m_strClassName, _T(""), WS_POPUP | WS_VISIBLE | WS_BORDER, rect, AfxGetMainWnd(), NULL);
}

void CFolderListPopupWnd::OnSize(UINT nType, int cx, int cy)
{
	CWnd::OnSize(nType, cx, cy);

	CRect rectBtn;
	m_btnPin.GetClientRect(rectBtn);

	m_rectCaption = CRect(0, 0, cx, rectBtn.Height() + 2);

	m_btnPin.SetWindowPos(NULL, cx - rectBtn.Width() - nHorzMargin, (m_rectCaption.Height() - rectBtn.Height()) / 2, -1, -1, SWP_NOSIZE | SWP_NOZORDER);
	m_wndFolders.MoveWindow(0, m_rectCaption.bottom, cx, cy - m_rectCaption.Height());
}

void CFolderListPopupWnd::OnPaint()
{
	CPaintDC dc(this); // device context for painting

	dc.FillRect(m_rectCaption, &afxGlobalData.brBarFace);

	int nOldBkMode = dc.SetBkMode(TRANSPARENT);
	COLORREF clrOldText = dc.SetTextColor(afxGlobalData.clrBarText);
	CFont* pOldFont = (CFont*) dc.SelectObject(&afxGlobalData.fontRegular);

	CRect rectText = m_rectCaption;
	rectText.left += 2 * nHorzMargin;
	rectText.right -= 2 * nHorzMargin + rectText.Height();

	dc.DrawText(m_strCaption, rectText, DT_END_ELLIPSIS | DT_SINGLELINE | DT_VCENTER);

	dc.SelectObject(pOldFont);
	dc.SetTextColor(clrOldText);
	dc.SetBkMode(nOldBkMode);
}

BOOL CFolderListPopupWnd::OnEraseBkgnd(CDC* /*pDC*/)
{
	return TRUE;
}

BOOL CFolderListPopupWnd::PreTranslateMessage(MSG* pMsg)
{
	switch (pMsg->message)
	{
	case WM_KEYDOWN:
		if (pMsg->wParam == VK_ESCAPE)
		{
			CloseMe();
			return TRUE;
		}
		break;
	}

	return CWnd::PreTranslateMessage(pMsg);
}

int CFolderListPopupWnd::OnCreate(LPCREATESTRUCT lpCreateStruct)
{
	if (CWnd::OnCreate(lpCreateStruct) == -1)
		return -1;

	CRect rect;
	rect.SetRectEmpty();

	// Create folders tree:
	m_wndFolders.Create(0, rect, this, idFoldersTree);

	m_wndFolders.SelectWorkspace(m_pSelWorkSpace);

	m_wndFolders.SetFocus();

	// Create "Pin" button:
	m_btnPin.Create(_T(""), WS_CHILD | WS_VISIBLE | BS_PUSHBUTTON, rect, this, idPinBtn);
	m_btnPin.m_bDrawFocus = FALSE;
	m_btnPin.m_nFlatStyle = CMFCButton::BUTTONSTYLE_FLAT;
	m_btnPin.SetImage(IDB_PIN);
	m_btnPin.SizeToContent();

	BOOL bValidString;
	bValidString = m_strCaption.LoadString(IDS_FOLDER_POPUP_CAPTION);

	m_bNotify = TRUE;

	return 0;
}

void CFolderListPopupWnd::OnCancelMode()
{
	CWnd::OnCancelMode();
	CloseMe();
}

void CFolderListPopupWnd::OnNcDestroy()
{
	CWnd::OnNcDestroy();
	delete this;
}

void CFolderListPopupWnd::OnActivateApp(BOOL bActive, DWORD dwThreadID)
{
	CWnd::OnActivateApp(bActive, dwThreadID);

	if (!bActive)
	{
		CloseMe();
	}
}

void CFolderListPopupWnd::OnActivate(UINT nState, CWnd* pWndOther, BOOL bMinimized)
{
	CWnd::OnActivate(nState, pWndOther, bMinimized);

	if (nState == WA_INACTIVE)
	{
		CloseMe();
	}
}

void CFolderListPopupWnd::OnSelectTree(NMHDR* /*pNMHDR*/, LRESULT* pResult)
{
	HTREEITEM hTreeItem = m_wndFolders.GetSelectedItem();
	if (m_bNotify && hTreeItem != NULL)
	{
		CWorkspaceObj* pWS = (CWorkspaceObj*) m_wndFolders.GetItemData(hTreeItem);

		CMainFrame* pMainFrame = DYNAMIC_DOWNCAST(CMainFrame, GetParentFrame());
		if (pMainFrame != NULL)
		{
			pMainFrame->SetWorkSpace(pWS);
		}

		CloseMe();
	}

	*pResult = 0;
}

void CFolderListPopupWnd::CloseMe(BOOL bKeep)
{
	CMainFrame* pMainFrame = DYNAMIC_DOWNCAST(CMainFrame, GetParentFrame());
	if (pMainFrame != NULL)
	{
		pMainFrame->OnCloseFoldersPopup(bKeep);
	}

	PostMessage(WM_CLOSE);
}

void CFolderListPopupWnd::OnKeepVisible()
{
	CloseMe(TRUE);
}

