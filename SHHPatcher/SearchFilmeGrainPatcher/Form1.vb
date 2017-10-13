Public Class Form1

    Dim WithEvents FilmGrainPatcher As New FilmGrainPatcher

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click

        FilmGrainPatcher.Patch()

    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click

        FilmGrainPatcher.Cancel()

    End Sub

    Private Sub UpdateProgress() Handles FilmGrainPatcher.UpdateProgress

        If Me.InvokeRequired Then
            Me.Invoke(New MethodInvoker(AddressOf UpdateProgress))
        Else
            ProgressBar1.Value = FilmGrainPatcher.ProgressValue1
        End If

    End Sub

    Private Sub UpdateProgress2() Handles FilmGrainPatcher.UpdateProgress2

        If Me.InvokeRequired Then
            Me.Invoke(New MethodInvoker(AddressOf UpdateProgress2))
        Else
            ProgressBar2.Value = FilmGrainPatcher.ProgressValue2
        End If

    End Sub

    Private Sub UpdateConsole() Handles FilmGrainPatcher.UpdateConsole

        If Me.InvokeRequired Then
            Me.Invoke(New MethodInvoker(AddressOf UpdateConsole))
        Else
            ListBox1.Items.Add(FilmGrainPatcher.Message)
            ListBox1.TopIndex = ListBox1.Items.Count - 1
        End If

    End Sub

    Private Sub Form1_FormClosing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing
        If FilmGrainPatcher.IsRunning Then
            e.Cancel = True
        End If
    End Sub

End Class
