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
using DevExpress.Utils;
using DevExpress.XtraEditors.Drawing;

namespace DXSample {
    [UserRepositoryItem("RegisterCustomEdit")]
    public class RepositoryItemCustomEdit : RepositoryItemComboBox
    {
        static RepositoryItemCustomEdit() { RegisterCustomEdit(); }
        public RepositoryItemCustomEdit() { }

        public const string CustomEditName = "CustomEdit";

        public override string EditorTypeName { get { return CustomEditName; } }

        public static void RegisterCustomEdit()
        {
            Image image = null;
            EditorRegistrationInfo.Default.Editors.Add(new EditorClassInfo(CustomEditName,
              typeof(CustomEdit), typeof(RepositoryItemCustomEdit),
              typeof(ComboBoxViewInfo), new ButtonEditPainter(), true, image));
        }

        bool showCloseButton, showClearButton = false;
        [DefaultValue(false)]
        public bool ShowCloseButton
        {
            get { return showCloseButton; }
            set
            {
                if (showCloseButton != value)
                    showCloseButton = value;
            }
        }

        [DefaultValue(false)]
        public bool ShowClearButton
        {
            get { return showClearButton; }
            set
            {
                if (showClearButton != value)
                    showClearButton = value;
            }
        }

        public override void Assign(RepositoryItem item)
        {
            BeginUpdate();
            try
            {
                base.Assign(item);
                RepositoryItemCustomEdit source = item as RepositoryItemCustomEdit;
                if (source == null) return;
                showCloseButton = source.showCloseButton;
                showClearButton = source.showClearButton;
            }
            finally
            {
                EndUpdate();
            }
        }
    }
}