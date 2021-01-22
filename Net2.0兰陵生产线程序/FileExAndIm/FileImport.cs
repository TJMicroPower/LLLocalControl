using System;
using System.Data;
using System.Threading;
using System.Collections;
using System.IO;
using PowerData;

namespace FileExAndIm
{
	/// <summary>
	/// FileImport 的摘要说明。
	/// </summary>
	public class FileImport
	{
		/// <summary>
		/// 该类对数据表字段的导入，字段的类型必须是varchar型
		/// </summary>
		#region 类变量
		private Queue _columnQueue = null;
		private Queue _errorQueue = new Queue();
		private string _fName = String.Empty;
		private string _tableName = String.Empty;
		private string _connStr = String.Empty;
		private char _splitchar = '0';
		#endregion

		#region 构造函数

		public FileImport(String connstr)
		{		
			this._connStr = connstr;
			//PowerData.ConnectionManager.CreateInstance().ConnectionString = connstr;
		}
		#endregion

		#region 属性列表
		public Queue Column
		{
			set
			{
				this._columnQueue = value;
			}
		}

		public Queue ErrorList
		{
			get
			{
				return this._errorQueue;
			}
		}

		public string FName
		{
			set
			{
				this._fName = value;
			}
		}
		public string TableName
		{
			set
			{
				this._tableName = value;
			}
		}
		public char SplitChar
		{
			set
			{
				this._splitchar = value;
			}
		}
		#endregion

		#region ExecuteNonQuery
		private int ExecuteNonQuery(string command)
		{
			int result = 0;
			try
			{
				PowerData.SqlDataOperator ps = new SqlDataOperator(this._connStr);
				result = ps.ExecuteNonQuery(command);
			}
			catch
			{
			}
			return result;
		}
		#endregion

		#region 向数据库内写入数据

		public void WriteInfoToDB()
		{
			this._errorQueue.Clear();
			try
			{
				if(File.Exists(this._fName))
				{
					StreamReader sr = new StreamReader(this._fName);
					while(sr.Peek()>-1)
					{
						string strInfo = sr.ReadLine();
						string[] strArr = strInfo.Split(new char[]{this._splitchar});
						object[] objArr = this._columnQueue.ToArray();
						string tmpCommand = "";
						for(int i=0;i<objArr.Length;i++)
						{
							tmpCommand = tmpCommand+objArr[i].ToString().Trim()+",";
						}
						tmpCommand = tmpCommand.Substring(0,tmpCommand.Length-1);
						string locCommand = "";
						for(int j=0;j<strArr.Length;j++)
						{
							locCommand = locCommand+"'"+strArr[j]+"',";
						}
						locCommand = locCommand.Substring(0,locCommand.Length-1);
						string command = "insert into "+this._tableName+"("+tmpCommand+")"+" values("+locCommand+")";
						ExecuteNonQuery(command);
					}
					sr.Close();
				}

			}
			catch(Exception ex)
			{
				this._errorQueue.Enqueue(ex.ToString());
			}
		}
		#endregion

	}
}
