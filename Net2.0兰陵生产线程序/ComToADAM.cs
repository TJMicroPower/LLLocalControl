using System;
using System.Text;
using System.IO.Ports;
namespace ComWithImaje
{
	/// <summary>
	/// ComToADAM 的摘要说明。
	/// </summary>
	public class ComToADAM
	{
        //private SerialStream _sCom = null;
        SerialPort _serialPortAdam;
		string _adamAddr = "";
		public ComToADAM(SerialPort serialPortAdam,string addr)
		{
            _serialPortAdam = serialPortAdam;
            this._adamAddr = addr;
		}
		/// <summary>
		/// 获取各输入通道的状态
		/// </summary>

		public string DataInState
		{
			get
			{
				byte[] by = this.ComReceive();
				string str = "";
				str = System.Text.Encoding.ASCII.GetString(by,0,by.Length-1);//-1的目的是将\r去掉
				if(str.Length>0)
				{
					if(str[0]=='!')
						return str.Substring(3,2);
					else
						return str;
				}
				else
					return str;
			}
		}

		/// <summary>
		/// 返回输出状态是否正确
		/// </summary>

		public bool DataOutState
		{
			get
			{				
				string str = "";
				try
				{
					byte[] by = this.ComReceive();
					str = System.Text.Encoding.ASCII.GetString(by,0,by.Length);//-1的目的是将\r去掉
				}
				catch
				{
				}
				if(str.Length>0)
				{
					if(str[0]=='>')
						return true;
					else
						return false;
				}
				else
					return false;
			}
		}
		/// <summary>
		/// 初始化ADSM4055
		/// </summary>
		/// <returns>是否成功标志</returns>
		public bool InitADAM4055()
		{
			bool result = false;
			try
			{
                _serialPortAdam.Open();
				result = true;
			}
			catch
			{
			}
			return result;
		}

		public bool WriteDataInCommand()
		{
			bool result = false;
			try
			{
				string cmd = "$"+this._adamAddr+"6\r";
				byte[] by_cmd = System.Text.Encoding.ASCII.GetBytes(cmd);
				this.ComSend(by_cmd,0,by_cmd.Length);
				result = true;
			}
			catch
			{
				result = false;
			}
			return result;
		}

		public bool WriteDataOutCommand(string channel,string voltagelevel)
		{
			bool result = false;
			try
			{
				string cmd = "#"+this._adamAddr+"1"+channel+"0"+voltagelevel+"\r";
				byte[] by_cmd = System.Text.Encoding.ASCII.GetBytes(cmd);
				this.ComSend(by_cmd,0,by_cmd.Length);
				result = true;
			}
			catch
			{
				result = false;
			}
			return result;
		}

		public void Close()
		{
            if (this._serialPortAdam != null)
                this._serialPortAdam.Close();
		}

		private bool ComSend(byte[] by,int start,int len)
		{
			bool result = false;
			try
			{
                //_sCom.Write(by,start,len);
                _serialPortAdam.Write(by, start, len);
               //_sCom.Flush();
				result = true;
			}
			catch
			{
			}
			return result;
		}

		private byte[] ComReceive()
		{			
			byte[] result = new byte[1024];
			try
			{
				int locReaded = 0;
				do
				{
                    int locRecCnt = _serialPortAdam.Read(result, locReaded, result.Length - locReaded);
					locReaded += locRecCnt;
				}
                while(result[locReaded-1]!=13);
			}
			catch
			{
			}
			return result;
		}


	}
}
