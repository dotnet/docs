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

#include "TaskPane.h"

#define CFrameWnd CFrameWndEx

class CMainFrame : public CFrameWnd
{
	friend class CTasksPaneView;
	
protected: // create from serialization only
	CMainFrame();
	DECLARE_DYNCREATE(CMainFrame)

// Attributes
public:

// Operations
public:
	void UpdateMRUFilesList ()
	{
		m_wndTaskPane.UpdateMRUFilesList ();
	}

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
	CMFCMenuBar			m_wndMenuBar;
	CMFCStatusBar	m_wndStatusBar;
	CMFCToolBar		m_wndToolBar;
	CTaskPane			m_wndTaskPane;

protected:
	afx_msg int OnCreate(LPCREATESTRUCT lpCreateStruct);
	afx_msg void OnViewCustomize();
	afx_msg LRESULT OnToolbarReset(WPARAM,LPARAM);
	afx_msg LRESULT OnToolbarContextMenu(WPARAM,LPARAM);
	afx_msg void OnViewTaskpane();
	afx_msg void OnUpdateViewTaskpane(CCmdUI* pCmdUI);
	afx_msg void OnTask();
	afx_msg void OnAppLook(UINT id);
	afx_msg void OnUpdateAppLook(CCmdUI* pCmdUI);

	DECLARE_MESSAGE_MAP()

	virtual BOOL OnShowPopupMenu (CMFCPopupMenu* pMenuPopup);
	BOOL CreateTaskPane ();

	UINT	m_nAppLook;
};

