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
Imports DevExpress.Utils
Imports DevExpress.XtraEditors.Drawing

Namespace DXSample
	<UserRepositoryItem("RegisterCustomEdit")> _
	Public Class RepositoryItemCustomEdit
		Inherits RepositoryItemComboBox
		Shared Sub New()
			RegisterCustomEdit()
		End Sub
		Public Sub New()
		End Sub

		Public Const CustomEditName As String = "CustomEdit"

		Public Overrides ReadOnly Property EditorTypeName() As String
			Get
				Return CustomEditName
			End Get
		End Property

		Public Shared Sub RegisterCustomEdit()
			Dim image As Image = Nothing
			EditorRegistrationInfo.Default.Editors.Add(New EditorClassInfo(CustomEditName, GetType(CustomEdit), GetType(RepositoryItemCustomEdit), GetType(ComboBoxViewInfo), New ButtonEditPainter(), True, image))
		End Sub

		Private showCloseButton_Renamed As Boolean, showClearButton_Renamed As Boolean = False
		<DefaultValue(False)> _
		Public Property ShowCloseButton() As Boolean
			Get
				Return showCloseButton_Renamed
			End Get
			Set(ByVal value As Boolean)
				If showCloseButton_Renamed <> value Then
					showCloseButton_Renamed = value
				End If
			End Set
		End Property

		<DefaultValue(False)> _
		Public Property ShowClearButton() As Boolean
			Get
				Return showClearButton_Renamed
			End Get
			Set(ByVal value As Boolean)
				If showClearButton_Renamed <> value Then
					showClearButton_Renamed = value
				End If
			End Set
		End Property

		Public Overrides Sub Assign(ByVal item As RepositoryItem)
			BeginUpdate()
			Try
				MyBase.Assign(item)
				Dim source As RepositoryItemCustomEdit = TryCast(item, RepositoryItemCustomEdit)
				If source Is Nothing Then
					Return
				End If
				showCloseButton_Renamed = source.showCloseButton
				showClearButton_Renamed = source.showClearButton
			Finally
				EndUpdate()
			End Try
		End Sub
	End Class
End Namespace