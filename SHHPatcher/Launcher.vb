Public Class Launcher

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click

        Dim FastFGPatcher As New FastFilmGrainPatcher
        FastFGPatcher.ShowDialog()

    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click

        Dim ButtonPatcher As New ButtonPatcher
        ButtonPatcher.ShowDialog()

    End Sub

End Class