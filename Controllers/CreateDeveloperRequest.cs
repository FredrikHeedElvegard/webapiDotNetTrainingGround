using System.ComponentModel.DataAnnotations;

public class CreateDeveloperRequest
{
    [Required]
    public string? Name { get; set; }
    [Required]
    public string? Email { get; set; }    
}