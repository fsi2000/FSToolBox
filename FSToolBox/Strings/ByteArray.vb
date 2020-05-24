Namespace Strings
	Public Class ByteArray
		Public Shared Function StringToByteArray(s As String) As Byte()
			Return System.Text.Encoding.Default.GetBytes(s)
		End Function

		Public Shared Function ByteArrayToString(b As Byte()) As String
			Return System.Text.Encoding.Default.GetString(b)
		End Function
	End Class
End Namespace

