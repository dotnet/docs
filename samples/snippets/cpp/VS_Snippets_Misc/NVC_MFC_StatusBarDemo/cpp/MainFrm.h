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

#define CFrameWnd CFrameWndEx

//-----------------
// Statusbar panes:
//-----------------
// <Snippet6>
// in MainFrm.h
const int nStatusIcon = 0;
const int nStatusInfo = 1;
const int nStatusProgress = 2;
const int nStatusLabel = 3;
const int nStatusAnimation = 4;
// </Snippet6>

class CMainFrame : public CFrameWnd
{
	
protected: // create from serialization only
	CMainFrame();
	DECLARE_DYNCREATE(CMainFrame)

// Attributes
// <Snippet7>
// in MainFrm.h
public:
	CMFCStatusBar& GetStatusBar ()
	{
		return m_wndStatusBar;
	}
// </Snippet7>

// Operations
public:

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

protected:
	afx_msg int OnCreate(LPCREATESTRUCT lpCreateStruct);
	afx_msg void OnViewCustomize();
	afx_msg LRESULT OnToolbarReset(WPARAM,LPARAM);
	afx_msg LRESULT OnToolbarContextMenu(WPARAM,LPARAM);

	DECLARE_MESSAGE_MAP()

	virtual BOOL OnShowPopupMenu (CMFCPopupMenu* pMenuPopup);
};
