#pragma once

class COutlookMultiViewsView : public CView
{
protected: // create from serialization only
	COutlookMultiViewsView();
	DECLARE_DYNCREATE(COutlookMultiViewsView)

// Attributes
public:
	COutlookMultiViewsDoc* GetDocument();

// Operations
public:

// Overrides
	public:
	virtual void OnDraw(CDC* pDC);  // overridden to draw this view
	virtual BOOL PreCreateWindow(CREATESTRUCT& cs);
	protected:
	virtual BOOL OnPreparePrinting(CPrintInfo* pInfo);
	virtual void OnBeginPrinting(CDC* pDC, CPrintInfo* pInfo);
	virtual void OnEndPrinting(CDC* pDC, CPrintInfo* pInfo);

// Implementation
public:
	virtual ~COutlookMultiViewsView();
#ifdef _DEBUG
	virtual void AssertValid() const;
	virtual void Dump(CDumpContext& dc) const;
#endif

protected:
	afx_msg void OnContextMenu(CWnd*, CPoint point);
	afx_msg void OnFilePrintPreview();

	DECLARE_MESSAGE_MAP()
};

#ifndef _DEBUG  // debug version in OutlookMultiViewsView.cpp
inline COutlookMultiViewsDoc* COutlookMultiViewsView::GetDocument()
   { return (COutlookMultiViewsDoc*)m_pDocument; }
#endif
