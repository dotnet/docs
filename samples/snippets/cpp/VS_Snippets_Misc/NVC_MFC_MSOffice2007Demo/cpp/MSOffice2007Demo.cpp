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

#include "stdafx.h"
#include "MSOffice2007Demo.h"

#include "MainFrm.h"
#include "MSOffice2007DemoDoc.h"
#include "MSOffice2007DemoView.h"
#include "RibbonTooltipCtrl.h"

#ifdef _DEBUG
#define new DEBUG_NEW
#undef THIS_FILE
static char THIS_FILE[] = __FILE__;
#endif

/////////////////////////////////////////////////////////////////////////////
// CMSOffice2007DemoApp

BEGIN_MESSAGE_MAP(CMSOffice2007DemoApp, CWinAppEx)
	//{{AFX_MSG_MAP(CMSOffice2007DemoApp)
	ON_COMMAND(ID_APP_ABOUT, OnAppAbout)
	// Standard file based document commands
	ON_COMMAND(ID_FILE_NEW, OnFileNew)
	ON_COMMAND(ID_FILE_OPEN, OnFileOpen)
	ON_COMMAND_EX_RANGE(ID_FILE_MRU_FILE1, ID_FILE_MRU_FILE16, OnOpenRecentFile)
	// Standard print setup command
	ON_COMMAND(ID_FILE_PRINT_SETUP, CWinAppEx::OnFilePrintSetup)
	//}}AFX_MSG_MAP
END_MESSAGE_MAP()

/////////////////////////////////////////////////////////////////////////////
// CMSOffice2007DemoApp construction

CMSOffice2007DemoApp::CMSOffice2007DemoApp()
{
	m_bShowFloaty = TRUE;
	m_bShowDevTab = FALSE;
	m_nAppLook = ID_VIEW_APPLOOK_2007_1;
	m_bShowToolTips = TRUE;
	m_bShowKeyTips = TRUE;
	m_bShowToolTipDescr = TRUE;
}

/////////////////////////////////////////////////////////////////////////////
// The one and only CMSOffice2007DemoApp object

CMSOffice2007DemoApp theApp;

/////////////////////////////////////////////////////////////////////////////
// CMSOffice2007DemoApp initialization

BOOL CMSOffice2007DemoApp::InitInstance()
{
	// Initialize OLE libraries
	if (!AfxOleInit())
	{
		AfxMessageBox(IDP_OLE_INIT_FAILED);
		return FALSE;
	}

	AfxEnableControlContainer();

	// Change the registry key under which our settings are stored.
	// TODO: You should modify this string to be something appropriate
	// such as the name of your company or organization.
	SetRegistryKey(_T("Microsoft\\MFC\\Samples"));

	LoadStdProfileSettings();  // Load standard INI file options(including MRU)

	SetRegistryBase(_T("Settings"));

	// Initialize all Managers for usage. They are automatically constructed
	// if not yet present
	InitContextMenuManager();
	InitKeyboardManager();
	InitTooltipManager();

	// Load options:
	m_bShowFloaty = GetInt(_T("ShowFloaty"), TRUE);
	m_bShowDevTab = GetInt(_T("ShowDevTab"), FALSE);
	m_nAppLook = GetInt(_T("ApplicationLook"), ID_VIEW_APPLOOK_2007_1);
	m_bShowToolTips = GetInt(_T("ShowToolTips"), TRUE);
	m_bShowKeyTips = GetInt(_T("ShowKeyTips"), TRUE);
	m_bShowToolTipDescr = GetInt(_T("bShowToolTipDescr"), TRUE);
	m_bIsRTL = GetInt(_T("IsRTL"), FALSE);

	CMFCToolTipInfo params;
	params.m_bVislManagerTheme = TRUE;

	theApp.GetTooltipManager()->SetTooltipParams(0xFFFF, RUNTIME_CLASS(CRibbonTooltipCtrl), &params);

	// Register the application's document templates.  Document templates
	//  serve as the connection between documents, frame windows and views.

	CSingleDocTemplate* pDocTemplate;
	pDocTemplate = new CSingleDocTemplate(IDR_MAINFRAME, RUNTIME_CLASS(CMSOffice2007DemoDoc), RUNTIME_CLASS(CMainFrame),       // main SDI frame window
		RUNTIME_CLASS(CMSOffice2007DemoView));
	pDocTemplate->SetContainerInfo(IDR_CNTR_INPLACE);
	AddDocTemplate(pDocTemplate);

	// Parse command line for standard shell commands, DDE, file open
	CCommandLineInfo cmdInfo;
	ParseCommandLine(cmdInfo);

	// Dispatch commands specified on the command line
	if (!ProcessShellCommand(cmdInfo))
		return FALSE;

	GetContextMenuManager()->AddMenu(_T("Context menu"), IDR_CONTEXT_MENU);

	// The one and only window has been initialized, so show and update it.
	m_pMainWnd->ShowWindow(SW_SHOW);

	CRect rect;
	m_pMainWnd->GetWindowRect(rect);

	m_pMainWnd->SetWindowPos(NULL, -1, -1, rect.Width(), rect.Height(), SWP_NOZORDER | SWP_NOMOVE | SWP_NOACTIVATE);
	m_pMainWnd->UpdateWindow();

	return TRUE;
}

