<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class NovaRegister
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
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
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(NovaRegister))
        Me.NovaRegisterTextBox = New System.Windows.Forms.TextBox()
        Me.NovaRegisterButton = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'NovaRegisterTextBox
        '
        Me.NovaRegisterTextBox.Location = New System.Drawing.Point(12, 9)
        Me.NovaRegisterTextBox.Name = "NovaRegisterTextBox"
        Me.NovaRegisterTextBox.Size = New System.Drawing.Size(100, 20)
        Me.NovaRegisterTextBox.TabIndex = 0
        '
        'NovaRegisterButton
        '
        Me.NovaRegisterButton.Location = New System.Drawing.Point(119, 9)
        Me.NovaRegisterButton.Name = "NovaRegisterButton"
        Me.NovaRegisterButton.Size = New System.Drawing.Size(75, 23)
        Me.NovaRegisterButton.TabIndex = 1
        Me.NovaRegisterButton.Text = "Register"
        Me.NovaRegisterButton.UseVisualStyleBackColor = True
        '
        'NovaRegister
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(204, 41)
        Me.Controls.Add(Me.NovaRegisterButton)
        Me.Controls.Add(Me.NovaRegisterTextBox)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "NovaRegister"
        Me.Text = "NovaRegister"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents NovaRegisterTextBox As TextBox
    Friend WithEvents NovaRegisterButton As Button
End Class
