namespace connectivesportService.Migrations
{
    using System;
    using System.Collections.Generic;
    using System.Data.Entity.Infrastructure.Annotations;
    using System.Data.Entity.Migrations;
    
    public partial class Challenge : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Challenges",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128,
                            annotations: new Dictionary<string, AnnotationValues>
                            {
                                { 
                                    "ServiceTableColumn",
                                    new AnnotationValues(oldValue: null, newValue: "Id")
                                },
                            }),
                        CustomMessage = c.String(),
                        BattleForRank = c.Int(),
                        Count = c.Int(),
                        Length = c.Double(),
                        Frequency = c.Int(),
                        ProposedTime = c.DateTime(),
                        DateAccepted = c.DateTime(),
                        DateCompleted = c.DateTime(),
                        SportId = c.String(maxLength: 128),
                        ChallengerUserId = c.String(nullable: false, maxLength: 128),
                        ChallengeeUserId = c.String(nullable: false, maxLength: 128),
                        Version = c.Binary(nullable: false, fixedLength: true, timestamp: true, storeType: "rowversion",
                            annotations: new Dictionary<string, AnnotationValues>
                            {
                                { 
                                    "ServiceTableColumn",
                                    new AnnotationValues(oldValue: null, newValue: "Version")
                                },
                            }),
                        CreatedAt = c.DateTimeOffset(nullable: false, precision: 7,
                            annotations: new Dictionary<string, AnnotationValues>
                            {
                                { 
                                    "ServiceTableColumn",
                                    new AnnotationValues(oldValue: null, newValue: "CreatedAt")
                                },
                            }),
                        UpdatedAt = c.DateTimeOffset(precision: 7,
                            annotations: new Dictionary<string, AnnotationValues>
                            {
                                { 
                                    "ServiceTableColumn",
                                    new AnnotationValues(oldValue: null, newValue: "UpdatedAt")
                                },
                            }),
                        Deleted = c.Boolean(nullable: false,
                            annotations: new Dictionary<string, AnnotationValues>
                            {
                                { 
                                    "ServiceTableColumn",
                                    new AnnotationValues(oldValue: null, newValue: "Deleted")
                                },
                            }),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Users", t => t.ChallengeeUserId)
                .ForeignKey("dbo.Users", t => t.ChallengerUserId)
                .ForeignKey("dbo.Sports", t => t.SportId)
                .Index(t => t.SportId)
                .Index(t => t.ChallengerUserId)
                .Index(t => t.ChallengeeUserId)
                .Index(t => t.CreatedAt, clustered: true);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Challenges", "SportId", "dbo.Sports");
            DropForeignKey("dbo.Challenges", "ChallengerUserId", "dbo.Users");
            DropForeignKey("dbo.Challenges", "ChallengeeUserId", "dbo.Users");
            DropIndex("dbo.Challenges", new[] { "CreatedAt" });
            DropIndex("dbo.Challenges", new[] { "ChallengeeUserId" });
            DropIndex("dbo.Challenges", new[] { "ChallengerUserId" });
            DropIndex("dbo.Challenges", new[] { "SportId" });
            DropTable("dbo.Challenges",
                removedColumnAnnotations: new Dictionary<string, IDictionary<string, object>>
                {
                    {
                        "CreatedAt",
                        new Dictionary<string, object>
                        {
                            { "ServiceTableColumn", "CreatedAt" },
                        }
                    },
                    {
                        "Deleted",
                        new Dictionary<string, object>
                        {
                            { "ServiceTableColumn", "Deleted" },
                        }
                    },
                    {
                        "Id",
                        new Dictionary<string, object>
                        {
                            { "ServiceTableColumn", "Id" },
                        }
                    },
                    {
                        "UpdatedAt",
                        new Dictionary<string, object>
                        {
                            { "ServiceTableColumn", "UpdatedAt" },
                        }
                    },
                    {
                        "Version",
                        new Dictionary<string, object>
                        {
                            { "ServiceTableColumn", "Version" },
                        }
                    },
                });
        }
    }
}
