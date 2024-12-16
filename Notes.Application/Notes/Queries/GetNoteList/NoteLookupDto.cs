using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using Notes.Domain;
using Notes.Application.Common.Mappings;

namespace Notes.Application.Notes.Queries.GetNoteList
{
    public class NoteLookupDto: IMapWith<Note>
    {
        public Guid Id { get; set; }
        public required string Title {  get; set; }
        public required string Details { get; set; }
        public void Mapping(Profile profile)
        {
            profile.CreateMap<Note, NoteLookupDto>().ForMember(noteDto=>noteDto.Id, opt=>opt.MapFrom(note=>note.Id)).
                ForMember(noteDto=>noteDto.Title,opt=>opt.MapFrom(note=>note.Title));
        }
    }
}
