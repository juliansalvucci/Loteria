Public Class logUsuario
    Dim ID As Integer
    Dim NombreUsu, Login, Password As String
    Dim Habilitado As Int16
    Dim Fecha As Date

    Public Property pID 'pID: ID  de propiedad.
        Get
            Return ID
        End Get
        Set(value)
            ID = value
        End Set
    End Property

    Public Property pFecha 'pID: ID  de propiedad.
        Get
            Return Fecha
        End Get
        Set(value)
            Fecha = value
        End Set
    End Property
    Public Property pNombreUsu
        Get
            Return NombreUsu
        End Get
        Set(value)
            NombreUsu = value
        End Set
    End Property
    Public Property pLogin
        Get
            Return Login
        End Get
        Set(value)
            Login = value
        End Set
    End Property
    Public Property pPassword
        Get
            Return Password
        End Get
        Set(value)
            Password = value
        End Set
    End Property

    Public Property pHabilitado
        Get
            Return Habilitado
        End Get
        Set(value)
            Habilitado = value
        End Set
    End Property
    Public Sub New()
    End Sub

    Public Sub New(ByVal ID As Integer, ByVal Fecha As Date, ByVal NombreUsu As String, ByVal Login As String, ByVal Password As String, ByVal Habilitado As Byte)
        pID = ID
        pFecha = Fecha
        pNombreUsu = NombreUsu
        pLogin = Login
        pPassword = Password
        pHabilitado = Habilitado
    End Sub
End Class
