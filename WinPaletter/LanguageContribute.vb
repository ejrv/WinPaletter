﻿Public Class LanguageContribute
    Private Sub XenonButton1_Click(sender As Object, e As EventArgs) Handles XenonButton1.Click
        Me.Close()
    End Sub

    Private Sub XenonButton2_Click(sender As Object, e As EventArgs) Handles XenonButton2.Click, XenonButton4.Click
        Process.Start(My.Resources.Link_Telegram)
    End Sub

    Private Sub XenonButton3_Click(sender As Object, e As EventArgs) Handles XenonButton3.Click
        Process.Start(My.Resources.Link_Repository)
    End Sub
End Class