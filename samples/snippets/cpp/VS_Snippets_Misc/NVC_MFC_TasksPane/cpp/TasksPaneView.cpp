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
#include "TasksPane.h"

#include "MainFrm.h"
#include "TasksPaneDoc.h"
#include "TasksPaneView.h"

#ifdef _DEBUG
#define new DEBUG_NEW
#undef THIS_FILE
static char THIS_FILE[] = __FILE__;
#endif

/////////////////////////////////////////////////////////////////////////////
// CTasksPaneView

IMPLEMENT_DYNCREATE(CTasksPaneView, CFormView)

BEGIN_MESSAGE_MAP(CTasksPaneView, CFormView)
	ON_BN_CLICKED(IDC_RADIO_WIN, OnVisualManager)
	ON_BN_CLICKED(IDC_CHECK_WRAPTASKS, OnWraptasks)
	ON_BN_CLICKED(IDC_CHECK_WRAPLABELS, OnWraplabels)
	ON_BN_CLICKED(IDC_CHECK_NAVTOOLBAR, OnNavtoolbar)
	ON_BN_CLICKED(IDC_CHECK_HISTBUTTONS, OnHistbuttons)
	ON_BN_CLICKED(IDC_CHECK_HICOLORIMAGES, OnHicolorimages)
	ON_WM_DESTROY()
	ON_BN_CLICKED(IDC_CHECK_SCROLLBUTTONS, OnScrollbuttons)
	ON_BN_CLICKED(IDC_CHECK_ANIMATION, OnAnimation)
	ON_BN_CLICKED(IDC_CHECK_COLLAPSEGROUPS, OnCollapsegroups)
	ON_BN_CLICKED(IDC_CHECK_MARGINS, OnMargins)
	ON_BN_CLICKED(IDC_COLOR_GROUPTEXT, OnColorGrouptext)
	ON_BN_CLICKED(IDC_COLOR_GROUPTEXTHOT, OnColorGrouptexthot)
	ON_BN_CLICKED(IDC_COLOR_TASKTEXT, OnColorTasktext)
	ON_BN_CLICKED(IDC_COLOR_TASKTEXTHOT, OnColorTasktexthot)
	ON_EN_CHANGE(IDC_EDIT_HMARGIN, OnChangeMargins)
	ON_BN_CLICKED(IDC_CHECK_CAPTIONICON, OnCaptionicon)
	ON_BN_CLICKED(IDC_RADIO_OFFICEXP, OnVisualManager)
	ON_BN_CLICKED(IDC_RADIO_WINXP, OnVisualManager)
	ON_BN_CLICKED(IDC_RADIO_OFFICE2003, OnVisualManager)
	ON_EN_CHANGE(IDC_EDIT_VMARGIN, OnChangeMargins)
	ON_EN_CHANGE(IDC_EDIT_GROUPSPACING, OnChangeMargins)
	ON_EN_CHANGE(IDC_EDIT_TASKSPACING, OnChangeMargins)
	ON_EN_CHANGE(IDC_EDIT_CAPTIONHEIGHT, OnChangeMargins)
	ON_EN_CHANGE(IDC_EDIT_TASKOFFSET, OnChangeMargins)
	ON_EN_CHANGE(IDC_EDIT_ICONOFFSET, OnChangeMargins)
	ON_BN_CLICKED(IDC_RADIO_OFFICE2007, OnVisualManager)
	ON_BN_CLICKED(IDC_RADIO_VS2005, OnVisualManager)
	ON_WM_CONTEXTMENU()
	// Standard printing commands
	ON_COMMAND(ID_FILE_PRINT, CFormView::OnFilePrint)
	ON_COMMAND(ID_FILE_PRINT_DIRECT, CFormView::OnFilePrint)
	ON_COMMAND(ID_FILE_PRINT_PREVIEW, OnFilePrintPreview)
END_MESSAGE_MAP()

/////////////////////////////////////////////////////////////////////////////
// CTasksPaneView construction/destruction

