//
// doctype.h : header file
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

#define RD_WINWORD2 0
#define RD_WINWORD6 1
#define RD_WORDPAD 2
#define RD_WRITE 3
#define RD_RICHTEXT 4
#define RD_TEXT 5
#define RD_OEMTEXT 6
#define RD_ALL 7
#define RD_EXE 8
#define RD_EMBEDDED 9
#define NUM_DOC_TYPES 10

#define RD_DEFAULT RD_WORDPAD
#define RD_NATIVE RD_RICHTEXT

typedef BOOL (*PISFORMATFUNC)(LPCSTR pszConverter, LPCSTR pszPathName);
inline BOOL IsTextType(int nType) {return ((nType==RD_TEXT) || (nType==RD_OEMTEXT));}

struct DocType
{
public:
	int nID;
	int idStr;
	BOOL bRead;
	BOOL bWrite;
	BOOL bDup;
	LPCSTR pszConverterName;
	CString GetString(int nID);
};

#define DOCTYPE_DOCTYPE 0
#define DOCTYPE_DESC 1
#define DOCTYPE_EXT 2
#define DOCTYPE_PROGID 3

#define DECLARE_DOCTYPE(name, b1, b2, b3, p) \
{RD_##name, IDS_##name##_DOC, b1, b2, b3, p}
#define DECLARE_DOCTYPE_SYN(actname, name, b1, b2, b3, p) \
{RD_##actname, IDS_##name##_DOC, b1, b2, b3, p}
#define DECLARE_DOCTYPE_NULL(name, b1, b2, b3, p) \
{RD_##name, NULL, b1, b2, b3, p}

extern DocType doctypes[NUM_DOC_TYPES];
extern int GetDocTypeFromName(LPCTSTR pszPathName, CFileException& fe);
extern void ScanForConverters();
extern BOOL IsDLLInPath(LPCSTR lpszName);
int GetIndexFromType(int nType, BOOL bOpen);
int GetTypeFromIndex(int nType, BOOL bOpen);
CString GetExtFromType(int nDocType);
CString GetFileTypes(BOOL bOpen);
