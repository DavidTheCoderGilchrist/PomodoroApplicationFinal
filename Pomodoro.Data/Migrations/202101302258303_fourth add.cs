namespace Pomodoro.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class fourthadd : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Reward",
                c => new
                    {
                        RewardId = c.Int(nullable: false, identity: true),
                        OwnerId = c.Guid(nullable: false),
                        RewardName = c.String(),
                        Description = c.String(),
                        PointCost = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.RewardId);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Reward");
        }
    }
}
