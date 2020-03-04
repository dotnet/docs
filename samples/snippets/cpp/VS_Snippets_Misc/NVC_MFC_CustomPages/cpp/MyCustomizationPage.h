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
// CMyCustomizationPage dialog

class CMyCustomizationPage : public CPropertyPage
{
	DECLARE_DYNCREATE (CMyCustomizationPage)
// Construction
public:
	CMyCustomizationPage(CWnd* pParent = NULL);   // standard constructor

// Dialog Data
	enum { IDD = IDD_CUST_PAGE_DLG };

// Overrides
	protected:
	virtual void DoDataExchange(CDataExchange* pDX);    // DDX/DDV support

// Implementation
protected:

	DECLARE_MESSAGE_MAP()
};
