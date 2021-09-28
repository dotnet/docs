// This is a part of the Microsoft Foundation Classes C++ library.
// Copyright (c) Microsoft Corporation.  All rights reserved.
//
// This source code is only intended as a supplement to the
// Microsoft Foundation Classes Reference and related
// electronic documentation provided with the library.
// See these sources for detailed information regarding the
// Microsoft Foundation Classes product.

#include "stdafx.h"
#include "NewControls.h"
#include "Page6.h"

#ifdef _DEBUG
#define new DEBUG_NEW
#undef THIS_FILE
static char THIS_FILE[] = __FILE__;
#endif

/////////////////////////////////////////////////////////////////////////////
// CPage6 property page

IMPLEMENT_DYNCREATE(CPage6, CMFCPropertyPage)

CPage6::CPage6() : CMFCPropertyPage(CPage6::IDD)
{
	m_strSelectedFolder = _T("c:\\");
}

CPage6::~CPage6()
{
}

void CPage6::DoDataExchange(CDataExchange* pDX)
{
	CMFCPropertyPage::DoDataExchange(pDX);
	DDX_Control(pDX, IDC_LIST1, m_wndShellList);
	DDX_Control(pDX, IDC_TREE1, m_wbdShellTree);
	DDX_Text(pDX, IDC_SELECTED_FOLDER, m_strSelectedFolder);
}

BEGIN_MESSAGE_MAP(CPage6, CMFCPropertyPage)
	ON_BN_CLICKED(IDC_SELECT_FOLDER, OnSelectFolder)
END_MESSAGE_MAP()

/////////////////////////////////////////////////////////////////////////////
// CPage6 message handlers

void CPage6::OnSelectFolder()
{
	if (theApp.GetShellManager()->BrowseForFolder(m_strSelectedFolder, this, m_strSelectedFolder))
	{
		UpdateData(FALSE);
	}
}

BOOL CPage6::OnInitDialog()
{
	CMFCPropertyPage::OnInitDialog();

	m_wbdShellTree.Expand(m_wbdShellTree.GetRootItem(), TVE_EXPAND);
	m_wbdShellTree.SetRelatedList(&m_wndShellList);

	return TRUE;  // return TRUE unless you set the focus to a control
}

