Namespace Strings
	Public Class Hexadecimal
		Public Shared Function ByteArrayToHexadecimal(ByRef b() As Byte) As String
			Dim i As Integer
			Dim result As String = ""
			Dim s As String = ""

			For i = 0 To b.Length - 1
				s = Hex(b(i))
				If Len(s) = 1 Then s = "0" & s
				result += s
			Next

			Return result
		End Function
	End Class
End Namespace
