// This is a part of the Microsoft Foundation Classes C++ library.
// Copyright (c) Microsoft Corporation.  All rights reserved.
//
// This source code is only intended as a supplement to the
// Microsoft Foundation Classes Reference and related
// electronic documentation provided with the library.
// See these sources for detailed information regarding the
// Microsoft Foundation Classes product.

#include "stdafx.h"
#include <winnls.h>

#include "DrawClient.h"

#ifdef _DEBUG
#undef THIS_FILE
static char BASED_CODE THIS_FILE[] = __FILE__;
#endif

#include <objbase.h>

// the following header redefines
// the DEFINE_GUID macro to actually allocate data

#include <initguid.h>
#ifndef INITGUID
#define INITGUID
#endif

// the DEFINE_GUID macro in the following header now allocates data
#include "summinfo.h"

const OLECHAR szSummInfo[] = OLESTR("\005SummaryInformation");

#if defined(_UNICODE)
LPCSTR tcstocs(LPCTSTR lpctStr) {                       // typed char(WCHAR) to CHAR
	size_t numConv = 0;
	static CHAR strTemp[1024];
	wcstombs_s(&numConv, strTemp, 1024, lpctStr, 1024);
	return strTemp;
}
#else // !defined(_UNICODE)
#define tcstocs(lpctStr)(LPCSTR)(lpctStr)
#endif

CSummInfo::CSummInfo()
{
	m_propSet.SetFormatVersion(0);
	DWORD dwOSVer;
	dwOSVer = (DWORD)MAKELONG(LOWORD(GetVersion()), 2);
	m_propSet.SetOSVersion(dwOSVer);
	m_propSet.SetClassID(FMTID_SummaryInformation);
	m_pSection = m_propSet.AddSection(FMTID_SummaryInformation);
	UINT cp = GetACP();
	m_pSection->Set(PID_CODEPAGE, (void*)&cp, VT_I2);
	SetTitle(_T(""));
	SetSubject(_T(""));
	SetAuthor(_T(""));
	SetKeywords(_T(""));
	SetComments(_T(""));
	SetTemplate(_T(""));
	SetLastAuthor(_T(""));
	m_pSection->Set(PIDSI_REVNUMBER, (void*)_T("0"), VT_LPSTR);
	FILETIME zeroTime = {0L, 0L};
	m_pSection->Set(PIDSI_EDITTIME, (void*)&zeroTime, VT_FILETIME);
	m_pSection->Set(PIDSI_LASTPRINTED, (void*)&zeroTime, VT_FILETIME);
	m_pSection->Set(PIDSI_LASTSAVE_DTM, (void*)&zeroTime, VT_FILETIME);
	m_pSection->Set(PIDSI_CREATE_DTM, (void*)&zeroTime, VT_FILETIME);
	SetNumPages(0);
	SetNumWords(0);
	SetNumChars(0);
	SetAppname(_T(""));
	SetSecurity(0);
}

BOOL CSummInfo::SetTitle(LPCTSTR szTitle)
{
	return m_pSection->Set(PIDSI_TITLE, (void*)tcstocs(szTitle), VT_LPSTR);
}

CString CSummInfo::GetTitle()
{
	return CString((LPCSTR)m_pSection->Get(PIDSI_TITLE));
}

BOOL CSummInfo::SetSubject(LPCTSTR szSubject)
{
	return m_pSection->Set(PIDSI_SUBJECT, (void*)tcstocs(szSubject), VT_LPSTR);
}

CString CSummInfo::GetSubject()
{
	return CString((LPCSTR)m_pSection->Get(PIDSI_SUBJECT));
}

BOOL CSummInfo::SetAuthor(LPCTSTR szAuthor)
{
	return m_pSection->Set(PIDSI_AUTHOR, (void*)tcstocs(szAuthor), VT_LPSTR);
}

CString CSummInfo::GetAuthor()
{
	return CString((LPCSTR)m_pSection->Get(PIDSI_AUTHOR));
}

BOOL CSummInfo::SetKeywords(LPCTSTR szKeywords)
{
	return m_pSection->Set(PIDSI_KEYWORDS, (void*)tcstocs(szKeywords), VT_LPSTR);
}

CString CSummInfo::GetKeywords()
{
	return CString((LPCSTR)m_pSection->Get(PIDSI_KEYWORDS));
}

BOOL CSummInfo::SetComments(LPCTSTR szComments)
{
	return m_pSection->Set(PIDSI_COMMENTS, (void*)tcstocs(szComments), VT_LPSTR);
}

