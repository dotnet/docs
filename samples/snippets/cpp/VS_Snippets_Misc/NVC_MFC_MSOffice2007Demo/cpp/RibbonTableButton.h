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

#pragma once

class CRibbonTableButton : public CMFCRibbonGallery
{
	DECLARE_DYNCREATE(CRibbonTableButton)

// Construction:
public:
	CRibbonTableButton() {}
	CRibbonTableButton(UINT nID, LPCTSTR lpszText, int nSmallImageIndex, int nLargeImageIndex);

	virtual ~CRibbonTableButton();

// Attributes:
public:
	static int GetRows() { return m_nRows; }
	static int GetColumns() { return m_nColumns; }

protected:
	static int m_nRows;
	static int m_nColumns;

// Overrides:
protected:
	virtual void OnDrawPaletteIcon(CDC* pDC, CRect rectIcon, int nIconIndex, CMFCRibbonGalleryIcon* pIcon, COLORREF clrText);
	virtual void NotifyHighlightListItem(int nIndex);
	virtual void OnShowPopupMenu();
};

