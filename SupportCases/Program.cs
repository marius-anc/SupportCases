using System;

namespace SupportCases
{
    public enum PriorityLevel
    {
        Critical = 0,
        Important = 1,
        Medium = 2,
        Low = 3
    }

    public struct SupportTicket
    {
        public long Id;
        public string Description;
        public PriorityLevel Priority;

        public SupportTicket(long id, string description, PriorityLevel priority)
        {
            this.Id = id;
            this.Description = description;
            this.Priority = priority;
        }
    }

    public class Program
    {
        public static void Quick3Sort(SupportTicket[] tickets)
        {
            if (tickets == null)
            {
                throw new ArgumentNullException(nameof(tickets));
            }

            Quick3SortAlg(tickets, 0, tickets.Length - 1);
        }

        static void Main()
        {
            SupportTicket[] tickets = ReadSupportTickets();
            Quick3Sort(tickets);
            Print(tickets);
            Console.Read();
        }

        private static void Quick3SortAlg(SupportTicket[] tickets, int low, int high)
        {
            if (low >= high)
            {
                return;
            }

            int i = 0;
            int j = 0;

            Partitioner(tickets, low, high, ref i, ref j);
            Quick3SortAlg(tickets, low, i);
            Quick3SortAlg(tickets, j, high);
        }

        private static void Partitioner(SupportTicket[] a, int low, int high, ref int i, ref int j)
        {
            if (high - low <= 1)
            {
                if (a[high].Priority < a[low].Priority)
                {
                    Swap(ref a[high], ref a[low]);
                }

                i = low;
                j = high;
                return;
            }

            int mid = low;
            PriorityLevel pivot = a[high].Priority;

            while (mid <= high)
            {
                if (a[mid].Priority < pivot)
                {
                    Swap(ref a[low++], ref a[mid++]);
                }
                else if (a[mid].Priority == pivot)
                {
                    mid++;
                }
                else if (a[mid].Priority > pivot)
                {
                    Swap(ref a[mid], ref a[high--]);
                }

                i = low - 1;
                j = mid;
            }
        }

        private static void Swap(ref SupportTicket supportTicket1, ref SupportTicket supportTicket2)
        {
            SupportTicket temp = supportTicket1;
            supportTicket1 = supportTicket2;
            supportTicket2 = temp;
        }

        static void Print(SupportTicket[] tickets)
        {
            for (int i = 0; i < tickets.Length; i++)
            {
                Console.WriteLine(tickets[i].Id + " - " + tickets[i].Description + " - " + tickets[i].Priority);
            }
        }

        static SupportTicket[] ReadSupportTickets()
        {
            const int ticketIdIndex = 0;
            const int descriptionIndex = 1;
            const int priorityLevelIndex = 2;

            int ticketsNumber = Convert.ToInt32(Console.ReadLine());
            SupportTicket[] result = new SupportTicket[ticketsNumber];

            for (int i = 0; i < ticketsNumber; i++)
            {
                string[] ticketData = Console.ReadLine().Split('-');
                long id = Convert.ToInt64(ticketData[ticketIdIndex]);
                result[i] = new SupportTicket(id, ticketData[descriptionIndex].Trim(), GetPriorityLevel(ticketData[priorityLevelIndex]));
            }

            return result;
        }

        static PriorityLevel GetPriorityLevel(string priority)
        {
            switch (priority.ToLower().Trim())
            {
                case "critical":
                    return PriorityLevel.Critical;
                case "important":
                    return PriorityLevel.Important;
                case "medium":
                    return PriorityLevel.Medium;
            }

            return PriorityLevel.Low;
        }
    }
}
