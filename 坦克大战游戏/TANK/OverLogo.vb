Imports TANK.My
Class OverLogo
    Inherits Element

    Private Shared imgOverLogo As Image = Resources.over

    Public Sub New(ByVal x As Integer, ByVal y As Integer)
        MyBase.New(x, y)

    End Sub

    Public Overrides Sub Draw(ByVal g As Graphics)
        g.DrawImage(imgOverLogo, Me.rx, Me.ry)
        If (Me.ry > 300) Then
            Me.ry -= 3
        End If
    End Sub
End Class
