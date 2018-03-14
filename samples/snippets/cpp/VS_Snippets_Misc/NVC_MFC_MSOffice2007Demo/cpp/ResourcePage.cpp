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
#include "ResourcePage.h"

#ifdef _DEBUG
#define new DEBUG_NEW
#undef THIS_FILE
static char THIS_FILE[] = __FILE__;
#endif

/////////////////////////////////////////////////////////////////////////////
// CResourcePage property page

IMPLEMENT_DYNCREATE(CResourcePage, CMFCPropertyPage)

CResourcePage::CResourcePage() : CMFCPropertyPage(CResourcePage::IDD)
{
}

CResourcePage::~CResourcePage()
{
}

void CResourcePage::DoDataExchange(CDataExchange* pDX)
{
	CMFCPropertyPage::DoDataExchange(pDX);
}

BEGIN_MESSAGE_MAP(CResourcePage, CMFCPropertyPage)
	//{{AFX_MSG_MAP(CResourcePage)
	ON_BN_CLICKED(IDC_HOME, OnHome)
	ON_BN_CLICKED(IDC_CONTACT, OnContact)
	ON_BN_CLICKED(IDC_PRODUCT, OnProduct)
	ON_BN_CLICKED(IDC_SUPPORT, OnSupport)
	//}}AFX_MSG_MAP
END_MESSAGE_MAP()

/////////////////////////////////////////////////////////////////////////////
// CResourcePage message handlers

void CResourcePage::OnHome()
{
	::ShellExecute(NULL, NULL, _T("http://www.microsoft.com"), NULL, NULL, NULL);
}

void CResourcePage::OnContact()
{
	::ShellExecute(NULL, NULL, _T("http://www.microsoft.com"), NULL, NULL, NULL);
}

void CResourcePage::OnProduct()
{
	::ShellExecute(NULL, NULL, _T("http://www.microsoft.com"), NULL, NULL, NULL);
}

void CResourcePage::OnSupport()
{
	::ShellExecute(NULL, NULL, _T("http://www.microsoft.com"), NULL, NULL, NULL);
}

