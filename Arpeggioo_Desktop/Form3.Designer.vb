﻿<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Index
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
        Me.btnLogout = New System.Windows.Forms.Button()
        Me.DGVProduk = New System.Windows.Forms.DataGridView()
        Me.btnData = New System.Windows.Forms.Button()
        CType(Me.DGVProduk, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(11, 9)
        Me.Label1.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(66, 13)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Panel Admin"
        '
        'btnLogout
        '
        Me.btnLogout.Location = New System.Drawing.Point(750, 12)
        Me.btnLogout.Name = "btnLogout"
        Me.btnLogout.Size = New System.Drawing.Size(91, 37)
        Me.btnLogout.TabIndex = 1
        Me.btnLogout.Text = "Logout"
        Me.btnLogout.UseVisualStyleBackColor = True
        '
        'DGVProduk
        '
        Me.DGVProduk.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        Me.DGVProduk.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DGVProduk.Location = New System.Drawing.Point(46, 129)
        Me.DGVProduk.Name = "DGVProduk"
        Me.DGVProduk.ReadOnly = True
        Me.DGVProduk.RowHeadersWidth = 62
        Me.DGVProduk.Size = New System.Drawing.Size(764, 308)
        Me.DGVProduk.TabIndex = 2
        '
        'btnData
        '
        Me.btnData.Location = New System.Drawing.Point(46, 75)
        Me.btnData.Name = "btnData"
        Me.btnData.Size = New System.Drawing.Size(91, 37)
        Me.btnData.TabIndex = 3
        Me.btnData.Text = "Manage Data"
        Me.btnData.UseVisualStyleBackColor = True
        '
        'Index
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(853, 470)
        Me.Controls.Add(Me.btnData)
        Me.Controls.Add(Me.DGVProduk)
        Me.Controls.Add(Me.btnLogout)
        Me.Controls.Add(Me.Label1)
        Me.Margin = New System.Windows.Forms.Padding(2, 2, 2, 2)
        Me.Name = "Index"
        Me.Text = "Menu"
        CType(Me.DGVProduk, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents Label1 As Label
    Friend WithEvents btnLogout As Button
    Friend WithEvents DGVProduk As DataGridView
    Friend WithEvents btnData As Button
End Class
