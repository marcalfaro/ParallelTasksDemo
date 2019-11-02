<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Form1
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
        Me.b2 = New System.Windows.Forms.Button()
        Me.b3 = New System.Windows.Forms.Button()
        Me.b1 = New System.Windows.Forms.Button()
        Me.b4 = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'b2
        '
        Me.b2.Location = New System.Drawing.Point(55, 100)
        Me.b2.Name = "b2"
        Me.b2.Size = New System.Drawing.Size(221, 51)
        Me.b2.TabIndex = 0
        Me.b2.Text = "Execute All Tasks and Wait"
        Me.b2.UseVisualStyleBackColor = True
        '
        'b3
        '
        Me.b3.Location = New System.Drawing.Point(55, 180)
        Me.b3.Name = "b3"
        Me.b3.Size = New System.Drawing.Size(221, 51)
        Me.b3.TabIndex = 0
        Me.b3.Text = "Execute Tasks by Batch and Wait"
        Me.b3.UseVisualStyleBackColor = True
        '
        'b1
        '
        Me.b1.Location = New System.Drawing.Point(55, 26)
        Me.b1.Name = "b1"
        Me.b1.Size = New System.Drawing.Size(221, 51)
        Me.b1.TabIndex = 0
        Me.b1.Text = "Execute Task and Wait"
        Me.b1.UseVisualStyleBackColor = True
        '
        'b4
        '
        Me.b4.Location = New System.Drawing.Point(55, 256)
        Me.b4.Name = "b4"
        Me.b4.Size = New System.Drawing.Size(221, 51)
        Me.b4.TabIndex = 0
        Me.b4.Text = "Execute Different Tasks and Wait"
        Me.b4.UseVisualStyleBackColor = True
        '
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(324, 349)
        Me.Controls.Add(Me.b4)
        Me.Controls.Add(Me.b3)
        Me.Controls.Add(Me.b1)
        Me.Controls.Add(Me.b2)
        Me.DoubleBuffered = True
        Me.Name = "Form1"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Form1"
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents b2 As Button
    Friend WithEvents b3 As Button
    Friend WithEvents b1 As Button
    Friend WithEvents b4 As Button
End Class
