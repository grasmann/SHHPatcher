Public Class FilmGrainTexture

    Private _position As ULong
    Private _texture As Texture
    'Private _size As ULong

    Public Sub New(ByVal Position As ULong, ByVal Texture As Texture)
        _position = Position
        _texture = Texture
        '_size = Size
    End Sub

    Public ReadOnly Property Position As ULong
        Get
            Return _position
        End Get
    End Property

    Public ReadOnly Property Texture As Texture
        Get
            Return _texture
        End Get
    End Property

    'Public ReadOnly Property Size As ULong
    '    Get
    '        Return _size
    '    End Get
    'End Property

End Class
