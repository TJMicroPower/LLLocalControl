using System;
using System.Collections.Generic;
//using System.Linq;
using System.Text;
using System.Runtime.InteropServices;

namespace EncryptionAndDecryption
{
    public class Class1
    {
        //声明要使用Rockey1 API接口
        //函数的返回值声明成int
        [DllImport("Rockey1S.dll",CharSet=CharSet.Unicode)]
        public static extern int R1_Find(byte[] pid, ref long dwCount);
        [DllImport("Rockey1S.dll")]
        public static extern int R1_Open(ref IntPtr handle, byte[] pid, int nIndex);
        [DllImport("Rockey1S.dll")]
        public static extern int R1_Close(IntPtr handle);
        [DllImport("Rockey1S.dll")]
        public static extern int R1_GetVersion(IntPtr handle, ref byte bVersionMajor, ref byte bVersionMinor);
        [DllImport("Rockey1S.dll")]
        public static extern int R1_GetHID(IntPtr handle, byte[] hid);
        [DllImport("Rockey1S.dll")]
        public static extern int R1_VerifyUserPin(IntPtr handle, byte[] pin, ref byte tryCount);
        [DllImport("Rockey1S.dll")]
        public static extern int R1_VerifySoPin(IntPtr handle, byte[] pin, ref byte tryCount);
        [DllImport("Rockey1S.dll")]
        public static extern int R1_GenRandom(IntPtr handle, byte[] buffer);
        [DllImport("Rockey1S.dll")]
        public static extern int R1_Read(IntPtr handle, short wOffset, short wLength, byte[] buf, ref short len, byte bType);
        [DllImport("Rockey1S.dll")]
        public static extern int R1_Write(IntPtr handle, short wOffset, short wLength, byte[] buf, ref short len, byte bType);
        [DllImport("Rockey1S.dll")]
        public static extern int R1_GenRSAKey(IntPtr handle, byte bFlag, byte id, string pubkey, string prikey);
        [DllImport("Rockey1S.dll")]
        public static extern int R1_SetRSAKey(IntPtr handle, byte bFlag, byte id, string pubkey, string prikey);
        [DllImport("Rockey1S.dll")]
        public static extern int R1_RSAEnc(IntPtr handle, byte bFlag, byte id, byte[] bBuf, int dwLen);
        [DllImport("Rockey1S.dll")]
        public static extern int R1_RSADec(IntPtr handle, byte bFlag, byte id, byte[] bBuf, int dwLen);
        [DllImport("Rockey1S.dll")]
        public static extern int R1_SetTDesKey(IntPtr handle, byte id, byte[] buf);
        [DllImport("Rockey1S.dll")]
        public static extern int R1_TDesEnc(IntPtr handle, byte id, byte[] buf, int dwLen);
        [DllImport("Rockey1S.dll")]
        public static extern int R1_TDesDec(IntPtr handle, byte id, byte[] buf, int dwLen);
        //DWORD WINAPI R1_LEDControl(HANDLE handle,BYTE bFlag);
        [DllImport("Rockey1S.dll")]
        public static extern int R1_LEDControl(IntPtr handle, byte bFlag);
        public string ResultOfEandD()
        {
            string result = string.Empty;
            long dwCount = 0;
            IntPtr handle = IntPtr.Zero;
            byte[] buffer = new byte[16];

            if (R1_Find(null, ref dwCount) == 0)
            {
                //打开Rockey1
                if (R1_Open(ref handle, null, 0) == 0)
                {
                    //验证UserPin
                    byte[] pin = new byte[10] { (byte)'M', (byte)'i', (byte)'c', (byte)'r', (byte)'o', (byte)'P', (byte)'o', (byte)'w', (byte)'e', (byte)'r' };
                    byte tryCount = 0;

                    if (R1_VerifyUserPin(handle, pin, ref tryCount) == 0)
                    {
                        //读取数据
                        short len = 0;
                        if (R1_Read(handle, 0, 16, buffer, ref len, (byte)1) == 0)
                        {
                            string s = string.Empty;
                            for (int i = 0; i < 16; i++)
                            {
                                s = s + buffer[i].ToString("X");
                            }
                            result = s;
                        }
                    }
                }
            }
            return result;
        }
    }
}