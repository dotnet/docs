// This is a part of the Microsoft Foundation Classes C++ library.
// Copyright (c) Microsoft Corporation.  All rights reserved.
//
// This source code is only intended as a supplement to the
// Microsoft Foundation Classes Reference and related
// electronic documentation provided with the library.
// See these sources for detailed information regarding the
// Microsoft Foundation Classes product.

#include "stdafx.h"
#include "MainFrm.h"
#include "VisualStudioDemo.h"

#include "VisualStudioDemoDoc.h"
#include "VisualStudioDemoView.h"

#ifdef _DEBUG
#define new DEBUG_NEW
#endif

// CVisualStudioDemoView

IMPLEMENT_DYNCREATE(CVisualStudioDemoView, CEditView)

BEGIN_MESSAGE_MAP(CVisualStudioDemoView, CEditView)
	// Standard printing commands
	ON_COMMAND(ID_FILE_PRINT, &CEditView::OnFilePrint)
	ON_COMMAND(ID_FILE_PRINT_DIRECT, &CEditView::OnFilePrint)
	ON_COMMAND(ID_FILE_PRINT_PREVIEW, &CVisualStudioDemoView::OnFilePrintPreview)
	ON_COMMAND(ID_EDIT_TOGGLEBREAKPOINT, &CVisualStudioDemoView::OnEditTogglebreakpoint)
	ON_COMMAND(ID_EDIT_FIND_COMBO, OnFind)
END_MESSAGE_MAP()

// CVisualStudioDemoView construction/destruction

CVisualStudioDemoView::CVisualStudioDemoView()
{
	// TODO: add construction code here
}

CVisualStudioDemoView::~CVisualStudioDemoView()
{
}

BOOL CVisualStudioDemoView::PreCreateWindow(CREATESTRUCT& cs)
{
	// TODO: Modify the Window class or styles here by modifying
	//  the CREATESTRUCT cs

	BOOL bPreCreated = CEditView::PreCreateWindow(cs);
	cs.style &= ~(ES_AUTOHSCROLL|WS_HSCROLL); // Enable word-wrapping

	return bPreCreated;
}

// CVisualStudioDemoView printing

BOOL CVisualStudioDemoView::OnPreparePrinting(CPrintInfo* pInfo)
{
	// default CEditView preparation
	return CEditView::OnPreparePrinting(pInfo);
}

void CVisualStudioDemoView::OnBeginPrinting(CDC* pDC, CPrintInfo* pInfo)
{
	// Default CEditView begin printing
	CEditView::OnBeginPrinting(pDC, pInfo);
}

void CVisualStudioDemoView::OnEndPrinting(CDC* pDC, CPrintInfo* pInfo)
{
	// Default CEditView end printing
	CEditView::OnEndPrinting(pDC, pInfo);
}

void CVisualStudioDemoView::OnFilePrintPreview()
{
	AFXPrintPreview(this);
}

// CVisualStudioDemoView diagnostics

#ifdef _DEBUG
void CVisualStudioDemoView::AssertValid() const
{
	CEditView::AssertValid();
}

void CVisualStudioDemoView::Dump(CDumpContext& dc) const
{
	CEditView::Dump(dc);
}

CVisualStudioDemoDoc* CVisualStudioDemoView::GetDocument() const // non-debug version is inline
{
	ASSERT(m_pDocument->IsKindOf(RUNTIME_CLASS(CVisualStudioDemoDoc)));
	return(CVisualStudioDemoDoc*)m_pDocument;
}
#endif //_DEBUG

// CVisualStudioDemoView message handlers

void CVisualStudioDemoView::OnEditTogglebreakpoint()
{
	// TODO: Add your command handler code here
}

void CVisualStudioDemoView::OnFind()
{
	CString strFindText;
	VerifyFindString(((CMainFrame*)AfxGetMainWnd())->GetFindCombo(), strFindText);

	if (!strFindText.IsEmpty())
	{
		FindText(strFindText);
	}
}

void CVisualStudioDemoView::VerifyFindString(CMFCToolBarComboBoxButton* pFindCombo, CString& strFindText)
{
	if (pFindCombo == NULL)
	{
		return;
	}

	BOOL bIsLastCommandFromButton = CMFCToolBar::IsLastCommandFromButton(pFindCombo);

	if (bIsLastCommandFromButton)
	{
		strFindText = pFindCombo->GetText();
	}

	CComboBox* pCombo = pFindCombo->GetComboBox();

	if (!strFindText.IsEmpty())
	{
		const int nCount = pCombo->GetCount();
		int ind = 0;
		CString strCmpText;

		while (ind < nCount)
		{
			pCombo->GetLBText(ind, strCmpText);

			if (strCmpText.GetLength() == strFindText.GetLength())
			{
				if (strCmpText == strFindText)
					break;
			}

			ind++;
		}

		if (ind < nCount)
		{
			pCombo->DeleteString(ind);
		}

		pCombo->InsertString(0,strFindText);
		pCombo->SetCurSel(0);

		if (!bIsLastCommandFromButton)
		{
			pFindCombo->SetText(strFindText);
		}
	}
}

