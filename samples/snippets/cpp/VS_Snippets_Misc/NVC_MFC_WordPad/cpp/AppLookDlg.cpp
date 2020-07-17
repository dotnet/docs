//
// AppLookDlg.cpp : implementation file
//

#include "stdafx.h"
#include "wordpad.h"
#include "AppLookDlg.h"
#include "mainfrm.h"

#ifdef _DEBUG
#define new DEBUG_NEW
#undef THIS_FILE
static char THIS_FILE[] = __FILE__;
#endif

/////////////////////////////////////////////////////////////////////////////
// CAppLookDlg dialog

CAppLookDlg::CAppLookDlg(BOOL bStartup, CWnd* pParent /*=NULL*/)
	: CDialog(CAppLookDlg::IDD, pParent),
	m_bStartup (bStartup)
{
	//{{AFX_DATA_INIT(CAppLookDlg)
	m_nAppLook = 1;
	m_bShowAtStartup = FALSE;
	m_nStyle2007 = 0;
	//}}AFX_DATA_INIT

	m_nAppLook = theApp.GetInt (_T("AppLook"), 1);
	m_bShowAtStartup = theApp.GetInt (_T("ShowAppLookAtStartup"), TRUE);
	m_nStyle2007 = theApp.GetInt (_T("Style2007"), 0);

	theApp.m_bHiColorIcons = m_nAppLook == 1 || m_nAppLook == 2;
}


void CAppLookDlg::DoDataExchange(CDataExchange* pDX)
{
	CDialog::DoDataExchange(pDX);
	//{{AFX_DATA_MAP(CAppLookDlg)
	DDX_Control(pDX, IDC_STYLE2007, m_wndStyle2007);
	DDX_Control(pDX, IDOK, m_wndOK);
	DDX_Control(pDX, IDCANCEL, m_wndCancel);
	DDX_Radio(pDX, IDC_APP_LOOK1, m_nAppLook);
	DDX_Check(pDX, IDC_SHOW_AT_STARTUP, m_bShowAtStartup);
	DDX_CBIndex(pDX, IDC_STYLE2007, m_nStyle2007);
	//}}AFX_DATA_MAP
}


BEGIN_MESSAGE_MAP(CAppLookDlg, CDialog)
	//{{AFX_MSG_MAP(CAppLookDlg)
	ON_BN_CLICKED(IDC_APPLY, OnApply)
	ON_BN_CLICKED(IDC_APP_LOOK1, OnAppLook)
	ON_BN_CLICKED(IDC_APP_LOOK2, OnAppLook)
	ON_BN_CLICKED(IDC_APP_LOOK3, OnAppLook)
	//}}AFX_MSG_MAP
END_MESSAGE_MAP()

/////////////////////////////////////////////////////////////////////////////
// CAppLookDlg message handlers

BOOL CAppLookDlg::OnInitDialog() 
{
	CDialog::OnInitDialog();

	if (m_bStartup)
	{
		SetLook ();

		if (!m_bShowAtStartup)
		{
			EndDialog (IDCANCEL);
			return TRUE;
		}

		CRect rectBtn;

		// Hide "Cancel" button:
		m_wndCancel.GetWindowRect (rectBtn);
		ScreenToClient (rectBtn);

		m_wndOK.MoveWindow (rectBtn);

		m_wndCancel.ShowWindow (SW_HIDE);
	}

	m_wndStyle2007.EnableWindow (m_nAppLook == 2);
	
	return TRUE;  // return TRUE unless you set the focus to a control
	              // EXCEPTION: OCX Property Pages should return FALSE
}

void CAppLookDlg::OnOK() 
{
	CDialog::OnOK();
	SetLook ();
}

void CAppLookDlg::OnApply() 
{
	SetLook ();

	if (!m_bStartup)
	{
		m_wndCancel.SetWindowText (_T("Close"));
	}
}

void CAppLookDlg::SetLook ()
{
	UpdateData ();

	switch (m_nAppLook)
	{
	case 0:
		CMFCVisualManager::SetDefaultManager (RUNTIME_CLASS (CMFCVisualManagerOfficeXP));
		break;

	case 1:
		CMFCVisualManager::SetDefaultManager (RUNTIME_CLASS (CMFCVisualManagerOffice2003));
		break;

	case 2:
		switch (m_nStyle2007)
		{
		case 0:
			CMFCVisualManagerOffice2007::SetStyle (CMFCVisualManagerOffice2007::Office2007_LunaBlue);
			break;

		case 1:
			CMFCVisualManagerOffice2007::SetStyle (CMFCVisualManagerOffice2007::Office2007_ObsidianBlack);
			break;

		case 2:
			CMFCVisualManagerOffice2007::SetStyle (CMFCVisualManagerOffice2007::Office2007_Aqua);
			break;

		case 3:
			CMFCVisualManagerOffice2007::SetStyle (CMFCVisualManagerOffice2007::Office2007_Silver);
			break;
		}

		CMFCVisualManager::SetDefaultManager (RUNTIME_CLASS (CMFCVisualManagerOffice2007));
		break;
	}

	theApp.WriteInt (_T("AppLook"), m_nAppLook);
	theApp.WriteInt (_T("Style2007"), m_nStyle2007);
	theApp.WriteInt (_T("ShowAppLookAtStartup"), m_bShowAtStartup);

	theApp.m_bHiColorIcons = m_nAppLook == 1 || m_nAppLook == 2;
	
	CMainFrame* pMainFrame = DYNAMIC_DOWNCAST(CMainFrame, AfxGetMainWnd ());
	if (pMainFrame != NULL)
	{
		pMainFrame->OnChangeLook ();
	}
}

void CAppLookDlg::OnAppLook() 
{
	UpdateData ();

	m_wndStyle2007.EnableWindow (m_nAppLook == 2);
}
