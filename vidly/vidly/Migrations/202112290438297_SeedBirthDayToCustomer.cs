namespace vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SeedBirthDayToCustomer : DbMigration
    {
        public override void Up()
        {
            Sql("Update Customers Set BirthDate = CAST('1990-03-01' as datetime) where Id = 2");
            Sql("Update Customers Set BirthDate = CAST('1997-10-01' as datetime) where Id = 3");
        }
        
        public override void Down()
        {
        }
    }
}
