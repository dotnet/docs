// This is a part of the Microsoft Foundation Classes C++ library.
// Copyright (c) Microsoft Corporation.  All rights reserved.
//
// This source code is only intended as a supplement to the
// Microsoft Foundation Classes Reference and related
// electronic documentation provided with the library.
// See these sources for detailed information regarding the
// Microsoft Foundation Classes product.

#pragma once

class CWorkspaceObj : public CObject
{
public:
	CWorkspaceObj(const CString& strName, const UINT uiCmd, const int iIconIndex, const UINT uiDefaultNewAction);
	virtual ~CWorkspaceObj();

	const CString m_strName;
	const UINT m_uiCmd;
	const int m_iIconIndex;
	const UINT m_uiDefaultNewAction;
};
