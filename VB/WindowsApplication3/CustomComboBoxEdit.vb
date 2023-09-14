Imports System.Drawing
Imports DevExpress.XtraEditors
Imports System.ComponentModel
Imports DevExpress.XtraEditors.Drawing
Imports DevExpress.XtraEditors.Popup
Imports DevExpress.Utils.Drawing

Namespace DXSample

    Public Class CustomEdit
        Inherits ComboBoxEdit

        Shared Sub New()
            RepositoryItemCustomEdit.RegisterCustomEdit()
        End Sub

        Public Sub New()
        End Sub

        Public Overrides ReadOnly Property EditorTypeName As String
            Get
                Return RepositoryItemCustomEdit.CustomEditName
            End Get
        End Property

        <DesignerSerializationVisibility(DesignerSerializationVisibility.Content)>
        Public Overloads ReadOnly Property Properties As RepositoryItemCustomEdit
            Get
                Return TryCast(MyBase.Properties, RepositoryItemCustomEdit)
            End Get
        End Property

        Protected Overrides Function CreatePopupForm() As PopupBaseForm
            Return New CustomPopupForm(Me)
        End Function
    End Class
End Namespace
