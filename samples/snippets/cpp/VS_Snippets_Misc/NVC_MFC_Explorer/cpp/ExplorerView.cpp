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
#include "Explorer.h"

#include "ExplorerDoc.h"
#include "ExplorerView.h"
#include "MainFrm.h"

#ifdef _DEBUG
#define new DEBUG_NEW
#undef THIS_FILE
static char THIS_FILE[] = __FILE__;
#endif

/////////////////////////////////////////////////////////////////////////////
// CExplorerView

IMPLEMENT_DYNCREATE(CExplorerView, CView)

BEGIN_MESSAGE_MAP(CExplorerView, CView)
	ON_WM_CREATE()
	ON_WM_SIZE()
	ON_COMMAND(ID_VIEW_LARGEICON, OnViewLargeicon)
	ON_UPDATE_COMMAND_UI(ID_VIEW_LARGEICON, OnUpdateViewLargeicon)
	ON_COMMAND(ID_VIEW_DETAILS, OnViewDetails)
	ON_UPDATE_COMMAND_UI(ID_VIEW_DETAILS, OnUpdateViewDetails)
	ON_COMMAND(ID_VIEW_LIST, OnViewList)
	ON_UPDATE_COMMAND_UI(ID_VIEW_LIST, OnUpdateViewList)
	ON_COMMAND(ID_VIEW_SMALLICON, OnViewSmallicon)
	ON_UPDATE_COMMAND_UI(ID_VIEW_SMALLICON, OnUpdateViewSmallicon)
	ON_WM_ERASEBKGND()
	ON_WM_SETFOCUS()
	ON_COMMAND(ID_FOLDER_UP, OnFolderUp)
	ON_UPDATE_COMMAND_UI(ID_FOLDER_UP, OnUpdateFolderUp)
	ON_COMMAND(ID_COPY_TO, OnCopyTo)
	ON_COMMAND(ID_MOVE_TO, OnMoveTo)
	ON_COMMAND(ID_VIEW_REFRESH, OnViewRefresh)
	ON_REGISTERED_MESSAGE(AFX_WM_CHANGE_CURRENT_FOLDER, OnChangeFolder)
END_MESSAGE_MAP()

/////////////////////////////////////////////////////////////////////////////
// CExplorerView construction/destruction

CExplorerView::CExplorerView()
{
}

CExplorerView::~CExplorerView()
{
}

BOOL CExplorerView::PreCreateWindow(CREATESTRUCT& cs)
{
	// TODO: Modify the Window class or styles here by modifying
	//  the CREATESTRUCT cs

	return CView::PreCreateWindow(cs);
}

/////////////////////////////////////////////////////////////////////////////
// CExplorerView drawing

void CExplorerView::OnDraw(CDC* /*pDC*/)
{
}

void CExplorerView::OnInitialUpdate()
{
	CView::OnInitialUpdate();
	OnChangeFolder (0, 0);	// To update mainframe's address bar
}

/////////////////////////////////////////////////////////////////////////////
// CExplorerView diagnostics

#ifdef _DEBUG
void CExplorerView::AssertValid() const
{
	CView::AssertValid();
}

void CExplorerView::Dump(CDumpContext& dc) const
{
	CView::Dump(dc);
}

CExplorerDoc* CExplorerView::GetDocument() // non-debug version is inline
{
	ASSERT(m_pDocument->IsKindOf(RUNTIME_CLASS(CExplorerDoc)));
	return (CExplorerDoc*)m_pDocument;
}
#endif //_DEBUG

/////////////////////////////////////////////////////////////////////////////
// CExplorerView message handlers

int CExplorerView::OnCreate(LPCREATESTRUCT lpCreateStruct) 
{
	if (CView::OnCreate(lpCreateStruct) == -1)
		return -1;
	
	// <snippet2>
	CRect rectDummy (0, 0, 0, 0);
	// The this pointer points to CExplorerView class which extends the CView class.
	m_wndList.Create (WS_CHILD | WS_VISIBLE | LVS_REPORT, rectDummy, this, 1);
	// </snippet2>

	return 0;
}

