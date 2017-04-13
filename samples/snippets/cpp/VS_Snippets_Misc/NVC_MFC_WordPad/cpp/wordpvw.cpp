//
// wordpvw.cpp : implementation of the CWordPadView class
//
// This is a part of the Microsoft Foundation Classes C++ library.
// Copyright (C) 1992-1998 Microsoft Corporation
// All rights reserved.
//
// This source code is only intended as a supplement to the
// Microsoft Foundation Classes Reference and related
// electronic documentation provided with the library.
// See these sources for detailed information regarding the
// Microsoft Foundation Classes product.

#include "stdafx.h"
#include "wordpad.h"
#include "cntritem.h"
#include "srvritem.h"

#include "wordpdoc.h"
#include "wordpvw.h"
#include "formatta.h"
#include "datedial.h"
#include "formatpa.h"
#include "ruler.h"
#include "strings.h"
#include "pageset.h"

extern CLIPFORMAT cfEmbeddedObject;
extern CLIPFORMAT cfRTO;

#ifdef _DEBUG
#undef THIS_FILE
static char BASED_CODE THIS_FILE[] = __FILE__;
#endif

BOOL CCharFormat::operator==(CCharFormat& cf)
{
	return
	dwMask == cf.dwMask
	&& dwEffects == cf.dwEffects
	&& yHeight == cf.yHeight
	&& yOffset == cf.yOffset
	&& crTextColor == cf.crTextColor
	&& bPitchAndFamily == cf.bPitchAndFamily
	&& (lstrcmp(szFaceName, cf.szFaceName) == 0);
}

BOOL CParaFormat::operator==(WPD_PARAFORMAT& pf)
{
	if(
		dwMask != pf.dwMask
		|| wNumbering != pf.wNumbering
#if _MSC_VER < 1500
		|| wReserved != pf.wReserved
#endif
		|| dxStartIndent != pf.dxStartIndent
		|| dxRightIndent != pf.dxRightIndent
		|| dxOffset != pf.dxOffset
		|| cTabCount != pf.cTabCount
		)
	{
		return FALSE;
	}
	for (int i=0;i<pf.cTabCount;i++)
	{
		if (rgxTabs[i] != pf.rgxTabs[i])
			return FALSE;
	}
	return TRUE;
}

/////////////////////////////////////////////////////////////////////////////
// CWordPadView

IMPLEMENT_DYNCREATE(CWordPadView, CRichEditView)

//WM_SETTINGCHANGE -- default printer might have changed
//WM_FONTCHANGE -- pool of fonts changed
//WM_DEVMODECHANGE -- printer settings changes

BEGIN_MESSAGE_MAP(CWordPadView, CRichEditView)
	ON_COMMAND(ID_CANCEL_EDIT_CNTR, OnCancelEditCntr)
	ON_COMMAND(ID_CANCEL_EDIT_SRVR, OnCancelEditSrvr)
	//{{AFX_MSG_MAP(CWordPadView)
	ON_WM_CREATE()
	ON_COMMAND(ID_PAGE_SETUP, OnPageSetup)
	ON_COMMAND(ID_INSERT_DATE_TIME, OnInsertDateTime)
	ON_COMMAND(ID_FORMAT_PARAGRAPH, OnFormatParagraph)
	ON_COMMAND(ID_FORMAT_TABS, OnFormatTabs)
	ON_WM_TIMER()
	ON_WM_DESTROY()
	ON_WM_MEASUREITEM()
	ON_COMMAND(ID_PEN_BACKSPACE, OnPenBackspace)
	ON_COMMAND(ID_PEN_NEWLINE, OnPenNewline)
	ON_COMMAND(ID_PEN_PERIOD, OnPenPeriod)
	ON_COMMAND(ID_PEN_SPACE, OnPenSpace)
	ON_WM_KEYDOWN()
	ON_COMMAND(ID_FILE_PRINT, OnFilePrint)
	ON_COMMAND(ID_PEN_LENS, OnPenLens)
	ON_COMMAND(ID_PEN_TAB, OnPenTab)
	ON_WM_PALETTECHANGED()
	ON_WM_QUERYNEWPALETTE()
	ON_WM_SETTINGCHANGE()
	ON_WM_SIZE()
	ON_WM_CONTEXTMENU()
	ON_WM_RBUTTONUP()
	ON_COMMAND(ID_CHAR_COLOR, OnCharColor)
	ON_COMMAND(ID_FILE_PRINT_PREVIEW, OnFilePrintPreview)
	ON_COMMAND(IDC_FONTNAME, OnFontname)
	ON_COMMAND(IDC_FONTSIZE, OnFontsize)
	ON_COMMAND(ID_CHAR_BOLD, OnCharBold)
	ON_UPDATE_COMMAND_UI(ID_CHAR_BOLD, OnUpdateCharBold)
	ON_COMMAND(ID_CHAR_ITALIC, OnCharItalic)
	ON_UPDATE_COMMAND_UI(ID_CHAR_ITALIC, OnUpdateCharItalic)
	ON_COMMAND(ID_CHAR_UNDERLINE, OnCharUnderline)
	ON_UPDATE_COMMAND_UI(ID_CHAR_UNDERLINE, OnUpdateCharUnderline)
	ON_COMMAND(ID_PARA_CENTER, OnParaCenter)
	ON_UPDATE_COMMAND_UI(ID_PARA_CENTER, OnUpdateParaCenter)
	ON_COMMAND(ID_PARA_LEFT, OnParaLeft)
	ON_UPDATE_COMMAND_UI(ID_PARA_LEFT, OnUpdateParaLeft)
	ON_COMMAND(ID_PARA_RIGHT, OnParaRight)
	ON_UPDATE_COMMAND_UI(ID_PARA_RIGHT, OnUpdateParaRight)
	ON_COMMAND(ID_FILE_PRINT_DIRECT, OnFilePrint)
	ON_WM_DROPFILES()
	//}}AFX_MSG_MAP
	// Standard printing commands
	ON_COMMAND(ID_INSERT_BULLET, CRichEditView::OnBullet)
	ON_UPDATE_COMMAND_UI(ID_INSERT_BULLET, CRichEditView::OnUpdateBullet)
	ON_EN_CHANGE(AFX_IDW_PANE_FIRST, OnEditChange)
	ON_WM_MOUSEACTIVATE()
	ON_NOTIFY_RANGE(NM_SETFOCUS, AFX_IDW_CONTROLBAR_FIRST, AFX_IDW_CONTROLBAR_LAST, OnBarSetFocus)
	ON_NOTIFY_RANGE(NM_KILLFOCUS, AFX_IDW_CONTROLBAR_FIRST, AFX_IDW_CONTROLBAR_LAST, OnBarKillFocus)
	ON_NOTIFY_RANGE(NM_RETURN, AFX_IDW_CONTROLBAR_FIRST, AFX_IDW_CONTROLBAR_LAST, OnBarReturn)
	ON_CBN_SELENDOK(IDC_FONTNAME, OnFontname)
	ON_CBN_SELENDOK(IDC_FONTSIZE, OnFontsize)
	ON_COMMAND_RANGE(ID_BORDER_1, ID_BORDER_13, OnBorderType)
	ON_UPDATE_COMMAND_UI_RANGE(ID_BORDER_1, ID_BORDER_13, OnUpdateBorderType)
