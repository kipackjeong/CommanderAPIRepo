using AutoMapper;
using CommanderAPI.Dtos;
using CommanderAPI.Models;

namespace CommanderAPI.Profiles
{
    public class CommandsProfile : Profile
    {
        
        public CommandsProfile() // ctor
        {
            // Source -> Target
            CreateMap<Command, CommandReadDto>();

            // Target -> Source
            CreateMap<CommandCreateDto, Command>();

            CreateMap<CommandUpdateDto, Command>();

        }
    }
}