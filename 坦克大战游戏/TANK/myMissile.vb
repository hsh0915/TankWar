
Imports TANK.My
Public Class myMissile
    Inherits Missile
    Private Shared imgMyMissile As Image = Resources.tankmissile
    Public Sub New(ByVal role As Roles, ByVal life As Integer, ByVal speed As Integer, ByVal power As Integer)
        MyBase.New(role, life, imgMyMissile.Width, imgMyMissile.Height, speed, power)
        'If dir = Direction.directions.R Then 
        'rWidth = role.rWidth / 2
        ' End If
    End Sub
    Public Overrides Sub Draw(ByVal g As Graphics)
        MyBase.Move()
        g.DrawImage(imgMyMissile, Me.rx, Me.ry)
    End Sub
End Class

