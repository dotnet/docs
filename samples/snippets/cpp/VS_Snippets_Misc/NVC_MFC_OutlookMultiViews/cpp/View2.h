#pragma once

class CView2 : public CView
{
public:
	CView2();           // protected constructor used by dynamic creation
	virtual ~CView2();

	DECLARE_DYNCREATE(CView2)

// Attributes
public:

// Operations
public:

// Overrides
	protected:
	virtual void OnDraw(CDC* pDC);      // overridden to draw this view
	virtual BOOL OnPreparePrinting(CPrintInfo* pInfo);
	virtual void OnBeginPrinting(CDC* pDC, CPrintInfo* pInfo);
	virtual void OnEndPrinting(CDC* pDC, CPrintInfo* pInfo);

// Implementation
protected:
#ifdef _DEBUG
	virtual void AssertValid() const;
	virtual void Dump(CDumpContext& dc) const;
#endif

protected:
	afx_msg void OnContextMenu(CWnd*, CPoint point);
	afx_msg void OnFilePrintPreview();

	DECLARE_MESSAGE_MAP()
};
