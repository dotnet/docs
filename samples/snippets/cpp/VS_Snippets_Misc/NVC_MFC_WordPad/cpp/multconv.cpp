//
// convert.cpp : implementation file
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
#include "multconv.h"
#include "mswd6_32.h"

#ifdef _DEBUG
#undef THIS_FILE
static char BASED_CODE THIS_FILE[] = __FILE__;
#endif

#ifdef CONVERTERS
CConverter* CConverter::m_pThis = NULL;
#endif

#define BUFFSIZE 4096

CTrackFile::CTrackFile(CFrameWnd* pWnd) : CFile()
{
	m_nLastPercent = -1;
	m_dwLength = 0;
	m_pFrameWnd = pWnd;
	VERIFY(m_strComplete.LoadString(IDS_COMPLETE));
	VERIFY(m_strWait.LoadString(IDS_PLEASE_WAIT));
	VERIFY(m_strSaving.LoadString(IDS_SAVING));
//  OutputPercent(0);
}

CTrackFile::~CTrackFile()
{
	OutputPercent(100);
	if (m_pFrameWnd != NULL)
		m_pFrameWnd->SetMessageText(AFX_IDS_IDLEMESSAGE);
}

UINT CTrackFile::Read(void FAR* lpBuf, UINT nCount)
{
	UINT n = CFile::Read(lpBuf, nCount);
	if (m_dwLength != 0)
		OutputPercent((int)((GetPosition()*100)/m_dwLength));
	return n;
}

void CTrackFile::Write(const void FAR* lpBuf, UINT nCount)
{
	CFile::Write(lpBuf, nCount);
	OutputString(m_strSaving);
//  if (m_dwLength != 0)
//      OutputPercent((int)((GetPosition()*100)/m_dwLength));
}

void CTrackFile::OutputString(LPCTSTR lpsz)
{
	if (m_pFrameWnd != NULL)
	{
		m_pFrameWnd->SetMessageText(lpsz);
		CWnd* pBarWnd = m_pFrameWnd->GetMessageBar();
		if (pBarWnd != NULL)
			pBarWnd->UpdateWindow();
	}
}

void CTrackFile::OutputPercent(int nPercentComplete)
{
	if (m_pFrameWnd != NULL && m_nLastPercent != nPercentComplete)
	{
		m_nLastPercent = nPercentComplete;
		TCHAR buf[64];
		int n = nPercentComplete;
		wsprintf(buf, (n==100) ? m_strWait : m_strComplete, n);
		OutputString(buf);
	}
}

COEMFile::COEMFile(CFrameWnd* pWnd) : CTrackFile(pWnd)
{
}

UINT COEMFile::Read(void FAR* lpBuf, UINT nCount)
{
	UINT n = CTrackFile::Read(lpBuf, nCount);
	OemToCharBuffA((const char*)lpBuf, (char*)lpBuf, n);
	return n;
}

void COEMFile::Write(const void FAR* lpBuf, UINT nCount)
{
	CharToOemBuffA((const char*)lpBuf, (char*)lpBuf, nCount);
	CTrackFile::Write(lpBuf, nCount);
}

#ifdef CONVERTERS

HGLOBAL CConverter::StringToHGLOBAL(LPCSTR pstr)
{
	HGLOBAL hMem = NULL;
	if (pstr != NULL)
	{
		hMem = GlobalAlloc(GHND, (lstrlenA(pstr)*2)+1);
		char* p = (char*) GlobalLock(hMem);
		ASSERT(p != NULL);
		if (p != NULL)
			lstrcpyA(p, pstr);
		GlobalUnlock(hMem);
	}
	return hMem;
}

