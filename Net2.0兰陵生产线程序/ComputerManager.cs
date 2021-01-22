using System;
using System.ComponentModel;
using System.Collections;
using System.Diagnostics;
using System.Runtime.InteropServices;

namespace LocalControl
{
	/// <summary>
	/// ComputerManager 的摘要说明。
	/// </summary>
	public class ComputerManager : System.ComponentModel.Component
	{
		/// <summary>
		/// 必需的设计器变量。
		/// </summary>
		private System.ComponentModel.Container components = null;

		public ComputerManager(System.ComponentModel.IContainer container)
		{
			///
			/// Windows.Forms 类撰写设计器支持所必需的
			///
			container.Add(this);
			InitializeComponent();

			//
			// TODO: 在 InitializeComponent 调用后添加任何构造函数代码
			//
		}

		public ComputerManager()
		{
			///
			/// Windows.Forms 类撰写设计器支持所必需的
			///
			InitializeComponent();

			//
			// TODO: 在 InitializeComponent 调用后添加任何构造函数代码
			//
		}

		/// <summary> 
		/// 清理所有正在使用的资源。
		/// </summary>
		protected override void Dispose( bool disposing )
		{
			if( disposing )
			{
				if(components != null)
				{
					components.Dispose();
				}
			}
			base.Dispose( disposing );
		}

		
		
		[StructLayout(LayoutKind.Sequential,   Pack=1)]   
			internal   struct   TokPriv1Luid   
		{   
			public   int   Count;   
			public   long   Luid;   
			public   int   Attr;   
		}   
    
		[DllImport("kernel32.dll",   ExactSpelling=true)   ]   
		internal   static   extern   IntPtr   GetCurrentProcess();   
    
		[DllImport("advapi32.dll",   ExactSpelling=true,   SetLastError=true)   ]   
		internal   static   extern   bool   OpenProcessToken(   IntPtr   h,   int   acc,   ref   IntPtr   phtok   );   
    
		[DllImport("advapi32.dll",   SetLastError=true)   ]   
		internal   static   extern   bool   LookupPrivilegeValue(   string   host,   string   name,   ref   long   pluid   );   
    
		[DllImport("advapi32.dll",   ExactSpelling=true,   SetLastError=true)   ]   
		internal   static   extern   bool   AdjustTokenPrivileges(   IntPtr   htok,   bool   disall,   
			ref   TokPriv1Luid   newst,   int   len,   IntPtr   prev,   IntPtr   relen   );   
    
		[DllImport("user32.dll",   ExactSpelling=true,   SetLastError=true)   ]   
		internal   static   extern   bool   ExitWindowsEx(   int   DoFlag,   int   rea   );   
    
		internal   const   int   SE_PRIVILEGE_ENABLED   =   0x00000002;   
		internal   const   int   TOKEN_QUERY   =   0x00000008;   
		internal   const   int   TOKEN_ADJUST_PRIVILEGES   =   0x00000020;   
		internal   const   string   SE_SHUTDOWN_NAME   =   "SeShutdownPrivilege";   
		internal   const   int   EWX_LOGOFF   =   0x00000000;   
		internal   const   int   EWX_SHUTDOWN   =   0x00000001;   
		internal   const   int   EWX_REBOOT   =   0x00000002;   
		internal   const   int   EWX_FORCE   =   0x00000004;   
		internal   const   int   EWX_POWEROFF   =   0x00000008;   
		internal   const   int   EWX_FORCEIFHUNG   =   0x00000010;   
    
		private   static   void   DoExitWin(   int   DoFlag   )   
		{   
			bool   ok;   
			TokPriv1Luid   tp;   
			IntPtr   hproc   =   GetCurrentProcess();   
			IntPtr   htok   =   IntPtr.Zero;   
			ok   =   OpenProcessToken(   hproc,   TOKEN_ADJUST_PRIVILEGES   |   TOKEN_QUERY,   ref   htok   );   
			tp.Count   =   1;   
			tp.Luid   =   0;   
			tp.Attr   =   SE_PRIVILEGE_ENABLED;   
			ok   =   LookupPrivilegeValue(   null,   SE_SHUTDOWN_NAME,   ref   tp.Luid   );   
			ok   =   AdjustTokenPrivileges(   htok,   false,   ref   tp,   0,   IntPtr.Zero,   IntPtr.Zero   );   
			ok   =   ExitWindowsEx(   DoFlag,   0   );   
		}   
    
		public   static   void   Reboot()   
		{   
			DoExitWin(     EWX_FORCE   |   EWX_REBOOT   );   
		}   
    
		public   static   void   PowerOff()   
		{   
			DoExitWin(       EWX_FORCE   |   EWX_POWEROFF   );   
		}   
    
		public   static   void   LogoOff()   
		{   
			DoExitWin   (     EWX_FORCE   |   EWX_LOGOFF   );   
		}   

		#region 组件设计器生成的代码
		/// <summary>
		/// 设计器支持所需的方法 - 不要使用代码编辑器修改
		/// 此方法的内容。
		/// </summary>
		private void InitializeComponent()
		{
			components = new System.ComponentModel.Container();
		}
		#endregion
	}
}
