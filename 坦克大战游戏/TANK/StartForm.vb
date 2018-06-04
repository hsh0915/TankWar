Imports TANK.My
Imports System.Threading

Public Class StartForm
    Inherits Form
    Public Sub New()
        InitializeComponent()
        Me.SetStyle(ControlStyles.AllPaintingInWmPaint Or ControlStyles.ResizeRedraw Or ControlStyles.OptimizedDoubleBuffer, True)
    End Sub
    Private g As Graphics
    Public Shared isMultiplayer As Boolean = False
    Private imgTitle As Image = Resources.title
    Private imgSelect As Image = Resources.select1
    Private imgtank As Image = Resources.selecttank
    Private xPos As Integer = 205
    Private yPos As Integer = 290
    Private roll As Integer = 500
    Private Shared instance As StartForm
    Public Shared ReadOnly Property rInstance() As StartForm
        Get
            If (instance Is Nothing) Then
                instance = New StartForm()
            End If
            Return instance
        End Get
    End Property
    Private Sub RollThread()
        If (roll > 0) Then
            roll = (roll - 3)
            Thread.Sleep(10)
        Else
            Return
        End If
        Invalidate()
    End Sub

    Private Sub StartForm_Paint(sender As Object, e As PaintEventArgs) Handles MyBase.Paint
        g = e.Graphics
        g.DrawImage(imgTitle, 65, (50 + roll))
        g.DrawImage(imgSelect, 305, (300 + roll))
        g.DrawImage(imgtank, xPos, (yPos + roll))
        RollThread()
    End Sub

    Private Sub StartForm_MouseMove(sender As Object, e As MouseEventArgs) Handles MyBase.MouseMove
        If ((e.X > 305) AndAlso ((e.X < (305 + imgSelect.Width)) AndAlso ((e.Y > 300) AndAlso (e.Y < 330)))) Then
            yPos = 290
            Invalidate()
        End If
        If ((e.X > 305) AndAlso ((e.X < (305 + imgSelect.Width)) AndAlso ((e.Y > 370) AndAlso (e.Y < 400)))) Then
            yPos = 360
            Invalidate()
        End If

        If ((e.X > 305) AndAlso ((e.X < (305 + imgSelect.Width)) AndAlso ((e.Y > 430) AndAlso (e.Y < 460)))) Then
            yPos = 430
            Invalidate()
        End If

    End Sub

    Private Sub StartForm_MouseDown(sender As Object, e As MouseEventArgs) Handles MyBase.MouseDown
        If (((e.X > 305) AndAlso ((e.X < (305 + imgSelect.Width)) AndAlso ((e.Y > 300) AndAlso (e.Y < 330)))) _
             OrElse (((e.X > 305) AndAlso ((e.X < (305 + imgSelect.Width)) AndAlso ((e.Y > 370) AndAlso (e.Y < 400)))) _
             OrElse ((e.X > 305) AndAlso ((e.X < (305 + imgSelect.Width)) AndAlso ((e.Y > 430) AndAlso (e.Y < 460)))))) Then
            Start()
        End If
    End Sub
    Private Sub Start()
        If (yPos = 290) Then
            isMultiplayer = False
        ElseIf (yPos = 360) Then
            isMultiplayer = True
        ElseIf (yPos = 430) Then
            MessageBox.Show("Sorry~~~此功能尚未完成!")
        End If
        Dim soundStart As Sound = New Sound(Resources.start)
        soundStart.Play()
        Dim frm As MainForm = New MainForm
        frm.ShowDialog()
        Me.Close()
    End Sub

    Private Sub StartForm_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
    End Sub
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        MessageBox.Show("游戏说明:" + System.Environment.NewLine + "玩家1:WASD上左下右,K键发子弹." + System.Environment.NewLine + "玩家2:方向键上下左右,数字0发子弹.")
    End Sub
End Class