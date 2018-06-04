Imports TANK.Direction
Imports TANK.My
Public Class MainForm
    Inherits Form
    Private minTank As Image = Resources.mintank
    Dim p1Tank As Image = Resources.p1tankU
    Dim p2Tank As Image = Resources.p2tankU
    Private isStart As Boolean = False
    Private enemyNum As Integer = 12   '敌人坦克数量
    Private count As Integer                ' 敌人剩下的坦克数量
    Private rnd As Random = New Random
    Private gp As Graphics
    Private font1 As Font = New Font("Tahoma", 15, FontStyle.Bold)
    Private sbrush As SolidBrush = New SolidBrush(Color.Black)
    Private n As Integer = 0
    Public imgTank1() As Image = New Image() {Resources.p1tankU, Resources.p1tankD, Resources.p1tankL, Resources.p1tankR}
    Public imgTank2() As Image = New Image() {Resources.p2tankU, Resources.p2tankD, Resources.p2tankL, Resources.p2tankR}
    Public Sub New()
        InitializeComponent()
        InitGame()
        Me.SetStyle(ControlStyles.AllPaintingInWmPaint Or ControlStyles.ResizeRedraw Or ControlStyles.OptimizedDoubleBuffer, True)
    End Sub
    Private Sub InitGame()                       'x,y,,life speed,
        Singleton.rInstance.AddElement(New P1Tank(200, 600, 2, 5, directions.U, imgTank1))
        If StartForm.isMultiplayer Then
            Singleton.rInstance.AddElement(New P2Tank(400, 600, 2, 5, directions.U, imgTank2))
        End If
        InitMap()
    End Sub
    Private Sub MainForm_Paint(sender As Object, e As PaintEventArgs) Handles MyBase.Paint
        InitUI(e.Graphics)
    End Sub
    Private Sub Panel_Paint(sender As Object, e As PaintEventArgs) Handles Panel.Paint
        Singleton.rInstance.Draw(e.Graphics)
    End Sub
    Private Sub MainForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
    End Sub
    Private Sub MainForm_KeyDown(sender As Object, e As KeyEventArgs) Handles MyBase.KeyDown
            If Not Singleton.rInstance.rP1Tank.rEnable Then
                Return
            End If
            Singleton.rInstance.rP1Tank.KeyDown(e)
            If StartForm.isMultiplayer Then
                Singleton.rInstance.rP2Tank.KeyDown(e)
            End If
    End Sub
    Private Sub MainForm_KeyUp(sender As Object, e As KeyEventArgs) Handles MyBase.KeyUp
        If Not Singleton.rInstance.rP1Tank.rEnable Then
            Return
        End If
        Singleton.rInstance.rP1Tank.KeyUP(e)
        If StartForm.isMultiplayer Then
            Singleton.rInstance.rP2Tank.KeyUP(e)
        End If
    End Sub

    Private Sub Timer_Tick(sender As Object, e As EventArgs) Handles Timer.Tick
        Singleton.rInstance.CreateThread()
        SetEnemy()
        Panel.Invalidate()              '使panel重画
        Invalidate()
    End Sub
    Private Sub SetEnemy()   '设置敌人
        If Not isStart Then
            If (n < 6) Then
                Singleton.rInstance.AddElement(New Enemy(rnd.Next(0, 640), rnd.Next(0, 200), rnd.Next(0, 3), directions.U))
                n = (n + 1)
            Else
                isStart = True
            End If
        ElseIf ((Singleton.rInstance.count < 6) AndAlso (enemyNum > 0)) Then
            Singleton.rInstance.AddElement(New Enemy(rnd.Next(0, 640), rnd.Next(0, 200), rnd.Next(0, 3), directions.U))
            enemyNum -= 1
        End If
    End Sub
    Private Sub InitUI(ByVal gp As Graphics)
        '''''画敌人坦克的缩略图
        count = enemyNum
        Select Case ((count - 1) \ 3)
            Case 0
                Dim a As Integer = 0
                Do While (a < count)
                    gp.DrawImage(minTank, (665 + (a * 32)), 3)
                    a = (a + 1)
                Loop
            Case 1
                Dim b As Integer = 0
                Do While (b < 3)
                    gp.DrawImage(minTank, (665 + (b * 32)), 3)
                    b += 1
                Loop

                Dim i As Integer = 0
                Do While (i < (count - 3))
                    gp.DrawImage(minTank, (665 + (i * 32)), (3 + 32))
                    i = (i + 1)
                Loop

            Case 2
                Dim c As Integer = 0
                Do While (c < 3)
                    Dim j As Integer = 0
                    Do While (j < 2)
                        gp.DrawImage(minTank, (665 + (c * 32)), (3 + (j * 32)))
                        j = (j + 1)
                    Loop
                    c = (c + 1)
                Loop

                Dim i As Integer = 0
                Do While (i < (count - 6))
                    gp.DrawImage(minTank, (665 + (i * 32)), (3 + (2 * 32)))
                    i = (i + 1)
                Loop
            Case 3
                Dim d As Integer = 0
                Do While (d < 3)
                    Dim j As Integer = 0
                    Do While (j < 3)
                        gp.DrawImage(minTank, (665 + (d * 32)), (3 + (j * 32)))
                        j = (j + 1)
                    Loop
                    d = (d + 1)
                Loop

                Dim i As Integer = 0
                Do While (i < (count - 9))
                    gp.DrawImage(minTank, (665 + (i * 32)), (3 + (3 * 32)))
                    i = (i + 1)
                Loop
        End Select

        ''画玩家坦克的缩略图
        gp.DrawImage(p1Tank, 665, 500, 50, 50)
        gp.DrawImage(p2Tank, 665, 600, 50, 50)
        Dim s1 As String = Singleton.rInstance.rP1Tank.rLive.ToString
        If (s1 = "-1") Then
            s1 = "0"
        End If
        gp.DrawString(s1, Font, sbrush, 720, 520)
        If StartForm.isMultiplayer Then
            Dim s2 As String = Singleton.rInstance.rP2Tank.rLive.ToString
            If (s2 = "-1") Then
                s2 = "0"
            End If
            gp.DrawString(s2, Font, sbrush, 720, 620)
        End If
    End Sub
    Private Sub InitMap()   ' 初始化地图～～～
        Singleton.rInstance.AddElement(New Symbol(300, 615))
        Singleton.rInstance.AddElement(New Steel(250, 500))
        Singleton.rInstance.AddElement(New Steel(310, 500))
        Singleton.rInstance.AddElement(New Steel(370, 500))
        Singleton.rInstance.AddElement(New Snow(100, 200))
        Singleton.rInstance.AddElement(New Snow(470, 200))
        Singleton.rInstance.AddElement(New Snow(300, 400))
        Dim r As Integer = 0
        Do While (r < 5)
            Singleton.rInstance.AddElement(New Grass(310, r * 60))
            r += 1
        Loop
        Dim a As Integer = 0
        Do While (a < 4)
            Singleton.rInstance.AddElement(New Wall(285, (600 + (a * 15))))
            Singleton.rInstance.AddElement(New Wall(360, (600 + (a * 15))))
            Singleton.rInstance.AddElement(New Wall((300 + (a * 15)), 600))
            a += 1
        Loop
        Dim b As Integer = 0
        Do While (b < 4)
            Singleton.rInstance.AddElement(New Wall(270, (600 + (b * 15))))
            Singleton.rInstance.AddElement(New Wall(375, (600 + (b * 15))))
            b += 1
        Loop
        Dim c As Integer = 0
        Do While (c < 4)
            Singleton.rInstance.AddElement(New Steel(100, (520 + (c * 60))))
            Singleton.rInstance.AddElement(New Steel(500, (520 + (c * 60))))
            c += 1
        Loop

        Dim d As Integer = 0
        Do While (d < 11)
            Singleton.rInstance.AddElement(New Grass((0 + d * 60), 100))
            d += 1
        Loop

        Dim f As Integer = 0
        Do While (f < 4)
            Singleton.rInstance.AddElement(New Water((0 + f * 60), 320))
            Singleton.rInstance.AddElement(New Water((430 + f * 60), 320))
            f += 1
        Loop

    End Sub
End Class
