// MFCRibbonAppView.h : interface of the CMFCRibbonAppView class
//


#pragma once


class CMFCRibbonAppView : public CView
{
protected: // create from serialization only
	CMFCRibbonAppView();
	DECLARE_DYNCREATE(CMFCRibbonAppView)

// Attributes
public:
	CMFCRibbonAppDoc* GetDocument() const;

// Operations
public:

// Overrides
public:
	virtual void OnDraw(CDC* pDC);  // overridden to draw this view
	virtual BOOL PreCreateWindow(CREATESTRUCT& cs);
protected:

// Implementation
public:
	virtual ~CMFCRibbonAppView();
#ifdef _DEBUG
	virtual void AssertValid() const;
	virtual void Dump(CDumpContext& dc) const;
#endif

protected:

// Generated message map functions
protected:
	afx_msg void OnFilePrintPreview();
	afx_msg void OnRButtonUp(UINT nFlags, CPoint point);
	afx_msg void OnContextMenu(CWnd* pWnd, CPoint point);
	DECLARE_MESSAGE_MAP()
};

#ifndef _DEBUG  // debug version in MFCRibbonAppView.cpp
inline CMFCRibbonAppDoc* CMFCRibbonAppView::GetDocument() const
   { return reinterpret_cast<CMFCRibbonAppDoc*>(m_pDocument); }
#endif

