Namespace UserManager
	Public Class User
		Public UserName As String
		Public FirstName As String
		Public LastName As String
		Public Roles As Role

		Public Sub New()
			Roles = New List(Of UserManager.Role)
		End Sub
	End Class
End Namespace
