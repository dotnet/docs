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
#include "summpage.h"

#ifdef _DEBUG
#undef THIS_FILE
static char THIS_FILE[] = __FILE__;
#endif

/////////////////////////////////////////////////////////////////////////////
// CSummPage property page

IMPLEMENT_DYNCREATE(CSummPage, CPropertyPage)

CSummPage::CSummPage() : CPropertyPage(CSummPage::IDD)
{
	//{{AFX_DATA_INIT(CSummPage)
	m_strAuthor = _T("");
	m_strKeywd = _T("");
	m_strSubj = _T("");
	m_strCmt = _T("");
	m_strTempl = _T("");
	m_strTitle = _T("");
	m_strAppname = _T("");
	//}}AFX_DATA_INIT
}

CSummPage::~CSummPage()
{
}

void CSummPage::DoDataExchange(CDataExchange* pDX)
{
	CPropertyPage::DoDataExchange(pDX);
	//{{AFX_DATA_MAP(CSummPage)
	DDX_Text(pDX, IDC_AUTHOR, m_strAuthor);
	DDX_Text(pDX, IDC_KEYWORDS, m_strKeywd);
	DDX_Text(pDX, IDC_SUBJECT, m_strSubj);
	DDX_Text(pDX, IDC_COMMENTS, m_strCmt);
	DDX_Text(pDX, IDC_TEMPLATE, m_strTempl);
	DDX_Text(pDX, IDC_TITLE, m_strTitle);
	DDX_Text(pDX, IDC_APPNAME, m_strAppname);
	//}}AFX_DATA_MAP
}

BEGIN_MESSAGE_MAP(CSummPage, CPropertyPage)
	//{{AFX_MSG_MAP(CSummPage)
	//}}AFX_MSG_MAP
END_MESSAGE_MAP()
