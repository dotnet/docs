// This is a part of the Microsoft Foundation Classes C++ library.
// Copyright (c) Microsoft Corporation.  All rights reserved.
//
// This source code is only intended as a supplement to the
// Microsoft Foundation Classes Reference and related
// electronic documentation provided with the library.
// See these sources for detailed information regarding the
// Microsoft Foundation Classes product.

#pragma once

#include "MailBar.h"

/////////////////////////////////////////////////////////////////////////////
// CMailFrame frame

class CMailFrame : public CFrameWndEx
{
	DECLARE_DYNCREATE(CMailFrame)

public:
	CMailFrame();
	virtual ~CMailFrame();

// Attributes
protected:  // control bar embedded members
	CMFCMenuBar m_wndMenuBar;
	CMFCToolBar m_wndToolBar;
	CMailBar m_wndMailBar;
	CMFCStatusBar m_wndStatusBar;
	CWnd* m_pMainWnd;

	static CObList m_lstMailFrames;

// Operations
public:
	static void OnChangeLook();

// Overrides
public:
	virtual BOOL LoadFrame(UINT nIDResource, DWORD dwDefaultStyle = WS_OVERLAPPEDWINDOW | FWS_ADDTOTITLE, CWnd* pParentWnd = NULL, CCreateContext* pContext = NULL);

// Implementation
protected:
	afx_msg int OnCreate(LPCREATESTRUCT lpCreateStruct);
	afx_msg void OnActivate(UINT nState, CWnd* pWndOther, BOOL bMinimized);
	afx_msg void OnViewCustomize();
	afx_msg void OnClose();
	afx_msg void OnMailClose();
	afx_msg void OnEnable( BOOL bEnable );
	afx_msg LRESULT OnToolbarReset(WPARAM,LPARAM);

	DECLARE_MESSAGE_MAP()
};

