// MFCRibbonAppDoc.cpp : implementation of the CMFCRibbonAppDoc class
//

#include "stdafx.h"
#include "MFCRibbonApp.h"

#include "MFCRibbonAppDoc.h"

#ifdef _DEBUG
#define new DEBUG_NEW
#endif


// CMFCRibbonAppDoc

IMPLEMENT_DYNCREATE(CMFCRibbonAppDoc, CDocument)

BEGIN_MESSAGE_MAP(CMFCRibbonAppDoc, CDocument)
END_MESSAGE_MAP()


// CMFCRibbonAppDoc construction/destruction

CMFCRibbonAppDoc::CMFCRibbonAppDoc()
{
	// TODO: add one-time construction code here

}

CMFCRibbonAppDoc::~CMFCRibbonAppDoc()
{
}

BOOL CMFCRibbonAppDoc::OnNewDocument()
{
	if (!CDocument::OnNewDocument())
		return FALSE;

	// TODO: add reinitialization code here
	// (SDI documents will reuse this document)

	return TRUE;
}




// CMFCRibbonAppDoc serialization

void CMFCRibbonAppDoc::Serialize(CArchive& ar)
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


// CMFCRibbonAppDoc diagnostics

#ifdef _DEBUG
void CMFCRibbonAppDoc::AssertValid() const
{
	CDocument::AssertValid();
}

void CMFCRibbonAppDoc::Dump(CDumpContext& dc) const
{
	CDocument::Dump(dc);
}
#endif //_DEBUG


// CMFCRibbonAppDoc commands
