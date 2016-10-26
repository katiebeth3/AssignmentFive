namespace AssignmentFive.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addedRequiredFields : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Activity", "ActivityName", c => c.String(nullable: false));
            AlterColumn("dbo.Activity", "ActivityCategory", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Activity", "ActivityCategory", c => c.String());
            AlterColumn("dbo.Activity", "ActivityName", c => c.String());
        }
    }
}
