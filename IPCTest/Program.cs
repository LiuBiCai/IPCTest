using MessageObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting;
using System.Runtime.Remoting.Channels;
using System.Runtime.Remoting.Channels.Ipc;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
//参考https://developer.aliyun.com/article/678809
namespace IPCTest
{
    class Program
    {
        static void Main(string[] args)
        {
            StartServer();
            Thread t = new Thread(new ThreadStart(ReceviceMessage));
            t.Start();
        }
        private static void StartServer()
          {
              IpcServerChannel channel = new IpcServerChannel("ServerChannel");
             ChannelServices.RegisterChannel(channel, false);
              RemotingConfiguration.RegisterWellKnownServiceType(typeof(RemoteObject), "RemoteObject", WellKnownObjectMode.SingleCall);
              Console.WriteLine("message server running...");
         }
         private static void ReceviceMessage()
         {
             while (true)
              {
                  Queue<string> qMessage = RemoteObject.qMessage;
                  if (qMessage != null)
                 {
                      if (qMessage.Count > 0)
                      {
                          string message = qMessage.Dequeue();
                          Console.WriteLine("recevice message is:" +message);
                      }
                }
                  Thread.Sleep(1000);  //每一秒获取一次
             }
          }
 
     }
  }
    

