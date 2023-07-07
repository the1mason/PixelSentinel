using FluentMigrator;

namespace ServerIndex.Data.Migrations;
[Migration(202307062015, "Added score modifiers")]
public class V202307062015AddScoreModifiers : Migration
{
    public override void Up()
    {
        Create.Table("Modifier")
            .WithColumn("Id").AsInt32().PrimaryKey().Unique().Identity()
            .WithColumn("DefaultValue").AsInt16().Nullable()
            .WithColumn("Name").AsString(64).NotNullable()
            .WithColumn("Description").AsString(512).Nullable();

        Create.Table("ServerModifier")
            .WithColumn("Id").AsInt64().PrimaryKey().Unique().Identity()
            .WithColumn("ServerId").AsInt64().NotNullable().ForeignKey("Server", "Id")
            .WithColumn("ModifierId").AsInt32().NotNullable().ForeignKey("Modifier", "Id")
            .WithColumn("Value").AsInt16().NotNullable();
    }
    public override void Down()
    {
        Delete.Table("Modifier");
        Delete.Table("ServerModifier");
    }
}
