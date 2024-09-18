namespace InspectorAR.Product.AddProduct;

/// <summary>
/// Command to add a product.
/// </summary>
public class AddProductCommand
{
    /// <summary>
    /// Name of the product.
    /// </summary>
    public string? Name { get;  set; }
    
    /// <summary>
    /// Information of the product.
    /// </summary>
    public Dictionary<string, object>? Information { get;  set; }

    /// <summary>
    /// Constructor of the command.
    /// </summary>
    public AddProductCommand() { }

    /// <summary>
    /// Constructor of the command with parameters.
    /// </summary>
    /// <param name="name"></param>
    /// <param name="information"></param>
    public AddProductCommand(string? name, Dictionary<string, object>? information)
    {
        Name = name;
        Information = information;
    }
}