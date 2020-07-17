#pragma once

#include "MyPropertyPage1.h"

/////////////////////////////////////////////////////////////////////////////
// CMyPropertySheet

class CMyPropertySheet : public CMFCPropertySheet
{
	DECLARE_DYNAMIC(CMyPropertySheet)

// Construction
public:
	CMyPropertySheet(CMFCPropertySheet::PropSheetLook look,
					UINT uiIconsResID = 0, int cxIcon = 0);

// Attributes
public:
	CMyPropertyPage1 m_Page1;
	CMyPropertyPage2 m_Page2;
	CMyPropertyPage3 m_Page3;
	CMyPropertyPage4 m_Page4;

// Operations
public:

// Overrides
	virtual void OnDrawPageHeader (CDC* pDC, int nPage, CRect rectHeader);

// Implementation
public:
	virtual ~CMyPropertySheet();

protected:
	DECLARE_MESSAGE_MAP()
};

