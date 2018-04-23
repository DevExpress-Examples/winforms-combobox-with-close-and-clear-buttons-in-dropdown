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
    public class CustomPopupForm : PopupListBoxForm
    {
        CloseButton closeBtn = null;
        Size closeButtonSize, clearButtonSize;
        Rectangle clearButtonRectangle = Rectangle.Empty;
        bool isHotTrackClearButton = false;

        public CustomPopupForm(ComboBoxEdit edit)
            : base(edit)
        {
            if (OwnerEdit.Properties.ShowCloseButton)
            {
                closeBtn = new CloseButton();
                closeBtn.Parent = this;
                closeBtn.Click += OnCloseButtonClick;
                closeButtonSize = new Size(16, 16);
            }
            if (OwnerEdit.Properties.ShowClearButton)
                clearButtonSize = new Size(35, 16);
        }

        internal Rectangle ClearButtonRectangle
        {
            get { return clearButtonRectangle; }
        }

        internal bool IsHotTrackClearButton
        {
            get { return isHotTrackClearButton; }
            set
            {
                if (isHotTrackClearButton != value)
                {
                    isHotTrackClearButton = value;
                    Invalidate();
                }
            }
        }

        public new CustomEdit OwnerEdit
        {
            get { return base.OwnerEdit as CustomEdit; }
        }

        public override bool AllowSizing
        {
            get
            {
                return true;
            }
            set
            {
                base.AllowSizing = value;
            }
        }

        void OnCloseButtonClick(object sender, EventArgs e)
        {
            ClosePopup(PopupCloseMode.Cancel);
        }

        protected override void SetupListBoxOnShow()
        {
            base.SetupListBoxOnShow();
            UpdateClearButtonBounds();
            UpdateCloseButtonBounds();
        }

        private void UpdateClearButtonBounds()
        {
            if (OwnerEdit.Properties.ShowClearButton)
                clearButtonRectangle = new Rectangle(ViewInfo.SizeBarRect.X + closeButtonSize.Width + 2,
                    ViewInfo.SizeBarRect.Y + 4, clearButtonSize.Width, clearButtonSize.Height);
        }

        private void UpdateCloseButtonBounds()
        {
            if (closeBtn != null)
                closeBtn.SetBounds(ViewInfo.SizeBarRect.X, ViewInfo.SizeBarRect.Y + 2, closeButtonSize.Width, closeButtonSize.Height);
        }

        protected override void UpdateControlPositionsCore()
        {
            base.UpdateControlPositionsCore();
            UpdateCloseButtonBounds();
            UpdateClearButtonBounds();
        }

        protected override void OnMouseMove(MouseEventArgs e)
        {
            base.OnMouseMove(e);
            IsHotTrackClearButton = ClearButtonRectangle.Contains(e.Location);
        }
        protected override void OnMouseDown(MouseEventArgs e)
        {
            base.OnMouseDown(e);
            if (ClearButtonRectangle.Contains(e.Location))
            {
                ClosePopup(PopupCloseMode.Normal);
                OwnerEdit.EditValue = null;
            }
        }

        protected override void OnVisibleChanged(EventArgs e)
        {
            base.OnVisibleChanged(e);
            IsHotTrackClearButton = false;
        }

        protected override PopupBaseFormPainter CreatePainter()
        {
            return new CustomPopupBaseSizeableFormPainter();
        }


        protected override void Dispose(bool disposing)
        {
            if (disposing && closeBtn != null)
                closeBtn.Click -= OnCloseButtonClick;
            base.Dispose(disposing);
        }
    }

}