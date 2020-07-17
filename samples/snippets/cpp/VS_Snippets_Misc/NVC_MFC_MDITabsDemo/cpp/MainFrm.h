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

#define CMDIFrameWnd CMDIFrameWndEx

class CMainFrame : public CMDIFrameWnd
{
	DECLARE_DYNAMIC(CMainFrame)
public:
	CMainFrame();

// Attributes
public:

// Operations
public:
	void UpdateMDITabs (BOOL bResetMDIChild);
	CMDIChildWndEx* CreateDocumentWindow (LPCTSTR lpcszDocName);

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
	CMFCMenuBar	m_wndMenuBar;
	CMFCStatusBar	m_wndStatusBar;
	CMFCToolBar	m_wndToolBar;
	CMFCToolBar	m_wndToolBarTheme;
	CWorkspaceBar	m_wndWorkSpace;

protected:
	afx_msg int OnCreate(LPCREATESTRUCT lpCreateStruct);
	afx_msg void OnViewThemeToolbar();
	afx_msg void OnUpdateViewThemeToolbar(CCmdUI* pCmdUI);
	afx_msg void OnMdiTabbed();
	afx_msg void OnUpdateMdiTabbed(CCmdUI* pCmdUI);
	afx_msg void OnViewCustomize();
	afx_msg LRESULT OnToolbarReset(WPARAM,LPARAM);
	afx_msg LRESULT OnToolbarContextMenu(WPARAM,LPARAM);
	afx_msg void OnViewWorkspace();
	afx_msg void OnUpdateViewWorkspace(CCmdUI* pCmdUI);
	afx_msg void OnWindowManager();
	afx_msg void OnAppLook(UINT id);
	afx_msg void OnUpdateAppLook(CCmdUI* pCmdUI);
	afx_msg LRESULT OnGetTabToolTip(WPARAM wp, LPARAM lp);

	DECLARE_MESSAGE_MAP()

	virtual BOOL OnShowPopupMenu (CMFCPopupMenu* pMenuPopup);
	virtual BOOL OnShowMDITabContextMenu (CPoint point, DWORD dwAllowedItems, BOOL bDrop);

	UINT	m_nAppLook;

	void SetupOffice2007Button ();
};