CConverter::CConverter(LPCSTR pszLibName, CFrameWnd* pWnd) : CTrackFile(pWnd)
{
	USES_CONVERSION;
	m_hBuff = NULL;
	m_pBuf = NULL;
	m_nBytesAvail = 0;
	m_nBytesWritten = 0;
	m_nPercent = 0;
	m_hEventFile = NULL;
	m_hEventConv = NULL;
	m_bDone = TRUE;
	m_bConvErr = FALSE;
	m_hFileName = NULL;
	OFSTRUCT ofs;
	if (OpenFile(pszLibName, &ofs, OF_EXIST) == HFILE_ERROR)
	{
		m_hLibCnv = NULL;
		return;
	}
	m_hLibCnv = LoadLibraryA(pszLibName);
	if (m_hLibCnv < (HINSTANCE)HINSTANCE_ERROR)
		m_hLibCnv = NULL;
	else
	{
		LoadFunctions();
		ASSERT(m_pInitConverter != NULL);
		if (m_pInitConverter != NULL)
		{
			CString str = AfxGetAppName();
			str.MakeUpper();
			VERIFY(m_pInitConverter(AfxGetMainWnd()->GetSafeHwnd(), T2CA(str)));
		}
	}
}

CConverter::CConverter(CFrameWnd* pWnd) : CTrackFile(pWnd)
{
	m_pInitConverter = NULL;
	m_pIsFormatCorrect = NULL;
	m_pForeignToRtf = NULL;
	m_pRtfToForeign = NULL;
	m_bConvErr = FALSE;
	m_hFileName = NULL;
}

CConverter::~CConverter()
{
	if (!m_bDone) // converter thread hasn't exited
	{
		WaitForConverter();
		m_nBytesAvail = 0;
		VERIFY(ResetEvent(m_hEventFile));
		m_nBytesAvail = 0;
		SetEvent(m_hEventConv);
		WaitForConverter();// wait for DoConversion exit
		VERIFY(ResetEvent(m_hEventFile));
	}

	if (m_hEventFile != NULL)
		VERIFY(CloseHandle(m_hEventFile));
	if (m_hEventConv != NULL)
		VERIFY(CloseHandle(m_hEventConv));
	if (m_hLibCnv != NULL)
		FreeLibrary(m_hLibCnv);
	if (m_hFileName != NULL)
		GlobalFree(m_hFileName);
}

void CConverter::WaitForConverter()
{
	// while event not signalled -- process messages
	while (MsgWaitForMultipleObjects(1, &m_hEventFile, FALSE, INFINITE,
		QS_SENDMESSAGE) != WAIT_OBJECT_0)
	{
		MSG msg;
		PeekMessage(&msg, 0, 0, 0, PM_NOREMOVE);
	}
}

void CConverter::WaitForBuffer()
{
	// while event not signalled -- process messages
	while (MsgWaitForMultipleObjects(1, &m_hEventConv, FALSE, INFINITE,
		QS_SENDMESSAGE) != WAIT_OBJECT_0)
	{
		MSG msg;
		PeekMessage(&msg, 0, 0, 0, PM_NOREMOVE);
	}
}

UINT CConverter::ConverterThread(LPVOID)
{
	ASSERT(m_pThis != NULL);

	HRESULT hRes = OleInitialize(NULL);
	if (hRes != S_OK && hRes != S_FALSE)
	{
		ASSERT(FALSE);
	}
	m_pThis->DoConversion();
	OleUninitialize();

	return 0;
}

BOOL CConverter::IsFormatCorrect(LPCTSTR pszFileName)
{
	USES_CONVERSION;
	int nRet;
	if (m_hLibCnv == NULL || m_pIsFormatCorrect == NULL)
		return FALSE;

	char buf[_MAX_PATH];
	strcpy(buf, T2CA(pszFileName));

	CharToOemA(buf, buf);

	HGLOBAL hFileName = StringToHGLOBAL(buf);
	HGLOBAL hDesc = GlobalAlloc(GHND, 256);
	ASSERT(hDesc != NULL);
	nRet = m_pIsFormatCorrect(hFileName, hDesc);
	GlobalFree(hDesc);
	GlobalFree(hFileName);
	return (nRet == 1) ? TRUE : FALSE;
}

// static callback function
int CALLBACK CConverter::WriteOutStatic(int cch, int nPercentComplete)
{
	ASSERT(m_pThis != NULL);
	return m_pThis->WriteOut(cch, nPercentComplete);
}

