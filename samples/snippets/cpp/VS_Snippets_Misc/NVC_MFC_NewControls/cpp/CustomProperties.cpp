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

#ifdef _DEBUG
#undef THIS_FILE
static char THIS_FILE[]=__FILE__;
#define new DEBUG_NEW
#endif

////////////////////////////////////////////////////////////////////////////////
// CCheckBoxProp class

CCheckBoxProp::CCheckBoxProp(const CString& strName, BOOL bCheck, LPCTSTR lpszDescr, DWORD dwData) :
	CMFCPropertyGridProperty(strName, COleVariant((long)bCheck), lpszDescr, dwData)
{
	m_rectCheck.SetRectEmpty();
}

void CCheckBoxProp::OnDrawName(CDC* pDC, CRect rect)
{
	m_rectCheck = rect;
	m_rectCheck.DeflateRect(1, 1);

	m_rectCheck.right = m_rectCheck.left + m_rectCheck.Height();

	rect.left = m_rectCheck.right + 1;

	CMFCPropertyGridProperty::OnDrawName(pDC, rect);

	OnDrawCheckBox(pDC, m_rectCheck, (m_varValue.boolVal));
}

void CCheckBoxProp::OnClickName(CPoint point)
{
	if (m_bEnabled && m_rectCheck.PtInRect(point))
	{
		m_varValue.boolVal = !(m_varValue.boolVal);
		m_pWndList->InvalidateRect(m_rectCheck);
	}
}

BOOL CCheckBoxProp::OnDblClk(CPoint point)
{
	if (m_bEnabled && m_rectCheck.PtInRect(point))
	{
		return TRUE;
	}

	m_varValue.boolVal = !(m_varValue.boolVal);
	m_pWndList->InvalidateRect(m_rectCheck);
	return TRUE;
}

void CCheckBoxProp::OnDrawCheckBox(CDC * pDC, CRect rect, BOOL bChecked)
{
	COLORREF clrTextOld = pDC->GetTextColor();

	CMFCVisualManager::GetInstance()->OnDrawCheckBox(pDC, rect, FALSE, bChecked, m_bEnabled);

	pDC->SetTextColor(clrTextOld);
}

BOOL CCheckBoxProp::PushChar(UINT nChar)
{
	if (nChar == VK_SPACE)
	{
		OnDblClk(CPoint(-1, -1));
	}

	return TRUE;
}

////////////////////////////////////////////////////////////////////////////////
// CPasswordProp class

const TCHAR cPassword = _T('*');

CPasswordProp::CPasswordProp(const CString& strName, const CString& strPassword, LPCTSTR lpszDescr, DWORD dwData)
: CMFCPropertyGridProperty(strName, (LPCTSTR) strPassword, lpszDescr, dwData)
{
}

CWnd* CPasswordProp::CreateInPlaceEdit(CRect rectEdit, BOOL& bDefaultFormat)
{
	CEdit* pWndEdit = new CEdit;

	DWORD dwStyle = WS_VISIBLE | WS_CHILD | ES_AUTOHSCROLL | ES_PASSWORD;

	if (!m_bEnabled || !m_bAllowEdit)
	{
		dwStyle |= ES_READONLY;
	}

	pWndEdit->Create(dwStyle, rectEdit, m_pWndList, AFX_PROPLIST_ID_INPLACE);
	pWndEdit->SetPasswordChar(cPassword);

	bDefaultFormat = TRUE;
	return pWndEdit;
}

CString CPasswordProp::FormatProperty()
{
	CString strVal = (LPCTSTR)(_bstr_t)m_varValue;

	for (int i = 0; i < strVal.GetLength(); i++)
	{
		strVal.SetAt(i, cPassword);
	}

	return strVal;
}

/////////////////////////////////////////////////////////////////////////////
// CPropSliderCtrl

CPropSliderCtrl::CPropSliderCtrl(CSliderProp* pProp, COLORREF clrBack)
{
	m_clrBack = clrBack;
	m_brBackground.CreateSolidBrush(m_clrBack);
	m_pProp = pProp;
}

