Imports TANK.My
Public Class Born
    Inherits Element         ' 坦克出生时产生闪烁的效果
    Private bornTimer As Integer = 0
    Private Shared imgBorn() As Image = New Image() {Resources.born1, Resources.born2, Resources.born3, Resources.born4}
    Public Sub New(ByVal x As Integer, ByVal y As Integer)
        MyBase.New(x, y)
    End Sub
    Public Overrides Sub Draw(ByVal g As Graphics)
        If (bornTimer < 12) Then
            Select Case ((bornTimer Mod 8))
                Case 0, 1
                    g.DrawImage(imgBorn(0), Me.rx, Me.ry)
                Case 2, 3
                    g.DrawImage(imgBorn(1), Me.rx, Me.ry)
                Case 4, 5
                    g.DrawImage(imgBorn(2), Me.rx, Me.ry)
                Case 6, 7
                    g.DrawImage(imgBorn(3), Me.rx, Me.ry)
            End Select
            bornTimer += 1
        End If
    End Sub
End Class