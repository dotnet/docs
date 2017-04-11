// This is a part of the Microsoft Foundation Classes C++ library.
// Copyright (c) Microsoft Corporation.  All rights reserved.
//
// This source code is only intended as a supplement to the
// Microsoft Foundation Classes Reference and related
// electronic documentation provided with the library.
// See these sources for detailed information regarding the
// Microsoft Foundation Classes product.

#pragma once

class CFindComboButton : public CMFCToolBarComboBoxButton
{
	DECLARE_SERIAL(CFindComboButton)

// Construction
public:
	CFindComboButton() : CMFCToolBarComboBoxButton(ID_EDIT_FIND_COMBO, GetCmdMgr()->GetCmdImage(ID_EDIT_FIND), CBS_DROPDOWN)
	{
	}

// Attributes:
public:
	static BOOL HasFocus()
	{
		return m_bHasFocus;
	}

protected:
	static BOOL m_bHasFocus;

// Overrides
protected:
	virtual BOOL NotifyCommand(int iNotifyCode);
};

