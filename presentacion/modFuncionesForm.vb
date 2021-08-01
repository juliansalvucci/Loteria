'Este módulo particular no se importa, debido a que trabaja con funciones nativas de vb de formulario para windows.
Module modFuncionesForm
    Public Enum ModoPantalla As Byte  'enumeración pública para los modos de pantalla, esta el modo en el modulo para poder aplicarlo en los demás formularios.
        ModoALTA = 0
        ModoMODIFICACION = 1
        ModoCONSULTA = 2
    End Enum
    Public Function AbmEvents_KP(ByVal Key As System.Windows.Forms.KeyEventArgs) As Integer
        'IMPORTANTE: establecer la propiedad KeyPreview del formulario en True.
        'KeyEventArgs = proporciona datos para los eventos KeyUp y KeyDown.
        '.KeyCode = obtiene el código de teclado.
        'Keys = especifica los códigos de tecla.
        AbmEvents_KP = 0 'evento keypress, evento que se ejecuta al presionar la tecla.
        If Key.KeyCode = Keys.Enter Then   'si se preciona enter.
            SendKeys.Send("{TAB}") 'se traduce enter a tab para saltar de un campo a otro.
        ElseIf Key.KeyCode = Keys.Escape Then 'se preciona esc.
            SendKeys.Send("+{TAB}") 'se traduce a alt tab.
        End If
    End Function
    Public Sub DeshabilitarTextos(ByVal frmFormulario As Form)
        'Establece la propiedad ReadOnly = True en todos los TextBox del formulario en los parámetros.
        'Otra manera de hacerla sería:
        'TextBox1.ReadOnly = True con cada caja de texto.
        For Each obObjeto As Windows.Forms.Control In frmFormulario.Controls 'para cada objeto del formulario
            If TypeOf obObjeto Is GroupBox Then 'si el objeto es groupbox
                For Each CajaTexto As Windows.Forms.Control In obObjeto.Controls 'recorro ese gp, y si es textbox lo deshabilito.
                    If TypeOf CajaTexto Is TextBox Then
                        CType(CajaTexto, TextBox).Enabled = False 'tb se deshabilita.
                    End If
                Next
            ElseIf TypeOf obObjeto Is TextBox Then 'esto es por si el formulario esta fuera del group box y está sobre el formulario.
                CType(obObjeto, TextBox).Enabled = False
            End If
        Next
    End Sub
    Public Sub DeshabilitarCombos(ByVal frmFormulario As Form)  'Lo mismo pero con los combos.
        For Each obObjeto As Windows.Forms.Control In frmFormulario.Controls
            If TypeOf obObjeto Is GroupBox Then
                For Each Combo As Windows.Forms.Control In obObjeto.Controls
                    If TypeOf Combo Is ComboBox Then
                        CType(Combo, ComboBox).Enabled = False
                    End If
                Next
            ElseIf TypeOf obObjeto Is ComboBox Then
                CType(obObjeto, ComboBox).Enabled = False
            End If
        Next
    End Sub
    Public Sub LimpiarTextos(ByVal frmFormulario As Form)
        'Limpia las cajas de texto del formulario.
        For Each obObjeto As Windows.Forms.Control In frmFormulario.Controls
            If TypeOf obObjeto Is GroupBox Then
                For Each CajaTexto As Windows.Forms.Control In obObjeto.Controls
                    If TypeOf CajaTexto Is TextBox Then
                        CType(CajaTexto, TextBox).Text = ""
                    End If
                Next
            ElseIf TypeOf obObjeto Is TextBox Then
                CType(obObjeto, TextBox).Text = ""
            End If
        Next
    End Sub

    Public Sub HabilitarTextos(ByVal frmFormulario As Form)
        'Establece la propiedad Enabled = True en todos los TextBox del formulario en los parámetros.

        For Each obObjeto As Windows.Forms.Control In frmFormulario.Controls
            If TypeOf obObjeto Is GroupBox Then
                For Each CajaTexto As Windows.Forms.Control In obObjeto.Controls
                    If TypeOf CajaTexto Is TextBox Then
                        CType(CajaTexto, TextBox).Enabled = True
                    End If
                Next
            ElseIf TypeOf obObjeto Is TextBox Then
                CType(obObjeto, TextBox).Enabled = True
            End If
        Next
    End Sub
End Module
