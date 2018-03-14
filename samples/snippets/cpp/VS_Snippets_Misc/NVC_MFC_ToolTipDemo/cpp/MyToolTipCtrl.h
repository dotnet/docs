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

/////////////////////////////////////////////////////////////////////////////
// CMyToolTipCtrl window

class CMyToolTipCtrl : public CMFCToolTipCtrl
{
	DECLARE_DYNCREATE(CMyToolTipCtrl)

// Construction
public:
	CMyToolTipCtrl();

// Attributes
public:

// Operations
public:

// Overrides
	virtual void SetDescription (const CString strDesrciption);
	virtual CSize GetIconSize ();
	virtual void OnFillBackground (CDC* pDC, CRect rect, COLORREF& clrText, COLORREF& clrLine);

	virtual BOOL OnDrawIcon (CDC* pDC, CRect rectImage);
	virtual void OnDrawSeparator (CDC* pDC, int x1, int x2, int y);

// Implementation
public:
	virtual ~CMyToolTipCtrl();

protected:
	afx_msg int OnCreate(LPCREATESTRUCT lpCreateStruct);

	DECLARE_MESSAGE_MAP()

	HICON	m_hIcon;
};
