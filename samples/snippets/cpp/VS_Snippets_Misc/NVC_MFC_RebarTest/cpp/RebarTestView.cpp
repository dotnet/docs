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
#include "RebarTest.h"

#include "RebarTestDoc.h"
#include "RebarTestView.h"

#ifdef _DEBUG
#define new DEBUG_NEW
#endif


// CRebarTestView

IMPLEMENT_DYNCREATE(CRebarTestView, CView)

BEGIN_MESSAGE_MAP(CRebarTestView, CView)
	// Standard printing commands
	ON_COMMAND(ID_FILE_PRINT, CView::OnFilePrint)
	ON_COMMAND(ID_FILE_PRINT_PREVIEW, OnFilePrintPreview)
	ON_COMMAND(ID_FILE_PRINT_DIRECT, CView::OnFilePrint)
END_MESSAGE_MAP()

// CRebarTestView construction/destruction

CRebarTestView::CRebarTestView()
{
	// TODO: add construction code here

}

CRebarTestView::~CRebarTestView()
{
}

BOOL CRebarTestView::PreCreateWindow(CREATESTRUCT& cs)
{
	// TODO: Modify the Window class or styles here by modifying
	//  the CREATESTRUCT cs

	return CView::PreCreateWindow(cs);
}

// CRebarTestView drawing

void CRebarTestView::OnDraw(CDC* /*pDC*/)
{
	CRebarTestDoc* pDoc;
	pDoc = GetDocument();
	ASSERT_VALID(pDoc);

	// TODO: add draw code for native data here
}


// CRebarTestView printing

void CRebarTestView::OnFilePrintPreview()
{
	AFXPrintPreview (this);
}

BOOL CRebarTestView::OnPreparePrinting(CPrintInfo* pInfo)
{
	// default preparation
	return DoPreparePrinting(pInfo);
}

void CRebarTestView::OnBeginPrinting(CDC* /*pDC*/, CPrintInfo* /*pInfo*/)
{
	// TODO: add extra initialization before printing
}

void CRebarTestView::OnEndPrinting(CDC* /*pDC*/, CPrintInfo* /*pInfo*/)
{
	// TODO: add cleanup after printing
}


// CRebarTestView diagnostics

#ifdef _DEBUG
void CRebarTestView::AssertValid() const
{
	CView::AssertValid();
}

void CRebarTestView::Dump(CDumpContext& dc) const
{
	CView::Dump(dc);
}

CRebarTestDoc* CRebarTestView::GetDocument() const // non-debug version is inline
{
	ASSERT(m_pDocument->IsKindOf(RUNTIME_CLASS(CRebarTestDoc)));
	return (CRebarTestDoc*)m_pDocument;
}
#endif //_DEBUG


// CRebarTestView message handlers
