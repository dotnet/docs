
// MiscDoc.h : interface of the CMiscDoc class
//


#pragma once


class CMiscDoc : public CDocument
{
protected: // create from serialization only
	CMiscDoc();
	DECLARE_DYNCREATE(CMiscDoc)

// Attributes
public:

// Operations
public:

// Overrides
public:
	virtual BOOL OnNewDocument();
	virtual void Serialize(CArchive& ar);

// Implementation
public:
	virtual ~CMiscDoc();
#ifdef _DEBUG
	virtual void AssertValid() const;
	virtual void Dump(CDumpContext& dc) const;
#endif

protected:

// Generated message map functions
protected:
	DECLARE_MESSAGE_MAP()
};


