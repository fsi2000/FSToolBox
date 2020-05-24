Namespace Windows.Cursor
  Public Class Position
		Private Structure POINTAPI
			Dim x As Long
			Dim y As Long
		End Structure

		Private Declare Function GetCursorPos Lib "user32" (ByRef point As POINTAPI) As Long
		Private Declare Function SetCursorPos Lib "user32" (ByVal x As Long, ByVal y As Long) As Long

		Public X As Long
		Public Y As Long

		Public Sub GetCursorPosition()
			Dim l As Long
			Dim p As POINTAPI

			l = GetCursorPos(p)
			Me.X = p.x
			Me.Y = p.y
		End Sub

		Public Sub SetCursorPosition()
			SetCursorPos(Me.X, Me.Y)
		End Sub

		Public Sub SetCursorPosition(x As Long, y As Long)
			Me.X = x
			Me.Y = y

			Me.SetCursorPosition()
		End Sub

	End Class
End Namespace
