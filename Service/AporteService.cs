using Microsoft.EntityFrameworkCore;
using Angel_Paredes_AP_AP1.DAL;
using Angel_Paredes_AP_AP1.Models; 
using System.Linq.Expressions;
using System.Linq;

namespace Angel_Paredes_AP_AP1.Service;

public class AporteService(IDbContextFactory<Contexto> DbFactory)
{
    public async Task<bool> Existe(int id)
    {
        await using var contexto = await DbFactory.CreateDbContextAsync();
        return await contexto.Aportes.AnyAsync(a => a.AporteId == id);
    }

    private async Task<bool> Insertar(Aportes aporte)
    {
        await using var contexto = await DbFactory.CreateDbContextAsync();
        contexto.Aportes.Add(aporte);
        return await contexto.SaveChangesAsync() > 0;
    }

    private async Task<bool> Modificar(Aportes aporte)
    {
        await using var contexto = await DbFactory.CreateDbContextAsync();
        contexto.Aportes.Update(aporte);
        return await contexto.SaveChangesAsync() > 0;
    }

    public async Task<bool> Guardar(Aportes aporte)
    {
        if (!await Existe(aporte.AporteId))
            return await Insertar(aporte);
        else
            return await Modificar(aporte);
    }

    public async Task<bool> Eliminar(int id)
    {
        await using var contexto = await DbFactory.CreateDbContextAsync();
        var eliminados = await contexto.Aportes
            .Where(a => a.AporteId == id)
            .ExecuteDeleteAsync();
        return eliminados > 0;
    }

    public async Task<Aportes?> Buscar(int id)
    {
        await using var contexto = await DbFactory.CreateDbContextAsync();
        return await contexto.Aportes.AsNoTracking()
            .FirstOrDefaultAsync(a => a.AporteId == id);
    }

    public async Task<List<Aportes>> Listar(Expression<Func<Aportes, bool>> criterio)
    {
        await using var contexto = await DbFactory.CreateDbContextAsync();
        return await contexto.Aportes.AsNoTracking()
            .Where(criterio)
            .ToListAsync();
    }

  
    public async Task<List<Aportes>> BuscarPorPersona(string persona)
    {
        await using var contexto = await DbFactory.CreateDbContextAsync();
        return await contexto.Aportes.AsNoTracking()
            .Where(a => a.Persona.Contains(persona))
            .ToListAsync();
    }
}