END_MESSAGE_MAP()

/////////////////////////////////////////////////////////////////////////////
// CWordPadView construction/destruction

CWordPadView::CWordPadView()
{
	m_bSyncCharFormat = m_bSyncParaFormat = TRUE;
	m_uTimerID = 0;
	m_bDelayUpdateItems = FALSE;
	m_bOnBar = FALSE;
	m_bInPrint = FALSE;
	m_nPasteType = 0;
	m_rectMargin = theApp.m_rectPageMargin;
	m_nBorderType = ID_BORDER_1;
}

BOOL CWordPadView::PreCreateWindow(CREATESTRUCT& cs)
{
	BOOL bRes = CRichEditView::PreCreateWindow(cs);
	cs.style |= ES_SELECTIONBAR;
	return bRes;
}

/////////////////////////////////////////////////////////////////////////////
// CWordPadView attributes

BOOL CWordPadView::IsFormatText()
{
	// this function checks to see if any formatting is not default text
	BOOL bRes = FALSE;
	CHARRANGE cr;
	CCharFormat cf;
	CParaFormat pf;
	GetRichEditCtrl().GetSel(cr);
	GetRichEditCtrl().HideSelection(TRUE, FALSE);
	GetRichEditCtrl().SetSel(0,-1);

	if (!(GetRichEditCtrl().GetSelectionType() & (SEL_OBJECT|SEL_MULTIOBJECT)))
	{
		GetRichEditCtrl().GetSelectionCharFormat(cf);
		if (cf == m_defTextCharFormat)
		{
			GetRichEditCtrl().GetParaFormat(pf);
			if (pf == m_defParaFormat) //compared using CParaFormat::operator==
				bRes = TRUE;
		}
	}

	GetRichEditCtrl().SetSel(cr);
	GetRichEditCtrl().HideSelection(FALSE, FALSE);
	return bRes;
}

HMENU CWordPadView::GetContextMenu(WORD, LPOLEOBJECT, CHARRANGE* )
{
	return NULL;
}

/////////////////////////////////////////////////////////////////////////////
// CWordPadView operations

void CWordPadView::WrapChanged()
{
	CWaitCursor wait;
	CFrameWnd* pFrameWnd = GetParentFrame();
	ASSERT(pFrameWnd != NULL);
	pFrameWnd->SetMessageText(IDS_FORMATTING);
	CWnd* pBarWnd = pFrameWnd->GetMessageBar();
	if (pBarWnd != NULL)
		pBarWnd->UpdateWindow();

	CRichEditView::WrapChanged();

	pFrameWnd->SetMessageText(AFX_IDS_IDLEMESSAGE);
	if (pBarWnd != NULL)
		pBarWnd->UpdateWindow();
}

