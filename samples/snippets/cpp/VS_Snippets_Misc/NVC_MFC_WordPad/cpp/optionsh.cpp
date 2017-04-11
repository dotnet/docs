//
// optionsh.cpp : implementation file
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
#include "unitspag.h"
#include "docopt.h"
#include "optionsh.h"

#ifdef _DEBUG
#undef THIS_FILE
static char BASED_CODE THIS_FILE[] = __FILE__;
#endif

/////////////////////////////////////////////////////////////////////////////
// COptionSheet

COptionSheet::COptionSheet(UINT nIDCaption, CWnd* pParentWnd, UINT iSelectPage)
	: CCSPropertySheet(nIDCaption, pParentWnd, iSelectPage),
	pageText(IDS_TEXT_OPTIONS), pageRTF(IDS_RTF_OPTIONS),
	pageWord(IDS_WORD6_OPTIONS), pageWrite(IDS_WRITE_OPTIONS),
	pageEmbedded()
{
	units.m_nUnits = theApp.GetUnits();
	units.m_bWordSel = theApp.m_bWordSel;
	pageText.m_nWordWrap = theApp.GetDocOptions(RD_TEXT).m_nWordWrap;
	pageRTF.m_nWordWrap = theApp.GetDocOptions(RD_RICHTEXT).m_nWordWrap;
	pageWord.m_nWordWrap = theApp.GetDocOptions(RD_WINWORD6).m_nWordWrap;
	pageWrite.m_nWordWrap = theApp.GetDocOptions(RD_WRITE).m_nWordWrap;
	pageEmbedded.m_nWordWrap = theApp.GetDocOptions(RD_EMBEDDED).m_nWordWrap;
	SetPageButtons(pageText, theApp.GetDockState(RD_TEXT));
	SetPageButtons(pageRTF, theApp.GetDockState(RD_RICHTEXT));
	SetPageButtons(pageWord, theApp.GetDockState(RD_WINWORD6));
	SetPageButtons(pageWrite, theApp.GetDockState(RD_WRITE));
	SetPageButtons(pageEmbedded, theApp.GetDockState(RD_EMBEDDED));
	SetPageButtons(pageEmbedded, theApp.GetDockState(RD_EMBEDDED, FALSE));
	AddPage(&units);
	AddPage(&pageText);
	AddPage(&pageRTF);
	AddPage(&pageWord);
	AddPage(&pageWrite);
	AddPage(&pageEmbedded);
}

void COptionSheet::SetPageButtons(CDocOptPage& page, CDockState& ds)
{
	if (ds.m_arrBarInfo.GetSize() == 0)
	{
		page.m_bFormatBar = page.m_bRulerBar = TRUE;
		page.m_bToolBar = page.m_bStatusBar = TRUE;
	}
	else
	{
		for (int i = 0;i < ds.m_arrBarInfo.GetSize(); i++)
		{
			CControlBarInfo* pInfo = (CControlBarInfo*)ds.m_arrBarInfo[i];
			ASSERT(pInfo != NULL);
			if (pInfo)
			{
				switch (pInfo->m_nBarID)
				{
				case ID_VIEW_FORMATBAR:
					page.m_bFormatBar = page.m_bFormatBar || pInfo->m_bVisible;
					break;
				case ID_VIEW_RULER:
					page.m_bRulerBar = page.m_bRulerBar || pInfo->m_bVisible;
					break;
				case ID_VIEW_TOOLBAR:
					page.m_bToolBar = page.m_bToolBar || pInfo->m_bVisible;
					break;
				case ID_VIEW_STATUS_BAR:
					page.m_bStatusBar = page.m_bStatusBar || pInfo->m_bVisible;
					break;
				}
			}
		}
	}
}

void COptionSheet::SetState(CDocOptPage& page, CDockState& ds)
{
	for (int i = 0;i < ds.m_arrBarInfo.GetSize(); i++)
	{
		CControlBarInfo* pInfo = (CControlBarInfo*)ds.m_arrBarInfo[i];
		ASSERT(pInfo != NULL);
		if (pInfo)
		{
			switch (pInfo->m_nBarID)
			{
			case ID_VIEW_FORMATBAR:
				pInfo->m_bVisible = page.m_bFormatBar;
				break;
			case ID_VIEW_RULER:
				pInfo->m_bVisible = page.m_bRulerBar;
				break;
			case ID_VIEW_TOOLBAR:
				pInfo->m_bVisible = page.m_bToolBar;
				break;
			case ID_VIEW_STATUS_BAR:
				pInfo->m_bVisible = page.m_bStatusBar;
				break;
			}
		}
	}
}

BEGIN_MESSAGE_MAP(COptionSheet, CCSPropertySheet)
	//{{AFX_MSG_MAP(COptionSheet)
	ON_WM_CREATE()
	//}}AFX_MSG_MAP
END_MESSAGE_MAP()


/////////////////////////////////////////////////////////////////////////////
// COptionSheet message handlers

INT_PTR COptionSheet::DoModal()
{
	INT_PTR nRes = CCSPropertySheet::DoModal();
	if (nRes == IDOK)
	{
		SetState(pageText, theApp.GetDockState(RD_TEXT));
		SetState(pageRTF, theApp.GetDockState(RD_RICHTEXT));
		SetState(pageWord, theApp.GetDockState(RD_WINWORD6));
		SetState(pageWrite, theApp.GetDockState(RD_WRITE));
		SetState(pageEmbedded, theApp.GetDockState(RD_EMBEDDED));
		SetState(pageEmbedded, theApp.GetDockState(RD_EMBEDDED, FALSE));
		theApp.SetUnits(units.m_nUnits);
		theApp.m_bWordSel = units.m_bWordSel;
		theApp.GetDocOptions(RD_TEXT).m_nWordWrap = pageText.m_nWordWrap;
		theApp.GetDocOptions(RD_RICHTEXT).m_nWordWrap = pageRTF.m_nWordWrap;
		theApp.GetDocOptions(RD_WINWORD6).m_nWordWrap = pageWord.m_nWordWrap;
		theApp.GetDocOptions(RD_WRITE).m_nWordWrap = pageWrite.m_nWordWrap;
		theApp.GetDocOptions(RD_EMBEDDED).m_nWordWrap = pageEmbedded.m_nWordWrap;
	}
	return nRes;
}

/////////////////////////////////////////////////////////////////////////////
// COptionSheet message handlers
