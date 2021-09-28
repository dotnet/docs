// This is a part of the Microsoft Foundation Classes C++ library.
// Copyright (c) Microsoft Corporation.  All rights reserved.
//
// This source code is only intended as a supplement to the
// Microsoft Foundation Classes Reference and related
// electronic documentation provided with the library.
// See these sources for detailed information regarding the
// Microsoft Foundation Classes product.

#include "stdafx.h"
#include "NewControls.h"
#include "CustomProperties.h"
#include "Page5.h"

#ifdef _DEBUG
#define new DEBUG_NEW
#undef THIS_FILE
static char THIS_FILE[] = __FILE__;
#endif

/////////////////////////////////////////////////////////////////////////////
// CPage5 property page

IMPLEMENT_DYNCREATE(CPage5, CMFCPropertyPage)

CPage5::CPage5() : CMFCPropertyPage(CPage5::IDD)
{
	m_bDescrArea = TRUE;
	m_bDotNetLook = TRUE;
	m_bHeader = TRUE;
	m_bMarkSortedColumn = TRUE;
	m_bColor = TRUE;
	m_bModifyFont = TRUE;
	m_bPropListCustomColors = FALSE;
	m_bPropListCategorized = TRUE;
	m_bShowDragContext = TRUE;
	m_bMarkChanged = TRUE;
	m_bHideFontProps = FALSE;

	m_wndList.m_bColor = TRUE;
	m_wndList.m_bModifyFont = TRUE;

	pGroupFont = NULL;
}

CPage5::~CPage5()
{
}

void CPage5::DoDataExchange(CDataExchange* pDX)
{
	CMFCPropertyPage::DoDataExchange(pDX);
	DDX_Control(pDX, IDC_PROPLIST_EXPAND_ALL, m_btnExpandAll);
	DDX_Control(pDX, IDC_PROPLIST_LOCATION, m_wndPropListLocation);
	DDX_Control(pDX, IDC_LIST1, m_wndList);
	DDX_Check(pDX, IDC_DESCRIPTION_AREA, m_bDescrArea);
	DDX_Check(pDX, IDC_DOT_NET_LOOK, m_bDotNetLook);
	DDX_Check(pDX, IDC_HEADER, m_bHeader);
	DDX_Check(pDX, IDC_MARK_SORTED_COLUMN, m_bMarkSortedColumn);
	DDX_Check(pDX, IDC_COLOR_ROWS, m_bColor);
	DDX_Check(pDX, IDC_MODIFY_FONT, m_bModifyFont);
	DDX_Check(pDX, IDC_CUSTOM_COLORS, m_bPropListCustomColors);
	DDX_Check(pDX, IDC_PROPLIST_CATEGORIZED, m_bPropListCategorized);
	DDX_Check(pDX, IDC_PROPLIST_CATEGORIZED2, m_bShowDragContext);
	DDX_Check(pDX, IDC_MARK_CHANGED, m_bMarkChanged);
	DDX_Check(pDX, IDC_HIDE_FONT_PROPS, m_bHideFontProps);
}

BEGIN_MESSAGE_MAP(CPage5, CMFCPropertyPage)
	ON_BN_CLICKED(IDC_HEADER, OnHeader)
	ON_BN_CLICKED(IDC_DOT_NET_LOOK, OnDotNetLook)
	ON_BN_CLICKED(IDC_DESCRIPTION_AREA, OnDescriptionArea)
	ON_BN_CLICKED(IDC_MARK_SORTED_COLUMN, OnMarkSortedColumn)
	ON_BN_CLICKED(IDC_COLOR_ROWS, OnColorRows)
	ON_BN_CLICKED(IDC_MODIFY_FONT, OnModifyFont)
	ON_BN_CLICKED(IDC_CUSTOM_COLORS, OnPropListCustomColors)
	ON_BN_CLICKED(IDC_PROPLIST_EXPAND_ALL, OnProplistExpandAll)
	ON_BN_CLICKED(IDC_PROPLIST_CATEGORIZED, OnProplistCategorized)
	ON_BN_CLICKED(IDC_PROPLIST_CATEGORIZED2, OnProplistCategorized2)
	ON_BN_CLICKED(IDC_RESET_VALUES, OnResetValues)
	ON_BN_CLICKED(IDC_MARK_CHANGED, OnMarkChanged)
	ON_BN_CLICKED(IDC_HIDE_FONT_PROPS, OnHideFontProps)
