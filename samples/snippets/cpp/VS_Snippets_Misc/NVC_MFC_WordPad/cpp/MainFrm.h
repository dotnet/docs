//
// mainfrm.h : interface of the CMainFrame class
//
// This is a part of the Microsoft Foundation Classes C++ library.
// Copyright (C) 1992-1998 Microsoft Corporation
// All rights reserved.
//
// This source code is only intended as a supplement to the
// Microsoft Foundation Classes Reference and related
// electronic documentation provided with the library.
// See these sources for detailed information regarding the
// Microsoft Foundation Classes product.

#include "formatba.h"
#include "ruler.h"
#include "taskpane.h"

// <snippet3>
class CMainFrame : public CFrameWndEx
{
protected: // create from serialization only
	CMainFrame();
	DECLARE_DYNCREATE(CMainFrame)

// Attributes
public:
	HICON m_hIconDoc;
	HICON m_hIconText;
	HICON m_hIconWrite;
	HICON GetIcon(int nDocType);

// Operations
public:
	void UpdateMRUFilesList ()
	{
		m_wndTaskPane.UpdateMRUFilesList ();
	}

	void OnChangeLook ();

// Overrides
	// ClassWizard generated virtual function overrides
	//{{AFX_VIRTUAL(CMainFrame)
	public:
	virtual void ActivateFrame(int nCmdShow = -1);
	virtual BOOL LoadFrame(UINT nIDResource, DWORD dwDefaultStyle = WS_OVERLAPPEDWINDOW | FWS_ADDTOTITLE, CWnd* pParentWnd = NULL, CCreateContext* pContext = NULL);
	protected:
	virtual BOOL PreCreateWindow(CREATESTRUCT& cs);
	virtual BOOL OnCommand(WPARAM wParam, LPARAM lParam);
	//}}AFX_VIRTUAL

	virtual BOOL OnShowPopupMenu (CMFCPopupMenu* pMenuPopup);
	virtual BOOL OnTearOffMenu (CMFCPopupMenu* pMenuPopup, CPane* pBar);

protected:
	void AdjustObjectSubmenu (CMFCPopupMenu* pMenuPopup);
	void AdjustColorsMenu (CMFCPopupMenu* pMenuPopup, UINT uiId);

// Implementation
public:
	virtual ~CMainFrame();
#ifdef _DEBUG
	virtual void AssertValid() const;
	virtual void Dump(CDumpContext& dc) const;
#endif

public:
	CMFCMenuBar	m_wndMenuBar;
	CMFCToolBar	m_wndToolBar;
	CMFCStatusBar	m_wndStatusBar;
	CFormatBar		m_wndFormatBar;
	CRulerBar		m_wndRulerBar;
	CTaskPane		m_wndTaskPane;

protected:  // control bar embedded members
	BOOL CreateMenuBar();
	BOOL CreateToolBar();
	BOOL CreateFormatBar();
	BOOL CreateStatusBar();
	BOOL CreateRulerBar();
	BOOL CreateTaskPane ();

// Generated message map functions
protected:
	//{{AFX_MSG(CMainFrame)
	afx_msg int OnCreate(LPCREATESTRUCT lpCreateStruct);
	afx_msg void OnSysColorChange();
	afx_msg void OnSize(UINT nType, int cx, int cy);
	afx_msg void OnMove(int x, int y);
	afx_msg void OnHelpFinder();
	afx_msg void OnDropFiles(HDROP hDropInfo);
	afx_msg void OnFontChange();
	afx_msg BOOL OnQueryNewPalette();
	afx_msg void OnPaletteChanged(CWnd* pFocusWnd);
	afx_msg void OnDevModeChange(LPTSTR lpDeviceName);
	afx_msg void OnViewCustomize();
	afx_msg void OnViewFullScreen();
	//}}AFX_MSG
	afx_msg LRESULT OnBarState(WPARAM wParam, LPARAM lParam);
	afx_msg LRESULT OnOpenMsg(WPARAM wParam, LPARAM lParam);
	afx_msg LRESULT OnHelpCustomizeToolbars(WPARAM wp, LPARAM lp);
	afx_msg LRESULT OnStartCustomize(WPARAM wp, LPARAM lp);
	afx_msg LRESULT OnToolbarCreateNew(WPARAM,LPARAM);
	afx_msg LRESULT OnGetDocumentColors(WPARAM,LPARAM);
	afx_msg void OnDummy();
	afx_msg void OnAskQuestion();
	DECLARE_MESSAGE_MAP()
};
// </snippet3>