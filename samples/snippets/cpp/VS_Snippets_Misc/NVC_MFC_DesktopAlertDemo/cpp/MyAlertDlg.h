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
// CMyPopupDlg dialog

class CMyPopupDlg : public CMFCDesktopAlertDialog
{
	DECLARE_DYNCREATE(CMyPopupDlg)

// Construction
public:
	CMyPopupDlg();

// Dialog Data
	enum { IDD = IDD_DIALOG1 };
	CStatic	m_wndFrom;

	// <snippet4>
	CMFCDesktopAlertWndButton	m_btnFlag;
	// </snippet4>
	CMFCDesktopAlertWndButton	m_btnDelete;
	CMFCLinkCtrl	m_btnRL;


// Overrides
	protected:
	virtual void DoDataExchange(CDataExchange* pDX);    // DDX/DDV support

// Implementation
protected:
	virtual BOOL OnInitDialog();

	afx_msg void OnDelete();
	afx_msg void OnFlag();
	afx_msg void OnButton1();

	DECLARE_MESSAGE_MAP()

	CFont	m_fontBold;
};
