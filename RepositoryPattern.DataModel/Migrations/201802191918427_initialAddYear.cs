namespace RepositoryPattern.DataModel.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class initialAddYear : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Ninjas", "YearOfBirth", c => c.DateTime(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Ninjas", "YearOfBirth");
        }
    }
}
