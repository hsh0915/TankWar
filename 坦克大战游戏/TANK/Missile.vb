Public MustInherit Class Missile
    Inherits Member
    Public power As Integer '子弹的威力
    Public Sub New(ByVal role As Roles, ByVal life As Integer, ByVal width As Integer, ByVal height As Integer, ByVal speed As Integer, ByVal power As Integer)
        ' If role.dir = Direction.directions.U Then
        'MyBase.New(role.rx + role.rWidth / 2 - 6, role.ry + role.rHeight / 2 - 6, life, speed, width, height, role.dir)
        MyBase.New(role.rx, role.ry, life, speed, width, height, role.dir, False)
        'End If
        Me.power = power
    End Sub
    Public Overrides Sub Move() ''''子弹的移动方法
        If ((Me.rx < 0) OrElse ((Me.ry < 0) OrElse ((Me.rx > 660) OrElse (Me.ry > 660)))) Then '当子弹出了边界
            rLife = 0        '''' 生命为0
        End If
        Adjustdirection()      ''''调整子弹的移动
    End Sub
End Class