void CWordPadView::SetUpdateTimer()
{
	if (m_uTimerID != 0) // if outstanding timer kill it
		KillTimer(m_uTimerID);
	m_uTimerID = SetTimer(1, 1000, NULL); //set a timer for 1000 milliseconds
	if (m_uTimerID == 0) // no timer available so force update now
		GetDocument()->UpdateAllItems(NULL);
	else
		m_bDelayUpdateItems = TRUE;
}

void CWordPadView::DeleteContents()
{
	ASSERT_VALID(this);
	ASSERT(m_hWnd != NULL);
	CRichEditView::DeleteContents();
	SetDefaultFont(IsTextType(GetDocument()->m_nNewDocType));
}

void CWordPadView::SetDefaultFont(BOOL bText)
{
	ASSERT_VALID(this);
	ASSERT(m_hWnd != NULL);
	m_bSyncCharFormat = m_bSyncParaFormat = TRUE;
	WPD_CHARFORMAT* pCharFormat = bText ? &m_defTextCharFormat : &m_defCharFormat;
	// set the default character format -- the FALSE makes it the default
	GetRichEditCtrl().SetSel(0,-1);
	GetRichEditCtrl().SetDefaultCharFormat(*pCharFormat);
	GetRichEditCtrl().SetSelectionCharFormat(*pCharFormat);

	GetRichEditCtrl().SetParaFormat(m_defParaFormat);

	GetRichEditCtrl().SetSel(0,0);
	GetRichEditCtrl().EmptyUndoBuffer();
	GetRichEditCtrl().SetModify(FALSE);
	ASSERT_VALID(this);
}

/////////////////////////////////////////////////////////////////////////////
// CWordPadView drawing

/////////////////////////////////////////////////////////////////////////////
// CWordPadView printing

void CWordPadView::OnPrint(CDC* pDC, CPrintInfo* pInfo)
{
	CRichEditView::OnPrint(pDC, pInfo);
	if (pInfo != NULL && pInfo->m_bPreview)
		DrawMargins(pDC);
}

void CWordPadView::DrawMargins(CDC* pDC)
{
	if (pDC->m_hAttribDC != NULL)
	{
		CRect rect;
		rect.left = m_rectMargin.left;
		rect.right = m_sizePaper.cx - m_rectMargin.right;
		rect.top = m_rectMargin.top;
		rect.bottom = m_sizePaper.cy - m_rectMargin.bottom;
		//rect in twips
		int logx = ::GetDeviceCaps(pDC->m_hDC, LOGPIXELSX);
		int logy = ::GetDeviceCaps(pDC->m_hDC, LOGPIXELSY);
		rect.left = MulDiv(rect.left, logx, 1440);
		rect.right = MulDiv(rect.right, logx, 1440);
		rect.top = MulDiv(rect.top, logy, 1440);
		rect.bottom = MulDiv(rect.bottom, logy, 1440);
		CPen pen(PS_DOT, 0, pDC->GetTextColor());
		CPen* ppen = pDC->SelectObject(&pen);
		pDC->MoveTo(0, rect.top);
		pDC->LineTo(10000, rect.top);
		pDC->MoveTo(rect.left, 0);
		pDC->LineTo(rect.left, 10000);
		pDC->MoveTo(0, rect.bottom);
		pDC->LineTo(10000, rect.bottom);
		pDC->MoveTo(rect.right, 0);
		pDC->LineTo(rect.right, 10000);
		pDC->SelectObject(ppen);
	}
}

BOOL CWordPadView::OnPreparePrinting(CPrintInfo* pInfo)
{
	return DoPreparePrinting(pInfo);
}

/////////////////////////////////////////////////////////////////////////////
// OLE Client support and commands

inline int roundleast(int n)
{
	int mod = n%10;
	n -= mod;
	if (mod >= 5)
		n += 10;
	else if (mod <= -5)
		n -= 10;
	return n;
}

static void RoundRect(LPRECT r1)
{
	r1->left = roundleast(r1->left);
	r1->right = roundleast(r1->right);
	r1->top = roundleast(r1->top);
	r1->bottom = roundleast(r1->bottom);
}

static void MulDivRect(LPRECT r1, LPRECT r2, int num, int div)
{
	r1->left = MulDiv(r2->left, num, div);
	r1->top = MulDiv(r2->top, num, div);
	r1->right = MulDiv(r2->right, num, div);
	r1->bottom = MulDiv(r2->bottom, num, div);
}

