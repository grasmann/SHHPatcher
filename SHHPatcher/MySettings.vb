Public Class MySettings

    Private Const app_name As String = "SHHPatcher"
    Private Const app_version As String = "3.0"

    Private Const setting_grain_patched As String = "GrainPatched"
    Private Const setting_grain_advanced As String = "GrainAdvanced"
    Private Const setting_grain_grain2_replace As String = "GrainGrain2Replace"
    Private Const settins_buttons_patched As String = "ButtonsPatched"
    Private Const settins_button_choice As String = "ButtonChoice"
    Private Const setting_patched_first As String = "PatchedFirst"
    Private Const setting_pak_path As String = "PAKPath"

    Private Shared Function Get_Setting(ByVal SettingName As String) As String
        Return GetSetting(app_name, app_version, SettingName)
    End Function

    Private Shared Sub Set_Setting(ByVal SettingName As String, ByVal Value As String)
        SaveSetting(app_name, app_version, SettingName, Value)
    End Sub

    Public Shared Property GrainPatched As Boolean
        Get
            Return Get_Setting(setting_grain_patched) = "True"
        End Get
        Set(value As Boolean)
            Set_Setting(setting_grain_patched, IIf(value, "True", "False"))
        End Set
    End Property

    Public Enum Patches
        None
        Buttons
        Grain
    End Enum
    Public Shared Property PatchedFirst As Patches
        Get
            Select Case (Get_Setting(setting_patched_first))
                Case "Buttons" : Return Patches.Buttons
                Case "Grain" : Return Patches.Grain
                Case Else : Return Patches.None
            End Select
        End Get
        Set(value As Patches)
            Select Case value
                Case Patches.Buttons : Set_Setting(setting_patched_first, "Buttons")
                Case Patches.Grain : Set_Setting(setting_patched_first, "Grain")
            End Select
        End Set
    End Property

    Public Shared Property ButtonsPatched As Boolean
        Get
            Return Get_Setting(settins_buttons_patched) = "True"
        End Get
        Set(value As Boolean)
            Set_Setting(settins_buttons_patched, IIf(value, "True", "False"))
        End Set
    End Property

    Public Enum Buttons
        None
        Playstation
        XBox
    End Enum
    Public Shared Property ButtonChoice As Buttons
        Get
            Select Case Get_Setting(settins_button_choice)
                Case "Playstation" : Return Buttons.Playstation
                Case "XBox" : Return Buttons.XBox
                Case Else : Return Buttons.None
            End Select
        End Get
        Set(value As Buttons)
            Select Case value
                Case Buttons.Playstation : Set_Setting(settins_button_choice, "Playstation")
                Case Buttons.XBox : Set_Setting(settins_button_choice, "XBox")
            End Select
        End Set
    End Property

    Public Shared Property PAKPath As String
        Get
            Return Get_Setting(setting_pak_path)
        End Get
        Set(value As String)
            Set_Setting(setting_pak_path, value)
        End Set
    End Property

    Public Shared Property GrainAdvanced As Boolean
        Get
            Return Get_Setting(setting_grain_advanced) = "True"
        End Get
        Set(value As Boolean)
            Set_Setting(setting_grain_advanced, IIf(value, "True", "False"))
        End Set
    End Property

    Public Shared Property GrainGrain2Replace As Boolean
        Get
            Return Get_Setting(setting_grain_grain2_replace) = "True"
        End Get
        Set(value As Boolean)
            Set_Setting(setting_grain_advanced, IIf(value, "True", "False"))
        End Set
    End Property

End Class
