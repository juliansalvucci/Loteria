Public Class logAgencia
    Dim ID As Integer
    Dim Nombre As String
    Dim Porc_ganancia As Decimal


    Public Property pID
        'Declara el nombre de una propiedad y los procedimientos de propiedad usados para almacenar y recuperar el valor de la propiedad.
        'La instrucci�n Property introduce la declaraci�n de una propiedad. 
        'Una propiedad puede tener un procedimiento Get (s�lo lectura), un procedimiento Set (s�lo escritura), o ambos (de lectura y escritura). 
        Get 'Inicia un procedimiento de propiedad Get que se usa para devolver el valor de la propiedad.
            Return ID
        End Get
        Set(value) 'Inicia un procedimiento de propiedad Set que se usa para almacenar el valor de la propiedad.
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

    Public Property pPorc_ganancia
        Get
            Return Porc_ganancia
        End Get
        Set(value)
            Porc_ganancia = value
        End Set
    End Property

    'Creaci�n de los constructores.

    Public Sub New()
        'Mediante el uso de la palabra clave New se crea una instancia de una clase, un objeto. 
        'Visual Basic controla la inicializaci�n de objetos nuevos mediante procedimientos denominados constructores (m�todos especiales que permitan controlar la inicializaci�n).
        'Despu�s de que un objeto abandone el �mbito, se libera por Common Language Runtime (CLR). Visual Basic controla la liberaci�n de recursos del sistema mediante procedimientos denominados destructores. Juntos, los constructores y los destructores permiten la creaci�n de bibliotecas de clases completas y predecibles.

        'El constructor Sub New solo puede ejecutarse una vez cuando se crea una clase. No se puede llamar expl�citamente en ning�n lugar que no sea la primera l�nea de c�digo de otro constructor de la misma clase o de una clase derivada. Adem�s, el c�digo del m�todo Sub New siempre se ejecuta antes que cualquier otro c�digo en una clase. 
        'Visual Basic 2005 y las versiones posteriores crean impl�citamente un constructor Sub New en tiempo de ejecuci�n si no se define expl�citamente un procedimiento Sub New para una clase.
        'Para crear un constructor para una clase, cree un procedimiento denominado Sub New en cualquier parte de la definici�n de la clase. 
        'Para crear un constructor parametrizado, especifique los nombres y los tipos de datos de los argumentos en Sub New tal y como har�a al especificar argumentos en cualquier otro procedimiento.
    End Sub

    Public Sub New(ByVal ID As Integer, ByVal Nombre As String, ByVal Porc_ganancia As Integer)
        pID = ID
        pNombre = Nombre
        pPorc_ganancia = Porc_ganancia
    End Sub
End Class