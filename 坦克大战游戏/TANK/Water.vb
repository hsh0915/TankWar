Imports TANK.My
Public Class Water
    Inherits Module1
    Private Shared imgWater As Image = Resources.water

    Public Sub New(ByVal x As Integer, ByVal y As Integer)
        MyBase.New(x, y, imgWater.Width, imgWater.Height)
    End Sub
    Public Overrides Sub Draw(ByVal g As Graphics)
        g.DrawImage(imgWater, Me.rx, Me.ry)
    End Sub
End Class
