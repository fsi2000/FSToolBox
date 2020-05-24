Public Class RingBufferInteger
	Private prvBufferData As List(Of Integer)
	Private prvBufferPosition As Integer
	Private prvBufferSize As Integer
	Private prvValueMinimum As Integer
	Private prvValueMaximum As Integer
	Private prvDirty As Boolean

	Public Sub New()                          'default constructor
		prvBufferData = New List(Of Integer)        'create list
		prvDirty = True
	End Sub

	Public Sub New(ByVal bufferSize As Integer)
		Me.New()          'call default constructor
		Me.BufferSize = bufferSize          'set buffersize
	End Sub

	Protected Overrides Sub Finalize()
		MyBase.Finalize()
		prvBufferData.Clear()                       'clear buffer
	End Sub

	Property BufferSize() As Integer
		Get
			Return prvBufferSize
		End Get
		Set(ByVal value As Integer)
			prvDirty = True                               'set dirty, because min/max are wrong
			prvBufferSize = value
			InitializeBuffer()                'clear and init buffer
		End Set
	End Property

	Private Sub InitializeBuffer()
		Dim i As Integer
		prvBufferData.Clear()                       'clear buffer 
		For i = 0 To Me.BufferSize - 1        'initialize buffer with initValue
			prvBufferData.Add(0)                          'add "empty" integer
		Next
	End Sub

	Private Sub NextBufferPosition()
		prvBufferPosition = prvBufferPosition + 1       'get next buffer position
		If prvBufferPosition = prvBufferSize Then       'because index starts with 0 :)
			prvBufferPosition = 0             'reset buffer position to first element
		End If
	End Sub

	Public Sub Add(ByVal value As Integer)
		prvDirty = True                               'set dirty, because min/max are wrong
		prvBufferData(prvBufferPosition) = value          'save item
		NextBufferPosition()            'go to next position
	End Sub

	ReadOnly Property Buffer(ByVal index As Integer) As Integer
		Get
			Return prvBufferData((prvBufferPosition + index) Mod prvBufferSize)
		End Get
	End Property

	Private Function CalcMin() As Integer
		Dim i As Integer
		Dim result As Integer

		result = Integer.MaxValue         'set result to maximum possble value

		For i = 0 To prvBufferData.Count - 1          'iterate throug all items
			If prvBufferData(i) < result Then         'if smaller than result
				result = prvBufferData(i)       'save it
			End If
		Next

		Return result       'and return it
	End Function

	Private Function CalcMax() As Integer
		Dim i As Integer
		Dim result As Integer

		result = Integer.MinValue         'set result to minimum possble value

		For i = 0 To prvBufferData.Count - 1          'iterate throug all items
			If prvBufferData(i) > result Then         'if bigger than result
				result = prvBufferData(i)       'save it
			End If
		Next

		Return result       'and return it
	End Function


	ReadOnly Property Minimum() As Integer
		Get
			If prvDirty Then
				prvValueMinimum = CalcMin()
				prvDirty = False
			End If
			Return prvValueMinimum
		End Get
	End Property

	ReadOnly Property Maximum() As Integer
		Get
			If prvDirty Then
				prvValueMaximum = CalcMax()
				prvDirty = False
			End If
			Return prvValueMaximum
		End Get
	End Property

End Class
