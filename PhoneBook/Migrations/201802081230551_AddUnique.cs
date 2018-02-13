namespace PhoneBook.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddUnique : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.ContactTypes", "EmailAddress", c => c.String(nullable: false, maxLength: 20));
            CreateIndex("dbo.ContactTypes", "PhoneNumber1", unique: true);
            CreateIndex("dbo.ContactTypes", "PhoneNumber2", unique: true);
            CreateIndex("dbo.ContactTypes", "EmailAddress", unique: true);
        }
        
        public override void Down()
        {
            DropIndex("dbo.ContactTypes", new[] { "EmailAddress" });
            DropIndex("dbo.ContactTypes", new[] { "PhoneNumber2" });
            DropIndex("dbo.ContactTypes", new[] { "PhoneNumber1" });
            AlterColumn("dbo.ContactTypes", "EmailAddress", c => c.String(nullable: false));
        }
    }
}
