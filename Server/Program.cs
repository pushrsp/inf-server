using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Sockets;
using System.Reflection;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Google.Protobuf;
using Google.Protobuf.Protocol;
using Google.Protobuf.WellKnownTypes;
using Server.Data;
using Server.Game;
using ServerCore;
using Timer = System.Timers.Timer;

namespace Server
{
    class Program
    {
        static Listener _listener = new Listener();
        private static List<Timer> _timers = new List<Timer>();

        static void TickRoom(GameRoom room, int tick = 100)
        {
            Timer timer = new Timer();
            timer.Interval = tick;
            timer.Elapsed += (s, e) => room.Update();
            timer.AutoReset = true;
            timer.Enabled = true;

            _timers.Add(timer);
        }

        static void Main(string[] args)
        {
            ConfigManager.LoadConfig();
            DataManager.LoadData();

            TickRoom(RoomManager.Instance.Add(1), 50);

            IPEndPoint endPoint = new IPEndPoint(IPAddress.Any, 7777);

            _listener.Init(endPoint, () => { return SessionManager.Instance.Generate(); });
            Console.WriteLine("Listening...");

            while (true)
            {
                Thread.Sleep(100);
            }
        }
    }
}