Option Strict On
Option Explicit On

Imports System
Imports System.IO
Imports System.Net
Imports System.Web
Imports System.Web.Script.Serialization
Imports System.Text

Public Module AppShared
    Private inCookies As CookieContainer = Nothing

    Public Property cookies As CookieContainer
        Get
            ' Share cookies across all instances of this module
            If inCookies Is Nothing Then
                inCookies = New CookieContainer()
            End If
            cookies = inCookies
        End Get

        Set(value As CookieContainer)
            inCookies = value
        End Set
    End Property

End Module
