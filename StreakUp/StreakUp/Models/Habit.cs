using System;

namespace StreakUp.Models;

public class Habit
{
    public int HabitId { get; set; }
    public int UserId { get; set; }
    public string Name { get; set; } = "";
    public string? Description { get; set; }
    public string? Category { get; set; }
    public TimeSpan? ReminderTime { get; set; }
    public bool IsArchived { get; set; }
    public DateTime CreatedAt { get; set; }
}