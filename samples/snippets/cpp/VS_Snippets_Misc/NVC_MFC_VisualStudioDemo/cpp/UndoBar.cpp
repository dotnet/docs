// This is a part of the Microsoft Foundation Classes C++ library.
// Copyright (c) Microsoft Corporation.  All rights reserved.
//
// This source code is only intended as a supplement to the
// Microsoft Foundation Classes Reference and related
// electronic documentation provided with the library.
// See these sources for detailed information regarding the
// Microsoft Foundation Classes product.

#include "stdafx.h"
#include "UndoBar.h"

#ifdef _DEBUG
#define new DEBUG_NEW
#undef THIS_FILE
static char THIS_FILE[] = __FILE__;
#endif

IMPLEMENT_SERIAL(CUndoBar, CMFCPopupMenuBar, 1)

const int ID_LIST = 1;

/////////////////////////////////////////////////////////////////////////////
// CUndoBar

#pragma warning(disable: 4355)
CUndoBar::CUndoBar() : m_wndList(*this), m_nLabelHeight(0)
#pragma warning(default: 4355)
{
	m_rectLabel.SetRectEmpty();
}

CUndoBar::~CUndoBar()
{
}

BEGIN_MESSAGE_MAP(CUndoBar, CMFCPopupMenuBar)
	ON_WM_SIZE()
	ON_WM_CREATE()
END_MESSAGE_MAP()

/////////////////////////////////////////////////////////////////////////////
// CUndoBar message handlers

void CUndoBar::OnFillBackground(CDC* pDC)
{
	ASSERT_VALID(pDC);

	CRect rectClient;
	GetClientRect(rectClient);

	::FillRect(pDC->GetSafeHdc(), &rectClient, ::GetSysColorBrush(COLOR_3DFACE));

	// Draw label:
	pDC->Draw3dRect(m_rectLabel, ::GetSysColor(COLOR_3DSHADOW), ::GetSysColor(COLOR_3DHILIGHT));

	CFont* pOldFont = pDC->SelectObject((CFont*) &CMFCMenuBar::GetMenuFont());
	pDC->SetBkMode(TRANSPARENT);
	pDC->SetTextColor(::GetSysColor(COLOR_BTNTEXT));

	CRect rectText = m_rectLabel;
	rectText.DeflateRect(1, 1);
	pDC->DrawText(m_strLabel, rectText, DT_CENTER | DT_VCENTER);

	pDC->SelectObject(pOldFont);
}

CSize CUndoBar::CalcSize(BOOL /*bVertDock*/)
{
	return CSize(160, 115);
}

CUndoButton* CUndoBar::GetParentButton() const
{
	// Get parent button:
	CUndoButton* pUndoButton = NULL;

	CUndoMenu* pParentMenu = DYNAMIC_DOWNCAST(CUndoMenu, GetParent());
	if (pParentMenu != NULL)
	{
		pUndoButton = DYNAMIC_DOWNCAST(CUndoButton, pParentMenu->GetParentButton());
	}

	return pUndoButton;
}

void CUndoBar::OnSize(UINT nType, int cx, int cy)
{
	const int nMargin = 5;

	CMFCPopupMenuBar::OnSize(nType, cx, cy);

	CRect rectClient;
	GetClientRect(rectClient);

	rectClient.DeflateRect(nMargin, nMargin);

	m_rectLabel = rectClient;
	m_rectLabel.top = m_rectLabel.bottom - m_nLabelHeight;

	CRect rectList = rectClient;
	rectList.bottom = m_rectLabel.top - nMargin;

	m_wndList.MoveWindow(rectList);
}

int CUndoBar::OnCreate(LPCREATESTRUCT lpCreateStruct)
{
	if (CMFCPopupMenuBar::OnCreate(lpCreateStruct) == -1)
		return -1;

	CFont* pMenuFont = (CFont*) &CMFCMenuBar::GetMenuFont();

	// Set label height:
	CClientDC dc(this);
	CFont* pOldFont = dc.SelectObject(pMenuFont);

	TEXTMETRIC tm;
	dc.GetTextMetrics(&tm);

	m_nLabelHeight = tm.tmHeight + 2;

	dc.SelectObject(pOldFont);

	CRect rectDummy(0, 0, 0, 0);
	m_wndList.Create(WS_VISIBLE | WS_CHILD | LBS_NOINTEGRALHEIGHT | LBS_NOTIFY | WS_VSCROLL | LBS_MULTIPLESEL, rectDummy, this, ID_LIST);
	m_wndList.ModifyStyleEx(0, WS_EX_CLIENTEDGE);

	m_wndList.SetFont(pMenuFont);

	CUndoButton* pUndoButton = GetParentButton();
	ASSERT_VALID(pUndoButton);

	for (POSITION pos = pUndoButton->m_lstActions.GetHeadPosition(); pos != NULL;)
	{
		m_wndList.AddString(pUndoButton->m_lstActions.GetNext(pos));
	}

	return 0;
}

