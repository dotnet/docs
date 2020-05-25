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
#include <wininet.h>
#include "IEDemo.h"
#include "FavoritesManager.h"

#ifdef _DEBUG
#undef THIS_FILE
static char THIS_FILE[]=__FILE__;
#define new DEBUG_NEW
#endif

CMap<CString, LPCTSTR, int, int> CFavorit::m_URLIcons;
CMap<UINT, UINT, int, int> CFavorit::m_IDIcons;
UINT CFavorit::m_uiNextCommand = FIRST_FAVORITE_COMMAND;
int CFavorit::m_iFolderIcon = -1;
int CFavorit::m_iInternetShortcutIcon = -1;

CFavorit::CFavorit (LPCTSTR lpszName, int iIcon, LPCTSTR lpszURL, UINT uiCommand)
{
	m_strName = lpszName;
	m_iIcon = iIcon;

	if (lpszURL != NULL)
	{
		m_strURL = lpszURL;
	}

	m_uiCommand = uiCommand;

	if (uiCommand != 0)
	{
		m_IDIcons.SetAt (uiCommand, iIcon);
	}
}
//*************************************************************************************
CFavorit::CFavorit ()
{
	m_uiCommand = 0;
	m_iIcon = -1;
}
//*************************************************************************************
CFavorit::~CFavorit()
{
	CleanUp ();
}
//*************************************************************************************
void CFavorit::CleanUp ()
{
	m_uiCommand = 0;
	m_iIcon = -1;

	while (!m_lstSubItems.IsEmpty ())
	{
		delete m_lstSubItems.RemoveHead ();
	}
}
//*************************************************************************************
const CFavorit* CFavorit::FindByID (UINT uiCommandID) const
{
	if (m_uiCommand == uiCommandID)
	{
		return this;
	}

	for (POSITION pos = m_lstSubItems.GetHeadPosition (); pos != NULL;)
	{
		CFavorit* pFavorit = (CFavorit*) m_lstSubItems.GetNext (pos);
		ASSERT_VALID (pFavorit);

		const CFavorit* pFavoritFound = pFavorit->FindByID (uiCommandID);
		if (pFavoritFound != NULL)
		{
			return pFavoritFound;
		}
	}

	return NULL;
}
//*************************************************************************************
BOOL CFavorit::Build (CString strPath)
{
	// make sure there's a trailing backslash
	if (strPath.GetLength () == 0 || 
		strPath [strPath.GetLength () - 1] != _T('\\'))
	{
		strPath += _T('\\');
	}

	// Prepare file mask:
	CString strFileMask = strPath;
	strFileMask += _T("*.*");

	// Start find all files in specific directory:
	WIN32_FIND_DATA fd;
	HANDLE hFile = FindFirstFile (strFileMask, &fd);
	if (hFile == INVALID_HANDLE_VALUE)
	{
		return FALSE;
	}

	do
	{
		CString strName = fd.cFileName;
		if (fd.dwFileAttributes & FILE_ATTRIBUTE_DIRECTORY)
		{
			if (strName != _T(".") && strName != _T(".."))
			{
				CFavorit* pSubFavorit = new CFavorit (strName, m_iFolderIcon, NULL);
				ASSERT_VALID (pSubFavorit);

				pSubFavorit->Build (strPath + strName);

				// Add to end of folders:
				BOOL bAdded = FALSE;
				for (POSITION pos = m_lstSubItems.GetTailPosition (); pos != NULL;)
				{
					POSITION posSave = pos;

					CFavorit* pListFavorit = (CFavorit*) m_lstSubItems.GetPrev (pos);
					ASSERT_VALID (pListFavorit);

					if (pListFavorit->m_uiCommand == 0)
					{
						m_lstSubItems.InsertAfter (posSave, pSubFavorit);
						bAdded = TRUE;
						break;
					}
				}

				if (!bAdded)
				{
					m_lstSubItems.AddTail (pSubFavorit);
				}
			}
		}
		else if (strName.Right (4).CompareNoCase (_T(".url")) == 0)
		{
			CString strFilePath = strPath + strName;

			// an .URL file is formatted just like an .INI file, so we can
			// use GetPrivateProfileString() to get the information we want
			TCHAR szURL [INTERNET_MAX_PATH_LENGTH + 1];
			::GetPrivateProfileString (_T("InternetShortcut"), _T("URL"),
						_T(""), szURL, INTERNET_MAX_PATH_LENGTH,
						strFilePath);

			// Obtain URL icon:
			TCHAR ext[_MAX_EXT];
			_tsplitpath_s (szURL, NULL, 0, NULL, 0, NULL, 0, ext, _MAX_EXT);
			
			int iIcon = 0;
			if (!m_URLIcons.Lookup (ext, iIcon))
			{
				// Retrieve icon file
				SHFILEINFO sfi;
				if (::SHGetFileInfo (strFilePath, 0, &sfi, sizeof(SHFILEINFO), 
					SHGFI_SMALLICON | SHGFI_SYSICONINDEX) &&
					sfi.iIcon >= 0)
				{
					m_URLIcons.SetAt (ext, sfi.iIcon);
					iIcon = sfi.iIcon;

					if (m_iInternetShortcutIcon == -1)
					{
						m_iInternetShortcutIcon = sfi.iIcon;
					}
				}
			}

			strName = strName.Left (strName.GetLength () - 4);

			m_lstSubItems.AddTail (new CFavorit (
				strName, iIcon, szURL, m_uiNextCommand ++));
		}
	}
	while (FindNextFile (hFile, &fd));
	FindClose (hFile);

	return TRUE;
}
//*************************************************************************************
BOOL CFavorit::CreateMenu (CMenu& menu)
{
	ASSERT (menu.GetSafeHmenu () == NULL);
	ASSERT (m_uiCommand == 0);

	if (!menu.CreatePopupMenu ())
	{
		ASSERT (FALSE);
		return FALSE;
	}

	for (POSITION pos = m_lstSubItems.GetHeadPosition (); pos != NULL;)
	{
		CFavorit* pFavorit = (CFavorit*) m_lstSubItems.GetNext (pos);
		ASSERT_VALID (pFavorit);

		if (pFavorit->m_uiCommand != 0)
		{
			menu.InsertMenu ((UINT)-1, MF_BYPOSITION | MF_STRING, pFavorit->m_uiCommand,
				pFavorit->m_strName);
		}
		else
		{
			CMenu subMenu;
			if (pFavorit->CreateMenu (subMenu))
			{
				menu.InsertMenu ((UINT) -1, MF_BYPOSITION | MF_POPUP | MF_STRING, 
					(UINT_PTR) subMenu.Detach (), pFavorit->m_strName);
			}
		}
	}

	return TRUE;
}
//************************************************************************************
void CFavorit::FillTree (CTreeCtrl& wndTree, HTREEITEM htreeItemParent)
{
	for (POSITION pos = m_lstSubItems.GetHeadPosition (); pos != NULL;)
	{
		CFavorit* pFavorit = (CFavorit*) m_lstSubItems.GetNext (pos);
		ASSERT_VALID (pFavorit);

		HTREEITEM hTreeItem = wndTree.InsertItem (pFavorit->m_strName, 
			pFavorit->m_iIcon, pFavorit->m_iIcon, htreeItemParent);
		wndTree.SetItemData (hTreeItem, (DWORD_PTR) pFavorit);

		pFavorit->FillTree (wndTree, hTreeItem);
	}
}

