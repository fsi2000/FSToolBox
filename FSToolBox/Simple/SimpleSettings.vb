Imports System.Windows.Forms

Namespace Simple
  Public Class Settings
    Private key As String
		Private path As String
		Private extension As String
		Private crypt As Encryption.TripleDES
    Private hash As Encryption.Hash
		Private prvEncryption As Boolean
		Private prvDebug As Boolean

		Public Sub New(ByVal key As String, ByVal path As String)
			Me.crypt = New Encryption.TripleDES(key)
			Me.hash = New Encryption.Hash(Encryption.Hash.HashMethods.MD5)
			Me.extension = ".txt"
			Me.path = path
			Me.prvEncryption = False
			Me.prvDebug = False
		End Sub

		Private Function GetFilename(ByVal controlName As String, ByVal prefix As String) As String
			Dim result As String
			If prvEncryption Then
				result = My.Computer.FileSystem.CombinePath(Me.path, hash.HashString(prefix + controlName) + Me.extension)
			Else
				result = My.Computer.FileSystem.CombinePath(Me.path, prefix + "-" + controlName + Me.extension)
			End If
			Return result
		End Function

		Public Property Encrypted As Boolean
			Get
				Return prvEncryption
			End Get
			Set(value As Boolean)
				prvEncryption = value
			End Set
		End Property

		Public Property Debug As Boolean
			Get
				Return prvDebug
			End Get
			Set(value As Boolean)
				prvDebug = value
			End Set
		End Property

#Region "TextBox"
		Public Sub LoadTextBox(ByVal control As TextBox, ByVal prefix As String)
			Dim sr As IO.StreamReader
			Dim filename As String
			Dim s As String

			filename = GetFilename(control.Name, prefix)

			If My.Computer.FileSystem.FileExists(filename) Then
				sr = New IO.StreamReader(filename)
				s = sr.ReadLine
				If prvEncryption Then s = crypt.DecryptData(s) 'decrypt if not in debug mode
				sr.Close()

				control.Text = s
			End If
		End Sub
		Public Sub SaveTextBox(ByVal control As TextBox, ByVal prefix As String)
			Dim sw As IO.StreamWriter
			Dim s As String

			sw = New IO.StreamWriter(GetFilename(control.Name, prefix))

			s = control.Text
			If prvEncryption Then s = crypt.EncryptData(s)
			sw.WriteLine(s)

			If prvDebug Then
				sw.WriteLine("")
				sw.WriteLine("")
				sw.WriteLine("")
				sw.WriteLine(prefix)
				sw.WriteLine(control.Name)
				sw.WriteLine(Now.ToString())
			End If

			sw.Close()
		End Sub
#End Region

#Region "ComboBox"
		Public Sub LoadComboBox(ByVal control As ComboBox, ByVal prefix As String)
			Dim sr As IO.StreamReader
			Dim filename As String
			Dim s As String
			Dim i As Integer

			filename = GetFilename(control.Name, prefix)

			If My.Computer.FileSystem.FileExists(filename) Then
				sr = New IO.StreamReader(filename)
				s = sr.ReadLine
				If prvEncryption Then s = crypt.DecryptData(s)
				i = Integer.Parse(s)
				sr.Close()

				control.SelectedIndex = i
			End If
		End Sub
		Public Sub SaveComboBox(ByVal control As ComboBox, ByVal prefix As String)
			Dim sw As IO.StreamWriter
			Dim s As String

			sw = New IO.StreamWriter(GetFilename(control.Name, prefix))

			s = control.SelectedIndex.ToString
			If prvEncryption Then s = crypt.EncryptData(s)
			sw.WriteLine(s)

			If prvDebug Then
				sw.WriteLine("")
				sw.WriteLine("")
				sw.WriteLine("")
				sw.WriteLine(prefix)
				sw.WriteLine(control.Name)
				sw.WriteLine(Now.ToString())
			End If

			sw.Close()
		End Sub
#End Region

