Imports System.IO
Imports System.ComponentModel
Imports System.Timers

Public Class FilmGrainPatcher

    Private PAKWhitelist() As String = {"GLOBAL.PAK", "M01_NIGHTMARE.PAK", "M02_SGTOWN1.PAK", "M03_ALEX1.PAK", "M04_SGTOWN2.PAK", "M05_HOTEL.PAK", "M06_SGTOWN3.PAK", _
    "M06_SGTOWN3B.PAK", "M07_DESCENT.PAK", "M08_SGTOWN4.PAK", "M09_050B_LAKE.PAK", "M09_ALEX2.PAK", "M10A_SHTOWN1.PAK", _
    "M10B_SHTOWN2.PAK", "M11_PRISON.PAK", "M13_CHURCH.PAK", "M14_LAIR.PAK", "M15_010_010.PAK", "M15_020.PAK", _
    "M15_030_010.PAK", "M15_040.PAK", "M15_045_010.PAK", "M15_060.PAK", "SHELL.PAK"}
    Private WhitelistActive As Boolean = False
    'Private Textures() As String = {"grain_flashback.tga", "grain_b.tga", "grain2.tga", "grain.tga", "grain_video.tga", "grain_c.tga", "grain03.tga", "load_ui_grainc"}
    Private Textures() As String = {"greyspec_s.tga", "smoke23_d.tga", "ash01.tga"}
    Private Sizes() As Integer = {176057, 176065, 44994, 44995, 44989, 176065, 176065}
    Private WithEvents Worker As New BackgroundWorker()
    Private running As Boolean = False

    ' Progressbar
    'Public FileCount As Integer
    Public ProgressValue1 As Integer
    'Public Event SetFileCount()
    Public Event UpdateProgress()
    ' Progressbar 2
    'Public FileSize As Integer
    Public ProgressValue2 As Integer
    'Public Event SetFileSize()
    Public Event UpdateProgress2()
    Private WithEvents timer As New Timer(1000)
    ' Console
    Public Message As String
    Public Event UpdateConsole()

    Public ReadOnly Property IsRunning As Boolean
        Get
            Return running
        End Get
    End Property

    Sub New()
        Worker.WorkerReportsProgress = True
        Worker.WorkerSupportsCancellation = True
        timer.Enabled = True
    End Sub

    Public Sub Patch()

        Dim openFileDialog1 As New OpenFileDialog()
        openFileDialog1.Filter = "M01_NIGHTMARE.PAK|M01_NIGHTMARE.PAK"
        openFileDialog1.Title = "Select M01_NIGHTMARE.PAK from the Silent Hill Homecoming PAK folder."

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

    Public Sub Cancel()
        Worker.CancelAsync()
    End Sub

    Private Sub bw_DoWork(ByVal sender As Object, ByVal e As DoWorkEventArgs) Handles Worker.DoWork
        'FilmGrainPatch("F:\SteamLibrary\steamapps\common\Silent Hill Homecoming\Engine\pak\pc")
        ' Path and files
        running = True
        Dim Path As String = e.Argument
        Dim Files As String() = Directory.GetFiles(Path)
        'FileCount = Files.Length
        'RaiseEvent SetFileCount()
        ' Backup
        'Dim deletebackup As Boolean
        'Dim BackupPath As String
        ' Bytes
        Dim bytes() As Byte
        Dim numBytesToRead As Integer
        Dim numBytesRead As Integer
        Dim n As Integer
        ' Compare
        Dim bytestring As String = String.Empty
        Dim ascval As Integer        

        ' Process the list of files found in the directory.
        For Each File As String In Files
            ' Process file if PAK
            If Right(File, 3) = "PAK" And File.Contains("M06_SGTOWN3B") Then 'And (PAKWhitelist.Contains(FileName(File)) Or Not WhitelistActive) Then

                'deletebackup = True
                'BackupPath = CreateBackup(File)

                Using fsSource As FileStream = New FileStream(File, FileMode.Open, FileAccess.Read)

                    Message = "Processing file '" + File + "' ..."
                    RaiseEvent UpdateConsole()
                    Debug.Print("Processing file '" + File + "' ...")

                    ' Read the source file into a byte array.
                    bytes = New Byte((fsSource.Length) - 1) {}
                    numBytesToRead = CType(fsSource.Length, Integer)
                    numBytesRead = 0

                    While (numBytesToRead > 0)
                        ' Read may return anything from 0 to numBytesToRead.
                        n = fsSource.Read(bytes, numBytesRead, numBytesToRead)
                        ' Break when the end of the file is reached.
                        If (n = 0) Then
                            Exit While
                        End If
                        numBytesRead = (numBytesRead + n)
                        numBytesToRead = (numBytesToRead - n)

                    End While
                    numBytesToRead = bytes.Length

                    'FileSize = 100
                    'RaiseEvent SetFileSize()
                    For i As Integer = 0 To bytes.Length - 1

                        ascval = Asc(Convert.ToChar(bytes(i)))
                        If ascval >= 65 And ascval <= 122 Then

                            ' Iterate Textures
                            For t = 0 To Textures.Length - 1
                                'For Each Texture As String In Textures
                                Dim Texture As String = Textures(t)
                                If bytes.Length > i + Texture.Length Then
                                    Dim arr(Texture.Length - 1) As Byte

                                    For i2 = 0 To Texture.Length - 1
                                        arr(i2) = bytes(i + i2)
                                    Next

                                    bytestring = ByteArrayToTextString(arr)

                                    If bytestring = Texture Then
                                        'deletebackup = False

                                        'Using fsWrite As FileStream = New FileStream(File, FileMode.Open, FileAccess.Write)
                                        '    Dim arr2(Sizes(t)) As Byte
                                        '    fsWrite.Seek(i + Texture.Length, SeekOrigin.Begin)
                                        '    fsWrite.Write(arr2, 0, Sizes(t))
                                        'End Using


                                        Message = " > " + bytestring + " patched. > Position: " + i.ToString
                                        RaiseEvent UpdateConsole()
                                        Debug.Print(Message)
                                    End If

                                End If
                            Next

                        End If

                        If i > 0 Then
                            ProgressValue2 = (i / bytes.Length) * 100
                            If ProgressValue2 > 100 Then ProgressValue2 = 100
                        End If

                    Next


                End Using

                'If deletebackup Then
                '    My.Computer.FileSystem.DeleteFile(BackupPath)
                'End If

                Debug.Print("Done")
                ProgressValue1 += 1
                'RaiseEvent UpdateProgress()

            End If

            'Cancel Worker
            If Worker.CancellationPending Then
                timer.Enabled = False
                e.Cancel = True
                Debug.Print("Canceled")
                ProgressValue1 = 0
                'RaiseEvent UpdateProgress()
                ProgressValue2 = 0
                RaiseEvent UpdateProgress2()
                Message = "Canceled"
                RaiseEvent UpdateConsole()
                running = False
                Exit For
            End If
        Next File

        timer.Enabled = False
        Message = "Finished"
        RaiseEvent UpdateConsole()
        running = False

    End Sub

    Private Sub Handler(ByVal sender As Object, ByVal e As ElapsedEventArgs) Handles timer.Elapsed
        RaiseEvent UpdateProgress2()
    End Sub

    Private Function FileName(ByVal Path As String) As String
        Dim Slash As Integer = InStrRev(Path, "/")
        If Slash <= 0 Then Slash = InStrRev(Path, "\")
        If Slash > 0 Then
            Return Right(Path, Path.Length - Slash)
        End If
        Return String.Empty
    End Function

    Private Function Folder(ByVal Path As String) As String
        Dim Slash As Integer = InStrRev(Path, "/")
        If Slash <= 0 Then Slash = InStrRev(Path, "\")
        If Slash > 0 Then
            Return Left(Path, Slash - 1)
        End If
        Return String.Empty
    End Function

    'Private Sub FilmGrainPatch(ByVal Path As String)
    '    Dim fileEntries As String() = Directory.GetFiles(Path)
    '    ' Process the list of files found in the directory.
    '    Dim fileName As String
    '    For Each fileName In fileEntries
    '        If Right(fileName, 3) = "PAK" Then
    '            PatchFile(fileName)
    '        End If
    '    Next fileName
    'End Sub

    Private Function CreateBackup(ByVal Path As String) As String
        Dim point As Integer = InStrRev(Path, ".")
        Dim number As Integer = 1
        Dim BackupPath As String = Path
        If point > 0 Then
            While My.Computer.FileSystem.FileExists(BackupPath)
                BackupPath = Left(Path, point - 1) + ".BAK" + number.ToString + "." + Right(Path, Path.Length - point)
                number += 1
            End While
            My.Computer.FileSystem.CopyFile(Path, BackupPath)
        End If
        Return BackupPath
    End Function

    'Public Function PatchFile(ByVal Path As String) As Boolean

    '    Dim backupcreated As Boolean = False

    '    ' Copy file
    '    'CreateBackup(Path)

    '    Using fsSource As FileStream = New FileStream(Path, FileMode.Open, FileAccess.ReadWrite)

    '        Debug.Print("Processing file '" + Path + "' ...")

    '        ' Read the source file into a byte array.
    '        Dim bytes() As Byte = New Byte((fsSource.Length) - 1) {}
    '        Dim numBytesToRead As Integer = CType(fsSource.Length, Integer)
    '        Dim numBytesRead As Integer = 0

    '        While (numBytesToRead > 0)
    '            ' Read may return anything from 0 to numBytesToRead.
    '            Dim n As Integer = fsSource.Read(bytes, numBytesRead, _
    '                numBytesToRead)
    '            ' Break when the end of the file is reached.
    '            If (n = 0) Then
    '                Exit While
    '            End If
    '            numBytesRead = (numBytesRead + n)
    '            numBytesToRead = (numBytesToRead - n)

    '        End While
    '        numBytesToRead = bytes.Length

    '        Dim bytestring As String = String.Empty
    '        Dim ascval As Integer
    '        For i As Integer = 0 To bytes.Length - 1

    '            'Cancel Worker
    '            If Worker.CancellationPending Then
    '                Worker.CancelAsync()
    '            End If

    '            ascval = Asc(Convert.ToChar(bytes(i)))
    '            If ascval >= 65 And ascval <= 90 Then
    '                'Debug.Print(Convert.ToChar(bytes(i)))

    '                For Each Texture As String In Textures
    '                    If bytes.Length > i + Texture.Length Then
    '                        Dim arr(Texture.Length - 1) As Byte

    '                        For i2 = 0 To Texture.Length - 1
    '                            arr(i2) = bytes(i + i2)
    '                        Next

    '                        bytestring = ByteArrayToTextString(arr)

    '                        If bytestring = Texture Then
    '                            If Not backupcreated Then
    '                                CreateBackup(Path)
    '                            End If

    '                            Debug.Print(bytestring)
    '                        End If

    '                    End If
    '                Next

    '            End If

    '        Next

    '        Debug.Print("Done")

    '    End Using

    '    Return False
    'End Function

    Public Function ByteArrayToString(ByRef Barr() As Byte) As String
        Return Convert.ToBase64String(Barr)
    End Function

    Public Function ByteArrayToTextString(ByRef Barr() As Byte) As String
        Dim enc As System.Text.Encoding = System.Text.Encoding.Default

        Return enc.GetString(Barr)
    End Function

End Class
