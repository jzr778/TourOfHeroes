using Repository.DTO;
using Repository.EntityModel.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Interface
{
    public interface IHeroService
    {
        void AddHero(HeroEntity hero);
        void UpdateHero(HeroEntity hero);
        void DeleteHero(int heroId);
        List<Hero> GetAllHeros();
        Hero GetHeroById(int heroId);
        IEnumerable<HeroEntity> SearchHeroes(string searchTerm);
    }
}
