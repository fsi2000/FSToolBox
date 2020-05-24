Namespace Math
	Public Class BitsAndBytes
		'Get the Byte where a given bit is (starting at 0)
		'Example: GetByteFromBit(0) => 0
		'Example: GetByteFromBit(8) => 1
		Public Shared Function GetByteFromBit(bit As Integer) As Integer
			Return bit \ 8
		End Function

		Public Function IsBitSet(data As Integer, bit As Integer) As Boolean
			Dim wertigkeit As Integer
			Dim i As Integer

			wertigkeit = 0
			For i = 0 To bit - 1
				If wertigkeit = 0 Then
					wertigkeit = 1
				Else
					wertigkeit = wertigkeit * 2
				End If
			Next

			'Return (data And wertigkeit)
			Return True
		End Function
	End Class
End Namespace

