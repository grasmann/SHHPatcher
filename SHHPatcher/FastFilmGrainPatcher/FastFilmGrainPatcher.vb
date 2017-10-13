Imports System.IO
Imports System.ComponentModel
Imports System.Configuration

Public Class FastFilmGrainPatcher

    Private Files As New List(Of FilmGrainFile)
    Private WithEvents Worker As New BackgroundWorker
    Private WithEvents RestoreWorker As New BackgroundWorker

    Private Progress As Integer
    Private Message As String

    Public Sub New()

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.

        Dim Index As Integer = 0
        Files.Add(New FilmGrainFile("GLOBAL.PAK"))
        Files(Index).FilmGrainTextures.Add(New FilmGrainTexture(104644660, New load_ui_grainc))
        Index += 1
        Files.Add(New FilmGrainFile("M01_NIGHTMARE.PAK"))
        Files(Index).FilmGrainTextures.Add(New FilmGrainTexture(12574772, New grain_flashback))
        Files(Index).FilmGrainTextures.Add(New FilmGrainTexture(12886068, New grain_b))
        Files(Index).FilmGrainTextures.Add(New FilmGrainTexture(13062196, New grain2))
        Index += 1
        Files.Add(New FilmGrainFile("M02_SGTOWN1.PAK"))
        Files(Index).FilmGrainTextures.Add(New FilmGrainTexture(17123380, New grain_flashback))
        Files(Index).FilmGrainTextures.Add(New FilmGrainTexture(17434676, New grain_b))
        Files(Index).FilmGrainTextures.Add(New FilmGrainTexture(17610804, New grain))
        Files(Index).FilmGrainTextures.Add(New FilmGrainTexture(17655860, New grain2))
        Index += 1
        Files.Add(New FilmGrainFile("M03_ALEX1.PAK"))
        Files(Index).FilmGrainTextures.Add(New FilmGrainTexture(15456308, New grain_flashback))
        Files(Index).FilmGrainTextures.Add(New FilmGrainTexture(15634484, New grain_b))
        Index += 1
        Files.Add(New FilmGrainFile("M04_SGTOWN2.PAK"))
        Files(Index).FilmGrainTextures.Add(New FilmGrainTexture(23070772, New grain_flashback))
        Files(Index).FilmGrainTextures.Add(New FilmGrainTexture(23382068, New grain_b))
        Index += 1
        Files.Add(New FilmGrainFile("M05_HOTEL.PAK"))
        Files(Index).FilmGrainTextures.Add(New FilmGrainTexture(15048756, New grain_flashback))
        Files(Index).FilmGrainTextures.Add(New FilmGrainTexture(15360052, New grain_b))
        Files(Index).FilmGrainTextures.Add(New FilmGrainTexture(15536180, New grain2))
        Index += 1
        Files.Add(New FilmGrainFile("M06_SGTOWN3.PAK"))
        Files(Index).FilmGrainTextures.Add(New FilmGrainTexture(16945204, New grain_flashback))
        Files(Index).FilmGrainTextures.Add(New FilmGrainTexture(17256500, New grain_b))
        Index += 1
        Files.Add(New FilmGrainFile("M06_SGTOWN3B.PAK"))
        Files(Index).FilmGrainTextures.Add(New FilmGrainTexture(23679028, New grain_flashback))
        Files(Index).FilmGrainTextures.Add(New FilmGrainTexture(23990324, New grain_b))
        Index += 1
        Files.Add(New FilmGrainFile("M07_DESCENT.PAK"))
        Files(Index).FilmGrainTextures.Add(New FilmGrainTexture(49924148, New grain_flashback))
        Files(Index).FilmGrainTextures.Add(New FilmGrainTexture(50235444, New grain2))
        Index += 1
        Files.Add(New FilmGrainFile("M08_SGTOWN4.PAK"))
        Files(Index).FilmGrainTextures.Add(New FilmGrainTexture(10102836, New grain_flashback))
        Files(Index).FilmGrainTextures.Add(New FilmGrainTexture(10414132, New grain_b))
        Index += 1
        Files.Add(New FilmGrainFile("M09_050B_LAKE.PAK"))
        Files(Index).FilmGrainTextures.Add(New FilmGrainTexture(29284404, New grain_flashback))
        Files(Index).FilmGrainTextures.Add(New FilmGrainTexture(29595700, New grain))
        Index += 1
        Files.Add(New FilmGrainFile("M09_ALEX2.PAK"))
        Files(Index).FilmGrainTextures.Add(New FilmGrainTexture(31404084, New grain_flashback))
        Files(Index).FilmGrainTextures.Add(New FilmGrainTexture(31715380, New grain2))
        Files(Index).FilmGrainTextures.Add(New FilmGrainTexture(31760436, New grain))
        Index += 1
        Files.Add(New FilmGrainFile("M10A_SHTOWN1.PAK"))
        Files(Index).FilmGrainTextures.Add(New FilmGrainTexture(13983796, New grain_flashback))
        Files(Index).FilmGrainTextures.Add(New FilmGrainTexture(14295092, New grain_b))
        Index += 1
        Files.Add(New FilmGrainFile("M10B_SHTOWN2.PAK"))
        Files(Index).FilmGrainTextures.Add(New FilmGrainTexture(16054324, New grain_flashback))
        Files(Index).FilmGrainTextures.Add(New FilmGrainTexture(16365620, New grain_b))
        Index += 1
        Files.Add(New FilmGrainFile("M11_PRISON.PAK"))
        Files(Index).FilmGrainTextures.Add(New FilmGrainTexture(14743604, New grain_flashback))
        Files(Index).FilmGrainTextures.Add(New FilmGrainTexture(15054900, New grain_b))
        Files(Index).FilmGrainTextures.Add(New FilmGrainTexture(15231028, New grain2))
        Files(Index).FilmGrainTextures.Add(New FilmGrainTexture(15276084, New grain_video))
        Index += 1
        Files.Add(New FilmGrainFile("M13_CHURCH.PAK"))
        Files(Index).FilmGrainTextures.Add(New FilmGrainTexture(22112308, New grain_flashback))
        Files(Index).FilmGrainTextures.Add(New FilmGrainTexture(22423604, New grain2))
        Index += 1
        Files.Add(New FilmGrainFile("M14_LAIR.PAK"))
        Files(Index).FilmGrainTextures.Add(New FilmGrainTexture(8855604, New grain_flashback))
        Files(Index).FilmGrainTextures.Add(New FilmGrainTexture(9031732, New grain_b))
        Files(Index).FilmGrainTextures.Add(New FilmGrainTexture(9207860, New grain_c))
        Index += 1
        Files.Add(New FilmGrainFile("M15_010_010.PAK"))
        Files(Index).FilmGrainTextures.Add(New FilmGrainTexture(9132084, New grain_flashback))
        Files(Index).FilmGrainTextures.Add(New FilmGrainTexture(9441332, New grain_b))
        Index += 1
        Files.Add(New FilmGrainFile("M15_020.PAK"))
        Files(Index).FilmGrainTextures.Add(New FilmGrainTexture(11720756, New grain_flashback))
        Files(Index).FilmGrainTextures.Add(New FilmGrainTexture(11898932, New grain_b))
        Index += 1
        Files.Add(New FilmGrainFile("M15_030_010.PAK"))
        Files(Index).FilmGrainTextures.Add(New FilmGrainTexture(10836020, New grain_flashback))
        Files(Index).FilmGrainTextures.Add(New FilmGrainTexture(11147316, New grain_b))
        Files(Index).FilmGrainTextures.Add(New FilmGrainTexture(11323444, New grain2))
        Files(Index).FilmGrainTextures.Add(New FilmGrainTexture(11368500, New grain03))
        Index += 1
        Files.Add(New FilmGrainFile("M15_040.PAK"))
        Files(Index).FilmGrainTextures.Add(New FilmGrainTexture(30355508, New grain_flashback))
        Files(Index).FilmGrainTextures.Add(New FilmGrainTexture(30664756, New grain_b))
        Index += 1
        Files.Add(New FilmGrainFile("M15_045_010.PAK"))
        Files(Index).FilmGrainTextures.Add(New FilmGrainTexture(13125684, New grain_flashback))
        Files(Index).FilmGrainTextures.Add(New FilmGrainTexture(13434932, New grain_b))
        Index += 1
        Files.Add(New FilmGrainFile("M15_060.PAK"))
        Files(Index).FilmGrainTextures.Add(New FilmGrainTexture(11001908, New grain_flashback))
        Files(Index).FilmGrainTextures.Add(New FilmGrainTexture(11180084, New grain_b))
        Index += 1
        Files.Add(New FilmGrainFile("SHELL.PAK"))
        Files(Index).FilmGrainTextures.Add(New FilmGrainTexture(13137972, New grain_flashback))        

    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click

        Dim openFileDialog1 As New OpenFileDialog()
        openFileDialog1.Filter = "GLOBAL.PAK|GLOBAL.PAK"
        openFileDialog1.Title = "Select GLOBAL.PAK from the Silent Hill Homecoming PAK folder."

        ' Show the Dialog.
        If openFileDialog1.ShowDialog() = System.Windows.Forms.DialogResult.OK Then
            Dim dir As String = Folder(openFileDialog1.FileName)
            ' Check if directory exists
            If My.Computer.FileSystem.DirectoryExists(dir) Then
                ' Start process
                Worker.RunWorkerAsync(dir)
            End If

        End If

    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click

        If MySettings.ButtonsPatched And MySettings.PatchedFirst = MySettings.Patches.Grain Then
            My.Computer.Audio.PlaySystemSound(System.Media.SystemSounds.Exclamation)
            MsgBox("Please remove the button icon patch first." + vbCrLf + "The patches share a file that has to be patched which leads to a backup conflict.", MsgBoxStyle.OkOnly, "Backup conflict")
        Else
            RestoreWorker.RunWorkerAsync()
        End If

    End Sub

    Private Sub UpdateProgress()

        If Me.InvokeRequired Then
            Me.Invoke(New MethodInvoker(AddressOf UpdateProgress))
        Else
            ProgressBar1.Value = Progress
        End If

    End Sub

    Private Sub ClearConsole()

        If Me.InvokeRequired Then
            Me.Invoke(New MethodInvoker(AddressOf ClearConsole))
        Else
            ListBox1.Items.Clear()
        End If

    End Sub

    Private Sub UpdateConsole()

        If Me.InvokeRequired Then
            Me.Invoke(New MethodInvoker(AddressOf UpdateConsole))
        Else
            ListBox1.Items.Add(Message)
            ListBox1.TopIndex = ListBox1.Items.Count - 1
        End If

    End Sub

    Private Sub UpdateLabel()

        If Me.InvokeRequired Then
            Me.Invoke(New MethodInvoker(AddressOf UpdateLabel))
        Else
            Label1.Text = Message
        End If

    End Sub

    Private Sub UpdateButton()

        If Me.InvokeRequired Then
            Me.Invoke(New MethodInvoker(AddressOf UpdateButton))
        Else
            Button1.Enabled = Not Button1.Enabled
        End If

    End Sub

    Private Sub UpdateButtons()

        If Me.InvokeRequired Then
            Me.Invoke(New MethodInvoker(AddressOf UpdateButtons))
        Else
            Button1.Enabled = Not MySettings.GrainPatched
            Button2.Enabled = MySettings.GrainPatched
        End If

    End Sub

    Private Sub bw_DoWork(ByVal sender As Object, ByVal e As DoWorkEventArgs) Handles Worker.DoWork
        Dim dir As String = e.Argument
        Dim filepath As String = String.Empty

        ClearConsole()
        Message = "Patching ..."
        UpdateConsole()
        UpdateLabel()
        UpdateButton()

        If My.Computer.FileSystem.DirectoryExists(dir) Then

            MySettings.PAKPath = dir

            Progress = 0
            UpdateProgress()

            For Each File As FilmGrainFile In Files
                filepath = dir + "\" + File.Name
                Message = "Patching file '" + filepath + "' ..."
                UpdateConsole()

                CreateBackup(filepath)

                Using fsWrite As FileStream = New FileStream(filepath, FileMode.Open, FileAccess.Write)

                    For Each GrainTexture As FilmGrainTexture In File.FilmGrainTextures                        
                        fsWrite.Seek(GrainTexture.Position + GrainTexture.Texture.Offset, SeekOrigin.Begin)
                        If CheckBox1.Checked And GrainTexture.Texture.Name = "grain2.tga" Then
                            ' Replace "grain2.tga"
                            fsWrite.Write(GrainTexture.Texture.ReplaceData, 0, GrainTexture.Texture.Size)
                        Else
                            Dim arr2(GrainTexture.Texture.Size) As Byte
                            fsWrite.Write(arr2, 0, GrainTexture.Texture.Size)
                        End If
                    Next

                End Using

                Progress += 1
                UpdateProgress()                

            Next

            Message = "Finished!"
            UpdateConsole()
            Message = String.Empty
            UpdateLabel()
            UpdateButton()

            If Not MySettings.ButtonsPatched Then
                MySettings.PatchedFirst = MySettings.Patches.Grain
            End If
            MySettings.GrainPatched = True
            My.Computer.Audio.PlaySystemSound(System.Media.SystemSounds.Asterisk)
            UpdateButtons()

        End If
    End Sub

    Private Sub bw_Restore_DoWork(ByVal sender As Object, ByVal e As DoWorkEventArgs) Handles RestoreWorker.DoWork
        Dim filepath As String = String.Empty

        ClearConsole()
        Message = "Restoring ..."
        UpdateConsole()
        UpdateLabel()
        UpdateButton()

        If Not String.IsNullOrEmpty(MySettings.PAKPath) And MySettings.GrainPatched Then

            Progress = 0
            UpdateProgress()

            For Each File As FilmGrainFile In Files

                filepath = MySettings.PAKPath + "\" + File.Name

                Message = "Restoring file '" + filepath + "' ..."
                UpdateConsole()

                RestoreBackup(filepath)

                Progress += 1
                UpdateProgress()

            Next
        End If

        Message = "Finished!"
        UpdateConsole()
        Message = String.Empty
        UpdateLabel()
        UpdateButton()

        MySettings.GrainPatched = False
        My.Computer.Audio.PlaySystemSound(System.Media.SystemSounds.Asterisk)
        UpdateButtons()

    End Sub

    Private Sub CreateBackup(ByVal Path As String)
        If My.Computer.FileSystem.FileExists(Path) Then
            Dim BackupPath As String = NormalToBackup(Path)
            If Not My.Computer.FileSystem.FileExists(BackupPath) Then
                My.Computer.FileSystem.CopyFile(Path, BackupPath)
            End If
        End If
    End Sub

    Private Sub RestoreBackup(ByVal Path As String)
        If My.Computer.FileSystem.FileExists(Path) Then
            Dim BackupPath As String = NormalToBackup(Path)
            If My.Computer.FileSystem.FileExists(BackupPath) Then
                My.Computer.FileSystem.DeleteFile(Path)
                My.Computer.FileSystem.RenameFile(BackupPath, FileName(Path))
            End If
        End If
    End Sub

    Private Function NormalToBackup(ByVal Path As String)
        Dim point As Integer = InStrRev(Path, ".")
        Return Microsoft.VisualBasic.Left(Path, point - 1) + ".BAK." + Microsoft.VisualBasic.Right(Path, Path.Length - point)
    End Function

    Private Function FileName(ByVal Path As String) As String
        Dim Slash As Integer = InStrRev(Path, "/")
        If Slash <= 0 Then Slash = InStrRev(Path, "\")
        If Slash > 0 Then
            Return Microsoft.VisualBasic.Right(Path, Path.Length - Slash)
        End If
        Return String.Empty
    End Function

    Private Function Folder(ByVal Path As String) As String
        Dim Slash As Integer = InStrRev(Path, "/")
        If Slash <= 0 Then Slash = InStrRev(Path, "\")
        If Slash > 0 Then
            Return Microsoft.VisualBasic.Left(Path, Slash - 1)
        End If
        Return String.Empty
    End Function

    Private Sub CheckBox1_MouseEnter(sender As Object, e As EventArgs) Handles CheckBox1.MouseEnter
        TextBox1.Text = "One of the film grain textures contains an orange color tone that can enhance the game graphic." + vbCrLf + _
            "With this option this particular texture is replaced by a cleaned up version instead of removed completely."
    End Sub

    Private Sub CheckBox2_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBox2.CheckedChanged

        Dim Anchors(Me.Controls.Count) As AnchorStyles
        For c = 0 To Me.Controls.Count - 1
            Anchors(c) = Me.Controls(c).Anchor
            Me.Controls(c).Anchor = AnchorStyles.Left + AnchorStyles.Top
        Next

        If CheckBox2.Checked Then
            Me.Height += 76
        Else
            Me.Height -= 76
        End If

        MySettings.GrainAdvanced = CheckBox2.Checked

        For c = 0 To Me.Controls.Count - 1
            Me.Controls(c).Anchor = Anchors(c)
        Next

    End Sub

    Private Sub CheckBox1_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBox1.CheckedChanged
        MySettings.GrainGrain2Replace = CheckBox1.Checked
    End Sub

    Private Sub FastFilmGrainPatcher_Shown(sender As Object, e As EventArgs) Handles MyBase.Shown
        UpdateButtons()
        Me.CheckBox2.Checked = MySettings.GrainAdvanced
        Me.CheckBox1.Checked = MySettings.GrainGrain2Replace
    End Sub

End Class