namespace GK.BRE.Models.Interfaces
{
    public interface IBusinessRule
    {
        string Name { get; }

        Result ExecuteRule(Product product);
    }
}
