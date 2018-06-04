
Imports TANK.My
Public Class Steel
    Inherits Module1
    Private Shared imgSteel As Image = Resources.steels

    Public Sub New(ByVal x As Integer, ByVal y As Integer)
        MyBase.New(x, y, imgSteel.Width, imgSteel.Height)
    End Sub
    Public Overrides Sub Draw(ByVal g As Graphics)
        g.DrawImage(imgSteel, Me.rx, Me.ry)
    End Sub
End Class

