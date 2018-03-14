// This is a part of the Microsoft Foundation Classes C++ library.
// Copyright (c) Microsoft Corporation.  All rights reserved.
//
// This source code is only intended as a supplement to the
// Microsoft Foundation Classes Reference and related
// electronic documentation provided with the library.
// See these sources for detailed information regarding the
// Microsoft Foundation Classes product.

#include "stdafx.h"
#include "UndoListBox.h"
#include "UndoBar.h"

#ifdef _DEBUG
#define new DEBUG_NEW
#undef THIS_FILE
static char THIS_FILE[] = __FILE__;
#endif

/////////////////////////////////////////////////////////////////////////////
// CUndoListBox

CUndoListBox::CUndoListBox(CUndoBar& bar) : m_Bar(bar)
{
}

CUndoListBox::~CUndoListBox()
{
}

BEGIN_MESSAGE_MAP(CUndoListBox, CListBox)
	ON_WM_MOUSEMOVE()
	ON_WM_LBUTTONUP()
END_MESSAGE_MAP()

/////////////////////////////////////////////////////////////////////////////
// CUndoListBox message handlers

void CUndoListBox::OnLButtonUp(UINT nFlags, CPoint point)
{
	BOOL bOutside;
	ItemFromPoint(point, bOutside);

	if (!bOutside)
	{
		m_Bar.DoUndo();
	}

	if (IsWindow(GetSafeHwnd()))
	{
		CListBox::OnLButtonUp(nFlags, point);
	}
}

void CUndoListBox::OnMouseMove(UINT nFlags, CPoint point)
{
	CListBox::OnMouseMove(nFlags, point);

	BOOL bOutside;
	int iItem = ItemFromPoint(point, bOutside);

	if (!bOutside)
	{
		SelItemRange(FALSE, iItem + 1, GetCount() - 1);

		if (iItem == 0)
		{
			SetSel(0);
		}
		else
		{
			SelItemRange(TRUE, 0, iItem);
		}

		CString strLabel;
		strLabel.Format(_T("Undo %d Actions"), iItem + 1);

		m_Bar.SetLabel(strLabel);
	}
}