void CWordPadView::OnPageSetup()
{
	CPageSetupDialog dlg;
	PAGESETUPDLG& psd = dlg.m_psd;
	BOOL bMetric = theApp.GetUnits() == 1; //centimeters
	psd.Flags |= PSD_MARGINS | (bMetric ? PSD_INHUNDREDTHSOFMILLIMETERS :
		PSD_INTHOUSANDTHSOFINCHES);
	int nUnitsPerInch = bMetric ? 2540 : 1000;
	MulDivRect(&psd.rtMargin, m_rectMargin, nUnitsPerInch, 1440);
	RoundRect(&psd.rtMargin);
	// get the current device from the app
	PRINTDLG pd;
	pd.hDevNames = NULL;
	pd.hDevMode = NULL;
	theApp.GetPrinterDeviceDefaults(&pd);
	psd.hDevNames = pd.hDevNames;
	psd.hDevMode = pd.hDevMode;
	if (dlg.DoModal() == IDOK)
	{
		RoundRect(&psd.rtMargin);
		MulDivRect(m_rectMargin, &psd.rtMargin, 1440, nUnitsPerInch);
		theApp.m_rectPageMargin = m_rectMargin;
		theApp.SelectPrinter(psd.hDevNames, psd.hDevMode);
		theApp.NotifyPrinterChanged();
	}
	// PageSetupDlg failed
	if (CommDlgExtendedError() != 0)
	{
		CPageSetupDlg dlg;
		dlg.m_nBottomMargin = m_rectMargin.bottom;
		dlg.m_nLeftMargin = m_rectMargin.left;
		dlg.m_nRightMargin = m_rectMargin.right;
		dlg.m_nTopMargin = m_rectMargin.top;
		if (dlg.DoModal() == IDOK)
		{
			m_rectMargin.SetRect(dlg.m_nLeftMargin, dlg.m_nTopMargin,
				dlg.m_nRightMargin, dlg.m_nBottomMargin);
			// m_page will be changed at this point
			theApp.m_rectPageMargin = m_rectMargin;
			theApp.NotifyPrinterChanged();
		}
	}
}

/////////////////////////////////////////////////////////////////////////////
// OLE Server support

// The following command handler provides the standard keyboard
//  user interface to cancel an in-place editing session.  Here,
//  the server (not the container) causes the deactivation.
void CWordPadView::OnCancelEditSrvr()
{
	GetDocument()->OnDeactivateUI(FALSE);
}

/////////////////////////////////////////////////////////////////////////////
// CWordPadView diagnostics

#ifdef _DEBUG
void CWordPadView::AssertValid() const
{
	CRichEditView::AssertValid();
}

void CWordPadView::Dump(CDumpContext& dc) const
{
	CRichEditView::Dump(dc);
}

CWordPadDoc* CWordPadView::GetDocument() // non-debug version is inline
{
	return (CWordPadDoc*)m_pDocument;
}
#endif //_DEBUG

/////////////////////////////////////////////////////////////////////////////
// CWordPadView message helpers

/////////////////////////////////////////////////////////////////////////////
// CWordPadView message handlers

int CWordPadView::OnCreate(LPCREATESTRUCT lpCreateStruct)
{
	if (CRichEditView::OnCreate(lpCreateStruct) == -1)
		return -1;
	theApp.m_listPrinterNotify.AddTail(m_hWnd);

	if (theApp.m_bWordSel)
		GetRichEditCtrl().SetOptions(ECOOP_OR, ECO_AUTOWORDSELECTION);
	else
		GetRichEditCtrl().SetOptions(ECOOP_AND, ~(DWORD)ECO_AUTOWORDSELECTION);
//  GetRichEditCtrl().SetOptions(ECOOP_OR, ECO_SELECTIONBAR);

	GetDefaultFont(m_defTextCharFormat, IDS_DEFAULTTEXTFONT);
	GetDefaultFont(m_defCharFormat, IDS_DEFAULTFONT);

	GetRichEditCtrl().GetParaFormat(m_defParaFormat);
	m_defParaFormat.cTabCount = 0;

	SetTextColor ((COLORREF) -1);	// Automatic
	return 0;
}

void CWordPadView::GetDefaultFont(CCharFormat& cf, UINT nFontNameID)
{
	USES_CONVERSION;
	CString strDefFont;
	VERIFY(strDefFont.LoadString(nFontNameID));
	ASSERT(cf.cbSize == sizeof(WPD_CHARFORMAT));
	cf.dwMask = CFM_BOLD|CFM_ITALIC|CFM_UNDERLINE|CFM_STRIKEOUT|CFM_SIZE|
		CFM_COLOR|CFM_OFFSET|CFM_PROTECTED;
	cf.dwEffects = CFE_AUTOCOLOR;
	cf.yHeight = 200; //10pt
	cf.yOffset = 0;
	cf.crTextColor = RGB(0, 0, 0);
	cf.bCharSet = 0;
	cf.bPitchAndFamily = DEFAULT_PITCH | FF_DONTCARE;
	ASSERT(strDefFont.GetLength() < LF_FACESIZE);
	lstrcpyn(cf.szFaceName, strDefFont, LF_FACESIZE);
	cf.dwMask |= CFM_FACE;
}

void CWordPadView::OnInsertDateTime()
{
	CDateDialog dlg;
	if (dlg.DoModal() == IDOK)
		GetRichEditCtrl().ReplaceSel(dlg.m_strSel);;
}

void CWordPadView::OnFormatParagraph()
{
	CFormatParaDlg dlg(GetParaFormatSelection());
	dlg.m_nWordWrap = m_nWordWrap;
	if (dlg.DoModal() == IDOK)
		SetParaFormat(dlg.m_pf);
}

void CWordPadView::OnFormatTabs()
{
	CFormatTabDlg dlg(GetParaFormatSelection());
	if (dlg.DoModal() == IDOK)
		SetParaFormat(dlg.m_pf);
}

