﻿using System.Windows.Forms;
using System.Drawing;

namespace MalikP.Controls.Loaders
{
    public partial class LoadScreenColor1 : UserControl, ILoader
    {
        public Point MessageOriginalLocation { get; private set; }

        public Font OriginalMessageFont { get; private set; }

        public LoadScreenColor1()
        {
            InitializeComponent();
            MessageOriginalLocation = _loaderLbl.Location;
            OriginalMessageFont = _loaderLbl.Font;
            //SetStyle(ControlStyles.SupportsTransparentBackColor, true);
            //this.BackColor = Color.Transparent;
        }

        public const string LoaderText = "Loading data...";
        public virtual bool ChangeText(string text)
        {
            if (string.IsNullOrEmpty(text))
            {
                return false;
            }

            _loaderLbl.Text = text;
            return true;
        }

        public virtual bool Reset()
        {
            _loaderLbl.Text = LoaderText;
            _loaderLbl.Font = OriginalMessageFont;
            _loaderLbl.Location = MessageOriginalLocation;
            return true;
        }

        public virtual void SetFontStyleAndLocation(Point drawLocation, FontFamily fontFamily, float fontSize)
        {
            SetFontStyleAndLocation(drawLocation, fontFamily, fontSize, _loaderLbl.Font.Style);
        }

        public virtual void SetFontStyleAndLocation(Point drawLocation, FontFamily fontFamily, float fontSize, FontStyle fontStyle)
        {
            SetFontStyle(fontFamily, fontSize, fontStyle);
            SetMessageLocation(drawLocation);
        }

        public void SetFontStyle(FontFamily fontFamily, float fontSize, FontStyle fontStyle)
        {
            _loaderLbl.Font = new Font(fontFamily, fontSize, fontStyle);
        }

        public void SetMessageLocation(Point drawLocation)
        {
            _loaderLbl.Location = drawLocation;
        }
    }
}
