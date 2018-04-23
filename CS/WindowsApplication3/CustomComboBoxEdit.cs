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
   
    public class CustomEdit : ComboBoxEdit
    {
        static CustomEdit() { RepositoryItemCustomEdit.RegisterCustomEdit(); }

        public CustomEdit() { }

        public override string EditorTypeName
        {
            get
            {
                return RepositoryItemCustomEdit.CustomEditName;
            }
        }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
        public new RepositoryItemCustomEdit Properties
        {
            get { return base.Properties as RepositoryItemCustomEdit; }
        }

        protected override DevExpress.XtraEditors.Popup.PopupBaseForm CreatePopupForm()
        {
            return new CustomPopupForm(this);
        }
    }
}