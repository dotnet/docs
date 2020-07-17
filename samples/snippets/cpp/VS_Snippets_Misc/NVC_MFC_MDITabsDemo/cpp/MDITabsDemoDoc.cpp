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
#include "MDITabsDemo.h"

#include "MDITabsDemoDoc.h"

#ifdef _DEBUG
#define new DEBUG_NEW
#undef THIS_FILE
static char THIS_FILE[] = __FILE__;
#endif

/////////////////////////////////////////////////////////////////////////////
// CMDITabsDemoDoc

IMPLEMENT_DYNCREATE(CMDITabsDemoDoc, CDocument)

BEGIN_MESSAGE_MAP(CMDITabsDemoDoc, CDocument)
END_MESSAGE_MAP()

/////////////////////////////////////////////////////////////////////////////
// CMDITabsDemoDoc construction/destruction

CMDITabsDemoDoc::CMDITabsDemoDoc()
{
	// TODO: add one-time construction code here

}

CMDITabsDemoDoc::~CMDITabsDemoDoc()
{
}

BOOL CMDITabsDemoDoc::OnNewDocument()
{
	if (!CDocument::OnNewDocument())
		return FALSE;

	// TODO: add reinitialization code here
	// (SDI documents will reuse this document)

	return TRUE;
}



/////////////////////////////////////////////////////////////////////////////
// CMDITabsDemoDoc serialization

void CMDITabsDemoDoc::Serialize(CArchive& ar)
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
// CMDITabsDemoDoc diagnostics

#ifdef _DEBUG
void CMDITabsDemoDoc::AssertValid() const
{
	CDocument::AssertValid();
}

void CMDITabsDemoDoc::Dump(CDumpContext& dc) const
{
	CDocument::Dump(dc);
}
#endif //_DEBUG

/////////////////////////////////////////////////////////////////////////////
// CMDITabsDemoDoc commands
