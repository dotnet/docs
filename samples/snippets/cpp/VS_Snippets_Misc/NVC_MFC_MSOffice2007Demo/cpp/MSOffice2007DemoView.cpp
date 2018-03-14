// This MFC Samples source code demonstrates using MFC Microsoft Office Fluent User Interface 
// (the "Fluent UI") and is provided only as referential material to supplement the 
// Microsoft Foundation Classes Reference and related electronic documentation 
// included with the MFC C++ library software.  
// License terms to copy, use or distribute the Fluent UI are available separately.  
// To learn more about our Fluent UI licensing program, please visit 
// http://msdn.microsoft.com/officeui.
//
// Copyright (C) Microsoft Corporation
// All rights reserved.

#include "stdafx.h"
#include "MSOffice2007Demo.h"
#include "MainFrm.h"

#include "MSOffice2007DemoDoc.h"
#include "CntrItem.h"
#include "MSOffice2007DemoView.h"
#include "RibbonTableButton.h"

#ifdef _DEBUG
#define new DEBUG_NEW
#undef THIS_FILE
static char THIS_FILE[] = __FILE__;
#endif

#pragma warning(disable:4100)

#if _MSC_VER >= 1300
#define WPD_CHARFORMAT CHARFORMAT2
#define WPD_PARAFORMAT PARAFORMAT2
#else
#define WPD_CHARFORMAT CHARFORMAT
#define WPD_PARAFORMAT PARAFORMAT
#endif

struct CCharFormat : public WPD_CHARFORMAT
{
	CCharFormat() {cbSize = sizeof(WPD_CHARFORMAT);}
	BOOL operator== (CCharFormat& cf);
};

int GetTwipSize(CString str)
{
	LPCTSTR lpszText = str;

	while (*lpszText == ' ' || *lpszText == '\t')
		lpszText++;

	if (lpszText[0] == NULL)
		return -1; // no text in control

	double d = _tcstod(lpszText, (LPTSTR*)&lpszText);
	while (*lpszText == ' ' || *lpszText == '\t')
		lpszText++;

	if (*lpszText != NULL)
		return -2;   // not terminated properly

	return(d < 0.) ? 0 :(int)(d * 20.);
}

CString TwipsToPointString (int nTwips)
{
	CString str;
	if (nTwips >= 0)
	{
		// round to nearest half point
		nTwips = (nTwips + 5) / 10;

		if ((nTwips % 2) == 0)
		{
			str.Format (_T("%ld"), nTwips/2);
		}
		else
		{
			str.Format (_T("%.1f"), (float) nTwips / 2.F);
		}
	}

	return str;
}

/////////////////////////////////////////////////////////////////////////////
// CMSOffice2007DemoView

BOOL CMSOffice2007DemoView::m_bForceReloadBmps = FALSE;

IMPLEMENT_DYNCREATE(CMSOffice2007DemoView, CRichEditView)

