[assembly: System.Reflection.AssemblyVersion("1.1.0.0")]
[assembly: System.Windows.Forms.AxHost.TypeLibraryTimeStamp("7/22/2001 12:56:59 PM")]

namespace AxMSMask
{

    [System.Security.Permissions.PermissionSet(System.Security.Permissions.SecurityAction.Demand, Name="FullTrust")]
    [System.Windows.Forms.AxHost.ClsidAttribute("{c932ba85-4374-101b-a56c-00aa003668dc}")]
    [System.ComponentModel.DesignTimeVisibleAttribute(true)]
    [System.ComponentModel.DefaultEvent("Change")]
    [System.ComponentModel.DefaultProperty("defaultText")]
    public class AxMaskEdBox : System.Windows.Forms.AxHost
    {

        private MSMask.IMSMask ocx;

        private AxMaskEdBoxEventMulticaster eventMulticaster;

        private System.Windows.Forms.AxHost.ConnectionPointCookie cookie;

        // <snippet1> 
        public AxMaskEdBox()
            :
          base("c932ba85-4374-101b-a56c-00aa003668dc") // The ActiveX control's class identifier.
        {
            // Make the AboutBox method the about box delegate.
            this.SetAboutBoxDelegate(new AboutBoxDelegate(AboutBox));
        }

        public virtual void AboutBox()
        {
            // If the instance of the ActiveX control is null when the AboutBox method 
            // is called, raise an InvalidActiveXStateException exception.
            if ((this.ocx == null))
            {
                throw new System.Windows.Forms.AxHost.InvalidActiveXStateException(
                  "AboutBox", System.Windows.Forms.AxHost.ActiveXInvokeKind.MethodInvoke);
            }
            // Show the about box if the ActiveX control has one.
            if (this.HasAboutBox)
            {
                this.ocx.AboutBox();
            }
        }

        protected override void AttachInterfaces()
        {
            try
            {
                // Attach the IMSMask interface to the ActiveX control.
                this.ocx = ((MSMask.IMSMask)(this.GetOcx()));
            }
            catch (System.Exception ex)
            {
                System.Console.WriteLine(ex.Message);
            }
        }
        // </snippet1>


        [System.ComponentModel.DesignerSerializationVisibility(System.ComponentModel.DesignerSerializationVisibility.Hidden)]
        [System.Runtime.InteropServices.DispIdAttribute(1)]
        public virtual MSMask.ClipModeConstants ClipMode
        {
            get
            {
                if ((this.ocx == null))
                {
                    throw new System.Windows.Forms.AxHost.InvalidActiveXStateException("ClipMode", System.Windows.Forms.AxHost.ActiveXInvokeKind.PropertyGet);
                }
                return this.ocx.ClipMode;
            }
            set
            {
                if ((this.ocx == null))
                {
                    throw new System.Windows.Forms.AxHost.InvalidActiveXStateException("ClipMode", System.Windows.Forms.AxHost.ActiveXInvokeKind.PropertySet);
                }
                this.ocx.ClipMode = value;
            }
        }

        [System.ComponentModel.DesignerSerializationVisibility(System.ComponentModel.DesignerSerializationVisibility.Hidden)]
        [System.Runtime.InteropServices.DispIdAttribute(2)]
        public virtual bool PromptInclude
        {
            get
            {
                if ((this.ocx == null))
                {
                    throw new System.Windows.Forms.AxHost.InvalidActiveXStateException("PromptInclude", System.Windows.Forms.AxHost.ActiveXInvokeKind.PropertyGet);
                }
                return this.ocx.PromptInclude;
            }
            set
            {
                if ((this.ocx == null))
                {
                    throw new System.Windows.Forms.AxHost.InvalidActiveXStateException("PromptInclude", System.Windows.Forms.AxHost.ActiveXInvokeKind.PropertySet);
                }
                this.ocx.PromptInclude = value;
            }
        }

        [System.ComponentModel.DesignerSerializationVisibility(System.ComponentModel.DesignerSerializationVisibility.Hidden)]
        [System.Runtime.InteropServices.DispIdAttribute(3)]
        public virtual bool AllowPrompt
        {
            get
            {
                if ((this.ocx == null))
                {
                    throw new System.Windows.Forms.AxHost.InvalidActiveXStateException("AllowPrompt", System.Windows.Forms.AxHost.ActiveXInvokeKind.PropertyGet);
                }
                return this.ocx.AllowPrompt;
            }
            set
            {
                if ((this.ocx == null))
                {
                    throw new System.Windows.Forms.AxHost.InvalidActiveXStateException("AllowPrompt", System.Windows.Forms.AxHost.ActiveXInvokeKind.PropertySet);
                }
                this.ocx.AllowPrompt = value;
            }
        }

        [System.ComponentModel.DesignerSerializationVisibility(System.ComponentModel.DesignerSerializationVisibility.Hidden)]
        [System.Runtime.InteropServices.DispIdAttribute(4)]
        public virtual bool AutoTab
        {
            get
            {
                if ((this.ocx == null))
                {
                    throw new System.Windows.Forms.AxHost.InvalidActiveXStateException("AutoTab", System.Windows.Forms.AxHost.ActiveXInvokeKind.PropertyGet);
                }
                return this.ocx.AutoTab;
            }
            set
            {
                if ((this.ocx == null))
                {
                    throw new System.Windows.Forms.AxHost.InvalidActiveXStateException("AutoTab", System.Windows.Forms.AxHost.ActiveXInvokeKind.PropertySet);
                }
                this.ocx.AutoTab = value;
            }
        }

