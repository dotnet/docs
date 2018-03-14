// This is a part of the Microsoft Foundation Classes C++ library.
// Copyright (C) Microsoft Corporation
// All rights reserved.
//
// This source code is only intended as a supplement to the
// Microsoft Foundation Classes Reference and related
// electronic documentation provided with the library.
// See these sources for detailed information regarding the
// Microsoft Foundation Classes product.

#pragma once

class CHistoryObj  
{
public:
	CHistoryObj(const CString& strTitle, const CString& strURL, const UINT uiCommand);
	virtual ~CHistoryObj();

	LPCTSTR GetTitle () const
	{
		return m_strTitle;
	}

	LPCTSTR GetURL () const
	{
		return m_strURL;
	}

	UINT GetCommand () const
	{
		return m_uiCommand;
	}

protected:
	const CString	m_strTitle;
	const CString	m_strURL;
	const UINT		m_uiCommand;
};

