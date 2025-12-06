using BlazorAppM1GL.Data;
using BlazorAppM1GL.Models;
using Microsoft.EntityFrameworkCore;

public class MemoireService : IMemoireService
{
    private readonly ApplicationDbContext _context;

    public MemoireService(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<List<Memoire>> GetMemoiresAsync()
        => await _context.Memoires.ToListAsync();

    public async Task<Memoire> GetMemoireByIdAsync(int id)
        => await _context.Memoires.FindAsync(id)
            ?? throw new Exception("Mémoire introuvable");

    public async Task AddMemoireAsync(Memoire memoire)
    {
        memoire.LastUpdate = DateTime.Now;
        _context.Memoires.Add(memoire);
        await _context.SaveChangesAsync();
    }

    public async Task UpdateMemoireAsync(Memoire memoire)
    {
        memoire.LastUpdate = DateTime.Now;
        _context.Memoires.Update(memoire);
        await _context.SaveChangesAsync();
    }

    public async Task DeleteMemoireAsync(int id)
    {
        var memoire = await _context.Memoires.FindAsync(id);
        if (memoire != null)
        {
            _context.Memoires.Remove(memoire);
            await _context.SaveChangesAsync();
        }
    }
}