//
// richdoc.cpp : implementation of the CRichEditDoc class
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
#include "resource.h"
#include "strings.h"

#include "multconv.h"

#ifdef _DEBUG
#undef THIS_FILE
static char BASED_CODE THIS_FILE[] = __FILE__;
#endif

static const BYTE byteRTFPrefix[5] = {'{', '\\', 'r', 't', 'f'};
static const BYTE byteWord2Prefix[4] = {0xDB, 0xA5, 0x2D, 0x00};
static const BYTE byteCompFilePrefix[8] = {0xD0, 0xCF, 0x11, 0xE0, 0xA1, 0xB1, 0x1A, 0xE1};
static const BYTE byteWrite1Prefix[2] = {0x31, 0xBE};
static const BYTE byteWrite2Prefix[2] = {0x32, 0xBE};
static const BYTE byteExePrefix[2] = {0x4D, 0x5A};

/////////////////////////////////////////////////////////////////////////////

static BOOL IsConverterFormat(LPCTSTR pszConverter, LPCTSTR pszPathName);
static BOOL IsWord6(LPCTSTR pszConverter, LPCTSTR pszPathName);

DocType doctypes[NUM_DOC_TYPES] =
{
	DECLARE_DOCTYPE(WINWORD2, FALSE, FALSE, FALSE, NULL),
	DECLARE_DOCTYPE(WINWORD6, TRUE, FALSE, TRUE, szWordConverter),
	DECLARE_DOCTYPE_SYN(WORDPAD, WINWORD6, TRUE, TRUE, FALSE, szWordConverter),
	DECLARE_DOCTYPE(WRITE, TRUE, FALSE, FALSE, szWriteConverter),
	DECLARE_DOCTYPE(RICHTEXT, TRUE, TRUE, FALSE, NULL),
	DECLARE_DOCTYPE(TEXT, TRUE, TRUE, FALSE, NULL),
	DECLARE_DOCTYPE(OEMTEXT, TRUE, TRUE, FALSE, NULL),
	DECLARE_DOCTYPE(ALL, TRUE, FALSE, FALSE, NULL),
	DECLARE_DOCTYPE(EXE, FALSE, FALSE, FALSE, NULL),
	DECLARE_DOCTYPE_NULL(EMBEDDED, FALSE, FALSE, FALSE, NULL)
};

CString DocType::GetString(int nID)
{
	ASSERT(idStr != NULL);
	CString str;
	VERIFY(str.LoadString(idStr));
	CString strSub;
	AfxExtractSubString(strSub, str, nID);
	return strSub;
}

static BOOL IsConverterFormat(LPCSTR pszConverter, LPCTSTR pszPathName)
{
	CConverter conv(pszConverter);
	return conv.IsFormatCorrect(pszPathName);
}

static BOOL IsLeadMatch(CFile& file, const BYTE* pb, UINT nCount)
{
	// check for match at beginning of file
	BOOL b = FALSE;
	BYTE* buf = new BYTE[nCount];

	TRY
	{
		file.SeekToBegin();
		memset(buf, 0, nCount);
		file.Read(buf, nCount);
		if (memcmp(buf, pb, nCount) == 0)
			b = TRUE;
	}
	END_TRY

	delete [] buf;
	return b;
}

static BOOL IsWord6(LPCTSTR pszPathName)
{
	USES_CONVERSION;
	BOOL bRes = FALSE;
	// see who created it
	LPSTORAGE lpStorage;
	SCODE sc = StgOpenStorage(T2COLE(pszPathName), NULL,
		STGM_READ|STGM_SHARE_EXCLUSIVE, 0, 0, &lpStorage);
	if (sc == NOERROR)
	{
		LPSTREAM lpStream;
		sc = lpStorage->OpenStream(T2COLE(szSumInfo), NULL,
			STGM_READ|STGM_SHARE_EXCLUSIVE, NULL, &lpStream);
		if (sc == NOERROR)
		{
			lpStream->Release();
			bRes = TRUE;
		}
		lpStorage->Release();
	}
	return bRes;
}