BEGIN_MESSAGE_MAP(CMSOffice2007DemoView, CRichEditView)
	//{{AFX_MSG_MAP(CMSOffice2007DemoView)
	ON_WM_DESTROY()
	ON_WM_LBUTTONUP()
	ON_COMMAND(ID_WRITE_FONT, OnFontDialog)
	ON_COMMAND(ID_WRITE_PARAGRAPH, OnParagraphDialog)
	ON_COMMAND(ID_WRITE_STYLE, OnStyleDialog)
	ON_COMMAND(ID_PARA_PAGESETUP, OnPagesetupDialog)
	ON_WM_RBUTTONUP()
	ON_WM_CONTEXTMENU()
	ON_COMMAND(ID_EDIT_UNDO, OnEditUndo)
	ON_COMMAND(ID_PAGELAYOUT_INDENT_LEFT, OnPagelayoutIndentLeft)
	ON_COMMAND(ID_PAGELAYOUT_INDENT_RIGHT, OnPagelayoutIndentRight)
	ON_COMMAND(ID_INSERT_SHAPES, OnInsertShape)
	ON_COMMAND(ID_WRITE_QUICKSTYLES, OnQuickStyle)
	ON_COMMAND(ID_PAGELAYOUT_INDENT_LEFT, OnIndentLeft)
	ON_COMMAND(ID_PAGELAYOUT_INDENT_RIGHT, OnIndentRight)
	ON_COMMAND(ID_PAGELAYOUT_SPACE_AFTER, OnSpaceAfter)
	ON_COMMAND(ID_PAGELAYOUT_SPACE_BEFORE, OnSpaceBefore)
	ON_COMMAND(ID_VIEW_RULER, OnViewRuler)
	ON_COMMAND(ID_VIEW_GRIDLINES, OnViewGridLines)
	ON_COMMAND(ID_VIEW_PROPERTIES, OnViewProps)
	ON_COMMAND(ID_VIEW_DOCUMENTMAP, OnViewDocMap)
	ON_UPDATE_COMMAND_UI(ID_VIEW_RULER, OnUpdateViewRuler)
	ON_UPDATE_COMMAND_UI(ID_VIEW_GRIDLINES, OnUpdateViewGridLines)
	ON_UPDATE_COMMAND_UI(ID_VIEW_PROPERTIES, OnUpdateViewProps)
	ON_UPDATE_COMMAND_UI(ID_VIEW_DOCUMENTMAP, OnUpdateViewDocMap)
	ON_UPDATE_COMMAND_UI(ID_VIEW_TRUMBNAILS, OnUpdateViewThumb)
	ON_COMMAND(ID_INSERT_PICTURE, OnInsertPicture)
	ON_COMMAND(ID_INSERT_CHART, OnInsertChart)
	ON_COMMAND(ID_TABLE_TABLE, OnInsertTable)
	ON_COMMAND(ID_TABLE_DRAWTABLE, OnInsertTable)
	ON_WM_CREATE()
	ON_COMMAND(ID_FONT_COLOR, OnFontColor)
	ON_COMMAND(ID_FONT_FONT, OnFontname)
	ON_COMMAND(ID_FONT_FONTSIZE, OnFontsize)
	ON_COMMAND(ID_FONT_BOLD, OnCharBold)
	ON_UPDATE_COMMAND_UI(ID_FONT_BOLD, OnUpdateCharBold)
	ON_COMMAND(ID_FONT_STRIKETHROUGH, OnCharStrikeThrough)
	ON_UPDATE_COMMAND_UI(ID_FONT_STRIKETHROUGH, OnUpdateCharStrikeThrough)
	ON_COMMAND(ID_FONT_ITALIC, OnCharItalic)
	ON_UPDATE_COMMAND_UI(ID_FONT_ITALIC, OnUpdateCharItalic)
	ON_COMMAND(ID_FONT_UNDERLINE, OnCharUnderline)
	ON_UPDATE_COMMAND_UI(ID_FONT_UNDERLINE, OnUpdateCharUnderline)
	ON_COMMAND(ID_PARA_CENTER, OnParaCenter)
	ON_UPDATE_COMMAND_UI(ID_PARA_CENTER, OnUpdateParaCenter)
	ON_COMMAND(ID_PARA_ALIGNLEFT, OnParaLeft)
	ON_UPDATE_COMMAND_UI(ID_PARA_ALIGNLEFT, OnUpdateParaLeft)
	ON_COMMAND(ID_PARA_ALIGNRIGHT, OnParaRight)
	ON_UPDATE_COMMAND_UI(ID_PARA_ALIGNRIGHT, OnUpdateParaRight)
	ON_WM_DROPFILES()
	ON_COMMAND(ID_FILE_PRINT, OnFilePrint)
	ON_COMMAND(ID_FILE_PRINT_DIRECT, OnFilePrint)
	ON_COMMAND(ID_FILE_PRINT_PREVIEW, OnFilePrintPreview)
	ON_COMMAND(ID_PARA_BULLETS, CRichEditView::OnBullet)
	ON_UPDATE_COMMAND_UI(ID_PARA_BULLETS, CRichEditView::OnUpdateBullet)
	ON_EN_CHANGE(AFX_IDW_PANE_FIRST, OnEditChange)
	ON_NOTIFY_REFLECT(EN_SELCHANGE, OnSelChange)
	ON_UPDATE_COMMAND_UI(ID_STATUSBAR_PRINTLAYOUT, OnUpdatePrintLayout)
	ON_UPDATE_COMMAND_UI(ID_VIEW_PRINTLAYOUT, OnUpdatePrintLayout)
	ON_COMMAND(ID_FROM_PALETTE_BULLET, OnInsertBulletFromPalette)
	ON_COMMAND(ID_FROM_PALETTE_NUMBER, OnInsertNumberFromPalette)
	ON_COMMAND(ID_FROM_PALETTE_MULTILEVEL, OnInsertMultilevelFromPalette)
	ON_COMMAND(ID_FROM_PALETTE_TABLE, OnInsertTableGallery)
	ON_UPDATE_COMMAND_UI(ID_EDIT_FIND, OnUpdateEditFind)
	ON_UPDATE_COMMAND_UI(ID_EDIT_REPLACE, OnUpdateEditReplace)
	ON_COMMAND(ID_PAGELAYOUT_THEMES, OnPageLayoutTheme)
	//}}AFX_MSG_MAP