int CALLBACK CConverter::WriteOut(int cch, int nPercentComplete)
{
	ASSERT(m_hBuff != NULL);
	m_nPercent = nPercentComplete;
	if (m_hBuff == NULL)
		return -9;
	if (cch != 0)
	{
		WaitForBuffer();
		VERIFY(ResetEvent(m_hEventConv));
		m_nBytesAvail = cch;
		SetEvent(m_hEventFile);
		WaitForBuffer();
	}
	return 0; //everything OK
}

int CALLBACK CConverter::ReadInStatic(int /*flags*/, int nPercentComplete)
{
	ASSERT(m_pThis != NULL);
	return m_pThis->ReadIn(nPercentComplete);
}

int CALLBACK CConverter::ReadIn(int /*nPercentComplete*/)
{
	ASSERT(m_hBuff != NULL);
	if (m_hBuff == NULL)
		return -8;

	SetEvent(m_hEventFile);
	WaitForBuffer();
	VERIFY(ResetEvent(m_hEventConv));

	return m_nBytesAvail;
}

BOOL CConverter::DoConversion()
{
	USES_CONVERSION;
	m_nLastPercent = -1;
//  m_dwLength = 0; // prevent Read/Write from displaying
	m_nPercent = 0;

	ASSERT(m_hBuff != NULL);
	ASSERT(m_pThis != NULL);
	HGLOBAL hDesc = StringToHGLOBAL("");
	HGLOBAL hSubset = StringToHGLOBAL("");

	int nRet;
	if (m_bForeignToRtf)
	{
		ASSERT(m_pForeignToRtf != NULL);
		ASSERT(m_hFileName != NULL);
		nRet = m_pForeignToRtf(m_hFileName, NULL, m_hBuff, hDesc, hSubset,
			(LPFNOUT)WriteOutStatic);
		// wait for next CConverter::Read to come through
		WaitForBuffer();
		VERIFY(ResetEvent(m_hEventConv));
	}
	else
	{
		ASSERT(m_pRtfToForeign != NULL);
		ASSERT(m_hFileName != NULL);
		nRet = m_pRtfToForeign(m_hFileName, NULL, m_hBuff, hDesc,
			(LPFNIN)ReadInStatic);
		// don't need to wait for m_hEventConv
	}

	GlobalFree(hDesc);
	GlobalFree(hSubset);
	if (m_pBuf != NULL)
		GlobalUnlock(m_hBuff);
	GlobalFree(m_hBuff);

	if (nRet != 0)
		m_bConvErr = TRUE;

	m_bDone = TRUE;
	m_nPercent = 100;
	m_nLastPercent = -1;

	SetEvent(m_hEventFile);

	return (nRet == 0);
}

void CConverter::LoadFunctions()
{
	m_pInitConverter = (PINITCONVERTER)GetProcAddress(m_hLibCnv, "InitConverter32");
	m_pIsFormatCorrect = (PISFORMATCORRECT)GetProcAddress(m_hLibCnv, "IsFormatCorrect32");
	m_pForeignToRtf = (PFOREIGNTORTF)GetProcAddress(m_hLibCnv, "ForeignToRtf32");
	m_pRtfToForeign = (PRTFTOFOREIGN)GetProcAddress(m_hLibCnv, "RtfToForeign32");
}
#endif

///////////////////////////////////////////////////////////////////////////////

