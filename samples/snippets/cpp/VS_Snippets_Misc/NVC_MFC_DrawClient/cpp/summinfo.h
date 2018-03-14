// This is a part of the Microsoft Foundation Classes C++ library.
// Copyright (c) Microsoft Corporation.  All rights reserved.
//
// This source code is only intended as a supplement to the
// Microsoft Foundation Classes Reference and related
// electronic documentation provided with the library.
// See these sources for detailed information regarding the
// Microsoft Foundation Classes product.

#include "propset.h"
#include <objidl.h>

extern const OLECHAR szSummInfo[];

DEFINE_GUID( FMTID_SummaryInformation, 0xF29F85E0, 0x4FF9, 0x1068, 0xAB, 0x91, 0x08, 0x00, 0x2B, 0x27, 0xB3, 0xD9 );

class CSummInfo
{
public:
	CSummInfo();
	BOOL SetTitle(LPCTSTR szTitle);
	CString GetTitle();
	BOOL SetSubject(LPCTSTR szSubject);
	CString GetSubject();
	BOOL SetAuthor(LPCTSTR szAuthor);
	CString GetAuthor();
	BOOL SetKeywords(LPCTSTR szKeywords);
	CString GetKeywords();
	BOOL SetComments(LPCTSTR szComments);
	CString GetComments();
	BOOL SetTemplate(LPCTSTR szTemplate);
	CString GetTemplate();
	BOOL SetLastAuthor(LPCTSTR szLastAuthor);
	CString GetLastAuthor();
	BOOL IncrRevNum();
	CString GetRevNum();
	void StartEditTimeCount();
	BOOL AddCountToEditTime();
	CString GetEditTime();
	BOOL RecordPrintDate();
	CString GetLastPrintDate();
	BOOL RecordCreateDate();
	CString GetCreateDate();
	BOOL RecordSaveDate();
	CString GetLastSaveDate();
	BOOL SetNumPages(ULONG nPages);
	CString GetNumPages();
	BOOL SetNumWords(ULONG nWords);
	CString GetNumWords();
	BOOL SetNumChars(ULONG nChars);
	CString GetNumChars();
	BOOL SetAppname(LPCTSTR szAppname);
	CString GetAppname();
	BOOL SetSecurity(ULONG nLevel);
	CString GetSecurity();
	BOOL WriteToStorage(LPSTORAGE lpRootStg);
	BOOL ReadFromStorage(LPSTORAGE lpRootStg);

protected:
	CPropertySet m_propSet;
	CPropertySection* m_pSection;
	__int64 startEdit;
};
