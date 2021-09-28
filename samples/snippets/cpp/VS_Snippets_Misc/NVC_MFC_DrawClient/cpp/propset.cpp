// This is a part of the Microsoft Foundation Classes C++ library.
// Copyright (c) Microsoft Corporation.  All rights reserved.
//
// This source code is only intended as a supplement to the
// Microsoft Foundation Classes Reference and related
// electronic documentation provided with the library.
// See these sources for detailed information regarding the
// Microsoft Foundation Classes product.

#include "stdafx.h"

#include <malloc.h>
#include <ole2.h>
#include <oleauto.h>
#include "propset.h"

#pragma warning( disable : 4311 4312 )

#ifdef AFXCTL_PROP_SEG
#pragma code_seg(AFXCTL_PROP_SEG)
#endif

#ifdef _DEBUG
#undef THIS_FILE
static char THIS_FILE[] = __FILE__;
#endif

#define new DEBUG_NEW

static LPVOID CountPrefixedStringA(LPCSTR lpsz)
{
	DWORD cb = (lstrlenA( lpsz ) + 1);
	LPDWORD lp = (LPDWORD)malloc((int)cb + sizeof(DWORD) );
	if (lp)
	{
		*lp = cb;
		strcpy_s((LPSTR)(lp+1), (int)cb, lpsz );
	}

	return(LPVOID)lp;
}

static LPVOID CountPrefixedStringW(LPCWSTR lpsz)
{
	DWORD cb = (DWORD)(wcslen( lpsz ) + 1);
	LPDWORD lp = (LPDWORD)malloc((int)cb * sizeof(WCHAR) + sizeof(DWORD) );
	if (lp)
	{
		*lp = cb;
		wcscpy_s((LPWSTR)(lp+1), (int)cb, lpsz );
	}

	return(LPVOID)lp;
}

#ifdef _UNICODE
#define CountPrefixedStringT CountPrefixedStringW
#else
#define CountPrefixedStringT CountPrefixedStringA
#endif

#ifdef _UNICODE

#define MAX_STRLEN 1024

static LPBYTE ConvertStringProp(LPBYTE pbProp, DWORD dwType, ULONG nReps, size_t cbCharSize)
{
	LPBYTE pbResult = NULL; // Return value
	ULONG cbResult = 0;     // Number of bytes in pbResult
	LPBYTE pbBuffer;        // Temporary holding space
	ULONG cchOrig;          // Number of characters in original string
	ULONG cchCopy;          // Number of characters to copy
	ULONG cbCopy;           // Number of bytes to copy
	LPBYTE pbResultNew;     // Used for realloc of pbResult

	pbBuffer = (LPBYTE)malloc(MAX_STRLEN * cbCharSize);
	if (pbBuffer == NULL)
		return NULL;

	// If it's a vector, the count goes first.
	if (dwType & VT_VECTOR)
	{
		pbResult = (LPBYTE)malloc(sizeof(DWORD));
		if (pbResult == NULL)
		{
			free(pbBuffer);
			return NULL;
		}
		*(LPDWORD)pbResult = nReps;
		cbResult = sizeof(DWORD);
	}

	while (nReps--)
	{
		cchOrig = *(LPDWORD)pbProp;
		pbProp += sizeof(DWORD);

		// Convert multibyte string to Unicode.
		if (cbCharSize == sizeof(WCHAR))
		{
			cchCopy = MultiByteToWideChar(CP_ACP, 0, (LPSTR)pbProp, -1,
				(LPWSTR)pbBuffer, min(cchOrig, MAX_STRLEN));
		}
		else
		{
			cchCopy = WideCharToMultiByte(CP_ACP, 0, (LPWSTR)pbProp, -1,
				(LPSTR)pbBuffer, min(cchOrig, MAX_STRLEN), NULL, NULL);
		}

		// Allocate space to append string.
		cbCopy = cchCopy *(ULONG)cbCharSize;
		pbResultNew = (LPBYTE)realloc(pbResult, cbResult + sizeof(DWORD) + cbCopy);

		// If allocation failed, cleanup and return NULL;
		if (pbResultNew == NULL)
		{
			free(pbResult);
			free(pbBuffer);
			return NULL;
		}

		pbResult = pbResultNew;

		// Copy character count and converted string into place, // then update the total size.
		memcpy(pbResult + cbResult, (LPBYTE)&cchCopy, sizeof(DWORD));
		memcpy(pbResult + cbResult + sizeof(DWORD), pbBuffer, cbCopy);
		cbResult += sizeof(DWORD) + cbCopy;

		// Advance to the next vector element
		pbProp += (cchOrig * cbCharSize);
	}

	free(pbBuffer);
	return pbResult;
}

#endif // _UNICODE

/////////////////////////////////////////////////////////////////////////////
//Implementation of the CProperty class

CProperty::CProperty( void )
{
	m_dwPropID = 0;

	m_dwType = VT_EMPTY;
	m_pValue = NULL;       // must init to NULL
}

CProperty::CProperty( DWORD dwID, const LPVOID pValue, DWORD dwType )
{
	m_dwPropID = dwID;
	m_dwType = dwType;
	m_pValue = NULL;       // must init to NULL
	Set( dwID, pValue, dwType );
}

CProperty::~CProperty()
{
	FreeValue();
}

BOOL CProperty::Set( DWORD dwID, const LPVOID pValue, DWORD dwType )
{
	m_dwType = dwType;
	m_dwPropID = dwID;

	return Set( pValue );
}

BOOL CProperty::Set( const LPVOID pValue, DWORD dwType )
{
	m_dwType = dwType;
	return Set( pValue );
}

