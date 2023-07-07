using FluentMigrator;

namespace ServerIndex.Data.Migrations;
[Migration(202306220000, "Initial Create")]
public class V202306220000InitialCreate : Migration
{
    public override void Up()
    {
        Create.Table("Server")
            .WithColumn("Id").AsInt64().PrimaryKey().Unique().Identity()
            .WithColumn("Displayname").AsString(128).Nullable()
            .WithColumn("Version").AsDateTime().NotNullable().WithDefault(SystemMethods.CurrentUTCDateTime)
            .WithColumn("Icon").AsBinary(82000).Nullable()
            .WithColumn("ShortDescription").AsString(128).Nullable()
            .WithColumn("LongDescription").AsString(2048).Nullable()
            .WithColumn("PlayerCount").AsInt32().Nullable()
            .WithColumn("Address").AsInt64().NotNullable()
            .WithColumn("DomainName").AsString(512).Nullable()
            .WithColumn("GameVersion").AsString(16).Nullable()
            .WithColumn("Website").AsString(256).Nullable()
            .WithColumn("LastMetadata").AsCustom("json").Nullable();

        Create.Table("Role")
            .WithColumn("Id").AsInt32().PrimaryKey().Unique().Identity()
            .WithColumn("Name").AsString(16).Unique().NotNullable()
            .WithColumn("UserPermissions").AsInt64().NotNullable()
            .WithColumn("AdminPermissions").AsInt64().NotNullable();

        Create.Table("User")
            .WithColumn("Id").AsInt64().PrimaryKey().Unique().Identity()
            .WithColumn("Email").AsString(320).Unique().NotNullable()
            .WithColumn("Password").AsString(96).NotNullable()
            .WithColumn("DsplayName").AsString(24).Nullable()
            .WithColumn("RoleId").AsInt32().ForeignKey("Role", "Id").NotNullable();

        Create.Table("Session")
            .WithColumn("Token").AsString(128).PrimaryKey().Unique()
            .WithColumn("Version").AsDateTime().NotNullable().WithDefault(SystemMethods.CurrentUTCDateTime)
            .WithColumn("Revoked").AsBoolean().NotNullable().WithDefaultValue(false);

        Create.Table("UserSession")
            .WithColumn("Id").AsInt64().PrimaryKey().Unique().Identity()
            .WithColumn("UserId").AsInt64().ForeignKey("User", "Id").NotNullable()
            .WithColumn("SessionToken").AsString(128).ForeignKey("Session", "Token").NotNullable()
            .WithColumn("Displayname").AsString(32).Nullable()
            .WithColumn("Address").AsInt64().NotNullable();

        Create.Table("UserServer")
            .WithColumn("Id").AsInt64().PrimaryKey().Unique().Identity()
            .WithColumn("UserId").AsInt64().ForeignKey("User", "Id").NotNullable()
            .WithColumn("ServerId").AsInt64().ForeignKey("Server", "Id").NotNullable()
            .WithColumn("Permissions").AsInt64().NotNullable();

        Create.Table("Tag")
            .WithColumn("Name").AsString(32).PrimaryKey().Unique()
            .WithColumn("DisplayName").AsString(32).Unique().NotNullable()
            .WithColumn("Data").AsCustom("json").Nullable()
            .WithColumn("IsVisible").AsBoolean().NotNullable();

        Create.Table("ServerTag")
            .WithColumn("Id").AsInt64().PrimaryKey().Unique().Identity()
            .WithColumn("ServerId").AsInt64().ForeignKey("Server", "Id").NotNullable()
            .WithColumn("TagName").AsString(32).NotNullable()
            .WithColumn("Order").AsInt64();

        Create.Table("ServerReaction")
            .WithColumn("Id").AsInt64().PrimaryKey().Unique().Identity()
            .WithColumn("UserId").AsInt64().ForeignKey("User", "Id").Nullable()
            .WithColumn("ServerId").AsInt64().ForeignKey("Server", "Id").NotNullable()
            .WithColumn("Type").AsInt64().NotNullable();

        Create.Table("AnalyticServer")
            .WithColumn("Id").AsInt64().PrimaryKey().Unique().Identity()
            .WithColumn("Type").AsInt64().NotNullable()
            .WithColumn("Data").AsCustom("json").Nullable()
            .WithColumn("ServerId").AsInt64().ForeignKey("Server", "Id").NotNullable();

        Create.Table("Settings")
            .WithColumn("Key").AsString(32).PrimaryKey().Unique()
            .WithColumn("Value").AsString(2048).Nullable()
            .WithColumn("Version").AsDateTime().NotNullable().WithDefault(SystemMethods.CurrentUTCDateTime);
    }
    public override void Down()
    {
        Delete.Table("Server");

        Delete.Table("Role");

        Delete.Table("User");

        Delete.Table("Session");

        Delete.Table("UserSession");

        Delete.Table("UserServer");

        Delete.Table("Tag");

        Delete.Table("ServerTag");

        Delete.Table("ServerReaction");

        Delete.Table("AnalyticServer");

        Delete.Table("Settings");
    }
}