void CWordPadView::OnTextNotFound(LPCTSTR lpStr)
{
	ASSERT_VALID(this);
	MessageBeep(0);
	AfxMessageBox(IDS_FINISHED_SEARCH,MB_OK|MB_ICONINFORMATION);
	CRichEditView::OnTextNotFound(lpStr);
}

void CWordPadView::OnTimer(UINT_PTR nIDEvent)
{
	if (m_uTimerID != nIDEvent) // not our timer
		CRichEditView::OnTimer(nIDEvent);
	else
	{
		KillTimer(m_uTimerID); // kill one-shot timer
		m_uTimerID = 0;
		if (m_bDelayUpdateItems)
			GetDocument()->UpdateAllItems(NULL);
		m_bDelayUpdateItems = FALSE;

		// Update document colors:
		CFrameWndEx* pFrameEx = (CFrameWndEx*) GetTopLevelFrame ();
		CMFCColorBar* pColorBar = DYNAMIC_DOWNCAST (CMFCColorBar, 
			pFrameEx->GetPane  (ID_COLOR_TEAROFF));
		
		if (pColorBar != NULL)
		{
			CList<COLORREF,COLORREF> lstDocColors;
			GetDocumentColors (lstDocColors);

			pColorBar->SetDocumentColors (_T("Document's Colors"), lstDocColors);
		}
	}
}

void CWordPadView::OnEditChange()
{
	SetUpdateTimer();
}

void CWordPadView::OnDestroy()
{
	POSITION pos = theApp.m_listPrinterNotify.Find(m_hWnd);
	ASSERT(pos != NULL);
	theApp.m_listPrinterNotify.RemoveAt(pos);

	CRichEditView::OnDestroy();

	if (m_uTimerID != 0) // if outstanding timer kill it
		OnTimer(m_uTimerID);
	ASSERT(m_uTimerID == 0);
}

void CWordPadView::CalcWindowRect(LPRECT lpClientRect, UINT nAdjustType)
{
	CRichEditView::CalcWindowRect(lpClientRect, nAdjustType);

	if (theApp.m_bWin4 && nAdjustType != 0 && (GetStyle() & WS_VSCROLL))
		lpClientRect->right--;

	// if the ruler is visible then slide the view up under the ruler to avoid
	// showing the top border of the view
	if (GetExStyle() & WS_EX_CLIENTEDGE)
	{
		CFrameWndEx* pFrame = DYNAMIC_DOWNCAST (CFrameWndEx, GetParentFrame());
		if (pFrame != NULL)
		{
			CRulerBar* pBar = (CRulerBar*)pFrame->GetPane(ID_VIEW_RULER);
			if (pBar != NULL)
			{
				BOOL bVis = pBar->IsVisible();
				if (pBar->m_bDeferInProgress)
					bVis = !bVis;
				if (bVis)
					lpClientRect->top -= 2;
			}
		}
	}
}

void CWordPadView::OnMeasureItem(int nIDCtl, LPMEASUREITEMSTRUCT lpMIS)
{
	lpMIS->itemID = (UINT)(WORD)lpMIS->itemID;
	CRichEditView::OnMeasureItem(nIDCtl, lpMIS);
}

void CWordPadView::OnPenBackspace()
{
	SendMessage(WM_KEYDOWN, VK_BACK, 0);
	SendMessage(WM_KEYUP, VK_BACK, 0);
}

void CWordPadView::OnPenNewline()
{
	SendMessage(WM_CHAR, '\n', 0);
}

void CWordPadView::OnPenPeriod()
{
	SendMessage(WM_CHAR, '.', 0);
}

void CWordPadView::OnPenSpace()
{
	SendMessage(WM_CHAR, ' ', 0);
}

void CWordPadView::OnPenTab()
{
	SendMessage(WM_CHAR, VK_TAB, 0);
}

void CWordPadView::OnKeyDown(UINT nChar, UINT nRepCnt, UINT nFlags)
{
	if (nChar == VK_F10 && GetKeyState(VK_SHIFT) < 0)
	{
		long nStart, nEnd;
		GetRichEditCtrl().GetSel(nStart, nEnd);
		CPoint pt = GetRichEditCtrl().GetCharPos(nEnd);
		SendMessage(WM_CONTEXTMENU, (WPARAM)m_hWnd, MAKELPARAM(pt.x, pt.y));
	}

	CRichEditView::OnKeyDown(nChar, nRepCnt, nFlags);
}

