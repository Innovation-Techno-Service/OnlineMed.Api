using Microsoft.AspNetCore.Mvc;
using OnlineMed.Application.Interfaces;
using OnlineMed.Contracts.Requests.Doctor;
using OnlineMed.Contracts.Responses.Doctor;

namespace OnlineMed.Api.Controllers;

[ApiController]
[Route("api/doctor")]
public sealed class DoctorController(IDoctorService service) : ControllerBase
{
    /// <summary>
    /// Returns a list of doctors, optionally filtered by search term, experience, age, price, rating 
    /// </summary>
    /// <param name="request"></param>
    /// <returns><returns>
    [HttpGet]
    [ProducesResponseType(typeof(List<DoctorResponse>), StatusCodes.Status200OK)]
    public async Task<ActionResult<List<DoctorResponse>>> GetAsync([FromQuery] GetDoctorsRequest request)
    {
        var doctors = await service.GetAllAsync(request);
        return Ok(doctors);
    }

    /// <summary>
    /// Retrieves a specific doctor by its ID.
    /// </summary>
    /// <param name="request"></param>
    /// <returns></returns>
    [HttpGet("{Id:int:min(1)}")]
    [ProducesResponseType(typeof(DoctorResponse), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status404NotFound)]
    public async Task<ActionResult> GetByIdAsync([FromQuery] GetDoctorByIdRequest request)
    {
        var doctor = await service.GetByIdAsync(request);
        return Ok(doctor);
    }

    /// <summary>
    /// Creates a new doctor.
    /// </summary>
    /// <param name="request"></param>
    /// <returns></returns>
    [HttpPost]
    [ProducesResponseType(typeof(CreateDoctorResponse), StatusCodes.Status201Created)]
    [ProducesResponseType(typeof(ValidationProblemDetails), StatusCodes.Status400BadRequest, "application/problem+json")]
    [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status404NotFound)]
    public async Task<ActionResult<CreateDoctorResponse>> CreateAsync([FromBody] CreateDoctorRequest request)
    {
        var createdDoctor = await service.CreateAsync(request);
        return CreatedAtAction(nameof(GetByIdAsync), new { id = createdDoctor.Id }, createdDoctor);
    }

    /// <summary>
    /// Updates an existing doctor.
    /// </summary>
    /// <param name="id"></param>
    /// <param name="request"></param>
    /// <returns></returns>
    [HttpPut]
    [ProducesResponseType(typeof(UpdateDoctorResponse), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ValidationProblemDetails), StatusCodes.Status400BadRequest, "application/problem+json")]
    [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status404NotFound)]
    public async Task<ActionResult<UpdateDoctorResponse>> UpdateAsync(
        [FromRoute] int id,
        [FromBody] UpdateDoctorRequest request)
    {
        if (id != request.Id)
        {
            return BadRequest(new ProblemDetails
            {
                Title = "ID mismatch",
                Detail = $"Route ID ({id}) does not match body ID ({request.Id}).",
                Status = StatusCodes.Status400BadRequest
            });
        }

        var updatedDoctor = await service.UpdateAsync(request);
        return Ok(updatedDoctor);
    }

    /// <summary>
    /// Deletes a doctor by its ID.
    /// </summary>
    /// <param name="request"></param>
    /// <returns></returns>
    [HttpDelete]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status404NotFound)]
    public async Task<IActionResult> DeleteAsync([FromRoute] DeleteDoctorRequest request)
    {
        await service.DeleteAsync(request);
        return NoContent();
    }
}
