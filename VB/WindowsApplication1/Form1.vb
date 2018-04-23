Imports Microsoft.VisualBasic
Imports System
Imports System.Collections.Generic
Imports System.ComponentModel
Imports System.Data
Imports System.Drawing
Imports System.Text
Imports System.Windows.Forms

Namespace WindowsApplication1
	Partial Public Class Form1
		Inherits Form
		Private Function CreateTable(ByVal RowCount As Integer) As DataTable
			Dim tbl As New DataTable()
			tbl.Columns.Add("Name", GetType(String))
			tbl.Columns.Add("ID", GetType(Integer))
			tbl.Columns.Add("Number", GetType(Integer))
			tbl.Columns.Add("Date", GetType(DateTime))
			tbl.Columns.Add("ParentID", GetType(Integer))
			For i As Integer = 0 To RowCount - 1
				tbl.Rows.Add(New Object() { String.Format("Name{0}", i), i + 1, 3 - i, DateTime.Now.AddDays(i), i Mod 3 })
			Next i
			Return tbl
		End Function


		Public Sub New()
			InitializeComponent()
			treeList1.DataSource = CreateTable(30)
		End Sub

		Private isChecked As Boolean

		Private Function CanCheckNode() As Boolean
			Return Not isChecked
		End Function

		Private Sub treeList1_BeforeCheckNode(ByVal sender As Object, ByVal e As DevExpress.XtraTreeList.CheckNodeEventArgs) Handles treeList1.BeforeCheckNode
			e.CanCheck = e.State = CheckState.Unchecked OrElse CanCheckNode()
		End Sub

		Private Sub treeList1_AfterCheckNode(ByVal sender As Object, ByVal e As DevExpress.XtraTreeList.NodeEventArgs) Handles treeList1.AfterCheckNode
			isChecked = e.Node.Checked
		End Sub

		Private Sub treeList1_CustomDrawNodeCheckBox(ByVal sender As Object, ByVal e As DevExpress.XtraTreeList.CustomDrawNodeCheckBoxEventArgs) Handles treeList1.CustomDrawNodeCheckBox
			If e.Node.Checked OrElse CanCheckNode() Then
				Return
			End If
			e.ObjectArgs.State = DevExpress.Utils.Drawing.ObjectState.Disabled
		End Sub
	End Class
End Namespace