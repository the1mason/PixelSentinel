using FluentMigrator;

namespace ServerIndex.Data.Migrations;
[Migration(202306260010, "AddWebServicesDatabase")]
public class V202306260010AddWebServicesDatabase : Migration
{
    public override void Up()
    {
        Alter.Table("Server")
            .AddColumn("Score").AsInt32();

        Create.Table("MasScanHistory")
            .WithColumn("Id").AsInt64().PrimaryKey().Unique().Identity()
            .WithColumn("Range").AsString(512).NotNullable()
            .WithColumn("StartedServing").AsBoolean().NotNullable().WithDefaultValue(false)
            .WithColumn("Served").AsBoolean().NotNullable().WithDefaultValue(false)
            .WithColumn("Date").AsDateTime().NotNullable().WithDefault(SystemMethods.CurrentDateTime);
    }
    public override void Down()
    {
        Delete.Column("Score").FromTable("Server");
        Delete.Table("MasScanHistory");
    }
}
