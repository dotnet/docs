// This is a part of the Microsoft Foundation Classes C++ library.
// Copyright (c) Microsoft Corporation.  All rights reserved.
//
// This source code is only intended as a supplement to the
// Microsoft Foundation Classes Reference and related
// electronic documentation provided with the library.
// See these sources for detailed information regarding the
// Microsoft Foundation Classes product.

#include "stdafx.h"
#include "OutlookDemo.h"
#include "WorkspaceObj.h"

#ifdef _DEBUG
#undef THIS_FILE
static char THIS_FILE[]=__FILE__;
#define new DEBUG_NEW
#endif

//////////////////////////////////////////////////////////////////////
// Construction/Destruction
//////////////////////////////////////////////////////////////////////

CWorkspaceObj::CWorkspaceObj(const CString& strName, const UINT uiCmd, const int iIconIndex, const UINT uiDefaultNewAction) :
	m_strName(strName), m_uiCmd(uiCmd), m_iIconIndex(iIconIndex), m_uiDefaultNewAction(uiDefaultNewAction)
{
}

CWorkspaceObj::~CWorkspaceObj()
{
}
