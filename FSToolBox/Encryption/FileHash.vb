Namespace Encryption
	Public Class FileHash
		Public Function FileProperties(filename As String) As String
			Dim fi As IO.FileInfo
			Dim h As Hash
			Dim result As String

			h = New Hash()
			fi = New IO.FileInfo(filename)

			result = h.HashString(fi.Name + fi.Length.ToString + fi.LastWriteTime.ToString)

			Return result
		End Function
	End Class
End Namespace