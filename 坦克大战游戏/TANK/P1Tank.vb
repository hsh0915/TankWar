Imports TANK.Direction
Imports TANK.My
Imports TANK.Singleton
Public Class P1Tank
    Inherits Player
    'Public imgTank1() As Image = New Image() {Resources.p1tankU, Resources.p1tankD, Resources.p1tankL, Resources.p1tankR}
    Public Sub New(ByVal x As Integer, ByVal y As Integer, ByVal speed As Integer, ByVal life As Integer, ByVal dir As directions, ByVal img() As Image)
        MyBase.New(x, y, speed, life, dir, img)
    End Sub
    Public Sub KeyDown(e As KeyEventArgs)
        Select Case (e.KeyCode)
            Case Keys.W
                dirU = True
            Case Keys.S
                dirD = True
            Case Keys.A
                dirL = True
            Case Keys.D
                dirR = True
            Case Keys.K
                Fire()
        End Select
        If (e.KeyCode = Keys.W Or e.KeyCode = Keys.S Or e.KeyCode = Keys.A Or e.KeyCode = Keys.D) Then
            isMove = True
        End If
        Adjustdirection()
    End Sub
    Public Sub KeyUP(e As KeyEventArgs)
        Select Case (e.KeyCode)
            Case Keys.W
                dirU = False
            Case Keys.S
                dirD = False
            Case Keys.A
                dirL = False
            Case Keys.D
                dirR = False
        End Select
        isMove = False
        Adjustdirection()
    End Sub
    Public Overrides Sub Beborn()
        Me.rx = 200   '出生闪烁图固定在P1tank 出生时原点
        Me.ry = 600
        Singleton.rInstance.AddElement(New Born(Me.rx, Me.ry))
    End Sub

End Class
