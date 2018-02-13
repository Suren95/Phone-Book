namespace PhoneBook.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DeleteUnique2 : DbMigration
    {
        public override void Up()
        {
            DropIndex("dbo.ContactTypes", new[] { "PhoneNumber2" });
        }
        
        public override void Down()
        {
            CreateIndex("dbo.ContactTypes", "PhoneNumber2", unique: true);
        }
    }
}
