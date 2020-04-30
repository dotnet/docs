#include "stdafx.h"
#include "OutlookMultiViews.h"

#include "OutlookMultiViewsDoc.h"

#ifdef _DEBUG
#define new DEBUG_NEW
#undef THIS_FILE
static char THIS_FILE[] = __FILE__;
#endif

/////////////////////////////////////////////////////////////////////////////
// COutlookMultiViewsDoc

IMPLEMENT_DYNCREATE(COutlookMultiViewsDoc, CDocument)

BEGIN_MESSAGE_MAP(COutlookMultiViewsDoc, CDocument)
END_MESSAGE_MAP()

/////////////////////////////////////////////////////////////////////////////
// COutlookMultiViewsDoc construction/destruction

COutlookMultiViewsDoc::COutlookMultiViewsDoc()
{
	// TODO: add one-time construction code here

}

COutlookMultiViewsDoc::~COutlookMultiViewsDoc()
{
}

BOOL COutlookMultiViewsDoc::OnNewDocument()
{
	if (!CDocument::OnNewDocument())
		return FALSE;

	// TODO: add reinitialization code here
	// (SDI documents will reuse this document)

	return TRUE;
}



/////////////////////////////////////////////////////////////////////////////
// COutlookMultiViewsDoc serialization

void COutlookMultiViewsDoc::Serialize(CArchive& ar)
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
// COutlookMultiViewsDoc diagnostics

#ifdef _DEBUG
void COutlookMultiViewsDoc::AssertValid() const
{
	CDocument::AssertValid();
}

void COutlookMultiViewsDoc::Dump(CDumpContext& dc) const
{
	CDocument::Dump(dc);
}
#endif //_DEBUG

/////////////////////////////////////////////////////////////////////////////
// COutlookMultiViewsDoc commands
