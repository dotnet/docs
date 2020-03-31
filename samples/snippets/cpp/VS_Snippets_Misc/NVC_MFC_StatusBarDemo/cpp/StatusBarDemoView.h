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

#include "MainFrm.h"

class CStatusBarDemoView : public CFormView
{
protected: // create from serialization only
	CStatusBarDemoView();
	DECLARE_DYNCREATE(CStatusBarDemoView)

public:
	enum { IDD = IDD_STATUSBARDEMO_FORM };

	// <snippet10>
	CMFCColorButton	m_wndTextColor;
	// </snippet10>

	CMFCColorButton	m_wndBackColor;
	CButton			m_wndStartAnimation;
	CButton			m_wndStartProgress;
	int				m_nIcon;

// Attributes
public:
	CStatusBarDemoDoc* GetDocument();

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
	virtual ~CStatusBarDemoView();
#ifdef _DEBUG
	virtual void AssertValid() const;
	virtual void Dump(CDumpContext& dc) const;
#endif

protected:
	afx_msg void OnStartProgress();
	afx_msg void OnStartAnimation();
	afx_msg void OnIcon();
	afx_msg void OnBackColor();
	afx_msg void OnTextColor();
	afx_msg void OnTimer(UINT_PTR nIDEvent);
	afx_msg void OnContextMenu(CWnd*, CPoint point);
	afx_msg void OnFilePrintPreview();
	afx_msg void OnIndicatorLabel();

	DECLARE_MESSAGE_MAP()

	// <Snippet8>
	// in StatusBarDemoView.h
	CMFCStatusBar& GetStatusBar () const
	{
		return ((CMainFrame*) AfxGetMainWnd ())->GetStatusBar ();
	}
	// </Snippet8>

	// <Snippet9>
	int			m_nProgressCurr;
	BOOL		m_bInProgress;

	CImageList	m_imlStatusAnimation;
	BOOL		m_bInAnimation;

	CBitmap		m_bmpIcon1;
	CBitmap		m_bmpIcon2;
	// </Snippet9>
};

#ifndef _DEBUG  // debug version in StatusBarDemoView.cpp
inline CStatusBarDemoDoc* CStatusBarDemoView::GetDocument()
   { return (CStatusBarDemoDoc*)m_pDocument; }
#endif
