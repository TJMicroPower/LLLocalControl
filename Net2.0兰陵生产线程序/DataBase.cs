using System;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace LocalControl
{
	/// <summary>
	/// DataBase ��ժҪ˵����
	/// </summary>
	public class DataBase:IDisposable
	{
		public DataBase()
		{
			//
			// TODO: �ڴ˴���ӹ��캯���߼�
			//
		}
		private SqlConnection SqlConn;
		public static string sConn =  ConfigurationManager.AppSettings["sql_connstr"];
		public void Dispose()
		{
			Dispose(true);
			GC.SuppressFinalize(true);
		}
		protected void Dispose(bool disposing)
		{
			if(disposing)
			{
				return;
			}
			if(SqlConn!=null)
			{
				SqlConn.Dispose();
				SqlConn = null;
			}
		}
		public void Open()
		{
			if(SqlConn==null)
			{
				SqlConn = new SqlConnection(sConn);	
				SqlConn.Open();
			}
		}
		public void Close()
		{
			if(SqlConn!=null)
			{
				SqlConn.Close();
				SqlConn = null;
			}
		}
		/// <summary>
		/// ����DataSet
		/// </summary>
		/// <param name="cmdString"></param>
		/// <returns></returns>
		public DataSet RunDataSetSQL(string cmdString,string tableName)
		{
			DataSet SqlDS = new DataSet();
			try
			{
				this.Open();
				
				SqlDataAdapter SqlDA = new SqlDataAdapter(cmdString,this.SqlConn);
				SqlDA.Fill(SqlDS,tableName);
				string aa = SqlDS.Tables[tableName].TableName.ToString();
				return SqlDS;
			}
			catch
			{
				SqlDS.Clear();
				return SqlDS;
			}
			finally
			{
				this.Close();
                //this.Dispose();
			}
		}
		/// <summary>
		/// ����Ĭ�ϵı�����Ϊselect���
		/// </summary>
		/// <param name="sSQLString"></param>
		/// <returns></returns>
		public DataView RunSelectSQL(string sSQLString)
		{
			
			DataSet SqlDS = new DataSet();
			try
			{
				this.Open();
				SqlDataAdapter SqlDA = new SqlDataAdapter(sSQLString,this.SqlConn);
				SqlDA.Fill(SqlDS);
				return SqlDS.Tables[0].DefaultView;
			}
			catch
			{
				SqlDS.Clear();
				return SqlDS.Tables[0].DefaultView;
			}
			finally
			{
				this.Close();
                //this.Dispose();
			}
		}
		public void RunDelOrInsertOrUppdateSQL(string sSQLString)
		{
			try
			{
				this.Open();
				SqlCommand SqlComm = new SqlCommand(sSQLString,SqlConn);
				SqlComm.ExecuteNonQuery();
				
			}
			catch(Exception es)
			{
				string a = es.ToString();
				string b = a;
			}
			finally
			{
				this.Close();
                //this.Dispose();
			}
		}
		/// <summary>
		/// ִ��ExecuteScale()����
		/// </summary>
		/// <param name="selectStr"></param>
		/// <returns></returns>
		public int RunSelectCountSQL(string selectStr)
		{
			int count = 0;
			try
			{
				this.Open();
				SqlCommand cmd = new SqlCommand(selectStr,SqlConn);
				count = int.Parse(cmd.ExecuteScalar().ToString());
				return count;
			}
			catch
			{
				return count;
			}
			finally
			{
				this.Close();
                //this.Dispose();
			}
		}
		/// <summary>
		/// ����ѡ��Ľ������ExecuteScalar��������
		/// </summary>
		/// <param name="selectStr"></param>
		/// <returns></returns>
		public string RunSelectResultsSQL(string selectStr)
		{
			string results = "";
			try
			{
				this.Open();
				SqlCommand SqlComm = new SqlCommand(selectStr,SqlConn);
				results = SqlComm.ExecuteScalar().ToString();
				return results;
			}
			catch(Exception es)
			{
				string a = es.ToString();
				return results;
			}
			finally
			{
				this.Close();
                //this.Dispose();
			}
		}
	}
}
