using System;
using MediatR;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using System.Text;
using Notes.Application.Notes.Queries.GetNoteList;
using Notes.Application.Notes.Queries.GetNoteDetails;

namespace Notes.WebApi.Controllers
{
    public class NoteController : BaseController
    {
        [HttpGet]
        public async Task<ActionResult<NoteListVm>> GetAll()
        {
            var query = new GetNoteListQuery
            {
                UserId = UserId
            };

            var vm = await Mediator.Send(query);
            return Ok(vm);
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<NoteDetailsVm>>Get(Guid id)
        {
            var query = new GetNoteDetailsQuery
            {
                UserId = UserId,
                Id = id
            };
            var vm=await Mediator.Send(query);
            return Ok(vm);
        }
    }
}
