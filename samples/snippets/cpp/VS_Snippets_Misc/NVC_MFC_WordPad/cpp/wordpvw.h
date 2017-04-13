//
// wordpvw.h : interface of the CWordPadView class
//
//
// This is a part of the Microsoft Foundation Classes C++ library.
// Copyright (C) 1992-1998 Microsoft Corporation
// All rights reserved.
//
// This source code is only intended as a supplement to the
// Microsoft Foundation Classes Reference and related
// electronic documentation provided with the library.
// See these sources for detailed information regarding the
// Microsoft Foundation Classes product.

class CWordPadView : public CRichEditView
{
protected: // create from serialization only
	CWordPadView();
	DECLARE_DYNCREATE(CWordPadView)

// Attributes
public:
	UINT_PTR m_uTimerID;
	BOOL m_bDelayUpdateItems;
	BOOL m_bInPrint;
	CParaFormat m_defParaFormat;
	CCharFormat m_defCharFormat;
	CCharFormat m_defTextCharFormat;

	CWordPadDoc* GetDocument();
	BOOL IsFormatText();

	virtual HMENU GetContextMenu(WORD seltype, LPOLEOBJECT lpoleobj,
		CHARRANGE* lpchrg);

// Operations
public:
	BOOL PasteNative(LPDATAOBJECT lpdataobj);
	void SetDefaultFont(BOOL bText);
	void SetUpdateTimer();
	void GetDefaultFont(CCharFormat& cf, UINT nFontNameID);
	void DrawMargins(CDC* pDC);
	BOOL SelectPalette();
	BOOL ShowContextMenu (CPoint pt);
	void SetTextColor (COLORREF color);

	void GetDocumentColors (CList<COLORREF,COLORREF>& lstColors);

// Overrides
	// ClassWizard generated virtual function overrides
	//{{AFX_VIRTUAL(CWordPadView)
	protected:
	virtual void CalcWindowRect(LPRECT lpClientRect, UINT nAdjustType = adjustBorder);
	virtual BOOL PreCreateWindow(CREATESTRUCT& cs);
	virtual void OnPrint(CDC* pDC, CPrintInfo* pInfo);
	//}}AFX_VIRTUAL
	BOOL OnPreparePrinting(CPrintInfo* pInfo);
	virtual HRESULT GetClipboardData(CHARRANGE* lpchrg, DWORD reco,
		LPDATAOBJECT lpRichDataObj, LPDATAOBJECT* lplpdataobj);
	virtual HRESULT QueryAcceptData(LPDATAOBJECT, CLIPFORMAT*, DWORD,
		BOOL, HGLOBAL);
public:
	virtual void WrapChanged();

// Implementation
public:
#ifdef _DEBUG
	virtual void AssertValid() const;
	virtual void Dump(CDumpContext& dc) const;
#endif

protected:
	BOOL	m_bOnBar;
	UINT	m_nBorderType;

	// OLE Container support

	virtual void DeleteContents();
	virtual void OnTextNotFound(LPCTSTR);

// Generated message map functions
protected:
	afx_msg void OnCancelEditSrvr();
	//{{AFX_MSG(CWordPadView)
	afx_msg int OnCreate(LPCREATESTRUCT lpCreateStruct);
	afx_msg void OnPageSetup();
	afx_msg void OnInsertDateTime();
	afx_msg void OnFormatParagraph();
	afx_msg void OnFormatTabs();
	afx_msg void OnTimer(UINT_PTR nIDEvent);
	afx_msg void OnDestroy();
	afx_msg void OnMeasureItem(int nIDCtl, LPMEASUREITEMSTRUCT lpMeasureItemStruct);
	afx_msg void OnPenBackspace();
	afx_msg void OnPenNewline();
	afx_msg void OnPenPeriod();
	afx_msg void OnPenSpace();
	afx_msg void OnKeyDown(UINT nChar, UINT nRepCnt, UINT nFlags);
	afx_msg void OnFilePrint();
	afx_msg void OnPenLens();
	afx_msg void OnPenTab();
	afx_msg void OnPaletteChanged(CWnd* pFocusWnd);
	afx_msg BOOL OnQueryNewPalette();
	afx_msg void OnSettingChange(UINT uFlags, LPCTSTR lpszSection);
	afx_msg void OnSize(UINT nType, int cx, int cy);
	afx_msg void OnContextMenu(CWnd* pWnd, CPoint point);
	afx_msg void OnRButtonUp(UINT nFlags, CPoint point);
	afx_msg void OnCharColor();
	afx_msg void OnFilePrintPreview();
	afx_msg void OnFontname();
	afx_msg void OnFontsize();
	//}}AFX_MSG
	afx_msg void OnEditChange();
	afx_msg int OnMouseActivate(CWnd* pWnd, UINT nHitTest, UINT message);
	afx_msg LONG OnPrinterChangedMsg(UINT, LONG);
	afx_msg void OnBarSetFocus(UINT, NMHDR*, LRESULT*);
	afx_msg void OnBarKillFocus(UINT, NMHDR*, LRESULT*);
	afx_msg void OnBarReturn(UINT, NMHDR*, LRESULT* );
	afx_msg void OnBorderType (UINT id);
	afx_msg void OnUpdateBorderType (CCmdUI* pCmdUI);
	DECLARE_MESSAGE_MAP()
};

#ifndef _DEBUG  // debug version in wordpvw.cpp
inline CWordPadDoc* CWordPadView::GetDocument()
   { return (CWordPadDoc*)m_pDocument; }
#endif

/////////////////////////////////////////////////////////////////////////////
