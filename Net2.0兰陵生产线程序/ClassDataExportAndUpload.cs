using System;
using System.Data;
using System.Data.SqlClient;
using ComWithImaje;
using PowerData;
using FileExAndIm;

namespace LocalControl
{
	/// <summary>
	/// ClassDataExportAndUpload ��ժҪ˵����
	/// </summary>
	public class ClassDataExportAndUpload
	{
		public static string _connstr = String.Empty;
		public ClassDataExportAndUpload()
		{
			//
			// TODO: �ڴ˴���ӹ��캯���߼�
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
