Public MustInherit Class Module1
    Inherits Element

    Private width As Integer
    Public Property rWidth() As Integer  '组件的长
        Get
            Return Me.width
        End Get
        Set(value As Integer)
            Me.width = value
        End Set
    End Property


    Private height As Integer   '组件的宽
    Public Property rHeight() As Integer
        Get
            Return Me.height
        End Get
        Set(value As Integer)
            Me.height = value
        End Set
    End Property

    Public Sub New(ByVal x As Integer, ByVal y As Integer, ByVal width As Integer, ByVal height As Integer)
        MyBase.New(x, y)
        Me.width = width
        Me.height = height
    End Sub

    Public Function GetRectangle() As Rectangle
        Return New Rectangle(Me.rx, Me.ry, Me.width, Me.height)
    End Function
End Class
