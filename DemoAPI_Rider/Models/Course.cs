using System.ComponentModel.DataAnnotations;

namespace DemoAPI_Rider.Models;

public class Course
{   
    [Key]
    public int IdCourse { get; set; }
    public string Name { get; set; }
    public int Credit { get; set; }
    public int Active { get; set; }
}