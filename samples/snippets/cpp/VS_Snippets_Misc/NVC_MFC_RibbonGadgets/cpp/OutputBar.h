#pragma once

class COutputToolBar : public CMFCToolBar
{
public:	
	virtual void OnUpdateCmdUI(CFrameWnd* /*pTarget*/, BOOL bDisableIfNoHndler)	
	{		
		CMFCToolBar::OnUpdateCmdUI ((CFrameWnd*) GetOwner (), bDisableIfNoHndler);
	}

	virtual BOOL AllowShowOnList () const		{	return FALSE;	}
};

/////////////////////////////////////////////////////////////////////////////
// COutputBar window

class COutputBar : public CDockablePane
{
// Construction
public:
	COutputBar();

// Attributes
protected:
	CMFCTabCtrl		m_wndTabs;
	COutputToolBar	m_wndToolBar;
	CFont			m_Font;

// Operations
public:
	void ClearTabs ();
	void AddTab (LPCTSTR lpszName, UINT nID);

// Overrides

// Implementation
public:
	virtual ~COutputBar();

protected:
	afx_msg int OnCreate(LPCREATESTRUCT lpCreateStruct);
	afx_msg void OnSize(UINT nType, int cx, int cy);
	afx_msg void OnDestroy();
	afx_msg void OnEditCopy();
	afx_msg void OnFileSaveAs();
	afx_msg void OnFilePrint();

	DECLARE_MESSAGE_MAP()
};

