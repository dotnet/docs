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

class CTooltipDemoView : public CFormView
{
protected: // create from serialization only
	CTooltipDemoView();
	DECLARE_DYNCREATE(CTooltipDemoView)

public:
	enum { IDD = IDD_TOOLTIPDEMO_FORM };
	int		m_nTTType;
	BOOL	m_bBoldLabel;
	BOOL	m_bCustomColors;
	BOOL	m_bDrawDescription;
	BOOL	m_bDrawIcon;
	BOOL	m_bRoundedCorners;
	BOOL	m_bDrawSeparator;
	BOOL	m_bTTInPopupMenus;

// Attributes
public:
	CTooltipDemoDoc* GetDocument();

// Operations
public:
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
	virtual ~CTooltipDemoView();
#ifdef _DEBUG
	virtual void AssertValid() const;
	virtual void Dump(CDumpContext& dc) const;
#endif

protected:
	afx_msg void OnApplyParams();
	afx_msg void OnContextMenu(CWnd*, CPoint point);
	afx_msg void OnFilePrintPreview();

	DECLARE_MESSAGE_MAP()

	void EnableControls ();
};

#ifndef _DEBUG  // debug version in TooltipDemoView.cpp
inline CTooltipDemoDoc* CTooltipDemoView::GetDocument()
   { return (CTooltipDemoDoc*)m_pDocument; }
#endif
