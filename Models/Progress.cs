using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace goal_tracker.Models

{
  public class Progress
  {
    public int Id { get; set; }
    public float TimeSpent { get; set; }
    public string DescribeProgress { get; set; }
    // public int goalId { get; set; } // foreign key
    public int TaskId { get; set; } // foreign key
    public DateTime CreationDateTime { get; set; }
    public DateTime? LastUpdateDateTime { get; set; }
  }
}