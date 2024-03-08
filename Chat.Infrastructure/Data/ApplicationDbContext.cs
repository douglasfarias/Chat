using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Chat.Infrastructure.Data;

public class ApplicationDbContext : IdentityDbContext<IdentityUser>
{
    public ApplicationDbContext(DbContextOptions options) : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);

        builder.Entity<IdentityUser>().ToTable("Usuarios");
        builder.Entity<IdentityRole>().ToTable("Papeis");
        builder.Entity<IdentityUserRole<string>>().ToTable("PapeisDoUsuario");
        builder.Entity<IdentityUserClaim<string>>().ToTable("ReivindicacoesDoUsuario");
        builder.Entity<IdentityUserLogin<string>>().ToTable("LoginsDoUsuario");
        builder.Entity<IdentityUserToken<string>>().ToTable("TokensDoUsuario");
        builder.Entity<IdentityRoleClaim<string>>().ToTable("ReivindicacoesDePapeis");
    }
}