        [System.ComponentModel.DesignerSerializationVisibility(System.ComponentModel.DesignerSerializationVisibility.Hidden)]
        [System.Runtime.InteropServices.DispIdAttribute(5)]
        public virtual MSMask.MousePointerConstants MousePointer
        {
            get
            {
                if ((this.ocx == null))
                {
                    throw new System.Windows.Forms.AxHost.InvalidActiveXStateException("MousePointer", System.Windows.Forms.AxHost.ActiveXInvokeKind.PropertyGet);
                }
                return this.ocx.MousePointer;
            }
            set
            {
                if ((this.ocx == null))
                {
                    throw new System.Windows.Forms.AxHost.InvalidActiveXStateException("MousePointer", System.Windows.Forms.AxHost.ActiveXInvokeKind.PropertySet);
                }
                this.ocx.MousePointer = value;
            }
        }

        [System.ComponentModel.Browsable(false)]
        [System.ComponentModel.DesignerSerializationVisibility(System.ComponentModel.DesignerSerializationVisibility.Hidden)]
        [System.Runtime.InteropServices.DispIdAttribute(6)]
        public virtual bool FontBold
        {
            get
            {
                if ((this.ocx == null))
                {
                    throw new System.Windows.Forms.AxHost.InvalidActiveXStateException("FontBold", System.Windows.Forms.AxHost.ActiveXInvokeKind.PropertyGet);
                }
                return this.ocx.FontBold;
            }
            set
            {
                if ((this.ocx == null))
                {
                    throw new System.Windows.Forms.AxHost.InvalidActiveXStateException("FontBold", System.Windows.Forms.AxHost.ActiveXInvokeKind.PropertySet);
                }
                this.ocx.FontBold = value;
            }
        }

        [System.ComponentModel.Browsable(false)]
        [System.ComponentModel.DesignerSerializationVisibility(System.ComponentModel.DesignerSerializationVisibility.Hidden)]
        [System.Runtime.InteropServices.DispIdAttribute(7)]
        public virtual bool FontItalic
        {
            get
            {
                if ((this.ocx == null))
                {
                    throw new System.Windows.Forms.AxHost.InvalidActiveXStateException("FontItalic", System.Windows.Forms.AxHost.ActiveXInvokeKind.PropertyGet);
                }
                return this.ocx.FontItalic;
            }
            set
            {
                if ((this.ocx == null))
                {
                    throw new System.Windows.Forms.AxHost.InvalidActiveXStateException("FontItalic", System.Windows.Forms.AxHost.ActiveXInvokeKind.PropertySet);
                }
                this.ocx.FontItalic = value;
            }
        }

        [System.ComponentModel.Browsable(false)]
        [System.ComponentModel.DesignerSerializationVisibility(System.ComponentModel.DesignerSerializationVisibility.Hidden)]
        [System.Runtime.InteropServices.DispIdAttribute(8)]
        public virtual string FontName
        {
            get
            {
                if ((this.ocx == null))
                {
                    throw new System.Windows.Forms.AxHost.InvalidActiveXStateException("FontName", System.Windows.Forms.AxHost.ActiveXInvokeKind.PropertyGet);
                }
                return this.ocx.FontName;
            }
            set
            {
                if ((this.ocx == null))
                {
                    throw new System.Windows.Forms.AxHost.InvalidActiveXStateException("FontName", System.Windows.Forms.AxHost.ActiveXInvokeKind.PropertySet);
                }
                this.ocx.FontName = value;
            }
        }

        [System.ComponentModel.Browsable(false)]
        [System.ComponentModel.DesignerSerializationVisibility(System.ComponentModel.DesignerSerializationVisibility.Hidden)]
        [System.Runtime.InteropServices.DispIdAttribute(9)]
        public virtual System.Single FontSize
        {
            get
            {
                if ((this.ocx == null))
                {
                    throw new System.Windows.Forms.AxHost.InvalidActiveXStateException("FontSize", System.Windows.Forms.AxHost.ActiveXInvokeKind.PropertyGet);
                }
                return this.ocx.FontSize;
            }
            set
            {
                if ((this.ocx == null))
                {
                    throw new System.Windows.Forms.AxHost.InvalidActiveXStateException("FontSize", System.Windows.Forms.AxHost.ActiveXInvokeKind.PropertySet);
                }
                this.ocx.FontSize = value;
            }
        }

        [System.ComponentModel.Browsable(false)]
        [System.ComponentModel.DesignerSerializationVisibility(System.ComponentModel.DesignerSerializationVisibility.Hidden)]
        [System.Runtime.InteropServices.DispIdAttribute(10)]
        public virtual bool FontStrikethru
        {
            get
            {
                if ((this.ocx == null))
                {
                    throw new System.Windows.Forms.AxHost.InvalidActiveXStateException("FontStrikethru", System.Windows.Forms.AxHost.ActiveXInvokeKind.PropertyGet);
                }
                return this.ocx.FontStrikethru;
            }
            set
            {
                if ((this.ocx == null))
                {
                    throw new System.Windows.Forms.AxHost.InvalidActiveXStateException("FontStrikethru", System.Windows.Forms.AxHost.ActiveXInvokeKind.PropertySet);
                }
                this.ocx.FontStrikethru = value;
            }
        }

        [System.ComponentModel.Browsable(false)]
        [System.ComponentModel.DesignerSerializationVisibility(System.ComponentModel.DesignerSerializationVisibility.Hidden)]
        [System.Runtime.InteropServices.DispIdAttribute(11)]
        public virtual bool FontUnderline
        {
            get
            {
                if ((this.ocx == null))
                {
                    throw new System.Windows.Forms.AxHost.InvalidActiveXStateException("FontUnderline", System.Windows.Forms.AxHost.ActiveXInvokeKind.PropertyGet);
                }
                return this.ocx.FontUnderline;
            }
            set
            {
                if ((this.ocx == null))
                {
                    throw new System.Windows.Forms.AxHost.InvalidActiveXStateException("FontUnderline", System.Windows.Forms.AxHost.ActiveXInvokeKind.PropertySet);
                }
                this.ocx.FontUnderline = value;
            }
        }

