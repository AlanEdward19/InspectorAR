using System.ComponentModel.DataAnnotations;
using System.Text.Json;
using InspectorAR.Product.UpdateProduct;

namespace InspectorAR.Product.Entities;

/// <summary>
/// Product entity.
/// </summary>
public class Product
{
    /// <summary>
    /// Id of the product.
    /// </summary>
    [Key] public Guid Id { get; private set; }
    
    /// <summary>
    /// Name of the product.
    /// </summary>
    [MaxLength(255)] public string Name { get; private set; } = null!;

    /// <summary>
    /// Information of the product.
    /// </summary>
    // ReSharper disable once EntityFramework.ModelValidation.UnlimitedStringLength
    public string Information { get; private set; } = null!;

    /// <summary>
    /// When the product was created
    /// </summary>
    public DateTime CreatedAt { get; private set; }
    
    /// <summary>
    /// When the product was last updated
    /// </summary>
    public DateTime UpdatedAt { get; private set; }

    /// <summary>
    /// Constructor of the product.
    /// </summary>
    /// <param name="id"></param>
    /// <param name="name"></param>
    /// <param name="information"></param>
    /// <param name="createdAt"></param>
    /// <param name="updatedAt"></param>
    public Product(Guid id, string name, string information, DateTime createdAt, DateTime updatedAt)
    {
        Id = id;
        Name = name;
        Information = information;
        CreatedAt = createdAt;
        UpdatedAt = updatedAt;
    }

    /// <summary>
    /// Constructor of the product.
    /// </summary>
    /// <param name="name"></param>
    /// <param name="information"></param>
    public Product(string name, string information)
    {
        Id = Guid.NewGuid();
        Name = name;
        Information = information;
        CreatedAt = DateTime.Now;
        UpdatedAt = DateTime.Now;
    }
    
    /// <summary>
    /// Constructor of the product.
    /// </summary>
    public Product() { }

    /// <summary>
    /// Method to update the product based on a command.
    /// </summary>
    /// <param name="command"></param>
    public void UpdateBasedOnCommand(UpdateProductCommand command)
    {
        bool updated = false;

        if (!string.IsNullOrWhiteSpace(command.Name))
        {
            Name = command.Name;
            updated = true;
        }
        
        if (command.Information != null)
        {
            Information = JsonSerializer.Serialize(command.Information);
            updated = true;
        }

        if (updated)
            UpdatedAt = DateTime.Now;
    }
}