Imports TANK.My
Public Class enemyMissile
    Inherits Missile
    Private Shared imgEnemyMissile As Image = Resources.enemymissile
    Public Sub New(ByVal role As Roles, ByVal life As Integer, ByVal speed As Integer, ByVal power As Integer)
        MyBase.New(role, life, imgEnemyMissile.Width, imgEnemyMissile.Height, speed, power)
    End Sub
    Public Overrides Sub Draw(ByVal g As Graphics)
        MyBase.Move()
        g.DrawImage(imgEnemyMissile, Me.rx, Me.ry)
    End Sub
End Class