END_MESSAGE_MAP()

/////////////////////////////////////////////////////////////////////////////
// CPage5 message handlers

const int nColumns = 3;
const int nRows = 50;

BOOL CPage5::OnInitDialog()
{
	CMFCPropertyPage::OnInitDialog();

	m_wndList.InsertColumn(0, _T("#"), LVCFMT_LEFT, 20);

	int nColumn;
	for (nColumn = 1; nColumn < nColumns; nColumn++)
	{
		m_wndList.InsertColumn(nColumn, CString((TCHAR)(_T('A') + nColumn - 1)), LVCFMT_LEFT, 60 + nColumn * 10);
	}

	for (int i = 0; i < nRows; i++)
	{
		CString str;
		str.Format(_T("%d"), i);
		m_wndList.InsertItem(i, str);
		m_wndList.SetItemData(i, i);

		for (nColumn = 1; nColumn < nColumns; nColumn++)
		{
			str.Format(_T("Item(%d, %d)"), nColumn - 1, nColumn == 1 ? 99 - i : i + 50);
			m_wndList.SetItemText(i, nColumn, str);
		}
	}

	m_wndList.SendMessage(LVM_SETEXTENDEDLISTVIEWSTYLE, 0, LVS_EX_FULLROWSELECT | LVS_EX_GRIDLINES);
	m_wndList.EnableMarkSortedColumn();

	CRect rectPropList;
	m_wndPropListLocation.GetClientRect(&rectPropList);
	m_wndPropListLocation.MapWindowPoints(this, &rectPropList);

	// <snippet15>
	// CRect rectPropList
	// CMFCPropertyGridCtrl m_wndPropList
	// The this pointer points to a CPage5 class which extends the CMFCPropertyPage class.
	m_wndPropList.Create(WS_CHILD | WS_VISIBLE | WS_TABSTOP | WS_BORDER, rectPropList, this, (UINT)-1);
	// </snippet15>

	// <snippet16>
	m_wndPropList.EnableHeaderCtrl();
	m_wndPropList.EnableDescriptionArea();
	m_wndPropList.SetVSDotNetLook(m_bDotNetLook);
    // BOOL m_bMarkChanged
	m_wndPropList.MarkModifiedProperties(m_bMarkChanged);
    // BOOL m_bPropListCategorized
	m_wndPropList.SetAlphabeticMode(!m_bPropListCategorized);
	// BOOL m_bShowDragContext
	m_wndPropList.SetShowDragContext(m_bShowDragContext);
	// </snippet16>

	// <snippet27>
	CMFCPropertyGridProperty* pGroup1 = new CMFCPropertyGridProperty(_T("Appearance"));

	// construct a COleVariant object. 
	COleVariant var3DLook((short)VARIANT_FALSE, VT_BOOL);

	pGroup1->AddSubItem(new CMFCPropertyGridProperty(_T("3D Look"), var3DLook, 
		_T("Specifies the dialog's font will be nonbold and controls will have a 3D border")));

	CMFCPropertyGridProperty* pProp = new CMFCPropertyGridProperty(_T("Border"),
		_T("Dialog Frame"), _T("One of: None, Thin, Resizable, or Dialog Frame"));
	pProp->AddOption(_T("None"));
	pProp->AddOption(_T("Thin"));
	pProp->AddOption(_T("Resizable"));
	pProp->AddOption(_T("Dialog Frame"));
	pProp->AllowEdit(FALSE);

	pGroup1->AddSubItem(pProp);
	pGroup1->AddSubItem(new CMFCPropertyGridProperty(_T("Caption"), (COleVariant) _T("About NewControlsDemo"), _T("Specifies the text that will be displayed in the dialog's title bar")));
	pGroup1->AdjustButtonRect();
	pGroup1->AllowEdit();
	pGroup1->Enable();
	pGroup1->Show();
	pGroup1->Redraw();
	// </snippet27>
	m_wndPropList.AddProperty(pGroup1);

	CMFCPropertyGridProperty* pSize = new CBoundedNumberPairProp(_T("Window Size"), 0, 300, 0, 200, 0, TRUE);

	pProp = new CBoundedNumberSubProp(_T("Height"), (COleVariant) 250l, 0, 300, _T("Specifies the dialog's height"));
	pProp->EnableSpinControl(TRUE, 0, 300);
	pSize->AddSubItem(pProp);

	pProp = new CBoundedNumberSubProp( _T("Width"), (COleVariant) 150l, 0, 200, _T("Specifies the dialog's width"));
	pProp->EnableSpinControl(TRUE, 0, 200);
	pSize->AddSubItem(pProp);

	m_wndPropList.AddProperty(pSize);

	pGroupFont = new CMFCPropertyGridProperty(_T("Font"));

	LOGFONT lf;
	CFont* font = CFont::FromHandle((HFONT) GetStockObject(DEFAULT_GUI_FONT));
	font->GetLogFont(&lf);
	lstrcpy(lf.lfFaceName, _T("Arial"));

    // <snippet26>
	// LOGFONT lf
	// CMFCPropertyGridProperty* pGroupFont
	pGroupFont->AddSubItem(new CMFCPropertyGridFontProperty(_T("Font"), lf, CF_EFFECTS | CF_SCREENFONTS, _T("Specifies the default font for the dialog")));
	// </snippet26>

	pGroupFont->AddSubItem(new CMFCPropertyGridProperty(_T("Use System Font"), (COleVariant)VARIANT_TRUE, _T("Specifies that the dialog uses MS Shell Dlg font")));

	m_wndPropList.AddProperty(pGroupFont);

	CMFCPropertyGridProperty* pGroup3 = new CMFCPropertyGridProperty(_T("Misc"));
	pProp = new CMFCPropertyGridProperty(_T("(Name)"), _T("IDD_ABOUT_BOX(dialog)"));
	pProp->Enable(FALSE);
	pGroup3->AddSubItem(pProp);

	// <snippet13>
	CMFCPropertyGridColorProperty* pColorProp = new CMFCPropertyGridColorProperty(_T("Window Color"), RGB(210, 192, 254), NULL, _T("Specifies the default dialog color"));
	pColorProp->EnableOtherButton(_T("Other..."));
	pColorProp->EnableAutomaticButton(_T("Default"), ::GetSysColor(COLOR_3DFACE));
	pColorProp->SetColor(RGB(255,0,0));
	pColorProp->SetColumnsNumber(3);
	// </snippet13>
	pGroup3->AddSubItem(pColorProp);

	static TCHAR BASED_CODE szFilter[] = _T("Icon Files(*.ico)|*.ico|All Files(*.*)|*.*||");
	pGroup3->AddSubItem(new CMFCPropertyGridFileProperty(_T("Icon"), TRUE, _T(""), _T("ico"), 0, szFilter, _T("Specifies the dialog icon")));

	pGroup3->AddSubItem(new CMFCPropertyGridFileProperty(_T("Folder"), _T("c:\\")));

	pGroup3->AddSubItem(new CMFCPropertyGridProperty(_T("Phone"), _T("(123) 123-12-12"), _T("Enter a phone number"), 0, _T(" ddd  ddd dd dd"), _T("(___) ___-__-__")));

	m_wndPropList.AddProperty(pGroup3);

	CMFCPropertyGridProperty* pGroup4 = new CMFCPropertyGridProperty(_T("Hierarchy"));

	CMFCPropertyGridProperty* pGroup41 = new CMFCPropertyGridProperty(_T("First sub-level"));
	pGroup4->AddSubItem(pGroup41);

	CMFCPropertyGridProperty* pGroup411 = new CMFCPropertyGridProperty(_T("Second sub-level"));
	pGroup41->AddSubItem(pGroup411);

	pGroup411->AddSubItem(new CMFCPropertyGridProperty(_T("Item 1"), (COleVariant) _T("Value 1"), _T("This is a description")));
	pGroup411->AddSubItem(new CMFCPropertyGridProperty(_T("Item 2"), (COleVariant) _T("Value 2"), _T("This is a description")));
	pGroup411->AddSubItem(new CMFCPropertyGridProperty(_T("Item 3"), (COleVariant) _T("Value 3"), _T("This is a description")));

	pGroup4->Expand(FALSE);
	m_wndPropList.AddProperty(pGroup4);

	// Add custom properties:
	CMFCPropertyGridProperty* pGroup5 = new CMFCPropertyGridProperty(_T("Custom Properties"));

	pGroup5->AddSubItem(new CCheckBoxProp(_T("Check Box"), TRUE, _T("Check Box Property")));

	pGroup5->AddSubItem(new CPasswordProp(_T("Password"), _T("123456"), _T("Password Property")));

	pGroup5->AddSubItem(new CSliderProp(_T("Slider"), 0, _T("Slider Property")));

	CBitmap bmp;
	bmp.LoadBitmap(IDB_PROPICONS);

	m_imageList.Create(16, 16, ILC_MASK | ILC_COLOR24, 0, 0);
	m_imageList.Add(&bmp, RGB(192, 192, 192));

	CStringList lstIconNames;
	lstIconNames.AddTail(_T("Icon 1"));
	lstIconNames.AddTail(_T("Icon 2"));
	lstIconNames.AddTail(_T("Icon 3"));
	lstIconNames.AddTail(_T("Icon 4"));
	lstIconNames.AddTail(_T("Icon 5"));
	lstIconNames.AddTail(_T("Icon 6"));
	lstIconNames.AddTail(_T("Icon 7"));
	lstIconNames.AddTail(_T("Icon 8"));
	lstIconNames.AddTail(_T("Icon 9"));
	lstIconNames.AddTail(_T("Icon 10"));

	pGroup5->AddSubItem(new CIconListProp(_T("Icon List"), m_imageList, 0, &lstIconNames, _T("Icon List Property")));

	CComboBoxExProp* pComboEx = new CComboBoxExProp(_T("ComboBoxEx"), _T("Test"), _T("ComboBoxEx Property"), 0, &m_imageList);
	pComboEx->AddOption(_T("New"), 0, 0);
	pComboEx->AddOption(_T("Open"), 1, 1);
	pComboEx->AddOption(_T("Save"), 2, 0);

	pGroup5->AddSubItem(pComboEx);

	pGroup5->AddSubItem(new COwnerDrawDescrProp(_T("Owner-draw descr."), 0l));
	pGroup5->AddSubItem(new CTwoButtonsProp(_T("2 Buttons"), _T("text")));
	pGroup5->AddSubItem(new CCustomDlgProp(_T("Custom Dialog"), _T("value")));

	m_wndPropList.AddProperty(pGroup5);

	return TRUE;  // return TRUE unless you set the focus to a control
	// EXCEPTION: OCX Property Pages should return FALSE
}

