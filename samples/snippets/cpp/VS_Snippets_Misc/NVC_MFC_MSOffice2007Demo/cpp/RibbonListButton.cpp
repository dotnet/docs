// This MFC Samples source code demonstrates using MFC Microsoft Office Fluent User Interface 
// (the "Fluent UI") and is provided only as referential material to supplement the 
// Microsoft Foundation Classes Reference and related electronic documentation 
// included with the MFC C++ library software.  
// License terms to copy, use or distribute the Fluent UI are available separately.  
// To learn more about our Fluent UI licensing program, please visit 
// http://msdn.microsoft.com/officeui.
//
// Copyright (C) Microsoft Corporation
// All rights reserved.

#include "stdafx.h"
#include "RibbonListButton.h"

#ifdef _DEBUG
#define new DEBUG_NEW
#undef THIS_FILE
static char THIS_FILE[] = __FILE__;
#endif

#pragma warning(disable:4100)

const int nImageMargin = 4;
const int nCheckMargin = 2;
const int nTextOffsetX = 11;
const int nTextOffsetY = 2;

const int nBorderMarginX = 1;
const int nBorderMarginY = 3;

/////////////////////////////////////////////////////////////////////////////
// CRibbonListButton

IMPLEMENT_DYNCREATE(CRibbonListButton, CMFCRibbonGallery)

CRibbonListButton::CRibbonListButton()
{
	m_sizeMargins = CSize(2, 2);
}

CRibbonListButton::CRibbonListButton(UINT nID, LPCTSTR lpszText, int nSmallImageIndex, int nLargeImageIndex, BOOL bRightAlignedText) :
	CMFCRibbonGallery(nID, lpszText, nSmallImageIndex, nLargeImageIndex, CSize(0, 0), 0, TRUE)
{
	SetButtonMode(TRUE);
	SetRightAlignedText(bRightAlignedText);

	m_sizeMargins = CSize(2, 2);
	m_sizeMaxText = CSize(0, 0);
}

CRibbonListButton::CRibbonListButton(UINT nID, LPCTSTR lpszText, int nSmallImageIndex, int nLargeImageIndex, UINT uiImagesPaletteResID,
		int cxPaletteImage, const CStringArray& arLabels, BOOL bRightAlignedText) :
	CMFCRibbonGallery(nID, lpszText, nSmallImageIndex, nLargeImageIndex, CSize(0, 0), 0, TRUE)
{
	SetButtonMode(TRUE);
	SetRightAlignedText(bRightAlignedText);

	m_listImages.Load(uiImagesPaletteResID);

	BITMAP bmp;
	GetObject(m_listImages.GetImageWell(), sizeof(BITMAP), &bmp);

	m_listImages.SetImageSize(CSize(cxPaletteImage, bmp.bmHeight), TRUE);
	m_imagesPalette.SetImageSize(m_listImages.GetImageSize());
	m_arLabels.Copy(arLabels);

	m_nIcons = (int) m_arLabels.GetSize();
	m_sizeMargins = CSize(2, 2);
	m_sizeMaxText = CSize(0, 0);
}

CRibbonListButton::~CRibbonListButton()
{
}

void CRibbonListButton::SetRightAlignedText(BOOL bSet)
{
	if (m_bRightAlignedText != bSet)
	{
		m_bRightAlignedText = bSet;

		if (m_bRightAlignedText)
		{
			SetIconsInRow(1);
		}
	}
}

void CRibbonListButton::AddGroup(LPCTSTR lpszGroupName, UINT uiImagesPaletteResID, int cxPaletteImage, const CStringArray& arLabels)
{
	CMFCRibbonGallery::AddGroup(lpszGroupName, (int) arLabels.GetSize());

	if (uiImagesPaletteResID != 0)
	{
		if (m_listImages.GetCount() == 0)
		{
			m_listImages.Load(uiImagesPaletteResID);

			BITMAP bmp;
			GetObject(m_listImages.GetImageWell(), sizeof(BITMAP), &bmp);

			m_listImages.SetImageSize(CSize(cxPaletteImage, bmp.bmHeight), TRUE);
			m_imagesPalette.SetImageSize(m_listImages.GetImageSize());
		}
		else
		{
			ASSERT(cxPaletteImage == m_listImages.GetImageSize().cx);
			m_listImages.Load(uiImagesPaletteResID, NULL, TRUE);
		}
	}

	if (m_arLabels.GetSize() == 0)
	{
		m_arLabels.Copy(arLabels);
	}
	else
	{
		m_arLabels.Append(arLabels);
	}

	m_nIcons = (int) m_arLabels.GetSize();

	RemoveAll();
	m_sizeMaxText = CSize(0, 0);
}

