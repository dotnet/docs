// This is a part of the Microsoft Foundation Classes C++ library.
// Copyright (c) Microsoft Corporation.  All rights reserved.
//
// This source code is only intended as a supplement to the
// Microsoft Foundation Classes Reference and related
// electronic documentation provided with the library.
// See these sources for detailed information regarding the
// Microsoft Foundation Classes product.

#pragma once

#include "UndoListBox.h"

class CUndoButton;

/////////////////////////////////////////////////////////////////////////////
// CUndoBar window

class CUndoBar : public CMFCPopupMenuBar
{
	DECLARE_SERIAL(CUndoBar)

// Construction
public:
	CUndoBar();

// Attributes
protected:
	CUndoListBox m_wndList;
	CRect m_rectLabel;
	int m_nLabelHeight;
	CString m_strLabel;

// Operations
public:
	void DoUndo();
	void SetLabel(const CString& strLabel);

// Overrides
	virtual void OnFillBackground(CDC* pDC);
	virtual CSize CalcSize(BOOL bVertDock);

// Implementation
public:
	virtual ~CUndoBar();

protected:
	afx_msg void OnSize(UINT nType, int cx, int cy);
	afx_msg int OnCreate(LPCREATESTRUCT lpCreateStruct);

	DECLARE_MESSAGE_MAP()

	CUndoButton* GetParentButton() const;
};

//////////////////////////////////////////////////////////////////////////////
// CUndoMenu

class CUndoMenu : public CMFCPopupMenu
{
	DECLARE_SERIAL(CUndoMenu)

	virtual CMFCPopupMenuBar* GetMenuBar()
	{
		return &m_wndUndoBar;
	}

	CUndoBar m_wndUndoBar;

protected:
	afx_msg int OnCreate(LPCREATESTRUCT lpCreateStruct);

	DECLARE_MESSAGE_MAP()
};

//////////////////////////////////////////////////////////////////////////////
// CUndoButton

class CUndoButton : public CMFCToolBarMenuButton
{
	friend class CUndoBar;

	DECLARE_SERIAL(CUndoButton)

public:
	CUndoButton()
	{
	}

	CUndoButton(UINT uiCmdID, LPCTSTR lpszText) : CMFCToolBarMenuButton(uiCmdID, NULL, GetCmdMgr()->GetCmdImage(uiCmdID, FALSE), lpszText)
	{
		m_nSelNum = 0;
	}

	CStringList m_lstActions;
	int m_nSelNum;

	int GetSelNum()
	{
		return m_nSelNum;
	}

	void ResetSelNum()
	{
		m_nSelNum = 0;
	}

protected:
	virtual CMFCPopupMenu* CreatePopupMenu();

	virtual BOOL IsEmptyMenuAllowed() const
	{
		return TRUE;
	}

	virtual void OnChangeParentWnd(CWnd* pWndParent)
	{
		CMFCToolBarMenuButton::OnChangeParentWnd(pWndParent);
		m_bDrawDownArrow = TRUE;
	}

	virtual BOOL IsExclusive() const
	{
		return TRUE;
	}
};

