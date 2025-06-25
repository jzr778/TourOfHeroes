using Microsoft.AspNetCore.Mvc;
using Repository.EntityModel.Entity;
using Service.Interface;
using System.Net;

namespace TourOfHeroes.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HeroesController : ControllerBase
    {
        private readonly IHeroService _heroService;
        private readonly ILogger<HeroesController> _logger;

        public HeroesController(
            IHeroService heroService,
            ILogger<HeroesController> logger)
        {
            _heroService = heroService;
            _logger = logger;
        }

        /// <summary>
        /// 获取所有英雄
        /// </summary>
        [HttpGet]
        public IActionResult GetAll()
        {
            var heroes = _heroService.GetAllHeros();
            if (!heroes.Any())
            {
                return NoContent();
            }
            return Ok(heroes);
        }

        [HttpGet("{id:int}")]
        public IActionResult GetHero(int id)
        {
            var hero = _heroService.GetHeroById(id);
            if (hero == null)
            {
                return NotFound();
            }
            return Ok(hero);
        }

        [HttpPost]
        public IActionResult CreateHero([FromBody] HeroEntity hero)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                _heroService.AddHero(hero);
                return CreatedAtAction(nameof(GetHero), new { id = hero.Id }, hero);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "创建英雄时发生错误");
                return StatusCode(500, "创建英雄时发生错误");
            }
        }

        [HttpPut("{id:int}")]
        public IActionResult UpdateHero(int id, [FromBody] HeroEntity hero)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            if (id != hero.Id)
                return BadRequest("URL中ID与请求体中ID不一致");

            try
            {
                _heroService.UpdateHero(hero);
                return NoContent();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "更新英雄时发生错误");
                return StatusCode(500, "更新英雄时发生错误");
            }
        }

        [HttpDelete("{id:int}")]
        public IActionResult DeleteHero(int id)
        {
            try
            {
                _heroService.DeleteHero(id);
                return NoContent();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "删除英雄时发生错误");
                return StatusCode(500, "删除英雄时发生错误");
            }
        }

        [HttpGet("search")]
        public IActionResult SearchHeroes([FromQuery] string name)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(name))
                {
                    return Ok(Enumerable.Empty<HeroEntity>());
                }

                var results = _heroService.SearchHeroes(name.Trim());
                return Ok(results);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "搜索英雄时发生错误");
                return StatusCode(500, "搜索英雄时发生错误");
            }
        }
    }
}
