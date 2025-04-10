<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmOptions
    Inherits System.Windows.Forms.Form

    'Form reemplaza a Dispose para limpiar la lista de componentes.
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

    'Requerido por el Diseñador de Windows Forms
    Private components As System.ComponentModel.IContainer

    'NOTA: el Diseñador de Windows Forms necesita el siguiente procedimiento
    'Se puede modificar usando el Diseñador de Windows Forms.  
    'No lo modifique con el editor de código.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.ChkIndentTry = New System.Windows.Forms.CheckBox()
        Me.ChkIndentCase = New System.Windows.Forms.CheckBox()
        Me.ChkIndentIf = New System.Windows.Forms.CheckBox()
        Me.ChkIndentOnlyBegin = New System.Windows.Forms.CheckBox()
        Me.LblIndentSpaces = New System.Windows.Forms.Label()
        Me.BtnApply = New System.Windows.Forms.Button()
        Me.NudIndentSpaces = New System.Windows.Forms.NumericUpDown()
        Me.CbxCapitalType = New System.Windows.Forms.ComboBox()
        Me.LblCapitalization = New System.Windows.Forms.Label()
        CType(Me.NudIndentSpaces, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'ChkIndentTry
        '
        Me.ChkIndentTry.AutoSize = True
        Me.ChkIndentTry.Location = New System.Drawing.Point(12, 31)
        Me.ChkIndentTry.Name = "ChkIndentTry"
        Me.ChkIndentTry.Size = New System.Drawing.Size(74, 17)
        Me.ChkIndentTry.TabIndex = 0
        Me.ChkIndentTry.Text = "Indent Try"
        Me.ChkIndentTry.UseVisualStyleBackColor = True
        '
        'ChkIndentCase
        '
        Me.ChkIndentCase.AutoSize = True
        Me.ChkIndentCase.Location = New System.Drawing.Point(12, 53)
        Me.ChkIndentCase.Name = "ChkIndentCase"
        Me.ChkIndentCase.Size = New System.Drawing.Size(83, 17)
        Me.ChkIndentCase.TabIndex = 1
        Me.ChkIndentCase.Text = "Indent Case"
        Me.ChkIndentCase.UseVisualStyleBackColor = True
        '
        'ChkIndentIf
        '
        Me.ChkIndentIf.AutoSize = True
        Me.ChkIndentIf.Location = New System.Drawing.Point(12, 75)
        Me.ChkIndentIf.Name = "ChkIndentIf"
        Me.ChkIndentIf.Size = New System.Drawing.Size(65, 17)
        Me.ChkIndentIf.TabIndex = 2
        Me.ChkIndentIf.Text = "Indent If"
        Me.ChkIndentIf.UseVisualStyleBackColor = True
        '
        'ChkIndentOnlyBegin
        '
        Me.ChkIndentOnlyBegin.AutoSize = True
        Me.ChkIndentOnlyBegin.Location = New System.Drawing.Point(12, 96)
        Me.ChkIndentOnlyBegin.Name = "ChkIndentOnlyBegin"
        Me.ChkIndentOnlyBegin.Size = New System.Drawing.Size(110, 17)
        Me.ChkIndentOnlyBegin.TabIndex = 3
        Me.ChkIndentOnlyBegin.Text = "Indent Only Begin"
        Me.ChkIndentOnlyBegin.UseVisualStyleBackColor = True
        '
        'LblIndentSpaces
        '
        Me.LblIndentSpaces.AutoSize = True
        Me.LblIndentSpaces.Location = New System.Drawing.Point(10, 8)
        Me.LblIndentSpaces.Name = "LblIndentSpaces"
        Me.LblIndentSpaces.Size = New System.Drawing.Size(76, 13)
        Me.LblIndentSpaces.TabIndex = 5
        Me.LblIndentSpaces.Text = "Indent Spaces"
        '
        'BtnApply
        '
        Me.BtnApply.DialogResult = System.Windows.Forms.DialogResult.OK
        Me.BtnApply.Location = New System.Drawing.Point(38, 162)
        Me.BtnApply.Name = "BtnApply"
        Me.BtnApply.Size = New System.Drawing.Size(66, 29)
        Me.BtnApply.TabIndex = 6
        Me.BtnApply.Text = "Apply"
        Me.BtnApply.UseVisualStyleBackColor = True
        '
        'NudIndentSpaces
        '
        Me.NudIndentSpaces.Location = New System.Drawing.Point(91, 6)
        Me.NudIndentSpaces.Name = "NudIndentSpaces"
        Me.NudIndentSpaces.Size = New System.Drawing.Size(42, 20)
        Me.NudIndentSpaces.TabIndex = 7
        '
        'CbxCapitalType
        '
        Me.CbxCapitalType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CbxCapitalType.FormattingEnabled = True
        Me.CbxCapitalType.Items.AddRange(New Object() {"Disabled", "lowercase", "UPPERCASE", "Capitalize"})
        Me.CbxCapitalType.Location = New System.Drawing.Point(13, 132)
        Me.CbxCapitalType.Name = "CbxCapitalType"
        Me.CbxCapitalType.Size = New System.Drawing.Size(121, 21)
        Me.CbxCapitalType.TabIndex = 8
        '
        'LblCapitalization
        '
        Me.LblCapitalization.AutoSize = True
        Me.LblCapitalization.Location = New System.Drawing.Point(10, 116)
        Me.LblCapitalization.Name = "LblCapitalization"
        Me.LblCapitalization.Size = New System.Drawing.Size(69, 13)
        Me.LblCapitalization.TabIndex = 9
        Me.LblCapitalization.Text = "Capitalization"
        '
        'FrmOptions
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(143, 203)
        Me.Controls.Add(Me.LblCapitalization)
        Me.Controls.Add(Me.CbxCapitalType)
        Me.Controls.Add(Me.NudIndentSpaces)
        Me.Controls.Add(Me.BtnApply)
        Me.Controls.Add(Me.LblIndentSpaces)
        Me.Controls.Add(Me.ChkIndentOnlyBegin)
        Me.Controls.Add(Me.ChkIndentIf)
        Me.Controls.Add(Me.ChkIndentCase)
        Me.Controls.Add(Me.ChkIndentTry)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FrmOptions"
        Me.Text = "Options"
        CType(Me.NudIndentSpaces, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents ChkIndentTry As CheckBox
    Friend WithEvents ChkIndentCase As CheckBox
    Friend WithEvents ChkIndentIf As CheckBox
    Friend WithEvents ChkIndentOnlyBegin As CheckBox
    Friend WithEvents LblIndentSpaces As Label
    Friend WithEvents BtnApply As Button
    Friend WithEvents NudIndentSpaces As NumericUpDown
    Friend WithEvents CbxCapitalType As ComboBox
    Friend WithEvents LblCapitalization As Label
End Class
