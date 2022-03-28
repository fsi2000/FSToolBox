Module Mathematics
	Function LinearInterpolation(ByVal x As Double, ByVal a As Double, ByVal b As Double, ByVal c As Double, ByVal d As Double) As Double
		Dim result As Double
		Dim factor As Double

		factor = (b - a) / (d - c)
		If factor = 0 Then
			result = 0
		Else
			result = (x - a) / factor
		End If

		Return result
	End Function
End Module
