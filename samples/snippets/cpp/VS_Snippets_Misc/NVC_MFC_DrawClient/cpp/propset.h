// This is a part of the Microsoft Foundation Classes C++ library.
// Copyright (c) Microsoft Corporation.  All rights reserved.
//
// This source code is only intended as a supplement to the
// Microsoft Foundation Classes Reference and related
// electronic documentation provided with the library.
// See these sources for detailed information regarding the
// Microsoft Foundation Classes product.

typedef struct tagSECTIONHEADER
{
	DWORD       cbSection ;
	DWORD       cProperties ;  // Number of props.
} SECTIONHEADER, *LPSECTIONHEADER ;

typedef struct tagPROPERTYIDOFFSET
{
	DWORD       propertyID;
	DWORD       dwOffset;
} PROPERTYIDOFFSET, *LPPROPERTYIDOFFSET;

typedef struct tagPROPHEADER
{
	WORD        wByteOrder ;    // Always 0xFFFE
	WORD        wFormat ;       // Always 0
	DWORD       dwOSVer ;       // System version
	CLSID       clsID ;         // Application CLSID
	DWORD       cSections ;     // Number of sections(must be at least 1)
} PROPHEADER, *LPPROPHEADER ;

typedef struct tagFORMATIDOFFSET
{
	GUID        formatID;
	DWORD       dwOffset;
} FORMATIDOFFSET, *LPFORMATIDOFFSET;

/////////////////////////////////////////////////////////////////////////////
// CProperty

class CProperty : public CObject
{
	friend class CPropertySet ;
	friend class CPropertySection ;

public:
// Construction
	CProperty( void ) ;
	CProperty( DWORD dwID, const LPVOID pValue, DWORD dwType ) ;

// Attributes
	BOOL    Set( DWORD dwID, const LPVOID pValue, DWORD dwType ) ;
	BOOL    Set( const LPVOID pValue, DWORD dwType ) ;
	BOOL    Set( const LPVOID pValue ) ;
	LPVOID  Get( DWORD* pcb ) ;     // Returns pointer to actual value
	LPVOID  Get( void ) ;           // Returns pointer to actual value
	DWORD   GetType( void ) ;       // Returns property type
	void    SetType( DWORD dwType ) ;
	DWORD   GetID( void ) ;
	void    SetID( DWORD dwPropID ) ;

	LPVOID  GetRawValue( void ) ;   // Returns pointer internal value(may
	// include size information)

// Operations
	BOOL    WriteToStream( IStream* pIStream ) ;
	BOOL    ReadFromStream( IStream* pIStream ) ;

private:
	DWORD       m_dwPropID ;
	DWORD       m_dwType ;
	LPVOID      m_pValue ;

	LPVOID  AllocValue(ULONG cb);
	void    FreeValue();

public:
	~CProperty() ;
} ;

/////////////////////////////////////////////////////////////////////////////
// CPropertySection

class CPropertySection : public CObject
{
	friend class CPropertySet ;
	friend class CProperty ;

public:
// Construction
	CPropertySection( void ) ;
	CPropertySection( CLSID FormatID ) ;

// Attributes
	CLSID   GetFormatID( void ) ;
	void    SetFormatID( CLSID FormatID ) ;

	BOOL    Set( DWORD dwPropID, LPVOID pValue, DWORD dwType ) ;
	BOOL    Set( DWORD dwPropID, LPVOID pValue ) ;
	LPVOID  Get( DWORD dwPropID, DWORD* pcb ) ;
	LPVOID  Get( DWORD dwPropID ) ;
	void    Remove( DWORD dwPropID ) ;
	void    RemoveAll() ;

	CProperty* GetProperty( DWORD dwPropID ) ;
	void AddProperty( CProperty* pProp ) ;

	DWORD   GetSize( void ) ;
	DWORD   GetCount( void ) ;
	CObList* GetList( void ) ;

	BOOL    GetID( LPCTSTR pszName, DWORD* pdwPropID ) ;
	BOOL    SetName( DWORD dwPropID, LPCTSTR pszName ) ;

	BOOL    SetSectionName( LPCTSTR pszName );
	LPCTSTR GetSectionName( void );

// Operations
	BOOL    WriteToStream( IStream* pIStream ) ;
	BOOL    ReadFromStream( IStream* pIStream, LARGE_INTEGER liPropSet ) ;
	BOOL    WriteNameDictToStream( IStream* pIStream ) ;
	BOOL    ReadNameDictFromStream( IStream* pIStream ) ;

private:
// Implementation
	CLSID           m_FormatID ;
	SECTIONHEADER   m_SH ;
	// List of properties(CProperty)
	CObList         m_PropList ;
	// Dictionary of property names
	CMapStringToPtr m_NameDict ;
	CString         m_strSectionName;

public:
	~CPropertySection();
} ;

/////////////////////////////////////////////////////////////////////////////
// CPropertySet

class CPropertySet : public CObject
{
	friend class CPropertySection ;
	friend class CProperty ;

public:
// Construction
	CPropertySet( void ) ;
	CPropertySet( CLSID clsID )  ;

// Attributes
	BOOL    Set( CLSID FormatID, DWORD dwPropID, LPVOID pValue, DWORD dwType ) ;
	BOOL    Set( CLSID FormatID, DWORD dwPropID, LPVOID pValue ) ;
	LPVOID  Get( CLSID FormatID, DWORD dwPropID, DWORD* pcb ) ;
	LPVOID  Get( CLSID FormatID, DWORD dwPropID ) ;
	void    Remove( CLSID FormatID, DWORD dwPropID ) ;
	void    Remove( CLSID FormatID ) ;
	void    RemoveAll( ) ;

	CProperty* GetProperty( CLSID FormatID, DWORD dwPropID ) ;
	void AddProperty( CLSID FormatID, CProperty* pProp ) ;
	CPropertySection* GetSection( CLSID FormatID ) ;
	CPropertySection* AddSection( CLSID FormatID ) ;
	void AddSection( CPropertySection* psect ) ;

	WORD    GetByteOrder( void ) ;
	WORD    GetFormatVersion( void ) ;
	void    SetFormatVersion( WORD wFmtVersion ) ;
	DWORD   GetOSVersion( void ) ;
	void    SetOSVersion( DWORD dwOSVer ) ;
	CLSID   GetClassID( void ) ;
	void    SetClassID( CLSID clsid ) ;
	DWORD   GetCount( void ) ;
	CObList* GetList( void ) ;

// Operations
	BOOL    WriteToStream( IStream* pIStream ) ;
	BOOL    ReadFromStream( IStream* pIStream ) ;

// Implementation
private:
	PROPHEADER      m_PH ;
	CObList         m_SectionList ;

public:
	~CPropertySet();
} ;