END_MESSAGE_MAP()

/////////////////////////////////////////////////////////////////////////////
// CMSOffice2007DemoView construction/destruction

CMSOffice2007DemoView::CMSOffice2007DemoView()
{
	m_bIsEndOfPrint = FALSE;
	m_bViewRuler = TRUE;
	m_bViewGridLines = TRUE;
	m_bViewProps = FALSE;
	m_bViewDocMap = FALSE;
	m_bViewThumb = FALSE;
}

CMSOffice2007DemoView::~CMSOffice2007DemoView()
{
}

BOOL CMSOffice2007DemoView::PreCreateWindow(CREATESTRUCT& cs)
{
	return CRichEditView::PreCreateWindow(cs);
}

void CMSOffice2007DemoView::OnInitialUpdate()
{
	CRichEditView::OnInitialUpdate();

	// Set the printing margins(720 twips = 1/2 inch).
	SetMargins(CRect(720, 720, 720, 720));

	CCharFormat cf;
	GetDefaultFont(cf);

	SetCharFormat(cf);
	SyncFont();
}

/////////////////////////////////////////////////////////////////////////////
// CMSOffice2007DemoView printing

void CMSOffice2007DemoView::OnFilePrintPreview()
{
	AFXPrintPreview(this);
}

BOOL CMSOffice2007DemoView::OnPreparePrinting(CPrintInfo* pInfo)
{
	// default preparation
	return DoPreparePrinting(pInfo);
}

void CMSOffice2007DemoView::OnPrepareDC(CDC* pDC, CPrintInfo* pInfo)
{
	if (m_bIsEndOfPrint)
	{
		pInfo->m_bContinuePrinting = FALSE;
		return;
	}

	CRichEditView::OnPrepareDC(pDC, pInfo);
}

void CMSOffice2007DemoView::OnDestroy()
{
	// Deactivate the item on destruction; this is important
	// when a splitter view is being used.
	COleClientItem* pActiveItem = GetDocument()->GetInPlaceActiveItem(this);
	if (pActiveItem != NULL && pActiveItem->GetActiveView() == this)
	{
		pActiveItem->Deactivate();
		ASSERT(GetDocument()->GetInPlaceActiveItem(this) == NULL);
	}

	CRichEditView::OnDestroy();
}

/////////////////////////////////////////////////////////////////////////////
// CMSOffice2007DemoView diagnostics

#ifdef _DEBUG
void CMSOffice2007DemoView::AssertValid() const
{
	CRichEditView::AssertValid();
}

void CMSOffice2007DemoView::Dump(CDumpContext& dc) const
{
	CRichEditView::Dump(dc);
}

CMSOffice2007DemoDoc* CMSOffice2007DemoView::GetDocument() // non-debug version is inline
{
	ASSERT(m_pDocument->IsKindOf(RUNTIME_CLASS(CMSOffice2007DemoDoc)));
	return(CMSOffice2007DemoDoc*)m_pDocument;
}
#endif //_DEBUG

/////////////////////////////////////////////////////////////////////////////
// CMSOffice2007DemoView message handlers

