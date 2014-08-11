Imports System.Xml
Imports System.IO

Public Class Main_Screen
    Dim savefilescheck As Boolean = True
    Dim lastindex As Integer = -1
    Dim displayrest As Boolean = False
    Dim recorded_distance As Integer

    Private AutoUpdate As Boolean = False

    Private Sub Error_Handler(ByVal ex As Exception, Optional ByVal identifier_msg As String = "")
        Try
            If My.Computer.FileSystem.FileExists((Application.StartupPath & "\Sounds\UHOH.WAV").Replace("\\", "\")) = True Then
                My.Computer.Audio.Play((Application.StartupPath & "\Sounds\UHOH.WAV").Replace("\\", "\"), AudioPlayMode.Background)
            End If
            Dim Display_Message1 As New Display_Message()
            Display_Message1.Message_Textbox.Text = "The Application encountered the following problem: " & vbCrLf & identifier_msg & ": " & ex.Message.ToString
            Display_Message1.Timer1.Interval = 1000
            Display_Message1.ShowDialog()
            Display_Message1.Dispose()
            Display_Message1 = Nothing
            If My.Computer.FileSystem.DirectoryExists((Application.StartupPath & "\").Replace("\\", "\") & "Error Logs") = False Then
                My.Computer.FileSystem.CreateDirectory((Application.StartupPath & "\").Replace("\\", "\") & "Error Logs")
            End If
            Dim filewriter As System.IO.StreamWriter = New System.IO.StreamWriter((Application.StartupPath & "\").Replace("\\", "\") & "Error Logs\" & Format(Now(), "yyyyMMdd") & "_Error_Log.txt", True)
            filewriter.WriteLine("#" & Format(Now(), "dd/MM/yyyy hh:mm:ss tt") & " - " & identifier_msg & ": " & ex.ToString)
            filewriter.Flush()
            filewriter.Close()
            filewriter = Nothing
            ex = Nothing
            identifier_msg = Nothing
            StatusLabel.Text = "Error encountered"
            If WebBrowser1.Url.Equals((Application.StartupPath & "\Loading.html").Replace("\\", "\")) Then
                If My.Computer.FileSystem.FileExists((Application.StartupPath & "\LoadFailed.html").Replace("\\", "\")) Then
                    WebBrowser1.Navigate((Application.StartupPath & "\LoadFailed.html").Replace("\\", "\"))
                    StatusLabel.Text = "Error encountered: Feed failed to load"
                End If

            End If
            If WebBrowser1.Url.Equals((Application.StartupPath & "\DownLoading.html").Replace("\\", "\")) Then
                If My.Computer.FileSystem.FileExists((Application.StartupPath & "\LoadFailed.html").Replace("\\", "\")) Then
                    WebBrowser1.Navigate((Application.StartupPath & "\LoadFailed.html").Replace("\\", "\"))
                    StatusLabel.Text = "Error encountered: Feed failed to load"
                End If

            End If

        Catch exc As Exception
            MsgBox("An error occurred in the application's error handling routine. The application will try to recover from this serious error.", MsgBoxStyle.Critical, "Critical Error Encountered")
        End Try
    End Sub

    Private Sub DisplayFeed(ByVal feed As String, ByVal tag As String)
        Try
            StatusLabel.Text = "Attempting to load feed..."
            tag = ListBox3.Items.Item(ListBox3.SelectedIndex)
            Dim filename1, filename2 As String
            filename1 = ""
            filename2 = ""

            Dim downloadfeed As Boolean = False
            Dim dinfo As DirectoryInfo = New DirectoryInfo(Application.StartupPath)
            For Each finfo As FileInfo In dinfo.GetFiles
                If finfo.Name.EndsWith(tag & ".xml") Then
                    If finfo.Name.Length > 15 Then
                        If IsNumeric(finfo.Name.Substring(0, 8)) Then
                            Dim yy, MM, dd, HH, mmm, ss As String
                            yy = finfo.Name.Substring(0, 4)
                            MM = finfo.Name.Substring(4, 2)
                            dd = finfo.Name.Substring(6, 2)
                            HH = finfo.Name.Substring(9, 2)
                            mmm = finfo.Name.Substring(11, 2)
                            ss = finfo.Name.Substring(13, 2)
                            Dim construct As Date = New Date(yy, MM, dd, HH, mmm, ss)
                            If DateDiff(DateInterval.Minute, construct, Now()) < 30 Then
                                downloadfeed = False
                                filename1 = (finfo.DirectoryName & "\" & finfo.Name.Substring(0, finfo.Name.Length - 4) & ".xml").Replace("\\", "\")
                                filename2 = (finfo.DirectoryName & "\" & finfo.Name.Substring(0, finfo.Name.Length - 4) & ".htm").Replace("\\", "\")
                            Else
                                downloadfeed = True
                                My.Computer.FileSystem.DeleteFile(finfo.FullName, FileIO.UIOption.OnlyErrorDialogs, FileIO.RecycleOption.DeletePermanently)
                                filename1 = (Application.StartupPath & "\" & Format(Now(), "yyyyMMdd_HHmmss") & "_" & tag & ".xml").Replace("\\", "\")
                                filename2 = (Application.StartupPath & "\" & Format(Now(), "yyyyMMdd_HHmmss") & "_" & tag & ".htm").Replace("\\", "\")
                            End If
                        End If
                    End If
                End If
                finfo = Nothing
            Next
            dinfo = Nothing


            Dim spanclass As String = ""
            Dim lastelement As String = ""

            If filename1.Length < 1 Then
                filename1 = (Application.StartupPath & "\" & Format(Now(), "yyyyMMdd_HHmmss") & "_" & tag & ".xml").Replace("\\", "\")
                downloadfeed = True
            End If
            If filename2.Length < 1 Then
                filename2 = (Application.StartupPath & "\" & Format(Now(), "yyyyMMdd_HHmmss") & "_" & tag & ".htm").Replace("\\", "\")
                downloadfeed = True
            End If

            If downloadfeed = True Then
                If My.Computer.FileSystem.FileExists((Application.StartupPath & "\Downloading.html").Replace("\\", "\")) Then
                    WebBrowser1.Navigate((Application.StartupPath & "\Downloading.html").Replace("\\", "\"))
                End If
                'My.Computer.Network.DownloadFile(feed, filename1, "", "", False, 100000, True)
                Dim WbReq As New Net.WebClient
                WbReq.Proxy.Credentials = System.Net.CredentialCache.DefaultCredentials
                WbReq.DownloadFile(New Uri(feed), filename1)
                WbReq.Dispose()

                If My.Computer.FileSystem.FileExists((Application.StartupPath & "\Loading.html").Replace("\\", "\")) Then
                    WebBrowser1.Navigate((Application.StartupPath & "\Loading.html").Replace("\\", "\"))
                End If
            End If




            If My.Computer.FileSystem.FileExists(filename1) Then
                Dim reader As New XmlTextReader(filename1)
                Dim contents As String = ""
                Dim contentsadjusted As Boolean = False
                While reader.Read()
                    reader.MoveToContent()
                    If reader.NodeType = XmlNodeType.Element Then
                        If reader.Name.ToLower = "channel" Then
                            contents &= "<p>"
                            lastelement = "channel"
                        End If
                        If reader.Name.ToLower = "item" Then
                            contents &= "</p><p>"
                            lastelement = "item"
                        End If
                        If reader.Name.ToLower = "image" Then
                            lastelement = "image"
                        End If
                        spanclass = lastelement & "_" & reader.Name
                    End If
                    contentsadjusted = False
                    If reader.NodeType = XmlNodeType.Text Or reader.NodeType = XmlNodeType.CDATA Then
                        If spanclass.ToLower.StartsWith("image_") = True Then
                            If spanclass.ToLower.StartsWith("image_url") = True Then
                                contents &= "<img src=""" & reader.Value & """ vspace=""6"">" & ControlChars.CrLf
                            End If
                            contentsadjusted = True
                        End If

                        If spanclass.ToLower.StartsWith("item_") = True And spanclass.ToLower.IndexOf("thumb") <> -1 Then
                            contents &= "<img src=""" & reader.Value & """ vspace=""6"">" & ControlChars.CrLf
                            contentsadjusted = True
                        End If

                        If spanclass.ToLower.StartsWith("item_link") = True Then
                            contents &= "<a target=""_blank"" href=""" & reader.Value & """>[Read More]</a><br/>" & ControlChars.CrLf
                            contentsadjusted = True
                        End If

                        If spanclass.ToLower.StartsWith("item_guid") = True Then
                            contents &= "<div name=""" & reader.Value & """></div>" & ControlChars.CrLf
                            contentsadjusted = True
                        End If

                        If contentsadjusted = False Then
                            contents &= "<span class=""" & spanclass.ToLower & """>" & reader.Value & "</span><br/>" & ControlChars.CrLf
                        End If

                    End If
                End While
                reader.Close()
                reader = Nothing
                Dim writer As StreamWriter
                writer = My.Computer.FileSystem.OpenTextFileWriter(filename2, False)
                writer.WriteLine("<html>")
                writer.WriteLine("<head>")
                writer.WriteLine("<title>")
                writer.WriteLine(feed)
                writer.WriteLine("</title>")
                writer.WriteLine("<link href=""" & (Application.StartupPath & "\").Replace("\\", "\") & "RSS Feed Display Stylesheet.css"" type=""text/css"" rel=""STYLESHEET"">")
                writer.WriteLine("</head>")
                writer.WriteLine("<body>")
                writer.WriteLine(contents)
                writer.WriteLine("</body>")
                writer.WriteLine("</html>")
                writer.Flush()
                writer.Close()
                writer.Dispose()
                writer = Nothing
                If My.Computer.FileSystem.FileExists(filename2) Then
                    WebBrowser1.Navigate(filename2)
                    If downloadfeed = True Then
                        StatusLabel.Text = "Fresh Feed successfully downloaded"
                    Else
                        StatusLabel.Text = "Feed successfully loaded from cache file"
                    End If
                End If


            End If
        Catch ex As Exception
            Error_Handler(ex, "Display Feed")
        End Try
    End Sub

    Private Sub ListBox1_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ListBox1.SelectedIndexChanged
        Try
            If ListBox1.SelectedIndex <> -1 Then

                If My.Computer.FileSystem.FileExists((Application.StartupPath & "\Loading.html").Replace("\\", "\")) Then
                    StatusLabel.Text = "Attempting to load feed..."
                    WebBrowser1.Navigate((Application.StartupPath & "\Loading.html").Replace("\\", "\"))
                End If
                BackgroundWorker1.RunWorkerAsync()
                '                DisplayFeed(ListBox1.Items.Item(ListBox1.SelectedIndex), ListBox1.SelectedIndex)



            End If
        Catch ex As Exception
            Error_Handler(ex, "Listbox Index Changed")
        End Try
    End Sub

    Private Sub SaveFeeds()
        Try
            StatusLabel.Text = "Saving feed list..."
            Dim filename As String = (Application.StartupPath & "\feeds.lst").Replace("\\", "\")
            Dim filename2 As String = (Application.StartupPath & "\feeds_backup.lst").Replace("\\", "\")
            If My.Computer.FileSystem.FileExists(filename2) Then
                My.Computer.FileSystem.DeleteFile(filename2, FileIO.UIOption.OnlyErrorDialogs, FileIO.RecycleOption.DeletePermanently)
            End If
            If My.Computer.FileSystem.FileExists(filename) Then
                My.Computer.FileSystem.CopyFile(filename, filename2)
            End If
            Dim filewriter As StreamWriter = New StreamWriter(filename, False, System.Text.Encoding.ASCII)
            For runner As Integer = 0 To ListBox2.Items.Count - 1
                filewriter.Write(ListBox2.Items.Item(runner) & "|")
                filewriter.Write(ListBox1.Items.Item(runner) & "|")
                filewriter.WriteLine(ListBox3.Items.Item(runner))
            Next
            filewriter.Flush()
            filewriter.Close()
            filewriter.Dispose()
            StatusLabel.Text = "Feed list successfully saved"
        Catch ex As Exception
            Error_Handler(ex, "Save Feeds")
        End Try
    End Sub


    Private Sub LoadFeeds()
        Try
            StatusLabel.Text = "Loading feed list..."
            Dim filename As String = (Application.StartupPath & "\feeds.lst").Replace("\\", "\")
            Dim feeds As ArrayList = New ArrayList()
            Dim lineread As String
            If My.Computer.FileSystem.FileExists(filename) Then
                Dim filereader As StreamReader = New StreamReader(filename)
                While filereader.Peek <> -1
                    lineread = filereader.ReadLine
                    If lineread.Length > 0 And lineread.IndexOf("|") <> -1 Then
                        feeds.Add(lineread)
                    End If
                End While
                filereader.Close()
                filereader.Dispose()
                feeds.Sort()
                ListBox1.Items.Clear()
                ListBox2.Items.Clear()
                ListBox3.Items.Clear()
                For Each value As String In feeds
                    ListBox2.Items.Add(value.Split("|")(0))
                    ListBox1.Items.Add(value.Split("|")(1))
                    ListBox3.Items.Add(value.Split("|")(2))
                    'MsgBox(value.Split("|")(0) & " - " & value.Split("|")(1) & " - " & value.Split("|")(2))
                Next

            End If
            feeds.Clear()
            feeds = Nothing
            StatusLabel.Text = "Feed list successfully loaded"
        Catch ex As Exception
            Error_Handler(ex, "Load Feeds")
        End Try
    End Sub

    Private Sub CleanDir()
        Try
            StatusLabel.Text = "Clearing cache files..."
            Dim dinfo As DirectoryInfo = New DirectoryInfo(Application.StartupPath)
            For Each finfo As FileInfo In dinfo.GetFiles
                If finfo.Name.Length > 15 Then
                    If IsNumeric(finfo.Name.Substring(0, 8)) Then
                        Dim yy, MM, dd, HH, mmm, ss As String
                        yy = finfo.Name.Substring(0, 4)
                        MM = finfo.Name.Substring(4, 2)
                        dd = finfo.Name.Substring(6, 2)
                        HH = finfo.Name.Substring(9, 2)
                        mmm = finfo.Name.Substring(11, 2)
                        ss = finfo.Name.Substring(13, 2)
                        Dim construct As Date = New Date(yy, MM, dd, HH, mmm, ss)
                        If DateDiff(DateInterval.Minute, construct, Now()) >= 30 Then
                            My.Computer.FileSystem.DeleteFile(finfo.FullName, FileIO.UIOption.OnlyErrorDialogs, FileIO.RecycleOption.DeletePermanently)
                        End If
                    End If
                End If
                finfo = Nothing
            Next
            dinfo = Nothing
            StatusLabel.Text = "Cache files successfully removed"
        Catch ex As Exception
            Error_Handler(ex, "Clean Cache")
        End Try
    End Sub

    Private Sub ForceCleanDir(Optional ByVal silent As Boolean = False)
        Try
            StatusLabel.Text = "Clearing cache files..."
            Dim dinfo As DirectoryInfo = New DirectoryInfo(Application.StartupPath)
            For Each finfo As FileInfo In dinfo.GetFiles
                If finfo.Name.Length > 15 Then
                    If IsNumeric(finfo.Name.Substring(0, 8)) Then
                        Dim yy, MM, dd, HH, mmm, ss As String
                        yy = finfo.Name.Substring(0, 4)
                        MM = finfo.Name.Substring(4, 2)
                        dd = finfo.Name.Substring(6, 2)
                        HH = finfo.Name.Substring(9, 2)
                        mmm = finfo.Name.Substring(11, 2)
                        ss = finfo.Name.Substring(13, 2)
                        Dim construct As Date = New Date(yy, MM, dd, HH, mmm, ss)
                        If DateDiff(DateInterval.Minute, construct, Now()) >= 0 Then
                            My.Computer.FileSystem.DeleteFile(finfo.FullName, FileIO.UIOption.OnlyErrorDialogs, FileIO.RecycleOption.DeletePermanently)
                        End If
                    End If
                End If
            Next
            StatusLabel.Text = "Cache files successfully removed"
            If silent = False Then
                MsgBox("RSS Cache Files Removed", MsgBoxStyle.Information, "RSS Raccoon Reader")
            End If
        Catch ex As Exception
            Error_Handler(ex, "Force Clean Cache")
        End Try
    End Sub

    Private Sub Form1_Close(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles MyBase.FormClosing
        Try
            StatusLabel.Text = "Closing application..."
            If savefilescheck = True Then
                SaveFeeds()
            End If
            CleanDir()
            If AutoUpdate = True Then
                If My.Computer.FileSystem.FileExists((Application.StartupPath & "\AutoUpdate.exe").Replace("\\", "\")) = True Then
                    Dim startinfo As ProcessStartInfo = New ProcessStartInfo
                    startinfo.FileName = (Application.StartupPath & "\AutoUpdate.exe").Replace("\\", "\")
                    startinfo.Arguments = "force"
                    startinfo.CreateNoWindow = False
                    Process.Start(startinfo)
                End If
            End If
        Catch ex As Exception
            Error_Handler(ex, "Application Close")
        End Try
    End Sub

    

    Private Sub Form1_Resize(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Resize
        Try
            SplitContainer1.SplitterDistance = recorded_distance
        Catch ex As Exception
            Error_Handler(ex, "Application Start")
        End Try
    End Sub

    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try
            StatusLabel.Text = "Loading application..."
            Control.CheckForIllegalCrossThreadCalls = False
            Me.Text = My.Application.Info.ProductName & " " & Format(My.Application.Info.Version.Major, "0000") & Format(My.Application.Info.Version.Minor, "00") & Format(My.Application.Info.Version.Build, "00") & "." & Format(My.Application.Info.Version.Revision, "00") & ""
            LoadFeeds()
            SplitContainer1.SplitterDistance = 232
            recorded_distance = SplitContainer1.SplitterDistance
            SplitContainer2.Panel2.Select()
            SplitContainer2.Panel2.Focus()
            WebBrowser1.Navigate((Application.StartupPath & "\LoadNothing.html").Replace("\\", "\"))
        Catch ex As Exception
            Error_Handler(ex, "Application Start")
        End Try
    End Sub

    Private Sub ListBox2_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ListBox2.SelectedIndexChanged
        Try
            If displayrest = False Then
                If ListBox2.SelectedIndex <> -1 And ListBox3.SelectedIndex <> ListBox2.SelectedIndex Then
                    lastindex = ListBox2.SelectedIndex
                    ListBox3.SelectedIndex = ListBox2.SelectedIndex
                    ListBox1.SelectedIndex = ListBox2.SelectedIndex
                    ListBox2.Enabled = False
                    MenuStrip1.Enabled = False
                End If
            End If

        Catch ex As Exception
            Error_Handler(ex, "Listbox Index Changed")
        End Try
    End Sub


    Private Sub ClearCacheToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ClearCacheToolStripMenuItem1.Click
        ForceCleanDir()
        displayrest = True
        'If ListBox2.Items.Count > 0 Then
        ListBox2.SelectedIndex = -1
        ListBox3.SelectedIndex = -1
        ListBox1.SelectedIndex = -1
        'End If
        WebBrowser1.Navigate((Application.StartupPath & "\LoadNothing.html").Replace("\\", "\"))
        displayrest = False
       
        ListBox2.SelectedIndex = lastindex
    End Sub


    Private Sub EditRSSFeedsToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles EditRSSFeedsToolStripMenuItem.Click
        Try
            StatusLabel.Text = "RSS Feed Edit prompted..."
            If MsgBox("To edit the RSS Feed List, Raccoon RSS Reader will automatically shut itself down. Is this okay?", MsgBoxStyle.OkCancel, "RSS Raccoon Reader") = MsgBoxResult.Ok Then
                Dim feeds As String = (Application.StartupPath & "\feeds.lst").Replace("\\", "\")
                If My.Computer.FileSystem.FileExists(feeds) Then
                    Process.Start(feeds)
                End If
                ForceCleanDir(True)
                savefilescheck = False
                Me.Close()
            End If
        Catch ex As Exception
            Error_Handler(ex, "Edit RSS Feeds")
        End Try
    End Sub


    Private Sub EditCSSStylesheetToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles EditCSSStylesheetToolStripMenuItem.Click
        Try
            StatusLabel.Text = "CSS Stylesheet Edit prompted..."
            Dim feeds As String = (Application.StartupPath & "\RSS Feed Display Stylesheet.css").Replace("\\", "\")
            If My.Computer.FileSystem.FileExists(feeds) Then
                Process.Start(feeds)
            End If
        Catch ex As Exception
            Error_Handler(ex, "Edit Stylesheet")
        End Try
    End Sub

    Private Sub BackgroundWorker1_DoWork(ByVal sender As System.Object, ByVal e As System.ComponentModel.DoWorkEventArgs) Handles BackgroundWorker1.DoWork
        Try
            'MsgBox("Doing Work")
            DisplayFeed(ListBox1.Items.Item(ListBox1.SelectedIndex), ListBox1.SelectedIndex)
        Catch ex As Exception
            Error_Handler(ex, "BackgroundWorker1_DoWork")
        End Try
    End Sub

    Private Sub BackgroundWorker1_RunWorkerCompleted(ByVal sender As Object, ByVal e As System.ComponentModel.RunWorkerCompletedEventArgs) Handles BackgroundWorker1.RunWorkerCompleted
        Try
            ListBox2.Enabled = True
            MenuStrip1.Enabled = True
        Catch ex As Exception
            Error_Handler(ex, "BackgroundWorker1_RunWorkerCompleted")
        End Try
    End Sub

    Private Sub HelpToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles HelpToolStripMenuItem.Click
        Try
            StatusLabel.Text = "Help dialog displayed"
            HelpBox1.ShowDialog()
        Catch ex As Exception
            Error_Handler(ex, "Display Help Screen")
        End Try
    End Sub

    Private Sub ExitToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ExitToolStripMenuItem.Click
        Me.Close()
    End Sub

    Private Sub ProxyUsernamePasswordToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ProxyUsernamePasswordToolStripMenuItem.Click
        Try
            Dim proxy As ProxyDetails = New ProxyDetails
            proxy.ShowDialog()
        Catch ex As Exception
            Error_Handler(ex, "Set Proxy Username and Password")
        End Try
    End Sub

    Private Sub AutoUpdateToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles AutoUpdateToolStripMenuItem.Click
        Try
            StatusLabel.Text = "AutoUpdate Requested"
            AutoUpdate = True
            Me.Close()
        Catch ex As Exception
            Error_Handler(ex, "AutoUpdate")
        End Try
    End Sub

    Private Sub AboutToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles AboutToolStripMenuItem1.Click
        Try
            StatusLabel.Text = "About dialog displayed"
            AboutBox1.ShowDialog()
        Catch ex As Exception
            Error_Handler(ex, "Display About Screen")
        End Try
    End Sub
End Class
