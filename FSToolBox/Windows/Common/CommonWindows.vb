Imports System.Runtime.InteropServices

Namespace Windows.Common
  Public Class Windows

    <DllImport("user32.dll")>
    Private Shared Sub LockWorkStation()
    End Sub

    Public Sub Lock()
      LockWorkStation()
    End Sub
  End Class
End Namespace