        [System.ComponentModel.Browsable(false)]
        [System.ComponentModel.DesignerSerializationVisibility(System.ComponentModel.DesignerSerializationVisibility.Hidden)]
        [System.Runtime.InteropServices.DispIdAttribute(12)]
        public virtual bool HideSelection
        {
            get
            {
                if ((this.ocx == null))
                {
                    throw new System.Windows.Forms.AxHost.InvalidActiveXStateException("HideSelection", System.Windows.Forms.AxHost.ActiveXInvokeKind.PropertyGet);
                }
                return this.ocx.HideSelection;
            }
            set
            {
                if ((this.ocx == null))
                {
                    throw new System.Windows.Forms.AxHost.InvalidActiveXStateException("HideSelection", System.Windows.Forms.AxHost.ActiveXInvokeKind.PropertySet);
                }
                this.ocx.HideSelection = value;
            }
        }

        [System.ComponentModel.DesignerSerializationVisibility(System.ComponentModel.DesignerSerializationVisibility.Hidden)]
        [System.Runtime.InteropServices.DispIdAttribute(13)]
        public virtual short MaxLength
        {
            get
            {
                if ((this.ocx == null))
                {
                    throw new System.Windows.Forms.AxHost.InvalidActiveXStateException("MaxLength", System.Windows.Forms.AxHost.ActiveXInvokeKind.PropertyGet);
                }
                return this.ocx.MaxLength;
            }
            set
            {
                if ((this.ocx == null))
                {
                    throw new System.Windows.Forms.AxHost.InvalidActiveXStateException("MaxLength", System.Windows.Forms.AxHost.ActiveXInvokeKind.PropertySet);
                }
                this.ocx.MaxLength = value;
            }
        }

        [System.ComponentModel.DesignerSerializationVisibility(System.ComponentModel.DesignerSerializationVisibility.Hidden)]
        [System.Runtime.InteropServices.DispIdAttribute(14)]
        public virtual string Format
        {
            get
            {
                if ((this.ocx == null))
                {
                    throw new System.Windows.Forms.AxHost.InvalidActiveXStateException("Format", System.Windows.Forms.AxHost.ActiveXInvokeKind.PropertyGet);
                }
                return this.ocx.Format;
            }
            set
            {
                if ((this.ocx == null))
                {
                    throw new System.Windows.Forms.AxHost.InvalidActiveXStateException("Format", System.Windows.Forms.AxHost.ActiveXInvokeKind.PropertySet);
                }
                this.ocx.Format = value;
            }
        }

        [System.ComponentModel.DesignerSerializationVisibility(System.ComponentModel.DesignerSerializationVisibility.Hidden)]
        [System.Runtime.InteropServices.DispIdAttribute(16)]
        public virtual string Mask
        {
            get
            {
                if ((this.ocx == null))
                {
                    throw new System.Windows.Forms.AxHost.InvalidActiveXStateException("Mask", System.Windows.Forms.AxHost.ActiveXInvokeKind.PropertyGet);
                }
                return this.ocx.Mask;
            }
            set
            {
                if ((this.ocx == null))
                {
                    throw new System.Windows.Forms.AxHost.InvalidActiveXStateException("Mask", System.Windows.Forms.AxHost.ActiveXInvokeKind.PropertySet);
                }
                this.ocx.Mask = value;
            }
        }

        [System.ComponentModel.Browsable(false)]
        [System.ComponentModel.DesignerSerializationVisibility(System.ComponentModel.DesignerSerializationVisibility.Hidden)]
        [System.Runtime.InteropServices.DispIdAttribute(15)]
        public virtual string FormattedText
        {
            get
            {
                if ((this.ocx == null))
                {
                    throw new System.Windows.Forms.AxHost.InvalidActiveXStateException("FormattedText", System.Windows.Forms.AxHost.ActiveXInvokeKind.PropertyGet);
                }
                return this.ocx.FormattedText;
            }
            set
            {
                if ((this.ocx == null))
                {
                    throw new System.Windows.Forms.AxHost.InvalidActiveXStateException("FormattedText", System.Windows.Forms.AxHost.ActiveXInvokeKind.PropertySet);
                }
                this.ocx.FormattedText = value;
            }
        }

        [System.ComponentModel.Browsable(false)]
        [System.ComponentModel.DesignerSerializationVisibility(System.ComponentModel.DesignerSerializationVisibility.Hidden)]
        [System.Runtime.InteropServices.DispIdAttribute(17)]
        public virtual int SelLength
        {
            get
            {
                if ((this.ocx == null))
                {
                    throw new System.Windows.Forms.AxHost.InvalidActiveXStateException("SelLength", System.Windows.Forms.AxHost.ActiveXInvokeKind.PropertyGet);
                }
                return this.ocx.SelLength;
            }
            set
            {
                if ((this.ocx == null))
                {
                    throw new System.Windows.Forms.AxHost.InvalidActiveXStateException("SelLength", System.Windows.Forms.AxHost.ActiveXInvokeKind.PropertySet);
                }
                this.ocx.SelLength = value;
            }
        }

