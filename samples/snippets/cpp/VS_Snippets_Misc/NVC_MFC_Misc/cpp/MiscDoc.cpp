
// MiscDoc.cpp : implementation of the CMiscDoc class
//

#include "stdafx.h"
#include "Misc.h"

#include "MiscDoc.h"

#ifdef _DEBUG
#define new DEBUG_NEW
#endif


// CMiscDoc

IMPLEMENT_DYNCREATE(CMiscDoc, CDocument)

BEGIN_MESSAGE_MAP(CMiscDoc, CDocument)
END_MESSAGE_MAP()


// CMiscDoc construction/destruction

CMiscDoc::CMiscDoc()
{
	// TODO: add one-time construction code here

}

CMiscDoc::~CMiscDoc()
{
}

BOOL CMiscDoc::OnNewDocument()
{
	if (!CDocument::OnNewDocument())
		return FALSE;

	// TODO: add reinitialization code here
	// (SDI documents will reuse this document)

	return TRUE;
}




// CMiscDoc serialization

void CMiscDoc::Serialize(CArchive& ar)
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


// CMiscDoc diagnostics

#ifdef _DEBUG
void CMiscDoc::AssertValid() const
{
	CDocument::AssertValid();
}

void CMiscDoc::Dump(CDumpContext& dc) const
{
	CDocument::Dump(dc);
}
#endif //_DEBUG


// CMiscDoc commands
