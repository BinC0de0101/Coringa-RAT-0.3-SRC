﻿Imports Microsoft.Win32
Public Class FrmRegeditEditor
    Public Path As String
    Public sk As MdClient

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Me.sk.Send(String.Concat(New String() {"RG", MdSokserver.Y, "!", MdSokserver.Y, Me.Path, MdSokserver.Y, Me.TextBox1.Text, MdSokserver.Y, Me.TextBox3.Text, MdSokserver.Y, Convert.ToString(Me.Typ(Me.ComboBox1.Text))}))
        Me.Close()
    End Sub
    Public Function Typ(ByVal t As String) As Integer
        Dim num As Integer
        Dim str As String = t.ToLower
        If (str = RegistryValueKind.Binary.ToString.ToLower) Then
            Return 3
        End If
        If (str = RegistryValueKind.DWord.ToString.ToLower) Then
            Return 4
        End If
        If (str = RegistryValueKind.ExpandString.ToString.ToLower) Then
            Return 2
        End If
        If (str = RegistryValueKind.MultiString.ToString.ToLower) Then
            Return 7
        End If
        If (str = RegistryValueKind.QWord.ToString.ToLower) Then
            Return 11
        End If
        If (str = RegistryValueKind.String.ToString.ToLower) Then
            Return 1
        End If
        Return num
    End Function

End Class
