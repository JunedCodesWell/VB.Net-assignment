Public Class Form1
    Private Sub BtnCustomer_Click(sender As Object, e As EventArgs) Handles BtnCustomer.Click

        Dim c1 As New Customer

        c1.firstname = txtFirstName.Text
        c1.lastname = txtLastName.Text
        'c1.DOB = CDate(txtDOB.Text)
        c1.weight = CInt(txtWeight.Text)
        c1.purchase = txtPurchase.Text
        c1.address = txtAddress.Text


        MsgBox("Name: " & c1.firstname & " " & c1.lastname & vbCrLf &
               "Body Weight: " & c1.weight & vbCrLf &
               "Purchased Items: " & c1.purchase & vbCrLf &
               "Address: " & c1.address)



    End Sub
    '"DOB: " & c1.DOB & vbCrLf &

End Class


Public Class Customer

    Public firstname As String
    Public lastname As String
    Public DOB As Date
    Public address As String
    Public purchase As String
    Public weight As Integer

End Class