HRESULT CWordPadView::GetClipboardData(CHARRANGE* lpchrg, DWORD /*reco*/,
	LPDATAOBJECT lpRichDataObj, LPDATAOBJECT* lplpdataobj)
{
	CHARRANGE& cr = *lpchrg;

	if ((cr.cpMax - cr.cpMin == 1) &&
		GetRichEditCtrl().GetSelectionType() == SEL_OBJECT)
	{
		return E_NOTIMPL;
	}

	BeginWaitCursor();
	//create the data source
	COleDataSource* pDataSource = new COleDataSource;

	// put the formats into the data source
	LPENUMFORMATETC lpEnumFormatEtc;
	lpRichDataObj->EnumFormatEtc(DATADIR_SET, &lpEnumFormatEtc);
	if (lpEnumFormatEtc != NULL)
	{
		FORMATETC etc;
		while (lpEnumFormatEtc->Next(1, &etc, NULL) == S_OK)
		{
			STGMEDIUM stgMedium;
			lpRichDataObj->GetData(&etc, &stgMedium);
			pDataSource->CacheData(etc.cfFormat, &stgMedium, &etc);
		}
		lpEnumFormatEtc->Release();
	}

	CEmbeddedItem item(GetDocument(), cr.cpMin, cr.cpMax);
	item.m_lpRichDataObj = lpRichDataObj;
	// get wordpad formats
	item.GetClipboardData(pDataSource);

	// get the IDataObject from the data source
	*lplpdataobj =  (LPDATAOBJECT)pDataSource->GetInterface(&IID_IDataObject);

	EndWaitCursor();
	return S_OK;
}

HRESULT CWordPadView::QueryAcceptData(LPDATAOBJECT lpdataobj,
	CLIPFORMAT* lpcfFormat, DWORD reco, BOOL bReally,
	HGLOBAL hMetaPict)
{
	if (bReally && *lpcfFormat == 0 && (m_nPasteType == 0))
	{
		COleDataObject dataobj;
		dataobj.Attach(lpdataobj, FALSE);
		if (!dataobj.IsDataAvailable(cfRTO)) // native avail, let richedit do as it wants
		{
			if (dataobj.IsDataAvailable(cfEmbeddedObject))
			{
				if (PasteNative(lpdataobj))
					return S_FALSE;
			}
		}
	}
	return CRichEditView::QueryAcceptData(lpdataobj, lpcfFormat, reco, bReally,
		hMetaPict);
}

BOOL CWordPadView::PasteNative(LPDATAOBJECT lpdataobj)
{
	// check data object for wordpad object
	// if true, suck out RTF directly
	FORMATETC etc = {NULL, NULL, DVASPECT_CONTENT, -1, TYMED_ISTORAGE};
	etc.cfFormat = (CLIPFORMAT)cfEmbeddedObject;
	STGMEDIUM stgMedium = {TYMED_ISTORAGE, 0, NULL};

	// create an IStorage to transfer the data in
	LPLOCKBYTES lpLockBytes;
	if (FAILED(::CreateILockBytesOnHGlobal(NULL, TRUE, &lpLockBytes)))
		return FALSE;
	ASSERT(lpLockBytes != NULL);

	HRESULT hr = ::StgCreateDocfileOnILockBytes(lpLockBytes,
		STGM_SHARE_EXCLUSIVE|STGM_CREATE|STGM_READWRITE, 0, &stgMedium.pstg);
	lpLockBytes->Release(); //storage addref'd
	if (FAILED(hr))
		return FALSE;

	ASSERT(stgMedium.pstg != NULL);
	CLSID clsid;
	BOOL bRes = FALSE; //let richedit do what it wants
	if (SUCCEEDED(lpdataobj->GetDataHere(&etc, &stgMedium)) &&
		SUCCEEDED(ReadClassStg(stgMedium.pstg, &clsid)) &&
		clsid == GetDocument()->GetClassID())
	{
		//suck out RTF now
		// open Contents stream
		COleStreamFile file;
		CFileException fe;
		if (file.OpenStream(stgMedium.pstg, szContents,
			CFile::modeReadWrite|CFile::shareExclusive, &fe))
		{

			// load it with CArchive (loads from Contents stream)
			CArchive loadArchive(&file, CArchive::load |
				CArchive::bNoFlushOnDelete);
			Stream(loadArchive, TRUE); //stream in selection
			hr = TRUE; // don't let richedit do anything
		}
	}
	::ReleaseStgMedium(&stgMedium);
	return bRes;
}

// things to fix
// if format==0 we are doing a straight EM_PASTE
//  look for native formats
//      richedit specific -- allow richedit to handle (these will be first)
//      look for RTF, CF_TEXT.  If there paste special as these
//  Do standard OLE scenario

// if pasting a particular format (format != 0)
//  if richedit specific, allow through
//  if RTF, CF_TEXT. paste special
//  if OLE format, do standard OLE scenario


void CWordPadView::OnFilePrint()
{
	// don't allow winini changes to occur while printing
	m_bInPrint = TRUE;
	CRichEditView::OnFilePrint();
	// printer may have changed
	theApp.NotifyPrinterChanged(); // this will cause a GetDocument()->PrinterChanged();
	m_bInPrint = FALSE;
}

int CWordPadView::OnMouseActivate(CWnd* pWnd, UINT nHitTest, UINT message)
{
	if (m_bOnBar)
	{
		SetFocus();
		return MA_ACTIVATEANDEAT;
	}
	else
		return CRichEditView::OnMouseActivate(pWnd, nHitTest, message);
}