CTasksPaneView::CTasksPaneView()
	: CFormView(CTasksPaneView::IDD)
{
	m_nVisualManager = theApp.GetInt (_T("VisualManager"), 2);
	m_bWrapTasks = FALSE;
	m_bWrapLabels = TRUE;
	m_bNavToolbar = TRUE;
	m_bMenuButtons = FALSE;
	m_bHicolorImages = FALSE;
	m_bCollapseGroups = TRUE;
	m_bCustomizeMargins = FALSE;
	m_bScrollButtons = TRUE;
	m_bAnimation = TRUE;
	m_nCaptionHeight = 0;
	m_nGroupSpacing = 0;
	m_nHMargin = 0;
	m_nIconOffset = 0;
	m_nTaskOffset = 0;
	m_nTaskSpacing = 0;
	m_nVMargin = 0;
	m_bCaptionIcon = FALSE;
}

CTasksPaneView::~CTasksPaneView()
{
}

void CTasksPaneView::DoDataExchange(CDataExchange* pDX)
{
	CFormView::DoDataExchange(pDX);

	DDX_Control(pDX, IDC_COLOR_TASKTEXTHOT, m_ColorTaskTextHot);
	DDX_Control(pDX, IDC_COLOR_TASKTEXT, m_ColorTaskText);
	DDX_Control(pDX, IDC_COLOR_GROUPTEXTHOT, m_ColorGroupTextHot);
	DDX_Control(pDX, IDC_COLOR_GROUPTEXT, m_ColorGroupText);

	DDX_Control(pDX, IDC_SPIN3, m_VMargin);
	DDX_Control(pDX, IDC_SPIN4, m_HMargin);
	DDX_Control(pDX, IDC_SPIN5, m_GroupSpacing);
	DDX_Control(pDX, IDC_SPIN6, m_TaskSpacing);
	DDX_Control(pDX, IDC_SPIN7, m_CaptionHeight);
	DDX_Control(pDX, IDC_SPIN8, m_TaskOffset);
	DDX_Control(pDX, IDC_SPIN9, m_IconOffset);

	DDX_Radio(pDX, IDC_RADIO_WIN, m_nVisualManager);
	DDX_Check(pDX, IDC_CHECK_WRAPTASKS, m_bWrapTasks);
	DDX_Check(pDX, IDC_CHECK_WRAPLABELS, m_bWrapLabels);
	DDX_Check(pDX, IDC_CHECK_NAVTOOLBAR, m_bNavToolbar);
	DDX_Check(pDX, IDC_CHECK_HISTBUTTONS, m_bMenuButtons);
	DDX_Check(pDX, IDC_CHECK_HICOLORIMAGES, m_bHicolorImages);
	DDX_Check(pDX, IDC_CHECK_COLLAPSEGROUPS, m_bCollapseGroups);
	DDX_Check(pDX, IDC_CHECK_MARGINS, m_bCustomizeMargins);
	DDX_Check(pDX, IDC_CHECK_SCROLLBUTTONS, m_bScrollButtons);
	DDX_Check(pDX, IDC_CHECK_ANIMATION, m_bAnimation);
	DDX_Check(pDX, IDC_CHECK_CAPTIONICON, m_bCaptionIcon);

	DDX_Text(pDX, IDC_EDIT_VMARGIN, m_nVMargin);
	DDV_MinMaxInt(pDX, m_nVMargin, 0, 25);
	DDX_Text(pDX, IDC_EDIT_HMARGIN, m_nHMargin);
	DDV_MinMaxInt(pDX, m_nHMargin, 0, 25);
	DDX_Text(pDX, IDC_EDIT_GROUPSPACING, m_nGroupSpacing);
	DDV_MinMaxInt(pDX, m_nGroupSpacing, 0, 25);
	DDX_Text(pDX, IDC_EDIT_TASKSPACING, m_nTaskSpacing);
	DDV_MinMaxInt(pDX, m_nTaskSpacing, 0, 25);
	DDX_Text(pDX, IDC_EDIT_CAPTIONHEIGHT, m_nCaptionHeight);
	DDV_MinMaxInt(pDX, m_nCaptionHeight, 0, 30);
	DDX_Text(pDX, IDC_EDIT_TASKOFFSET, m_nTaskOffset);
	DDV_MinMaxInt(pDX, m_nTaskOffset, 0, 20);
	DDX_Text(pDX, IDC_EDIT_ICONOFFSET, m_nIconOffset);
	DDV_MinMaxInt(pDX, m_nIconOffset, 0, 25);
}

