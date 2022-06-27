using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HiLife_API.Model.Base;

public class BaseEntity
{
    [Key]
    [Column("id")]
    public long Id { get; set; }

    [Column("image_url")]
    [StringLength(300)]
    public string? ImageURL { get; set; }

    [Column("refresh_token")]
    public string? RefreshToken { get; set; }

    [Column("refresh_token_experiy_time")]
    public DateTime? RefreshTokenExperyTime { get; set; }
}
