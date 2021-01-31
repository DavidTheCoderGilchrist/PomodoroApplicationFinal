namespace Pomodoro.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class fifthadd : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Achievement",
                c => new
                    {
                        AchievementId = c.Int(nullable: false, identity: true),
                        OwnerId = c.Guid(nullable: false),
                        AchievementName = c.String(),
                        Description = c.String(),
                        TotalCompletes = c.Int(nullable: false),
                        PointsToUnlock = c.Int(nullable: false),
                        IsUnlocked = c.Boolean(nullable: false),
                        Message = c.String(),
                    })
                .PrimaryKey(t => t.AchievementId);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Achievement");
        }
    }
}
