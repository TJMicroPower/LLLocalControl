using System;
using System.Data;
using System.Data.SqlClient;

namespace LocalControl
{
	/// <summary>
	/// ClassLocalControl 的摘要说明。
	/// </summary>
	public class ClassLocalControl
	{
		private string _connString = String.Empty;
		public ClassLocalControl()
		{
			//
			// TODO: 在此处添加构造函数逻辑
			//
		}

		public string ConnectString
		{
			set
			{
				this._connString = value;
			}
		}

		public SqlDataReader GetBottleCode(string command)
		{
			SqlDataReader result = null;
			try
			{
				PowerData.SqlDataOperator ps = new PowerData.SqlDataOperator(this._connString);
				result = ps.ExecuteReader(command);
			}
			catch
			{
			}
			return result;
		}

		public DataSet ExecuteDataSet(string command,string tableName)
		{
			DataSet result = null;
			try
			{
				PowerData.SqlDataOperator ps = new PowerData.SqlDataOperator(this._connString);
				result = ps.ExecuteDataSet(command,tableName);
			}
			catch
			{
			}
			return result;
		}

		public int WriteBindStr(string command)
		{
			int result = 0;
			try
			{
				PowerData.SqlDataOperator ps = new PowerData.SqlDataOperator(this._connString);
				result = ps.ExecuteNonQuery(command);
			}
			catch
			{
			}
			return result;
		}

		public int DeleteBottleCode(string command)
		{
			int result = 0;
			try
			{
				PowerData.SqlDataOperator ps = new PowerData.SqlDataOperator(this._connString);
				result = ps.ExecuteNonQuery(command);
			}
			catch
			{
			}
			return result;
		}
	}
}
