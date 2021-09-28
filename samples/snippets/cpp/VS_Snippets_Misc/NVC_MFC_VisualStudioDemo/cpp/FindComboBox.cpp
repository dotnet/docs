// This is a part of the Microsoft Foundation Classes C++ library.
// Copyright (c) Microsoft Corporation.  All rights reserved.
//
// This source code is only intended as a supplement to the
// Microsoft Foundation Classes Reference and related
// electronic documentation provided with the library.
// See these sources for detailed information regarding the
// Microsoft Foundation Classes product.

#include "stdafx.h"
#include "VisualStudioDemo.h"
#include "FindComboBox.h"

#ifdef _DEBUG
#define new DEBUG_NEW
#undef THIS_FILE
static char THIS_FILE[] = __FILE__;
#endif

/////////////////////////////////////////////////////////////////////////////
// CFindComboButton

IMPLEMENT_SERIAL(CFindComboButton, CMFCToolBarComboBoxButton, 1)

BOOL CFindComboButton::m_bHasFocus = FALSE;

BOOL CFindComboButton::NotifyCommand(int iNotifyCode)
{
	BOOL bRes = CMFCToolBarComboBoxButton::NotifyCommand(iNotifyCode);

	switch (iNotifyCode)
	{
	case CBN_KILLFOCUS:
		m_bHasFocus = FALSE;
		bRes = TRUE;
		break;

	case CBN_SETFOCUS:
		m_bHasFocus = TRUE;
		bRes = TRUE;
		break;
	}

	return bRes;
}