typedef BOOL (WINAPI *PCWPROC)(HWND, LPSTR, UINT, LPVOID, DWORD, DWORD);
void CWordPadView::OnPenLens()
{
	USES_CONVERSION;
	HINSTANCE hLib = LoadLibrary(_T("PENWIN32.DLL"));
	if (hLib == NULL)
		return;
	PCWPROC pCorrectWriting = (PCWPROC)GetProcAddress(hLib, "CorrectWriting");
	ASSERT(pCorrectWriting != NULL);
	if (pCorrectWriting != NULL)
	{
		CHARRANGE cr;
		GetRichEditCtrl().GetSel(cr);
		int nCnt = 2*(cr.cpMax-cr.cpMin);
		BOOL bSel = (nCnt != 0);
		nCnt = max(1024, nCnt);
		char* pBuf = new char[nCnt];
		pBuf[0] = NULL;
		if (bSel)
			GetRichEditCtrl().GetSelText(pBuf);
		delete [] pBuf;
	}
	FreeLibrary(hLib);
}

LONG CWordPadView::OnPrinterChangedMsg(UINT, LONG)
{
	CDC dc;
	AfxGetApp()->CreatePrinterDC(dc);
	OnPrinterChanged(dc);
	return 0;
}

static void ForwardPaletteChanged(HWND hWndParent, HWND hWndFocus)
{
	// this is a quick and dirty hack to send the WM_QUERYNEWPALETTE to a window that is interested
	HWND hWnd = NULL;
	for (hWnd = ::GetWindow(hWndParent, GW_CHILD); hWnd != NULL; hWnd = ::GetWindow(hWnd, GW_HWNDNEXT))
	{
		if (hWnd != hWndFocus)
		{
			::SendMessage(hWnd, WM_PALETTECHANGED, (WPARAM)hWndFocus, 0L);
			ForwardPaletteChanged(hWnd, hWndFocus);
		}
	}
}

void CWordPadView::OnPaletteChanged(CWnd* pFocusWnd)
{
	ForwardPaletteChanged(m_hWnd, pFocusWnd->GetSafeHwnd());
	// allow the richedit control to realize its palette
	// remove this if if richedit fixes their code so that
	// they don't realize their palette into foreground
	if (::GetWindow(m_hWnd, GW_CHILD) == NULL)
		CRichEditView::OnPaletteChanged(pFocusWnd);
}

static BOOL FindQueryPalette(HWND hWndParent)
{
	// this is a quick and dirty hack to send the WM_QUERYNEWPALETTE to a window that is interested
	HWND hWnd = NULL;
	for (hWnd = ::GetWindow(hWndParent, GW_CHILD); hWnd != NULL; hWnd = ::GetWindow(hWnd, GW_HWNDNEXT))
	{
		if (::SendMessage(hWnd, WM_QUERYNEWPALETTE, 0, 0L))
			return TRUE;
		else if (FindQueryPalette(hWnd))
			return TRUE;
	}
	return FALSE;
}

BOOL CWordPadView::OnQueryNewPalette()
{
	if(FindQueryPalette(m_hWnd))
		return TRUE;
	return CRichEditView::OnQueryNewPalette();
}

void CWordPadView::OnSettingChange(UINT uFlags, LPCTSTR lpszSection)
{
	CRichEditView::OnSettingChange(uFlags, lpszSection);
	//printer might have changed
	if (!m_bInPrint)
	{
		if (lstrcmpi(lpszSection, _T("windows")) == 0)
			theApp.NotifyPrinterChanged(TRUE); // force update to defaults
	}
}

void CWordPadView::OnSize(UINT nType, int cx, int cy)
{
	CRichEditView::OnSize(nType, cx, cy);
	CRect rect(HORZ_TEXTOFFSET, VERT_TEXTOFFSET, cx, cy);
	GetRichEditCtrl().SetRect(rect);
}

void CWordPadView::OnBarSetFocus(UINT, NMHDR*, LRESULT*)
{
	m_bOnBar = TRUE;
}

void CWordPadView::OnBarKillFocus(UINT, NMHDR*, LRESULT*)
{
	m_bOnBar = FALSE;
}

void CWordPadView::OnBarReturn(UINT, NMHDR*, LRESULT* )
{
	SetFocus();
}

void CWordPadView::OnContextMenu(CWnd* /*pWnd*/, CPoint point) 
{
	if (!ShowContextMenu (point))
	{
		Default ();
	}
}

void CWordPadView::OnRButtonUp(UINT nFlags, CPoint point) 
{
	long nStartChar, nEndChar;
	GetRichEditCtrl().GetSel(nStartChar, nEndChar);
	if (nEndChar - nStartChar <= 1)
	{
		SendMessage (WM_LBUTTONDOWN, nFlags, MAKELPARAM (point.x, point.y));
		ReleaseCapture ();
	}

	CPoint ptScreen = point;
	ClientToScreen (&ptScreen);

	if (!ShowContextMenu (ptScreen))
	{
		Default ();
	}
}

BOOL CWordPadView::ShowContextMenu (CPoint point)
{
	if (DYNAMIC_DOWNCAST (CFrameWndEx, GetParentFrame ()) == NULL)
	{
		// Maybe, server mode, show the regular menu!
		return FALSE;
	}

	CRichEditCntrItem* pItem = GetSelectedItem();
	if (pItem == NULL || !pItem->IsInPlaceActive())
	{
		theApp.ShowPopupMenu (IDR_TEXT_POPUP, point, this);
		return TRUE;
	}

	return FALSE;
}

