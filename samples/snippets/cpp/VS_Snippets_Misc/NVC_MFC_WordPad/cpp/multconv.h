//
// convert.h : header file
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

#ifdef CONVERTERS

/////////////////////////////////////////////////////////////////////////////
// CConverter

typedef int (CALLBACK *LPFNOUT)(int cch, int nPercentComplete);
typedef int (CALLBACK *LPFNIN)(int flags, int nPercentComplete);
typedef BOOL (FAR PASCAL *PINITCONVERTER)(HWND hWnd, LPCSTR lpszModuleName);
typedef BOOL (FAR PASCAL *PISFORMATCORRECT)(HANDLE ghszFile, HANDLE ghszClass);
typedef int (FAR PASCAL *PFOREIGNTORTF)(HANDLE ghszFile, LPVOID lpv, HANDLE ghBuff,
	HANDLE ghszClass, HANDLE ghszSubset, LPFNOUT lpfnOut);
typedef int (FAR PASCAL *PRTFTOFOREIGN)(HANDLE ghszFile, LPVOID lpv, HANDLE ghBuff,
	HANDLE ghszClass, LPFNIN lpfnIn);

#endif

/////////////////////////////////////////////////////////////////////////////
// CTrackFile
class CTrackFile : public CFile
{
public:
//Construction
	CTrackFile(CFrameWnd* pWnd);
	~CTrackFile();

//Attributes
	int m_nLastPercent;
	ULONGLONG m_dwLength;
	CFrameWnd* m_pFrameWnd;
	CString m_strComplete;
	CString m_strWait;
	CString m_strSaving;
//Operations
	void OutputPercent(int nPercentComplete = 0);
	void OutputString(LPCTSTR lpsz);
	virtual UINT Read(void FAR* lpBuf, UINT nCount);
	virtual void Write(const void FAR* lpBuf, UINT nCount);
};

class COEMFile : public CTrackFile
{
public:
	COEMFile(CFrameWnd* pWnd);
	virtual UINT Read(void FAR* lpBuf, UINT nCount);
	virtual void Write(const void FAR* lpBuf, UINT nCount);
};

#ifdef CONVERTERS

class CConverter : public CTrackFile
{
public:
	CConverter(LPCSTR pszLibName, CFrameWnd* pWnd = NULL);
protected:
	CConverter(CFrameWnd* pWnd = NULL);

public:
//Attributes
	int m_nPercent;
	BOOL m_bDone;
	BOOL m_bConvErr;

	virtual ULONGLONG GetPosition() const
	{
		return 0;
	}

	virtual ULONGLONG GetLength() const
	{
		ASSERT_VALID(this);
		return 1;
	}

// Operations
	BOOL IsFormatCorrect(LPCTSTR pszFileName);
	BOOL DoConversion();
	virtual BOOL Open(LPCTSTR lpszFileName, UINT nOpenFlags,
		CFileException* pError = NULL);
	void WaitForConverter();
	void WaitForBuffer();

// Overridables
	virtual LONG Seek(LONG lOff, UINT nFrom);

	virtual UINT Read(void* lpBuf, UINT nCount);
	virtual void Write(const void* lpBuf, UINT nCount);

	virtual void Abort();
	virtual void Flush();
	virtual void Close();

// Unsupported
	virtual CFile* Duplicate() const;
	virtual void LockRange(DWORD dwPos, DWORD dwCount);
	virtual void UnlockRange(DWORD dwPos, DWORD dwCount);
	virtual void SetLength(DWORD dwNewLen);

//Implementation
public:
	~CConverter();

protected:
	int m_nBytesAvail;
	int m_nBytesWritten;
	BYTE* m_pBuf;
	HANDLE m_hEventFile;
	HANDLE m_hEventConv;
	BOOL m_bForeignToRtf;
	HGLOBAL m_hBuff;
	HGLOBAL m_hFileName;
	void LoadFunctions();
	HINSTANCE m_hLibCnv;
	PINITCONVERTER m_pInitConverter;
	PISFORMATCORRECT m_pIsFormatCorrect;
	PFOREIGNTORTF m_pForeignToRtf;
	PRTFTOFOREIGN m_pRtfToForeign;
	int CALLBACK WriteOut(int cch, int nPercentComplete);
	int CALLBACK ReadIn(int nPercentComplete);
	static HGLOBAL StringToHGLOBAL(LPCSTR pstr);
	static int CALLBACK WriteOutStatic(int cch, int nPercentComplete);
	static int CALLBACK ReadInStatic(int flags, int nPercentComplete);
	static UINT ConverterThread(LPVOID pParam);
	static CConverter *m_pThis;
};

#endif

/////////////////////////////////////////////////////////////////////////////