void CExplorerView::OnSize(UINT nType, int cx, int cy) 
{
	CView::OnSize(nType, cx, cy);
	m_wndList.SetWindowPos (NULL, -1, -1, cx, cy, SWP_NOMOVE | SWP_NOZORDER | SWP_NOACTIVATE);
}

void CExplorerView::OnActivateView(BOOL bActivate, CView* pActivateView, CView* pDeactiveView) 
{
	if (bActivate && AfxGetMainWnd () != NULL)
	{
		((CMainFrame*) AfxGetMainWnd ())->GetFolders ().SetRelatedList (&m_wndList);
	}
	
	CView::OnActivateView(bActivate, pActivateView, pDeactiveView);
}

void CExplorerView::OnViewLargeicon() 
{
	m_wndList.ModifyStyle(LVS_TYPEMASK, LVS_ICON);
}

void CExplorerView::OnUpdateViewLargeicon(CCmdUI* pCmdUI) 
{
	pCmdUI->SetRadio ((m_wndList.GetStyle () & LVS_TYPEMASK) == LVS_ICON);
}

void CExplorerView::OnViewDetails() 
{
	m_wndList.ModifyStyle(LVS_TYPEMASK, LVS_REPORT);
}

void CExplorerView::OnUpdateViewDetails(CCmdUI* pCmdUI) 
{
	pCmdUI->SetRadio ((m_wndList.GetStyle () & LVS_TYPEMASK) == LVS_REPORT);
}

void CExplorerView::OnViewList() 
{
	m_wndList.ModifyStyle(LVS_TYPEMASK, LVS_LIST);
}

void CExplorerView::OnUpdateViewList(CCmdUI* pCmdUI) 
{
	pCmdUI->SetRadio ((m_wndList.GetStyle () & LVS_TYPEMASK) == LVS_LIST);
}

void CExplorerView::OnViewSmallicon() 
{
	m_wndList.ModifyStyle(LVS_TYPEMASK, LVS_SMALLICON);
}

void CExplorerView::OnUpdateViewSmallicon(CCmdUI* pCmdUI) 
{
	pCmdUI->SetRadio ((m_wndList.GetStyle () & LVS_TYPEMASK) == LVS_SMALLICON);
}

BOOL CExplorerView::OnEraseBkgnd(CDC* /*pDC*/) 
{
	return TRUE;
}

void CExplorerView::OnSetFocus(CWnd* pOldWnd) 
{
	CView::OnSetFocus(pOldWnd);
	m_wndList.SetFocus ();
}

LRESULT CExplorerView::OnChangeFolder(WPARAM,LPARAM)
{
	CString strPath;
	if (!m_wndList.GetCurrentFolder (strPath) &&
		!m_wndList.GetCurrentFolderName (strPath))
	{
		strPath = _T("????");
	}

	if (AfxGetMainWnd () != NULL)
	{
		((CMainFrame*) AfxGetMainWnd ())->SetCurrFolder (strPath);
	}

	return 0;
}

void CExplorerView::OnFolderUp() 
{
	// <snippet3>
	m_wndList.DisplayParentFolder ();
	// </snippet3>
}

void CExplorerView::OnUpdateFolderUp(CCmdUI* pCmdUI) 
{
	pCmdUI->Enable (!m_wndList.IsDesktop ());
}

void CExplorerView::OnCopyTo() 
{
	// <snippet6>
	CString strPath;
	// The this pointer points to the CExplorerView class which extends the CView class.
	// CMFCShellListCtrl m_wndList
	if (m_wndList.GetCurrentFolder (strPath) &&
		theApp.GetShellManager ()->BrowseForFolder (strPath, 
			this, strPath, _T("Copy the selected item(s) to the folder:")))
	{
		MessageBox (CString (_T("The selected path is: ")) + strPath);
	}
	// </snippet6>
}

void CExplorerView::OnMoveTo() 
{
	CString strPath;
	if (m_wndList.GetCurrentFolder (strPath) &&
		theApp.GetShellManager ()->BrowseForFolder (strPath, 
			this, strPath, _T("Move the selected item(s) to the folder:")))
	{
		MessageBox (CString (_T("The selected path is: ")) + strPath);
	}
}

void CExplorerView::OnViewRefresh() 
{
	m_wndList.Refresh ();
}
