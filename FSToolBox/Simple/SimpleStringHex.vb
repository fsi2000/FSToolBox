Namespace Simple
	Public Class StringHex
		Public Function StrToHex(ByRef Data As String) As String
			Dim sVal As String
			Dim sHex As String = ""
			While Data.Length > 0
				sVal = Conversion.Hex(Asc(Data.Substring(0, 1).ToString()))
				Data = Data.Substring(1, Data.Length - 1)
				sHex = sHex & sVal
			End While
			Return sHex
		End Function

		Public Function StrToHex2(ByRef Data As String) As String
			Dim sVal As String
			Dim sHex As String = ""
			While Data.Length > 0
				sVal = Data.Substring(0, 1).ToString() + "=" + Conversion.Hex(Asc(Data.Substring(0, 1).ToString())) + " "
				Data = Data.Substring(1, Data.Length - 1)
				sHex = sHex & sVal
			End While
			Return sHex
		End Function

	End Class
End Namespace