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
#include "CustomPages.h"

#include "CustomPagesDoc.h"

#ifdef _DEBUG
#define new DEBUG_NEW
#undef THIS_FILE
static char THIS_FILE[] = __FILE__;
#endif

/////////////////////////////////////////////////////////////////////////////
// CCustomPagesDoc

IMPLEMENT_DYNCREATE(CCustomPagesDoc, CDocument)

BEGIN_MESSAGE_MAP(CCustomPagesDoc, CDocument)
END_MESSAGE_MAP()

/////////////////////////////////////////////////////////////////////////////
// CCustomPagesDoc construction/destruction

CCustomPagesDoc::CCustomPagesDoc()
{
	// TODO: add one-time construction code here

}

CCustomPagesDoc::~CCustomPagesDoc()
{
}

BOOL CCustomPagesDoc::OnNewDocument()
{
	if (!CDocument::OnNewDocument())
		return FALSE;

	// TODO: add reinitialization code here
	// (SDI documents will reuse this document)

	return TRUE;
}



/////////////////////////////////////////////////////////////////////////////
// CCustomPagesDoc serialization

void CCustomPagesDoc::Serialize(CArchive& ar)
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
// CCustomPagesDoc diagnostics

#ifdef _DEBUG
void CCustomPagesDoc::AssertValid() const
{
	CDocument::AssertValid();
}

void CCustomPagesDoc::Dump(CDumpContext& dc) const
{
	CDocument::Dump(dc);
}
#endif //_DEBUG

/////////////////////////////////////////////////////////////////////////////
// CCustomPagesDoc commands
