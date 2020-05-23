using DoughnutFactory.Entities;
using Microsoft.EntityFrameworkCore;
using System.Linq;

public class ApplicationDbContext : DbContext
{
    public DbSet<DoughnutTreeNode> DoughnutTreeNodes { get; set; }
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
    { }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<DoughnutTreeNode>()
            .HasOne(x => x.PositiveNode)
            .WithMany()
            .HasForeignKey(x => x.PositiveNodeId);

        modelBuilder.Entity<DoughnutTreeNode>()
            .HasOne(x => x.NegativeNode)
            .WithMany()
            .HasForeignKey(x => x.NegativeNodeId);
    }

    public void EnsureSeeded()
    {
        //Make sure that DB exists and has latest schema
        Database.Migrate();

        if (!DoughnutTreeNodes.Any())
        {
            DoughnutTreeNodes.AddRange(
                new DoughnutTreeNode { Question = "Do I want a doughnut?", PositiveNodeId = 2, NegativeNodeId = 3 },
                new DoughnutTreeNode { Question = "Do I deserve it?", PositiveNodeId = 4, NegativeNodeId = 5 },
                new DoughnutTreeNode { Question = "Maybe you want an apple?" },
                new DoughnutTreeNode { Question = "Are you sure?", PositiveNodeId = 8, NegativeNodeId = 9 },
                new DoughnutTreeNode { Question = "Is it a good doughnut?", PositiveNodeId = 6, NegativeNodeId = 7 },
                new DoughnutTreeNode { Question = "What are you waiting for? Grab it now." },
                new DoughnutTreeNode { Question = "Wait `till you find a sinful, unforgettable doughnut." },
                new DoughnutTreeNode { Question = "Get it." },
                new DoughnutTreeNode { Question = "Do jumping jacks first." });
        }

        SaveChanges();
    }
  }