void CPage5::OnHeader()
{
	UpdateData();
	// <snippet17>
	// BOOL m_bHeader
	m_wndPropList.EnableHeaderCtrl(m_bHeader);
	// </snippet17>
}

void CPage5::OnDotNetLook()
{
	UpdateData();
	// <snippet18>
	// BOOL m_bDOtNetLook
	m_wndPropList.SetVSDotNetLook(m_bDotNetLook);
	// </snippet18>
}

void CPage5::OnDescriptionArea()
{
	UpdateData();
	// <snippet19>
	m_wndPropList.EnableDescriptionArea(m_bDescrArea);
	// </snippet19>
}

void CPage5::OnMarkSortedColumn()
{
	UpdateData();
	// <snippet20>
	// BOOL m_bMarkSortedColumn
	m_wndList.EnableMarkSortedColumn(m_bMarkSortedColumn);
	// </snippet20>
}

COLORREF CMyListCtrl::OnGetCellTextColor(int nRow, int nColum)
{
	if (!m_bColor)
	{
		return CMFCListCtrl::OnGetCellTextColor(nRow, nColum);
	}

	return(nRow % 2) == 0 ? RGB(128, 37, 0) : RGB(0, 0, 0);
}

COLORREF CMyListCtrl::OnGetCellBkColor(int nRow, int nColum)
{
	if (!m_bColor)
	{
		return CMFCListCtrl::OnGetCellBkColor(nRow, nColum);
	}

	if (m_bMarkSortedColumn && nColum == m_iSortedColumn)
	{
		return(nRow % 2) == 0 ? RGB(233, 221, 229) : RGB(176, 218, 234);
	}

	return(nRow % 2) == 0 ? RGB(253, 241, 249) : RGB(196, 238, 254);
}

