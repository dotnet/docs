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

#include "LinksBar.h"
#include "ExplorerBar.h"

class CMainFrame : public CFrameWnd
{
protected: // create from serialization only
	CMainFrame();
	DECLARE_DYNCREATE(CMainFrame)

// Attributes
public:
	CMenu								m_menuFavotites;

protected:
	CBitmap								m_bmpStatus;
	CImageList							m_imlStatusAnimation;

// Operations
public:
	void SetAddress(LPCTSTR lpszUrl);
	void StartAnimation();
	BOOL IsFavoritesMenu (const CMFCToolBarMenuButton* pMenuButton);

	virtual BOOL OnShowPopupMenu (CMFCPopupMenu* pMenuPopup);
	virtual BOOL OnDrawMenuImage (CDC* pDC,
									const CMFCToolBarMenuButton* pMenuButton, 
									const CRect& rectImage);

	virtual BOOL OnMenuButtonToolHitTest (CMFCToolBarButton* pButton, TOOLINFO* pTI);
	virtual BOOL GetToolbarButtonToolTipText (CMFCToolBarButton* pButton, CString& strTTText);

	void SetProgress (long nCurr, long nTotal);

// Overrides
	// ClassWizard generated virtual function overrides
	//{{AFX_VIRTUAL(CMainFrame)
	public:
	virtual BOOL PreCreateWindow(CREATESTRUCT& cs);
	virtual BOOL LoadFrame(UINT nIDResource, DWORD dwDefaultStyle = WS_OVERLAPPEDWINDOW | FWS_ADDTOTITLE, CWnd* pParentWnd = NULL, CCreateContext* pContext = NULL);
	//}}AFX_VIRTUAL

// Implementation
public:
	virtual ~CMainFrame();
#ifdef _DEBUG
	virtual void AssertValid() const;
	virtual void Dump(CDumpContext& dc) const;
#endif

protected:  // control bar embedded members
	// <snippet1>
	CMFCMenuBar	m_wndMenuBar;
	// </snippet1>
	CMFCStatusBar	m_wndStatusBar;

	// <snippet6>
	CMFCToolBar		m_wndToolBar;
	// </snippet6>

	CLinksBar		m_wndLinksBar;
	CMFCReBar		m_wndReBar;
	
	CComboBoxEx		m_wndAddress;
	CExplorerBar	m_wndExplorerBar;

	BOOL			m_bMainToolbarMenu;
	BOOL			m_bIsHighColor;

// Generated message map functions
protected:
	//{{AFX_MSG(CMainFrame)
	afx_msg int OnCreate(LPCREATESTRUCT lpCreateStruct);
	afx_msg void OnLink1();
	afx_msg void OnViewAddressBar();
	afx_msg void OnUpdateViewAddressBar(CCmdUI* pCmdUI);
	afx_msg void OnViewLinksBar();
	afx_msg void OnUpdateViewLinksBar(CCmdUI* pCmdUI);
	afx_msg void OnViewTextlabels();
	afx_msg void OnUpdateViewTextlabels(CCmdUI* pCmdUI);
	afx_msg void OnViewExplorerbar();
	afx_msg void OnUpdateViewExplorerbar(CCmdUI* pCmdUI);
	//}}AFX_MSG
	afx_msg void OnViewCustomize();
	afx_msg LRESULT OnToolbarReset(WPARAM,LPARAM);
	afx_msg LRESULT OnToolbarContextMenu(WPARAM,LPARAM);
	afx_msg LRESULT OnHelpCustomizeToolbars(WPARAM wp, LPARAM lp);
	afx_msg void OnNewAddress();
	afx_msg void OnNewAddressEnter();
	afx_msg void OnFavorite(UINT nID);
	afx_msg void OnHistory(UINT nID);
	afx_msg void OnLinkMSDN();
	afx_msg void OnLinkMicrosoft();
	afx_msg void OnLinkVisualCPP();
	DECLARE_MESSAGE_MAP()
};
