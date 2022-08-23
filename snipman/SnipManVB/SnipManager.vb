Imports Microsoft.VisualBasic
Imports System.IO

Public Class SnipManager
    Private _FileName As String
    Private _FullPath As String

    Private _Snippets As List(Of String)
    Public ReadOnly Property Snippets() As List(Of String)
        Get
            Return _Snippets
        End Get
    End Property

    Sub New()
        Dim WeekDayNum As Integer = CInt(DateTime.Now.DayOfWeek)
        Dim DateDiff As Double = (WeekDayNum - 1)
        Dim Monday As Date = DateAdd(DateInterval.Day, -DateDiff, Date.Today)
        _FileName = Format(Monday, "yyyyMMdd") & "_Snippets.txt"
        _FullPath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments)
        _FullPath &= "\" & _FileName
        _Snippets = New List(Of String)

        ' Load the existing snippets for this week.
        If File.Exists(_FullPath) Then
            For Each line As String In File.ReadLines(_FullPath)
                _Snippets.Add(line)
            Next
        End If
    End Sub

    Public Sub AddSnippet(newSnippet As String)
        My.Computer.FileSystem.WriteAllText(_FullPath, newSnippet, True)
    End Sub
End Class
