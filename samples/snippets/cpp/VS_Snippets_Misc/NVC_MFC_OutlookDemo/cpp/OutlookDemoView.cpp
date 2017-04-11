// This is a part of the Microsoft Foundation Classes C++ library.
// Copyright (c) Microsoft Corporation.  All rights reserved.
//
// This source code is only intended as a supplement to the
// Microsoft Foundation Classes Reference and related
// electronic documentation provided with the library.
// See these sources for detailed information regarding the
// Microsoft Foundation Classes product.

#include "stdafx.h"
#include "OutlookDemo.h"

#include "OutlookDemoDoc.h"
#include "OutlookDemoView.h"

#ifdef _DEBUG
#define new DEBUG_NEW
#undef THIS_FILE
static char THIS_FILE[] = __FILE__;
#endif

/////////////////////////////////////////////////////////////////////////////
// COutlookDemoView

IMPLEMENT_DYNCREATE(COutlookDemoView, CListView)

BEGIN_MESSAGE_MAP(COutlookDemoView, CListView)
	ON_COMMAND(ID_VIEW_PREVIEW_PANE, OnViewPreviewPane)
	ON_UPDATE_COMMAND_UI(ID_VIEW_PREVIEW_PANE, OnUpdateViewPreviewPane)
	ON_WM_CREATE()
	ON_WM_CONTEXTMENU()
	// Standard printing commands
	ON_COMMAND(ID_FILE_PRINT, CListView::OnFilePrint)
	ON_COMMAND(ID_FILE_PRINT_DIRECT, CListView::OnFilePrint)
	ON_COMMAND(ID_FILE_PRINT_PREVIEW, OnFilePrintPreview)
END_MESSAGE_MAP()

/////////////////////////////////////////////////////////////////////////////
// COutlookDemoView construction/destruction

COutlookDemoView::COutlookDemoView()
{
	// TODO: add construction code here
}

COutlookDemoView::~COutlookDemoView()
{
}

BOOL COutlookDemoView::PreCreateWindow(CREATESTRUCT& cs)
{
	cs.style |= LVS_REPORT;
	return CListView::PreCreateWindow(cs);
}

/////////////////////////////////////////////////////////////////////////////
// COutlookDemoView drawing

void COutlookDemoView::OnDraw(CDC* /*pDC*/)
{
}

void COutlookDemoView::OnInitialUpdate()
{
	CListView::OnInitialUpdate();

	CListCtrl& wndList = GetListCtrl();
	wndList.DeleteAllItems();

	wndList.InsertItem(0, _T("Microsoft"), 1);
	wndList.SetItemText(0, 1, _T("Welcome to MFC!"));
}

/////////////////////////////////////////////////////////////////////////////
// COutlookDemoView printing

void COutlookDemoView::OnFilePrintPreview()
{
	AFXPrintPreview(this);
}

BOOL COutlookDemoView::OnPreparePrinting(CPrintInfo* pInfo)
{
	// default preparation
	return DoPreparePrinting(pInfo);
}

void COutlookDemoView::OnBeginPrinting(CDC* /*pDC*/, CPrintInfo* /*pInfo*/)
{
	// TODO: add extra initialization before printing
}

void COutlookDemoView::OnEndPrinting(CDC* /*pDC*/, CPrintInfo* /*pInfo*/)
{
	// TODO: add cleanup after printing
}

/////////////////////////////////////////////////////////////////////////////
// COutlookDemoView diagnostics

#ifdef _DEBUG
void COutlookDemoView::AssertValid() const
{
	CListView::AssertValid();
}

void COutlookDemoView::Dump(CDumpContext& dc) const
{
	CListView::Dump(dc);
}

COutlookDemoDoc* COutlookDemoView::GetDocument() // non-debug version is inline
{
	ASSERT(m_pDocument->IsKindOf(RUNTIME_CLASS(COutlookDemoDoc)));
	return(COutlookDemoDoc*)m_pDocument;
}
#endif //_DEBUG

/////////////////////////////////////////////////////////////////////////////
// COutlookDemoView message handlers

void COutlookDemoView::OnContextMenu(CWnd*, CPoint point)
{
	theApp.ShowPopupMenu(IDR_CONTEXT_MENU, point, this);
}

void COutlookDemoView::OnViewPreviewPane()
{
	// TODO: Add your command handler code here

}

void COutlookDemoView::OnUpdateViewPreviewPane(CCmdUI* /*pCmdUI*/)
{
	// TODO: Add your command update UI handler code here

}

int COutlookDemoView::OnCreate(LPCREATESTRUCT lpCreateStruct)
{
	if (CListView::OnCreate(lpCreateStruct) == -1)
		return -1;

	const int nImageWidth = 12;

	m_ImagesHeader.Create(IDB_HEADER_IMAGES, nImageWidth, 0, RGB(255, 0, 255));

	CBitmap bmp;
	if (bmp.LoadBitmap(IDB_LIST_IMAGES))
	{
		m_ImagesList.Create(16, 16, ILC_COLOR24 | ILC_MASK, 0, 0);
		m_ImagesList.Add(&bmp, RGB(255, 0, 255));
	}

	CListCtrl& wndList = GetListCtrl();
	wndList.SetExtendedStyle(LVS_EX_FULLROWSELECT);

	wndList.SetImageList(&m_ImagesList, LVSIL_SMALL);

	wndList.InsertColumn(0, _T("From"), LVCFMT_LEFT, 100);
	wndList.InsertColumn(1, _T("Subject"), LVCFMT_LEFT, 200);

	CHeaderCtrl* pHeaderCtrl = (CHeaderCtrl*) wndList.GetDlgItem(0);
	ASSERT_VALID(pHeaderCtrl);

	pHeaderCtrl->SetImageList(&m_ImagesHeader);

	LVCOLUMN lvColumn;
	memset(&lvColumn, 0, sizeof(LVCOLUMN));
	lvColumn.mask = LVCF_IMAGE | LVCF_WIDTH;
	lvColumn.fmt = LVCFMT_COL_HAS_IMAGES;
	lvColumn.cx = nImageWidth * 2 + 4;

	lvColumn.iImage = 0;
	wndList.InsertColumn(2, &lvColumn);

	lvColumn.iImage = 1;
	wndList.InsertColumn(3, &lvColumn);

	lvColumn.iImage = 2;
	wndList.InsertColumn(4, &lvColumn);

	static int nColumsOrder [] = { 2, 3, 4, 0, 1 };
	wndList.SetColumnOrderArray(sizeof(nColumsOrder) / sizeof(int), nColumsOrder);

	return 0;
}
