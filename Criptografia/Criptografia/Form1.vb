Imports System.Security.Cryptography
Imports System.IO
Imports System.Text

Public Class Form1

    Function gerarSHA1(palavra As String) As String
        Dim fornece As New SHA1CryptoServiceProvider 
        Dim byteHash() As Byte
        Dim hash As String = ""

        byteHash = fornece.ComputeHash(Encoding.UTF8.GetBytes(palavra))
        fornece.Clear()
        hash = BitConverter.ToString(byteHash).Replace("-", String.Empty)

        Return hash.ToLower
    End Function

    Function gerarMD5(palavra As String) As String
        Dim fornece As New MD5CryptoServiceProvider
        Dim byteHash() As Byte
        Dim hash As String = ""

        byteHash = fornece.ComputeHash(Encoding.UTF8.GetBytes(palavra))
        fornece.Clear()
        hash = BitConverter.ToString(byteHash).Replace("-", String.Empty)

        Return hash.ToLower

    End Function

    Function gerarHashArq(caminhoArquivo As String) As String
        Dim fornece As New MD5CryptoServiceProvider
        Dim byteHash() As Byte
        Dim hash As String = ""
        Dim arquivoStream As FileStream = File.OpenRead(caminhoArquivo)
        arquivoStream.Position = 0

        byteHash = fornece.ComputeHash(arquivoStream)
        hash = BitConverter.ToString(byteHash).Replace("-", String.Empty)

        Return hash.ToLower

    End Function

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles btnGenerate.Click
        If (tbString.Text <> "") Then
            If (rbSHA1.Checked) Then
                tbResult.Text = gerarSHA1(tbString.Text)
            ElseIf (rbMD5.Checked) Then
                tbResult.Text = gerarMD5(tbString.Text)
            Else
                MsgBox("Escolha algum tipo")
            End If
        Else
            MsgBox("Preencha o campo")
        End If


    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles btnSearch.Click
        Dim hash As String = ""
        If (OpenFileDialog1.ShowDialog = Windows.Forms.DialogResult.OK) Then
            hash = gerarHashArq(OpenFileDialog1.FileName)
        End If
        tbSearch.Text = OpenFileDialog1.FileName
        tbResult.Text = hash
    End Sub

    Private Sub Button1_Click_1(sender As Object, e As EventArgs) Handles btnClear.Click
        tbResult.Clear()
        tbSearch.Clear()
        tbString.Clear()
        rbMD5.Checked = False
        rbSHA1.Checked = False
    End Sub
End Class

