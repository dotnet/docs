// This is a part of the Microsoft Foundation Classes C++ library.
// Copyright (C) Microsoft Corporation
// All rights reserved.
//
// This source code is only intended as a supplement to the
// Microsoft Foundation Classes Reference and related
// electronic documentation provided with the library.
// See these sources for detailed information regarding the
// Microsoft Foundation Classes product.

#include "stdafx.h"
#include "DesktopAlertDemo.h"
#include "DesktopAlertDemoDlg.h"

#ifdef _DEBUG
#define new DEBUG_NEW
#undef THIS_FILE
static char THIS_FILE[] = __FILE__;
#endif

/////////////////////////////////////////////////////////////////////////////
// CDesktopAlertDemoApp

BEGIN_MESSAGE_MAP(CDesktopAlertDemoApp, CWinAppEx)
	ON_COMMAND(ID_HELP, CWinApp::OnHelp)
END_MESSAGE_MAP()

/////////////////////////////////////////////////////////////////////////////
// CDesktopAlertDemoApp construction

CDesktopAlertDemoApp::CDesktopAlertDemoApp()
{
	// TODO: add construction code here,
	// Place all significant initialization in InitInstance
}

/////////////////////////////////////////////////////////////////////////////
// The one and only CDesktopAlertDemoApp object

CDesktopAlertDemoApp theApp;

/////////////////////////////////////////////////////////////////////////////
// CDesktopAlertDemoApp initialization

BOOL CDesktopAlertDemoApp::InitInstance()
{
	AfxEnableControlContainer();

	// <snippet6>
	CMFCVisualManager::SetDefaultManager (RUNTIME_CLASS (CMFCVisualManagerOffice2003));
	// </snippet6>
	InitContextMenuManager();

	SetRegistryKey(_T("Microsoft\\MFC\\Samples"));
	LoadStdProfileSettings();  // Load standard INI file options (including MRU)
	SetRegistryBase (_T("Settings"));

	// Standard initialization
	// If you are not using these features and wish to reduce the size
	//  of your final executable, you should remove from the following
	//  the specific initialization routines you do not need.

	CDesktopAlertDemoDlg dlg;
	m_pMainWnd = &dlg;
	int nResponse = (int) dlg.DoModal();
	if (nResponse == IDOK)
	{
		// TODO: Place code here to handle when the dialog is
		//  dismissed with OK
	}
	else if (nResponse == IDCANCEL)
	{
		// TODO: Place code here to handle when the dialog is
		//  dismissed with Cancel
	}

	// Since the dialog has been closed, return FALSE so that we exit the
	//  application, rather than start the application's message pump.
	return FALSE;
}