        [System.ComponentModel.Browsable(false)]
        [System.ComponentModel.DesignerSerializationVisibility(System.ComponentModel.DesignerSerializationVisibility.Hidden)]
        [System.Runtime.InteropServices.DispIdAttribute(18)]
        public virtual int SelStart
        {
            get
            {
                if ((this.ocx == null))
                {
                    throw new System.Windows.Forms.AxHost.InvalidActiveXStateException("SelStart", System.Windows.Forms.AxHost.ActiveXInvokeKind.PropertyGet);
                }
                return this.ocx.SelStart;
            }
            set
            {
                if ((this.ocx == null))
                {
                    throw new System.Windows.Forms.AxHost.InvalidActiveXStateException("SelStart", System.Windows.Forms.AxHost.ActiveXInvokeKind.PropertySet);
                }
                this.ocx.SelStart = value;
            }
        }

        [System.ComponentModel.Browsable(false)]
        [System.ComponentModel.DesignerSerializationVisibility(System.ComponentModel.DesignerSerializationVisibility.Hidden)]
        [System.Runtime.InteropServices.DispIdAttribute(19)]
        public virtual string SelText
        {
            get
            {
                if ((this.ocx == null))
                {
                    throw new System.Windows.Forms.AxHost.InvalidActiveXStateException("SelText", System.Windows.Forms.AxHost.ActiveXInvokeKind.PropertyGet);
                }
                return this.ocx.SelText;
            }
            set
            {
                if ((this.ocx == null))
                {
                    throw new System.Windows.Forms.AxHost.InvalidActiveXStateException("SelText", System.Windows.Forms.AxHost.ActiveXInvokeKind.PropertySet);
                }
                this.ocx.SelText = value;
            }
        }

        [System.ComponentModel.Browsable(false)]
        [System.ComponentModel.DesignerSerializationVisibility(System.ComponentModel.DesignerSerializationVisibility.Hidden)]
        [System.Runtime.InteropServices.DispIdAttribute(20)]
        public virtual string ClipText
        {
            get
            {
                if ((this.ocx == null))
                {
                    throw new System.Windows.Forms.AxHost.InvalidActiveXStateException("ClipText", System.Windows.Forms.AxHost.ActiveXInvokeKind.PropertyGet);
                }
                return this.ocx.ClipText;
            }
            set
            {
                if ((this.ocx == null))
                {
                    throw new System.Windows.Forms.AxHost.InvalidActiveXStateException("ClipText", System.Windows.Forms.AxHost.ActiveXInvokeKind.PropertySet);
                }
                this.ocx.ClipText = value;
            }
        }

        [System.ComponentModel.DesignerSerializationVisibility(System.ComponentModel.DesignerSerializationVisibility.Hidden)]
        [System.Runtime.InteropServices.DispIdAttribute(21)]
        public virtual string PromptChar
        {
            get
            {
                if ((this.ocx == null))
                {
                    throw new System.Windows.Forms.AxHost.InvalidActiveXStateException("PromptChar", System.Windows.Forms.AxHost.ActiveXInvokeKind.PropertyGet);
                }
                return this.ocx.PromptChar;
            }
            set
            {
                if ((this.ocx == null))
                {
                    throw new System.Windows.Forms.AxHost.InvalidActiveXStateException("PromptChar", System.Windows.Forms.AxHost.ActiveXInvokeKind.PropertySet);
                }
                this.ocx.PromptChar = value;
            }
        }

        [System.ComponentModel.Browsable(false)]
        [System.ComponentModel.DesignerSerializationVisibility(System.ComponentModel.DesignerSerializationVisibility.Hidden)]
        [System.Runtime.InteropServices.DispIdAttribute(0)]
        public virtual string defaultText
        {
            get
            {
                if ((this.ocx == null))
                {
                    throw new System.Windows.Forms.AxHost.InvalidActiveXStateException("defaultText", System.Windows.Forms.AxHost.ActiveXInvokeKind.PropertyGet);
                }
                return this.ocx.defaultText;
            }
            set
            {
                if ((this.ocx == null))
                {
                    throw new System.Windows.Forms.AxHost.InvalidActiveXStateException("defaultText", System.Windows.Forms.AxHost.ActiveXInvokeKind.PropertySet);
                }
                this.ocx.defaultText = value;
            }
        }

        [System.ComponentModel.Browsable(false)]
        [System.ComponentModel.DesignerSerializationVisibility(System.ComponentModel.DesignerSerializationVisibility.Hidden)]
        [System.Runtime.InteropServices.DispIdAttribute(22)]
        [System.ComponentModel.Bindable(System.ComponentModel.BindableSupport.Default)]
        public virtual string CtlText
        {
            get
            {
                if ((this.ocx == null))
                {
                    throw new System.Windows.Forms.AxHost.InvalidActiveXStateException("CtlText", System.Windows.Forms.AxHost.ActiveXInvokeKind.PropertyGet);
                }
                return this.ocx.Text;
            }
            set
            {
                if ((this.ocx == null))
                {
                    throw new System.Windows.Forms.AxHost.InvalidActiveXStateException("CtlText", System.Windows.Forms.AxHost.ActiveXInvokeKind.PropertySet);
                }
                this.ocx.Text = value;
            }
        }

        [System.ComponentModel.DesignerSerializationVisibility(System.ComponentModel.DesignerSerializationVisibility.Hidden)]
        [System.Runtime.InteropServices.DispIdAttribute(23)]
        [System.Runtime.InteropServices.ComAliasNameAttribute("stdole.IPictureDisp")]
        public virtual System.Drawing.Image MouseIcon
        {
            get
            {
                if ((this.ocx == null))
                {
                    throw new System.Windows.Forms.AxHost.InvalidActiveXStateException("MouseIcon", System.Windows.Forms.AxHost.ActiveXInvokeKind.PropertyGet);
                }
                return GetPictureFromIPicture(this.ocx.MouseIcon);
            }
            set
            {
                if ((this.ocx == null))
                {
                    throw new System.Windows.Forms.AxHost.InvalidActiveXStateException("MouseIcon", System.Windows.Forms.AxHost.ActiveXInvokeKind.PropertySet);
                }
                this.ocx.MouseIcon = ((stdole.IPictureDisp)(GetIPictureFromPicture(value)));
            }
        }

