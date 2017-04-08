// This is a part of the Microsoft Foundation Classes C++ library.
// Copyright (c) Microsoft Corporation.  All rights reserved.
//
// This source code is only intended as a supplement to the
// Microsoft Foundation Classes Reference and related
// electronic documentation provided with the library.
// See these sources for detailed information regarding the
// Microsoft Foundation Classes product.

#pragma once

class CLineWeightDlg : public CDialog
{
// Construction
public:
	CLineWeightDlg(CWnd* pParent = NULL);   // standard constructor

// Dialog Data
	//{{AFX_DATA(CLineWeightDlg)
	enum { IDD = IDD_LINEWEIGHT };
	CSpinButtonCtrl m_SpinCtrl;
	UINT    m_penSize;
	//}}AFX_DATA

// Overrides
protected:
	virtual void DoDataExchange(CDataExchange* pDX);    // DDX/DDV support
	virtual BOOL OnInitDialog();

// Implementation
protected:
	//{{AFX_MSG(CLineWeightDlg)
	//}}AFX_MSG

	DECLARE_MESSAGE_MAP()
};
