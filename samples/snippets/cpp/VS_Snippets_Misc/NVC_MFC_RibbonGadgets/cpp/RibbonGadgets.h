#pragma once

#ifndef __AFXWIN_H__
	#error include 'stdafx.h' before including this file for PCH
#endif

#include "resource.h"       // main symbols

/////////////////////////////////////////////////////////////////////////////
// CRibbonGadgetsApp:
// See RibbonGadgets.cpp for the implementation of this class
//

class CRibbonGadgetsApp : public CWinAppEx
{
public:
	CRibbonGadgetsApp();

	virtual void PreLoadState ();

// Overrides
	public:
	virtual BOOL InitInstance();
	virtual int ExitInstance();

// Implementation
	afx_msg void OnAppAbout();

	DECLARE_MESSAGE_MAP()
};


extern CRibbonGadgetsApp theApp;
