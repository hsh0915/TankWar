Public MustInherit Class Element
    Private x As Integer
    Public Property rx() As Integer
        Get
            Return x
        End Get
        Set(value As Integer)
            x = value
        End Set
    End Property
    Private y As Integer
    Public Property ry() As Integer
        Get
            Return Me.y
        End Get
        Set(value As Integer)
            Me.y = value
        End Set
    End Property
    Public Sub New(ByVal x As Integer, ByVal y As Integer)
        Me.x = x
        Me.y = y
    End Sub
    Public Sub New(ByVal x As Integer, ByVal y As Integer, ByVal dir As Direction.directions)
        If dir = Direction.directions.U Then
            Me.x = x + 60 \ 2 - 8
            Me.y = y
        End If
        If dir = Direction.directions.D Then
            Me.x = x + 60 \ 2 - 8
            Me.y = y + 60 - 14
        End If
        If dir = Direction.directions.L Then
            Me.x = x
            Me.y = y + 60 \ 2 - 10
        End If
        If dir = Direction.directions.R Then
            Me.x = x + 60 - 14
            Me.y = y + 60 \ 2 - 6
        End If
    End Sub
    Public Overridable Sub Draw(ByVal g As Graphics)
    End Sub
End Class
