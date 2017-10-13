Public Class Texture

    Private _size As ULong
    Private _offset As Integer
    Private _replacedata As Byte()
    Private _name As String

    Public Sub New()
    End Sub

    Public Sub New(ByVal Size As ULong, ByVal Offset As Integer, ByVal ReplaceData As Byte(), Optional ByVal Name As String = "")
        _size = Size
        _offset = Offset
        _replacedata = ReplaceData
        _name = Name
    End Sub

    Public ReadOnly Property Offset As Integer
        Get
            Return _offset
        End Get
    End Property

    Public ReadOnly Property Size As ULong
        Get
            Return _size
        End Get
    End Property

    Public ReadOnly Property ReplaceData As Byte()
        Get
            Return _replacedata
        End Get
    End Property

    Public ReadOnly Property Name As String
        Get
            Return _name
        End Get
    End Property

End Class
