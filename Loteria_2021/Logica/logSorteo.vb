﻿Public Class logSorteo
    Dim ID, IDTipoSorteo As Integer
    Dim Fecha As Date

    Public Property pID
        'declara el nombre de una propiedad y los procedimientos de porpiedad usados para almacenar y
        'recuperar el valor de la propiedad.
        'la instriccion property introduce la declaracion de una propiedad.
        'una propiedad puede tener un procedimiento get (solo lectura), un pocedimiento se (solo escritura),
        'o ambos (lectura y escritura).

        Get 'inicia un procedimiento de propiedad get que se una para devolver el valor de la propiedad.
            Return ID
        End Get
        Set(value) 'inicia un procedimiento de propiedad ser que se usa para almacenar el valor de la propiedad
            ID = value
        End Set
    End Property

    Public Property pFecha
        Get
            Return Fecha
        End Get
        Set(value)
            Fecha = value
        End Set
    End Property

    Public Property pIDTipoSorteo
        Get
            Return IDTipoSorteo

        End Get
        Set(value)
            IDTipoSorteo = value
        End Set
    End Property

    Public Sub New()
        'Mediante el uso de la palabra clave New se crea una instancia de una clase, un objeto. 
        'Visual Basic controla la inicialización de objetos nuevos mediante procedimientos denominados constructores(métodos especiales que permitan controlar la inicialización).
        'Después de que un objeto abandone el ámbito, se libera por Common Language Runtime (CLR). Visual Basic controla la liberación de recursos del sistema mediante procedimientos denominados destructores.Juntos, los constructores y los destructores permiten la creación de bibliotecas de clases completas y predecibles.
        'El constructor Sub New solo puede ejecutarse una vez cuando se crea una clase. No se puede llamar explícitamente en ningún lugar que no sea la primera línea de código de otro constructor de la misma clase o de una clase derivada. Además, el código del método Sub New siempre se ejecuta antes que cualquier otro código en una clase. 
        'Visual Basic 2005 y las versiones posteriores crean implícitamente un constructor Sub New en tiempo de ejecución si no se define explícitamente un procedimiento Sub New para una clase.
        'Para crear un constructor para una clase, cree un procedimiento denominado Sub New en cualquier parte de la definición de la clase. 
        'Para crear un constructor parametrizado, especifique los nombres y los tipos de datos de los argumentos en Sub New tal y como haría al especificar argumentos en cualquier otro procedimiento.
    End Sub

    Public Sub New(ByVal ID As Integer, ByVal Fecha As Date, ByVal IDTipoSorteo As Integer)
        pID = ID
        pFecha = Fecha
        pIDTipoSorteo = IDTipoSorteo

    End Sub
End Class