//////////////////////////////////////////////////////////////////////
// Construction/Destruction
//////////////////////////////////////////////////////////////////////

CFavoritesManager::CFavoritesManager()
{
	m_himSystem = NULL;
	m_SysImageSize = CSize (0, 0);
}
//*************************************************************************************
CFavoritesManager::~CFavoritesManager()
{
}
//************************************************************************************
BOOL CFavoritesManager::Load ()
{
	HKEY	hKey;

	// find out from the registry where the favorites are located.
	if(RegOpenKey (HKEY_CURRENT_USER, 
		_T("Software\\Microsoft\\Windows\\CurrentVersion\\Explorer\\User Shell Folders"), 
		&hKey) != ERROR_SUCCESS)
	{
		TRACE0("Favorites folder not found\n");
		return FALSE;
	}

	TCHAR sz [MAX_PATH];
	DWORD dwSize = sizeof(sz);

	RegQueryValueEx(hKey, _T("Favorites"), NULL, NULL, (LPBYTE)sz, &dwSize);

	TCHAR	szPath [MAX_PATH];
	ExpandEnvironmentStrings(sz, szPath, MAX_PATH);

	RegCloseKey(hKey);

	SHFILEINFO sfi;
	m_himSystem = (HIMAGELIST)SHGetFileInfo( szPath,
                                       0,
                                       &sfi, 
                                       sizeof(SHFILEINFO), 
                                       SHGFI_SYSICONINDEX | SHGFI_SMALLICON);
	if (m_himSystem != NULL)
	{
		int cx, cy;

		::ImageList_GetIconSize (m_himSystem, &cx, &cy);
		m_SysImageSize = CSize (cx, cy);

		CFavorit::m_iFolderIcon = sfi.iIcon;
	}

	m_Root.Build (szPath);
	return TRUE;
}
//*************************************************************************************
BOOL CFavoritesManager::CreateMenu (CMenu& menu)
{
	return m_Root.CreateMenu (menu);
}
//*************************************************************************************
void CFavoritesManager::FillTree (CTreeCtrl& wndTree)
{
	ASSERT (wndTree.GetSafeHwnd () != NULL);

	wndTree.DeleteAllItems ();
	wndTree.SetImageList (CImageList::FromHandle (m_himSystem), TVSIL_NORMAL);
	m_Root.FillTree (wndTree, NULL);
}
//*************************************************************************************
int CFavoritesManager::GetIDIcon (UINT uiCommandID) const
{
	int iIcon = -1;
	CFavorit::m_IDIcons.Lookup (uiCommandID, iIcon);

	return iIcon;
}
//************************************************************************************
CString CFavoritesManager::GetURLofID (UINT uiCommandID) const
{
	if (uiCommandID == 0)
	{
		ASSERT (FALSE);
		return _T("");
	}

	const CFavorit* pFavorit = m_Root.FindByID (uiCommandID);
	if (pFavorit == NULL)
	{
		ASSERT (FALSE);
		return _T("");
	}

	return pFavorit->m_strURL;
}
