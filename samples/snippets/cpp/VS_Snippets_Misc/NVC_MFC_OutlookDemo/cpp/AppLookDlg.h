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
// CAppLookDlg dialog

class CAppLookDlg : public CDialog
{
// Construction
public:
	CAppLookDlg(BOOL bStartup, CWnd* pParent = NULL);   // standard constructor

// Dialog Data
	enum { IDD = IDD_APP_LOOK };
	CComboBox m_wndStyle2007;
	CButton m_wndOutlookBar2003;
	CButton m_wndOK;
	CButton m_wndCancel;
	int m_nAppLook;
	BOOL m_bShowAtStartup;
	BOOL m_bOutlookBar2003;
	int m_nStyle2007;

// Overrides
protected:
	virtual void DoDataExchange(CDataExchange* pDX);    // DDX/DDV support

// Implementation
protected:
	virtual BOOL OnInitDialog();
	virtual void OnOK();
	afx_msg void OnApply();
	afx_msg void OnAppLook();

	DECLARE_MESSAGE_MAP()

	const BOOL m_bStartup;

	void SetLook();
};
