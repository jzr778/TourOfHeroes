using Repository.DTO;
using Repository.EntityModel.Entity;
using Repository.Interface;
using Service.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service
{
    public class HeroService : IHeroService
    {
        private readonly IHeroRepository _repository;

        public HeroService(IHeroRepository irepository)
        {
            _repository = irepository;
        }

        public void AddHero(HeroEntity hero)
        {
            _repository.AddHero(hero);
        }

        //public void AddDetail(DetailEntity detail)
        //{
        //    _repository.AddDetail(detail);
        //}

        //public HeroEntity GetHeroWithDetails(int heroId)
        //{
        //    return _repository.GetHeroWithDetails(heroId);
        //}

        public void UpdateHero(HeroEntity hero)
        {
            _repository.UpdateHero(hero);
        }

        public void DeleteHero(int heroId)
        {
            _repository.DeleteHero(heroId);
        }

        public List<Hero> GetAllHeros()
        {
            // 实现获取所有Hero的逻辑
            return _repository.GetAllHeros();
        }

        public Hero GetHeroById(int heroId)
        {
            return _repository.GetHeroById(heroId);
        }

        public IEnumerable<HeroEntity> SearchHeroes(string searchTerm)
        {
            // 使用LINQ实现不区分大小写的包含搜索
            return _repository.SearchHeroes(searchTerm);

        }
    }
}
