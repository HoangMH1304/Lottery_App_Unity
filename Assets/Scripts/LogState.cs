using System.Collections.Generic;

public class LogState
{
    public static List<Ticket> tickets = new List<Ticket>();
    public static void Reset()
    {
        tickets.Clear();
    }

    public static int FindIndex(Ticket ticket)
    {
        for (int i = 0; i < tickets.Count; i++)
        {
            int targetNumber = ticket.number;
            if (tickets[i].number == targetNumber) return i;
        }
        return -1;
    }
}