void CWordPadView::SetTextColor (COLORREF color)
{
	CRichEditView::OnColorPick (color == -1 ? ::GetSysColor (COLOR_WINDOWTEXT) : color);
}

void CWordPadView::OnCharColor() 
{
	COLORREF color = CMFCColorMenuButton::GetColorByCmdID (ID_CHAR_COLOR);
	CRichEditView::OnColorPick (color == -1 ? ::GetSysColor (COLOR_WINDOWTEXT) : color);
}

void CWordPadView::OnFilePrintPreview() 
{
	CRichEditCntrItem* pItem = GetSelectedItem();
	if (pItem != NULL && pItem->IsInPlaceActive())
	{
		pItem->Deactivate ();
	}

	AFXPrintPreview (this);
}

void CWordPadView::GetDocumentColors (CList<COLORREF,COLORREF>& lstColors)
{
	CRichEditCtrl& wndRichEdit = GetRichEditCtrl();

	// Save current selection:
	CHARRANGE cr;
	wndRichEdit.GetSel(cr);

	wndRichEdit.HideSelection (TRUE, FALSE);

	int nTextLen = min (500, wndRichEdit.GetTextLength ());
		// For demonstration purposes only!

	for (long iSel = 0; iSel < nTextLen; iSel += 2)
	{
		wndRichEdit.SetSel (iSel, iSel);
		if (!(wndRichEdit.GetSelectionType() & (SEL_OBJECT|SEL_MULTIOBJECT)))
		{
			CCharFormat cf;
			wndRichEdit.GetSelectionCharFormat (cf);

			COLORREF color = cf.crTextColor;
			if (lstColors.Find (color) == NULL)
			{
				lstColors.AddTail (color);

				if (lstColors.GetCount () == 10)
				{
					break;
				}
			}
		}
	}

	// Restore selection:
	wndRichEdit.SetSel (cr);
	wndRichEdit.HideSelection (FALSE, FALSE);
}

void CWordPadView::OnFontname() 
{
	USES_CONVERSION;

	CMFCToolBarFontComboBox* pSrcCombo = 
		(CMFCToolBarFontComboBox*) CMFCToolBarComboBoxButton::GetByCmd (IDC_FONTNAME, TRUE);
	if (pSrcCombo == NULL)
	{
		CRichEditView::OnFormatFont ();
		return;
	}

	CCharFormat cf;
	cf.szFaceName[0] = NULL;
	cf.dwMask = CFM_FACE | CFM_CHARSET;

	const CMFCFontInfo* pDesc = pSrcCombo->GetFontDesc ();
	ASSERT_VALID (pDesc);
	ASSERT(pDesc->m_strName.GetLength() < LF_FACESIZE);

	lstrcpyn(cf.szFaceName, pDesc->m_strName, LF_FACESIZE);

	cf.bCharSet = pDesc->m_nCharSet;
	cf.bPitchAndFamily = pDesc->m_nPitchAndFamily;

	// <snippet8>
	CMFCToolBarFontSizeComboBox* pSizeCombo =
		DYNAMIC_DOWNCAST (CMFCToolBarFontSizeComboBox, CMFCToolBarFontSizeComboBox::GetByCmd (IDC_FONTSIZE));
	if (pSizeCombo != NULL)
	{
		int nSize = pSizeCombo->GetTwipSize();
		// CMFCFontInfo* pDesc
		pSizeCombo->RebuildFontSizes (pDesc->m_strName);
		pSizeCombo->SetTwipSize (nSize);
	}
	// </snippet8>

	SetCharFormat (cf);
	SetFocus ();
}
//****************************************************************************************
void CWordPadView::OnFontsize() 
{
	CMFCToolBarFontSizeComboBox* pSrcCombo = 
		(CMFCToolBarFontSizeComboBox*) CMFCToolBarComboBoxButton::GetByCmd (IDC_FONTSIZE, TRUE);
	if (pSrcCombo == NULL)
	{
		CRichEditView::OnFormatFont ();
		return;
	}

	int nSize = pSrcCombo->GetTwipSize();
	if (nSize == -2)
	{
		AfxMessageBox(IDS_INVALID_NUMBER, MB_OK|MB_ICONINFORMATION);
	}
	else if ((nSize >= 0 && nSize < 20) || nSize > 32760)
	{
		AfxMessageBox(IDS_INVALID_FONTSIZE, MB_OK|MB_ICONINFORMATION);
	}
	else if (nSize > 0)
	{
		CCharFormat cf;
		cf.dwMask = CFM_SIZE;
		cf.yHeight = nSize;

		SetCharFormat (cf);
		SetFocus ();
	}
}
//*********************************************************************************
void CWordPadView::OnBorderType (UINT id)
{
	m_nBorderType = id;

	MessageBox (_T("Add your code here..."));
}
//********************************************************************************
void CWordPadView::OnUpdateBorderType (CCmdUI* pCmdUI)
{
	pCmdUI->SetCheck (pCmdUI->m_nID == m_nBorderType);
}