CPropSliderCtrl::~CPropSliderCtrl()
{
}

BEGIN_MESSAGE_MAP(CPropSliderCtrl, CSliderCtrl)
	//{{AFX_MSG_MAP(CPropSliderCtrl)
	ON_WM_CTLCOLOR_REFLECT()
	ON_WM_HSCROLL_REFLECT()
	//}}AFX_MSG_MAP
END_MESSAGE_MAP()

/////////////////////////////////////////////////////////////////////////////
// CPropSliderCtrl message handlers

HBRUSH CPropSliderCtrl::CtlColor(CDC* pDC, UINT /*nCtlColor*/)
{
	pDC->SetBkColor(m_clrBack);
	return m_brBackground;
}

void CPropSliderCtrl::HScroll(UINT /*nSBCode*/, UINT /*nPos*/)
{
	ASSERT_VALID(m_pProp);

	m_pProp->OnUpdateValue();
	m_pProp->Redraw();
}

////////////////////////////////////////////////////////////////////////////////
// CSliderProp class

CSliderProp::CSliderProp(const CString& strName, long nValue, LPCTSTR lpszDescr, DWORD dwData) :
	CMFCPropertyGridProperty(strName, nValue, lpszDescr, dwData)
{
}

CWnd* CSliderProp::CreateInPlaceEdit(CRect rectEdit, BOOL& bDefaultFormat)
{
	CPropSliderCtrl* pWndSlider = new CPropSliderCtrl(this, m_pWndList->GetBkColor());

	rectEdit.left += rectEdit.Height() + 5;

	pWndSlider->Create(WS_VISIBLE | WS_CHILD, rectEdit, m_pWndList, AFX_PROPLIST_ID_INPLACE);
	pWndSlider->SetPos(m_varValue.lVal);

	bDefaultFormat = TRUE;
	return pWndSlider;
}

BOOL CSliderProp::OnUpdateValue()
{
	ASSERT_VALID(this);
	ASSERT_VALID(m_pWndInPlace);
	ASSERT_VALID(m_pWndList);
	ASSERT(::IsWindow(m_pWndInPlace->GetSafeHwnd()));

	long lCurrValue = m_varValue.lVal;

	CSliderCtrl* pSlider = (CSliderCtrl*) m_pWndInPlace;

	m_varValue = (long) pSlider->GetPos();

	if (lCurrValue != m_varValue.lVal)
	{
		m_pWndList->OnPropertyChanged(this);
	}

	return TRUE;
}

////////////////////////////////////////////////////////////////////////////////
// CBoundedNumberPairProp class

CBoundedNumberPairProp::CBoundedNumberPairProp(const CString& strGroupName, int nMinValue1, int nMaxValue1, int nMinValue2, int nMaxValue2, DWORD_PTR dwData, BOOL bIsValueList) :
	CMFCPropertyGridProperty(strGroupName, dwData, bIsValueList)
{
	m_nMinValue1 = nMinValue1;
	m_nMaxValue1 = nMaxValue1;
	m_nMinValue2 = nMinValue2;
	m_nMaxValue2 = nMaxValue2;
}

