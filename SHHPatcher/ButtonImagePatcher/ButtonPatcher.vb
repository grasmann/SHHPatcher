Imports System.ComponentModel
Imports System.IO
Imports System.Configuration

Public Class ButtonPatcher

    Private WithEvents Worker As New BackgroundWorker
    Private Textures As New List(Of ButtonTexture)
    Private Working As Boolean

    Public Sub New()

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.

        UpdateButtons()

    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        'PS
        If Not Working Then
            Dim Path As String = Openfile()

            If My.Computer.FileSystem.FileExists(Path) Then
                MySettings.PAKPath = Folder(Path)
                Textures.Clear()
                Textures.Add(New ps_x)
                Textures.Add(New ps_circle)
                Textures.Add(New ps_square)
                Textures.Add(New ps_triangle)
                Textures.Add(New ps_x_flash)
                Textures.Add(New ps_circle_flash)
                Textures.Add(New ps_square_flash)
                Textures.Add(New ps_triangle_flash)
                MySettings.ButtonChoice = MySettings.Buttons.Playstation
                Worker.RunWorkerAsync(Path)
            End If
        End If

    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        'XBox
        If Not Working Then
            Dim Path As String = Openfile()

            If My.Computer.FileSystem.FileExists(Path) And Not Working Then
                MySettings.PAKPath = Folder(Path)
                Textures.Clear()
                Textures.Add(New xbox_a)
                Textures.Add(New xbox_b)
                Textures.Add(New xbox_x)
                Textures.Add(New xbox_y)
                Textures.Add(New xbox_a_flash)
                Textures.Add(New xbox_b_flash)
                Textures.Add(New xbox_x_flash)
                Textures.Add(New xbox_y_flash)
                MySettings.ButtonChoice = MySettings.Buttons.XBox
                Worker.RunWorkerAsync(Path)
            End If
        End If

    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        If MySettings.GrainPatched And MySettings.PatchedFirst = MySettings.Patches.Buttons Then
            My.Computer.Audio.PlaySystemSound(System.Media.SystemSounds.Exclamation)
            MsgBox("Please remove the film grain patch first." + vbCrLf + "The patches share a file that has to be patched which leads to a backup conflict.", MsgBoxStyle.OkOnly, "Backup conflict")
        Else
            If RestoreBackup(MySettings.PAKPath + "\GLOBAL.PAK") Then
                MySettings.ButtonsPatched = False
                My.Computer.Audio.PlaySystemSound(System.Media.SystemSounds.Asterisk)
                UpdateButtons()
            End If
        End If
    End Sub

    Private Sub UpdateButtons()

        If Me.InvokeRequired Then
            Me.Invoke(New MethodInvoker(AddressOf UpdateButtons))
        Else
            Label1.Visible = False
            Label2.Visible = False
            Me.Button1.Enabled = Not MySettings.ButtonsPatched
            If MySettings.ButtonsPatched And MySettings.ButtonChoice = MySettings.Buttons.Playstation Then
                Label1.Visible = True
            End If
            Me.Button2.Enabled = Not MySettings.ButtonsPatched
            If MySettings.ButtonsPatched And MySettings.ButtonChoice = MySettings.Buttons.XBox Then
                Label2.Visible = True
            End If
            Me.Button3.Enabled = MySettings.ButtonsPatched
        End If

    End Sub

    Private Sub bw_DoWork(ByVal sender As Object, ByVal e As DoWorkEventArgs) Handles Worker.DoWork
        Dim filepath As String = e.Argument
        Working = True

        CreateBackup(filepath)

        For Each ButtonTexture As ButtonTexture In Textures
            Using fsWrite As FileStream = New FileStream(filepath, FileMode.Open, FileAccess.Write)
                fsWrite.Seek(ButtonTexture.Offset, SeekOrigin.Begin)
                fsWrite.Write(ButtonTexture.ImageData, 0, ButtonTexture.ImageData.Length)
            End Using
        Next

        If Not MySettings.GrainPatched Then
            MySettings.PatchedFirst = MySettings.Patches.Buttons
        End If
        MySettings.ButtonsPatched = True
        My.Computer.Audio.PlaySystemSound(System.Media.SystemSounds.Asterisk)
        UpdateButtons()

        Working = False
    End Sub

    Private Function Openfile() As String

        Dim openFileDialog1 As New OpenFileDialog()
        openFileDialog1.Filter = "GLOBAL.PAK|GLOBAL.PAK"
        openFileDialog1.Title = "Select GLOBAL.PAK from the Silent Hill Homecoming PAK folder."

        ' Show the Dialog.
        If openFileDialog1.ShowDialog() = System.Windows.Forms.DialogResult.OK Then
            Dim file As String = openFileDialog1.FileName
            ' Check if directory exists
            If My.Computer.FileSystem.FileExists(file) Then
                ' Start process
                Return file
            End If

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

    Private Sub CreateBackup(ByVal Path As String)
        If My.Computer.FileSystem.FileExists(Path) Then
            Dim BackupPath As String = NormalToBackup(Path)
            If Not My.Computer.FileSystem.FileExists(BackupPath) Then
                My.Computer.FileSystem.CopyFile(Path, BackupPath)
            End If
        End If
    End Sub

    Private Function RestoreBackup(ByVal Path As String) As Boolean
        If My.Computer.FileSystem.FileExists(Path) Then
            Dim BackupPath As String = NormalToBackup(Path)
            If My.Computer.FileSystem.FileExists(BackupPath) Then
                My.Computer.FileSystem.DeleteFile(Path)
                My.Computer.FileSystem.RenameFile(BackupPath, FileName(Path))
                Return True
            End If
        End If
        Return False
    End Function

    Private Function NormalToBackup(ByVal Path As String)
        Dim point As Integer = InStrRev(Path, ".")
        Return Microsoft.VisualBasic.Left(Path, point - 1) + ".BAK_BUTTON." + Microsoft.VisualBasic.Right(Path, Path.Length - point)
    End Function

    Private Function FileName(ByVal Path As String) As String
        Dim Slash As Integer = InStrRev(Path, "/")
        If Slash <= 0 Then Slash = InStrRev(Path, "\")
        If Slash > 0 Then
            Return Microsoft.VisualBasic.Right(Path, Path.Length - Slash)
        End If
        Return String.Empty
    End Function

End Class