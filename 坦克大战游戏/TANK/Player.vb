Imports TANK.Direction
Imports TANK.My
Public MustInherit Class Player
    Inherits Roles
    Protected isMove As Boolean = False     '是否在移动
    Protected dirU As Boolean = False, dirD = False, dirL = False, dirR = False
    Private img() As Image
    Private live As Integer = 2  '坦克的数量
    Public Property rLive() As Integer
        Get
            Return Live
        End Get
        Set(value As Integer)
            live = value
        End Set
    End Property
    Dim misLv As Integer = 0   ' 子弹的等级
    Public Property rMisLv() As Integer
        Get
            Return misLv
        End Get
        Set(value As Integer)
            misLv = value
        End Set
    End Property

    Public Sub New(ByVal x As Integer, ByVal y As Integer, ByVal life As Integer, ByVal speed As Integer, ByVal dir As directions, ByVal img() As Image)
        MyBase.New(x, y, life, speed, img(0).Width, img(0).Height, dir) '!!!!!!!***
        Me.img = img
        Beborn()
    End Sub
    Public Overrides Sub Adjustdirection() ' 调整方向 //哪个方向的值为true,就设dir为哪个方向  
        If (dirU AndAlso (Not dirD AndAlso (Not dirL AndAlso Not dirR))) Then
            dir = directions.U
        ElseIf (Not dirU AndAlso (dirD AndAlso (Not dirL AndAlso Not dirR))) Then
            dir = directions.D
        ElseIf (Not dirU AndAlso (Not dirD AndAlso (dirL AndAlso Not dirR))) Then
            dir = directions.L
        ElseIf (Not dirU AndAlso (Not dirD AndAlso (Not dirL AndAlso dirR))) Then
            dir = directions.R
        End If
    End Sub
    Public Overrides Sub Move()    ' 移动方法
        If (Not isMove) Then
            Return  '如果没按方向键就返回,防止坦克自动移动
        End If
        MyBase.Move()
    End Sub
    Public Overrides Sub Draw(ByVal g As Graphics)  ' 画出坦克
        If (rBornTimer < 12) Then
            rBornTimer += 1
            Return
        End If
        If live < 0 Then    ' 玩家坦克死亡后不再出坦克
            Return
        End If
        Move()
        Select Case (dir)
            Case directions.U
                g.DrawImage(img(0), Me.rx, Me.ry)
            Case directions.D
                g.DrawImage(img(1), Me.rx, Me.ry)
            Case directions.L
                g.DrawImage(img(2), Me.rx, Me.ry)
            Case directions.R
                g.DrawImage(img(3), Me.rx, Me.ry)
        End Select
    End Sub
    Public Overrides Sub Fire()  ' 坦克开火
        If (live >= 0) Then
            Dim soundFire As Sound = New Sound(Resources.fire)
            soundFire.Play()
            Select Case (misLv)          ' me life speed power
                Case 0
                    Singleton.rInstance.AddElement(New myMissile(Me, 1, 10, 1))
                Case 1
                    Singleton.rInstance.AddElement(New myMissile(Me, 1, 15, 1))
                Case 2
                    Singleton.rInstance.AddElement(New myMissile(Me, 1, 20, 1))
            End Select

        End If

    End Sub
    Public Sub isDead()  '如果死亡的话。画出爆炸图片
        If (live = 0) Then
            Dim soundBlast As Sound = New Sound(Resources.blast)
            soundBlast.Play()
            Singleton.rInstance.AddElement(New Blast((Me.rx - 25), (Me.ry - 25)))
            live = -1   ‘ 玩家坦克死亡后不再出坦克
            Return
        End If
        If ((Me.rLife <= 0) AndAlso (live <> 0)) Then
            Dim soundBlast As Sound = New Sound(Resources.blast)
            soundBlast.Play()
            Singleton.rInstance.AddElement(New Blast((Me.rx - 25), (Me.ry - 25)))
            rBornTimer = 0
            Beborn()
            live -= 1
            If (live > 1) Then
                Me.rLife += 1
            End If
        End If
    End Sub
End Class
