using Microsoft.EntityFrameworkCore;
using PMUKTest.Shared.Entities;

namespace PMUKTest.Server.Data;

public class PmukTestContext : DbContext
{
	public PmukTestContext(DbContextOptions<PmukTestContext> options) : base(options){}

	public DbSet<User> Users { get; set; }
}