        [System.ComponentModel.DesignerSerializationVisibility(System.ComponentModel.DesignerSerializationVisibility.Hidden)]
        [System.Runtime.InteropServices.DispIdAttribute(24)]
        public virtual MSMask.AppearanceConstants Appearance
        {
            get
            {
                if ((this.ocx == null))
                {
                    throw new System.Windows.Forms.AxHost.InvalidActiveXStateException("Appearance", System.Windows.Forms.AxHost.ActiveXInvokeKind.PropertyGet);
                }
                return this.ocx.Appearance;
            }
            set
            {
                if ((this.ocx == null))
                {
                    throw new System.Windows.Forms.AxHost.InvalidActiveXStateException("Appearance", System.Windows.Forms.AxHost.ActiveXInvokeKind.PropertySet);
                }
                this.ocx.Appearance = value;
            }
        }

        [System.ComponentModel.Browsable(true)]
        [System.ComponentModel.DesignerSerializationVisibility(System.ComponentModel.DesignerSerializationVisibility.Hidden)]
        [System.Runtime.InteropServices.DispIdAttribute(-501)]
        [System.Runtime.InteropServices.ComAliasNameAttribute("System.UInt32")]
        [System.ComponentModel.Bindable(System.ComponentModel.BindableSupport.Yes)]
        public override System.Drawing.Color BackColor
        {
            get
            {
                if (((this.ocx != null)
                            && (this.PropsValid() == true)))
                {
                    return GetColorFromOleColor(((System.UInt32)(this.ocx.BackColor)));
                }
                else
                {
                    return base.BackColor;
                }
            }
            set
            {
                base.BackColor = value;
                if ((this.ocx != null))
                {
                    this.ocx.BackColor = ((System.UInt32)(GetOleColorFromColor(value)));
                }
            }
        }

        [System.ComponentModel.Browsable(true)]
        [System.ComponentModel.DesignerSerializationVisibility(System.ComponentModel.DesignerSerializationVisibility.Hidden)]
        [System.Runtime.InteropServices.DispIdAttribute(-512)]
        [System.Runtime.InteropServices.ComAliasNameAttribute("stdole.IFontDisp")]
        [System.ComponentModel.Bindable(System.ComponentModel.BindableSupport.Yes)]
        public override System.Drawing.Font Font
        {
            get
            {
                if (((this.ocx != null)
                            && (this.PropsValid() == true)))
                {
                    return GetFontFromIFont(this.ocx.Font);
                }
                else
                {
                    return base.Font;
                }
            }
            set
            {
                base.Font = value;
                if ((this.ocx != null))
                {
                    this.ocx.Font = ((stdole.IFontDisp)(GetIFontFromFont(value)));
                }
            }
        }

        [System.ComponentModel.Browsable(true)]
        [System.ComponentModel.DesignerSerializationVisibility(System.ComponentModel.DesignerSerializationVisibility.Hidden)]
        [System.Runtime.InteropServices.DispIdAttribute(-513)]
        [System.Runtime.InteropServices.ComAliasNameAttribute("System.UInt32")]
        [System.ComponentModel.Bindable(System.ComponentModel.BindableSupport.Yes)]
        public override System.Drawing.Color ForeColor
        {
            get
            {
                if (((this.ocx != null)
                            && (this.PropsValid() == true)))
                {
                    return GetColorFromOleColor(((System.UInt32)(this.ocx.ForeColor)));
                }
                else
                {
                    return base.ForeColor;
                }
            }
            set
            {
                base.ForeColor = value;
                if ((this.ocx != null))
                {
                    this.ocx.ForeColor = ((System.UInt32)(GetOleColorFromColor(value)));
                }
            }
        }

        [System.ComponentModel.Browsable(true)]
        [System.ComponentModel.DesignerSerializationVisibility(System.ComponentModel.DesignerSerializationVisibility.Hidden)]
        [System.Runtime.InteropServices.DispIdAttribute(-514)]
        [System.ComponentModel.Bindable(System.ComponentModel.BindableSupport.Yes)]
        public override bool Enabled
        {
            get
            {
                if (((this.ocx != null)
                            && (this.PropsValid() == true)))
                {
                    return this.ocx.Enabled;
                }
                else
                {
                    return base.Enabled;
                }
            }
            set
            {
                base.Enabled = value;
                if ((this.ocx != null))
                {
                    this.ocx.Enabled = value;
                }
            }
        }

        [System.ComponentModel.Browsable(false)]
        [System.ComponentModel.DesignerSerializationVisibility(System.ComponentModel.DesignerSerializationVisibility.Hidden)]
        [System.Runtime.InteropServices.DispIdAttribute(-515)]
        [System.Runtime.InteropServices.ComAliasNameAttribute("System.Int32")]
        public virtual int hWnd
        {
            get
            {
                if ((this.ocx == null))
                {
                    throw new System.Windows.Forms.AxHost.InvalidActiveXStateException("hWnd", System.Windows.Forms.AxHost.ActiveXInvokeKind.PropertyGet);
                }
                return (this.ocx.hWnd);
            }
            set
            {
                if ((this.ocx == null))
                {
                    throw new System.Windows.Forms.AxHost.InvalidActiveXStateException("hWnd", System.Windows.Forms.AxHost.ActiveXInvokeKind.PropertySet);
                }
                this.ocx.hWnd = ((int)((value)));
            }
        }

