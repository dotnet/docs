// This is a part of the Microsoft Foundation Classes C++ library.
// Copyright (c) Microsoft Corporation.  All rights reserved.
//
// This source code is only intended as a supplement to the
// Microsoft Foundation Classes Reference and related
// electronic documentation provided with the library.
// See these sources for detailed information regarding the
// Microsoft Foundation Classes product.

#pragma once

/////////////////////////////////////////////////////////////////////////////
// CWatchBar window

class CWatchBar : public CDockablePane
{
// Construction
public:
	CWatchBar();

// Attributes
protected:
	CFont m_Font;

	// <snippet25>
	CMFCListCtrl m_wndWatch;
	// </snippet25>

// Implementation
public:
	virtual ~CWatchBar();

protected:
	afx_msg int OnCreate(LPCREATESTRUCT lpCreateStruct);
	afx_msg void OnSize(UINT nType, int cx, int cy);
	afx_msg void OnPaint();
	afx_msg void OnSetFocus(CWnd* pOldWnd);

	DECLARE_MESSAGE_MAP()
};