BOOL CProperty::Set( const  LPVOID pVal )
{
	ULONG           cb;
	ULONG           cbItem;
	ULONG           cbValue;
	ULONG           nReps;
	LPBYTE          pCur;
	LPVOID          pValue = pVal;
	DWORD           dwType = m_dwType;
	LPVOID          pValueOrig = NULL;

	if (m_pValue != NULL)
	{
		FreeValue();
	}

	if (pValue == NULL || m_dwType == 0)
		return TRUE;

	// Given pValue, determine how big it is
	// Then allocate a new buffer for m_pValue and copy...
	nReps = 1;
	cbValue = 0;
	pCur = (LPBYTE)pValue;
	if (m_dwType & VT_VECTOR)
	{
		// The next DWORD is a count of the elements
		nReps = *(LPDWORD)pValue;
		cb = sizeof( nReps );
		pCur += cb;
		cbValue += cb;
		dwType &= ~VT_VECTOR;
	}
	else
	{
		// If we get any of the string-like types, // and we are not a vector create a count-prefixed
		// buffer.
		switch (dwType )
		{
		case VT_LPSTR:          // null terminated string
			pValueOrig = pValue;
			pValue = CountPrefixedStringA((LPSTR)pValueOrig );
			pCur = (LPBYTE)pValue;
			break;

		case VT_BSTR:           // binary string
		case VT_STREAM:         // Name of the stream follows
		case VT_STORAGE:        // Name of the storage follows
		case VT_STREAMED_OBJECT:// Stream contains an object
		case VT_STORED_OBJECT:  // Storage contains an object
			pValueOrig = pValue;
			pValue = CountPrefixedStringT((LPTSTR)pValueOrig );
			pCur = (LPBYTE)pValue;
			break;

		case VT_LPWSTR:         // UNICODE string
			pValueOrig = pValue;
			pValue = CountPrefixedStringW((LPWSTR)pValueOrig );
			pCur = (LPBYTE)pValue;
			break;
		}
	}

	// Since a value can be made up of a vector(VT_VECTOR) of
	// items, we first seek through the value, picking out
	// each item, getting it's size.
	//
	cbItem = 0;        // Size of the current item
	while (nReps--)
	{
		switch (dwType)
		{
		case VT_EMPTY:          // nothing
			cbItem = 0;
			break;

		case VT_I2:             // 2 byte signed int
		case VT_BOOL:           // True=-1, False=0
			cbItem = 2;
			break;

		case VT_I4:             // 4 byte signed int
		case VT_R4:             // 4 byte real
			cbItem = 4;
			break;

		case VT_R8:             // 8 byte real
		case VT_CY:             // currency
		case VT_DATE:           // date
		case VT_I8:             // signed 64-bit int
		case VT_FILETIME:       // FILETIME
			cbItem = 8;
			break;

		case VT_CLSID:          // A Class ID
			cbItem = sizeof(CLSID);
			break;

#ifndef _UNICODE
		case VT_BSTR:           // binary string
		case VT_STREAM:         // Name of the stream follows
		case VT_STORAGE:        // Name of the storage follows
		case VT_STREAMED_OBJECT:// Stream contains an object
		case VT_STORED_OBJECT:  // Storage contains an object
		case VT_STREAMED_PROPSET:// Stream contains a propset
		case VT_STORED_PROPSET: // Storage contains a propset
#endif // _UNICODE
		case VT_LPSTR:          // null terminated string
		case VT_BLOB_OBJECT:    // Blob contains an object
		case VT_BLOB_PROPSET:   // Blob contains a propset
		case VT_BLOB:           // Length prefixed bytes
		case VT_CF:             // Clipboard format
			// Get the DWORD that gives us the size, making
			// sure we increment cbValue.
			cbItem = *(LPDWORD)pCur;
			cb = sizeof(cbItem);
			pCur += cb;
			cbValue += cb;
			break;

#ifdef _UNICODE
		case VT_BSTR:           // binary string
		case VT_STREAM:         // Name of the stream follows
		case VT_STORAGE:        // Name of the storage follows
		case VT_STREAMED_OBJECT:// Stream contains an object
		case VT_STORED_OBJECT:  // Storage contains an object
		case VT_STREAMED_PROPSET:// Stream contains a propset
		case VT_STORED_PROPSET: // Storage contains a propset
#endif // _UNICODE
		case VT_LPWSTR:         // UNICODE string
			cbItem = *(LPDWORD)pCur * sizeof(WCHAR);
			cb = sizeof( cbItem );
			pCur += cb;
			cbValue += cb;
			break;
		case VT_VARIANT:        // VARIANT*
			break;

		default:
			if (pValueOrig)
				free( pValue );
			return FALSE;
		}

		// Add 'cb' to cbItem before seeking...
		//
		// Seek to the next item
		pCur += cbItem;
		cbValue += cbItem;
	}

	if (NULL == AllocValue(cbValue))
	{
		TRACE0("CProperty::AllocValue failed");
		return FALSE;
	}
	memcpy_s( m_pValue, (int)cbValue, pValue, (int)cbValue );

	if (pValueOrig)
		free( pValue );

	return TRUE;
}

LPVOID CProperty::Get( void )
{   return Get((DWORD*)NULL );   }

LPVOID CProperty::Get( DWORD* pcb )
{
	DWORD   cb = 0;
	LPBYTE  p = NULL;

	p = (LPBYTE)m_pValue;

	// m_pValue points to a Property "Value" which may
	// have size information included...
	switch ( m_dwType )
	{
	case VT_EMPTY:          // nothing
		cb = 0;
		break;

	case VT_I2:             // 2 byte signed int
	case VT_BOOL:           // True=-1, False=0
		cb = 2;
		break;

	case VT_I4:             // 4 byte signed int
	case VT_R4:             // 4 byte real
		cb = 4;
		break;

	case VT_R8:             // 8 byte real
	case VT_CY:             // currency
	case VT_DATE:           // date
	case VT_I8:             // signed 64-bit int
	case VT_FILETIME:       // FILETIME
		cb = 8;
		break;

#ifndef _UNICODE
	case VT_BSTR:           // binary string
	case VT_STREAM:         // Name of the stream follows
	case VT_STORAGE:        // Name of the storage follows
	case VT_STREAMED_OBJECT:// Stream contains an object
	case VT_STORED_OBJECT:  // Storage contains an object
	case VT_STREAMED_PROPSET:// Stream contains a propset
	case VT_STORED_PROPSET: // Storage contains a propset
#endif // UNICODE
	case VT_LPSTR:          // null terminated string
	case VT_CF:             // Clipboard format
		// Read the DWORD that gives us the size, making
		// sure we increment cbValue.
		cb = *(LPDWORD)p;
		p += sizeof( DWORD );
		break;

	case VT_BLOB:           // Length prefixed bytes
	case VT_BLOB_OBJECT:    // Blob contains an object
	case VT_BLOB_PROPSET:   // Blob contains a propset
		// Read the DWORD that gives us the size.
		cb = *(LPDWORD)p;
		break;

#ifdef _UNICODE
	case VT_BSTR:           // binary string
	case VT_STREAM:         // Name of the stream follows
	case VT_STORAGE:        // Name of the storage follows
	case VT_STREAMED_OBJECT:// Stream contains an object
	case VT_STORED_OBJECT:  // Storage contains an object
	case VT_STREAMED_PROPSET:// Stream contains a propset
	case VT_STORED_PROPSET: // Storage contains a propset
#endif // _UNICODE
	case VT_LPWSTR:         // UNICODE string
		cb = *(LPDWORD)p * sizeof(WCHAR);
		p += sizeof( DWORD );
		break;

	case VT_CLSID:          // A Class ID
		cb = sizeof(CLSID);
		break;

	case VT_VARIANT:        // VARIANT*
		break;

	default:
		return NULL;
	}
	if (pcb != NULL)
		*pcb = cb;

	return p;
}

