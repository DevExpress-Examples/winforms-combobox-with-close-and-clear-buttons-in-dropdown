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
	Public Class CustomPopupBaseSizeableFormPainter
		Inherits PopupBaseSizeableFormPainter
		Public Sub New()
			MyBase.New()
		End Sub
		Protected Overrides Sub DrawSizeBar(ByVal info As PopupFormGraphicsInfoArgs)
			MyBase.DrawSizeBar(info)
			Dim form As CustomPopupForm = TryCast(info.ViewInfo.Form, CustomPopupForm)
			DrawClear(form.IsHotTrackClearButton, form.Appearance, info.Cache, form.ClearButtonRectangle)
		End Sub
		Protected Sub DrawClear(ByVal isHot As Boolean, ByVal app As AppearanceObject, ByVal cache As GraphicsCache, ByVal rect As Rectangle)
			If rect.IsEmpty Then
				Return
			End If
			Dim br As Brush = app.GetForeBrush(cache)
			If isHot Then
				Dim skin As New SkinElementInfo(CommonSkins.GetSkin(DevExpress.LookAndFeel.UserLookAndFeel.Default.ActiveLookAndFeel)(CommonSkins.SkinHighlightedItem), rect)
				br = New SolidBrush(DevExpress.LookAndFeel.LookAndFeelHelper.GetSystemColor(DevExpress.LookAndFeel.UserLookAndFeel.Default.ActiveLookAndFeel, SystemColors.HotTrack))
				ObjectPainter.DrawObject(cache, SkinElementPainter.Default, skin)
			End If
			Dim format As New StringFormat()
			format.Alignment = StringAlignment.Center
			cache.DrawString("Clear", app.Font, br, rect, format)
		End Sub
	End Class
End Namespace