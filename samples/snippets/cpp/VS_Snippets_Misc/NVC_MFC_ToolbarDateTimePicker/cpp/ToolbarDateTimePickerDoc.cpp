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
#include "ToolbarDateTimePicker.h"

#include "ToolbarDateTimePickerDoc.h"

#ifdef _DEBUG
#define new DEBUG_NEW
#undef THIS_FILE
static char THIS_FILE[] = __FILE__;
#endif

/////////////////////////////////////////////////////////////////////////////
// CToolbarDateTimePickerDoc

IMPLEMENT_DYNCREATE(CToolbarDateTimePickerDoc, CDocument)

BEGIN_MESSAGE_MAP(CToolbarDateTimePickerDoc, CDocument)
	//{{AFX_MSG_MAP(CToolbarDateTimePickerDoc)
		// NOTE - the ClassWizard will add and remove mapping macros here.
		//    DO NOT EDIT what you see in these blocks of generated code!
	//}}AFX_MSG_MAP
END_MESSAGE_MAP()

/////////////////////////////////////////////////////////////////////////////
// CToolbarDateTimePickerDoc construction/destruction

CToolbarDateTimePickerDoc::CToolbarDateTimePickerDoc()
{
	// TODO: add one-time construction code here

}

CToolbarDateTimePickerDoc::~CToolbarDateTimePickerDoc()
{
}

BOOL CToolbarDateTimePickerDoc::OnNewDocument()
{
	if (!CDocument::OnNewDocument())
		return FALSE;

	// TODO: add reinitialization code here
	// (SDI documents will reuse this document)

	return TRUE;
}



/////////////////////////////////////////////////////////////////////////////
// CToolbarDateTimePickerDoc serialization

void CToolbarDateTimePickerDoc::Serialize(CArchive& ar)
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
// CToolbarDateTimePickerDoc diagnostics

#ifdef _DEBUG
void CToolbarDateTimePickerDoc::AssertValid() const
{
	CDocument::AssertValid();
}

void CToolbarDateTimePickerDoc::Dump(CDumpContext& dc) const
{
	CDocument::Dump(dc);
}
#endif //_DEBUG

/////////////////////////////////////////////////////////////////////////////
// CToolbarDateTimePickerDoc commands