void CRibbonListButton::Clear()
{
	CMFCRibbonGallery::Clear();

	m_arLabels.RemoveAll();
	m_sizeMaxText = CSize(0, 0);
}

void CRibbonListButton::OnShowPopupMenu()
{
	ASSERT_VALID(this);

	CMFCRibbonBaseElement::OnShowPopupMenu();

	if (m_sizeMaxText == CSize(0, 0))
	{
		CMFCRibbonBar* pRibbonBar = GetTopLevelRibbonBar();
		ASSERT_VALID(pRibbonBar);

		CClientDC dc(pRibbonBar);

		CFont* pOldFont = dc.SelectObject(pRibbonBar->GetFont());
		ASSERT(pOldFont != NULL);

		int i = 0;

		for (i = 0; i < m_arLabels.GetSize(); i++)
		{
			CSize szText = dc.GetTextExtent(m_arLabels [i]);

			m_sizeMaxText.cx = max(m_sizeMaxText.cx, szText.cx);
			m_sizeMaxText.cy = max(m_sizeMaxText.cy, szText.cy);
		}

		const int cxImage = m_listImages.GetImageSize().cx;

		for (i = 0; i < m_arSubItems.GetSize(); i++)
		{
			CMFCRibbonBaseElement* pButton = m_arSubItems [i];
			ASSERT_VALID(pButton);

			CString strText = pButton->GetText();
			CSize szText = dc.GetTextExtent(strText);

			m_sizeMaxText.cx = max(m_sizeMaxText.cx, szText.cx - cxImage);
		}

		dc.SelectObject(pOldFont);
	}

	CMFCRibbonGallery::OnShowPopupMenu();
}

CSize CRibbonListButton::GetIconSize() const
{
	CSize size = CMFCRibbonGallery::GetIconSize();

	if (m_bRightAlignedText)
	{
		if (size.cx > 0)
		{
			size.cx += 2 *(m_sizeMargins.cx + nCheckMargin) - nImageMargin + nTextOffsetX + m_sizeMaxText.cx;
		}
		else
		{
			size.cx = m_sizeMaxText.cx + 2 *(m_sizeMargins.cy + nCheckMargin + nTextOffsetX);
		}

		if (size.cy > 0)
		{
			size.cy += 2 *(m_sizeMargins.cy - nImageMargin + nCheckMargin);
		}
		else
		{
			size.cy = m_sizeMaxText.cy + 2 * m_sizeMargins.cy;
		}
	}
	else
	{
		size.cy += nTextOffsetY + m_sizeMaxText.cy;
	}

	return size;
}

void CRibbonListButton::OnDrawPaletteIcon( CDC* pDC, CRect rectIcon, int nIconIndex, CMFCRibbonGalleryIcon* pIcon, COLORREF clrText)
{
	ASSERT_VALID(this);
	ASSERT_VALID(pDC);
	ASSERT_VALID(pIcon);
	ASSERT(nIconIndex >= 0);
	ASSERT(nIconIndex < m_nIcons);

	BOOL bChecked     = pIcon->IsChecked();
	BOOL bHighlighted = pIcon->IsHighlighted();

	CRect rectText(0, 0, 0, 0);

	if (m_bRightAlignedText)
	{
		if (!m_bSmallIcons)
		{
			rectIcon.DeflateRect(nCheckMargin, nCheckMargin, nImageMargin, nCheckMargin);
		}

		CRect rect(rectIcon);
		rect.right  = rect.left + m_listImages.GetImageSize().cx + m_sizeMargins.cx * 2;

		if (bChecked)
		{
			CMFCVisualManager::GetInstance()->OnDrawRibbonMenuCheckFrame(pDC, this, rect);
		}

		if (0 <= nIconIndex && nIconIndex < m_listImages.GetCount())
		{
			m_listImages.DrawEx(pDC, rect, nIconIndex, CMFCToolBarImages::ImageAlignHorzCenter, CMFCToolBarImages::ImageAlignVertCenter);
		}
		else if (bChecked)
		{
			CMFCToolBarMenuButton dummy;
			CMFCVisualManager::GetInstance()->OnDrawMenuCheck(pDC, &dummy, rect, bHighlighted, FALSE);
		}

		rectText = rect;
		rectText.left  = rectText.right + nTextOffsetX;
		rectText.right = rectIcon.right;
	}
	else
	{
		if (!m_bSmallIcons)
		{
			rectIcon.DeflateRect(nImageMargin, nImageMargin);
		}

		CRect rect(rectIcon);
		rect.bottom = rect.top + m_listImages.GetImageSize().cy;

		if (0 <= nIconIndex && nIconIndex < m_listImages.GetCount())
		{
			m_listImages.DrawEx(pDC, rect, nIconIndex, CMFCToolBarImages::ImageAlignHorzCenter, CMFCToolBarImages::ImageAlignVertTop);
		}

		rectText = rect;
		rectText.top    = rectText.bottom + nTextOffsetY;
		rectText.bottom = rectIcon.bottom;
	}

	if (!rectText.IsRectEmpty())
	{
		COLORREF clrOld = (COLORREF)-1;
		if (clrText != (COLORREF)-1)
		{
			clrOld = pDC->SetTextColor(clrText);
		}

		CString strText = m_arLabels[nIconIndex];
		pDC->DrawText(strText, rectText, m_bRightAlignedText ? DT_VCENTER | DT_SINGLELINE | DT_LEFT : DT_TOP | DT_SINGLELINE | DT_CENTER | DT_END_ELLIPSIS);

		if (clrText != (COLORREF)-1)
		{
			pDC->SetTextColor(clrOld);
		}
	}
}

