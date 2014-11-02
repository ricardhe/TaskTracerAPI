namespace TaskTracerApi.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class WorkGroupCreation : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.WorkGroups",
                c => new
                    {
                        WorkGroupID = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 50),
                        Alias = c.String(nullable: false, maxLength: 20),
                        Description = c.String(maxLength: 200),
                        URLIdentifier = c.String(nullable: false, maxLength: 150),
                        EmailGroup = c.String(nullable: false),
                        Active = c.Boolean(nullable: false),
                        CreateDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.WorkGroupID);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.WorkGroups");
        }
    }
}