HFONT CMyListCtrl::OnGetCellFont(int nRow, int nColum, DWORD /*dwData* = 0*/)
{
	if (!m_bModifyFont)
	{
		return NULL;
	}

	if (nColum == 2 &&(nRow >= 4 && nRow <= 8))
	{
		return afxGlobalData.fontDefaultGUIBold;
	}

	return NULL;
}

int CMyListCtrl::OnCompareItems(LPARAM lParam1, LPARAM lParam2, int iColumn)
{
	CString strItem1 = GetItemText((int)(lParam1 < lParam2 ? lParam1 : lParam2), iColumn);
	CString strItem2 = GetItemText((int)(lParam1 < lParam2 ? lParam2 : lParam1), iColumn);

	if (iColumn == 0)
	{
		int nItem1 = _ttoi(strItem1);
		int nItem2 = _ttoi(strItem2);
		return(nItem1 < nItem2 ? -1 : 1);
	}
	else
	{
		int iSort = _tcsicmp(strItem1, strItem2);
		return(iSort);
	}
}

void CPage5::OnColorRows()
{
	UpdateData();
	m_wndList.m_bColor = m_bColor;
	m_wndList.RedrawWindow();
}

void CPage5::OnModifyFont()
{
	UpdateData();
	m_wndList.m_bModifyFont = m_bModifyFont;
	m_wndList.RedrawWindow();
}

