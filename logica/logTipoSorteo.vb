Public Class logTipoSorteo 'incorpora las propiedades de tipo de sorteo para trabajar con la bd.
    Dim ID As Integer
    Dim Nombre, Descripcion As String

    Public Property pID
        Get
            Return ID
        End Get
        Set(value)
            ID = value
        End Set
    End Property
    Public Property pNombre
        Get
            Return Nombre
        End Get
        Set(value)
            Nombre = value
        End Set
    End Property
    Public Property pDescripcion
        Get
            Return Descripcion
        End Get
        Set(value)
            Descripcion = value
        End Set
    End Property

    Public Sub New()

    End Sub

    Public Sub New(ByVal ID As Integer, ByVal Nombre As String, ByVal Descripcion As String)
        pID = ID
        pNombre = Nombre
        pDescripcion = Descripcion
    End Sub


End Class
