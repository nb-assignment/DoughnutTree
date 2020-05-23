using Microsoft.EntityFrameworkCore;

public static class ModelBuilderExtensions
{
    public static void Seed(this ModelBuilder modelBuilder)
    {
        //modelBuilder.Entity<DoughnutTree>().HasData(
        //    new DoughnutTree
        //    {
        //        Question = "abcd",
        //        ParentId = 1,
        //        BranchId = 1,
        //        LeafId = 1
        //    }
        //);
    }
}