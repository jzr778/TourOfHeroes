using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.DTO
{
    public class Hero
    {
        
        public int Id { get; set; }

        
        public required string HeroName { get; set; }

        
        public DateTime CreatedTime { get; set; }

       
        public string? CreatedUser { get; set; }

        
        public List<HeroSkill> Skills { get; set; } = new List<HeroSkill>();
    }
}
