// This is a part of the Microsoft Foundation Classes C++ library.
// Copyright (c) Microsoft Corporation.  All rights reserved.
//
// This source code is only intended as a supplement to the
// Microsoft Foundation Classes Reference and related
// electronic documentation provided with the library.
// See these sources for detailed information regarding the
// Microsoft Foundation Classes product.

#pragma once

#include "WatchBar.h"
#include "ClassViewBar.h"
#include "ResourceView.h"
#include "FileViewBar.h"
#include "OutputView.h"
#include "DynamicHelpView.h"
#include "PropertiesViewBar.h"

class CMainFrame : public CMDIFrameWndEx
{
	DECLARE_DYNAMIC(CMainFrame)
public:
	CMainFrame();

// Operations
public:
	void OnChangeLook(BOOL bOneNoteTabs, BOOL bMDITabColors, BOOL bIsVSDotNetLook, BOOL bDockTabColors, BOOL bMDITabsVS2005Look, BOOL bActiveTabCloseButton);

// Overrides
public:
	virtual BOOL LoadFrame(UINT nIDResource, DWORD dwDefaultStyle = WS_OVERLAPPEDWINDOW | FWS_ADDTOTITLE, CWnd* pParentWnd = NULL, CCreateContext* pContext = NULL);
	virtual BOOL DestroyWindow();

protected:
	virtual BOOL OnCommand(WPARAM wParam, LPARAM lParam);
	virtual BOOL PreCreateWindow(CREATESTRUCT& cs);

	virtual CMDIChildWndEx* CreateDocumentWindow(LPCTSTR lpcszDocName, CObject* pObj);
	virtual BOOL OnShowMDITabContextMenu(CPoint point, DWORD dwAllowedItems, BOOL bDrop);

// Implementation
public:
	static CMFCToolBarComboBoxButton* GetFindCombo();
	virtual ~CMainFrame();
#ifdef _DEBUG
	virtual void AssertValid() const;
	virtual void Dump(CDumpContext& dc) const;
#endif

protected:  // control bar embedded members
	CMFCMenuBar m_wndMenuBar;
	CMFCStatusBar m_wndStatusBar;
	CMFCToolBar m_wndToolBar;
	CMFCToolBar m_wndToolbarBuild;
	CMFCToolBar m_wndToolbarEdit;

	// <snippet29>
	CMFCDropDownToolBar m_wndToolbarResource;
	// </snippet29>

	CClassViewBar m_wndClassView;
	CResourceViewBar m_wndResourceView;
	CFileViewBar m_wndFileView;

	CDynamicHelpViewBar m_wndDynamicHelpView;
	COutputViewBar m_wndOutputView;
	CPropertiesViewBar m_wndPropertiesBar;

	CWatchBar m_wndWatchBar;

	CMFCToolBarImages m_UserImages;

private:
	BOOL IsEditViewActive();

protected:
	afx_msg int OnCreate(LPCREATESTRUCT lpCreateStruct);
	afx_msg void OnWindowManager();
	afx_msg void OnHelpKeyboardmap();
	afx_msg void OnFileNewProject();
	afx_msg void OnFileNewBlankSolution();
	afx_msg void OnFileOpenSolution();
	afx_msg void OnFileCloseSolution();
	afx_msg void OnFileSaveAll();
	afx_msg void OnViewRefresh();
	afx_msg void OnToolsConnectToDatabase();
	afx_msg void OnToolsDebugProcesses();
	afx_msg void OnViewFullScreen();
	afx_msg void OnToolsOptions();
	afx_msg void OnHelpWeb();
	afx_msg void OnMdiMoveToNextGroup();
	afx_msg void OnMdiMoveToPrevGroup();
	afx_msg void OnMdiNewHorzTabGroup();
	afx_msg void OnMdiNewVertGroup();
	afx_msg void OnMdiCancel();
	afx_msg void OnClose();
	afx_msg void OnViewClass();
	afx_msg void OnUpdateViewClass(CCmdUI* pCmdUI);
	afx_msg void OnViewFile();
	afx_msg void OnUpdateViewFile(CCmdUI* pCmdUI);
	afx_msg void OnViewResource();
	afx_msg void OnUpdateViewResource(CCmdUI* pCmdUI);
	afx_msg void OnViewProperties();
	afx_msg void OnUpdateViewProperties(CCmdUI* pCmdUI);
	afx_msg void OnViewOutput();
	afx_msg void OnUpdateViewOutput(CCmdUI* pCmdUI);
	afx_msg void OnViewWatch();
	afx_msg void OnUpdateViewWatch(CCmdUI* pCmdUI);
	afx_msg void OnViewDynamichelp();
	afx_msg void OnUpdateViewDynamichelp(CCmdUI* pCmdUI);
	afx_msg void OnMdiTabbedDocument();
	afx_msg void OnUpdateMdiTabbedDocument(CCmdUI* pCmdUI);
	afx_msg void OnViewCustomize();
	afx_msg LRESULT OnToolbarReset(WPARAM,LPARAM);
	afx_msg LRESULT OnGetTabToolTip(WPARAM wp, LPARAM lp);
	afx_msg LRESULT OnHelpCustomizeToolbars(WPARAM wp, LPARAM lp);
	LRESULT OnToolbarCreateNew(WPARAM wp,LPARAM lp);
	afx_msg void OnSysColorChange();

	DECLARE_MESSAGE_MAP()

	BOOL CreateDockingBars();
	void SetDockingBarsIcons(BOOL bHiColorIcons);
};


