using Lab_Clothing_Collection_M2.DTO.User;
using Lab_Clothing_Collection_M2.Repository.UserRepository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Lab_Clothing_Collection_M2.Controllers;

[Route("api/usuarios")]
[ApiController]
public class UserController : ControllerBase
{
    private readonly IUserRepository _repository;

    public UserController(IUserRepository userRepository)
    {
        _repository = userRepository;
    }

    /// <summary>
    /// User registration request
    /// </summary>
    /// <returns>Returns the created user and the resource uri</returns>
    /// <param name="request">Request body containing the data needed to add a new user</param>
    /// <response code="201">Successfully created a new user with the given information</response>
    /// <response code="400">Bad request when provided data is invalid or missing required fields</response>
    /// <response code="409">Conflict when the provided CPF or CNPJ is already registered in the system</response>
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status409Conflict)]
    [ApiVersion("1.0")]
    [HttpPost]
    public async Task<ActionResult<UserResponse>> Post([FromBody] UserRequest request)
    {
        try
        {
            var response = await _repository.AddUser(request);
            return Created($"api/usuarios/{response.Id}", response);
        }
        catch (FluentValidation.ValidationException)
        {
            return BadRequest("Provided data is invalid or missing required fields");
        }
        catch (DbUpdateException)
        {
            return Conflict("Error to update the database");
        }
    }

    /// <summary>
    /// Update user request
    /// </summary>
    /// <param name="identifier">Unique identifier of the user to be updated</param>
    /// <param name="request">Request body containing the updated data for the user</param>
    /// <returns>Returns the updated user data</returns>
    /// <response code="200">User data successfully updated</response>
    /// <response code="400">Bad request when provided data is invalid or missing required fields</response>
    /// <response code="404">Not found when provided identifier does not match an existing user in the system</response>
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ApiVersion("1.0")]
    [HttpPut("/api/usuarios/{identifier:int}")]
    public async Task<ActionResult<UserResponse>> UpdateUser(
        [FromRoute] int identifier,
        [FromBody] UserUpdateRequest request)
    {
        try
        {
            var response = await _repository.UpdateUser(identifier, request);
            return Ok(response);
        }
        catch (InvalidOperationException)
        {
            return NotFound("Provided identifier does not match an existing user in the system");
        }
        catch (FluentValidation.ValidationException)
        {
            return BadRequest("Provided data is invalid or missing required fields");
        }
    }

    /// <summary>
    /// Update user status request
    /// </summary>
    /// <param name="id">Unique identifier of the user whose status is to be updated</param>
    /// <param name="request">Request body containing the new status for the user</param>
    /// <returns>Returns the updated user data</returns>
    /// <response code="200">User status successfully updated</response>
    /// <response code="400">Bad request when provided data is invalid or missing required fields</response>
    /// <response code="404">Not found when provided identifier does not match an existing user in the system</response>
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ApiVersion("1.0")]
    [HttpPut("/api/usuario/{id:int}/status")]
    public async Task<ActionResult<UserResponse>> UpdateUserStatus(
        [FromRoute] int id,
        [FromBody] UserStatusUpdateRequest request)
    {
        try
        {
            var response = await _repository.UpdateStatusUser(id, request);
            return Ok(response);
        }
        catch (InvalidOperationException)
        {
            return NotFound("Provided identifier does not match an existing user in the system");
        }
        catch (FluentValidation.ValidationException)
        {
            return BadRequest("Provided data is invalid or missing required fields");
        }
    }

    /// <summary>
    /// Get users request
    /// </summary>
    /// <param name="status">Optional query parameter to filter the result by user status (ATIVO or INATIVO)</param>
    /// <returns>Returns the list of users matching the provided status or all users if no status is provided</returns>
    /// <response code="200">List of users retrieved successfully</response>
    /// <response code="400">Bad request when provided data is invalid or missing required fields</response>
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ApiVersion("1.0")]
    [HttpGet("/api/usuarios")]
    public async Task<ActionResult<IEnumerable<UserResponse>>> GetUsers([FromQuery] string? status = null)
    {
        try
        {
            var response = await _repository.GetUsersStatus(status);
            return Ok(response);
        }
        catch (ArgumentException)
        {
            return BadRequest("Provided identifier does not match an existing user in the system");
        }
    }
    
    /// <summary>
    /// Get user by identifier request
    /// </summary>
    /// <param name="id">Unique identifier of the user to be retrieved</param>
    /// <returns>Returns the user data corresponding to the provided identifier</returns>
    /// <response code="200">User data retrieved successfully</response>
    /// <response code="404">Not found when provided identifier does not match an existing user in the system</response>
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ApiVersion("1.0")]
    [HttpGet("/api/usuarios/{id:int}")]
    public async Task<ActionResult<UserResponse>> GetUserById([FromRoute] int id)
    {
        try
        {
            var response = await _repository.GetUserById(id);
            return Ok(response);
        }
        catch (InvalidOperationException)
        {
            return NotFound("Provided identifier does not match an existing user in the system");
        }
    }
}