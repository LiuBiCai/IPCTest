using MessageObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Channels;
using System.Runtime.Remoting.Channels.Ipc;
using System.Text;
using System.Threading.Tasks;

namespace Client
{
    class Program
    {
        static void Main(string[] args)
        {
            RemoteObject objRemoteObject = ConnectServer();
            Send(objRemoteObject);
            string message = Console.ReadLine();
        }
        private static void Send(RemoteObject objRemoteObject)
        {
            while (true)
            {
                Console.WriteLine("please input message...");
                string message = Console.ReadLine();
                try
                {
                    objRemoteObject.SendMessage(message);
                    Console.WriteLine("send success");

                    var task = objRemoteObject.GetTask();
                    Console.WriteLine(task);
                }
                catch (System.Runtime.Remoting.RemotingException)
                {
                    Console.WriteLine("can not connect message server");
                }
            }
        }
        private static RemoteObject ConnectServer()
        {
            IpcClientChannel channel = new IpcClientChannel();
            ChannelServices.RegisterChannel(channel, false);
            RemoteObject objRemoteObject = (RemoteObject)Activator.GetObject(typeof(RemoteObject), "ipc://ServerChannel/RemoteObject");
            return objRemoteObject;
        }
    }

}

