namespace ProjectManagementSystem.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class taskTableUpdate : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Task_tbl", "AssignedBy", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Task_tbl", "AssignedBy");
        }
    }
}