void CMSOffice2007DemoView::OnEditChange()
{
}

void CMSOffice2007DemoView::OnFontColor()
{
	CMFCRibbonBar* pRibbon = ((CMainFrame*) GetTopLevelFrame())->GetRibbonBar();
	ASSERT_VALID(pRibbon);

	CMFCRibbonColorButton* pFontColorBtn = DYNAMIC_DOWNCAST(CMFCRibbonColorButton, pRibbon->FindByID(ID_FONT_COLOR));

	if (pFontColorBtn != NULL)
	{
		COLORREF color = pFontColorBtn->GetColor();
		CRichEditView::OnColorPick(color == -1 ? ::GetSysColor(COLOR_WINDOWTEXT) : color);
	}
}

void CMSOffice2007DemoView::OnFontname()
{
	USES_CONVERSION;

	CMFCRibbonBar* pRibbon = ((CMainFrame*) GetTopLevelFrame())->GetRibbonBar();
	ASSERT_VALID(pRibbon);

	// <snippet6>
	CMFCRibbonFontComboBox* pFontCombo = DYNAMIC_DOWNCAST(CMFCRibbonFontComboBox, pRibbon->FindByID(ID_FONT_FONT));
	if (pFontCombo == NULL)
	{
		return;
	}

	CCharFormat cf;
	cf.szFaceName[0] = NULL;
	cf.dwMask = CFM_FACE | CFM_CHARSET;

	const CMFCFontInfo* pDesc = pFontCombo->GetFontDesc();
	ASSERT_VALID(pDesc);
	ASSERT(pDesc->m_strName.GetLength() < LF_FACESIZE);

#if _MSC_VER >= 1300
	lstrcpyn(cf.szFaceName, pDesc->m_strName, LF_FACESIZE);
#else
	lstrcpynA(cf.szFaceName, T2A((LPTSTR)(LPCTSTR) pDesc->m_strName), LF_FACESIZE);
#endif

	cf.bCharSet = pDesc->m_nCharSet;
	cf.bPitchAndFamily = pDesc->m_nPitchAndFamily;
	// </snippet6>

	SetCharFormat(cf);
}

void CMSOffice2007DemoView::OnFontsize()
{
	CMFCRibbonBar* pRibbon = ((CMainFrame*) GetTopLevelFrame())->GetRibbonBar();
	ASSERT_VALID(pRibbon);

	CMFCRibbonComboBox* pSizeCombo = DYNAMIC_DOWNCAST(CMFCRibbonComboBox, pRibbon->FindByID(ID_FONT_FONTSIZE));
	if (pSizeCombo == NULL)
	{
		return;
	}

	int nSize = GetTwipSize(pSizeCombo->GetEditText());

	if (nSize == -2 || (nSize >= 0 && nSize < 20) || nSize > 32760)
	{
		// Restore current size:
		pSizeCombo->SetEditText (TwipsToPointString (GetCharFormatSelection ().yHeight));

		MessageBox (_T("The number must be between 1 and 1638."));                               
		return;
	}

	if (nSize > 0)
	{
		CCharFormat cf;
		cf.dwMask = CFM_SIZE;
		cf.yHeight = nSize;

		SetCharFormat(cf);
	}
}

void CMSOffice2007DemoView::OnLButtonUp(UINT nFlags, CPoint point)
{
	CRichEditView::OnLButtonUp(nFlags, point);

	if (GetSelectedItem() != NULL || CMFCPopupMenu::GetActiveMenu() != NULL || GetRichEditCtrl().GetSelText().IsEmpty())
	{
		return;
	}

	if (!theApp.m_bShowFloaty)
	{
		return;
	}

	CMFCRibbonMiniToolBar* pFloaty = new CMFCRibbonMiniToolBar;

	InitFloaty(pFloaty);

	ClientToScreen(&point);
	pFloaty->Show(point.x, point.y);
}

void CMSOffice2007DemoView::OnFontDialog()
{
	CRichEditView::OnFormatFont();
}

void CMSOffice2007DemoView::OnParagraphDialog()
{
	AfxMessageBox(_T("Show your Paragraph dialog here."));
}

