namespace Model.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _2 : DbMigration
    {
        public override void Up()
        {
            //CreateTable(
            //    "dbo.tblProgramType",
            //    c => new
            //        {
            //            ID = c.Int(nullable: false, identity: true),
            //            ProgramType = c.String(nullable: false, maxLength: 100),
            //        })
            //    .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.AppPrograms",
                c => new
                    {
                        ApplicationId = c.Int(nullable: false),
                        ProgramId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.ApplicationId, t.ProgramId })
                .ForeignKey("dbo.tblParticipant", t => t.ApplicationId, cascadeDelete: true)
                .ForeignKey("dbo.tblProgramType", t => t.ProgramId, cascadeDelete: true)
                .Index(t => t.ApplicationId)
                .Index(t => t.ProgramId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.AppPrograms", "ProgramId", "dbo.tblProgramType");
            DropForeignKey("dbo.AppPrograms", "ApplicationId", "dbo.tblParticipant");
            DropIndex("dbo.AppPrograms", new[] { "ProgramId" });
            DropIndex("dbo.AppPrograms", new[] { "ApplicationId" });
            DropTable("dbo.AppPrograms");
            DropTable("dbo.tblProgramType");
        }
    }
}
