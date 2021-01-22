using System;
using System.Collections;
using System.Threading;

namespace ComWithImaje
{
	/// <summary>
	/// BindQueue ��ժҪ˵����
	/// </summary>
	public class BindQueue
	{
		int _countPerBox = 0;
		Queue _locQueue = new Queue();	
		string _box = String.Empty;
		public BindQueue(int cnt)
		{
			this._countPerBox = cnt;
			//_locQueue.Enqueue(bCode);
		}	
	
		public string NewBottle
		{
			set
			{
				string str = value;
				if(str.Length==0)
					str = "0000000000000000";
				else
				{
					Monitor.Enter(this._locQueue);
					try
					{						
						this._locQueue.Enqueue(str);
					}
					catch
					{
					}
					finally
					{
						Monitor.Exit(this._locQueue);
					}
				}
			}
		}
		public string NewBox
		{
			set
			{
				this._box = value;
			}
		}
        /// <summary>
        /// ����������������������ڵ����趨��ÿ�������ƿ��������������ƿ��������������ذ�ֵ
        /// </summary>
		public string BindData
		{
			get
			{
				string str = "";
				Monitor.Enter(this._locQueue);
				try
				{
					if(this._countPerBox>0)
					{
                        if (this._locQueue.Count >= this._countPerBox)//this._countPerBox��ÿ��ĺ�����
						{					
							for(int i=0;i<this._countPerBox;i++)
							{
								str += this._locQueue.Dequeue().ToString()+",";
							}
							str = this._box+"#"+str;					
						}
						else
							str = "null";
					}
					else
						str = "null";
				}
				catch
				{
				}
				finally
				{
					Monitor.Exit(this._locQueue);
				}
				return str;
			}
		}

		public void Clear()
		{
			this._locQueue.Clear();
			this._box = String.Empty;
			//this._countPerBox = 0;
		}

	}
}