BOOL CBoundedNumberPairProp::OnUpdateValue()
{
	ASSERT_VALID(this);
	ASSERT_VALID(m_pWndInPlace);
	ASSERT_VALID(m_pWndList);
	ASSERT(::IsWindow(m_pWndInPlace->GetSafeHwnd()));

	CString strText;
	m_pWndInPlace->GetWindowText(strText);

	BOOL bIsChanged = FormatProperty() != strText;

	if (bIsChanged)
	{
		CString strDelimeter(_T(","));

		for (int i = 0; !strText.IsEmpty() && i < GetSubItemsCount(); i++)
		{
			CString strItem = strText.SpanExcluding(strDelimeter);
			if (strItem.GetLength() + 1 > strText.GetLength())
			{
				strText.Empty();
			}
			else
			{
				strText = strText.Mid(strItem.GetLength() + 1);
			}
			strItem.TrimLeft();
			strItem.TrimRight();

			int nItem = _ttoi(strItem);
			if ((i == 0) && ((nItem < m_nMinValue1) || (nItem > m_nMaxValue1)))
			{
				static BOOL bRecursedHere = FALSE;
				if (bRecursedHere)
					return TRUE;
				bRecursedHere = TRUE;

				CString strMessage;
				strMessage.Format(_T("Height value must be between %d and %d."), m_nMinValue1, m_nMaxValue1);
				AfxMessageBox(strMessage);

				bRecursedHere = FALSE;
				return FALSE;
			}
			else if ((i == 1) && ((nItem < m_nMinValue2) || (nItem > m_nMaxValue2)))
			{
				static BOOL bRecursedHere = FALSE;
				if (bRecursedHere)
					return TRUE;
				bRecursedHere = TRUE;

				CString strMessage;
				strMessage.Format(_T("Width value must be between %d and %d."), m_nMinValue2, m_nMaxValue2);
				AfxMessageBox(strMessage);

				bRecursedHere = FALSE;
				return FALSE;
			}
		}

		return CMFCPropertyGridProperty::OnUpdateValue();
	}

	return TRUE;
}

////////////////////////////////////////////////////////////////////////////////
// CBoundedNumberSubProp class

CBoundedNumberSubProp::CBoundedNumberSubProp(const CString& strName, const COleVariant& varValue, int nMinValue, int nMaxValue, LPCTSTR lpszDescr) :
	CMFCPropertyGridProperty(strName, varValue, lpszDescr)
{
	m_nMinValue = nMinValue;
	m_nMaxValue = nMaxValue;
}

BOOL CBoundedNumberSubProp::OnUpdateValue()
{
	ASSERT_VALID(this);
	ASSERT_VALID(m_pWndInPlace);
	ASSERT_VALID(m_pWndList);
	ASSERT(::IsWindow(m_pWndInPlace->GetSafeHwnd()));

	BOOL bRet = TRUE;
	CString strText;
	m_pWndInPlace->GetWindowText(strText);

	BOOL bIsChanged = FormatProperty() != strText;
	if (bIsChanged)
	{
		int nItem = _ttoi(strText);
		if ((nItem < m_nMinValue) || (nItem > m_nMaxValue))
		{
			static BOOL bRecursedHere = FALSE;
			if (bRecursedHere)
				return TRUE;
			bRecursedHere = TRUE;

			CString strMessage;
			strMessage.Format(_T("Value must be between %d and %d."), m_nMinValue, m_nMaxValue);
			AfxMessageBox(strMessage);

			bRecursedHere = FALSE;
			return FALSE;
		}

		bRet = CMFCPropertyGridProperty::OnUpdateValue();

		if (m_pParent != NULL)
		{
			m_pWndList->OnPropertyChanged(m_pParent);
		}
	}

	return bRet;
}

////////////////////////////////////////////////////////////////////////////////
// CIconListProp class

const int nIconMargin = 3;

CIconListProp::CIconListProp(const CString& strName, const CImageList& imageListIcons, int nSelectedIcon, CStringList* plstIconNames, LPCTSTR lpszDescr, DWORD dwData) :
	CMFCPropertyGridProperty(strName, (long) nSelectedIcon, lpszDescr, dwData)
{
	m_imageListIcons.CreateFromImageList(imageListIcons);
	m_imageListIcons.SetTransparentColor(::GetSysColor(COLOR_3DFACE));

	if (plstIconNames != NULL)
	{
		m_lstIconNames.AddTail(plstIconNames);
		ASSERT(m_lstIconNames.GetCount() == m_imageListIcons.GetCount());
	}

	for (int i = 0; i < m_imageListIcons.GetCount(); i++)
	{
		CString strItem;
		strItem.Format(_T("%d"), i);

		AddOption(strItem);
	}

	AllowEdit(FALSE);
}

