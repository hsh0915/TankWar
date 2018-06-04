Imports TANK.Direction
Public MustInherit Class Roles
    Inherits Member
    Private bornTimer As Integer = 0
    Public Property rBornTimer() As Integer
        Get
            Return BornTimer
        End Get
        Set(value As Integer)
            bornTimer = value
        End Set
    End Property
    Dim enable As Boolean = True   '是否可以移动
    Public Property rEnable() As Boolean
        Get
            Return Enable
        End Get
        Set(value As Boolean)
            enable = value
        End Set
    End Property
    Public Sub New(ByVal x As Integer, ByVal y As Integer, ByVal life As Integer, ByVal speed As Integer, ByVal width As Integer, ByVal height As Integer, ByVal dir As directions)
        MyBase.New(x, y, life, speed, width, height, dir)
    End Sub
    Public Overrides Sub Move()
        MyBase.Adjustdirection()
        If (Me.rx > 600) Then
            Me.rx = 600
        End If
        If (Me.rx < 0) Then
            Me.rx = 0
        End If
        If (Me.ry > 600) Then
            Me.ry = 600
        End If

        If (Me.ry < 0) Then
            Me.ry = 0
        End If
    End Sub
    Public MustOverride Sub Fire()
    Public MustOverride Sub Beborn()
End Class
