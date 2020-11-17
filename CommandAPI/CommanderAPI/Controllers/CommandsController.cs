using System.Collections.Generic;
using AutoMapper;
using CommanderAPI.Data;
using CommanderAPI.Dtos;
using CommanderAPI.Models;
using Microsoft.AspNetCore.Mvc;

namespace CommanderAPI.Controllers
{
  // api/commands
  [Route("api/commands")]
  [ApiController] // gives outbox behavior
  public class CommandsController : ControllerBase
  {
    private readonly ICommanderAPIRepo _repository;

    public IMapper _mapper { get; }

    public CommandsController(ICommanderAPIRepo repository, IMapper mapper)
    {
      _repository = repository;
      _mapper = mapper; 
    }


    // GET api/commands from HTTP
    [HttpGet]
    public ActionResult<IEnumerable<CommandReadDto>> GetAllCommands()
    {
      var commandItems = _repository.GetAllCommands();
      
      return Ok(_mapper.Map<IEnumerable<CommandReadDto>>(commandItems));
    }

    // GET api/commands/{id} from HTTP
    [HttpGet("{id}", Name="GetCommandByID")]
    public ActionResult<CommandReadDto> GetCommandByID(int id)
    {
      var commandItem = _repository.GetCommandByID(id);
      if(commandItem !=null)
      {
        return Ok(_mapper.Map<CommandReadDto>(commandItem));
      }
      return NotFound();

    }

    // POST api/commands
    [HttpPost]
    public ActionResult<CommandReadDto> CreateCommand(CommandCreateDto commandCreateDto)
    {
      // commandcreatedto -> command
      var commandModel = _mapper.Map<Command>(commandCreateDto);
      _repository.CreateCommand(commandModel);
      _repository.SaveChanges();

      // command -> commandreaddto
      var commandReadDto = _mapper.Map<CommandReadDto>(commandModel);

      return CreatedAtRoute(nameof(GetCommandByID), new {id = commandReadDto.ID}, commandReadDto);
      // 201 message with url.



      // return Ok(commandReadDto); ==>   200 message
    }

    // Put api/commands/{id}
    [HttpPut("{id}")]
    public ActionResult UpdateCommand(int id, CommandUpdateDto commandUpdateDto)
    {
      var commandModelFromRepo = _repository.GetCommandByID(id);
      if(commandModelFromRepo == null)
      {
        return NotFound();  // 404 not found
      }
                          //  from -> to
      _mapper.Map(commandUpdateDto, commandModelFromRepo);

      _repository.UpdateCommand(commandModelFromRepo);

      _repository.SaveChanges();

      return NoContent(); // 204
    }
  }
}