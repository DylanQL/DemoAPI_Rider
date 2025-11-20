using System.ComponentModel.DataAnnotations;

namespace DemoAPI_Rider.Models;

public class Student
{   
    [Key]
    public int IdStudent { get; set; }
    public int GradeId { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Phone { get; set; }
    public string Email { get; set; }
    public int Active { get; set; }
    
    //Navigation Properties
    public Grade Grade { get; set; }
}