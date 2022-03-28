Namespace Simple
  Public Class Template
    Public Structure Placeholder
      Dim id As String
      Dim value As String
    End Structure

    Public Placeholders As List(Of Placeholder)

    Private _PlaceholderTag1 As String
    Private _PlaceholderTag2 As String
    Private _exception As Exception

    Public Sub New()
      _PlaceholderTag1 = "###"
      _PlaceholderTag2 = "###"
      Placeholders = New List(Of Placeholder)
    End Sub

    Public Property PlaceholderTag1 As String
      Get
        Return _PlaceholderTag1
      End Get
      Set(value As String)
        _PlaceholderTag1 = value
      End Set
    End Property
    Public Property PlaceholderTag2 As String
      Get
        Return _PlaceholderTag2
      End Get
      Set(value As String)
        _PlaceholderTag2 = value
      End Set
    End Property

    Private Property Exception(p1 As String) As Exception
      Get
        Return _exception
      End Get
      Set(value As Exception)
        _exception = value
      End Set
    End Property

    Public Sub Add(id As String, value As String)
			Dim tmp As Placeholder
			tmp = New Placeholder
			tmp.id = Me.PlaceholderTag1 + id + Me.PlaceholderTag2
			tmp.value = value

			Placeholders.Add(tmp)
		End Sub

    Public Sub Clear()
      Placeholders.Clear()
    End Sub

    Public Sub Remove(id As String)
			Throw Exception("not implemented")          'TODO
		End Sub

    Public Function Render(s As String) As String
      Dim result As String

      result = s
      For Each item As Placeholder In Placeholders
        result = result.Replace(item.id, item.value)
      Next
      Return result
    End Function

  End Class
End Namespace