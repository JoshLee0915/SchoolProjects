
Public Enum threadTypes
    warp = 0
    weft = 1
End Enum
Structure Thread
    Public x_Start As Integer
    Public x_End As Integer
    Public y_Start As Integer
    Public y_End As Integer
    Public color As Color
End Structure

Structure intersection
    Public x_Start As Integer
    Public x_End As Integer
    Public y_Start As Integer
    Public y_End As Integer
    Public warpThread As Integer
    Public weftThread As Integer
    Public Heddle_Pos_Up As Boolean
End Structure

Public Class PatternClass
    Private Const Space As Integer = 15
    Private errorOccured As Boolean = False
    Private pattern As Bitmap
    Private e As Exception
    Private Warps As New ArrayList()
    Private Wefts As New ArrayList()
    Private Intersections As New ArrayList()

    'properties
    ReadOnly Property ErrorCheck
        Get
            Return errorOccured
        End Get
    End Property

    ReadOnly Property InternalError
        Get
            Return e
        End Get
    End Property

    ReadOnly Property PatternImg
        Get
            Return pattern
        End Get
    End Property

    Sub New(ByVal WeftNum As Integer, ByVal WarpNum As Integer, ByVal PixWidth As Integer, ByVal PixHeight As Integer, ByVal DefaultWeftColor As Color, ByVal DefaultWarpColor As Color)
        Dim netWidth As Integer = PixWidth - ((WarpNum + 1) * Space)
        Dim netHight As Integer = PixHeight - ((WeftNum + 1) * Space)

        'create a bitmap the size of the pattern window
        pattern = New Bitmap(PixWidth, PixHeight)

        'create the wefts and warps
        createWeft(netHight, WeftNum, DefaultWeftColor)
        createWarp(netWidth, WarpNum, DefaultWarpColor)

        'find the weft and warp intersection points
        findIntersections(WeftNum, WarpNum, PixWidth, PixHeight)

    End Sub

    Sub New(ByVal file As IO.Stream, ByVal height As Integer, ByVal width As Integer)
        'this constructor is just ment for loading a pattern file
        errorOccured = LoadPattern(file)

        pattern = New Bitmap(width, height)
    End Sub

    'Josh Lee 11/24/2012: This consturctor is currently broken and should not be used will be repaired at a 
    'later date
    Sub New(ByVal width As Double, ByVal height As Double, ByVal threadDiameter As Double, ByVal PixWidth As Integer, ByVal PixHeight As Integer, ByVal DefaultWeftColor As Color, ByVal DefaultWarpColor As Color)
        'find the number of threads that would be in the specfied pattern
        Dim warpCount As Integer = width / threadDiameter
        Dim weftCount As Integer = height / threadDiameter
        'find the net width and hight
        Dim netWidth As Integer = PixWidth - ((warpCount + 1) * Space)
        Dim netHight As Integer = PixHeight - ((weftCount + 1) * Space)

        'create a bitmap the size of the pattern window
        pattern = New Bitmap(PixWidth, PixHeight)

        'create the wefts and warps
        createWeft(netHight, weftCount, DefaultWeftColor)
        createWarp(netWidth, weftCount, DefaultWarpColor)

        'find the weft and warp intersection points
        findIntersections(weftCount, warpCount, netWidth, netHight)

    End Sub

    Public Function drawPattern() As Bitmap
        Dim intersectIndex As Integer = 0
        'Create a white canvas for the patter to be drawn upon
        For y As Integer = 0 To pattern.Height - 1
            For x As Integer = 0 To pattern.Width - 1
                pattern.SetPixel(x, y, Color.White)
            Next
        Next

        'draw the warps
        For Each warp As Thread In Warps
            For y As Integer = warp.y_Start To warp.y_End
                For x As Integer = warp.x_Start To warp.x_End
                    pattern.SetPixel(x, y, warp.color)
                Next
            Next
        Next

        'draw the wefts
        For Each weft As Thread In Wefts
            Dim warpIndex As Integer = 0
            For x As Integer = weft.x_Start To weft.x_End
                'Check if the weft is intersecting a warp thread
                If warpIndex < Warps.Count Then
                    If x = Warps(warpIndex).x_Start Then
                        'Check the heddle pos
                        If Intersections(intersectIndex).Heddle_Pos_Up Then
                            'Add the width of the warp thread to the x
                            x += (Warps(warpIndex).x_End - Warps(warpIndex).x_Start)
                        Else
                            'drawOverIt
                            For y As Integer = weft.y_Start To weft.y_End
                                pattern.SetPixel(x, y, weft.color)
                            Next
                        End If
                        'increment the intersect point and warp thread
                        intersectIndex += 1
                        warpIndex += 1
                    Else
                        'Draw the thread
                        For y As Integer = weft.y_Start To weft.y_End
                            pattern.SetPixel(x, y, weft.color)
                        Next
                    End If
                Else
                    'Draw the thread
                    For y As Integer = weft.y_Start To weft.y_End
                        pattern.SetPixel(x, y, weft.color)
                    Next
                End If
            Next
        Next

        Return pattern
    End Function

    Public Function debugDraw() As Bitmap
        'Debug variation of draw
        Dim intersectIndex As Integer = 0
        'Create a white canvas for the patter to be drawn upon
        For y As Integer = 0 To pattern.Height - 1
            For x As Integer = 0 To pattern.Width - 1
                pattern.SetPixel(x, y, Color.White)
            Next
        Next

        'draw the warps
        For Each warp As Thread In Warps
            For y As Integer = warp.y_Start To warp.y_End
                For x As Integer = warp.x_Start To warp.x_End
                    pattern.SetPixel(x, y, warp.color)
                Next
            Next
        Next

        'draw the wefts
        For Each weft As Thread In Wefts
            Dim warpIndex As Integer = 0
            For x As Integer = weft.x_Start To weft.x_End
                'Check if the weft is intersecting a warp thread
                If warpIndex < Warps.Count Then
                    If x = Warps(warpIndex).x_Start Then
                        'Check the heddle pos
                        If Intersections(intersectIndex).Heddle_Pos_Up Then
                            'Add the width of the warp thread to the x
                            x += (Warps(warpIndex).x_End - Warps(warpIndex).x_Start)
                        Else
                            'drawOverIt
                            For y As Integer = weft.y_Start To weft.y_End
                                pattern.SetPixel(x, y, weft.color)
                            Next
                        End If
                        'increment the intersect point and warp thread
                        intersectIndex += 1
                        warpIndex += 1
                    Else
                        'Draw the thread
                        For y As Integer = weft.y_Start To weft.y_End
                            pattern.SetPixel(x, y, weft.color)
                        Next
                    End If
                Else
                    'Draw the thread
                    For y As Integer = weft.y_Start To weft.y_End
                        pattern.SetPixel(x, y, weft.color)
                    Next
                End If
            Next
        Next

        'draw the intersect boxes
        For Each interset As intersection In Intersections
            For y As Integer = interset.y_Start To interset.y_End - 1
                For x As Integer = interset.x_Start To interset.x_End - 1
                    If y < pattern.Height And x < pattern.Width Then
                        pattern.SetPixel(x, y, Color.Black)
                    End If
                Next
            Next
        Next

        Return pattern
    End Function

    Public Function update(ByVal xPoint As Integer, ByVal yPoint As Integer) As Bitmap
        Dim warp As New Thread
        Dim weft As New Thread
        Dim index As Integer = 0

        'Find the threads that intersected
        For Each intersect As intersection In Intersections
            If (intersect.x_Start <= xPoint And intersect.x_End >= xPoint) And (intersect.y_Start <= yPoint And intersect.y_End >= yPoint) Then
                'invert the heddlePos, get the threads that intersect, and exit the for loop
                Dim newIntersectPos As intersection = Intersections(index)
                newIntersectPos.Heddle_Pos_Up = Not newIntersectPos.Heddle_Pos_Up
                Intersections(index) = newIntersectPos

                warp = Warps(intersect.warpThread)
                weft = Wefts(intersect.weftThread)

                Exit For
            Else
                index += 1
            End If
        Next

        Return drawPattern()
    End Function

    Public Function changeThreadColor(ByVal threadType As threadTypes, ByVal thread As Integer, ByVal newColor As Color) As Bitmap
        'change the thread to its new color
        If threadType = threadTypes.warp Then
            Dim newWarp As Thread = Warps(thread)
            newWarp.color = newColor
            Warps(thread) = newWarp
        Else
            Dim newWeft As Thread = Wefts(thread)
            newWeft.color = newColor
            Wefts(thread) = newWeft
        End If

        'redraw the pattern with the new change
        Return drawPattern()
    End Function

    Public Function getThreadColor(ByVal threadType As threadTypes, ByVal thread As Integer) As Color
        If threadType = threadTypes.warp Then
            Return Warps(thread).color
        Else
            Return Wefts(thread).color
        End If
    End Function

    Public Function weave(ByVal pxWidth As Integer, ByVal pxHeight As Integer, ByVal Width As Double, ByVal Height As Double, ByVal threadDiameter As Double) As Bitmap
        'weave the pattern
        Dim fabric As New Bitmap(pxWidth, pxHeight)
        Dim startIndex As Integer = 0
        Dim SectionIndex As Integer = startIndex
        Dim CurrentWeftThread As Integer = 0
        Dim warpCount As Integer = Width / threadDiameter
        Dim weftCount As Integer = Height / threadDiameter
        Dim ThreadWidth As Integer = pxWidth / warpCount
        Dim ThreadHeight As Integer = pxHeight / weftCount
        Dim sectionColor As Color

        If weftCount > 0 And warpCount > 0 Then
            For yThread As Integer = 0 To weftCount - 1
                If CurrentWeftThread = Wefts.Count Then CurrentWeftThread = 0
                If Not (startIndex < Intersections.Count) Then startIndex = 0

                For xThread As Integer = 0 To warpCount - 1

                    If SectionIndex < Intersections.Count Then
                        If Intersections(SectionIndex).weftThread > CurrentWeftThread Then
                            SectionIndex = startIndex
                        End If
                    Else
                        SectionIndex = startIndex
                    End If

                    If Intersections(SectionIndex).Heddle_Pos_Up Then
                        sectionColor = Warps(Intersections(SectionIndex).warpThread).color
                    Else
                        sectionColor = Wefts(Intersections(SectionIndex).weftThread).color
                    End If

                    For y As Integer = (yThread * ThreadWidth) To ((yThread * ThreadWidth) + (ThreadWidth - 1))
                        For x As Integer = (xThread * ThreadWidth) To ((xThread * ThreadWidth) + (ThreadWidth - 1))
                            If x < fabric.Width And y < fabric.Height Then
                                fabric.SetPixel(x, y, sectionColor)
                            End If
                        Next
                    Next
                    SectionIndex += 1
                Next
                CurrentWeftThread += 1
                startIndex += Wefts.Count
            Next
        End If

        Return fabric
    End Function

    Public Function save(ByVal file As IO.Stream) As Boolean
        'Function for saving a patern file
        Dim writer As IO.BinaryWriter = New IO.BinaryWriter(file)

        Try
            writer.Seek(0, IO.SeekOrigin.Begin) 'set to the begining of the file

            'Write the sizes of weft, warp, and intersection
            writer.Write(Wefts.Count)
            writer.Write(Warps.Count)
            writer.Write(Intersections.Count)

            'Write the information from the weft array to the file
            For Each weft As Thread In Wefts
                writer.Write(weft.x_Start)
                writer.Write(weft.x_End)
                writer.Write(weft.y_Start)
                writer.Write(weft.y_End)
                writer.Write(weft.color.ToArgb())
            Next

            'Write the information from the warps array to the file
            For Each warp As Thread In Warps
                writer.Write(warp.x_Start)
                writer.Write(warp.x_End)
                writer.Write(warp.y_Start)
                writer.Write(warp.y_End)
                writer.Write(warp.color.ToArgb())
            Next

            'Write the information from the intersections array to the file
            For Each intersect As intersection In Intersections
                writer.Write(intersect.x_Start)
                writer.Write(intersect.x_End)
                writer.Write(intersect.y_Start)
                writer.Write(intersect.y_End)
                writer.Write(intersect.weftThread)
                writer.Write(intersect.warpThread)
                writer.Write(intersect.Heddle_Pos_Up)
            Next

        Catch ex As Exception
            e = ex
            writer.Close()
            Return False
        Finally
            'Close the writer stream
            writer.Close()
        End Try

        Return True
    End Function

    Private Sub createWeft(ByVal netHeight As Integer, ByVal WeftNum As Integer, ByVal threadColor As Color)
        'A sub to create the weft threads of the pattern
        Dim HeightStart As Integer = 0
        Dim WeftHeight As Integer = netHeight / WeftNum

        For Thread As Integer = 1 To WeftNum
            Dim WeftThread As New Thread
            WeftThread.x_Start = 0
            WeftThread.x_End = pattern.Width - 1
            WeftThread.y_Start = HeightStart + Space
            WeftThread.y_End = WeftThread.y_Start + WeftHeight
            WeftThread.color = threadColor

            Wefts.Add(WeftThread)

            HeightStart = WeftThread.y_End
        Next
    End Sub

    Private Sub createWarp(ByVal netWidth As Integer, ByVal WarpNum As Integer, ByVal threadColor As Color)
        'A sub to create the warp threads of the pattern
        Dim WidthStart As Integer = 0
        Dim WarpWidth As Integer = netWidth / WarpNum

        For Thread As Integer = 1 To WarpNum
            Dim WarpThread As New Thread
            WarpThread.y_Start = 0
            WarpThread.y_End = pattern.Height - 1
            WarpThread.x_Start = WidthStart + Space
            WarpThread.x_End = WarpThread.x_Start + WarpWidth
            WarpThread.color = threadColor

            Warps.Add(WarpThread)

            WidthStart = WarpThread.x_End
        Next
    End Sub

    Private Sub findIntersections(ByVal WeftNum As Integer, ByVal WarpNum As Integer, ByVal PixWidth As Integer, ByVal PixHeight As Integer)
        'a sub ment to find where the threads will intersect to help determin heddle position
        Dim StartX As Integer
        Dim StartY As Integer = 0
        Dim width As Integer = PixWidth / WarpNum
        Dim height As Integer = PixHeight / WeftNum

        For y As Integer = 1 To WeftNum
            StartX = 0
            For x As Integer = 1 To WarpNum
                Dim intersect As New intersection
                'Get the dimensions of the intersect box
                intersect.x_Start = StartX
                intersect.x_End = StartX + width
                intersect.y_Start = StartY
                intersect.y_End = StartY + height

                'Get the warp and weft that intersect in that area
                intersect.weftThread = y - 1
                intersect.warpThread = x - 1
                intersect.Heddle_Pos_Up = True

                Intersections.Add(intersect)

                StartX += width
            Next
            StartY += height
        Next
    End Sub

    Private Function LoadPattern(ByVal file As IO.Stream) As Boolean
        'Load a pattern file
            Dim reader As IO.BinaryReader = New IO.BinaryReader(file)

            Try
                'Get the dimensions for the arrays
                Dim weftCount As Integer = reader.ReadInt32()
                Dim warpCount As Integer = reader.ReadInt32()
                Dim intersectCount As Integer = reader.ReadInt32()

                'Get the information for the wefts
                For x As Integer = 1 To weftCount
                    Dim tempWeft As New Thread
                    tempWeft.x_Start = reader.ReadInt32()
                    tempWeft.x_End = reader.ReadInt32()
                    tempWeft.y_Start = reader.ReadInt32()
                    tempWeft.y_End = reader.ReadInt32()
                    tempWeft.color = Color.FromArgb(reader.ReadInt32())
                    Wefts.Add(tempWeft)
                Next

                'Get the information for the warps
                For x As Integer = 1 To warpCount
                    Dim tempWarp As New Thread
                    tempWarp.x_Start = reader.ReadInt32()
                    tempWarp.x_End = reader.ReadInt32()
                    tempWarp.y_Start = reader.ReadInt32()
                    tempWarp.y_End = reader.ReadInt32()
                    tempWarp.color = Color.FromArgb(reader.ReadInt32())
                    Warps.Add(tempWarp)
                Next

                'Get the information for the intersections
                For XAttribute As Integer = 1 To intersectCount
                    Dim tempIntersect As New intersection
                    tempIntersect.x_Start = reader.ReadInt32()
                    tempIntersect.x_End = reader.ReadInt32()
                    tempIntersect.y_Start = reader.ReadInt32()
                    tempIntersect.y_End = reader.ReadInt32()
                    tempIntersect.weftThread = reader.ReadInt32()
                    tempIntersect.warpThread = reader.ReadInt32()
                tempIntersect.Heddle_Pos_Up = reader.ReadBoolean()
                Intersections.Add(tempIntersect)
                Next

            Catch ex As Exception
                e = ex
                reader.Close()
            Return True
            Finally
                reader.Close()
            End Try

        Return False
    End Function

    'Josh Lee 11/23/12: dropped in favor of just redrawing the full pattern may revsit at later date to fully 
    'impliment this sub to increase program effecency
    Private Sub updateHeddles(ByVal warp As Thread, ByVal weft As Thread, ByVal intersect As intersection)
        'Update the pattern
        If intersect.Heddle_Pos_Up Then
            'The warp will be over the weft so redraw the warp
            For y As Integer = intersect.y_Start To intersect.y_End
                For x As Integer = weft.x_Start To weft.x_End
                    pattern.SetPixel(x, y, weft.color)
                Next
            Next
        Else
            'The weft will be over the warp
            For y As Integer = warp.y_Start To warp.y_End
                For x As Integer = intersect.x_Start To intersect.x_End
                    pattern.SetPixel(x, y, warp.color)
                Next
            Next
        End If
    End Sub
End Class
