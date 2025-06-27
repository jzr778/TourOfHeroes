using Repository.DTO;
using Repository.EntityModel.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Helper
{
    public static class HeroDataHelper
    {

        /// <summary>
        /// 将Entity转换为DTO
        /// </summary>
        public static HeroSkill HeroSkillToDTO(HeroSkillEntity entity)
        {
            if (entity == null) return null;

            var dto = new HeroSkill
            {
                SkillId = entity.SkillId,
                HeroId = entity.HeroId,
                SkillName = entity.SkillName,
                CreatedTime = entity.CreatedTime,
                CreatedUser = entity.CreatedUser
            };
            return dto;
        }


        public static Hero HeroToDTO(HeroEntity entity)
        {
            if (entity == null) return null;

            return new Hero
            {
                Id = entity.Id,
                HeroName = entity.HeroName,
                CreatedTime = entity.CreatedTime,
                CreatedUser = entity.CreatedUser,
                Skills = entity.HeroSkillEntities.Select(x => HeroSkillToDTO(x)).ToList()
            };
        }



        /// <summary>
        /// 将DTO转换回Entity(用于更新操作)
        /// </summary>
        public static HeroSkillEntity HeroSkillToEntity(HeroSkill dto)
        {
            if (dto == null) return null;

            return new HeroSkillEntity
            {
                SkillId = dto.SkillId,
                HeroId = dto.HeroId,
                SkillName = dto.SkillName,
                CreatedTime = dto.CreatedTime,
                CreatedUser = dto.CreatedUser
            };
        }
    }
}
