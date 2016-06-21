namespace NewModel.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _3 : DbMigration
    {
        public override void Up()
        {
            //DropIndex("dbo.Application", new[] { "ParticipantId" });
            AlterColumn("dbo.Application", "ParticipantId", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Application", "ParticipantId", c => c.String(nullable: false, maxLength: 13));
            CreateIndex("dbo.Application", "ParticipantId", unique: true);
        }
    }
}
