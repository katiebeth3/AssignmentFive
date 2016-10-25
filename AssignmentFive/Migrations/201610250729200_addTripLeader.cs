namespace AssignmentFive.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addTripLeader : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.TripLeader",
                c => new
                    {
                        TripLeaderID = c.Int(nullable: false, identity: true),
                        LastName = c.String(nullable: false, maxLength: 50),
                        FirstName = c.String(nullable: false, maxLength: 50),
                    })
                .PrimaryKey(t => t.TripLeaderID);
            
            AddColumn("dbo.Activity", "TripLeaderID", c => c.Int(nullable: false));
            CreateIndex("dbo.Activity", "TripLeaderID");
            AddForeignKey("dbo.Activity", "TripLeaderID", "dbo.TripLeader", "TripLeaderID", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Activity", "TripLeaderID", "dbo.TripLeader");
            DropIndex("dbo.Activity", new[] { "TripLeaderID" });
            DropColumn("dbo.Activity", "TripLeaderID");
            DropTable("dbo.TripLeader");
        }
    }
}
