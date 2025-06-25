using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.EntityModel.Entity
{
    [Table("Hero")]
    public class HeroEntity
    {
        [Key] // 标识主键
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)] // 自增标识
        [Column("HeroId")]
        public required int Id { get; set; }

        [Column("HeroName")] // 明确指定列名(可选)
        public required string HeroName { get; set; }

        [DatabaseGenerated(DatabaseGeneratedOption.Computed)] // 表示该值由数据库生成
        [Column("CreatedTime")] // 明确指定列名(可选)
        public DateTime CreatedTime { get; set; }

        [StringLength(50)] // 对应NVARCHAR(50)
        [Column("CreatedUser")] // 明确指定列名(可选)
        public string? CreatedUser { get; set; }

        public virtual ICollection<HeroSkillEntity> HeroSkillEntities { get; set; } = new List<HeroSkillEntity>();

    }
}
