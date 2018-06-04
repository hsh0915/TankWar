Imports TANK.Direction
Imports TANK.My
Imports System.Media

Public Class Enemy
    Inherits Roles
    Private imgEnemy1() As Image = New Image() {Resources.enemy1U, Resources.enemy1D, Resources.enemy1L, Resources.enemy1R}
    Private imgEnemy2() As Image = New Image() {Resources.enemy2U, Resources.enemy2D, Resources.enemy2L, Resources.enemy2R}
    Private imgEnemy3() As Image = New Image() {Resources.enemy3U, Resources.enemy3D, Resources.enemy3L, Resources.enemy3R}
    Private type As Integer
    Private rnd As Random = New Random
    Private timer As Integer = 0
    Public Property rType() As Integer
        Get
            Return type
        End Get
        Set(value As Integer)
            type = value
        End Set
    End Property
    Private Shared speed As Integer
    Private Shared life As Integer
    Private Shared Function SetSpeed(ByVal type As Integer) As Integer
        Select Case (type)
            Case 0
                speed = 2
            Case 1
                speed = 3
            Case 2
                speed = 1
        End Select
        Return speed
    End Function
    Private Shared Function SetLife(ByVal type As Integer) As Integer
        Select Case (type)
            Case 0
                life = 1
            Case 1
                life = 2
            Case 2
                life = 3
        End Select
        Return life
    End Function
    Public Sub New(ByVal x As Integer, ByVal y As Integer, ByVal type As Integer, ByVal dir As directions)
        MyBase.New(x, y, Enemy.SetLife(type), Enemy.SetSpeed(type), 60, 60, dir)
        Me.type = type
        Beborn()
    End Sub
    Public Sub EnemyAI()
        If (rnd.Next(0, 100) < 2) Then
            Select Case (rnd.Next(0, 4))
                Case 0
                    dir = directions.U
                Case 1
                    dir = directions.D
                Case 2
                    dir = directions.L
                Case 3
                    dir = directions.R
            End Select
        End If
    End Sub
    Public Overrides Sub Move()
        If Not rEnable Then
            Return
        End If
        EnemyAI()
        Adjustdirection()
        If ((Me.rx > 600) OrElse ((Me.rx < 0) OrElse ((Me.ry > 600) OrElse (Me.ry < 0)))) Then
            Select Case (rnd.Next(0, 4))
                Case 0
                    dir = directions.U
                Case 1
                    dir = directions.D
                Case 2
                    dir = directions.L
                Case 3
                    dir = directions.R
            End Select
            MyBase.Move()
        End If
    End Sub
    Public Overrides Sub Draw(ByVal g As Graphics)

        If (rBornTimer < 12) Then
            rBornTimer += 1
            Return
        End If

        If Not rEnable Then
            timer = (timer + 1)
            If (timer = 100) Then
                rEnable = True
            End If
            If ((timer Mod 10) = 0) Then
                Return
            End If
        End If

        Move()
        Select Case (type)
            Case 0
                Select Case (dir)
                    Case directions.U
                        g.DrawImage(imgEnemy1(0), Me.rx, Me.ry)
                    Case directions.D
                        g.DrawImage(imgEnemy1(1), Me.rx, Me.ry)
                    Case directions.L
                        g.DrawImage(imgEnemy1(2), Me.rx, Me.ry)
                    Case directions.R
                        g.DrawImage(imgEnemy1(3), Me.rx, Me.ry)
                End Select
            Case 1
                Select Case (dir)
                    Case directions.U
                        g.DrawImage(imgEnemy2(0), Me.rx, Me.ry)
                    Case directions.D
                        g.DrawImage(imgEnemy2(1), Me.rx, Me.ry)
                    Case directions.L
                        g.DrawImage(imgEnemy2(2), Me.rx, Me.ry)
                    Case directions.R
                        g.DrawImage(imgEnemy2(3), Me.rx, Me.ry)
                End Select
            Case 2
                Select Case (dir)
                    Case directions.U
                        g.DrawImage(imgEnemy3(0), Me.rx, Me.ry)
                    Case directions.D
                        g.DrawImage(imgEnemy3(1), Me.rx, Me.ry)
                    Case directions.L
                        g.DrawImage(imgEnemy3(2), Me.rx, Me.ry)
                    Case directions.R
                        g.DrawImage(imgEnemy3(3), Me.rx, Me.ry)
                End Select
        End Select
        If (rnd.Next(0, 50) < 1) Then
            Fire()
        End If
    End Sub
    Public Overrides Sub Fire()
        If Not rEnable Then
            Return
        End If
        Singleton.rInstance.AddElement(New enemyMissile(Me, 1, 15, 1))  ' me life speed power
    End Sub
    Public Sub isDead()  '如果死亡的话。画出爆炸图片
        If (Me.rLife = 0) Then
            Dim spBlast As SoundPlayer = New SoundPlayer(Resources.blast)
            spBlast.Play()
            Singleton.rInstance.AddElement(New Blast(Me.rx - 25, Me.ry - 25))
            Singleton.rInstance.RemoveElement(Me)
            Singleton.rInstance.AddElement(New Equipment(rnd.Next(0, 620), rnd.Next(0, 620), rnd.Next(0, 5)))
        End If
    End Sub
    Public Overrides Sub Beborn()
        Singleton.rInstance.AddElement(New Born(Me.rx, Me.ry))
    End Sub
End Class
