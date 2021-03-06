using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MessageObject
{
    //MarshalByRefObject 允许在支持远程处理的应用程序中跨应用程序域边界访问对象。
      public class RemoteObject : MarshalByRefObject
      {
          public static Queue<string> qMessage { get; set; } //使用消息队列储存消息
   
          public string SendMessage(string message)
          {
              if (qMessage == null)
              {
                  qMessage = new Queue<string>();
              }
              qMessage.Enqueue(message);
   
              return message;
          }

        public static string taskInfo = string.Empty;
        public void Add(string taskInfo)
        {
            Console.WriteLine("Add:{0}", taskInfo);
        }
        public string GetTask()
        {
            Console.WriteLine("GetTask;{0}", taskInfo);
            return taskInfo;
        }
     }
}