DWORD  CProperty::GetType( void )
{   return m_dwType;  }

void   CProperty::SetType( DWORD dwType )
{   m_dwType = dwType; }

DWORD CProperty::GetID( void )
{   return m_dwPropID;   }

void CProperty::SetID( DWORD dwPropID )
{    m_dwPropID = dwPropID;   }

LPVOID CProperty::GetRawValue( void )
{   return m_pValue; }

BOOL CProperty::WriteToStream( IStream* pIStream )
{
	ULONG           cb = 0;
	ULONG           cbTotal; // Total size of the whole value
	DWORD           dwType = m_dwType;
	DWORD           nReps;
	LPBYTE          pValue;
	LPBYTE          pCur;
	BOOL            bSuccess = FALSE;
	BYTE            b = 0;

	nReps = 1;
	pValue = (LPBYTE)m_pValue;
	pCur = pValue;
	cbTotal = 0;
	if (m_dwType & VT_VECTOR)
	{
		// Value is a DWORD count of elements followed by
		// that many repititions of the value.
		//
		nReps = *(LPDWORD)pCur;
		cbTotal = sizeof(DWORD);
		pCur += cbTotal;
		dwType &= ~VT_VECTOR;
	}

#ifdef _UNICODE
	switch (dwType)
	{
	case VT_BSTR:           // binary string
	case VT_STREAM:         // Name of the stream follows
	case VT_STORAGE:        // Name of the storage follows
	case VT_STREAMED_OBJECT:// Stream contains an object
	case VT_STORED_OBJECT:  // Storage contains an object
	case VT_STREAMED_PROPSET:// Stream contains a propset
	case VT_STORED_PROPSET: // Storage contains a propset
		pValue = ConvertStringProp(pCur, m_dwType, nReps, sizeof(char));
		if (m_dwType & VT_VECTOR)
			pCur = pValue + sizeof(DWORD);
		break;
	}
#endif // _UNICODE

	// Figure out how big the data is.
	while (nReps--)
	{
		switch (dwType)
		{
		case VT_EMPTY:          // nothing
			cb = 0;
			break;

		case VT_I2:             // 2 byte signed int
		case VT_BOOL:           // True=-1, False=0
			cb = 2;
			break;

		case VT_I4:             // 4 byte signed int
		case VT_R4:             // 4 byte real
			cb = 4;
			break;

		case VT_R8:             // 8 byte real
		case VT_CY:             // currency
		case VT_DATE:           // date
		case VT_I8:             // signed 64-bit int
		case VT_FILETIME:       // FILETIME
			cb = 8;
			break;

		case VT_LPSTR:          // null terminated string
		case VT_BSTR:           // binary string
		case VT_STREAM:         // Name of the stream follows
		case VT_STORAGE:        // Name of the storage follows
		case VT_STREAMED_OBJECT:// Stream contains an object
		case VT_STORED_OBJECT:  // Storage contains an object
		case VT_STREAMED_PROPSET:// Stream contains a propset
		case VT_STORED_PROPSET: // Storage contains a propset
		case VT_BLOB:           // Length prefixed bytes
		case VT_BLOB_OBJECT:    // Blob contains an object
		case VT_BLOB_PROPSET:   // Blob contains a propset
		case VT_CF:             // Clipboard format
			cb = sizeof(DWORD) + *(LPDWORD)pCur;
			break;

		case VT_LPWSTR:         // UNICODE string
			cb = sizeof(DWORD) +(*(LPDWORD)pCur * sizeof(WCHAR));
			break;

		case VT_CLSID:          // A Class ID
			cb = sizeof(CLSID);
			break;

		case VT_VARIANT:        // VARIANT*
			break;

		default:
			return FALSE;
		}

		pCur += cb;
		cbTotal+= cb;
	}

	// Write the type
	pIStream->Write((LPVOID)&m_dwType, sizeof(m_dwType), &cb);
	if (cb != sizeof(m_dwType))
		goto Cleanup;

	// Write the value
	pIStream->Write((LPVOID)pValue, cbTotal, &cb);
	if (cb != cbTotal)
		goto Cleanup;

	// Make sure we are 32 bit aligned
	cbTotal = (((cbTotal + 3) >> 2) << 2) - cbTotal;
	while (cbTotal--)
	{
		pIStream->Write((LPVOID)&b, 1, &cb);
		if (cb != sizeof(BYTE))
			goto Cleanup;
	}

	bSuccess = TRUE;

Cleanup:
	if (pValue != m_pValue)
		free(pValue);

	return bSuccess;
}

