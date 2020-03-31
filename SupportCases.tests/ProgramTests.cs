using System;
using Xunit;

namespace SupportCases.tests
{
    public class ProgramTests
    {
        [Fact]
        public void QuickSortWorksWithUnsortedArray()
        {
            SupportTicket ticket1 = new SupportTicket(1, "Incorrect behavior", PriorityLevel.Medium);
            SupportTicket ticket2 = new SupportTicket(2, "Device not workingr", PriorityLevel.Important);
            SupportTicket ticket3 = new SupportTicket(3, "Battery drain", PriorityLevel.Important);
            SupportTicket ticket4 = new SupportTicket(4, "Device immediately turns off", PriorityLevel.Critical);
            SupportTicket ticket5 = new SupportTicket(5, "Strange behavior", PriorityLevel.Low);
            SupportTicket ticket6 = new SupportTicket(6, "Occasionally freeze", PriorityLevel.Critical);
            SupportTicket ticket7 = new SupportTicket(7, "Application not working", PriorityLevel.Low);
            SupportTicket ticket8 = new SupportTicket(8, " Internet connection problems", PriorityLevel.Medium);
            SupportTicket[] ticketsTosort = new SupportTicket[] {ticket1,ticket2, ticket3, ticket4, ticket5, ticket6, ticket7, ticket8 };
            SupportTicket[] ticketsSorted = new SupportTicket[] { ticket6, ticket4, ticket3, ticket2, ticket8, ticket1, ticket7, ticket5 };

            Program.Quick3Sort(ticketsTosort);
            Assert.Equal<SupportTicket>(ticketsSorted , ticketsTosort);
        }

        [Fact]
        public void QuickSortWorksWithOneElementArray()
        {
            SupportTicket ticket1 = new SupportTicket(1, "Incorrect behavior", PriorityLevel.Medium);
            SupportTicket[] ticketsTosort = new SupportTicket[] { ticket1 };
            SupportTicket[] ticketsSorted = new SupportTicket[] { ticket1};
            Program.Quick3Sort(ticketsTosort);
            Assert.Equal<SupportTicket>(ticketsSorted, ticketsTosort);
        }

        [Fact]
        public void QuickSortWorksWithZeroElementArray()
        {
            SupportTicket[] ticketsTosort = Array.Empty<SupportTicket>();
            SupportTicket[] ticketsSorted = Array.Empty<SupportTicket>();
            Program.Quick3Sort(ticketsTosort);
            Assert.Equal<SupportTicket>(ticketsSorted, ticketsTosort);
        }
    }
}