BOOL CTasksPaneView::PreCreateWindow(CREATESTRUCT& cs)
{
	// TODO: Modify the Window class or styles here by modifying
	//  the CREATESTRUCT cs

	return CFormView::PreCreateWindow(cs);
}

void CTasksPaneView::OnInitialUpdate()
{
	// There is only one view ever, so it only needs to do the initial
	// update once--otherwise the application is  resized needlessly.
	static BOOL bUpdatedOnce = FALSE;
	if (bUpdatedOnce)
		return;
	bUpdatedOnce = TRUE;

	CFormView::OnInitialUpdate();
	GetParentFrame()->RecalcLayout();
	ResizeParentToFit();

	// Create color pickers:
	m_ColorTaskTextHot.EnableAutomaticButton (_T("Default"), (COLORREF)-1);
	m_ColorTaskTextHot.EnableOtherButton (_T("Other"));
	m_ColorTaskTextHot.SetColor ((COLORREF)-1);

	m_ColorTaskText.EnableAutomaticButton (_T("Default"), (COLORREF)-1);
	m_ColorTaskText.EnableOtherButton (_T("Other"));
	m_ColorTaskText.SetColor ((COLORREF)-1);

	m_ColorGroupTextHot.EnableAutomaticButton (_T("Default"), (COLORREF)-1);
	m_ColorGroupTextHot.EnableOtherButton (_T("Other"));
	m_ColorGroupTextHot.SetColor ((COLORREF)-1);

	m_ColorGroupText.EnableAutomaticButton (_T("Default"), (COLORREF)-1);
	m_ColorGroupText.EnableOtherButton (_T("Other"));
	m_ColorGroupText.SetColor ((COLORREF)-1);

	OnMargins();
	GetDlgItem (IDC_CHECK_HISTBUTTONS)->EnableWindow (m_bNavToolbar);

	CWindowDC dc (NULL);
	int nBitsPerPixel = dc.GetDeviceCaps (BITSPIXEL);
	GetDlgItem (IDC_CHECK_HICOLORIMAGES)->EnableWindow (m_bNavToolbar && (nBitsPerPixel > 16));

	m_VMargin.SetRange(0, 25);
	m_HMargin.SetRange(0, 25);
	m_GroupSpacing.SetRange(0, 25);
	m_TaskSpacing.SetRange(0, 25);
	m_CaptionHeight.SetRange(0, 30);
	m_TaskOffset.SetRange(0, 20);
	m_IconOffset.SetRange(0, 25);
}

/////////////////////////////////////////////////////////////////////////////
// CTasksPaneView printing

void CTasksPaneView::OnFilePrintPreview() 
{
	AFXPrintPreview (this);
}

BOOL CTasksPaneView::OnPreparePrinting(CPrintInfo* pInfo)
{
	// default preparation
	return DoPreparePrinting(pInfo);
}

void CTasksPaneView::OnBeginPrinting(CDC* /*pDC*/, CPrintInfo* /*pInfo*/)
{
	// TODO: add extra initialization before printing
}

void CTasksPaneView::OnEndPrinting(CDC* /*pDC*/, CPrintInfo* /*pInfo*/)
{
	// TODO: add cleanup after printing
}

void CTasksPaneView::OnPrint(CDC* /*pDC*/, CPrintInfo* /*pInfo*/)
{
	// TODO: add customized printing code here
}

