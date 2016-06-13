namespace Model.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _3 : DbMigration
    {
        public override void Up()
        {
            //CreateTable(
            //    "dbo.tblTeachingCredentialType",
            //    c => new
            //        {
            //            ID = c.Int(nullable: false),
            //            TeachingCredentialType = c.String(nullable: false, maxLength: 500),
            //        })
            //    .PrimaryKey(t => t.ID);
            
            //CreateTable(
            //    "dbo.tblDegree",
            //    c => new
            //        {
            //            DegreeId = c.Int(nullable: false, identity: true),
            //            Degree = c.String(nullable: false, maxLength: 50),
            //        })
            //    .PrimaryKey(t => t.DegreeId);
            
            CreateTable(
                "dbo.AppCredentialTypes",
                c => new
                    {
                        ApplicationId = c.Int(nullable: false),
                        CredentialTypeId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.ApplicationId, t.CredentialTypeId })
                .ForeignKey("dbo.tblParticipant", t => t.ApplicationId, cascadeDelete: true)
                .ForeignKey("dbo.tblTeachingCredentialType", t => t.CredentialTypeId, cascadeDelete: true)
                .Index(t => t.ApplicationId)
                .Index(t => t.CredentialTypeId);
            
            CreateTable(
                "dbo.AppDegrees",
                c => new
                    {
                        ApplicationId = c.Int(nullable: false),
                        DegreeId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.ApplicationId, t.DegreeId })
                .ForeignKey("dbo.tblParticipant", t => t.ApplicationId, cascadeDelete: true)
                .ForeignKey("dbo.tblDegree", t => t.DegreeId, cascadeDelete: true)
                .Index(t => t.ApplicationId)
                .Index(t => t.DegreeId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.AppDegrees", "DegreeId", "dbo.tblDegree");
            DropForeignKey("dbo.AppDegrees", "ApplicationId", "dbo.tblParticipant");
            DropForeignKey("dbo.AppCredentialTypes", "CredentialTypeId", "dbo.tblTeachingCredentialType");
            DropForeignKey("dbo.AppCredentialTypes", "ApplicationId", "dbo.tblParticipant");
            DropIndex("dbo.AppDegrees", new[] { "DegreeId" });
            DropIndex("dbo.AppDegrees", new[] { "ApplicationId" });
            DropIndex("dbo.AppCredentialTypes", new[] { "CredentialTypeId" });
            DropIndex("dbo.AppCredentialTypes", new[] { "ApplicationId" });
            DropTable("dbo.AppDegrees");
            DropTable("dbo.AppCredentialTypes");
            DropTable("dbo.tblDegree");
            DropTable("dbo.tblTeachingCredentialType");
        }
    }
}
