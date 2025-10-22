using AutoMapper;
using CourtReservation_Api.Responses;
using CourtReservation_Core.CustomEntities;
using CourtReservation_Core.Entities;
using CourtReservation_Core.Interfaces.Services_Interfaces;
using CourtReservation_Infraestructure.Dto_s;
using CourtReservation_Infraestructure.Validators;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;


namespace CourtReservation_Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReservasController : ControllerBase
    {
        
        private readonly IReservaService _service; // Inyecta el servicio
        private readonly IMapper _mapper;
        private readonly IValidationService _validationService;

        public ReservasController(IReservaService service,IMapper mapper, IValidationService validationService)
        {
            _service = service;
            _mapper = mapper;
            _validationService = validationService;
        }

        [HttpGet]
        public async Task<IEnumerable<Reservas>> GetAllReservas()
        {
            var reservas = await _service.GetAllReservasAsync();
            var reservasDto = _mapper.Map<IEnumerable<ReservaDto>>(reservas);
           
            var response = new ApiResponse<IEnumerable<ReservaDto>>(reservasDto);
            
            return (IEnumerable<Reservas>)Ok(response);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetReserva(int id)
        {
            

                var validationRequest = new GetByIdRequest { Id = id };
                var validationResult = await _validationService.ValidateAsync(validationRequest);
                if (!validationResult.IsValid)
                {
                    return BadRequest(new
                    {
                        Message = "Error de validación del ID",
                        Errors = validationResult.Errors
                    });
                }

                var reserva = await _service.GetReservaAsync(id);
                var reservatDto = _mapper.Map<ReservaDto>(reserva);

                ApiResponse<ReservaDto> response = new ApiResponse<ReservaDto>(reservatDto);
                
                return Ok(response); // Retorna 200
            

        }

        [HttpPost]
        public async Task<IActionResult> CrearReserva([FromBody] ReservaDto reservaDto)
        {
           
                #region Validaciones
              
                var validationResult = await _validationService.ValidateAsync(reservaDto);

                if (!validationResult.IsValid)
                {
                    return BadRequest(new { Errors = validationResult.Errors });
                }
                #endregion

                var reserva = _mapper.Map<Reservas>(reservaDto); 

                 await _service.InsertReservaAsync(reserva);

                var response = new ApiResponse<ReservaDto>(reservaDto)
                {
                    Data = reservaDto,
                    Message = "Reserva creada exitosamente",
                    Success = true,
                    StatusCode = 201
                };
                return StatusCode(201, response); 
        }
        [HttpPut]
        public async Task<IActionResult> ActualizarReserva([FromBody] ReservaDto reservaDto)
        {

            #region Validaciones

            var validationResult = await _validationService.ValidateAsync(reservaDto);

            if (!validationResult.IsValid)
            {
                return BadRequest(new { Errors = validationResult.Errors });
            }
            #endregion

            var reserva = _mapper.Map<Reservas>(reservaDto);

            await _service.UpdateReservaAsync(reserva);

            var response = new ApiResponse<ReservaDto>(reservaDto)
            {
                Data = reservaDto,
                Message = "Reserva creada exitosamente",
                Success = true,
                StatusCode = 201
            };
            return StatusCode(201, response);
        }
        [HttpDelete]
        public async Task<IActionResult> BorrarReserva([FromBody] ReservaDto reservaDto)
        {

            #region Validaciones

            var validationResult = await _validationService.ValidateAsync(reservaDto);

            if (!validationResult.IsValid)
            {
                return BadRequest(new { Errors = validationResult.Errors });
            }
            #endregion

            var reserva = _mapper.Map<Reservas>(reservaDto);

            await _service.DeleteReservaAsync(reserva);

            return NoContent();
        }
    }
}