/////////////////////////////////////////////////////////////////////////////
// CAboutDlg dialog used for App About

class CAboutDlg : public CDialog
{
public:
	CAboutDlg();

// Dialog Data
	//{{AFX_DATA(CAboutDlg)
	enum { IDD = IDD_ABOUTBOX };
	//}}AFX_DATA

	// ClassWizard generated virtual function overrides
	//{{AFX_VIRTUAL(CAboutDlg)
	protected:
	virtual void DoDataExchange(CDataExchange* pDX);    // DDX/DDV support
	//}}AFX_VIRTUAL

// Implementation
protected:
	//{{AFX_MSG(CAboutDlg)
		// No message handlers
	//}}AFX_MSG
	DECLARE_MESSAGE_MAP()
};

CAboutDlg::CAboutDlg() : CDialog(CAboutDlg::IDD)
{
	//{{AFX_DATA_INIT(CAboutDlg)
	//}}AFX_DATA_INIT
}

void CAboutDlg::DoDataExchange(CDataExchange* pDX)
{
	CDialog::DoDataExchange(pDX);
	//{{AFX_DATA_MAP(CAboutDlg)
	//}}AFX_DATA_MAP
}

BEGIN_MESSAGE_MAP(CAboutDlg, CDialog)
	//{{AFX_MSG_MAP(CAboutDlg)
		// No message handlers
	//}}AFX_MSG_MAP
END_MESSAGE_MAP()

// App command to run the dialog
void CMSOffice2007DemoApp::OnAppAbout()
{
	CAboutDlg aboutDlg;
	aboutDlg.DoModal();
}

void CMSOffice2007DemoApp::OnFileNew()
{
	if (m_pMainWnd && ((CMainFrame *)m_pMainWnd)->IsPrintPreview())
	{
		m_pMainWnd->SendMessage(WM_COMMAND, AFX_ID_PREVIEW_CLOSE);      // Force Print Preview Close
	}
	CWinAppEx::OnFileNew();
}

void CMSOffice2007DemoApp::OnFileOpen()
{
	if (m_pMainWnd && ((CMainFrame *)m_pMainWnd)->IsPrintPreview())
	{
		m_pMainWnd->SendMessage(WM_COMMAND, AFX_ID_PREVIEW_CLOSE);      // Force Print Preview Close
	}
	CWinAppEx::OnFileOpen();
}

BOOL CMSOffice2007DemoApp::OnOpenRecentFile(UINT nID)
{
	if (m_pMainWnd && ((CMainFrame *)m_pMainWnd)->IsPrintPreview())
	{
		m_pMainWnd->SendMessage(WM_COMMAND, AFX_ID_PREVIEW_CLOSE);      // Force Print Preview Close
	}
	return CWinAppEx::OnOpenRecentFile(nID);
}

/////////////////////////////////////////////////////////////////////////////
// CMSOffice2007DemoApp message handlers

int CMSOffice2007DemoApp::ExitInstance()
{
	// Save options:
	WriteInt(_T("ShowFloaty"), m_bShowFloaty);
	WriteInt(_T("ShowDevTab"), m_bShowDevTab);
	WriteInt(_T("ApplicationLook"), m_nAppLook);
	WriteInt(_T("ShowToolTips"), m_bShowToolTips);
	WriteInt(_T("ShowKeyTips"), m_bShowKeyTips);
	WriteInt(_T("bShowToolTipDescr"), m_bShowToolTipDescr);
	WriteInt(_T("IsRTL"), m_bIsRTL);

	return CWinAppEx::ExitInstance();
}
