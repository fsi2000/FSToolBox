Namespace Booleans
	Public Class Bytes
		Public Shared Function ByteToBoolean(b As Byte) As Boolean
			Return b <> 0
		End Function

		Public Shared Function BooleanToByte(b As Boolean) As Byte
			Dim result As Byte

			If b Then
				result = 1
			Else
				result = 0
			End If

			Return result
		End Function
	End Class
End Namespace

