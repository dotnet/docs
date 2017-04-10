// This is a part of the Microsoft Foundation Classes C++ library.
// Copyright (c) Microsoft Corporation.  All rights reserved.
//
// This source code is only intended as a supplement to the
// Microsoft Foundation Classes Reference and related
// electronic documentation provided with the library.
// See these sources for detailed information regarding the
// Microsoft Foundation Classes product.

#pragma once

class CHelpToolBar : public CMFCToolBar
{
public:
	virtual void OnUpdateCmdUI(CFrameWnd* /*pTarget*/, BOOL bDisableIfNoHndler)
	{
		CMFCToolBar::OnUpdateCmdUI((CFrameWnd*) GetOwner(), bDisableIfNoHndler);
	}

	virtual BOOL AllowShowOnList() const { return FALSE; }
};

/////////////////////////////////////////////////////////////////////////////
// CDynamicHelpVieBar window

class CDynamicHelpViewBar : public CDockablePane
{
// Construction
public:
	CDynamicHelpViewBar();

	void AdjustLayout();

// Attributes
protected:
	CHelpToolBar m_wndToolBar;
	CTreeCtrl m_wndArticles;
	CImageList m_DynamicHelpImages;

// Operations
public:
	void OnChangeVisualStyle();

protected:
	virtual void OnEraseWorkArea(CDC* pDC, CRect rectWorkArea);
	void FillHelp();

// Implementation
public:
	virtual ~CDynamicHelpViewBar();

protected:
	afx_msg int OnCreate(LPCREATESTRUCT lpCreateStruct);
	afx_msg void OnSize(UINT nType, int cx, int cy);
	afx_msg void OnDhelp1();
	afx_msg void OnUpdateDhelp1(CCmdUI* pCmdUI);
	afx_msg void OnDhelp2();
	afx_msg void OnUpdateDhelp2(CCmdUI* pCmdUI);
	afx_msg void OnDhelp3();
	afx_msg void OnUpdateDhelp3(CCmdUI* pCmdUI);
	afx_msg void OnPaint();
	afx_msg void OnSetFocus(CWnd* pOldWnd);
	afx_msg void OnSelectTree(NMHDR* pNMHDR, LRESULT* pResult);

	DECLARE_MESSAGE_MAP()
};

