// MFCRibbonApp.h : main header file for the MFCRibbonApp application
//
#pragma once

#ifndef __AFXWIN_H__
	#error "include 'stdafx.h' before including this file for PCH"
#endif

#include "resource.h"       // main symbols


// CMFCRibbonAppApp:
// See MFCRibbonApp.cpp for the implementation of this class
//

class CMFCRibbonAppApp : public CWinAppEx
{
public:
	CMFCRibbonAppApp();


// Overrides
public:
	virtual BOOL InitInstance();

// Implementation
	UINT  m_nAppLook;
	virtual void PreLoadState();
	virtual void LoadCustomState();
	virtual void SaveCustomState();

	afx_msg void OnAppAbout();
	DECLARE_MESSAGE_MAP()
};

extern CMFCRibbonAppApp theApp;
