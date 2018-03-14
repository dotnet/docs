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
	CComboBox m_wndStyle;
	CButton m_wndRoundedTabs;
	CButton m_wndDockTabColors;
	CButton m_wndOneNoteTabs;
	CButton m_wndOK;
	CButton m_wndCancel;
	BOOL m_bShowAtStartup;
	BOOL m_bOneNoteTabs;
	BOOL m_bDockTabColors;
	BOOL m_bRoundedTabs;
	BOOL m_bCustomTooltips;
	int m_nAppLook;
	int m_nStyle;
	BOOL m_bActiveTabCloseButton;

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