int GetDocTypeFromName(LPCTSTR pszPathName, CFileException& fe)
{
	CFile file;
	ASSERT(pszPathName != NULL);

	if (!file.Open(pszPathName, CFile::modeRead | CFile::shareDenyWrite, &fe))
		return -1;

	CFileStatus stat;
	VERIFY(file.GetStatus(stat));

	if (stat.m_size == 0) // file is empty
	{
		CString ext = CString(pszPathName).Right(4);
		if (ext[0] != '.')
			return RD_TEXT;
		if (lstrcmpi(ext, _T(".doc"))==0)
			return RD_WORDPAD;
		if (lstrcmpi(ext, _T(".rtf"))==0)
			return RD_RICHTEXT;
		return RD_TEXT;
	}
	// RTF
	if (IsLeadMatch(file, byteRTFPrefix, sizeof(byteRTFPrefix)))
		return RD_RICHTEXT;
	// WORD 2
	if (IsLeadMatch(file, byteWord2Prefix, sizeof(byteWord2Prefix)))
		return RD_WINWORD2;
	// EXE
	if (IsLeadMatch(file, byteExePrefix, sizeof(byteExePrefix)))
		return RD_EXE;
	// write file can start with 31BE or 32BE depending on whether it has
	// OLE objects in it or not
	if (IsLeadMatch(file, byteWrite1Prefix, sizeof(byteWrite1Prefix)) ||
		IsLeadMatch(file, byteWrite2Prefix, sizeof(byteWrite2Prefix)))
	{
		file.Close();
		if (IsConverterFormat(szWriteConverter, pszPathName))
			return RD_WRITE;
		else
			return RD_TEXT;
	}

	// test for compound file
	if (IsLeadMatch(file, byteCompFilePrefix, sizeof(byteCompFilePrefix)))
	{
		file.Close();
		if (IsConverterFormat(szWordConverter, pszPathName))
		{
			if (IsWord6(pszPathName))
				return RD_WINWORD6;
			else
				return RD_WORDPAD;
		}
		return RD_TEXT;
	}
	return RD_TEXT;
}

void ScanForConverters()
{
	static BOOL bScanned = FALSE;
	if (bScanned)
		return;

	for (int i=0;i<NUM_DOC_TYPES;i++)
	{
		LPCSTR lpsz = doctypes[i].pszConverterName;
		// if converter specified but can't find it
		if (lpsz != NULL && *lpsz != NULL && !IsDLLInPath(lpsz))
			doctypes[i].bRead = doctypes[i].bWrite = FALSE;
	}
	if (GetSystemMetrics(SM_DBCSENABLED))
		doctypes[RD_OEMTEXT].bRead = doctypes[RD_OEMTEXT].bWrite = FALSE;
	bScanned = TRUE;
}

BOOL IsDLLInPath(LPCSTR lpszName)
{
	ASSERT(lpszName != NULL);
	OFSTRUCT ofs;
	return (OpenFile(lpszName, &ofs, OF_EXIST) != HFILE_ERROR);
}

CString GetExtFromType(int nDocType)
{
	ScanForConverters();

	CString str = doctypes[nDocType].GetString(DOCTYPE_EXT);
	if (!str.IsEmpty())
	{
		ASSERT(str[1] == '.');
		return str.Right(str.GetLength()-1);
	}
	return str;
}

// returns an RD_* from an index into the openfile dialog types
int GetTypeFromIndex(int nIndex, BOOL bOpen)
{
	ScanForConverters();

	int nCnt = 0;
	for (int i=0;i<NUM_DOC_TYPES;i++)
	{
		if (!doctypes[i].bDup &&
			(bOpen ? doctypes[i].bRead : doctypes[i].bWrite))
		{
			if (nCnt == nIndex)
				return i;
			nCnt++;
		}
	}
	ASSERT(FALSE);
	return -1;
}

// returns an index into the openfile dialog types for the RD_* type
int GetIndexFromType(int nType, BOOL bOpen)
{
	ScanForConverters();

	int nCnt = 0;
	for (int i=0;i<NUM_DOC_TYPES;i++)
	{
		if (!doctypes[i].bDup &&
			(bOpen ? doctypes[i].bRead : doctypes[i].bWrite))
		{
			if (i == nType)
				return nCnt;
			nCnt++;
		}
	}
	return -1;
}

CString GetFileTypes(BOOL bOpen)
{
	ScanForConverters();

	CString str;
	for (int i=0;i<NUM_DOC_TYPES;i++)
	{
		if (bOpen && doctypes[i].bRead && !doctypes[i].bDup)
		{
			str += doctypes[i].GetString(DOCTYPE_DESC);
			str += (TCHAR)NULL;
			str += doctypes[i].GetString(DOCTYPE_EXT);
			str += (TCHAR)NULL;
		}
		else if (!bOpen && doctypes[i].bWrite && !doctypes[i].bDup)
		{
			str += doctypes[i].GetString(DOCTYPE_DOCTYPE);
			str += (TCHAR)NULL;
			str += doctypes[i].GetString(DOCTYPE_EXT);
			str += (TCHAR)NULL;
		}
	}
	return str;
}
