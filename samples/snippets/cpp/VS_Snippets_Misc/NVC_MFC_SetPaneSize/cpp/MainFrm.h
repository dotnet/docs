// This is a part of the Microsoft Foundation Classes C++ library.
// Copyright (C) Microsoft Corporation
// All rights reserved.
//
// This source code is only intended as a supplement to the
// Microsoft Foundation Classes Reference and related
// electronic documentation provided with the library.
// See these sources for detailed information regarding the
// Microsoft Foundation Classes product.

#pragma once

#include "WorkspaceBar.h"

#define CFrameWnd CFrameWndEx

class CMainFrame : public CFrameWnd
{
	
protected: // create from serialization only
	CMainFrame();
	DECLARE_DYNCREATE(CMainFrame)

// Attributes
public:

// Operations
public:
	void SetDlgBarSizeInContainer (UINT nSize);
	void SetContainerSize (UINT nSize);
	void SetDlgBarHeightInPixels (UINT nHeight);
	void SetDlgBarWidthInPixels (UINT nWidth);
// Overrides
	virtual BOOL PreCreateWindow(CREATESTRUCT& cs);

// Implementation
public:
	virtual ~CMainFrame();
#ifdef _DEBUG
	virtual void AssertValid() const;
	virtual void Dump(CDumpContext& dc) const;
#endif

protected:  // control bar embedded members
	CMFCMenuBar		m_wndMenuBar;
	CMFCStatusBar		m_wndStatusBar;
	CMFCToolBar		m_wndToolBar;
	CWorkspaceBar		m_wndWorkSpace;

	// <snippet2>
	CPaneDialog		m_wndDlgBar;
	// </snippet2>

protected:
	afx_msg int OnCreate(LPCREATESTRUCT lpCreateStruct);
	afx_msg void OnViewCustomize();
	afx_msg LRESULT OnToolbarReset(WPARAM,LPARAM);
	afx_msg LRESULT OnToolbarContextMenu(WPARAM,LPARAM);
	afx_msg void OnViewWorkspace();
	afx_msg void OnUpdateViewWorkspace(CCmdUI* pCmdUI);
	afx_msg void OnViewDialogBar();
	afx_msg void OnUpdateViewDialogBar(CCmdUI* pCmdUI);

	DECLARE_MESSAGE_MAP()

	virtual BOOL OnShowPopupMenu (CMFCPopupMenu* pMenuPopup);

private:
	BOOL FindInternalDivider (CDockablePane* pBar, 
							 CPaneContainer*& pContainer, 
							 CPaneDivider*& pDivider, BOOL& bLeftSlider, 
							 BOOL& bAloneInContainer);
};
