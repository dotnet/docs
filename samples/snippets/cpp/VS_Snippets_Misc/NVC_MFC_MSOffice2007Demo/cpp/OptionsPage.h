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

#include "DlgBanner.h"

/////////////////////////////////////////////////////////////////////////////
// CDemoOptionsPage dialog

class CDemoOptionsPage : public CMFCPropertyPage
{
	DECLARE_DYNCREATE(CDemoOptionsPage)

// Construction
public:
	CDemoOptionsPage();
	~CDemoOptionsPage();

// Dialog Data
	//{{AFX_DATA(CDemoOptionsPage)
	enum { IDD = IDD_POPULAR_PAGE };
	CDlgBanner m_wndBanner;
	CComboBox m_wndColorScheme;
	int m_nColorScheme;
	int m_nTooltipStyle;
	BOOL m_bShowDevTab;
	BOOL m_bShowFloaty;
	BOOL m_bShowKeyTips;
	//}}AFX_DATA

// Overrides
public:
	virtual void OnOK();
protected:
	virtual void DoDataExchange(CDataExchange* pDX);    // DDX/DDV support

// Implementation
protected:
	//{{AFX_MSG(CDemoOptionsPage)
	afx_msg void OnSize(UINT nType, int cx, int cy);
	//}}AFX_MSG

	DECLARE_MESSAGE_MAP()

	virtual BOOL OnInitDialog();
};

class CDemoOptionsPropSheet : public CMFCPropertySheet
{
public:
	CDemoOptionsPropSheet(CWnd* pWndParent, UINT nSelectedPage = 0);

public:
	virtual BOOL OnInitDialog();

protected:
	virtual void OnDrawPageHeader(CDC* pDC, int nPage, CRect rectHeader);

	CMFCToolBarImages m_Icons;

	// <snippet3>
	CMFCControlRenderer m_Pat[4];
	// </snippet3>
};