BOOL CProperty::ReadFromStream( IStream* pIStream )
{
	ULONG           cb;
	ULONG           cbItem;
	ULONG           cbValue;
	DWORD           dwType;
	ULONG           nReps;
	ULONG           iReps;
	LPSTREAM        pIStrItem;
	LARGE_INTEGER   li;

	// All properties are made up of a type/value pair.
	// The obvious first thing to do is to get the type...
	pIStream->Read((LPVOID)&m_dwType, sizeof(m_dwType), &cb );
	if (cb != sizeof(m_dwType))
		return FALSE;

	dwType = m_dwType;
	nReps = 1;
	cbValue = 0;
	if (m_dwType & VT_VECTOR)
	{
		// The next DWORD in the stream is a count of the
		// elements
		pIStream->Read((LPVOID)&nReps, sizeof(nReps), &cb );
		if (cb != sizeof(nReps))
			return FALSE;
		cbValue += cb;
		dwType &= ~VT_VECTOR;
	}

	// Since a value can be made up of a vector(VT_VECTOR) of
	// items, we first seek through the value, picking out
	// each item, getting it's size.  We use a cloned
	// stream for this(pIStrItem).
	// We then use our pIStream to read the entire 'blob' into
	// the allocated buffer.
	//
	cbItem = 0;        // Size of the current item
	pIStream->Clone( &pIStrItem );
	ENSURE(pIStrItem != NULL);
	iReps = nReps;
	while (iReps--)
	{
		switch (dwType)
		{
		case VT_EMPTY:          // nothing
			cbItem = 0;
			break;

		case VT_I2:             // 2 byte signed int
		case VT_BOOL:           // True=-1, False=0
			cbItem = 2;
			break;

		case VT_I4:             // 4 byte signed int
		case VT_R4:             // 4 byte real
			cbItem = 4;
			break;

		case VT_R8:             // 8 byte real
		case VT_CY:             // currency
		case VT_DATE:           // date
		case VT_I8:             // signed 64-bit int
		case VT_FILETIME:       // FILETIME
			cbItem = 8;
			break;

		case VT_LPSTR:          // null terminated string
		case VT_BSTR:           // binary string
		case VT_STREAM:         // Name of the stream follows
		case VT_STORAGE:        // Name of the storage follows
		case VT_STREAMED_OBJECT:// Stream contains an object
		case VT_STORED_OBJECT:  // Storage contains an object
		case VT_STREAMED_PROPSET:// Stream contains a propset
		case VT_STORED_PROPSET: // Storage contains a propset
		case VT_BLOB:           // Length prefixed bytes
		case VT_BLOB_OBJECT:    // Blob contains an object
		case VT_BLOB_PROPSET:   // Blob contains a propset
		case VT_CF:             // Clipboard format
			// Read the DWORD that gives us the size, making
			// sure we increment cbValue.
			pIStream->Read((LPVOID)&cbItem, sizeof(cbItem), &cb );
			if (cb != sizeof(cbItem))
				return FALSE;
			LISet32( li, -(LONG)cb );
			pIStream->Seek( li, STREAM_SEEK_CUR, NULL );
			cbValue += cb;
			break;

		case VT_LPWSTR:         // UNICODE string
			pIStream->Read((LPVOID)&cbItem, sizeof(cbItem), &cb );
			if (cb != sizeof(cbItem))
				return FALSE;
			LISet32( li, -(LONG)cb );
			pIStream->Seek( li, STREAM_SEEK_CUR, NULL );
			cbValue += cb;
			cbItem *= sizeof(WCHAR);
			break;

		case VT_CLSID:          // A Class ID
			cbItem = sizeof(CLSID);
			break;

		case VT_VARIANT:        // VARIANT*
			break;

		default:
			pIStrItem->Release();
			return FALSE;
		}

		// Add 'cb' to cbItem before seeking...
		//
		// Seek to the next item
		LISet32( li, cbItem );
		pIStrItem->Seek( li, STREAM_SEEK_CUR, NULL);
		cbValue += cbItem;
	}

	pIStrItem->Release();

#ifdef _UNICODE
	LPBYTE pTmp;

	switch (dwType)
	{
	case VT_BSTR:           // binary string
	case VT_STREAM:         // Name of the stream follows
	case VT_STORAGE:        // Name of the storage follows
	case VT_STREAMED_OBJECT:// Stream contains an object
	case VT_STORED_OBJECT:  // Storage contains an object
	case VT_STREAMED_PROPSET:// Stream contains a propset
	case VT_STORED_PROPSET: // Storage contains a propset
		pTmp = (LPBYTE)malloc((int)cbValue);
		pIStream->Read( pTmp, cbValue, &cb );
		m_pValue = ConvertStringProp(pTmp, m_dwType, nReps, sizeof(WCHAR));
		free(pTmp);
		break;

	default:
#endif // _UNICODE
		// Allocate cbValue bytes
		if (NULL == AllocValue(cbValue))
			return FALSE;

		// Read the buffer from pIStream
		pIStream->Read( m_pValue, cbValue, &cb );
		if (cb != cbValue)
			return FALSE;
#ifdef _UNICODE
		break;
	}
#endif // _UNICODE

	// Done!
	return TRUE;
}

LPVOID CProperty::AllocValue(ULONG cb)
{
	return m_pValue = malloc((int)cb);
}

void CProperty::FreeValue()
{
	if (m_pValue != NULL)
	{
		free(m_pValue);
		m_pValue = NULL;
	}
}

/////////////////////////////////////////////////////////////////////////////
// Implementation of the CPropertySection Class

CPropertySection::CPropertySection( void )
{
	m_FormatID = GUID_NULL;
	m_SH.cbSection = 0;
	m_SH.cProperties = 0;
}

CPropertySection::CPropertySection( CLSID FormatID )
{
	m_FormatID = FormatID;
	m_SH.cbSection = 0;
	m_SH.cProperties = 0;
}

CPropertySection::~CPropertySection( void )
{
	RemoveAll();
	return;
}

CLSID CPropertySection::GetFormatID( void )
{   return m_FormatID; }

void CPropertySection::SetFormatID( CLSID FormatID )
{   m_FormatID = FormatID; }

BOOL CPropertySection::Set( DWORD dwPropID, LPVOID pValue, DWORD dwType )
{
	CProperty* pProp = GetProperty( dwPropID );
	if (pProp == NULL)
	{
		if ((pProp = new CProperty( dwPropID, pValue, dwType )) != NULL)
			AddProperty( pProp );
		return(pProp != NULL);
	}

	pProp->Set( dwPropID, pValue, dwType );
	return TRUE;
}

