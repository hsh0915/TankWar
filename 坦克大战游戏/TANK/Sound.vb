Imports Microsoft.DirectX.DirectSound
Imports System.IO

Class Sound

    Private secBuffer As SecondaryBuffer

    Public Property rSecBuffer() As SecondaryBuffer
        Get
            Return Me.secBuffer
        End Get
        Set(value As SecondaryBuffer)
            Me.secBuffer = value
        End Set
    End Property

    Public Sub New(ByVal fileName As Stream)
        MyBase.New()
        Dim desc As BufferDescription = New BufferDescription
        desc.StaticBuffer = True
        Dim dev As Device = New Device
        dev.SetCooperativeLevel(StartForm.rInstance, CooperativeLevel.Normal)
        Me.secBuffer = New SecondaryBuffer(fileName, desc, dev)
    End Sub

    Public Sub Play()
        Me.secBuffer.Play(0, BufferPlayFlags.Default)
    End Sub
End Class
