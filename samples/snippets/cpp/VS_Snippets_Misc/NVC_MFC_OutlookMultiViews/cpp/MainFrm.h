#pragma once

#define CFrameWnd CFrameWndEx
#define NUMVIEWS 4

class CMainFrame : public CFrameWnd
{
	
protected: // create from serialization only
	CMainFrame();
	DECLARE_DYNCREATE(CMainFrame)

// Attributes
public:

// Operations
public:
	void InitViews ();

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
	CMFCMenuBar			m_wndMenuBar;
	CMFCStatusBar	m_wndStatusBar;
	CMFCToolBar		m_wndToolBar;

	// <snippet1>
	CMFCOutlookBar			m_wndShortcutsBar;
	// </snippet1>

	// <snippet3>
	CMFCOutlookBarPane		m_wndShortcutsPane1;
	// </snippet3>

	CMFCCaptionBar			m_wndCaptionBar;
	CBitmap				m_bmpCaption;

protected:
	afx_msg int OnCreate(LPCREATESTRUCT lpCreateStruct);
	afx_msg void OnViewCustomize();
	afx_msg LRESULT OnToolbarReset(WPARAM,LPARAM);
	afx_msg LRESULT OnToolbarContextMenu(WPARAM,LPARAM);
	afx_msg void OnViewOutlookBar();
	afx_msg void OnUpdateViewOutlookBar(CCmdUI* pCmdUI);
	afx_msg void OnOutlookBarShortcut(UINT id);
	afx_msg void OnUpdateOutlookBarShortcut(CCmdUI* pCmdUI);
	afx_msg void OnViewCaptionBar();
	afx_msg void OnUpdateViewCaptionBar(CCmdUI* pCmdUI);
	afx_msg void OnAppLook(UINT id);
	afx_msg void OnUpdateAppLook(CCmdUI* pCmdUI);

	DECLARE_MESSAGE_MAP()

	virtual BOOL OnShowPopupMenu (CMFCPopupMenu* pMenuPopup);

	BOOL CreateShortcutsBar ();

	UINT	m_nAppLook;

    // Array of views attached to single document
    CView * m_pViews[NUMVIEWS];
    // Index to current view
    UINT m_nCurView;    
};

