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

class CLinkButton : public CMFCToolBarButton  
{
	DECLARE_SERIAL(CLinkButton)

public:
	CLinkButton();
	CLinkButton(LPCTSTR lpszLabel, LPCTSTR lpszURL);

	virtual ~CLinkButton();

	LPCTSTR GetURL () const
	{
		return m_strURL;
	}

protected:
	void Initialize ();
	virtual void CopyFrom (const CMFCToolBarButton& src);
	virtual void Serialize (CArchive& ar);

	CString	m_strURL;

	virtual BOOL IsEditable () const
	{
		return FALSE;
	}
};