        [System.ComponentModel.DesignerSerializationVisibility(System.ComponentModel.DesignerSerializationVisibility.Hidden)]
        [System.Runtime.InteropServices.DispIdAttribute(-504)]
        [System.ComponentModel.Bindable(System.ComponentModel.BindableSupport.Yes)]
        public virtual MSMask.BorderStyleConstants BorderStyle
        {
            get
            {
                if ((this.ocx == null))
                {
                    throw new System.Windows.Forms.AxHost.InvalidActiveXStateException("BorderStyle", System.Windows.Forms.AxHost.ActiveXInvokeKind.PropertyGet);
                }
                return this.ocx.BorderStyle;
            }
            set
            {
                if ((this.ocx == null))
                {
                    throw new System.Windows.Forms.AxHost.InvalidActiveXStateException("BorderStyle", System.Windows.Forms.AxHost.ActiveXInvokeKind.PropertySet);
                }
                this.ocx.BorderStyle = value;
            }
        }

        [System.ComponentModel.DesignerSerializationVisibility(System.ComponentModel.DesignerSerializationVisibility.Hidden)]
        [System.Runtime.InteropServices.DispIdAttribute(1550)]
        public virtual MSMask.OLEDragConstants OLEDragMode
        {
            get
            {
                if ((this.ocx == null))
                {
                    throw new System.Windows.Forms.AxHost.InvalidActiveXStateException("OLEDragMode", System.Windows.Forms.AxHost.ActiveXInvokeKind.PropertyGet);
                }
                return this.ocx.OLEDragMode;
            }
            set
            {
                if ((this.ocx == null))
                {
                    throw new System.Windows.Forms.AxHost.InvalidActiveXStateException("OLEDragMode", System.Windows.Forms.AxHost.ActiveXInvokeKind.PropertySet);
                }
                this.ocx.OLEDragMode = value;
            }
        }

        [System.ComponentModel.DesignerSerializationVisibility(System.ComponentModel.DesignerSerializationVisibility.Hidden)]
        [System.Runtime.InteropServices.DispIdAttribute(1551)]
        public virtual MSMask.OLEDropConstants OLEDropMode
        {
            get
            {
                if ((this.ocx == null))
                {
                    throw new System.Windows.Forms.AxHost.InvalidActiveXStateException("OLEDropMode", System.Windows.Forms.AxHost.ActiveXInvokeKind.PropertyGet);
                }
                return this.ocx.OLEDropMode;
            }
            set
            {
                if ((this.ocx == null))
                {
                    throw new System.Windows.Forms.AxHost.InvalidActiveXStateException("OLEDropMode", System.Windows.Forms.AxHost.ActiveXInvokeKind.PropertySet);
                }
                this.ocx.OLEDropMode = value;
            }
        }

        public event MaskEdBoxEvents_OLEDragDropEventHandler OLEDragDrop;

        public event MaskEdBoxEvents_OLEDragOverEventHandler OLEDragOver;

        public event MaskEdBoxEvents_OLECompleteDragEventHandler OLECompleteDrag;

        public event MaskEdBoxEvents_OLESetDataEventHandler OLESetData;

        public event MaskEdBoxEvents_OLEGiveFeedbackEventHandler OLEGiveFeedback;

        public event MaskEdBoxEvents_OLEStartDragEventHandler OLEStartDrag;

        public event MaskEdBoxEvents_KeyUpEventHandler KeyUpEvent;

        public event MaskEdBoxEvents_KeyPressEventHandler KeyPressEvent;

        public event MaskEdBoxEvents_KeyDownEventHandler KeyDownEvent;

        public event MaskEdBoxEvents_ValidationErrorEventHandler ValidationError;

        public event System.EventHandler Change;

        public virtual void OLEDrag()
        {
            if ((this.ocx == null))
            {
                throw new System.Windows.Forms.AxHost.InvalidActiveXStateException("OLEDrag", System.Windows.Forms.AxHost.ActiveXInvokeKind.MethodInvoke);
            }
            this.ocx.OLEDrag();
        }

        public virtual void CtlRefresh()
        {
            if ((this.ocx == null))
            {
                throw new System.Windows.Forms.AxHost.InvalidActiveXStateException("CtlRefresh", System.Windows.Forms.AxHost.ActiveXInvokeKind.MethodInvoke);
            }
            this.ocx.Refresh();
        }

        protected override void CreateSink()
        {
            try
            {
                this.eventMulticaster = new AxMaskEdBoxEventMulticaster(this);
                this.cookie = new System.Windows.Forms.AxHost.ConnectionPointCookie(this.ocx, this.eventMulticaster, typeof(MSMask.MaskEdBoxEvents));
            }
            catch (System.Exception)
            {
            }
        }

        protected override void DetachSink()
        {
            try
            {
                this.cookie.Disconnect();
            }
            catch (System.Exception)
            {
            }
        }



        internal void RaiseOnOLEDragDrop(object sender, MaskEdBoxEvents_OLEDragDropEvent e)
        {
            if ((this.OLEDragDrop != null))
            {
                this.OLEDragDrop(sender, e);
            }
        }

        internal void RaiseOnOLEDragOver(object sender, MaskEdBoxEvents_OLEDragOverEvent e)
        {
            if ((this.OLEDragOver != null))
            {
                this.OLEDragOver(sender, e);
            }
        }

        internal void RaiseOnOLECompleteDrag(object sender, MaskEdBoxEvents_OLECompleteDragEvent e)
        {
            if ((this.OLECompleteDrag != null))
            {
                this.OLECompleteDrag(sender, e);
            }
        }

        internal void RaiseOnOLESetData(object sender, MaskEdBoxEvents_OLESetDataEvent e)
        {
            if ((this.OLESetData != null))
            {
                this.OLESetData(sender, e);
            }
        }

