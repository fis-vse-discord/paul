using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace PaulBot.Discord.Verification.Models;

[Index("MemberId", IsUnique = true)]
public class MemberVerification
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }
    
    [Required]
    public ulong MemberId { get; set; }
    
    public string? AzureId { get; set; } = null;
}