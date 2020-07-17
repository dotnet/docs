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
#include "MDITabsDemo.h"

#include "MainFrm.h"
#include "ChildFrm.h"
#include "MDITabsDemoDoc.h"
#include "MDITabsDemoView.h"

#ifdef _DEBUG
#define new DEBUG_NEW
#undef THIS_FILE
static char THIS_FILE[] = __FILE__;
#endif

CMDITabOptions::CMDITabOptions()
{
	m_nMDITabsType = CMDITabOptions::MDITabsStandard;
	m_bTabsOnTop = TRUE;
	m_bActiveTabCloseButton = FALSE;
	m_nTabsStyle = CMFCTabCtrl::STYLE_3D_ONENOTE;
	m_bTabsAutoColor = FALSE;
	m_bMDITabsIcons = TRUE;
	m_bMDITabsDocMenu = FALSE;
	m_bDragMDITabs = TRUE;
	m_bMDITabsContextMenu = TRUE;
	m_nMDITabsBorderSize = 2;
	m_bDisableMDIChildRedraw = TRUE;
	m_bFlatFrame = TRUE;
	m_bCustomTooltips = FALSE;
}

void CMDITabOptions::Load ()
{
	m_nMDITabsType =  (MDITabsType) theApp.GetInt (_T("ShowMDITabs"), TRUE);
	m_bTabsOnTop = theApp.GetInt (_T("TabsOnTop"), TRUE);
	m_bActiveTabCloseButton = theApp.GetInt (_T("ActiveTabCloseButton"), FALSE);
	m_nTabsStyle = (CMFCTabCtrl::Style) theApp.GetInt (_T("TabsStyle"), CMFCTabCtrl::STYLE_3D_ONENOTE);
	m_bTabsAutoColor = theApp.GetInt (_T("TabsAutoColor"), FALSE);
	m_bMDITabsIcons = theApp.GetInt (_T("MDITabsIcons"), TRUE);
	m_bMDITabsDocMenu = theApp.GetInt (_T("MDITabsDocMenu"), FALSE);
	m_bDragMDITabs = theApp.GetInt (_T("DragMDITabs"), TRUE);
	m_bMDITabsContextMenu = theApp.GetInt (_T("MDITabsContextMenu"), TRUE);
	m_nMDITabsBorderSize = theApp.GetInt (_T("MDITabsBorderSize"), TRUE);
	m_bDisableMDIChildRedraw = theApp.GetInt (_T("DisableMDIChildRedraw"), TRUE);
	m_bFlatFrame = theApp.GetInt (_T("FlatFrame"), TRUE);
	m_bCustomTooltips = theApp.GetInt (_T("CustomTooltips"), FALSE);
}

void CMDITabOptions::Save ()
{
	theApp.WriteInt (_T("ShowMDITabs"), m_nMDITabsType);
	theApp.WriteInt (_T("TabsOnTop"), m_bTabsOnTop);
	theApp.WriteInt (_T("ActiveTabCloseButton"), m_bActiveTabCloseButton);
	theApp.WriteInt (_T("TabsStyle"), m_nTabsStyle);
	theApp.WriteInt (_T("TabsAutoColor"), m_bTabsAutoColor);
	theApp.WriteInt (_T("MDITabsIcons"), m_bMDITabsIcons);
	theApp.WriteInt (_T("MDITabsDocMenu"), m_bMDITabsDocMenu);
	theApp.WriteInt (_T("DragMDITabs"), m_bDragMDITabs);
	theApp.WriteInt (_T("MDITabsContextMenu"), m_bMDITabsContextMenu);
	theApp.WriteInt (_T("MDITabsBorderSize"), m_nMDITabsBorderSize);
	theApp.WriteInt (_T("DisableMDIChildRedraw"), m_bDisableMDIChildRedraw);
	theApp.WriteInt (_T("FlatFrame"), m_bFlatFrame);
	theApp.WriteInt (_T("CustomTooltips"), m_bCustomTooltips);
}

/////////////////////////////////////////////////////////////////////////////
// CMDITabsDemoApp

