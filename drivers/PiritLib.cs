﻿using System;
using System.Runtime.InteropServices;

namespace DvizhSeller.drivers
{
    public class PiritLib
    {
        [StructLayout(LayoutKind.Sequential)]
        public unsafe struct MData
        {
            public int errCode;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 256)]
            public byte[] data;
            public int dataLength;
        }

        //openPort
        [DllImport("PiritLib.dll", CallingConvention = CallingConvention.StdCall)]
        public static extern int openPort(string fileName, int speed);

        //commandStart
        [DllImport("PiritLib.dll", CharSet = CharSet.Auto, CallingConvention = CallingConvention.StdCall)]
        public static extern int commandStart();

        [DllImport("PiritLib.dll", CharSet = CharSet.Auto, CallingConvention = CallingConvention.StdCall)]
        public static extern int libAddDiscount(byte typeDiscount, string nameDiscount, long sum);

        //libSubTotal
        [DllImport("PiritLib.dll", CharSet = CharSet.Auto, CallingConvention = CallingConvention.StdCall)]
        public static extern int libSubTotal();

        //scrollPaper
        [DllImport("PiritLib.dll")]
        public static extern int scrollPaper();

        //closePort
        [DllImport("PiritLib.dll")]
        public static extern int closePort();

        //libAddPayment
        [DllImport("PiritLib.dll", CharSet = CharSet.Auto, CallingConvention = CallingConvention.StdCall)]
        public static extern int libAddPayment(byte typePayment, long sum, string infoStr);

        //libAddPaymentD
        [DllImport("PiritLib.dll", CharSet = CharSet.Auto, CallingConvention = CallingConvention.StdCall)]
        public static extern int libAddPaymentD(byte typePayment, double sum, string infoStr);

        //libOpenDocument
        [DllImport("PiritLib.dll", CallingConvention = CallingConvention.StdCall)]
        public static extern int libOpenDocument(byte type, byte numDepart, string nameCashier, int docNumber);

        //libPrintString
        [DllImport("PiritLib.dll", CallingConvention = CallingConvention.StdCall)]
        public static extern int libPrintString(string textStr, string attribute);

        //libCloseDocument
        [DllImport("PiritLib.dll", CallingConvention = CallingConvention.StdCall)]
        public static extern IntPtr libCloseDocument(ref MData data, byte cutPaper);

        //libCloseDocument
        [DllImport("PiritLib.dll", CallingConvention = CallingConvention.StdCall)]
        public static extern int libDoCheckCorrection(string nameCashier, double cash, double cashless, byte correctionFlags);

        //libAddPosition
        [DllImport("PiritLib.dll", CallingConvention = CallingConvention.StdCall)]
        public static extern int libAddPosition(
            string goodsName,
            string barcode,
            double quantity,
            double price,
            byte taxNumber,
            int numGoodsPos,
            byte numDepart,
            byte coefType,
            string coefName,
            double coefValue
        );

        //libPrintServiceData
        [DllImport("PiritLib.dll", CallingConvention = CallingConvention.StdCall)]
        public static extern int libPrintServiceData();
    }
}
