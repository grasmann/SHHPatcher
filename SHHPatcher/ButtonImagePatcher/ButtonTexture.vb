Public Class ButtonTexture

    Private _image_data As Byte()
    Private _offset As ULong

    Public Sub New()
    End Sub
    Public Sub New(ByVal Offset As ULong, ByVal ImageData As Byte())
        _offset = Offset
        _image_data = ImageData
    End Sub

    Public ReadOnly Property ImageData As Byte()
        Get
            Return _image_data
        End Get
    End Property

    Public ReadOnly Property Offset As ULong
        Get
            Return _offset
        End Get
    End Property

End Class
