#pragma once

#ifndef __AFXWIN_H__
	#error include 'stdafx.h' before including this file for PCH
#endif

#include "resource.h"       // main symbols

/////////////////////////////////////////////////////////////////////////////
// COutlookMultiViewsApp:
// See OutlookMultiViews.cpp for the implementation of this class
//

class COutlookMultiViewsApp : public CWinAppEx
{
public:
	COutlookMultiViewsApp();

	// Override from CWinAppEx
	virtual void PreLoadState ();


// Overrides
	public:
	virtual BOOL InitInstance();
	virtual int ExitInstance();

// Implementation
	afx_msg void OnAppAbout();

	DECLARE_MESSAGE_MAP()
};


extern COutlookMultiViewsApp theApp;

