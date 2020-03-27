#pragma once

class CRibbonGadgetsView : public CView
{
protected: // create from serialization only
	CRibbonGadgetsView();
	DECLARE_DYNCREATE(CRibbonGadgetsView)

// Attributes
public:
	CRibbonGadgetsDoc* GetDocument();

// Operations
public:

// Overrides
	public:
	virtual BOOL PreCreateWindow(CREATESTRUCT& cs);
	protected:
	virtual BOOL OnPreparePrinting(CPrintInfo* pInfo);
	virtual HMENU GetContextMenu(WORD, LPOLEOBJECT, CHARRANGE* );
	virtual void OnDraw(CDC* pDC);

// Implementation
public:
	virtual ~CRibbonGadgetsView();

#ifdef _DEBUG
	virtual void AssertValid() const;
	virtual void Dump(CDumpContext& dc) const;
#endif

protected:
	afx_msg void OnFilePrintPreview();
	afx_msg void OnDestroy();
	afx_msg int OnCreate(LPCREATESTRUCT lpCreateStruct);
	afx_msg void OnContextMenu(CWnd* pWnd, CPoint point);

	DECLARE_MESSAGE_MAP()
};

#ifndef _DEBUG  // debug version in RibbonGadgetsView.cpp
inline CRibbonGadgetsDoc* CRibbonGadgetsView::GetDocument()
   { return (CRibbonGadgetsDoc*)m_pDocument; }
#endif
