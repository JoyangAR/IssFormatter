<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class FrmMain
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()>
    Protected Overrides Sub Dispose(disposing As Boolean)
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
        Me.MsMain = New System.Windows.Forms.MenuStrip()
        Me.MsuFile = New System.Windows.Forms.ToolStripMenuItem()
        Me.MsiOpen = New System.Windows.Forms.ToolStripMenuItem()
        Me.MsiOptions = New System.Windows.Forms.ToolStripMenuItem()
        Me.MsiExit = New System.Windows.Forms.ToolStripMenuItem()
        Me.MniFormatFile = New System.Windows.Forms.ToolStripMenuItem()
        Me.ContextMenuStrip1 = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.BtnFormatISS = New System.Windows.Forms.Button()
        Me.RtbISSScript = New System.Windows.Forms.TextBox()
        Me.MsMain.SuspendLayout()
        Me.SuspendLayout()
        '
        'MsMain
        '
        Me.MsMain.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.MsuFile})
        Me.MsMain.Location = New System.Drawing.Point(0, 0)
        Me.MsMain.Name = "MsMain"
        Me.MsMain.Padding = New System.Windows.Forms.Padding(5, 2, 0, 2)
        Me.MsMain.Size = New System.Drawing.Size(686, 24)
        Me.MsMain.TabIndex = 1
        Me.MsMain.Text = "MenuStrip1"
        '
        'MsuFile
        '
        Me.MsuFile.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.MsiOpen, Me.MsiOptions, Me.MsiExit, Me.MniFormatFile})
        Me.MsuFile.Name = "MsuFile"
        Me.MsuFile.Size = New System.Drawing.Size(37, 20)
        Me.MsuFile.Text = "File"
        '
        'MsiOpen
        '
        Me.MsiOpen.Name = "MsiOpen"
        Me.MsiOpen.Size = New System.Drawing.Size(133, 22)
        Me.MsiOpen.Text = "Open"
        '
        'MsiOptions
        '
        Me.MsiOptions.Name = "MsiOptions"
        Me.MsiOptions.Size = New System.Drawing.Size(133, 22)
        Me.MsiOptions.Text = "Options"
        '
        'MsiExit
        '
        Me.MsiExit.Name = "MsiExit"
        Me.MsiExit.Size = New System.Drawing.Size(133, 22)
        Me.MsiExit.Text = "Exit"
        '
        'MniFormatFile
        '
        Me.MniFormatFile.Name = "MniFormatFile"
        Me.MniFormatFile.Size = New System.Drawing.Size(133, 22)
        Me.MniFormatFile.Text = "Format File"
        '
        'ContextMenuStrip1
        '
        Me.ContextMenuStrip1.Name = "ContextMenuStrip1"
        Me.ContextMenuStrip1.Size = New System.Drawing.Size(61, 4)
        '
        'BtnFormatISS
        '
        Me.BtnFormatISS.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnFormatISS.Location = New System.Drawing.Point(591, 359)
        Me.BtnFormatISS.Name = "BtnFormatISS"
        Me.BtnFormatISS.Size = New System.Drawing.Size(85, 21)
        Me.BtnFormatISS.TabIndex = 3
        Me.BtnFormatISS.Text = "Format"
        Me.BtnFormatISS.UseVisualStyleBackColor = True
        '
        'RtbISSScript
        '
        Me.RtbISSScript.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.RtbISSScript.Location = New System.Drawing.Point(12, 27)
        Me.RtbISSScript.MaxLength = 999999999
        Me.RtbISSScript.Multiline = True
        Me.RtbISSScript.Name = "RtbISSScript"
        Me.RtbISSScript.ScrollBars = System.Windows.Forms.ScrollBars.Both
        Me.RtbISSScript.Size = New System.Drawing.Size(664, 326)
        Me.RtbISSScript.TabIndex = 4
        Me.RtbISSScript.WordWrap = False
        '
        'FrmMain
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(686, 390)
        Me.Controls.Add(Me.RtbISSScript)
        Me.Controls.Add(Me.BtnFormatISS)
        Me.Controls.Add(Me.MsMain)
        Me.MainMenuStrip = Me.MsMain
        Me.Name = "FrmMain"
        Me.ShowIcon = False
        Me.Text = "Inno-Formatter GUI"
        Me.MsMain.ResumeLayout(False)
        Me.MsMain.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents MsMain As MenuStrip
    Friend WithEvents MsuFile As ToolStripMenuItem
    Friend WithEvents MsiOpen As ToolStripMenuItem
    Friend WithEvents MsiOptions As ToolStripMenuItem
    Friend WithEvents MsiExit As ToolStripMenuItem
    Friend WithEvents ContextMenuStrip1 As ContextMenuStrip
    Friend WithEvents BtnFormatISS As Button
    Friend WithEvents MniFormatFile As ToolStripMenuItem
    Friend WithEvents RtbISSScript As TextBox
End Class
