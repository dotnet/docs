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
#include "MSNDlg.h"

#ifdef _DEBUG
#define new DEBUG_NEW
#undef THIS_FILE
static char THIS_FILE[] = __FILE__;
#endif

/////////////////////////////////////////////////////////////////////////////
// CMSNDlg dialog

IMPLEMENT_DYNCREATE(CMSNDlg, CMFCDesktopAlertDialog)

CMSNDlg::CMSNDlg()
{
}


void CMSNDlg::DoDataExchange(CDataExchange* pDX)
{
	CMFCDesktopAlertDialog::DoDataExchange(pDX);
	DDX_Control(pDX, IDC_OPTIONS, m_Options);
	DDX_Control(pDX, IDC_BUTTON1, m_btnRL);
}


BEGIN_MESSAGE_MAP(CMSNDlg, CMFCDesktopAlertDialog)
	ON_BN_CLICKED(IDC_BUTTON1, OnButton1)
	ON_BN_CLICKED(IDC_OPTIONS, OnOptions)
END_MESSAGE_MAP()

/////////////////////////////////////////////////////////////////////////////
// CMSNDlg message handlers

void CMSNDlg::OnDraw (CDC* pDC)
{
	CMFCDesktopAlertDialog::OnDraw (pDC);

	CRect rectClient;
	GetClientRect (rectClient);

	CSize sizeLogo = m_imgLogo.GetImageSize ();

	CAfxDrawState ds;
	m_imgLogo.PrepareDrawImage (ds);

	m_imgLogo.Draw (pDC, 
		rectClient.right - sizeLogo.cx - 5,
		rectClient.bottom - sizeLogo.cy - 5,
		0);

	m_imgLogo.EndDrawImage (ds);
}


BOOL CMSNDlg::OnInitDialog() 
{
	CMFCDesktopAlertDialog::OnInitDialog();
	
	m_Options.m_bAlwaysUnderlineText = FALSE;
	m_Options.m_bDefaultClickProcess = FALSE;
	
	m_btnRL.m_bMultilineText = TRUE;
	m_btnRL.m_bAlwaysUnderlineText = FALSE;
	m_btnRL.m_bDefaultClickProcess = TRUE;

	m_imgLogo.Load (IDB_LOGO);
	m_imgLogo.SetTransparentColor (RGB (236, 0, 140));
	m_imgLogo.SetSingleImage ();

	return TRUE;  // return TRUE unless you set the focus to a control
	              // EXCEPTION: OCX Property Pages should return FALSE
}

void CMSNDlg::OnButton1() 
{
	::ShellExecute (NULL, NULL, _T("http://www.microsoft.com"), NULL, NULL, NULL);
}

void CMSNDlg::OnOptions() 
{
	// TODO: Add your control notification handler code here
	
}
