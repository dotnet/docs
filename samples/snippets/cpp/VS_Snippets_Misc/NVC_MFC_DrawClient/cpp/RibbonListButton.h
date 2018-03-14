// This is a part of the Microsoft Foundation Classes C++ library.
// Copyright (c) Microsoft Corporation.  All rights reserved.
//
// This source code is only intended as a supplement to the
// Microsoft Foundation Classes Reference and related
// electronic documentation provided with the library.
// See these sources for detailed information regarding the
// Microsoft Foundation Classes product.

#pragma once

class CRibbonListButton : public CMFCRibbonGallery
{
	DECLARE_DYNCREATE(CRibbonListButton)

	// Construction:
public:
	CRibbonListButton();
	CRibbonListButton(UINT nID, LPCTSTR lpszText, int nSmallImageIndex, int nLargeImageIndex, BOOL    bRightAlignedText = TRUE);
	CRibbonListButton(UINT nID, LPCTSTR lpszText, int nSmallImageIndex, int nLargeImageIndex, UINT uiImagesPaletteResID, int cxPaletteImage, const CStringArray& arLabels, BOOL bRightAlignedText = TRUE);

	virtual ~CRibbonListButton();

public:
	void AddGroup(LPCTSTR lpszGroupName, UINT uiImagesPaletteResID, int cxPaletteImage, const CStringArray& arLabels);

	virtual void Clear();

	void SetRightAlignedText(BOOL bSet = TRUE);

protected:
	virtual CSize GetIconSize() const;
	virtual void OnDrawPaletteIcon(CDC* pDC, CRect rectIcon, int nIconIndex, CMFCRibbonGalleryIcon* pIcon, COLORREF clrText);
	virtual void CopyFrom(const CMFCRibbonBaseElement& src);
	virtual void OnShowPopupMenu();

	virtual BOOL IsItemMenuLook() const
	{
		return m_bRightAlignedText;
	}

	void RecalcTextSizes(CDC* pDC);

protected:
	CMFCToolBarImages m_listImages;
	CStringArray m_arLabels;
	CSize m_sizeMargins;
	BOOL m_bRightAlignedText;
	CSize m_sizeMaxText;
};

