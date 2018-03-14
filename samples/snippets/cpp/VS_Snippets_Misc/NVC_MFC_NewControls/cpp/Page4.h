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
// CPage4 dialog

class CPage4 : public CMFCPropertyPage
{
	DECLARE_DYNCREATE(CPage4)

// Construction
public:
	CPage4();
	~CPage4();

// Dialog Data
	enum { IDD = IDD_PAGE4 };

	// <snippet11>
	CMFCMaskedEdit m_wndMaskEdit1;
	CMFCMaskedEdit m_wndMaskEdit2;
	CMFCMaskedEdit m_wndMaskEdit3;
	CMFCMaskedEdit m_wndMaskEdit4;
	CMFCMaskedEdit m_wndMaskEdit5;

	CString m_strValue1;
	CString m_strValue2;
	CString m_strValue3;
	CString m_strValue4;
	CString m_strValue5;
	// </snippet11>

// Overrides
protected:
	virtual void DoDataExchange(CDataExchange* pDX);    // DDX/DDV support

// Implementation
protected:
	virtual BOOL OnInitDialog();
	afx_msg void OnButtonGet();

	DECLARE_MESSAGE_MAP()
};

