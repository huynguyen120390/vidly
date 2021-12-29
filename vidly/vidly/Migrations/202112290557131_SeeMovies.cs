namespace vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SeeMovies : DbMigration
    {
        public override void Up()
        {
            Sql("Set identity_insert Movies on");
            //Sql(
            //    "INSERT INTO Movies(Id, Name, ReleaseDate, DateAdded, NumberInStock, GenreId) VALUES(1, 'Concobebe', Cast('2020-10-20' as datetime), Cast('2020-10-21' as datetime), 10, 1)");
            Sql(
                "INSERT INTO Movies(Id, Name, ReleaseDate, DateAdded, NumberInStock, GenreId) VALUES(2, 'Concobebe1', Cast('2020-10-20' as datetime), Cast('2020-10-21' as datetime), 10, 2)");
            Sql(
                "INSERT INTO Movies(Id, Name, ReleaseDate, DateAdded, NumberInStock, GenreId) VALUES(3, 'Concobebe2', Cast('2020-10-20' as datetime), Cast('2020-10-21' as datetime), 10, 3)");
            Sql(
                "INSERT INTO Movies(Id, Name, ReleaseDate, DateAdded, NumberInStock, GenreId) VALUES(4, 'Concobebe3', Cast('2020-10-20' as datetime), Cast('2020-10-21' as datetime), 10, 4)");

        }
        
        public override void Down()
        {
        }
    }
}
