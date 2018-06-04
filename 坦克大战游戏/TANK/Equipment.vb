Imports TANK.My
Public Class Equipment
    Inherits Module1
    Private imgStar As Image = Resources.star
    Private imgBomb As Image = Resources.bomb
    Private imgTimer As Image = Resources.timer
    Private flag As Integer    ' 标志是哪个装备

    Public Property rFlag() As Integer
        Get
            Return flag
        End Get
        Set(value As Integer)
            flag = value
        End Set
    End Property
    Public Sub New(ByVal x As Integer, ByVal y As Integer, ByVal flag As Integer)
        MyBase.New(x, y, 40, 40)
        Me.flag = flag
    End Sub
    Public Overrides Sub Draw(ByVal g As Graphics)
        Select Case (flag)
            Case 0
                g.DrawImage(imgStar, Me.rx, Me.ry)
            Case 1
                g.DrawImage(imgBomb, Me.rx, Me.ry)
            Case 2
                g.DrawImage(imgTimer, Me.rx, Me.ry)
        End Select
    End Sub
End Class
