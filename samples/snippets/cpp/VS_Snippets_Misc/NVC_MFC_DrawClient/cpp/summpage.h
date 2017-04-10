// This is a part of the Microsoft Foundation Classes C++ library.
// Copyright (c) Microsoft Corporation.  All rights reserved.
//
// This source code is only intended as a supplement to the
// Microsoft Foundation Classes Reference and related
// electronic documentation provided with the library.
// See these sources for detailed information regarding the
// Microsoft Foundation Classes product.

class CSummPage : public CPropertyPage
{
	DECLARE_DYNCREATE(CSummPage)

// Construction
public:
	CSummPage();
	~CSummPage();

// Dialog Data
	//{{AFX_DATA(CSummPage)
	enum { IDD = IDD_SUMM_PAGE };
	CString m_strAuthor;
	CString m_strKeywd;
	CString m_strSubj;
	CString m_strCmt;
	CString m_strTempl;
	CString m_strTitle;
	CString m_strAppname;
	//}}AFX_DATA

// Overrides
protected:
	virtual void DoDataExchange(CDataExchange* pDX);    // DDX/DDV support

// Implementation
protected:
	//{{AFX_MSG(CSummPage)
	//}}AFX_MSG
	DECLARE_MESSAGE_MAP()
};
