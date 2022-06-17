using HiLife_API.Model.Base;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HiLife_API.Model;

[Table("patient")]
public class Patient : BaseEntity
{
    [Column("email")]
    [Required]
    public string Email { get; set; }

    [Column("password")]
    [Required]
    public string Password { get; set; }

    [Column("name")]
    [Required]
    [StringLength(150)]
    public string Name { get; set; }

    [Column("cep")]
    [Required]
    public string Cep { get; set; }

    [Column("address")]
    [Required]
    [StringLength(300)]
    public string Address { get; set; }

    [Column("image_url")]
    [StringLength(300)]
    public string ImageURL { get; set; }

}