BEGIN_MESSAGE_MAP(CMDITabsDemoApp, CWinApp)
	ON_COMMAND(ID_APP_ABOUT, OnAppAbout)
	// Standard file based document commands
	ON_COMMAND(ID_FILE_NEW, CWinApp::OnFileNew)
	ON_COMMAND(ID_FILE_OPEN, CWinApp::OnFileOpen)
	// Standard print setup command
	ON_COMMAND(ID_FILE_PRINT_SETUP, CWinApp::OnFilePrintSetup)
END_MESSAGE_MAP()

/////////////////////////////////////////////////////////////////////////////
// CMDITabsDemoApp construction

CMDITabsDemoApp::CMDITabsDemoApp() :
	CWinAppEx (TRUE /* m_bResourceSmartUpdate */)
{
	// TODO: add construction code here,
	// Place all significant initialization in InitInstance
}

/////////////////////////////////////////////////////////////////////////////
// The one and only CMDITabsDemoApp object

CMDITabsDemoApp theApp;

/////////////////////////////////////////////////////////////////////////////
// CMDITabsDemoApp initialization

BOOL CMDITabsDemoApp::InitInstance()
{
	// Initialize OLE libraries
	if (!AfxOleInit())
	{
		AfxMessageBox(IDP_OLE_INIT_FAILED);
		return FALSE;
	}

	AfxEnableControlContainer();

	// Standard initialization
	// If you are not using these features and wish to reduce the size
	//  of your final executable, you should remove from the following
	//  the specific initialization routines you do not need.

	// Change the registry key under which our settings are stored.
	// TODO: You should modify this string to be something appropriate
	// such as the name of your company or organization.
	SetRegistryKey(_T("Microsoft\\MFC\\Samples"));
	LoadStdProfileSettings();  // Load standard INI file options (including MRU)
	SetRegistryBase (_T("Settings"));

	m_Options.Load ();

	// Initialize all Managers for usage. They are automatically constructed
	// if not yet present
	InitContextMenuManager();
	InitKeyboardManager();
	InitTooltipManager ();

	CMFCToolTipInfo params;
	params.m_bVislManagerTheme = TRUE;

	GetTooltipManager ()->SetTooltipParams (
		AFX_TOOLTIP_TYPE_ALL,
		RUNTIME_CLASS (CMFCToolTipCtrl),
		&params);

	// Register the application's document templates.  Document templates
	//  serve as the connection between documents, frame windows and views.

	CMultiDocTemplate* pDocTemplate;
	pDocTemplate = new CMultiDocTemplate(
		IDR_MDITABTYPE,
		RUNTIME_CLASS(CMDITabsDemoDoc),
		RUNTIME_CLASS(CChildFrame), // custom MDI child frame
		RUNTIME_CLASS(CMDITabsDemoView));
	AddDocTemplate(pDocTemplate);

	// create main MDI Frame window
	CMainFrame* pMainFrame = new CMainFrame;
	if (!pMainFrame->LoadFrame(IDR_MAINFRAME))
		return FALSE;
	m_pMainWnd = pMainFrame;

	// Parse command line for standard shell commands, DDE, file open
	CCommandLineInfo cmdInfo;
	ParseCommandLine(cmdInfo);

	// Dispatch commands specified on the command line
	if (!ProcessShellCommand(cmdInfo))
		return FALSE;

	OnFileNew ();
	OnFileNew ();
	OnFileNew ();
	
	// The main window has been initialized, so show and update it.
	pMainFrame->ShowWindow(m_nCmdShow);
	pMainFrame->UpdateWindow();

	return TRUE;
}

/////////////////////////////////////////////////////////////////////////////
// CMDITabsDemoApp message handlers

int CMDITabsDemoApp::ExitInstance() 
{
	m_Options.Save ();
	return CWinAppEx::ExitInstance();
}

void CMDITabsDemoApp::PreLoadState ()
{
	GetContextMenuManager()->AddMenu (_T("My menu"), IDR_CONTEXT_MENU);

	// TODO: add another context menus here
}

void CMDITabsDemoApp::UpdateMDITabs (BOOL bResetMDIChild)
{
	((CMainFrame*) AfxGetMainWnd ())->UpdateMDITabs (bResetMDIChild);
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
void CMDITabsDemoApp::OnAppAbout()
{
	CAboutDlg aboutDlg;
	aboutDlg.DoModal();
}

/////////////////////////////////////////////////////////////////////////////
// CMDITabsDemoApp message handlers
