using FluentMigrator;

namespace ServerIndex.Data.Migrations;
[Migration(202307070110, "Added score modifiers")]
public class V202307070110AddServerTagTagForeignKey : Migration
{
    public override void Up()
    {
        Alter.Table("ServerTag")
            .AlterColumn("TagName")
                .AsString(32)
                .NotNullable()
                .ForeignKey("Tag", "Name");
    }
    public override void Down()
    {
        Delete.ForeignKey()
            .FromTable("ServerTag")
            .ForeignColumn("TagName");
    }
}
