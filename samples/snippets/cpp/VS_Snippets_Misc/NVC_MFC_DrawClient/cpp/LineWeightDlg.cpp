// This is a part of the Microsoft Foundation Classes C++ library.
// Copyright (c) Microsoft Corporation.  All rights reserved.
//
// This source code is only intended as a supplement to the
// Microsoft Foundation Classes Reference and related
// electronic documentation provided with the library.
// See these sources for detailed information regarding the
// Microsoft Foundation Classes product.

#include "stdafx.h"
#include "DrawClient.h"
#include "LineWeightDlg.h"

#ifdef _DEBUG
#define new DEBUG_NEW
#undef THIS_FILE
static char THIS_FILE[] = __FILE__;
#endif

CLineWeightDlg::CLineWeightDlg(CWnd* pParent /*=NULL*/) :
	CDialog(CLineWeightDlg::IDD, pParent)
{
	//{{AFX_DATA_INIT(CLineWeightDlg)
	m_penSize = 0;
	//}}AFX_DATA_INIT
}

void CLineWeightDlg::DoDataExchange(CDataExchange* pDX)
{
	CDialog::DoDataExchange(pDX);
	//{{AFX_DATA_MAP(CLineWeightDlg)
	DDX_Control(pDX, IDC_SPIN1, m_SpinCtrl);
	DDX_Text(pDX, IDC_WEIGHT, m_penSize);
	DDV_MinMaxUInt(pDX, m_penSize, 0, 100);
	//}}AFX_DATA_MAP
}

BOOL CLineWeightDlg::OnInitDialog()
{
	CDialog::OnInitDialog();

	m_SpinCtrl.SetRange(0, 100);
	m_SpinCtrl.SetBase(10);
	m_SpinCtrl.SetPos(max(m_penSize, 0));
	return TRUE;
}

BEGIN_MESSAGE_MAP(CLineWeightDlg, CDialog)
	//{{AFX_MSG_MAP(CLineWeightDlg)
	//}}AFX_MSG_MAP
END_MESSAGE_MAP()
