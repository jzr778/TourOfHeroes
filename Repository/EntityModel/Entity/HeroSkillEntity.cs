using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.EntityModel.Entity
{
    [Table("HeroSkill")]
    public class HeroSkillEntity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public required int SkillId { get; set; }

        [Required]
        public required int HeroId { get; set; }

        [Required]
        [MaxLength(100)]
        public required string SkillName { get; set; }

        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        public DateTime CreatedTime { get; set; }

        [MaxLength(50)]
        public string? CreatedUser { get; set; }

        // 导航属性
        [ForeignKey("HeroId")]
        public virtual HeroEntity? HeroEntity { get; set; }
    }
}
