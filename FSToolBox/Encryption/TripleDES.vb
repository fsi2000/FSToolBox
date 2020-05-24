﻿Namespace Encryption
  Public NotInheritable Class TripleDES
    Private serviceProvider As New System.Security.Cryptography.TripleDESCryptoServiceProvider

    Private Function TruncateHash(ByVal key As String, ByVal length As Integer) As Byte()
      Dim sha1 As New System.Security.Cryptography.SHA1CryptoServiceProvider

      ' Hash the key.
      Dim keyBytes() As Byte = System.Text.Encoding.Unicode.GetBytes(key)
      Dim hash() As Byte = sha1.ComputeHash(keyBytes)

      ' Truncate or pad the hash.
      ReDim Preserve hash(length - 1)
      Return hash
    End Function

    Sub New(ByVal key As String)
      ' Initialize the crypto provider.
      serviceProvider.Key = TruncateHash(key, serviceProvider.KeySize \ 8)
      serviceProvider.IV = TruncateHash("", serviceProvider.BlockSize \ 8)
    End Sub

    Public Function EncryptData(ByVal plaintext As String) As String
      ' Convert the plaintext string to a byte array.
      Dim plaintextBytes() As Byte = System.Text.Encoding.Unicode.GetBytes(plaintext)

      ' Create the stream.
      Dim ms As New System.IO.MemoryStream
      ' Create the encoder to write to the stream.
      Dim encStream As New System.Security.Cryptography.CryptoStream(ms, serviceProvider.CreateEncryptor(), System.Security.Cryptography.CryptoStreamMode.Write)

      ' Use the crypto stream to write the byte array to the stream.
      encStream.Write(plaintextBytes, 0, plaintextBytes.Length)
      encStream.FlushFinalBlock()

      ' Convert the encrypted stream to a printable string.
      Return Convert.ToBase64String(ms.ToArray)
    End Function

    Public Function DecryptData(ByVal encryptedtext As String) As String
      ' Convert the encrypted text string to a byte array.
      Dim encryptedBytes() As Byte = Convert.FromBase64String(encryptedtext)

      ' Create the stream.
      Dim ms As New System.IO.MemoryStream
      ' Create the decoder to write to the stream.
      Dim decStream As New System.Security.Cryptography.CryptoStream(ms, serviceProvider.CreateDecryptor(), System.Security.Cryptography.CryptoStreamMode.Write)

      ' Use the crypto stream to write the byte array to the stream.
      decStream.Write(encryptedBytes, 0, encryptedBytes.Length)
      decStream.FlushFinalBlock()

      ' Convert the plaintext stream to a string.
      Return System.Text.Encoding.Unicode.GetString(ms.ToArray)
    End Function
  End Class
End Namespace