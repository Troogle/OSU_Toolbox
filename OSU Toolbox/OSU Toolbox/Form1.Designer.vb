<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Form1
    Inherits System.Windows.Forms.Form

    'Form 重写 Dispose，以清理组件列表。
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

    'Windows 窗体设计器所必需的
    Private components As System.ComponentModel.IContainer

    '注意: 以下过程是 Windows 窗体设计器所必需的
    '可以使用 Windows 窗体设计器修改它。
    '不要使用代码编辑器修改它。
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.MenuStrip1 = New System.Windows.Forms.MenuStrip()
        Me.ToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem()
        Me.运行OSUToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.手动指定OSU目录ToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
        Me.重新导入osuToolStripMenuItem7 = New System.Windows.Forms.ToolStripMenuItem()
        Me.重新导入scoresToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.重新导入collectionsToolStripMenuItem9 = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator2 = New System.Windows.Forms.ToolStripSeparator()
        Me.打开曲目文件夹ToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.打开铺面文件ToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.打开SB文件ToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator3 = New System.Windows.Forms.ToolStripSeparator()
        Me.退出ToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItem2 = New System.Windows.Forms.ToolStripMenuItem()
        Me.重复歌曲扫描ToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItem3 = New System.Windows.Forms.ToolStripMenuItem()
        Me.音效ToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.视频开关ToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.播放模式ToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.随机播放ToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem()
        Me.顺序播放ToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.单曲循环ToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.QQ状态同步ToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.音效音乐控制ToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.SB开关ToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.关于ToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.PlayButton = New System.Windows.Forms.Button()
        Me.PreviousButton = New System.Windows.Forms.Button()
        Me.TrackBar1 = New System.Windows.Forms.TrackBar()
        Me.NextButton = New System.Windows.Forms.Button()
        Me.LabelQQ = New System.Windows.Forms.Label()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.TrackBar2 = New System.Windows.Forms.TrackBar()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.ListView1 = New System.Windows.Forms.ListView()
        Me.ListBox1 = New System.Windows.Forms.ListBox()
        Me.TextBox1 = New System.Windows.Forms.TextBox()
        Me.SearchButton = New System.Windows.Forms.Button()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.TrackBar3 = New System.Windows.Forms.TrackBar()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.TrackBar4 = New System.Windows.Forms.TrackBar()
        Me.Timer1 = New System.Windows.Forms.Timer(Me.components)
        Me.Timer2 = New System.Windows.Forms.Timer(Me.components)
        Me.Button2 = New System.Windows.Forms.Button()
        Me.MenuStrip1.SuspendLayout()
        CType(Me.TrackBar1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TrackBar2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TrackBar3, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TrackBar4, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Panel1
        '
        Me.Panel1.Location = New System.Drawing.Point(342, 67)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(480, 360)
        Me.Panel1.TabIndex = 1
        '
        'MenuStrip1
        '
        Me.MenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripMenuItem1, Me.ToolStripMenuItem2, Me.ToolStripMenuItem3, Me.关于ToolStripMenuItem})
        Me.MenuStrip1.Location = New System.Drawing.Point(0, 0)
        Me.MenuStrip1.Name = "MenuStrip1"
        Me.MenuStrip1.Size = New System.Drawing.Size(886, 28)
        Me.MenuStrip1.TabIndex = 2
        Me.MenuStrip1.Text = "MenuStrip1"
        '
        'ToolStripMenuItem1
        '
        Me.ToolStripMenuItem1.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.运行OSUToolStripMenuItem, Me.手动指定OSU目录ToolStripMenuItem, Me.ToolStripSeparator1, Me.重新导入osuToolStripMenuItem7, Me.重新导入scoresToolStripMenuItem, Me.重新导入collectionsToolStripMenuItem9, Me.ToolStripSeparator2, Me.打开曲目文件夹ToolStripMenuItem, Me.打开铺面文件ToolStripMenuItem, Me.打开SB文件ToolStripMenuItem, Me.ToolStripSeparator3, Me.退出ToolStripMenuItem})
        Me.ToolStripMenuItem1.Name = "ToolStripMenuItem1"
        Me.ToolStripMenuItem1.Size = New System.Drawing.Size(51, 24)
        Me.ToolStripMenuItem1.Text = "文件"
        '
        '运行OSUToolStripMenuItem
        '
        Me.运行OSUToolStripMenuItem.Name = "运行OSUToolStripMenuItem"
        Me.运行OSUToolStripMenuItem.Size = New System.Drawing.Size(241, 24)
        Me.运行OSUToolStripMenuItem.Text = "运行OSU!"
        '
        '手动指定OSU目录ToolStripMenuItem
        '
        Me.手动指定OSU目录ToolStripMenuItem.Name = "手动指定OSU目录ToolStripMenuItem"
        Me.手动指定OSU目录ToolStripMenuItem.Size = New System.Drawing.Size(241, 24)
        Me.手动指定OSU目录ToolStripMenuItem.Text = "手动指定OSU目录"
        '
        'ToolStripSeparator1
        '
        Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
        Me.ToolStripSeparator1.Size = New System.Drawing.Size(238, 6)
        '
        '重新导入osuToolStripMenuItem7
        '
        Me.重新导入osuToolStripMenuItem7.Name = "重新导入osuToolStripMenuItem7"
        Me.重新导入osuToolStripMenuItem7.Size = New System.Drawing.Size(241, 24)
        Me.重新导入osuToolStripMenuItem7.Text = "重新导入osu.db"
        '
        '重新导入scoresToolStripMenuItem
        '
        Me.重新导入scoresToolStripMenuItem.Name = "重新导入scoresToolStripMenuItem"
        Me.重新导入scoresToolStripMenuItem.Size = New System.Drawing.Size(241, 24)
        Me.重新导入scoresToolStripMenuItem.Text = "重新导入scores.db"
        '
        '重新导入collectionsToolStripMenuItem9
        '
        Me.重新导入collectionsToolStripMenuItem9.Name = "重新导入collectionsToolStripMenuItem9"
        Me.重新导入collectionsToolStripMenuItem9.Size = New System.Drawing.Size(241, 24)
        Me.重新导入collectionsToolStripMenuItem9.Text = "重新导入collections.db"
        '
        'ToolStripSeparator2
        '
        Me.ToolStripSeparator2.Name = "ToolStripSeparator2"
        Me.ToolStripSeparator2.Size = New System.Drawing.Size(238, 6)
        '
        '打开曲目文件夹ToolStripMenuItem
        '
        Me.打开曲目文件夹ToolStripMenuItem.Name = "打开曲目文件夹ToolStripMenuItem"
        Me.打开曲目文件夹ToolStripMenuItem.Size = New System.Drawing.Size(241, 24)
        Me.打开曲目文件夹ToolStripMenuItem.Text = "打开曲目文件夹"
        '
        '打开铺面文件ToolStripMenuItem
        '
        Me.打开铺面文件ToolStripMenuItem.Name = "打开铺面文件ToolStripMenuItem"
        Me.打开铺面文件ToolStripMenuItem.Size = New System.Drawing.Size(241, 24)
        Me.打开铺面文件ToolStripMenuItem.Text = "打开铺面文件"
        '
        '打开SB文件ToolStripMenuItem
        '
        Me.打开SB文件ToolStripMenuItem.Name = "打开SB文件ToolStripMenuItem"
        Me.打开SB文件ToolStripMenuItem.Size = New System.Drawing.Size(241, 24)
        Me.打开SB文件ToolStripMenuItem.Text = "打开SB文件"
        '
        'ToolStripSeparator3
        '
        Me.ToolStripSeparator3.Name = "ToolStripSeparator3"
        Me.ToolStripSeparator3.Size = New System.Drawing.Size(238, 6)
        '
        '退出ToolStripMenuItem
        '
        Me.退出ToolStripMenuItem.Name = "退出ToolStripMenuItem"
        Me.退出ToolStripMenuItem.Size = New System.Drawing.Size(241, 24)
        Me.退出ToolStripMenuItem.Text = "退出"
        '
        'ToolStripMenuItem2
        '
        Me.ToolStripMenuItem2.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.重复歌曲扫描ToolStripMenuItem})
        Me.ToolStripMenuItem2.Name = "ToolStripMenuItem2"
        Me.ToolStripMenuItem2.Size = New System.Drawing.Size(51, 24)
        Me.ToolStripMenuItem2.Text = "工具"
        '
        '重复歌曲扫描ToolStripMenuItem
        '
        Me.重复歌曲扫描ToolStripMenuItem.Name = "重复歌曲扫描ToolStripMenuItem"
        Me.重复歌曲扫描ToolStripMenuItem.Size = New System.Drawing.Size(168, 24)
        Me.重复歌曲扫描ToolStripMenuItem.Text = "重复歌曲扫描"
        '
        'ToolStripMenuItem3
        '
        Me.ToolStripMenuItem3.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.音效ToolStripMenuItem, Me.视频开关ToolStripMenuItem, Me.播放模式ToolStripMenuItem, Me.QQ状态同步ToolStripMenuItem, Me.音效音乐控制ToolStripMenuItem, Me.SB开关ToolStripMenuItem})
        Me.ToolStripMenuItem3.Name = "ToolStripMenuItem3"
        Me.ToolStripMenuItem3.Size = New System.Drawing.Size(51, 24)
        Me.ToolStripMenuItem3.Text = "选项"
        '
        '音效ToolStripMenuItem
        '
        Me.音效ToolStripMenuItem.Checked = True
        Me.音效ToolStripMenuItem.CheckOnClick = True
        Me.音效ToolStripMenuItem.CheckState = System.Windows.Forms.CheckState.Checked
        Me.音效ToolStripMenuItem.Name = "音效ToolStripMenuItem"
        Me.音效ToolStripMenuItem.Size = New System.Drawing.Size(168, 24)
        Me.音效ToolStripMenuItem.Text = "音效开关"
        '
        '视频开关ToolStripMenuItem
        '
        Me.视频开关ToolStripMenuItem.Checked = True
        Me.视频开关ToolStripMenuItem.CheckOnClick = True
        Me.视频开关ToolStripMenuItem.CheckState = System.Windows.Forms.CheckState.Checked
        Me.视频开关ToolStripMenuItem.Name = "视频开关ToolStripMenuItem"
        Me.视频开关ToolStripMenuItem.Size = New System.Drawing.Size(168, 24)
        Me.视频开关ToolStripMenuItem.Text = "视频开关"
        '
        '播放模式ToolStripMenuItem
        '
        Me.播放模式ToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.随机播放ToolStripMenuItem1, Me.顺序播放ToolStripMenuItem, Me.单曲循环ToolStripMenuItem})
        Me.播放模式ToolStripMenuItem.Name = "播放模式ToolStripMenuItem"
        Me.播放模式ToolStripMenuItem.Size = New System.Drawing.Size(168, 24)
        Me.播放模式ToolStripMenuItem.Text = "播放模式"
        '
        '随机播放ToolStripMenuItem1
        '
        Me.随机播放ToolStripMenuItem1.Checked = True
        Me.随机播放ToolStripMenuItem1.CheckOnClick = True
        Me.随机播放ToolStripMenuItem1.CheckState = System.Windows.Forms.CheckState.Checked
        Me.随机播放ToolStripMenuItem1.Name = "随机播放ToolStripMenuItem1"
        Me.随机播放ToolStripMenuItem1.Size = New System.Drawing.Size(138, 24)
        Me.随机播放ToolStripMenuItem1.Text = "随机播放"
        '
        '顺序播放ToolStripMenuItem
        '
        Me.顺序播放ToolStripMenuItem.CheckOnClick = True
        Me.顺序播放ToolStripMenuItem.Name = "顺序播放ToolStripMenuItem"
        Me.顺序播放ToolStripMenuItem.Size = New System.Drawing.Size(138, 24)
        Me.顺序播放ToolStripMenuItem.Text = "顺序播放"
        '
        '单曲循环ToolStripMenuItem
        '
        Me.单曲循环ToolStripMenuItem.CheckOnClick = True
        Me.单曲循环ToolStripMenuItem.Name = "单曲循环ToolStripMenuItem"
        Me.单曲循环ToolStripMenuItem.Size = New System.Drawing.Size(138, 24)
        Me.单曲循环ToolStripMenuItem.Text = "单曲循环"
        '
        'QQ状态同步ToolStripMenuItem
        '
        Me.QQ状态同步ToolStripMenuItem.Checked = True
        Me.QQ状态同步ToolStripMenuItem.CheckOnClick = True
        Me.QQ状态同步ToolStripMenuItem.CheckState = System.Windows.Forms.CheckState.Checked
        Me.QQ状态同步ToolStripMenuItem.Name = "QQ状态同步ToolStripMenuItem"
        Me.QQ状态同步ToolStripMenuItem.Size = New System.Drawing.Size(168, 24)
        Me.QQ状态同步ToolStripMenuItem.Text = "QQ状态同步"
        '
        '音效音乐控制ToolStripMenuItem
        '
        Me.音效音乐控制ToolStripMenuItem.Name = "音效音乐控制ToolStripMenuItem"
        Me.音效音乐控制ToolStripMenuItem.Size = New System.Drawing.Size(168, 24)
        Me.音效音乐控制ToolStripMenuItem.Text = "音效音乐控制"
        '
        'SB开关ToolStripMenuItem
        '
        Me.SB开关ToolStripMenuItem.Name = "SB开关ToolStripMenuItem"
        Me.SB开关ToolStripMenuItem.Size = New System.Drawing.Size(168, 24)
        Me.SB开关ToolStripMenuItem.Text = "SB开关"
        '
        '关于ToolStripMenuItem
        '
        Me.关于ToolStripMenuItem.Name = "关于ToolStripMenuItem"
        Me.关于ToolStripMenuItem.Size = New System.Drawing.Size(51, 24)
        Me.关于ToolStripMenuItem.Text = "关于"
        '
        'PlayButton
        '
        Me.PlayButton.Location = New System.Drawing.Point(342, 435)
        Me.PlayButton.Name = "PlayButton"
        Me.PlayButton.Size = New System.Drawing.Size(57, 23)
        Me.PlayButton.TabIndex = 3
        Me.PlayButton.Text = "播放"
        Me.PlayButton.UseVisualStyleBackColor = True
        '
        'PreviousButton
        '
        Me.PreviousButton.Location = New System.Drawing.Point(405, 435)
        Me.PreviousButton.Name = "PreviousButton"
        Me.PreviousButton.Size = New System.Drawing.Size(43, 23)
        Me.PreviousButton.TabIndex = 5
        Me.PreviousButton.Text = "←"
        Me.PreviousButton.UseVisualStyleBackColor = True
        '
        'TrackBar1
        '
        Me.TrackBar1.AutoSize = False
        Me.TrackBar1.Enabled = False
        Me.TrackBar1.Location = New System.Drawing.Point(503, 433)
        Me.TrackBar1.Maximum = 100
        Me.TrackBar1.Name = "TrackBar1"
        Me.TrackBar1.Size = New System.Drawing.Size(363, 28)
        Me.TrackBar1.TabIndex = 0
        Me.TrackBar1.TickStyle = System.Windows.Forms.TickStyle.None
        '
        'NextButton
        '
        Me.NextButton.Location = New System.Drawing.Point(454, 435)
        Me.NextButton.Name = "NextButton"
        Me.NextButton.Size = New System.Drawing.Size(43, 23)
        Me.NextButton.TabIndex = 6
        Me.NextButton.Text = "→"
        Me.NextButton.UseVisualStyleBackColor = True
        '
        'LabelQQ
        '
        Me.LabelQQ.AutoSize = True
        Me.LabelQQ.Location = New System.Drawing.Point(149, 38)
        Me.LabelQQ.Name = "LabelQQ"
        Me.LabelQQ.Size = New System.Drawing.Size(91, 15)
        Me.LabelQQ.TabIndex = 8
        Me.LabelQQ.Text = "当前同步QQ:"
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(342, 34)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(75, 23)
        Me.Button1.TabIndex = 9
        Me.Button1.Text = "选择QQ"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'TrackBar2
        '
        Me.TrackBar2.AutoSize = False
        Me.TrackBar2.Location = New System.Drawing.Point(832, 67)
        Me.TrackBar2.Maximum = 100
        Me.TrackBar2.Name = "TrackBar2"
        Me.TrackBar2.Orientation = System.Windows.Forms.Orientation.Vertical
        Me.TrackBar2.Size = New System.Drawing.Size(34, 342)
        Me.TrackBar2.TabIndex = 10
        Me.TrackBar2.TickStyle = System.Windows.Forms.TickStyle.None
        Me.TrackBar2.Value = 100
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(829, 412)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(37, 15)
        Me.Label2.TabIndex = 11
        Me.Label2.Text = "音量"
        '
        'ListView1
        '
        Me.ListView1.FullRowSelect = True
        Me.ListView1.GridLines = True
        Me.ListView1.Location = New System.Drawing.Point(16, 67)
        Me.ListView1.MultiSelect = False
        Me.ListView1.Name = "ListView1"
        Me.ListView1.Size = New System.Drawing.Size(316, 360)
        Me.ListView1.TabIndex = 0
        Me.ListView1.UseCompatibleStateImageBehavior = False
        Me.ListView1.View = System.Windows.Forms.View.List
        '
        'ListBox1
        '
        Me.ListBox1.FormattingEnabled = True
        Me.ListBox1.ItemHeight = 15
        Me.ListBox1.Location = New System.Drawing.Point(12, 472)
        Me.ListBox1.Name = "ListBox1"
        Me.ListBox1.Size = New System.Drawing.Size(320, 94)
        Me.ListBox1.TabIndex = 0
        '
        'TextBox1
        '
        Me.TextBox1.Location = New System.Drawing.Point(12, 433)
        Me.TextBox1.Name = "TextBox1"
        Me.TextBox1.Size = New System.Drawing.Size(239, 25)
        Me.TextBox1.TabIndex = 13
        '
        'SearchButton
        '
        Me.SearchButton.Location = New System.Drawing.Point(257, 433)
        Me.SearchButton.Name = "SearchButton"
        Me.SearchButton.Size = New System.Drawing.Size(75, 25)
        Me.SearchButton.TabIndex = 14
        Me.SearchButton.Text = "搜索"
        Me.SearchButton.UseVisualStyleBackColor = True
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(625, 38)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(37, 15)
        Me.Label3.TabIndex = 16
        Me.Label3.Text = "音效"
        '
        'TrackBar3
        '
        Me.TrackBar3.AutoSize = False
        Me.TrackBar3.Location = New System.Drawing.Point(668, 34)
        Me.TrackBar3.Maximum = 100
        Me.TrackBar3.Name = "TrackBar3"
        Me.TrackBar3.Size = New System.Drawing.Size(154, 27)
        Me.TrackBar3.TabIndex = 15
        Me.TrackBar3.TickStyle = System.Windows.Forms.TickStyle.None
        Me.TrackBar3.Value = 60
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(435, 38)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(37, 15)
        Me.Label4.TabIndex = 18
        Me.Label4.Text = "音乐"
        '
        'TrackBar4
        '
        Me.TrackBar4.AutoSize = False
        Me.TrackBar4.Location = New System.Drawing.Point(478, 34)
        Me.TrackBar4.Maximum = 100
        Me.TrackBar4.Name = "TrackBar4"
        Me.TrackBar4.Size = New System.Drawing.Size(138, 27)
        Me.TrackBar4.TabIndex = 17
        Me.TrackBar4.TickStyle = System.Windows.Forms.TickStyle.None
        Me.TrackBar4.Value = 80
        '
        'Timer1
        '
        '
        'Timer2
        '
        '
        'Button2
        '
        Me.Button2.Location = New System.Drawing.Point(16, 34)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(127, 23)
        Me.Button2.TabIndex = 9
        Me.Button2.Text = "选择Collection"
        Me.Button2.UseVisualStyleBackColor = True
        '
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 15.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(886, 593)
        Me.Controls.Add(Me.TrackBar3)
        Me.Controls.Add(Me.ListView1)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.ListBox1)
        Me.Controls.Add(Me.TrackBar2)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.TrackBar4)
        Me.Controls.Add(Me.SearchButton)
        Me.Controls.Add(Me.TextBox1)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Button2)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.LabelQQ)
        Me.Controls.Add(Me.NextButton)
        Me.Controls.Add(Me.TrackBar1)
        Me.Controls.Add(Me.PreviousButton)
        Me.Controls.Add(Me.PlayButton)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.MenuStrip1)
        Me.MainMenuStrip = Me.MenuStrip1
        Me.Name = "Form1"
        Me.Text = "Form1"
        Me.MenuStrip1.ResumeLayout(False)
        Me.MenuStrip1.PerformLayout()
        CType(Me.TrackBar1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TrackBar2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TrackBar3, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TrackBar4, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents MenuStrip1 As System.Windows.Forms.MenuStrip
    Friend WithEvents ToolStripMenuItem1 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents 运行OSUToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents 手动指定OSU目录ToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripSeparator1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents 重新导入osuToolStripMenuItem7 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents 重新导入scoresToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents 重新导入collectionsToolStripMenuItem9 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripSeparator2 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents 打开曲目文件夹ToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents 打开铺面文件ToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents 打开SB文件ToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripMenuItem2 As System.Windows.Forms.ToolStripMenuItem
    Private WithEvents ToolStripMenuItem3 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents 关于ToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents 重复歌曲扫描ToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents 音效ToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripSeparator3 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents 退出ToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents 视频开关ToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents 播放模式ToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents 随机播放ToolStripMenuItem1 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents 顺序播放ToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents 单曲循环ToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents QQ状态同步ToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents PlayButton As System.Windows.Forms.Button
    Friend WithEvents PreviousButton As System.Windows.Forms.Button
    Friend WithEvents TrackBar1 As System.Windows.Forms.TrackBar
    Friend WithEvents NextButton As System.Windows.Forms.Button
    Friend WithEvents LabelQQ As System.Windows.Forms.Label
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents TrackBar2 As System.Windows.Forms.TrackBar
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents ListBox1 As System.Windows.Forms.ListBox
    Friend WithEvents ListView1 As System.Windows.Forms.ListView
    Friend WithEvents 音效音乐控制ToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents SB开关ToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents TextBox1 As System.Windows.Forms.TextBox
    Friend WithEvents SearchButton As System.Windows.Forms.Button
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents TrackBar3 As System.Windows.Forms.TrackBar
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents TrackBar4 As System.Windows.Forms.TrackBar
    Friend WithEvents Timer1 As System.Windows.Forms.Timer
    Friend WithEvents Timer2 As System.Windows.Forms.Timer
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents Button2 As System.Windows.Forms.Button

End Class
