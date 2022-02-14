using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

namespace PaulBot.Discord.Verification.Models;

[Index("MemberId", IsUnique = true)]
public class MemberVerification
{
    [Key]
    public Guid Id { get; init; } = Guid.NewGuid();
    
    [Required]
    public ulong MemberId { get; set; }
    
    [Required]
    public bool IsRevoked { get; set; } = false;
    
    public string? AzureId { get; set; } = null;
}