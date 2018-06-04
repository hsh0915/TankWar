Imports TANK.My
Public Class Snow
    Inherits Module1
    Private Shared imgSnow As Image = Resources.snow

    Public Sub New(ByVal x As Integer, ByVal y As Integer)
        MyBase.New(x, y, imgSnow.Width, imgSnow.Height)
    End Sub
    Public Overrides Sub Draw(ByVal g As Graphics)
        g.DrawImage(imgSnow, Me.rx, Me.ry)
    End Sub
End Class