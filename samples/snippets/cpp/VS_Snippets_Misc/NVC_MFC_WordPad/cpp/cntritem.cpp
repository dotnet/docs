//
// cntritem.cpp : implementation of the CWordPadCntrItem class
//
// This is a part of the Microsoft Foundation Classes C++ library.
// Copyright (C) 1992-1998 Microsoft Corporation
// All rights reserved.
//
// This source code is only intended as a supplement to the
// Microsoft Foundation Classes Reference and related
// electronic documentation provided with the library.
// See these sources for detailed information regarding the
// Microsoft Foundation Classes product.

#include "stdafx.h"
#include "wordpad.h"

#include "wordpdoc.h"
#include "wordpvw.h"
#include "cntritem.h"

#ifdef _DEBUG
#undef THIS_FILE
static char BASED_CODE THIS_FILE[] = __FILE__;
#endif

/////////////////////////////////////////////////////////////////////////////
// CWordPadCntrItem implementation

IMPLEMENT_SERIAL(CWordPadCntrItem, CRichEditCntrItem, 0)

CWordPadCntrItem::CWordPadCntrItem(REOBJECT *preo, CWordPadDoc* pContainer)
	: CRichEditCntrItem(preo, pContainer)
{
}


BOOL CWordPadCntrItem::OnShowPanes(CFrameWnd* pFrameWnd, BOOL bShow)
{
	CMDIFrameWndEx* pMainFrame = DYNAMIC_DOWNCAST (CMDIFrameWndEx, pFrameWnd);
	if (pMainFrame != NULL)
	{
		return pMainFrame->OnShowPanes (bShow);
	}
	else	// Maybe, SDI frame...
	{
		CFrameWndEx* pFrame = DYNAMIC_DOWNCAST (CFrameWndEx, pFrameWnd);
		if (pFrame != NULL)
		{
			return pFrame->OnShowPanes (bShow);
		}
	}

	return FALSE;
}

/////////////////////////////////////////////////////////////////////////////
// CWordPadCntrItem diagnostics

#ifdef _DEBUG
void CWordPadCntrItem::AssertValid() const
{
	CRichEditCntrItem::AssertValid();
}

void CWordPadCntrItem::Dump(CDumpContext& dc) const
{
	CRichEditCntrItem::Dump(dc);
}
#endif

/////////////////////////////////////////////////////////////////////////////
