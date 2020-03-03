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
// COutlookDemoApp:
// See OutlookDemo.cpp for the implementation of this class
//

class COutlookDemoApp : public CWinAppEx
{
public:
	COutlookDemoApp();

	virtual void PreLoadState();

	enum OUTLOOK_FRAME
	{
		MainFrame, MailFrame
	};

	void SetActiveFrame(OUTLOOK_FRAME frame);

// Overrides
public:
	virtual BOOL InitInstance();
	virtual int ExitInstance();

// Implementation
	afx_msg void OnAppAbout();
	afx_msg void OnViewAppLook();

	DECLARE_MESSAGE_MAP()
};

extern COutlookDemoApp theApp;
