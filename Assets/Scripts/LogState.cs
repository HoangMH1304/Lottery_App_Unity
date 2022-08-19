using System.Collections.Generic;

public class LogState
{
    public static int[] totalMoneyInNumber = new int[100];
    public static void ResetValue()
    {
        totalMoneyInNumber = new int[100];
    }

    public static List<Ticket> tickets = new List<Ticket>();
    public static void Reset()
    {
        tickets.Clear();
    }
}