void CMSOffice2007DemoView::OnStyleDialog()
{
	AfxMessageBox(_T("Show your Style dialog here."));
}

void CMSOffice2007DemoView::OnPagesetupDialog()
{
	AfxMessageBox(_T("Show your page setup dialog here."));
}

BOOL CMSOffice2007DemoView::ShowContextMenu(CPoint point)
{
	if (DYNAMIC_DOWNCAST(CFrameWndEx, GetParentFrame()) == NULL)
	{
		// Maybe, server mode, show the regular menu!
		return FALSE;
	}

	CRichEditCntrItem* pItem = GetSelectedItem();
	if (pItem == NULL || !pItem->IsInPlaceActive())
	{
		CMFCRibbonMiniToolBar* pFloaty = new CMFCRibbonMiniToolBar;

		InitFloaty(pFloaty);

		pFloaty->ShowWithContextMenu(point.x, point.y, IDR_CONTEXT_MENU, this);
		return TRUE;
	}

	return FALSE;
}

void CMSOffice2007DemoView::OnRButtonUp(UINT nFlags, CPoint point)
{
	long nStartChar, nEndChar;
	GetRichEditCtrl().GetSel(nStartChar, nEndChar);
	if (nEndChar - nStartChar <= 1)
	{
		SendMessage(WM_LBUTTONDOWN, nFlags, MAKELPARAM(point.x, point.y));
		ReleaseCapture ();
	}

	CPoint ptScreen = point;
	ClientToScreen(&ptScreen);

	if (!ShowContextMenu(ptScreen))
	{
		Default();
	}
}

void CMSOffice2007DemoView::OnContextMenu(CWnd* pWnd, CPoint point)
{
	if (!ShowContextMenu(point))
	{
		Default();
	}
}
void CMSOffice2007DemoView::OnBeginPrinting(CDC* pDC, CPrintInfo* pInfo)
{
	m_bIsEndOfPrint = FALSE;

	CRichEditView::OnBeginPrinting(pDC, pInfo);
}

void CMSOffice2007DemoView::OnEndPrinting(CDC* pDC, CPrintInfo* pInfo)
{
	m_bIsEndOfPrint = TRUE;

	CRichEditView::OnEndPrinting(pDC, pInfo);
}

void CMSOffice2007DemoView::OnInsertPicture()
{
	WPD_CHARFORMAT cf = GetCharFormatSelection();
	InsertBitmap(IDB_PICTURE);
	SetCharFormat (cf);
	SyncFont ();
}

void CMSOffice2007DemoView::OnInsertChart()
{
	WPD_CHARFORMAT cf = GetCharFormatSelection();
	InsertBitmap(IDB_CHART);
	SetCharFormat (cf);
	SyncFont ();
}

void CMSOffice2007DemoView::OnInsertTable()
{
	WPD_CHARFORMAT cf = GetCharFormatSelection();
	InsertBitmap(IDB_TABLE);
	SetCharFormat (cf);
	SyncFont ();
}

BOOL CMSOffice2007DemoView::InsertBitmap(UINT uiBmpResID)
{
	CWaitCursor wait;

	CBitmap bmp;
	if (!bmp.LoadBitmap(uiBmpResID))
	{
		return FALSE;
	}

	COleDataSource* pDataSrc = new COleDataSource;
	COleDataObject* pData = new COleDataObject;

	CMSOffice2007DemoCntrItem* pItem = NULL;

	TRY
	{
		STGMEDIUM stgm;
		stgm.hGlobal = bmp.GetSafeHandle();
		stgm.tymed = TYMED_GDI;
		stgm.pUnkForRelease = NULL;

		pDataSrc->CacheData(CF_BITMAP, &stgm);

		LPDATAOBJECT lpdata;

		if (FAILED(pDataSrc->m_xDataObject.QueryInterface(IID_IDataObject,
			(LPVOID FAR*) &lpdata)))
		{
			AfxThrowUserException();
		}

		pData->Attach(lpdata);

		CMSOffice2007DemoDoc* pDoc = GetDocument();
		ASSERT_VALID(pDoc);

		pItem = new CMSOffice2007DemoCntrItem(NULL, pDoc);
		ASSERT_VALID(pItem);

		if (!pItem->CreateStaticFromData(pData))
		{
			AfxThrowUserException();
		}

		pItem->m_uiCategoryID = uiBmpResID;
		InsertItem(pItem);

		pDoc->UpdateAllViews(this);
	}
	CATCH(CException, e)
	{
		if (pItem != NULL)
		{
			ASSERT_VALID(pItem);
			pItem->Delete();
		}

		delete pData;
		delete pDataSrc;

		return FALSE;
	}
	END_CATCH

	delete pData;
	delete pDataSrc;

	CMainFrame* pMainFrame = ((CMainFrame*) GetTopLevelFrame());
	ASSERT_VALID(pMainFrame);

	pMainFrame->ActivateRibbonContextCategory(uiBmpResID);

	return TRUE;
}

