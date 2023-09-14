Imports System
Imports System.Windows.Forms
Imports System.Drawing
Imports DevExpress.XtraEditors
Imports System.ComponentModel
Imports DevExpress.XtraEditors.Drawing
Imports DevExpress.XtraEditors.Popup
Imports DevExpress.Utils.Drawing

Namespace DXSample

    Public Class CustomPopupForm
        Inherits PopupListBoxForm

        Private closeBtn As CloseButton = Nothing

        Private closeButtonSize, clearButtonSize As Size

        Private clearButtonRectangleField As Rectangle = Rectangle.Empty

        Private isHotTrackClearButtonField As Boolean = False

        Public Sub New(ByVal edit As ComboBoxEdit)
            MyBase.New(edit)
            If OwnerEdit.Properties.ShowCloseButton Then
                closeBtn = New CloseButton()
                closeBtn.Parent = Me
                AddHandler closeBtn.Click, AddressOf OnCloseButtonClick
                closeButtonSize = New Size(16, 16)
            End If

            If OwnerEdit.Properties.ShowClearButton Then clearButtonSize = New Size(35, 16)
        End Sub

        Friend ReadOnly Property ClearButtonRectangle As Rectangle
            Get
                Return clearButtonRectangleField
            End Get
        End Property

        Friend Property IsHotTrackClearButton As Boolean
            Get
                Return isHotTrackClearButtonField
            End Get

            Set(ByVal value As Boolean)
                If isHotTrackClearButtonField <> value Then
                    isHotTrackClearButtonField = value
                    Invalidate()
                End If
            End Set
        End Property

        Public Overloads ReadOnly Property OwnerEdit As CustomEdit
            Get
                Return TryCast(MyBase.OwnerEdit, CustomEdit)
            End Get
        End Property

        Public Overrides Property AllowSizing As Boolean
            Get
                Return True
            End Get

            Set(ByVal value As Boolean)
                MyBase.AllowSizing = value
            End Set
        End Property

        Private Sub OnCloseButtonClick(ByVal sender As Object, ByVal e As EventArgs)
            ClosePopup(PopupCloseMode.Cancel)
        End Sub

        Protected Overrides Sub SetupListBoxOnShow()
            MyBase.SetupListBoxOnShow()
            UpdateClearButtonBounds()
            UpdateCloseButtonBounds()
        End Sub

        Private Sub UpdateClearButtonBounds()
            If OwnerEdit.Properties.ShowClearButton Then clearButtonRectangleField = New Rectangle(ViewInfo.SizeBarRect.X + closeButtonSize.Width + 2, ViewInfo.SizeBarRect.Y + 4, clearButtonSize.Width, clearButtonSize.Height)
        End Sub

        Private Sub UpdateCloseButtonBounds()
            If closeBtn IsNot Nothing Then closeBtn.SetBounds(ViewInfo.SizeBarRect.X, ViewInfo.SizeBarRect.Y + 2, closeButtonSize.Width, closeButtonSize.Height)
        End Sub

        Protected Overrides Sub UpdateControlPositionsCore()
            MyBase.UpdateControlPositionsCore()
            UpdateCloseButtonBounds()
            UpdateClearButtonBounds()
        End Sub

        Protected Overrides Sub OnMouseMove(ByVal e As MouseEventArgs)
            MyBase.OnMouseMove(e)
            IsHotTrackClearButton = ClearButtonRectangle.Contains(e.Location)
        End Sub

        Protected Overrides Sub OnMouseDown(ByVal e As MouseEventArgs)
            MyBase.OnMouseDown(e)
            If ClearButtonRectangle.Contains(e.Location) Then
                ClosePopup(PopupCloseMode.Normal)
                OwnerEdit.EditValue = Nothing
            End If
        End Sub

        Protected Overrides Sub OnVisibleChanged(ByVal e As EventArgs)
            MyBase.OnVisibleChanged(e)
            IsHotTrackClearButton = False
        End Sub

        Protected Overrides Function CreatePainter() As PopupBaseFormPainter
            Return New CustomPopupBaseSizeableFormPainter()
        End Function

        Protected Overrides Sub Dispose(ByVal disposing As Boolean)
            If disposing AndAlso closeBtn IsNot Nothing Then RemoveHandler closeBtn.Click, AddressOf OnCloseButtonClick
            MyBase.Dispose(disposing)
        End Sub
    End Class
End Namespace
