namespace Pluto.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialModelling : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Authors",
                c => new
                    {
                        AuthorID = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.AuthorID);
            
            CreateTable(
                "dbo.Courses",
                c => new
                    {
                        CourseID = c.Int(nullable: false, identity: true),
                        Title = c.String(),
                        Description = c.String(),
                        Price = c.Single(nullable: false),
                        Author_AuthorID = c.Int(),
                        Tag_TagID = c.Int(),
                    })
                .PrimaryKey(t => t.CourseID)
                .ForeignKey("dbo.Authors", t => t.Author_AuthorID)
                .ForeignKey("dbo.Tags", t => t.Tag_TagID)
                .Index(t => t.Author_AuthorID)
                .Index(t => t.Tag_TagID);
            
            CreateTable(
                "dbo.Tags",
                c => new
                    {
                        TagID = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.TagID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Courses", "Tag_TagID", "dbo.Tags");
            DropForeignKey("dbo.Courses", "Author_AuthorID", "dbo.Authors");
            DropIndex("dbo.Courses", new[] { "Tag_TagID" });
            DropIndex("dbo.Courses", new[] { "Author_AuthorID" });
            DropTable("dbo.Tags");
            DropTable("dbo.Courses");
            DropTable("dbo.Authors");
        }
    }
}
