// This is a part of the Microsoft Foundation Classes C++ library.
// Copyright (c) Microsoft Corporation.  All rights reserved.
//
// This source code is only intended as a supplement to the
// Microsoft Foundation Classes Reference and related
// electronic documentation provided with the library.
// See these sources for detailed information regarding the
// Microsoft Foundation Classes product.

#pragma once

#ifndef __AFXWIN_H__
#error include 'stdafx.h' before including this file for PCH
#endif

#include "resource.h"       // main symbols

/////////////////////////////////////////////////////////////////////////////
// CVisualStudioDemoApp:
// See VisualStudioDemo.cpp for the implementation of this class
//

class CVisualStudioDemoApp : public CWinAppEx
{
public:
	CVisualStudioDemoApp();
	virtual ~CVisualStudioDemoApp();

	BOOL m_bHiColorIcons;

	virtual void PreLoadState();
	virtual void LoadCustomState();
	virtual void SaveCustomState();

	CMultiDocTemplate* m_pDocTemplateCpp;
	CMultiDocTemplate* m_pStartDocTemplate;

	// Overrides
public:
	virtual BOOL InitInstance();
	virtual int ExitInstance();
	virtual BOOL SaveAllModified();

	// Implementation
	afx_msg void OnAppAbout();
	afx_msg void OnHelpShowStart();
	afx_msg void OnViewAppLook();

	DECLARE_MESSAGE_MAP()
};

extern CVisualStudioDemoApp theApp;