#Region "ListBox"
		Public Sub LoadListBox(ByVal control As ListBox, ByVal prefix As String)
			Dim sr As IO.StreamReader
			Dim filename As String
			Dim s As String
			Dim count As Integer
			Dim i As Integer

			filename = GetFilename(control.Name, prefix)

			If My.Computer.FileSystem.FileExists(filename) Then
				control.Items.Clear()         'clear all items

				sr = New IO.StreamReader(filename)
				s = sr.ReadLine
				If prvEncryption Then s = crypt.DecryptData(s)
				count = Integer.Parse(s)

				For i = 0 To count - 1
					s = sr.ReadLine         'read line
					If prvEncryption Then s = crypt.DecryptData(s) 'decrypt it
					control.Items.Add(s)        'add to list
				Next
				sr.Close()
			End If
		End Sub
		Public Sub SaveListBox(ByVal control As ListBox, ByVal prefix As String)
			Dim sw As IO.StreamWriter
			Dim s As String
			Dim i As Integer

			sw = New IO.StreamWriter(GetFilename(control.Name, prefix))

			i = control.Items.Count         'get item count
			s = i.ToString
			If prvEncryption Then s = crypt.EncryptData(s) 'encrypt if needed
			sw.WriteLine(s)         'save number of lines

			For i = 0 To control.Items.Count - 1
				s = control.Items(i).ToString
				If prvEncryption Then s = crypt.EncryptData(s)
				sw.WriteLine(s)
			Next
			If prvDebug Then
				sw.WriteLine("")
				sw.WriteLine("")
				sw.WriteLine("")
				sw.WriteLine(prefix)
				sw.WriteLine(control.Name)
				sw.WriteLine(Now.ToString())
			End If
			sw.Close()
    End Sub
#End Region

#Region "Label"
		Public Sub LoadLabel(ByVal control As Label, ByVal prefix As String)
			Dim sr As IO.StreamReader
			Dim filename As String
			Dim s As String

			filename = GetFilename(control.Name, prefix)

			If My.Computer.FileSystem.FileExists(filename) Then
				sr = New IO.StreamReader(filename)
				s = sr.ReadLine
				If prvEncryption Then s = crypt.DecryptData(s) 'decrypt if not in debug mode
				sr.Close()

				control.Text = s
			End If
		End Sub
		Public Sub SaveLabel(ByVal control As Label, ByVal prefix As String)
			Dim sw As IO.StreamWriter
			Dim s As String

			sw = New IO.StreamWriter(GetFilename(control.Name, prefix))

			s = control.Text
			If prvEncryption Then s = crypt.EncryptData(s)
			sw.WriteLine(s)

			If prvDebug Then
				sw.WriteLine("")
				sw.WriteLine("")
				sw.WriteLine("")
				sw.WriteLine(prefix)
				sw.WriteLine(control.Name)
				sw.WriteLine(Now.ToString())
			End If

			sw.Close()
		End Sub
#End Region

#Region "NumericUpDown"
		Public Sub LoadNumericUpDown(ByVal control As NumericUpDown, ByVal prefix As String)
			Dim sr As IO.StreamReader
			Dim filename As String
			Dim s As String

			filename = GetFilename(control.Name, prefix)

			If My.Computer.FileSystem.FileExists(filename) Then
				sr = New IO.StreamReader(filename)
				s = sr.ReadLine
				If prvEncryption Then s = crypt.DecryptData(s) 'decrypt if not in debug mode
				sr.Close()

				control.Value = Integer.Parse(s)
			End If
		End Sub
		Public Sub SaveNumericUpDown(ByVal control As NumericUpDown, ByVal prefix As String)
			Dim sw As IO.StreamWriter
			Dim s As String

			sw = New IO.StreamWriter(GetFilename(control.Name, prefix))

			s = control.Value.ToString
			If prvEncryption Then s = crypt.EncryptData(s)
			sw.WriteLine(s)

			If prvDebug Then
				sw.WriteLine("")
				sw.WriteLine("")
				sw.WriteLine("")
				sw.WriteLine(prefix)
				sw.WriteLine(control.Name)
				sw.WriteLine(Now.ToString())
			End If

			sw.Close()
		End Sub
