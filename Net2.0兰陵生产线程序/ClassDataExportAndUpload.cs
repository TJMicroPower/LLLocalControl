using System;
using System.Data;
using System.Data.SqlClient;
using ComWithImaje;
using PowerData;
using FileExAndIm;

namespace LocalControl
{
	/// <summary>
	/// ClassDataExportAndUpload 的摘要说明。
	/// </summary>
	public class ClassDataExportAndUpload
	{
		public static string _connstr = String.Empty;
		public ClassDataExportAndUpload()
		{
			//
			// TODO: 在此处添加构造函数逻辑
			//
		}

		public static DataSet ExecuteDataSet(string command,string tableName)
		{
			DataSet result = null;
			try
			{
				PowerData.SqlDataOperator ps = new SqlDataOperator(_connstr);
				result = ps.ExecuteDataSet(command,tableName);
			}
			catch
			{

			}
			return result;
		}
		public static int ExcuteNonQuery(string command)
		{
			int result = 0;
			try
			{
				PowerData.SqlDataOperator ps = new SqlDataOperator(_connstr);
				result = ps.ExecuteNonQuery(command);
			}
			catch
			{
			}
			return result;
		}	
		
	}
}
