Imports System.Threading
Imports TANK.My
Imports TANK.Direction
Imports System.Media
Public Class Singleton
    Private p1Tank As P1Tank
    Private p2Tank As P2Tank
    Private symbol As Symbol
    Public Property rP1Tank() As P1Tank
        Get
            Return p1Tank
        End Get
        Set(value As P1Tank)
            p1Tank = value
        End Set
    End Property
    Public Property rP2Tank() As P2Tank
        Get
            Return p2Tank
        End Get
        Set(value As P2Tank)
            p2Tank = value
        End Set
    End Property
    Public Property rSymbol() As Symbol
        Get
            Return symbol
        End Get
        Set(value As Symbol)
            symbol = value
        End Set
    End Property
    Private a As Integer
    Public count As Integer   '画出敌人缩略图
    Private enemy As List(Of Enemy) = New List(Of Enemy)
    Private myMissile As List(Of myMissile) = New List(Of myMissile)
    Private enemyMissile As List(Of enemyMissile) = New List(Of enemyMissile)
    Private blast As List(Of Blast) = New List(Of Blast)
    Private born As List(Of Born) = New List(Of Born)
    Private equipment As List(Of Equipment) = New List(Of Equipment)
    Private wall As List(Of Wall) = New List(Of Wall)
    Private grass As List(Of Grass) = New List(Of Grass)
    Private water As List(Of Water) = New List(Of Water)
    Private snow As List(Of Snow) = New List(Of Snow)
    Private steel As List(Of Steel) = New List(Of Steel)
    Private Sub New()
        MyBase.New()
    End Sub
    Private Singleton()
    Private Shared instance As Singleton
    Public Shared ReadOnly Property rInstance() As Singleton
        Get
            If (instance Is Nothing) Then
                instance = New Singleton
            End If
            Return instance
        End Get
    End Property
    Public Sub CreateThread()    ' 使用多线程  使用 HitCheck（） 在计时器里里面调用
        Dim hitThread As Thread = New Thread(New ThreadStart(AddressOf HitCheck)) '!!!!!!!!
        hitThread.Start()
        count = enemy.Count    '画出敌人缩略图
    End Sub
    Public Sub AddElement(ByVal e As Element)
        If (TypeOf e Is P1Tank) Then
            Me.p1Tank = CType(e, P1Tank)
            Return
        End If
        If (TypeOf e Is P2Tank) Then
            Me.p2Tank = CType(e, P2Tank)
            Return
        End If
        If (TypeOf e Is Enemy) Then
            enemy.Add(CType(e, Enemy))
            Return
        End If
        If (TypeOf e Is myMissile) Then
            myMissile.Add(CType(e, myMissile))
            Return
        End If
        If (TypeOf e Is enemyMissile) Then
            enemyMissile.Add(CType(e, enemyMissile))
            Return
        End If
        If (TypeOf e Is Blast) Then
            blast.Add(CType(e, Blast))
            Return
        End If

        If (TypeOf e Is Born) Then
            born.Add(CType(e, Born))
            Return
        End If
        If (TypeOf e Is Equipment) Then
            Me.equipment.Add(CType(e, Equipment))
            Return
        End If
        If (TypeOf e Is Wall) Then
            wall.Add(CType(e, Wall))
            Return
        End If

        If (TypeOf e Is Grass) Then
            grass.Add(CType(e, Grass))
            Return
        End If

        If (TypeOf e Is Water) Then
            water.Add(CType(e, Water))
            Return
        End If

        If (TypeOf e Is Steel) Then
            steel.Add(CType(e, Steel))
            Return
        End If

        If (TypeOf e Is Symbol) Then
            symbol = CType(e, Symbol)
            Return
        End If
        If (TypeOf e Is Snow) Then
            snow.Add(CType(e, Snow))
            Return
        End If

    End Sub
    Public Sub Draw(ByVal g As Graphics)
        p1Tank.Draw(g)
        symbol.Draw(g)
        If (StartForm.isMultiplayer) Then
            p2Tank.Draw(g)
        End If

        Dim i As Integer = 0
        Do While (i < enemy.Count)
            enemy(i).Draw(g)
            i += 1
        Loop

        Dim j As Integer = 0
        Do While (j < enemyMissile.Count)
            enemyMissile(j).Draw(g)
            j += 1
        Loop

        Dim k As Integer = 0
        Do While (k < myMissile.Count)
            myMissile(k).Draw(g)
            k += 1
        Loop

        Dim a As Integer = 0
        Do While (a < blast.Count)
            blast(a).Draw(g)
            a += 1
        Loop

        Dim b As Integer = 0
        Do While (b < Me.born.Count)
            born(b).Draw(g)
            b += 1
        Loop

        Dim c As Integer = 0
        Do While (c < Me.equipment.Count)
            equipment(c).Draw(g)
            c += 1
        Loop
        Dim d As Integer = 0
        Do While (d < wall.Count)
            wall(d).Draw(g)
            d += 1
        Loop

        Dim e As Integer = 0
        Do While (e < grass.Count)
            grass(e).Draw(g)
            e += 1
        Loop

        Dim f As Integer = 0
        Do While (f < water.Count)
            water(f).Draw(g)
            f += 1
        Loop

        Dim h As Integer = 0
        Do While (h < steel.Count)
            steel(h).Draw(g)
            h += 1
        Loop
        Dim m As Integer = 0
        Do While (m < snow.Count)
            snow(m).Draw(g)
            m += 1
        Loop
    End Sub
    Public Sub RemoveElement(ByVal e As Element)

        If (TypeOf e Is myMissile) Then
            myMissile.Remove(CType(e, myMissile))
            Return
        End If

        If (TypeOf e Is enemyMissile) Then
            enemyMissile.Remove(CType(e, enemyMissile))
            Return
        End If

        If (TypeOf e Is Blast) Then
            blast.Remove(CType(e, Blast))
            Return
        End If

        If (TypeOf e Is Enemy) Then
            enemy.Remove(CType(e, Enemy))
            Return
        End If

        If (TypeOf e Is Wall) Then
            wall.Remove(CType(e, Wall))
            Return
        End If

        If (TypeOf e Is Grass) Then
            grass.Remove(CType(e, Grass))
            Return
        End If

        If (TypeOf e Is Water) Then
            water.Remove(CType(e, Water))
            Return
        End If

        If (TypeOf e Is Steel) Then
            steel.Remove(CType(e, Steel))
            Return
        End If
        If (TypeOf e Is Snow) Then
            snow.Remove(CType(e, Snow))
            Return
        End If
    End Sub
    Public Sub HitCheck()
        '1 玩家是否和敌人子弹碰撞
        Dim i As Integer = 0
        Do While (i < enemyMissile.Count)
            If (p1Tank.rLive >= 0) Then
                Try
                    If p1Tank.GetRectangle.IntersectsWith(enemyMissile(i).GetRectangle) Then
                        p1Tank.rLife = (p1Tank.rLife - enemyMissile(i).power)
                        enemyMissile.Remove(enemyMissile(i))
                        p1Tank.isDead()
                    End If
                Catch
                End Try

            End If
            If (StartForm.isMultiplayer AndAlso (p2Tank.rLive >= 0)) Then
                Try
                    If p2Tank.GetRectangle.IntersectsWith(enemyMissile(i).GetRectangle) Then
                        p2Tank.rLife = (p2Tank.rLife - enemyMissile(i).power)
                        enemyMissile.Remove(enemyMissile(i))
                        p2Tank.isDead()
                    End If
                Catch
                End Try
            End If
            Try
                If symbol.GetRectangle.IntersectsWith(enemyMissile(i).GetRectangle) Then
                    symbol.rIsDestory = True
                    enemyMissile.Remove(enemyMissile(i))
                End If
            Catch
            End Try
            i = (i + 1)
        Loop
        ' 2玩家的子弹是否和敌人碰撞
        Dim a As Integer = 0
        Do While (a < myMissile.Count)
            Dim j As Integer = 0
            Do While (j < enemy.Count)
                Try
                    If myMissile(a).GetRectangle.IntersectsWith(enemy(j).GetRectangle) Then
                        Dim sound As SoundPlayer = New SoundPlayer(Resources.hit)
                        sound.Play()
                        enemy(j).rLife -= myMissile(a).power
                        enemy(j).isDead()
                        myMissile.Remove(myMissile(a))
                    End If
                Catch
                End Try
                j = (j + 1)
            Loop
            Try
                If symbol.GetRectangle.IntersectsWith(myMissile(a).GetRectangle) Then
                    symbol.rIsDestory = True
                    'enemyMissile.Remove(enemyMissile(a))
                End If
            Catch
            End Try
            a = (a + 1)
        Loop

        '3玩家的子弹是否和敌人的子弹碰撞
        Dim b As Integer = 0
        Do While (b < myMissile.Count)
            Dim j As Integer = 0
            Do While (j < enemyMissile.Count)
                Try
                    If myMissile(b).GetRectangle.IntersectsWith(enemyMissile(j).GetRectangle) Then
                        myMissile.Remove(myMissile(b))
                        enemyMissile.Remove(enemyMissile(j))
                    End If
                Catch
                End Try
                j = (j + 1)
            Loop
            b += 1
        Loop
        ' 4玩家和装备的碰撞
        Dim w As Integer = 0
        Do While (w < equipment.Count)
            Try
                If p1Tank.GetRectangle.IntersectsWith(equipment(w).GetRectangle) Then
                    Dim sound As SoundPlayer = New SoundPlayer(Resources.add)
                    sound.Play()
                    Equip(equipment(w).rFlag, 1)
                    equipment.Remove(equipment(w))
                End If

                If p2Tank.GetRectangle.IntersectsWith(equipment(w).GetRectangle) Then
                    Dim sound As SoundPlayer = New SoundPlayer(Resources.add)
                    sound.Play()
                    Equip(equipment(w).rFlag, 2)
                    equipment.Remove(equipment(w))
                End If
            Catch
            End Try
            w = (w + 1)
        Loop


        '5子弹是否和组件碰撞

        Dim x As Integer = 0
        Do While (x < myMissile.Count)
            Dim j As Integer = 0
            Do While (j < wall.Count)
                Try
                    If myMissile(x).GetRectangle.IntersectsWith(wall(j).GetRectangle) Then
                        myMissile.Remove(myMissile(x))
                        wall.Remove(wall(j))
                    End If

                Catch

                End Try

                j = (j + 1)
            Loop

            Dim j2 As Integer = 0
            Do While (j2 < steel.Count)
                Try
                    If myMissile(x).GetRectangle.IntersectsWith(steel(j2).GetRectangle) Then
                        myMissile.Remove(myMissile(x))
                    End If

                Catch

                End Try

                j2 = (j2 + 1)
            Loop

            x = (x + 1)
        Loop

        Dim z As Integer = 0
        Do While (z < enemyMissile.Count)
            Dim j As Integer = 0
            Do While (j < wall.Count)
                Try
                    If enemyMissile(z).GetRectangle.IntersectsWith(wall(j).GetRectangle) Then
                        enemyMissile.Remove(enemyMissile(z))
                        wall.Remove(wall(j))
                    End If
                Catch
                End Try
                j = (j + 1)
            Loop
            Dim j3 As Integer = 0
            Do While (j3 < steel.Count)
                Try
                    If enemyMissile(z).GetRectangle.IntersectsWith(steel(j3).GetRectangle) Then
                        enemyMissile.Remove(enemyMissile(z))
                    End If

                Catch
                End Try
                j3 = (j3 + 1)
            Loop
            z = (z + 1)
        Loop


        '6坦克是否和土墙碰撞
        Dim p As Integer = 0
        Do While (p < wall.Count)
            Dim j As Integer = 0
            Do While (j < enemy.Count)
                If enemy(j).GetRectangle.IntersectsWith(wall(p).GetRectangle) Then
                    Select Case (enemy(j).dir)
                        Case directions.U
                            enemy(j).ry = (wall(p).ry + wall(p).rHeight)
                        Case directions.D
                            enemy(j).ry = (wall(p).ry - enemy(j).rHeight)
                        Case directions.L
                            enemy(j).rx = (wall(p).rx + wall(p).rWidth)
                        Case directions.R
                            enemy(j).rx = (wall(p).rx - enemy(j).rWidth)
                    End Select
                End If
                j = (j + 1)
            Loop

            If p1Tank.GetRectangle.IntersectsWith(wall(p).GetRectangle) Then
                Select Case (p1Tank.dir)
                    Case directions.U
                        p1Tank.ry = (wall(p).ry + wall(p).rHeight)
                    Case directions.D
                        p1Tank.ry = (wall(p).ry - p1Tank.rHeight)
                    Case directions.L
                        p1Tank.rx = (wall(p).rx + wall(p).rWidth)
                    Case directions.R
                        p1Tank.rx = (wall(p).rx - p1Tank.rWidth)
                End Select
            End If

            If StartForm.isMultiplayer Then
                If p2Tank.GetRectangle.IntersectsWith(wall(p).GetRectangle) Then
                    Select Case (p2Tank.dir)
                        Case directions.U
                            p2Tank.ry = (wall(p).ry + wall(p).rHeight)
                        Case directions.D
                            p2Tank.ry = (wall(p).ry - p2Tank.rHeight)
                        Case directions.L
                            p2Tank.rx = (wall(p).rx + wall(p).rWidth)
                        Case directions.R
                            p2Tank.rx = (wall(p).rx - p2Tank.rWidth)
                    End Select
                End If
            End If
            p = (p + 1)
        Loop


        '7 坦克是否和钢墙碰撞
        Dim q As Integer = 0
        Do While (q < steel.Count)
            Dim j As Integer = 0
            Do While (j < enemy.Count)
                If enemy(j).GetRectangle.IntersectsWith(steel(q).GetRectangle) Then
                    Select Case (enemy(j).dir)
                        Case directions.U
                            enemy(j).ry = (steel(q).ry + steel(q).rHeight)
                        Case directions.D
                            enemy(j).ry = (steel(q).ry - enemy(j).rHeight)
                        Case directions.L
                            enemy(j).rx = (steel(q).rx + steel(q).rWidth)
                        Case directions.R
                            enemy(j).rx = (steel(q).rx - enemy(j).rWidth)
                    End Select
                End If
                j = (j + 1)
            Loop
            If p1Tank.GetRectangle.IntersectsWith(steel(q).GetRectangle) Then
                Select Case (p1Tank.dir)
                    Case directions.U
                        p1Tank.ry = (steel(q).ry + steel(q).rHeight)
                    Case directions.D
                        p1Tank.ry = (steel(q).ry - p1Tank.rHeight)
                    Case directions.L
                        p1Tank.rx = (steel(q).rx + steel(q).rWidth)
                    Case directions.R
                        p1Tank.rx = (steel(q).rx - p1Tank.rWidth)
                End Select
            End If
            If StartForm.isMultiplayer Then
                If p2Tank.GetRectangle.IntersectsWith(steel(q).GetRectangle) Then
                    Select Case (p2Tank.dir)
                        Case directions.U
                            p2Tank.ry = (steel(q).ry + steel(q).rHeight)
                        Case directions.D
                            p2Tank.ry = (steel(q).ry - p2Tank.rHeight)
                        Case directions.L
                            p2Tank.rx = (steel(q).rx + steel(q).rWidth)
                        Case directions.R
                            p2Tank.rx = (steel(q).rx - p2Tank.rWidth)
                    End Select
                End If
            End If
            q = (q + 1)
        Loop


        ''8坦克是否和河水碰撞
        Dim r As Integer = 0
        Do While (r < water.Count)
            Dim j As Integer = 0
            Do While (j < enemy.Count)
                If enemy(j).GetRectangle.IntersectsWith(water(r).GetRectangle) Then
                    Select Case (enemy(j).dir)
                        Case directions.U
                            enemy(j).ry = (water(r).ry + water(r).rHeight)
                        Case directions.D
                            enemy(j).ry = (water(r).ry - enemy(j).rHeight)
                        Case directions.L
                            enemy(j).rx = (water(r).rx + water(r).rWidth)
                        Case directions.R
                            enemy(j).rx = (water(r).rx - enemy(j).rWidth)
                    End Select

                End If
                j = (j + 1)
            Loop
            If p1Tank.GetRectangle.IntersectsWith(water(r).GetRectangle) Then
                Select Case (p1Tank.dir)
                    Case directions.U
                        p1Tank.ry = (water(r).ry + water(r).rHeight)
                    Case directions.D
                        p1Tank.ry = (water(r).ry - p1Tank.rHeight)
                    Case directions.L
                        p1Tank.rx = (water(r).rx + water(r).rWidth)
                    Case directions.R
                        p1Tank.rx = (water(r).rx - p1Tank.rWidth)
                End Select

            End If

            If StartForm.isMultiplayer Then
                If p2Tank.GetRectangle.IntersectsWith(water(r).GetRectangle) Then
                    Select Case (p2Tank.dir)
                        Case directions.U
                            p2Tank.ry = (water(r).ry + water(r).rHeight)
                        Case directions.D
                            p2Tank.ry = (water(r).ry - p1Tank.rHeight)
                        Case directions.L
                            p2Tank.rx = (water(r).rx + water(r).rWidth)
                        Case directions.R
                            p2Tank.rx = (water(r).rx - p1Tank.rWidth)
                    End Select
                End If
            End If
            r = (r + 1)
        Loop

        '10 敌人坦克和玩家坦克碰撞检测
        Dim t As Integer = 0
        Do While (t < enemy.Count)
            If enemy(t).GetRectangle.IntersectsWith(p1Tank.GetRectangle) Then

                Select Case (enemy(t).dir)
                    Case directions.U
                        enemy(t).ry = (p1Tank.ry + 60)
                    Case directions.D
                        enemy(t).ry = (p1Tank.ry - 60)
                    Case directions.L
                        enemy(t).rx = (p1Tank.rx + 60)
                    Case directions.R
                        enemy(t).rx = (p1Tank.rx - 60)
                End Select
            End If

            If (StartForm.isMultiplayer) Then 'AndAlso (p2Tank.rLive >= 0))
                If enemy(t).GetRectangle.IntersectsWith(p2Tank.GetRectangle) Then
                    Select Case (enemy(t).dir)
                        Case directions.U
                            enemy(t).ry = (p2Tank.ry + 60)
                        Case directions.D
                            enemy(t).ry = (p2Tank.ry - 60)
                        Case directions.L
                            enemy(t).rx = (p2Tank.rx + 60)
                        Case directions.R
                            enemy(t).rx = (p2Tank.rx - 60)
                    End Select
                End If
            End If
            t = (t + 1)
        Loop
        '9 玩家坦克和敌人坦克碰撞检测
        Dim s As Integer = 0
        Do While (s < enemy.Count)
            If (p1Tank.rLive >= 0) Then
                Try
                    If p1Tank.GetRectangle.IntersectsWith(enemy(s).GetRectangle) Then
                        Select Case (p1Tank.dir)
                            Case directions.U
                                p1Tank.ry = (enemy(s).ry + 60) ' enemy(s).rHeight
                            Case directions.D
                                p1Tank.ry = (enemy(s).ry - 60) 'p1Tank.rHeight
                            Case directions.L
                                p1Tank.rx = (enemy(s).rx + 60)
                            Case directions.R
                                p1Tank.rx = (enemy(s).rx - 60)
                        End Select
                    End If
                Catch
                End Try
            End If
            If StartForm.isMultiplayer Then
                If p2Tank.GetRectangle.IntersectsWith(enemy(s).GetRectangle) Then
                    Select Case (p2Tank.dir)
                        Case directions.U
                            p2Tank.ry = (enemy(s).ry + 60)
                        Case directions.D
                            p2Tank.ry = (enemy(s).ry - 60)
                        Case directions.L
                            p2Tank.rx = (enemy(s).rx + 60)
                        Case directions.R
                            p2Tank.rx = (enemy(s).rx - 60)
                    End Select
                End If
            End If
            s = (s + 1)
        Loop

        ' 11 坦克和雪的碰撞
        Dim v As Integer = 0
        Do While (v < snow.Count)
            Dim j As Integer = 0
            Do While (j < enemy.Count)
                If enemy(j).GetRectangle.IntersectsWith(snow(v).GetRectangle) Then
                    Select Case (enemy(j).dir)
                        Case directions.U
                            enemy(j).ry -= 30
                        Case directions.D
                            enemy(j).ry += 30
                        Case directions.L
                            enemy(j).rx -= 30
                        Case directions.R
                            enemy(j).rx += 30
                    End Select

                End If

                j = (j + 1)
            Loop

            If p1Tank.GetRectangle.IntersectsWith(snow(v).GetRectangle) Then
                Select Case (p1Tank.dir)
                    Case directions.U
                        p1Tank.ry -= 30 '(snow(v).ry + snow(v).rHeight) 
                    Case directions.D
                        p1Tank.ry += 30
                    Case directions.L
                        p1Tank.rx -= 30
                    Case directions.R
                        p1Tank.rx += 30
                End Select
            End If

            If StartForm.isMultiplayer Then
                If p2Tank.GetRectangle.IntersectsWith(snow(v).GetRectangle) Then
                    Select Case (p2Tank.dir)
                        Case directions.U
                            p2Tank.ry -= 30
                        Case directions.D
                            p2Tank.ry += 30
                        Case directions.L
                            p2Tank.rx -= 30
                        Case directions.R
                            p2Tank.rx += 30
                    End Select
                End If
            End If
            v = (v + 1)
        Loop
    End Sub
    Public Sub Equip(ByVal type As Integer, ByVal player As Integer)
        Select Case (type)
            Case 0
                If (player = 1) Then
                    If (p1Tank.rMisLv < 2) Then
                        p1Tank.rMisLv += 1
                    End If
                    If (p1Tank.rMisLv = 2) Then
                        p1Tank.rLife += 1
                    End If
                End If
                If (player = 2) Then
                    If (p2Tank.rMisLv < 2) Then
                        p2Tank.rMisLv += 1
                    End If
                    If (p2Tank.rMisLv = 2) Then
                        p2Tank.rLife += 1
                    End If
                End If
            Case 1
                Dim i As Integer = 0
                Do While (i < enemy.Count)
                    enemy(i).rLife = 0
                    enemy(i).isDead()
                    i = (i + 1)
                Loop
            Case 2
                Dim i As Integer = 0
                Do While (i < enemy.Count)
                    enemy(i).rEnable = False
                    i = (i + 1)
                Loop
        End Select
    End Sub

End Class



