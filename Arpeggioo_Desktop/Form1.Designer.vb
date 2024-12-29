<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class LoginForm
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
        Me.Label1 = New System.Windows.Forms.Label()
        Me.txUsername = New System.Windows.Forms.TextBox()
        Me.txPassword = New System.Windows.Forms.TextBox()
        Me.btnLogin = New System.Windows.Forms.Button()
        Me.btnRegistrasi = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(216, 26)
        Me.Label1.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(109, 30)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Login"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'txUsername
        '
        Me.txUsername.Location = New System.Drawing.Point(157, 90)
        Me.txUsername.Margin = New System.Windows.Forms.Padding(2, 2, 2, 2)
        Me.txUsername.Name = "txUsername"
        Me.txUsername.Size = New System.Drawing.Size(230, 20)
        Me.txUsername.TabIndex = 1
        Me.txUsername.Text = "Username"
        '
        'txPassword
        '
        Me.txPassword.Location = New System.Drawing.Point(157, 122)
        Me.txPassword.Margin = New System.Windows.Forms.Padding(2, 2, 2, 2)
        Me.txPassword.Name = "txPassword"
        Me.txPassword.Size = New System.Drawing.Size(230, 20)
        Me.txPassword.TabIndex = 2
        Me.txPassword.Text = "Password"
        '
        'btnLogin
        '
        Me.btnLogin.BackColor = System.Drawing.Color.FromArgb(CType(CType(254, Byte), Integer), CType(CType(165, Byte), Integer), CType(CType(8, Byte), Integer))
        Me.btnLogin.ForeColor = System.Drawing.Color.White
        Me.btnLogin.Location = New System.Drawing.Point(275, 170)
        Me.btnLogin.Margin = New System.Windows.Forms.Padding(2, 2, 2, 2)
        Me.btnLogin.Name = "btnLogin"
        Me.btnLogin.Size = New System.Drawing.Size(111, 34)
        Me.btnLogin.TabIndex = 5
        Me.btnLogin.Text = "Login"
        Me.btnLogin.UseVisualStyleBackColor = False
        '
        'btnRegistrasi
        '
        Me.btnRegistrasi.BackColor = System.Drawing.Color.FromArgb(CType(CType(254, Byte), Integer), CType(CType(165, Byte), Integer), CType(CType(8, Byte), Integer))
        Me.btnRegistrasi.ForeColor = System.Drawing.Color.White
        Me.btnRegistrasi.Location = New System.Drawing.Point(157, 170)
        Me.btnRegistrasi.Margin = New System.Windows.Forms.Padding(2, 2, 2, 2)
        Me.btnRegistrasi.Name = "btnRegistrasi"
        Me.btnRegistrasi.Size = New System.Drawing.Size(111, 34)
        Me.btnRegistrasi.TabIndex = 6
        Me.btnRegistrasi.Text = "Registrasi"
        Me.btnRegistrasi.UseVisualStyleBackColor = False
        '
        'LoginForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(533, 292)
        Me.Controls.Add(Me.btnRegistrasi)
        Me.Controls.Add(Me.btnLogin)
        Me.Controls.Add(Me.txPassword)
        Me.Controls.Add(Me.txUsername)
        Me.Controls.Add(Me.Label1)
        Me.Margin = New System.Windows.Forms.Padding(2, 2, 2, 2)
        Me.Name = "LoginForm"
        Me.Text = "Login"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents Label1 As Label
    Friend WithEvents txUsername As TextBox
    Friend WithEvents txPassword As TextBox
    Friend WithEvents btnLogin As Button
    Friend WithEvents btnRegistrasi As Button
End Class