void CMSOffice2007DemoView::OnSelChange(NMHDR* pNMHDR, LRESULT* pResult)
{
	CRichEditView::OnSelChange(pNMHDR, pResult);

	CMainFrame* pMainFrame = ((CMainFrame*) GetTopLevelFrame());
	ASSERT_VALID(pMainFrame);

	UINT uiCategoryID = 0;

	CMSOffice2007DemoCntrItem* pItem = (CMSOffice2007DemoCntrItem*) GetSelectedItem();

	if (pItem != NULL)
	{
		uiCategoryID = pItem->m_uiCategoryID;
	}

	pMainFrame->SetRibbonContextCategory(uiCategoryID);

	SyncFont();
}

void CMSOffice2007DemoView::OnUpdatePrintLayout(CCmdUI* pCmdUI)
{
	pCmdUI->SetCheck();
}

void CMSOffice2007DemoView::OnIndentLeft()
{
}

void CMSOffice2007DemoView::OnIndentRight()
{
}

void CMSOffice2007DemoView::OnSpaceAfter()
{
}

void CMSOffice2007DemoView::OnSpaceBefore()
{
}

void CMSOffice2007DemoView::SyncFont()
{
	USES_CONVERSION;

	CString strFontName;


	// get the current font from the view and update
	WPD_CHARFORMAT cf = GetCharFormatSelection();

	CMFCRibbonBar* pRibbon = ((CMainFrame*) GetTopLevelFrame())->GetRibbonBar();
	ASSERT_VALID(pRibbon);

	CMFCRibbonFontComboBox* pFontCombo = DYNAMIC_DOWNCAST(CMFCRibbonFontComboBox, pRibbon->FindByID(ID_FONT_FONT));

	if (pFontCombo != NULL && !pFontCombo->HasFocus())
	{
		if ((cf.dwMask &(CFM_FACE|CFM_CHARSET)) == (CFM_FACE|CFM_CHARSET))
		{
#if _MSC_VER >= 1300
			strFontName = cf.szFaceName;
#else
			strFontName = A2T(cf.szFaceName);
#endif
			pFontCombo->SetFont(strFontName, DEFAULT_CHARSET, TRUE);
		}
		else
		{
			pFontCombo->SetText(_T(""));
		}
	}

	SetFocus();
}

void CMSOffice2007DemoView::GetDefaultFont(CCharFormat& cf)
{
	USES_CONVERSION;

	CString strDefFont = _T("Tahoma");

	ASSERT(cf.cbSize == sizeof(WPD_CHARFORMAT));
	cf.dwMask = CFM_BOLD|CFM_ITALIC|CFM_UNDERLINE|CFM_STRIKEOUT|CFM_SIZE| CFM_COLOR|CFM_OFFSET|CFM_PROTECTED;
	cf.dwEffects = CFE_AUTOCOLOR;
	cf.yHeight = 200; //10pt
	cf.yOffset = 0;
	cf.crTextColor = RGB(0, 0, 0);
	cf.bCharSet = 0;
	cf.bPitchAndFamily = DEFAULT_PITCH | FF_DONTCARE;
	ASSERT(strDefFont.GetLength() < LF_FACESIZE);
#if _MSC_VER >= 1300
	lstrcpyn(cf.szFaceName, strDefFont, LF_FACESIZE);
#else
	lstrcpynA(cf.szFaceName, T2A((LPTSTR)(LPCTSTR) strDefFont), LF_FACESIZE);
#endif
	cf.dwMask |= CFM_FACE;
}

