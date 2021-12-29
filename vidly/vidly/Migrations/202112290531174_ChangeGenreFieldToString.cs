namespace vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChangeGenreFieldToString : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Movies", "Genre", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Movies", "Genre", c => c.Int(nullable: false));
        }
    }
}
