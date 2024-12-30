<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class RegistrasiForm
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
        Me.txUserRegis = New System.Windows.Forms.TextBox()
        Me.txNamaRegis = New System.Windows.Forms.TextBox()
        Me.txPassRegis = New System.Windows.Forms.TextBox()
        Me.btnRegistrasi = New System.Windows.Forms.Button()
        Me.btnKembali = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(193, 36)
        Me.Label1.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(146, 30)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "Registrasi"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'txUserRegis
        '
        Me.txUserRegis.Location = New System.Drawing.Point(153, 98)
        Me.txUserRegis.Margin = New System.Windows.Forms.Padding(2, 2, 2, 2)
        Me.txUserRegis.Name = "txUserRegis"
        Me.txUserRegis.Size = New System.Drawing.Size(228, 20)
        Me.txUserRegis.TabIndex = 2
        Me.txUserRegis.Text = "Username"
        '
        'txNamaRegis
        '
        Me.txNamaRegis.Location = New System.Drawing.Point(153, 130)
        Me.txNamaRegis.Margin = New System.Windows.Forms.Padding(2, 2, 2, 2)
        Me.txNamaRegis.Name = "txNamaRegis"
        Me.txNamaRegis.Size = New System.Drawing.Size(228, 20)
        Me.txNamaRegis.TabIndex = 3
        Me.txNamaRegis.Text = "Nama"
        '
        'txPassRegis
        '
        Me.txPassRegis.Location = New System.Drawing.Point(153, 167)
        Me.txPassRegis.Margin = New System.Windows.Forms.Padding(2, 2, 2, 2)
        Me.txPassRegis.Name = "txPassRegis"
        Me.txPassRegis.Size = New System.Drawing.Size(228, 20)
        Me.txPassRegis.TabIndex = 4
        Me.txPassRegis.Text = "Password"
        '
        'btnRegistrasi
        '
        Me.btnRegistrasi.BackColor = System.Drawing.Color.FromArgb(CType(CType(254, Byte), Integer), CType(CType(165, Byte), Integer), CType(CType(8, Byte), Integer))
        Me.btnRegistrasi.ForeColor = System.Drawing.Color.White
        Me.btnRegistrasi.Location = New System.Drawing.Point(277, 208)
        Me.btnRegistrasi.Margin = New System.Windows.Forms.Padding(2, 2, 2, 2)
        Me.btnRegistrasi.Name = "btnRegistrasi"
        Me.btnRegistrasi.Size = New System.Drawing.Size(103, 38)
        Me.btnRegistrasi.TabIndex = 5
        Me.btnRegistrasi.Text = "Registrasi"
        Me.btnRegistrasi.UseVisualStyleBackColor = False
        '
        'btnKembali
        '
        Me.btnKembali.BackColor = System.Drawing.Color.White
        Me.btnKembali.ForeColor = System.Drawing.Color.Black
        Me.btnKembali.Location = New System.Drawing.Point(153, 208)
        Me.btnKembali.Margin = New System.Windows.Forms.Padding(2, 2, 2, 2)
        Me.btnKembali.Name = "btnKembali"
        Me.btnKembali.Size = New System.Drawing.Size(103, 38)
        Me.btnKembali.TabIndex = 6
        Me.btnKembali.Text = "Kembali"
        Me.btnKembali.UseVisualStyleBackColor = False
        '
        'RegistrasiForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(533, 292)
        Me.Controls.Add(Me.btnKembali)
        Me.Controls.Add(Me.btnRegistrasi)
        Me.Controls.Add(Me.txPassRegis)
        Me.Controls.Add(Me.txNamaRegis)
        Me.Controls.Add(Me.txUserRegis)
        Me.Controls.Add(Me.Label1)
        Me.Margin = New System.Windows.Forms.Padding(2, 2, 2, 2)
        Me.Name = "RegistrasiForm"
        Me.Text = "Registrasi"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents Label1 As Label
    Friend WithEvents txUserRegis As TextBox
    Friend WithEvents txNamaRegis As TextBox
    Friend WithEvents txPassRegis As TextBox
    Friend WithEvents btnRegistrasi As Button
    Friend WithEvents btnKembali As Button
End Class