void CMSOffice2007DemoView::OnViewRuler()
{
	m_bViewRuler = !m_bViewRuler;
}

void CMSOffice2007DemoView::OnViewGridLines()
{
	m_bViewGridLines = !m_bViewGridLines;
}

void CMSOffice2007DemoView::OnViewProps()
{
	m_bViewProps = !m_bViewProps;
}

void CMSOffice2007DemoView::OnViewDocMap()
{
	m_bViewDocMap = !m_bViewDocMap;
}

void CMSOffice2007DemoView::OnUpdateViewRuler(CCmdUI* pCmdUI)
{
	pCmdUI->SetCheck(m_bViewRuler);
}

void CMSOffice2007DemoView::OnUpdateViewGridLines(CCmdUI* pCmdUI)
{
	pCmdUI->SetCheck(m_bViewGridLines);
}

void CMSOffice2007DemoView::OnUpdateViewProps(CCmdUI* pCmdUI)
{
	pCmdUI->SetCheck(m_bViewProps);
}

void CMSOffice2007DemoView::OnUpdateViewDocMap(CCmdUI* pCmdUI)
{
	pCmdUI->SetCheck(m_bViewDocMap);
}

void CMSOffice2007DemoView::OnUpdateViewThumb(CCmdUI* pCmdUI)
{
	pCmdUI->Enable(FALSE);
}

void CMSOffice2007DemoView::OnInsertBulletFromPalette()
{
	CString str;
	str.Format(_T("Insert Bullet from Palette %d"), CMFCRibbonGallery::GetLastSelectedItem(ID_FROM_PALETTE_BULLET));

	MessageBox(str);
}

void CMSOffice2007DemoView::OnInsertNumberFromPalette()
{
	CString str;
	str.Format(_T("Insert Number from Palette %d"), CMFCRibbonGallery::GetLastSelectedItem(ID_FROM_PALETTE_NUMBER));

	MessageBox(str);
}

void CMSOffice2007DemoView::OnInsertMultilevelFromPalette()
{
	CString str;
	str.Format(_T("Insert Multilevel List from Palette %d"), CMFCRibbonGallery::GetLastSelectedItem(ID_FROM_PALETTE_MULTILEVEL));

	MessageBox(str);
}

void CMSOffice2007DemoView::InitFloaty(CMFCRibbonMiniToolBar* pFloaty)
{
	ASSERT_VALID(pFloaty);

	// <snippet9>
	// CMFCRibbonMiniToolBar* pFloaty
	CList<UINT, UINT> lstCmds;

	lstCmds.AddTail(ID_FONT_FONT);
	lstCmds.AddTail(ID_FONT_FONTSIZE);
	lstCmds.AddTail(ID_FONT_GROWFONT);
	lstCmds.AddTail(ID_FONT_SHRINK);
	lstCmds.AddTail(ID_WRITE_CHANGESTYLES);
	lstCmds.AddTail(ID_EDIT_COPYFORMAT);
	lstCmds.AddTail(ID_FONT_BOLD);
	lstCmds.AddTail(ID_FONT_ITALIC);
	lstCmds.AddTail(ID_PARA_CENTER);
	lstCmds.AddTail(ID_FONT_TEXTHIGHLIGHT);
	lstCmds.AddTail(ID_FONT_COLOR);
	lstCmds.AddTail(ID_PARA_DECREASEINDENT);
	lstCmds.AddTail(ID_PARA_INCREASEINDENT);
	lstCmds.AddTail(ID_PARA_BULLETS);

	pFloaty->SetCommands(((CMainFrame*) GetTopLevelFrame())->GetRibbonBar(), lstCmds);
	// </snippet9>
}

void CMSOffice2007DemoView::OnCharStrikeThrough()
{
	OnCharEffect(CFM_STRIKEOUT, CFE_STRIKEOUT);
}

