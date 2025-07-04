using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MediatR;
using Pago.Application.Commands;
using Pago.Application.Interfaces;
using Pago.Domain.Repositories;

namespace Pago.API.Controllers
{
    /// <summary>
    /// Controlador para gestionar las operaciones relacionadas con pagos.
    /// </summary>
    [ApiController]
    [Route("api/pagos")]
    public class PagoController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly IPagoRepository _pagoRepository;

        /// <summary>
        /// Inicializa una nueva instancia de <see cref="PagoController"/>.
        /// </summary>
        public PagoController(IMediator mediator, IPagoRepository pagoRepository)
        {
            _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
            _pagoRepository = pagoRepository ?? throw new ArgumentNullException(nameof(pagoRepository));
        }

        /// <summary>
        /// Verifica el estado de salud del servicio de pagos.
        /// </summary>
        [HttpGet("/Pago/health")]
        public IActionResult Health() => Ok("Healthy");

        /// <summary>
        /// Registra un nuevo pago.
        /// </summary>
        /// <param name="pagoDto">Datos del pago a registrar.</param>
        /// <returns>Resultado del registro.</returns>
        [HttpPost("create")]
        public async Task<IActionResult> RegistrarPago([FromBody] RegistrarPagoDto pagoDto)
        {
            var pagoId = await _mediator.Send(new RegistrarPagoCommand(
                pagoDto.SubastaId,
                pagoDto.UsuarioId,
                pagoDto.Monto,
                pagoDto.Metodo,
                pagoDto.DetallesTransaccion
            ));

            return CreatedAtAction(nameof(RegistrarPago), new { id = pagoId });
        }
    }
}

       
