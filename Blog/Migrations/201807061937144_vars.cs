namespace Blog.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class vars : DbMigration
    {
        public override void Up()
        {
            RenameColumn(table: "dbo.Posts", name: "CategoriaId", newName: "CategoryId");
            RenameIndex(table: "dbo.Posts", name: "IX_CategoriaId", newName: "IX_CategoryId");
        }
        
        public override void Down()
        {
            RenameIndex(table: "dbo.Posts", name: "IX_CategoryId", newName: "IX_CategoriaId");
            RenameColumn(table: "dbo.Posts", name: "CategoryId", newName: "CategoriaId");
        }
    }
}
