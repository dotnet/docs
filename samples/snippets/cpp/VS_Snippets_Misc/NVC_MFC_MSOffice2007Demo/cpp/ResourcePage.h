// This MFC Samples source code demonstrates using MFC Microsoft Office Fluent User Interface 
// (the "Fluent UI") and is provided only as referential material to supplement the 
// Microsoft Foundation Classes Reference and related electronic documentation 
// included with the MFC C++ library software.  
// License terms to copy, use or distribute the Fluent UI are available separately.  
// To learn more about our Fluent UI licensing program, please visit 
// http://msdn.microsoft.com/officeui.
//
// Copyright (C) Microsoft Corporation
// All rights reserved.

#pragma once

/////////////////////////////////////////////////////////////////////////////
// CResourcePage dialog

class CResourcePage : public CMFCPropertyPage
{
	DECLARE_DYNCREATE(CResourcePage)

// Construction
public:
	CResourcePage();
	~CResourcePage();

// Dialog Data
	//{{AFX_DATA(CResourcePage)
	enum { IDD = IDD_RES_PAGE };
	//}}AFX_DATA

// Overrides
protected:
	virtual void DoDataExchange(CDataExchange* pDX);    // DDX/DDV support

// Implementation
protected:
	//{{AFX_MSG(CResourcePage)
	afx_msg void OnHome();
	afx_msg void OnContact();
	afx_msg void OnProduct();
	afx_msg void OnSupport();
	//}}AFX_MSG

	DECLARE_MESSAGE_MAP()
};

