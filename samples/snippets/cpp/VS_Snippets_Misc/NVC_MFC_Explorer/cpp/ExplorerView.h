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

class CExplorerView : public CView
{
protected: // create from serialization only
	CExplorerView();
	DECLARE_DYNCREATE(CExplorerView)

// Attributes
public:
	CExplorerDoc* GetDocument();
	// <snippet1>
	CMFCShellListCtrl	m_wndList;
	// </snippet1>

// Operations
public:

// Overrides
	public:
	virtual void OnDraw(CDC* pDC);  // overridden to draw this view
	virtual BOOL PreCreateWindow(CREATESTRUCT& cs);
	protected:
	virtual void OnInitialUpdate(); // called first time after construct
	virtual void OnActivateView(BOOL bActivate, CView* pActivateView, CView* pDeactiveView);

// Implementation
public:
	virtual ~CExplorerView();
#ifdef _DEBUG
	virtual void AssertValid() const;
	virtual void Dump(CDumpContext& dc) const;
#endif

protected:
	afx_msg int OnCreate(LPCREATESTRUCT lpCreateStruct);
	afx_msg void OnSize(UINT nType, int cx, int cy);
	afx_msg void OnViewLargeicon();
	afx_msg void OnUpdateViewLargeicon(CCmdUI* pCmdUI);
	afx_msg void OnViewDetails();
	afx_msg void OnUpdateViewDetails(CCmdUI* pCmdUI);
	afx_msg void OnViewList();
	afx_msg void OnUpdateViewList(CCmdUI* pCmdUI);
	afx_msg void OnViewSmallicon();
	afx_msg void OnUpdateViewSmallicon(CCmdUI* pCmdUI);
	afx_msg BOOL OnEraseBkgnd(CDC* pDC);
	afx_msg void OnSetFocus(CWnd* pOldWnd);
	afx_msg void OnFolderUp();
	afx_msg void OnUpdateFolderUp(CCmdUI* pCmdUI);
	afx_msg void OnCopyTo();
	afx_msg void OnMoveTo();
	afx_msg void OnViewRefresh();
	afx_msg LRESULT OnChangeFolder(WPARAM,LPARAM);

	DECLARE_MESSAGE_MAP()
};

#ifndef _DEBUG  // debug version in ExplorerView.cpp
inline CExplorerDoc* CExplorerView::GetDocument()
   { return (CExplorerDoc*)m_pDocument; }
#endif
