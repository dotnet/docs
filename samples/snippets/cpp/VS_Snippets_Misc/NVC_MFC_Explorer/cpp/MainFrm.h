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

#include "FolderBar.h"

#define CFrameWnd CFrameWndEx

class CMainFrame : public CFrameWnd
{
	
protected: // create from serialization only
	CMainFrame();
	DECLARE_DYNCREATE(CMainFrame)

// Attributes
public:
	CMFCShellTreeCtrl& GetFolders ();

// Operations
public:
	void SetCurrFolder (LPCTSTR lpszPath);

// Overrides
	public:
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
	CMFCStatusBar	m_wndStatusBar;
	CMFCToolBar		m_wndToolBar;
	CMFCReBar		m_wndReBar;
	CFolderBar		m_wndFoldersBar;
	CComboBoxEx		m_wndAddress;

protected:
	afx_msg int OnCreate(LPCREATESTRUCT lpCreateStruct);
	afx_msg void OnViewCustomize();
	afx_msg LRESULT OnToolbarReset(WPARAM,LPARAM);
	afx_msg LRESULT OnToolbarContextMenu(WPARAM,LPARAM);
	afx_msg void OnViewFolders();
	afx_msg void OnUpdateViewFolders(CCmdUI* pCmdUI);
	afx_msg void OnNewAddressEnter();
	afx_msg void OnNewAddress();

	DECLARE_MESSAGE_MAP()

	virtual BOOL OnShowPopupMenu (CMFCPopupMenu* pMenuPopup);
};
