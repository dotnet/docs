// This is a part of the Microsoft Foundation Classes C++ library.
// Copyright (c) Microsoft Corporation.  All rights reserved.
//
// This source code is only intended as a supplement to the
// Microsoft Foundation Classes Reference and related
// electronic documentation provided with the library.
// See these sources for detailed information regarding the
// Microsoft Foundation Classes product.

#pragma once

class COutlookDemoView : public CListView
{
protected: // create from serialization only
	COutlookDemoView();
	DECLARE_DYNCREATE(COutlookDemoView)

// Attributes
public:
	COutlookDemoDoc* GetDocument();

protected:
	CImageList m_ImagesHeader;
	CImageList m_ImagesList;

// Overrides
public:
	virtual void OnDraw(CDC* pDC);  // overridden to draw this view
	virtual BOOL PreCreateWindow(CREATESTRUCT& cs);

protected:
	virtual void OnInitialUpdate(); // called first time after construct
	virtual BOOL OnPreparePrinting(CPrintInfo* pInfo);
	virtual void OnBeginPrinting(CDC* pDC, CPrintInfo* pInfo);
	virtual void OnEndPrinting(CDC* pDC, CPrintInfo* pInfo);

// Implementation
public:
	virtual ~COutlookDemoView();
#ifdef _DEBUG
	virtual void AssertValid() const;
	virtual void Dump(CDumpContext& dc) const;
#endif

protected:
	afx_msg void OnViewPreviewPane();
	afx_msg void OnUpdateViewPreviewPane(CCmdUI* pCmdUI);
	afx_msg int OnCreate(LPCREATESTRUCT lpCreateStruct);
	afx_msg void OnContextMenu(CWnd*, CPoint point);
	afx_msg void OnFilePrintPreview();

	DECLARE_MESSAGE_MAP()
};

#ifndef _DEBUG  // debug version in OutlookDemoView.cpp
inline COutlookDemoDoc* COutlookDemoView::GetDocument() { return(COutlookDemoDoc*)m_pDocument; }
#endif
