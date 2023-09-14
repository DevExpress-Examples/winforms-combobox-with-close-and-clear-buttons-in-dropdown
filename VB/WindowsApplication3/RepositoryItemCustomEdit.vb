Imports DevExpress.XtraEditors.Registrator
Imports DevExpress.XtraEditors.Repository
Imports System.Drawing
Imports System.ComponentModel
Imports DevExpress.XtraEditors.ViewInfo
Imports DevExpress.XtraEditors.Drawing

Namespace DXSample

    <UserRepositoryItem("RegisterCustomEdit")>
    Public Class RepositoryItemCustomEdit
        Inherits RepositoryItemComboBox

        Shared Sub New()
            Call RegisterCustomEdit()
        End Sub

        Public Sub New()
        End Sub

        Public Const CustomEditName As String = "CustomEdit"

        Public Overrides ReadOnly Property EditorTypeName As String
            Get
                Return CustomEditName
            End Get
        End Property

        Public Shared Sub RegisterCustomEdit()
            Dim image As Image = Nothing
            Call EditorRegistrationInfo.Default.Editors.Add(New EditorClassInfo(CustomEditName, GetType(CustomEdit), GetType(RepositoryItemCustomEdit), GetType(ComboBoxViewInfo), New ButtonEditPainter(), True, image))
        End Sub

        Private showCloseButtonField As Boolean, showClearButtonField As Boolean = False

        <DefaultValue(False)>
        Public Property ShowCloseButton As Boolean
            Get
                Return showCloseButtonField
            End Get

            Set(ByVal value As Boolean)
                If showCloseButtonField <> value Then showCloseButtonField = value
            End Set
        End Property

        <DefaultValue(False)>
        Public Property ShowClearButton As Boolean
            Get
                Return showClearButtonField
            End Get

            Set(ByVal value As Boolean)
                If showClearButtonField <> value Then showClearButtonField = value
            End Set
        End Property

        Public Overrides Sub Assign(ByVal item As RepositoryItem)
            BeginUpdate()
            Try
                MyBase.Assign(item)
                Dim source As RepositoryItemCustomEdit = TryCast(item, RepositoryItemCustomEdit)
                If source Is Nothing Then Return
                showCloseButtonField = source.showCloseButtonField
                showClearButtonField = source.showClearButtonField
            Finally
                EndUpdate()
            End Try
        End Sub
    End Class
End Namespace
