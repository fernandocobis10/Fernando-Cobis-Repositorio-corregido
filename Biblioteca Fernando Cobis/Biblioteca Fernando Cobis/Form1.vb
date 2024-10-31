
Public Class Form1
    Private books As Dictionary(Of String, Boolean) = New Dictionary(Of String, Boolean) From {
        {"Harry potter", True},
        {"El principito", True},
    }

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ComboBox1.Items.AddRange(books.Keys.ToArray())
        ComboBox2.Items.AddRange(books.Keys.ToArray())
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        If ComboBox1.SelectedItem Is Nothing Then
            MessageBox.Show("Por favor, selecciona un libro para prestar.")
            Return
        End If

        Dim selectedBook As String = ComboBox1.SelectedItem.ToString()
        If books(selectedBook) Then
            books(selectedBook) = False
            MessageBox.Show(selectedBook & " prestado exitosamente.")
        Else
            MessageBox.Show(selectedBook & " ya está prestado.")
        End If
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        If ComboBox2.SelectedItem Is Nothing Then
            MessageBox.Show("Por favor, selecciona un libro para devolver.")
            Return
        End If

        Dim selectedBook As String = ComboBox2.SelectedItem.ToString()
        If Not books(selectedBook) Then
            books(selectedBook) = True
            MessageBox.Show(selectedBook & " devuelto exitosamente.")
        Else
            MessageBox.Show(selectedBook & " ya está en la biblioteca.")
        End If
    End Sub

    Private Sub PictureBox1_Click(sender As Object, e As EventArgs) Handles PictureBox1.Click

    End Sub
End Class
