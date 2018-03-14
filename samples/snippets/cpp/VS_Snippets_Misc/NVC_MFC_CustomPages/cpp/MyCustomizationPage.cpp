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
#include "CustomPages.h"
#include "MyCustomizationPage.h"

#ifdef _DEBUG
#define new DEBUG_NEW
#undef THIS_FILE
static char THIS_FILE[] = __FILE__;
#endif

IMPLEMENT_DYNCREATE(CMyCustomizationPage, CPropertyPage)

/////////////////////////////////////////////////////////////////////////////
// CMyCustomizationPage dialog


CMyCustomizationPage::CMyCustomizationPage(CWnd* /*pParent*/ /*=NULL*/)
	: CPropertyPage(CMyCustomizationPage::IDD)
{
}


void CMyCustomizationPage::DoDataExchange(CDataExchange* pDX)
{
	CDialog::DoDataExchange(pDX);
}


BEGIN_MESSAGE_MAP(CMyCustomizationPage, CDialog)
END_MESSAGE_MAP()

/////////////////////////////////////////////////////////////////////////////
// CMyCustomizationPage message handlers
