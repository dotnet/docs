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
#include "HistoryObj.h"

#ifdef _DEBUG
#undef THIS_FILE
static char THIS_FILE[]=__FILE__;
#define new DEBUG_NEW
#endif

//////////////////////////////////////////////////////////////////////
// Construction/Destruction
//////////////////////////////////////////////////////////////////////

CHistoryObj::CHistoryObj(const CString& strTitle, const CString& strURL,
						const UINT uiCommand) :
	m_strTitle (strTitle),
	m_strURL (strURL),
	m_uiCommand (uiCommand)
{
}

CHistoryObj::~CHistoryObj()
{
}
