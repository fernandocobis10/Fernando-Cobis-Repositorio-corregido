Imports System.Windows.Forms

Public Class Form1
    ' Constantes de Masa
    Private Const KILO As Double = 1000
    Private Const HECTO As Double = 100
    Private Const DECA As Double = 10
    Private Const GRAMO As Double = 1
    Private Const DECI As Double = 0.1
    Private Const CENTI As Double = 0.01
    Private Const MILI As Double = 0.001

    ' Constantes de Distancia
    Private Const KILOMETRO As Double = 1000
    Private Const METRO As Double = 1
    Private Const DECIMETRO As Double = 0.1
    Private Const CENTIMETRO As Double = 0.01
    Private Const MILIMETRO As Double = 0.001

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim masas() As String = {"KILO", "HECTO", "DECA", "GRAMO", "DECI", "CENTI", "MILI"}
        Dim distancias() As String = {"KILOMETRO", "METRO", "DECIMETRO", "CENTIMETRO", "MILIMETRO"}
        ComboBox3.Items.AddRange(New String() {"Masa", "Distancia"})
        ComboBox3.SelectedIndex = 0
        ComboBox1.Items.AddRange(masas)
        ComboBox2.Items.AddRange(masas)
        ComboBox1.SelectedIndex = 3
        ComboBox2.SelectedIndex = 3
    End Sub

    Private Sub Tbx_cantidad_TextChanged(sender As Object, e As EventArgs) Handles Tbx_cantidad.TextChanged
        Convertir()
    End Sub

    Private Sub ComboBox1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox1.SelectedIndexChanged
        Convertir()
    End Sub

    Private Sub ComboBox2_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox2.SelectedIndexChanged
        Convertir()
    End Sub

    Private Sub ComboBox3_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox3.SelectedIndexChanged
        If ComboBox3.SelectedItem.ToString() = "Masa" Then
            ComboBox1.Items.Clear()
            ComboBox2.Items.Clear()
            Dim masas() As String = {"KILO", "HECTO", "DECA", "GRAMO", "DECI", "CENTI", "MILI"}
            ComboBox1.Items.AddRange(masas)
            ComboBox2.Items.AddRange(masas)
            ComboBox1.SelectedIndex = 3
            ComboBox2.SelectedIndex = 3
        ElseIf ComboBox3.SelectedItem.ToString() = "Distancia" Then
            ComboBox1.Items.Clear()
            ComboBox2.Items.Clear()
            Dim distancias() As String = {"KILOMETRO", "METRO", "DECIMETRO", "CENTIMETRO", "MILIMETRO"}
            ComboBox1.Items.AddRange(distancias)
            ComboBox2.Items.AddRange(distancias)
            ComboBox1.SelectedIndex = 1
            ComboBox2.SelectedIndex = 1
        End If
        Convertir()
    End Sub

    Private Sub Convertir()
        Dim cantidad As Double
        If Not Double.TryParse(Tbx_cantidad.Text, cantidad) Then
            Tbx_resultado.Text = "0"
            Return
        End If
        Dim unidadOrigen As String = ComboBox1.SelectedItem.ToString()
        Dim unidadDestino As String = ComboBox2.SelectedItem.ToString()
        Dim factorOrigen As Double = ObtenerFactor(unidadOrigen, ComboBox3.SelectedItem.ToString())
        Dim factorDestino As Double = ObtenerFactor(unidadDestino, ComboBox3.SelectedItem.ToString())
        Dim cantidadEnUnidad As Double = cantidad * factorOrigen
        Dim resultado As Double = cantidadEnUnidad / factorDestino
        Tbx_resultado.Text = resultado.ToString("F3")
    End Sub

    Private Function ObtenerFactor(unidad As String, tipo As String) As Double
        Select Case tipo.ToUpper()
            Case "MASA"
                Select Case unidad.ToUpper()
                    Case "KILO"
                        Return KILO
                    Case "HECTO"
                        Return HECTO
                    Case "DECA"
                        Return DECA
                    Case "GRAMO"
                        Return GRAMO
                    Case "DECI"
                        Return DECI
                    Case "CENTI"
                        Return CENTI
                    Case "MILI"
                        Return MILI
                    Case Else
                        Return 1
                End Select
            Case "DISTANCIA"
                Select Case unidad.ToUpper()
                    Case "KILOMETRO"
                        Return KILOMETRO
                    Case "METRO"
                        Return METRO
                    Case "DECIMETRO"
                        Return DECIMETRO
                    Case "CENTIMETRO"
                        Return CENTIMETRO
                    Case "MILIMETRO"
                        Return MILIMETRO
                    Case Else
                        Return 1
                End Select
            Case Else
                Return 1
        End Select
    End Function

    Private Sub PictureBox1_Click(sender As Object, e As EventArgs) Handles PictureBox1.Click
        ' Añadir código aquí si es necesario
    End Sub
End Class
