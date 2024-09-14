namespace InspectorAR.Product.Common.Models;

/// <summary>
/// Product view model.
/// </summary>
/// <param name="id"></param>
/// <param name="name"></param>
/// <param name="information"></param>
public class ProductViewModel(Guid id, string name, dynamic information)
{
    /// <summary>
    /// Id
    /// </summary>
    public Guid Id { get; private set; } = id;
    
    /// <summary>
    /// Name
    /// </summary>
    public string Name { get; private set; } = name;
    
    /// <summary>
    /// Information
    /// </summary>
    public dynamic Information { get; private set; } = information;
}