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

class CIEDemoView : public CHtmlView
{
protected: // create from serialization only
	CIEDemoView();
	DECLARE_DYNCREATE(CIEDemoView)

// Attributes
public:
	CIEDemoDoc* GetDocument();

// Operations
public:

// Overrides
	// ClassWizard generated virtual function overrides
	//{{AFX_VIRTUAL(CIEDemoView)
	public:
	virtual void OnDraw(CDC* pDC);  // overridden to draw this view
	virtual BOOL PreCreateWindow(CREATESTRUCT& cs);
	virtual void OnDocumentComplete(LPCTSTR lpszURL);
	virtual void OnTitleChange(LPCTSTR lpszText);
	virtual void OnBeforeNavigate2(LPCTSTR lpszURL, DWORD nFlags, LPCTSTR lpszTargetFrameName, CByteArray& baPostedData, LPCTSTR lpszHeaders, BOOL* pbCancel);
	virtual void OnInitialUpdate();
	virtual void OnProgressChange(long nProgress, long nProgressMax);
	protected:
	virtual BOOL OnPreparePrinting(CPrintInfo* pInfo);
	virtual void OnBeginPrinting(CDC* pDC, CPrintInfo* pInfo);
	virtual void OnEndPrinting(CDC* pDC, CPrintInfo* pInfo);
	//}}AFX_VIRTUAL

// Implementation
public:
	virtual ~CIEDemoView();
#ifdef _DEBUG
	virtual void AssertValid() const;
	virtual void Dump(CDumpContext& dc) const;
#endif

protected:

// Generated message map functions
protected:
	//{{AFX_MSG(CIEDemoView)
	afx_msg void OnGoBack();
	afx_msg void OnGoForward();
	afx_msg void OnGoSearchTheWeb();
	afx_msg void OnGoStartPage();
	afx_msg void OnViewStop();
	afx_msg void OnViewRefresh();
	afx_msg void OnViewFontsLargest();
	afx_msg void OnViewFontsLarge();
	afx_msg void OnViewFontsMedium();
	afx_msg void OnViewFontsSmall();
	afx_msg void OnViewFontsSmallest();
	afx_msg void OnFileOpen();
	afx_msg void OnUpdateGoForward(CCmdUI* pCmdUI);
	afx_msg void OnUpdateGoBack(CCmdUI* pCmdUI);
	afx_msg void OnDestroy();
	//}}AFX_MSG
	DECLARE_MESSAGE_MAP()
};

#ifndef _DEBUG  // debug version in IEDemoView.cpp
inline CIEDemoDoc* CIEDemoView::GetDocument()
   { return (CIEDemoDoc*)m_pDocument; }
#endif
