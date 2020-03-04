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

// ExplorerBar.h : header file
//

/////////////////////////////////////////////////////////////////////////////
// CExplorerBar window

class CExplorerBar : public CMFCTasksPane
{
// Construction
public:
	CExplorerBar();

// Attributes
protected:
	CTreeCtrl		m_wndFavorites;

// Operations
protected:

// Overrides
	// ClassWizard generated virtual function overrides
	//{{AFX_VIRTUAL(CExplorerBar)
	//}}AFX_VIRTUAL

protected:

// Implementation
public:
	virtual ~CExplorerBar();

	// Generated message map functions
protected:
	//{{AFX_MSG(CExplorerBar)
	afx_msg int OnCreate(LPCREATESTRUCT lpCreateStruct);
	//}}AFX_MSG
	afx_msg void OnSelectTree(NMHDR* pNMHDR, LRESULT* pResult);
	DECLARE_MESSAGE_MAP()
};
