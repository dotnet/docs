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

class CTabControlView : public CFormView
{
protected: // create from serialization only
	CTabControlView();
	DECLARE_DYNCREATE(CTabControlView)

public:
	enum { IDD = IDD_TABCONTROL_FORM };
	CButton	m_wndTabIcons;
	CListBox	m_wndNotifications;
	CStatic	m_wndTabLoc;
	int		m_nTabStyle;
	int		m_nTabLocation;
	int		m_nColor;
	BOOL	m_bTabIcons;
	BOOL	m_bTabsSwap;

// Attributes
public:
	CTabControlDoc* GetDocument();

protected:
	CMFCTabCtrl	m_wndTab;

	CEdit		m_wnd1;
	CEdit		m_wnd2;
	CEdit		m_wnd3;
	CEdit		m_wnd4;

// Operations
public:

// Overrides
	public:
	virtual BOOL PreCreateWindow(CREATESTRUCT& cs);
	protected:
	virtual void DoDataExchange(CDataExchange* pDX);    // DDX/DDV support
	virtual void OnInitialUpdate(); // called first time after construct
	virtual BOOL OnPreparePrinting(CPrintInfo* pInfo);
	virtual void OnBeginPrinting(CDC* pDC, CPrintInfo* pInfo);
	virtual void OnEndPrinting(CDC* pDC, CPrintInfo* pInfo);
	virtual void OnPrint(CDC* pDC, CPrintInfo* pInfo);

// Implementation
public:
	virtual ~CTabControlView();
#ifdef _DEBUG
	virtual void AssertValid() const;
	virtual void Dump(CDumpContext& dc) const;
#endif

protected:
	void AddNotification (LPCTSTR lpszText);

protected:
	afx_msg void OnSelchangeTabStyle();
	afx_msg void OnLocation();
	afx_msg void OnColor();
	afx_msg void OnTabIcons();
	afx_msg void OnTabSwap();
	afx_msg void OnContextMenu(CWnd*, CPoint point);
	afx_msg void OnFilePrintPreview();
	afx_msg LRESULT OnMoveTab(WPARAM wp, LPARAM lp);
	afx_msg LRESULT OnChangeActiveTab(WPARAM wp, LPARAM lp);
	afx_msg LRESULT OnChangingActiveTab(WPARAM wp, LPARAM lp);

	DECLARE_MESSAGE_MAP()
};

#ifndef _DEBUG  // debug version in TabControlView.cpp
inline CTabControlDoc* CTabControlView::GetDocument()
   { return (CTabControlDoc*)m_pDocument; }
#endif
