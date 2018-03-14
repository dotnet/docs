#include "stdafx.h"
#include "ribbongadgets.h"
#include "OutputBar.h"

#include "../src/mfc/AfxImpl.h"

#ifdef _DEBUG
#define new DEBUG_NEW
#undef THIS_FILE
static char THIS_FILE[] = __FILE__;
#endif

/////////////////////////////////////////////////////////////////////////////
// COutputBar

COutputBar::COutputBar()
{
}

COutputBar::~COutputBar()
{
}


BEGIN_MESSAGE_MAP(COutputBar, CDockablePane)
	ON_WM_CREATE()
	ON_WM_SIZE()
	ON_WM_DESTROY()
	ON_COMMAND(ID_EDIT_COPY, OnEditCopy)
	ON_COMMAND(ID_FILE_SAVE_AS, OnFileSaveAs)
	ON_COMMAND(ID_FILE_PRINT, OnFilePrint)
END_MESSAGE_MAP()


/////////////////////////////////////////////////////////////////////////////
// COutputBar message handlers

int COutputBar::OnCreate(LPCREATESTRUCT lpCreateStruct) 
{
	if (CDockablePane::OnCreate(lpCreateStruct) == -1)
		return -1;
	
	// Create tabs window:
	if (!m_wndTabs.Create (CMFCTabCtrl::STYLE_FLAT, CRect (0, 0, 0, 0), this, 1))
	{
		TRACE0("Failed to create output tab window\n");
		return -1;      // fail to create
	}

	// Create toolbar:
	m_wndTabs.SetFlatFrame (FALSE, FALSE);
	m_wndTabs.AutoDestroyWindow (FALSE);

	m_wndToolBar.Create (this, AFX_DEFAULT_TOOLBAR_STYLE, IDR_CODE);
	m_wndToolBar.LoadToolBar (IDR_CODE, 0, 0, TRUE /* Is locked */);

	m_wndToolBar.SetPaneStyle(m_wndToolBar.GetPaneStyle() |
		CBRS_TOOLTIPS | CBRS_FLYBY);
		
	m_wndToolBar.SetPaneStyle (
		m_wndToolBar.GetPaneStyle () & 
			~(CBRS_GRIPPER | CBRS_SIZE_DYNAMIC | CBRS_BORDER_TOP | CBRS_BORDER_BOTTOM | CBRS_BORDER_LEFT | CBRS_BORDER_RIGHT));

	m_wndToolBar.SetOwner (this);

	// All commands will be routed via this control , not via the parent frame:
	m_wndToolBar.SetRouteCommandsViaFrame (FALSE);

	m_Font.CreateFont 
		(
			-12, 0, 0, 0, FW_NORMAL, 0, 0, 0, DEFAULT_CHARSET, 
			OUT_DEFAULT_PRECIS, CLIP_DEFAULT_PRECIS, DEFAULT_QUALITY, 
			DEFAULT_PITCH, _T("Courier")
		);

	return 0;
}

void COutputBar::OnSize(UINT nType, int cx, int cy) 
{
	CDockablePane::OnSize(nType, cx, cy);
	
	CRect rectClient,rectCombo;
	GetClientRect (rectClient);

	int cyTlb = m_wndToolBar.CalcFixedLayout (FALSE, TRUE).cy;

	m_wndToolBar.SetWindowPos (NULL,
							   rectClient.left, 
							   rectClient.top,
							   rectClient.Width (),
							   cyTlb,
							   SWP_NOACTIVATE | SWP_NOZORDER);

	m_wndTabs.SetWindowPos (NULL, rectClient.left, rectClient.top + cyTlb, 
		rectClient.Width (), rectClient.Height () - cyTlb,
		SWP_NOACTIVATE | SWP_NOZORDER);
}

void COutputBar::ClearTabs ()
{
	for (int i = 0; i < m_wndTabs.GetTabsNum (); i++)
	{
		CWnd* pWnd = m_wndTabs.GetTabWnd (i);
		pWnd->DestroyWindow ();
		delete pWnd;
	}

	m_wndTabs.RemoveAllTabs ();
}

