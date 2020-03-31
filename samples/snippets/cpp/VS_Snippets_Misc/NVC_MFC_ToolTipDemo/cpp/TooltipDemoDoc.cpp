// This is a part of the Microsoft Foundation Classes C++ library.
// Copyright (C) Microsoft Corporation
// All rights reserved.
//
// This source code is only intended as a supplement to the
// Microsoft Foundation Classes Reference and related
// electronic documentation provided with the library.
// See these sources for detailed information regarding the
// Microsoft Foundation Classes product.

#include "stdafx.h"
#include "TooltipDemo.h"

#include "TooltipDemoDoc.h"

#ifdef _DEBUG
#define new DEBUG_NEW
#undef THIS_FILE
static char THIS_FILE[] = __FILE__;
#endif

/////////////////////////////////////////////////////////////////////////////
// CTooltipDemoDoc

IMPLEMENT_DYNCREATE(CTooltipDemoDoc, CDocument)

BEGIN_MESSAGE_MAP(CTooltipDemoDoc, CDocument)
END_MESSAGE_MAP()

/////////////////////////////////////////////////////////////////////////////
// CTooltipDemoDoc construction/destruction

CTooltipDemoDoc::CTooltipDemoDoc()
{
	// TODO: add one-time construction code here

}

CTooltipDemoDoc::~CTooltipDemoDoc()
{
}

BOOL CTooltipDemoDoc::OnNewDocument()
{
	if (!CDocument::OnNewDocument())
		return FALSE;

	// TODO: add reinitialization code here
	// (SDI documents will reuse this document)

	return TRUE;
}



/////////////////////////////////////////////////////////////////////////////
// CTooltipDemoDoc serialization

void CTooltipDemoDoc::Serialize(CArchive& ar)
{
	if (ar.IsStoring())
	{
		// TODO: add storing code here
	}
	else
	{
		// TODO: add loading code here
	}
}

/////////////////////////////////////////////////////////////////////////////
// CTooltipDemoDoc diagnostics

#ifdef _DEBUG
void CTooltipDemoDoc::AssertValid() const
{
	CDocument::AssertValid();
}

void CTooltipDemoDoc::Dump(CDumpContext& dc) const
{
	CDocument::Dump(dc);
}
#endif //_DEBUG

/////////////////////////////////////////////////////////////////////////////
// CTooltipDemoDoc commands
