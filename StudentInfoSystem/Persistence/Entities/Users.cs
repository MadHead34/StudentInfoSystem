using System.ComponentModel.DataAnnotations;

public class Users
{
    public int Id { get;set; }

    [Required]
    public string Username { get; set; }

    [Required]
    public string PasswordHash { get; set; }
}