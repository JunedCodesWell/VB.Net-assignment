Public Class Form1

    Private Sub Customer_tableBindingNavigatorSaveItem_Click(sender As Object, e As EventArgs) Handles Customer_tableBindingNavigatorSaveItem.Click
        Me.Validate()
        Me.Customer_tableBindingSource.EndEdit()
        Me.TableAdapterManager.UpdateAll(Me.Cr_ds)

    End Sub

    Private Sub CustomerFrm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'TODO: This line of code loads data into the 'Cr_ds.customer_table' table. You can move, or remove it, as needed.
        Me.Customer_tableTableAdapter.Fill_all(Me.Cr_ds.customer_table)
        Me.GroupBox1.Enabled = False

        'Disable Save & Cancel button
        Me.Save_btn.Enabled = False
        Me.Cancel_btn.Enabled = False

    End Sub

    Private Sub EnableAddNewEditDel_btn()
        'Disable AddNew, Edit, Delete button

        Me.AddNew_btn.Enabled = False
        Me.Edit_btn.Enabled = False
        Me.Delete_btn.Enabled = False

        'Enable Save And Cancel Button

        Me.Save_btn.Enabled = True
        Me.Cancel_btn.Enabled = True

        'Enable groupBox1
        Me.GroupBox1.Enabled = True
        Me.Customer_tableDataGridView.Enabled = False
    End Sub

    Private Sub DisableSaveCancel_btn()
        'Disable Save & Cancel Button

        Me.Save_btn.Enabled = False
        Me.Cancel_btn.Enabled = False

        'Enable AddNew, Edit, Delete button

        Me.AddNew_btn.Enabled = True
        Me.Edit_btn.Enabled = True
        Me.Delete_btn.Enabled = True

        'Disable groupbox1
        Me.GroupBox1.Enabled = False
        Me.Customer_tableDataGridView.Enabled = True
    End Sub

    Private Sub AddNew_btn_Click(sender As Object, e As EventArgs) Handles AddNew_btn.Click

        EnableAddNewEditDel_btn()

        'AddNew botton code
        Me.Customer_tableBindingSource.AddNew()

    End Sub

    Private Sub Edit_btn_Click(sender As Object, e As EventArgs) Handles Edit_btn.Click
        Dim rc As Integer
        rc = Me.Cr_ds.customer_table.Rows.Count

        If rc = 0 Then
            MessageBox.Show("please select your record to edit..")
            Exit Sub
        End If

        EnableAddNewEditDel_btn()

    End Sub

    Private Sub Delete_btn_Click(sender As Object, e As EventArgs) Handles Delete_btn.Click

        Dim rc As Integer
        rc = Me.Cr_ds.customer_table.Rows.Count

        If rc = 0 Then
            MessageBox.Show("please select your record to delete..")
            Exit Sub
        End If

        EnableAddNewEditDel_btn()

        'delete record code
        Me.Customer_tableBindingSource.RemoveCurrent()
        Me.GroupBox1.Enabled = False

    End Sub

    Private Sub Save_btn_Click(sender As Object, e As EventArgs) Handles Save_btn.Click

        Dim n As Integer

        DisableSaveCancel_btn()

        'Save in SQL DataBase
        Me.Customer_tableBindingSource.EndEdit()
        n = Me.Customer_tableTableAdapter.Update(Me.Cr_ds.customer_table)

        If n > 0 Then
            MessageBox.Show("Saved")
        Else
            MessageBox.Show("Not Saved")
        End If

    End Sub

    Private Sub Cancel_btn_Click(sender As Object, e As EventArgs) Handles Cancel_btn.Click

        DisableSaveCancel_btn()

        'cancel button code
        Me.Cr_ds.customer_table.RejectChanges()
        Me.Customer_tableBindingSource.CancelEdit()

    End Sub


End Class
