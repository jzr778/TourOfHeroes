using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.DTO
{
    public class HeroSkill
    {
       
        public int SkillId { get; set; }

        public int HeroId { get; set; }

        public required string SkillName { get; set; }

        public DateTime CreatedTime { get; set; }

        public string? CreatedUser { get; set; }
    }
}
