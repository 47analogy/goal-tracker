using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace goal_tracker.Models
{
  public class Goal
  {
    public int Id { get; set; }
    public string GoalName { get; set; }
    public int PercentComplete { get; set; }
    public DateTime CreationDateTime { get; set; }
    public DateTime? LastUpdateDateTime { get; set; }
  }
}
