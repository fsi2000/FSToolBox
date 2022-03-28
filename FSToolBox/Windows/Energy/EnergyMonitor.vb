Imports System.Runtime.InteropServices

Namespace Windows.Energy
  Public Class Monitor
    Private Const WM_SYSCOMMAND As Integer = &H112
    Private Const SC_MONITORPOWER As Integer = &HF170

    Private Const MONITOR_ON As Integer = -1
    Private Const MONITOR_OFF As Integer = 2
    Private Const MONITOR_STANDBY As Integer = 1

    Public Enum MonitorStates As Integer
      StateOn = -1
      StateOff = 2
      StateStandby = 1
    End Enum

    Private myHWnd As Int32 = 0

    <DllImport("user32.dll", SetLastError:=True)> Private Shared Function SendMessage(ByVal hWnd As Integer, ByVal hMsg As Integer, ByVal wParam As Integer, ByVal lParam As Integer) As Integer
    End Function

    Public Sub SetHandle(hWnd As Int32)
      'SetHandle(Me.Handle.ToInt32())
      myHWnd = hWnd
    End Sub

    Public Sub SetMonitorState(hWnd As Int32, state As MonitorStates)
      'Example MonitorState(,StateOn)

      Select Case state
        Case MonitorStates.StateOn
          SendMessage(hWnd, WM_SYSCOMMAND, SC_MONITORPOWER, MONITOR_ON)
        Case MonitorStates.StateOff
          SendMessage(hWnd, WM_SYSCOMMAND, SC_MONITORPOWER, MONITOR_OFF)
        Case MonitorStates.StateStandby
          SendMessage(hWnd, WM_SYSCOMMAND, SC_MONITORPOWER, MONITOR_STANDBY)
      End Select
    End Sub


    Public Sub MonitorOn()
      SetMonitorState(myHWnd, MonitorStates.StateOn)
    End Sub

    Public Sub MonitorOff()
      SetMonitorState(myHWnd, MonitorStates.StateOff)
    End Sub

    Public Sub MonitorStandby()
      SetMonitorState(myHWnd, MonitorStates.StateStandby)
    End Sub
  End Class
End Namespace