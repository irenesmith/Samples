Public Class FormMain
    Private SnippetMgr As SnipManager
    Private Sub FormMain_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        SnippetMgr = New SnipManager()

        lblWelcome.Width = Me.Width
        lblWelcome.Height = 30
        lblWelcome.BackColor = Color.Navy
        lblWelcome.ForeColor = Color.White
        If SnippetMgr.Snippets.Count > 0 Then
            For Each snippet As String In SnippetMgr.Snippets
                ListSnippets.Items.Add(snippet)
            Next
        End If
    End Sub

    Private Sub BtnAddSnippet_Click(sender As Object, e As EventArgs) Handles BtnAddSnippet.Click
        If String.IsNullOrEmpty(TxtNewItem.Text) Then
            Return
        End If
        SnippetMgr.AddSnippet(TxtNewItem.Text)
        ListSnippets.Items.Add(TxtNewItem.Text)
        TxtNewItem.Text = String.Empty
    End Sub
End Class