void CMSOffice2007DemoView::OnUpdateCharStrikeThrough(CCmdUI* pCmdUI)
{
	OnUpdateCharEffect(pCmdUI, CFM_STRIKEOUT, CFE_STRIKEOUT);
}

void CMSOffice2007DemoView::OnEditUndo()
{
	CMFCRibbonBar* pRibbon = ((CMainFrame*) GetTopLevelFrame())->GetRibbonBar();
	ASSERT_VALID(pRibbon);

	CMFCRibbonUndoButton* pUndoBtn = DYNAMIC_DOWNCAST(CMFCRibbonUndoButton, pRibbon->FindByID(ID_EDIT_UNDO));

	if (pUndoBtn != NULL && pUndoBtn->GetActionNumber() > 0)
	{
		CString str;
		str.Format(_T("Demo: undo %d action(s)"), pUndoBtn->GetActionNumber());

		MessageBox(str);
		return;
	}

	CRichEditView::OnEditUndo();
}

void CMSOffice2007DemoView::OnInsertTableGallery()
{
	if (CRibbonTableButton::GetRows() > 0 && CRibbonTableButton::GetColumns() > 0)
	{
		CString str;
		str.Format(_T("Demo: insert %dx%d table"), CRibbonTableButton::GetColumns(), CRibbonTableButton::GetRows());

		MessageBox(str);

		WPD_CHARFORMAT cf = GetCharFormatSelection();
		InsertBitmap(IDB_TABLE);
		SetCharFormat (cf);
		SyncFont ();
	}
}

void CMSOffice2007DemoView::OnInsertShape()
{
	CString str;
	str.Format(_T("Insert Shape from Palette %d"), CMFCRibbonGallery::GetLastSelectedItem(ID_INSERT_SHAPES));

	MessageBox(str);
}

void CMSOffice2007DemoView::OnQuickStyle()
{
	CString str;
	str.Format(_T("Change Style %d"), CMFCRibbonGallery::GetLastSelectedItem(ID_WRITE_QUICKSTYLES));

	MessageBox(str);
}

void CMSOffice2007DemoView::OnUpdateEditFind(CCmdUI* pCmdUI)
{
	pCmdUI->Enable(TRUE);
}

void CMSOffice2007DemoView::OnUpdateEditReplace(CCmdUI* pCmdUI)
{
	pCmdUI->Enable(TRUE);
}

void CMSOffice2007DemoView::OnPagelayoutIndentLeft()
{
	CMFCRibbonBar* pRibbon = ((CMainFrame*) GetTopLevelFrame())->GetRibbonBar();
	ASSERT_VALID(pRibbon);

	CMFCRibbonEdit* pEdit = DYNAMIC_DOWNCAST(CMFCRibbonEdit, pRibbon->FindByID(ID_PAGELAYOUT_INDENT_LEFT));

	WPD_PARAFORMAT pf;
	pf.cbSize = sizeof(PARAFORMAT);
	pf.dwMask = PFM_STARTINDENT;
	pf.dxStartIndent = _ttol(pEdit->GetEditText()) * 10;

	SetParaFormat(pf);
}

void CMSOffice2007DemoView::OnPagelayoutIndentRight()
{
	CMFCRibbonBar* pRibbon = ((CMainFrame*) GetTopLevelFrame())->GetRibbonBar();
	ASSERT_VALID(pRibbon);

	CMFCRibbonEdit* pEdit = DYNAMIC_DOWNCAST(CMFCRibbonEdit, pRibbon->FindByID(ID_PAGELAYOUT_INDENT_RIGHT));

	WPD_PARAFORMAT pf;
	pf.cbSize = sizeof(PARAFORMAT);
	pf.dwMask = PFM_RIGHTINDENT;
	pf.dxRightIndent = _ttol(pEdit->GetEditText()) * 10;

	SetParaFormat(pf);
}

void CMSOffice2007DemoView::OnPageLayoutTheme()
{
	CString str;
	str.Format(_T("Change Theme: %d"), CMFCRibbonGallery::GetLastSelectedItem(ID_PAGELAYOUT_THEMES));

	MessageBox(str);
}

