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
// CPage6 dialog

class CPage6 : public CMFCPropertyPage
{
	DECLARE_DYNCREATE(CPage6)

// Construction
public:
	CPage6();
	~CPage6();

// Dialog Data
	enum { IDD = IDD_PAGE6 };
	CMFCShellListCtrl m_wndShellList;
	CMFCShellTreeCtrl m_wbdShellTree;
	CString m_strSelectedFolder;

// Overrides
protected:
	virtual void DoDataExchange(CDataExchange* pDX);    // DDX/DDV support

// Implementation
protected:
	afx_msg void OnSelectFolder();
	virtual BOOL OnInitDialog();

	DECLARE_MESSAGE_MAP()
};