void COutputBar::AddTab (LPCTSTR lpszName, UINT nID)
{
	CEdit* pWndEdit = new CEdit ();

	pWndEdit->Create (WS_CHILD | WS_VISIBLE | WS_HSCROLL | WS_VSCROLL |
		ES_MULTILINE | ES_AUTOHSCROLL | ES_AUTOVSCROLL, 
		CRect (0, 0, 0, 0), &m_wndTabs, 1);
	pWndEdit->SetReadOnly ();
	pWndEdit->SetFont (m_Font.GetSafeHandle () == NULL ? &afxGlobalData.fontRegular : &m_Font);

	if (nID != 0)
	{
		LPCTSTR lpszResourceName = MAKEINTRESOURCE (nID);
		ASSERT(lpszResourceName != NULL);

		HINSTANCE hInst = AfxFindResourceHandle (lpszResourceName, _T("CODE"));
		HRSRC hRsrc = ::FindResource (hInst, lpszResourceName, _T("CODE"));
		
		if (hRsrc == NULL)
		{
			ASSERT(FALSE);
		}
		else
		{
			DWORD dwSize = SizeofResource (hInst, hRsrc);
			HGLOBAL hGlobal = NULL;
			if (dwSize != NULL)
			{
				hGlobal = LoadResource (hInst, hRsrc);
			}

			if (hGlobal == NULL)
			{
				ASSERT(FALSE);
			}
			else
			{
				TCHAR* lpszText = new TCHAR[dwSize + 1];
				LPCSTR lpszResourceText = (LPCSTR)LockResource(hGlobal);
#ifdef UNICODE
				MultiByteToWideChar(CP_ACP, MB_ERR_INVALID_CHARS, lpszResourceText, dwSize, lpszText, dwSize);
#else
				memcpy (lpszText, lpszResourceText, dwSize);
#endif
				lpszText[dwSize] = 0;

				if (lpszText == NULL)
				{
					ASSERT(FALSE);
				}
				else
				{
					pWndEdit->SetWindowText(lpszText);
					delete lpszText;
				}

				UnlockResource(hGlobal);
				FreeResource(hGlobal);
			}
		}
	}

	m_wndTabs.AddTab (pWndEdit, lpszName, (UINT)-1, FALSE);
}

void COutputBar::OnDestroy() 
{
	ClearTabs ();
	CDockablePane::OnDestroy();
}

void COutputBar::OnEditCopy() 
{
	CEdit* pWndEdit = (CEdit*) m_wndTabs.GetActiveWnd ();
	ASSERT_VALID (pWndEdit);

	pWndEdit->Copy ();
}

void ErrorReport (LPCTSTR lpszPathName, CException* e)
{
	UINT nIDP = 0;
	UINT nHelpContext = 0;
	CString prompt;

	if (e->IsKindOf(RUNTIME_CLASS(CFileException)))
	{
		TRACE(traceAppMsg, 0, "Reporting file I/O exception on save with lOsError = $%lX.\n",
			((CFileException*)e)->m_lOsError);

		CFileException* pFileException = (CFileException*)e;
		if (pFileException->m_strFileName.IsEmpty())
		{
			pFileException->m_strFileName = lpszPathName;
		}

		LPTSTR lpszMessage = prompt.GetBuffer(255);
		ASSERT(lpszMessage != NULL);
		if (!e->GetErrorMessage(lpszMessage, 256, &nHelpContext))
		{
			switch (((CFileException*)e)->m_cause)
			{
				case CFileException::fileNotFound:
				case CFileException::badPath:
					nIDP = AFX_IDP_FAILED_INVALID_PATH;
					break;
				case CFileException::diskFull:
					nIDP = AFX_IDP_FAILED_DISK_FULL;
					break;
				case CFileException::accessDenied:
					nIDP = AFX_IDP_FAILED_ACCESS_WRITE;
					break;

				case CFileException::badSeek:
				case CFileException::genericException:
				case CFileException::tooManyOpenFiles:
				case CFileException::invalidFile:
				case CFileException::hardIO:
				case CFileException::directoryFull:
					break;

				default:
					break;
			}
		}
		prompt.ReleaseBuffer();
	}

	if (prompt.IsEmpty())
	{
		TCHAR szTitle[_MAX_PATH];
		AfxGetFileTitle(lpszPathName, szTitle, _countof(szTitle));

		if (nIDP != 0)
		{
			AfxFormatString1(prompt, nIDP, szTitle);
		}
		else
		{
			prompt.Format (_T("Failed to save file: %s."), szTitle);
		}
	}

	AfxMessageBox(prompt, MB_ICONEXCLAMATION, nHelpContext);
}