void CRibbonListButton::CopyFrom(const CMFCRibbonBaseElement& s)
{
	ASSERT_VALID(this);

	CMFCRibbonGallery::CopyFrom(s);
	CRibbonListButton& src = (CRibbonListButton&) s;

	src.m_listImages.CopyTo(m_listImages);
	m_imagesPalette.SetImageSize (m_listImages.GetImageSize ());

	m_arLabels.RemoveAll();
	m_arLabels.Copy(src.m_arLabels);

	m_sizeMargins = src.m_sizeMargins;
	m_bRightAlignedText = src.m_bRightAlignedText;
	m_sizeMaxText = src.m_sizeMaxText;
}

IMPLEMENT_DYNCREATE(CRibbonListFontButton, CMFCRibbonGallery)

CRibbonListFontButton::CRibbonListFontButton()
{
	m_sizeMargins = CSize(2, 2);
}

CRibbonListFontButton::CRibbonListFontButton(UINT nID, LPCTSTR lpszText, int nSmallImageIndex, int nLargeImageIndex) :
	CMFCRibbonGallery(nID, lpszText, nSmallImageIndex, nLargeImageIndex, CSize(0, 0), 0, TRUE)
{
	SetButtonMode(TRUE);
	SetIconsInRow(1);

	m_sizeMargins = CSize(2, 2);
	m_sizeMaxText = CSize(0, 0);
}

CRibbonListFontButton::CRibbonListFontButton(UINT nID, LPCTSTR lpszText, int nSmallImageIndex, int nLargeImageIndex, UINT uiImagesPaletteResID, int cxPaletteImage, const XItems& arItems) :
	CMFCRibbonGallery(nID, lpszText, nSmallImageIndex, nLargeImageIndex, CSize(0, 0), 0, TRUE)
{
	SetButtonMode(TRUE);
	SetIconsInRow(1);

	m_listImages.Load(uiImagesPaletteResID);

	BITMAP bmp;
	GetObject(m_listImages.GetImageWell(), sizeof(BITMAP), &bmp);

	m_listImages.SetImageSize(CSize(cxPaletteImage, bmp.bmHeight), TRUE);
	m_imagesPalette.SetImageSize(m_listImages.GetImageSize());

	m_arItems.Copy(arItems);
	m_nIcons = (int) m_arItems.GetSize();

	m_sizeMargins = CSize(2, 2);
	m_sizeMaxText = CSize(0, 0);
}

CRibbonListFontButton::~CRibbonListFontButton()
{
}

void CRibbonListFontButton::AddGroup(LPCTSTR lpszGroupName, UINT uiImagesPaletteResID, int cxPaletteImage, const XItems& arItems)
{
	CMFCRibbonGallery::AddGroup(lpszGroupName, (int) arItems.GetSize());

	if (m_listImages.GetCount() == 0)
	{
		m_listImages.Load(uiImagesPaletteResID);

		BITMAP bmp;
		GetObject(m_listImages.GetImageWell(), sizeof(BITMAP), &bmp);

		m_listImages.SetImageSize(CSize(cxPaletteImage, bmp.bmHeight), TRUE);
		m_imagesPalette.SetImageSize(m_listImages.GetImageSize());
	}
	else
	{
		ASSERT(cxPaletteImage == m_listImages.GetImageSize().cx);
		m_listImages.Load(uiImagesPaletteResID, NULL, TRUE);
	}

	if (m_arItems.GetSize() == 0)
	{
		m_arItems.Copy(arItems);
	}
	else
	{
		m_arItems.Append(arItems);
	}

	m_nIcons = (int) m_arItems.GetSize();

	RemoveAll();
	m_sizeMaxText = CSize(0, 0);
}

void CRibbonListFontButton::Clear()
{
	CMFCRibbonGallery::Clear();

	m_arItems.RemoveAll();
	m_sizeMaxText = CSize(0, 0);
}

