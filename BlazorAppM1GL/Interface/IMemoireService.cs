using BlazorAppM1GL.Models;

public interface IMemoireService
{
    Task<List<Memoire>> GetMemoiresAsync();

    Task<Memoire> GetMemoireByIdAsync(int IdM);

    Task AddMemoireAsync(Memoire memoire);

    Task UpdateMemoireAsync(Memoire memoire);

    Task DeleteMemoireAsync(int IdM);

}