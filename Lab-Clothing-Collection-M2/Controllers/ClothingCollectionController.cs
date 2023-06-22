using Lab_Clothing_Collection_M2.DTO.ClothingCollection;
using Lab_Clothing_Collection_M2.Repository.CollectionRepository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Exception = System.Exception;

namespace Lab_Clothing_Collection_M2.Controllers;

[Route("api/colecoes")]
[ApiController]
public class ClothingCollectionController : ControllerBase
{
    private readonly ICollectioRepository _repository;

    public ClothingCollectionController(ICollectioRepository repository)
    {
        _repository = repository;
    }

    /// <summary>
    /// Create a new collection request
    /// </summary>
    /// <param name="request">Request body containing the data for the new collection</param>
    /// <returns>Returns the created collection data including the assigned identifier and other fields</returns>
    /// <response code="201">Collection successfully created</response>
    /// <response code="400">Bad request when provided data is invalid or missing required fields</response>
    /// <response code="409">Conflict when the provided collection name already exists in the system</response>
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status409Conflict)]
    [ApiVersion("1.0")]
    [HttpPost("/api/colecoes")]
    public async Task<ActionResult<CollectionResponse>> CreateCollection(
        [FromBody] CollectionRequest request)
    {
        try
        {
            var response = await _repository.AddClothingCollection(request);
            return Created($"api/colecoes/{response.Id}", response);
        }
        catch (Exception ex) when (ex is FluentValidation.ValidationException or ArgumentException)
        {
            return BadRequest("Provided data is invalid or missing required fields");
        }
        catch (DbUpdateException)
        {
            return Conflict("Provided collection name already exists in the system or UserId doesnt exist");
        }
    }
    
    /// <summary>
    /// Update collection request
    /// </summary>
    /// <param name="id">Unique identifier of the collection to be updated</param>
    /// <param name="request">Request body containing the updated data for the collection</param>
    /// <returns>Returns the updated collection data</returns>
    /// <response code="200">Collection data successfully updated</response>
    /// <response code="400">Bad request when provided data is invalid or missing required fields</response>
    /// <response code="404">
    /// Not found when provided identifier does not match an existing collection in the system
    /// </response>
    /// <response code="409">Conflict when the provided collection name already exists in the system</response>
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ApiVersion("1.0")]
    [HttpPut("/api/colecoes/{id:int}")]
    public async Task<ActionResult<CollectionResponse>> UpdateCollection(
        [FromRoute] int id,
        [FromBody] CollectionUpdateRequest request)
    {
        try
        {
            var response = await _repository.UpdateClothingCollection(id, request);
            return Ok(response);
        }
        catch (InvalidOperationException)
        {
            return NotFound("Provided identifier does not match an existing collection in the system");
        }
        catch (Exception ex) when (ex is FluentValidation.ValidationException or ArgumentException)
        {
            return BadRequest("Provided data is invalid or missing required fields," +
                              " and if an userId was provided, check if it exists");
        }
        catch (DbUpdateException)
        {
            return Conflict("Provided name already in use");
        }
    }
    
    /// <summary>
    /// Update collection status request
    /// </summary>
    /// <param name="id">Unique identifier of the collection whose status is to be updated</param>
    /// <param name="request">Request body containing the new status for the collection</param>
    /// <returns>Returns the updated collection data</returns>
    /// <response code="200">Collection status successfully updated</response>
    /// <response code="400">Bad request when provided data is invalid or missing required fields</response>
    /// <response code="404">Not found when provided identifier does not match an existing collection in the system</response>
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ApiVersion("1.0")]
    [HttpPut("/api/colecoes/{id:int}/status")]
    public async Task<ActionResult<CollectionResponse>> UpdateCollectionStatus(
        [FromRoute] int id,
        [FromBody] CollectionStatusUpdateRequest request)
    {
        try
        {
            var response = await _repository.UpdateClothingStatus(id, request);
            return Ok(response);
        }
        catch (InvalidOperationException)
        {
            return NotFound("provided data is invalid or missing required fields");
        }
        catch (Exception ex) when (ex is ArgumentException or FluentValidation.ValidationException)
        {
            return BadRequest("Provided identifier does not match an existing collection in the system");
        }
    }
    
    
    /// <summary>
    /// Get collections request
    /// </summary>
    /// <param name="status">Optional query parameter to filter the result by collection status (ATIVA or INATIVA)</param>
    /// <returns>Returns the list of collections matching the provided status or all collections if no status is provided</returns>
    /// <response code="200">List of collections retrieved successfully</response>
    /// <response code="400">Bad request when provided data is invalid or missing required fields</response>
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ApiVersion("1.0")]
    [HttpGet("/api/colecoes")]
    public async Task<ActionResult<IEnumerable<CollectionResponse>>> GetCollections(
        [FromQuery] string? status = null)
    {
        try
        {
            var response = await _repository.GetAllCollection(status);
            return Ok(response);
        }
        catch (InvalidOperationException)
        {
            return Ok(new List<CollectionResponse>());
        }
        catch (ArgumentException)
        {
            return BadRequest("Provided data is invalid or missing required fields");
        }
    }
    
    /// <summary>
    /// Get collection by identifier request
    /// </summary>
    /// <param name="id">Unique identifier of the collection to be retrieved</param>
    /// <returns>Returns the collection data corresponding to the provided identifier</returns>
    /// <response code="200">Collection data retrieved successfully</response>
    /// <response code="404">Not found when provided identifier does not match an existing collection in the system</response>
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ApiVersion("1.0")]
    [HttpGet("/api/colecoes/{id:int}")]
    public async Task<ActionResult<CollectionResponse>> GetCollectionById(
        [FromRoute] int id)
    {
        try
        {
            var response = await _repository.GetClothingCollection(id);
            return Ok(response);
        }
        catch (InvalidOperationException)
        {
            return NotFound("Provided identifier does not match an existing collection in the system");
        }
    }
    
    /// <summary>
    /// Delete collection request
    /// </summary>
    /// <param name="id">Unique identifier of the collection to be deleted</param>
    /// <returns>Returns no content if the collection is successfully deleted</returns>
    /// <response code="204">Collection successfully deleted, no content returned</response>
    /// <response code="404">Not found when provided identifier does not match an existing collection in the system</response>
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ApiVersion("1.0")]
    [HttpDelete("/api/colecoes/{id:int}")]
    public async Task<IActionResult> DeleteCollection(
        [FromRoute] int id)
    {
        try
        {
            await _repository.DeleteClothingCollection(id);
            return NoContent();
        }
        catch (ArgumentException)
        {
            return NotFound("Provided identifier does not match an existing collection in the system");
        }
    }
}