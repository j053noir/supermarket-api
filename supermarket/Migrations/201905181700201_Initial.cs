namespace supermarket.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Products",
                c => new
                    {
                        Id = c.Guid(nullable: false, identity: true),
                        Reference = c.String(),
                        Name = c.String(),
                        Cost = c.Double(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.Reference, unique: true);
            
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        Id = c.Guid(nullable: false, identity: true),
                        Username = c.String(),
                        Password = c.String(),
                        Name = c.String(),
                        Token = c.Guid(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.Token, unique: true);
            
        }
        
        public override void Down()
        {
            DropIndex("dbo.Users", new[] { "Token" });
            DropIndex("dbo.Products", new[] { "Reference" });
            DropTable("dbo.Users");
            DropTable("dbo.Products");
        }
    }
}
