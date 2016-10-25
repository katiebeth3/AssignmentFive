namespace AssignmentFive.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Activity",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        ActivityName = c.String(),
                        ActivityDate = c.DateTime(nullable: false),
                        ActivityTitle = c.String(),
                        ActivityParticipants = c.String(),
                        ActivityCategory = c.String(),
                        ActivityDescription = c.String(),
                        ActivityLengthHours = c.Decimal(nullable: false, precision: 18, scale: 2),
                        ActivityText = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Activity");
        }
    }
}
