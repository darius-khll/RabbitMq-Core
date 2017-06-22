using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System;
using System.Text;

namespace Receive
{
    class Program
    {
        static void Main(string[] args) //Receive
        {
            //new Receive().ConsumerReceiver();
            new WorkerQueue().ConsumerReceiver();
        }
    }
}