BOOL CConverter::Open(LPCTSTR pszFileName, UINT nOpenFlags,
	CFileException* pException)
{
	USES_CONVERSION;
	// we convert to oem and back because of the following case
	// test(c).txt becomes testc.txt in OEM and stays testc.txt to Ansi
	char buf[_MAX_PATH];
	strcpy(buf, T2CA(pszFileName));
	CharToOemA(buf, buf);
	OemToCharA(buf, buf);

	LPTSTR lpszFileNameT = A2T(buf);

	// let's make sure we could do what is wanted directly even though we aren't
	m_bCloseOnDelete = FALSE;
	m_hFile = hFileNull;

	BOOL bOpen = CFile::Open(lpszFileNameT, nOpenFlags, pException);
	CFile::Close();
	if (!bOpen)
		return FALSE;

	m_bForeignToRtf = !(nOpenFlags & (CFile::modeReadWrite | CFile::modeWrite));

	// check for reading empty file
	if (m_bForeignToRtf)
	{
		CFileStatus stat;
		if (CFile::GetStatus(lpszFileNameT, stat) && stat.m_size == 0)
			return TRUE;
	}

	//set security attributes to inherit handle
	SECURITY_ATTRIBUTES sa = {sizeof(SECURITY_ATTRIBUTES), NULL, TRUE};
	//create the events
	m_hEventFile = CreateEvent(&sa, TRUE, FALSE, NULL);
	m_hEventConv = CreateEvent(&sa, TRUE, FALSE, NULL);
	//create the converter thread and create the events

	CharToOemA(buf, buf);
	ASSERT(m_hFileName == NULL);
	m_hFileName = StringToHGLOBAL(buf);

	m_pThis = this;
	m_bDone = FALSE;
	m_hBuff = GlobalAlloc(GHND, BUFFSIZE);
	ASSERT(m_hBuff != NULL);

	AfxBeginThread(ConverterThread, this, THREAD_PRIORITY_NORMAL, 0, 0, &sa);

	return TRUE;
}

// m_hEventConv -- the main thread signals this event when ready for more data
// m_hEventFile -- the converter signals this event when data is ready

UINT CConverter::Read(void FAR* lpBuf, UINT nCount)
{
	ASSERT(m_bForeignToRtf);
	if (m_bDone)
		return 0;
	// if converter is done
	int cch = nCount;
	BYTE* pBuf = (BYTE*)lpBuf;
	while (cch != 0)
	{
		if (m_nBytesAvail == 0)
		{
			if (m_pBuf != NULL)
				GlobalUnlock(m_hBuff);
			m_pBuf = NULL;
			SetEvent(m_hEventConv);
			WaitForConverter();
			VERIFY(ResetEvent(m_hEventFile));
			if (m_bConvErr)
				AfxThrowFileException(CFileException::genericException);
			if (m_bDone)
				return nCount - cch;
			m_pBuf = (BYTE*)GlobalLock(m_hBuff);
			ASSERT(m_pBuf != NULL);
		}
		int nBytes = min(cch, m_nBytesAvail);
		memcpy(pBuf, m_pBuf, nBytes);
		pBuf += nBytes;
		m_pBuf += nBytes;
		m_nBytesAvail -= nBytes;
		cch -= nBytes;
		OutputPercent(m_nPercent);
	}
	return nCount - cch;
}

void CConverter::Write(const void FAR* lpBuf, UINT nCount)
{
	ASSERT(!m_bForeignToRtf);

	m_nBytesWritten += nCount;
	while (nCount != 0)
	{
		WaitForConverter();
		VERIFY(ResetEvent(m_hEventFile));
		if (m_bConvErr)
			AfxThrowFileException(CFileException::genericException);
		m_nBytesAvail = min(nCount, BUFFSIZE);
		nCount -= m_nBytesAvail;
		BYTE* pBuf = (BYTE*)GlobalLock(m_hBuff);
		ASSERT(pBuf != NULL);
		memcpy(pBuf, lpBuf, m_nBytesAvail);
		GlobalUnlock(m_hBuff);
		SetEvent(m_hEventConv);
	}
	OutputString(m_strSaving);
}

LONG CConverter::Seek(LONG lOff, UINT nFrom)
{
	if (lOff != 0 && nFrom != current)
		AfxThrowNotSupportedException();
	return 0;
}

void CConverter::Flush()
{
}

void CConverter::Close()
{
}

void CConverter::Abort()
{
}

CFile* CConverter::Duplicate() const
{
	AfxThrowNotSupportedException();
	return NULL;
}

void CConverter::LockRange(DWORD, DWORD)
{
	AfxThrowNotSupportedException();
}

void CConverter::UnlockRange(DWORD, DWORD)
{
	AfxThrowNotSupportedException();
}

void CConverter::SetLength(DWORD)
{
	AfxThrowNotSupportedException();
}
