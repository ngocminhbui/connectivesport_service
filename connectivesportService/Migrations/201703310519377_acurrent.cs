namespace connectivesportService.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class acurrent : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Challenges", "Current_Count", c => c.Int());
            AddColumn("dbo.Challenges", "Current_Length", c => c.Int());
            AddColumn("dbo.Challenges", "Current_Frequency", c => c.Int());
            AddColumn("dbo.Challenges", "Current_ProposedTime", c => c.Int());
            AddColumn("dbo.Goals", "Current_Count", c => c.Int());
            AddColumn("dbo.Goals", "Current_Length", c => c.Int());
            AddColumn("dbo.Goals", "Current_Frequency", c => c.Int());
            AddColumn("dbo.Goals", "Current_ProposedTime", c => c.Int());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Goals", "Current_ProposedTime");
            DropColumn("dbo.Goals", "Current_Frequency");
            DropColumn("dbo.Goals", "Current_Length");
            DropColumn("dbo.Goals", "Current_Count");
            DropColumn("dbo.Challenges", "Current_ProposedTime");
            DropColumn("dbo.Challenges", "Current_Frequency");
            DropColumn("dbo.Challenges", "Current_Length");
            DropColumn("dbo.Challenges", "Current_Count");
        }
    }
}