void CRibbonListFontButton::OnShowPopupMenu()
{
	ASSERT_VALID(this);

	CMFCRibbonBaseElement::OnShowPopupMenu();

	if (m_sizeMaxText == CSize(0, 0))
	{
		CMFCRibbonBar* pRibbonBar = GetTopLevelRibbonBar();
		ASSERT_VALID(pRibbonBar);

		CClientDC dc(pRibbonBar);
		CFont* pOldFont = dc.SelectObject(&afxGlobalData.fontBold);

		for (int i = 0; i < m_arItems.GetSize(); i++)
		{
			CSize szText = dc.GetTextExtent(m_arItems [i].m_Caption);

			for (int j = 0; j < 2; j++)
			{
				LOGFONT& lf = m_arItems [i].m_Font[j];

				CFont font;
				font.CreateFontIndirect(&lf);
				dc.SelectObject(&font);

				CSize szText2 = dc.GetTextExtent(lf.lfFaceName);

				szText.cx = max(szText.cx, szText2.cx);
				szText.cy += szText2.cy;
			}

			m_arItems [i].m_Height = szText.cy;

			m_sizeMaxText.cx = max(m_sizeMaxText.cx, szText.cx);
			m_sizeMaxText.cy = max(m_sizeMaxText.cy, szText.cy);
		}

		dc.SelectObject(pOldFont);
	}

	CMFCRibbonGallery::OnShowPopupMenu();
}

CSize CRibbonListFontButton::GetIconSize() const
{
	CSize size = CMFCRibbonGallery::GetIconSize();

	size.cx += 2 *(m_sizeMargins.cx + nCheckMargin) - nImageMargin + nTextOffsetX + m_sizeMaxText.cx;
	size.cy += 2 *(m_sizeMargins.cy - nImageMargin + nCheckMargin);

	return size;
}

void CRibbonListFontButton::OnDrawPaletteIcon( CDC* pDC, CRect rectIcon, int nIconIndex, CMFCRibbonGalleryIcon* pIcon, COLORREF clrText)
{
	ASSERT_VALID(this);
	ASSERT_VALID(pDC);
	ASSERT_VALID(pIcon);
	ASSERT(nIconIndex >= 0);
	ASSERT(nIconIndex < m_nIcons);

	CRect rectText(0, 0, 0, 0);

	if (!m_bSmallIcons)
	{
		rectIcon.DeflateRect(nCheckMargin, nCheckMargin, nImageMargin, nCheckMargin);
	}

	CRect rect(rectIcon);
	rect.right  = rect.left + m_listImages.GetImageSize().cx + m_sizeMargins.cx * 2;

	if (0 <= nIconIndex && nIconIndex < m_listImages.GetCount())
	{
		m_listImages.DrawEx(pDC, rect, nIconIndex, CMFCToolBarImages::ImageAlignHorzCenter, CMFCToolBarImages::ImageAlignVertCenter);
	}

	rectText = rect;
	rectText.left  = rectText.right + nTextOffsetX;
	rectText.right = rectIcon.right;

	if (!rectText.IsRectEmpty())
	{
		COLORREF clrOld = (COLORREF)-1;
		if (clrText != (COLORREF)-1)
		{
			clrOld = pDC->SetTextColor(clrText);
		}

		rectText.OffsetRect(0, (rectText.Height() - m_arItems [nIconIndex].m_Height) / 2);

		CFont* pOldFont = pDC->SelectObject(&afxGlobalData.fontBold);

		int nHeight = pDC->DrawText(m_arItems [nIconIndex].m_Caption, rectText, DT_TOP | DT_SINGLELINE | DT_LEFT);
		rectText.OffsetRect(0, nHeight);

		for (int j = 0; j < 2; j++)
		{
			LOGFONT& lf = m_arItems [nIconIndex].m_Font[j];

			CFont font;
			font.CreateFontIndirect(&lf);
			pDC->SelectObject(&font);

			nHeight = pDC->DrawText(lf.lfFaceName, rectText, DT_TOP | DT_SINGLELINE | DT_LEFT);
			rectText.OffsetRect(0, nHeight);
		}

		pDC->SelectObject(pOldFont);

		if (clrText != (COLORREF)-1)
		{
			pDC->SetTextColor(clrOld);
		}
	}
}

void CRibbonListFontButton::CopyFrom(const CMFCRibbonBaseElement& s)
{
	ASSERT_VALID(this);

	CMFCRibbonGallery::CopyFrom(s);

	CRibbonListFontButton& src = (CRibbonListFontButton&) s;

	src.m_listImages.CopyTo(m_listImages);
	m_imagesPalette.SetImageSize (m_listImages.GetImageSize ());


	m_arItems.RemoveAll();
	m_arItems.Copy(src.m_arItems);

	m_sizeMargins = src.m_sizeMargins;
	m_sizeMaxText = src.m_sizeMaxText;
}

