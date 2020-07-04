using System;
using System.Collections.Generic;
using System.Text;
using FluentMigrator;

namespace DDD.Data.DAL.NH.Migrator
{
    [Migration(202006301200)]
    public class _202006301200_inicial : Migration
    {
        public override void Up()
        {
            Create.Table("TBGames")
                .WithColumn("Id").AsGuid().NotNullable().PrimaryKey()
                .WithColumn("Name").AsString(size: 100).NotNullable()
                .WithColumn("Description").AsString(size: 250).NotNullable()
                .WithColumn("Price").AsDecimal().NotNullable();
        }

        public override void Down()
        {
            Delete.Table("TBGames");
        }
    }
}
