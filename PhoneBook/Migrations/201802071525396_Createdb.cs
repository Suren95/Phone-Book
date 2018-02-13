namespace PhoneBook.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Createdb : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Contacts",
                c => new
                    {
                        ContactId = c.Int(nullable: false, identity: true),
                        ContactName = c.String(nullable: false, maxLength: 20),
                    })
                .PrimaryKey(t => t.ContactId);
            
            CreateTable(
                "dbo.ContactTypes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        PhoneNumber1 = c.String(nullable: false, maxLength: 9),
                        PhoneNumber2 = c.String(maxLength: 9),
                        EmailAddress = c.String(nullable: false),
                        ContactId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Contacts", t => t.ContactId, cascadeDelete: true)
                .Index(t => t.ContactId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ContactTypes", "ContactId", "dbo.Contacts");
            DropIndex("dbo.ContactTypes", new[] { "ContactId" });
            DropTable("dbo.ContactTypes");
            DropTable("dbo.Contacts");
        }
    }
}
