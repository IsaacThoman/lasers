Public Class Form1
    Dim selected(15, 15) As Boolean
    Dim pointsX(15, 15) As Integer
    Dim pointsY(15, 15) As Integer

    Dim lastSelectionx As Integer
    Dim lastSelectiony As Integer

    Dim lineStart As Integer

    Function renderer()



        Dim rects(15, 15)

        Dim surface As Graphics = CreateGraphics()
        Dim Brush1 As Brush
        Dim solidBrushGreen As SolidBrush = New SolidBrush(Color.DarkGreen)
        Dim solidBrushBlack As SolidBrush = New SolidBrush(Color.Red)
        Dim solidBrushYellow As SolidBrush = New SolidBrush(Color.LightYellow)

        For fillerx = 1 To 15
            For fillery = 1 To 15
                rects(fillerx, fillery) = New Rectangle((fillerx * 32) - 32 + 200, (fillery * 32) + 20, 4, 4)
                pointsX(fillerx, fillery) = (fillerx * 32) - 32 + 200
                pointsY(fillerx, fillery) = (fillery * 32) + 20

                If selected(fillerx, fillery) Then
                    surface.FillRectangle(solidBrushBlack, rects(fillerx, fillery))
                Else
                    surface.FillRectangle(solidBrushGreen, rects(fillerx, fillery))
                End If


            Next
        Next


        For line = 1 To 15


        Next



    End Function



    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        ' Dim surface As Graphics = CreateGraphics()
        ' surface.Clear(Color.FloralWhite)
        For fillerx = 1 To 15
            For fillery = 1 To 15

            Next
        Next
        lastSelectionx = 0
        lastSelectiony = 0
        renderer()
    End Sub

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    Private Sub Form1_Click(sender As Object, e As EventArgs) Handles Me.Click
        Dim mouseX = MousePosition.X - Me.Left - 8
        Dim mouseY = MousePosition.Y - Me.Top - 40
        Dim smallestNumber As Integer = 100
        Dim smallestNumbery As Integer = 100
        Dim selX As Integer
        Dim selY As Integer


        For fillerx = 1 To 15
            For fillerY = 1 To 15
                If (Math.Abs(mouseX - pointsX(fillerx, fillerY))) < smallestNumber Then
                    selX = fillerx
                    smallestNumber = (Math.Abs(mouseX - pointsX(fillerx, fillerY)))

                End If

                If (Math.Abs(mouseY - pointsY(fillerx, fillerY))) < smallestNumber Then
                    selY = fillerY
                    smallestNumbery = (Math.Abs(mouseX - pointsX(fillerx, fillerY)))

                End If


                '    Button1.Text = mouseX & ", " & mouseY
                ' Button1.Text = (Math.Abs(mouseX - pointsX(fillerx, fillerY))) + (Math.Abs(mouseY - pointsY(fillerx, fillerY)))
                Button1.Text = selX & ", " & selY

            Next
        Next

        selected(selX, selY) = True
        Dim Pen = Me.CreateGraphics()
        ' (fillerx * 32) - 32 + 200, (fillery * 32) + 20, 4, 4)
        If lastSelectiony > 0 Then
            Pen.DrawLine(Pens.Red, (lastSelectionx * 32) - 32 + 200, (lastSelectiony * 32) + 20, (selX * 32) - 32 + 200, (selY * 32) + 20)
        End If

        lastSelectionx = selX
        lastSelectiony = selY

        renderer()
    End Sub
End Class