void CPage5::OnPropListCustomColors()
{
	UpdateData();

	// <snippet21>
	// BOOL m_bPropListCustomColors
	// set custom colors for various elements of the property grid control
	if (m_bPropListCustomColors)
	{
		m_wndPropList.SetCustomColors(RGB(228, 243, 254), RGB(46, 70, 165), RGB(200, 236, 209), RGB(33, 102, 49), RGB(255, 229, 216), RGB(128, 0, 0), RGB(159, 159, 255));
	}
	else
	{
		COLORREF c = (COLORREF)-1;
		m_wndPropList.SetCustomColors(c, c, c, c, c, c, c);
	}

	m_wndPropList.RedrawWindow();
	// </snippet21>
}

void CPage5::OnProplistExpandAll()
{
	static BOOL bExpanded = FALSE;

	m_wndPropList.ExpandAll(!bExpanded);

	m_btnExpandAll.SetWindowText(bExpanded ? _T("Expand &All") : _T("Collapse &All"));

	bExpanded = !bExpanded;
}

void CPage5::OnProplistCategorized()
{
	UpdateData();

	// <snippet22>
	m_wndPropList.SetAlphabeticMode(!m_bPropListCategorized);
	// </snippet22>
	m_btnExpandAll.EnableWindow(m_bPropListCategorized);
}

void CPage5::OnProplistCategorized2()
{
	UpdateData();
	// <snippet23>
	// BOOL m_bShowDragContext
	m_wndPropList.SetShowDragContext(m_bShowDragContext);
	// </snippet23>
}

void CPage5::OnResetValues()
{
	// <snippet24>
	// restore original values of the properties
	m_wndPropList.ResetOriginalValues();
	// </snippet24>
}

void CPage5::OnMarkChanged()
{
	UpdateData();
	// <snippet25>
	m_wndPropList.MarkModifiedProperties(m_bMarkChanged);
	// </snippet25>
}

void CPage5::OnHideFontProps()
{
	UpdateData();

	ASSERT_VALID(pGroupFont);
	pGroupFont->Show(!m_bHideFontProps);
}

