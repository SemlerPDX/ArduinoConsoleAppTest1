using System;
using System.Text;
using System.IO.Ports;
using System.Threading;

namespace ArduinoConsoleAppTest1
{
    class Program
    {
        private static void OpenDataConnection()
        {
            System.IO.Ports.SerialPort SerialPort1 = new System.IO.Ports.SerialPort();
            string incoming = "";
            string dataBuild = "";
            int checkReadChars = 0;
            bool dataComplete = false;
            byte[] inBuffer = new byte[1];

            SerialPort1.PortName = "COM13"; // !!!  Change to the COMPORT of your Aduino Device between tests!!!
            SerialPort1.BaudRate = 9600;
            SerialPort1.DataBits = 8;
            SerialPort1.Parity = Parity.None;
            SerialPort1.StopBits = StopBits.One;
            SerialPort1.Handshake = Handshake.None;
            SerialPort1.Encoding = System.Text.Encoding.Default;
            SerialPort1.ReadTimeout = 500;

            SerialPort1.Open();
            Thread.Sleep(100);

            Console.WriteLine("Beginning Serial Monitor Loop...");

            while (dataComplete != true)
            {
                try
                {
                    SerialPort1.Read(inBuffer, 0, 1);
                    incoming = Encoding.ASCII.GetString(inBuffer, 0, inBuffer.Length);

                    if (String.IsNullOrEmpty(incoming))
                    {
                        incoming = "nothing" + Environment.NewLine;
                    }
                    else
                    {
                        if (String.IsNullOrEmpty(dataBuild))
                        {
                            if (incoming == "[")
                                dataBuild += incoming;
                        }
                        else
                        {
                            dataBuild += incoming;
                            if (incoming == "]")
                                dataComplete = true;
                        }
                    }
                }
                catch (TimeoutException e)
                {
                    Console.WriteLine("Error: Serial Port read timed out.");
                }
                finally
                {
                    incoming = "";
                    if (dataComplete)
                    {
                        //VA.SetText("AVCS_DHT1_DATA", dataBuild); //this loop will exist in VoiceAttack program as inline C# function, setting this GVAR
                        Console.WriteLine(dataBuild);
                        dataBuild = "";
                        dataComplete = false;
                        //SerialPort1.DiscardOutBuffer();
                        //SerialPort1.DiscardInBuffer();
                        Thread.Sleep(2000);
                    }
                }
            }

            //SerialPort1.DiscardOutBuffer();
            //SerialPort1.DiscardInBuffer();
            SerialPort1.Dispose();
            //VA.SetText("AVCS_DHT1_DATA", null); //this loop will exist in VoiceAttack program as inline function, setting this GVAR
        }

        static void Main(string[] args)
        {
            Console.WriteLine("TESTER");
            OpenDataConnection();
            Thread.Sleep(2500);
	}
    }
}
