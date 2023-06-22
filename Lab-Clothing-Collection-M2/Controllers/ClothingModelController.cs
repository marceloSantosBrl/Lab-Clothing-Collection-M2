using Lab_Clothing_Collection_M2.DTO.ClothingModel;
using Lab_Clothing_Collection_M2.Repository.ModelRepository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Lab_Clothing_Collection_M2.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ClothingModelController : ControllerBase
{
    private readonly IModelRepository _repository;
    public ClothingModelController(IModelRepository repository)
    {
        _repository = repository;
    }
    
    /// <summary>
    /// Create a new model request
    /// </summary>
    /// <param name="request">Request body containing the data for the new model</param>
    /// <returns>Returns the created model data including the assigned identifier and other fields</returns>
    /// <response code="201">Model successfully created</response>
    /// <response code="400">Bad request when provided data is invalid or missing required fields</response>
    /// <response code="404">
    /// Not found when provided ModelRequest.CollectionId does not match an existing user in the system
    /// </response>
    /// <response code="409">Conflict when the provided model name already exists in the system</response>
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status409Conflict)]
    [ApiVersion("1.0")]
    [HttpPost("/api/modelos")]
    public async Task<ActionResult<ModelResponse>> CreateModel(
        [FromBody] ModelRequest request)
    {
        try
        {
            var response = await _repository.AddModel(request);
            return Created($"/api/modelos/{response.Id}", response);
        }
        catch (Exception ex) when (ex is FluentValidation.ValidationException or ArgumentException)
        {
            return BadRequest("Provided data is invalid or missing required fields");
        }
        catch (DbUpdateException)
        {
            return Conflict("Provided model name already exists in the system or CollectionId is invalid");
        }
    }
    
    /// <summary>
    /// Update model request
    /// </summary>
    /// <param name="id">Unique identifier of the model to be updated</param>
    /// <param name="request">Request body containing the updated data for the model</param>
    /// <returns>Returns the updated model data</returns>
    /// <response code="200">Model data successfully updated</response>
    /// <response code="400">Bad request when provided data is invalid or missing required fields</response>
    /// <response code="404">Not found when provided identifier does not match an existing model in the system</response>
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ApiVersion("1.0")]
    [HttpPut("/api/modelos/{id:int}")]
    public async Task<ActionResult<ModelResponse>> UpdateModel(
        [FromRoute] int id,
        [FromBody] ModelRequest request)
    {
        try
        {
            var response = await _repository.UpdateModel(id, request);
            return Ok(response);
        }
        catch (InvalidOperationException)
        {
            return NotFound("Provided identifier does not match an existing model in the system");
        }
        catch (FluentValidation.ValidationException)
        {
            return BadRequest("Provided data is invalid or missing required fields");
        }
        catch (DbUpdateException)
        {
            return Conflict("Provided name already in use or collectionId doesnt exist");
        }
    }

    /// <summary>
    /// Get models request
    /// </summary>
    /// <param name="layout">Optional query parameter to filter the result by model layout (BORDADO, ESTAMPA, or LISO)</param>
    /// <returns>Returns the list of models matching the provided layout or all models if no layout is provided</returns>
    /// <response code="200">List of models retrieved successfully</response>
    /// <response code="404">Not found when provided layout does not match an existing model in the system</response>
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ApiVersion("1.0")]
    [HttpGet("/api/modelos")]
    public async Task<ActionResult<IEnumerable<ModelResponse>>> GetModels(
        [FromQuery] string? layout = null)
    {
        try
        {
            var response = await _repository.GetAllModels(layout);
            return Ok(response);
        }
        catch (Exception ex) when (ex is ArgumentException or InvalidOperationException)
        {
            return NotFound("Provided layout does not match any existing model in the system");
        }
    }
    
    /// <summary>
    /// Get model by identifier request
    /// </summary>
    /// <param name="id">Unique identifier of the model to be retrieved</param>
    /// <returns>Returns the model data corresponding to the provided identifier</returns>
    /// <response code="200">Model data retrieved successfully</response>
    /// <response code="404">Not found when provided identifier does not match an existing model in the system</response>
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ApiVersion("1.0")]
    [HttpGet("/api/modelos/{id:int}")]
    public async Task<ActionResult<ModelResponse>> GetModelById(
        [FromRoute] int id)
    {
        try
        {
            var response = await _repository.GetModel(id);
            return Ok(response);
        }
        catch (InvalidOperationException)
        {
            return NotFound("Provided identifier does not match an existing model in the system");
        }
    }

    /// <summary>
    /// Delete a model by its identifier
    /// </summary>
    /// <param name="id">Unique identifier of the model to be deleted</param>
    /// <returns>Returns no content when model is successfully deleted</returns>
    /// <response code="204">Model successfully deleted with no returned content</response>
    /// <response code="404">Not found when provided identifier does not match an existing model in the database</response>
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ApiVersion("1.0")]
    [HttpDelete("/api/modelos/{id:int}")]
    public async Task<ActionResult> DeleteModel(
        [FromRoute] int id)
    {
        try
        {
            await _repository.DeleteModel(id);
            return NoContent();
        }
        catch (ArgumentException)
        {
            return NotFound("Provided identifier does not match an existing model in the database");
        }
    }
}