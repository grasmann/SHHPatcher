Public Class FilmGrainFile

    Private _name As String
    Private _filmgraintextures As New List(Of FilmGrainTexture)

    Public Sub New(ByVal Name As String)
        _name = Name
    End Sub

    Public ReadOnly Property Name As String
        Get
            Return _name
        End Get
    End Property

    Public ReadOnly Property FilmGrainTextures As List(Of FilmGrainTexture)
        Get
            Return _filmgraintextures
        End Get
    End Property

End Class
