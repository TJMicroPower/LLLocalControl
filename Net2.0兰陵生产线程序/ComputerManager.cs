using System;
using System.ComponentModel;
using System.Collections;
using System.Diagnostics;
using System.Runtime.InteropServices;

namespace LocalControl
{
	/// <summary>
	/// ComputerManager ��ժҪ˵����
	/// </summary>
	public class ComputerManager : System.ComponentModel.Component
	{
		/// <summary>
		/// ����������������
		/// </summary>
		private System.ComponentModel.Container components = null;

		public ComputerManager(System.ComponentModel.IContainer container)
		{
			///
			/// Windows.Forms ��׫д�����֧���������
			///
			container.Add(this);
			InitializeComponent();

			//
			// TODO: �� InitializeComponent ���ú�����κι��캯������
			//
		}

		public ComputerManager()
		{
			///
			/// Windows.Forms ��׫д�����֧���������
			///
			InitializeComponent();

			//
			// TODO: �� InitializeComponent ���ú�����κι��캯������
			//
		}

		/// <summary> 
		/// ������������ʹ�õ���Դ��
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

		#region �����������ɵĴ���
		/// <summary>
		/// �����֧������ķ��� - ��Ҫʹ�ô���༭���޸�
		/// �˷��������ݡ�
		/// </summary>
		private void InitializeComponent()
		{
			components = new System.ComponentModel.Container();
		}
		#endregion
	}
}
