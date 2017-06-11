using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

using GamesRent.Models;
using GamesRent.Dtos;
using AutoMapper;
namespace GamesRent.Controllers.Api
{
    public class GamesController : ApiController
    {
        // GET api/<controller>
        private ApplicationDbContext _context;

        public GamesController()
        {
            _context = new ApplicationDbContext();
        }
        // GET api/<controller>
        public IEnumerable<GameDto> GetGames()
        {
            return _context.Games.ToList().Select(Mapper.Map<Game, GameDto>);
        }

        // GET api/<controller>/5
        public IHttpActionResult GetGame(int id)
        {
            var game = _context.Games.SingleOrDefault(c => c.Id == id);


            if (game == null)
                return NotFound();
            return Ok(Mapper.Map<Game, GameDto>(game));
        }

        [Authorize(Roles = "CanManageGames")]
        [HttpPost]
        // POST api/<controller>
        public IHttpActionResult CreateGame(GameDto gameDto)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var game = Mapper.Map<GameDto, Game>(gameDto);

            _context.Games.Add(game);
            _context.SaveChanges();
            gameDto.Id = game.Id;
            return Created(new Uri(Request.RequestUri + "/" + game.Id), gameDto);

        }

        [Authorize(Roles = "CanManageGames")]
        [HttpPut]
        // PUT api/<controller>/5
        public void Put(int id, GameDto game)
        {

            if (!ModelState.IsValid)
                throw new HttpResponseException(HttpStatusCode.BadRequest);
            var gameInDb = _context.Games.SingleOrDefault(c => c.Id == id);

            if (gameInDb == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);
            //customerInDb.Name = customer.Name;
            //customerInDb.BirthDate = customer.BirthDate;
            //customerInDb.IsSubscribedtoNews = customer.IsSubscribedtoNews;
            //customerInDb.MembershipTypeId = customer.MembershipTypeId;
            Mapper.Map(game, gameInDb);
            _context.SaveChanges();
        }

        [Authorize(Roles = "CanManageGames")]
        [HttpDelete]
        // DELETE api/<controller>/5
        public void Delete(int id)
        {


            var gameInDb = _context.Games.SingleOrDefault(c => c.Id == id);

            if (gameInDb == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);

            _context.Games.Remove(gameInDb);

            _context.SaveChanges();


        }
    }
    }