CComboBox* CIconListProp::CreateCombo(CWnd* pWndParent, CRect rect)
{
	rect.bottom = rect.top + 400;

	CIconCombo* pWndCombo = new CIconCombo(m_imageListIcons, m_lstIconNames);
	if (!pWndCombo->Create(WS_CHILD | CBS_NOINTEGRALHEIGHT | CBS_DROPDOWNLIST | WS_VSCROLL | CBS_OWNERDRAWFIXED | CBS_HASSTRINGS, rect, pWndParent, AFX_PROPLIST_ID_INPLACE))
	{
		delete pWndCombo;
		return NULL;
	}

	return pWndCombo;
}

void CIconListProp::OnDrawValue(CDC* pDC, CRect rect)
{
	ASSERT_VALID(m_pWndList);
	ASSERT_VALID(pDC);

	CString strVal = (LPCTSTR)(_bstr_t) m_varValue;
	if (strVal.IsEmpty() || m_imageListIcons.GetCount() == 0)
	{
		return;
	}

	int nIndex = _ttoi(strVal);

	if (nIndex < 0)
	{
		return;
	}

	COLORREF clrTextOld = pDC->GetTextColor();

	CFont* pOldFont = pDC->SelectObject(IsModified() && m_pWndList->IsMarkModifiedProperties() ? &m_pWndList->GetBoldFont() : m_pWndList->GetFont());

	CRect rectImage = rect;
	rectImage.right = rectImage.left + rectImage.Height();
	rectImage.DeflateRect(1, 1);

	CAfxDrawState ds;
	m_imageListIcons.PrepareDrawImage(ds, rectImage.Size());
	m_imageListIcons.Draw(pDC, rectImage.left, rectImage.top, nIndex);
	m_imageListIcons.EndDrawImage(ds);

	if (!m_lstIconNames.IsEmpty())
	{
		CString str = m_lstIconNames.GetAt(m_lstIconNames.FindIndex(nIndex));

		rect.left = rectImage.right + 2 * nIconMargin;

		pDC->DrawText(str, rect, DT_SINGLELINE | DT_VCENTER);
	}

	pDC->SetTextColor(clrTextOld);
	pDC->SelectObject(pOldFont);

	m_bValueIsTruncated = FALSE;
}

CWnd* CIconListProp::CreateInPlaceEdit(CRect rectEdit, BOOL& bDefaultFormat)
{
	CWnd* pWnd = CMFCPropertyGridProperty::CreateInPlaceEdit(rectEdit, bDefaultFormat);
	if (pWnd != NULL)
	{
		pWnd->ShowWindow(SW_HIDE);
	}

	return pWnd;
}

/////////////////////////////////////////////////////////////////////////////
// CIconCombo

CIconCombo::CIconCombo(CMFCToolBarImages& imageListIcons, CStringList& lstIconNames) :
	m_imageListIcons(imageListIcons), m_lstIconNames(lstIconNames)
{
}

CIconCombo::~CIconCombo()
{
}

BEGIN_MESSAGE_MAP(CIconCombo, CComboBox)
	//{{AFX_MSG_MAP(CIconCombo)
	ON_WM_DRAWITEM()
	ON_WM_MEASUREITEM()
	//}}AFX_MSG_MAP
END_MESSAGE_MAP()

/////////////////////////////////////////////////////////////////////////////
// CIconCombo message handlers