CString CSummInfo::GetComments()
{
	return CString((LPCSTR)m_pSection->Get(PIDSI_COMMENTS));
}

BOOL CSummInfo::SetTemplate(LPCTSTR szTemplate)
{
	return m_pSection->Set(PIDSI_TEMPLATE, (void*)tcstocs(szTemplate), VT_LPSTR);
}

CString CSummInfo::GetTemplate()
{
	return CString((LPCSTR)m_pSection->Get(PIDSI_TEMPLATE));
}

BOOL CSummInfo::SetLastAuthor(LPCTSTR szLastAuthor)
{
	return m_pSection->Set(PIDSI_LASTAUTHOR, (void*)tcstocs(szLastAuthor), VT_LPSTR);
}

CString CSummInfo::GetLastAuthor()
{
	return CString((LPCSTR)m_pSection->Get(PIDSI_LASTAUTHOR));
}

BOOL CSummInfo::IncrRevNum()
{
	ULONG count;
	_stscanf_s((LPCTSTR)GetRevNum(), _T("%lu"), &count);
	count++;
	TCHAR buff[20];
	_stprintf_s(buff, 20, _T("%lu"), count);
	return m_pSection->Set(PIDSI_REVNUMBER, (void*)buff, VT_LPSTR);
}

CString CSummInfo::GetRevNum()
{
	return CString((LPCSTR)m_pSection->Get(PIDSI_REVNUMBER));
}

void CSummInfo::StartEditTimeCount()
{
	FILETIME now;
	CoFileTimeNow(&now);
	startEdit = *(__int64*)&now;
}

BOOL CSummInfo::AddCountToEditTime()
{
	FILETIME now;
	CoFileTimeNow(&now);
	__int64 currTime = *(__int64*)&now;
	__int64 thisSession = currTime - startEdit;
	__int64 lastTotal = *(__int64*)m_pSection->Get(PIDSI_EDITTIME);
	__int64 newTotal = lastTotal + thisSession;
	return m_pSection->Set(PIDSI_EDITTIME, (void*)&newTotal, VT_FILETIME);
}

CString CSummInfo::GetEditTime()
{
	FILETIME now;
	CoFileTimeNow(&now);
	__int64 currTime = *(__int64*)&now;
	__int64 thisSession = currTime - startEdit;
	__int64 lastTotal = *(__int64*)m_pSection->Get(PIDSI_EDITTIME);
	__int64 newTotal = lastTotal + thisSession;
	ULONG editMinutes = (ULONG)(newTotal/600000000);

	TCHAR buff[20];
	_stprintf_s(buff, 20, _T("%lu min"), editMinutes);
	return CString(buff);
}

BOOL CSummInfo::RecordPrintDate()
{
	FILETIME printDate;
	CoFileTimeNow(&printDate);
	return m_pSection->Set(PIDSI_LASTPRINTED,
		(void*)&printDate, VT_FILETIME);
}

CString CSummInfo::GetLastPrintDate()
{
	FILETIME* pPrintDate = (FILETIME*)m_pSection->Get(PIDSI_LASTPRINTED);
	if ((pPrintDate == NULL) || ((pPrintDate->dwLowDateTime == 0L) && (pPrintDate->dwHighDateTime == 0L)))
		return CString(_T(""));
	else
	{
		COleDateTime tempDate = *pPrintDate;
		return tempDate.Format();
	}
}

BOOL CSummInfo::RecordCreateDate()
{
	FILETIME createDate;
	CoFileTimeNow(&createDate);
	return m_pSection->Set(PIDSI_CREATE_DTM, (void*)&createDate, VT_FILETIME);
}

CString CSummInfo::GetCreateDate()
{
	FILETIME* pCreateDate = (FILETIME*)m_pSection->Get(PIDSI_CREATE_DTM);
	if ((pCreateDate == NULL) || ((pCreateDate->dwLowDateTime == 0L) && (pCreateDate->dwHighDateTime == 0L)  ))
		return CString(_T(""));
	else
	{
		COleDateTime tempDate = *pCreateDate;
		return tempDate.Format();
	}
}

BOOL CSummInfo::RecordSaveDate()
{
	FILETIME saveDate;
	CoFileTimeNow(&saveDate);
	return m_pSection->Set(PIDSI_LASTSAVE_DTM, (void*)&saveDate, VT_FILETIME);
}

