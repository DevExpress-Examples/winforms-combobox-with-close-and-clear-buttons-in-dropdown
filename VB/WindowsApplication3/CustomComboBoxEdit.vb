Imports Microsoft.VisualBasic
Imports System
Imports System.Collections.Generic
Imports System.Windows.Forms
Imports DevExpress.Skins
Imports DevExpress.XtraEditors.Registrator
Imports DevExpress.XtraEditors.Repository
Imports System.Drawing
Imports DevExpress.XtraEditors
Imports System.ComponentModel
Imports DevExpress.XtraEditors.ViewInfo
Imports DevExpress.XtraEditors.Drawing
Imports DevExpress.XtraEditors.Popup
Imports DevExpress.Utils.Drawing
Imports DevExpress.Utils

Namespace DXSample

	Public Class CustomEdit
		Inherits ComboBoxEdit
		Shared Sub New()
			RepositoryItemCustomEdit.RegisterCustomEdit()
		End Sub

		Public Sub New()
		End Sub

		Public Overrides ReadOnly Property EditorTypeName() As String
			Get
				Return RepositoryItemCustomEdit.CustomEditName
			End Get
		End Property

		<DesignerSerializationVisibility(DesignerSerializationVisibility.Content)> _
		Public Shadows ReadOnly Property Properties() As RepositoryItemCustomEdit
			Get
				Return TryCast(MyBase.Properties, RepositoryItemCustomEdit)
			End Get
		End Property

		Protected Overrides Function CreatePopupForm() As DevExpress.XtraEditors.Popup.PopupBaseForm
			Return New CustomPopupForm(Me)
		End Function
	End Class
End Namespace