#pragma once

#include "OutputBar.h"

class CMainFrame : public CFrameWndEx
{
	
protected: // create from serialization only
	CMainFrame();
	DECLARE_DYNCREATE(CMainFrame)

// Attributes
public:

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

protected:
	void CreateDocumentColors ();

	void Add_MainPanel ();
	void Add_QAT ();
	void Add_Category1 ();
	void Add_Category2 ();
	void Add_Category3 ();
	void Add_Category4 ();
	void Add_Category5 ();
	void Add_Category6 ();

	void OnLink (UINT nID);

	int GetSliderPos (UINT nID);
	void SetSliderPos (int nPos, UINT nID);
	void SetProgressPos (int nPos, UINT nID);

protected:  // control bar embedded members
	CMFCRibbonBar			m_wndRibbonBar;
	CMFCRibbonApplicationButton	m_MainButton;
	CMFCToolBarImages		m_PanelImages;
	CMFCRibbonStatusBar	m_wndStatusBar;
	COutputBar				m_wndOutput;

	// Document colors for demo:
	CList<COLORREF,COLORREF> m_lstMainColors;
	CList<COLORREF,COLORREF> m_lstAdditionalColors;
	CList<COLORREF,COLORREF> m_lstStandardColors;

	BOOL m_bCheckBox1;
	BOOL m_bCheckBox2;
	BOOL m_bCheckBox3;

	int m_nProgressValue1;
	int m_nProgressValue2;

protected:
	afx_msg int OnCreate(LPCREATESTRUCT lpCreateStruct);
	afx_msg void OnRibbonBtn7();
	afx_msg void OnUpdateRibbonBtn7(CCmdUI* pCmdUI);
	afx_msg void OnRibbonBtn8();
	afx_msg void OnUpdateRibbonBtn8(CCmdUI* pCmdUI);
	afx_msg void OnRibbonBtn9();
	afx_msg void OnUpdateRibbonBtn9(CCmdUI* pCmdUI);
	afx_msg void OnRibbonObtn2();
	afx_msg void OnRibbonObtn3();
	afx_msg void OnRibbonObtn4();
	afx_msg void OnRibbonObtn8();
	afx_msg void OnUpdateRibbonObtn8(CCmdUI* pCmdUI);
	afx_msg void OnRibbonObtn10();
	afx_msg void OnUpdateRibbonObtn10(CCmdUI* pCmdUI);
	afx_msg void OnTimer(UINT_PTR nIDEvent);
	afx_msg void OnAppLook(UINT id);
	afx_msg void OnUpdateAppLook(CCmdUI* pCmdUI);
	afx_msg LRESULT OnRibbonCustomize (WPARAM wp, LPARAM lp);
	afx_msg LRESULT OnChangeRibbonCategory(WPARAM,LPARAM);
	afx_msg void OnToolsOptions();
	afx_msg void OnDummy(UINT id);
	afx_msg void OnFilePrint();
	afx_msg void OnFilePrintPreview();
	afx_msg void OnUpdateFilePrintPreview(CCmdUI* pCmdUI);
	afx_msg void OnSysColorChange();

	DECLARE_MESSAGE_MAP()

	BOOL CreateRibbonBar ();
	void ShowOptions (int nPage);

	UINT	m_nAppLook;
};