void CIconCombo::OnDrawItem(int /*nIDCtl*/, LPDRAWITEMSTRUCT lpDIS)
{
	CDC* pDC = CDC::FromHandle(lpDIS->hDC);
	ASSERT_VALID(pDC);

	CRect rect = lpDIS->rcItem;
	int nIcon = lpDIS->itemID;

	HBRUSH brBackground;
	COLORREF clText;

	if (lpDIS->itemState & ODS_SELECTED)
	{
		brBackground = GetSysColorBrush(COLOR_HIGHLIGHT);
		clText = afxGlobalData.clrTextHilite;
	}
	else
	{
		brBackground = GetSysColorBrush(COLOR_WINDOW);
		clText = afxGlobalData.clrWindowText;
	}

	if (lpDIS->itemAction &(ODA_DRAWENTIRE | ODA_SELECT))
	{
		::FillRect(lpDIS->hDC, &rect, brBackground);
	}

	if (nIcon < 0)
	{
		return;
	}

	CAfxDrawState ds;
	m_imageListIcons.PrepareDrawImage(ds);
	m_imageListIcons.Draw(pDC, rect.left + nIconMargin, rect.top + nIconMargin, nIcon);
	m_imageListIcons.EndDrawImage(ds);

	if (!m_lstIconNames.IsEmpty())
	{
		CString str = m_lstIconNames.GetAt(m_lstIconNames.FindIndex(nIcon));
		CFont* pOldFont = pDC->SelectObject(&afxGlobalData.fontRegular);

		pDC->SetBkMode(TRANSPARENT);
		pDC->SetTextColor(clText);

		CRect rectText = rect;
		rectText.left += m_imageListIcons.GetImageSize().cx + 2 * nIconMargin;

		pDC->DrawText(str, rectText, DT_SINGLELINE | DT_VCENTER);

		pDC->SelectObject(pOldFont);
	}
}

void CIconCombo::OnMeasureItem(int /*nIDCtl*/, LPMEASUREITEMSTRUCT lpMeasureItemStruct)
{
	int nTextWidth = 0;
	int nTextHeight = 0;

	if (!m_lstIconNames.IsEmpty())
	{
		nTextHeight = afxGlobalData.GetTextHeight();

		CClientDC dc(this);
		CFont* pOldFont = dc.SelectObject(&afxGlobalData.fontRegular);

		for (POSITION pos = m_lstIconNames.GetHeadPosition(); pos != NULL;)
		{
			CString str = m_lstIconNames.GetNext(pos);

			nTextWidth = max(nTextWidth, dc.GetTextExtent(str).cx + nIconMargin);
		}

		dc.SelectObject(pOldFont);
	}

	lpMeasureItemStruct->itemWidth = m_imageListIcons.GetImageSize().cx + nTextWidth + 2 * nIconMargin;
	lpMeasureItemStruct->itemHeight = max(nTextHeight, m_imageListIcons.GetImageSize().cy + 2 * nIconMargin);
}

////////////////////////////////////////////////////////////////////////////////
// CComboBoxExProp class

CComboBoxExProp::CComboBoxExProp(const CString& strName, const CString& strValue, LPCTSTR lpszDescr, DWORD dwData, CImageList* pImageList) :
	CMFCPropertyGridProperty(strName, (LPCTSTR) strValue, lpszDescr, dwData), m_pImageList(pImageList)
{
}

CComboBox* CComboBoxExProp::CreateCombo(CWnd* pWndParent, CRect rect)
{
	rect.bottom = rect.top + 400;

	CComboBoxEx* pWndCombo = new CComboBoxEx;

	if (!pWndCombo->Create(WS_CHILD | CBS_DROPDOWNLIST | WS_VSCROLL, rect, pWndParent, AFX_PROPLIST_ID_INPLACE))
	{
		delete pWndCombo;
		return NULL;
	}

	if (m_pImageList != NULL)
	{
		pWndCombo->SetImageList(m_pImageList);
	}

	return pWndCombo;
}

BOOL CComboBoxExProp::OnEdit(LPPOINT lptClick)
{
	if (!CMFCPropertyGridProperty::OnEdit(lptClick))
	{
		return FALSE;
	}

	CComboBoxEx* pWndComboEx = DYNAMIC_DOWNCAST(CComboBoxEx, m_pWndCombo);
	if (pWndComboEx == NULL)
	{
		ASSERT(FALSE);
		return FALSE;
	}

	pWndComboEx->ResetContent();

	int i = 0;

	COMBOBOXEXITEM item;
	memset(&item, 0, sizeof(item));

	item.mask = CBEIF_IMAGE | CBEIF_INDENT | CBEIF_SELECTEDIMAGE | CBEIF_TEXT;

	for (POSITION pos = m_lstOptions.GetHeadPosition(); pos != NULL; i++)
	{
		CString strItem = m_lstOptions.GetNext(pos);

		item.iItem = i;
		item.iSelectedImage = item.iImage = m_lstIcons [i];
		item.iIndent = m_lstIndents [i];
		item.pszText = (LPTSTR)(LPCTSTR) strItem;
		item.cchTextMax = strItem.GetLength();

		pWndComboEx->InsertItem(&item);
	}

	return TRUE;
}