CString CSummInfo::GetLastSaveDate()
{
	FILETIME *pSaveDate = (FILETIME*)m_pSection->Get(PIDSI_LASTSAVE_DTM);
	if ((pSaveDate == NULL) || ((pSaveDate->dwLowDateTime == 0L) && (pSaveDate->dwHighDateTime == 0L)  ))
		return CString(_T(""));
	else
	{
		COleDateTime tempDate = *pSaveDate;
		return tempDate.Format();
	}
}

BOOL CSummInfo::SetNumPages(ULONG nPages)
{
	return m_pSection->Set(PIDSI_PAGECOUNT, (void*)&nPages, VT_I4);
}

CString CSummInfo::GetNumPages()
{
	TCHAR buff[20];
	ULONG* pNumPages = (ULONG*)m_pSection->Get(PIDSI_PAGECOUNT);
	if (pNumPages != NULL)
	{
		_stprintf_s(buff,20, _T("%lu"), *pNumPages);
		return CString(buff);
	}
	else
		return CString(_T(""));
}

BOOL CSummInfo::SetNumWords(ULONG nWords)
{
	return m_pSection->Set(PIDSI_WORDCOUNT, (void*)&nWords, VT_I4);
}

CString CSummInfo::GetNumWords()
{
	TCHAR buff[20];
	ULONG* pNumWords = (ULONG*)m_pSection->Get(PIDSI_WORDCOUNT);
	if (pNumWords != NULL)
	{
		_stprintf_s(buff, 20,_T("%lu"), *pNumWords);
		return CString(buff);
	}
	else
		return CString(_T(""));
}

BOOL CSummInfo::SetNumChars(ULONG nChars)
{
	return m_pSection->Set(PIDSI_CHARCOUNT, (void*)&nChars, VT_I4);
}

CString CSummInfo::GetNumChars()
{
	TCHAR buff[20];
	ULONG* pNumChars = (ULONG*)m_pSection->Get(PIDSI_CHARCOUNT);
	if (pNumChars != NULL)
	{
		_stprintf_s(buff, 20,_T("%lu"), *pNumChars);
		return CString(buff);
	}
	else
		return CString(_T(""));
}

BOOL CSummInfo::SetAppname(LPCTSTR szAppname)
{
	return m_pSection->Set(PIDSI_APPNAME, (void*)tcstocs(szAppname), VT_LPSTR);
}

CString CSummInfo::GetAppname()
{
	return CString((LPCSTR)m_pSection->Get(PIDSI_APPNAME));
}

BOOL CSummInfo::SetSecurity(ULONG nLevel)
{
	return m_pSection->Set(PID_SECURITY, (void*)&nLevel, VT_I4);
}

CString CSummInfo::GetSecurity()
{
	TCHAR buff[20];
	ULONG* pSecurity = (ULONG*)m_pSection->Get(PID_SECURITY);
	if (pSecurity != NULL)
	{
		_stprintf_s(buff, 20,_T("%lu"), *pSecurity);
		return CString(buff);
	}
	else
		return CString(_T(""));
}

BOOL CSummInfo::WriteToStorage(LPSTORAGE lpRootStg)
{
	if (lpRootStg != NULL)
	{
		LPSTREAM lpStream = NULL;
		if (FAILED(lpRootStg->CreateStream(szSummInfo, STGM_SHARE_EXCLUSIVE|STGM_CREATE|STGM_READWRITE, 0, 0, &lpStream)))
		{
			TRACE(_T("CreateStream failed\n"));
			return FALSE;
		}
		else
		{
			if (!m_propSet.WriteToStream(lpStream))
			{
				TRACE(_T("WriteToStream failed\n"));
				return FALSE;
			}
			lpRootStg->Commit(STGC_DEFAULT);
			lpStream->Release();
			return TRUE;
		}
	}
	return FALSE;
}

BOOL CSummInfo::ReadFromStorage(LPSTORAGE lpRootStg)
{
	if (lpRootStg != NULL)
	{
		LPSTREAM lpStream = NULL;

		if (FAILED(lpRootStg->OpenStream(szSummInfo, NULL, STGM_SHARE_EXCLUSIVE|STGM_READ, 0, &lpStream)))
		{
			TRACE(_T("OpenStream failed\n"));
			return FALSE;
		}
		else
		{
			if (!m_propSet.ReadFromStream(lpStream))
			{
				TRACE(_T("ReadFromStream failed\n"));
				return FALSE;
			}
			m_pSection = m_propSet.GetSection(FMTID_SummaryInformation);
			lpStream->Release();
			return TRUE;
		}
	}
	return FALSE;
}
