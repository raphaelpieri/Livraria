namespace Livraria.Infra.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class v1 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Book",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Title = c.String(nullable: false, maxLength: 100),
                        PublishingCompany = c.String(nullable: false, maxLength: 100),
                        Author = c.String(nullable: false, maxLength: 100),
                        Page = c.Int(nullable: false),
                        BookValue = c.Decimal(nullable: false, storeType: "money"),
                        QuantityOnHand = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Book");
        }
    }
}
