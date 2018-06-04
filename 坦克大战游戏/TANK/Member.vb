Imports TANK.Direction
Public MustInherit Class Member
    Inherits Element
    Public dir As directions
    Private life As Integer

    Public Property rLife() As Integer
        Get
            Return Me.life
        End Get
        Set(value As Integer)
            Me.life = value
        End Set
    End Property
    Private speed As Integer
    Public Property rSpeed() As Integer
        Get
            Return speed
        End Get
        Set(value As Integer)
            speed = value
        End Set
    End Property
    Private width As Integer
    Public Property rWidth() As Integer
        Get
            Return Me.width
        End Get
        Set(value As Integer)
            Me.width = value
        End Set
    End Property
    Private height As Integer
    Public Property rHeight() As Integer
        Get
            Return Me.height
        End Get
        Set(value As Integer)
            Me.height = value
        End Set
    End Property
    Public Sub New(ByVal x As Integer, ByVal y As Integer, ByVal life As Integer, ByVal speed As Integer, ByVal width As Integer, ByVal height As Integer, ByVal dir As directions)
        MyBase.New(x, y)
        Me.life = life
        Me.speed = speed
        Me.width = width
        Me.height = height
        Me.dir = dir
    End Sub
    Public Sub New(ByVal x As Integer, ByVal y As Integer, ByVal life As Integer, ByVal speed As Integer, ByVal width As Integer, ByVal height As Integer, ByVal dir As directions, ByVal meiyong As Boolean)
        MyBase.New(x, y, dir)
        Me.life = life
        Me.speed = speed
        Me.width = width
        Me.height = height
        Me.dir = dir
    End Sub
    Public Overridable Sub Move()
    End Sub
    Public Function GetRectangle() As Rectangle
        Return New Rectangle(Me.rx, Me.ry, rWidth, rHeight)
    End Function

    Public Overridable Sub Adjustdirection()
        Select Case (dir)
            Case directions.U
                Me.ry -= speed
            Case directions.L
                Me.rx -= speed
            Case directions.R
                Me.rx += speed
            Case directions.D
                Me.ry += speed
        End Select
    End Sub
End Class