BOOL CPropertySection::Set( DWORD dwPropID, LPVOID pValue )
{
	// Since no dwType was specified, the property is assumed
	// to exist.   Fail if it does not.
	CProperty* pProp = GetProperty( dwPropID );
	if (pProp != NULL && pProp->m_dwType)
	{
		pProp->Set( dwPropID, pValue, pProp->m_dwType );
		return TRUE;
	}
	else
		return FALSE;
}

LPVOID CPropertySection::Get( DWORD dwPropID )
{   return Get( dwPropID, (DWORD*)NULL );  }

LPVOID CPropertySection::Get( DWORD dwPropID, DWORD* pcb )
{
	CProperty* pProp = GetProperty(dwPropID);
	if (pProp)
	{
		ASSERT_VALID(pProp);
		return pProp->Get(pcb);
	}
	else
		return NULL;
}

void CPropertySection::Remove( DWORD dwID )
{
	POSITION pos = m_PropList.GetHeadPosition();
	CProperty*  pProp;
	while ( pos != NULL )
	{
		POSITION posRemove = pos;
		pProp = (CProperty*)m_PropList.GetNext( pos );
		if (pProp->m_dwPropID == dwID)
		{
			m_PropList.RemoveAt( posRemove );
			delete pProp;
			m_SH.cProperties--;
			return;
		}
	}
}

void CPropertySection::RemoveAll( )
{
	POSITION pos = m_PropList.GetHeadPosition();
	while ( pos != NULL )
		delete(CProperty*)m_PropList.GetNext( pos );
	m_PropList.RemoveAll();
	m_SH.cProperties = 0;
}

CProperty* CPropertySection::GetProperty( DWORD dwPropID )
{
	POSITION pos = m_PropList.GetHeadPosition();
	ASSERT_VALID(&m_PropList);
	CProperty* pProp;
	while (pos != NULL)
	{
		pProp= (CProperty*)m_PropList.GetNext( pos );
		ASSERT_VALID(pProp);
		if (pProp->m_dwPropID == dwPropID)
			return pProp;
	}
	return NULL;
}

void CPropertySection::AddProperty( CProperty* pProp )
{
	m_PropList.AddTail( pProp );
	m_SH.cProperties++;
}

DWORD CPropertySection::GetSize( void )
{   return m_SH.cbSection; }

DWORD CPropertySection::GetCount( void )
{   return(DWORD)m_PropList.GetCount();  }

CObList* CPropertySection::GetList( void )
{   return &m_PropList;  }

BOOL CPropertySection::WriteToStream( IStream* pIStream )
{
	// Create a dummy property entry for the name dictionary(ID == 0).
	Set(0, NULL, VT_EMPTY);

	ULONG           cb;
	ULARGE_INTEGER  ulSeekOld;
	ULARGE_INTEGER  ulSeek;
	LPSTREAM        pIStrPIDO;
	PROPERTYIDOFFSET  pido;
	LARGE_INTEGER   li;

	// The Section header contains the number of bytes in the
	// section.  Thus we need  to go back to where we should
	// write the count of bytes
	// after we write all the property sets..
	// We accomplish this by saving the seek pointer to where
	// the size should be written in ulSeekOld
	m_SH.cbSection = 0;
	m_SH.cProperties = (DWORD)m_PropList.GetCount();
	LISet32( li, 0 );
	pIStream->Seek( li, STREAM_SEEK_CUR, &ulSeekOld);

	pIStream->Write((LPVOID)&m_SH, sizeof(m_SH), &cb);
	if (sizeof(m_SH) != cb)
	{
		TRACE0("Write of section header failed(1).\n");
		return FALSE;
	}

	if (m_PropList.IsEmpty())
	{
		TRACE0("Warning: Wrote empty property section.\n");
		return TRUE;
	}

	// After the section header is the list of property ID/Offset pairs
	// Since there is an ID/Offset pair for each property and we
	// need to write the ID/Offset pair as we write each property
	// we clone the stream and use the clone to access the
	// table of ID/offset pairs(PIDO)...
	//
	pIStream->Clone( &pIStrPIDO );

	// Now seek pIStream past the PIDO list
	//
	LISet32( li,  m_SH.cProperties * sizeof( PROPERTYIDOFFSET ) );
	pIStream->Seek( li, STREAM_SEEK_CUR, &ulSeek);

	// Now write each section to pIStream.
	CProperty* pProp = NULL;
	POSITION pos = m_PropList.GetHeadPosition();
	while ( pos != NULL )
	{
		// Get next element(note cast)
		pProp = (CProperty*)m_PropList.GetNext( pos );

		if (pProp->m_dwPropID != 0)
		{
			// Write it
			if (!pProp->WriteToStream( pIStream ))
			{
				pIStrPIDO->Release();
				return FALSE;
			}
		}
		else
		{
			if (!WriteNameDictToStream( pIStream ))
			{
				pIStrPIDO->Release();
				return FALSE;
			}
		}

		// Using our cloned stream write the Format ID / Offset pair
		// The offset to this property is the current seek pointer
		// minus the pointer to the beginning of the section
		pido.dwOffset = ulSeek.LowPart - ulSeekOld.LowPart;
		pido.propertyID = pProp->m_dwPropID;
		pIStrPIDO->Write((LPVOID)&pido, sizeof(pido), &cb);
		if (sizeof(pido) != cb)
		{
			TRACE0("Write of 'pido' failed\n");
			pIStrPIDO->Release();
			return FALSE;
		}

		// Get the seek offset after the write
		LISet32( li, 0 );
		pIStream->Seek( li, STREAM_SEEK_CUR, &ulSeek );
	}

	pIStrPIDO->Release();

	// Now go back to ulSeekOld and write the section header.
	// Size of section is current seek point minus old seek point
	//
	m_SH.cbSection = ulSeek.LowPart - ulSeekOld.LowPart;

	// Seek to beginning of this section and write the section header.
	LISet32( li, ulSeekOld.LowPart );
	pIStream->Seek( li, STREAM_SEEK_SET, NULL );
	pIStream->Write((LPVOID)&m_SH, sizeof(m_SH), &cb);
	if (sizeof(m_SH) != cb)
	{
		TRACE0("Write of section header failed(2).\n");
		return FALSE;
	}

	// Now seek to end of the now written section
	LISet32(li, ulSeek.LowPart);
	pIStream->Seek(li, STREAM_SEEK_SET, NULL);

	return TRUE;
}

