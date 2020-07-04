using System;
using System.Collections.Generic;
using System.Text;
using FluentMigrator;

namespace DDD.Data.DAL.NH.Migrator
{
    [Migration(2020063001342)]
    public class _2020063001342_Gender : Migration
    {
        public override void Up()
        {
            Create.Table("TBGender")
                .WithColumn("Id").AsGuid().NotNullable().PrimaryKey()
                .WithColumn("Name").AsString(size: 100).NotNullable();
        }
        public override void Down()
        {
            Delete.Table("TBGender");
        }

        
    }
}
