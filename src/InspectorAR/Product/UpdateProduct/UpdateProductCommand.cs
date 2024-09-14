using System.Text.Json.Serialization;

namespace InspectorAR.Product.UpdateProduct;

/// <summary>
/// Command to update a product.
/// </summary>
public class UpdateProductCommand
{
    /// <summary>
    /// Id of the product.
    /// </summary>
    [JsonIgnore]
    public Guid Id { get; private set; }
    
    /// <summary>
    /// Name of the product.
    /// </summary>
    public string? Name { get; private set; }
    
    /// <summary>
    /// Information of the product.
    /// </summary>
    public Dictionary<string, object>? Information { get; private set; }
    
    /// <summary>
    /// Constructor of the command.
    /// </summary>
    public UpdateProductCommand() { }

    /// <summary>
    /// Constructor of the command.
    /// </summary>
    /// <param name="id"></param>
    /// <param name="name"></param>
    /// <param name="information"></param>
    public UpdateProductCommand(Guid id, string? name, Dictionary<string, object>? information)
    {
        Id = id;
        Name = name;
        Information = information;
    }

    /// <summary>
    /// Method to set the id of the product.
    /// </summary>
    /// <param name="id"></param>
    public void SetId(Guid id) => Id = id;
}