<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class FormMain
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()>
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.TxtNewItem = New System.Windows.Forms.TextBox()
        Me.BtnAddSnippet = New System.Windows.Forms.Button()
        Me.ListSnippets = New System.Windows.Forms.ListBox()
        Me.lblWelcome = New System.Windows.Forms.Label()
        Me.SuspendLayout()
        '
        'TxtNewItem
        '
        Me.TxtNewItem.Location = New System.Drawing.Point(11, 35)
        Me.TxtNewItem.Name = "TxtNewItem"
        Me.TxtNewItem.Size = New System.Drawing.Size(230, 23)
        Me.TxtNewItem.TabIndex = 0
        '
        'BtnAddSnippet
        '
        Me.BtnAddSnippet.Location = New System.Drawing.Point(247, 34)
        Me.BtnAddSnippet.Name = "BtnAddSnippet"
        Me.BtnAddSnippet.Size = New System.Drawing.Size(90, 23)
        Me.BtnAddSnippet.TabIndex = 1
        Me.BtnAddSnippet.Text = "Add Snippet"
        Me.BtnAddSnippet.UseVisualStyleBackColor = True
        '
        'ListSnippets
        '
        Me.ListSnippets.FormattingEnabled = True
        Me.ListSnippets.ItemHeight = 15
        Me.ListSnippets.Location = New System.Drawing.Point(11, 65)
        Me.ListSnippets.Name = "ListSnippets"
        Me.ListSnippets.Size = New System.Drawing.Size(326, 184)
        Me.ListSnippets.TabIndex = 2
        '
        'lblWelcome
        '
        Me.lblWelcome.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point)
        Me.lblWelcome.Location = New System.Drawing.Point(0, 0)
        Me.lblWelcome.Name = "lblWelcome"
        Me.lblWelcome.Padding = New System.Windows.Forms.Padding(5)
        Me.lblWelcome.Size = New System.Drawing.Size(350, 25)
        Me.lblWelcome.TabIndex = 3
        Me.lblWelcome.Text = "Welcome to SnipMan VB v1.0"
        Me.lblWelcome.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'FormMain
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 15.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(349, 261)
        Me.Controls.Add(Me.lblWelcome)
        Me.Controls.Add(Me.ListSnippets)
        Me.Controls.Add(Me.BtnAddSnippet)
        Me.Controls.Add(Me.TxtNewItem)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.Name = "FormMain"
        Me.Text = "SnipMan VB"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents TxtNewItem As TextBox
    Friend WithEvents BtnAddSnippet As Button
    Friend WithEvents ListSnippets As ListBox
    Friend WithEvents lblWelcome As Label
End Class
