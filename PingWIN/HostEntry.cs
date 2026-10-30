using System;
using System.Collections.Generic;
using System.Net.NetworkInformation;

namespace PingWIN
{
    internal enum HostState
    {
        Unknown,
        Online,
        Slow,
        Offline
    }

    /// <summary>
    /// Monitorowany host wraz ze statystykami pingowania.
    /// </summary>
    internal sealed class HostEntry
    {
        public const int HistorySize = 40;

        private readonly Queue<long?> history = new Queue<long?>();
        private long totalRtt;

        public HostEntry(string name, string address)
        {
            Name = name;
            Address = address;
        }

        public string Name { get; set; }
        public string Address { get; }
        public bool Busy { get; set; }

        public int Sent { get; private set; }
        public int Received { get; private set; }
        public long? LastRtt { get; private set; }
        public long MinRtt { get; private set; }
        public long MaxRtt { get; private set; }
        public HostState State { get; private set; }
        public string StatusText { get; private set; } = "Oczekuje";
        public string ErrorMessage { get; private set; }

        /// <summary>Ostatnie wyniki – czas odpowiedzi w ms lub null dla nieudanej próby.</summary>
        public IReadOnlyCollection<long?> History => history;

        public double AverageRtt => Received == 0 ? 0 : (double)totalRtt / Received;
        public double LossPercent => Sent == 0 ? 0 : 100.0 * (Sent - Received) / Sent;

        public void RecordReply(IPStatus status, long rtt, int slowThresholdMs)
        {
            Sent++;
            ErrorMessage = null;

            if (status == IPStatus.Success)
            {
                Received++;
                totalRtt += rtt;
                MinRtt = Received == 1 ? rtt : Math.Min(MinRtt, rtt);
                MaxRtt = Math.Max(MaxRtt, rtt);
                LastRtt = rtt;
                State = rtt > slowThresholdMs ? HostState.Slow : HostState.Online;
                StatusText = State == HostState.Slow ? "Wolny" : "Online";
                Push(rtt);
            }
            else
            {
                LastRtt = null;
                State = HostState.Offline;
                StatusText = DescribeStatus(status);
                Push(null);
            }
        }

        public void RecordError(string statusText, string details)
        {
            Sent++;
            LastRtt = null;
            State = HostState.Offline;
            StatusText = statusText;
            ErrorMessage = details;
            Push(null);
        }

        public void ResetStatistics()
        {
            history.Clear();
            totalRtt = 0;
            Sent = 0;
            Received = 0;
            LastRtt = null;
            MinRtt = 0;
            MaxRtt = 0;
            State = HostState.Unknown;
            StatusText = "Oczekuje";
            ErrorMessage = null;
        }

        private void Push(long? value)
        {
            history.Enqueue(value);
            while (history.Count > HistorySize)
                history.Dequeue();
        }

        private static string DescribeStatus(IPStatus status)
        {
            switch (status)
            {
                case IPStatus.TimedOut: return "Przekroczono czas";
                case IPStatus.DestinationHostUnreachable: return "Host nieosiągalny";
                case IPStatus.DestinationNetworkUnreachable: return "Sieć nieosiągalna";
                case IPStatus.DestinationUnreachable: return "Cel nieosiągalny";
                case IPStatus.TtlExpired: return "TTL wygasł";
                case IPStatus.BadDestination: return "Zły adres";
                default: return status.ToString();
            }
        }
    }
}