void CUndoBar::DoUndo()
{
	CUndoButton* pUndoButton = GetParentButton();
	ASSERT_VALID(pUndoButton);

	pUndoButton->m_nSelNum = m_wndList.GetSelCount() + 1;

	CMDIChildWnd* pChildFrame = ((CMDIFrameWndEx*)GetTopLevelFrame())->MDIGetActive();
	if (pChildFrame)
	{
		CEditView* pView = DYNAMIC_DOWNCAST(CEditView, pChildFrame->GetActiveView());
		if (pView != NULL)
		{
			//pView->OnEditUndo(); TODO
		}
		else
		{
			ASSERT(FALSE);
		}
	}
	else
	{
		ASSERT(FALSE);
	}

	GetParent()->PostMessage(WM_CLOSE);
}

void CUndoBar::SetLabel(const CString& strLabel)
{
	m_strLabel = strLabel;

	if (GetSafeHwnd() != NULL)
	{
		InvalidateRect(m_rectLabel);
		UpdateWindow();
	}
}

//////////////////////////////////////////////////////////////////////////////
// CUndoButton

IMPLEMENT_SERIAL(CUndoButton, CMFCToolBarMenuButton, 1)

CMFCPopupMenu* CUndoButton::CreatePopupMenu()
{
	if (CMFCToolBar::IsCustomizeMode() ||(m_nStyle & TBBS_DISABLED))
	{
		return NULL;
	}

	CUndoMenu* pPopupMenu = new CUndoMenu;

	ResetSelNum();

#if 0
	CMDIChildWnd* pChildFrame = ((CMDIFrameWndEx*)::AfxGetMainWnd())->MDIGetActive();
	if (pChildFrame)
	{
		CVisualStudioDemoView* pView = (CVisualStudioDemoView*)pChildFrame->GetActiveView();

		if (pView && pView->IsKindOf(RUNTIME_CLASS(CVisualStudioDemoView)))
		{
			CDWordArray dwaUAT;

			// Setup undo actions:
			switch (m_nID)
			{
			case ID_EDIT_UNDO:
				pView->GetUndoActions(m_lstActions);

				break;
			case ID_EDIT_REDO:
				pView->GetRedoActions(m_lstActions);

				break;
			default:
				break;
			}
		}
		else
		{
			ASSERT(FALSE);
			m_lstActions.RemoveAll();
		}
	}
	else
	{
		ASSERT(FALSE);
		m_lstActions.RemoveAll();
	}
#endif

	return pPopupMenu;
}

//////////////////////////////////////////////////////////////////////////////
// CUndoMenu

IMPLEMENT_SERIAL(CUndoMenu, CMFCPopupMenu, 1)

BEGIN_MESSAGE_MAP(CUndoMenu, CMFCPopupMenu)
	ON_WM_CREATE()
END_MESSAGE_MAP()

int CUndoMenu::OnCreate(LPCREATESTRUCT lpCreateStruct)
{
	if (CMiniFrameWnd::OnCreate(lpCreateStruct) == -1)
		return -1;

	DWORD toolbarStyle = AFX_DEFAULT_TOOLBAR_STYLE;
	if (m_AnimationType != NO_ANIMATION && !CMFCToolBar::IsCustomizeMode())
	{
		toolbarStyle &= ~WS_VISIBLE;
	}

	if (!m_wndUndoBar.Create(this, toolbarStyle | CBRS_TOOLTIPS | CBRS_FLYBY, 1))
	{
		TRACE(_T("Can't create popup menu bar\n"));
		return -1;
	}

	CWnd* pWndParent = GetParent();
	ASSERT_VALID(pWndParent);

	m_wndUndoBar.SetOwner(pWndParent);
	m_wndUndoBar.SetPaneStyle(m_wndUndoBar.GetPaneStyle() | CBRS_TOOLTIPS);

	ActivatePopupMenu(GetTopLevelFrame(), this);
	RecalcLayout();

	return 0;
}


