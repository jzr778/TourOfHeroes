using Repository.DTO;
using Repository.EntityModel.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Interface
{
    public interface IHeroRepository
    {
        void AddHero(HeroEntity hero);
        void UpdateHero(HeroEntity hero);
        void DeleteHero(int heroId);
        List<Hero> GetAllHeros();
        Hero GetHeroById(int HeroId);
        IEnumerable<HeroEntity> SearchHeroes(string searchTerm);
    }
}
