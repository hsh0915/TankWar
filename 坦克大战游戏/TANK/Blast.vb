Imports TANK.My
Public Class Blast   '爆炸类
    Inherits Element
    Private count As Integer = 0      '用记指定在加载哪张图片
    Private imgBlast() As Image = New Image() {Resources.blast1, Resources.blast2, Resources.blast3, Resources.blast4 _
                                          , Resources.blast5, Resources.blast6, Resources.blast7, Resources.blast8}
    Public Sub New(ByVal x As Integer, ByVal y As Integer)
        MyBase.New(x, y)
    End Sub
    Public Overrides Sub Draw(g As Graphics)  '画图方法
        If count < imgBlast.Length Then   '当记数器小于图片数量时
            g.DrawImage(imgBlast(count), Me.rx, Me.ry)  '在指定的位置画图
            count += 1    '记数器自加
        Else
            Singleton.rInstance.RemoveElement(Me) '防止爆炸发生后图片还在
        End If

    End Sub


End Class
