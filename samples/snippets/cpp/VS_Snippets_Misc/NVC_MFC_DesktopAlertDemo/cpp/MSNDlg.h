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
// CMSNDlg dialog

class CMSNDlg : public CMFCDesktopAlertDialog
{
	DECLARE_DYNCREATE(CMSNDlg)

// Construction
public:
	CMSNDlg();

// Dialog Data
	enum { IDD = IDD_DIALOG2 };
	CMFCLinkCtrl	m_Options;
	CMFCLinkCtrl	m_btnRL;

// Overrides
	protected:
	virtual void DoDataExchange(CDataExchange* pDX);    // DDX/DDV support

	virtual void OnDraw (CDC* pDC);

// Implementation
protected:
	virtual BOOL OnInitDialog();

	afx_msg void OnButton1();
	afx_msg void OnOptions();

	DECLARE_MESSAGE_MAP()

	CMFCToolBarImages	m_imgLogo;
};
