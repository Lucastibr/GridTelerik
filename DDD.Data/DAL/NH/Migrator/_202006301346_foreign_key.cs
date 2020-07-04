using FluentMigrator;

namespace DDD.Data.DAL.NH.Migrator
{
    [Migration(202006301346)]
    public class _202006301346_foreign_key : Migration
    {
        public override void Up()
        {
            Alter.Table("TBGames")
                .AddColumn("Gender_Id").AsGuid().Nullable().ForeignKey("FK_TBGames_Gender_Id", "TBGender", "Id");
        }

        public override void Down()
        {
            
        }
    }
}
