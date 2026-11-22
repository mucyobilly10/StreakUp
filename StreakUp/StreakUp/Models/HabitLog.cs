using System;

namespace StreakUp.Models;

public class HabitLog
{
    public int LogId { get; set; }
    public int HabitId { get; set; }
    public DateTime LogDate { get; set; }
    public bool IsDone { get; set; }
}