BOOL CPropertySection::ReadFromStream( IStream* pIStream, LARGE_INTEGER liPropSet )
{
	ULONG               cb;
	PROPERTYIDOFFSET    pido;
	ULONG               cProperties;
	LPSTREAM            pIStrPIDO;
	ULARGE_INTEGER      ulSectionStart;
	LARGE_INTEGER       li;
	CProperty*          pProp;

	if (m_SH.cProperties || !m_PropList.IsEmpty())
		RemoveAll();

	// pIStream is pointing to the beginning of the section we
	// are to read.  First there is a DWORD that is the count
	// of bytes in this section, then there is a count
	// of properties, followed by a list of propertyID/offset pairs, // followed by type/value pairs.
	//
	LISet32( li, 0 );
	pIStream->Seek( li, STREAM_SEEK_CUR, &ulSectionStart );
	pIStream->Read((LPVOID)&m_SH, sizeof(m_SH), &cb );
	if (cb != sizeof(m_SH))
		return FALSE;

	// Now we're pointing at the first of the PropID/Offset pairs
	//(PIDOs).   To get to each property we use a cloned stream
	// to stay back and point at the PIDOs(pIStrPIDO).  We seek
	// pIStream to each of the Type/Value pairs, creating CProperites
	// and so forth as we go...
	//
	pIStream->Clone( &pIStrPIDO );

	cProperties = m_SH.cProperties;
	while (cProperties--)
	{
		pIStrPIDO->Read((LPVOID)&pido, sizeof( pido ), &cb );
		if (cb != sizeof(pido))
		{
			pIStrPIDO->Release();
			return FALSE;
		}

		// Do a seek from the beginning of the property set.
		LISet32( li, ulSectionStart.LowPart + pido.dwOffset );
		pIStream->Seek( liPropSet, STREAM_SEEK_SET, NULL );
		pIStream->Seek( li, STREAM_SEEK_CUR, NULL );

		// Now pIStream is at the type/value pair
		if (pido.propertyID != 0)
		{
			pProp = new CProperty( pido.propertyID, NULL, 0 );
			pProp->ReadFromStream( pIStream );
			ASSERT_VALID(pProp);
			m_PropList.AddTail( pProp );
			ASSERT_VALID(&m_PropList);
		}
		else
		{
			ReadNameDictFromStream( pIStream );
		}
	}

	pIStrPIDO->Release();

	return TRUE;
}

BOOL CPropertySection::GetID( LPCTSTR pszName, DWORD* pdwPropID )
{
	CString strName(pszName);
	strName.MakeLower();        // Dictionary stores all names in lowercase

	void* pvID;
	if (m_NameDict.Lookup(strName, pvID))
	{
		*pdwPropID = (DWORD)pvID;
		return TRUE;
	}

	// Failed to find entry in dictionary
	return FALSE;
}

BOOL CPropertySection::SetName( DWORD dwPropID, LPCTSTR pszName )
{
	BOOL bSuccess = TRUE;
	CString strName(pszName);
	strName.MakeLower();        // Dictionary stores all names in lowercase

	TRY
	{
		void* pDummy;
		BOOL bNameExists = m_NameDict.Lookup(strName, pDummy);

		ASSERT(! bNameExists);  // Property names must be unique.

		if (bNameExists)
			bSuccess = FALSE;
		else
			m_NameDict.SetAt(strName, (void*)dwPropID);
	}
	CATCH(CException, e)
	{
		TRACE0("Failed to add entry to dictionary.\n");
		bSuccess = FALSE;
	}
	END_CATCH

		return bSuccess;
}

struct DICTENTRYHEADER
{
	DWORD dwPropID;
	DWORD cb;
};

struct DICTENTRY
{
	DICTENTRYHEADER hdr;
	char sz[256];
};

BOOL CPropertySection::ReadNameDictFromStream( IStream* pIStream )
{
	ULONG cb;
	ULONG cbRead = 0;

	// Read dictionary header(count).
	ULONG cProperties = 0;
	pIStream->Read((LPVOID)&cProperties, sizeof(cProperties), &cb);
	if (sizeof(cProperties) != cb)
	{
		TRACE0("Read of dictionary header failed.\n");
		return FALSE;
	}

	ULONG iProp;
	DICTENTRY entry;

	for (iProp = 0; iProp < cProperties; iProp++)
	{
		// Read entry header(dwPropID, cch).
		if (FAILED(pIStream->Read((LPVOID)&entry, sizeof(DICTENTRYHEADER), &cbRead)) ||
			(sizeof(DICTENTRYHEADER) != cbRead))
		{
			TRACE0("Read of dictionary entry failed.\n");
			return FALSE;
		}

		// Read entry data(name).

		cb = entry.hdr.cb;

		if (FAILED(pIStream->Read((LPVOID)entry.sz, cb, &cbRead)) ||
			(cbRead != cb))
		{
			TRACE0("Read of dictionary entry failed.\n");
			return FALSE;
		}

		LPTSTR pszName;

#ifdef _UNICODE
		// Persistent form is always ANSI/DBCS.  Convert to Unicode.
		WCHAR wszName[256];
		MultiByteToWideChar(CP_ACP, 0, entry.sz, -1, wszName, 256);
		pszName = wszName;
#else // _UNICODE
		pszName = entry.sz;
#endif // _UNICODE

		// Section's "name" appears first in list and has dwPropID == 0.
		if ((iProp == 0) &&(entry.hdr.dwPropID == 0))
			m_strSectionName = pszName;             // Section name
		else
			SetName(entry.hdr.dwPropID, pszName);   // Some other property
	}

	return TRUE;
}

