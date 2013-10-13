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
        Me.StopButton = New System.Windows.Forms.Button()
        Me.PreviousButton = New System.Windows.Forms.Button()
        Me.TrackBar1 = New System.Windows.Forms.TrackBar()
        Me.NextButton = New System.Windows.Forms.Button()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.TrackBar2 = New System.Windows.Forms.TrackBar()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.TabControl1 = New System.Windows.Forms.TabControl()
        Me.TabPage2 = New System.Windows.Forms.TabPage()
        Me.SplitContainer1 = New System.Windows.Forms.SplitContainer()
        Me.ListView1 = New System.Windows.Forms.ListView()
        Me.ListBox1 = New System.Windows.Forms.ListBox()
        Me.TabPage1 = New System.Windows.Forms.TabPage()
        Me.SplitContainer2 = New System.Windows.Forms.SplitContainer()
        Me.ListBox2 = New System.Windows.Forms.ListBox()
        Me.ListView2 = New System.Windows.Forms.ListView()
        Me.TextBox1 = New System.Windows.Forms.TextBox()
        Me.SearchButton = New System.Windows.Forms.Button()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.TrackBar3 = New System.Windows.Forms.TrackBar()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.TrackBar4 = New System.Windows.Forms.TrackBar()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.MenuStrip1.SuspendLayout()
        CType(Me.TrackBar1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TrackBar2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TabControl1.SuspendLayout()
        Me.TabPage2.SuspendLayout()
        Me.SplitContainer1.Panel1.SuspendLayout()
        Me.SplitContainer1.Panel2.SuspendLayout()
        Me.SplitContainer1.SuspendLayout()
        Me.TabPage1.SuspendLayout()
        Me.SplitContainer2.Panel1.SuspendLayout()
        Me.SplitContainer2.Panel2.SuspendLayout()
        Me.SplitContainer2.SuspendLayout()
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
        Me.MenuStrip1.Size = New System.Drawing.Size(886, 27)
        Me.MenuStrip1.TabIndex = 2
        Me.MenuStrip1.Text = "MenuStrip1"
        '
        'ToolStripMenuItem1
        '
        Me.ToolStripMenuItem1.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.运行OSUToolStripMenuItem, Me.手动指定OSU目录ToolStripMenuItem, Me.ToolStripSeparator1, Me.重新导入osuToolStripMenuItem7, Me.重新导入scoresToolStripMenuItem, Me.重新导入collectionsToolStripMenuItem9, Me.ToolStripSeparator2, Me.打开曲目文件夹ToolStripMenuItem, Me.打开铺面文件ToolStripMenuItem, Me.打开SB文件ToolStripMenuItem, Me.ToolStripSeparator3, Me.退出ToolStripMenuItem})
        Me.ToolStripMenuItem1.Name = "ToolStripMenuItem1"
        Me.ToolStripMenuItem1.Size = New System.Drawing.Size(51, 23)
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
        Me.ToolStripMenuItem2.Size = New System.Drawing.Size(51, 23)
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
        Me.ToolStripMenuItem3.Size = New System.Drawing.Size(51, 23)
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
        Me.关于ToolStripMenuItem.Size = New System.Drawing.Size(51, 23)
        Me.关于ToolStripMenuItem.Text = "关于"
        '
        'PlayButton
        '
        Me.PlayButton.Location = New System.Drawing.Point(12, 30)
        Me.PlayButton.Name = "PlayButton"
        Me.PlayButton.Size = New System.Drawing.Size(57, 23)
        Me.PlayButton.TabIndex = 3
        Me.PlayButton.Text = "播放"
        Me.PlayButton.UseVisualStyleBackColor = True
        '
        'StopButton
        '
        Me.StopButton.Location = New System.Drawing.Point(75, 30)
        Me.StopButton.Name = "StopButton"
        Me.StopButton.Size = New System.Drawing.Size(53, 23)
        Me.StopButton.TabIndex = 4
        Me.StopButton.Text = "停止"
        Me.StopButton.UseVisualStyleBackColor = True
        '
        'PreviousButton
        '
        Me.PreviousButton.Location = New System.Drawing.Point(134, 30)
        Me.PreviousButton.Name = "PreviousButton"
        Me.PreviousButton.Size = New System.Drawing.Size(43, 23)
        Me.PreviousButton.TabIndex = 5
        Me.PreviousButton.Text = "←"
        Me.PreviousButton.UseVisualStyleBackColor = True
        '
        'TrackBar1
        '
        Me.TrackBar1.Location = New System.Drawing.Point(386, 433)
        Me.TrackBar1.Maximum = 100
        Me.TrackBar1.Name = "TrackBar1"
        Me.TrackBar1.Size = New System.Drawing.Size(480, 56)
        Me.TrackBar1.TabIndex = 0
        Me.TrackBar1.TickStyle = System.Windows.Forms.TickStyle.None
        '
        'NextButton
        '
        Me.NextButton.Location = New System.Drawing.Point(183, 30)
        Me.NextButton.Name = "NextButton"
        Me.NextButton.Size = New System.Drawing.Size(43, 23)
        Me.NextButton.TabIndex = 6
        Me.NextButton.Text = "→"
        Me.NextButton.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(232, 34)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(163, 15)
        Me.Label1.TabIndex = 8
        Me.Label1.Text = "当前同步QQ:909643356"
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(416, 30)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(75, 23)
        Me.Button1.TabIndex = 9
        Me.Button1.Text = "选择QQ"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'TrackBar2
        '
        Me.TrackBar2.Location = New System.Drawing.Point(832, 67)
        Me.TrackBar2.Maximum = 100
        Me.TrackBar2.Name = "TrackBar2"
        Me.TrackBar2.Orientation = System.Windows.Forms.Orientation.Vertical
        Me.TrackBar2.Size = New System.Drawing.Size(56, 342)
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
        'TabControl1
        '
        Me.TabControl1.Controls.Add(Me.TabPage2)
        Me.TabControl1.Controls.Add(Me.TabPage1)
        Me.TabControl1.Location = New System.Drawing.Point(12, 67)
        Me.TabControl1.Name = "TabControl1"
        Me.TabControl1.SelectedIndex = 0
        Me.TabControl1.Size = New System.Drawing.Size(324, 360)
        Me.TabControl1.TabIndex = 12
        '
        'TabPage2
        '
        Me.TabPage2.Controls.Add(Me.SplitContainer1)
        Me.TabPage2.Location = New System.Drawing.Point(4, 25)
        Me.TabPage2.Name = "TabPage2"
        Me.TabPage2.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage2.Size = New System.Drawing.Size(316, 331)
        Me.TabPage2.TabIndex = 1
        Me.TabPage2.Text = "Osu"
        Me.TabPage2.UseVisualStyleBackColor = True
        '
        'SplitContainer1
        '
        Me.SplitContainer1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SplitContainer1.Location = New System.Drawing.Point(3, 3)
        Me.SplitContainer1.Name = "SplitContainer1"
        '
        'SplitContainer1.Panel1
        '
        Me.SplitContainer1.Panel1.Controls.Add(Me.ListView1)
        '
        'SplitContainer1.Panel2
        '
        Me.SplitContainer1.Panel2.Controls.Add(Me.ListBox1)
        Me.SplitContainer1.Size = New System.Drawing.Size(310, 325)
        Me.SplitContainer1.SplitterDistance = 199
        Me.SplitContainer1.TabIndex = 0
        '
        'ListView1
        '
        Me.ListView1.Location = New System.Drawing.Point(3, 3)
        Me.ListView1.Name = "ListView1"
        Me.ListView1.Size = New System.Drawing.Size(193, 319)
        Me.ListView1.TabIndex = 0
        Me.ListView1.UseCompatibleStateImageBehavior = False
        '
        'ListBox1
        '
        Me.ListBox1.FormattingEnabled = True
        Me.ListBox1.ItemHeight = 15
        Me.ListBox1.Location = New System.Drawing.Point(3, 3)
        Me.ListBox1.Name = "ListBox1"
        Me.ListBox1.Size = New System.Drawing.Size(101, 319)
        Me.ListBox1.TabIndex = 0
        '
        'TabPage1
        '
        Me.TabPage1.Controls.Add(Me.SplitContainer2)
        Me.TabPage1.Location = New System.Drawing.Point(4, 25)
        Me.TabPage1.Name = "TabPage1"
        Me.TabPage1.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage1.Size = New System.Drawing.Size(316, 331)
        Me.TabPage1.TabIndex = 0
        Me.TabPage1.Text = "Colletions"
        Me.TabPage1.UseVisualStyleBackColor = True
        '
        'SplitContainer2
        '
        Me.SplitContainer2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SplitContainer2.Location = New System.Drawing.Point(3, 3)
        Me.SplitContainer2.Name = "SplitContainer2"
        '
        'SplitContainer2.Panel1
        '
        Me.SplitContainer2.Panel1.Controls.Add(Me.ListBox2)
        '
        'SplitContainer2.Panel2
        '
        Me.SplitContainer2.Panel2.Controls.Add(Me.ListView2)
        Me.SplitContainer2.Size = New System.Drawing.Size(310, 325)
        Me.SplitContainer2.SplitterDistance = 103
        Me.SplitContainer2.TabIndex = 0
        '
        'ListBox2
        '
        Me.ListBox2.FormattingEnabled = True
        Me.ListBox2.ItemHeight = 15
        Me.ListBox2.Location = New System.Drawing.Point(4, 3)
        Me.ListBox2.Name = "ListBox2"
        Me.ListBox2.Size = New System.Drawing.Size(96, 319)
        Me.ListBox2.TabIndex = 0
        '
        'ListView2
        '
        Me.ListView2.Location = New System.Drawing.Point(3, 3)
        Me.ListView2.Name = "ListView2"
        Me.ListView2.Size = New System.Drawing.Size(197, 319)
        Me.ListView2.TabIndex = 1
        Me.ListView2.UseCompatibleStateImageBehavior = False
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
        Me.Label3.Location = New System.Drawing.Point(508, 34)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(37, 15)
        Me.Label3.TabIndex = 16
        Me.Label3.Text = "音效"
        '
        'TrackBar3
        '
        Me.TrackBar3.Location = New System.Drawing.Point(551, 34)
        Me.TrackBar3.Maximum = 100
        Me.TrackBar3.Name = "TrackBar3"
        Me.TrackBar3.Size = New System.Drawing.Size(122, 56)
        Me.TrackBar3.TabIndex = 15
        Me.TrackBar3.TickStyle = System.Windows.Forms.TickStyle.None
        Me.TrackBar3.Value = 60
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(679, 34)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(37, 15)
        Me.Label4.TabIndex = 18
        Me.Label4.Text = "音乐"
        '
        'TrackBar4
        '
        Me.TrackBar4.Location = New System.Drawing.Point(722, 34)
        Me.TrackBar4.Maximum = 100
        Me.TrackBar4.Name = "TrackBar4"
        Me.TrackBar4.Size = New System.Drawing.Size(122, 56)
        Me.TrackBar4.TabIndex = 17
        Me.TrackBar4.TickStyle = System.Windows.Forms.TickStyle.None
        Me.TrackBar4.Value = 80
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(343, 436)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(37, 15)
        Me.Label5.TabIndex = 19
        Me.Label5.Text = "进度"
        '
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 15.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(886, 593)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.TrackBar2)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.TrackBar4)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.TrackBar3)
        Me.Controls.Add(Me.SearchButton)
        Me.Controls.Add(Me.TextBox1)
        Me.Controls.Add(Me.TabControl1)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.NextButton)
        Me.Controls.Add(Me.TrackBar1)
        Me.Controls.Add(Me.PreviousButton)
        Me.Controls.Add(Me.StopButton)
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
        Me.TabControl1.ResumeLayout(False)
        Me.TabPage2.ResumeLayout(False)
        Me.SplitContainer1.Panel1.ResumeLayout(False)
        Me.SplitContainer1.Panel2.ResumeLayout(False)
        Me.SplitContainer1.ResumeLayout(False)
        Me.TabPage1.ResumeLayout(False)
        Me.SplitContainer2.Panel1.ResumeLayout(False)
        Me.SplitContainer2.Panel2.ResumeLayout(False)
        Me.SplitContainer2.ResumeLayout(False)
        CType(Me.TrackBar3, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TrackBar4, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
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
    Friend WithEvents StopButton As System.Windows.Forms.Button
    Friend WithEvents PreviousButton As System.Windows.Forms.Button
    Friend WithEvents TrackBar1 As System.Windows.Forms.TrackBar
    Friend WithEvents NextButton As System.Windows.Forms.Button
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents TrackBar2 As System.Windows.Forms.TrackBar
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents TabControl1 As System.Windows.Forms.TabControl
    Friend WithEvents TabPage2 As System.Windows.Forms.TabPage
    Friend WithEvents SplitContainer1 As System.Windows.Forms.SplitContainer
    Friend WithEvents ListBox1 As System.Windows.Forms.ListBox
    Friend WithEvents ListView1 As System.Windows.Forms.ListView
    Friend WithEvents TabPage1 As System.Windows.Forms.TabPage
    Friend WithEvents SplitContainer2 As System.Windows.Forms.SplitContainer
    Friend WithEvents ListBox2 As System.Windows.Forms.ListBox
    Friend WithEvents ListView2 As System.Windows.Forms.ListView
    Friend WithEvents 音效音乐控制ToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents SB开关ToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents TextBox1 As System.Windows.Forms.TextBox
    Friend WithEvents SearchButton As System.Windows.Forms.Button
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents TrackBar3 As System.Windows.Forms.TrackBar
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents TrackBar4 As System.Windows.Forms.TrackBar
    Friend WithEvents Label5 As System.Windows.Forms.Label

End Class
