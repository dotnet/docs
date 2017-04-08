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
#include "SetPaneSize.h"

#include "SetPaneSizeDoc.h"

#ifdef _DEBUG
#define new DEBUG_NEW
#undef THIS_FILE
static char THIS_FILE[] = __FILE__;
#endif

/////////////////////////////////////////////////////////////////////////////
// CSetPaneSizeDoc

IMPLEMENT_DYNCREATE(CSetPaneSizeDoc, CDocument)

BEGIN_MESSAGE_MAP(CSetPaneSizeDoc, CDocument)
END_MESSAGE_MAP()

/////////////////////////////////////////////////////////////////////////////
// CSetPaneSizeDoc construction/destruction

CSetPaneSizeDoc::CSetPaneSizeDoc()
{
	// TODO: add one-time construction code here

}

CSetPaneSizeDoc::~CSetPaneSizeDoc()
{
}

BOOL CSetPaneSizeDoc::OnNewDocument()
{
	if (!CDocument::OnNewDocument())
		return FALSE;

	// TODO: add reinitialization code here
	// (SDI documents will reuse this document)

	return TRUE;
}



/////////////////////////////////////////////////////////////////////////////
// CSetPaneSizeDoc serialization

void CSetPaneSizeDoc::Serialize(CArchive& ar)
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
// CSetPaneSizeDoc diagnostics

#ifdef _DEBUG
void CSetPaneSizeDoc::AssertValid() const
{
	CDocument::AssertValid();
}

void CSetPaneSizeDoc::Dump(CDumpContext& dc) const
{
	CDocument::Dump(dc);
}
#endif //_DEBUG

/////////////////////////////////////////////////////////////////////////////
// CSetPaneSizeDoc commands
