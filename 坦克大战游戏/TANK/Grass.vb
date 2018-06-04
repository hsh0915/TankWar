Imports TANK.My
Public Class Grass
    Inherits Module1
    Private Shared imgGrass As Image = Resources.grass

    Public Sub New(ByVal x As Integer, ByVal y As Integer)
        MyBase.New(x, y, imgGrass.Width, imgGrass.Height)
    End Sub
    Public Overrides Sub Draw(ByVal g As Graphics)
        g.DrawImage(imgGrass, Me.rx, Me.ry)
    End Sub
End Class

