Module AutoLogonSwitcher
	Public Sub SetAutoLogon(ByVal enable As Boolean, ByVal username As String, ByVal password As String, ByVal domain As String)
		Dim key As Microsoft.Win32.RegistryKey
		Const regKeyWinLogon As String = "Software\Microsoft\Windows NT\CurrentVersion\Winlogon"

		key = Microsoft.Win32.Registry.LocalMachine.OpenSubKey(regKeyWinLogon, True)

		Try
			If enable Then key.SetValue("AutoAdminLogon", 1) Else key.SetValue("AutoAdminLogon", 0)
			key.SetValue("DefaultUserName", username)
			key.SetValue("DefaultPassword", password)
			key.SetValue("DefaultDomainName", domain)
		Catch e As Exception
			MessageBox.Show(e.Message)
		End Try

	End Sub

End Module
