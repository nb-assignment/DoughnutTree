using DoughnutFactory.Entities;
using Microsoft.EntityFrameworkCore;
using System.Linq;

/// <summary>
/// Db context
/// </summary>
public class ApplicationDbContext : DbContext
{
    /// <summary>
    /// Tree nodes
    /// </summary>
    public DbSet<DoughnutTreeNode> DoughnutTreeNodes { get; set; }

    /// <summary>
    /// Ctor
    /// </summary>
    /// <param name="options"></param>
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
    { }

    /// <summary>
    /// Model creating
    /// </summary>
    /// <param name="modelBuilder"></param>
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

    /// <summary>
    /// Seed the default tree nodes
    /// </summary>
    public void EnsureSeeded()
    {
        //Make sure that DB exists and has latest schema
        Database.Migrate();

        // If tree nodes are not available, add them
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