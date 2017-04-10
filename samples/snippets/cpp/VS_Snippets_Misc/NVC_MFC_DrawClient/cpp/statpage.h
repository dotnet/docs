// This is a part of the Microsoft Foundation Classes C++ library.
// Copyright (c) Microsoft Corporation.  All rights reserved.
//
// This source code is only intended as a supplement to the
// Microsoft Foundation Classes Reference and related
// electronic documentation provided with the library.
// See these sources for detailed information regarding the
// Microsoft Foundation Classes product.

/////////////////////////////////////////////////////////////////////////////
// CStatPage dialog

class CStatPage : public CPropertyPage
{
	DECLARE_DYNCREATE(CStatPage)

// Construction
public:
	CStatPage();
	~CStatPage();

// Dialog Data
	//{{AFX_DATA(CStatPage)
	enum { IDD = IDD_STAT_PAGE };
	CString m_strSavedBy;
	CString m_strRevNum;
	CString m_strEditTime;
	CString m_strLastPrint;
	CString m_strCreateDate;
	CString m_strLastSave;
	CString m_strNumPages;
	CString m_strNumWords;
	CString m_strNumChars;
	CString m_strSecurity;
	//}}AFX_DATA

// Overrides
protected:
	virtual void DoDataExchange(CDataExchange* pDX);    // DDX/DDV support

	// Implementation
protected:
	//{{AFX_MSG(CStatPage)
	//}}AFX_MSG

	DECLARE_MESSAGE_MAP()
};
