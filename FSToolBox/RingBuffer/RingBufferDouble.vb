Namespace RingBuffer
	Public Class RingBufferDouble
		Private prvBufferData As List(Of Double)
		Private prvBufferPosition As Integer
		Private prvBufferSize As Integer
		Private prvValueMinimum As Double
		Private prvDirtyMinimum As Boolean
		Private prvValueMaximum As Double
		Private prvDirtyMaximum As Boolean

		Public Sub New()                          'default constructor
			prvBufferData = New List(Of Double)       'create list
			prvDirtyMinimum = True
			prvDirtyMaximum = True
		End Sub

		Public Sub New(ByVal bufferSize As Integer)
			Me.New()                                  'call default constructor
			Me.BufferSize = bufferSize          'set buffersize
		End Sub

		Protected Overrides Sub Finalize()
			MyBase.Finalize()
			prvBufferData.Clear()                                       'clear buffer
		End Sub

		Property BufferSize() As Integer
			Get
				Return prvBufferSize
			End Get
			Set(ByVal value As Integer)
				prvDirtyMinimum = True                'set dirty, because min/max are wrong
				prvDirtyMaximum = True                  'set dirty, because min/max are wrong
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

		Public Sub Add(ByVal value As Double)
			prvDirtyMinimum = True                                'set dirty, because min/max are wrong
			prvDirtyMaximum = True                                'set dirty, because min/max are wrong
			prvBufferData(prvBufferPosition) = value          'save item
			NextBufferPosition()            'go to next position
		End Sub

		ReadOnly Property Buffer(index As Integer) As Double
			Get
				Return prvBufferData((prvBufferPosition + index) Mod prvBufferSize)
			End Get
		End Property

		Private Function CalcMin() As Double
			Dim i As Integer
			Dim result As Double

			result = Double.MaxValue          'set result to maximum possble value

			For i = 0 To prvBufferData.Count - 1          'iterate throug all items
				If prvBufferData(i) < result Then         'if smaller than result
					result = prvBufferData(i)       'save it
				End If
			Next

			Return result       'and return it
		End Function

		Private Function CalcMax() As Double
			Dim i As Integer
			Dim result As Double

			result = Double.MinValue          'set result to minimum possble value

			For i = 0 To prvBufferData.Count - 1          'iterate throug all items
				If prvBufferData(i) > result Then         'if bigger than result
					result = prvBufferData(i)       'save it
				End If
			Next

			Return result       'and return it
		End Function


		ReadOnly Property Minimum As Double
			Get
				If prvDirtyMinimum Then
					prvValueMinimum = CalcMin()
					prvDirtyMinimum = False
				End If
				Return prvValueMinimum
			End Get
		End Property

		ReadOnly Property Maximum As Double
			Get
				If prvDirtyMaximum Then
					prvValueMaximum = CalcMax()
					prvDirtyMaximum = False
				End If
				Return prvValueMaximum
			End Get
		End Property

	End Class
End Namespace