void COutputBar::OnFileSaveAs() 
{
	CEdit* pWndEdit = (CEdit*) m_wndTabs.GetActiveWnd ();
	ASSERT_VALID (pWndEdit);

	CString strText;
	pWndEdit->GetWindowText (strText);
	if (strText.IsEmpty ())
	{
		return;
	}

	CFileDialog dlgFile(FALSE, _T("txt"), _T("Code.txt"), OFN_HIDEREADONLY | OFN_OVERWRITEPROMPT, _T("Text Documents (*.txt)|*.txt||"));
	if (dlgFile.DoModal() != IDOK)
	{
		return;
	}

	CString strPathName (dlgFile.GetPathName ());

	CFileException fe;
	CFile file;
	if (file.Open(strPathName, CFile::modeCreate |
					CFile::modeWrite | CFile::shareExclusive, &fe))
	{
		TRY
		{
			CWaitCursor wait;

			file.Write((LPCTSTR)strText, strText.GetLength () * sizeof(TCHAR));
			file.Close ();
		}
		CATCH_ALL(e)
		{
			file.Abort ();

			TRY
			{
				ErrorReport (strPathName, e);
			}
			END_TRY
			do { e->Delete(); } while (0);
		}
		END_CATCH_ALL
	}
	else
	{
		ErrorReport (strPathName, &fe);
	}
}

void COutputBar::OnFilePrint() 
{
	CEdit* pWndEdit = (CEdit*) m_wndTabs.GetActiveWnd ();
	ASSERT_VALID (pWndEdit);

	CString strText;
	pWndEdit->GetWindowText (strText);
	if (strText.IsEmpty ())
	{
		return;
	}

    CDC dc;
    CPrintDialog printDlg(FALSE);
	
    if (printDlg.DoModal() == IDCANCEL)
	{
        return;
	}
	
    dc.Attach(printDlg.GetPrinterDC());
    dc.m_bPrinting = TRUE;

    DOCINFO di;
    ::ZeroMemory (&di, sizeof (DOCINFO));
    di.cbSize = sizeof (DOCINFO);
    di.lpszDocName = _T("code");

    BOOL bPrintingOK = dc.StartDoc(&di);

	if (bPrintingOK)
	{
		CFont* pFont = pWndEdit->GetFont ();
		ASSERT_VALID (pFont);

		LOGFONT lf;
		pFont->GetLogFont (&lf);
		lf.lfHeight = -::MulDiv (abs(lf.lfHeight), dc.GetDeviceCaps(LOGPIXELSY), 72);

		CFont font;
		if (font.CreateFontIndirect (&lf))
		{
			CFont* pOldFont = (CFont*)dc.SelectObject (&font);

			CRect rect (0, 0,dc.GetDeviceCaps(HORZRES), dc.GetDeviceCaps(VERTRES));
			dc.DrawText (strText, rect, DT_WORDBREAK | DT_EXPANDTABS | DT_NOPREFIX);

			if (pOldFont != NULL)
			{
				dc.SelectObject (pOldFont);
			}

			dc.EndDoc();
		}
		else
		{
			bPrintingOK = FALSE;
		}
	}

	if (!bPrintingOK)
	{
		dc.AbortDoc();
	}

    dc.DeleteDC();
}


