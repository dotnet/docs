// This is a part of the Microsoft Foundation Classes C++ library.
// Copyright (c) Microsoft Corporation.  All rights reserved.
//
// This source code is only intended as a supplement to the
// Microsoft Foundation Classes Reference and related
// electronic documentation provided with the library.
// See these sources for detailed information regarding the
// Microsoft Foundation Classes product.

#pragma once

#define CFrameWnd CFrameWndEx

#include "FolderListBar.h"
#include "CalendarBar.h"

class CWorkspaceObj;

class CMyOutlookBar : public CMFCOutlookBar
{
	virtual BOOL AllowShowOnPaneMenu() const;
	virtual void GetPaneName(CString& strName) const
	{
		strName = _T("Outlook Bar");
	}
};

class CShellTreeCtrl : public CMFCShellTreeCtrl
{
	virtual BOOL OnNotify(WPARAM wParam, LPARAM lParam, LRESULT* pResult)
	{
		BOOL bRes = CMFCShellTreeCtrl::OnNotify(wParam, lParam, pResult);

		NMHDR* pNMHDR = (NMHDR*)lParam;
		ASSERT (pNMHDR != NULL);

		if (pNMHDR && pNMHDR->code == TTN_SHOW && GetToolTips () != NULL)
		{
			GetToolTips ()->SetWindowPos (&wndTop, -1, -1, -1, -1,
			SWP_NOMOVE | SWP_NOACTIVATE | SWP_NOSIZE);
		}

		return bRes;
	}
};

class CMainFrame : public CFrameWnd
{
protected: // create from serialization only
	CMainFrame();
	DECLARE_DYNCREATE(CMainFrame)

// Attributes
public:
	BOOL IsOutlookBar2003() const
	{
		return m_bOutlookBar2003;
	}

// Operations
public:
	void SetWorkSpace(CWorkspaceObj* pWorkSpace);
	void OnCloseFoldersPopup(BOOL bKeep);
	virtual void AdjustDockingLayout(HDWP hdwp = NULL);

	void OnChangeLook(BOOL bOutlookBar2003);

// Overrides
public:
	virtual BOOL PreCreateWindow(CREATESTRUCT& cs);
	virtual void RecalcLayout(BOOL bNotify = TRUE);
	virtual BOOL LoadFrame(UINT nIDResource, DWORD dwDefaultStyle = WS_OVERLAPPEDWINDOW | FWS_ADDTOTITLE, CWnd* pParentWnd = NULL, CCreateContext* pContext = NULL);

protected:
	virtual BOOL OnCreateClient(LPCREATESTRUCT lpcs, CCreateContext* pContext);

// Implementation
public:
	virtual ~CMainFrame();
#ifdef _DEBUG
	virtual void AssertValid() const;
	virtual void Dump(CDumpContext& dc) const;
#endif

protected:  // control bar embedded members
	CMFCMenuBar m_wndMenuBar;
	CMFCStatusBar m_wndStatusBar;

	CImageList m_imlStatusAnimation;

	CMFCToolBar m_wndToolBar;
	CMFCToolBar m_wndToolBarAdvanced;
	CMFCToolBar m_wndToolBarWeb;

	CMyOutlookBar m_wndBarOutlook;
	CMyOutlookBar m_wndBarOutlook2003;

	// Outlook bar panes:
	CMFCOutlookBarPane m_wndOutlookPane1;
	CMFCOutlookBarPane m_wndOutlookPane2;
	CShellTreeCtrl m_wndTree;
	CCalendarBar m_wndCalendar;

	// Outlook bar-2003 panes:
	CMFCOutlookBarPane m_wndOutlookPane12003;
	CMFCOutlookBarPane m_wndOutlookPane22003;
	CShellTreeCtrl m_wndTree2003;
	CCalendarBar m_wndCalendar2003;

	UINT m_uiHilightedPage;

	CMFCCaptionBar m_wndCaption;

	CFolderListBar m_wndFolderList;

	CSplitterWndEx m_wndSplitter;

	CMFCToolBarImages m_UserImages;
	CImageList m_ImagesSmall;

	CObList m_lstWorkspaces; // List of CWorkspaceObj
	CWorkspaceObj* m_pCurrWorkSpace;

	BOOL m_bOutlookBar2003;

protected:
	afx_msg int OnCreate(LPCREATESTRUCT lpCreateStruct);
	afx_msg void OnActivate(UINT nState, CWnd* pWndOther, BOOL bMinimized);
	afx_msg void OnOutlookAddPage();
	afx_msg void OnOutlookAnimation();
	afx_msg void OnOutlookDeletePage();
	afx_msg void OnOutlookRenamePage();
	afx_msg void OnOutlookShowTextLabels();
	afx_msg void OnUpdateOutlookRenamePage(CCmdUI* pCmdUI);
	afx_msg void OnUpdateOutlookDeletePage(CCmdUI* pCmdUI);
	afx_msg void OnUpdateOutlookAnimation(CCmdUI* pCmdUI);
	afx_msg void OnUpdateOutlookShowTextLabels(CCmdUI* pCmdUI);
	afx_msg void OnResetPage();
	afx_msg void OnUpdateResetPage(CCmdUI* pCmdUI);
	afx_msg void OnClose();
	afx_msg void OnUpdateOutlookAddPage(CCmdUI* pCmdUI);
	afx_msg void OnSettingChange(UINT uFlags, LPCTSTR lpszSection);
	afx_msg void OnEnable( BOOL bEnable );
	afx_msg void OnViewCaptionbar();
	afx_msg void OnUpdateViewCaptionbar(CCmdUI* pCmdUI);
	afx_msg void OnViewFolderList();
	afx_msg void OnUpdateViewFolderList(CCmdUI* pCmdUI);
	afx_msg void OnViewOutlookbar();
	afx_msg void OnUpdateViewOutlookbar(CCmdUI* pCmdUI);
	afx_msg void OnViewCustomize();
	afx_msg LRESULT OnToolbarReset(WPARAM,LPARAM);
	afx_msg LRESULT OnToolbarCreateNew(WPARAM,LPARAM);
	afx_msg void OnUpdateIndicatorSendReceive(CCmdUI* pCmdUI);
	afx_msg LRESULT OnToolbarContextMenu(WPARAM,LPARAM);
	afx_msg void OnViewWorkSpace(UINT ud);
	afx_msg void OnViewMyComputer();
	afx_msg void OnViewFoldersPopup();

	DECLARE_MESSAGE_MAP()

	BOOL CreateOutlookBar(CMFCOutlookBar& bar, UINT uiID, CMFCOutlookBarPane& pane1, CMFCOutlookBarPane& pane2, CShellTreeCtrl& tree, CCalendarBar& calendar, int nInitialWidth);
	BOOL CreateCaptionBar();

	void SetBasicCommands();

	void AddWorkSpace(const CString& strName, const int iIconIndex, const UINT uiCmd, CMFCOutlookBarPane& pane, const UINT uiNewCmdID, CImageList& images);
	int FindFocusedOutlookWnd(CMFCOutlookBarTabCtrl** ppOutlookWnd);
	CMFCOutlookBarTabCtrl* FindOutlookParent(CWnd* pWnd);
	CMFCOutlookBarTabCtrl* m_pCurrOutlookWnd;

	CMFCOutlookBarPane* m_pCurrOutlookPage;
};


