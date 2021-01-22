using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections;
using System.Windows.Forms;
using PowerData;
using System.Configuration;


namespace LocalControl
{
	/// <summary>
	/// CommonClass 的摘要说明。
	/// </summary>
	public class CommonClass
	{
        public static string _connstr = ConfigurationManager.AppSettings["sql_connstr"];
		public CommonClass()
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
				return result;
			}
			catch
			{
				
				return result;
			
			}
			
			
		}

		public static DataSet ExecuteDataSet(string processName,string tableName,SqlParameter[] sp)
		{
			DataSet result = null;
			try
			{
				PowerData.SqlDataOperator ps = new SqlDataOperator(_connstr);
				result = ps.ExecuteDataSet(processName,tableName,CommandType.StoredProcedure,sp);
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
		
		public static int ExcuteNonQuery(string processName,SqlParameter[] sp)
		{
			int result = 0;
			try
			{
				PowerData.SqlDataOperator ps = new SqlDataOperator(_connstr);
				result = ps.ExecuteNonQuery(processName,CommandType.StoredProcedure,sp);
			}
			catch(Exception e)
			{
				throw e;
			}
			return result;
		}
	
		public static SqlDataReader ExecuteReader(string command)
		{
			SqlDataReader result = null;
			try
			{
				PowerData.SqlDataOperator ps = new SqlDataOperator(_connstr);
				result = ps.ExecuteReader(command);
			}
			catch
			{
			}
			return result;
		}

		public static bool Exists(string command,string colName)
		{//command 必须是select count(*) 
			bool result = false;
			try
			{				
				SqlDataReader sdr = ExecuteReader(command);
				int cnt = 0;
				if(sdr.Read())
				{
					cnt = (int)sdr[colName];
				}
				sdr.Close();
				result = ((cnt==0)?false:true);
			}
			catch
			{
			}
			return result;
		}		
	}
}