/////////////////////////////////////////////////////////////////////////////
// CTasksPaneView diagnostics

#ifdef _DEBUG
void CTasksPaneView::AssertValid() const
{
	CFormView::AssertValid();
}

void CTasksPaneView::Dump(CDumpContext& dc) const
{
	CFormView::Dump(dc);
}

CTasksPaneDoc* CTasksPaneView::GetDocument() // non-debug version is inline
{
	ASSERT(m_pDocument->IsKindOf(RUNTIME_CLASS(CTasksPaneDoc)));
	return (CTasksPaneDoc*)m_pDocument;
}
#endif //_DEBUG

/////////////////////////////////////////////////////////////////////////////
// CTasksPaneView message handlers

void CTasksPaneView::OnContextMenu(CWnd*, CPoint point)
{
	theApp.ShowPopupMenu (IDR_CONTEXT_MENU, point, this);
}
//******************************************************************************************
void CTasksPaneView::OnDestroy() 
{
	UpdateData ();

	theApp.WriteInt (_T("VisualManager"), m_nVisualManager);

	CFormView::OnDestroy();
}
//******************************************************************************************
CTaskPane* CTasksPaneView::GetTasksPane()
{
	CMainFrame* pMainFrm = ((CMainFrame*) AfxGetMainWnd ());
	ASSERT_VALID (pMainFrm);

	return &(pMainFrm->m_wndTaskPane);
}
//******************************************************************************************
void CTasksPaneView::OnVisualManager() 
{
	UpdateData ();

	OnChangeMargins ();

	CMainFrame* pMainFrm = ((CMainFrame*) AfxGetMainWnd ());
	ASSERT_VALID (pMainFrm);

	pMainFrm->OnAppLook (ID_VIEW_APPLOOK_2000 + m_nVisualManager);
}
//******************************************************************************************
void CTasksPaneView::OnWraptasks() 
{
	UpdateData ();

	CTaskPane* pTaskPane = GetTasksPane ();
	ASSERT_VALID (pTaskPane);

	pTaskPane->EnableWrapTasks (m_bWrapTasks);
	pTaskPane->RecalcLayout ();
}
//******************************************************************************************
void CTasksPaneView::OnWraplabels() 
{
	UpdateData ();

	CTaskPane* pTaskPane = GetTasksPane ();
	ASSERT_VALID (pTaskPane);

	pTaskPane->EnableWrapLabels (m_bWrapLabels);
	pTaskPane->RecalcLayout ();
}
//******************************************************************************************
void CTasksPaneView::OnNavtoolbar() 
{
	UpdateData ();

	CTaskPane* pTaskPane = GetTasksPane ();
	ASSERT_VALID (pTaskPane);

	CWindowDC dc (NULL);
	int nBitsPerPixel = dc.GetDeviceCaps (BITSPIXEL);
	if (m_bHicolorImages && (nBitsPerPixel > 16))
	{
		pTaskPane->EnableNavigationToolbar (m_bNavToolbar, IDB_TASKPANE_TOOLBAR, CSize (16, 16));
	}
	else
	{
		pTaskPane->EnableNavigationToolbar (m_bNavToolbar);
	}
	
	pTaskPane->RecalcLayout ();

	GetDlgItem (IDC_CHECK_HISTBUTTONS)->EnableWindow (m_bNavToolbar);
	GetDlgItem (IDC_CHECK_HICOLORIMAGES)->EnableWindow (m_bNavToolbar && (nBitsPerPixel > 16));
}
//******************************************************************************************
void CTasksPaneView::OnHistbuttons() 
{
	UpdateData ();

	CTaskPane* pTaskPane = GetTasksPane ();
	ASSERT_VALID (pTaskPane);

	pTaskPane->EnableHistoryMenuButtons (m_bMenuButtons);
	pTaskPane->RecalcLayout ();
}
//******************************************************************************************
void CTasksPaneView::OnHicolorimages() 
{
	UpdateData ();

	CTaskPane* pTaskPane = GetTasksPane ();
	ASSERT_VALID (pTaskPane);

	CWindowDC dc (NULL);
	int nBitsPerPixel = dc.GetDeviceCaps (BITSPIXEL);
	if (m_bHicolorImages && (nBitsPerPixel > 16))
	{
		pTaskPane->EnableNavigationToolbar (TRUE, IDB_TASKPANE_TOOLBAR, CSize (16, 16));
	}
	else
	{
		pTaskPane->EnableNavigationToolbar (TRUE);
	}
	
	pTaskPane->UpdateToolbar ();
}
//******************************************************************************************
void CTasksPaneView::OnScrollbuttons() 
{
	UpdateData ();

	CTaskPane* pTaskPane = GetTasksPane ();
	ASSERT_VALID (pTaskPane);

	pTaskPane->EnableScrollButtons (m_bScrollButtons);
	pTaskPane->RecalcLayout ();
}
//******************************************************************************************
void CTasksPaneView::OnAnimation() 
{
	UpdateData ();

	CTaskPane* pTaskPane = GetTasksPane ();
	ASSERT_VALID (pTaskPane);

	pTaskPane->EnableAnimation (m_bAnimation);
}
//******************************************************************************************
void CTasksPaneView::OnCollapsegroups() 
{
	UpdateData ();

	CTaskPane* pTaskPane = GetTasksPane ();
	ASSERT_VALID (pTaskPane);

	pTaskPane->EnableGroupCollapse (m_bCollapseGroups);
	pTaskPane->RecalcLayout ();
}
//******************************************************************************************
void CTasksPaneView::OnColorGrouptext() 
{
	UpdateData ();

	COLORREF clrTextHot = m_ColorGroupTextHot.GetColor ();	// (COLORREF)-1, if default
	COLORREF clrText = m_ColorGroupText.GetColor ();		// (COLORREF)-1, if default

	CTaskPane* pTaskPane = GetTasksPane ();
	ASSERT_VALID (pTaskPane);

	pTaskPane->SetGroupTextColor (pTaskPane->m_nUserColorGroup, clrText, clrTextHot);
}
//******************************************************************************************
void CTasksPaneView::OnColorGrouptexthot() 
{
	UpdateData ();

	COLORREF clrTextHot = m_ColorGroupTextHot.GetColor ();	// (COLORREF)-1, if default
	COLORREF clrText = m_ColorGroupText.GetColor ();		// (COLORREF)-1, if default

	CTaskPane* pTaskPane = GetTasksPane ();
	ASSERT_VALID (pTaskPane);

	pTaskPane->SetGroupTextColor (pTaskPane->m_nUserColorGroup, clrText, clrTextHot);
}
//******************************************************************************************
void CTasksPaneView::OnColorTasktext() 
{
	UpdateData ();

	COLORREF clrTextHot = m_ColorTaskTextHot.GetColor ();	// (COLORREF)-1, if default
	COLORREF clrText = m_ColorTaskText.GetColor ();			// (COLORREF)-1, if default

	CTaskPane* pTaskPane = GetTasksPane ();
	ASSERT_VALID (pTaskPane);

	pTaskPane->SetTaskTextColor (pTaskPane->m_nUserColorGroup, pTaskPane->m_nUserColorTask, clrText, clrTextHot);
}
//******************************************************************************************
void CTasksPaneView::OnColorTasktexthot() 
{
	UpdateData ();

	COLORREF clrTextHot = m_ColorTaskTextHot.GetColor ();	// (COLORREF)-1, if default
	COLORREF clrText = m_ColorTaskText.GetColor ();			// (COLORREF)-1, if default

	CTaskPane* pTaskPane = GetTasksPane ();
	ASSERT_VALID (pTaskPane);

	pTaskPane->SetTaskTextColor (pTaskPane->m_nUserColorGroup, pTaskPane->m_nUserColorTask, clrText, clrTextHot);
}
//******************************************************************************************
void CTasksPaneView::OnMargins() 
{
	UpdateData ();

	GetDlgItem (IDC_EDIT_VMARGIN)->EnableWindow (m_bCustomizeMargins);
	GetDlgItem (IDC_EDIT_HMARGIN)->EnableWindow (m_bCustomizeMargins);
	GetDlgItem (IDC_EDIT_GROUPSPACING)->EnableWindow (m_bCustomizeMargins);
	GetDlgItem (IDC_EDIT_TASKSPACING)->EnableWindow (m_bCustomizeMargins);
	GetDlgItem (IDC_EDIT_CAPTIONHEIGHT)->EnableWindow (m_bCustomizeMargins);
	GetDlgItem (IDC_EDIT_TASKOFFSET)->EnableWindow (m_bCustomizeMargins);
	GetDlgItem (IDC_EDIT_ICONOFFSET)->EnableWindow (m_bCustomizeMargins);

	GetDlgItem (IDC_SPIN3)->EnableWindow (m_bCustomizeMargins);
	GetDlgItem (IDC_SPIN4)->EnableWindow (m_bCustomizeMargins);
	GetDlgItem (IDC_SPIN5)->EnableWindow (m_bCustomizeMargins);
	GetDlgItem (IDC_SPIN6)->EnableWindow (m_bCustomizeMargins);
	GetDlgItem (IDC_SPIN7)->EnableWindow (m_bCustomizeMargins);
	GetDlgItem (IDC_SPIN8)->EnableWindow (m_bCustomizeMargins);
	GetDlgItem (IDC_SPIN9)->EnableWindow (m_bCustomizeMargins);

	GetDlgItem (IDC_STATIC_MARGINS1)->EnableWindow (m_bCustomizeMargins);
	GetDlgItem (IDC_STATIC_MARGINS2)->EnableWindow (m_bCustomizeMargins);
	GetDlgItem (IDC_STATIC_MARGINS3)->EnableWindow (m_bCustomizeMargins);
	GetDlgItem (IDC_STATIC_MARGINS4)->EnableWindow (m_bCustomizeMargins);
	GetDlgItem (IDC_STATIC_MARGINS5)->EnableWindow (m_bCustomizeMargins);
	GetDlgItem (IDC_STATIC_MARGINS6)->EnableWindow (m_bCustomizeMargins);
	GetDlgItem (IDC_STATIC_MARGINS7)->EnableWindow (m_bCustomizeMargins);

	if (m_bCustomizeMargins)
	{
		// <snippet2>
		// Retrieve visual manager's default values.
		m_nVMargin = CMFCVisualManager::GetInstance ()->GetTasksPaneVertMargin ();
		m_nHMargin = CMFCVisualManager::GetInstance ()->GetTasksPaneHorzMargin ();
		m_nGroupSpacing = CMFCVisualManager::GetInstance ()->GetTasksPaneGroupVertOffset ();
		m_nTaskSpacing = CMFCVisualManager::GetInstance ()->GetTasksPaneIconVertOffset ();
		m_nCaptionHeight = CMFCVisualManager::GetInstance ()->GetTasksPaneGroupCaptionHeight();
		m_nTaskOffset = CMFCVisualManager::GetInstance ()->GetTasksPaneTaskHorzOffset();
		m_nIconOffset = CMFCVisualManager::GetInstance ()->GetTasksPaneIconHorzOffset();
		// </snippet2>

		UpdateData (FALSE);
	}
	else
	{
		// reset visual manager's default values
		OnChangeMargins ();
	}
}
//******************************************************************************************
void CTasksPaneView::OnChangeMargins ()
{
	if (m_ColorTaskTextHot.GetSafeHwnd () == NULL)
	{
		return;
	}

	if (!UpdateData())
	{
		return;
	}

	CTaskPane* pTaskPane = GetTasksPane ();
	ASSERT_VALID (pTaskPane);

	if (m_bCustomizeMargins)
	{
		pTaskPane->SetVertMargin (m_nVMargin);
		pTaskPane->SetHorzMargin (m_nHMargin);
		pTaskPane->SetGroupVertOffset (m_nGroupSpacing);
		pTaskPane->SetTasksIconVertOffset (m_nTaskSpacing);
		pTaskPane->SetGroupCaptionHeight (m_nCaptionHeight);
		pTaskPane->SetTasksHorzOffset (m_nTaskOffset);
		pTaskPane->SetTasksIconHorzOffset (m_nIconOffset);
	}
	else
	{
		// use visual manager's default values
		pTaskPane->SetVertMargin (-1);
		pTaskPane->SetHorzMargin (-1);
		pTaskPane->SetGroupVertOffset (-1);
		pTaskPane->SetTasksIconVertOffset (-1);
		pTaskPane->SetGroupCaptionHeight (-1);
		pTaskPane->SetTasksHorzOffset (-1);
		pTaskPane->SetTasksIconHorzOffset (-1);
	}

	pTaskPane->RecalcLayout ();
}
//******************************************************************************************
void CTasksPaneView::OnCaptionicon() 
{
	BOOL bOld = m_bCaptionIcon;

	UpdateData ();

	if (bOld == m_bCaptionIcon)
	{
		return;
	}

	CTaskPane* pTaskPane = GetTasksPane ();
	ASSERT_VALID (pTaskPane);

	// --------------------------------------
	// Remove all groups from the first page:
	// --------------------------------------
	pTaskPane->RemoveAllGroups (0);

	// -----------------
	// Add groups again:
	// -----------------
	if (m_bCaptionIcon)
	{
		HICON hIcon = (HICON)LoadImage(AfxGetInstanceHandle (), 
                           MAKEINTRESOURCE (IDI_NOTE), 
                           IMAGE_ICON, 
                           0,
                           0,
                           LR_SHARED); 
		pTaskPane->m_nDocumentsGroup = pTaskPane->AddGroup (0, _T("Open a document"), FALSE, TRUE, hIcon);
	}
	else
	{
		pTaskPane->m_nDocumentsGroup = pTaskPane->AddGroup (0, _T("Open a document"), FALSE, TRUE);
	}

	// Add MRU list:
	pTaskPane->AddMRUFilesList (pTaskPane->m_nDocumentsGroup);
	pTaskPane->AddTask (pTaskPane->m_nDocumentsGroup, _T("More Documents..."), 0, ID_FILE_OPEN);

	int nPage1Gr2 = pTaskPane->AddGroup (0, _T("Custom group"));
	pTaskPane->m_nUserColorGroup = nPage1Gr2;

	pTaskPane->AddTask (nPage1Gr2, _T("Task 1"), 1, ID_TASK1);
	pTaskPane->m_nUserColorTask = 
		pTaskPane->AddTask (nPage1Gr2, _T("Task 2"), 2, ID_TASK2);
	pTaskPane->AddTask (nPage1Gr2, _T("Task 3"), 3, ID_TASK3);
	pTaskPane->AddSeparator (nPage1Gr2);
	pTaskPane->AddTask (nPage1Gr2, _T("Task 4"), 4, ID_TASK4);
	pTaskPane->AddTask (nPage1Gr2, _T("Task 5"), 5, ID_TASK5);
	pTaskPane->AddTask (nPage1Gr2, _T("Long task's name to see words wrap feature"), 6, ID_TASK6);

	int nPage1Gr3 = pTaskPane->AddGroup (0, _T("Details"), TRUE);
	pTaskPane->AddLabel (nPage1Gr3, _T("The Label contains text, which can be displayed in several lines. \n\nText can include line breaking characters \'\\n\' and &underline markers \'&&\'"));

	// Set custom colors again:
	OnColorGrouptext();
	OnColorGrouptexthot();
	OnColorTasktext();
	OnColorTasktexthot();

	pTaskPane->RecalcLayout ();
}