        internal void RaiseOnOLEGiveFeedback(object sender, MaskEdBoxEvents_OLEGiveFeedbackEvent e)
        {
            if ((this.OLEGiveFeedback != null))
            {
                this.OLEGiveFeedback(sender, e);
            }
        }

        internal void RaiseOnOLEStartDrag(object sender, MaskEdBoxEvents_OLEStartDragEvent e)
        {
            if ((this.OLEStartDrag != null))
            {
                this.OLEStartDrag(sender, e);
            }
        }

        internal void RaiseOnKeyUpEvent(object sender, MaskEdBoxEvents_KeyUpEvent e)
        {
            if ((this.KeyUpEvent != null))
            {
                this.KeyUpEvent(sender, e);
            }
        }

        internal void RaiseOnKeyPressEvent(object sender, MaskEdBoxEvents_KeyPressEvent e)
        {
            if ((this.KeyPressEvent != null))
            {
                this.KeyPressEvent(sender, e);
            }
        }

        internal void RaiseOnKeyDownEvent(object sender, MaskEdBoxEvents_KeyDownEvent e)
        {
            if ((this.KeyDownEvent != null))
            {
                this.KeyDownEvent(sender, e);
            }
        }

        internal void RaiseOnValidationError(object sender, MaskEdBoxEvents_ValidationErrorEvent e)
        {
            if ((this.ValidationError != null))
            {
                this.ValidationError(sender, e);
            }
        }

        internal void RaiseOnChange(object sender, System.EventArgs e)
        {
            if ((this.Change != null))
            {
                this.Change(sender, e);
            }
        }
    }

    public delegate void MaskEdBoxEvents_OLEDragDropEventHandler(object sender, MaskEdBoxEvents_OLEDragDropEvent e);

    public class MaskEdBoxEvents_OLEDragDropEvent
    {

        public MSMask.DataObject data;

        public int effect;

        public short button;

        public short shift;

        public System.Single x;

        public System.Single y;

        public MaskEdBoxEvents_OLEDragDropEvent(MSMask.DataObject data, int effect, short button, short shift, System.Single x, System.Single y)
        {
            this.data = data;
            this.effect = effect;
            this.button = button;
            this.shift = shift;
            this.x = x;
            this.y = y;
        }
    }

    public delegate void MaskEdBoxEvents_OLEDragOverEventHandler(object sender, MaskEdBoxEvents_OLEDragOverEvent e);

    public class MaskEdBoxEvents_OLEDragOverEvent
    {

        public MSMask.DataObject data;

        public int effect;

        public short button;

        public short shift;

        public System.Single x;

        public System.Single y;

        public short state;

        public MaskEdBoxEvents_OLEDragOverEvent(MSMask.DataObject data, int effect, short button, short shift, System.Single x, System.Single y, short state)
        {
            this.data = data;
            this.effect = effect;
            this.button = button;
            this.shift = shift;
            this.x = x;
            this.y = y;
            this.state = state;
        }
    }

    public delegate void MaskEdBoxEvents_OLECompleteDragEventHandler(object sender, MaskEdBoxEvents_OLECompleteDragEvent e);

    public class MaskEdBoxEvents_OLECompleteDragEvent
    {

        public int effect;

        public MaskEdBoxEvents_OLECompleteDragEvent(int effect)
        {
            this.effect = effect;
        }
    }

    public delegate void MaskEdBoxEvents_OLESetDataEventHandler(object sender, MaskEdBoxEvents_OLESetDataEvent e);

    public class MaskEdBoxEvents_OLESetDataEvent
    {

        public MSMask.DataObject data;

        public short dataFormat;

        public MaskEdBoxEvents_OLESetDataEvent(MSMask.DataObject data, short dataFormat)
        {
            this.data = data;
            this.dataFormat = dataFormat;
        }
    }

    public delegate void MaskEdBoxEvents_OLEGiveFeedbackEventHandler(object sender, MaskEdBoxEvents_OLEGiveFeedbackEvent e);

    public class MaskEdBoxEvents_OLEGiveFeedbackEvent
    {

        public int effect;

        public bool defaultCursors;

        public MaskEdBoxEvents_OLEGiveFeedbackEvent(int effect, bool defaultCursors)
        {
            this.effect = effect;
            this.defaultCursors = defaultCursors;
        }
    }

    public delegate void MaskEdBoxEvents_OLEStartDragEventHandler(object sender, MaskEdBoxEvents_OLEStartDragEvent e);

    public class MaskEdBoxEvents_OLEStartDragEvent
    {

        public MSMask.DataObject data;

        public int allowedEffects;

        public MaskEdBoxEvents_OLEStartDragEvent(MSMask.DataObject data, int allowedEffects)
        {
            this.data = data;
            this.allowedEffects = allowedEffects;
        }
    }

    public delegate void MaskEdBoxEvents_KeyUpEventHandler(object sender, MaskEdBoxEvents_KeyUpEvent e);

    public class MaskEdBoxEvents_KeyUpEvent
    {

        public short keyCode;

        public short shift;

        public MaskEdBoxEvents_KeyUpEvent(short keyCode, short shift)
        {
            this.keyCode = keyCode;
            this.shift = shift;
        }
    }

    public delegate void MaskEdBoxEvents_KeyPressEventHandler(object sender, MaskEdBoxEvents_KeyPressEvent e);

    public class MaskEdBoxEvents_KeyPressEvent
    {

        public short keyAscii;

        public MaskEdBoxEvents_KeyPressEvent(short keyAscii)
        {
            this.keyAscii = keyAscii;
        }
    }

    public delegate void MaskEdBoxEvents_KeyDownEventHandler(object sender, MaskEdBoxEvents_KeyDownEvent e);

    public class MaskEdBoxEvents_KeyDownEvent
    {

