namespace WebDACS.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CreatetableDACS : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Categories",
                c => new
                    {
                        IdGory = c.Int(nullable: false, identity: true),
                        Namegory = c.String(nullable: false),
                        Titlegory = c.String(nullable: false),
                        DateCreate = c.DateTime(nullable: false),
                        NameCreate = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.IdGory);
            
            CreateTable(
                "dbo.CMTs",
                c => new
                    {
                        IDcmt = c.Int(nullable: false, identity: true),
                        Iduser = c.Int(nullable: false),
                        Idfilm = c.Int(nullable: false),
                        Cmt = c.String(),
                        DateCreate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.IDcmt)
                .ForeignKey("dbo.Films", t => t.Idfilm, cascadeDelete: true)
                .ForeignKey("dbo.Users", t => t.Iduser, cascadeDelete: true)
                .Index(t => t.Iduser)
                .Index(t => t.Idfilm);
            
            CreateTable(
                "dbo.Films",
                c => new
                    {
                        IdFilm = c.Int(nullable: false, identity: true),
                        NameVN = c.String(nullable: false),
                        NameF = c.String(nullable: false),
                        Status = c.String(nullable: false),
                        Director = c.String(nullable: false),
                        Nation = c.String(nullable: false),
                        Years = c.Int(nullable: false),
                        TypeFilm = c.String(nullable: false),
                        Times = c.Int(nullable: false),
                        Images = c.String(nullable: false),
                        Information = c.String(nullable: false),
                        Rating = c.Int(nullable: false),
                        DateCreate = c.DateTime(nullable: false),
                        DateUpdate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.IdFilm);
            
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        Iduser = c.Int(nullable: false, identity: true),
                        Username = c.String(nullable: false),
                        Userpassword = c.String(nullable: false),
                        Displayname = c.String(nullable: false),
                        Email = c.String(nullable: false),
                        Avatar = c.String(nullable: false),
                        DateCreate = c.DateTime(nullable: false),
                        IDrole = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Iduser)
                .ForeignKey("dbo.Roles", t => t.IDrole, cascadeDelete: true)
                .Index(t => t.IDrole);
            
            CreateTable(
                "dbo.Roles",
                c => new
                    {
                        Idrole = c.Int(nullable: false, identity: true),
                        Namerole = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Idrole);
            
            CreateTable(
                "dbo.EpisodeFilms",
                c => new
                    {
                        IdEs = c.Int(nullable: false, identity: true),
                        IdFilm = c.Int(nullable: false),
                        EsName = c.String(nullable: false),
                        EsFilm = c.Int(nullable: false),
                        EsUrl = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.IdEs)
                .ForeignKey("dbo.Films", t => t.IdFilm, cascadeDelete: true)
                .Index(t => t.IdFilm);
            
            CreateTable(
                "dbo.Film_Category",
                c => new
                    {
                        Idgory = c.Int(nullable: false),
                        Idfilm = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Idgory, t.Idfilm })
                .ForeignKey("dbo.Categories", t => t.Idgory, cascadeDelete: true)
                .ForeignKey("dbo.Films", t => t.Idfilm, cascadeDelete: true)
                .Index(t => t.Idgory)
                .Index(t => t.Idfilm);
            
            CreateTable(
                "dbo.Reports",
                c => new
                    {
                        Idreport = c.Int(nullable: false, identity: true),
                        Idfilm = c.Int(nullable: false),
                        Content = c.String(),
                        DateCreate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Idreport)
                .ForeignKey("dbo.Films", t => t.Idfilm, cascadeDelete: true)
                .Index(t => t.Idfilm);

            CreateTable(
                "dbo.Trailers",
                c => new
                    {
                        Idtrailer = c.Int(nullable: false, identity: true),
                        TrailerName = c.String(),
                        TrailerImage = c.String(),
                        TrailerUrl = c.String(),
                        Idfilm = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Idtrailer)
                .ForeignKey("dbo.Films", t => t.Idfilm, cascadeDelete: true)
                .Index(t => t.Idfilm);

        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Trailers", "Idfilm", "dbo.Films");
            DropForeignKey("dbo.Reports", "Idfilm", "dbo.Films");
            DropForeignKey("dbo.Film_Category", "Idfilm", "dbo.Films");
            DropForeignKey("dbo.Film_Category", "Idgory", "dbo.Categories");
            DropForeignKey("dbo.EpisodeFilms", "IdFilm", "dbo.Films");
            DropForeignKey("dbo.CMTs", "Iduser", "dbo.Users");
            DropForeignKey("dbo.Users", "IDrole", "dbo.Roles");
            DropForeignKey("dbo.CMTs", "Idfilm", "dbo.Films");
            DropIndex("dbo.Trailers", new[] { "Idfilm" });
            DropIndex("dbo.Reports", new[] { "Idfilm" });
            DropIndex("dbo.Film_Category", new[] { "Idfilm" });
            DropIndex("dbo.Film_Category", new[] { "Idgory" });
            DropIndex("dbo.EpisodeFilms", new[] { "IdFilm" });
            DropIndex("dbo.Users", new[] { "IDrole" });
            DropIndex("dbo.CMTs", new[] { "Idfilm" });
            DropIndex("dbo.CMTs", new[] { "Iduser" });
            DropTable("dbo.Trailers");
            DropTable("dbo.Reports");
            DropTable("dbo.Film_Category");
            DropTable("dbo.EpisodeFilms");
            DropTable("dbo.Roles");
            DropTable("dbo.Users");
            DropTable("dbo.Films");
            DropTable("dbo.CMTs");
            DropTable("dbo.Categories");
        }
    }
}
