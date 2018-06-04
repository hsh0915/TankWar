Imports TANK.Direction
Imports TANK.My
Public Class P2Tank
    Inherits Player
    Public Sub New(ByVal x As Integer, ByVal y As Integer, ByVal speed As Integer, ByVal life As Integer, ByVal dir As directions, ByVal img() As Image)
        MyBase.New(x, y, speed, life, dir, img)
    End Sub
    Public Sub KeyDown(e As KeyEventArgs)
        Select Case (e.KeyCode)
            Case Keys.Up
                dirU = True
            Case Keys.Down
                dirD = True
            Case Keys.Left
                dirL = True
            Case Keys.Right
                dirR = True
            Case Keys.D0
                Fire()
        End Select
        If (e.KeyCode = Keys.Up Or e.KeyCode = Keys.Down Or e.KeyCode = Keys.Left Or e.KeyCode = Keys.Right) Then
            isMove = True
        End If
        Adjustdirection()
    End Sub
    Public Sub KeyUP(e As KeyEventArgs)
        Select Case (e.KeyCode)
            Case Keys.Up
                dirU = False
            Case Keys.Down
                dirD = False
            Case Keys.Left
                dirL = False
            Case Keys.Right
                dirR = False
        End Select
        isMove = False
        Adjustdirection()
    End Sub
    Public Overrides Sub Beborn()
        Me.rx = 400  '出生闪烁图固定在P2tank 出生时原点
        Me.ry = 600
        Singleton.rInstance.AddElement(New Born(Me.rx, Me.ry))
    End Sub
End Class

