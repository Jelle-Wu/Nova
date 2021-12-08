<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class Nova_Form
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
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Nova_Form))
        Me.Nova_ListBox = New System.Windows.Forms.ListBox()
        Me.Nova_Check_Box = New System.Windows.Forms.CheckBox()
        Me.Nova_Start_Button = New System.Windows.Forms.Button()
        Me.Nova_Stop_Button = New System.Windows.Forms.Button()
        Me.Nova_NotifyIcon = New System.Windows.Forms.NotifyIcon(Me.components)
        Me.Nova_License = New System.Windows.Forms.ToolStripMenuItem()
        Me.License_ToolStripTextBox = New System.Windows.Forms.ToolStripTextBox()
        Me.Nova_Separator = New System.Windows.Forms.ToolStripSeparator()
        Me.Nova_ToolStripMenu_Exit = New System.Windows.Forms.ToolStripMenuItem()
        Me.Nova_ContextMenuStrip = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.Nova_ContextMenuStrip.SuspendLayout()
        Me.SuspendLayout()
        '
        'Nova_ListBox
        '
        Me.Nova_ListBox.FormattingEnabled = True
        Me.Nova_ListBox.Location = New System.Drawing.Point(5, 5)
        Me.Nova_ListBox.Name = "Nova_ListBox"
        Me.Nova_ListBox.Size = New System.Drawing.Size(295, 342)
        Me.Nova_ListBox.TabIndex = 1
        '
        'Nova_Check_Box
        '
        Me.Nova_Check_Box.AutoSize = True
        Me.Nova_Check_Box.Location = New System.Drawing.Point(12, 353)
        Me.Nova_Check_Box.Name = "Nova_Check_Box"
        Me.Nova_Check_Box.Size = New System.Drawing.Size(73, 17)
        Me.Nova_Check_Box.TabIndex = 4
        Me.Nova_Check_Box.Text = "Auto Start"
        Me.Nova_Check_Box.UseVisualStyleBackColor = True
        '
        'Nova_Start_Button
        '
        Me.Nova_Start_Button.Location = New System.Drawing.Point(10, 370)
        Me.Nova_Start_Button.Name = "Nova_Start_Button"
        Me.Nova_Start_Button.Size = New System.Drawing.Size(75, 23)
        Me.Nova_Start_Button.TabIndex = 5
        Me.Nova_Start_Button.Text = "Start"
        Me.Nova_Start_Button.UseVisualStyleBackColor = True
        '
        'Nova_Stop_Button
        '
        Me.Nova_Stop_Button.Location = New System.Drawing.Point(220, 370)
        Me.Nova_Stop_Button.Name = "Nova_Stop_Button"
        Me.Nova_Stop_Button.Size = New System.Drawing.Size(75, 23)
        Me.Nova_Stop_Button.TabIndex = 6
        Me.Nova_Stop_Button.Text = "Stop"
        Me.Nova_Stop_Button.UseVisualStyleBackColor = True
        '
        'Nova_NotifyIcon
        '
        Me.Nova_NotifyIcon.ContextMenuStrip = Me.Nova_ContextMenuStrip
        Me.Nova_NotifyIcon.Icon = CType(resources.GetObject("Nova_NotifyIcon.Icon"), System.Drawing.Icon)
        Me.Nova_NotifyIcon.Text = "Nova"
        Me.Nova_NotifyIcon.Visible = True
        '
        'Nova_License
        '
        Me.Nova_License.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.License_ToolStripTextBox})
        Me.Nova_License.Name = "Nova_License"
        Me.Nova_License.Size = New System.Drawing.Size(152, 22)
        Me.Nova_License.Text = "License"
        '
        'License_ToolStripTextBox
        '
        Me.License_ToolStripTextBox.Name = "License_ToolStripTextBox"
        Me.License_ToolStripTextBox.Size = New System.Drawing.Size(100, 23)
        '
        'Nova_Separator
        '
        Me.Nova_Separator.Name = "Nova_Separator"
        Me.Nova_Separator.Size = New System.Drawing.Size(149, 6)
        '
        'Nova_ToolStripMenu_Exit
        '
        Me.Nova_ToolStripMenu_Exit.Name = "Nova_ToolStripMenu_Exit"
        Me.Nova_ToolStripMenu_Exit.Size = New System.Drawing.Size(152, 22)
        Me.Nova_ToolStripMenu_Exit.Text = "Exit"
        '
        'Nova_ContextMenuStrip
        '
        Me.Nova_ContextMenuStrip.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.Nova_License, Me.Nova_Separator, Me.Nova_ToolStripMenu_Exit})
        Me.Nova_ContextMenuStrip.Name = "Nova_ContextMenuStrip"
        Me.Nova_ContextMenuStrip.Size = New System.Drawing.Size(153, 76)
        '
        'Nova_Form
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.Control
        Me.ClientSize = New System.Drawing.Size(305, 407)
        Me.Controls.Add(Me.Nova_Stop_Button)
        Me.Controls.Add(Me.Nova_Start_Button)
        Me.Controls.Add(Me.Nova_Check_Box)
        Me.Controls.Add(Me.Nova_ListBox)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "Nova_Form"
        Me.Text = "Nova"
        Me.Nova_ContextMenuStrip.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents Nova_ListBox As ListBox
    Friend WithEvents Nova_Check_Box As CheckBox
    Friend WithEvents Nova_Start_Button As Button
    Friend WithEvents Nova_Stop_Button As Button
    Friend WithEvents Nova_NotifyIcon As NotifyIcon
    Friend WithEvents Nova_ContextMenuStrip As ContextMenuStrip
    Friend WithEvents Nova_License As ToolStripMenuItem
    Friend WithEvents License_ToolStripTextBox As ToolStripTextBox
    Friend WithEvents Nova_Separator As ToolStripSeparator
    Friend WithEvents Nova_ToolStripMenu_Exit As ToolStripMenuItem
End Class
