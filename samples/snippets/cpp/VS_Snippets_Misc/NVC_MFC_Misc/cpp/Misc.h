
// Misc.h : main header file for the Misc application
//
#pragma once

#ifndef __AFXWIN_H__
	#error "include 'stdafx.h' before including this file for PCH"
#endif

#include "resource.h"       // main symbols


// CMiscApp:
// See Misc.cpp for the implementation of this class
//

class CMiscApp : public CWinAppEx
{
public:
	CMiscApp();


// Overrides
public:
	virtual BOOL InitInstance();

// Implementation
	UINT  m_nAppLook;
	BOOL  m_bHiColorIcons;

	virtual void PreLoadState();
	virtual void LoadCustomState();
	virtual void SaveCustomState();

	afx_msg void OnAppAbout();
	DECLARE_MESSAGE_MAP()
};

extern CMiscApp theApp;


class CMyApp 
{
   // <snippet1>
   void CMyApp::ProcessCommand()
   {
      // Temporarily disable menu animation. 
      CMFCDisableMenuAnimation disableMenuAnimation;

      // TODO: Process the command here.

      // When the CMFCDisableMenuAnimation object leaves scope,
      // the destructor will restore the previous animation type.
   }
   // </snippet1>
};