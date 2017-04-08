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
#include "MSOffice2007Demo.h"

#include "MSOffice2007DemoDoc.h"
#include "MSOffice2007DemoView.h"
#include "CntrItem.h"

#ifdef _DEBUG
#define new DEBUG_NEW
#undef THIS_FILE
static char THIS_FILE[] = __FILE__;
#endif

/////////////////////////////////////////////////////////////////////////////
// CMSOffice2007DemoCntrItem implementation

IMPLEMENT_SERIAL(CMSOffice2007DemoCntrItem, CRichEditCntrItem, 0)

CMSOffice2007DemoCntrItem::CMSOffice2007DemoCntrItem(REOBJECT* preo, CMSOffice2007DemoDoc* pContainer) :
	CRichEditCntrItem(preo, pContainer)
{
	m_uiCategoryID = 0;
}

CMSOffice2007DemoCntrItem::~CMSOffice2007DemoCntrItem()
{
	// TODO: add cleanup code here
}

BOOL CMSOffice2007DemoCntrItem::OnShowPanes(CFrameWnd* pFrameWnd, BOOL bShow)
{
	CMDIFrameWndEx* pMainFrame = DYNAMIC_DOWNCAST(CMDIFrameWndEx, pFrameWnd);
	if (pMainFrame != NULL)
	{
		return pMainFrame->OnShowPanes(bShow);
	}
	else // Maybe, SDI frame...
	{
		CFrameWndEx* pFrame = DYNAMIC_DOWNCAST(CFrameWndEx, pFrameWnd);
		if (pFrame != NULL)
		{
			return pFrame->OnShowPanes(bShow);
		}
	}

	return FALSE;
}

/////////////////////////////////////////////////////////////////////////////
// CMSOffice2007DemoCntrItem diagnostics

#ifdef _DEBUG
void CMSOffice2007DemoCntrItem::AssertValid() const
{
	CRichEditCntrItem::AssertValid();
}

void CMSOffice2007DemoCntrItem::Dump(CDumpContext& dc) const
{
	CRichEditCntrItem::Dump(dc);
}
#endif

/////////////////////////////////////////////////////////////////////////////


