<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Main_Screen
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        If disposing AndAlso components IsNot Nothing Then
            components.Dispose()
        End If
        MyBase.Dispose(disposing)
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Main_Screen))
        Me.SplitContainer1 = New System.Windows.Forms.SplitContainer
        Me.SplitContainer2 = New System.Windows.Forms.SplitContainer
        Me.Label1 = New System.Windows.Forms.Label
        Me.StatusLabel = New System.Windows.Forms.Label
        Me.ListBox2 = New System.Windows.Forms.ListBox
        Me.ListBox3 = New System.Windows.Forms.ListBox
        Me.ListBox1 = New System.Windows.Forms.ListBox
        Me.WebBrowser1 = New System.Windows.Forms.WebBrowser
        Me.MenuStrip1 = New System.Windows.Forms.MenuStrip
        Me.ClearCacheToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.ClearCacheToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem
        Me.ToolStripSeparator2 = New System.Windows.Forms.ToolStripSeparator
        Me.EditRSSFeedsToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.EditCSSStylesheetToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator
        Me.ProxyUsernamePasswordToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.ToolStripSeparator3 = New System.Windows.Forms.ToolStripSeparator
        Me.ExitToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.HelpToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.AboutToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.AboutToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem
        Me.AutoUpdateToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.BackgroundWorker1 = New System.ComponentModel.BackgroundWorker
        Me.SplitContainer1.Panel1.SuspendLayout()
        Me.SplitContainer1.Panel2.SuspendLayout()
        Me.SplitContainer1.SuspendLayout()
        Me.SplitContainer2.Panel1.SuspendLayout()
        Me.SplitContainer2.Panel2.SuspendLayout()
        Me.SplitContainer2.SuspendLayout()
        Me.MenuStrip1.SuspendLayout()
        Me.SuspendLayout()
        '
        'SplitContainer1
        '
        Me.SplitContainer1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SplitContainer1.Location = New System.Drawing.Point(0, 24)
        Me.SplitContainer1.Name = "SplitContainer1"
        '
        'SplitContainer1.Panel1
        '
        Me.SplitContainer1.Panel1.Controls.Add(Me.SplitContainer2)
        '
        'SplitContainer1.Panel2
        '
        Me.SplitContainer1.Panel2.Controls.Add(Me.WebBrowser1)
        Me.SplitContainer1.Size = New System.Drawing.Size(792, 542)
        Me.SplitContainer1.SplitterDistance = 232
        Me.SplitContainer1.TabIndex = 0
        '
        'SplitContainer2
        '
        Me.SplitContainer2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SplitContainer2.FixedPanel = System.Windows.Forms.FixedPanel.Panel1
        Me.SplitContainer2.IsSplitterFixed = True
        Me.SplitContainer2.Location = New System.Drawing.Point(0, 0)
        Me.SplitContainer2.Name = "SplitContainer2"
        Me.SplitContainer2.Orientation = System.Windows.Forms.Orientation.Horizontal
        '
        'SplitContainer2.Panel1
        '
        Me.SplitContainer2.Panel1.BackColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.SplitContainer2.Panel1.BackgroundImage = Global.Raccoon_RSS_Reader.My.Resources.Resources.Left_Block_Background
        Me.SplitContainer2.Panel1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.SplitContainer2.Panel1.Controls.Add(Me.Label1)
        '
        'SplitContainer2.Panel2
        '
        Me.SplitContainer2.Panel2.Controls.Add(Me.StatusLabel)
        Me.SplitContainer2.Panel2.Controls.Add(Me.ListBox2)
        Me.SplitContainer2.Panel2.Controls.Add(Me.ListBox3)
        Me.SplitContainer2.Panel2.Controls.Add(Me.ListBox1)
        Me.SplitContainer2.Size = New System.Drawing.Size(232, 542)
        Me.SplitContainer2.SplitterDistance = 40
        Me.SplitContainer2.TabIndex = 2
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(12, 11)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(94, 19)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "RSS Feeds"
        '
        'StatusLabel
        '
        Me.StatusLabel.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.StatusLabel.ForeColor = System.Drawing.SystemColors.ControlDarkDark
        Me.StatusLabel.Location = New System.Drawing.Point(0, 475)
        Me.StatusLabel.Name = "StatusLabel"
        Me.StatusLabel.Size = New System.Drawing.Size(232, 23)
        Me.StatusLabel.TabIndex = 3
        Me.StatusLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'ListBox2
        '
        Me.ListBox2.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.ListBox2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.ListBox2.FormattingEnabled = True
        Me.ListBox2.Location = New System.Drawing.Point(0, 0)
        Me.ListBox2.Name = "ListBox2"
        Me.ListBox2.Size = New System.Drawing.Size(232, 494)
        Me.ListBox2.TabIndex = 1
        '
        'ListBox3
        '
        Me.ListBox3.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.ListBox3.FormattingEnabled = True
        Me.ListBox3.Location = New System.Drawing.Point(0, 2)
        Me.ListBox3.Name = "ListBox3"
        Me.ListBox3.Size = New System.Drawing.Size(10, 0)
        Me.ListBox3.TabIndex = 2
        Me.ListBox3.Visible = False
        '
        'ListBox1
        '
        Me.ListBox1.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.ListBox1.FormattingEnabled = True
        Me.ListBox1.Location = New System.Drawing.Point(0, 0)
        Me.ListBox1.Name = "ListBox1"
        Me.ListBox1.Size = New System.Drawing.Size(10, 0)
        Me.ListBox1.TabIndex = 1
        Me.ListBox1.Visible = False
        '
        'WebBrowser1
        '
        Me.WebBrowser1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.WebBrowser1.Location = New System.Drawing.Point(0, 0)
        Me.WebBrowser1.MinimumSize = New System.Drawing.Size(20, 20)
        Me.WebBrowser1.Name = "WebBrowser1"
        Me.WebBrowser1.Size = New System.Drawing.Size(556, 542)
        Me.WebBrowser1.TabIndex = 0
        '
        'MenuStrip1
        '
        Me.MenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ClearCacheToolStripMenuItem, Me.HelpToolStripMenuItem, Me.AboutToolStripMenuItem})
        Me.MenuStrip1.Location = New System.Drawing.Point(0, 0)
        Me.MenuStrip1.Name = "MenuStrip1"
        Me.MenuStrip1.Size = New System.Drawing.Size(792, 24)
        Me.MenuStrip1.TabIndex = 1
        Me.MenuStrip1.Text = "MenuStrip1"
        '
        'ClearCacheToolStripMenuItem
        '
        Me.ClearCacheToolStripMenuItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text
        Me.ClearCacheToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ClearCacheToolStripMenuItem1, Me.ToolStripSeparator2, Me.EditRSSFeedsToolStripMenuItem, Me.EditCSSStylesheetToolStripMenuItem, Me.ToolStripSeparator1, Me.ProxyUsernamePasswordToolStripMenuItem, Me.ToolStripSeparator3, Me.ExitToolStripMenuItem})
        Me.ClearCacheToolStripMenuItem.Name = "ClearCacheToolStripMenuItem"
        Me.ClearCacheToolStripMenuItem.Size = New System.Drawing.Size(45, 20)
        Me.ClearCacheToolStripMenuItem.Text = "Menu"
        '
        'ClearCacheToolStripMenuItem1
        '
        Me.ClearCacheToolStripMenuItem1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text
        Me.ClearCacheToolStripMenuItem1.Name = "ClearCacheToolStripMenuItem1"
        Me.ClearCacheToolStripMenuItem1.Size = New System.Drawing.Size(214, 22)
        Me.ClearCacheToolStripMenuItem1.Text = "Clear Cache"
        '
        'ToolStripSeparator2
        '
        Me.ToolStripSeparator2.Name = "ToolStripSeparator2"
        Me.ToolStripSeparator2.Size = New System.Drawing.Size(211, 6)
        '
        'EditRSSFeedsToolStripMenuItem
        '
        Me.EditRSSFeedsToolStripMenuItem.Name = "EditRSSFeedsToolStripMenuItem"
        Me.EditRSSFeedsToolStripMenuItem.Size = New System.Drawing.Size(214, 22)
        Me.EditRSSFeedsToolStripMenuItem.Text = "Edit RSS Feeds"
        '
        'EditCSSStylesheetToolStripMenuItem
        '
        Me.EditCSSStylesheetToolStripMenuItem.Name = "EditCSSStylesheetToolStripMenuItem"
        Me.EditCSSStylesheetToolStripMenuItem.Size = New System.Drawing.Size(214, 22)
        Me.EditCSSStylesheetToolStripMenuItem.Text = "Edit CSS Stylesheet"
        '
        'ToolStripSeparator1
        '
        Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
        Me.ToolStripSeparator1.Size = New System.Drawing.Size(211, 6)
        '
        'ProxyUsernamePasswordToolStripMenuItem
        '
        Me.ProxyUsernamePasswordToolStripMenuItem.Name = "ProxyUsernamePasswordToolStripMenuItem"
        Me.ProxyUsernamePasswordToolStripMenuItem.Size = New System.Drawing.Size(214, 22)
        Me.ProxyUsernamePasswordToolStripMenuItem.Text = "Proxy Username/Password"
        '
        'ToolStripSeparator3
        '
        Me.ToolStripSeparator3.Name = "ToolStripSeparator3"
        Me.ToolStripSeparator3.Size = New System.Drawing.Size(211, 6)
        '
        'ExitToolStripMenuItem
        '
        Me.ExitToolStripMenuItem.Name = "ExitToolStripMenuItem"
        Me.ExitToolStripMenuItem.Size = New System.Drawing.Size(214, 22)
        Me.ExitToolStripMenuItem.Text = "Exit"
        '
        'HelpToolStripMenuItem
        '
        Me.HelpToolStripMenuItem.Name = "HelpToolStripMenuItem"
        Me.HelpToolStripMenuItem.Size = New System.Drawing.Size(40, 20)
        Me.HelpToolStripMenuItem.Text = "Help"
        '
        'AboutToolStripMenuItem
        '
        Me.AboutToolStripMenuItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text
        Me.AboutToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.AboutToolStripMenuItem1, Me.AutoUpdateToolStripMenuItem})
        Me.AboutToolStripMenuItem.Name = "AboutToolStripMenuItem"
        Me.AboutToolStripMenuItem.Size = New System.Drawing.Size(48, 20)
        Me.AboutToolStripMenuItem.Text = "About"
        '
        'AboutToolStripMenuItem1
        '
        Me.AboutToolStripMenuItem1.Name = "AboutToolStripMenuItem1"
        Me.AboutToolStripMenuItem1.Size = New System.Drawing.Size(218, 22)
        Me.AboutToolStripMenuItem1.Text = "About Raccoon RSS Reader"
        '
        'AutoUpdateToolStripMenuItem
        '
        Me.AutoUpdateToolStripMenuItem.Name = "AutoUpdateToolStripMenuItem"
        Me.AutoUpdateToolStripMenuItem.Size = New System.Drawing.Size(218, 22)
        Me.AutoUpdateToolStripMenuItem.Text = "AutoUpdate"
        '
        'BackgroundWorker1
        '
        '
        'Main_Screen
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(792, 566)
        Me.Controls.Add(Me.SplitContainer1)
        Me.Controls.Add(Me.MenuStrip1)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MainMenuStrip = Me.MenuStrip1
        Me.Name = "Main_Screen"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Raccoon RSS Reader"
        Me.SplitContainer1.Panel1.ResumeLayout(False)
        Me.SplitContainer1.Panel2.ResumeLayout(False)
        Me.SplitContainer1.ResumeLayout(False)
        Me.SplitContainer2.Panel1.ResumeLayout(False)
        Me.SplitContainer2.Panel1.PerformLayout()
        Me.SplitContainer2.Panel2.ResumeLayout(False)
        Me.SplitContainer2.ResumeLayout(False)
        Me.MenuStrip1.ResumeLayout(False)
        Me.MenuStrip1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents SplitContainer1 As System.Windows.Forms.SplitContainer
    Friend WithEvents ListBox1 As System.Windows.Forms.ListBox
    Friend WithEvents WebBrowser1 As System.Windows.Forms.WebBrowser
    Friend WithEvents ListBox2 As System.Windows.Forms.ListBox
    Friend WithEvents MenuStrip1 As System.Windows.Forms.MenuStrip
    Friend WithEvents ClearCacheToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ClearCacheToolStripMenuItem1 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents AboutToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents SplitContainer2 As System.Windows.Forms.SplitContainer
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents EditRSSFeedsToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents EditCSSStylesheetToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ListBox3 As System.Windows.Forms.ListBox
    Friend WithEvents BackgroundWorker1 As System.ComponentModel.BackgroundWorker
    Friend WithEvents HelpToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents StatusLabel As System.Windows.Forms.Label
    Friend WithEvents ProxyUsernamePasswordToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripSeparator2 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents ToolStripSeparator1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents ToolStripSeparator3 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents ExitToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents AboutToolStripMenuItem1 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents AutoUpdateToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem

End Class