static BOOL WriteNameDictEntry(IStream* pIStream, DWORD dwPropID, CString& strName)
{
	ULONG cb;
	ULONG cbWritten = 0;
	DICTENTRY entry;

	entry.hdr.dwPropID = dwPropID;
	entry.hdr.cb = min(strName.GetLength() + 1, 255);
#ifdef _UNICODE
	// Persistent form is always ANSI/DBCS.  Convert from Unicode.
	WideCharToMultiByte(CP_ACP, 0, strName, -1, entry.sz, 256, NULL, NULL);
#else // _UNICODE
	memcpy_s(entry.sz, 256, (LPCSTR)strName, (size_t)entry.hdr.cb);
#endif // _UNICODE

	cb = sizeof(DICTENTRYHEADER) + entry.hdr.cb;

	if (FAILED(pIStream->Write((LPVOID)&entry, cb, &cbWritten)) ||
		(cbWritten != cb))
	{
		TRACE0("Write of dictionary entry failed.\n");
		return FALSE;
	}

	return TRUE;
}

BOOL CPropertySection::WriteNameDictToStream( IStream* pIStream )
{
	ULONG cb;

	// Write dictionary header(count).
	ULONG cProperties = (ULONG)(m_NameDict.GetCount() + 1);
	pIStream->Write((LPVOID)&cProperties, sizeof(cProperties), &cb);
	if (sizeof(cProperties) != cb)
	{
		TRACE0("Write of dictionary header failed.\n");
		return FALSE;
	}

	POSITION pos;
	CString strName;
	void* pvID;

	// Write out section's "name" with dwPropID == 0 first
	if (! WriteNameDictEntry(pIStream, 0, m_strSectionName))
		return FALSE;

	// Enumerate contents of dictionary and write out(dwPropID, cb, name).
	pos = m_NameDict.GetStartPosition();
	while (pos != NULL)
	{
		m_NameDict.GetNextAssoc( pos, strName, pvID );
		if (! WriteNameDictEntry(pIStream, (DWORD)pvID, strName))
			return FALSE;
	}

	return TRUE;
}

BOOL CPropertySection::SetSectionName( LPCTSTR pszName )
{
	m_strSectionName = pszName;
	return TRUE;
}

LPCTSTR CPropertySection::GetSectionName( void )
{
	return(LPCTSTR)m_strSectionName;
}

/////////////////////////////////////////////////////////////////////////////
// Implementation of the CPropertySet class

CPropertySet::CPropertySet( void )
{
	m_PH.wByteOrder = 0xFFFE;
	m_PH.wFormat = 0;
	m_PH.dwOSVer = (DWORD)MAKELONG( LOWORD(GetVersion()), 2 );
	m_PH.clsID =  GUID_NULL;
	m_PH.cSections = 0;

}

CPropertySet::CPropertySet( CLSID clsID )
{
	m_PH.wByteOrder = 0xFFFE;
	m_PH.wFormat = 0;
	m_PH.dwOSVer = (DWORD)MAKELONG( LOWORD(GetVersion()), 2 );
	m_PH.clsID = clsID;
	m_PH.cSections = 0;
}

CPropertySet::~CPropertySet()
{   RemoveAll();  }

BOOL CPropertySet::Set( CLSID FormatID, DWORD dwPropID, LPVOID pValue, DWORD dwType )
{
	CPropertySection* pSect = GetSection( FormatID );
	if (pSect == NULL)
	{
		if ((pSect = new CPropertySection( FormatID )) != NULL)
			AddSection( pSect );
	}
	pSect->Set( dwPropID, pValue, dwType );
	return TRUE;
}

BOOL CPropertySet::Set( CLSID FormatID, DWORD dwPropID, LPVOID pValue )
{
	// Since there is no dwType, we have to assume that the property
	// already exists.  If it doesn't, fail.
	CPropertySection* pSect = GetSection( FormatID );
	if (pSect != NULL)
		return pSect->Set( dwPropID, pValue );
	else
		return FALSE;
}

LPVOID CPropertySet::Get( CLSID FormatID, DWORD dwPropID, DWORD* pcb )
{
	CPropertySection* pSect = GetSection( FormatID );
	if (pSect)
		return pSect->Get( dwPropID, pcb );
	else
		return NULL;
}

LPVOID CPropertySet::Get( CLSID FormatID, DWORD dwPropID )
{   return Get( FormatID, dwPropID, (DWORD*)NULL ); }

void CPropertySet::Remove( CLSID FormatID, DWORD dwPropID )
{
	CPropertySection*  pSect = GetSection( FormatID );
	if (pSect)
		pSect->Remove( dwPropID );
}

void CPropertySet::Remove( CLSID FormatID )
{
	CPropertySection* pSect;
	POSITION posRemove = m_SectionList.GetHeadPosition();
	POSITION pos = posRemove;
	while ( posRemove != NULL )
	{
		pSect = (CPropertySection*)m_SectionList.GetNext( pos );
		if (IsEqualCLSID( pSect->m_FormatID, FormatID ))
		{
			m_SectionList.RemoveAt( posRemove );
			delete pSect;
			m_PH.cSections--;
			return;
		}
		posRemove = pos;
	}
}

void CPropertySet::RemoveAll( )
{
	POSITION pos = m_SectionList.GetHeadPosition();
	while ( pos != NULL )
	{
		delete(CPropertySection*)m_SectionList.GetNext( pos );
	}
	m_SectionList.RemoveAll();
	m_PH.cSections = 0;
}

CPropertySection* CPropertySet::GetSection( CLSID FormatID )
{
	POSITION pos = m_SectionList.GetHeadPosition();
	CPropertySection* pSect;
	while (pos != NULL)
	{
		pSect = (CPropertySection*)m_SectionList.GetNext( pos );
		if (IsEqualCLSID( pSect->m_FormatID, FormatID ))
			return pSect;
	}
	return NULL;
}

CPropertySection* CPropertySet::AddSection( CLSID FormatID )
{
	CPropertySection* pSect = GetSection( FormatID );
	if (pSect)
		return pSect;

	pSect = new CPropertySection( FormatID ) ;
	if (pSect)
		AddSection( pSect );
	return pSect;
}

