using System;

namespace RabbitMq
{
    class Program
    {
        static void Main(string[] args)
        {
            //new Send().SendMessage();
            for (int i = 0; i < 10; i++)
            {
                new WorkerQueue().Send(args.Length > 0 ? args[0] : "ali khalili" + i);
            }
        }

    }
}
