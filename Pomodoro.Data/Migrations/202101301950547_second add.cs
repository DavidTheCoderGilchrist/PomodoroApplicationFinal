namespace Pomodoro.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class secondadd : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Assignment", "OwnerId", c => c.Guid(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Assignment", "OwnerId");
        }
    }
}
