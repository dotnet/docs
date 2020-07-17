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
#include "IEDemo.h"
#include "LinkButton.h"

#ifdef _DEBUG
#undef THIS_FILE
static char THIS_FILE[]=__FILE__;
#define new DEBUG_NEW
#endif

IMPLEMENT_SERIAL(CLinkButton, CMFCToolBarButton, 1)

//////////////////////////////////////////////////////////////////////
// Construction/Destruction
//////////////////////////////////////////////////////////////////////

CLinkButton::CLinkButton()
{
	Initialize ();
}
//***************************************************************************************
CLinkButton::CLinkButton(LPCTSTR lpszLabel, LPCTSTR lpszURL)
{
	m_strURL = lpszURL;
	m_strText = lpszLabel;

	Initialize ();
}
//***************************************************************************************
CLinkButton::~CLinkButton()
{

}
//***************************************************************************************
void CLinkButton::Initialize ()
{
	m_nID = ID_LINK_1;
	SetImage (GetCmdMgr ()->GetCmdImage (ID_LINK_1));
	m_bImage = m_bText = TRUE;

    // <snippet5>
	CMFCToolBarComboBoxButton* pButton = new CMFCToolBarComboBoxButton();
	CMFCToolBarComboBoxEdit* pWndEdit = new CMFCToolBarComboBoxEdit(*pButton);
	// </snippet5>
}
//*********************************************************************************
void CLinkButton::CopyFrom (const CMFCToolBarButton& src)
{
	CMFCToolBarButton::CopyFrom (src);

	const CLinkButton& srcLinkButton = (const CLinkButton&) src;
	m_strURL = srcLinkButton.m_strURL;
}					
//***************************************************************************************
void CLinkButton::Serialize (CArchive& ar)
{
	CMFCToolBarButton::Serialize (ar);

	if (ar.IsLoading ())
	{
		ar >> m_strURL;
	}
	else
	{
		ar << m_strURL;
	}
}