#End Region

#Region "CheckBox"
		Public Sub LoadCheckBox(ByVal control As CheckBox, ByVal prefix As String)
			Dim sr As IO.StreamReader
			Dim filename As String
			Dim s As String

			filename = GetFilename(control.Name, prefix)

			If My.Computer.FileSystem.FileExists(filename) Then
				sr = New IO.StreamReader(filename)
				s = sr.ReadLine
				If prvEncryption Then s = crypt.DecryptData(s) 'decrypt if not in debug mode
				sr.Close()

				control.Checked = Boolean.Parse(s)
			End If
		End Sub
		Public Sub SaveCheckBox(ByVal control As CheckBox, ByVal prefix As String)
			Dim sw As IO.StreamWriter
			Dim s As String

			sw = New IO.StreamWriter(GetFilename(control.Name, prefix))

			s = control.Checked.ToString
			If prvEncryption Then s = crypt.EncryptData(s)
			sw.WriteLine(s)

			If prvDebug Then
				sw.WriteLine("")
				sw.WriteLine("")
				sw.WriteLine("")
				sw.WriteLine(prefix)
				sw.WriteLine(control.Name)
				sw.WriteLine(Now.ToString())
			End If

			sw.Close()
		End Sub
#End Region

#Region "String"
		Public Sub LoadString(ByVal control As String, ByVal prefix As String, ByRef data As String)
			Dim sr As IO.StreamReader
			Dim filename As String
			Dim s As String

			filename = GetFilename(control, prefix)

			If My.Computer.FileSystem.FileExists(filename) Then
				sr = New IO.StreamReader(filename)
				s = sr.ReadLine
				If prvEncryption Then s = crypt.DecryptData(s) 'decrypt if not in debug mode
				sr.Close()

				data = s
			End If
		End Sub
		Public Sub SaveString(ByVal control As String, ByVal prefix As String, ByRef data As String)
			Dim sw As IO.StreamWriter
			Dim s As String

			sw = New IO.StreamWriter(GetFilename(control, prefix))

			s = data
			If prvEncryption Then s = crypt.EncryptData(s)
			sw.WriteLine(s)

			If prvDebug Then
				sw.WriteLine("")
				sw.WriteLine("")
				sw.WriteLine("")
				sw.WriteLine(prefix)
				sw.WriteLine(control)
				sw.WriteLine(Now.ToString())
			End If

			sw.Close()
		End Sub
#End Region

#Region "Integer"
		Public Sub LoadInteger(ByVal control As String, ByVal prefix As String, ByRef data As Integer)
			Dim sr As IO.StreamReader
			Dim filename As String
			Dim s As String

			filename = GetFilename(control, prefix)

			If My.Computer.FileSystem.FileExists(filename) Then
				sr = New IO.StreamReader(filename)
				s = sr.ReadLine
				If prvEncryption Then s = crypt.DecryptData(s) 'decrypt if not in debug mode
				sr.Close()

				data = Integer.Parse(s)
			End If
		End Sub
		Public Sub SaveInteger(ByVal control As String, ByVal prefix As String, ByRef data As Integer)
			Dim sw As IO.StreamWriter
			Dim s As String

			sw = New IO.StreamWriter(GetFilename(control, prefix))

			s = data.ToString
			If prvEncryption Then s = crypt.EncryptData(s)
			sw.WriteLine(s)

			If prvDebug Then
				sw.WriteLine("")
				sw.WriteLine("")
				sw.WriteLine("")
				sw.WriteLine(prefix)
				sw.WriteLine(control)
				sw.WriteLine(Now.ToString())
			End If

			sw.Close()
		End Sub
#End Region

	End Class
End Namespace