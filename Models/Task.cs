using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace goal_tracker.Models

{
  public class TaskItem
  {
    public int Id { get; set; }
    public string TaskName { get; set; }
    public string Requirements { get; set; }
    public bool IsComplete { get; set; }
    public int GoalId { get; set; } // foreign key
    public DateTime CreationDateTime { get; set; }
    public DateTime? LastUpdateDateTime { get; set; }
  }
}