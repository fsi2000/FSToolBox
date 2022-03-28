Namespace UserManager
	Public Class Role
		Public Structure Role
			Dim id As String
			Dim description As String
		End Structure

		Public Roles As List(Of Role)
		Private _exception As Exception

		Public Sub New()
			Roles = New List(Of Role)
		End Sub

		Private Property Exception(p1 As String) As Exception
			Get
				Return _exception
			End Get
			Set(value As Exception)
				_exception = value
			End Set
		End Property

		Public Sub Add(id As String, description As String)
			Dim tmp As Role
			tmp = New Role
			tmp.id = id
			tmp.description = description

			Roles.Add(tmp)
		End Sub

		Public Sub Clear()
			Roles.Clear()
		End Sub

		Public Sub Remove(id As String)
			Throw Exception("not implemented")          'TODO
		End Sub

		Public Shared Widening Operator CType(v As List(Of UserManager.Role)) As UserManager.Role
			Throw New NotImplementedException()
		End Operator
	End Class
End Namespace
