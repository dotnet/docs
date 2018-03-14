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

class CMSNVisualManager : public CMFCVisualManagerWindows
{
	DECLARE_DYNCREATE(CMSNVisualManager)

public:
	CMSNVisualManager();
	virtual ~CMSNVisualManager();

	virtual void OnFillPopupWindowBackground (CDC* pDC, CRect rect);
	virtual void OnDrawPopupWindowBorder (CDC* pDC, CRect rect);
	virtual COLORREF OnDrawPopupWindowCaption (CDC* pDC, CRect rectCaption, CMFCDesktopAlertWnd* pPopupWnd);
};