BOOL CComboBoxExProp::AddOption(LPCTSTR lpszOption, int nIcon, int nIndent)
{
	if (!CMFCPropertyGridProperty::AddOption(lpszOption))
	{
		return FALSE;
	}

	m_lstIcons.Add(nIcon);
	m_lstIndents.Add(nIndent);

	return TRUE;
}

COwnerDrawDescrProp::COwnerDrawDescrProp(const CString& strName, const COleVariant& varValue) : CMFCPropertyGridProperty(strName, varValue)
{
}

void COwnerDrawDescrProp::OnDrawDescription(CDC* pDC, CRect rect)
{
	// <snippet37>
	// CRect rect
	// CDC* pDC
	CDrawingManager dm(*pDC);
	// The last parameter is the angle that specifies the direction of the color gradient.
	dm.FillGradient2(rect, RGB(102, 200, 238), RGB(0, 129, 185), 45);
	// </snippet37>

	CFont* pOldFont = pDC->SelectObject(&afxGlobalData.fontBold);

	CString strText = _T("Custom Text");

	pDC->SetTextColor(RGB(0, 65, 117));
	pDC->DrawText(strText, rect, DT_CENTER | DT_VCENTER | DT_SINGLELINE);

	rect.OffsetRect(-2, -2);

	pDC->SetTextColor(RGB(155, 251, 255));
	pDC->DrawText(strText, rect, DT_CENTER | DT_VCENTER | DT_SINGLELINE);

	pDC->SelectObject(pOldFont);
}

CTwoButtonsProp::CTwoButtonsProp(const CString& strName, const COleVariant& varValue) : CMFCPropertyGridProperty(strName, varValue)
{
	CBitmap bmp;
	bmp.LoadBitmap(IDB_BUTTONS);

	m_images.Create(14, 14, ILC_MASK | ILC_COLOR8, 0, 0);
	m_images.Add(&bmp, RGB(255, 0, 255));
}

void CTwoButtonsProp::AdjustButtonRect()
{
	CMFCPropertyGridProperty::AdjustButtonRect();
	m_rectButton.left -= m_rectButton.Width();
}

void CTwoButtonsProp::OnClickButton(CPoint point)
{
	BOOL bIsLeft = point.x < m_rectButton.CenterPoint().x;
	AfxMessageBox(bIsLeft ? _T("Left button clicked") : _T("Right button clicked"));
}

void CTwoButtonsProp::OnDrawButton(CDC* pDC, CRect rectButton)
{
	for (int i = 0; i < 2; i++)
	{
		CMFCToolBarButton button;

		CRect rect = rectButton;

		if (i == 0)
		{
			rect.right = rect.left + rect.Width() / 2;
		}
		else
		{
			rect.left = rect.right - rect.Width() / 2;
		}

		CMFCVisualManager::AFX_BUTTON_STATE state = CMFCVisualManager::ButtonsIsHighlighted;

		CMFCVisualManager::GetInstance()->OnFillButtonInterior(pDC, &button, rect, state);

		m_images.Draw(pDC, i, CPoint(rect.left, rect.top), ILD_NORMAL);

		CMFCVisualManager::GetInstance()->OnDrawButtonBorder(pDC, &button, rect, state);
	}
}

CCustomDlgProp::CCustomDlgProp(const CString& strName, const COleVariant& varValue) : CMFCPropertyGridProperty(strName, varValue)
{
}

void CCustomDlgProp::OnClickButton(CPoint /*point*/)
{
	AfxMessageBox(_T("Show your dialog here..."));
	SetValue(_T("New value"));
}


