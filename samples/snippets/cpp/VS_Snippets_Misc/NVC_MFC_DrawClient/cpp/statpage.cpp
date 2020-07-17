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
#include "statpage.h"

#ifdef _DEBUG
#undef THIS_FILE
static char THIS_FILE[] = __FILE__;
#endif

/////////////////////////////////////////////////////////////////////////////
// CStatPage property page

IMPLEMENT_DYNCREATE(CStatPage, CPropertyPage)

CStatPage::CStatPage() : CPropertyPage(CStatPage::IDD)
{
	//{{AFX_DATA_INIT(CStatPage)
	m_strCreateDate = _T("");
	m_strEditTime = _T("");
	m_strLastPrint = _T("");
	m_strLastSave = _T("");
	m_strNumChars = _T("");
	m_strNumPages = _T("");
	m_strNumWords = _T("");
	m_strRevNum = _T("");
	m_strSavedBy = _T("");
	m_strSecurity = _T("");
	//}}AFX_DATA_INIT
}

CStatPage::~CStatPage()
{
}

void CStatPage::DoDataExchange(CDataExchange* pDX)
{
	CPropertyPage::DoDataExchange(pDX);
	//{{AFX_DATA_MAP(CStatPage)
	DDX_Text(pDX, IDC_CREATEDATE, m_strCreateDate);
	DDX_Text(pDX, IDC_EDITTIME, m_strEditTime);
	DDX_Text(pDX, IDC_LASTPRINT, m_strLastPrint);
	DDX_Text(pDX, IDC_LASTSAVE, m_strLastSave);
	DDX_Text(pDX, IDC_NUMCHARS, m_strNumChars);
	DDX_Text(pDX, IDC_NUMPAGES, m_strNumPages);
	DDX_Text(pDX, IDC_NUMWORDS, m_strNumWords);
	DDX_Text(pDX, IDC_REVNUM, m_strRevNum);
	DDX_Text(pDX, IDC_SAVEDBY, m_strSavedBy);
	DDX_Text(pDX, IDC_SECURITY, m_strSecurity);
	//}}AFX_DATA_MAP
}

BEGIN_MESSAGE_MAP(CStatPage, CPropertyPage)
	//{{AFX_MSG_MAP(CStatPage)
	//}}AFX_MSG_MAP
END_MESSAGE_MAP()
