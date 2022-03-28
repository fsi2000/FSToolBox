Namespace Encryption
	Public Class Hash
		Public Enum HashMethods
			MD5 = 1
			SHA1 = 2
			SHA256 = 4
			SHA384 = 8
			SHA512 = 16
		End Enum

		Private myHashMethod As Encryption.Hash.HashMethods

		Public Sub New()
			myHashMethod = HashMethods.MD5
		End Sub

		Public Sub New(hashMethod As HashMethods)
			Me.New()
			hashMethod = hashMethod
		End Sub

		Public Function HashString(ByRef s As String) As String
			Return HashString(s, myHashMethod)
		End Function

		Public Function HashString(ByRef s As String, ByRef method As HashMethods) As String
			Dim data As Byte()
			Dim result As Byte()
			Dim hex As Strings.Hexadecimal

			data = System.Text.Encoding.ASCII.GetBytes(s)
			result = data

			Select Case method
				Case HashMethods.MD5
					Dim cryptoServiceMD5 As New System.Security.Cryptography.MD5CryptoServiceProvider
					result = cryptoServiceMD5.ComputeHash(data)
				Case HashMethods.SHA1
					Dim cryptoServiceSHA1 As New System.Security.Cryptography.SHA1CryptoServiceProvider
					result = cryptoServiceSHA1.ComputeHash(data)
				Case HashMethods.SHA256
					Dim cryptoServiceSHA256 As New System.Security.Cryptography.SHA256CryptoServiceProvider
					result = cryptoServiceSHA256.ComputeHash(data)
				Case HashMethods.SHA384
					Dim cryptoServiceSHA384 As New System.Security.Cryptography.SHA384CryptoServiceProvider
					result = cryptoServiceSHA384.ComputeHash(data)
				Case HashMethods.SHA512
					Dim cryptoServiceSHA512 As New System.Security.Cryptography.SHA512CryptoServiceProvider
					result = cryptoServiceSHA512.ComputeHash(data)
			End Select

			hex = New FSToolBox.Strings.Hexadecimal
			Return hex.ByteArrayToHexadecimal(result)
		End Function

		Public Function HashStringMD5(ByRef s As String) As String
			Return HashString(s, HashMethods.MD5)
		End Function

		Public Function HashStringSHA1(ByRef s As String) As String
			Return HashString(s, HashMethods.SHA1)
		End Function

		Public Function HashStringSHA256(ByRef s As String) As String
			Return HashString(s, HashMethods.SHA256)
		End Function

		Public Function HashStringSHA384(ByRef s As String) As String
			Return HashString(s, HashMethods.SHA384)
		End Function

		Public Function HashStringSHA512(ByRef s As String) As String
			Return HashString(s, HashMethods.SHA512)
		End Function
	End Class
End Namespace