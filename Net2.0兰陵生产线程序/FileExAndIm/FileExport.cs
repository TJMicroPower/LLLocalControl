using System;
using System.Data;
using System.Threading;
using System.Collections;
using System.IO;
namespace FileExAndIm
{
	/// <summary>
	/// FileExport 的摘要说明。
	/// </summary>
	public class FileExport
	{
		private int _countPerFile = 0;
		private string _machineID = String.Empty;
		private string _filePath = String.Empty;
//		private string _boxColumn = String.Empty;
//		private string _pingColumn = String.Empty;
		private Queue _hsColumn = null;		
		private string _tableName = String.Empty;
		private string _spliteChar = String.Empty;
		private DataSet _ds = null;
		private bool _finished = false;
		private Queue _fileQueue = new Queue();
		public FileExport(string machine_id,int cnt,string fPath)
		{
			this._countPerFile = cnt;
			this._filePath = fPath;
			this._machineID = machine_id;
		}
//		public string SetBoxColumn
//		{
//			set
//			{
//				this._boxColumn = value;
//			}
//		}
//		public string SetPingColumn
//		{
//			set
//			{
//				this._pingColumn = value;
//			}
//		}

		public Queue SetColumn
		{
			set
			{
				this._hsColumn = value;				
			}
		}

		public string SetTableName
		{
			set
			{
				this._tableName = value;
			}
		}

		public string SetSpliteChar
		{
			set
			{
				this._spliteChar = value;
			}
		}
			

			public DataSet SetDataSet
		{
			set
			{
				if(this._ds!=null)
					this._ds.Clear();
				this._ds = value;
			}
		}

		public bool GetExportStatus
		{
			get
			{
				return this._finished;
			}
		}
		public Queue GetFileQueue
		{
			get
			{
				return this._fileQueue;
			}
		}

		private string GetFileName()
		{
			string result = "";
			result = this._filePath+@"\"+this._machineID+DateTime.Now.ToString("yyMMddHHmmss")+".txt";
			return result;
		}

		public void ExportData()
		{
			try
			{
				DataTable dt = this._ds.Tables[this._tableName];
				this._fileQueue.Clear();
				if(dt.Rows.Count>0)
				{
					string locFName = "";
					StreamWriter sw = null;
					try
					{
						for(int i=0;i<dt.Rows.Count;i++)
						{
							if(i%this._countPerFile==0)
							{
								Thread.Sleep(1000);
								if(sw!=null)
									sw.Close();
								locFName = GetFileName();
								if(File.Exists(locFName))
									File.Delete(locFName);
								sw = new StreamWriter(locFName,true);							
								this._fileQueue.Enqueue(locFName);
							}
							string writeStr = String.Empty;
							object[] objArr = this._hsColumn.ToArray();
							for(int j=0;j<objArr.Length;j++)
							{
								string colName = objArr[j].ToString();
								if(dt.Rows[i][colName]!=null)
								{
									writeStr = writeStr+dt.Rows[i][colName].ToString()+this._spliteChar;
								}
							}
//							foreach(object obj in this._hsColumn.Keys)
//							{
//								string colName = _hsColumn[obj].ToString();
//								if(dt.Rows[i][colName]!=null)
//								{
//									writeStr = writeStr+dt.Rows[i][colName].ToString()+this._spliteChar;
//								}								
//							}
							if(this._spliteChar.Length>0)
							{
								writeStr = writeStr.Substring(0,writeStr.Length-1);//减1的目的是将最后的
							}
							sw.WriteLine(writeStr);
						}						
					}
					catch
					{						
						this._fileQueue.Clear();
						this._ds.Clear();
					}
					finally
					{
						if(sw!=null)
							sw.Close();
					}
				}
				else
				{
					this._fileQueue.Clear();					
				}
			}
			catch
			{
				this._fileQueue.Clear();
				this._ds.Clear();
			}
			this._finished = true;
		}

	}
}
