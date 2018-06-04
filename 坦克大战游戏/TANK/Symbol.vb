Imports TANK.My
Public Class Symbol
    Inherits Module1
    Private Shared imgSymbol As Image = Resources.symbol

    Private Shared imgDestroy As Image = Resources.destory

    Private Shared imgOver As Image = Resources.over

    Private isDestory As Boolean = False
    Private overLogo As OverLogo = New OverLogo(290, 615)
    Public Property rIsDestory() As Boolean
        Get
            Return Me.isDestory
        End Get
        Set(value As Boolean)
            Me.isDestory = value
        End Set
    End Property
    Public Sub New(ByVal x As Integer, ByVal y As Integer)
        MyBase.New(x, y, imgSymbol.Width, imgSymbol.Height)
    End Sub
    Public Overrides Sub Draw(ByVal g As Graphics)
        If Me.isDestory Then
            g.DrawImage(imgDestroy, Me.rx, Me.ry)
            Me.overLogo.Draw(g)
            'Singleton.rInstance.rP1Tank.rEnable = False
            'Singleton.rInstance.rP2Tank.rEnable = False
            Return
        End If
        If StartForm.isMultiplayer = False Then
            If Singleton.rInstance.rP1Tank.rLive < 0 Then
                g.DrawImage(imgDestroy, Me.rx, Me.ry)
                Me.overLogo.Draw(g)
                Return
            End If
        End If
        If StartForm.isMultiplayer Then
            If Singleton.rInstance.rP1Tank.rLive < 0 AndAlso Singleton.rInstance.rP2Tank.rLive < 0 Then
                g.DrawImage(imgDestroy, Me.rx, Me.ry)
                Me.overLogo.Draw(g)
                Return
            End If
        End If


        g.DrawImage(imgSymbol, Me.rx, Me.ry)
    End Sub


End Class