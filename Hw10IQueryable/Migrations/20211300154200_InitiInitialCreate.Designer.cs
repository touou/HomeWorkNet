using Hw10IQueryable.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Hw10IQueryable.Migrations
{
    
    [DbContext(typeof(AppContext))]
    [Migration("20211300154200_InitialCreate")]
    public partial class InitialCreate 
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.12")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("HW10.Models.ExpressionModel", b =>
            {
                b.Property<string>("Expression")
                    .HasColumnType("nvarchar(450)");

                b.Property<int>("Value")
                    .HasColumnType("int");

                b.HasKey("Expression");

                b.ToTable("ExpressionCache");
            });
#pragma warning restore 612, 618
        }
    }
}