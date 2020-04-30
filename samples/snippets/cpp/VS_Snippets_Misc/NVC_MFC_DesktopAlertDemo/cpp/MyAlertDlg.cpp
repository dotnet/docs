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
#include "MyAlertDlg.h"

#ifdef _DEBUG
#define new DEBUG_NEW
#undef THIS_FILE
static char THIS_FILE[] = __FILE__;
#endif

/////////////////////////////////////////////////////////////////////////////
// CMyPopupDlg dialog

IMPLEMENT_DYNCREATE(CMyPopupDlg, CMFCDesktopAlertDialog)

CMyPopupDlg::CMyPopupDlg()
{
}


void CMyPopupDlg::DoDataExchange(CDataExchange* pDX)
{
	CMFCDesktopAlertDialog::DoDataExchange(pDX);
	DDX_Control(pDX, IDC_FROM, m_wndFrom);
	DDX_Control(pDX, IDC_FLAG, m_btnFlag);
	DDX_Control(pDX, IDC_DELETE, m_btnDelete);
	DDX_Control(pDX, IDC_BUTTON1, m_btnRL);
}


BEGIN_MESSAGE_MAP(CMyPopupDlg, CMFCDesktopAlertDialog)
	ON_BN_CLICKED(IDC_DELETE, OnDelete)
	ON_BN_CLICKED(IDC_FLAG, OnFlag)
	ON_BN_CLICKED(IDC_BUTTON1, OnButton1)
END_MESSAGE_MAP()

/////////////////////////////////////////////////////////////////////////////
// CMyPopupDlg message handlers

BOOL CMyPopupDlg::OnInitDialog() 
{
	CMFCDesktopAlertDialog::OnInitDialog();
	
	LOGFONT lf;
	m_wndFrom.GetFont ()->GetLogFont (&lf);

	lf.lfWeight = FW_BOLD;
	m_fontBold.CreateFontIndirect (&lf);
	
	m_wndFrom.SetFont (&m_fontBold);

	// <snippet5>
	m_btnFlag.SetImage (IDB_FLAG);
	// </snippet5>

	m_btnDelete.SetImage (IDB_DELETE);

	m_btnRL.m_bMultilineText = TRUE;
	m_btnRL.m_bAlwaysUnderlineText = FALSE;
	m_btnRL.m_bDefaultClickProcess = TRUE;
	
	return TRUE;  // return TRUE unless you set the focus to a control
	              // EXCEPTION: OCX Property Pages should return FALSE
}

void CMyPopupDlg::OnDelete() 
{
	GetParent ()->PostMessage (WM_CLOSE);
}

void CMyPopupDlg::OnFlag() 
{
	GetParent ()->PostMessage (WM_CLOSE);
}

void CMyPopupDlg::OnButton1() 
{
	GetParent ()->PostMessage (WM_CLOSE);
}
