using System;
using System.Windows.Forms;
using System.Collections;
using System.Data;
using System.Data.SqlClient;
using MyComponent;
using PowerData;
namespace LocalControl
{
	/// <summary>
	/// ListViewOperator 的摘要说明。
	/// </summary>
	public class ListViewOperator
	{
		public static string _connStr = String.Empty;
		public ListViewOperator()
		{
			//
			// TODO: 在此处添加构造函数逻辑
			//
		}

		private static void AddNewItem(ref CListView listView,Queue myQueue)
		{
			listView.NewItem = myQueue;
		}

		public static void GetViewList(ref CListView listView,string command,CommandType type,Hashtable ht)
		{
			listView.Command = command;			
			listView.Type = type;
			PowerData.ConnectionManager.CreateInstance().ConnectionString = _connStr;
			listView.Connection = PowerData.ConnectionManager.CreateInstance().GetConnection();
			listView.Params = ht;
			listView.GetList();
		}
		
		public static void AddOneRow(ref CListView listView,Queue myQueue)
		{			
			AddNewItem(ref listView,myQueue);
		}

		public static void DeleteOneRow(ref CListView listView)
		{
			listView.SelectedItems[0].Remove();
		}
	}
}
