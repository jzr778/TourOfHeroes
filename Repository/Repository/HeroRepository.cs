using Microsoft.EntityFrameworkCore;
using Repository.DBContext;
using Repository.DTO;
using Repository.EntityModel.Entity;
using Repository.Helper;
using Repository.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Repository
{
    public class HeroRepository : IHeroRepository
    {
        private readonly HeroContext _context;

        // 依赖注入
        public HeroRepository(HeroContext context)
        {
            _context = context;
        }

        // 添加主实体
        public void AddHero(HeroEntity hero)
        {
            _context.HeroEntities.Add(hero);
            _context.SaveChanges();

        }



        public void UpdateHero(HeroEntity hero)
        {
            // 标记实体状态为"已修改"
            _context.Entry(hero).State = EntityState.Modified;
            _context.SaveChanges();
        }

        public void DeleteHero(int heroId)
        {

            var hero = _context.HeroEntities
                .Include(h => h.HeroSkillEntities)
                .FirstOrDefault(m => m.Id == heroId);
            if (hero != null)
            {
                // 先删除所有关联的技能
                _context.HeroSkillEntities.RemoveRange(hero.HeroSkillEntities);

                // 再删除英雄
                _context.HeroEntities.Remove(hero);

                _context.SaveChanges();
            }

        }

        public List<Hero> GetAllHeros()
        {
            try
            {
                var list = _context.HeroEntities.Include(o => o.HeroSkillEntities).ToList();
                var heroList = list.Select(hero => HeroDataHelper.HeroToDTO(hero)).ToList();

                return heroList;
            }
            catch (Exception ex)
            {
                throw ex;
            }


        }

        public Hero GetHeroById(int HeroId)
        {
            HeroEntity heroEntity = _context.HeroEntities
                .Include(m => m.HeroSkillEntities)
                .FirstOrDefault(m => m.Id == HeroId);
            return HeroDataHelper.HeroToDTO(heroEntity);
        }

        public IEnumerable<HeroEntity> SearchHeroes(string searchTerm)
        {
            var query = _context.HeroEntities
                .Where(h => h.HeroName.Contains(searchTerm)).AsEnumerable()
                .Select(h => new HeroEntity
                {
                    Id = h.Id,
                    HeroName = h.HeroName
                    // 其他需要返回的字段...
                });
            return query.ToList();
        }
    }
}
