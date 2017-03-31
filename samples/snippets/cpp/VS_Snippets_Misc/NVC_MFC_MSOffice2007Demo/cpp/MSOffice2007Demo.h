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

#ifndef __AFXWIN_H__
#error include 'stdafx.h' before including this file for PCH
#endif

#include "resource.h"       // main symbols

/////////////////////////////////////////////////////////////////////////////
// CMSOffice2007DemoApp:
// See MSOffice2007Demo.cpp for the implementation of this class
//

class CMSOffice2007DemoApp : public CWinAppEx
{
public:
	CMSOffice2007DemoApp();

	BOOL m_bShowFloaty;
	UINT m_nAppLook;
	BOOL m_bShowDevTab;
	BOOL m_bShowToolTips;
	BOOL m_bShowToolTipDescr;
	BOOL m_bShowKeyTips;
	BOOL m_bIsRTL;

// Overrides
public:
	virtual BOOL InitInstance();
	virtual int ExitInstance();

// Implementation
	//{{AFX_MSG(CMSOffice2007DemoApp)
	afx_msg void OnAppAbout();
	afx_msg void OnFileNew();
	afx_msg void OnFileOpen();
	afx_msg BOOL OnOpenRecentFile(UINT nID);
	//}}AFX_MSG
	DECLARE_MESSAGE_MAP()
};

extern CMSOffice2007DemoApp theApp;
