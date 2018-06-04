Imports TANK.My
Public Class Wall
    Inherits Module1
    Private Shared imgWall As Image = Resources.wall

    Public Sub New(ByVal x As Integer, ByVal y As Integer)
        MyBase.New(x, y, imgWall.Width, imgWall.Height)
    End Sub
    Public Overrides Sub Draw(ByVal g As Graphics)
        g.DrawImage(imgWall, Me.rx, Me.ry)
    End Sub
End Class

