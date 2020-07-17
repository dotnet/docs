#include "stdafx.h"
#include "resource.h"
#include "MyPropertySheet.h"

#ifdef _DEBUG
#undef THIS_FILE
static char BASED_CODE THIS_FILE[] = __FILE__;
#endif

/////////////////////////////////////////////////////////////////////////////
// CMyPropertySheet

IMPLEMENT_DYNAMIC(CMyPropertySheet, CMFCPropertySheet)

CMyPropertySheet::CMyPropertySheet(CMFCPropertySheet::PropSheetLook look,
								   UINT uiIconsResID, int cxIcon)
	 : CMFCPropertySheet(IDS_PROPSHT_CAPTION, NULL)
{
	SetLook (look);

	if (uiIconsResID != 0)
	{
		SetIconsList (uiIconsResID, cxIcon);
	}

	if (look == PropSheetLook_Tree)
	{
		CMFCPropertySheetCategoryInfo* pCategory1 = AddTreeCategory (
			_T("Category 1"), 0, 1);
		AddPageToTree (pCategory1, &m_Page1, -1, 2);
		AddPageToTree (pCategory1, &m_Page2, -1, 2);

		CMFCPropertySheetCategoryInfo* pCategory2 = AddTreeCategory (
			_T("Category 2"), 0, 1);

		AddPageToTree (pCategory2, &m_Page3, -1, 2);
		AddPageToTree (pCategory2, &m_Page4, -1, 2);
	}
	else
	{
		AddPage(&m_Page1);
		AddPage(&m_Page2);
		AddPage(&m_Page3);
		AddPage(&m_Page4);
	}
}

CMyPropertySheet::~CMyPropertySheet()
{
}


BEGIN_MESSAGE_MAP(CMyPropertySheet, CMFCPropertySheet)
END_MESSAGE_MAP()


/////////////////////////////////////////////////////////////////////////////
// CMyPropertySheet message handlers


void CMyPropertySheet::OnDrawPageHeader (CDC* pDC, int nPage, CRect rectHeader)
{
	rectHeader.top += 2;
	rectHeader.right -= 2;
	rectHeader.bottom -= 2;

	pDC->FillRect (rectHeader, &afxGlobalData.brBtnFace);
	pDC->Draw3dRect (rectHeader, afxGlobalData.clrBtnShadow, afxGlobalData.clrBtnShadow);

	// <snippet1>
	// CDC* pDC
	// CRect rectHeader
	CDrawingManager dm (*pDC);
	// Draw a shadow for a rectangular area.
	// second parameter is the depth of the shadow
	dm.DrawShadow (rectHeader, 2);	
	// </snippet1>

	CString strText;
	strText.Format (_T("Page %d description..."), nPage + 1);

	CRect rectText = rectHeader;
	rectText.DeflateRect (10, 0);

	CFont* pOldFont = pDC->SelectObject (&afxGlobalData.fontBold);
	pDC->SetBkMode (TRANSPARENT);
	pDC->SetTextColor (afxGlobalData.clrBtnText);

	pDC->DrawText (strText, rectText, DT_SINGLELINE | DT_VCENTER);

	pDC->SelectObject (pOldFont);
}