void CPropertySet::AddSection( CPropertySection* pSect )
{
	m_SectionList.AddTail( pSect );
	m_PH.cSections++;
}

CProperty* CPropertySet::GetProperty( CLSID FormatID, DWORD dwPropID )
{
	CPropertySection* pSect = GetSection( FormatID );
	if (pSect)
		return pSect->GetProperty( dwPropID );
	else
		return NULL;
}

void CPropertySet::AddProperty( CLSID FormatID, CProperty* pProp )
{
	CPropertySection* pSect = GetSection( FormatID );
	if (pSect)
		pSect->AddProperty( pProp );
}

WORD CPropertySet::GetByteOrder( void )
{   return m_PH.wByteOrder;  }

WORD CPropertySet::GetFormatVersion( void )
{   return m_PH.wFormat;  }

void CPropertySet::SetFormatVersion( WORD wFmtVersion )
{   m_PH.wFormat = wFmtVersion;  }

DWORD CPropertySet::GetOSVersion( void )
{   return m_PH.dwOSVer;  }

void CPropertySet::SetOSVersion( DWORD dwOSVer )
{   m_PH.dwOSVer = dwOSVer;  }

CLSID CPropertySet::GetClassID( void )
{   return m_PH.clsID;  }

void CPropertySet::SetClassID( CLSID clsID )
{   m_PH.clsID = clsID;  }

DWORD CPropertySet::GetCount( void )
{   return(DWORD)m_SectionList.GetCount();  }

CObList* CPropertySet::GetList( void )
{   return &m_SectionList;  }

BOOL CPropertySet::WriteToStream( IStream* pIStream )
{
	LPSTREAM        pIStrFIDO;
	FORMATIDOFFSET  fido;
	ULONG           cb;
	ULARGE_INTEGER  ulSeek;
	LARGE_INTEGER   li;

	// Write the Property List Header
	m_PH.cSections = (DWORD)m_SectionList.GetCount();
	pIStream->Write((LPVOID)&m_PH, sizeof(m_PH), &cb);
	if (sizeof(m_PH) != cb)
	{
		TRACE0("Write of Property Set Header failed.\n");
		return FALSE;
	}

	if (m_SectionList.IsEmpty())
	{
		TRACE0("Warning: Wrote empty property set.\n");
		return TRUE;
	}

	// After the header is the list of Format ID/Offset pairs
	// Since there is an ID/Offset pair for each section and we
	// need to write the ID/Offset pair as we write each section
	// we clone the stream and use the clone to access the
	// table of ID/offset pairs(FIDO)...
	//
	pIStream->Clone( &pIStrFIDO );

	// Now seek pIStream past the FIDO list
	//
	LISet32( li, m_PH.cSections * sizeof( FORMATIDOFFSET ) );
	pIStream->Seek( li, STREAM_SEEK_CUR, &ulSeek);

	// Write each section.
	CPropertySection*   pSect = NULL;
	POSITION            pos = m_SectionList.GetHeadPosition();
	while ( pos != NULL )
	{
		// Get next element(note cast)
		pSect = (CPropertySection*)m_SectionList.GetNext( pos );

		// Write it
		if (!pSect->WriteToStream( pIStream ))
		{
			pIStrFIDO->Release();
			return FALSE;
		}

		// Using our cloned stream write the Format ID / Offset pair
		fido.formatID = pSect->m_FormatID;
		fido.dwOffset = ulSeek.LowPart;
		pIStrFIDO->Write((LPVOID)&fido, sizeof(fido), &cb);
		if (sizeof(fido) != cb)
		{
			TRACE0("Write of 'fido' failed.\n");
			pIStrFIDO->Release();
			return FALSE;
		}

		// Get the seek offset(for pIStream) after the write
		LISet32( li, 0 );
		pIStream->Seek( li, STREAM_SEEK_CUR, &ulSeek );
	}

	pIStrFIDO->Release();

	return TRUE;
}

BOOL CPropertySet::ReadFromStream( IStream* pIStream )
{
	ULONG               cb;
	FORMATIDOFFSET      fido;
	ULONG               cSections;
	LPSTREAM            pIStrFIDO;
	CPropertySection*   pSect;
	LARGE_INTEGER       li;
	LARGE_INTEGER       liPropSet;

	// Save the stream position at which the property set starts.
	LARGE_INTEGER liZero = {0,0};
	pIStream->Seek( liZero, STREAM_SEEK_CUR, (ULARGE_INTEGER*)&liPropSet );

	if (m_PH.cSections || !m_SectionList.IsEmpty())
		RemoveAll();

	// The stream starts like this:
	//  wByteOrder   wFmtVer   dwOSVer   clsID  cSections
	// Which is nice, because our PROPHEADER is the same!
	pIStream->Read((LPVOID)&m_PH, sizeof( m_PH ), &cb );
	if (cb != sizeof(m_PH))
		return FALSE;

	// Now we're pointing at the first of the FormatID/Offset pairs
	//(FIDOs).   To get to each section we use a cloned stream
	// to stay back and point at the FIDOs(pIStrFIDO).  We seek
	// pIStream to each of the sections, creating CProperitySection
	// and so forth as we go...
	//
	pIStream->Clone( &pIStrFIDO );

	cSections = m_PH.cSections;
	while (cSections--)
	{
		pIStrFIDO->Read((LPVOID)&fido, sizeof( fido ), &cb );
		if (cb != sizeof(fido))
		{
			pIStrFIDO->Release();
			return FALSE;
		}

		// Do a seek from the beginning of the property set.
		LISet32( li, fido.dwOffset );
		pIStream->Seek( liPropSet, STREAM_SEEK_SET, NULL );
		pIStream->Seek( li, STREAM_SEEK_CUR, NULL );

		// Now pIStream is at the type/value pair
		pSect = new CPropertySection;
		pSect->SetFormatID( fido.formatID );
		pSect->ReadFromStream( pIStream, liPropSet );
		m_SectionList.AddTail( pSect );
	}

	pIStrFIDO->Release();
	return TRUE;
}
