namespace connectivesportService.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class FixSportType : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.SportTypes", "Descrition", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.SportTypes", "Descrition");
        }
    }
}