        public short keyCode;

        public short shift;

        public MaskEdBoxEvents_KeyDownEvent(short keyCode, short shift)
        {
            this.keyCode = keyCode;
            this.shift = shift;
        }
    }

    public delegate void MaskEdBoxEvents_ValidationErrorEventHandler(object sender, MaskEdBoxEvents_ValidationErrorEvent e);

    public class MaskEdBoxEvents_ValidationErrorEvent
    {

        public string invalidText;

        public short startPosition;

        public MaskEdBoxEvents_ValidationErrorEvent(string invalidText, short startPosition)
        {
            this.invalidText = invalidText;
            this.startPosition = startPosition;
        }
    }

    public class AxMaskEdBoxEventMulticaster : MSMask.MaskEdBoxEvents
    {

        private AxMaskEdBox parent;

        public AxMaskEdBoxEventMulticaster(AxMaskEdBox parent)
        {
            this.parent = parent;
        }

        public virtual void OLEDragDrop(ref MSMask.DataObject data, ref int effect, ref short button, ref short shift, ref System.Single x, ref System.Single y)
        {
            MaskEdBoxEvents_OLEDragDropEvent oledragdropEvent = new MaskEdBoxEvents_OLEDragDropEvent(data, effect, button, shift, x, y);
            this.parent.RaiseOnOLEDragDrop(this.parent, oledragdropEvent);
            data = oledragdropEvent.data;
            effect = oledragdropEvent.effect;
            button = oledragdropEvent.button;
            shift = oledragdropEvent.shift;
            x = oledragdropEvent.x;
            y = oledragdropEvent.y;
        }

        public virtual void OLEDragOver(ref MSMask.DataObject data, ref int effect, ref short button, ref short shift, ref System.Single x, ref System.Single y, ref short state)
        {
            MaskEdBoxEvents_OLEDragOverEvent oledragoverEvent = new MaskEdBoxEvents_OLEDragOverEvent(data, effect, button, shift, x, y, state);
            this.parent.RaiseOnOLEDragOver(this.parent, oledragoverEvent);
            data = oledragoverEvent.data;
            effect = oledragoverEvent.effect;
            button = oledragoverEvent.button;
            shift = oledragoverEvent.shift;
            x = oledragoverEvent.x;
            y = oledragoverEvent.y;
            state = oledragoverEvent.state;
        }

        public virtual void OLECompleteDrag(ref int effect)
        {
            MaskEdBoxEvents_OLECompleteDragEvent olecompletedragEvent = new MaskEdBoxEvents_OLECompleteDragEvent(effect);
            this.parent.RaiseOnOLECompleteDrag(this.parent, olecompletedragEvent);
            effect = olecompletedragEvent.effect;
        }

        public virtual void OLESetData(ref MSMask.DataObject data, ref short dataFormat)
        {
            MaskEdBoxEvents_OLESetDataEvent olesetdataEvent = new MaskEdBoxEvents_OLESetDataEvent(data, dataFormat);
            this.parent.RaiseOnOLESetData(this.parent, olesetdataEvent);
            data = olesetdataEvent.data;
            dataFormat = olesetdataEvent.dataFormat;
        }

        public virtual void OLEGiveFeedback(ref int effect, ref bool defaultCursors)
        {
            MaskEdBoxEvents_OLEGiveFeedbackEvent olegivefeedbackEvent = new MaskEdBoxEvents_OLEGiveFeedbackEvent(effect, defaultCursors);
            this.parent.RaiseOnOLEGiveFeedback(this.parent, olegivefeedbackEvent);
            effect = olegivefeedbackEvent.effect;
            defaultCursors = olegivefeedbackEvent.defaultCursors;
        }

        public virtual void OLEStartDrag(ref MSMask.DataObject data, ref int allowedEffects)
        {
            MaskEdBoxEvents_OLEStartDragEvent olestartdragEvent = new MaskEdBoxEvents_OLEStartDragEvent(data, allowedEffects);
            this.parent.RaiseOnOLEStartDrag(this.parent, olestartdragEvent);
            data = olestartdragEvent.data;
            allowedEffects = olestartdragEvent.allowedEffects;
        }

        public virtual void KeyUp(short keyCode, short shift)
        {
            MaskEdBoxEvents_KeyUpEvent keyupEvent = new MaskEdBoxEvents_KeyUpEvent(keyCode, shift);
            this.parent.RaiseOnKeyUpEvent(this.parent, keyupEvent);
        }

        public virtual void KeyPress(ref short keyAscii)
        {
            MaskEdBoxEvents_KeyPressEvent keypressEvent = new MaskEdBoxEvents_KeyPressEvent(keyAscii);
            this.parent.RaiseOnKeyPressEvent(this.parent, keypressEvent);
            keyAscii = keypressEvent.keyAscii;
        }

        public virtual void KeyDown(short keyCode, short shift)
        {
            MaskEdBoxEvents_KeyDownEvent keydownEvent = new MaskEdBoxEvents_KeyDownEvent(keyCode, shift);
            this.parent.RaiseOnKeyDownEvent(this.parent, keydownEvent);
        }

        public virtual void ValidationError(ref string invalidText, ref short startPosition)
        {
            MaskEdBoxEvents_ValidationErrorEvent validationerrorEvent = new MaskEdBoxEvents_ValidationErrorEvent(invalidText, startPosition);
            this.parent.RaiseOnValidationError(this.parent, validationerrorEvent);
            invalidText = validationerrorEvent.invalidText;
            startPosition = validationerrorEvent.startPosition;
        }

        public virtual void Change()
        {
            System.EventArgs changeEvent = new System.EventArgs();
            this.parent.RaiseOnChange(this.parent, changeEvent);
        }
    }
}
