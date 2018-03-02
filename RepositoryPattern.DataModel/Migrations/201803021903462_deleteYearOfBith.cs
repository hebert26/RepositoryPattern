namespace RepositoryPattern.DataModel.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class deleteYearOfBith : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Ninjas", "YearOfBirth");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Ninjas", "YearOfBirth", c => c.DateTime(nullable: false));
        }
    }
}
