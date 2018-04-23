using System;
using System.Collections.Generic;
using System.Windows.Forms;
using DevExpress.Skins;
using DevExpress.XtraEditors.Registrator;
using DevExpress.XtraEditors.Repository;
using System.Drawing;
using DevExpress.XtraEditors;
using System.ComponentModel;
using DevExpress.XtraEditors.ViewInfo;
using DevExpress.XtraEditors.Drawing;
using DevExpress.XtraEditors.Popup;
using DevExpress.Utils.Drawing;
using DevExpress.Utils;

namespace DXSample {
    public class CustomPopupBaseSizeableFormPainter : PopupBaseSizeableFormPainter
    {
        public CustomPopupBaseSizeableFormPainter() : base() { }
        protected override void DrawSizeBar(PopupFormGraphicsInfoArgs info)
        {
            base.DrawSizeBar(info);
            CustomPopupForm form = info.ViewInfo.Form as CustomPopupForm;
            DrawClear(form.IsHotTrackClearButton, form.Appearance, info.Cache, form.ClearButtonRectangle);
        }
        protected void DrawClear(bool isHot, AppearanceObject app, GraphicsCache cache, Rectangle rect)
        {
            if (rect.IsEmpty) return;
            Brush br = app.GetForeBrush(cache);
            if (isHot)
            {
                SkinElementInfo skin = new SkinElementInfo(CommonSkins.GetSkin(DevExpress.LookAndFeel.UserLookAndFeel.Default.ActiveLookAndFeel)[CommonSkins.SkinHighlightedItem], rect);
                br = new SolidBrush(DevExpress.LookAndFeel.LookAndFeelHelper.GetSystemColor(
                    DevExpress.LookAndFeel.UserLookAndFeel.Default.ActiveLookAndFeel,
                    SystemColors.HotTrack));
                ObjectPainter.DrawObject(cache, SkinElementPainter.Default, skin);
            }
            StringFormat format = new StringFormat();
            format.Alignment = StringAlignment.Center;
            cache.DrawString("Clear", app.Font, br, rect, format);
        }
    }
}